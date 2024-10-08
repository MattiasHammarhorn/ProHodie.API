using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ProHodie.API.Models;

namespace ProHodie.API.Data.Repositories
{
    public class ActivityCategoryRepository : IActivityCategoryRepository
    {
        private readonly ProHodieDbContext _context;

        public ActivityCategoryRepository(ProHodieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ActivityCategory>> GetActivityCategories()
        {
            return await _context.ActivityCategories.ToListAsync();
        }

        public async Task<ActivityCategory> AddActivityCategory(ActivityCategory activityCategory)
        {
            await _context.ActivityCategories.AddAsync(activityCategory);
            await _context.SaveChangesAsync();
            return activityCategory;
        }

        public async Task DeleteActivityCategory(int id)
        {
            var activityToDelete = await _context.ActivityCategories.SingleOrDefaultAsync();
        }

        public async Task<ActivityCategory?> GetActivityCategoryById(int id)
        {
            return await _context.ActivityCategories.SingleOrDefaultAsync(ac => ac.ActivityCategoryId == id);
        }

        public async Task<ActivityCategory> UpdateActivityCategory(ActivityCategory activityCategory)
        {
            var activityCategoryToUpdate = await _context.ActivityCategories.FirstOrDefaultAsync(ac => ac.ActivityCategoryId == activityCategory.ActivityCategoryId);

            activityCategoryToUpdate.ActivityCategoryName = activityCategory.ActivityCategoryName;

            await _context.SaveChangesAsync();
            return activityCategoryToUpdate;
        }
    }
}
