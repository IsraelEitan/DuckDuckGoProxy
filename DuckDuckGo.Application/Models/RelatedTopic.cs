using Newtonsoft.Json;

namespace DuckDuckGo.Application.Models
{
    public class RelatedTopic
    {
        [JsonProperty("FirstURL")]
        public string FirstURL { get; set; }
        public string Title { get; set; }
     
    }
}