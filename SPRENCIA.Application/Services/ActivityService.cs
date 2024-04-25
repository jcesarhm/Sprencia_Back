using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;

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

        public async Task<ActivityDto> AddNewActivity(ActivityAddRequestDto newActivity)
        {
            ActivityDto? activityAdded = null;
            //Validar Formulario
            if(newActivity != null)
            {
                activityAdded = await _activityRepository.AddActivity(newActivity);
            }
            return activityAdded;
        }

        public async Task<Activity> GetActivityById(int activityId)
        {
            Activity activity = null;
            if (activityId != null) 
            { 
                activity = await _activityRepository.GetActivityById(activityId);
            }

            return activity;
        }

        public async Task<Activity> DeleteActivityById(int activityId)
        {
            Activity activityDelete = null;
            if (activityId != null)
            {
                activityDelete = await _activityRepository.DeleteActivityById(activityId);
            }

            return activityDelete;
        }

        public async Task<ActivityDto> ModifyActivityById(ActivityModifyRequestDto activityModifyRequestDto)
        {
            ActivityDto? activityModify = null;
            if (activityModifyRequestDto != null)
            {
                activityModify = await _activityRepository.ModifyActivityById(activityModifyRequestDto);
            }

            return activityModify;
        }
    }
}
