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
    public class HistorialsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Historials
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
            Epoch epoch = new Epoch(); 
            if (id == null)
            {
                var historialsLayout = db.Historials.OrderByDescending(h => h.FechaEpoch).ToList();
                return View(historialsLayout);
            }
            var historials = db.Historials.Where(h => h.PrivadaID == id)
                                           .OrderByDescending(h => h.FechaEpoch)
                                           .ToList();
            return View(historials);
        }
        // GET: Historials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historials historials = db.Historials.Find(id);
            if (historials == null)
            {
                return HttpNotFound();
            }
            return View(historials);
        }
        // GET: Historials/Create
        public ActionResult Create()
        {
            ViewBag.PrivadaID = new SelectList(db.Privadas, "ID", "Nombre");
            return View();
        }
        // POST: Historials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NumCasa,Observacion,Usuario,FechaEpoch,PrivadaID")] Historials historials)
        {
            if (ModelState.IsValid)
            {
                db.Historials.Add(historials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrivadaID = new SelectList(db.Privadas, "ID", "Nombre", historials.PrivadaID);
            return View(historials);
        }
        // GET: Historials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historials historials = db.Historials.Find(id);
            if (historials == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrivadaID = new SelectList(db.Privadas, "ID", "Nombre", historials.PrivadaID);
            return View(historials);
        }
        // POST: Historials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NumCasa,Observacion,Usuario,FechaEpoch,PrivadaID")] Historials historials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrivadaID = new SelectList(db.Privadas, "ID", "Nombre", historials.PrivadaID);
            return View(historials);
        }
        // GET: Historials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Historials historials = db.Historials.Find(id);
            if (historials == null)
            {
                return HttpNotFound();
            }
            return View(historials);
        }
        // POST: Historials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Historials historials = db.Historials.Find(id);
            db.Historials.Remove(historials);
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
