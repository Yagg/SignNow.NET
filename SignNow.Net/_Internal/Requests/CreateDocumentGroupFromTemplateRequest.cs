using Newtonsoft.Json;
using SignNow.Net.Model.Requests;

namespace SignNow.Net.Internal.Requests
{
    internal class CreateDocumentGroupFromTemplateRequest : JsonHttpContent
    {
        /// <summary>
        /// The new document group name.
        /// </summary>
        [JsonProperty("group_name")]
        public string GroupName { get; set; }

        public CreateDocumentGroupFromTemplateRequest(string groupName)
        {
            GroupName = groupName;
        }
    }
}
