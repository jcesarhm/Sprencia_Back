using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public int Qualification { get; set; }
        public int? ActivityId { get; set; }

        public DateTime Date { get; set; }

    
    }
}
