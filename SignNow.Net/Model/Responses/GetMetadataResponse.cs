using Newtonsoft.Json;

namespace SignNow.Net.Model.Responses
{
    public class GetMetadataResponse
    {
        [JsonProperty("content")]
        public DocumentMetadata DocumentMetadata { get; set; }

        [JsonProperty("application_id")]

        public string ApplicationId { get; set; }

        [JsonProperty("updated")]

        public string Updated { get; set; }
    }
}
