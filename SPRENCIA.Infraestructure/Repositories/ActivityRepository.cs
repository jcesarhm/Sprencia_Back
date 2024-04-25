﻿using Microsoft.EntityFrameworkCore;
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

            ActivityDto activityDto = new ActivityDto();

            activityDto.Id = activity.Id;
            activityDto.Name = activity.Name;
            activityDto.Description = activity.Description;
            activityDto.Prices = activity.Prices;
            activityDto.Summary = activity.Summary;


            return activity;
        }

        public async Task<Activity> DeleteActivityById(int activityId)
        {
           Activity? activity =  _context.Activities.Where( x => x.Id == activityId).FirstOrDefault();
           _context.Remove(activity);
            await _context.SaveChangesAsync();

            return activity;
        }

        public async Task<ActivityDto> ModifyActivityById(ActivityModifyRequestDto activityModifyRequestDto)
        {
           Activity? activityResult = _context.Activities.Where(x => x.Id == activityModifyRequestDto.Id).FirstOrDefault();

          
            activityResult.Name = activityModifyRequestDto.Name;
            activityResult.Description = activityModifyRequestDto.Description;
            activityResult.Prices = activityModifyRequestDto.Prices;
            activityResult.Summary = activityModifyRequestDto.Summary;
      

            _context.Activities.Update(activityResult);
            _context.SaveChanges();

            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activityModifyRequestDto.Id;
            activityDto.Name = activityModifyRequestDto.Name;
            activityDto.Description = activityModifyRequestDto.Description;
            activityDto.Prices = activityModifyRequestDto.Prices;
            activityDto.Summary = activityModifyRequestDto.Summary;

            return activityDto;
        

        }
    }
}
