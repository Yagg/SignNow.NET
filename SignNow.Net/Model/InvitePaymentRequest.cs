using Newtonsoft.Json;

namespace SignNow.Net.Model
{
    public class InvitePaymentRequest
    {
        /// <summary>
        /// The ID of the merchant account added to your Organization.
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The payment currency requested.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// In case of Group Invite, must be "fixed".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The payment amount requested.
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}
