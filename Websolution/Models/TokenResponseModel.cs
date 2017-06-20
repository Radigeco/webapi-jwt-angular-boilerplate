using System;
using Newtonsoft.Json;

namespace Websolution.Models
{
    public class TokenResponseModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("issue_date")]
        public Int64 IssueDate { get; set; }

        [JsonProperty("expire_date")]
        public Int64 ExpireDate { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}