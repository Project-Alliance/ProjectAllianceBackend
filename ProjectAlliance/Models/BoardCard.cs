using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models
{
    public class BoardCard
    {
        [Key]
        public int cid { set; get; }
        public string lid {get;set;}
        public string title { set; get; }

         public string label {get;set;}
         public string description {get;set;}
         public string id {get;set;}


        public BoardCard()
        {
        }
    }
}
