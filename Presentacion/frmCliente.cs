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
    public partial class frmCliente : Form
    {
        //variables indican si es editar o registrar
        private bool isNuevo = false;
        private bool isEditar = false;
        public frmCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del cliente");
            this.ttMensaje.SetToolTip(this.cmbTipo_documento, "Ingrese el tipo de documento del cliente");
            this.ttMensaje.SetToolTip(this.txtNum_documento, "Ingrese el numero de documento del proveedor");       
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
            this.txtIdcliente.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.cmbSexo.SelectedIndex = -1;
            this.dtFecha_nacimiento.ResetText();
            this.cmbTipo_documento.SelectedIndex = -1;
            this.txtNum_documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;           
        }
        //habilitar controles del form
        private void Habilitar(bool valor)
        {
            this.txtIdcliente.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cmbSexo.Enabled = valor;
            this.dtFecha_nacimiento.Enabled = valor;
            this.cmbTipo_documento.Enabled = valor;
            this.txtNum_documento.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;          
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

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            //carga al iniciar el form
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
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
                            rpta = NCliente.Eliminar(Convert.ToInt32(id)); //envio el id

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
            this.txtIdcliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);            
            this.cmbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            //obitne valor seleccionado con value
            this.dtFecha_nacimiento.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            this.cmbTipo_documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
          
            //muestra el primer tab
            this.tabControl1.SelectedIndex = 1;
            this.btnEditar.Enabled = true;
        }
        //nuevo
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }
        //guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.cmbTipo_documento.Text == string.Empty || this.txtNum_documento.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese nombre del cliente");
                    errorIcono.SetError(cmbTipo_documento, "seleccione el tipo de documento");
                    errorIcono.SetError(txtNum_documento, "Ingrese el numero de documento");
                }
                else
                {
                    if (this.isNuevo) //si es nuevo
                    {                //opcional txtNombre.Text.Trim.Upper
                        rpta = NCliente.Insertar(this.txtNombre.Text, this.txtApellidos.Text, this.cmbSexo.Text, this.dtFecha_nacimiento.Value,cmbTipo_documento.Text, this.txtNum_documento.Text, this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text);
                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdcliente.Text), this.txtNombre.Text, this.txtApellidos.Text, this.cmbSexo.Text, this.dtFecha_nacimiento.Value, cmbTipo_documento.Text, this.txtNum_documento.Text, this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text);
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
            if (!this.txtIdcliente.Text.Equals(""))
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
            txtIdcliente.Text = string.Empty;
        }
    }
}
