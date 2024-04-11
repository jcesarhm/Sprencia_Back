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

            return activities;
            
        }

        public  async Task<ActivityDto> AddActivity(ActivityAddRequestDto newActivity)
        {
            // Una vez recogido el formulario del front, hay que convertir en un objeto real, Activity
            ActivityAddRequestDto activityRequestDto = newActivity;

            Activity activity = new Activity();
            activity.Name = activityRequestDto.Name;
            activity.Description = activityRequestDto.Description;
            activity.Prices = activityRequestDto.Prices;
            activity.Summary = activityRequestDto.Summary;
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


            return activityDto;

        }

      

        public async Task<Activity> GetActivityById(int activityId)
        {
            Activity? activity = _context.Activities.Where(x => x.Id == activityId).FirstOrDefault();

            return activity;
        }
    }
}
