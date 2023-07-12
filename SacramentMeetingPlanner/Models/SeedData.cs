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
                context.Meeting.AddRange(
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
                );
                context.SaveChanges();

                context.Hymn.AddRange(
                    new Hymn
                    {
                        HymnName = "The Morning Breaks",
                        HymnType = "Opening",
                        HymnPage = 1,
                        MeetingId = 1

                    },
                    new Hymn
                    {
                        HymnName = "The Spirit of God",
                        HymnType = "Sacrament",
                        HymnPage = 2,
                        MeetingId = 1

                    },
                    new Hymn
                    {
                        HymnName = "Ward Choir",
                        HymnType = "Special Musical Number",
                        HymnPage = null,
                        MeetingId = 1

                    },
                    new Hymn
                    {
                        HymnName = "Now Let Us Rejoice",
                        HymnType = "Closing",
                        HymnPage = 3,
                        MeetingId = 1

                    },
                    new Hymn
                    {
                        HymnName = "Truth Eternal",
                        HymnType = "Dismissal",
                        HymnPage = 4,
                        MeetingId = 1

                    },
                    new Hymn
                    {
                        HymnName = "High on the Mountain Top",
                        HymnType = "Opening",
                        HymnPage = 5,
                        MeetingId = 2

                    },
                    new Hymn
                    {
                        HymnName = "Redeemer of Israel",
                        HymnType = "Sacrament",
                        HymnPage = 6,
                        MeetingId = 2

                    },
                    new Hymn
                    {
                        HymnName = "Israel, Israel, God is Calling",
                        HymnType = "Intermediate",
                        HymnPage = 7,
                        MeetingId = 2

                    },
                    new Hymn
                    {
                        HymnName = "Awake and Arise",
                        HymnType = "Closing",
                        HymnPage = 8,
                        MeetingId = 2

                    },
                    new Hymn
                    {
                        HymnName = "Come, Rejoice",
                        HymnType = "Dismissal",
                        HymnPage = 9,
                        MeetingId = 2

                    },
                    new Hymn
                    {
                        HymnName = "Come, Sing to the Lord",
                        HymnType = "Opening",
                        HymnPage = 10,
                        MeetingId = 3

                    },
                    new Hymn
                    {
                        HymnName = "What Was Witnessed in the Heavens?",
                        HymnType = "Sacrament",
                        HymnPage = 11,
                        MeetingId = 3

                    },
                    new Hymn
                    {
                        HymnName = "Ward Choir",
                        HymnType = "Special Musical Number",
                        HymnPage = null,
                        MeetingId = 3

                    },
                    new Hymn
                    {
                        HymnName = "An Angel from on High",
                        HymnType = "Closing",
                        HymnPage = 13,
                        MeetingId = 3

                    },
                    new Hymn
                    {
                        HymnName = "Sweet Is the Peace the Gospel Brings",
                        HymnType = "Dismissal",
                        HymnPage = 14,
                        MeetingId = 3

                    },
                    new Hymn
                    {
                        HymnName = "What Glorious Scenes Mine Eyes Behold",
                        HymnType = "Opening",
                        HymnPage = 16,
                        MeetingId = 4

                    },
                    new Hymn
                    {
                        HymnName = "Awake, Ye Saints of God, Awake",
                        HymnType = "Sacrament",
                        HymnPage = 17,
                        MeetingId = 4

                    },
                    new Hymn
                    {
                        HymnName = "The Voice of God Again is Heard",
                        HymnType = "Intermediate",
                        HymnPage = 18,
                        MeetingId = 4

                    },
                    new Hymn
                    {
                        HymnName = "We Thank Thee, O God, for a Prophet",
                        HymnType = "Closing",
                        HymnPage = 19,
                        MeetingId = 4

                    },
                    new Hymn
                    {
                        HymnName = "God of Power, God of Right",
                        HymnType = "Dismissal",
                        HymnPage = 20,
                        MeetingId = 4

                    },
                    new Hymn
                    {
                        HymnName = "Come, Listen to a Prophet's Voice",
                        HymnType = "Opening",
                        HymnPage = 21,
                        MeetingId = 5

                    },
                    new Hymn
                    {
                        HymnName = "We listen to a Prophet's Voice",
                        HymnType = "Sacrament",
                        HymnPage = 22,
                        MeetingId = 5

                    },
                    new Hymn
                    {
                        HymnName = "Ward Choir",
                        HymnType = "Special Musical Number",
                        HymnPage = null,
                        MeetingId = 5

                    },
                    new Hymn
                    {
                        HymnName = "We Ever Pray for Thee",
                        HymnType = "Closing",
                        HymnPage = 23,
                        MeetingId = 5

                    },
                    new Hymn
                    {
                        HymnName = "God Bless Our Prophet Dear",
                        HymnType = "Dismissal",
                        HymnPage = 24,
                        MeetingId = 5

                    }
                );

                context.Talk.AddRange(
                    new Talk
                    {
                        MeetingId = 1,
                        TalkType = "Youth",
                        SpeakerName = "Kevin Johnson",
                        Topic = "Jesus Christ"
                    },
                    new Talk
                    {
                        MeetingId = 1,
                        TalkType = "First",
                        SpeakerName = "Manny Johnson",
                        Topic = "Holy Ghost"
                    },
                    new Talk
                    {
                        MeetingId = 1,
                        TalkType = "Second",
                        SpeakerName = "Kristin Johnson",
                        Topic = "Heavenly Parents"
                    },
                    new Talk
                    {
                        MeetingId = 1,
                        TalkType = "AoF1",
                        SpeakerName = "Josh Jessen",
                        Topic = "Article of Faith"
                    },
                    new Talk
                    {
                        MeetingId = 1,
                        TalkType = "AoF2",
                        SpeakerName = "Ben Lemmon",
                        Topic = "Article of Faith"
                    },
                    new Talk
                    {
                        MeetingId = 2,
                        TalkType = "Youth",
                        SpeakerName = "Jonathan Hernandez",
                        Topic = "Blessings"
                    },
                    new Talk
                    {
                        MeetingId = 2,
                        TalkType = "First",
                        SpeakerName = "Jesus Hernandez",
                        Topic = "Tithing"
                    },
                    new Talk
                    {
                        MeetingId = 2,
                        TalkType = "Second",
                        SpeakerName = "Maria Hernandez",
                        Topic = "Commandments"
                    },
                    new Talk
                    {
                        MeetingId = 2,
                        TalkType = "AoF1",
                        SpeakerName = "Verdus Miles",
                        Topic = "Article of Faith"
                    },
                    new Talk
                    {
                        MeetingId = 2,
                        TalkType = "AoF2",
                        SpeakerName = "Delanee Theener",
                        Topic = "Article of Faith"
                    },
                    new Talk
                    {
                        MeetingId = 3,
                        TalkType = "Youth",
                        SpeakerName = "Jessica Smith",
                        Topic = "Prophets"
                    },
                    new Talk
                    {
                        MeetingId = 3,
                        TalkType = "First",
                        SpeakerName = "Tiffany Smith",
                        Topic = "Following The Spirit"
                    },
                    new Talk
                    {
                        MeetingId = 3,
                        TalkType = "Second",
                        SpeakerName = "Jeffery Smith",
                        Topic = "Worthiness"
                    },
                    new Talk
                    {
                        MeetingId = 3,
                        TalkType = "AoF1",
                        SpeakerName = "Coy Lawton",
                        Topic = "Article of Faith"
                    },
                    new Talk
                    {
                        MeetingId = 3,
                        TalkType = "AoF2",
                        SpeakerName = "Colt Duncan",
                        Topic = "Article of Faith"
                    },
                    new Talk
                    {
                        MeetingId = 4,
                        TalkType = "Youth",
                        SpeakerName = "Jenny Lopez",
                        Topic = "Obedience"
                    },
                    new Talk
                    {
                        MeetingId = 4,
                        TalkType = "First",
                        SpeakerName = "Ally Lopez",
                        Topic = "Sabbath Day"
                    },
                    new Talk
                    {
                        MeetingId = 4,
                        TalkType = "Second",
                        SpeakerName = "Samuel Lopez",
                        Topic = "Temples"
                    },
                    new Talk
                    {
                        MeetingId = 4,
                        TalkType = "AoF1",
                        SpeakerName = "Donald Miles",
                        Topic = "Article of Faith"
                    },
                    new Talk
                    {
                        MeetingId = 4,
                        TalkType = "AoF2",
                        SpeakerName = "Randy Brotherson",
                        Topic = "Article of Faith"
                    },
                    new Talk
                    {
                        MeetingId = 5,
                        TalkType = "Youth",
                        SpeakerName = "Christopher Jones",
                        Topic = "General Conference"
                    },
                    new Talk
                    {
                        MeetingId = 5,
                        TalkType = "First",
                        SpeakerName = "Samantha Jones",
                        Topic = "Book of Mormon"
                    },
                    new Talk
                    {
                        MeetingId = 5,
                        TalkType = "Second",
                        SpeakerName = "Kyle Jones",
                        Topic = "Journaling"
                    },
                    new Talk
                    {
                        MeetingId = 5,
                        TalkType = "AoF1",
                        SpeakerName = "Brent Holgate",
                        Topic = "Article of Faith"
                    },
                    new Talk
                    {
                        MeetingId = 5,
                        TalkType = "AoF2",
                        SpeakerName = "Kenny Benson",
                        Topic = "Article of Faith"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
