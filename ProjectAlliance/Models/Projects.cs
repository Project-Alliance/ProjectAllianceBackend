using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    //[Table("Projects")]
    public class Project
    {
        [Key]
        public int pid { get; set; }
        public string ProjectTitle { get; set; }
        public string projectDescription { get; set; }
        public string status { get; set; }
        public string progress { get; set; }
        [Column(TypeName = "Date")]
        
        public DateTime CreateAt { get; set; }

        public string companyProject { get; set; }
        [Column(TypeName = "Date")]
        public DateTime startDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime endDate { get; set; }

        public ICollection<ProjectSchedule> projectSchedules { get; set; }

        public Project()
        {
        }
    }
}
