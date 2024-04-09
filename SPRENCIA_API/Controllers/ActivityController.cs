using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;

namespace SPRENCIA_API.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            //Hacemos la conexion entre Controller y Service
            _activityService = activityService;
        }
        [HttpGet]
        public async Task<List<Activity>> GetAll() 
        {
            // Controladores solamente tiene que llamar a servicios.
            // No debe de hacer ninguna operacion.
            var getAllActivity = await _activityService.GetAllActivities();

            return getAllActivity;
        }

      
    }
}
