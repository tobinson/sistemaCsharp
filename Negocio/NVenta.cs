using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using para acceder a datos
using Datos;
using System.Data;

namespace Negocio
{
    //se agrega public para acceder desde presentacion
    public class NVenta
    {
        //metodo insertar que llama a insertar de dcategoria en datos
        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv,DataTable dDetalles)
        {
            DVenta obj = new DVenta();
            obj.Idcliente = idcliente;
            obj.Idtrabajador = idtrabajador;
            obj.Fecha = fecha;
            obj.Tipo_comprobante = tipo_comprobante;
            obj.Serie = serie;
            obj.Correlativo = correlativo;
            obj.Igv = igv;            

            //=========================================================
            //recibo los detalles en una lista para enviarlo como lista a Insertar
            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                //iddetalle_ingreso autogenerado,idingreso se obtendra de la clase ingreso                               
                detalle.Iddetalle_ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio_venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["descuento"].ToString());                
                //agrego a la lista el objeto
                detalles.Add(detalle);
            }
            return obj.Insertar(obj, detalles);
        }
        //eliminar
        public static string Eliminar(int idventa)
        {
            DVenta obj = new DVenta();
            obj.Idventa = idventa;
            return obj.Eliminar(obj);
        }
        //buscar fecha
        public static DataTable BuscarFecha(string textobuscar, string textobuscar2)
        {
            DVenta obj = new DVenta();
            return obj.BuscarFechas(textobuscar, textobuscar2);
        }
        //mostrar detalle
        public static DataTable Mostrar_detalle(string textobuscar)
        {
            DVenta obj = new DVenta();
            return obj.mostrarDetalle(textobuscar);
        }
        //mostrar articulo de venta por nombre
        public static DataTable Mostrar_articulo_venta_nombre(string textobuscar)
        {
            DVenta obj = new DVenta();
            return obj.mostrarArticulo_Venta_Nombre(textobuscar);
        }
        //mostrar articulo de venta por codigo
        public static DataTable Mostrar_articulo_venta_codigo(string textobuscar)
        {
            DVenta obj = new DVenta();
            return obj.mostrarArticulo_Venta_Codigo(textobuscar);
        }
        //mostrar        
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }
    }
}
