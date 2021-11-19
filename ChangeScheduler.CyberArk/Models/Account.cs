using System.Text.Json.Serialization;
using ChangeScheduler.CyberArk.Api;

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
        [JsonPropertyName("secretManagement")]
        public SecretManagement SecretManagement { get; set; }

    }

    public class SecretManagement
    {
        [JsonPropertyName("automaticManagementEnabled")]
        public bool AutomaticManagementEnabled { get; set; }
        [JsonPropertyName("manualManagementReason")]
        public string ManualManagementReason { get; set; }
        [JsonPropertyName("status")]

        public string Status { get; set; }
        [JsonPropertyName("lastModifiedTime")]
        [JsonConverter(typeof(UnixMillisecondsToDateTimeConverter))]
        public DateTime LastModifiedTime { get; set; }
        [JsonPropertyName("lastReconciledTime")]

        public long LastReconciledTime { get; set; }
        [JsonPropertyName("lastVerifiedTime")]

        public long LastVerifiedTime { get; set; }

    }
}
