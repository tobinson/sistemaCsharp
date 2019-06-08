using Presentacion.Consultas;
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
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 0;
        //recibo los datos obtenidos con el login al acceder al sistema(tabla trabajador)
        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";       
        public string Acceso = "";
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        //salir
        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //almacen-categorias
        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.MdiParent = this;
            frm.Show();
        }
        //almacen-presentacion
        private void PresentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresentacion frm = new frmPresentacion();
            frm.MdiParent = this;
            frm.Show();
        }
        //almacen-articulo
        private void ArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo frm = frmArticulo.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }
        //compras -proveedor
        private void ProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }
        //ventas-cliente
        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TrabajadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrabajador frm = new frmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }
        //control de accesos
        private void GestionUsuarios()
        {
            if (Acceso == "Administrador")//seleccion del combobox
            {
                this.mnuAlmacen.Enabled = true;
                this.mnuCompras.Enabled = true;
                this.mnuVentas.Enabled = true;
                this.mnuMantenimiento.Enabled = true;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramientas.Enabled = true;
                this.tsCompras.Enabled = true;
                this.tsVentas.Enabled = true;
            }
            else if (Acceso == "Vendedor")
            {
                this.mnuAlmacen.Enabled = false;
                this.mnuCompras.Enabled = false;
                this.mnuVentas.Enabled = true;
                this.mnuMantenimiento.Enabled = true;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramientas.Enabled = false;
                this.tsCompras.Enabled = false;
                this.tsVentas.Enabled = true;
            }
            else if (Acceso == "Almacenero")
            {
                this.mnuAlmacen.Enabled = true;
                this.mnuCompras.Enabled = true;
                this.mnuVentas.Enabled = false;
                this.mnuMantenimiento.Enabled = false;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramientas.Enabled = true;
                this.tsCompras.Enabled = true;
                this.tsVentas.Enabled = false;
            }
            else
            {
                this.mnuAlmacen.Enabled = false;
                this.mnuCompras.Enabled = false;
                this.mnuVentas.Enabled = false;
                this.mnuMantenimiento.Enabled = false;
                this.mnuConsultas.Enabled = false;
                this.mnuHerramientas.Enabled = false;
                this.tsCompras.Enabled = true;
                this.tsVentas.Enabled = false;
            }
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuarios();
        }

        private void IngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.getInstancia();
            frm.MdiParent = this;
            frm.Show();            
            //para insertar un ingreso necesito el idtrabajador del trabajador respnsable
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);

        }

        private void VentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVenta frm = frmVenta.getInstancia();
            //frm.tabPage2.Parent = null; EL TAB Y TABPAGE PUBIC ANTES PARA OCULTAR TAB MANTENIMIENTO
            frm.MdiParent = this;            
            frm.Show();
            //envio a venta el idtrabajador desde principal obtenido al hacer login
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void StockDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Consulta_Stock_Articulos frm = new frm_Consulta_Stock_Articulos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void VentasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenta frm = frmVenta.getInstancia();
            frm.tabPage2.Parent = null; //EL TAB Y TABPAGE PUBIC ANTES PARA OCULTAR TAB MANTENIMIENTO
            frm.MdiParent = this;
            frm.Show();
            //envio a venta el idtrabajador desde principal obtenido al hacer login
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void ComprasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.getInstancia();
            frm.tabPage2.Parent = null;
            frm.MdiParent = this;
            frm.Show();
            //para insertar un ingreso necesito el idtrabajador del trabajador respnsable
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }
    }
}
