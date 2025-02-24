using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace SignNow.Net.Model
{
    public class SignatureOption
    {
        /// <summary>
        /// Type of QES signature. Possible values: eideasy, eideasy-pdf, and nom151. All signers in the invite must have the same signature type.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SignatureType Type { get; set; }
    }

    public enum SignatureType
    {
        [EnumMember(Value = "eideasy")]
        Eideasy,

        [EnumMember(Value = "eideasy-pdf")]
        EideasyPdf,

        [EnumMember(Value = "nom151")]
        Nom151
    }
}
