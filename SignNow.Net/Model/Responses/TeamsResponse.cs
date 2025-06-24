using System.Collections.Generic;
using Newtonsoft.Json;

namespace SignNow.Net.Model.Responses
{
    public class TeamsResponse
    {
        [JsonProperty("data")]
        public List<Team> Data { get; set; }

        [JsonProperty("meta")]
        public MetaInfo Meta { get; set; }
    }
}
