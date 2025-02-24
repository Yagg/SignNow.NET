using Newtonsoft.Json;
using SignNow.Net.Model.Responses.GenericResponses;

namespace SignNow.Net.Model.Responses
{
    public class FolderIdentityResponse : IdResponse
    {
        [JsonProperty("success")]
        public override bool Success { get; set; } = true;
    }
}
