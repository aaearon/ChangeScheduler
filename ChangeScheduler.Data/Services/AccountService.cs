using ChangeScheduler.CyberArk;
using ChangeScheduler.CyberArk.Models;

namespace ChangeScheduler.Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApiClient _client;

        public AccountService(ApiClient client)
        {
            _client = client;
        }

        public async Task<Account> GetAccountByIdAsync(string id)
        {
            return await _client.GetAccount(id);
        }

        public Task<Account> GetAccountByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAccountsBySafeAsync(string safe)
        {
            throw new NotImplementedException();
        }
    }
}
