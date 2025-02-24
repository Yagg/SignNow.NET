using Newtonsoft.Json;

namespace SignNow.Net.Model
{
    public class CompletionEmailOption
    {
        /// <summary>
        /// Email address of the completion email recipient.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Whether to disable sending document attachments with the completion email. Possible values: 0 - enable document attachment, 1 - disable document attachment.
        /// </summary>
        [JsonProperty("disable_document_attachment")]
        public string DisableDocumentAttachment { get; set; }

        /// <summary>
        /// Custom subject for the completion email.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Custom message for the completion email.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }
    }
}
