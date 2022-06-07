
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Models{
    public class Enviorment{
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string summary { get; set; }

        public int projectId { get; set; }
        public string TestType { get; set; }
        public int RequirementId { get; set; }
    }
}