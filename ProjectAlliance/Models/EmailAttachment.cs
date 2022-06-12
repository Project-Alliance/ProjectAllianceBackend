using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models
{
    public class EmailAttachment
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int emailId { get; set; }
        public string path { get; set; }
        public string ext { get; set; }
        public string fakeName { get; set; }


        public EmailAttachment()
        {
        }
    }
}
