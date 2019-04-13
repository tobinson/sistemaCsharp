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
    class DCategoria
    {
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;

        private string _TextoBuscar;

        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DCategoria()
        {
        }

        public DCategoria(int idcategoria, string nombre, string descripcion, string textoBuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textoBuscar;
        }
        //Metodo Insertar
        public string Insertar(DCategoria Categoria)
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
                sqlcmd.CommandText = "spinsertar_categoria";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdcategoria = new SqlParameter();
                parIdcategoria.ParameterName = "@idcategoria";
                parIdcategoria.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdcategoria.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parIdcategoria);
                //nombre
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                //metodo get obtiene el metodo Nombre
                parNombre.Value=Categoria.Nombre;
                sqlcmd.Parameters.Add(parNombre);
                //descripcion
                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 256;
                //metodo get obtiene el metodo Descrpcion
                parDescripcion.Value = Categoria.Descripcion;
                sqlcmd.Parameters.Add(parDescripcion);

                //ejecutamos nuestro comando
                rpta=sqlcmd.ExecuteNonQuery()==1?"Ok":"No se ingreso el registro"
            }
            catch (Exception ex)
            {
                rpta=ex.Message;
            }
            finally
            {
                if (sqlcon.State==ConnectionState.Open) sqlcon.Close();               
            }
            return rpta;
        }
        //Metodo Editar
        public string Editar(DCategoria Categoria)
        {

        }
        //Metodo Eliminar
        public string Eliminar(DCategoria Categoria)
        {

        }
        //Metodo Mostrar
        public DataTable Mostrar()
        {

        }
        //Metodo Buscar nombre
        public string BuscarNombre(DCategoria Categoria)
        {

        }
    }
}
