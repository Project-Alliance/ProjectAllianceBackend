using System.ComponentModel.DataAnnotations;

namespace ProjectAlliance.Models
{
    public class DocumentSection
    {
        [Key]
        public int sectionId { set; get; }

        [MaxLength(30)]
        public string sectionName { set; get; }
        public string sectionDescription { set; get; }
        public int projectId { set; get; }
    }
}
