using Microsoft.EntityFrameworkCore;
using ProHodie.API.Models;

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
            await _context.AddAsync(activity);

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

        public async Task<IEnumerable<Activity>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
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
            activityToEdit.StartDate = activity.StartDate;
            activityToEdit.EndDate = activity.EndDate;

            await _context.SaveChangesAsync();

            return activityToEdit;
        }
    }
}
