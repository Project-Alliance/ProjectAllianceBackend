using System;
namespace ProjectAlliance.Models
{
    public class User
    {
        public int id { set; get; }
        public string name { set; get; }
        public string password { set; get; }
        public string userName { set; get; }
        public string email { set; get; }
        public int age { set; get; }
        public User()
        {
        }
    }
}
