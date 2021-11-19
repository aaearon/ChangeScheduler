using ChangeScheduler.Data.Repositories;
using ChangeScheduler.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChangeScheduler.Web.Pages.ChangeTasks
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<ChangeTask> changeTaskRepository;

        public IndexModel(IRepository<ChangeTask> changeTaskRepository)
        {
            this.changeTaskRepository = changeTaskRepository;
        }

        public IList<ChangeTask> ChangeTask { get; set; }

        public async Task OnGetAsync()
        {
            ChangeTask = (IList<ChangeTask>)await changeTaskRepository.AllAsync();
        }
    }
}
