namespace Presentacion
{
    partial class frmVenta
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
            this.txtIgv = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCorrelativo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotal_pagado = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtlistado_detalle = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecio_venta = new System.Windows.Forms.TextBox();
            this.txtPrecio_compra = new System.Windows.Forms.TextBox();
            this.txtStock_actual = new System.Windows.Forms.TextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.dtFecha_vencimiento = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.btnBuscar_articulo = new System.Windows.Forms.Button();
            this.txtIdarticulo = new System.Windows.Forms.TextBox();
            this.cmbTipo_comprobante = new System.Windows.Forms.ComboBox();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscar_cliente = new System.Windows.Forms.Button();
            this.txtIdcliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdventa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.dtFecha_fin = new System.Windows.Forms.DateTimePicker();
            this.dtFecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.dataListado = new System.Windows.Forms.DataGridView();
            this.eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.btnComprobante = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlistado_detalle)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIgv
            // 
            this.txtIgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIgv.Location = new System.Drawing.Point(325, 72);
            this.txtIgv.Name = "txtIgv";
            this.txtIgv.Size = new System.Drawing.Size(46, 20);
            this.txtIgv.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(235, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Igv";
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtCorrelativo.Location = new System.Drawing.Point(377, 44);
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.Size = new System.Drawing.Size(141, 20);
            this.txtCorrelativo.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(235, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Numero";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotal_pagado);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.dtlistado_detalle);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtIgv);
            this.groupBox1.Controls.Add(this.txtIdarticulo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtCorrelativo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbTipo_comprobante);
            this.groupBox1.Controls.Add(this.dtFecha);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnBuscar_cliente);
            this.groupBox1.Controls.Add(this.txtIdcliente);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.txtSerie);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtIdventa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 307);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventas";
            // 
            // lblTotal_pagado
            // 
            this.lblTotal_pagado.AutoSize = true;
            this.lblTotal_pagado.Location = new System.Drawing.Point(477, 283);
            this.lblTotal_pagado.Name = "lblTotal_pagado";
            this.lblTotal_pagado.Size = new System.Drawing.Size(22, 13);
            this.lblTotal_pagado.TabIndex = 29;
            this.lblTotal_pagado.Text = "0:0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(377, 285);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "Total Pagado: S./";
            // 
            // dtlistado_detalle
            // 
            this.dtlistado_detalle.AllowUserToAddRows = false;
            this.dtlistado_detalle.AllowUserToDeleteRows = false;
            this.dtlistado_detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtlistado_detalle.Location = new System.Drawing.Point(27, 175);
            this.dtlistado_detalle.Name = "dtlistado_detalle";
            this.dtlistado_detalle.Size = new System.Drawing.Size(524, 97);
            this.dtlistado_detalle.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPrecio_venta);
            this.groupBox2.Controls.Add(this.txtPrecio_compra);
            this.groupBox2.Controls.Add(this.txtStock_actual);
            this.groupBox2.Controls.Add(this.txtDescuento);
            this.groupBox2.Controls.Add(this.txtCantidad);
            this.groupBox2.Controls.Add(this.dtFecha_vencimiento);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtArticulo);
            this.groupBox2.Controls.Add(this.btnBuscar_articulo);
            this.groupBox2.Location = new System.Drawing.Point(27, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 71);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // btnQuitar
            // 
            this.btnQuitar.BackgroundImage = global::Presentacion.Properties.Resources.remover32;
            this.btnQuitar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitar.Location = new System.Drawing.Point(494, 38);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(24, 23);
            this.btnQuitar.TabIndex = 21;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::Presentacion.Properties.Resources.anadir32;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.Green;
            this.btnAgregar.Location = new System.Drawing.Point(494, 15);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(24, 23);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(195, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "P. Venta";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(195, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "P. Compra";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(333, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Descuento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Articulo";
            // 
            // txtPrecio_venta
            // 
            this.txtPrecio_venta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtPrecio_venta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio_venta.Location = new System.Drawing.Point(257, 45);
            this.txtPrecio_venta.Name = "txtPrecio_venta";
            this.txtPrecio_venta.Size = new System.Drawing.Size(68, 20);
            this.txtPrecio_venta.TabIndex = 14;
            // 
            // txtPrecio_compra
            // 
            this.txtPrecio_compra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtPrecio_compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio_compra.Location = new System.Drawing.Point(257, 19);
            this.txtPrecio_compra.Name = "txtPrecio_compra";
            this.txtPrecio_compra.Size = new System.Drawing.Size(68, 20);
            this.txtPrecio_compra.TabIndex = 14;
            // 
            // txtStock_actual
            // 
            this.txtStock_actual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtStock_actual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock_actual.Location = new System.Drawing.Point(107, 45);
            this.txtStock_actual.Name = "txtStock_actual";
            this.txtStock_actual.Size = new System.Drawing.Size(80, 20);
            this.txtStock_actual.TabIndex = 14;
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.Location = new System.Drawing.Point(414, 46);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(77, 20);
            this.txtDescuento.TabIndex = 14;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Location = new System.Drawing.Point(58, 45);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(43, 20);
            this.txtCantidad.TabIndex = 14;
            // 
            // dtFecha_vencimiento
            // 
            this.dtFecha_vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha_vencimiento.Location = new System.Drawing.Point(414, 19);
            this.dtFecha_vencimiento.Name = "dtFecha_vencimiento";
            this.dtFecha_vencimiento.Size = new System.Drawing.Size(77, 20);
            this.dtFecha_vencimiento.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(333, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "F. Vencimiento";
            // 
            // txtArticulo
            // 
            this.txtArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArticulo.Location = new System.Drawing.Point(58, 20);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(97, 20);
            this.txtArticulo.TabIndex = 14;
            // 
            // btnBuscar_articulo
            // 
            this.btnBuscar_articulo.BackgroundImage = global::Presentacion.Properties.Resources.buscar_categoria;
            this.btnBuscar_articulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar_articulo.Location = new System.Drawing.Point(161, 21);
            this.btnBuscar_articulo.Name = "btnBuscar_articulo";
            this.btnBuscar_articulo.Size = new System.Drawing.Size(26, 19);
            this.btnBuscar_articulo.TabIndex = 16;
            this.btnBuscar_articulo.UseVisualStyleBackColor = true;
            this.btnBuscar_articulo.Click += new System.EventHandler(this.BtnBuscar_articulo_Click);
            // 
            // txtIdarticulo
            // 
            this.txtIdarticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdarticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdarticulo.Location = new System.Drawing.Point(82, 278);
            this.txtIdarticulo.Name = "txtIdarticulo";
            this.txtIdarticulo.Size = new System.Drawing.Size(46, 20);
            this.txtIdarticulo.TabIndex = 15;
            // 
            // cmbTipo_comprobante
            // 
            this.cmbTipo_comprobante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cmbTipo_comprobante.FormattingEnabled = true;
            this.cmbTipo_comprobante.Items.AddRange(new object[] {
            "Ticket",
            "Boleta",
            "Factura",
            "G. Remision"});
            this.cmbTipo_comprobante.Location = new System.Drawing.Point(105, 45);
            this.cmbTipo_comprobante.Name = "cmbTipo_comprobante";
            this.cmbTipo_comprobante.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo_comprobante.TabIndex = 21;
            this.cmbTipo_comprobante.Text = "Ticket";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(105, 72);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(77, 20);
            this.dtFecha.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Fecha";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 17;
            // 
            // btnBuscar_cliente
            // 
            this.btnBuscar_cliente.BackgroundImage = global::Presentacion.Properties.Resources.buscar_categoria;
            this.btnBuscar_cliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar_cliente.Location = new System.Drawing.Point(525, 19);
            this.btnBuscar_cliente.Name = "btnBuscar_cliente";
            this.btnBuscar_cliente.Size = new System.Drawing.Size(26, 19);
            this.btnBuscar_cliente.TabIndex = 16;
            this.btnBuscar_cliente.UseVisualStyleBackColor = true;
            this.btnBuscar_cliente.Click += new System.EventHandler(this.BtnBuscar_cliente_Click);
            // 
            // txtIdcliente
            // 
            this.txtIdcliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdcliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdcliente.Location = new System.Drawing.Point(325, 19);
            this.txtIdcliente.Name = "txtIdcliente";
            this.txtIdcliente.Size = new System.Drawing.Size(46, 20);
            this.txtIdcliente.TabIndex = 15;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(377, 19);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(141, 20);
            this.txtCliente.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cliente";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(296, 278);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(215, 278);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNuevo.Location = new System.Drawing.Point(134, 278);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // txtSerie
            // 
            this.txtSerie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerie.Location = new System.Drawing.Point(325, 46);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(46, 20);
            this.txtSerie.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Comprobante";
            // 
            // txtIdventa
            // 
            this.txtIdventa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdventa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdventa.Location = new System.Drawing.Point(105, 19);
            this.txtIdventa.Name = "txtIdventa";
            this.txtIdventa.Size = new System.Drawing.Size(43, 20);
            this.txtIdventa.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 347);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.dtFecha_fin);
            this.tabPage1.Controls.Add(this.dtFecha_inicio);
            this.tabPage1.Controls.Add(this.dataListado);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.chkEliminar);
            this.tabPage1.Controls.Add(this.btnComprobante);
            this.tabPage1.Controls.Add(this.btnImprimir);
            this.tabPage1.Controls.Add(this.btnAnular);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(123, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Fecha Fin";
            // 
            // dtFecha_fin
            // 
            this.dtFecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha_fin.Location = new System.Drawing.Point(126, 30);
            this.dtFecha_fin.Name = "dtFecha_fin";
            this.dtFecha_fin.Size = new System.Drawing.Size(82, 20);
            this.dtFecha_fin.TabIndex = 9;
            // 
            // dtFecha_inicio
            // 
            this.dtFecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha_inicio.Location = new System.Drawing.Point(16, 30);
            this.dtFecha_inicio.Name = "dtFecha_inicio";
            this.dtFecha_inicio.Size = new System.Drawing.Size(82, 20);
            this.dtFecha_inicio.TabIndex = 8;
            // 
            // dataListado
            // 
            this.dataListado.AllowUserToAddRows = false;
            this.dataListado.AllowUserToDeleteRows = false;
            this.dataListado.AllowUserToOrderColumns = true;
            this.dataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eliminar});
            this.dataListado.Location = new System.Drawing.Point(4, 79);
            this.dataListado.MultiSelect = false;
            this.dataListado.Name = "dataListado";
            this.dataListado.ReadOnly = true;
            this.dataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListado.Size = new System.Drawing.Size(585, 235);
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
            this.lblTotal.Location = new System.Drawing.Point(374, 56);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "label3";
            // 
            // chkEliminar
            // 
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Location = new System.Drawing.Point(16, 56);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(62, 17);
            this.chkEliminar.TabIndex = 5;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            this.chkEliminar.CheckedChanged += new System.EventHandler(this.ChkEliminar_CheckedChanged);
            // 
            // btnComprobante
            // 
            this.btnComprobante.Location = new System.Drawing.Point(415, 28);
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.Size = new System.Drawing.Size(83, 23);
            this.btnComprobante.TabIndex = 3;
            this.btnComprobante.Text = "&Comprobante";
            this.btnComprobante.UseVisualStyleBackColor = true;
            this.btnComprobante.Click += new System.EventHandler(this.BtnComprobante_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(504, 27);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnAnular
            // 
            this.btnAnular.Location = new System.Drawing.Point(334, 27);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(75, 23);
            this.btnAnular.TabIndex = 2;
            this.btnAnular.Text = "&Eliminar";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.BtnAnular_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(253, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Inicio";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // frmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(613, 362);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmVenta";
            this.Text = ".:. Mantenimiento de Ventas .:.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVenta_FormClosing);
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtlistado_detalle)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIgv;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCorrelativo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotal_pagado;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dtlistado_detalle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecio_venta;
        private System.Windows.Forms.TextBox txtPrecio_compra;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DateTimePicker dtFecha_vencimiento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Button btnBuscar_articulo;
        private System.Windows.Forms.TextBox txtIdarticulo;
        private System.Windows.Forms.ComboBox cmbTipo_comprobante;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscar_cliente;
        private System.Windows.Forms.TextBox txtIdcliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIdventa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFecha_fin;
        private System.Windows.Forms.DateTimePicker dtFecha_inicio;
        private System.Windows.Forms.DataGridView dataListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eliminar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Button btnComprobante;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtStock_actual;
        private System.Windows.Forms.TextBox txtDescuento;
    }
}