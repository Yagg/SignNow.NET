using Newtonsoft.Json;

namespace SignNow.Net.Model
{
    public class ReminderOptions
    {
        /// <summary>
        /// x days after the invite, a recepient gets a reminder email. Must be less than expiration_days
        /// </summary>
        [JsonProperty("remind_after", NullValueHandling = NullValueHandling.Ignore)]
        public int? RemindAfter { get; set; }

        /// <summary>
        /// x days before expiration, a recepient gets a reminder email. Must be less than expiration_days
        /// </summary>
        [JsonProperty("remind_before", NullValueHandling = NullValueHandling.Ignore)]
        public int? RemindBefore { get; set; }

        /// <summary>
        /// A recepient gets a reminder email each x days after the invite is sent
        /// </summary>
        [JsonProperty("remind_repeat", NullValueHandling = NullValueHandling.Ignore)]
        public int? RemindRepeat { get; set; }
    }
}
