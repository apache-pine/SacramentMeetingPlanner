namespace SacramentMeetingPlanner.Models
{
    public class MeetingViewModel
    {
        public Meeting Meeting { get; set; }
        public IEnumerable<Talk> Talks { get; set; }
        public IEnumerable<Hymn> Hymns { get; set; }
    }
}
