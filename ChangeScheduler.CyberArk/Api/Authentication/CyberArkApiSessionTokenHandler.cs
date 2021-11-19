using System.Net;
using System.Net.Http.Headers;

namespace ChangeScheduler.CyberArk.Api
{
    public class CyberArkApiSessionTokenHandler : DelegatingHandler
    {

        private readonly ICyberArkApiSessionClient _sessionClient;

        public CyberArkApiSessionTokenHandler(ICyberArkApiSessionClient sessionClient)
        {
            _sessionClient = sessionClient ?? throw new ArgumentNullException(nameof(sessionClient));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var sessionToken = await _sessionClient.GetSessionTokenAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue(sessionToken);
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _sessionClient.ClearSessionToken();
                sessionToken = await _sessionClient.GetSessionTokenAsync();
                request.Headers.Authorization = new AuthenticationHeaderValue(sessionToken);
                response = await base.SendAsync(request, cancellationToken);
            }
            
            return await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
