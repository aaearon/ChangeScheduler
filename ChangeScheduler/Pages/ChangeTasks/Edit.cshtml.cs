using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangeScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ChangeScheduler.Pages.ChangeTasks
{
    public class EditModel : PageModel
    {
        private readonly ChangeSchedulerContext _context;

        public EditModel(ChangeSchedulerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChangeTask ChangeTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChangeTask = await _context.ChangeTasks.FirstOrDefaultAsync(m => m.ID == id);

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

            _context.Attach(ChangeTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeTaskExists(ChangeTask.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChangeTaskExists(int id)
        {
            return _context.ChangeTasks.Any(e => e.ID == id);
        }
    }
}
