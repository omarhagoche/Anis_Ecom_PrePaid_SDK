using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrePaid_SDK.Entities.ECOM.AnisLY.Wallet
{
    public class Order_Response
    {
        public class Root
        {
            [JsonPropertyName("data")]
            public Data Data { get; set; }

            [JsonPropertyName("message")]
            public string Message { get; set; }
        }

        public class Data
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("number")]
            public int Number { get; set; }

            [JsonPropertyName("subscriptionName")]
            public string SubscriptionName { get; set; }

            [JsonPropertyName("phone")]
            public string Phone { get; set; }

            [JsonPropertyName("walletIdentifier")]
            public string WalletIdentifier { get; set; }

            [JsonPropertyName("currencyType")]
            public int CurrencyType { get; set; }

            [JsonPropertyName("regionId")]
            public string RegionId { get; set; }

            [JsonPropertyName("regionName")]
            public string RegionName { get; set; }

            [JsonPropertyName("dateTime")]
            public DateTime DateTime { get; set; }

            [JsonPropertyName("cards")]
            public List<PurchasedCard> Cards { get; set; }
        }

        public class PurchasedCard
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("card")]
            public Cards.Cards.Card Card { get; set; }

            [JsonPropertyName("categoryName")]
            public string CategoryName { get; set; }

            [JsonPropertyName("virtualCost")]
            public int VirtualCost { get; set; }

            [JsonPropertyName("price")]
            public double Price { get; set; }

            [JsonPropertyName("secretNumber")]
            public string SecretNumber { get; set; }

            [JsonPropertyName("printNote")]
            public object PrintNote { get; set; }

            [JsonPropertyName("arabicDisclaimerNote")]
            public object ArabicDisclaimerNote { get; set; }

            [JsonPropertyName("englishDisclaimerNote")]
            public string EnglishDisclaimerNote { get; set; }

            [JsonPropertyName("serialNumber")]
            public string SerialNumber { get; set; }

            [JsonPropertyName("expireDate")]
            public object ExpireDate { get; set; }

            [JsonPropertyName("soldAt")]
            public DateTime SoldAt { get; set; }
        }
    }
}
