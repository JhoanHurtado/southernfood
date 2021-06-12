using southernfood.Data.Models;
using southernfood.Datos.Interface;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace southernfood.Presentacion.Controllers
{
    public class DetalleFacturasController : Controller
    {
        private IDetalleFacturaRepositorio _detalleFacturaRepositorio;
        private IFacturaRepositorio _facturaRepositorio;
        private ISupervisorRepositorio _supervisorRepositorio;

        public DetalleFacturasController(IDetalleFacturaRepositorio detalleFacturaRepositorio, IFacturaRepositorio facturaRepositorio, ISupervisorRepositorio supervisorRepositorio)
        {
            _detalleFacturaRepositorio = detalleFacturaRepositorio;
            _facturaRepositorio = facturaRepositorio;
            _supervisorRepositorio = supervisorRepositorio;
        }

        // GET: DetalleFacturas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var detalleFactura = await _detalleFacturaRepositorio.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public async Task<ActionResult> Create(int? factura)
        {
            if (factura == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var facturaCurrent = await _facturaRepositorio.Find(factura);
            if (facturaCurrent == null)
            {
                return HttpNotFound();
            }
            ViewBag.NroFactura = new SelectList(await _facturaRepositorio.Get(), "NroFactura", "NroFactura");
            ViewBag.IdSupervisor = new SelectList(await _supervisorRepositorio.Get(), "IdSupervisor", "Nombres");
            ViewBag.FacturaId = factura;
            return View();
        }

        // POST: DetalleFacturas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdDetalleFactura,NroFactura,IdSupervisor,Plato,Valor")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                await _detalleFacturaRepositorio.Add(detalleFactura);
                return RedirectToAction("Details", "Factura", new { id = detalleFactura.NroFactura });
            }

            ViewBag.NroFactura = new SelectList(await _facturaRepositorio.Get(), "NroFactura", "NroFactura", detalleFactura.NroFactura);
            ViewBag.IdSupervisor = new SelectList(await _supervisorRepositorio.Get(), "IdSupervisor", "Nombres", detalleFactura.IdSupervisor);
            return RedirectToAction("Details", "Factura", new { id = detalleFactura.NroFactura });
        }

        // GET: DetalleFacturas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var detalleFactura = await _detalleFacturaRepositorio.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            ViewBag.NroFactura = new SelectList(await _facturaRepositorio.Get(), "NroFactura", "NroFactura", detalleFactura.NroFactura);
            ViewBag.IdSupervisor = new SelectList(await _supervisorRepositorio.Get(), "IdSupervisor", "Nombres", detalleFactura.IdSupervisor);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdDetalleFactura,NroFactura,IdSupervisor,Plato,Valor")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                await _detalleFacturaRepositorio.Update(detalleFactura);
                return RedirectToAction("Details", "Factura", new { id = detalleFactura.NroFactura });
            }
            ViewBag.NroFactura = new SelectList(await _facturaRepositorio.Get(), "NroFactura", "NroFactura", detalleFactura.NroFactura);
            ViewBag.IdSupervisor = new SelectList(await _supervisorRepositorio.Get(), "IdSupervisor", "Nombres", detalleFactura.IdSupervisor);
            return RedirectToAction("Details", "Factura", new { id = detalleFactura.NroFactura });
        }

        // GET: DetalleFacturas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var detalleFactura = await _detalleFacturaRepositorio.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Details", "Factura", new { id = detalleFactura.NroFactura });
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var detalleFactura = await _detalleFacturaRepositorio.Find(id);
            await _detalleFacturaRepositorio.Delete(id);
            return RedirectToAction("Details", "Factura", new { id = detalleFactura.NroFactura });
        }
    }
}
