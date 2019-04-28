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
    public partial class frmArticulo : Form
    {
        //variables indican si es editar o registrar
        private bool isNuevo = false;
        private bool isEditar = false;
        public frmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCodigo, "Ingrese el codigo del articulo");
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del articulo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la imagen del articulo");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccione la categoria del articulo");         
            this.ttMensaje.SetToolTip(this.cmbPresentacion, "Seleccione la presentacion del articulo");

            this.txtIdcategoria.Visible = false;
            this.txtCategoria.ReadOnly = true;

            this.LlenarComPresentacion();
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
            this.txtIdarticulo.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.pxImagen.Image = global::Presentacion.Properties.Resources.transparente;
            this.txtIdcategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            //this.cmbPresentacion.Items.Clear();
            this.cmbPresentacion.SelectedIndex = -1;

        }
        //habilitar controles del form
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscar_categoria.Enabled = valor;
            this.cmbPresentacion.Enabled = valor;
            //this.txtIdcategoria.ReadOnly = !valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
            this.txtIdarticulo.ReadOnly = !valor;           
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
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }
        //Metod mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);
        }
        //Metod buscar nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.Buscar(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros:" + Convert.ToString(dataListado.Rows.Count);

        }
        //llenar combobox
        private void LlenarComPresentacion()
        {
            cmbPresentacion.DataSource = NPresentacion.Mostrar();
            cmbPresentacion.ValueMember = "idpresentacion";
            cmbPresentacion.DisplayMember = "nombre";//de la presentacion
        }
        //cargar imagen
        private void BtnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();//cuadro de dialogo abrir archivo
            DialogResult result = dialog.ShowDialog();//indica el valor devuelto por el cuadro
            if (result==DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }
        //limpiar imagen
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::Presentacion.Properties.Resources.transparente;
        }

        private void FrmArticulo_Load(object sender, EventArgs e)
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
            this.BuscarNombre();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
                if (this.txtNombre.Text == string.Empty|| this.txtIdcategoria.Text == string.Empty|| this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos,seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un nombre");
                    errorIcono.SetError(txtCodigo, "Ingrese un codigo");
                    errorIcono.SetError(txtCategoria, "Ingrese una categoria");
                }
                else //si no esta vacias las cajas
                {
                    //=======creamos un obj memorystream========
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    //guardamos la imagen en un buffer
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    //envio a imagen lo que tengo almacenado en el buffer
                    byte[] imagen = ms.GetBuffer();
                    //===============FIN IMAGEN============================

                    if (this.isNuevo) //si es nuevo
                    {                //opcional txtNombre.Text.Trim.Upper
                        rpta = NArticulo.Insertar(this.txtCodigo.Text, this.txtNombre.Text, this.txtDescripcion.Text,imagen,Convert.ToInt32(this.txtIdcategoria.Text),Convert.ToInt32(this.cmbPresentacion.SelectedValue));
                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(this.txtIdarticulo.Text), this.txtCodigo.Text, this.txtNombre.Text, this.txtDescripcion.Text, imagen, Convert.ToInt32(this.txtIdcategoria.Text), Convert.ToInt32(this.cmbPresentacion.SelectedValue));
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
            if (!this.txtIdarticulo.Text.Equals(""))
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
            this.txtIdarticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            //====MOSTRAR IMAGEN=================
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);//recibo el byte de la celda

            this.pxImagen.Image = Image.FromStream(ms);//crea la imagen desde el ms
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.cmbPresentacion.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idpresentacion"].Value);

            //muestra el primer tab
            this.tabControl1.SelectedIndex = 1;
            this.btnEditar.Enabled = true;
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
                            rpta = NArticulo.Eliminar(Convert.ToInt32(id)); //envio el id

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
