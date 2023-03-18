using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using VisitorsApp.Data;
using VisitorsApp.Entities;

namespace VisitorsApp.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string sortParam)
        {

            return View(await _context.Visitors.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            if (_context.Visitors == null)
            {
                return NotFound();
            }
            var visitor = await _context.Visitors.FirstOrDefaultAsync(i => i.Id == id);
            return View(visitor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Visitor visitor)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(visitor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(visitor);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Visitors == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }
            return View(visitor);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Edit(int id, Visitor visitor)
        {
            if (id != visitor.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(visitor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Visitors == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

    }
}
