using southernfood.Data.Models;
using southernfood.Datos.Interface;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace southernfood.Presentacion.Controllers
{
    public class MeseroController : Controller
    {
        private IMeseroRepositorio _meseroRepositorio;

        public MeseroController(IMeseroRepositorio meseroRepositorio)
        {
            _meseroRepositorio = meseroRepositorio;

        }

        // GET: Mesero
        public async Task<ActionResult> Index()
        {
            return View(await _meseroRepositorio.Get());
        }

        // GET: Mesero/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mesero = await _meseroRepositorio.Find(id);
            if (mesero == null)
            {
                return HttpNotFound();
            }
            return View(mesero);
        }

        // GET: Mesero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mesero/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdMesero,Nombres,Apellidos,Edad,Antiguedad")] Mesero mesero)
        {
            if (ModelState.IsValid)
            {
                await _meseroRepositorio.Add(mesero);
                return RedirectToAction("Index");
            }
            return View(mesero);
        }

        // GET: Mesero/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mesero = await _meseroRepositorio.Find(id);
            if (mesero == null)
            {
                return HttpNotFound();
            }
            return View(mesero);
        }

        // POST: Mesero/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdMesero,Nombres,Apellidos,Edad,Antiguedad")] Mesero mesero)
        {
            if (ModelState.IsValid)
            {
                await _meseroRepositorio.Update(mesero);
                return RedirectToAction("Index");
            }
            return View(mesero);
        }

        // GET: Mesero/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var mesero = await _meseroRepositorio.Find(id);
            if (mesero == null)
            {
                return HttpNotFound();
            }
            return View(mesero);
        }

        // POST: Mesero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var mesero = await _meseroRepositorio.Find(id);
            return RedirectToAction("Index");
        }
    }
}
