﻿using System;
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
    public class VehicleModelsController : Controller
    {
        private readonly DataContext _context;

        public VehicleModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.VehicleModels.Include(v => v.VehicleMake);
            return View(await dataContext.ToListAsync());
        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(v => v.VehicleMake)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public IActionResult Create()
        {
            ViewData["VehicleMakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,VehicleMakeId")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleMakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }
            ViewData["VehicleMakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,VehicleMakeId")] VehicleModel vehicleModel)
        {
            if (id != vehicleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicleModel.Id))
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
            ViewData["VehicleMakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name", vehicleModel.VehicleMakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(v => v.VehicleMake)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            if (vehicleModel != null)
            {
                _context.VehicleModels.Remove(vehicleModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(int id)
        {
            return _context.VehicleModels.Any(e => e.Id == id);
        }
    }
}
