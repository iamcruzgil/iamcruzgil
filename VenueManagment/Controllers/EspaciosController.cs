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
    public class EspaciosController : Controller
    {
        private readonly DbContexto _context;

        public EspaciosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Espacios
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Espacio.Include(e => e.flujoingreso).Include(e => e.grupoespacio).Include(e => e.venue);
            return View(await dbContexto.ToListAsync());
        }

        // GET: Espacios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacio = await _context.Espacio
                .Include(e => e.flujoingreso)
                .Include(e => e.grupoespacio)
                .Include(e => e.venue)
                .FirstOrDefaultAsync(m => m.idEspacio == id);
            if (espacio == null)
            {
                return NotFound();
            }

            return View(espacio);
        }

        // GET: Espacios/Create
        public IActionResult Create()
        {
            ViewData["idFlujoIngreso"] = new SelectList(_context.FlujoIngreso, "idFlujoIngreso", "nombre");
            ViewData["idGrupoEspacio"] = new SelectList(_context.GrupoEspacio, "idGrupoEspacio", "nombre");
            ViewData["idVenue"] = new SelectList(_context.Venue, "idVenue", "nombre");
            return View();
        }

        // POST: Espacios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idEspacio,nombre,capacidadMaxima,area,combo,estado,idFlujoIngreso,idGrupoEspacio,idVenue")] Espacio espacio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(espacio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idFlujoIngreso"] = new SelectList(_context.FlujoIngreso, "idFlujoIngreso", "nombre", espacio.idFlujoIngreso);
            ViewData["idGrupoEspacio"] = new SelectList(_context.GrupoEspacio, "idGrupoEspacio", "nombre", espacio.idGrupoEspacio);
            ViewData["idVenue"] = new SelectList(_context.Venue, "idVenue", "nombre", espacio.idVenue);
            return View(espacio);
        }

        // GET: Espacios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacio = await _context.Espacio.FindAsync(id);
            if (espacio == null)
            {
                return NotFound();
            }
            ViewData["idFlujoIngreso"] = new SelectList(_context.FlujoIngreso, "idFlujoIngreso", "nombre", espacio.idFlujoIngreso);
            ViewData["idGrupoEspacio"] = new SelectList(_context.GrupoEspacio, "idGrupoEspacio", "nombre", espacio.idGrupoEspacio);
            ViewData["idVenue"] = new SelectList(_context.Venue, "idVenue", "nombre", espacio.idVenue);
            return View(espacio);
        }

        // POST: Espacios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idEspacio,nombre,capacidadMaxima,area,combo,estado,idFlujoIngreso,idGrupoEspacio,idVenue")] Espacio espacio)
        {
            if (id != espacio.idEspacio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(espacio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspacioExists(espacio.idEspacio))
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
            ViewData["idFlujoIngreso"] = new SelectList(_context.FlujoIngreso, "idFlujoIngreso", "nombre", espacio.idFlujoIngreso);
            ViewData["idGrupoEspacio"] = new SelectList(_context.GrupoEspacio, "idGrupoEspacio", "nombre", espacio.idGrupoEspacio);
            ViewData["idVenue"] = new SelectList(_context.Venue, "idVenue", "nombre", espacio.idVenue);
            return View(espacio);
        }

        // GET: Espacios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var espacio = await _context.Espacio
                .Include(e => e.flujoingreso)
                .Include(e => e.grupoespacio)
                .Include(e => e.venue)
                .FirstOrDefaultAsync(m => m.idEspacio == id);
            if (espacio == null)
            {
                return NotFound();
            }

            return View(espacio);
        }

        // POST: Espacios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var espacio = await _context.Espacio.FindAsync(id);
            _context.Espacio.Remove(espacio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspacioExists(int id)
        {
            return _context.Espacio.Any(e => e.idEspacio == id);
        }
    }
}
