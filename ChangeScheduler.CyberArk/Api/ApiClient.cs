using ChangeScheduler.CyberArk.Models;
using System.Net.Http.Json;

namespace ChangeScheduler.CyberArk
{
    public class ApiClient
    {

        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<AccountsApiResponse> GetAccountsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/Accounts");
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<AccountsApiResponse>();
            }
        }

        public async Task<Account> GetAccount(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Accounts/{id}");
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Account>();
            }
        }

    }
}