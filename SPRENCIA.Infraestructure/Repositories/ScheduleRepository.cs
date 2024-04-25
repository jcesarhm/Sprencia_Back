using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using System.ComponentModel.Design;

namespace SPRENCIA.Infraestructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly SprenciaDbContext _context;

        public ScheduleRepository(SprenciaDbContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<Schedule> AddSchedule(Schedule newSchedule)
        {
            Schedule schedule = newSchedule;

            var scheduleAdded = await _context.Schedules.AddAsync(schedule);

            return scheduleAdded.Entity;
        }

        public async Task<Schedule> DeleteScheduleById(int scheduleId)
        {
            Schedule? schedule = _context.Schedules.Where(x => x.Id == scheduleId).FirstOrDefault();
            _context.Remove(schedule);
            await _context.SaveChangesAsync();

            return schedule;
        }

        public Task<List<Schedule>> GetAll()
        {
            var schedules = _context.Schedules.ToListAsync();

            return schedules;
        }

        public async Task<Schedule> GetScheduleById(int ScheduleId)
        {
            Schedule? schedule = _context.Schedules.Where(x => x.Id == ScheduleId).FirstOrDefault();

           

            return schedule;
        }
    }
}
