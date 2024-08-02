using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using System;

namespace SPRENCIA.Infraestructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        // Privatizar el contexto
        private readonly SprenciaDbContext _context;

        //Contexto
        public ActivityRepository(SprenciaDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Activity>> GetAll()
        {
            //Crear la Consulta LINQ
            var activities = await _context.Activities.ToListAsync();

            /// mapear cada uno de los elemntos del array en un Dto.

            return activities;

        }

        public async Task<List<Comment>> GetCommentsForActivity(int activityId)
        {
            return await _context.Comments.Where(c => c.ActivityId == activityId).ToListAsync();
        }

        //public async Task<List<Schedule>> GetSchedulesForActivity(int activityId)
        //{
          //  return await _context.Schedules.Where(c => c.ActivityId == activityId).ToListAsync();
       // }

        public  async Task<ActivityDto> AddActivity(ActivityAddRequestDto newActivity)
        {
            // Una vez recogido el formulario del front, hay que convertir en un objeto real, Activity
            ActivityAddRequestDto activityRequestDto = newActivity;

            Activity activity = new Activity();
            activity.Name = activityRequestDto.Name;
            activity.Description = activityRequestDto.Description;
            activity.Prices = activityRequestDto.Prices;
            activity.Summary = activityRequestDto.Summary;
            activity.Date = activityRequestDto.Date;
         
            // Haciendo el AddAsync, entity Framework nos devuelve el objeto creado.
            var activityAdded = await _context.Activities.AddAsync(activity);
            _context.SaveChanges();// se actualiza la base de datos 
            //Creamos un DTO para no mostrar campos que no queremos mostrar.
            ActivityDto activityDto = new ActivityDto();

            activityDto.Id = activityAdded.Entity.Id;
            activityDto.Name = activityAdded.Entity.Name;
            activityDto.Description = activityAdded.Entity.Description;
            activityDto.Prices = activityAdded.Entity.Prices;
            activityDto.Summary = activityAdded.Entity.Summary;
            activityDto.Date = activityAdded.Entity.Date;
            return activityDto;
        
        }

        public async Task<ActivityDto> GetActivityById(int activityId)
        {
            Activity? activity = _context.Activities.Where(x => x.Id == activityId).FirstOrDefault();

            ActivityDto activityDto = new ActivityDto();
            if(activity == null)
            {
                return null;
            }
            activityDto.Id = activity.Id;
            activityDto.Name = activity.Name;
            activityDto.Description = activity.Description;
            activityDto.Prices = activity.Prices;
            activityDto.Summary = activity.Summary;
            activityDto.Date = activity.Date;
            activityDto.Comments = activity.Comments;
            //activityDto.Schedules = activity.Schedules;

            return activityDto;
        }

        public async Task DeleteActivityById(int? activityId)
        {
           Activity? activity =  _context.Activities.Where( x => x.Id == activityId).FirstOrDefault();
           _context.Remove(activity);
            await _context.SaveChangesAsync();

           
        }

        public async Task<ActivityDto> ModifyActivityById(int activityId, ActivityModifyRequestDto activityModifyRequestDto)
        {
           Activity? activityResult = _context.Activities.Where(x => x.Id == activityId).FirstOrDefault();

          
            activityResult.Name = activityModifyRequestDto.Name;
            activityResult.Description = activityModifyRequestDto.Description;
            activityResult.Prices = activityModifyRequestDto.Prices;
            activityResult.Summary = activityModifyRequestDto.Summary;
            activityResult.Date = activityModifyRequestDto.Date;
            _context.Activities.Update(activityResult);
            _context.SaveChanges();
            /// GetActivityById
            /// _context.Activities.Where(x => x.Id == activityModifyRequestDto.Id).FirstOrDefault();

            Activity? activityModify = _context.Activities.Where(x => x.Id == activityId).FirstOrDefault();

            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activityModify.Id;
            activityDto.Name = activityModify.Name;
            activityDto.Description = activityModify.Description;
            activityDto.Prices = activityModify.Prices;
            activityDto.Summary = activityModify.Summary;
            //activityDto.Schedules = activityModify.Schedules;  
            activityDto.Date = activityModify.Date;
            /// activity

            return activityDto;
        

        }
    }
}
