using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> GetAll();

        Task<Schedule> GetScheduleById(int ScheduleId);

        Task<Schedule> AddSchedule(Schedule newSchedule);

        Task DeleteScheduleById(int? cheduleId);
    }
}
