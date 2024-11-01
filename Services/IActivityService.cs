using ProHodie.API.Models;

namespace ProHodie.API.Services
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetActivities();
        Task<Activity?> GetOngoingActivity();
        Task<Activity?> GetActivityById(int id);
        Task<Activity> AddActivity(Activity activity);
        Task<Activity> UpdateActivity(Activity activity);
        Task DeleteActivity(int id);
    }
}
