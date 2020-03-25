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
    public class FlujoIngresosController : Controller
    {
        private readonly DbContexto _context;

        public FlujoIngresosController(DbContexto context)
        {
            _context = context;
        }

        // GET: FlujoIngresos
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.FlujoIngreso.Include(f => f.tipoingreso);
            return View(await dbContexto.ToListAsync());
        }

        // GET: FlujoIngresos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flujoIngreso = await _context.FlujoIngreso
                .Include(f => f.tipoingreso)
                .FirstOrDefaultAsync(m => m.idFlujoIngreso == id);
            if (flujoIngreso == null)
            {
                return NotFound();
            }

            return View(flujoIngreso);
        }

        // GET: FlujoIngresos/Create
        public IActionResult Create()
        {
            ViewData["idTipoIngreso"] = new SelectList(_context.TipoIngreso, "idTipoIngreso", "nombre");
            return View();
        }

        // POST: FlujoIngresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idFlujoIngreso,nombre,estado,idTipoIngreso")] FlujoIngreso flujoIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flujoIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idTipoIngreso"] = new SelectList(_context.TipoIngreso, "idTipoIngreso", "nombre", flujoIngreso.idTipoIngreso);
            return View(flujoIngreso);
        }

        // GET: FlujoIngresos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flujoIngreso = await _context.FlujoIngreso.FindAsync(id);
            if (flujoIngreso == null)
            {
                return NotFound();
            }
            ViewData["idTipoIngreso"] = new SelectList(_context.TipoIngreso, "idTipoIngreso", "nombre", flujoIngreso.idTipoIngreso);
            return View(flujoIngreso);
        }

        // POST: FlujoIngresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idFlujoIngreso,nombre,estado,idTipoIngreso")] FlujoIngreso flujoIngreso)
        {
            if (id != flujoIngreso.idFlujoIngreso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flujoIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlujoIngresoExists(flujoIngreso.idFlujoIngreso))
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
            ViewData["idTipoIngreso"] = new SelectList(_context.TipoIngreso, "idTipoIngreso", "nombre", flujoIngreso.idTipoIngreso);
            return View(flujoIngreso);
        }

        // GET: FlujoIngresos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flujoIngreso = await _context.FlujoIngreso
                .Include(f => f.tipoingreso)
                .FirstOrDefaultAsync(m => m.idFlujoIngreso == id);
            if (flujoIngreso == null)
            {
                return NotFound();
            }

            return View(flujoIngreso);
        }

        // POST: FlujoIngresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flujoIngreso = await _context.FlujoIngreso.FindAsync(id);
            _context.FlujoIngreso.Remove(flujoIngreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlujoIngresoExists(int id)
        {
            return _context.FlujoIngreso.Any(e => e.idFlujoIngreso == id);
        }
    }
}
