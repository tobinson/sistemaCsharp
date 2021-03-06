﻿using System;
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
//using Datos;

namespace Presentacion
{
    public partial class frmPresentacion : Form
    {
        //variables indican si es editar o registrar
        private bool isNuevo = false;
        private bool isEditar = false;
        public frmPresentacion()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre de la presentacion");
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
            this.txtIdpresentacion.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;           
        }
        //habilitar controles del form
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdpresentacion.ReadOnly = !valor;
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
            this.dataListado.DataSource = NPresentacion.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metod buscar nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NPresentacion.Buscar(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);

        }
        //click en cualquier parte blanca del formulario para activar  load
        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            //carga al iniciar el form
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        //buscar al hacer click
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
        //buscar al hacer escribir en la caja de texto
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.isNuevo = true;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un nombre");
                }
                else //si no esta vacias las cajas
                {
                    if (this.isNuevo) //si es nuevo
                    {                //opcional txtNombre.Text.Trim.Upper
                        rpta = NPresentacion.Insertar(txtNombre.Text, txtDescripcion.Text);
                    }
                    else
                    {
                        rpta = NPresentacion.Editar(Convert.ToInt32(this.txtIdpresentacion.Text), txtNombre.Text, txtDescripcion.Text);
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
        //evento envia del listado a mantenimiento al hacer dobleclick
        private void DataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdpresentacion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idpresentacion"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);

            //muestra el primer tab
            this.tabControl1.SelectedIndex = 1;
            this.btnEditar.Enabled = true;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdpresentacion.Text.Equals(""))
            {
                this.isEditar = true;
                Botones();
            }
            else
            {
                MensajeError("Debe selecionar primero el registro a modificar");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.isNuevo = false;
            this.isEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
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

        private void BtnEliminar_Click(object sender, EventArgs e)
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
                            rpta = NPresentacion.Eliminar(Convert.ToInt32(id)); //envio el id

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
        
    }
}
