using southernfood.Data.Models;
using southernfood.Datos.Interface;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace southernfood.Presentacion.Controllers
{
    public class MesaController : Controller
    {
        private IMesaRepositorio _mesaRepositorio;

        public MesaController(IMesaRepositorio mesaRepositorio)
        {
            _mesaRepositorio = mesaRepositorio;
        }
        // GET: Mesa
        public async Task<ActionResult> Index()
        {
            return View(await _mesaRepositorio.Get());
        }

        // GET: Mesa/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mesa = await _mesaRepositorio.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // GET: Mesa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mesa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NroMesa,Nombre,Reservada,Puestos")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                await _mesaRepositorio.Add(mesa);  
                return RedirectToAction("Index");
            }
            return View(mesa);
        }

        // GET: Mesa/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mesa = await _mesaRepositorio.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // POST: Mesa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NroMesa,Nombre,Reservada,Puestos")] Mesa mesa)
        {
            if (ModelState.IsValid)
            {
                await _mesaRepositorio.Update(mesa);
                return RedirectToAction("Index");
            }
            return View(mesa);
        }

        // GET: Mesa/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mesa = await _mesaRepositorio.Find(id);
            if (mesa == null)
            {
                return HttpNotFound();
            }
            return View(mesa);
        }

        // POST: Mesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _mesaRepositorio.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
