using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    //[Table("ProjectMemebrs")]
    public class Members
    {
        [Key]
        public int mid { get; set; }
        //[Column("role",TypeName = "ntext")]
      
        public Members()
        {
        }
    }
}
