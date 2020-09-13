using System.Text.Json.Serialization;

namespace Safra.Domain.Models
{
    public class Token
    {
        [JsonPropertyNameAttribute("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyNameAttribute("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyNameAttribute("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
