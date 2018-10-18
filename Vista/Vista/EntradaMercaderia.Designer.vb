<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EntradaMercaderia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EntradaMercaderia))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButtonRegistrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButtonSalir = New System.Windows.Forms.ToolStripButton
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.mtFecha = New System.Windows.Forms.MaskedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbDescripcion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvEntradaMercaderia = New System.Windows.Forms.DataGridView
        Me.Eliminar = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
        Me.TipoUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodBarras = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnidadesKilos = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chbActualizarStockArticulos = New System.Windows.Forms.CheckBox
        Me.chbInicializarStock = New System.Windows.Forms.CheckBox
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvEntradaMercaderia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripSeparator1, Me.ToolStripButtonRegistrar, Me.ToolStripSeparator2, Me.ToolStripButtonSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(851, 45)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(117, 42)
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
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripButtonSalir, New DevComponents.DotNetBar.SuperTooltipInfo("Salir", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.GroupBox1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(2, 46)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(849, 576)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTitulo)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.dgvEntradaMercaderia)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(829, 564)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "XC"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(336, 27)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(0, 23)
        Me.lblTitulo.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.mtFecha)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.tbDescripcion)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(14, 121)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(793, 64)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Tag = "XC"
        '
        'mtFecha
        '
        Me.mtFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mtFecha.Location = New System.Drawing.Point(604, 27)
        Me.mtFecha.Mask = "00/00/0000"
        Me.mtFecha.Name = "mtFecha"
        Me.mtFecha.Size = New System.Drawing.Size(82, 23)
        Me.mtFecha.TabIndex = 3
        Me.mtFecha.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(558, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        '
        'tbDescripcion
        '
        Me.tbDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbDescripcion.Location = New System.Drawing.Point(143, 27)
        Me.tbDescripcion.Name = "tbDescripcion"
        Me.tbDescripcion.Size = New System.Drawing.Size(335, 23)
        Me.tbDescripcion.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(68, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descripcion:"
        '
        'dgvEntradaMercaderia
        '
        Me.dgvEntradaMercaderia.AllowDrop = True
        Me.dgvEntradaMercaderia.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvEntradaMercaderia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEntradaMercaderia.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvEntradaMercaderia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntradaMercaderia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Eliminar, Me.TipoUnidad, Me.CodBarras, Me.CodArticulo, Me.Descripcion, Me.UnidadesKilos})
        Me.dgvEntradaMercaderia.Location = New System.Drawing.Point(16, 198)
        Me.dgvEntradaMercaderia.Name = "dgvEntradaMercaderia"
        Me.dgvEntradaMercaderia.RowHeadersVisible = False
        Me.dgvEntradaMercaderia.Size = New System.Drawing.Size(791, 350)
        Me.SuperTooltip1.SetSuperTooltip(Me.dgvEntradaMercaderia, New DevComponents.DotNetBar.SuperTooltipInfo("Para Agregar una Nueva Fila, Presione la Tecla Enter, cuando este posisionado en " & _
                    "la columna Unid/Kilos.", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue))
        Me.dgvEntradaMercaderia.TabIndex = 1
        '
        'Eliminar
        '
        Me.Eliminar.FillWeight = 60.0!
        Me.Eliminar.HeaderText = "Eliminar"
        Me.Eliminar.Image = CType(resources.GetObject("Eliminar.Image"), System.Drawing.Image)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Eliminar.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 12, 12, 2)
        Me.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.ToolTipText = "Eliminar"
        Me.Eliminar.Width = 60
        '
        'TipoUnidad
        '
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray
        Me.TipoUnidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.TipoUnidad.FillWeight = 40.0!
        Me.TipoUnidad.HeaderText = "T.U"
        Me.TipoUnidad.Name = "TipoUnidad"
        Me.TipoUnidad.ToolTipText = "Tipo Unidad"
        Me.TipoUnidad.Width = 40
        '
        'CodBarras
        '
        Me.CodBarras.HeaderText = "Cod. Barras"
        Me.CodBarras.Name = "CodBarras"
        '
        'CodArticulo
        '
        Me.CodArticulo.HeaderText = "Cod. Articulo"
        Me.CodArticulo.Name = "CodArticulo"
        Me.CodArticulo.ToolTipText = "Codigo Articulo"
        '
        'Descripcion
        '
        Me.Descripcion.FillWeight = 375.0!
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ToolTipText = "Descripcion"
        Me.Descripcion.Width = 375
        '
        'UnidadesKilos
        '
        Me.UnidadesKilos.HeaderText = "Unid/Kilos"
        Me.UnidadesKilos.Name = "UnidadesKilos"
        Me.UnidadesKilos.ToolTipText = "Unidades/Kilos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chbActualizarStockArticulos)
        Me.GroupBox2.Controls.Add(Me.chbInicializarStock)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(793, 64)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "XC"
        '
        'chbActualizarStockArticulos
        '
        Me.chbActualizarStockArticulos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbActualizarStockArticulos.Location = New System.Drawing.Point(390, 27)
        Me.chbActualizarStockArticulos.Name = "chbActualizarStockArticulos"
        Me.chbActualizarStockArticulos.Size = New System.Drawing.Size(340, 19)
        Me.SuperTooltip1.SetSuperTooltip(Me.chbActualizarStockArticulos, New DevComponents.DotNetBar.SuperTooltipInfo("Al seleccionar esta opcion, el stock de articulo se actualizara con lo ingresado " & _
                    "en la grilla mas el stock que posee el articulo", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue))
        Me.chbActualizarStockArticulos.TabIndex = 1
        Me.chbActualizarStockArticulos.Text = "Actualizar Stock de Articulos, Con lo Ingresado en la Grilla"
        Me.chbActualizarStockArticulos.UseVisualStyleBackColor = True
        '
        'chbInicializarStock
        '
        Me.chbInicializarStock.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbInicializarStock.Location = New System.Drawing.Point(55, 27)
        Me.chbInicializarStock.Name = "chbInicializarStock"
        Me.chbInicializarStock.Size = New System.Drawing.Size(225, 19)
        Me.SuperTooltip1.SetSuperTooltip(Me.chbInicializarStock, New DevComponents.DotNetBar.SuperTooltipInfo("Al seleccionar esta opcion, el stock se inicializara a Cero.", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue))
        Me.chbInicializarStock.TabIndex = 0
        Me.chbInicializarStock.Text = "Inicializar a Cero Stock de Articulos"
        Me.chbInicializarStock.UseVisualStyleBackColor = True
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        '
        'EntradaMercaderia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 625)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EntradaMercaderia"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entrada Salida Mercaderia"
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelEx1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvEntradaMercaderia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonRegistrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButtonSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chbActualizarStockArticulos As System.Windows.Forms.CheckBox
    Friend WithEvents chbInicializarStock As System.Windows.Forms.CheckBox
    Friend WithEvents dgvEntradaMercaderia As System.Windows.Forms.DataGridView
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Eliminar As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents TipoUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodBarras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnidadesKilos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
End Class
