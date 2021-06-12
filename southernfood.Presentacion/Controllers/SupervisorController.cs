using southernfood.Data.Models;
using southernfood.Datos.Interface;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace southernfood.Presentacion.Controllers
{
    public class SupervisorController : Controller
    {
        private ISupervisorRepositorio _supervisorRepositorio;

        public SupervisorController(ISupervisorRepositorio supervisorRepositorio)
        {
            _supervisorRepositorio = supervisorRepositorio;
        }

        // GET: Supervisor
        public async Task<ActionResult> Index()
        {
            return View(await _supervisorRepositorio.Get());
        }

        // GET: Supervisor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supervisor = await _supervisorRepositorio.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        // GET: Supervisor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supervisor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdSupervisor,Nombres,Apellidos,Edad,Antiguedad")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                await _supervisorRepositorio.Add(supervisor);
                return RedirectToAction("Index");
            }
            return View(supervisor);
        }

        // GET: Supervisor/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supervisor = await _supervisorRepositorio.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        // POST: Supervisor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdSupervisor,Nombres,Apellidos,Edad,Antiguedad")] Supervisor supervisor)
        {
            if (ModelState.IsValid)
            {
                await _supervisorRepositorio.Update(supervisor);
                return RedirectToAction("Index");
            }
            return View(supervisor);
        }

        // GET: Supervisor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var supervisor = await _supervisorRepositorio.Find(id);
            if (supervisor == null)
            {
                return HttpNotFound();
            }
            return View(supervisor);
        }

        // POST: Supervisor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var supervisor = await _supervisorRepositorio.Find(id);
            return RedirectToAction("Index");
        }
    }
}
