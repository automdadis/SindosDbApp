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

namespace SindosDbAppweb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles ="Staff")]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
     


        public StudentController(ApplicationDbContext context)
        {
           
            _context = context;
        }

        // GET: Admin/Student
        public async Task<IActionResult> Index()
        {
              return _context.STUDENTS != null ? 
                          View(await _context.STUDENTS.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.STUDENTS'  is null.");
        }

        // GET: Admin/Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.STUDENTS == null)
            {
                return NotFound();
            }

            var student = await _context.STUDENTS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Admin/Student/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> SchoolList = _context.SCHOOLS.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Name.ToString()
            });
            ViewBag.SchoolList = SchoolList;
            IEnumerable<SelectListItem> SexList = _context.SEXS.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Name.ToString()
            });
            ViewBag.SexList = SexList;
            return View();
        }

        // POST: Admin/Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kod,Onomateponimo,TypeId,Eponimo,Onoma,Patronimo,Mitronimo,BirthYear,Sex,IdCart,AFM,Town,ZipCode,PhoneHome,PhoneJob,MobilePhone,Email,FromSchool,Orientation,ChoiceNumber,RankNumber,IdPaneladikes,Moria,YearRegistry,IBAN,HtmlNote,Sxolia")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Admin/Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            IEnumerable<SelectListItem> SchoolList = _context.SCHOOLS.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Name.ToString()
            });
            ViewBag.SchoolList = SchoolList;
            IEnumerable<SelectListItem> SexList = _context.SEXS.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Name.ToString()
            });
            ViewBag.SexList = SexList;
            if (id == null || _context.STUDENTS == null)
            {
                return NotFound();
            }

            var student = await _context.STUDENTS.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Admin/Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kod,Onomateponimo,TypeId,Eponimo,Onoma,Patronimo,Mitronimo,BirthYear,Sex,IdCart,AFM,Town,ZipCode,PhoneHome,PhoneJob,MobilePhone,Email,FromSchool,Orientation,ChoiceNumber,RankNumber,IdPaneladikes,Moria,YearRegistry,IBAN,HtmlNote,Sxolia")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Admin/Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.STUDENTS == null)
            {
                return NotFound();
            }

            var student = await _context.STUDENTS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Admin/Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.STUDENTS == null)
            {
                return Problem("Entity set 'ApplicationDbContext.STUDENTS'  is null.");
            }
            var student = await _context.STUDENTS.FindAsync(id);
            if (student != null)
            {
                _context.STUDENTS.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.STUDENTS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
