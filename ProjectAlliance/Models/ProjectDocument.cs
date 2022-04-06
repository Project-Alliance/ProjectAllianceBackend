using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace ProjectAlliance.Models
{

    public class ProjectDocument
    {
        [Key]
        public int documentId { set; get; }

        [MaxLength(30)]
        public string documentName { set; get; }
        public string documentDescription { set; get; }
        public string documentStatus { set; get; }
        public string uploadBy { set; get; }
        public string documentVersion { set; get; }
        public string filePath { set; get; }
        public int sectionId { set; get; }
        public int projectId { set; get; }
        public string documentFileExtension { set; get; }

        [NotMapped]
        public IFormFile file { set; get; }

    }
}

