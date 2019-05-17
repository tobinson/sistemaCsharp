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
    public class NIngreso
    {
        //metodo insertar que llama a insertar de dcategoria en datos
        public static string Insertar(int idtrabajador,int idproveedor, DateTime fecha,string tipo_comprobante,string serie,string correlativo, decimal igv,string estado,DataTable dDetalles)
        {
            DIngreso obj = new DIngreso();
            obj.Idtrabajador = idtrabajador;
            obj.Fecha= fecha;
            obj.Tipo_comprobante = tipo_comprobante;
            obj.Correlativo = correlativo;
            obj.Igv= igv;
            obj.Estado = estado;
            //recibo los detalles en una lista
            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fecha_produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                //agrego a la lista el objeto
                detalles.Add(detalle);
            }
            return obj.Insertar(obj,detalles);
        }
        //eliminar
        public static string Anular(int idingreso)
        {
            DIngreso obj = new DIngreso();
            obj.Idingreso = idingreso;
            return obj.Anular(obj);
        }
        //buscar fecha
        public static DataTable BuscarFecha(string textobuscar, string textobuscar2)
        {
            DIngreso obj = new DIngreso();            
            return obj.BuscarFechas(textobuscar,textobuscar2);
        }
        //mostrar detalle
        public static DataTable Mostrar_detalle(string textobuscar)
        {
            DIngreso obj = new DIngreso();
            return obj.mostrarDetalle(textobuscar);
        }
        //mostrar        
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }
    }
}
