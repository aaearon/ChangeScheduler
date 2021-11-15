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
    public class IndexModel : PageModel
    {
        private readonly ChangeSchedulerContext _context;

        public IndexModel(ChangeSchedulerContext context)
        {
            _context = context;
        }

        public IList<ChangeTask> ChangeTask { get;set; }

        public async Task OnGetAsync()
        {
            ChangeTask = await _context.ChangeTasks.ToListAsync();
        }
    }
}
