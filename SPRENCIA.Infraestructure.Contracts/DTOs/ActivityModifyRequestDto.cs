using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    /// <summary>
    /// DTO de entrada para la modificacion del cliente
    /// </summary>
    public class ActivityModifyRequestDto
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Prices { get; set; }

        public string Summary { get; set; }

        public int  ScheduleId { get; set; }



      
    }
}
