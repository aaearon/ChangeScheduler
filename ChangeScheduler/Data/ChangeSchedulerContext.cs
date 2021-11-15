using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChangeScheduler.Models;

public class ChangeSchedulerContext : DbContext
    {
        public ChangeSchedulerContext (DbContextOptions<ChangeSchedulerContext> options)
            : base(options)
        {
        }

        public DbSet<ChangeTask> ChangeTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChangeTask>().ToTable("ChangeTask");
    }
}
