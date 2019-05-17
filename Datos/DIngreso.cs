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
    class DIngreso
    {
        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _Tipo_comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_comprobante { get => _Tipo_comprobante; set => _Tipo_comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        public DIngreso()
        {
        }

        public DIngreso(int idingreso, int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, string estado)
        {
            this.Idingreso = idingreso;
            this.Idtrabajador = idtrabajador;
            this.Idproveedor = idproveedor;
            this.Fecha = fecha;
            this.Tipo_comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;
        }
        //Metodo Insertar (ingreso y todos sus detalles a modo lista)
        public string Insertar(DIngreso Ingreso,List<DDetalle_Ingreso> Detalle)
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
                sqlcmd.CommandText = "spinsertar_ingreso";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdingreso = new SqlParameter();
                parIdingreso.ParameterName = "@idingreso";
                parIdingreso.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdingreso.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parIdingreso);
                //idtrabajador
                SqlParameter parIdtrabajador = new SqlParameter();
                parIdtrabajador.ParameterName = "@idtrabajador";
                parIdtrabajador.SqlDbType = SqlDbType.Int;                
                //metodo get obtiene el metodo Nombre
                parIdtrabajador.Value = Ingreso.Idtrabajador;
                sqlcmd.Parameters.Add(parIdtrabajador);
                //idproveedor
                SqlParameter parIdproveedor = new SqlParameter();
                parIdproveedor.ParameterName = "@idproveedor";
                parIdproveedor.SqlDbType = SqlDbType.Int;
                //metodo get obtiene el metodo Descrpcion
                parIdproveedor.Value = Ingreso.Idproveedor;
                sqlcmd.Parameters.Add(parIdproveedor);
                //fecha
                SqlParameter parFecha = new SqlParameter();
                parFecha.ParameterName = "@fecha";
                parFecha.SqlDbType = SqlDbType.DateTime;
                //metodo get obtiene el metodo Descrpcion
                parFecha.Value = Ingreso.Fecha;
                sqlcmd.Parameters.Add(parFecha);
                //tipo comprobante
                SqlParameter parTipo_comprobante = new SqlParameter();
                parTipo_comprobante.ParameterName = "@tipo_comprobante";
                parTipo_comprobante.SqlDbType = SqlDbType.VarChar;
                parTipo_comprobante.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parTipo_comprobante.Value = Ingreso.Tipo_comprobante;
                sqlcmd.Parameters.Add(parTipo_comprobante);
                //serie
                SqlParameter parSerie = new SqlParameter();
                parSerie.ParameterName = "@serie";
                parSerie.SqlDbType = SqlDbType.VarChar;
                parSerie.Size = 4;
                //metodo get obtiene el metodo Descrpcion
                parSerie.Value = Ingreso.Serie;
                sqlcmd.Parameters.Add(parSerie);
                //correlativo
                SqlParameter parCorrelativo = new SqlParameter();
                parCorrelativo.ParameterName = "@correlativo";
                parCorrelativo.SqlDbType = SqlDbType.VarChar;
                parCorrelativo.Size = 7;
                //metodo get obtiene el metodo Descrpcion
                parCorrelativo.Value = Ingreso.Correlativo;
                sqlcmd.Parameters.Add(parCorrelativo);
                //igv
                SqlParameter parIgv = new SqlParameter();
                parIgv.ParameterName = "@igv";
                parIgv.SqlDbType = SqlDbType.Decimal;//tiene presicion y scala
                parIgv.Precision = 4;
                parIgv.Scale = 2;
                //metodo get obtiene el metodo Descrpcion
                parIgv.Value = Ingreso.Igv;
                sqlcmd.Parameters.Add(parIgv);
                //estado
                SqlParameter parEstado = new SqlParameter();
                parEstado.ParameterName = "@estado";
                parEstado.SqlDbType = SqlDbType.VarChar;
                parEstado.Size = 7;
                //metodo get obtiene el metodo Descrpcion
                parEstado.Value = Ingreso.Estado;
                sqlcmd.Parameters.Add(parEstado);

                //ejecutamos nuestro comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ingreso el registro";
                //si es ok Dingreso inserto los detalles_ingreso
                if (rpta.Equals("Ok"))
                {
                    //obtenemos el idingreso de la tabla ingreso para detalle_ingreso
                    this.Idingreso = Convert.ToInt32(sqlcmd.Parameters["@idingreso"].Value);//value por ser de salida
                    //recorre la lista Detalle en la var det del mismo tipo q la lista
                    foreach (DDetalle_Ingreso det in Detalle)
                    {
                        det.Idingreso = this.Idingreso; //envio el idingreso obtenido a detalle_ingreso
                        //insertar de la clase detalle_ingreso
                        rpta = det.Insertar(det,ref sqlcon,ref sqltra);
                        if (!rpta.Equals("Ok")) //si no se pudo insertar
                        {
                            break;// salgo del bucle
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
        public string Anular(DIngreso Ingreso)
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
                sqlcmd.CommandText = "spanular_ingreso";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdingreso = new SqlParameter();
                parIdingreso.ParameterName = "@idingreso";
                parIdingreso.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdingreso.Value = Ingreso.Idingreso;
                sqlcmd.Parameters.Add(parIdingreso);

                //ejecutamos nuestro comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "No se eanulo el registro";
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
        //Metodo Mostrar
        public DataTable Mostrar()
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("ingreso");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                // sqlcon.Open();
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;//indico al comando q cadena de conex va a usar
                sqlcmd.CommandText = "spmostrar_ingreso";
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
        public DataTable BuscarFechas(string textoBuscar,string textoBuscar2)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("ingreso");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_ingreso_fecha";
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
            DataTable dtresultado = new DataTable("detalle_ingreso");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spmostrar_detalle_ingreso";
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
