using System.Collections.Generic;
using Newtonsoft.Json;

namespace SignNow.Net.Model.Responses
{
    public class EditDocGroupRecepientsResponse
    {
        [JsonProperty("data")]
        public EditDocGroupRecepientsData Data { get; set; }
    }

    public class EditDocGroupRecepientsData
    {
        [JsonProperty("recipients")]
        public List<EditDocGroupRecipient> Recipients { get; set; }

        [JsonProperty("allowed_unmapped_sign_documents")]
        public List<string> AllowedUnmappedSignDocuments { get; set; }

        [JsonProperty("cc")]
        public List<string> Cc { get; set; }
    }

    public class EditDocGroupRecipient
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone_invite")]
        public string PhoneInvite { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("attributes")]
        public EditDocGroupRecipientAttributes Attributes { get; set; }

        [JsonProperty("documents")]
        public List<EditDocGroupRecipientDocument> Documents { get; set; }
    }

    public class EditDocGroupRecipientAttributes
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("expiration_days")]
        public int? ExpirationDays { get; set; }

        [JsonProperty("allow_forwarding")]
        public bool? AllowForwarding { get; set; }

        [JsonProperty("show_decline_button")]
        public bool? ShowDeclineButton { get; set; }

        [JsonProperty("i_am_recipient")]
        public bool? IAmRecipient { get; set; }

        [JsonProperty("authentication")]
        public EditDocGroupRecipientAuthentication Authentication { get; set; }

        [JsonProperty("reminder")]
        public ReminderOptions Reminder { get; set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonProperty("decline_redirect_uri")]
        public string DeclineRedirectUri { get; set; }

        [JsonProperty("close_redirect_uri")]
        public string CloseRedirectUri { get; set; }
    }

    public class EditDocGroupRecipientAuthentication
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }


    public class EditDocGroupRecipientDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }
    }
}
