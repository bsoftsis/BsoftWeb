using System;
using System.Collections.Generic;
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
       EntregaPendiente=1,
       Entregada=2
    }
}