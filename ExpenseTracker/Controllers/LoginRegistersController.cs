using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseTracker.Controllers
{
    [Authorize]
    public class LoginRegistersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginRegistersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LoginRegisters
        public async Task<IActionResult> Index()
        {
              return _context.LoginRegisters != null ? 
                          View(await _context.LoginRegisters.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LoginRegisters'  is null.");
        }

        // GET: LoginRegisters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoginRegisters == null)
            {
                return NotFound();
            }

            var loginRegister = await _context.LoginRegisters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginRegister == null)
            {
                return NotFound();
            }

            return View(loginRegister);
        }

        // GET: LoginRegisters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone")] LoginRegister loginRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginRegister);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginRegister);
        }

        // GET: LoginRegisters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoginRegisters == null)
            {
                return NotFound();
            }

            var loginRegister = await _context.LoginRegisters.FindAsync(id);
            if (loginRegister == null)
            {
                return NotFound();
            }
            return View(loginRegister);
        }

        // POST: LoginRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone")] LoginRegister loginRegister)
        {
            if (id != loginRegister.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginRegister);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginRegisterExists(loginRegister.Id))
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
            return View(loginRegister);
        }

        // GET: LoginRegisters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoginRegisters == null)
            {
                return NotFound();
            }

            var loginRegister = await _context.LoginRegisters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginRegister == null)
            {
                return NotFound();
            }

            return View(loginRegister);
        }

        // POST: LoginRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoginRegisters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LoginRegisters'  is null.");
            }
            var loginRegister = await _context.LoginRegisters.FindAsync(id);
            if (loginRegister != null)
            {
                _context.LoginRegisters.Remove(loginRegister);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginRegisterExists(int id)
        {
          return (_context.LoginRegisters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
