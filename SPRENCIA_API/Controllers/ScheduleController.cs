using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA_API.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            //Hacemos la conexion entre Controller y Service
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<List<Schedule>> GetAll() 
        {
            // Controladores solamente tiene que llamar a servicios.
            // No debe de hacer ninguna operacion.
            var getAllSchedule = await _scheduleService.GetAllSchedule();

            return getAllSchedule;
        }

        [HttpGet("{scheduleId}")]
        public async Task<ActionResult> GetScheduleById(int scheduleId)
        {
            var scheduleById = _scheduleService.GetScheduleById(scheduleId);
            return Ok(scheduleById);
        }

        [HttpPost]
        [Route("AddSchedule")]
        //REcuerda poner el ActionResult
        public async Task<ActionResult> AddNewSchedule([FromBody] Schedule schedule)
        {
            var scheduleAdded = await _scheduleService.AddNewSchedule(schedule);

            if (scheduleAdded == null)

            {

                //Aqui hay un error o el DTO esta vacio
                return BadRequest("la peticion es incorrecta");
            }
            else
            {
                //Aqui ha ido todo bien 
                return Ok(scheduleAdded);
            }

        }

        [HttpDelete("{scheduleId}")]

        public async Task<ActionResult> DeleteScheduleById(int scheduleId)
        {
            Schedule? schedule = await _scheduleService.DeleteScheduleById(scheduleId);

            if (schedule == null)
            {
                return BadRequest(" la peticion es incorrecta");
            }

            return Ok(schedule);

        }
    }
}
