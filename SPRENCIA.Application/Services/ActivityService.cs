using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;

namespace SPRENCIA.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityService(IActivityRepository activityRepository) 
        {
            // hacemos la conexion entre Services y Repository
            _activityRepository = activityRepository;
        }
        public async Task<List<Activity>> GetAllActivities()
        {
            // llamamos al metodo repository que nos devuelva los datos que nos interesa
            var AllActivities = await _activityRepository.GetAll(); 
            // await es para que la app espere la respuesta

            return AllActivities;
        }
    }
}
