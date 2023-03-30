using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SindosDbAppweb.DataAccess.Data;
using SindosDbAppweb.Models;
using StackExchange.Redis;

namespace SindosDbAppweb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize (Roles = "Staff")]
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Staff
        public async Task<IActionResult> Index()
        {
            return _context.STAFF != null ?
                        View(await _context.STAFF.ToListAsync()): 
                          Problem("Entity set 'ApplicationDbContext.STAFF'  is null.");
        }

        // GET: Admin/Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.STAFF == null)
            {
                return NotFound();
            }

            var staff = await _context.STAFF
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Admin/Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Staff/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HmniaStart,Onomateponimo,TypeId,ADT,AMKA,AFM,PhoneHome,PhoneJob,MobilePhone,Web,Email,Email2,Address,Town,ZipCode,Fek_Start,Scientific_Object,Fek_Object,IBAN,HtmlNote,Sxolia")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Admin/Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.STAFF == null)
            {
                return NotFound();
            }

            var staff = await _context.STAFF.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Admin/Staff/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HmniaStart,Onomateponimo,TypeId,ADT,AMKA,AFM,PhoneHome,PhoneJob,MobilePhone,Web,Email,Email2,Address,Town,ZipCode,Fek_Start,Scientific_Object,Fek_Object,IBAN,HtmlNote,Sxolia")] Staff staff)
        {
            if (id != staff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.Id))
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
            return View(staff);
        }

        // GET: Admin/Staff/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.STAFF == null)
            {
                return NotFound();
            }

            var staff = await _context.STAFF
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Admin/Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.STAFF == null)
            {
                return Problem("Entity set 'ApplicationDbContext.STAFF'  is null.");
            }
            var staff = await _context.STAFF.FindAsync(id);
            if (staff != null)
            {
                _context.STAFF.Remove(staff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
          return (_context.STAFF?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
