using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Reportes
{
    public partial class frmReporteFactura : Form
    {
        private int _Idventa;
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public frmReporteFactura()
        {
            InitializeComponent();
        }
        private void FrmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spreporte_venta' Puede moverla o quitarla según sea necesario.
            try
            {
                this.spreporte_ventaTableAdapter.Fill(this.dsPrincipal.spreporte_venta,Idventa);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {                
            }
        }
    }
}
