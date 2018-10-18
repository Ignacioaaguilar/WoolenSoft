<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaCreditoProveedores
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotaCreditoProveedores))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProgressBarFacturacionProveedor = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButtonRegistrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButtonSalir = New System.Windows.Forms.ToolStripButton
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.dgvNotaCreditoProveedor = New System.Windows.Forms.DataGridView
        Me.Eliminar = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
        Me.TipoUnid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodigoProductoProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodigoArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.txtDescuento = New System.Windows.Forms.TextBox
        Me.txtIVa = New System.Windows.Forms.TextBox
        Me.txtSubTotal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnBuscarProveedor = New System.Windows.Forms.Button
        Me.txtLimiteCC = New System.Windows.Forms.TextBox
        Me.txtCondIva = New System.Windows.Forms.TextBox
        Me.txtCelular = New System.Windows.Forms.TextBox
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.txtMail = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCodigoPostal = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtRazonSocial = New System.Windows.Forms.TextBox
        Me.txtCodigoProveedor = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblCodN = New System.Windows.Forms.Label
        Me.tbNumeroComprobante = New System.Windows.Forms.TextBox
        Me.lblIdComprobante = New System.Windows.Forms.Label
        Me.tbPuntoVenta = New System.Windows.Forms.TextBox
        Me.lblTipoComprobante = New System.Windows.Forms.Label
        Me.mtFecha = New System.Windows.Forms.MaskedTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvNotaCreditoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBarFacturacionProveedor, Me.ToolStripSeparator1, Me.ToolStripButtonRegistrar, Me.ToolStripSeparator2, Me.ToolStripButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(909, 45)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProgressBarFacturacionProveedor
        '
        Me.ProgressBarFacturacionProveedor.Name = "ProgressBarFacturacionProveedor"
        Me.ProgressBarFacturacionProveedor.Size = New System.Drawing.Size(117, 42)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripButtonRegistrar
        '
        Me.ToolStripButtonRegistrar.AutoToolTip = False
        Me.ToolStripButtonRegistrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonRegistrar.Image = CType(resources.GetObject("ToolStripButtonRegistrar.Image"), System.Drawing.Image)
        Me.ToolStripButtonRegistrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonRegistrar.Name = "ToolStripButtonRegistrar"
        Me.ToolStripButtonRegistrar.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripButtonRegistrar, New DevComponents.DotNetBar.SuperTooltipInfo("Registrar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(62, 21)))
        Me.ToolStripButtonRegistrar.Text = "Registrar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripButtonSalir
        '
        Me.ToolStripButtonSalir.AutoToolTip = False
        Me.ToolStripButtonSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonSalir.Image = CType(resources.GetObject("ToolStripButtonSalir.Image"), System.Drawing.Image)
        Me.ToolStripButtonSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonSalir.Name = "ToolStripButtonSalir"
        Me.ToolStripButtonSalir.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripButtonSalir, New DevComponents.DotNetBar.SuperTooltipInfo("Salir", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(62, 21)))
        Me.ToolStripButtonSalir.Text = "Salir"
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue)
        '
        'dgvNotaCreditoProveedor
        '
        Me.dgvNotaCreditoProveedor.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvNotaCreditoProveedor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvNotaCreditoProveedor.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvNotaCreditoProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotaCreditoProveedor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eliminar, Me.TipoUnid, Me.CodigoProductoProveedor, Me.CodigoArticulo, Me.Descripcion, Me.Cantidad, Me.PrecioUnitario, Me.Importe})
        Me.HelpProvider1.SetHelpString(Me.dgvNotaCreditoProveedor, "Para Agregar una Nueva Fila, Presione la Tecla Enter, cuando este posisionado en " & _
                "la columna Importe.")
        Me.dgvNotaCreditoProveedor.Location = New System.Drawing.Point(9, 210)
        Me.dgvNotaCreditoProveedor.Name = "dgvNotaCreditoProveedor"
        Me.dgvNotaCreditoProveedor.RowHeadersVisible = False
        Me.HelpProvider1.SetShowHelp(Me.dgvNotaCreditoProveedor, True)
        Me.dgvNotaCreditoProveedor.Size = New System.Drawing.Size(887, 221)
        Me.SuperTooltip1.SetSuperTooltip(Me.dgvNotaCreditoProveedor, New DevComponents.DotNetBar.SuperTooltipInfo("Para Agregar una Nueva Fila, Presione la Tecla Enter, cuando este posisionado en " & _
                    "la columna Importe.", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue))
        Me.dgvNotaCreditoProveedor.TabIndex = 2
        '
        'Eliminar
        '
        Me.Eliminar.FillWeight = 60.0!
        Me.Eliminar.HeaderText = "Eliminar"
        Me.Eliminar.Image = CType(resources.GetObject("Eliminar.Image"), System.Drawing.Image)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Eliminar.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 12, 12, 2)
        Me.Eliminar.Text = Nothing
        Me.Eliminar.ToolTipText = "Eliminar"
        Me.Eliminar.Width = 60
        '
        'TipoUnid
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        Me.TipoUnid.DefaultCellStyle = DataGridViewCellStyle2
        Me.TipoUnid.FillWeight = 40.0!
        Me.TipoUnid.HeaderText = "T.U"
        Me.TipoUnid.MaxInputLength = 5
        Me.TipoUnid.Name = "TipoUnid"
        Me.TipoUnid.ReadOnly = True
        Me.TipoUnid.Width = 40
        '
        'CodigoProductoProveedor
        '
        Me.CodigoProductoProveedor.FillWeight = 93.0!
        Me.CodigoProductoProveedor.HeaderText = "C. Prod Prov"
        Me.CodigoProductoProveedor.MaxInputLength = 7
        Me.CodigoProductoProveedor.Name = "CodigoProductoProveedor"
        Me.CodigoProductoProveedor.Width = 93
        '
        'CodigoArticulo
        '
        Me.CodigoArticulo.FillWeight = 94.0!
        Me.CodigoArticulo.HeaderText = "Cod Articulo"
        Me.CodigoArticulo.MaxInputLength = 7
        Me.CodigoArticulo.Name = "CodigoArticulo"
        Me.CodigoArticulo.Width = 94
        '
        'Descripcion
        '
        Me.Descripcion.FillWeight = 310.0!
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.MaxInputLength = 100
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 310
        '
        'Cantidad
        '
        Me.Cantidad.FillWeight = 75.0!
        Me.Cantidad.HeaderText = "Und/Kgs"
        Me.Cantidad.MaxInputLength = 7
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 75
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.HeaderText = "P. Unitario"
        Me.PrecioUnitario.MaxInputLength = 7
        Me.PrecioUnitario.Name = "PrecioUnitario"
        '
        'Importe
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Importe.DefaultCellStyle = DataGridViewCellStyle3
        Me.Importe.HeaderText = "Importe"
        Me.Importe.MaxInputLength = 7
        Me.Importe.Name = "Importe"
        Me.Importe.ReadOnly = True
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.txtTotal)
        Me.PanelEx1.Controls.Add(Me.txtDescuento)
        Me.PanelEx1.Controls.Add(Me.txtIVa)
        Me.PanelEx1.Controls.Add(Me.txtSubTotal)
        Me.PanelEx1.Controls.Add(Me.Label4)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.Controls.Add(Me.dgvNotaCreditoProveedor)
        Me.PanelEx1.Controls.Add(Me.GroupBox2)
        Me.PanelEx1.Controls.Add(Me.GroupBox1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(0, 48)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(906, 470)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotal.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(757, 437)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 26)
        Me.txtTotal.TabIndex = 10
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescuento.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.ForeColor = System.Drawing.Color.Red
        Me.txtDescuento.Location = New System.Drawing.Point(549, 440)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(100, 23)
        Me.txtDescuento.TabIndex = 9
        '
        'txtIVa
        '
        Me.txtIVa.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIVa.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVa.Location = New System.Drawing.Point(329, 440)
        Me.txtIVa.Name = "txtIVa"
        Me.txtIVa.ReadOnly = True
        Me.txtIVa.Size = New System.Drawing.Size(100, 23)
        Me.txtIVa.TabIndex = 8
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSubTotal.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.Location = New System.Drawing.Point(122, 440)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(100, 23)
        Me.txtSubTotal.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(703, 442)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 19)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Total:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(465, 442)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Descuento:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(282, 442)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "IVA:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 442)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sub Total:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBuscarProveedor)
        Me.GroupBox2.Controls.Add(Me.txtLimiteCC)
        Me.GroupBox2.Controls.Add(Me.txtCondIva)
        Me.GroupBox2.Controls.Add(Me.txtCelular)
        Me.GroupBox2.Controls.Add(Me.txtTelefono)
        Me.GroupBox2.Controls.Add(Me.txtMail)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtCodigoPostal)
        Me.GroupBox2.Controls.Add(Me.txtDireccion)
        Me.GroupBox2.Controls.Add(Me.txtRazonSocial)
        Me.GroupBox2.Controls.Add(Me.txtCodigoProveedor)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(888, 96)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "XC"
        '
        'btnBuscarProveedor
        '
        Me.btnBuscarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarProveedor.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarProveedor.ForeColor = System.Drawing.Color.Transparent
        Me.btnBuscarProveedor.Image = CType(resources.GetObject("btnBuscarProveedor.Image"), System.Drawing.Image)
        Me.btnBuscarProveedor.Location = New System.Drawing.Point(175, 22)
        Me.btnBuscarProveedor.Name = "btnBuscarProveedor"
        Me.btnBuscarProveedor.Size = New System.Drawing.Size(33, 23)
        Me.btnBuscarProveedor.TabIndex = 28
        Me.btnBuscarProveedor.UseVisualStyleBackColor = True
        '
        'txtLimiteCC
        '
        Me.txtLimiteCC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLimiteCC.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLimiteCC.Location = New System.Drawing.Point(801, 22)
        Me.txtLimiteCC.MaxLength = 10
        Me.txtLimiteCC.Name = "txtLimiteCC"
        Me.txtLimiteCC.ReadOnly = True
        Me.txtLimiteCC.Size = New System.Drawing.Size(81, 23)
        Me.txtLimiteCC.TabIndex = 27
        '
        'txtCondIva
        '
        Me.txtCondIva.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCondIva.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCondIva.Location = New System.Drawing.Point(539, 58)
        Me.txtCondIva.MaxLength = 50
        Me.txtCondIva.Name = "txtCondIva"
        Me.txtCondIva.ReadOnly = True
        Me.txtCondIva.Size = New System.Drawing.Size(133, 23)
        Me.txtCondIva.TabIndex = 26
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCelular.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.Location = New System.Drawing.Point(356, 58)
        Me.txtCelular.MaxLength = 50
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.ReadOnly = True
        Me.txtCelular.Size = New System.Drawing.Size(118, 23)
        Me.txtCelular.TabIndex = 25
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTelefono.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(217, 58)
        Me.txtTelefono.MaxLength = 50
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.Size = New System.Drawing.Size(81, 23)
        Me.txtTelefono.TabIndex = 24
        '
        'txtMail
        '
        Me.txtMail.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMail.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMail.Location = New System.Drawing.Point(709, 58)
        Me.txtMail.MaxLength = 50
        Me.txtMail.Name = "txtMail"
        Me.txtMail.ReadOnly = True
        Me.txtMail.Size = New System.Drawing.Size(173, 23)
        Me.txtMail.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(676, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 16)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Mail:"
        '
        'txtCodigoPostal
        '
        Me.txtCodigoPostal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigoPostal.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoPostal.Location = New System.Drawing.Point(91, 58)
        Me.txtCodigoPostal.MaxLength = 4
        Me.txtCodigoPostal.Name = "txtCodigoPostal"
        Me.txtCodigoPostal.ReadOnly = True
        Me.txtCodigoPostal.Size = New System.Drawing.Size(57, 23)
        Me.txtCodigoPostal.TabIndex = 23
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDireccion.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(561, 22)
        Me.txtDireccion.MaxLength = 50
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(162, 23)
        Me.txtDireccion.TabIndex = 21
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRazonSocial.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazonSocial.Location = New System.Drawing.Point(295, 22)
        Me.txtRazonSocial.MaxLength = 50
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.ReadOnly = True
        Me.txtRazonSocial.Size = New System.Drawing.Size(196, 23)
        Me.txtRazonSocial.TabIndex = 20
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigoProveedor.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(113, 22)
        Me.txtCodigoProveedor.MaxLength = 6
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(59, 23)
        Me.txtCodigoProveedor.TabIndex = 19
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(728, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 16)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Limite C/C:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(479, 62)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 16)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Cond Iva:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(306, 62)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 16)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Celular:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(156, 62)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 16)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Telefono:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 16)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Codigo Postal:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(496, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 16)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Direccion:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(213, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Razon Social:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Codigo Proveedor:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCodN)
        Me.GroupBox1.Controls.Add(Me.tbNumeroComprobante)
        Me.GroupBox1.Controls.Add(Me.lblIdComprobante)
        Me.GroupBox1.Controls.Add(Me.tbPuntoVenta)
        Me.GroupBox1.Controls.Add(Me.lblTipoComprobante)
        Me.GroupBox1.Controls.Add(Me.mtFecha)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(888, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "XC"
        '
        'lblCodN
        '
        Me.lblCodN.AutoSize = True
        Me.lblCodN.Location = New System.Drawing.Point(50, 46)
        Me.lblCodN.Name = "lblCodN"
        Me.lblCodN.Size = New System.Drawing.Size(46, 15)
        Me.lblCodN.TabIndex = 31
        Me.lblCodN.Text = "Cod N°:"
        Me.lblCodN.Visible = False
        '
        'tbNumeroComprobante
        '
        Me.tbNumeroComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbNumeroComprobante.Location = New System.Drawing.Point(414, 29)
        Me.tbNumeroComprobante.MaxLength = 8
        Me.tbNumeroComprobante.Name = "tbNumeroComprobante"
        Me.tbNumeroComprobante.Size = New System.Drawing.Size(87, 23)
        Me.tbNumeroComprobante.TabIndex = 4
        '
        'lblIdComprobante
        '
        Me.lblIdComprobante.AutoSize = True
        Me.lblIdComprobante.Location = New System.Drawing.Point(95, 46)
        Me.lblIdComprobante.Name = "lblIdComprobante"
        Me.lblIdComprobante.Size = New System.Drawing.Size(0, 15)
        Me.lblIdComprobante.TabIndex = 30
        '
        'tbPuntoVenta
        '
        Me.tbPuntoVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbPuntoVenta.Location = New System.Drawing.Point(361, 29)
        Me.tbPuntoVenta.MaxLength = 4
        Me.tbPuntoVenta.Name = "tbPuntoVenta"
        Me.tbPuntoVenta.Size = New System.Drawing.Size(48, 23)
        Me.tbPuntoVenta.TabIndex = 3
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoComprobante.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoComprobante.Location = New System.Drawing.Point(50, 29)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(0, 16)
        Me.lblTipoComprobante.TabIndex = 29
        '
        'mtFecha
        '
        Me.mtFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mtFecha.Location = New System.Drawing.Point(725, 29)
        Me.mtFecha.Mask = "00/00/0000"
        Me.mtFecha.Name = "mtFecha"
        Me.mtFecha.Size = New System.Drawing.Size(84, 23)
        Me.mtFecha.TabIndex = 2
        Me.mtFecha.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(678, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(329, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "N°:"
        '
        'NotaCreditoProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 520)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "")
        Me.HelpProvider1.SetHelpString(Me, "Para Agregar una Nueva Fila, Presione la Tecla Enter, cuando este posisionado en " & _
                "la columna Importe.")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(917, 554)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(917, 554)
        Me.Name = "NotaCreditoProveedores"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nota Credito Proveedor"
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvNotaCreditoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProgressBarFacturacionProveedor As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonRegistrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvNotaCreditoProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents txtIVa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tbNumeroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents tbPuntoVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarProveedor As System.Windows.Forms.Button
    Friend WithEvents txtLimiteCC As System.Windows.Forms.TextBox
    Friend WithEvents txtCondIva As System.Windows.Forms.TextBox
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents txtMail As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents lblCodN As System.Windows.Forms.Label
    Friend WithEvents lblIdComprobante As System.Windows.Forms.Label
    Friend WithEvents lblTipoComprobante As System.Windows.Forms.Label
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Public WithEvents txtCodigoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Eliminar As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents TipoUnid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoProductoProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
