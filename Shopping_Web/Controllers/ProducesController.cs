using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping_Web.Data;
using Shopping_Web.Models;
using Shopping_Web.Services;
using Shopping_Web.Services.Interface;

namespace Shopping_Web.Controllers
{
    public class ProducesController : Controller
    {
        private readonly Shopping_WebContext _context;
        private readonly IProduceService _produceService;

        public ProducesController(Shopping_WebContext context, IProduceService produceService)
        {
            _context = context;
            _produceService = produceService;
        }

        // GET: Produces
        public async Task<IActionResult> Index()
        {
            var produce = await _produceService.GetInitial();
            return View(await _context.Produce.ToListAsync());
        }

        // GET: Produces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produce == null)
            {
                return NotFound();
            }

            var produce = await _context.Produce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produce == null)
            {
                return NotFound();
            }

            return View(produce);
        }

        // GET: Produces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,SellingStarTime,SellingEndTime,CreateTime")] Produce produce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produce);
        }

        // GET: Produces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produce == null)
            {
                return NotFound();
            }

            var produce = await _context.Produce.FindAsync(id);
            if (produce == null)
            {
                return NotFound();
            }
            return View(produce);
        }

        // POST: Produces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,SellingStarTime,SellingEndTime,CreateTime")] Produce produce)
        {
            if (id != produce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduceExists(produce.Id))
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
            return View(produce);
        }

        // GET: Produces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produce == null)
            {
                return NotFound();
            }

            var produce = await _context.Produce
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produce == null)
            {
                return NotFound();
            }

            return View(produce);
        }

        // POST: Produces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produce == null)
            {
                return Problem("Entity set 'Shopping_WebContext.Produce'  is null.");
            }
            var produce = await _context.Produce.FindAsync(id);
            if (produce != null)
            {
                _context.Produce.Remove(produce);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduceExists(int id)
        {
          return _context.Produce.Any(e => e.Id == id);
        }
    }
}
