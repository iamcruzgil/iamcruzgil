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
    public class TipoEventosController : Controller
    {
        private readonly DbContexto _context;

        public TipoEventosController(DbContexto context)
        {
            _context = context;
        }

        // GET: TipoEventos
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.TipoEvento.Include(t => t.maestroevento);
            return View(await dbContexto.ToListAsync());
        }

        // GET: TipoEventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento
                .Include(t => t.maestroevento)
                .FirstOrDefaultAsync(m => m.idTipoEvento == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // GET: TipoEventos/Create
        public IActionResult Create()
        {
            ViewData["idMaestroEvento"] = new SelectList(_context.Set<MaestroEvento>(), "idMaestroEvento", "nombre");
            return View();
        }

        // POST: TipoEventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idTipoEvento,nombre,estado,idMaestroEvento")] TipoEvento tipoEvento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEvento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idMaestroEvento"] = new SelectList(_context.Set<MaestroEvento>(), "idMaestroEvento", "nombre", tipoEvento.idMaestroEvento);
            return View(tipoEvento);
        }

        // GET: TipoEventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento.FindAsync(id);
            if (tipoEvento == null)
            {
                return NotFound();
            }
            ViewData["idMaestroEvento"] = new SelectList(_context.Set<MaestroEvento>(), "idMaestroEvento", "nombre", tipoEvento.idMaestroEvento);
            return View(tipoEvento);
        }

        // POST: TipoEventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idTipoEvento,nombre,estado,idMaestroEvento")] TipoEvento tipoEvento)
        {
            if (id != tipoEvento.idTipoEvento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEvento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEventoExists(tipoEvento.idTipoEvento))
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
            ViewData["idMaestroEvento"] = new SelectList(_context.Set<MaestroEvento>(), "idMaestroEvento", "nombre", tipoEvento.idMaestroEvento);
            return View(tipoEvento);
        }

        // GET: TipoEventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEvento = await _context.TipoEvento
                .Include(t => t.maestroevento)
                .FirstOrDefaultAsync(m => m.idTipoEvento == id);
            if (tipoEvento == null)
            {
                return NotFound();
            }

            return View(tipoEvento);
        }

        // POST: TipoEventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEvento = await _context.TipoEvento.FindAsync(id);
            _context.TipoEvento.Remove(tipoEvento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEventoExists(int id)
        {
            return _context.TipoEvento.Any(e => e.idTipoEvento == id);
        }
    }
}
