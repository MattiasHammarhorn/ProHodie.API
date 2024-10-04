
using Microsoft.EntityFrameworkCore;
using ProHodie.API.Models;

namespace ProHodie.API.Data
{
    public class ProHodieDbContext : DbContext
    {
        public ProHodieDbContext(DbContextOptions<ProHodieDbContext> options) :
            base(options)
        { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityCategory> ActivityCategories { get; set; }
    }
}
