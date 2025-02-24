using System.Collections.Generic;
using Newtonsoft.Json;

namespace SignNow.Net.Model.Responses.GenericResponses
{
    public class SingleError
    {
        [JsonProperty("error")]
        public string ErrorMessage { get; set; }

        [JsonProperty("code")]
        public string ErrorCode { get; set; }
    }

    /// <summary>
    /// Represents response from signNow API with identity of the signNow object.
    /// </summary>
    public abstract class IdResponse: SingleError
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("success")]
        public virtual bool Success { get; set; }

        [JsonProperty("errors")]
        public List<SingleError> Errors { get; set; }
    }
}
