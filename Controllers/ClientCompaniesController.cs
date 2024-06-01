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
    public class ClientCompaniesController : Controller
    {
        private readonly DataContext _context;

        public ClientCompaniesController(DataContext context)
        {
            _context = context;
        }

        // GET: ClientCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientCompanies.ToListAsync());
        }

        // GET: ClientCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCompany = await _context.ClientCompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientCompany == null)
            {
                return NotFound();
            }

            return View(clientCompany);
        }

        // GET: ClientCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ContactName,Phone,Email,Address,Notes")] ClientCompany clientCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientCompany);
        }

        // GET: ClientCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCompany = await _context.ClientCompanies.FindAsync(id);
            if (clientCompany == null)
            {
                return NotFound();
            }
            return View(clientCompany);
        }

        // POST: ClientCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ContactName,Phone,Email,Address,Notes")] ClientCompany clientCompany)
        {
            if (id != clientCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientCompanyExists(clientCompany.Id))
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
            return View(clientCompany);
        }

        // GET: ClientCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCompany = await _context.ClientCompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientCompany == null)
            {
                return NotFound();
            }

            return View(clientCompany);
        }

        // POST: ClientCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientCompany = await _context.ClientCompanies.FindAsync(id);
            if (clientCompany != null)
            {
                _context.ClientCompanies.Remove(clientCompany);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientCompanyExists(int id)
        {
            return _context.ClientCompanies.Any(e => e.Id == id);
        }
    }
}
