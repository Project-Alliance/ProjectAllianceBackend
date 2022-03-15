using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    //[Table("ProjectMemebrs")]
    public class ProjectTeam
    {

        [Key]
        public int id { get; set; }
        public int pid { get; set; }
        public int uid { get; set; }
        public string role { get; set; }
        

        public ProjectTeam()
        {
        }
    }
}
