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
    public class ClientVehiclesController : Controller
    {
        private readonly DataContext _context;

        public ClientVehiclesController(DataContext context)
        {
            _context = context;
        }

        // GET: ClientVehicles
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.ClientVehicles.Include(c => c.Client).Include(c => c.ClientCompany).Include(c => c.VehicleMake).Include(c => c.VehicleModel);
            return View(await dataContext.ToListAsync());
        }

        // GET: ClientVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientVehicle = await _context.ClientVehicles
                .Include(c => c.Client)
                .Include(c => c.ClientCompany)
                .Include(c => c.VehicleMake)
                .Include(c => c.VehicleModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientVehicle == null)
            {
                return NotFound();
            }

            return View(clientVehicle);
        }

        // GET: ClientVehicles/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["ClientCompanyId"] = new SelectList(_context.ClientCompanies, "Id", "Id");
            ViewData["VehicleMakeId"] = new SelectList(_context.VehicleMakes, "Id", "Id");
            ViewData["VehicleModelId"] = new SelectList(_context.VehicleModels, "Id", "Id");
            return View();
        }

        // POST: ClientVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleMakeId,VehicleModelId,Year,VIN,LicensePlate,ClientId,ClientCompanyId")] ClientVehicle clientVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientVehicle.ClientId);
            ViewData["ClientCompanyId"] = new SelectList(_context.ClientCompanies, "Id", "Id", clientVehicle.ClientCompanyId);
            ViewData["VehicleMakeId"] = new SelectList(_context.VehicleMakes, "Id", "Id", clientVehicle.VehicleMakeId);
            ViewData["VehicleModelId"] = new SelectList(_context.VehicleModels, "Id", "Id", clientVehicle.VehicleModelId);
            return View(clientVehicle);
        }

        // GET: ClientVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientVehicle = await _context.ClientVehicles.FindAsync(id);
            if (clientVehicle == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientVehicle.ClientId);
            ViewData["ClientCompanyId"] = new SelectList(_context.ClientCompanies, "Id", "Id", clientVehicle.ClientCompanyId);
            ViewData["VehicleMakeId"] = new SelectList(_context.VehicleMakes, "Id", "Id", clientVehicle.VehicleMakeId);
            ViewData["VehicleModelId"] = new SelectList(_context.VehicleModels, "Id", "Id", clientVehicle.VehicleModelId);
            return View(clientVehicle);
        }

        // POST: ClientVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleMakeId,VehicleModelId,Year,VIN,LicensePlate,ClientId,ClientCompanyId")] ClientVehicle clientVehicle)
        {
            if (id != clientVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientVehicleExists(clientVehicle.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientVehicle.ClientId);
            ViewData["ClientCompanyId"] = new SelectList(_context.ClientCompanies, "Id", "Id", clientVehicle.ClientCompanyId);
            ViewData["VehicleMakeId"] = new SelectList(_context.VehicleMakes, "Id", "Id", clientVehicle.VehicleMakeId);
            ViewData["VehicleModelId"] = new SelectList(_context.VehicleModels, "Id", "Id", clientVehicle.VehicleModelId);
            return View(clientVehicle);
        }

        // GET: ClientVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientVehicle = await _context.ClientVehicles
                .Include(c => c.Client)
                .Include(c => c.ClientCompany)
                .Include(c => c.VehicleMake)
                .Include(c => c.VehicleModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientVehicle == null)
            {
                return NotFound();
            }

            return View(clientVehicle);
        }

        // POST: ClientVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientVehicle = await _context.ClientVehicles.FindAsync(id);
            if (clientVehicle != null)
            {
                _context.ClientVehicles.Remove(clientVehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientVehicleExists(int id)
        {
            return _context.ClientVehicles.Any(e => e.Id == id);
        }
    }
}
