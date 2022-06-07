using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Models
{
    public class RequirementModule{
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string modifiedBy { get; set; }
        [Column(TypeName = "Date")]
        public DateTime modifeidOn { get; set; }
        public int projectId { get; set; }

        public RequirementModule()
        {
        }
    }
}