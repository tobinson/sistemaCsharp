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
    public partial class frmProveedor_Ingreso : Form
    {
        public frmProveedor_Ingreso()
        {
            InitializeComponent();
        }
        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        //Metod mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo buscar razon social
        private void BuscarRazon_social()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazon_social(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo buscar numero de documento
        private void BuscarNum_documento()
        {
            this.dataListado.DataSource = NProveedor.BuscarNum_documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.Text.Equals("Razon_social"))
            {
                this.BuscarRazon_social();
            }
            else if (cmbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_documento();
            }
        }

        private void DataListado_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso form = frmIngreso.getInstancia();
            string p1, p2;
            p1 = Convert.ToString(dataListado.CurrentRow.Cells["idproveedor"].Value);
            p2 = Convert.ToString(dataListado.CurrentRow.Cells["razon_social"].Value);
            form.setProveedor(p1, p2);
            this.Hide();
        }
    }
}
