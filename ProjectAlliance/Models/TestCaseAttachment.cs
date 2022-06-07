

using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models
{
    public class TestCaseAttachment
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int testresultId { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentExtension { get; set; }
        public string AtttachmentType { get; set; }




        public TestCaseAttachment()
        {
        }
    }}