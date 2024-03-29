
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

        public int testId {get;set;}

        [NotMapped]
        public List<IFormFile> ExpectedOutcomeFile { get; set; }
        [NotMapped]
        public List<IFormFile> testOutComeFile { get; set; }
    }
}