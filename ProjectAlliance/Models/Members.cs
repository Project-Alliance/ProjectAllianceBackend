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
        public string Role { get; set; }
        //[ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User Uid { get; set; }
        //[ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public virtual Projects Pid { get; set; }
        public Members()
        {
        }
    }
}
