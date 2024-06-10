using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitmentProcess.Database;
using RecruitmentProcess.Models;

namespace RecruitmentProcess.Controllers
{
    public class RekrutacjaModelsController : Controller
    {
        private readonly RecruitmentContext _context;

        public RekrutacjaModelsController(RecruitmentContext context)
        {
            _context = context;
        }

        // GET: RekrutacjaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rekrutacja.ToListAsync());
        }

        // GET: RekrutacjaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rekrutacjaModel = await _context.Rekrutacja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rekrutacjaModel == null)
            {
                return NotFound();
            }

            return View(rekrutacjaModel);
        }

        // GET: RekrutacjaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RekrutacjaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAplikacji,IdOgloszenia,IdRekrutera,IdUzytkownika,Tresc,DataAplikacji,PlikCV,Status")] RekrutacjaModel rekrutacjaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rekrutacjaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rekrutacjaModel);
        }

        // GET: RekrutacjaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rekrutacjaModel = await _context.Rekrutacja.FindAsync(id);
            if (rekrutacjaModel == null)
            {
                return NotFound();
            }
            return View(rekrutacjaModel);
        }

        // POST: RekrutacjaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAplikacji,IdOgloszenia,IdRekrutera,IdUzytkownika,Tresc,DataAplikacji,PlikCV,Status")] RekrutacjaModel rekrutacjaModel)
        {
            if (id != rekrutacjaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rekrutacjaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RekrutacjaModelExists(rekrutacjaModel.Id))
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
            return View(rekrutacjaModel);
        }

        // GET: RekrutacjaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rekrutacjaModel = await _context.Rekrutacja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rekrutacjaModel == null)
            {
                return NotFound();
            }

            return View(rekrutacjaModel);
        }

        // POST: RekrutacjaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rekrutacjaModel = await _context.Rekrutacja.FindAsync(id);
            if (rekrutacjaModel != null)
            {
                _context.Rekrutacja.Remove(rekrutacjaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RekrutacjaModelExists(int id)
        {
            return _context.Rekrutacja.Any(e => e.Id == id);
        }
    }
}
