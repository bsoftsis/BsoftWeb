using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BsoftWeb.Models;

namespace BsoftWeb.Controllers
{
    public class DetalleCompraController : Controller
    {
        private BsoftDBModel db = new BsoftDBModel();

        // GET: DetalleCompra
        public ActionResult Index()
        {
            var detalleCompra = db.DetalleCompra.Include(d => d.Compra).Include(d => d.Equipamiento);
            return View(detalleCompra.ToList());
        }

        // GET: DetalleCompra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompra.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // GET: DetalleCompra/Create
        public ActionResult Create()
        {
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "nroComprobante");
            ViewBag.idEquipamiento = new SelectList(db.Equipamiento, "idEquipamiento", "descripcion");
            return View();
        }

        // POST: DetalleCompra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalleCompra,idCompra,idEquipamiento,cantidad,precioCpra,plazoEntrega,fechaEntrega,calidad,observaciones")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.DetalleCompra.Add(detalleCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "nroComprobante", detalleCompra.idCompra);
            ViewBag.idEquipamiento = new SelectList(db.Equipamiento, "idEquipamiento", "descripcion", detalleCompra.idEquipamiento);
            return View(detalleCompra);
        }

        // GET: DetalleCompra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompra.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "nroComprobante", detalleCompra.idCompra);
            ViewBag.idEquipamiento = new SelectList(db.Equipamiento, "idEquipamiento", "descripcion", detalleCompra.idEquipamiento);
            return View(detalleCompra);
        }

        // POST: DetalleCompra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalleCompra,idCompra,idEquipamiento,cantidad,precioCpra,plazoEntrega,fechaEntrega,calidad,observaciones")] DetalleCompra detalleCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleCompra).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCompra = new SelectList(db.Compra, "idCompra", "nroComprobante", detalleCompra.idCompra);
            ViewBag.idEquipamiento = new SelectList(db.Equipamiento, "idEquipamiento", "descripcion", detalleCompra.idEquipamiento);
            return View(detalleCompra);
        }

        // GET: DetalleCompra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleCompra detalleCompra = db.DetalleCompra.Find(id);
            if (detalleCompra == null)
            {
                return HttpNotFound();
            }
            return View(detalleCompra);
        }

        // POST: DetalleCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleCompra detalleCompra = db.DetalleCompra.Find(id);
            db.DetalleCompra.Remove(detalleCompra);
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
