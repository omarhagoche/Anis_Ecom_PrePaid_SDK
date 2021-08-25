using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrePaid_SDK.Entities.ECOM.AnisLY.Cards
{
    public class Cards
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
            [JsonPropertyName("cards")]
            public List<Card> Cards { get; set; }

            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("logo")]
            public string Logo { get; set; }

            [JsonPropertyName("inStock")]
            public bool InStock { get; set; }
        }

        public class Card
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("arabicName")]
            public string ArabicName { get; set; }

            [JsonPropertyName("englishName")]
            public string EnglishName { get; set; }

            [JsonPropertyName("price")]
            public double Price { get; set; }

            [JsonPropertyName("currencyType")]
            public int CurrencyType { get; set; }

            [JsonPropertyName("faceValue")]
            public string FaceValue { get; set; }

            [JsonPropertyName("logo")]
            public string Logo { get; set; }

            [JsonPropertyName("printLogoName")]
            public string PrintLogoName { get; set; }

            [JsonPropertyName("inStock")]
            public bool InStock { get; set; }
        }
    }
}
