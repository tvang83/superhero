using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperHeros.Data;
using SuperHeros.Models;

namespace SuperHeros.Controllers
{
    //Controller with scaffolding 
    public class SuperheroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Superheroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Name.ToListAsync());
        }

        // GET: Superheroes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Name
                .FirstOrDefaultAsync(m => m.Name == id);
            if (superhero == null)
            {
                return NotFound();
            }

            return View(superhero);
        }

        // GET: Superheroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Superheroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Alter_Ego,Primary_Ability,Secondary_Ability,Catchphrase")] Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superhero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superhero);
        }

        // GET: Superheroes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Name.FindAsync(id);
            if (superhero == null)
            {
                return NotFound();
            }
            return View(superhero);
        }

        // POST: Superheroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Alter_Ego,Primary_Ability,Secondary_Ability,Catchphrase")] Superhero superhero)
        {
            if (id != superhero.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superhero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperheroExists(superhero.Name))
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
            return View(superhero);
        }

        // GET: Superheroes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Name
                .FirstOrDefaultAsync(m => m.Name == id);
            if (superhero == null)
            {
                return NotFound();
            }

            return View(superhero);
        }

        // POST: Superheroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var superhero = await _context.Name.FindAsync(id);
            _context.Name.Remove(superhero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperheroExists(string id)
        {
            return _context.Name.Any(e => e.Name == id);
        }
    }
}
