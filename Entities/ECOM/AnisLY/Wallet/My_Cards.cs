using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrePaid_SDK.Entities.ECOM.AnisLY.Wallet
{
    public class My_Cards
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
            [JsonPropertyName("results")]
            public List<Result> Results { get; set; }

            [JsonPropertyName("currentPage")]
            public int CurrentPage { get; set; }

            [JsonPropertyName("pageSize")]
            public int PageSize { get; set; }

            [JsonPropertyName("total")]
            public int Total { get; set; }

            [JsonPropertyName("showingFrom")]
            public int ShowingFrom { get; set; }

            [JsonPropertyName("showingTo")]
            public int ShowingTo { get; set; }

            [JsonPropertyName("lastPage")]
            public int LastPage { get; set; }

            [JsonPropertyName("pages")]
            public List<int> Pages { get; set; }
        }

        public class Result
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("number")]
            public int Number { get; set; }

            [JsonPropertyName("soldAt")]
            public DateTime SoldAt { get; set; }

            [JsonPropertyName("virtualCost")]
            public int VirtualCost { get; set; }

            [JsonPropertyName("currencyType")]
            public int CurrencyType { get; set; }

            [JsonPropertyName("price")]
            public double Price { get; set; }

            [JsonPropertyName("secretNumber")]
            public string SecretNumber { get; set; }

            [JsonPropertyName("serialNumber")]
            public string SerialNumber { get; set; }

            [JsonPropertyName("expireDate")]
            public DateTime? ExpireDate { get; set; }

            [JsonPropertyName("archived")]
            public bool Archived { get; set; }

            [JsonPropertyName("cardName")]
            public string CardName { get; set; }

            [JsonPropertyName("cardArabicName")]
            public string CardArabicName { get; set; }

            [JsonPropertyName("cardEnglishName")]
            public string CardEnglishName { get; set; }

            [JsonPropertyName("categoryName")]
            public string CategoryName { get; set; }

            [JsonPropertyName("logo")]
            public string Logo { get; set; }

            [JsonPropertyName("printLogoName")]
            public string PrintLogoName { get; set; }

            [JsonPropertyName("subscriptionName")]
            public string SubscriptionName { get; set; }

            [JsonPropertyName("phone")]
            public string Phone { get; set; }

            [JsonPropertyName("walletIdentifier")]
            public string WalletIdentifier { get; set; }

            [JsonPropertyName("faceValue")]
            public string FaceValue { get; set; }

            [JsonPropertyName("totalPrints")]
            public int TotalPrints { get; set; }

            [JsonPropertyName("note")]
            public string Note { get; set; }

            [JsonPropertyName("printNote")]
            public string PrintNote { get; set; }

            [JsonPropertyName("arabicDisclaimerNote")]
            public string ArabicDisclaimerNote { get; set; }

            [JsonPropertyName("englishDisclaimerNote")]
            public string EnglishDisclaimerNote { get; set; }
        }

    }
}
