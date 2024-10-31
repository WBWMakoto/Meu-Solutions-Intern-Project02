namespace MeU_EventManagementSystem_API.Models
{
    public class NewsFeed
    {
        public int NewsID { get; set; }
        public int EventID { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public Event Event { get; set; }
    }
}
