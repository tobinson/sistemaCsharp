using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace Datos
{
    class Dcategoria
    {
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;

        private string _TextoBuscar;

        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public Dcategoria()
        {
        }

        public Dcategoria(int idcategoria, string nombre, string descripcion, string textoBuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textoBuscar;
        }
        //Metodo Insertar
        public string Insertar(Dcategoria Categoria)
        {

        }
        //Metodo Editar
        public string Editar(Dcategoria Categoria)
        {

        }
        //Metodo Eliminar
        public string Eliminar(Dcategoria Categoria)
        {

        }
        //Metodo Mostrar
        public DataTable Mostrar()
        {

        }
        //Metodo Buscar nombre
        public string BuscarNombre(Dcategoria Categoria)
        {

        }
    }
}
