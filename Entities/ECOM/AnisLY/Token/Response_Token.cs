using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrePaid_SDK.Entities.ECOM.AnisLY.Token
{
    public class Response_Token
    {
        [JsonPropertyName("access_token")]
        public string access_token { get; set; }

        [JsonPropertyName("expires_in")]
        public Int64 expires_in { get; set; }

        [JsonPropertyName("token_type")]
        public string token_type { get; set; }

        [JsonPropertyName("refresh_token")]
        public string refresh_token { get; set; }

        [JsonPropertyName("scope")]
        public string scope { get; set; }

        [JsonPropertyName("completed")]
        public bool completed { get; set; }

        [JsonPropertyName("input_business_info")]
        public bool input_business_info { get; set; }

        [JsonPropertyName("verify_phone")]
        public bool verify_phone { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }

        [JsonPropertyName("verify_email")]
        public bool verify_email { get; set; }

        [JsonPropertyName("input_email")]
        public bool input_email { get; set; }
    }
}
