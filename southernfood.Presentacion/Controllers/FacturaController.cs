using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using southernfood.Data.Models;
using southernfood.Datos.Interface;

namespace southernfood.Presentacion.Controllers
{
    public class FacturaController : Controller
    {
        private IFacturaRepositorio _facturaRepositorio;
        private IMeseroRepositorio _meseroRepositorio;
        private IMesaRepositorio _mesaRepositorio;
        private IClienteRepositorio _clienteRepositorio;

        public FacturaController(IFacturaRepositorio facturaRepositorio, IMeseroRepositorio meseroRepositorio, IMesaRepositorio mesaRepositorio, IClienteRepositorio clienteRepositorio)
        {
            _facturaRepositorio = facturaRepositorio;
            _meseroRepositorio = meseroRepositorio;
            _mesaRepositorio = mesaRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        // GET: Factura
        public async Task<ActionResult> Index()
        {
            var facturas = await _facturaRepositorio.Get();
            return View(facturas);
        }

        // GET: Factura/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var factura = await _facturaRepositorio.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Factura/Create
        public async Task<ActionResult> Create()
        {
            var mesas = await _mesaRepositorio.Get();
            //mesas = mesas.Where(m => m.Reservada == 0).ToList();
            ViewBag.IdCliente = new SelectList(await _clienteRepositorio.Get(), "Identificacion", "Nombres");
            ViewBag.NroMesa = new SelectList(mesas, "NroMesa", "Nombre");
            ViewBag.IdMesero = new SelectList(await _meseroRepositorio.Get(), "IdMesero", "Nombres");
            return View();
        }

        // POST: Factura/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NroFactura,IdCliente,NroMesa,IdMesero,Fecha")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                await _facturaRepositorio.Add(factura);
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(await _clienteRepositorio.Get(), "Identificacion", "Nombres", factura.IdCliente);
            ViewBag.NroMesa = new SelectList(await _mesaRepositorio.Get(), "NroMesa", "Nombre", factura.NroMesa);
            ViewBag.IdMesero = new SelectList(await _meseroRepositorio.Get(), "IdMesero", "Nombres", factura.IdMesero);
            return View(factura);
        }

        // GET: Factura/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var factura = await _facturaRepositorio.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(await _clienteRepositorio.Get(), "Identificacion", "Nombres", factura.IdCliente);
            ViewBag.NroMesa = new SelectList(await _mesaRepositorio.Get(), "NroMesa", "Nombre", factura.NroMesa);
            ViewBag.IdMesero = new SelectList(await _meseroRepositorio.Get(), "IdMesero", "Nombres", factura.IdMesero);
            return View(factura);
        }

        // POST: Factura/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NroFactura,IdCliente,NroMesa,IdMesero,Fecha")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                await _facturaRepositorio.Update(factura);
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(await _clienteRepositorio.Get(), "Identificacion", "Nombres", factura.IdCliente);
            ViewBag.NroMesa = new SelectList(await _mesaRepositorio.Get(), "NroMesa", "Nombre", factura.NroMesa);
            ViewBag.IdMesero = new SelectList(await _meseroRepositorio.Get(), "IdMesero", "Nombres", factura.IdMesero);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var factura = await _facturaRepositorio.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync(int id)
        {
            await _facturaRepositorio.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
