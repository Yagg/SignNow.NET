using Newtonsoft.Json;
using SignNow.Net.Model.Responses.GenericResponses;

namespace SignNow.Net.Model
{
    /// <summary>
    /// Represents response from signNow API for upload document request.
    /// </summary>
    public class UploadDocumentResponse : IdResponse
    {
        [JsonProperty("success")]
        public override bool Success { get; set; } = true;
    }
}
