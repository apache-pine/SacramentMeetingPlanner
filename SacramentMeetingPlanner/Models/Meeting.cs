using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        public Meeting()
        {
            this.Talks = new HashSet<Talk>();
            this.Hymns = new HashSet<Hymn>();
        }

        public int MeetingId { get; set; }

        [Display(Name = "Meeting Date"), DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }

        public string Presiding { get; set; }

        public string Conducting { get; set; }

        public string Invocation { get; set; }

        public string Benediction { get; set; }

        public virtual ICollection<Talk> Talks { get; set; }
        public virtual ICollection<Hymn> Hymns { get; set; }
    }
}
