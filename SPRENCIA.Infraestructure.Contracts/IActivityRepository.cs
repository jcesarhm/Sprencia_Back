﻿using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAll();
        Task<ActivityDto> AddActivity(ActivityAddRequestDto newActivity);

        Task<Activity> GetActivityById(int activityId);

        Task<Activity> DeleteActivityById(int ActivityId);

        Task<ActivityDto> ModifyActivityById(ActivityModifyRequestDto activityModifyRequestDto);

      
    }
}
