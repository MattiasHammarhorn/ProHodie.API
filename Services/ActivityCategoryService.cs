using ProHodie.API.Data.Repositories;
using ProHodie.API.Models;

namespace ProHodie.API.Services
{
    public class ActivityCategoryService : IActivityCategoryService
    {
        private readonly IActivityCategoryRepository _repository;

        public ActivityCategoryService(IActivityCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActivityCategory> AddActivityCategory(ActivityCategory activityCategory)
        {
            return await _repository.AddActivityCategory(activityCategory);
        }

        public async Task DeleteActivityCategory(int id)
        {
            await _repository.DeleteActivityCategory(id);
        }

        public async Task<IEnumerable<ActivityCategory>> GetActivityCategories()
        {
            return await _repository.GetActivityCategories();
        }

        public async Task<ActivityCategory?> GetActivityCategoryById(int id)
        {
            return await _repository.GetActivityCategoryById(id);
        }

        public async Task<ActivityCategory> UpdateActivityCategory(ActivityCategory activityCategory)
        {
            return await _repository.UpdateActivityCategory(activityCategory);
        }
    }
}
