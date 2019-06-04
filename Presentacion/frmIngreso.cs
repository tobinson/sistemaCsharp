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
        public int Idtrabajador;//enviado desde principal en la sesion

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
            this.lblTotal_pagado.Text="0.0";            
            this.txtIgv.Text = "18";
            this.crearTabla();
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
            this.txtPrecio_venta.ReadOnly = !valor;
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
            this.dataListado.DataSource = NIngreso.BuscarFecha(this.dtFecha_inicio.Value.ToString("dd/MM/yyyy"),this.dtFecha_fin.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);

        }
        //Mostrar detalle
        private void MostrarDetalle()
        {
            this.dataListado.DataSource = NIngreso.Mostrar_detalle(this.txtIdingreso.Text);            
        }
        //crea la tabla de los articulos
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");//creo una tabla Detalle
            this.dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //envio dtDetalle como origen de datos a dtlistado_detalle
            this.dtlistado_detalle.DataSource = this.dtDetalle;
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
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFecha();
        }
        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Reamente desea anular los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    string id;
                    string rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows) //recorre las filas
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value)) //la celda 0 cnvierte a bool
                        {
                            id = Convert.ToString(row.Cells[1].Value); //obtiene su idcategoria
                            rpta = NIngreso.Anular(Convert.ToInt32(id)); //envio el id

                            if (rpta.Equals("Ok"))
                            {
                                this.MensajeOk("Se anulo correctamente el registro");
                                this.chkAnular.Checked = false;//despues de eliminar deselecciona el check
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

        private void ChkAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnular.Checked)
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
                DataGridViewCheckBoxCell chkAnular = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["eliminar"];
                chkAnular.Value = !Convert.ToBoolean(chkAnular.Value);
            }
        }
        //nuevo
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;            
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtSerie.Focus();
            this.limpiarDetalle();
        }
        //cancelar
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;            
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.limpiarDetalle();
        }
        //boton guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdproveedor.Text == string.Empty || this.txtSerie.Text == string.Empty || this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,seran remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un id del articulo");
                    errorIcono.SetError(txtStock, "Ingrese el stock");
                    errorIcono.SetError(txtPrecio_compra, "Ingrese el precio de compra");
                    errorIcono.SetError(txtPrecio_venta, "Ingrese el precio de venta");
                    errorIcono.SetError(txtIgv, "Ingrese el igv");
                }
                else //si no esta vacias las cajas
                {
                    if (this.isNuevo) //si es nuevo
                    {                //emitido es el estado dtdetalle es la variable  q almacenara la nueva tabla
                        rpta = NIngreso.Insertar(Idtrabajador, Convert.ToInt32(this.txtIdproveedor.Text), this.dtFecha.Value, cmbTipo_comprobante.Text, this.txtSerie.Text, this.txtCorrelativo.Text, Convert.ToDecimal(txtIgv.Text), "emitido", dtDetalle);
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
        //boton agregar nueva tabla de articulo a dtlistado_detalle
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtIdarticulo.Text == string.Empty || this.txtStock.Text == string.Empty || this.txtPrecio_compra.Text == string.Empty || this.txtPrecio_venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,seran remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un id del articulo");
                    errorIcono.SetError(txtStock, "Ingrese el stock");
                    errorIcono.SetError(txtPrecio_compra, "Ingrese el precio de compra");
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
                    if (registrar)
                    {
                        decimal subtotal = Convert.ToDecimal(this.txtStock.Text) * Convert.ToDecimal(this.txtPrecio_compra.Text);
                        totalPago = totalPago + subtotal;
                        this.lblTotal_pagado.Text = totalPago.ToString("#0.00#");
                        //crear la fila 
                        DataRow row = this.dtDetalle.NewRow();
                        row["idarticulo"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.txtPrecio_compra.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecio_venta.Text);
                        row["stock_inicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["fecha_produccion"] = dtFecha_produccion.Value;
                        row["fecha_vencimiento"] = dtFecha_vencimiento.Value;
                        row["subtotal"] = subtotal;
                        this.dtDetalle.Rows.Add(row); //se agrega la fila row creada a dtDetalle
                        this.limpiarDetalle();//se limpia las cajas al crear la fila para insertar otra fila
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //boton quitar nueva tabla de articulo a dtlistado_detalle
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
        //al hacer doble click envia los datos a las cajas
        private void DataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdingreso.Text = Convert.ToString(dataListado.CurrentRow.Cells["idingreso"].Value);
            this.txtProveedor.Text = Convert.ToString(dataListado.CurrentRow.Cells["proveedor"].Value);
            this.dtFecha.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["fecha"].Value);
            this.cmbTipo_comprobante.Text = Convert.ToString(dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotal_pagado.Text= Convert.ToString(dataListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();//solo necesita idingreso para mostrarlos
            //muestra el primer tab
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
