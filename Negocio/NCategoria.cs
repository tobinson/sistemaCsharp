﻿using System;
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
     public class NCategoria
    {
        //metodo insertar que llama a insertar de dcategoria en datos
        public static string Insertar(string nombre,string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;            
            return obj.Insertar(obj);
        }
        //editar
        public static string Editar(int idcategoria,string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.Idcategoria = idcategoria;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;            
            return obj.Editar(obj);
        }
        //eliminar
        public static string Eliminar(int idcategoria)
        {
            DCategoria obj = new DCategoria();
            obj.Idcategoria = idcategoria;
            return obj.Eliminar(obj);
        }
        //buscar
        public static DataTable Buscar(string textobuscar)
        {
            DCategoria obj = new DCategoria();
            obj.TextoBuscar = textobuscar;
            return obj.BuscarNombre(obj);
        }
        //mostrar        
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();            
        }

    }
}
