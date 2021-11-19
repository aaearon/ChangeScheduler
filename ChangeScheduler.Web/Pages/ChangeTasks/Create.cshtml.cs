using ChangeScheduler.Data.Repositories;
using ChangeScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChangeScheduler.Web.Pages.ChangeTasks
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<ChangeTask> changeTaskRepository;

        public CreateModel(IRepository<ChangeTask> changeTaskRepository)
        {
            this.changeTaskRepository = changeTaskRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ChangeTask ChangeTask { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await changeTaskRepository.AddAsync(ChangeTask);

            return RedirectToPage("./Index");
        }
    }
}
