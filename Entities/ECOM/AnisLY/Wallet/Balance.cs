using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrePaid_SDK.Entities.ECOM.AnisLY.Wallet
{
    public class Balance
    {
        [JsonPropertyName("data")]
        public double Balanace { get; set; }

        [JsonPropertyName("message")]
        public string message { get; set; }
    }
}
