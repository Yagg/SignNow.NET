using Newtonsoft.Json;
using SignNow.Net.Model.Requests;

namespace SignNow.Net.Internal.Requests
{
    public class CreateSigningLinkRequest : JsonHttpContent
    {
        [JsonProperty("document_id")]
        public string DocumentId { get; set; }
    }
}
