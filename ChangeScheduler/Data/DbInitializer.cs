using ChangeScheduler.Models;

namespace ChangeScheduler.Data
{
    public class DbInitializer
    {
        public static void Initialize(ChangeSchedulerContext context)
        {
            // Look for any students.
            if (context.ChangeTasks.Any())
            {
                return;   // DB has been seeded
            }

            var changeTasks = new ChangeTask[]
            {
                new ChangeTask{AccountName="root@linux1",AccountSafe="Linux",ScheduledChangeDate=DateTime.Parse("2023-09-01 01:02:03"), Completed=false},
                new ChangeTask{AccountName="root@linux2",AccountSafe="Linux",ScheduledChangeDate=DateTime.Parse("2023-09-02 01:02:03"), Completed=false},
                new ChangeTask{AccountName="admin@linux1",AccountSafe="Linux",ScheduledChangeDate=DateTime.Parse("2019-07-02 10:12:59"), Completed=true},
                new ChangeTask{AccountName="admin@linux2",AccountSafe="Linux",ScheduledChangeDate=DateTime.Parse("2023-09-02 01:02:03"), Completed=false},

            };

            context.ChangeTasks.AddRange(changeTasks);
            context.SaveChanges();
        }
    }
}

