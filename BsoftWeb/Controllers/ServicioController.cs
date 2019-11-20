using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BsoftWeb.Models;

namespace BsoftWeb.Controllers
{
    public class ServicioController : Controller
    {
        private BsoftEntities db = new BsoftEntities();

        // GET: Servicio
        public ActionResult Index()
        {
            var servicio = db.Servicio.Include(s => s.TecnicoProveedor).Include(s => s.Usuario);
            return View(servicio.ToList());
        }

        // GET: Servicio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicio/Create
        public ActionResult Create()
        {
            ViewBag.idTecnicoProveedor = new SelectList(db.TecnicoProveedor, "idTecnicoProveedor", "nombre");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Servicio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServicio,nroOrden,fechaInicio,plazo,fechaFin,descripcion,calidad,estado,fechaRegistro,idTecnicoProveedor,idUsuario")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Servicio.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTecnicoProveedor = new SelectList(db.TecnicoProveedor, "idTecnicoProveedor", "nombre", servicio.idTecnicoProveedor);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuario);
            return View(servicio);
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTecnicoProveedor = new SelectList(db.TecnicoProveedor, "idTecnicoProveedor", "nombre", servicio.idTecnicoProveedor);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuario);
            return View(servicio);
        }

        // POST: Servicio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServicio,nroOrden,fechaInicio,plazo,fechaFin,descripcion,calidad,estado,fechaRegistro,idTecnicoProveedor,idUsuario")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTecnicoProveedor = new SelectList(db.TecnicoProveedor, "idTecnicoProveedor", "nombre", servicio.idTecnicoProveedor);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuario);
            return View(servicio);
        }

        // GET: Servicio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicio servicio = db.Servicio.Find(id);
            db.Servicio.Remove(servicio);
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
