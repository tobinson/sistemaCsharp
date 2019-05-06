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
    public class NProveedor
    {
        //metodo insertar que llama a insertar de dcategoria en datos
        public static string Insertar(string razon_social, string sector_comercial,string tipo_documento,string num_documento,string direccion,string telefono,string email,string url)
        {
            DProveedor obj = new DProveedor();
            obj.Razon_social = razon_social;
            obj.Sector_comercial = sector_comercial;
            obj.Tipo_documento = tipo_documento;
            obj.Num_documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Url = url;
            return obj.Insertar(obj);
        }
        //editar
        public static string Editar(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor obj = new DProveedor();
            obj.Idproveedor = idproveedor;
            obj.Razon_social = razon_social;
            obj.Sector_comercial = sector_comercial;
            obj.Tipo_documento = tipo_documento;
            obj.Num_documento = num_documento;
            obj.Direccion = direccion;
            obj.Telefono = telefono;
            obj.Email = email;
            obj.Url = url;
            return obj.Editar(obj);
        }
        //eliminar
        public static string Eliminar(int idproveedor)
        {
            DProveedor obj = new DProveedor();
            obj.Idproveedor = idproveedor;
            return obj.Eliminar(obj);
        }
        //buscar razon social
        public static DataTable BuscarRazon_social(string textobuscar)
        {
            DProveedor obj = new DProveedor();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarRazon_social(obj);
        }
        //buscar numero documento
        public static DataTable BuscarNum_documento(string textobuscar)
        {
            DProveedor obj = new DProveedor();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNum_documento(obj);
        }
        //mostrar        
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }
    }
}
