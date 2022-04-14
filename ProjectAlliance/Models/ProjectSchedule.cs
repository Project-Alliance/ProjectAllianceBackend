using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    public class ProjectSchedule
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime start { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime end { get; set; }
        public string dependancies { get; set; }
        
        public int AssignTo { get; set; }
        public int progress { get; set; }
        [ForeignKey("Standard")]
        public int ProjectId { get; set; }
        public Project pid { get; set; }
        [NotMapped]
        public object assigedTo { get; set; }
        [NotMapped]
        public string dependencies { get; set; }

        public ProjectSchedule()
        {
        }
    }
}
