using System.Collections.Generic;
using Newtonsoft.Json;

namespace SignNow.Net.Model.Responses
{
    public class DocumentGroupTemplatesResponse
    {
        [JsonProperty("document_group_templates")]
        public IReadOnlyList<SignNowDocumentGroupTemplate> Data { get; set; }

        /// <summary>
        /// Total document group templates count.
        /// </summary>
        [JsonProperty("document_group_template_total_count")]
        public int TotalCount { get; set; }
    }
}
