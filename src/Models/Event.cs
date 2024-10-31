namespace MeU_EventManagementSystem_API.Models
{
    public class Event
{
    public int EventID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Timeline { get; set; }
    public string ImageURL { get; set; }
    public string CreatedBy { get; set; }
    public List<EventSponsor> EventSponsors { get; set; }
    public List<QRCheckIn> QRCheckIns { get; set; }
    public List<NewsFeed> NewsFeeds { get; set; }
}
}
