using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrePaid_SDK.Entities.ECOM.AnisLY.Wallet
{
    class Transactions
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

            [JsonPropertyName("dateTime")]
            public DateTime DateTime { get; set; }

            [JsonPropertyName("statement")]
            public string Statement { get; set; }

            [JsonPropertyName("credit")]
            public double Credit { get; set; }

            [JsonPropertyName("debit")]
            public int Debit { get; set; }

            [JsonPropertyName("creditorName")]
            public string CreditorName { get; set; }

            [JsonPropertyName("debitorName")]
            public string DebitorName { get; set; }

            [JsonPropertyName("creditorWalletIdentifier")]
            public string CreditorWalletIdentifier { get; set; }

            [JsonPropertyName("debitorWalletIdentifier")]
            public string DebitorWalletIdentifier { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("balance")]
            public double Balance { get; set; }

            [JsonPropertyName("note")]
            public string Note { get; set; }

            [JsonPropertyName("hasDetails")]
            public bool HasDetails { get; set; }
        }
    }
}
