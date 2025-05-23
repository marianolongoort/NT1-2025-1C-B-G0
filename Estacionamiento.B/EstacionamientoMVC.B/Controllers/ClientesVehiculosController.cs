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
    public class ClientesVehiculosController : Controller
    {
        private readonly MiDb_B _miDb;

        public ClientesVehiculosController(MiDb_B context)
        {
            _miDb = context;
        }

        // GET: ClienteVehiculos
        public async Task<IActionResult> Index()
        {
            var miDb_C = _miDb.ClienteVehiculos.Include(c => c.Cliente).Include(c => c.Vehiculo);
            return View(await miDb_C.ToListAsync());
        }

        // GET: ClienteVehiculos/Details/5
        public async Task<IActionResult> Details(int? clienteId,int? vehiculoId)
        {
            if (clienteId is null || vehiculoId is null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _miDb.ClienteVehiculos
                .Include(c => c.Cliente)
                .Include(c => c.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == clienteId && m.VehiculoId == vehiculoId);
           
            
            if (clienteVehiculo == null)
            {
                return NotFound();
            }

            return View(clienteVehiculo);
        }

        // GET: ClienteVehiculos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto");
            ViewData["VehiculoId"] = new SelectList(_miDb.Vehiculos, "Id", "Patente");
            return View();
        }

        // POST: ClienteVehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,VehiculoId,ResponsablePrincipal")] ClienteVehiculo clienteVehiculo)
        {
            if (ModelState.IsValid)
            {
                _miDb.Add(clienteVehiculo);
                await _miDb.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", " NombreCompleto", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_miDb.Vehiculos, "Id", "Patente", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // GET: ClienteVehiculos/Edit/5
        public async Task<IActionResult> Edit(int? clienteid,int? vehiculoid)
        {
            if (clienteid == null || vehiculoid == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _miDb.ClienteVehiculos.FindAsync(clienteid,vehiculoid);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_miDb.Vehiculos, "Id", "Patente", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // POST: ClienteVehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ClienteId,VehiculoId,ResponsablePrincipal")] ClienteVehiculo clienteVehiculo)
        {           

            if (ModelState.IsValid)
            {
                try
                {
                    _miDb.Update(clienteVehiculo);
                    await _miDb.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteVehiculoExists(clienteVehiculo.ClienteId))
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
            ViewData["ClienteId"] = new SelectList(_miDb.Clientes, "Id", "NombreCompleto", clienteVehiculo.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_miDb.Vehiculos, "Id", "Patente", clienteVehiculo.VehiculoId);
            return View(clienteVehiculo);
        }

        // GET: ClienteVehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteVehiculo = await _miDb.ClienteVehiculos
                .Include(c => c.Cliente)
                .Include(c => c.Vehiculo)
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteVehiculo == null)
            {
                return NotFound();
            }

            return View(clienteVehiculo);
        }

        // POST: ClienteVehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteVehiculo = await _miDb.ClienteVehiculos.FindAsync(id);
            if (clienteVehiculo != null)
            {
                _miDb.ClienteVehiculos.Remove(clienteVehiculo);
            }

            await _miDb.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteVehiculoExists(int id)
        {
            return _miDb.ClienteVehiculos.Any(e => e.ClienteId == id);
        }
    }
}
