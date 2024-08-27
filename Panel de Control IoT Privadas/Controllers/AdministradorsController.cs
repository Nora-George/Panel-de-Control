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
    public class AdministradorsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Administradors
        
        public ActionResult Index()
        {
            return View(db.Administradores.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Administrador administrador)
        {
            Administrador administradorLogueo = db.Administradores.Where(a => a.Correo == administrador.Correo && a.Contraseña == administrador.Contraseña).FirstOrDefault();
            if (administradorLogueo == null)
            {
                ViewBag.ErrorMsg = "Correo o contraseña incorrectos";
            }
            else
            {
                if (administradorLogueo.Contraseña.Equals(administrador.Contraseña) && administradorLogueo.Correo.Equals(administrador.Correo))
                {
                    if (administradorLogueo.Estatus)
                    {
                        Session["AdministradorID"] = administradorLogueo.ID;
                        Session["SesionActiva"] = true;
                        Session["Nombre"] = administradorLogueo.Nombre;
                        Session["Correo"] = administradorLogueo.Correo;
                        return RedirectToAction("Index", "Privadas");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Usuario inactivo";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Correo o contraseña incorrectos";
                }
            }
            return View();
        }
        public ActionResult CerrarSesion()
        {
            Session["SesionActiva"] = false;
            return RedirectToAction("Login");
        }

        // GET: Administradors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // GET: Administradors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administradors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Correo,Contraseña,Estatus")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Administradores.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrador);
        }

        // GET: Administradors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administradors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Correo,Contraseña,Estatus")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        // GET: Administradors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador administrador = db.Administradores.Find(id);
            db.Administradores.Remove(administrador);
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
