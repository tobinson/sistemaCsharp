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
    public class DCliente
    {
        private int _Idcliente;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_nacimiento;
        private string _Tipo_documento;
        private string _Num_documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;

        private string _TextoBuscar;

        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_nacimiento { get => _Fecha_nacimiento; set => _Fecha_nacimiento = value; }
        public string Tipo_documento { get => _Tipo_documento; set => _Tipo_documento = value; }
        public string Num_documento { get => _Num_documento; set => _Num_documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DCliente()
        {
        }

        public DCliente(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_documento, string num_documento, string direccion, string telefono, string email, string textoBuscar)
        {
            this.Idcliente = idcliente;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Tipo_documento = tipo_documento;
            this.Num_documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TextoBuscar = textoBuscar;
        }
        //Metodo Insertar
        public string Insertar(DCliente Cliente)
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
                sqlcmd.CommandText = "spinsertar_cliente";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdcliente = new SqlParameter();
                parIdcliente.ParameterName = "@idcliente";
                parIdcliente.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdcliente.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parIdcliente);
                //nombre
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                //metodo get obtiene el metodo Nombre
                parNombre.Value = Cliente.Nombre;
                sqlcmd.Parameters.Add(parNombre);
                //apellidos
                SqlParameter parApellidos = new SqlParameter();
                parApellidos.ParameterName = "@apellidos";
                parApellidos.SqlDbType = SqlDbType.VarChar;
                parApellidos.Size = 40;
                //metodo get obtiene el metodo Descrpcion
                parApellidos.Value = Cliente.Apellidos;
                sqlcmd.Parameters.Add(parApellidos);
                //sexo
                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                //metodo get obtiene el metodo Descrpcion
                parSexo.Value = Cliente.Sexo;
                sqlcmd.Parameters.Add(parSexo);
                //fecha nacimiento
                SqlParameter parFecha_nacimiento = new SqlParameter();
                parFecha_nacimiento.ParameterName = "@fecha_nacimiento";
                parFecha_nacimiento.SqlDbType = SqlDbType.DateTime;
                //parFecha_nacimiento.Size = 40;
                //metodo get obtiene el metodo Descrpcion
                parFecha_nacimiento.Value = Cliente.Fecha_nacimiento;
                sqlcmd.Parameters.Add(parFecha_nacimiento);
                //tipo documento
                SqlParameter parTipo_documento = new SqlParameter();
                parTipo_documento.ParameterName = "@tipo_documento";
                parTipo_documento.SqlDbType = SqlDbType.VarChar;
                parTipo_documento.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parTipo_documento.Value = Cliente.Tipo_documento;
                sqlcmd.Parameters.Add(parTipo_documento);
                //numero documento
                SqlParameter parNum_documento = new SqlParameter();
                parNum_documento.ParameterName = "@num_documento";
                parNum_documento.SqlDbType = SqlDbType.VarChar;
                parNum_documento.Size = 11;
                //metodo get obtiene el metodo Descrpcion
                parNum_documento.Value = Cliente.Num_documento;
                sqlcmd.Parameters.Add(parNum_documento);
                //direccion
                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                //metodo get obtiene el metodo Descrpcion
                parDireccion.Value = Cliente.Direccion;
                sqlcmd.Parameters.Add(parDireccion);
                //telefono
                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                //metodo get obtiene el metodo Descrpcion
                parTelefono.Value = Cliente.Telefono;
                sqlcmd.Parameters.Add(parTelefono);
                //telefono
                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parEmail.Value = Cliente.Email;
                sqlcmd.Parameters.Add(parEmail);

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
        public string Editar(DCliente Cliente)
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
                sqlcmd.CommandText = "speditar_cliente";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdcliente = new SqlParameter();
                parIdcliente.ParameterName = "@idcliente";
                parIdcliente.SqlDbType = SqlDbType.Int;
                //parametro de entrada necesario para editar
                parIdcliente.Value = Cliente.Idcliente;
                sqlcmd.Parameters.Add(parIdcliente);
                //nombre
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                //metodo get obtiene el metodo Nombre
                parNombre.Value = Cliente.Nombre;
                sqlcmd.Parameters.Add(parNombre);
                //apellidos
                SqlParameter parApellidos = new SqlParameter();
                parApellidos.ParameterName = "@apellidos";
                parApellidos.SqlDbType = SqlDbType.VarChar;
                parApellidos.Size = 40;
                //metodo get obtiene el metodo Descrpcion
                parApellidos.Value = Cliente.Apellidos;
                sqlcmd.Parameters.Add(parApellidos);
                //sexo
                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                //metodo get obtiene el metodo Descrpcion
                parSexo.Value = Cliente.Sexo;
                sqlcmd.Parameters.Add(parSexo);
                //fecha nacimiento
                SqlParameter parFecha_nacimiento = new SqlParameter();
                parFecha_nacimiento.ParameterName = "@fecha_nacimiento";
                parFecha_nacimiento.SqlDbType = SqlDbType.DateTime;
                //parFecha_nacimiento.Size = 40;
                //metodo get obtiene el metodo Descrpcion
                parFecha_nacimiento.Value = Cliente.Fecha_nacimiento;
                sqlcmd.Parameters.Add(parFecha_nacimiento);
                //tipo documento
                SqlParameter parTipo_documento = new SqlParameter();
                parTipo_documento.ParameterName = "@tipo_documento";
                parTipo_documento.SqlDbType = SqlDbType.VarChar;
                parTipo_documento.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parTipo_documento.Value = Cliente.Tipo_documento;
                sqlcmd.Parameters.Add(parTipo_documento);
                //numero documento
                SqlParameter parNum_documento = new SqlParameter();
                parNum_documento.ParameterName = "@num_documento";
                parNum_documento.SqlDbType = SqlDbType.VarChar;
                parNum_documento.Size = 11;
                //metodo get obtiene el metodo Descrpcion
                parNum_documento.Value = Cliente.Num_documento;
                sqlcmd.Parameters.Add(parNum_documento);
                //direccion
                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                //metodo get obtiene el metodo Descrpcion
                parDireccion.Value = Cliente.Direccion;
                sqlcmd.Parameters.Add(parDireccion);
                //telefono
                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                //metodo get obtiene el metodo Descrpcion
                parTelefono.Value = Cliente.Telefono;
                sqlcmd.Parameters.Add(parTelefono);
                //telefono
                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parEmail.Value = Cliente.Email;
                sqlcmd.Parameters.Add(parEmail);

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
        public string Eliminar(DCliente Cliente)
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
                sqlcmd.CommandText = "speliminar_cliente";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdccliente = new SqlParameter();
                parIdccliente.ParameterName = "@idcliente";
                parIdccliente.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdccliente.Value = Cliente.Idcliente;
                sqlcmd.Parameters.Add(parIdccliente);

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
            DataTable dtresultado = new DataTable("cliente");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                // sqlcon.Open();
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;//indico al comando q cadena de conex va a usar
                sqlcmd.CommandText = "spmostrar_cliente";
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
        public DataTable BuscarApellidos(DCliente Cliente)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("cliente");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_cliente_apellidos";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = Cliente.TextoBuscar;
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
        //Metodo Buscar numero de documento
        public DataTable BuscarNum_documento(DCliente Cliente)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("cliente");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_num_documento";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = Cliente.TextoBuscar;
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

