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
    public class NPresentacion
    {
        //metodo insertar 
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion obj = new DPresentacion();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Insertar(obj);
        }
        //editar
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion obj = new DPresentacion();
            obj.Idpresentacion = idpresentacion;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            return obj.Editar(obj);
        }
        //eliminar
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion obj = new DPresentacion();
            obj.Idpresentacion = idpresentacion;
            return obj.Eliminar(obj);
        }
        //buscar
        public static DataTable Buscar(string textobuscar)
        {
            DPresentacion obj = new DPresentacion();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);
        }
        //mostrar        
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }
    }
}
