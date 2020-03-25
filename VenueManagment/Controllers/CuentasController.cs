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
    public class CuentasController : Controller
    {
        private readonly DbContexto _context;

        public CuentasController(DbContexto context)
        {
            _context = context;
        }

        // GET: Cuentas
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Cuenta.Include(c => c.campana).Include(c => c.contacto).Include(c => c.segmento);
            return View(await dbContexto.ToListAsync());
        }

        // GET: Cuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuenta
                .Include(c => c.campana)
                .Include(c => c.contacto)
                .Include(c => c.segmento)
                .FirstOrDefaultAsync(m => m.idCuenta == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // GET: Cuentas/Create
        public IActionResult Create()
        {
            ViewData["idCampana"] = new SelectList(_context.Set<Campana>(), "idCampana", "nombre");
            ViewData["idContacto"] = new SelectList(_context.Contacto, "idContacto", "email");
            ViewData["idSegmento"] = new SelectList(_context.Segmento, "idSegmento", "nombre");
            return View();
        }

        // POST: Cuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCuenta,nombre,calle,colonia,noInt,noExt,ciudad,estado,pais,cp,web,descripcion,estatus,idContacto,idSegmento,idCampana")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCampana"] = new SelectList(_context.Set<Campana>(), "idCampana", "nombre", cuenta.idCampana);
            ViewData["idContacto"] = new SelectList(_context.Contacto, "idContacto", "email", cuenta.idContacto);
            ViewData["idSegmento"] = new SelectList(_context.Segmento, "idSegmento", "nombre", cuenta.idSegmento);
            return View(cuenta);
        }

        // GET: Cuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuenta.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }
            ViewData["idCampana"] = new SelectList(_context.Set<Campana>(), "idCampana", "nombre", cuenta.idCampana);
            ViewData["idContacto"] = new SelectList(_context.Contacto, "idContacto", "email", cuenta.idContacto);
            ViewData["idSegmento"] = new SelectList(_context.Segmento, "idSegmento", "nombre", cuenta.idSegmento);
            return View(cuenta);
        }

        // POST: Cuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCuenta,nombre,calle,colonia,noInt,noExt,ciudad,estado,pais,cp,web,descripcion,estatus,idContacto,idSegmento,idCampana")] Cuenta cuenta)
        {
            if (id != cuenta.idCuenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentaExists(cuenta.idCuenta))
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
            ViewData["idCampana"] = new SelectList(_context.Set<Campana>(), "idCampana", "nombre", cuenta.idCampana);
            ViewData["idContacto"] = new SelectList(_context.Contacto, "idContacto", "email", cuenta.idContacto);
            ViewData["idSegmento"] = new SelectList(_context.Segmento, "idSegmento", "nombre", cuenta.idSegmento);
            return View(cuenta);
        }

        // GET: Cuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuenta
                .Include(c => c.campana)
                .Include(c => c.contacto)
                .Include(c => c.segmento)
                .FirstOrDefaultAsync(m => m.idCuenta == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuenta = await _context.Cuenta.FindAsync(id);
            _context.Cuenta.Remove(cuenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentaExists(int id)
        {
            return _context.Cuenta.Any(e => e.idCuenta == id);
        }
    }
}
