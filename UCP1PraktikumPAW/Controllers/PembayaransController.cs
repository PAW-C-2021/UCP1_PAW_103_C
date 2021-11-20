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
    public class PembayaransController : Controller
    {
        private readonly UCPPAWContext _context;

        public PembayaransController(UCPPAWContext context)
        {
            _context = context;
        }

        // GET: Pembayarans
        public async Task<IActionResult> Index()
        {
            var uCPPAWContext = _context.Pembayaran.Include(p => p.IdCustomerNavigation).Include(p => p.IdOrderNavigation);
            return View(await uCPPAWContext.ToListAsync());
        }

        // GET: Pembayarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayaran
                .Include(p => p.IdCustomerNavigation)
                .Include(p => p.IdOrderNavigation)
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // GET: Pembayarans/Create
        public IActionResult Create()
        {
            ViewData["IdCustomer"] = new SelectList(_context.Customer, "IdCustomer", "IdCustomer");
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder");
            return View();
        }

        // POST: Pembayarans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembayaran,IdCustomer,IdOrder,TotalHarga,ViaPembayaran")] Pembayaran pembayaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembayaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCustomer"] = new SelectList(_context.Customer, "IdCustomer", "IdCustomer", pembayaran.IdCustomer);
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder", pembayaran.IdOrder);
            return View(pembayaran);
        }

        // GET: Pembayarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayaran.FindAsync(id);
            if (pembayaran == null)
            {
                return NotFound();
            }
            ViewData["IdCustomer"] = new SelectList(_context.Customer, "IdCustomer", "IdCustomer", pembayaran.IdCustomer);
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder", pembayaran.IdOrder);
            return View(pembayaran);
        }

        // POST: Pembayarans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPembayaran,IdCustomer,IdOrder,TotalHarga,ViaPembayaran")] Pembayaran pembayaran)
        {
            if (id != pembayaran.IdPembayaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembayaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembayaranExists(pembayaran.IdPembayaran))
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
            ViewData["IdCustomer"] = new SelectList(_context.Customer, "IdCustomer", "IdCustomer", pembayaran.IdCustomer);
            ViewData["IdOrder"] = new SelectList(_context.Order, "IdOrder", "IdOrder", pembayaran.IdOrder);
            return View(pembayaran);
        }

        // GET: Pembayarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayaran
                .Include(p => p.IdCustomerNavigation)
                .Include(p => p.IdOrderNavigation)
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // POST: Pembayarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembayaran = await _context.Pembayaran.FindAsync(id);
            _context.Pembayaran.Remove(pembayaran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembayaranExists(int id)
        {
            return _context.Pembayaran.Any(e => e.IdPembayaran == id);
        }
    }
}
