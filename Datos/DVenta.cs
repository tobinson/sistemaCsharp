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
    public class DVenta
    {
        private int _Idventa;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _Tipo_comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;

        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_comprobante { get => _Tipo_comprobante; set => _Tipo_comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }

        public DVenta()
        {
        }

        public DVenta(int idventa, int idcliente, int idtrabajador, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv)
        {
            this.Idventa = idventa;
            this.Idcliente = idcliente;
            this.Idtrabajador = idtrabajador;
            this.Fecha = fecha;
            this.Tipo_comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
        }
        //disminuir
        public string Disminuir_Stock(int iddetalle_ingreso,int cantidad)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establecer la cadena de conexion y abrirla
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spdisminuir_stock";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIddetalle_ingreso = new SqlParameter();
                parIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                parIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIddetalle_ingreso.Value = iddetalle_ingreso;
                sqlcmd.Parameters.Add(parIddetalle_ingreso);
                //cantidad
                SqlParameter parCantidad = new SqlParameter();
                parCantidad.ParameterName = "@cantidad";
                parCantidad.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parCantidad.Value = cantidad;
                sqlcmd.Parameters.Add(parCantidad);

                //ejecutamos nuestro comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "No se actualizo el stock";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }
            return rpta;
        }
        //Metodo Insertar (ingreso y todos sus detalles a modo lista)
        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalle)//recibe 1 obj y una lista desde ningreso
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establecer la cadena de conexion y abrirla
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();
                //=============INICIO DE TRANSACCION==============
                //cada detalle ingreso se realacione con un solo ingreso
                SqlTransaction sqltra = sqlcon.BeginTransaction();
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                //le decimos al comando que trabaje con esta transaccion
                sqlcmd.Transaction = sqltra;
                //================================================  
                sqlcmd.CommandText = "spinsertar_venta";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdventa = new SqlParameter();
                parIdventa.ParameterName = "@idventa";
                parIdventa.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdventa.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parIdventa);
                //idcliente
                SqlParameter parIdcliente = new SqlParameter();
                parIdcliente.ParameterName = "@idcliente";
                parIdcliente.SqlDbType = SqlDbType.Int;
                //metodo get obtiene el metodo Nombre
                parIdcliente.Value = Venta.Idcliente;
                sqlcmd.Parameters.Add(parIdcliente);
                //idtrabajador
                SqlParameter parIdtrabajador = new SqlParameter();
                parIdtrabajador.ParameterName = "@idtrabajador";
                parIdtrabajador.SqlDbType = SqlDbType.Int;
                //metodo get obtiene el metodo Nombre
                parIdtrabajador.Value = Venta.Idtrabajador;
                sqlcmd.Parameters.Add(parIdtrabajador);                
                //fecha
                SqlParameter parFecha = new SqlParameter();
                parFecha.ParameterName = "@fecha";
                parFecha.SqlDbType = SqlDbType.DateTime;
                //metodo get obtiene el metodo Descrpcion
                parFecha.Value = Venta.Fecha;
                sqlcmd.Parameters.Add(parFecha);
                //tipo comprobante
                SqlParameter parTipo_comprobante = new SqlParameter();
                parTipo_comprobante.ParameterName = "@tipo_comprobante";
                parTipo_comprobante.SqlDbType = SqlDbType.VarChar;
                parTipo_comprobante.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parTipo_comprobante.Value = Venta.Tipo_comprobante;
                sqlcmd.Parameters.Add(parTipo_comprobante);
                //serie
                SqlParameter parSerie = new SqlParameter();
                parSerie.ParameterName = "@serie";
                parSerie.SqlDbType = SqlDbType.VarChar;
                parSerie.Size = 4;
                //metodo get obtiene el metodo Descrpcion
                parSerie.Value = Venta.Serie;
                sqlcmd.Parameters.Add(parSerie);
                //correlativo
                SqlParameter parCorrelativo = new SqlParameter();
                parCorrelativo.ParameterName = "@correlativo";
                parCorrelativo.SqlDbType = SqlDbType.VarChar;
                parCorrelativo.Size = 7;
                //metodo get obtiene el metodo Descrpcion
                parCorrelativo.Value = Venta.Correlativo;
                sqlcmd.Parameters.Add(parCorrelativo);
                //igv
                SqlParameter parIgv = new SqlParameter();
                parIgv.ParameterName = "@igv";
                parIgv.SqlDbType = SqlDbType.Decimal;//tiene presicion y scala
                parIgv.Precision = 4;
                parIgv.Scale = 2;
                //metodo get obtiene el metodo Descrpcion
                parIgv.Value = Venta.Igv;
                sqlcmd.Parameters.Add(parIgv);                

                //ejecutamos nuestro comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ingreso el registro";
                //si es ok Dingreso inserto los detalles_ingreso
                if (rpta.Equals("Ok"))
                {
                    //obtenemos el idingreso de la tabla ingreso para detalle_ingreso
                    this.Idventa = Convert.ToInt32(sqlcmd.Parameters["@idventa"].Value);//value por ser de salida
                    //recorre la lista Detalle en la var det del mismo tipo q la lista
                    foreach (DDetalle_Venta det in Detalle)
                    {
                        det.Idventa = this.Idventa; //envio el idingreso obtenido a detalle_ingreso
                        //insertar de la clase detalle_ingreso
                        rpta = det.Insertar(det, ref sqlcon, ref sqltra);
                        if (!rpta.Equals("Ok")) //si no se pudo insertar
                        {
                            break;// salgo del bucle
                        }
                        else
                        {//si se inserta los detalles de venta actualizamos el stock
                            rpta = Disminuir_Stock(det.Iddetalle_ingreso, det.Cantidad);
                            if (!rpta.Equals("Ok"))
                            {
                                break;
                            }
                        }
                    }
                }
                //si se pudo insertar
                if (rpta.Equals("Ok"))
                {
                    sqltra.Commit();//confirmo la transaccion
                }
                else
                {
                    sqltra.Rollback();//se niega la transaccion
                }

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }
            return rpta;
        }
        //eliminar
        public string Eliminar(DVenta Venta)
        {
            string rpta = "";
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establecer la cadena de conexion y abrirla
                sqlcon.ConnectionString = Conexion.cn;
                sqlcon.Open();
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "speliminar_venta";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdVenta = new SqlParameter();
                parIdVenta.ParameterName = "@idventa";
                parIdVenta.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdVenta.Value = Venta.Idventa;
                sqlcmd.Parameters.Add(parIdVenta);

                //ejecutamos nuestro comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "Ok";//es psosible q no se envie el ok pero si se elimine la venta y ejecute el trigger 
            }                                                      //por trabajar con transacciones
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            }
            return rpta;
        }
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("venta");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                // sqlcon.Open();
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;//indico al comando q cadena de conex va a usar
                sqlcmd.CommandText = "spmostrar_venta";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //ejecuto el comando y lleno el datatable
                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                //rellena el adaptador con mi datatable
                sqldat.Fill(dtresultado);
            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            //finally
            //{
            //    if (sqlcon.State == ConnectionState.Open) sqlcon.Close();
            //}
            return dtresultado;
        }
        //Metodo Buscar fechas
        public DataTable BuscarFechas(string textoBuscar, string textoBuscar2)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("venta");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_venta_fecha";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = textoBuscar;
                sqlcmd.Parameters.Add(parTextoBuscar);
                //parametro buscar2
                SqlParameter parTextoBuscar2 = new SqlParameter();
                parTextoBuscar2.ParameterName = "@textobuscar2";
                parTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar2.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar2.Value = textoBuscar2;
                sqlcmd.Parameters.Add(parTextoBuscar2);

                //ejecuto el comando y lleno el datatable
                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                //rellena el adaptador con mi datatable
                sqldat.Fill(dtresultado);
            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            return dtresultado;
        }
        //mostrar detalle
        public DataTable mostrarDetalle(string textoBuscar)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("detalle_venta");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_detalle_venta";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = textoBuscar;
                sqlcmd.Parameters.Add(parTextoBuscar);

                //ejecuto el comando y lleno el datatable
                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                //rellena el adaptador con mi datatable
                sqldat.Fill(dtresultado);
            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            return dtresultado;            
        }
        //mostrar articulos por nombre
        public DataTable mostrarArticulo_Venta_Nombre(string textoBuscar)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("articulo");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_articulo_venta_nombre";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = textoBuscar;
                sqlcmd.Parameters.Add(parTextoBuscar);

                //ejecuto el comando y lleno el datatable
                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                //rellena el adaptador con mi datatable
                sqldat.Fill(dtresultado);
            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            return dtresultado;
        }
        //mostrar articulo por codigo
        public DataTable mostrarArticulo_Venta_Codigo(string textoBuscar)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("articulo");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_articulo_venta_codigo";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = textoBuscar;
                sqlcmd.Parameters.Add(parTextoBuscar);

                //ejecuto el comando y lleno el datatable
                SqlDataAdapter sqldat = new SqlDataAdapter(sqlcmd);
                //rellena el adaptador con mi datatable
                sqldat.Fill(dtresultado);
            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            return dtresultado;
        }
    }
}
