
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectAlliance.Models{
    public class RecevidMail{
        
        [Key]
        public int id {set;get;}
        public string subject {set;get;}
        public string title {set;get;}
        public string description {set;get;}
        [Column(TypeName = "DateTime")]
        public DateTime time { set; get; }
        public string to { set; get; }
        public string from { set; get; }
        public bool isRead { set; get; }
        public bool isStared { set; get; }
        public string company { set; get; }

        [NotMapped]
        public List<IFormFile> mailAttachment { set; get; }

        [NotMapped]
        public List<string> ToList { set; get; }
    }
}