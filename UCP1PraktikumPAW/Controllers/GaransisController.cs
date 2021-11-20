using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1PraktikumPAW.Models;

namespace UCP1PraktikumPAW.Controllers
{
    public class GaransisController : Controller
    {
        private readonly UCPPAWContext _context;

        public GaransisController(UCPPAWContext context)
        {
            _context = context;
        }

        // GET: Garansis
        public async Task<IActionResult> Index()
        {
            var uCPPAWContext = _context.Garansi.Include(g => g.IdJasaKirimNavigation);
            return View(await uCPPAWContext.ToListAsync());
        }

        // GET: Garansis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garansi = await _context.Garansi
                .Include(g => g.IdJasaKirimNavigation)
                .FirstOrDefaultAsync(m => m.IdGaransi == id);
            if (garansi == null)
            {
                return NotFound();
            }

            return View(garansi);
        }

        // GET: Garansis/Create
        public IActionResult Create()
        {
            ViewData["IdJasaKirim"] = new SelectList(_context.JasaKirim, "IdJasaKirim", "IdJasaKirim");
            return View();
        }

        // POST: Garansis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGaransi,IdJasaKirim,Kerusakan,JenisGaransi")] Garansi garansi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garansi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdJasaKirim"] = new SelectList(_context.JasaKirim, "IdJasaKirim", "IdJasaKirim", garansi.IdJasaKirim);
            return View(garansi);
        }

        // GET: Garansis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garansi = await _context.Garansi.FindAsync(id);
            if (garansi == null)
            {
                return NotFound();
            }
            ViewData["IdJasaKirim"] = new SelectList(_context.JasaKirim, "IdJasaKirim", "IdJasaKirim", garansi.IdJasaKirim);
            return View(garansi);
        }

        // POST: Garansis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGaransi,IdJasaKirim,Kerusakan,JenisGaransi")] Garansi garansi)
        {
            if (id != garansi.IdGaransi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garansi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GaransiExists(garansi.IdGaransi))
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
            ViewData["IdJasaKirim"] = new SelectList(_context.JasaKirim, "IdJasaKirim", "IdJasaKirim", garansi.IdJasaKirim);
            return View(garansi);
        }

        // GET: Garansis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garansi = await _context.Garansi
                .Include(g => g.IdJasaKirimNavigation)
                .FirstOrDefaultAsync(m => m.IdGaransi == id);
            if (garansi == null)
            {
                return NotFound();
            }

            return View(garansi);
        }

        // POST: Garansis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garansi = await _context.Garansi.FindAsync(id);
            _context.Garansi.Remove(garansi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GaransiExists(int id)
        {
            return _context.Garansi.Any(e => e.IdGaransi == id);
        }
    }
}
