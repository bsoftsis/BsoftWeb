using BsoftWeb.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace BsoftWeb.Models
{

    public class UsuarioMetaData
    {
        [Display(Name = "Usuario")]
        public virtual int idUsuario { get; set; }

        [Required(ErrorMessage = "Nombre de Usuario - Campo obligatorio")]
        [StringLength(45)]
        [Display(Name = "Nombre de Usuario")]
        public virtual string nombreUsuario { get; set; }

        [Required(ErrorMessage = "Contraeña - Campo obligatorio")]
        [StringLength(100)]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public virtual string contraseña { get; set; }

        [Required(ErrorMessage = "E-mail - Campo obligatorio")]
        [StringLength(200)]
        [Display(Name = "E-mail")]
        public virtual string email { get; set; }

        [Required(ErrorMessage = "Estado - Campo obligatorio")]
        [StringLength(45)]
        [Display(Name = "Estado")]
        public virtual string estado { get; set; }

        [Required(ErrorMessage = "Campo obligatorio - Fecha de registro")]
        [Display(Name = "Fecha de Registro")]
        public virtual System.DateTime fechaRegistro { get; set; }

        [Display(Name = "Perfil Usuario")]
        public virtual int idPerfilUsuario { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Compra> Compra { get; set; }
        //public virtual PerfilUsuario PerfilUsuario { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Servicio> Servicio { get; set; }
    }

    public class TecnicoProveedorMetaData
    {
        [Display(Name = "Tecnico")]
        public virtual int idTecnicoProveedor { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(200)]
        [Display(Name = "Nombre")]
        public virtual string nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(200)]
        [Display(Name = "Apellido")]
        public virtual string apellido { get; set; }

        [CustomValidationCUIT(ErrorMessage = "El nro de CUIL no es valido")]
        [Required(ErrorMessage = "Nro de CUIL - Campo obligatorio - Ingresar sin guiones")]
        [StringLength(11)]
        [Display(Name = "Nro de CUIL")]
        [DisplayFormat(DataFormatString = "{0:00-00000000-0}")]
        public virtual string cuil { get; set; }

        [Required(ErrorMessage = "Especialidad - Campo obligatorio")]
        [StringLength(150)]
        [Display(Name = "Especialidad")]
        public virtual string especialidad { get; set; }

        [Required(ErrorMessage = "Nivel Especialidad - Campo obligatorio")]
        [Display(Name = "Nivel de Especialidad")]
        public virtual int nivelEspecialidad { get; set; }

        [Required(ErrorMessage = "Fecha Ingreso - Campo obligatorio")]
        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.DateTime)]
        public virtual System.DateTime fechaIngreso { get; set; }

        [Required(ErrorMessage = "Estado - Campo obligatorio")]
        [StringLength(45)]
        [Display(Name = "Estado")]
        public virtual string estado { get; set; }

        [Display(Name = "Fecha de Egreso")]
        [DataType(DataType.DateTime)]
        public virtual Nullable<System.DateTime> fechaEgreso { get; set; }

        [Required(ErrorMessage = "Campo obligatorio - Fecha de registro")]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public virtual System.DateTime fechaRegistro { get; set; }

        [Display(Name = "Proveedor")]
        public virtual int idProveedor { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Compra> Compra { get; set; }

        //public virtual Localidad Localidad { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TecnicoProveedor> TecnicoProveedor { get; set; }
    }

    public class ServicioMetaData
    {
        [Display(Name = "Servicio")]
        public virtual int idServicio { get; set; }

        [Required(ErrorMessage = "Nro de orden de servicio - Campo obligatorio")]
        [Display(Name = "Nro orden de servicio")]
        [StringLength(14)]
        public virtual string nroOrden { get; set; }

        [Required(ErrorMessage = "Fecha inicio - Campo obligatorio ")]
        [Display(Name = "Fecha inicio")]
        [DataType(DataType.DateTime)]
        public virtual System.DateTime fechaInicio { get; set; }

        [Required(ErrorMessage = "Plazo - Campo obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar un nro entero mayor a 0")]
        [RegularExpression("^\\d+$", ErrorMessage = "El plazo debe contener sólo números enteros.")]
        [Display(Name = "Plazo")]
        public virtual int plazo { get; set; }

        [Required(ErrorMessage = "Fecha fin  - Campo obligatorio")]
        [Display(Name = "Fecha fin")]
        [DataType(DataType.DateTime)]
        public virtual System.DateTime fechaFin { get; set; }

        [Required(ErrorMessage = "Descripcion - Campo obligatorio ")]
        [Display(Name = "Descripcion ")]
        [StringLength(200)]
        public virtual System.String descripcion { get; set; }

        [Required(ErrorMessage = "Calidad servicio - Campo obligatorio")]
        [Display(Name = "Calidad servicios")]
        public virtual int calidad { get; set; }

        [Required(ErrorMessage = "Estado - Campo obligatorio")]
        [Display(Name = "Estado")]
        [StringLength(45)]
        public virtual string estado { get; set; }

        [Required(ErrorMessage = "Fecha de Resgistro - Campo obligatorio")]
        [Display(Name = "Fecha de registro")]
        [DataType(DataType.DateTime)]
        public virtual System.DateTime fechaRegistro { get; set; }

        [Display(Name = "Proveedor")]
        public virtual int idTecnicoProveedor { get; set; }

        [Display(Name = "Usuario")]
        public virtual int idUsuario { get; set; }
    }
    


    public class ProvinciaMetaData
    {
        [Display(Name = "Provincia")]
        public virtual int idProvincia { get; set; }

        [Required(ErrorMessage = "Nombre Provincia - Campo obligatorio")]
        [Display(Name = "Nombre Provincia")]
        [StringLength(45)]
        public virtual string nombreProvincia { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Localidad> Localidad { get; set; }
    }

    public class ProveedorMetaData
    {

        [Display(Name = "Proveedor")]
        public virtual int idProveedor { get; set; }

        [Required(ErrorMessage = "Razon social - Campo obligatorio")]
        [StringLength(200)]
        [Display(Name = "Razon social")]
        public virtual string razonSocial { get; set; }

        [CustomValidationCUIT(ErrorMessage = "El nro de CUIT no es valido")]
        [Required(ErrorMessage = "Nro CUIT - Campo obligatorio - Ingresar sin guiones")]
        [StringLength(11)]
        [Display(Name = "Nro de CUIT")]
        [DisplayFormat(DataFormatString = "{0:00-00000000-0}")]
        public virtual string cuit { get; set; }

        [Required(ErrorMessage = "Domicilio - Campo obligatorio")]
        [StringLength(200)]
        [Display(Name = "Domicilio")]
        public virtual string domicilio { get; set; }

        [Required(ErrorMessage = "Telefono - Campo obligatorio")]
        [StringLength(45)]
        [Display(Name = "Nro Telefono")]
        [DisplayFormat(DataFormatString = "{0:(0###)4###-###}")]
        public virtual string telefono { get; set; }

        [Required(ErrorMessage = "Celular - Campo obligatorio")]
        [StringLength(45)]
        [Display(Name = "Nro Celular")]
        [DisplayFormat(DataFormatString = "{0:(0###)15###-####}")]
        public virtual string celular { get; set; }

        [Required(ErrorMessage = "Email - Campo obligatorio")]
        [StringLength(200)]
        [Display(Name = "E-mail")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$",
            ErrorMessage = "Formato de correo incorrecto")]
        public virtual string email { get; set; }

        [Required(ErrorMessage = "Estado - Campo obligatorio")]
        [StringLength(45)]
        [Display(Name = "Estado")]
        public virtual string estado { get; set; }

        [Required(ErrorMessage = "Campo obligatorio - Fecha de registro")]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public virtual System.DateTime fechaRegistro { get; set; }

        [Display(Name = "Localidad")]
        public virtual int idLocalidad { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Compra> Compra { get; set; }
        //public virtual Localidad Localidad { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TecnicoProveedor> TecnicoProveedor { get; set; }
    }


    public class PerfilUsuarioMetaData
    {
        [Display(Name = "Perfil Usuario")]
        public virtual int idPerfilUsuario { get; set; }

        [Required(ErrorMessage = "Descripcion - Campo obligatorio ")]
        [StringLength(45)]
        [Display(Name = "Descripcion")]
        public virtual string descripcion { get; set; }

        [Required(ErrorMessage = "Estado - Campo obligatorio")]
        [Display(Name = "Estado")]
        public virtual string estado { get; set; }

        [Required(ErrorMessage = "Fecha de registro - Campo obligatorio")]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual System.DateTime fechaRegistro { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Usuario> Usuario { get; set; }
    }

    public class LocalidadMetaData
    {
        [Display(Name = "Localidad")]
        public virtual int idLocalidad { get; set; }

        [Required(ErrorMessage = "Nombre Localidad - Campo obligatorio")]
        [Display(Name = "Nombre Localidad")]
        [StringLength(70)]
        public virtual string nombreLocalidad { get; set; }

        [Required(ErrorMessage = "Codigo Postal - Campo obligatorio")]
        [Display(Name = "Codigo Postal")]
        [StringLength(10)]
        public virtual string codigoPostal { get; set; }

        [Display(Name = "Provincia")]
        public virtual int idProvincia { get; set; }

        //public virtual Provincia Provincia { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Proveedor> Proveedor { get; set; }
    }

    public class EquipamientoMetaData
    {
        [Display(Name = "Equipamiento")]
        public virtual int idEquipamiento { get; set; }

        [Required(ErrorMessage = "Descripcion - Campo obligatorio")]
        [StringLength(150)]
        public virtual string descripcion { get; set; }

        [Required(ErrorMessage = "Stock - Campo obligatorio")]
        [Display(Name = "Stock")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar un nro entero mayor a 0")]
        [RegularExpression("^\\d+$", ErrorMessage = "El stock debe contener sólo números.")]
        public virtual int stock { get; set; }

        [Required(ErrorMessage = "Estado - Campo obligatorio")]
        [StringLength(45)]
        [Display(Name = "Estado")]
        public virtual string estado { get; set; }

        [Required(ErrorMessage = "Fecha de Registro - Campo obligatorio")]
        [StringLength(45)]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public virtual System.DateTime fechaRegistro { get; set; }

        [Required(ErrorMessage = "Precio Compra- Campo obligatorio")]
        [Display(Name = "Precio Compra")]
        [DataType(DataType.Currency)]
        public virtual double precioCpraActual { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
    }

    public class CompraMetaData
    {
        [Display(Name = "Compra")]
        public virtual int idCompra { get; set; }

        [Required(ErrorMessage = "Fecha de Compra - Campo obligatorio")]
        [Display(Name = "Fecha de Campra")]
        [DataType(DataType.DateTime)]
        public virtual System.DateTime fechaCompra { get; set; }

        [Required(ErrorMessage = "Nro de Comprobante - Campo obligatorio")]
        [StringLength(15)]
        [Display(Name = "Nro de Comprobante")]
        public virtual string nroComprobante { get; set; }

        [Required(ErrorMessage = "Estado - Campo obligatorio")]
        [StringLength(45)]
        [Display(Name = "Estado")]
        public virtual string estado { get; set; }

        [Required(ErrorMessage = "Campo obligatorio - Fecha de registro")]
        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public virtual System.DateTime fechaRegistro { get; set; }

        [Display(Name = "Proveedor")]
        public virtual int idProveedor { get; set; }

        [Display(Name = "Usuario")]
        public virtual int idUsuario { get; set; }


        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
    }

    public class DetalleCompraMetaData
    {
        [Display(Name = "Detalle Compra")]
        public virtual int idDetalleCompra { get; set; }

        [Display(Name = "Compra")]
        public virtual int idCompra { get; set; }

        [Display(Name = "Equipamiento")]
        public virtual int idEquipamiento { get; set; }

        [Required(ErrorMessage = "Cantidad - Campo obligatorio")]
        [Display(Name = "Cantidad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar un nro valor mayor a 0")]
        [RegularExpression("^\\d+$", ErrorMessage = "La cantidad debe contener sólo números.")]
        public virtual int cantidad { get; set; }

        [Required(ErrorMessage = "Precio compra - Campo obligatorio")]
        [Display(Name = "Precio compra")]
        [Range(1, float.MaxValue, ErrorMessage = "Debe ingresar un valor mayor a 0")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "El precio debe contener sólo números decimales.")]
        public virtual float precioCpra { get; set; }

        [Required(ErrorMessage = "Plazo de entrega - Campo obligatorio")]
        [Display(Name = "Plazo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe ingresar un nro valor mayor a 0")]
        [RegularExpression("^\\d+$", ErrorMessage = "El palzo de dias debe contener sólo números.")]
        public virtual int plazoEntrega { get; set; }

        [Required(ErrorMessage = "Fecha Registro- Campo obligatorio")]
        [Display(Name = "Fecha registro")]
        [DataType(DataType.DateTime)]
        public virtual System.DateTime fechaEntrega { get; set; }

        [Required(ErrorMessage = "Calidad servicio - Campo obligatorio")]
        [Display(Name = "Calidad servicios")]
        public virtual int calidad { get; set; }


        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        public virtual string observaciones{ get; set; }

        //public virtual Compra Compra { get; set; }
        //public virtual Equipamiento Equipamiento { get; set; }
    }
}
