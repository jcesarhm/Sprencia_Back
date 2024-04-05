using SPRENCIA.Domain.Models;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAll();
    }
}
