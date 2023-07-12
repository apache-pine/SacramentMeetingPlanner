using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Hymn
    {
        public int HymnId { get; set; }

        public string? HymnName { get; set; }

        public string? HymnType { get; set; }

        [Range(0, 400)]
        public int? HymnPage { get; set; }

        public int MeetingId { get; set; }

        public Meeting Meeting { get; set; }
    }
}
