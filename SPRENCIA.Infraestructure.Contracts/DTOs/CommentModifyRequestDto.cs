using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class CommentModifyRequestDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Detail { get; set; }

        public int Qualification { get; set; }

        public DateTime Date { get; set; }


    }
}
