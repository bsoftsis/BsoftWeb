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
    public class EquipamientoController : Controller
    {
        private BsoftEntities db = new BsoftEntities();

        // GET: Equipamientoes
        public ActionResult Index()
        {
            return View(db.Equipamiento.ToList());
        }

        // GET: Equipamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamiento equipamiento = db.Equipamiento.Find(id);
            if (equipamiento == null)
            {
                return HttpNotFound();
            }
            return View(equipamiento);
        }

        // GET: Equipamientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipamientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEquipamiento,descripcion,stock,estado,fechaRegistro")] Equipamiento equipamiento)
        {
            if (ModelState.IsValid)
            {
                db.Equipamiento.Add(equipamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipamiento);
        }

        // GET: Equipamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamiento equipamiento = db.Equipamiento.Find(id);
            if (equipamiento == null)
            {
                return HttpNotFound();
            }
            return View(equipamiento);
        }

        // POST: Equipamientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEquipamiento,descripcion,stock,estado,fechaRegistro")] Equipamiento equipamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipamiento);
        }

        // GET: Equipamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipamiento equipamiento = db.Equipamiento.Find(id);
            if (equipamiento == null)
            {
                return HttpNotFound();
            }
            return View(equipamiento);
        }

        // POST: Equipamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipamiento equipamiento = db.Equipamiento.Find(id);
            db.Equipamiento.Remove(equipamiento);
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
