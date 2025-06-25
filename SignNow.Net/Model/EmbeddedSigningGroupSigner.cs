using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SignNow.Net.Exceptions;
using SignNow.Net.Internal.Extensions;
using SignNow.Net.Internal.Helpers;
using SignNow.Net.Internal.Helpers.Converters;
using SignNow.Net.Model.Requests;
using SignNow.Net.Model.Responses;

namespace SignNow.Net.Model
{
    public class EmbeddedSigningGroupSigner
    {
        private string email { get; set; }
        private string requiredPresetSignatureName { get; set; }

        /// <summary>
        /// Prefilled text in the Signature field, disabled for editing by signer.
        /// Cannot be used together with prefill_signature_name and/or force_new_signature.
        /// </summary>
        private bool isPrefilledSignatureName { get; set; }

        /// <summary>
        /// Signer's email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email
        {
            get { return email; }
            set { email = value.ValidateEmail(); }
        }

        /// <summary>
        /// Signer authentication method.
        /// </summary>
        [JsonProperty("auth_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EmbeddedAuthType AuthMethod { get; set; } = EmbeddedAuthType.None;

        /// <summary>
        /// Signer's first name.
        /// </summary>
        [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Firstname { get; set; }

        /// <summary>
        /// Signer's last name.
        /// </summary>
        [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Lastname { get; set; }

        /// <summary>
        /// Prefilled text in the Signature field, disabled for editing by signer.
        /// </summary>
        /// <exception cref="ArgumentException">Cannot be used together with prefill for Signature name</exception>
        [JsonProperty("required_preset_signature_name", NullValueHandling = NullValueHandling.Ignore)]
        public string RequiredPresetSignatureName
        {
            get { return requiredPresetSignatureName; }
            set
            {
                if (isPrefilledSignatureName)
                {
                    throw new ArgumentException(
                        "Prefill for Signature name or Force new signature is set. Cannot be used together with",
                        nameof(RequiredPresetSignatureName));
                }

                requiredPresetSignatureName = value;
            }
        }

        /// <summary>
        /// The link that opens after the signing session has been completed.
        /// </summary>
        [JsonProperty("redirect_uri", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringToUriJsonConverter))]
        public Uri RedirectUrl { get; set; }

        /// <summary>
        /// The link that opens after the signing session has been declined by the signer.
        /// </summary>
        [JsonProperty("decline_redirect_uri", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringToUriJsonConverter))]
        public Uri DeclineRedirectUrl { get; set; }

        /// <summary>
        /// Determines whether to open the redirect link in the new tab in the browser, or in the same tab after the signing session.
        /// Possible values: blank - opens the link in the new tab, self - opens the link in the same tab, default value.
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
        /// Defines how the invite is sent.
        /// </summary>
        [JsonProperty("delivery_type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public EmbeddedLinkDeliveryType? DeliveryType { get; set; }

        /// <summary>
        /// In how many minutes the email invite expires. Can be used only if delivery_type=email.
        /// </summary>
        [JsonProperty("link_expiration", NullValueHandling = NullValueHandling.Ignore)]
        public int? LinkExpiration { get; set; }

        /// <summary>
        /// This object is used to request QES signatures from signers. To use it, a user must be a member of an organization
        /// with QES settings enabled. If QES is used, it must be used for all signers in the invite.
        /// For more information, see QES user guide.
        /// </summary>
        [JsonProperty("signature")]
        public SignatureOption Signature { get; set; }

        /// <summary>
        /// Array of documents in the document group that the signer is invited to sign. For each document in the array, the document ID, signer role, and signer action are specified.
        /// </summary>
        [JsonProperty("documents")]
        public List<EmbeddedSigningGroupSignerDocument> Documents { get; set; } = new List<EmbeddedSigningGroupSignerDocument>();
    }
}
