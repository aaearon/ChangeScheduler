using ChangeScheduler.Data.Repositories;
using ChangeScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChangeScheduler.Web.Pages.ChangeTasks
{
    public class EditModel : PageModel
    {
        private readonly IRepository<ChangeTask> changeTaskRepository;

        public EditModel(IRepository<ChangeTask> changeTaskRepository)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await changeTaskRepository.UpdateAsync(ChangeTask);

            return RedirectToPage("./Index");
        }
    }
}
