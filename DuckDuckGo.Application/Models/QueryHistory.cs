
using Newtonsoft.Json;

namespace DuckDuckGo.Application.Models
{
    public class QueryHistory
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

    }
}