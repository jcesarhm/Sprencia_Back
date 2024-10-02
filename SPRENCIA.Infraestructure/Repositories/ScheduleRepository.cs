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

         public async Task<List<Schedule>> GetAll()
 {
     var schedules =  await _context.Schedules.ToListAsync();

     return schedules;
 }
        public async Task<ScheduleDto> AddSchedule(ScheduleAddRequestDto newSchedule)
        {
            ScheduleAddRequestDto scheduleAddRequestDto = newSchedule;
            
            Schedule schedule = new Schedule();
            schedule.Name = scheduleAddRequestDto.Name;
           

            var scheduleAdded = await _context.Schedules.AddAsync(schedule);
            _context.SaveChanges();

            ScheduleDto scheduleDto = new ScheduleDto();

            scheduleDto.Id = scheduleAdded.Entity.Id;
            scheduleDto.Name = scheduleAdded.Entity.Name;
            return scheduleDto;
        }

        public async Task DeleteScheduleById(int? scheduleId)
        {
            Schedule? schedule = _context.Schedules.Where(x => x.Id == scheduleId).FirstOrDefault();
            _context.Remove(schedule);
            await _context.SaveChangesAsync();

            
        }

       

        public async Task<Schedule> GetScheduleById(int ScheduleId)
        {
            Schedule? schedule = _context.Schedules.Where(x => x.Id == ScheduleId).FirstOrDefault();

           

            return schedule;
        }

        public async Task<Schedule> GetActivityBySchedule(int ScheduleId)
        {

            Schedule? schedule = await _context.Schedules.FindAsync(ScheduleId);
            return schedule;

           

        }         
    }
}
