using ChangeScheduler.CyberArk;
using ChangeScheduler.CyberArk.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChangeScheduler.Web.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly ApiClient _apiClient;

        public IndexModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IList<Account> Accounts { get; set; }


        public async Task OnGetAsync()
        {
            try
            {
                var response = await _apiClient.GetAccountsAsync();
                Accounts = (IList<Account>)response.Accounts;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }
    }
}
