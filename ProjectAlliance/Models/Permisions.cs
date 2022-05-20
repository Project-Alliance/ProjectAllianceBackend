

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    //[Table("Projects")]
    public class Permisions
    {
        [Key]
        public int permisionId { get; set; }
        public string permisionTitle { get; set; }
        public bool create { get; set; }
        public bool update { get; set; }
        public bool Delete { get; set; }
        public bool read { get; set; }
        public int userId { get; set; }


        public Permisions()
        {
        }
    }
}
