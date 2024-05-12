using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepairShopV2.Data;
using RepairShopV2.Models;

namespace RepairShopV2.Controllers
{
    public class SparePartStoragesController : Controller
    {
        private readonly DataContext _context;

        public SparePartStoragesController(DataContext context)
        {
            _context = context;
        }

        // GET: SparePartStorages
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.SparePartStorages.Include(s => s.SparePart);
            return View(await dataContext.ToListAsync());
        }

        // GET: SparePartStorages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sparePartStorage = await _context.SparePartStorages
                .Include(s => s.SparePart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sparePartStorage == null)
            {
                return NotFound();
            }

            return View(sparePartStorage);
        }

        // GET: SparePartStorages/Create
        public IActionResult Create()
        {
            ViewData["SparePartId"] = new SelectList(_context.SpareParts, "Id", "Id");
            return View();
        }

        // POST: SparePartStorages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SparePartId,Quantity")] SparePartStorage sparePartStorage)
        {
            sparePartStorage.LastUpdated = DateTime.Now; //Local time, not utc. 
            if (ModelState.IsValid)
            {
                _context.Add(sparePartStorage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SparePartId"] = new SelectList(_context.SpareParts, "Id", "Id", sparePartStorage.SparePartId);
            return View(sparePartStorage);
        }

        // GET: SparePartStorages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sparePartStorage = await _context.SparePartStorages.FindAsync(id);
            if (sparePartStorage == null)
            {
                return NotFound();
            }
            ViewData["SparePartId"] = new SelectList(_context.SpareParts, "Id", "Id", sparePartStorage.SparePartId);
            return View(sparePartStorage);
        }

        // POST: SparePartStorages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SparePartId,Quantity")] SparePartStorage sparePartStorage)
        {
            if (id != sparePartStorage.Id)
            {
                return NotFound();
            }

            sparePartStorage.LastUpdated = DateTime.Now; //Local time, not utc. 
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sparePartStorage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SparePartStorageExists(sparePartStorage.Id))
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
            ViewData["SparePartId"] = new SelectList(_context.SpareParts, "Id", "Id", sparePartStorage.SparePartId);
            return View(sparePartStorage);
        }

        // GET: SparePartStorages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sparePartStorage = await _context.SparePartStorages
                .Include(s => s.SparePart)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sparePartStorage == null)
            {
                return NotFound();
            }

            return View(sparePartStorage);
        }

        // POST: SparePartStorages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sparePartStorage = await _context.SparePartStorages.FindAsync(id);
            if (sparePartStorage != null)
            {
                _context.SparePartStorages.Remove(sparePartStorage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SparePartStorageExists(int id)
        {
            return _context.SparePartStorages.Any(e => e.Id == id);
        }
    }
}
