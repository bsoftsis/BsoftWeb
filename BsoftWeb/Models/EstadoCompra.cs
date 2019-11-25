using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BsoftWeb.Models
{
    /*se definen los estado de las compras que seran dos
    EntregaPendiente=Falta entrega de algun equipamiento
    Etregada=Todos los equipamientos de la compra fueron entregados
     */
    public enum EstadoCompra
    {
        [DescriptionAttribute("Entrega Pendiente")]
        EntregaPendiente = 1,
        [DescriptionAttribute("Entregada")]
        Entregada = 2
    }
}