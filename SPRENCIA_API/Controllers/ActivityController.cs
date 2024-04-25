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

        [HttpGet("{activityId}")]
        public async Task<ActionResult> GetActivityById(int activityId)
        {
            var activityById = _activityService.GetActivityById(activityId);
            return Ok(activityById);
        }


        [HttpPost]
        [Route("AddActivity")]
        //REcuerda poner el ActionResult
        public async Task<ActionResult> AddNewActivity([FromBody] ActivityAddRequestDto activity)
        {
            var activityAdded = await _activityService.AddNewActivity(activity);

            if (activityAdded == null)

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

        [HttpDelete ("{activityId}")]

        public async Task<ActionResult> DeleteActivityById(int activityId)
        {
            Activity? activity = await _activityService.DeleteActivityById(activityId);
           
            if (activity == null)
            {
                return BadRequest(" la peticion es incorrecta");
            }

            return Ok(activity);
  
        }

        [HttpPut]
        [Route("ModifyActivity")]

        public async Task<ActionResult> ModifyActivityById([FromBody] ActivityModifyRequestDto activityModifyRequestDto)
        {
            ActivityDto? activityModify = await _activityService.ModifyActivityById(activityModifyRequestDto);
            if (activityModify == null)
            {
                return BadRequest("la peticion es incorrecta");
            }

            return Ok(activityModify);
        }
    }
}
