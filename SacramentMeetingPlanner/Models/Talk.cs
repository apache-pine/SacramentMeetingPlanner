namespace SacramentMeetingPlanner.Models
{
    public class Talk
    {
        public int TalkId { get; set; }

        public string? TalkType { get; set;}

        public string? SpeakerName { get; set;}

        public string? Topic { get; set;}

        public int MeetingId { get; set; }

        public Meeting Meeting { get; set; }
    }
}
