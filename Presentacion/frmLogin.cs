using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//importacion necesaria para llamar a negocio
using Negocio;

namespace Presentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            //devuelve un databale el metodo login
            DataTable datos = NTrabajador.Login(this.txtUsuario.Text,this.txtPassword.Text);
            //evaluar si existe el usuario y password si hay una fila
            if (datos.Rows.Count==0)
            {
                MessageBox.Show("No tiene acceso al sistema", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //accedo al sistema abro frmprincipal y y envio los datos
                MessageBox.Show("Bienvenido al sistema "+this.txtUsuario.Text, "Sistema de ventas", MessageBoxButtons.OK);
                frmPrincipal obj = new frmPrincipal();
                obj.Idtrabajador = datos.Rows[0][0].ToString();//[fila][columna]
                obj.Apellidos = datos.Rows[0][1].ToString();
                obj.Nombre= datos.Rows[0][2].ToString();
                obj.Acceso = datos.Rows[0][3].ToString();

                obj.Show();//muestro principal
                this.Hide();//oculto login

            }
        }
    }
}
