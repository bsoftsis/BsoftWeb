//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BsoftWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servicio
    {
        public int idServicio { get; set; }
        public string nroOrden { get; set; }
        public System.DateTime fechaInicio { get; set; }
        public int plazo { get; set; }
        public System.DateTime fechaFin { get; set; }
        public System.DateTime descripcion { get; set; }
        public int calidad { get; set; }
        public string estado { get; set; }
        public System.DateTime fechaRegistro { get; set; }
        public int idTecnicoProveedor { get; set; }
        public int idUsuario { get; set; }
    
        public virtual TecnicoProveedor TecnicoProveedor { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
