using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BsoftWeb.Models
{
    [MetadataType(typeof(CompraMetaData))]
    public partial class Compra
    {
        ///calcula el total de la compra
        public double Total()
        {
            double total = 0;
            foreach (var dc in this.DetalleCompra)
                total = total + dc.SubTotal;
            return total;
        }

        public int CalidadCompra()
        {
            int calidad = 0;
            if (DetalleCompra.Count > 0)
            {
                foreach (var dc in DetalleCompra)
                    calidad = calidad + dc.calidad;
                // promedio de calidades
                calidad = calidad / DetalleCompra.Count;
                if (calidad > 5) calidad = 5;//excelente
            }
            return calidad;
        }
    }

    [MetadataType(typeof(DetalleCompraMetaData))]
    public partial class DetalleCompra
    {
        public double SubTotal { get { return cantidad * precioCpra; } }
    }


    [MetadataType(typeof(ProveedorMetaData))]
    public partial class Proveedor
    {
        public int CalidadCompras()
        {
            int calidad = 0;
            if (Compra.Count > 0)
            {
                foreach (var c in Compra)
                    calidad = calidad + c.CalidadCompra();
                calidad = calidad / Compra.Count;
                if (calidad > 5) calidad = 5;
            }
            return calidad;
        }

        public int CalidadServicios()
        {
            /*
             Sumatoria de todas las calidades de todos los servicios de
             todos los tecnicos de proveedor
             Luego se saca promedio entre todos los servicios
             */

            int calidad = 0;
            int cantServicios = 0;

            if (TecnicoProveedor.Count > 0)
            {
                foreach (var t in TecnicoProveedor)
                {
                    calidad = calidad + t.CalidadServicio();
                    cantServicios = cantServicios = t.Servicio.Count;
                }

                if (cantServicios > 0)
                    calidad = calidad / cantServicios;
                if (calidad > 5) calidad = 5;
            }
            return calidad;
        }
    }

    [MetadataType(typeof(TecnicoProveedorMetaData))]
    public partial class TecnicoProveedor
    {
        public int CalidadServicio()
        {
            /*
             Calcula el promedio de calidad de los servicios del un tecnico
             */
            int calidad = 0;
            if (Servicio.Count > 0)
            {
                foreach (var s in Servicio)
                    calidad = calidad + s.calidad;
                calidad = calidad / Servicio.Count;
            }
            return calidad;
        }     
    }

    [MetadataType(typeof(ServicioMetaData))]
    public partial class Servicio
    {
    }

    [MetadataType(typeof(EquipamientoMetaData))]
    public partial class Equipamiento
    {

    }

    [MetadataType(typeof(LocalidadMetaData))]
    public partial class Localidad
    {
    }

    [MetadataType(typeof(UsuarioMetaData))]
    public partial class Usuario
    {
    }

    [MetadataType(typeof(PerfilUsuarioMetaData))]
    public partial class PerfilUsuario
    {
    }

    [MetadataType(typeof(ProvinciaMetaData))]
    public partial class Provincia
    {
    }
}
