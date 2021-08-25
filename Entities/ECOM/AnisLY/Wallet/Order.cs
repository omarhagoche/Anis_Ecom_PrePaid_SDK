using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrePaid_SDK.Entities.ECOM.AnisLY.Wallet
{
    public class Order
    {
        [JsonPropertyName("walletId")]
        public string WalletId { get; set; }

        [JsonPropertyName("cardId")]
        public string CardId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("totalValue")]
        public double TotalValue { get; set; }

        [JsonPropertyName("pinNumber")]
        public string PinNumber { get; set; }
    }
}
