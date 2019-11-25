using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BsoftWeb.Models
{
    /* se definen estados posibles para proveedores, usuarios, perfiles usuarios, equipamientos, tecnicos*/
    public enum EstadoGeneral
    {
        [DescriptionAttribute("Habilitado")]
        Habilitado = 1,
        [DescriptionAttribute("Deshabilitado")]
        Deshabilitado = 2
    }
}
