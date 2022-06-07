

using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models
{
    public class DesignAttachment
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int designId { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentExtension { get; set; }




        public DesignAttachment()
        {
        }
    }}