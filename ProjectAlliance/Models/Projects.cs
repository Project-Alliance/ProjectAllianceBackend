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
        //[Column("PTitle",TypeName= "ntext")]
        //[MaxLength(30)]
        public string ProjectTitle { get; set; }
        //[Column("PDesc", TypeName = "ntext")]
        public string projectDescription { get; set; }
        //[Column("PIconName", TypeName = "ntext")]
        //[MaxLength(30)]
        public string PIconName { get; set; }
        //[Column("PIconBackground", TypeName = "ntext")]
        //[MaxLength(20)]
        public string PIconBackground { get; set; }
        [ForeignKey("ProjectId")]
        public ICollection<Members> Members { get; set; }
        public Projects()
        {
        }
    }
}
