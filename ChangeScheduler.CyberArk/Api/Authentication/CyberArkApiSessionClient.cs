using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;

namespace ChangeScheduler.CyberArk.Api
{

    public class CyberArkApiSessionClient : ICyberArkApiSessionClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ICyberArkApiSessionClient> _logger;
        private readonly CyberArkAuthenticationRequest _authRequest;

        private string SessionToken;

        public CyberArkApiSessionClient(HttpClient httpClient, ILogger<ICyberArkApiSessionClient> logger, CyberArkAuthenticationRequest authRequest)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authRequest = authRequest ?? throw new ArgumentNullException(nameof(authRequest));
        }

        public async Task<string> GetSessionTokenAsync()
        {
            var sessionToken = SessionToken;

            if (sessionToken == null)
            {
                var response = await _httpClient.PostAsync(
                    "api/auth/CyberArk/Logon",
                    new StringContent(
                        JsonSerializer.Serialize(_authRequest),
                        Encoding.UTF8,
                        "application/json"));

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                sessionToken = JsonSerializer.Deserialize<string>(content);
                SessionToken = sessionToken;
            }
            return sessionToken;

        }

        public void ClearSessionToken()
        {
            SessionToken = null;
        }
    }
}
