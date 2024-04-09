using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivityAddRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Prices { get; set; }
        public string Summary { get; set; }

    }
}
