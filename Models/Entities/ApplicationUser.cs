using Microsoft.AspNetCore.Identity;

namespace ProHodie.API.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IEnumerable<Activity>? Activities { get; set; }
        public virtual IEnumerable<ActivityCategory>? ActivityCategories { get; set; }
    }
}
