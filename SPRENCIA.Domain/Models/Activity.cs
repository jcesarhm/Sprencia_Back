using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPRENCIA.Domain.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int Prices { get; set; }

        public string Summary { get; set; }

        public DateTime Date { get; set; }
     
        //public List<Schedule> Schedules { get; set; }


        public List<Comment> Comments { get; set; }
    }
}
