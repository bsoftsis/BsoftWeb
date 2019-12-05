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
    public class ServicioController : Controller
    {
        private BsoftDBModel db = new BsoftDBModel();

        // GET: Servicio
        public ActionResult Index()
        {
            var servicio = db.Servicio.Include(s => s.TecnicoProveedor).Include(s => s.Usuario);
            return View(servicio.ToList());
        }

        // GET: Servicios/Details/5
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

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.idTecnicoProveedor = (from tp in db.TecnicoProveedor
                                   select new SelectListItem { Value = tp.idTecnicoProveedor.ToString(), Text = tp.apellido+", "+tp.nombre });
            //para el combo de niveles de estados
            ViewBag.ListaEstado = HTMLSelect.ToListSelectListItem<EstadoServicio>();
            //niveles de calidad
            ViewBag.ListaCalidad = HTMLSelect.ToListSelectListItem<NivelCalidad>();
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServicio,nroOrden,fechaInicio,plazo,fechaFin,descripcion,calidad,estado,fechaRegistro,idTecnicoProveedor,idUsuario")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                //pasa el estado de numero a cadena de caracteres
                servicio.estado = Enum.GetName(typeof(EstadoServicio), Convert.ToInt32(servicio.estado));
                servicio.fechaRegistro = DateTime.Now;
                servicio.idUsuario = Int32.Parse(Session["idUsuario"].ToString());//usuario activo

                db.Servicio.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Servicios/Edit/5
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
            
            //para el combo de niveles de estados
            ViewBag.ListaEstado = HTMLSelect.ToListSelectListItem<EstadoServicio>();
            //niveles de calidad
            ViewBag.ListaCalidad = HTMLSelect.ToListSelectListItem<NivelCalidad>();


            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServicio,nroOrden,fechaInicio,plazo,fechaFin,descripcion,calidad,estado,fechaRegistro,idTecnicoProveedor,idUsuario")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                //pasa el estado de numero a cadena de caracteres
                servicio.estado = Enum.GetName(typeof(EstadoServicio), Convert.ToInt32(servicio.estado));

                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTecnicoProveedor = new SelectList(db.TecnicoProveedor, "idTecnicoProveedor", "nombre", servicio.idTecnicoProveedor);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuario);
            return View(servicio);
        }

        // GET: Servicios/Delete/5
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

        // POST: Servicios/Delete/5
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
