using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace BsoftWeb.Models
{
    /*Se definen los valores de calidad que se daran a los servicios prestados por los tecnicos
     y  a los equipamientos comprados*/
   
    
        public enum NivelCalidad
        {
            [DescriptionAttribute("Excelente")]
            Excelente = 5,
            [DescriptionAttribute("Muy Bueno")]
            MuyBueno = 4,
            [DescriptionAttribute("Bueno")]
            Bueno = 3,
            [DescriptionAttribute("Regular")]
            Regular = 2,
            [DescriptionAttribute("Malo")]
            Malo = 1
        }
    }
