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
    public class ProduksController : Controller
    {
        private readonly UCPPAWContext _context;

        public ProduksController(UCPPAWContext context)
        {
            _context = context;
        }

        // GET: Produks
        public async Task<IActionResult> Index()
        {
            var uCPPAWContext = _context.Produk.Include(p => p.IdPenjualNavigation);
            return View(await uCPPAWContext.ToListAsync());
        }

        // GET: Produks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk
                .Include(p => p.IdPenjualNavigation)
                .FirstOrDefaultAsync(m => m.IdProduk == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // GET: Produks/Create
        public IActionResult Create()
        {
            ViewData["IdPenjual"] = new SelectList(_context.Penjual, "IdPenjual", "IdPenjual");
            return View();
        }

        // POST: Produks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduk,IdPenjual,HargaProduk,StokBarang,NamaProduk")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPenjual"] = new SelectList(_context.Penjual, "IdPenjual", "IdPenjual", produk.IdPenjual);
            return View(produk);
        }

        // GET: Produks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk.FindAsync(id);
            if (produk == null)
            {
                return NotFound();
            }
            ViewData["IdPenjual"] = new SelectList(_context.Penjual, "IdPenjual", "IdPenjual", produk.IdPenjual);
            return View(produk);
        }

        // POST: Produks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduk,IdPenjual,HargaProduk,StokBarang,NamaProduk")] Produk produk)
        {
            if (id != produk.IdProduk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukExists(produk.IdProduk))
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
            ViewData["IdPenjual"] = new SelectList(_context.Penjual, "IdPenjual", "IdPenjual", produk.IdPenjual);
            return View(produk);
        }

        // GET: Produks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk
                .Include(p => p.IdPenjualNavigation)
                .FirstOrDefaultAsync(m => m.IdProduk == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // POST: Produks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produk = await _context.Produk.FindAsync(id);
            _context.Produk.Remove(produk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukExists(int id)
        {
            return _context.Produk.Any(e => e.IdProduk == id);
        }
    }
}
