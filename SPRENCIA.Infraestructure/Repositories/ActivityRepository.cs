using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Repositories
{
    public class ActivityRepository : IActivity
    {
        // Privatizar el contexto
        private readonly SprenciaDbContext _context;

        //Contexto
        public ActivityRepository(SprenciaDbContext dbContext) 
        { 
            _context = dbContext;
        }



        public async Task<List<Activity>> GetAll()
        {
            //Crear la Consulta LINQ
            var activities = await _context.Activities.ToListAsync();

            return activities;
            
        }
    }
}
