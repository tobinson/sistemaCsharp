using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmBorrar2 : Form
    {
        public frmBorrar2()
        {
            InitializeComponent();
            //lblSalida.Text = DateTime.Now.ToString("G");
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            if (dtFecha.Value.Year==DateTime.Now.Year)
            {
                lblSalida.Text = "no cambiaste de fecha";
            }
            else
            {
                lblSalida.Text = "cambiaste de fecha";
            }
        }
    }
}
