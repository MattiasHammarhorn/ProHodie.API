namespace ProHodie.API.Models.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public int ActivityCategoryId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }

        public ApplicationUser User { get; set; }
        public virtual ActivityCategory ActivityCategory { get; set; }
    }
}
