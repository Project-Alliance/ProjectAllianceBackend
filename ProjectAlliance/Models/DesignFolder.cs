
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    
    public class DesignFolder{
        [Key]
        public int id {set;get;}
        public string name {set;get;}

        public int projectId {get;set;}
        public int modifiedBy {get;set;}
        public string folderType {get;set;}

       [Column(TypeName = "Date")]
        public DateTime modifeidOn { get; set; }

        public DesignFolder()
        {
        }
    }
}