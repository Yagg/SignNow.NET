using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SignNow.Net.Internal.Helpers;
using SignNow.Net.Internal.Helpers.Converters;

namespace SignNow.Net.Model
{
    /// <summary>
    /// Kind of action is required for group invite. 
    /// </summary>
    public enum ActionType
    {
        [EnumMember(Value = "sign")]
        Sign,

        [EnumMember(Value = "view")]
        View
    }

    public interface IGroupInviteBase
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_group")]
        public EmailGroup EmailGroup { get; set; }
    }

    /// <summary>
    /// Objects that define custom email subject, email message, expiration and reminder settings for each recipient within a step.
    /// </summary>
    public interface IGroupInviteOption: IGroupInviteBase
    {
        /// <summary>
        /// Custom email subject for the recipient.
        /// </summary>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Custom email message for the recipient.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// In x days, the invite expires
        /// </summary>
        [JsonProperty("expiration_days")]
        public int ExpirationDays { get; set; }

        [JsonProperty("reminder", NullValueHandling = NullValueHandling.Ignore)]
        public ReminderOptions Reminder { get; set; }
    }

    /// <summary>
    /// Objects that define recipients (email addresses or signing groups) and invite actions, roles and documents assigned to each recipient within a step.
    /// </summary>
    public interface IGroupInviteAction: IGroupInviteBase
    {
        /// <summary>
        /// Recipient's role name in the document (can be used to identify fields in the document assigned to this particular recipient).
        /// </summary>
        [JsonProperty("role_name")]
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
        [JsonProperty("document_id")]
        public string DocumentId {  get; set; }

        /// <summary>
        /// Presets the signature name for the role and disables the ability to change the signature.
        /// </summary>
        [JsonProperty("required_preset_signature_name")]
        public string RequiredPresetSignatureName {  get; set; }

        /// <summary>
        /// Whether or not to allow recipients reassign this invite to another email address. Possible values: "0" - not allowed, "1" - allowed.
        /// </summary>
        [JsonProperty("allow_reassign", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BoolToIntJsonConverter))]
        public bool? AllowReassign { get; set; }

        /// <summary>
        /// Whether or not to allow recipients decline to sign the invite.
        /// </summary>
        [JsonProperty("decline_by_signature", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(BoolToIntJsonConverter))]
        public bool? DeclineBySignature { get; set; }

        /// <summary>
        /// Object that contains the type of signer's identity verification, phone number or password.
        /// </summary>
        [JsonProperty("authentication")]
        public SignerAuthentication Authentication { get; set; }

        /// <summary>
        /// Object that contains the type of signer's identity verification, phone number or password.
        /// </summary>
        [JsonProperty("payment_request")]
        public InvitePaymentRequest PaymentRequest { get; set; }

        /// <summary>
        /// When all the requested fields are completed and signed, the signer is redirected to this URI.
        /// </summary>
        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; set; }

        /// <summary>
        /// The link that opens after the signing session has been declined by the signer.
        /// </summary>
        [JsonProperty("decline_redirect_uri")]
        public string DeclineRedirectUri { get; set; }

        /// <summary>
        /// Determines whether to open the redirect link in the new tab in the browser, or in the same tab after the signing session.
        /// Possible values: blank - opens the link in the new tab, self - opens the link in the same tab.
        /// </summary>
        [JsonProperty("redirect_target", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public RedirectTarget? RedirectTarget { get; set; }

        /// <summary>
        /// Sets the language of the signing session and notification emails for the signer.
        /// Possible values: en for English, es for Spanish, and fr for French. If not set, the language is determined by
        /// the language of your signNow account. If emails are branded, you can set up your own email texts in different languages.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// The link that opens after a signer selects the Close button. One signer or viewer cannot have different close redirect URLs within one invite step.
        /// </summary>
        [JsonProperty("close_redirect_uri")]
        public string CloseRedirectUri { get; set; }

        /// <summary>
        /// This object is used to request QES signatures from signers. To use it, a user must be a member of an organization
        /// with QES settings enabled. If QES is used, it must be used for all signers in the invite.
        /// For more information, see QES user guide.
        /// </summary>
        [JsonProperty("signature")]
        public SignatureOption Signature { get; set; }
    }


    public class GroupInviteEmail: IGroupInviteOption
    {
        // IGroupInviteBase
        public string Email { get; set; }
        public EmailGroup EmailGroup { get; set; }
        // IGroupInviteOption
        public string Subject { get; set; }
        public string Message { get; set; }
        public int ExpirationDays { get; set; }
        public ReminderOptions Reminder { get; set; }
    }

    public class GroupInviteAction : IGroupInviteAction
    {
        // IGroupInviteBase
        public string Email { get; set; }
        public EmailGroup EmailGroup { get; set; }

        // IGroupInviteAction
        public string RoleName { get; set; }
        public ActionType Action { get; set; } = ActionType.Sign;
        public string DocumentId { get; set; }
        public string RequiredPresetSignatureName { get; set; }
        public bool? AllowReassign { get; set; }
        public bool? DeclineBySignature { get; set; }
        public SignerAuthentication Authentication { get; set; }
        public InvitePaymentRequest PaymentRequest { get; set; }
        public string RedirectUri { get; set; }
        public string DeclineRedirectUri { get; set; }
        public RedirectTarget? RedirectTarget { get; set; }
        public string Language { get; set; }
        public string CloseRedirectUri { get; set; }
        public SignatureOption Signature { get; set; }

    }

    /// <summary>
    /// Step of the Document group invite. Every step contains the order number, invite_emails and invite_actions within this step.
    /// </summary>
    public class GroupInviteStep
    {
        [JsonProperty("order")]
        public int Order { get; set; } = 1;

        [JsonProperty("invite_emails")]
        public IEnumerable<IGroupInviteOption> InviteEmails => GroupInviteEmails;

        [JsonProperty("invite_actions")]
        public IEnumerable<IGroupInviteAction> InviteActions => GroupInviteAction;

        [JsonIgnore]
        public List<GroupInviteAction> GroupInviteAction { get; internal set; } = new List<GroupInviteAction>();

        [JsonIgnore]
        public List<GroupInviteEmail> GroupInviteEmails { get; internal set; } = new List<GroupInviteEmail>();

        public void AddInviteAction(GroupInviteEmail email, GroupInviteAction action)
        {
            Guard.ArgumentNotNull(action, nameof(action));
            Guard.PropertyNotNull(action.RoleName, nameof(action.RoleName));
            Guard.PropertyNotNull(action.Email, nameof(action.Email));
            Guard.PropertyNotNull(action.DocumentId, nameof(action.DocumentId));

            GroupInviteAction.Add(action);
            GroupInviteEmails.Add(email);
        }
    }
}
