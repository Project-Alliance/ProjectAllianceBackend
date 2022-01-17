using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    [Table("SubTasks")]
    public class SubTasks
    {
        [Key]
        public int taskid { get; set; }
        public string taskTitle { get; set; }
        [Timestamp]
        public byte[] startDate { get; set; }
        [Timestamp]
        public byte[] endDate { get; set; }        
        public string description { get; set; }
       
        public SubTasks(){}
    }
}
