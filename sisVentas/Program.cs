﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using para acceder a presentacion
using Presentacion;
namespace sisVentas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1()); 
            //Application.Run(new frmCategoria());
            //Application.Run(new frmPresentacion());
            //Application.Run(new frmArticulo());
            //Application.Run(frmArticulo.GetInstancia());
            //Application.Run(new frmProveedor());
            //Application.Run(new frmCliente());
            //Application.Run(new mdiBorrar());
            //Application.Run(new frmTrabajador());
            //Application.Run(new frmBorrar2());
            //Application.Run(new frmPrincipal());
            Application.Run(new frmLogin());
        }
    }
}
