using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAlliance.Models
{
    public class BoardLane
    {
        [Key]
        public int lid { set; get; }
         public int projectId {get;set;}
        public string title { set; get; }

        public string label {get;set;}
        
        public string id {get;set;}


        public BoardLane()
        {
        }
    }
}
