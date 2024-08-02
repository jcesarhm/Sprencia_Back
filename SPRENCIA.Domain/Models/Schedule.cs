using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPRENCIA.Domain.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ActivityId { get; set; }

    }
}
