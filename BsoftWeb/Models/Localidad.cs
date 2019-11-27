//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BsoftWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Localidad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Localidad()
        {
            this.Proveedor = new HashSet<Proveedor>();
        }

        [Display(Name = "Localidad")]
        public int idLocalidad { get; set; }
        [Required(ErrorMessage = "Nombre Localidad - Campo obligatorio")]
        [Display(Name = "Nombre Localidad")]
        [StringLength(70)]
        public string nombreLocalidad { get; set; }
        [Required(ErrorMessage = "Codigo Postal - Campo obligatorio")]
        [Display(Name = "Codigo Postal")]
        [StringLength(10)]
        public string codigoPostal { get; set; }
        [Display(Name = "Provincia")]
        public int idProvincia { get; set; }

        public virtual Provincia Provincia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedor> Proveedor { get; set; }
    }
}
