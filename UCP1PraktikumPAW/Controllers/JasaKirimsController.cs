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
    public class JasaKirimsController : Controller
    {
        private readonly UCPPAWContext _context;

        public JasaKirimsController(UCPPAWContext context)
        {
            _context = context;
        }

        // GET: JasaKirims
        public async Task<IActionResult> Index()
        {
            var uCPPAWContext = _context.JasaKirim.Include(j => j.IdOrderNavigation);
            return View(await uCPPAWContext.ToListAsync());
        }

        // GET: JasaKirims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jasaKirim = await _context.JasaKirim
                .Include(j => j.IdOrderNavigation)
                .FirstOrDefaultAsync(m => m.IdJasaKirim == id);
            if (jasaKirim == null)
            {
                return NotFound();
            }

            return View(jasaKirim);
        }

        // GET: JasaKirims/Create
        public IActionResult Create()
        {
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder");
            return View();
        }

        // POST: JasaKirims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJasaKirim,NamaJasaKirim,IdOrder,TanggalDiterima,JenisLayanan,HargaJasa")] JasaKirim jasaKirim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jasaKirim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder", jasaKirim.IdOrder);
            return View(jasaKirim);
        }

        // GET: JasaKirims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jasaKirim = await _context.JasaKirim.FindAsync(id);
            if (jasaKirim == null)
            {
                return NotFound();
            }
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder", jasaKirim.IdOrder);
            return View(jasaKirim);
        }

        // POST: JasaKirims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJasaKirim,NamaJasaKirim,IdOrder,TanggalDiterima,JenisLayanan,HargaJasa")] JasaKirim jasaKirim)
        {
            if (id != jasaKirim.IdJasaKirim)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jasaKirim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JasaKirimExists(jasaKirim.IdJasaKirim))
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
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder", jasaKirim.IdOrder);
            return View(jasaKirim);
        }

        // GET: JasaKirims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jasaKirim = await _context.JasaKirim
                .Include(j => j.IdOrderNavigation)
                .FirstOrDefaultAsync(m => m.IdJasaKirim == id);
            if (jasaKirim == null)
            {
                return NotFound();
            }

            return View(jasaKirim);
        }

        // POST: JasaKirims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jasaKirim = await _context.JasaKirim.FindAsync(id);
            _context.JasaKirim.Remove(jasaKirim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JasaKirimExists(int id)
        {
            return _context.JasaKirim.Any(e => e.IdJasaKirim == id);
        }
    }
}
