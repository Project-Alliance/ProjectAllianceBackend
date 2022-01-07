using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectAlliance.Models
{
    //[Table("User")]
    public class User
    {
        [Key]
        public int id { set; get; }
        //[Column("PTitle", TypeName = "ntext")]
        [MaxLength(30)]
        public string name { set; get; }
        //[Column("password", TypeName = "ntext")]
        public string password { set; get; }
        //[Column("userName", TypeName = "ntext")]
        public string userName { set; get; }
        //[Column("email", TypeName = "ntext")]
        public string email { set; get; }
        [ForeignKey("UserId")]
        public ICollection<Members> members { get; set; }
        [NotMapped]
       public string accessToken { get; set; }

        public User()
        {
        }
    }
}
