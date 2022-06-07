
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Models{
    public class Design{
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string url { get; set; }
        public int folderId { get; set; }
        [NotMapped]
        public List<IFormFile> file { set; get; }
    }
}