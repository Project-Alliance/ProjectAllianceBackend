using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models
{
    public class CommentsReplies
    {
        [Key]
        public int id { set; get; }

         public int userId {get;set;}
        public string comId {get;set;}
         public string text {get;set;}

         public string parentCommentId { set; get; }

        public CommentsReplies()
        {
        }
    }
}
