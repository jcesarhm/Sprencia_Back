using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Prices { get; set; }
        public string Summary { get; set; }

        public DateTime Date { get; set; }
        public  int? ScheduleId { get; set; }
        public string ScheduleName { get; set; }
        
        public List<Comment> Comments{ get; set; }
    }
}
