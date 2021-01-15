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
    public class InstalledsoftwaresController : Controller
    {
        private readonly softwareContext _context;

        public InstalledsoftwaresController(softwareContext context)
        {
            _context = context;
        }

        // GET: Installedsoftwares
        public async Task<IActionResult> Index()
        {
            var softwareContext = _context.Installedsoftwares.Include(i => i.IdEnginereNavigation).Include(i => i.IdSoftwareNavigation).Include(i => i.TypeLicense);
            return View(await softwareContext.ToListAsync());
        }

        // GET: Installedsoftwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installedsoftware = await _context.Installedsoftwares
                .Include(i => i.IdEnginereNavigation)
                .Include(i => i.IdSoftwareNavigation)
                .Include(i => i.TypeLicense)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (installedsoftware == null)
            {
                return NotFound();
            }

            return View(installedsoftware);
        }

        // GET: Installedsoftwares/Create
        public IActionResult Create()
        {
            ViewData["IdEnginere"] = new SelectList(_context.Workers, "Id", "FirstName");
            ViewData["IdSoftware"] = new SelectList(_context.Softwares, "Id", "Name");
            ViewData["TypeLicenseId"] = new SelectList(_context.Typelicenses, "Id", "TypeLicense1");
            return View();
        }

        // POST: Installedsoftwares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdSoftware,IdComputer,LicenseStart,LicenseEnd,TypeLicenseId,IdEnginere,InstallationDate,WorkStatus,IdRoom")] Installedsoftware installedsoftware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(installedsoftware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEnginere"] = new SelectList(_context.Workers, "Id", "FirstName", installedsoftware.IdEnginere);
            ViewData["IdSoftware"] = new SelectList(_context.Softwares, "Id", "Name", installedsoftware.IdSoftware);
            ViewData["TypeLicenseId"] = new SelectList(_context.Typelicenses, "Id", "TypeLicense1", installedsoftware.TypeLicenseId);
            return View(installedsoftware);
        }

        // GET: Installedsoftwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installedsoftware = await _context.Installedsoftwares.FindAsync(id);
            if (installedsoftware == null)
            {
                return NotFound();
            }
            ViewData["IdEnginere"] = new SelectList(_context.Workers, "Id", "FirstName", installedsoftware.IdEnginere);
            ViewData["IdSoftware"] = new SelectList(_context.Softwares, "Id", "Name", installedsoftware.IdSoftware);
            ViewData["TypeLicenseId"] = new SelectList(_context.Typelicenses, "Id", "TypeLicense1", installedsoftware.TypeLicenseId);
            return View(installedsoftware);
        }

        // POST: Installedsoftwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdSoftware,IdComputer,LicenseStart,LicenseEnd,TypeLicenseId,IdEnginere,InstallationDate,WorkStatus,IdRoom")] Installedsoftware installedsoftware)
        {
            if (id != installedsoftware.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(installedsoftware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstalledsoftwareExists(installedsoftware.Id))
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
            ViewData["IdEnginere"] = new SelectList(_context.Workers, "Id", "FirstName", installedsoftware.IdEnginere);
            ViewData["IdSoftware"] = new SelectList(_context.Softwares, "Id", "Name", installedsoftware.IdSoftware);
            ViewData["TypeLicenseId"] = new SelectList(_context.Typelicenses, "Id", "TypeLicense1", installedsoftware.TypeLicenseId);
            return View(installedsoftware);
        }

        // GET: Installedsoftwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var installedsoftware = await _context.Installedsoftwares
                .Include(i => i.IdEnginereNavigation)
                .Include(i => i.IdSoftwareNavigation)
                .Include(i => i.TypeLicense)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (installedsoftware == null)
            {
                return NotFound();
            }

            return View(installedsoftware);
        }

        // POST: Installedsoftwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var installedsoftware = await _context.Installedsoftwares.FindAsync(id);
            _context.Installedsoftwares.Remove(installedsoftware);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstalledsoftwareExists(int id)
        {
            return _context.Installedsoftwares.Any(e => e.Id == id);
        }
    }
}
