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
    public class CasasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Casas
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
        public ActionResult Index(int? id)
        {
            if(id == null)
            {
                var casasLayout = db.Casas.ToList();
                return View(casasLayout);
            } 
            var casas =  db.Casas.Where(c => c.PrivadaID == id).ToList().OrderBy(c => c.NumCasa);
            return View(casas);
        }
        // GET: Casas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casas casas = db.Casas.Find(id);
            if (casas == null)
            {
                return HttpNotFound();
            }
            return View(casas);
        }
        public ActionResult Users(int? id)
        {
            return RedirectToAction("Index", "Usuarios", new {id = id});
        }

        // GET: Casas/Create
        public ActionResult Create()
        {
            ViewBag.PrivadaID = new SelectList(db.Privadas, "ID", "Nombre");
            return View();
        }

        // POST: Casas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NumCasa,PrivadaID,Estatus")] Casas casas)
        {
            if (ModelState.IsValid)
            {
                db.Casas.Add(casas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrivadaID = new SelectList(db.Privadas, "ID", "Nombre", casas.PrivadaID);
            return View(casas);
        }

        // GET: Casas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casas casas = db.Casas.Find(id);
            if (casas == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrivadaID = new SelectList(db.Privadas, "ID", "Nombre", casas.PrivadaID);
            return View(casas);
        }

        // POST: Casas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NumCasa,PrivadaID,Estatus")] Casas casas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrivadaID = new SelectList(db.Privadas, "ID", "Nombre", casas.PrivadaID);
            return View(casas);
        }

        // GET: Casas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Casas casas = db.Casas.Find(id);
            if (casas == null)
            {
                return HttpNotFound();
            }
            return View(casas);
        }

        // POST: Casas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Casas casas = db.Casas.Find(id);
            db.Casas.Remove(casas);
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
