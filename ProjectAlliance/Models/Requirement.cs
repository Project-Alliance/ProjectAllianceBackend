using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    public class Requirements
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string name { get; set; }
        public string status { get; set; }
        public string requirementDescription { get; set; }
        public int uid { get; set; }
        public int ProjectId { get; set; }
       
        public Requirements()
        {
        }
    }
}
