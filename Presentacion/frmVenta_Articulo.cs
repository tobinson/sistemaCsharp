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
    public partial class frmVenta_Articulo : Form
    {
        public frmVenta_Articulo()
        {
            InitializeComponent();
        }
        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        //Metodo buscar nombre
        private void Buscar_Articulo_venta_Nombre()
        {
            this.dataListado.DataSource = NVenta.Mostrar_articulo_venta_nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metodo buscar numero de documento
        private void BuscarArticulo_Venta_Codigo()
        {
            this.dataListado.DataSource = NVenta.Mostrar_articulo_venta_codigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.Text.Equals("Codigo"))
            {
                this.BuscarArticulo_Venta_Codigo();
            }
            else if (cmbBuscar.Text.Equals("Nombre"))
            {
                this.Buscar_Articulo_venta_Nombre();
            }
        }
        private void DataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta frm = frmVenta.getInstancia();
            string p1, p2;
            decimal pcompra, pventa;
            int pstock;
            DateTime fvencimiento;

            p1 = Convert.ToString(dataListado.CurrentRow.Cells["iddetalle_ingreso"].Value);
            p2 = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            pcompra = Convert.ToDecimal(dataListado.CurrentRow.Cells["precio_compra"].Value);
            pventa = Convert.ToDecimal(dataListado.CurrentRow.Cells["precio_venta"].Value);
            pstock = Convert.ToInt32(dataListado.CurrentRow.Cells["stock_actual"].Value);
            fvencimiento = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha_vencimiento"].Value);
            frm.setArticulo(p1,p2,pcompra,pventa,pstock,fvencimiento);
            this.Hide();
        }
    }
}
