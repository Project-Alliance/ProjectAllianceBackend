using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectAlliance.Models
{
    public class User
    {
        [Key]
        public int id { set; get; }
        [MaxLength(30)]
        public string name { set; get; }
        public string password { set; get; }
        public string userName { set; get; }
        public string email { set; get; }
        public string profilePic { set; get; }
        public string phone { set; get; }
        
        [Timestamp]
        public byte[] Lastlogin { set; get; }
        public string role { set; get; }
        public string onlineStatus { set; get; }

        public string companyId { get; set; }

        [NotMapped]
        public string company { get; set; }
        [NotMapped]
        public string accessToken { get; set; }

        public User()
        {
        }
    }
}
