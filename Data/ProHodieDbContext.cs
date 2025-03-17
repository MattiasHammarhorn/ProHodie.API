using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProHodie.API.Models.Entities;

namespace ProHodie.API.Data
{
    public class ProHodieDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ProHodieDbContext(DbContextOptions<ProHodieDbContext> options) :
            base(options)
        { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityCategory> ActivityCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActivityCategory>()
                .HasMany<Activity>(e => e.Activities)
                .WithOne(e => e.ActivityCategory)
                .HasForeignKey("ActivityCategoryId");

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<ActivityCategory>(e => e.ActivityCategories)
                .WithOne(e => e.User)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany<Activity>(e => e.Activities)
                .WithOne(e => e.User)
                .HasForeignKey("UserId");
        }
    }
}
