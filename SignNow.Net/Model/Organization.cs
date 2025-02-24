using Newtonsoft.Json;
using SignNow.Net.Model.Responses.GenericResponses;

namespace SignNow.Net.Model
{
    public class Organization : IdResponse
    {
        [JsonProperty("success")]
        public override bool Success { get; set; } = true;
    }
}
