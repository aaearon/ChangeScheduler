using System.ComponentModel.DataAnnotations;

namespace ChangeTaskRepository.Interface
{
    public class ChangeTask
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ChangeDate { get; set; }
        public string AccountSafe { get; set; }
        public string AccountName { get; set; }
        public Boolean Completed { get; set; }
    }
}