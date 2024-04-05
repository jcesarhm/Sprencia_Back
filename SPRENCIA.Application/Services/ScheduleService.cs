using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;

namespace SPRENCIA.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository) 
        {
          _scheduleRepository = scheduleRepository;
        }

        public async Task<List<Schedule>> GetAllSchedule()
        {
            var AllSchedule = await _scheduleRepository.GetAll();

            return AllSchedule;
        }
    }
}
