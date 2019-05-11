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
    public class DTrabajador
    {
        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_nacimiento;
        private string _Num_documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;

        private string _TextoBuscar;

        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_nacimiento { get => _Fecha_nacimiento; set => _Fecha_nacimiento = value; }
        public string Num_documento { get => _Num_documento; set => _Num_documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DTrabajador()
        {
        }

        public DTrabajador(int idtrabajador, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password,string textobuscar)
        {
            this.Idtrabajador = idtrabajador;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Num_documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textobuscar;
        }
        //Metodo Insertar
        public string Insertar(DTrabajador Trabajador)
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
                sqlcmd.CommandText = "spinsertar_trabajador";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdtrabajador = new SqlParameter();
                parIdtrabajador.ParameterName = "@idtrabajador";
                parIdtrabajador.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdtrabajador.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parIdtrabajador);
                //nombre
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 20;
                //metodo get obtiene el metodo Nombre
                parNombre.Value = Trabajador.Nombre;
                sqlcmd.Parameters.Add(parNombre);
                //apellidos
                SqlParameter parApellidos = new SqlParameter();
                parApellidos.ParameterName = "@apellidos";
                parApellidos.SqlDbType = SqlDbType.VarChar;
                parApellidos.Size = 40;
                //metodo get obtiene el metodo Descrpcion
                parApellidos.Value = Trabajador.Apellidos;
                sqlcmd.Parameters.Add(parApellidos);
                //sexo
                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                //metodo get obtiene el metodo Descrpcion
                parSexo.Value = Trabajador.Sexo;
                sqlcmd.Parameters.Add(parSexo);
                //fecha nacimiento
                SqlParameter parFecha_nacimiento = new SqlParameter();
                parFecha_nacimiento.ParameterName = "@fecha_nacimiento";
                parFecha_nacimiento.SqlDbType = SqlDbType.DateTime;
                //parFecha_nacimiento.Size = 40;
                //metodo get obtiene el metodo Descrpcion
                parFecha_nacimiento.Value = Trabajador.Fecha_nacimiento;
                sqlcmd.Parameters.Add(parFecha_nacimiento);                
                //numero documento
                SqlParameter parNum_documento = new SqlParameter();
                parNum_documento.ParameterName = "@num_documento";
                parNum_documento.SqlDbType = SqlDbType.VarChar;
                parNum_documento.Size = 8;
                //metodo get obtiene el metodo Descrpcion
                parNum_documento.Value = Trabajador.Num_documento;
                sqlcmd.Parameters.Add(parNum_documento);
                //direccion
                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                //metodo get obtiene el metodo Descrpcion
                parDireccion.Value = Trabajador.Direccion;
                sqlcmd.Parameters.Add(parDireccion);
                //telefono
                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                //metodo get obtiene el metodo Descrpcion
                parTelefono.Value = Trabajador.Telefono;
                sqlcmd.Parameters.Add(parTelefono);
                //email
                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parEmail.Value = Trabajador.Email;
                sqlcmd.Parameters.Add(parEmail);
                //acceso
                SqlParameter parAcceso = new SqlParameter();
                parAcceso.ParameterName = "@acceso";
                parAcceso.SqlDbType = SqlDbType.VarChar;
                parAcceso.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parAcceso.Value = Trabajador.Acceso;
                sqlcmd.Parameters.Add(parAcceso);
                //usuario
                SqlParameter parUsuario = new SqlParameter();
                parUsuario.ParameterName = "@usuario";
                parUsuario.SqlDbType = SqlDbType.VarChar;
                parUsuario.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parUsuario.Value = Trabajador.Usuario;
                sqlcmd.Parameters.Add(parUsuario);
                //password
                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@password";
                parPassword.SqlDbType = SqlDbType.VarChar;
                parPassword.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parPassword.Value = Trabajador.Password;
                sqlcmd.Parameters.Add(parPassword);


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
        public string Editar(DTrabajador Trabajador)
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
                sqlcmd.CommandText = "speditar_trabajador";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdtrabajador = new SqlParameter();
                parIdtrabajador.ParameterName = "@idtrabajador";
                parIdtrabajador.SqlDbType = SqlDbType.Int;
                //parametro de entrada necesario para editar
                parIdtrabajador.Value = Trabajador.Idtrabajador;
                sqlcmd.Parameters.Add(parIdtrabajador);
                //nombre
                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 20;
                //metodo get obtiene el metodo Nombre
                parNombre.Value = Trabajador.Nombre;
                sqlcmd.Parameters.Add(parNombre);
                //apellidos
                SqlParameter parApellidos = new SqlParameter();
                parApellidos.ParameterName = "@apellidos";
                parApellidos.SqlDbType = SqlDbType.VarChar;
                parApellidos.Size = 40;
                //metodo get obtiene el metodo Descrpcion
                parApellidos.Value = Trabajador.Apellidos;
                sqlcmd.Parameters.Add(parApellidos);
                //sexo
                SqlParameter parSexo = new SqlParameter();
                parSexo.ParameterName = "@sexo";
                parSexo.SqlDbType = SqlDbType.VarChar;
                parSexo.Size = 1;
                //metodo get obtiene el metodo Descrpcion
                parSexo.Value = Trabajador.Sexo;
                sqlcmd.Parameters.Add(parSexo);
                //fecha nacimiento
                SqlParameter parFecha_nacimiento = new SqlParameter();
                parFecha_nacimiento.ParameterName = "@fecha_nacimiento";
                parFecha_nacimiento.SqlDbType = SqlDbType.DateTime;
                //parFecha_nacimiento.Size = 40;
                //metodo get obtiene el metodo Descrpcion
                parFecha_nacimiento.Value = Trabajador.Fecha_nacimiento;
                sqlcmd.Parameters.Add(parFecha_nacimiento);
                //numero documento
                SqlParameter parNum_documento = new SqlParameter();
                parNum_documento.ParameterName = "@num_documento";
                parNum_documento.SqlDbType = SqlDbType.VarChar;
                parNum_documento.Size = 8;
                //metodo get obtiene el metodo Descrpcion
                parNum_documento.Value = Trabajador.Num_documento;
                sqlcmd.Parameters.Add(parNum_documento);
                //direccion
                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                //metodo get obtiene el metodo Descrpcion
                parDireccion.Value = Trabajador.Direccion;
                sqlcmd.Parameters.Add(parDireccion);
                //telefono
                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                //metodo get obtiene el metodo Descrpcion
                parTelefono.Value = Trabajador.Telefono;
                sqlcmd.Parameters.Add(parTelefono);
                //email
                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parEmail.Value = Trabajador.Email;
                sqlcmd.Parameters.Add(parEmail);
                //acceso
                SqlParameter parAcceso = new SqlParameter();
                parAcceso.ParameterName = "@acceso";
                parAcceso.SqlDbType = SqlDbType.VarChar;
                parAcceso.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parAcceso.Value = Trabajador.Acceso;
                sqlcmd.Parameters.Add(parAcceso);
                //usuario
                SqlParameter parUsuario = new SqlParameter();
                parUsuario.ParameterName = "@usuario";
                parUsuario.SqlDbType = SqlDbType.VarChar;
                parUsuario.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parUsuario.Value = Trabajador.Usuario;
                sqlcmd.Parameters.Add(parUsuario);
                //password
                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@password";
                parPassword.SqlDbType = SqlDbType.VarChar;
                parPassword.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parPassword.Value = Trabajador.Password;
                sqlcmd.Parameters.Add(parPassword);

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
        public string Eliminar(DTrabajador Trabajador)
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
                sqlcmd.CommandText = "speliminar_trabajador";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdtrabajador = new SqlParameter();
                parIdtrabajador.ParameterName = "@idtrabajador";
                parIdtrabajador.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdtrabajador.Value = Trabajador.Idtrabajador;
                sqlcmd.Parameters.Add(parIdtrabajador);

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
            DataTable dtresultado = new DataTable("trabajador");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                // sqlcon.Open();
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;//indico al comando q cadena de conex va a usar
                sqlcmd.CommandText = "spmostrar_trabajador";
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
        //Metodo Buscar apellidos
        public DataTable BuscarApellidos(DTrabajador Trabajador)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("trabajador");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_trabajador_apellidos";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = Trabajador.TextoBuscar;
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
        public DataTable BuscarNum_documento(DTrabajador Trabajador)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("trabajador");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_trabajador_num_documento";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = Trabajador.TextoBuscar;
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
        //=================LOGIN====================
        public DataTable Login(DTrabajador Trabajador)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("trabajador");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "splogin";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //usuario
                SqlParameter parUsuario = new SqlParameter();
                parUsuario.ParameterName = "@usuario";
                parUsuario.SqlDbType = SqlDbType.VarChar;
                parUsuario.Size = 20;
                //metodo get obtiene el metodo texto buscar
                parUsuario.Value = Trabajador.Usuario;
                sqlcmd.Parameters.Add(parUsuario);
                //password
                SqlParameter parPassword = new SqlParameter();
                parPassword.ParameterName = "@password";
                parPassword.SqlDbType = SqlDbType.VarChar;
                parPassword.Size = 20;
                //metodo get obtiene el metodo texto buscar
                parPassword.Value = Trabajador.Password;
                sqlcmd.Parameters.Add(parPassword);

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
