﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstacionamientoMVC.B.Data;
using EstacionamientoMVC.B.Models;

namespace EstacionamientoMVC.B.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly MiDb_B _miDb;

        public DireccionesController(MiDb_B context)
        {
            _miDb = context;
        }

        public async Task<IActionResult> Index()
        {
            var MiDb_B = _miDb.Direcciones.Include(d => d.Cliente);
            return View(await MiDb_B.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        public IActionResult Create(int? clienteId)
        {
            ViewBag.ClienteId = clienteId;

            ViewData["Id"]= new SelectList(_miDb.Clientes, "Id", "NombreCompleto");         


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Calle,Numero,Piso,Departamento,CodigoPostal,ClienteId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _miDb.Add(direccion);
                await _miDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            //ModelState.AddModelError("Departamento","No podes vivir en el dpto A");
            //ModelState.AddModelError(string.Empty, "Otro error, poquesiii");

            ViewData["Id"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", direccion.Id);
            return View(direccion);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", direccion.Id);
            return View(direccion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,Numero,Piso,Departamento,CodigoPostal,ClienteId")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(direccion);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            
            ViewData["Id"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", direccion.Id);
           
            return View(direccion);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _miDb.Direcciones
                .Include(d => d.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccion = await _miDb.Direcciones.FindAsync(id);
            if (direccion != null)
            {
                _miDb.Direcciones.Remove(direccion);
            }

            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
            return _miDb.Direcciones.Any(e => e.Id == id);
        }
    }
}
