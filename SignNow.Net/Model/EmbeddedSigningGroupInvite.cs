using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SignNow.Net.Exceptions;
using SignNow.Net.Internal.Helpers;
using SignNow.Net.Model.Responses;

namespace SignNow.Net.Model
{
    public class EmbeddedSigningGroupInvite
    {
        private DocumentGroupData DocumentGroup { get; set; }

        /// <summary>
        /// List with Embedded Sign Invites options.
        /// </summary>
        [JsonProperty("invites", NullValueHandling = NullValueHandling.Ignore)]
        public List<EmbeddedSigningGroupInviteStep> InviteSteps { get; private set; } = new List<EmbeddedSigningGroupInviteStep>();

        /// <summary>
        /// Initialize a new instance of Embedded Signing Invite.
        /// </summary>
        /// <param name="docGroup">signNow document group which you would like to sign with Embedded Invite.</param>
        /// <exception cref="ArgumentException">The <paramref name="docGroup"/> can not be null.</exception>
        /// <exception cref="ArgumentException">When <paramref name="docGroup"/> does not have <see cref="Role"/></exception>
        /// <exception cref="ArgumentException">When <see cref="FreeFormSignInvite"/> exists in a <paramref name="docGroup"/></exception>
        public EmbeddedSigningGroupInvite(DocumentGroupData docGroup)
        {
            Guard.ArgumentNotNull(docGroup, nameof(docGroup));

            if (docGroup.Documents.Count == 0)
            {
                throw new ArgumentException(ExceptionMessages.DocumentGroupWithoutDocs);
            }
            foreach(var doc in docGroup.Documents)
            {
                if (doc.Roles.Count == 0)
                {
                    throw new ArgumentException(ExceptionMessages.DocumentDoesNotHaveRoles);
                }
            }
            if (!string.IsNullOrEmpty(docGroup.InviteId))
            {
                throw new ArgumentException(ExceptionMessages.InviteIsAlreadyExistsForDocument);
            }

            DocumentGroup = docGroup;
        }

    }
}
