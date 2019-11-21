using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BsoftWeb.Models
{
    
    public static class Estados
    {
        /*se definen los estado de las compras que seran dos
        EntregaPendiente=Falta entrega de algun equipamiento
        Etregada=Todos los equipamientos de la compra fueron entregados
         */
        public enum EstadoCompra
        {
            EntregaPendiente = 1,
            Entregada = 2
        }

        /*se define el estado del servicio
        terminado o no terminado*/
        public enum EstadoServicio
        {
            Terminado = 1,
            NoTerminado = 2
        }

        /* se definen estados posibles para proveedores, usuarios, perfiles usuarios, equipamientos, tecnicos*/
        public enum EstadoGeneral
        {
            Habilitado = 1,
            Deshabilitado = 2
        }
    }
}