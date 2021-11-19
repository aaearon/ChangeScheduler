using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangeScheduler.Models;
using ChangeScheduler.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChangeScheduler.Pages.ChangeTasks
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<ChangeTask> changeTaskRepository;

        public DetailsModel(IRepository<ChangeTask> changeTaskRepository)
        {
            this.changeTaskRepository = changeTaskRepository;
        }

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
    }
}
