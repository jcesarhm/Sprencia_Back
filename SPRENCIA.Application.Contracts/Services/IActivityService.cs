using SPRENCIA.Domain.Models;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IActivityService
    {

        Task<List<Activity>> GetAllActivities();
    }
}
