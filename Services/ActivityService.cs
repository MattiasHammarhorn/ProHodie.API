using ProHodie.API.Data.Repositories;
using ProHodie.API.Models;

namespace ProHodie.API.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _repository;

        public ActivityService(IActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Activity> AddActivity(Activity activity)
        {
            return await _repository.AddActivity(activity);
        }

        public async Task DeleteActivity(int id)
        {
            await _repository.DeleteActivity(id);
        }

        public async Task<IEnumerable<Activity>> GetActivities()
        {
            return await _repository.GetActivities();
        }

        public async Task<Activity?> GetActivityById(int id)
        {
            return await _repository.GetActivityById(id);
        }

        public async Task<Activity?> GetOngoingActivity()
        {
            return await _repository.GetOngoingActivity();
        }

        public async Task<Activity> UpdateActivity(Activity activity)
        {
            return await _repository.UpdateActivity(activity);
        }
    }
}
