using ChangeScheduler.Data.Repositories;
using ChangeScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChangeScheduler.Web.Pages.ChangeTasks
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<ChangeTask> changeTaskRepository;

        public DeleteModel(IRepository<ChangeTask> changeTaskRepository)
        {
            this.changeTaskRepository = changeTaskRepository;
        }

        [BindProperty]
        public ChangeTask ChangeTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChangeTask = await changeTaskRepository.GetAsync(id);

            if (ChangeTask == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChangeTask = await changeTaskRepository.GetAsync(id);

            if (ChangeTask != null)
            {
                await changeTaskRepository.DeleteAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
