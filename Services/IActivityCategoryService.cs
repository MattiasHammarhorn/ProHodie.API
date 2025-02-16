using ProHodie.API.Models.Entities;

namespace ProHodie.API.Services
{
    public interface IActivityCategoryService
    {
        Task<IEnumerable<ActivityCategory>> GetActivityCategories();
        Task<ActivityCategory?> GetActivityCategoryById(int id);
        Task<ActivityCategory> AddActivityCategory(ActivityCategory activityCategory);
        Task<ActivityCategory> UpdateActivityCategory(ActivityCategory activityCategory);
        Task DeleteActivityCategory(int id);
    }
}
