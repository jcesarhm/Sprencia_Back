using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository) 
        {
          _scheduleRepository = scheduleRepository;
        }

        public async Task<ScheduleDto> AddNewSchedule(ScheduleAddRequestDto newSchedule)
        {
            ScheduleDto? scheduleAdded = null;

            if (newSchedule != null)
            {
                scheduleAdded = await _scheduleRepository.AddSchedule(newSchedule); 
            }

            return scheduleAdded;
        }

        public async Task DeleteScheduleById(int? scheduleId)
        {
           
            if (scheduleId != null)
            {
                await _scheduleRepository.DeleteScheduleById(scheduleId);
            }

           
        }

        public async Task<List<Schedule>> GetAllSchedules()
        {
            var allSchedules = await _scheduleRepository.GetAll();

            return allSchedules;
        }

        public  async Task<Schedule> GetScheduleById(int scheduleId)
        {
            Schedule schedule = null;
            if (scheduleId != null)
            {
                schedule = await _scheduleRepository.GetScheduleById(scheduleId);
            }

            return schedule;
        }
    }
}
