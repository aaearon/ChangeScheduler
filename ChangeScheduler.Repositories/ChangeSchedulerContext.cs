using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
