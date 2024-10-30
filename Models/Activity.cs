namespace ProHodie.API.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivityCategoryId { get; set; }
        public DateTimeOffset StartTime{ get; set; }
        public DateTimeOffset? EndTime { get; set; }
    }
}
