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
    public class RazonSocialsController : Controller
    {
        private readonly DbContexto _context;

        public RazonSocialsController(DbContexto context)
        {
            _context = context;
        }

        // GET: RazonSocials
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.RazonSocial.Include(r => r.cuenta);
            return View(await dbContexto.ToListAsync());
        }

        // GET: RazonSocials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razonSocial = await _context.RazonSocial
                .Include(r => r.cuenta)
                .FirstOrDefaultAsync(m => m.idRazonSocial == id);
            if (razonSocial == null)
            {
                return NotFound();
            }

            return View(razonSocial);
        }

        // GET: RazonSocials/Create
        public IActionResult Create()
        {
            ViewData["idCuenta"] = new SelectList(_context.Cuenta, "idCuenta", "nombre");
            return View();
        }

        // POST: RazonSocials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idRazonSocial,nombre,rfc,calle,colonia,noInt,noExt,ciudad,estado,pais,cp,metodoPago,usoCfdi,estatus,idCuenta")] RazonSocial razonSocial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(razonSocial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCuenta"] = new SelectList(_context.Cuenta, "idCuenta", "nombre", razonSocial.idCuenta);
            return View(razonSocial);
        }

        // GET: RazonSocials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razonSocial = await _context.RazonSocial.FindAsync(id);
            if (razonSocial == null)
            {
                return NotFound();
            }
            ViewData["idCuenta"] = new SelectList(_context.Cuenta, "idCuenta", "nombre", razonSocial.idCuenta);
            return View(razonSocial);
        }

        // POST: RazonSocials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idRazonSocial,nombre,rfc,calle,colonia,noInt,noExt,ciudad,estado,pais,cp,metodoPago,usoCfdi,estatus,idCuenta")] RazonSocial razonSocial)
        {
            if (id != razonSocial.idRazonSocial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(razonSocial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RazonSocialExists(razonSocial.idRazonSocial))
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
            ViewData["idCuenta"] = new SelectList(_context.Cuenta, "idCuenta", "nombre", razonSocial.idCuenta);
            return View(razonSocial);
        }

        // GET: RazonSocials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razonSocial = await _context.RazonSocial
                .Include(r => r.cuenta)
                .FirstOrDefaultAsync(m => m.idRazonSocial == id);
            if (razonSocial == null)
            {
                return NotFound();
            }

            return View(razonSocial);
        }

        // POST: RazonSocials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var razonSocial = await _context.RazonSocial.FindAsync(id);
            _context.RazonSocial.Remove(razonSocial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RazonSocialExists(int id)
        {
            return _context.RazonSocial.Any(e => e.idRazonSocial == id);
        }
    }
}
