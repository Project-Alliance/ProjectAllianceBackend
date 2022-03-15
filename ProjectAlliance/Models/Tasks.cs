using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    //[Table("Tasks")]
    public class Tasks
    {
        [Key]
        public int tid { get; set; }
        //[Column("TaskTitle",TypeName = "ntext")]
        public string TaskTitle { get; set; }
        //[ForeignKey("pid")]
        public int ProjectId { get; set; }

   
      
        public DateTime startDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime endDate { get; set; }
        public string description { get; set; }

        public string status { get; set; }
        public string progress { get; set; }
        [Column(TypeName = "Date")]

        public DateTime CreateAt { get; set; }

       
        public string TaskCost { get; set; }
        public Tasks()
        {
        }
    }
}
