using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> GetAll();

        Task<Schedule> GetScheduleById(int ScheduleId);

        Task<ScheduleDto> AddSchedule(ScheduleAddRequestDto newSchedule);

        Task DeleteScheduleById(int? scheduleId);

        Task<Schedule> GetActivityBySchedule(int scheduleId);
    }
}
