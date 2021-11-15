using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangeScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChangeScheduler.Pages.ChangeTasks
{
    public class CreateModel : PageModel
    {
        private readonly ChangeSchedulerContext _context;

        public CreateModel(ChangeSchedulerContext context)
        {
            _context = context;
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

            _context.ChangeTasks.Add(ChangeTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
