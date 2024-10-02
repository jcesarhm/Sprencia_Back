using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Services
{
    public class ActivityService: IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IScheduleRepository _scheduleRepository;
        public ActivityService(IActivityRepository activityRepository, IScheduleRepository scheduleRepository)
        {
            // hacemos la conexion entre Services y Repository
            _activityRepository = activityRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<Activity>> GetAllActivities()
        {
            // llamamos al metodo repository que nos devuelva los datos que nos interesa
            var allActivities = await _activityRepository.GetAll();
            // await es para que la app espere la respuesta

            return allActivities;
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

        public async Task<ActivityDto1> GetActivityById(int activityId)
        {
            Activity activity = null ;
            if (activityId  != null ) 
            { 
                activity = await _activityRepository.GetActivityById(activityId);

                activity.Comments = await _activityRepository.GetCommentsForActivity(activityId);

                var schedule = await _scheduleRepository.GetActivityBySchedule(activity.ScheduleId);

            ActivityDto1 activityDto1 = new ActivityDto1();
                if (activity == null)
                {
                    return null;
                }
                activityDto1.Id = activity.Id;
                activityDto1.Name = activity.Name;
                activityDto1.Description = activity.Description;
                activityDto1.Prices = activity.Prices;
                activityDto1.Summary = activity.Summary;
                activityDto1.Date = activity.Date;
                activityDto1.Comments = activity.Comments;
                activityDto1.ScheduleName = schedule.Name;

            return activityDto1;
            }

            return null;
        }

        public async Task DeleteActivityById(int? activityId)
        {
     
            if (activityId != null)
            {
               await _activityRepository.DeleteActivityById(activityId.Value);
            }

          
        }

        public async Task<ActivityDto> ModifyActivityById(int activityId, ActivityModifyRequestDto activityModifyRequestDto)
        {
            ActivityDto? activityModify = null;
            if (activityModifyRequestDto != null)
            {
                activityModify = await _activityRepository.ModifyActivityById(activityId, activityModifyRequestDto);

            
                /// hacer una peticion Schdule al respositorio ( scheduleId ) 
                /// 

            }

            return activityModify;
        }
    }
}
