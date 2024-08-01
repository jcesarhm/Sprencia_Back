using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure
{
    public class SprenciaDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
           
            optionsBuilder.UseSqlServer("Server = DESKTOP-9NPKDB6\\SQLEXPRESS;User Id=sa;Password=12345; Database = SprenciaDb; Trusted_Connection = True;Encrypt=False");
        }



    }
}