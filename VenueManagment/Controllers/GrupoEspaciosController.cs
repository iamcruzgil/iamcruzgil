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
    public class GrupoEspaciosController : Controller
    {
        private readonly DbContexto _context;

        public GrupoEspaciosController(DbContexto context)
        {
            _context = context;
        }

        // GET: GrupoEspacios
        public async Task<IActionResult> Index()
        {
            return View(await _context.GrupoEspacio.ToListAsync());
        }

        // GET: GrupoEspacios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoEspacio = await _context.GrupoEspacio
                .FirstOrDefaultAsync(m => m.idGrupoEspacio == id);
            if (grupoEspacio == null)
            {
                return NotFound();
            }

            return View(grupoEspacio);
        }

        // GET: GrupoEspacios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrupoEspacios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idGrupoEspacio,nombre,estado")] GrupoEspacio grupoEspacio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoEspacio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupoEspacio);
        }

        // GET: GrupoEspacios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoEspacio = await _context.GrupoEspacio.FindAsync(id);
            if (grupoEspacio == null)
            {
                return NotFound();
            }
            return View(grupoEspacio);
        }

        // POST: GrupoEspacios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idGrupoEspacio,nombre,estado")] GrupoEspacio grupoEspacio)
        {
            if (id != grupoEspacio.idGrupoEspacio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoEspacio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoEspacioExists(grupoEspacio.idGrupoEspacio))
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
            return View(grupoEspacio);
        }

        // GET: GrupoEspacios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoEspacio = await _context.GrupoEspacio
                .FirstOrDefaultAsync(m => m.idGrupoEspacio == id);
            if (grupoEspacio == null)
            {
                return NotFound();
            }

            return View(grupoEspacio);
        }

        // POST: GrupoEspacios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoEspacio = await _context.GrupoEspacio.FindAsync(id);
            _context.GrupoEspacio.Remove(grupoEspacio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoEspacioExists(int id)
        {
            return _context.GrupoEspacio.Any(e => e.idGrupoEspacio == id);
        }
    }
}
