using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using agregado
using Negocio;

namespace Presentacion
{
    public partial class frmCategoria_Articulo : Form
    {
        public frmCategoria_Articulo()
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
            this.dataListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);

        }
        //Metod buscar nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCategoria.Buscar(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void FrmCategoria_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        //envia idcategoria y nombre de categoria al form articulo
        private void DataListado_DoubleClick(object sender, EventArgs e)
        {
            frmArticulo form = frmArticulo.GetInstancia();
            string p1, p2;
            p1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            p2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCategoria(p1,p2);
            this.Hide();
        }
    }
}
