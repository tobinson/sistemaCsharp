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
    public class DProveedor
    {
        private int _Idproveedor;
        private string _Razon_social;
        private string _Sector_comercial;
        private string _Tipo_documento;
        private string _Num_documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Url;

        private string _TextoBuscar;

        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Razon_social { get => _Razon_social; set => _Razon_social = value; }
        public string Sector_comercial { get => _Sector_comercial; set => _Sector_comercial = value; }
        public string Tipo_documento { get => _Tipo_documento; set => _Tipo_documento = value; }
        public string Num_documento { get => _Num_documento; set => _Num_documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DProveedor()
        {
        }

        public DProveedor(int idproveedor, string razon_social, string sector_social, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url, string textoBuscar)
        {
            this.Idproveedor = idproveedor;
            this.Razon_social = razon_social;
            this.Sector_comercial = sector_social;
            this.Tipo_documento = tipo_documento;
            this.Num_documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textoBuscar;
        }
        //Metodo Insertar
        public string Insertar(DProveedor Proveedor)
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
                sqlcmd.CommandText = "spinsertar_proveedor";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //idproveedor
                SqlParameter parIdproveedor = new SqlParameter();
                parIdproveedor.ParameterName = "@idproveedor";
                parIdproveedor.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdproveedor.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(parIdproveedor);
                //razon social
                SqlParameter parRazon_social = new SqlParameter();
                parRazon_social.ParameterName = "@razon_social";
                parRazon_social.SqlDbType = SqlDbType.VarChar;
                parRazon_social.Size = 150;
                //metodo get obtiene el metodo Nombre
                parRazon_social.Value = Proveedor.Razon_social;
                sqlcmd.Parameters.Add(parRazon_social);
                //sector comercial
                SqlParameter parSector_comercial = new SqlParameter();
                parSector_comercial.ParameterName = "@sector_comercial";
                parSector_comercial.SqlDbType = SqlDbType.VarChar;
                parSector_comercial.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parSector_comercial.Value = Proveedor.Sector_comercial;
                sqlcmd.Parameters.Add(parSector_comercial);
                //tipo documento documento
                SqlParameter parTipo_documento = new SqlParameter();
                parTipo_documento.ParameterName = "@tipo_documento";
                parTipo_documento.SqlDbType = SqlDbType.VarChar;
                parTipo_documento.Size = 20;
                //metodo get q obtiene el tipo documento
                parTipo_documento.Value = Proveedor.Tipo_documento;
                sqlcmd.Parameters.Add(parTipo_documento);
                //numero de  documento
                SqlParameter parNum_documento = new SqlParameter();
                parNum_documento.ParameterName = "@num_documento";
                parNum_documento.SqlDbType = SqlDbType.VarChar;
                parNum_documento.Size = 11;
                //metodo get obtiene el metodo Descrpcion
                parNum_documento.Value = Proveedor.Num_documento;
                sqlcmd.Parameters.Add(parNum_documento);
                //direccion
                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                //metodo get obtiene el metodo Descrpcion
                parDireccion.Value = Proveedor.Direccion;
                sqlcmd.Parameters.Add(parDireccion);
                //telefono
                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                //metodo get obtiene el metodo Descrpcion
                parTelefono.Value = Proveedor.Telefono;
                sqlcmd.Parameters.Add(parTelefono);
                //email
                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parEmail.Value = Proveedor.Email;
                sqlcmd.Parameters.Add(parEmail);
                //Url
                SqlParameter parUrl = new SqlParameter();
                parUrl.ParameterName = "@url";
                parUrl.SqlDbType = SqlDbType.VarChar;
                parUrl.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parUrl.Value = Proveedor.Url;
                sqlcmd.Parameters.Add(parUrl);

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
        public string Editar(DProveedor Proveedor)
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
                sqlcmd.CommandText = "speditar_proveedor";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado id
                SqlParameter parIdproveedor = new SqlParameter();
                parIdproveedor.ParameterName = "@idproveedor";
                parIdproveedor.SqlDbType = SqlDbType.Int;
                //parametro de entrada necesario para editar
                parIdproveedor.Value = Proveedor.Idproveedor;
                sqlcmd.Parameters.Add(parIdproveedor);
                //razon social
                SqlParameter parRazon_social = new SqlParameter();
                parRazon_social.ParameterName = "@razon_social";
                parRazon_social.SqlDbType = SqlDbType.VarChar;
                parRazon_social.Size = 150;
                //metodo get obtiene el metodo Nombre
                parRazon_social.Value = Proveedor.Razon_social;
                sqlcmd.Parameters.Add(parRazon_social);
                //sector comercial
                SqlParameter parSector_comercial = new SqlParameter();
                parSector_comercial.ParameterName = "@sector_comercial";
                parSector_comercial.SqlDbType = SqlDbType.VarChar;
                parSector_comercial.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parSector_comercial.Value = Proveedor.Sector_comercial;
                sqlcmd.Parameters.Add(parSector_comercial);
                //tipo documento documento
                SqlParameter parTipo_documento = new SqlParameter();
                parTipo_documento.ParameterName = "@tipo_documento";
                parTipo_documento.SqlDbType = SqlDbType.VarChar;
                parTipo_documento.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parTipo_documento.Value = Proveedor.Tipo_documento;
                sqlcmd.Parameters.Add(parTipo_documento);
                //numero de documento
                SqlParameter parNum_documento = new SqlParameter();
                parNum_documento.ParameterName = "@num_documento";
                parNum_documento.SqlDbType = SqlDbType.VarChar;
                parNum_documento.Size = 20;
                //metodo get obtiene el metodo Descrpcion
                parNum_documento.Value = Proveedor.Num_documento;
                sqlcmd.Parameters.Add(parNum_documento);
                //direccion
                SqlParameter parDireccion = new SqlParameter();
                parDireccion.ParameterName = "@direccion";
                parDireccion.SqlDbType = SqlDbType.VarChar;
                parDireccion.Size = 100;
                //metodo get obtiene el metodo Descrpcion
                parDireccion.Value = Proveedor.Direccion;
                sqlcmd.Parameters.Add(parDireccion);
                //telefono
                SqlParameter parTelefono = new SqlParameter();
                parTelefono.ParameterName = "@telefono";
                parTelefono.SqlDbType = SqlDbType.VarChar;
                parTelefono.Size = 10;
                //metodo get obtiene el metodo Descrpcion
                parTelefono.Value = Proveedor.Telefono;
                sqlcmd.Parameters.Add(parTelefono);
                //email
                SqlParameter parEmail = new SqlParameter();
                parEmail.ParameterName = "@email";
                parEmail.SqlDbType = SqlDbType.VarChar;
                parEmail.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parEmail.Value = Proveedor.Email;
                sqlcmd.Parameters.Add(parEmail);
                //Url
                SqlParameter parUrl = new SqlParameter();
                parUrl.ParameterName = "@url";
                parUrl.SqlDbType = SqlDbType.VarChar;
                parUrl.Size = 50;
                //metodo get obtiene el metodo Descrpcion
                parUrl.Value = Proveedor.Url;
                sqlcmd.Parameters.Add(parUrl);

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
        public string Eliminar(DProveedor Proveedor)
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
                sqlcmd.CommandText = "speliminar_proveedor";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //declarar parametros q recibe el procedimiento almacenado
                SqlParameter parIdproveedor = new SqlParameter();
                parIdproveedor.ParameterName = "@idproveedor";
                parIdproveedor.SqlDbType = SqlDbType.Int;
                //parametro de salida por ser autonumerico
                parIdproveedor.Value = Proveedor.Idproveedor;
                sqlcmd.Parameters.Add(parIdproveedor);

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
            DataTable dtresultado = new DataTable("proveedor");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                // sqlcon.Open();
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;//indico al comando q cadena de conex va a usar
                sqlcmd.CommandText = "spmostrar_proveedor";
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
        //Metodo Buscar razon social
        public DataTable BuscarRazon_social(DProveedor Proveedor)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("proveedor");
            SqlConnection sqlcon = new SqlConnection();
            try
            {
                //establesco la cadena de conexion
                sqlcon.ConnectionString = Conexion.cn;
                //establecer el comando para ejecutar sentecias sql
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandText = "spbuscar_proveedor_razon_social";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //parametro buscar
                SqlParameter parTextoBuscar = new SqlParameter();
                parTextoBuscar.ParameterName = "@textobuscar";
                parTextoBuscar.SqlDbType = SqlDbType.VarChar;
                parTextoBuscar.Size = 50;
                //metodo get obtiene el metodo texto buscar
                parTextoBuscar.Value = Proveedor.TextoBuscar;
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
        public DataTable BuscarNum_documento(DProveedor Proveedor)
        {
            //envio como parametro el nombre de la tabla
            DataTable dtresultado = new DataTable("proveedor");
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
                parTextoBuscar.Value = Proveedor.TextoBuscar;
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
