using Newtonsoft.Json;

namespace DuckDuckGo.Application.Models
{
    public class Icon
    {
        [JsonProperty("Height")]
        public string Height { get; set; }

        [JsonProperty("URL")]
        public string URL { get; set; }

        [JsonProperty("Width")]
        public string Width { get; set; }
    }
}
