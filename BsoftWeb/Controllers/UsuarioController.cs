using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BsoftWeb.Models;
using BsoftWeb.Servicios;

namespace BsoftWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private BsoftDBEntities db = new BsoftDBEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.PerfilUsuario);
            return View(usuario.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            //para el combo de niveles de estados
            ViewBag.ListaEstado = HTMLSelect.ToListSelectListItem<EstadoGeneral>();

            //para el combo de perfiles de usuario
            ViewBag.idPerfilUsuario = new SelectList(db.PerfilUsuario, "idPerfilUsuario", "descripcion");
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,nombreUsuario,contraseña,email,estado,idPerfilUsuario,fechaRegistro")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPerfilUsuario = new SelectList(db.PerfilUsuario, "idPerfilUsuario", "descripcion", usuario.idPerfilUsuario);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            EncriptadorAES128 desEnc = new EncriptadorAES128();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            //para el combo de niveles de estados
            ViewBag.ListaEstado = HTMLSelect.ToListSelectListItem<EstadoGeneral>();

            usuario.contraseña = desEnc.Desencriptar(usuario.contraseña);

            ViewBag.idPerfilUsuario = new SelectList(db.PerfilUsuario, "idPerfilUsuario", "descripcion", usuario.idPerfilUsuario);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,nombreUsuario,contraseña,email,estado,idPerfilUsuario,fechaRegistro")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                EncriptadorAES128 enc = new EncriptadorAES128();
                usuario.contraseña = enc.Encriptar(usuario.contraseña);
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPerfilUsuario = new SelectList(db.PerfilUsuario, "idPerfilUsuario", "descripcion", usuario.idPerfilUsuario);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
