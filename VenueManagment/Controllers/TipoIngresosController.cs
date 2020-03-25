using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VenueManagment.Models;

namespace VenueManagment.Controllers
{
    public class TipoIngresosController : Controller
    {
        private readonly DbContexto _context;

        public TipoIngresosController(DbContexto context)
        {
            _context = context;
        }

        // GET: TipoIngresos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoIngreso.ToListAsync());
        }

        // GET: TipoIngresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.TipoIngreso
                .FirstOrDefaultAsync(m => m.idTipoIngreso == id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return View(tipoIngreso);
        }

        // GET: TipoIngresos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoIngresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTipoIngreso,nombre,estado")] TipoIngreso tipoIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoIngreso);
        }

        // GET: TipoIngresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.TipoIngreso.FindAsync(id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }
            return View(tipoIngreso);
        }

        // POST: TipoIngresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTipoIngreso,nombre,estado")] TipoIngreso tipoIngreso)
        {
            if (id != tipoIngreso.idTipoIngreso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoIngresoExists(tipoIngreso.idTipoIngreso))
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
            return View(tipoIngreso);
        }

        // GET: TipoIngresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoIngreso = await _context.TipoIngreso
                .FirstOrDefaultAsync(m => m.idTipoIngreso == id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return View(tipoIngreso);
        }

        // POST: TipoIngresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoIngreso = await _context.TipoIngreso.FindAsync(id);
            _context.TipoIngreso.Remove(tipoIngreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoIngresoExists(int id)
        {
            return _context.TipoIngreso.Any(e => e.idTipoIngreso == id);
        }
    }
}
