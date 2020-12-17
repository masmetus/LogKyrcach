using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogKyrcach.Models;

namespace LogKyrcach.Controllers
{
    public class WorkplacesController : Controller
    {
        private readonly softwareContext _context;

        public WorkplacesController(softwareContext context)
        {
            _context = context;
        }

        // GET: Workplaces
        public async Task<IActionResult> Index()
        {
            var softwareContext = _context.Workplaces.Include(w => w.IdComputerNavigation).Include(w => w.IdMonitorNavigation).Include(w => w.IdRoomNavigation);
            return View(await softwareContext.ToListAsync());
        }

        // GET: Workplaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplaces
                .Include(w => w.IdComputerNavigation)
                .Include(w => w.IdMonitorNavigation)
                .Include(w => w.IdRoomNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workplace == null)
            {
                return NotFound();
            }

            return View(workplace);
        }

        // GET: Workplaces/Create
        public IActionResult Create()
        {
            ViewData["IdComputer"] = new SelectList(_context.Computers, "Id", "Inv");
            ViewData["IdMonitor"] = new SelectList(_context.Monitors, "Id", "Inv");
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "Id", "RoomNumber");
            return View();
        }

        // POST: Workplaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,IdRoom,IdComputer,IdMonitor")] Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workplace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdComputer"] = new SelectList(_context.Computers, "Id", "Inv", workplace.IdComputer);
            ViewData["IdMonitor"] = new SelectList(_context.Monitors, "Id", "Inv", workplace.IdMonitor);
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "Id", "RoomNumber", workplace.IdRoom);
            return View(workplace);
        }

        // GET: Workplaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplaces.FindAsync(id);
            if (workplace == null)
            {
                return NotFound();
            }
            ViewData["IdComputer"] = new SelectList(_context.Computers, "Id", "Inv", workplace.IdComputer);
            ViewData["IdMonitor"] = new SelectList(_context.Monitors, "Id", "Inv", workplace.IdMonitor);
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "Id", "RoomNumber", workplace.IdRoom);
            return View(workplace);
        }

        // POST: Workplaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,IdRoom,IdComputer,IdMonitor")] Workplace workplace)
        {
            if (id != workplace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workplace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkplaceExists(workplace.Id))
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
            ViewData["IdComputer"] = new SelectList(_context.Computers, "Id", "Inv", workplace.IdComputer);
            ViewData["IdMonitor"] = new SelectList(_context.Monitors, "Id", "Inv", workplace.IdMonitor);
            ViewData["IdRoom"] = new SelectList(_context.Rooms, "Id", "RoomNumber", workplace.IdRoom);
            return View(workplace);
        }

        // GET: Workplaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplaces
                .Include(w => w.IdComputerNavigation)
                .Include(w => w.IdMonitorNavigation)
                .Include(w => w.IdRoomNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workplace == null)
            {
                return NotFound();
            }

            return View(workplace);
        }

        // POST: Workplaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workplace = await _context.Workplaces.FindAsync(id);
            _context.Workplaces.Remove(workplace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkplaceExists(int id)
        {
            return _context.Workplaces.Any(e => e.Id == id);
        }
    }
}
