using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentMeetingPlanner.Data;
using System;
using System.Linq;

namespace SacramentMeetingPlanner.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentMeetingPlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SacramentMeetingPlannerContext>>()))
            {
                // Look for any meetings.
                if (context.Meeting.Any())
                {
                    return; // DB has been seeded
                }

                var meetings = new[]
                {
                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2023-04-02"),
                        Presiding = "Bishop",
                        Conducting = "Bishop",
                        Invocation = "Brother Smith",
                        Benediction = "Sister Smith"
                    },
                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2023-04-09"),
                        Presiding = "Bishop",
                        Conducting = "First Counselor",
                        Invocation = "Sister Matthews",
                        Benediction = "Brother Jones"
                    },
                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2023-04-16"),
                        Presiding = "Stake President",
                        Conducting = "Second Counselor",
                        Invocation = "Sister Davis",
                        Benediction = "Sister Benson"
                    },
                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2023-04-23"),
                        Presiding = "Bishop",
                        Conducting = "Bishop",
                        Invocation = "Brother Calvin",
                        Benediction = "Sister Nelson"
                    },
                    new Meeting
                    {
                        MeetingDate = DateTime.Parse("2023-04-30"),
                        Presiding = "Area Seventy",
                        Conducting = "First Counselor",
                        Invocation = "Brother Benedict",
                        Benediction = "Brother Sanders"
                    }
                };

                context.Meeting.AddRange(meetings);
                context.SaveChanges();

                var hymns = new[]
                {
                    new Hymn
                    {
                        HymnName = "The Morning Breaks",
                        HymnType = "Opening",
                        HymnPage = 1,
                        Meeting = meetings[0]

                    },
                    new Hymn
                    {
                        HymnName = "The Spirit of God",
                        HymnType = "Sacrament",
                        HymnPage = 2,
                        Meeting = meetings[0]

                    },
                    new Hymn
                    {
                        HymnName = "Ward Choir",
                        HymnType = "Special Musical Number",
                        HymnPage = null,
                        Meeting = meetings[0]

                    },
                    new Hymn
                    {
                        HymnName = "Now Let Us Rejoice",
                        HymnType = "Closing",
                        HymnPage = 3,
                        Meeting = meetings[0]

                    },
                    new Hymn
                    {
                        HymnName = "Truth Eternal",
                        HymnType = "Dismissal",
                        HymnPage = 4,
                        Meeting = meetings[0]

                    },
                    new Hymn
                    {
                        HymnName = "High on the Mountain Top",
                        HymnType = "Opening",
                        HymnPage = 5,
                        Meeting = meetings[1]

                    },
                    new Hymn
                    {
                        HymnName = "Redeemer of Israel",
                        HymnType = "Sacrament",
                        HymnPage = 6,
                        Meeting = meetings[1]

                    },
                    new Hymn
                    {
                        HymnName = "Israel, Israel, God is Calling",
                        HymnType = "Intermediate",
                        HymnPage = 7,
                        Meeting = meetings[1]

                    },
                    new Hymn
                    {
                        HymnName = "Awake and Arise",
                        HymnType = "Closing",
                        HymnPage = 8,
                        Meeting = meetings[1]

                    },
                    new Hymn
                    {
                        HymnName = "Come, Rejoice",
                        HymnType = "Dismissal",
                        HymnPage = 9,
                        Meeting = meetings[1]

                    },
                    new Hymn
                    {
                        HymnName = "Come, Sing to the Lord",
                        HymnType = "Opening",
                        HymnPage = 10,
                        Meeting = meetings[2]

                    },
                    new Hymn
                    {
                        HymnName = "What Was Witnessed in the Heavens?",
                        HymnType = "Sacrament",
                        HymnPage = 11,
                        Meeting = meetings[2]

                    },
                    new Hymn
                    {
                        HymnName = "Ward Choir",
                        HymnType = "Special Musical Number",
                        HymnPage = null,
                        Meeting = meetings[2]

                    },
                    new Hymn
                    {
                        HymnName = "An Angel from on High",
                        HymnType = "Closing",
                        HymnPage = 13,
                        Meeting = meetings[2]

                    },
                    new Hymn
                    {
                        HymnName = "Sweet Is the Peace the Gospel Brings",
                        HymnType = "Dismissal",
                        HymnPage = 14,
                        Meeting = meetings[2]

                    },
                    new Hymn
                    {
                        HymnName = "What Glorious Scenes Mine Eyes Behold",
                        HymnType = "Opening",
                        HymnPage = 16,
                        Meeting = meetings[3]

                    },
                    new Hymn
                    {
                        HymnName = "Awake, Ye Saints of God, Awake",
                        HymnType = "Sacrament",
                        HymnPage = 17,
                        Meeting = meetings[3]

                    },
                    new Hymn
                    {
                        HymnName = "The Voice of God Again is Heard",
                        HymnType = "Intermediate",
                        HymnPage = 18,
                        Meeting = meetings[3]

                    },
                    new Hymn
                    {
                        HymnName = "We Thank Thee, O God, for a Prophet",
                        HymnType = "Closing",
                        HymnPage = 19,
                        Meeting = meetings[3]

                    },
                    new Hymn
                    {
                        HymnName = "God of Power, God of Right",
                        HymnType = "Dismissal",
                        HymnPage = 20,
                        Meeting = meetings[3]

                    },
                    new Hymn
                    {
                        HymnName = "Come, Listen to a Prophet's Voice",
                        HymnType = "Opening",
                        HymnPage = 21,
                        Meeting = meetings[4]

                    },
                    new Hymn
                    {
                        HymnName = "We listen to a Prophet's Voice",
                        HymnType = "Sacrament",
                        HymnPage = 22,
                        Meeting = meetings[4]

                    },
                    new Hymn
                    {
                        HymnName = "Ward Choir",
                        HymnType = "Special Musical Number",
                        HymnPage = null,
                        Meeting = meetings[4]

                    },
                    new Hymn
                    {
                        HymnName = "We Ever Pray for Thee",
                        HymnType = "Closing",
                        HymnPage = 23,
                        Meeting = meetings[4]

                    },
                    new Hymn
                    {
                        HymnName = "God Bless Our Prophet Dear",
                        HymnType = "Dismissal",
                        HymnPage = 24,
                        Meeting = meetings[4]

                    }
                };
                context.Hymn.AddRange(hymns);
                context.SaveChanges();


                var talks = new[]
                {
                    new Talk
                    {
                        TalkType = "Youth",
                        SpeakerName = "Kevin Johnson",
                        Topic = "Jesus Christ",
                        Meeting = meetings[0]
                    },
                    new Talk
                    {

                        TalkType = "First",
                        SpeakerName = "Manny Johnson",
                        Topic = "Holy Ghost",
                        Meeting = meetings[0]
                    },
                    new Talk
                    {
                        TalkType = "Second",
                        SpeakerName = "Kristin Johnson",
                        Topic = "Heavenly Parents",
                        Meeting = meetings[0]
                    },
                    new Talk
                    {
                        TalkType = "AoF1",
                        SpeakerName = "Josh Jessen",
                        Topic = "Article of Faith",
                        Meeting = meetings[0]
                    },
                    new Talk
                    {
                        TalkType = "AoF2",
                        SpeakerName = "Ben Lemmon",
                        Topic = "Article of Faith",
                        Meeting = meetings[0]
                    },
                    new Talk
                    {
                        TalkType = "Youth",
                        SpeakerName = "Jonathan Hernandez",
                        Topic = "Blessings",
                        Meeting = meetings[1]
                    },
                    new Talk
                    {
                        TalkType = "First",
                        SpeakerName = "Jesus Hernandez",
                        Topic = "Tithing",
                        Meeting = meetings[1]
                    },
                    new Talk
                    {
                        TalkType = "Second",
                        SpeakerName = "Maria Hernandez",
                        Topic = "Commandments",
                        Meeting = meetings[1]
                    },
                    new Talk
                    {
                        TalkType = "AoF1",
                        SpeakerName = "Verdus Miles",
                        Topic = "Article of Faith",
                        Meeting = meetings[1]
                    },
                    new Talk
                    {
                        TalkType = "AoF2",
                        SpeakerName = "Delanee Theener",
                        Topic = "Article of Faith",
                        Meeting = meetings[1]
                    },
                    new Talk
                    {
                        TalkType = "Youth",
                        SpeakerName = "Jessica Smith",
                        Topic = "Prophets",
                        Meeting = meetings[2]
                    },
                    new Talk
                    {
                        TalkType = "First",
                        SpeakerName = "Tiffany Smith",
                        Topic = "Following The Spirit",
                        Meeting = meetings[2]
                    },
                    new Talk
                    {
                        TalkType = "Second",
                        SpeakerName = "Jeffery Smith",
                        Topic = "Worthiness",
                        Meeting = meetings[2]
                    },
                    new Talk
                    {
                        TalkType = "AoF1",
                        SpeakerName = "Coy Lawton",
                        Topic = "Article of Faith",
                        Meeting = meetings[2]
                    },
                    new Talk
                    {
                        TalkType = "AoF2",
                        SpeakerName = "Colt Duncan",
                        Topic = "Article of Faith",
                        Meeting = meetings[2]
                    },
                    new Talk
                    {
                        TalkType = "Youth",
                        SpeakerName = "Jenny Lopez",
                        Topic = "Obedience",
                        Meeting = meetings[3]
                    },
                    new Talk
                    {
                        TalkType = "First",
                        SpeakerName = "Ally Lopez",
                        Topic = "Sabbath Day",
                        Meeting = meetings[3]
                    },
                    new Talk
                    {
                        TalkType = "Second",
                        SpeakerName = "Samuel Lopez",
                        Topic = "Temples",
                        Meeting = meetings[3]
                    },
                    new Talk
                    {
                        TalkType = "AoF1",
                        SpeakerName = "Donald Miles",
                        Topic = "Article of Faith",
                        Meeting = meetings[3]
                    },
                    new Talk
                    {
                        TalkType = "AoF2",
                        SpeakerName = "Randy Brotherson",
                        Topic = "Article of Faith",
                        Meeting = meetings[3]
                    },
                    new Talk
                    {
                        TalkType = "Youth",
                        SpeakerName = "Christopher Jones",
                        Topic = "General Conference",
                        Meeting = meetings[4]
                    },
                    new Talk
                    {
                        TalkType = "First",
                        SpeakerName = "Samantha Jones",
                        Topic = "Book of Mormon",
                        Meeting = meetings[4]
                    },
                    new Talk
                    {
                        TalkType = "Second",
                        SpeakerName = "Kyle Jones",
                        Topic = "Journaling",
                        Meeting = meetings[4]
                    },
                    new Talk
                    {
                        TalkType = "AoF1",
                        SpeakerName = "Brent Holgate",
                        Topic = "Article of Faith",
                        Meeting = meetings[4]
                    },
                    new Talk
                    {
                        TalkType = "AoF2",
                        SpeakerName = "Kenny Benson",
                        Topic = "Article of Faith",
                        Meeting = meetings[4]
                    }
                };

                context.Talk.AddRange(talks);
                context.SaveChanges();
            }
        }
    }
}
