using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsoftWeb.Models
{
    /*Se definen los valores de calidad que se daran a los servicios prestados por los tecnicos
     y  a los equipamientos comprados*/
    public enum ValorCalidad
    {
        ExcelenteCalidad = 5,
        MuyBuenaCalidad  = 4,
        BuenaCalidad     = 3,
        RegularCalidad   = 2,
        MalaCalidad      = 1
    }
}