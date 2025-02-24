using System.Collections.Generic;
using Newtonsoft.Json;

namespace SignNow.Net.Model
{
    public class EmailAddress
    {
        /// <summary>
        /// Email address in the signing group. Must be unique within a group.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public class EmailGroup
    {
        /// <summary>
        /// Signing group ID. If you created your own ID, make sure that it's 40 characters long.
        /// </summary>
        [JsonProperty("id")]
        public string Id {  get; set; }

        /// <summary>
        /// Signing group name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// List all the email addresses that should receive an invite within a group, no matter if you are using an existing email group or a new one.
        /// </summary>
        [JsonProperty("emails")]
        public List<EmailAddress> Emails { get; set; }
    }
}
