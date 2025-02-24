using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Newtonsoft.Json;

namespace SignNow.Net.Model
{
    public class WebhookPayloadContent
    {
        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }

        [JsonProperty("document_id")]
        public string DocumentId { get; set; }

        [JsonProperty("document_name")]
        public string DocumentName { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }

    public class WebhookMetadata
    {
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("initiator_id")]
        public string InitiatorId { get; set; }

        [JsonProperty("metadata")]
        public DocumentMetadata Metadata { get; set; }
    }

    public class WebhookPayload
    {
        [JsonProperty("meta")]
        public WebhookMetadata Meta { get; set; }

        [JsonProperty("content")]
        public WebhookPayloadContent Content { get; set; }

        public static WebhookPayload FromStream(Stream stream)
        {
            using (var tr = new StreamReader(stream))
            {
                var strResp = tr.ReadToEnd();
                if (string.IsNullOrEmpty(strResp))
                {
                    return null;
                }
                else
                {
                    return JsonConvert.DeserializeObject<WebhookPayload>(strResp);
                }
            }
        }
    }
}
