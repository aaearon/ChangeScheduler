using ChangeScheduler.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChangeScheduler.Data.Repositories
{
    public class ChangeTaskRepository : IRepository<ChangeTask>
    {

        protected ChangeSchedulerContext context;

        public ChangeTaskRepository(ChangeSchedulerContext context)
        {
            this.context = context;
        }

        public async Task<ChangeTask> AddAsync(ChangeTask entity)
        {
            await context.ChangeTasks.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<ChangeTask>> AllAsync()
        {
            var changeTasks = await context.ChangeTasks.ToListAsync();

            return changeTasks;
        }

        public async Task<ChangeTask> DeleteAsync(int id)
        {
            var changeTask = await context.ChangeTasks.FindAsync(id);

            if (changeTask != null)
            {
                context.ChangeTasks.Remove(changeTask);
                await context.SaveChangesAsync();
            }

            return null;
        }

        public Task<IEnumerable<ChangeTask>> FindAsync(Expression<Func<ChangeTask, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<ChangeTask> GetAsync(int id)
        {
            var changeTask = await context.ChangeTasks.FirstOrDefaultAsync(e => e.ID == id);

            return changeTask;
        }

        public async Task<ChangeTask> UpdateAsync(ChangeTask entity)
        {
            context.ChangeTasks.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
