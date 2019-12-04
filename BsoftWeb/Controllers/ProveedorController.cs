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
    public class ProveedorController : Controller
    {
        private BsoftDBModel db = new BsoftDBModel();

        // GET: Proveedor
        public ActionResult Evaluacion(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();


            }

            ViewBag.CalidadCompras = proveedor.CalidadCompras();
            ViewBag.CalidadServicios = proveedor.CalidadServicios();


            return View(proveedor);

           
        }

        // GET: Proveedor
        public ActionResult Index()
        {
            var proveedor = db.Proveedor.Include(p => p.Localidad);
            return View(proveedor.ToList());
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.idLocalidad= (from m in db.Localidad
                       select new SelectListItem {  Value = m.idLocalidad.ToString(), Text = m.nombreLocalidad });

            ViewBag.idProvincia = (from m in db.Provincia
                        select new SelectListItem { Value = m.idProvincia.ToString(), Text = m.nombreProvincia });
           

            //para el combo de niveles de estados
            ViewBag.ListaEstado = HTMLSelect.ToListSelectListItem<EstadoGeneral>();

            //Proveedor proveedor = new Proveedor();

            return View();
        }

        // POST: Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedor,razonSocial,cuit,domicilio,telefono,celular,email,estado,fechaRegistro,idLocalidad")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                //pasa el estado de numero a cadena de caracteres
                proveedor.estado = Enum.GetName(typeof(EstadoGeneral), Convert.ToInt32(proveedor.estado));
                db.Proveedor.Add(proveedor);
                //db.Localidad.Attach(proveedor.Localidad);
                //db.Provincia.Attach(proveedor.Localidad.Provincia);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    Console.Write(e);
                }
                return RedirectToAction("Index");
            }

            ViewBag.idLocalidad = new SelectList(db.Localidad, "idLocalidad", "nombreLocalidad", proveedor.idLocalidad);
            return View(proveedor);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLocalidad = new SelectList(db.Localidad, "idLocalidad", "nombreLocalidad", proveedor.idLocalidad);
            return View(proveedor);
        }

        // POST: Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedor,razonSocial,cuit,domicilio,telefono,celular,email,estado,fechaRegistro,idLocalidad")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLocalidad = new SelectList(db.Localidad, "idLocalidad", "nombreLocalidad", proveedor.idLocalidad);
            return View(proveedor);
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = db.Proveedor.Find(id);
            db.Proveedor.Remove(proveedor);
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
