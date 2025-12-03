using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _202230548_CoffeeShop.Data;
using _202230548_CoffeeShop.Models;

namespace _202230548_CoffeeShop.Controllers
{
    public class SalesController : Controller
    {
        private readonly _202230548_CoffeeShopContext _context;

        public SalesController(_202230548_CoffeeShopContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var _202230548_CoffeeShopContext = _context.Sale.Include(s => s.Customer).Include(s => s.Product);
            return View(await _202230548_CoffeeShopContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "FullName");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Description");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,Date,Comment,CustomerId,ProductId")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                sale.SaleId = Guid.NewGuid();
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "FullName", sale.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Description", sale.ProductId);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "FullName", sale.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Description", sale.ProductId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SaleId,Date,Comment,CustomerId,ProductId")] Sale sale)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SaleId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "FullName", sale.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Description", sale.ProductId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.SaleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sale = await _context.Sale.FindAsync(id);
            if (sale != null)
            {
                _context.Sale.Remove(sale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(Guid id)
        {
            return _context.Sale.Any(e => e.SaleId == id);
        }
    }
}
