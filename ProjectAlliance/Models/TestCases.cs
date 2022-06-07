
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Models{
    public class TestCases{
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string categoryName { get; set; }
        public string categoryType { get; set; }

        public int testPlanId { get; set; }

    }
}