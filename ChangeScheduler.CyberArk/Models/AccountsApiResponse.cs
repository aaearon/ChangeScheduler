using System.Text.Json.Serialization;

namespace ChangeScheduler.CyberArk.Models
{
    public class AccountsApiResponse
    {
        [JsonPropertyName("value")]
        public IEnumerable<Account> Accounts { get; set; }
    }
}
