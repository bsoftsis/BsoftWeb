﻿using System;
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
    public class TecnicoProveedorController : Controller
    {
        private BsoftEntities db = new BsoftEntities();

        // GET: TecnicoProveedor
        public ActionResult Index()
        {
            var tecnicoProveedor = db.TecnicoProveedor.Include(t => t.Proveedor);
            return View(tecnicoProveedor.ToList());
        }

        // GET: TecnicoProveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TecnicoProveedor tecnicoProveedor = db.TecnicoProveedor.Find(id);
            if (tecnicoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tecnicoProveedor);
        }

        // GET: TecnicoProveedor/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "razonSocial");
            return View();
        }

        // POST: TecnicoProveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTecnicoProveedor,nombre,apellido,cuil,especialidad,nivelEspecialidad,estado,fechaIngreso,fechaEgreso,fechaRegistro,idProveedor")] TecnicoProveedor tecnicoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.TecnicoProveedor.Add(tecnicoProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "razonSocial", tecnicoProveedor.idProveedor);
            return View(tecnicoProveedor);
        }

        // GET: TecnicoProveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TecnicoProveedor tecnicoProveedor = db.TecnicoProveedor.Find(id);
            if (tecnicoProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "razonSocial", tecnicoProveedor.idProveedor);
            return View(tecnicoProveedor);
        }

        // POST: TecnicoProveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTecnicoProveedor,nombre,apellido,cuil,especialidad,nivelEspecialidad,estado,fechaIngreso,fechaEgreso,fechaRegistro,idProveedor")] TecnicoProveedor tecnicoProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnicoProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "razonSocial", tecnicoProveedor.idProveedor);
            return View(tecnicoProveedor);
        }

        // GET: TecnicoProveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TecnicoProveedor tecnicoProveedor = db.TecnicoProveedor.Find(id);
            if (tecnicoProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tecnicoProveedor);
        }

        // POST: TecnicoProveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TecnicoProveedor tecnicoProveedor = db.TecnicoProveedor.Find(id);
            db.TecnicoProveedor.Remove(tecnicoProveedor);
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