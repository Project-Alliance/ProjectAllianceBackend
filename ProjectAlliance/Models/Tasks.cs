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
        public Projects Pid { get; set; }
        public Tasks()
        {
        }
    }
}
