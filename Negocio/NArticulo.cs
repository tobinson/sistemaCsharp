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
    public class NArticulo
    {
        //metodo insertar 
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo obj = new DArticulo();            
            obj.Codigo = codigo;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Imagen = imagen;
            obj.Idcategoria = idcategoria;
            obj.Idpresentacion = idpresentacion;
            return obj.Insertar(obj);
        }
        //editar
        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo obj = new DArticulo();
            obj.Idarticulo = idarticulo;
            obj.Codigo = codigo;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Imagen = imagen;
            obj.Idcategoria = idcategoria;
            obj.Idpresentacion = idpresentacion;
            return obj.Insertar(obj);
        }
        //eliminar
        public static string Eliminar(int idarticulo)
        {
            DArticulo obj = new DArticulo();
            obj.Idarticulo = idarticulo;
            return obj.Eliminar(obj);
        }
        //buscar
        public static DataTable Buscar(string textobuscar)
        {
            DArticulo obj = new DArticulo();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);
        }
        //mostrar        
        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }
        //stock
        public static DataTable Mostrar_Stock_Articulos()
        {
            return new DArticulo().Mostrar_Stock_Articulos();
        }
    }
}
