using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class Meeting
    {
        public Meeting()
        {
            this.Talks = new List<Talk>();
            this.Hymns = new List<Hymn>();
        }

        public int MeetingId { get; set; }

        [Display(Name = "Meeting Date"), DataType(DataType.Date)]
        public DateTime MeetingDate { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Presiding { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Conducting { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Invocation { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Benediction { get; set; }

        [ForeignKey("MeetingId")]
        public List<Talk> Talks { get; set; }

        [ForeignKey("MeetingId")]
        public List<Hymn> Hymns { get; set; }
    }
}
