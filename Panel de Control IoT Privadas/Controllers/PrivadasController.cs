using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Panel_de_Control_IoT_Privadas.Models;

namespace Panel_de_Control_IoT_Privadas.Controllers
{
    public class PrivadasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Privadas
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["SesionActiva"] != null)
            {
                if (bool.Parse(Session["SesionActiva"].ToString()) == false)
                {
                    filterContext.Result = RedirectToAction("Login", "Administradors");
                    return;
                }
            }
        }
        public ActionResult Index()
        {
            return View(db.Privadas.ToList());
        }

        // GET: Privadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privadas privadas = db.Privadas.Find(id);
            if (privadas == null)
            {
                return HttpNotFound();
            }
            return View(privadas);
        }

        // GET: Privadas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Privadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,NumeroSerie,Contraseña,NombreAdministrador,ContraseñaAdministrador,Estatus,ServicioCompleto")] Privadas privadas)
        {
            if (ModelState.IsValid)
            {
                db.Privadas.Add(privadas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(privadas);
        }

        // GET: Privadas/Edit/5
        public ActionResult Houses(int? id)
        {
            return RedirectToAction("Index", "Casas", new { id = id });
        }
        public ActionResult Historials(int? id)
        {
            return RedirectToAction("Index", "Historials", new { id = id });
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privadas privadas = db.Privadas.Find(id);
            if (privadas == null)
            {
                return HttpNotFound();
            }
            return View(privadas);
        }

        // POST: Privadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,NumeroSerie,Contraseña,NombreAdministrador,ContraseñaAdministrador,Estatus,ServicioCompleto")] Privadas privadas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(privadas);
        }

        // GET: Privadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privadas privadas = db.Privadas.Find(id);
            if (privadas == null)
            {
                return HttpNotFound();
            }
            return View(privadas);
        }

        // POST: Privadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Privadas privadas = db.Privadas.Find(id);
            db.Privadas.Remove(privadas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
