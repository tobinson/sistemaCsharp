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
    public partial class frmIngreso : Form
    {
        //envia el idtrabajador al formulario principal
        public int Idtrabajador;

        //variables 
        private bool isNuevo;
        private DataTable dtDetalle;
        private Decimal totalPago = 0;//acumulador

        //objeto que me hace referencia a la clase frmingreso
        private static frmIngreso _Instancia;
        //metodo q verifica si se creo el obj o no
        public static frmIngreso getInstancia()
        {
            if (_Instancia==null)
            {
                _Instancia = new frmIngreso();
            }
            return _Instancia;
        }
        //metodos para establecer los valores en las cajas
        public void setProveedor(string idproveedor,string nombre)
        {
            this.txtIdproveedor.Text = idproveedor;
            this.txtProveedor.Text = nombre;
        }
        public void setArticulo(string idarticulo,string nombre)
        {
            this.txtIdarticulo.Text = idarticulo;
            this.txtArticulo.Text = nombre;
        }
        public frmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtProveedor,"Seleccione el proveedor");
            this.ttMensaje.SetToolTip(txtSerie, "Seleccione la serie del comprovante");
            this.ttMensaje.SetToolTip(txtCorrelativo, "Ingrese un numero del comprobante");
            this.ttMensaje.SetToolTip(txtStock, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(txtArticulo, "Seleccione el articulo de compra");
            this.txtIdproveedor.Visible = false;
            this.txtIdarticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
        }
        //mostrar mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //limpiar controles del form
        private void Limpiar()
        {
            this.txtIdingreso.Text = string.Empty;
            this.txtIdproveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;            
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotal.Text="0.0";            
        }
        //limpiar detalle
        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text= string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecio_compra.Text = string.Empty;
            this.txtPrecio_venta.Text = string.Empty;
        }
        //habilitar controles del form
        private void Habilitar(bool valor)
        {
            this.txtIdingreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cmbTipo_comprobante.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecio_compra.ReadOnly = !valor;
            this.txtPrecio_venta.Enabled = !valor;
            this.dtFecha_produccion.Enabled = valor;
            this.dtFecha_vencimiento.Enabled = valor;

            this.btnBuscar_articulo.Enabled = valor;
            this.btnBuscar_proveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            
        }
        //habilitar botones
        private void Botones()
        {
            //disyuncion f v f= f las demas verdaderas
            //los valores de isNuevo y isEditar se envian desde los metodos
            if (this.isNuevo)
            {       //si es nuevo o editar
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;                
                this.btnCancelar.Enabled = true;
            }
            else
            {       //si no es editar o insertar habilitamos nuevo ambos f
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;                
                this.btnCancelar.Enabled = false;
            }
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
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metod buscar fechas
        private void BuscarFecha()
        {
            this.dataListado.DataSource = NIngreso.BuscarFecha(this.dtFecha_inicio.Value.ToString("dd/mm/yyyy"),this.dtFecha_fin.Value.ToString("dd/mm/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);

        }
        //evento al cerrar el formulario
        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void BtnBuscar_proveedor_Click(object sender, EventArgs e)
        {
            frmProveedor_Ingreso vista = new frmProveedor_Ingreso();
            vista.ShowDialog();
        }

        private void BtnBuscar_articulo_Click(object sender, EventArgs e)
        {
            frmArticulo_Ingreso vista = new frmArticulo_Ingreso();
            vista.ShowDialog();
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {

        }
    }
}
