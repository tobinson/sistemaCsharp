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
    public partial class frmVenta_Cliente : Form
    {
        public frmVenta_Cliente()
        {
            InitializeComponent();
        }
        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        //Metodo buscar apellidos
        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo buscar numero de documento
        private void BuscarNum_documento()
        {
            this.dataListado.DataSource = NCliente.BuscarNum_documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metod mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVenta_Cliente_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        //buscar
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cmbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_documento();
            }
        }
        //evento envia del listado a mantenimiento al hacer dobleclick
        private void DataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.getInstancia();
            string p1, p2;
            p1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            p2 = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value) + " " +
                 Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCliente(p1,p2);
            this.Hide();
        }
    }
}
