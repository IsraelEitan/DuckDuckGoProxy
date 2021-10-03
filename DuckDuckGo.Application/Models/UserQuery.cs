using Newtonsoft.Json;
using System;

namespace DuckDuckGo.Application.Models
{
    public class UserQuery
    {
        [JsonProperty("queryParam")]
        public string QueryParam { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get;set; }

    }
}
