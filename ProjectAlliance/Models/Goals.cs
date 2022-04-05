using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models
{
    public class Goals
    {
        [Key]
        public int id { set; get; }

        [MaxLength(30)]
        public string goalName { set; get; }
        public string goalDescription { set; get; }
        public DateTime statingDate { set; get; }
        public DateTime endingDate { set; get; }
        public int companyId { set; get; }

        public Goals()
        {
        }
    }
}
