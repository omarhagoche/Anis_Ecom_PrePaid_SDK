using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PrePaid_SDK.Entities.ECOM.AnisLY.Token
{
    public class Login_Token
    {
        [JsonPropertyName("grant_type")]
        public string grant_type { get=> "user_credentials";}

        [JsonPropertyName("client_id")]
        public string client_id { get; set; }

        [JsonPropertyName("client_secret")]
        public string  client_secret { get; set; }

        [JsonPropertyName("password")]
        public string password { get; set; }

        [JsonPropertyName("email")]
        public string email { get; set; }
    }
}
