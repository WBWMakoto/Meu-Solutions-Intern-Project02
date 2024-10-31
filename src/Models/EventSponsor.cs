namespace MeU_EventManagementSystem_API.Models
{
    public class EventSponsor
    {
        public int EventSponsorID { get; set; }
        public int EventID { get; set; }
        public int SponsorID { get; set; }
        public Event Event { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
