using System.Collections.Generic;
using Newtonsoft.Json;

namespace SignNow.Net.Model.Responses
{
    public class CompletedFieldResponse
    {
        [JsonProperty("data")]
        public List<CompletedField> Data { get; set; }

        [JsonProperty("meta")]
        public MetaInfo Meta { get; set; }
    }
}
