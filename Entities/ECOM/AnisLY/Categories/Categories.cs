using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrePaid_SDK.Entities.ECOM.AnisLY.Categories
{
    public class Categories
    {
        public class Root
        {
            [JsonPropertyName("data")]
            public List<Data> Data { get; set; }

            [JsonPropertyName("message")]
            public string Message { get; set; }
        }

        public class Data
        {
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

            [JsonPropertyName("subCategories")]
            public List<SubCategory> SubCategories { get; set; }
        }
    }
}
