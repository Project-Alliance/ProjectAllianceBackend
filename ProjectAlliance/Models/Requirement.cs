using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

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
         public string requirementType { set; get; }
         public string modifiedBy { set; get; }
         [Column(TypeName = "Date")]
         public DateTime modifeidOn { set; get; }
        public int moduleId { get; set; }

        [NotMapped]
        public List<IFormFile> file { set; get; }
        
       
        public Requirements()
        {
        }
    }
}
