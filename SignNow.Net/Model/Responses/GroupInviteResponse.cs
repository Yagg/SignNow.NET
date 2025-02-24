using Newtonsoft.Json;
using SignNow.Net.Model.Responses.GenericResponses;

namespace SignNow.Net.Model
{
    /// <summary>
    /// Represents response from signNow API for create invite request for document group.
    /// </summary>
    public class GroupInviteResponse : IdResponse
    {
        /// <summary>
        /// Invite link
        /// </summary>
        [JsonProperty("pending_invite_link")]
        public string PendingInviteLink { get; set; }

        [JsonProperty("success")]
        public override bool Success { get; set; } = true;
    }
}
