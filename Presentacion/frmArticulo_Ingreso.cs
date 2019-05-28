using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using para llamar a negocio
using Negocio;

namespace Presentacion
{
    public partial class frmArticulo_Ingreso : Form
    {
        public frmArticulo_Ingreso()
        {
            InitializeComponent();
        }
        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }
        //Metod mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metod buscar nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.Buscar(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);

        }

        private void FrmArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
        //doble click envia a las cajas de frmingreso atravez del metodo setArticulo
        private void DataListado_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso form = frmIngreso.getInstancia();
            string p1, p2;
            p1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            p2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setArticulo(p1, p2);
            this.Hide();
        }
    }
}
