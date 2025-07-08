using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SignNow.Net.Model.Responses;

namespace SignNow.Net.Model.Requests
{
    public class EditDocGroupRecepientsRequest: JsonHttpContent
    {
        [JsonProperty("recipients")]
        public List<EditDocGroupRecipient> Recipients { get; set; }

        [JsonProperty("cc")]
        public List<string> Cc { get; set; }
    }

}
