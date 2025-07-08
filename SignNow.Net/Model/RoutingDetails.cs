using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SignNow.Net.Model
{
    public class RoutingDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("data")]
        public List<RoutingDetail> Data { get; set; }

        [JsonProperty("cc")]
        public List<object> Cc { get; set; }

        [JsonProperty("cc_step")]
        public List<object> CcStep { get; set; }

        [JsonProperty("invite_link_instructions")]
        public object InviteLinkInstructions { get; set; }

        [JsonProperty("viewers")]
        public List<object> Viewers { get; set; }

        [JsonProperty("approvers")]
        public List<object> Approvers { get; set; }

        [JsonProperty("attributes")]
        public List<object> Attributes { get; set; }
    }

    public class RoutingDetail
    {
        [JsonProperty("default_email")]
        public string DefaultEmail { get; set; }
        [JsonProperty("inviter_role")]
        public bool InviterRole { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("role_id")]
        public string RoleId { get; set; }
        [JsonProperty("signing_order")]
        public int SigningOrder { get; set; }
        [JsonProperty("decline_by_signature")]
        public bool DeclineBySignature { get; set; }
    }
    /*
   "routing_details": [
   {
       "id": "a7a73254152141b59b64c327138e311c999b551a",
       "data": [
           {
               "default_email": "",
               "inviter_role": false,
               "name": "Caregiver",
               "role_id": "08a425e5124147e29b35d3653e77dcfba0f1fe9d",
               "signing_order": 1,
               "decline_by_signature": false
           },
           {
               "default_email": "spv.tests@gmail.com",
               "inviter_role": false,
               "decline_by_signature": false,
               "role_id": "3da3eab9ed294117b5e60743c52c700d3fa6c350",
               "name": "Recipient 2",
               "signing_order": 1
           }
       ],
       "created": "1751276514",
       "updated": "1751276865",
       "cc": [],
       "cc_step": [],
       "invite_link_instructions": null,
       "viewers": [],
       "approvers": [],
       "attributes": []
   }
],
*/

}
