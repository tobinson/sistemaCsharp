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
    public class DArticulo
    {
        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;//array de tipo byte
        private int _Idcategoria;
        private int _Idpresentacion;

        private string _TextoBuscar;

        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DArticulo()
        {
        }

        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string textoBuscar)
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textoBuscar;
        }
        //Metodo Insertar
        public string Insertar(DArticulo Articulo)
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
                sqlcmd.CommandText = "spinsertar_articulo";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdarticulo = new SqlParameter();
                parIdarticulo.ParameterName = "@idarticulo";
                parIdarticulo.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdarticulo.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parIdarticulo);
                //codigo
                SqlParameter parCodigo = new SqlParameter();
                parCodigo.ParameterName = "@codigo";
                parCodigo.SqlDbType = SqlDbType.VarChar;
                parCodigo.Size = 50;
                //metodo get obtiene el metodo Codigo
                parCodigo.Value = Articulo.Codigo;
                sqlcmd.Parameters.Add(parCodigo);
                //nombre
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                //metodo get obtiene el metodo Nombre
                parNombre.Value = Articulo.Nombre;
                sqlcmd.Parameters.Add(parNombre);
                //descripcion
                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 1024;
                //metodo get obtiene el metodo Descrpcion
                parDescripcion.Value = Articulo.Descripcion;
                sqlcmd.Parameters.Add(parDescripcion);
                //imagen                
                SqlParameter parImagen = new SqlParameter();
                parImagen.ParameterName = "@imagen";
                parImagen.SqlDbType = SqlDbType.Image;                
                //imagen no tiene medida size
                parImagen.Value = Articulo.Imagen;
                sqlcmd.Parameters.Add(parImagen);
                //Idcategoria
                SqlParameter parIdcategoria = new SqlParameter();
                parIdcategoria.ParameterName = "@idcategoria";
                parIdcategoria.SqlDbType = SqlDbType.Int;
                //tampoco tiene tamaño por ser int                
                parIdcategoria.Value = Articulo.Idcategoria;
                sqlcmd.Parameters.Add(parIdcategoria);
                //Idpresentacion
                SqlParameter parIdpresentacion = new SqlParameter();
                parIdpresentacion.ParameterName = "@idpresentacion";
                parIdpresentacion.SqlDbType = SqlDbType.Int;
                //tampoco tiene tamaño por ser int                
                parIdpresentacion.Value = Articulo.Idpresentacion;
                sqlcmd.Parameters.Add(parIdpresentacion);


                //ejecutamos nuestro comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ingreso el registro";
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
        //Metodo Editar
        public string Editar(DArticulo Articulo)
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
                sqlcmd.CommandText = "speditar_articulo";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //idarticulo editar
                SqlParameter parIdarticulo = new SqlParameter();
                parIdarticulo.ParameterName = "@idarticulo";
                parIdarticulo.SqlDbType = SqlDbType.Int;
                //parametro de entrada necesario para editar
                parIdarticulo.Value = Articulo.Idarticulo;
                sqlcmd.Parameters.Add(parIdarticulo);
                //nombre
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                //metodo get obtiene el metodo Nombre
                parNombre.Value = Articulo.Nombre;
                sqlcmd.Parameters.Add(parNombre);
                //descripcion
                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 1024;
                //metodo get obtiene el metodo Descrpcion
                parDescripcion.Value = Articulo.Descripcion;
                sqlcmd.Parameters.Add(parDescripcion);
                //imagen                
                SqlParameter parImagen = new SqlParameter();
                parImagen.ParameterName = "@imagen";
                parImagen.SqlDbType = SqlDbType.Image;
                //imagen no tiene medida size
                parImagen.Value = Articulo.Imagen;
                sqlcmd.Parameters.Add(parImagen);
                //Idcategoria
                SqlParameter parIdcategoria = new SqlParameter();
                parIdcategoria.ParameterName = "@idcategoria";
                parIdcategoria.SqlDbType = SqlDbType.Int;
                //tampoco tiene tamaño por ser int                
                parIdcategoria.Value = Articulo.Idcategoria;
                sqlcmd.Parameters.Add(parIdcategoria);
                //Idpresentacion
                SqlParameter parIdpresentacion = new SqlParameter();
                parIdpresentacion.ParameterName = "@idpresentacion";
                parIdpresentacion.SqlDbType = SqlDbType.Int;
                //tampoco tiene tamaño por ser int                
                parIdpresentacion.Value = Articulo.Idpresentacion;
                sqlcmd.Parameters.Add(parIdpresentacion);

                //ejecutamos nuestro comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "No se actualizo el registro";
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
        //Metodo Eliminar
        public string Eliminar(DArticulo Articulo)
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
                sqlcmd.CommandText = "speliminar_articulo";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdarticulo = new SqlParameter();
                parIdarticulo.ParameterName = "@idarticulo";
                parIdarticulo.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdarticulo.Value = Articulo.Idarticulo;
                sqlcmd.Parameters.Add(parIdarticulo);

                //ejecutamos nuestro comando
                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "Ok" : "No se elimino el registro";
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
            DataTable dtresultado = new DataTable("articulo");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                // sqlcon.Open();
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;//indico al comando q cadena de conex va a usar
                sqlcmd.CommandText = "spmostrar_articulo";
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
        //Metodo Buscar nombre
        public DataTable BuscarNombre(DArticulo Articulo)
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
                sqlcmd.CommandText = "spbuscar_articulo";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = Articulo.TextoBuscar;
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
