
using System;

namespace ProjectAlliance.Models
{
    public class RequirementAttachment
    {
        public int id { get; set; }
        public string name { get; set; }
        public int requirementId { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentExtension { get; set; }




        public RequirementAttachment()
        {
        }
    }}