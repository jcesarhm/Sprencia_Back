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
        [HttpGet("All")]
        public async Task<List<Activity>> GetAll()
        {
            // Controladores solamente tiene que llamar a servicios.
            // No debe de hacer ninguna operacion.
            var getAllActivity = await _activityService.GetAllActivities();

            return getAllActivity;
        }

        [HttpGet("{activityId}")]
        public async Task<ActionResult<ActivityDto>> GetActivityById(int activityId)
        {
            var activityById = await _activityService.GetActivityById(activityId);
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
            await _activityService.DeleteActivityById(activityId);
           
        

            return Ok();
  
        }

        [HttpPut]
        [Route("{activityId}")]

        public async Task<ActionResult> ModifyActivityById([FromRoute] int activityId, [FromBody] ActivityModifyRequestDto activityModifyRequestDto)
        {
           ActivityDto? activityModify = await _activityService.ModifyActivityById(activityId, activityModifyRequestDto);
           
            return Ok(activityModify);
        }
    }
}
