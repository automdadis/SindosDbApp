using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SindosDbAppweb.DataAccess.Data;
using SindosDbAppweb.Models;

namespace SindosDbAppweb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Events
        public async Task<IActionResult> Index()
        {
              return _context.EVENTS != null ? 
                          View(await _context.EVENTS.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EVENTS'  is null.");
        }

        // GET: Admin/Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EVENTS == null)
            {
                return NotFound();
            }

            var @event = await _context.EVENTS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Admin/Events/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> AbroadList = _context.ABROADS.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Name
            });
            ViewBag.AbroadList = AbroadList;
            return View();
        }

        // POST: Admin/Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hmnia,Description,Region,Abroad,Url,Sxolia")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Admin/Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            IEnumerable<SelectListItem> AbroadList = _context.ABROADS.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Name
            });
            ViewBag.AbroadList = AbroadList;
            if (id == null || _context.EVENTS == null)
            {
                return NotFound();
            }

            var @event = await _context.EVENTS.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Admin/Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Hmnia,Description,Region,Abroad,Url,Sxolia")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Admin/Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EVENTS == null)
            {
                return NotFound();
            }

            var @event = await _context.EVENTS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Admin/Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EVENTS == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EVENTS'  is null.");
            }
            var @event = await _context.EVENTS.FindAsync(id);
            if (@event != null)
            {
                _context.EVENTS.Remove(@event);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
          return (_context.EVENTS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
