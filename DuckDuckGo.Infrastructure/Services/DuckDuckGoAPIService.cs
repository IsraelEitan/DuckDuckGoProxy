using DuckDuckGo.Application.Exceptions;
using DuckDuckGo.Application.Interfaces;
using DuckDuckGo.Application.Models;
using DuckDuckGo.Infrastructure.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace DuckDuckGo.Infrastructure.Services
{
    public class DuckDuckGoAPIService : IDuckDuckGoAPIService
    {
        private static readonly HttpClient client;
      
        static DuckDuckGoAPIService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("http://api.duckduckgo.com")
            };
        }

        public async Task<List<RelatedTopic>> GetRelatedTopics(string queryParam)
        {
            var url = $"/?q={queryParam}&format=json";

            var relatedTopicList = new List<RelatedTopic>();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                dynamic duckDuckGoJSONObject = JsonConvert.DeserializeObject<ExpandoObject>(stringResponse, new ExpandoObjectConverter());

                ((List<dynamic>)duckDuckGoJSONObject.RelatedTopics).ForEach(item =>
                {
                    var epItem = (IDictionary<String, object>)item;
                    if (epItem.ContainsKey("Name"))
                    {
                        var topics = (IEnumerable<dynamic>)epItem["Topics"];
                        relatedTopicList.AddRange(topics.Select(rt => new RelatedTopic()
                        {
                            FirstURL = rt.FirstURL,
                            Title = epItem["Name"].ToString()
                        }));
                    }
                    else
                    {
                        relatedTopicList.Add(new RelatedTopic()
                        {
                            FirstURL = epItem["FirstURL"].ToString(),
                            Title = "Related Topic"
                        });
                    }
                });

            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return relatedTopicList;
        }

        public async Task SaveUserQueries(List<UserQuery> queries)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\userQueries.txt";

            try
            {
                using (var fileStream = File.Create(path))
                {
                    await JsonExtensions.ToJsonAsync(queries, fileStream);
                }
            }
            catch
            {
                throw new HttpStatusException(HttpStatusCode.InternalServerError, "Operation failed, please contact us...");
            }
           
        }

        public async Task<List<UserQuery>> GetUserQueries()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + @"\userQueries.txt";
            List<UserQuery> result = null;

            try
            {
                using (var fileStream = File.OpenRead(path))
                {
                    result = await JsonExtensions.FromJsonAsync<List<UserQuery>>(fileStream);
                }
            }
            catch
            {
                // Log Exception for iternal use
            }
           
            return result;
        }
    }
}