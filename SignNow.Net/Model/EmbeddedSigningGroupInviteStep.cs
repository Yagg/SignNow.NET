using System;
using System.Collections.Generic;
using System.Text;
using SignNow.Net.Exceptions;
using SignNow.Net.Internal.Helpers;
using SignNow.Net.Model.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SignNow.Net.Model
{
    public class EmbeddedSigningGroupInviteStep
    {
        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("signers", NullValueHandling = NullValueHandling.Ignore)]
        public List<EmbeddedSigningGroupSigner> Signers { get; set; } = new List<EmbeddedSigningGroupSigner>();

        /// <summary>
        /// Add Embedded Sign Invite Signer.
        /// </summary>
        /// <param name="signer">Embedded invite signer data</param>
        /// <exception cref="ArgumentException">If <paramref name="signer.RoleId"/> does not exists in document Roles.</exception>
        public void AddSigner(EmbeddedSigningGroupSigner signer)
        {
            Guard.ArgumentNotNull(signer, nameof(signer));

            Signers.Add(signer);
        }
    }
}
