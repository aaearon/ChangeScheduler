using ChangeScheduler.Models;
using Microsoft.EntityFrameworkCore;

public class ChangeSchedulerContext : DbContext
    {
        public ChangeSchedulerContext (DbContextOptions<ChangeSchedulerContext> options)
            : base(options)
        {
        }

        public DbSet<ChangeTask> ChangeTasks { get; set; }

}
