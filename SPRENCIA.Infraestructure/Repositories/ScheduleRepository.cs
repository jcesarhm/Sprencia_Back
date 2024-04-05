using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;

namespace SPRENCIA.Infraestructure.Repositories
{
    internal class ScheduleRepository : IScheduleRepository
    {
        private readonly SprenciaDbContext _context;

        public ScheduleRepository(SprenciaDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public Task<List<Schedule>> GetAll()
        {
            var schedules = _context.Schedules.ToListAsync();

            return schedules;
        }
    }
}
