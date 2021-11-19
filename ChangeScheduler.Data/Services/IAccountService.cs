using ChangeScheduler.CyberArk.Models;


namespace ChangeScheduler.Data.Services
{
    public interface IAccountService
    {
        Task<Account> GetAccountByNameAsync(string name);
        Task<Account> GetAccountByIdAsync(string id);
        Task<IEnumerable<Account>> GetAccountsBySafeAsync(string safe);
    }
}
