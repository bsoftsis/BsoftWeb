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
    public class PerfilUsuarioController : Controller
    {
        private BsoftEntities db = new BsoftEntities();

        // GET: PerfilUsuario
        public ActionResult Index()
        {
            return View(db.PerfilUsuario.ToList());
        }

        // GET: PerfilUsuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilUsuario perfilUsuario = db.PerfilUsuario.Find(id);
            if (perfilUsuario == null)
            {
                return HttpNotFound();
            }
            return View(perfilUsuario);
        }

        // GET: PerfilUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilUsuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPerfilUsuario,descripcion,estado,fechaRegistro")] PerfilUsuario perfilUsuario)
        {
            if (ModelState.IsValid)
            {
                db.PerfilUsuario.Add(perfilUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfilUsuario);
        }

        // GET: PerfilUsuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilUsuario perfilUsuario = db.PerfilUsuario.Find(id);
            if (perfilUsuario == null)
            {
                return HttpNotFound();
            }
            return View(perfilUsuario);
        }

        // POST: PerfilUsuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPerfilUsuario,descripcion,estado,fechaRegistro")] PerfilUsuario perfilUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfilUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfilUsuario);
        }

        // GET: PerfilUsuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilUsuario perfilUsuario = db.PerfilUsuario.Find(id);
            if (perfilUsuario == null)
            {
                return HttpNotFound();
            }
            return View(perfilUsuario);
        }

        // POST: PerfilUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerfilUsuario perfilUsuario = db.PerfilUsuario.Find(id);
            db.PerfilUsuario.Remove(perfilUsuario);
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