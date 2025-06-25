using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SignNow.Net.Model
{
    public enum EmbeddedLinkDeliveryType
    {
        [EnumMember(Value = "link")]
        Link,

        [EnumMember(Value = "email")]
        Email,

    }
}
