using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models
{
    public class Comments
    {
        [Key]
        public int id { set; get; }

        public string comId { set; get; }

         public int userId {get;set;}
         public int reqId {get;set;}
         public string text {get;set;}

        public Comments()
        {
        }
    }
}
