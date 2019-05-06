namespace Presentacion
{
    partial class frmProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbBuscar = new System.Windows.Forms.ComboBox();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRazon_social = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdproveedor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipo_documento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSector_comercial = new System.Windows.Forms.ComboBox();
            this.txtNum_documento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Codigo";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbBuscar);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.chkEliminar);
            this.tabPage1.Controls.Add(this.txtBuscar);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(542, 225);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbBuscar
            // 
            this.cmbBuscar.FormattingEnabled = true;
            this.cmbBuscar.Items.AddRange(new object[] {
            "Documento",
            "Razon_social"});
            this.cmbBuscar.Location = new System.Drawing.Point(3, 21);
            this.cmbBuscar.Name = "cmbBuscar";
            this.cmbBuscar.Size = new System.Drawing.Size(121, 21);
            this.cmbBuscar.TabIndex = 8;
            this.cmbBuscar.Text = "Documento";
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eliminar});
            this.dataListado.Location = new System.Drawing.Point(4, 68);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(527, 124);
            this.dataListado.TabIndex = 7;
            this.dataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataListado_CellContentClick);
            this.dataListado.DoubleClick += new System.EventHandler(this.DataListado_DoubleClick);
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "eliminar";
            this.eliminar.Name = "eliminar";
            this.eliminar.ReadOnly = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(404, 48);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "label3";
            // 
            // chkEliminar
            // 
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Location = new System.Drawing.Point(9, 44);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(62, 17);
            this.chkEliminar.TabIndex = 5;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            this.chkEliminar.CheckedChanged += new System.EventHandler(this.ChkEliminar_CheckedChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(137, 21);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(140, 20);
            this.txtBuscar.TabIndex = 4;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(456, 18);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(375, 18);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(294, 19);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(337, 174);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(256, 174);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(175, 174);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(94, 174);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Location = new System.Drawing.Point(119, 103);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(141, 53);
            this.txtDireccion.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Direccion";
            // 
            // txtRazon_social
            // 
            this.txtRazon_social.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtRazon_social.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRazon_social.Location = new System.Drawing.Point(119, 50);
            this.txtRazon_social.Name = "txtRazon_social";
            this.txtRazon_social.Size = new System.Drawing.Size(141, 20);
            this.txtRazon_social.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "R. Social";
            // 
            // txtIdproveedor
            // 
            this.txtIdproveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdproveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdproveedor.Location = new System.Drawing.Point(120, 24);
            this.txtIdproveedor.Name = "txtIdproveedor";
            this.txtIdproveedor.Size = new System.Drawing.Size(49, 20);
            this.txtIdproveedor.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipo_documento);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbSector_comercial);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNum_documento);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtRazon_social);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtIdproveedor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proveedores";
            // 
            // cmbTipo_documento
            // 
            this.cmbTipo_documento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cmbTipo_documento.FormattingEnabled = true;
            this.cmbTipo_documento.Items.AddRange(new object[] {
            "Dni",
            "Ruc"});
            this.cmbTipo_documento.Location = new System.Drawing.Point(119, 76);
            this.cmbTipo_documento.Name = "cmbTipo_documento";
            this.cmbTipo_documento.Size = new System.Drawing.Size(48, 21);
            this.cmbTipo_documento.TabIndex = 12;
            this.cmbTipo_documento.Text = "Ruc";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "T. Documento";
            // 
            // cmbSector_comercial
            // 
            this.cmbSector_comercial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cmbSector_comercial.FormattingEnabled = true;
            this.cmbSector_comercial.Items.AddRange(new object[] {
            "Salud",
            "Alimentos",
            "Tecnologia",
            "Ropa",
            "Servicios"});
            this.cmbSector_comercial.Location = new System.Drawing.Point(346, 24);
            this.cmbSector_comercial.Name = "cmbSector_comercial";
            this.cmbSector_comercial.Size = new System.Drawing.Size(121, 21);
            this.cmbSector_comercial.TabIndex = 10;
            this.cmbSector_comercial.Text = "Alimentos";
            // 
            // txtNum_documento
            // 
            this.txtNum_documento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtNum_documento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNum_documento.Location = new System.Drawing.Point(173, 75);
            this.txtNum_documento.Name = "txtNum_documento";
            this.txtNum_documento.Size = new System.Drawing.Size(88, 20);
            this.txtNum_documento.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "S. Comercial";
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrl.Location = new System.Drawing.Point(346, 103);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(121, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(276, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Url";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(346, 77);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(121, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(276, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Email";
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Location = new System.Drawing.Point(346, 51);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(121, 20);
            this.txtTelefono.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Telefono";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(542, 225);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 251);
            this.tabControl1.TabIndex = 3;
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // frmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(551, 253);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Name = "frmProveedor";
            this.Text = ".:. Mantenimiento de Proveedores .:.";
            this.Load += new System.EventHandler(this.FrmProveedor_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRazon_social;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdproveedor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSector_comercial;
        private System.Windows.Forms.TextBox txtNum_documento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipo_documento;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbBuscar;
    }
}