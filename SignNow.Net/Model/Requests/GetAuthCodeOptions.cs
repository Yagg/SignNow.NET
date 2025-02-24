using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SignNow.Net.Interfaces;

namespace SignNow.Net.Model.Requests
{
    internal class GetAuthCodeOptions : IQueryToString
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("response_type")]
        public string ResponseType { get; set; } = "code";

        public string ToQueryString()
        {
            var filters = JsonConvert.SerializeObject(this);

            var toDictionary = JsonConvert.DeserializeObject<IDictionary<string, string>>(filters);

            if (toDictionary == null)
                return string.Empty;

            var query = toDictionary
                .Select(k => $"{k.Key}={k.Value}");

            return string.Join("&", query);
        }


    }
}
