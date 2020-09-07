using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreEntityFrameworkDBFirst1.Models;

namespace CoreEntityFrameworkDBFirst1
{
    public class EmpcompnaydetailsController : Controller
    {
        private readonly SampleContext _context;

        public EmpcompnaydetailsController(SampleContext context)
        {
            _context = context;
        }

        // GET: Empcompnaydetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empcompnaydetails.ToListAsync());
        }

        // GET: Empcompnaydetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empcompnaydetails = await _context.Empcompnaydetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empcompnaydetails == null)
            {
                return NotFound();
            }

            return View(empcompnaydetails);
        }

        // GET: Empcompnaydetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empcompnaydetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpCompanyname,Ecmplocation,Esalary")] Empcompnaydetails empcompnaydetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empcompnaydetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empcompnaydetails);
        }

        // GET: Empcompnaydetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empcompnaydetails = await _context.Empcompnaydetails.FindAsync(id);
            if (empcompnaydetails == null)
            {
                return NotFound();
            }
            return View(empcompnaydetails);
        }

        // POST: Empcompnaydetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpCompanyname,Ecmplocation,Esalary")] Empcompnaydetails empcompnaydetails)
        {
            if (id != empcompnaydetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empcompnaydetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpcompnaydetailsExists(empcompnaydetails.Id))
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
            return View(empcompnaydetails);
        }

        // GET: Empcompnaydetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empcompnaydetails = await _context.Empcompnaydetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empcompnaydetails == null)
            {
                return NotFound();
            }

            return View(empcompnaydetails);
        }

        // POST: Empcompnaydetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empcompnaydetails = await _context.Empcompnaydetails.FindAsync(id);
            _context.Empcompnaydetails.Remove(empcompnaydetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpcompnaydetailsExists(int id)
        {
            return _context.Empcompnaydetails.Any(e => e.Id == id);
        }
    }
}
