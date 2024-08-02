using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ActivityId { get; set; }
    }
}
