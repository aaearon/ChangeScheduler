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
    public class IndexModel : PageModel
    {
        private readonly IRepository<ChangeTask> changeTaskRepository;

        public IndexModel(IRepository<ChangeTask> changeTaskRepository)
        {
            this.changeTaskRepository = changeTaskRepository;
        }

        public IList<ChangeTask> ChangeTask { get;set; }

        public async Task OnGetAsync()
        {
            ChangeTask = (IList<ChangeTask>)await changeTaskRepository.AllAsync();
        }
    }
}
