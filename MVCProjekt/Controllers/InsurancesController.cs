using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCProjekt.Data;
using MVCProjekt.Models;
using Newtonsoft.Json.Linq;

namespace MVCProjekt.Controllers
{
    public class InsurancesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InsurancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Insurances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Insurance.Include(i => i.Client);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Insurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Insurance == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurance
                .Include(i => i.Client)
                .FirstOrDefaultAsync(m => m.InsuranceId == id);
            if (insurance == null)
            {
                return NotFound();
            }
            var client = await _context.Client.FirstOrDefaultAsync(x => x.ClientId == insurance.ClientId);
            ViewBag.ClientId = client?.ClientId;
            ViewBag.InsuranceId = insurance.InsuranceId;
            ViewBag.Name = client.Name + " " + client.Surnname;


            return View(insurance);
        }

        public async Task<IActionResult> CreateAsync(int value)
        {
            ViewBag.ClientId = value;
            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.ClientId == value);
            ViewBag.Name = client.Name + " " + client.Surnname;

            return View();
        }
        // POST: Insurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InsuranceId,ClientId,InsuranceName,InsuranceValue,ObjectOfInsurance")] Insurance insurance, int value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insurance);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Clients", new { @id = value}); // MŮŽE ZPŮSOBOVAT PROBLÉMY
            }
            
            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.ClientId == value);

            ViewBag.ClientId = value;
            ViewBag.Name = client.Name + " " + client.Surnname;

            return View(insurance);

        }

        // GET: Insurances/Edit/5
        public async Task<IActionResult> Edit(int? id, int value)
        {
            if (id == null || _context.Insurance == null)
            {
                return NotFound();
            }

            var insurance = await _context.Insurance.FindAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "InsuranceId", "Address", insurance.ClientId);
            ViewBag.ClientId = insurance.ClientId;
            ViewBag.InsuranceId = insurance.InsuranceId;
            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.ClientId == insurance.ClientId);
            ViewBag.Jmeno = client.Name + " " + client.Surnname;
            return View(insurance);
        }

        // POST: Insurances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InsuranceId,ClientId,InsuranceName,InsuranceValue,ObjectOfInsurance")] Insurance insurance)
        {
            if (id != insurance.InsuranceId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceExists(insurance.InsuranceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect($"/Clients/Details/{insurance.ClientId}");
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Address", insurance.ClientId);
            return View(insurance);
        }

        // GET: Insurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Insurance == null)
            {
                return NotFound();
            }
            var insurance = await _context.Insurance
                .Include(i => i.Client)
                .FirstOrDefaultAsync(m => m.InsuranceId == id);


            var client = await _context.Client
                .FirstOrDefaultAsync(m => m.ClientId == insurance.ClientId);


            ViewBag.ClientId = insurance.ClientId;
            ViewBag.InsuranceId = insurance.InsuranceId;
            ViewBag.Name = client.Name + " " + client.Surnname;
            if (insurance == null)
            {
                return NotFound();
            }

            return View(insurance);
        }

        // POST: Insurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Insurance == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Insurance'  is null.");
            }
            
            var insurance = await _context.Insurance.FindAsync(id);
            var client = await _context.Client
                .FirstOrDefaultAsync (m => m.ClientId == insurance.ClientId);
            if (insurance != null)
            {
                _context.Insurance.Remove(insurance);
            }
            await _context.SaveChangesAsync();
            return Redirect($"/Clients/Details/{client.ClientId}");
        }

        private bool InsuranceExists(int id)
        {
          return (_context.Insurance?.Any(e => e.InsuranceId == id)).GetValueOrDefault();
        }
    }
}
