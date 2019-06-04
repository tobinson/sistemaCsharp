using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//usings necesarios para trabajar con sql
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    //hacerlo public para acceder desde negocio
    public class DDetalle_Venta
    {
        private int _Iddetalle_venta;
        private int _Idventa;
        private int _Iddetalle_ingreso;
        private int _Cantidad;
        private decimal _Precio_venta;
        private decimal _Descuento;

        public int Iddetalle_venta { get => _Iddetalle_venta; set => _Iddetalle_venta = value; }
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Iddetalle_ingreso { get => _Iddetalle_ingreso; set => _Iddetalle_ingreso = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio_venta { get => _Precio_venta; set => _Precio_venta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }

        public DDetalle_Venta()
        {
        }

        public DDetalle_Venta(int iddetalle_venta, int idventa, int iddetalle_ingreso, int cantidad, decimal precio_venta, decimal descuento)
        {
            this.Iddetalle_venta = iddetalle_venta;
            this.Idventa = idventa;
            this.Iddetalle_ingreso = iddetalle_ingreso;
            this.Cantidad = cantidad;
            this.Precio_venta = precio_venta;
            this.Descuento = descuento;
        }
        //Metodo Insertar (recibe la coneccion de Dventa y la transaccion por referencia)
        public string Insertar(DDetalle_Venta Detalle_Venta, ref SqlConnection sqlcon, ref SqlTransaction sqltra)
        {
            //la coneccion ya la recibo con el parametro sqlcon sqltra un ingreso con una sola trnasaccion
            string rpta = "";

            try
            {
                //sqlcon.Open();
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                //===============agregado para la transaccion============
                sqlcmd.Transaction = sqltra;
                //=======================================================
                sqlcmd.CommandText = "spinsertar_detalle_venta";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIddetalle_venta = new SqlParameter();
                parIddetalle_venta.ParameterName = "@iddetalle_venta";
                parIddetalle_venta.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIddetalle_venta.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parIddetalle_venta);
                //idingreso
                SqlParameter parIdventa = new SqlParameter();
                parIdventa.ParameterName = "@idventa";
                parIdventa.SqlDbType = SqlDbType.Int;
                parIdventa.Value = Detalle_Venta.Idventa;
                //metodo get obtiene el metodo Nombre                
                sqlcmd.Parameters.Add(parIdventa);
                //idarticulo
                SqlParameter parIddetalle_ingreso = new SqlParameter();
                parIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                parIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                parIddetalle_ingreso.Value = Detalle_Venta.Iddetalle_ingreso;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parIddetalle_ingreso);
                //cantidad
                SqlParameter parCantidad = new SqlParameter();
                parCantidad.ParameterName = "@cantidad";
                parCantidad.SqlDbType = SqlDbType.Int;
                parCantidad.Value = Detalle_Venta.Cantidad;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parCantidad);
                //precio venta
                SqlParameter parPrecio_venta = new SqlParameter();
                parPrecio_venta.ParameterName = "@precio_venta";
                parPrecio_venta.SqlDbType = SqlDbType.Money;
                parPrecio_venta.Value = Detalle_Venta.Precio_venta;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parPrecio_venta);
                //descuento
                SqlParameter parDescuento = new SqlParameter();
                parDescuento.ParameterName = "@descuento";
                parDescuento.SqlDbType = SqlDbType.Money;
                parDescuento.Value = Detalle_Venta.Descuento;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parDescuento);
                
                //ejecutamos nuestro comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ingreso el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            //no se cierra para seguir insertando otros detalle de ingreso xq 1 ingreso tiene 1 o varios detalles
            return rpta;
        }
    }
}
