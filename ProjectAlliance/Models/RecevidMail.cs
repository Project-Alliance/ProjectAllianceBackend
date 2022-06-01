
using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models{
    public class RecevidMail{
        
        [Key]
        public int id {set;get;}
        public int projectId {set;get;}
        public int dcumentId {set;get;}
        public int sharedBy {set;get;}

        public int sharedTO { set; get; }
    }
}