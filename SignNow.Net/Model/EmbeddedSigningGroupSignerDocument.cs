using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SignNow.Net.Model
{
    public class EmbeddedSigningGroupSignerDocument
    {
        /// <summary>
        /// Recipient's role name in the document (can be used to identify fields in the document assigned to this particular recipient).
        /// </summary>
        [JsonProperty("role")]
        public string RoleName { get; set; }

        /// <summary>
        /// What kind of action is required. Possible values "sign", "view".
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionType Action { get; set; }

        /// <summary>
        /// ID of the document on which actions are required from this recipient.
        /// </summary>
        [JsonProperty("id")]
        public string DocumentId { get; set; }
    }
}
