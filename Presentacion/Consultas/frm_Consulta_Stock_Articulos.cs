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

namespace Presentacion.Consultas
{
    public partial class frm_Consulta_Stock_Articulos : Form
    {
        public frm_Consulta_Stock_Articulos()
        {
            InitializeComponent();
        }
        //ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;//columna eliminar            
        }
        //Metod mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar_Stock_Articulos();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }

        private void Frm_Consulta_Stock_Articulos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();            
        }
    }
}
