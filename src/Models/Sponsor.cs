namespace MeU_EventManagementSystem_API.Models
{
    public class Sponsor
    {
        public int SponsorID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteURL { get; set; }
        public List<EventSponsor> EventSponsors { get; set; }
    }
}
