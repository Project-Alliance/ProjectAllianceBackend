using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    //[Table("Projects")]
    public class Projects
    {
        [Key]
        public int pid { get; set; }
        public string ProjectTitle { get; set; }
        public string projectDescription { get; set; }
        public string status { get; set; }
        public string progress { get; set; }
        [Timestamp]
        public byte[] CreateAt { get; set; }

        public string companyProject { get; set; }

        [Timestamp]
        public byte[] startDate { get; set; }
        [Timestamp]
        public byte[] endDate { get; set; }

        public Projects()
        {
        }
    }
}
