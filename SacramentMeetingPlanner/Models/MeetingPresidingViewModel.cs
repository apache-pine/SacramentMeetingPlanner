using Microsoft.AspNetCore.Mvc.Rendering;

namespace SacramentMeetingPlanner.Models
{
    public class MeetingPresidingViewModel
    {
        public List<Meeting>? Meetings { get; set; }

        public SelectList? Presidings { get; set; }

        public string? MeetingPresiding { get; set; }

        public string? SearchString { get; set; }

        public string? SortBy { get; set; }

        public string? SortOrder { get; set;}
    }
}
