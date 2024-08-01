using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class CommentAddRequestDto
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public int Qualification { get; set; }
        public int? ActivityId { get; set; }

        public DateTime Date { get; set; }
    }
}
