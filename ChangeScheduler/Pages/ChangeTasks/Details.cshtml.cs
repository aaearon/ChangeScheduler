using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangeScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChangeScheduler.Pages.ChangeTasks
{
    public class DetailsModel : PageModel
    {
        private readonly ChangeSchedulerContext _context;

        public DetailsModel(ChangeSchedulerContext context)
        {
            _context = context;
        }

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
    }
}
