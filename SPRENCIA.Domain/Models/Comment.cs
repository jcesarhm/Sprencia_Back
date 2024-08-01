using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPRENCIA.Domain.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Detail { get; set; }
        [Required]
        public int Qualification { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("ActivityId")]
        public int? ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
