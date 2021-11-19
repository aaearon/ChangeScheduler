using ChangeScheduler.CyberArk.Models;
using ChangeScheduler.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChangeScheduler.Web.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DetailsModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account = await _accountService.GetAccountByIdAsync(id);

            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
