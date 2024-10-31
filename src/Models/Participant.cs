namespace MeU_EventManagementSystem_API.Models
{
    public class Participant
    {
        public int ParticipantID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<QRCheckIn> QRCheckIns { get; set; }
    }
}
