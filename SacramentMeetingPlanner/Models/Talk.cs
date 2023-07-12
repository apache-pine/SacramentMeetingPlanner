using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Talk
    {
        public int TalkId { get; set; }

        public string? TalkType { get; set;}

        [StringLength(60, MinimumLength = 3)]
        public string? SpeakerName { get; set;}

        [StringLength(60, MinimumLength = 3)]
        public string? Topic { get; set;}

        public int MeetingId { get; set; }

        public Meeting Meeting { get; set; }
    }
}
