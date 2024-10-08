using ProHodie.API.Models;

namespace ProHodie.API.Data.Repositories
{
    public interface IActivityCategoryRepository
    {
        Task<IEnumerable<ActivityCategory>> GetActivityCategories();
        Task<ActivityCategory?> GetActivityCategoryById(int id);
        Task<ActivityCategory> AddActivityCategory(ActivityCategory activityCategory);
        Task<ActivityCategory> UpdateActivityCategory(ActivityCategory activityCategory);
        Task DeleteActivityCategory(int id);
    }
}
