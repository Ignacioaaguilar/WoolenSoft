<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArticulosAltas
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ArticulosAltas))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProgressBarArticulosAltas = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripGuardarArticuloAlta = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSalirArticuloAlta = New System.Windows.Forms.ToolStripButton
        Me.tbCodProdProveedor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbInhabiliarArticulo = New System.Windows.Forms.CheckBox
        Me.TBPesoUnidad = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TBCantUnidCaja = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.CBUnidades = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CBPesable = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TBStock = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TBStockMinimo = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CBTasaIVA = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CBCodProveedor = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TBDescripcion = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TBCodigoBarra = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.BTNGenerarCodigo = New System.Windows.Forms.Button
        Me.TBNumeroAsignado = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TBCodigoArticulo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CBRubro = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGVListaPrecio = New System.Windows.Forms.DataGridView
        Me.BtnAgregarListaPrecio = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnModificarListaPrecio = New System.Windows.Forms.Button
        Me.BtnEliminarListaPrecio = New System.Windows.Forms.Button
        Me.btnImportarExcel = New System.Windows.Forms.Button
        Me.DGVEmpresaArticulos = New System.Windows.Forms.DataGridView
        Me.Button5 = New System.Windows.Forms.Button
        Me.btnEliminarEmpresaArticulo = New System.Windows.Forms.Button
        Me.btnModidicarEmpresaArticulo = New System.Windows.Forms.Button
        Me.btnAgregarEmpresaArticulo = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.LBProveedor = New System.Windows.Forms.Label
        Me.LbTasaIVA = New System.Windows.Forms.Label
        Me.LBRubro = New System.Windows.Forms.Label
        Me.RibbonClientPanel2 = New DevComponents.DotNetBar.Ribbon.RibbonClientPanel
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGVListaPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVEmpresaArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.RibbonClientPanel2.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBarArticulosAltas, Me.ToolStripSeparator1, Me.ToolStripGuardarArticuloAlta, Me.ToolStripSeparator2, Me.ToolStripSalirArticuloAlta})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(809, 45)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProgressBarArticulosAltas
        '
        Me.ProgressBarArticulosAltas.Name = "ProgressBarArticulosAltas"
        Me.ProgressBarArticulosAltas.Size = New System.Drawing.Size(117, 42)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripGuardarArticuloAlta
        '
        Me.ToolStripGuardarArticuloAlta.AutoToolTip = False
        Me.ToolStripGuardarArticuloAlta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripGuardarArticuloAlta.Image = CType(resources.GetObject("ToolStripGuardarArticuloAlta.Image"), System.Drawing.Image)
        Me.ToolStripGuardarArticuloAlta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripGuardarArticuloAlta.Name = "ToolStripGuardarArticuloAlta"
        Me.ToolStripGuardarArticuloAlta.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripGuardarArticuloAlta, New DevComponents.DotNetBar.SuperTooltipInfo("Registrar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(62, 21)))
        Me.ToolStripGuardarArticuloAlta.Text = "ToolStripButton1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripSalirArticuloAlta
        '
        Me.ToolStripSalirArticuloAlta.AutoToolTip = False
        Me.ToolStripSalirArticuloAlta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSalirArticuloAlta.Image = CType(resources.GetObject("ToolStripSalirArticuloAlta.Image"), System.Drawing.Image)
        Me.ToolStripSalirArticuloAlta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSalirArticuloAlta.Name = "ToolStripSalirArticuloAlta"
        Me.ToolStripSalirArticuloAlta.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripSalirArticuloAlta, New DevComponents.DotNetBar.SuperTooltipInfo("Salir ", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.ToolStripSalirArticuloAlta.Text = "Salir Articulo Alta"
        '
        'tbCodProdProveedor
        '
        Me.tbCodProdProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbCodProdProveedor.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCodProdProveedor.Location = New System.Drawing.Point(129, 223)
        Me.tbCodProdProveedor.Name = "tbCodProdProveedor"
        Me.tbCodProdProveedor.Size = New System.Drawing.Size(161, 23)
        Me.tbCodProdProveedor.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 16)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Cod Prod Proveedor:"
        '
        'cbInhabiliarArticulo
        '
        Me.cbInhabiliarArticulo.BackColor = System.Drawing.Color.Transparent
        Me.cbInhabiliarArticulo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbInhabiliarArticulo.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbInhabiliarArticulo.Location = New System.Drawing.Point(17, 15)
        Me.cbInhabiliarArticulo.Name = "cbInhabiliarArticulo"
        Me.cbInhabiliarArticulo.Size = New System.Drawing.Size(148, 24)
        Me.cbInhabiliarArticulo.TabIndex = 30
        Me.cbInhabiliarArticulo.Text = "Inhabilitar Articulo"
        Me.cbInhabiliarArticulo.UseVisualStyleBackColor = False
        '
        'TBPesoUnidad
        '
        Me.TBPesoUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBPesoUnidad.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBPesoUnidad.Location = New System.Drawing.Point(710, 101)
        Me.TBPesoUnidad.Name = "TBPesoUnidad"
        Me.TBPesoUnidad.Size = New System.Drawing.Size(81, 23)
        Me.TBPesoUnidad.TabIndex = 28
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(628, 106)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 16)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Peso Unidad:"
        '
        'TBCantUnidCaja
        '
        Me.TBCantUnidCaja.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBCantUnidCaja.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCantUnidCaja.Location = New System.Drawing.Point(710, 101)
        Me.TBCantUnidCaja.Name = "TBCantUnidCaja"
        Me.TBCantUnidCaja.Size = New System.Drawing.Size(81, 23)
        Me.TBCantUnidCaja.TabIndex = 26
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(590, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(114, 16)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Cantidad Unid Caja:"
        '
        'CBUnidades
        '
        Me.CBUnidades.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUnidades.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBUnidades.FormattingEnabled = True
        Me.CBUnidades.Items.AddRange(New Object() {"Kgs", "Cajas", "Lts", "Un"})
        Me.CBUnidades.Location = New System.Drawing.Point(451, 194)
        Me.CBUnidades.Name = "CBUnidades"
        Me.CBUnidades.Size = New System.Drawing.Size(60, 23)
        Me.CBUnidades.TabIndex = 24
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(356, 201)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 16)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Unidades:"
        '
        'CBPesable
        '
        Me.CBPesable.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBPesable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPesable.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBPesable.FormattingEnabled = True
        Me.CBPesable.Items.AddRange(New Object() {"Si", "No"})
        Me.CBPesable.Location = New System.Drawing.Point(451, 158)
        Me.CBPesable.Name = "CBPesable"
        Me.CBPesable.Size = New System.Drawing.Size(59, 23)
        Me.CBPesable.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(356, 165)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 16)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Pesable*:"
        '
        'TBStock
        '
        Me.TBStock.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBStock.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBStock.Location = New System.Drawing.Point(451, 121)
        Me.TBStock.Name = "TBStock"
        Me.TBStock.Size = New System.Drawing.Size(99, 23)
        Me.TBStock.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(356, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 16)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Stock*:"
        '
        'TBStockMinimo
        '
        Me.TBStockMinimo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBStockMinimo.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBStockMinimo.Location = New System.Drawing.Point(451, 81)
        Me.TBStockMinimo.Name = "TBStockMinimo"
        Me.TBStockMinimo.Size = New System.Drawing.Size(100, 23)
        Me.TBStockMinimo.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(356, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 16)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Stock Minimo*:"
        '
        'CBTasaIVA
        '
        Me.CBTasaIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBTasaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBTasaIVA.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBTasaIVA.FormattingEnabled = True
        Me.CBTasaIVA.Location = New System.Drawing.Point(451, 46)
        Me.CBTasaIVA.Name = "CBTasaIVA"
        Me.CBTasaIVA.Size = New System.Drawing.Size(56, 23)
        Me.CBTasaIVA.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(356, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Tasa IVA*:"
        '
        'CBCodProveedor
        '
        Me.CBCodProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBCodProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBCodProveedor.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBCodProveedor.FormattingEnabled = True
        Me.CBCodProveedor.Location = New System.Drawing.Point(129, 194)
        Me.CBCodProveedor.Name = "CBCodProveedor"
        Me.CBCodProveedor.Size = New System.Drawing.Size(62, 23)
        Me.CBCodProveedor.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Cod Proveedor:"
        '
        'TBDescripcion
        '
        Me.TBDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBDescripcion.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBDescripcion.Location = New System.Drawing.Point(129, 159)
        Me.TBDescripcion.Name = "TBDescripcion"
        Me.TBDescripcion.Size = New System.Drawing.Size(161, 23)
        Me.TBDescripcion.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Descripcion*:"
        '
        'TBCodigoBarra
        '
        Me.TBCodigoBarra.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBCodigoBarra.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCodigoBarra.Location = New System.Drawing.Point(129, 124)
        Me.TBCodigoBarra.Name = "TBCodigoBarra"
        Me.TBCodigoBarra.Size = New System.Drawing.Size(161, 23)
        Me.TBCodigoBarra.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Codigo Barras:"
        '
        'BTNGenerarCodigo
        '
        Me.BTNGenerarCodigo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTNGenerarCodigo.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNGenerarCodigo.Location = New System.Drawing.Point(242, 72)
        Me.BTNGenerarCodigo.Name = "BTNGenerarCodigo"
        Me.BTNGenerarCodigo.Size = New System.Drawing.Size(108, 43)
        Me.BTNGenerarCodigo.TabIndex = 6
        Me.BTNGenerarCodigo.Text = "Generar Codigo Articulo"
        Me.BTNGenerarCodigo.UseVisualStyleBackColor = True
        '
        'TBNumeroAsignado
        '
        Me.TBNumeroAsignado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBNumeroAsignado.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBNumeroAsignado.Location = New System.Drawing.Point(128, 83)
        Me.TBNumeroAsignado.Name = "TBNumeroAsignado"
        Me.TBNumeroAsignado.Size = New System.Drawing.Size(108, 23)
        Me.TBNumeroAsignado.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Numero Asignado*:"
        '
        'TBCodigoArticulo
        '
        Me.TBCodigoArticulo.BackColor = System.Drawing.Color.PeachPuff
        Me.TBCodigoArticulo.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCodigoArticulo.Location = New System.Drawing.Point(129, 50)
        Me.TBCodigoArticulo.Name = "TBCodigoArticulo"
        Me.TBCodigoArticulo.ReadOnly = True
        Me.TBCodigoArticulo.Size = New System.Drawing.Size(108, 23)
        Me.TBCodigoArticulo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Codigo Articulo*:"
        '
        'CBRubro
        '
        Me.CBRubro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBRubro.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.CBRubro.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBRubro.FormattingEnabled = True
        Me.CBRubro.Location = New System.Drawing.Point(365, 16)
        Me.CBRubro.Name = "CBRubro"
        Me.CBRubro.Size = New System.Drawing.Size(83, 23)
        Me.CBRubro.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(313, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rubro*:"
        '
        'DGVListaPrecio
        '
        Me.DGVListaPrecio.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVListaPrecio.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVListaPrecio.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVListaPrecio.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVListaPrecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVListaPrecio.Location = New System.Drawing.Point(10, 8)
        Me.DGVListaPrecio.Name = "DGVListaPrecio"
        Me.DGVListaPrecio.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVListaPrecio.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVListaPrecio.RowHeadersVisible = False
        Me.DGVListaPrecio.Size = New System.Drawing.Size(587, 182)
        Me.DGVListaPrecio.TabIndex = 2
        '
        'BtnAgregarListaPrecio
        '
        Me.BtnAgregarListaPrecio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAgregarListaPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAgregarListaPrecio.ImageKey = "agregar.png"
        Me.BtnAgregarListaPrecio.ImageList = Me.ImageList1
        Me.BtnAgregarListaPrecio.Location = New System.Drawing.Point(611, 3)
        Me.BtnAgregarListaPrecio.Name = "BtnAgregarListaPrecio"
        Me.BtnAgregarListaPrecio.Size = New System.Drawing.Size(187, 41)
        Me.BtnAgregarListaPrecio.TabIndex = 3
        Me.BtnAgregarListaPrecio.Text = "Agregar"
        Me.BtnAgregarListaPrecio.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "agregar.png")
        Me.ImageList1.Images.SetKeyName(1, "eliminarListaPrecio.png")
        Me.ImageList1.Images.SetKeyName(2, "remito.png")
        Me.ImageList1.Images.SetKeyName(3, "excel.png")
        '
        'BtnModificarListaPrecio
        '
        Me.BtnModificarListaPrecio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnModificarListaPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnModificarListaPrecio.ImageKey = "remito.png"
        Me.BtnModificarListaPrecio.ImageList = Me.ImageList1
        Me.BtnModificarListaPrecio.Location = New System.Drawing.Point(611, 50)
        Me.BtnModificarListaPrecio.Name = "BtnModificarListaPrecio"
        Me.BtnModificarListaPrecio.Size = New System.Drawing.Size(187, 41)
        Me.BtnModificarListaPrecio.TabIndex = 4
        Me.BtnModificarListaPrecio.Text = "Modificar"
        Me.BtnModificarListaPrecio.UseVisualStyleBackColor = True
        '
        'BtnEliminarListaPrecio
        '
        Me.BtnEliminarListaPrecio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEliminarListaPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminarListaPrecio.ImageKey = "eliminarListaPrecio.png"
        Me.BtnEliminarListaPrecio.ImageList = Me.ImageList1
        Me.BtnEliminarListaPrecio.Location = New System.Drawing.Point(611, 97)
        Me.BtnEliminarListaPrecio.Name = "BtnEliminarListaPrecio"
        Me.BtnEliminarListaPrecio.Size = New System.Drawing.Size(187, 41)
        Me.BtnEliminarListaPrecio.TabIndex = 5
        Me.BtnEliminarListaPrecio.Text = "Eliminar"
        Me.BtnEliminarListaPrecio.UseVisualStyleBackColor = True
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportarExcel.ImageKey = "excel.png"
        Me.btnImportarExcel.ImageList = Me.ImageList1
        Me.btnImportarExcel.Location = New System.Drawing.Point(611, 146)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Size = New System.Drawing.Size(187, 41)
        Me.btnImportarExcel.TabIndex = 6
        Me.btnImportarExcel.Text = "Importar Lista Precio"
        Me.btnImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImportarExcel.UseVisualStyleBackColor = True
        '
        'DGVEmpresaArticulos
        '
        Me.DGVEmpresaArticulos.AllowUserToAddRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVEmpresaArticulos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DGVEmpresaArticulos.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.DGVEmpresaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVEmpresaArticulos.Location = New System.Drawing.Point(10, 8)
        Me.DGVEmpresaArticulos.Name = "DGVEmpresaArticulos"
        Me.DGVEmpresaArticulos.ReadOnly = True
        Me.DGVEmpresaArticulos.RowHeadersVisible = False
        Me.DGVEmpresaArticulos.Size = New System.Drawing.Size(587, 182)
        Me.DGVEmpresaArticulos.TabIndex = 2
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Enabled = False
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.ImageKey = "excel.png"
        Me.Button5.ImageList = Me.ImageList1
        Me.Button5.Location = New System.Drawing.Point(611, 146)
        Me.Button5.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(187, 41)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Importar Lista Precio"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'btnEliminarEmpresaArticulo
        '
        Me.btnEliminarEmpresaArticulo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarEmpresaArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminarEmpresaArticulo.ImageKey = "eliminarListaPrecio.png"
        Me.btnEliminarEmpresaArticulo.ImageList = Me.ImageList1
        Me.btnEliminarEmpresaArticulo.Location = New System.Drawing.Point(611, 97)
        Me.btnEliminarEmpresaArticulo.Name = "btnEliminarEmpresaArticulo"
        Me.btnEliminarEmpresaArticulo.Size = New System.Drawing.Size(187, 41)
        Me.btnEliminarEmpresaArticulo.TabIndex = 5
        Me.btnEliminarEmpresaArticulo.Text = "Eliminar"
        Me.btnEliminarEmpresaArticulo.UseVisualStyleBackColor = True
        '
        'btnModidicarEmpresaArticulo
        '
        Me.btnModidicarEmpresaArticulo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModidicarEmpresaArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModidicarEmpresaArticulo.ImageKey = "remito.png"
        Me.btnModidicarEmpresaArticulo.ImageList = Me.ImageList1
        Me.btnModidicarEmpresaArticulo.Location = New System.Drawing.Point(611, 50)
        Me.btnModidicarEmpresaArticulo.Name = "btnModidicarEmpresaArticulo"
        Me.btnModidicarEmpresaArticulo.Size = New System.Drawing.Size(187, 41)
        Me.btnModidicarEmpresaArticulo.TabIndex = 4
        Me.btnModidicarEmpresaArticulo.Text = "Modificar"
        Me.btnModidicarEmpresaArticulo.UseVisualStyleBackColor = True
        '
        'btnAgregarEmpresaArticulo
        '
        Me.btnAgregarEmpresaArticulo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregarEmpresaArticulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarEmpresaArticulo.ImageKey = "agregar.png"
        Me.btnAgregarEmpresaArticulo.ImageList = Me.ImageList1
        Me.btnAgregarEmpresaArticulo.Location = New System.Drawing.Point(611, 3)
        Me.btnAgregarEmpresaArticulo.Name = "btnAgregarEmpresaArticulo"
        Me.btnAgregarEmpresaArticulo.Size = New System.Drawing.Size(187, 41)
        Me.btnAgregarEmpresaArticulo.TabIndex = 3
        Me.btnAgregarEmpresaArticulo.Text = "Agregar"
        Me.btnAgregarEmpresaArticulo.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(9, 23)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(587, 182)
        Me.DataGridView1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageKey = "excel.png"
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(610, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 41)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Importar Lista Precio"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageKey = "eliminarListaPrecio.png"
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(610, 112)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(161, 41)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Eliminar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.ImageKey = "remito.png"
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(610, 65)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(161, 41)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Modificar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.ImageKey = "agregar.png"
        Me.Button4.ImageList = Me.ImageList1
        Me.Button4.Location = New System.Drawing.Point(610, 18)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(161, 41)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Agregar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TabControl1.Location = New System.Drawing.Point(3, 322)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(804, 226)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.TabControl1.TabIndex = 31
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.DGVListaPrecio)
        Me.TabControlPanel1.Controls.Add(Me.btnImportarExcel)
        Me.TabControlPanel1.Controls.Add(Me.BtnAgregarListaPrecio)
        Me.TabControlPanel1.Controls.Add(Me.BtnEliminarListaPrecio)
        Me.TabControlPanel1.Controls.Add(Me.BtnModificarListaPrecio)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(804, 201)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = -90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabItem1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue
        Me.TabItem1.Text = "Lista de Precio"
        Me.TabItem1.TextColor = System.Drawing.Color.Black
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.DGVEmpresaArticulos)
        Me.TabControlPanel2.Controls.Add(Me.Button5)
        Me.TabControlPanel2.Controls.Add(Me.btnAgregarEmpresaArticulo)
        Me.TabControlPanel2.Controls.Add(Me.btnEliminarEmpresaArticulo)
        Me.TabControlPanel2.Controls.Add(Me.btnModidicarEmpresaArticulo)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 25)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(804, 201)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = -90
        Me.TabControlPanel2.TabIndex = 5
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabItem2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue
        Me.TabItem2.Text = "Empresa Articulos"
        Me.TabItem2.TextColor = System.Drawing.Color.Black
        '
        'LBProveedor
        '
        Me.LBProveedor.AutoSize = True
        Me.LBProveedor.BackColor = System.Drawing.Color.Transparent
        Me.LBProveedor.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBProveedor.Location = New System.Drawing.Point(193, 198)
        Me.LBProveedor.Name = "LBProveedor"
        Me.LBProveedor.Size = New System.Drawing.Size(0, 16)
        Me.LBProveedor.TabIndex = 13
        '
        'LbTasaIVA
        '
        Me.LbTasaIVA.AutoSize = True
        Me.LbTasaIVA.BackColor = System.Drawing.Color.Transparent
        Me.LbTasaIVA.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTasaIVA.Location = New System.Drawing.Point(509, 50)
        Me.LbTasaIVA.Name = "LbTasaIVA"
        Me.LbTasaIVA.Size = New System.Drawing.Size(0, 16)
        Me.LbTasaIVA.TabIndex = 16
        '
        'LBRubro
        '
        Me.LBRubro.AutoSize = True
        Me.LBRubro.BackColor = System.Drawing.Color.Transparent
        Me.LBRubro.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBRubro.Location = New System.Drawing.Point(450, 20)
        Me.LBRubro.Name = "LBRubro"
        Me.LBRubro.Size = New System.Drawing.Size(0, 16)
        Me.LBRubro.TabIndex = 29
        '
        'RibbonClientPanel2
        '
        Me.RibbonClientPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.RibbonClientPanel2.Controls.Add(Me.cbInhabiliarArticulo)
        Me.RibbonClientPanel2.Location = New System.Drawing.Point(593, 173)
        Me.RibbonClientPanel2.Name = "RibbonClientPanel2"
        Me.RibbonClientPanel2.Size = New System.Drawing.Size(179, 55)
        '
        '
        '
        Me.RibbonClientPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.RibbonClientPanel2.Style.BackColorGradientAngle = 90
        Me.RibbonClientPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.RibbonClientPanel2.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile
        Me.RibbonClientPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonClientPanel2.Style.BorderBottomWidth = 1
        Me.RibbonClientPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.RibbonClientPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonClientPanel2.Style.BorderLeftWidth = 1
        Me.RibbonClientPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonClientPanel2.Style.BorderRightWidth = 1
        Me.RibbonClientPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.RibbonClientPanel2.Style.BorderTopWidth = 1
        Me.RibbonClientPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonClientPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.RibbonClientPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        '
        '
        '
        Me.RibbonClientPanel2.StyleMouseDown.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.RibbonClientPanel2.StyleMouseDown.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.RibbonClientPanel2.StyleMouseDown.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.RibbonClientPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonClientPanel2.StyleMouseDown.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedText
        '
        '
        '
        Me.RibbonClientPanel2.StyleMouseOver.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground2
        Me.RibbonClientPanel2.StyleMouseOver.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBackground
        Me.RibbonClientPanel2.StyleMouseOver.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotBorder
        Me.RibbonClientPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonClientPanel2.StyleMouseOver.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemHotText
        Me.RibbonClientPanel2.TabIndex = 34
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.TBCantUnidCaja)
        Me.PanelEx1.Controls.Add(Me.RibbonClientPanel2)
        Me.PanelEx1.Controls.Add(Me.TBPesoUnidad)
        Me.PanelEx1.Controls.Add(Me.Label13)
        Me.PanelEx1.Controls.Add(Me.Label5)
        Me.PanelEx1.Controls.Add(Me.TBCodigoBarra)
        Me.PanelEx1.Controls.Add(Me.tbCodProdProveedor)
        Me.PanelEx1.Controls.Add(Me.CBPesable)
        Me.PanelEx1.Controls.Add(Me.CBUnidades)
        Me.PanelEx1.Controls.Add(Me.TBDescripcion)
        Me.PanelEx1.Controls.Add(Me.Label7)
        Me.PanelEx1.Controls.Add(Me.Label4)
        Me.PanelEx1.Controls.Add(Me.LbTasaIVA)
        Me.PanelEx1.Controls.Add(Me.Label12)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.Controls.Add(Me.Label14)
        Me.PanelEx1.Controls.Add(Me.CBTasaIVA)
        Me.PanelEx1.Controls.Add(Me.Label6)
        Me.PanelEx1.Controls.Add(Me.CBRubro)
        Me.PanelEx1.Controls.Add(Me.BTNGenerarCodigo)
        Me.PanelEx1.Controls.Add(Me.Label10)
        Me.PanelEx1.Controls.Add(Me.TBStock)
        Me.PanelEx1.Controls.Add(Me.LBRubro)
        Me.PanelEx1.Controls.Add(Me.TBNumeroAsignado)
        Me.PanelEx1.Controls.Add(Me.Label8)
        Me.PanelEx1.Controls.Add(Me.CBCodProveedor)
        Me.PanelEx1.Controls.Add(Me.TBCodigoArticulo)
        Me.PanelEx1.Controls.Add(Me.Label15)
        Me.PanelEx1.Controls.Add(Me.TBStockMinimo)
        Me.PanelEx1.Controls.Add(Me.Label11)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.LBProveedor)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(2, 48)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(804, 262)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 35
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
        'ArticulosAltas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 551)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(220, 200)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ArticulosAltas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Articulos Altas"
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGVListaPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVEmpresaArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        Me.RibbonClientPanel2.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProgressBarArticulosAltas As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripGuardarArticuloAlta As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSalirArticuloAlta As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBRubro As System.Windows.Forms.ComboBox
    Friend WithEvents TBCodigoArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BTNGenerarCodigo As System.Windows.Forms.Button
    Friend WithEvents TBNumeroAsignado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBCodProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TBDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TBCodigoBarra As System.Windows.Forms.TextBox
    Friend WithEvents CBTasaIVA As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TBStockMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TBStock As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CBPesable As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CBUnidades As System.Windows.Forms.ComboBox
    Friend WithEvents TBCantUnidCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TBPesoUnidad As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DGVListaPrecio As System.Windows.Forms.DataGridView
    Friend WithEvents BtnEliminarListaPrecio As System.Windows.Forms.Button
    Friend WithEvents BtnModificarListaPrecio As System.Windows.Forms.Button
    Friend WithEvents BtnAgregarListaPrecio As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnImportarExcel As System.Windows.Forms.Button
    Friend WithEvents DGVEmpresaArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents btnEliminarEmpresaArticulo As System.Windows.Forms.Button
    Friend WithEvents btnModidicarEmpresaArticulo As System.Windows.Forms.Button
    Friend WithEvents btnAgregarEmpresaArticulo As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cbInhabiliarArticulo As System.Windows.Forms.CheckBox
    Friend WithEvents tbCodProdProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents LBRubro As System.Windows.Forms.Label
    Friend WithEvents LbTasaIVA As System.Windows.Forms.Label
    Friend WithEvents LBProveedor As System.Windows.Forms.Label
    Friend WithEvents RibbonClientPanel2 As DevComponents.DotNetBar.Ribbon.RibbonClientPanel
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
End Class
