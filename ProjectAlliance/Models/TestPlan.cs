
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Models{
    public class TestPlan{
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EnvId { get; set; }
    }
}