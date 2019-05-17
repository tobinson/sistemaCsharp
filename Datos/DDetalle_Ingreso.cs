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
    public class DDetalle_Ingreso
    {
        private int _Iddetalle_ingreso;
        private int _Idingreso;
        private int _Idarticulo;
        private decimal _Precio_compra;
        private decimal _Precio_venta;
        private int _Stock_inicial;
        private int _Stock_actual;
        private DateTime _Fecha_produccion;
        private DateTime _Fecha_vencimiento;

        public int Iddetalle_ingreso { get => _Iddetalle_ingreso; set => _Iddetalle_ingreso = value; }
        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public decimal Precio_compra { get => _Precio_compra; set => _Precio_compra = value; }
        public decimal Precio_venta { get => _Precio_venta; set => _Precio_venta = value; }
        public int Stock_inicial { get => _Stock_inicial; set => _Stock_inicial = value; }
        public int Stock_actual { get => _Stock_actual; set => _Stock_actual = value; }
        public DateTime Fecha_produccion { get => _Fecha_produccion; set => _Fecha_produccion = value; }
        public DateTime Fecha_vencimiento { get => _Fecha_vencimiento; set => _Fecha_vencimiento = value; }

        public DDetalle_Ingreso()
        {
        }

        public DDetalle_Ingreso(int iddetalle_ingreso, int idingreso, int idarticulo, decimal precio_compra, decimal precio_venta, int stock_inicial, int stock_actual, DateTime fecha_produccion, DateTime fecha_vencimiento)
        {
            this.Iddetalle_ingreso = iddetalle_ingreso;
            this.Idingreso = idingreso;
            this.Idarticulo = idarticulo;
            this.Precio_compra = precio_compra;
            this.Precio_venta = precio_venta;
            this.Stock_inicial = stock_inicial;
            this.Stock_actual = stock_actual;
            this.Fecha_produccion = fecha_produccion;
            this.Fecha_vencimiento = fecha_vencimiento;
        }
        //Metodo Insertar (recibe la coneccion de Dingreso y la transaccion por referencia)
        public string Insertar(DDetalle_Ingreso Detalle_Ingreso,ref SqlConnection sqlcon,ref SqlTransaction sqltra)
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
                sqlcmd.CommandText = "spinsertar_detalle_ingreso";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIddetalle_ingreso = new SqlParameter();
                parIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                parIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIddetalle_ingreso.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parIddetalle_ingreso);
                //idingreso
                SqlParameter parIdingreso = new SqlParameter();
                parIdingreso.ParameterName = "@idingreso";
                parIdingreso.SqlDbType = SqlDbType.Int;
                parIdingreso.Value = Detalle_Ingreso.Idingreso;
                //metodo get obtiene el metodo Nombre                
                sqlcmd.Parameters.Add(parIdingreso);
                //idarticulo
                SqlParameter parIdarticulo = new SqlParameter();
                parIdarticulo.ParameterName = "@idarticulo";
                parIdarticulo.SqlDbType = SqlDbType.Int;
                parIdarticulo.Value = Detalle_Ingreso.Idarticulo;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parIdarticulo);
                //precio compra
                SqlParameter parPrecio_compra = new SqlParameter();
                parPrecio_compra.ParameterName = "@precio_compra";
                parPrecio_compra.SqlDbType = SqlDbType.Money;
                parPrecio_compra.Value = Detalle_Ingreso.Precio_compra;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parPrecio_compra);
                //precio venta
                SqlParameter parPrecio_venta = new SqlParameter();
                parPrecio_venta.ParameterName = "@precio_venta";
                parPrecio_venta.SqlDbType = SqlDbType.Money;
                parPrecio_venta.Value = Detalle_Ingreso.Precio_venta;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parPrecio_venta);
                //stock inicial
                SqlParameter parStock_inicial = new SqlParameter();
                parStock_inicial.ParameterName = "@stock_inicial";
                parStock_inicial.SqlDbType = SqlDbType.Int;
                parStock_inicial.Value = Detalle_Ingreso.Stock_inicial;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parStock_inicial);
                //stock actual
                SqlParameter parStock_actual = new SqlParameter();
                parStock_actual.ParameterName = "@stock_actual";
                parStock_actual.SqlDbType = SqlDbType.Int;
                parStock_actual.Value = Detalle_Ingreso.Stock_actual;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parStock_actual);
                //fecha produccion
                SqlParameter parFecha_produccion = new SqlParameter();
                parFecha_produccion.ParameterName = "@fecha_produccion";
                parFecha_produccion.SqlDbType = SqlDbType.DateTime;
                parFecha_produccion.Value = Detalle_Ingreso.Fecha_produccion;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parFecha_produccion);
                //fecha vencimiento
                SqlParameter parFecha_vencimiento = new SqlParameter();
                parFecha_vencimiento.ParameterName = "@fecha_vencimiento";
                parFecha_vencimiento.SqlDbType = SqlDbType.DateTime;
                parFecha_vencimiento.Value = Detalle_Ingreso.Fecha_vencimiento;
                //metodo get obtiene el metodo Descrpcion                
                sqlcmd.Parameters.Add(parFecha_vencimiento);

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
