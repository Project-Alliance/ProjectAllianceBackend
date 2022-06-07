
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Models{
    public class TestResult{
        [Key]
        public int id { get; set; }
        public string Description { get; set; }
        public string ExpectedOutcome { get; set; }

        public string testOutCome { get; set; }
        public string url { get; set; }

        public int testId {get;set;}
    }
}