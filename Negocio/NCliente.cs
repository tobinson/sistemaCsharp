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
    public class NCliente
    {
        //metodo insertar que llama a insertar de dcategoria en datos
        public static string Insertar(string nombre, string apellidos,string sexo,DateTime fecha_nacimiento,string tipo_documento,string num_documento,string direccion,string telefono,string email)
        {
            DCliente obj = new DCliente();
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.Fecha_nacimiento = fecha_nacimiento;
            obj.Tipo_documento = tipo_documento;
            obj.Num_documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            return obj.Insertar(obj);
        }
        //editar
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento, string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente obj = new DCliente();
            obj.Idcliente = idcliente;
            obj.Nombre = nombre;
            obj.Apellidos = apellidos;
            obj.Sexo = sexo;
            obj.Fecha_nacimiento = fecha_nacimiento;
            obj.Tipo_documento = tipo_documento;
            obj.Num_documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            return obj.Editar(obj);
        }
        //eliminar
        public static string Eliminar(int idcliente)
        {
            DCliente obj = new DCliente();
            obj.Idcliente = idcliente;
            return obj.Eliminar(obj);
        }
        //buscar apellidos
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DCliente obj = new DCliente();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarApellidos(obj);
        }
        //buscar numero documento
        public static DataTable BuscarNum_documento(string textobuscar)
        {
            DCliente obj = new DCliente();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNum_documento(obj);
        }
        //mostrar        
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }
    }
}
