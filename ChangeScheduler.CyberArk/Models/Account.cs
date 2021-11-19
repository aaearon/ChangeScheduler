using System.Text.Json.Serialization;

namespace ChangeScheduler.CyberArk.Models
{
    public class Account
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("safeName")]
        public string Safe { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }

    }
}
