using Newtonsoft.Json;
using SignNow.Net.Model.Responses.GenericResponses;

namespace SignNow.Net.Model.Responses
{
    /// <summary>
    /// Represents response from signNow API for Create Template from Document request.
    /// </summary>
    [JsonObject]
    public class CreateTemplateFromDocumentResponse : IdResponse
    {
        [JsonProperty("success")]
        public override bool Success { get; set; } = true;
    }
}
