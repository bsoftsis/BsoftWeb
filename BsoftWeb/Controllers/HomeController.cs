using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BsoftWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Escribenos!!!!";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(String razon, String email, String mensaje)
        {

            /* con este codigo se puede enviar correo desde el formulario de la web
             hacia la casilla de bsoftsis*/
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(email);
                correo.To.Add("bsoftsis@gmail.com");
                correo.Subject = "Mensaje de " + razon;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string sCuentaCorreo = "bsoftsis@gmail.com";
                string sPassWordCorreo = "Admrec2019";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPassWordCorreo);
                smtp.Send(correo);

                ViewBag.Message = "Gracias por Escribirnos " + razon + "!!!!";

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error al Enviar mensaje: " + ex.Message;
            }


            return View();
        }

    }
}