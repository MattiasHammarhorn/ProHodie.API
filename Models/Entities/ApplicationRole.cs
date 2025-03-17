using Microsoft.AspNetCore.Identity;

namespace ProHodie.API.Models.Entities
{
    public class ApplicationRole: IdentityRole
    {
        public string? Description { get; set; }
    }
}
