namespace MeU_EventManagementSystem_API.Models
{
    public class QRCheckIn
    {
        public int CheckInID { get; set; }
        public int EventID { get; set; }
        public int ParticipantID { get; set; }
        public DateTime CheckInTime { get; set; }
        public Event Event { get; set; }
        public Participant Participant { get; set; }
    }
}
