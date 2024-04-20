using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.DbModels
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int projectid {  get; set; }
        public string name { get; set; }
        public DateTime dateofstart {  get; set; }

        public int TeamSize {  get; set; }
    }
}
