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
    public partial class frmProveedor : Form
    {
        //variables indican si es editar o registrar
        private bool isNuevo = false;
        private bool isEditar = false;
        public frmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazon_social, "Ingrese la razon social del proveedor");            
            this.ttMensaje.SetToolTip(this.txtNum_documento, "Ingrese el numero de documento del proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la direccion del proveedor");
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
            this.txtIdproveedor.Text = string.Empty;
            this.txtRazon_social.Text = string.Empty;
            this.cmbSector_comercial.SelectedIndex = -1;
            this.cmbTipo_documento.SelectedIndex = -1;
            this.txtNum_documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUrl.Text = string.Empty;           
        }
        //habilitar controles del form
        private void Habilitar(bool valor)
        {
            this.txtIdproveedor.ReadOnly = !valor;
            this.txtRazon_social.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;            
            this.cmbSector_comercial.Enabled = valor;
            this.cmbTipo_documento.Enabled = valor;
            this.txtNum_documento.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;      
        }
        //habilitar botones
        private void Botones()
        {
            //disyuncion f v f= f las demas verdaderas
            //los valores de isNuevo y isEditar se envian desde los metodos
            if (this.isNuevo || this.isEditar)
            {       //si es nuevo o editar
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {       //si no es editar o insertar habilitamos nuevo ambos f
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                // this.btnEditar.Enabled = true;
                this.btnEditar.Enabled = false;
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
   
        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            //carga al iniciar el form
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbBuscar.Text.Equals("Razon_social"))
            {
                this.BuscarRazon_social();
            }
            else if(cmbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_documento();
            }
        }
        //eliminar
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Realmente desea eliminar los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    string id;
                    string rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows) //recorre las filas
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value)) //la celda 0 convierte a bool
                        {
                            id = Convert.ToString(row.Cells[1].Value); //obtiene su idcategoria
                            rpta = NProveedor.Eliminar(Convert.ToInt32(id)); //envio el id

                            if (rpta.Equals("Ok"))
                            {
                                this.MensajeOk("Se elimino correctamente el registro");
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
        //muestra desaparece checkbox eliminar en datalistado
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
        //nuevo
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazon_social.Focus();
        }
        //guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtRazon_social.Text == string.Empty || this.txtNum_documento.Text == string.Empty || this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,seran remarcados");
                    errorIcono.SetError(txtRazon_social, "Ingrese la rzon social");
                    errorIcono.SetError(txtNum_documento, "Ingrese el numero de documento");
                    errorIcono.SetError(txtDireccion, "Ingrese su direccion");
                }
                else 
                {                    
                    if (this.isNuevo) //si es nuevo
                    {                //opcional txtNombre.Text.Trim.Upper
                        rpta = NProveedor.Insertar(this.txtRazon_social.Text,this.cmbSector_comercial.Text,this.cmbTipo_documento.Text,this.txtNum_documento.Text,this.txtDireccion.Text,this.txtTelefono.Text,this.txtEmail.Text,this.txtUrl.Text);
                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdproveedor.Text), this.txtRazon_social.Text, this.cmbSector_comercial.Text, this.cmbTipo_documento.Text, this.txtNum_documento.Text, this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text, this.txtUrl.Text);
                    }
                    if (rpta.Equals("Ok"))
                    {
                        if (this.isNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    //despues de editar o guardar dejarlos en false
                    this.isNuevo = false;
                    this.isEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //editar
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdproveedor.Text.Equals(""))
            {
                this.isEditar = true;
                Botones();
            }
            else
            {
                MensajeError("Debe selecionar primero el registro a modificar");
            }
        }
        //cancelar
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
        }
        //doble click
        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["eliminar"];
                chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
            }
        }
        //evento envia del listado a mantenimiento al hacer dobleclick
        private void DataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
            this.txtRazon_social.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["razon_social"].Value);
            this.cmbSector_comercial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sector_comercial"].Value);
            this.cmbTipo_documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["url"].Value);

            //muestra el primer tab
            this.tabControl1.SelectedIndex = 1;
            this.btnEditar.Enabled = true;
        }
    }
}
