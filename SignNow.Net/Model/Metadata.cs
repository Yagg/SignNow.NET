using Newtonsoft.Json;
using SignNow.Net.Model.Requests;

namespace SignNow.Net.Model
{
    public class DocumentMetadata: JsonHttpContent
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("key1")]
        public string Key1 { get; set; }

        [JsonProperty("key2")]
        public string Key2 { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public class DocumentGroupMetadata: JsonHttpContent
    {
        [JsonProperty("content")]
        public DocumentMetadata Metadata { get; set; } = new DocumentMetadata();
    }
}
