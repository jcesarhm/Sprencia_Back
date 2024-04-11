using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using System.Reflection.Metadata.Ecma335;

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

        [HttpPost]
        [Route("AddActivity")]
        //REcuerda poner el ActionResult
        public async Task<ActionResult> AddNewActivity([FromBody] ActivityAddRequestDto activity)
        {
            var activityAdded = await _activityService.AddNewActivity(activity);

            if(activityAdded == null) 

            {

                //Aqui hay un error o el DTO esta vacio
                return BadRequest("la peticion es incorrecta");
            }
            else
            {
                //Aqui ha ido todo bien 
                return Ok(activityAdded);
            }
           
        }
        [HttpGet("{activityId}")]
        public async Task<ActionResult> GetActivityById(int activityId)
        {
            var activityById = _activityService.GetActivityById(activityId);
            return Ok(activityById);
        }
        
    }
}
