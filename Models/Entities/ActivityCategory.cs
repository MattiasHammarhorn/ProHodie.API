namespace ProHodie.API.Models.Entities
{
    public class ActivityCategory
    {
        public int ActivityCategoryId { get; set; }
        public string ActivityCategoryName { get; set; }
        public string UserId { get; set; }

        public List<Activity>? Activities { get; set; }
        public ApplicationUser User { get; set; }
    }
}
