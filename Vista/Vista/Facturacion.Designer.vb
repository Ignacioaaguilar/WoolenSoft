﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Facturacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Facturacion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProgressBarFacturacion = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripRegistrarFactura = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripBuscar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSalir = New System.Windows.Forms.ToolStripButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvFacturacion = New System.Windows.Forms.DataGridView
        Me.Eliminar = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
        Me.Tipo_Unidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IdArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnBuscarCliente = New System.Windows.Forms.Button
        Me.btnBuscarArticulo = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtApellido = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtCelular = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCondIVA = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMail = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtLimiteCC = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbCondicionPago = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtPorcDesc = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblCodN = New System.Windows.Forms.Label
        Me.lblIdComprobante = New System.Windows.Forms.Label
        Me.mtFecha = New System.Windows.Forms.MaskedTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cbListaPrecio = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtnumeroComprobante = New System.Windows.Forms.TextBox
        Me.txtNroSucursal = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblTipoComprobante = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnLimpiarBuff = New System.Windows.Forms.Button
        Me.btnCerrar = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Estable = New System.Windows.Forms.Label
        Me.txtBalanza = New System.Windows.Forms.TextBox
        Me.btnAbrir = New System.Windows.Forms.Button
        Me.AxMSComm2 = New AxMSCommLib.AxMSComm
        Me.txtBusquedaArticulo = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Neto = New System.Windows.Forms.Label
        Me.txtNeto = New System.Windows.Forms.TextBox
        Me.txtDescuento = New System.Windows.Forms.TextBox
        Me.txtIVA21 = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.lbl21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelEx4 = New DevComponents.DotNetBar.PanelEx
        Me.txtIVA27 = New System.Windows.Forms.TextBox
        Me.lbl27 = New System.Windows.Forms.Label
        Me.txtIVA105 = New System.Windows.Forms.TextBox
        Me.lbl105 = New System.Windows.Forms.Label
        Me.TxtSubTotal = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.AxMSComm2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx4.SuspendLayout()
        Me.SuspendLayout()
        '
        'VisualStyler1
        '
        Me.VisualStyler1.HostForm = Me
        Me.VisualStyler1.License = CType(resources.GetObject("VisualStyler1.License"), SkinSoft.VisualStyler.Licensing.VisualStylerLicense)
        Me.VisualStyler1.ShadowStyle = SkinSoft.VisualStyler.ShadowStyle.Bold
        Me.VisualStyler1.ToolStripStyle = SkinSoft.VisualStyler.ToolStripRenderStyle.Professional
        Me.VisualStyler1.LoadVisualStyle(Nothing, "Office2007 (Blue).vssf")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBarFacturacion, Me.ToolStripSeparator1, Me.ToolStripRegistrarFactura, Me.ToolStripSeparator2, Me.ToolStripBuscar, Me.ToolStripSeparator3, Me.ToolStripSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(905, 45)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProgressBarFacturacion
        '
        Me.ProgressBarFacturacion.Name = "ProgressBarFacturacion"
        Me.ProgressBarFacturacion.Size = New System.Drawing.Size(117, 42)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripRegistrarFactura
        '
        Me.ToolStripRegistrarFactura.AutoToolTip = False
        Me.ToolStripRegistrarFactura.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripRegistrarFactura.Image = CType(resources.GetObject("ToolStripRegistrarFactura.Image"), System.Drawing.Image)
        Me.ToolStripRegistrarFactura.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripRegistrarFactura.Name = "ToolStripRegistrarFactura"
        Me.ToolStripRegistrarFactura.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripRegistrarFactura, New DevComponents.DotNetBar.SuperTooltipInfo("Registrar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(70, 21)))
        Me.ToolStripRegistrarFactura.Text = "Registrar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripBuscar
        '
        Me.ToolStripBuscar.AutoToolTip = False
        Me.ToolStripBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripBuscar.Image = CType(resources.GetObject("ToolStripBuscar.Image"), System.Drawing.Image)
        Me.ToolStripBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripBuscar.Name = "ToolStripBuscar"
        Me.ToolStripBuscar.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripBuscar, New DevComponents.DotNetBar.SuperTooltipInfo("Buscar Documento", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(113, 21)))
        Me.ToolStripBuscar.Text = "Buscar Documento"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripSalir
        '
        Me.ToolStripSalir.AutoToolTip = False
        Me.ToolStripSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSalir.Image = CType(resources.GetObject("ToolStripSalir.Image"), System.Drawing.Image)
        Me.ToolStripSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSalir.Name = "ToolStripSalir"
        Me.ToolStripSalir.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripSalir, New DevComponents.DotNetBar.SuperTooltipInfo("Salir", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.ToolStripSalir.Text = "Salir"
        '
        'dgvFacturacion
        '
        Me.dgvFacturacion.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.NullValue = Nothing
        Me.dgvFacturacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFacturacion.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvFacturacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFacturacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eliminar, Me.Tipo_Unidad, Me.IdArticulo, Me.Descripcion, Me.Cantidad, Me.PrecioUnitario, Me.Importe})
        Me.dgvFacturacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dgvFacturacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvFacturacion.Location = New System.Drawing.Point(7, 312)
        Me.dgvFacturacion.Name = "dgvFacturacion"
        Me.dgvFacturacion.ReadOnly = True
        Me.dgvFacturacion.RowHeadersVisible = False
        Me.dgvFacturacion.Size = New System.Drawing.Size(884, 238)
        Me.dgvFacturacion.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.dgvFacturacion, "Eliminar")
        '
        'Eliminar
        '
        Me.Eliminar.FillWeight = 52.0!
        Me.Eliminar.HeaderText = "Eliminar"
        Me.Eliminar.Image = CType(resources.GetObject("Eliminar.Image"), System.Drawing.Image)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.ReadOnly = True
        Me.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Eliminar.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 12, 12, 2)
        Me.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Eliminar.Text = Nothing
        Me.Eliminar.ToolTipText = "Eliminar"
        Me.Eliminar.Width = 52
        '
        'Tipo_Unidad
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray
        Me.Tipo_Unidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.Tipo_Unidad.FillWeight = 40.0!
        Me.Tipo_Unidad.HeaderText = "T.U"
        Me.Tipo_Unidad.MaxInputLength = 5
        Me.Tipo_Unidad.Name = "Tipo_Unidad"
        Me.Tipo_Unidad.ReadOnly = True
        Me.Tipo_Unidad.Width = 40
        '
        'IdArticulo
        '
        Me.IdArticulo.HeaderText = "Articulo"
        Me.IdArticulo.MaxInputLength = 7
        Me.IdArticulo.Name = "IdArticulo"
        Me.IdArticulo.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.FillWeight = 400.0!
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MaxInputLength = 400
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 400
        '
        'Cantidad
        '
        Me.Cantidad.FillWeight = 89.0!
        Me.Cantidad.HeaderText = "Cantidad/Kgs"
        Me.Cantidad.MaxInputLength = 5
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 89
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.HeaderText = "Precio Unitario"
        Me.PrecioUnitario.MaxInputLength = 7
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        '
        'Importe
        '
        Me.Importe.FillWeight = 101.0!
        Me.Importe.HeaderText = "Importe"
        Me.Importe.MaxInputLength = 7
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        Me.Importe.Width = 101
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarCliente.FlatAppearance.BorderSize = 0
        Me.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarCliente.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCliente.Location = New System.Drawing.Point(168, 23)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(38, 24)
        Me.SuperTooltip1.SetSuperTooltip(Me.btnBuscarCliente, New DevComponents.DotNetBar.SuperTooltipInfo("Buscar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.btnBuscarCliente.TabIndex = 2
        Me.btnBuscarCliente.UseVisualStyleBackColor = True
        '
        'btnBuscarArticulo
        '
        Me.btnBuscarArticulo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBuscarArticulo.BackColor = System.Drawing.Color.Transparent
        Me.btnBuscarArticulo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarArticulo.FlatAppearance.BorderSize = 0
        Me.btnBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarArticulo.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscarArticulo.Image = CType(resources.GetObject("btnBuscarArticulo.Image"), System.Drawing.Image)
        Me.btnBuscarArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarArticulo.Location = New System.Drawing.Point(598, 44)
        Me.btnBuscarArticulo.Name = "btnBuscarArticulo"
        Me.btnBuscarArticulo.Size = New System.Drawing.Size(43, 23)
        Me.SuperTooltip1.SetSuperTooltip(Me.btnBuscarArticulo, New DevComponents.DotNetBar.SuperTooltipInfo("Buscar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.btnBuscarArticulo.TabIndex = 2
        Me.btnBuscarArticulo.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo Cliente:"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigoCliente.Location = New System.Drawing.Point(109, 23)
        Me.txtCodigoCliente.MaxLength = 6
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(56, 23)
        Me.txtCodigoCliente.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(230, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNombre.Location = New System.Drawing.Point(285, 24)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(126, 23)
        Me.txtNombre.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(452, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Apellido:"
        '
        'txtApellido
        '
        Me.txtApellido.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtApellido.Location = New System.Drawing.Point(506, 24)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.ReadOnly = True
        Me.txtApellido.Size = New System.Drawing.Size(129, 23)
        Me.txtApellido.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(673, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Direccion:"
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDireccion.Location = New System.Drawing.Point(736, 24)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(129, 23)
        Me.txtDireccion.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(52, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Celular:"
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCelular.Location = New System.Drawing.Point(100, 61)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.ReadOnly = True
        Me.txtCelular.Size = New System.Drawing.Size(126, 23)
        Me.txtCelular.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(260, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Telefono:"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTelefono.Location = New System.Drawing.Point(318, 60)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(129, 23)
        Me.txtTelefono.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(478, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Cond Iva:"
        '
        'txtCondIVA
        '
        Me.txtCondIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCondIVA.Location = New System.Drawing.Point(536, 59)
        Me.txtCondIVA.Name = "txtCondIVA"
        Me.txtCondIVA.ReadOnly = True
        Me.txtCondIVA.Size = New System.Drawing.Size(129, 23)
        Me.txtCondIVA.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(689, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Mail:"
        '
        'txtMail
        '
        Me.txtMail.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMail.Location = New System.Drawing.Point(726, 60)
        Me.txtMail.Name = "txtMail"
        Me.txtMail.ReadOnly = True
        Me.txtMail.Size = New System.Drawing.Size(139, 23)
        Me.txtMail.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(167, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Limite C/C:"
        '
        'txtLimiteCC
        '
        Me.txtLimiteCC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLimiteCC.Location = New System.Drawing.Point(235, 97)
        Me.txtLimiteCC.Name = "txtLimiteCC"
        Me.txtLimiteCC.ReadOnly = True
        Me.txtLimiteCC.Size = New System.Drawing.Size(126, 23)
        Me.txtLimiteCC.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(471, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(91, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Condicion Pago:"
        Me.Label10.Visible = False
        '
        'cbCondicionPago
        '
        Me.cbCondicionPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCondicionPago.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbCondicionPago.FormattingEnabled = True
        Me.cbCondicionPago.Items.AddRange(New Object() {"Efectivo", "Cuenta Corriente", "Cheque", "Tarjeta Debito", "Tarjeta Credito"})
        Me.cbCondicionPago.Location = New System.Drawing.Point(561, 97)
        Me.cbCondicionPago.Name = "cbCondicionPago"
        Me.cbCondicionPago.Size = New System.Drawing.Size(121, 23)
        Me.cbCondicionPago.TabIndex = 20
        Me.cbCondicionPago.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TxtPorcDesc)
        Me.GroupBox1.Controls.Add(Me.cbCondicionPago)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtLimiteCC)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtMail)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtCondIVA)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtTelefono)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCelular)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtDireccion)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtApellido)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnBuscarCliente)
        Me.GroupBox1.Controls.Add(Me.txtCodigoCliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(881, 124)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "XC"
        '
        'TxtPorcDesc
        '
        Me.TxtPorcDesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtPorcDesc.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPorcDesc.ForeColor = System.Drawing.Color.Red
        Me.TxtPorcDesc.Location = New System.Drawing.Point(785, 94)
        Me.TxtPorcDesc.MaxLength = 5
        Me.TxtPorcDesc.Name = "TxtPorcDesc"
        Me.TxtPorcDesc.Size = New System.Drawing.Size(52, 24)
        Me.TxtPorcDesc.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(722, 97)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 19)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "% Desc:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lblCodN)
        Me.GroupBox2.Controls.Add(Me.lblIdComprobante)
        Me.GroupBox2.Controls.Add(Me.mtFecha)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.cbListaPrecio)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtnumeroComprobante)
        Me.GroupBox2.Controls.Add(Me.txtNroSucursal)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.lblTipoComprobante)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(881, 72)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "XC"
        '
        'lblCodN
        '
        Me.lblCodN.AutoSize = True
        Me.lblCodN.Location = New System.Drawing.Point(27, 54)
        Me.lblCodN.Name = "lblCodN"
        Me.lblCodN.Size = New System.Drawing.Size(46, 15)
        Me.lblCodN.TabIndex = 11
        Me.lblCodN.Text = "Cod N°:"
        '
        'lblIdComprobante
        '
        Me.lblIdComprobante.AutoSize = True
        Me.lblIdComprobante.Location = New System.Drawing.Point(72, 54)
        Me.lblIdComprobante.Name = "lblIdComprobante"
        Me.lblIdComprobante.Size = New System.Drawing.Size(0, 15)
        Me.lblIdComprobante.TabIndex = 10
        '
        'mtFecha
        '
        Me.mtFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mtFecha.Location = New System.Drawing.Point(751, 34)
        Me.mtFecha.Mask = "00/00/0000"
        Me.mtFecha.Name = "mtFecha"
        Me.mtFecha.Size = New System.Drawing.Size(80, 23)
        Me.mtFecha.TabIndex = 9
        Me.mtFecha.ValidatingType = GetType(Date)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(705, 38)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 16)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Fecha:"
        '
        'cbListaPrecio
        '
        Me.cbListaPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbListaPrecio.FormattingEnabled = True
        Me.cbListaPrecio.Location = New System.Drawing.Point(435, 34)
        Me.cbListaPrecio.Name = "cbListaPrecio"
        Me.cbListaPrecio.Size = New System.Drawing.Size(121, 23)
        Me.cbListaPrecio.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(359, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 16)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Lista Precio:"
        '
        'txtnumeroComprobante
        '
        Me.txtnumeroComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtnumeroComprobante.Location = New System.Drawing.Point(235, 34)
        Me.txtnumeroComprobante.Name = "txtnumeroComprobante"
        Me.txtnumeroComprobante.ReadOnly = True
        Me.txtnumeroComprobante.Size = New System.Drawing.Size(100, 23)
        Me.txtnumeroComprobante.TabIndex = 4
        '
        'txtNroSucursal
        '
        Me.txtNroSucursal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNroSucursal.Location = New System.Drawing.Point(185, 34)
        Me.txtNroSucursal.Name = "txtNroSucursal"
        Me.txtNroSucursal.ReadOnly = True
        Me.txtNroSucursal.Size = New System.Drawing.Size(46, 23)
        Me.txtNroSucursal.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(155, 37)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 16)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "N°:"
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoComprobante.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoComprobante.Location = New System.Drawing.Point(27, 37)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(0, 16)
        Me.lblTipoComprobante.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnLimpiarBuff)
        Me.GroupBox3.Controls.Add(Me.btnCerrar)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.btnAbrir)
        Me.GroupBox3.Controls.Add(Me.btnBuscarArticulo)
        Me.GroupBox3.Controls.Add(Me.AxMSComm2)
        Me.GroupBox3.Controls.Add(Me.txtBusquedaArticulo)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 213)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(881, 87)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Tag = "XC"
        '
        'btnLimpiarBuff
        '
        Me.btnLimpiarBuff.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLimpiarBuff.Location = New System.Drawing.Point(160, 22)
        Me.btnLimpiarBuff.Name = "btnLimpiarBuff"
        Me.btnLimpiarBuff.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpiarBuff.TabIndex = 5
        Me.btnLimpiarBuff.Text = "Limpiar Buff"
        Me.btnLimpiarBuff.UseVisualStyleBackColor = True
        Me.btnLimpiarBuff.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(56, 46)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(99, 23)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "Cerrar Puertos"
        Me.btnCerrar.UseVisualStyleBackColor = True
        Me.btnCerrar.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.Estable)
        Me.GroupBox4.Controls.Add(Me.txtBalanza)
        Me.GroupBox4.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(705, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(161, 69)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Balanza"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(119, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(26, 16)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Kgs"
        '
        'Estable
        '
        Me.Estable.Location = New System.Drawing.Point(31, 20)
        Me.Estable.Name = "Estable"
        Me.Estable.Size = New System.Drawing.Size(83, 15)
        Me.Estable.TabIndex = 1
        Me.Estable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtBalanza
        '
        Me.txtBalanza.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBalanza.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalanza.Location = New System.Drawing.Point(29, 37)
        Me.txtBalanza.MaxLength = 8
        Me.txtBalanza.Name = "txtBalanza"
        Me.txtBalanza.Size = New System.Drawing.Size(88, 23)
        Me.txtBalanza.TabIndex = 0
        '
        'btnAbrir
        '
        Me.btnAbrir.Location = New System.Drawing.Point(54, 22)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(99, 23)
        Me.btnAbrir.TabIndex = 3
        Me.btnAbrir.Text = "Abrir Puertos"
        Me.btnAbrir.UseVisualStyleBackColor = True
        Me.btnAbrir.Visible = False
        '
        'AxMSComm2
        '
        Me.AxMSComm2.Enabled = True
        Me.AxMSComm2.Location = New System.Drawing.Point(10, 34)
        Me.AxMSComm2.Name = "AxMSComm2"
        Me.AxMSComm2.OcxState = CType(resources.GetObject("AxMSComm2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxMSComm2.Size = New System.Drawing.Size(38, 38)
        Me.AxMSComm2.TabIndex = 2
        '
        'txtBusquedaArticulo
        '
        Me.txtBusquedaArticulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBusquedaArticulo.Location = New System.Drawing.Point(256, 44)
        Me.txtBusquedaArticulo.MaxLength = 20
        Me.txtBusquedaArticulo.Name = "txtBusquedaArticulo"
        Me.txtBusquedaArticulo.Size = New System.Drawing.Size(338, 23)
        Me.txtBusquedaArticulo.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(356, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(156, 19)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Busqueda de Articulos "
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Borrar.png")
        '
        'Neto
        '
        Me.Neto.AutoSize = True
        Me.Neto.BackColor = System.Drawing.Color.Transparent
        Me.Neto.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Neto.Location = New System.Drawing.Point(7, 563)
        Me.Neto.Name = "Neto"
        Me.Neto.Size = New System.Drawing.Size(46, 19)
        Me.Neto.TabIndex = 7
        Me.Neto.Text = "Neto:"
        '
        'txtNeto
        '
        Me.txtNeto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNeto.Location = New System.Drawing.Point(52, 560)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(76, 23)
        Me.txtNeto.TabIndex = 8
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescuento.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.ForeColor = System.Drawing.Color.Red
        Me.txtDescuento.Location = New System.Drawing.Point(173, 560)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(87, 24)
        Me.txtDescuento.TabIndex = 9
        '
        'txtIVA21
        '
        Me.txtIVA21.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIVA21.Location = New System.Drawing.Point(469, 560)
        Me.txtIVA21.Name = "txtIVA21"
        Me.txtIVA21.ReadOnly = True
        Me.txtIVA21.Size = New System.Drawing.Size(59, 23)
        Me.txtIVA21.TabIndex = 10
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(796, 556)
        Me.txtTotal.Multiline = True
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(92, 29)
        Me.txtTotal.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(130, 563)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 19)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Desc:"
        '
        'lbl21
        '
        Me.lbl21.AutoSize = True
        Me.lbl21.BackColor = System.Drawing.Color.Transparent
        Me.lbl21.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl21.Location = New System.Drawing.Point(428, 562)
        Me.lbl21.Name = "lbl21"
        Me.lbl21.Size = New System.Drawing.Size(42, 19)
        Me.lbl21.TabIndex = 13
        Me.lbl21.Text = "21%:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(746, 562)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 19)
        Me.Label20.TabIndex = 14
        Me.Label20.Text = "Total:"
        '
        'Timer1
        '
        '
        'SerialPort1
        '
        Me.SerialPort1.Handshake = System.IO.Ports.Handshake.XOnXOff
        Me.SerialPort1.PortName = "COM6"
        Me.SerialPort1.ReadBufferSize = 4024
        '
        'Timer2
        '
        Me.Timer2.Interval = 10
        '
        'PanelEx4
        '
        Me.PanelEx4.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx4.Controls.Add(Me.txtIVA27)
        Me.PanelEx4.Controls.Add(Me.lbl27)
        Me.PanelEx4.Controls.Add(Me.txtIVA105)
        Me.PanelEx4.Controls.Add(Me.lbl105)
        Me.PanelEx4.Controls.Add(Me.txtTotal)
        Me.PanelEx4.Controls.Add(Me.TxtSubTotal)
        Me.PanelEx4.Controls.Add(Me.Label11)
        Me.PanelEx4.Controls.Add(Me.txtNeto)
        Me.PanelEx4.Controls.Add(Me.GroupBox3)
        Me.PanelEx4.Controls.Add(Me.txtDescuento)
        Me.PanelEx4.Controls.Add(Me.txtIVA21)
        Me.PanelEx4.Controls.Add(Me.GroupBox1)
        Me.PanelEx4.Controls.Add(Me.GroupBox2)
        Me.PanelEx4.Controls.Add(Me.Label18)
        Me.PanelEx4.Controls.Add(Me.lbl21)
        Me.PanelEx4.Controls.Add(Me.Neto)
        Me.PanelEx4.Controls.Add(Me.Label20)
        Me.PanelEx4.Controls.Add(Me.dgvFacturacion)
        Me.PanelEx4.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx4.Location = New System.Drawing.Point(2, 47)
        Me.PanelEx4.Name = "PanelEx4"
        Me.PanelEx4.Size = New System.Drawing.Size(902, 597)
        Me.PanelEx4.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx4.Style.GradientAngle = 90
        Me.PanelEx4.TabIndex = 27
        '
        'txtIVA27
        '
        Me.txtIVA27.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIVA27.Location = New System.Drawing.Point(687, 559)
        Me.txtIVA27.Name = "txtIVA27"
        Me.txtIVA27.ReadOnly = True
        Me.txtIVA27.Size = New System.Drawing.Size(51, 23)
        Me.txtIVA27.TabIndex = 19
        '
        'lbl27
        '
        Me.lbl27.AutoSize = True
        Me.lbl27.BackColor = System.Drawing.Color.Transparent
        Me.lbl27.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl27.Location = New System.Drawing.Point(646, 562)
        Me.lbl27.Name = "lbl27"
        Me.lbl27.Size = New System.Drawing.Size(42, 19)
        Me.lbl27.TabIndex = 20
        Me.lbl27.Text = "27%:"
        '
        'txtIVA105
        '
        Me.txtIVA105.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIVA105.Location = New System.Drawing.Point(585, 559)
        Me.txtIVA105.Name = "txtIVA105"
        Me.txtIVA105.ReadOnly = True
        Me.txtIVA105.Size = New System.Drawing.Size(59, 23)
        Me.txtIVA105.TabIndex = 17
        '
        'lbl105
        '
        Me.lbl105.AutoSize = True
        Me.lbl105.BackColor = System.Drawing.Color.Transparent
        Me.lbl105.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl105.Location = New System.Drawing.Point(530, 561)
        Me.lbl105.Name = "lbl105"
        Me.lbl105.Size = New System.Drawing.Size(56, 19)
        Me.lbl105.TabIndex = 18
        Me.lbl105.Text = "10.5%:"
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TxtSubTotal.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotal.ForeColor = System.Drawing.Color.Black
        Me.TxtSubTotal.Location = New System.Drawing.Point(339, 559)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.ReadOnly = True
        Me.TxtSubTotal.Size = New System.Drawing.Size(87, 24)
        Me.TxtSubTotal.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(262, 563)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 19)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Sub Total:"
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue)
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'Facturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 649)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PanelEx4)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(913, 683)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(913, 683)
        Me.Name = "Facturacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Facturacion"
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.AxMSComm2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx4.ResumeLayout(False)
        Me.PanelEx4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProgressBarFacturacion As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripRegistrarFactura As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbCondicionPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLimiteCC As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMail As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCondIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbListaPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtnumeroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents txtNroSucursal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTipoComprobante As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarArticulo As System.Windows.Forms.Button
    Friend WithEvents dgvFacturacion As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtIVA21 As System.Windows.Forms.TextBox
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents Neto As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lbl21 As System.Windows.Forms.Label
    Public WithEvents txtBusquedaArticulo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBalanza As System.Windows.Forms.TextBox
    Friend WithEvents Estable As System.Windows.Forms.Label
    Friend WithEvents AxMSComm2 As AxMSCommLib.AxMSComm
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarBuff As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lblIdComprobante As System.Windows.Forms.Label
    Friend WithEvents lblCodN As System.Windows.Forms.Label
    Friend WithEvents ToolStripBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelEx4 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Eliminar As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents Tipo_Unidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtPorcDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtIVA105 As System.Windows.Forms.TextBox
    Friend WithEvents lbl105 As System.Windows.Forms.Label
    Friend WithEvents txtIVA27 As System.Windows.Forms.TextBox
    Friend WithEvents lbl27 As System.Windows.Forms.Label
    Friend WithEvents mtFecha As System.Windows.Forms.MaskedTextBox
End Class
