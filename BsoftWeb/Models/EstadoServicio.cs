using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BsoftWeb.Models
{
        /*se define el estado del servicio
        terminado o no terminado*/
        public enum EstadoServicio
        {
            [DescriptionAttribute("Servicio Terminado")]
            Terminado = 1,
            [DescriptionAttribute("Servicio No Terminado")]
            NoTerminado = 2
        }
}