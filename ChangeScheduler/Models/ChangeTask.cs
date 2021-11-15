using System.ComponentModel.DataAnnotations;

namespace ChangeScheduler.Models
{
    public class ChangeTask
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Scheduled Change Date")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime ScheduledChangeDate { get; set; }
        [Required]
        [Display(Name = "Account Safe")]
        public string AccountSafe { get; set; }
        [Required]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }
        [Display(Name = "Change Completed")]
        public Boolean Completed { get; set; }
    }
}