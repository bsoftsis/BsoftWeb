using BsoftWeb.Models;
using System;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web.Configuration;
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
        public ActionResult Contact(String email, String razon, string mensaje)
        {
            /* con este codigo se puede enviar correo desde el formulario de la web
             hacia la casilla de bsoftsis*/
            try
            {
                MailMessage correo = new MailMessage();
                var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                correo.To.Add(new MailAddress(smtpSection.Network.UserName));
                correo.From = new MailAddress(email);
                correo.Sender = new MailAddress(email);
                correo.Subject = "Mensaje de " + razon + " - " + email;

                correo.Body = string.Format("<p>Email de: {0} ({1})</p><p>Mensaje:</p><p>{2}</p>", razon, email, mensaje);

                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpSection.Network.Host;

                /*uso web config para la configuracion del servidor smtp, en este acaso gmail*/
                smtp.Port = smtpSection.Network.Port;
                smtp.EnableSsl = smtpSection.Network.EnableSsl;
                smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                string sCuentaCorreo = smtpSection.Network.UserName;
                string sPassWordCorreo = smtpSection.Network.Password;

                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPassWordCorreo);
                smtp.Send(correo);

                ViewBag.Message = "Gracias por Escribirnos " + razon + "!!!!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error al Enviar mensaje. No pudo ser entregado ";
            }
            return View();
        }
    }
}