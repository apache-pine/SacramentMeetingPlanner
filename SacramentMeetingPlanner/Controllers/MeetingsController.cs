using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly SacramentMeetingPlannerContext _context;

        public MeetingsController(SacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index(string sortOrder, string sortBy, string meetingPresiding, string searchString)
        {
            if (_context.Meeting == null)
            {
                return Problem("Entity set 'SacramentMeetingPlannerContext.Meeting' is null.");
            }

            //Use LINQ to get list of presiding persons.
            IQueryable<string> presidingQuery = from m in _context.Meeting
                                                orderby m.Presiding
                                                select m.Presiding;

            var meetings = from m in _context.Meeting
                           .Include(m => m.Talks)
                           .Include(m => m.Hymns)
                           select m;


            if (!string.IsNullOrEmpty(searchString))
            {
                meetings = meetings.Where(s => s.Conducting!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(meetingPresiding))
            {
                meetings = meetings.Where(x => x.Presiding ==  meetingPresiding);
            }

            ViewData["SortOrder"] = sortOrder;
            ViewData["SortBy"] = sortBy;

            meetings = sortBy switch
            {
                "MeetingDateAsc" => meetings.OrderBy(s => s.MeetingDate),
                "MeetingDateDesc" => meetings.OrderByDescending(s => s.MeetingDate),
                _ => meetings.OrderBy(s => s.MeetingDate)
            };

            var meetingPresidingVM = new MeetingPresidingViewModel
            {
                Presidings = new SelectList(await presidingQuery.Distinct().ToListAsync()),
                Meetings = await meetings.ToListAsync(),
                SortBy = sortBy
            };

            return View(meetingPresidingVM);
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Meeting == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.Talks)
                .Include(m => m.Hymns)
                .FirstOrDefaultAsync(m => m.MeetingId == id);

            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("MeetingId,MeetingDate,Presiding,Conducting,Invocation,Benediction,Talks[0].SpeakerName,Talks[0].Topic,Talks[0].TalkType,Hymns[0].HymnName,Hymns[0].HymnType,Hymns[0].HymnPage")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                // Manually bind Talks
                meeting.Talks = new List<Talk>();
                for (int i = 0; i < 5; i++)
                {
                    var speakerName = Request.Form[$"Talks[{i}].SpeakerName"];
                    var topic = Request.Form[$"Talks[{i}].Topic"];
                    var talkType = Request.Form[$"Talks[{i}].TalkType"];

                    meeting.Talks.Add(new Talk
                    {
                        SpeakerName = speakerName,
                        Topic = topic,
                        TalkType = talkType
                    });
                }

                // Manually bind Hymns
                meeting.Hymns = new List<Hymn>();
                for (int i = 0; i < 5; i++)
                {
                    var hymnName = Request.Form[$"Hymns[{i}].HymnName"];
                    var hymnPage = Request.Form[$"Hymns[{i}].HymnPage"];
                    var hymnType = Request.Form[$"Hymns[{i}].HymnType"];

                    meeting.Hymns.Add(new Hymn
                    {
                        HymnName = hymnName,
                        HymnPage = string.IsNullOrEmpty(hymnPage) ? null : (int?)int.Parse(hymnPage),
                        HymnType = hymnType
                    });
                }

                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.Talks)
                .Include(m => m.Hymns)
                .FirstOrDefaultAsync(m => m.MeetingId == id);


            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Meeting meeting)
        {
            if (id != meeting.MeetingId)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(meeting);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.MeetingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            return View(meeting);
        }



        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Meeting == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .Include(m => m.Talks)
                .Include(m => m.Hymns)
                .FirstOrDefaultAsync(m => m.MeetingId == id);

            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Meeting == null)
            {
                return Problem("Entity set 'SacramentMeetingPlannerContext.Meeting'  is null.");
            }
            var meeting = await _context.Meeting
                .Include(m => m.Talks)
                .Include(m => m.Hymns)
                .FirstOrDefaultAsync(m => m.MeetingId == id);

            if (meeting != null)
            {
                _context.Talk.RemoveRange(meeting.Talks);
                _context.Hymn.RemoveRange(meeting.Hymns);
                _context.Meeting.Remove(meeting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool MeetingExists(int id)
        {
          return (_context.Meeting?.Any(e => e.MeetingId == id)).GetValueOrDefault();
        }
    }
}
