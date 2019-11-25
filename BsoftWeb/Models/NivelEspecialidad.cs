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
   
    
        public enum NivelEspecialidad
        {
            [DescriptionAttribute("Senior")]
            Senior = 3,
            [DescriptionAttribute("Semi-Senior")]
            SemiSenior = 2,
            [DescriptionAttribute("Junior")]
            Junior= 1,
        }
    }
