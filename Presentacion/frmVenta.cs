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
using Presentacion.Reportes;

namespace Presentacion
{    
    public partial class frmVenta : Form
    {
        //variables 
        private bool isNuevo = false;
        public int Idtrabajador;
        private DataTable dtDetalle;
        private decimal totalPago=0;//acumulador

        //objeto que me hace referencia a la clase frmingreso
        private static frmVenta _Instancia;
        //metodo q verifica si se creo el obj o no
        public static frmVenta getInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmVenta();
            }
            return _Instancia;
        }
        //metodos para establecer los valores en las cajas
        public void setArticulo(string iddetalle_ingreso,string nombre,decimal precio_compra,decimal precio_venta,int stock,DateTime fecha_vencimiento)
        {
            this.txtIdarticulo.Text = iddetalle_ingreso;
            this.txtArticulo.Text = nombre;
            this.txtPrecio_compra.Text = Convert.ToString(precio_compra);
            this.txtPrecio_venta.Text= Convert.ToString(precio_venta);
            this.txtStock_actual.Text= Convert.ToString(stock);
            this.dtFecha_vencimiento.Value = fecha_vencimiento;            
        }
        public void setCliente(string idcliente, string nombre)
        {
            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;            
        }

        public frmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtIdcliente,"seleccione un cliente");
            this.ttMensaje.SetToolTip(this.txtSerie, "ingrese una serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "ingrese una numero correlativo");
            this.ttMensaje.SetToolTip(this.txtCantidad, "ingrese la cantidad del producto");
            this.ttMensaje.SetToolTip(this.txtArticulo, "seleccione un articulo");

            this.txtIdcliente.Visible = false;
            this.txtIdarticulo.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
            this.dtFecha_vencimiento.Enabled = false;
            this.txtPrecio_compra.ReadOnly = true;
            this.txtPrecio_venta.ReadOnly = true;            
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
            this.txtIdventa.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotal_pagado.Text = "0.0";
            this.txtIgv.Text = "18";
            this.crearTabla();
        }
        //limpiar detalle
        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock_actual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio_compra.Text = string.Empty;
            this.txtPrecio_venta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
        }
        //habilitar controles del form
        private void Habilitar(bool valor)
        {
            this.txtIdventa.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cmbTipo_comprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecio_compra.ReadOnly = !valor;
            this.txtPrecio_venta.ReadOnly = !valor;
            this.txtStock_actual.ReadOnly = !valor;
            this.txtDescuento.ReadOnly = !valor;
            this.dtFecha_vencimiento.Enabled = valor;

            this.btnBuscar_articulo.Enabled = valor;
            this.btnBuscar_cliente.Enabled = valor;
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
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metod buscar fechas
        private void BuscarFecha()
        {
            this.dataListado.DataSource = NVenta.BuscarFecha(this.dtFecha_inicio.Value.ToString("dd/MM/yyyy"), this.dtFecha_fin.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);

        }
        //Mostrar detalle
        private void MostrarDetalle()
        {
            this.dataListado.DataSource = NVenta.Mostrar_detalle(this.txtIdventa.Text);
        }
        //crea la tabla de los articulos
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");//creo una tabla Detalle
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));            
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));            
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //envio dtDetalle como origen de datos a dtlistado_detalle
            this.dtlistado_detalle.DataSource = this.dtDetalle;
        }
        //evento al cerrar el formulario
        //evento al cerrar el formulario se destruye la instancia
        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
        //formulario de vista cliente
        private void BtnBuscar_cliente_Click(object sender, EventArgs e)
        {
            frmVenta_Cliente vista = new frmVenta_Cliente();
            vista.ShowDialog();
        }
        //formulario de vista articulo
        private void BtnBuscar_articulo_Click(object sender, EventArgs e)
        {
            frmVenta_Articulo vista = new frmVenta_Articulo();
            vista.ShowDialog();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;            
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();
        }
        //guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdcliente.Text == string.Empty || this.txtSerie.Text == string.Empty || this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,seran remarcados");
                    errorIcono.SetError(txtIdcliente, "Ingrese un id del cliente");
                    errorIcono.SetError(txtSerie, "Ingrese la serie");
                    errorIcono.SetError(txtCorrelativo, "Ingrese el correlativo");                    
                    errorIcono.SetError(txtIgv, "Ingrese el igv");
                }
                else //si no esta vacias las cajas
                {
                    if (this.isNuevo) //si es nuevo IDTRABAJADOR SE ENVIA COMO PARAMETRO DESDE PRINCIPAL
                    {                //emitido es el estado dtdetalle es la variable  q almacenara la nueva tabla
                        rpta = NVenta.Insertar(Convert.ToInt32(txtIdcliente.Text), Idtrabajador, this.dtFecha.Value, cmbTipo_comprobante.Text, this.txtSerie.Text, this.txtCorrelativo.Text, Convert.ToDecimal(txtIgv.Text),dtDetalle);
                    }
                    if (rpta.Equals("Ok"))
                    {
                        if (this.isNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    //despues de editar o guardar dejarlos en false
                    this.isNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFecha();
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Reamente desea eliminar los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    string id;
                    string rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows) //recorre las filas
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value)) //la celda 0 cnvierte a bool
                        {
                            id = Convert.ToString(row.Cells[1].Value); //obtiene su idcategoria
                            rpta = NVenta.Eliminar(Convert.ToInt32(id)); //envio el id

                            if (rpta.Equals("Ok"))
                            {
                                this.MensajeOk("Se elimino correctamente la venta");
                                this.chkEliminar.Checked = false;//despues de eliminar deselecciona el check
                            }
                            else
                            {
                                this.MensajeError(rpta);
                            }
                        }
                    }
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //al hacer doble click envia los datos a las cajas
        private void DataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdventa.Text = Convert.ToString(dataListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha"].Value);
            this.cmbTipo_comprobante.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotal_pagado.Text = Convert.ToString(dataListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();//solo necesita idingreso para mostrarlos
            //muestra el primer tab
            this.tabControl1.SelectedIndex = 1;
        }

        private void ChkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }
        //doble click
        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);            
        }
        //boton agregar nueva tabla de articulo a dtlistado_detalle
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtIdarticulo.Text == string.Empty || this.txtCantidad.Text == string.Empty || this.txtDescuento.Text == string.Empty || this.txtPrecio_venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,seran remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un id del articulo");
                    errorIcono.SetError(txtCantidad, "Ingrese la cantidad del articulo");
                    errorIcono.SetError(txtDescuento, "Ingrese el descuento");
                    errorIcono.SetError(txtPrecio_venta, "Ingrese el precio de venta");
                }
                else //si no esta vacias las cajas
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {   //verificar si se repite el id ya q la fila es editable
                        if (Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(txtIdarticulo.Text))
                        {
                            registrar = false;//si se repite no se registra
                            this.MensajeError("ya se encuentra el articulo en el detalle");
                        }
                    }
                    if (registrar && (Convert.ToInt32(this.txtCantidad.Text)<Convert.ToInt32(this.txtStock_actual.Text)))
                    {
                        decimal subtotal = Convert.ToDecimal(this.txtStock_actual.Text) * Convert.ToDecimal(this.txtPrecio_compra.Text)-Convert.ToDecimal(this.txtDescuento.Text);
                        totalPago = totalPago + subtotal;
                        this.lblTotal_pagado.Text = totalPago.ToString("#0.00#");
                        //crear la fila 
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecio_venta.Text);                                               
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subtotal"] = subtotal;
                        this.dtDetalle.Rows.Add(row); //se agrega la fila row creada a dtDetalle
                        this.limpiarDetalle();//se limpia las cajas al crear la fila para insertar otra fila
                    }
                    else
                    {
                        MensajeError("no hay stock suficiente");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //quitar
        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            try
            {   //obtengo el indice de la fila seleccionada
                int indiceFila = this.dtlistado_detalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];//envio esa fila a row
                //diminuir total pagado
                this.totalPago = this.totalPago - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotal_pagado.Text = totalPago.ToString("#0.00#");
                //removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception)
            {
                this.MensajeError("no hay fila para remover");
            }
        }

        private void BtnComprobante_Click(object sender, EventArgs e)
        {
            frmReporteFactura frm = new frmReporteFactura();
            frm.Idventa = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idventa"].Value);
            frm.ShowDialog();
        }
    }
}
