using southernfood.Data.Models;
using southernfood.Datos.Interface;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace southernfood.Presentacion.Controllers
{
    public class ClienteController : Controller
    {      
        private IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            return View(await _clienteRepositorio.Get());
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = await _clienteRepositorio.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificacion,Nombres,Apellidos,Direccion,Telefono")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepositorio.Add(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = await _clienteRepositorio.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificacion,Nombres,Apellidos,Direccion,Telefono")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepositorio.Update(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = await _clienteRepositorio.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //var cliente = _clienteRepositorio.GetClienteAsync(id);
            await _clienteRepositorio.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
