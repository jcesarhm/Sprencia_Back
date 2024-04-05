using SPRENCIA.Domain.Models;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetAllSchedule();
    }
}
