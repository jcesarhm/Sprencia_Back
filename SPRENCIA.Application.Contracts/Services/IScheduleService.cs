using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetAllSchedule();

        Task<Schedule> GetScheduleById(int scheduleId);

        Task<Schedule> AddNewSchedule(Schedule newSchedule);

        Task<Schedule> DeleteScheduleById(int scheduleId);
    }
}
