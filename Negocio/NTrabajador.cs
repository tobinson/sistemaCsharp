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
    public class NTrabajador
    {
        //metodo insertar que llama a insertar de dcategoria en datos
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,string num_documento, string direccion, string telefono, string email,string acceso,string usuario,string password)
        {
            DTrabajador obj = new DTrabajador();
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.Fecha_nacimiento = fecha_nacimiento;            
            obj.Num_documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Acceso = acceso;
            obj.Usuario = usuario;
            obj.Password = password;
            return obj.Insertar(obj);
        }
        //editar
        public static string Editar(int idtrabajador, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador obj = new DTrabajador();
            obj.Idtrabajador = idtrabajador;
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.Fecha_nacimiento = fecha_nacimiento;
            obj.Num_documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Acceso = acceso;
            obj.Usuario = usuario;
            obj.Password = password;
            return obj.Editar(obj);
        }
        //eliminar
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador obj = new DTrabajador();
            obj.Idtrabajador = idtrabajador;
            return obj.Eliminar(obj);
        }
        //buscar apellidos
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DTrabajador obj = new DTrabajador();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarApellidos(obj);
        }
        //buscar numero documento
        public static DataTable BuscarNum_documento(string textobuscar)
        {
            DTrabajador obj = new DTrabajador();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNum_documento(obj);
        }
        //mostrar        
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }
    }
}
