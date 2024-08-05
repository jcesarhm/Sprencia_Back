using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IScheduleService
    {
        Task<List<Schedule>>GetAllSchedules();

        Task<Schedule> GetScheduleById(int scheduleId);

        Task<ScheduleDto> AddNewSchedule(ScheduleAddRequestDto newSchedule);

        Task DeleteScheduleById(int? scheduleId);
    }
}
