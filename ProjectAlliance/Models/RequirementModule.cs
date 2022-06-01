using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Models
{
    public class RequirementModule{
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string modifiedBy { get; set; }
        public DateTime modifeidOn { get; set; }
        public int projectId { get; set; }

        public RequirementModule()
        {
        }
    }
}