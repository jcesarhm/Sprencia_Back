using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IActivityService
    {

        Task<List<Activity>> GetAllActivities();
        Task<ActivityDto> AddNewActivity(ActivityAddRequestDto newActivity);

        Task<ActivityDto> GetActivityById(int activityId);
     
        Task DeleteActivityById(int? activityId);

        Task<ActivityDto> ModifyActivityById( int activityId,  ActivityModifyRequestDto activityModifyRequestDto);

       

    }
}
