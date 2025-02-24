using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SignNow.Net.Internal.Extensions;
using SignNow.Net.Internal.Helpers;
using SignNow.Net.Model.Requests;

namespace SignNow.Net.Model
{
    public class GroupInvite : JsonHttpContent
    {
        /// <summary>
        /// The subject of the CC email.
        /// <remarks>
        ///     If <see cref="CCSubject"/> is null - default subject will be used:
        ///     `sender.email@signnow.com` Needs Your Signature
        /// </remarks>
        /// </summary>
        [JsonProperty("cc_subject")]
        public string CCSubject { get; set; }

        /// <summary>
        /// The message body of the CC email invite.
        /// <remarks>
        ///     If <see cref="CCMessage"/> is null - default message will be used:
        ///     `sender.email@signnow.com` invited you to sign `DocumentName`
        /// </remarks>
        /// </summary>
        [JsonProperty("cc_message")]
        public string CCMessage { get; set; }

        /// <summary>
        /// The list with emails of copy receivers.
        /// </summary>
        [JsonProperty("cc", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> Cc => CcList;

        /// <summary>
        /// Steps of the Document group invite. Every step contains the order number, invite_emails and invite_actions within this step.
        /// </summary>
        [JsonProperty("invite_steps")]
        public List<GroupInviteStep> InviteSteps { get; set; } = new List<GroupInviteStep>();

        /// <summary>
        /// Defines a signing group. Required if at least one step contains a signing group (email_group). You can use both an existing email group or create your own.
        /// </summary>
        [JsonProperty("email_groups")]
        public List<EmailGroup> EmailGroups { get; set; }

        /// <summary>
        /// Object that contains email addresses and custom settings for sending emails about completing the invite.
        /// </summary>
        [JsonProperty("completion_emails")]
        public List<CompletionEmailOption> CompletionEmails { get; set; }

        /// <summary>
        /// If true, allows API user to send an invite which opens as merged document group in a single document.
        /// </summary>
        [JsonProperty("sign_as_merged")]
        public bool SignAsMerged { get; set; } = true;

        [JsonIgnore]
        protected HashSet<string> CcList { get; } = new HashSet<string>();

        /// <summary>
        /// Add an Email to CC list.
        /// </summary>
        /// <param name="email">Email of copy receiver.</param>
        /// <exception cref="ArgumentException">when an email is not valid.</exception>
        public void AddCcRecipients(string email)
        {
            CcList.Add(email.ValidateEmail());
        }

        /// <inheritdoc cref="AddCcRecipients(string)"/>
        /// <param name="emails">Emails list of copy receivers.</param>
        public void AddCcRecipients(IEnumerable<string> emails)
        {
            Guard.ArgumentNotNull(emails, nameof(emails));
            foreach (var email in emails)
            {
                AddCcRecipients(email);
            }
        }
    }

}
