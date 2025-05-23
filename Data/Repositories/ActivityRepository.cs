﻿using Microsoft.EntityFrameworkCore;
using ProHodie.API.Models.Entities;

namespace ProHodie.API.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly ProHodieDbContext _context;

        public ActivityRepository(ProHodieDbContext context)
        {
            _context = context;
        }
        public async Task<Activity> AddActivity(Activity activity)
        {
            _context.Add(activity);

            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task DeleteActivity(int id)
        {
            var activityToDelete = await _context.Activities.SingleOrDefaultAsync(a => a.Id == id);
            if (activityToDelete != null)
            {
                _context.Remove(activityToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Activity>> GetActivities(string? filter)
        {
            if (filter == "endTime=null")
                return await _context.Activities
                    .Include(a => a.EndTime == null)
                    .OrderByDescending(a => a.StartTime).ToListAsync();
            else
                return await _context.Activities
                    .Where(a => a.EndTime != null)
                    .OrderByDescending(a => a.StartTime).ToListAsync();
        }

        public async Task<Activity?> GetOngoingActivity()
        {
            return await _context.Activities.FirstOrDefaultAsync(a => a.EndTime == null);
        }

        public async Task<Activity?> GetActivityById(int id)
        {
            return await _context.Activities.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Activity> UpdateActivity(Activity activity)
        {
            var activityToEdit = await _context.Activities.SingleOrDefaultAsync(a => a.Id == activity.Id); 
            
            activityToEdit.Name = activity.Name;
            activityToEdit.ActivityCategoryId = activity.ActivityCategoryId;
            activityToEdit.StartTime = activity.StartTime;
            activityToEdit.EndTime = activity.EndTime;

            await _context.SaveChangesAsync();

            return activityToEdit;
        }
    }
}
