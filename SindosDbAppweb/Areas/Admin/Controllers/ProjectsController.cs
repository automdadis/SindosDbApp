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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public ProjectsController(ApplicationDbContext context)
        { 
            _context = context;
        }

        // GET: Admin/Projects
        public async Task<IActionResult> Index()
        {
          
            return _context.PROJECTS != null ?
                        View(await _context.PROJECTS.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.PROJECTS'  is null.");
        }

        // GET: Admin/Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PROJECTS == null)
            {
                return NotFound();
            }

            var project = await _context.PROJECTS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Admin/Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Title,Apo,Eos,Amount,WhoFund,Abroad,url,Sxolia")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                TempData["success"] = "Project created succesfully";
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Admin/Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PROJECTS == null)
            {
                return NotFound();
            }

            var project = await _context.PROJECTS.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Admin/Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Title,Apo,Eos,Amount,WhoFund,Abroad,url,Sxolia")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Project updated succesfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            return View(project);
        }

        // GET: Admin/Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PROJECTS == null)
            {
                return NotFound();
            }

            var project = await _context.PROJECTS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Admin/Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PROJECTS == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PROJECTS'  is null.");
            }
            var project = await _context.PROJECTS.FindAsync(id);
            if (project != null)
            {
                _context.PROJECTS.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            TempData["success"] = "Project deleted succesfully";
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
          return (_context.PROJECTS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
   
}
