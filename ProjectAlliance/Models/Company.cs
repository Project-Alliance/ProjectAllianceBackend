using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models
{
    public class Company
    {
        [Key]
        public int id { set; get; }

        [MaxLength(30)]
        public string companyName { set; get; }
        public string createdBy { set; get; }

        public Company()
        {
        }
    }
}
