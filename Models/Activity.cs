namespace ProHodie.API.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivityCategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
