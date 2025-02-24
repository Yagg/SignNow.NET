using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SignNow.Net.Internal.Helpers.Converters;

namespace SignNow.Net.Model
{
    /// <summary>
    /// Represents signNow document group template object.
    /// </summary>
    public class SignNowDocumentGroupTemplate
    {
        /// <summary>
        /// Identity of specific template group.
        /// </summary>
        [JsonProperty("template_group_id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of specific template group.
        /// </summary>
        [JsonProperty("template_group_name")]
        public string Name { get; set; }

        /// <summary>
        /// An ID of folder with template group.
        /// </summary>
        [JsonProperty("folder_id")]
        public string FolderId { get; set; }

        /// <summary>
        /// Timestamp of document group update.
        /// </summary>
        [JsonProperty("last_updated")]
        [JsonConverter(typeof(UnixTimeStampJsonConverter))]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Owner email address.
        /// </summary>
        [JsonProperty("owner_email")]
        public string OwnerEmail { get; set; }

        /// <summary>
        /// Preparation status.
        /// </summary>
        [JsonProperty("is_prepared")]
        public bool IsPrepared { get; set; }

        /// <summary>
        /// Routing details
        /// </summary>
        [JsonProperty("routing_details")]
        public RoutingDetails RoutingDetails { get; set; }

        [JsonProperty("templates")]
        public IReadOnlyList<TemplateInfo> Templates { get; set; }
    }

    public class TemplateInfo
    {
        /// <summary>
        /// Identity of specific template.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of specific template.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Template thumbnails
        /// </summary>
        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        /// <summary>
        /// List with template roles.
        /// </summary>
        [JsonProperty("roles")]
        public IReadOnlyList<string> Roles { get; set; }

    }

    public class RoutingDetails
    {
        [JsonProperty("sign_as_merged")]
        public bool SignAsMerged {  get; set; }

        [JsonProperty("include_email_attachments")]
        public string IncludeEmailAttachments { get; set; }
    }
}
