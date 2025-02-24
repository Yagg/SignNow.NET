using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace SignNow.Net.Model
{
    public enum AuthType
    {
        [EnumMember(Value = "password")]
        Password,

        [EnumMember(Value = "phone")]
        Phone,
    }

    public enum AuthMethod
    {
        [EnumMember(Value = "phone_call")]
        PhoneCall,

        [EnumMember(Value = "sms")]
        SMS
    }

    public class SignerAuthentication
    {
        /// <summary>
        /// Type of signer's identity verification. Possible values: "password" or "phone".
        /// </summary>
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuthType Type { get; set; }

        /// <summary>
        /// Required in case of "type": "password". The password for user authentication.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Required in case of "type": "phone". Possible values: "phone_call", "sms".
        /// </summary>
        [JsonProperty("method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AuthMethod Method { get; set; }

        /// <summary>
        /// Required in case of "type": "phone". User's phone number.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// In case of "method": "sms" - custom SMS message, max 140 characters.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
