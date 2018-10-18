<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Precio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Precio))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripRegistrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSalir = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.tbImportePrecioCosto = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.rbDisminuirPrecioCosto = New System.Windows.Forms.RadioButton
        Me.rbAumentaPrecioCosto = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.gbArticulos = New System.Windows.Forms.GroupBox
        Me.lbRangoArticuloHasta = New System.Windows.Forms.Label
        Me.lbRangoArticuloDesde = New System.Windows.Forms.Label
        Me.cbRangoArticuloHasta = New System.Windows.Forms.ComboBox
        Me.cbRangoArticuloDesde = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.rbRangoArticulo = New System.Windows.Forms.RadioButton
        Me.rbTodosArticulos = New System.Windows.Forms.RadioButton
        Me.lbListaPrecio = New System.Windows.Forms.Label
        Me.cbListaPrecio = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbArticulos.SuspendLayout()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripSeparator1, Me.ToolStripRegistrar, Me.ToolStripSeparator2, Me.ToolStripSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(472, 45)
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
        'ToolStripRegistrar
        '
        Me.ToolStripRegistrar.AutoToolTip = False
        Me.ToolStripRegistrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripRegistrar.Image = CType(resources.GetObject("ToolStripRegistrar.Image"), System.Drawing.Image)
        Me.ToolStripRegistrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripRegistrar.Name = "ToolStripRegistrar"
        Me.ToolStripRegistrar.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripRegistrar, New DevComponents.DotNetBar.SuperTooltipInfo("Registrar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(65, 21)))
        Me.ToolStripRegistrar.Text = "Registrar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 45)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.gbArticulos)
        Me.GroupBox1.Controls.Add(Me.lbListaPrecio)
        Me.GroupBox1.Controls.Add(Me.cbListaPrecio)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(456, 306)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "XC"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(52, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(350, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Permite mantener acutualizado los precios ante cambios de costos..."
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tbImportePrecioCosto)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.rbDisminuirPrecioCosto)
        Me.GroupBox3.Controls.Add(Me.rbAumentaPrecioCosto)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 202)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(429, 89)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Tag = "XC"
        Me.GroupBox3.Text = "Aumentar/Disminuir Precio Costo"
        '
        'tbImportePrecioCosto
        '
        Me.tbImportePrecioCosto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbImportePrecioCosto.Location = New System.Drawing.Point(307, 36)
        Me.tbImportePrecioCosto.Name = "tbImportePrecioCosto"
        Me.tbImportePrecioCosto.Size = New System.Drawing.Size(100, 23)
        Me.tbImportePrecioCosto.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(177, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Importe Precio Costo: $"
        '
        'rbDisminuirPrecioCosto
        '
        Me.rbDisminuirPrecioCosto.AutoSize = True
        Me.rbDisminuirPrecioCosto.Location = New System.Drawing.Point(18, 51)
        Me.rbDisminuirPrecioCosto.Name = "rbDisminuirPrecioCosto"
        Me.rbDisminuirPrecioCosto.Size = New System.Drawing.Size(142, 19)
        Me.rbDisminuirPrecioCosto.TabIndex = 6
        Me.rbDisminuirPrecioCosto.TabStop = True
        Me.rbDisminuirPrecioCosto.Text = "Disminuir Precio Costo"
        Me.rbDisminuirPrecioCosto.UseVisualStyleBackColor = True
        '
        'rbAumentaPrecioCosto
        '
        Me.rbAumentaPrecioCosto.AutoSize = True
        Me.rbAumentaPrecioCosto.Location = New System.Drawing.Point(18, 26)
        Me.rbAumentaPrecioCosto.Name = "rbAumentaPrecioCosto"
        Me.rbAumentaPrecioCosto.Size = New System.Drawing.Size(141, 19)
        Me.rbAumentaPrecioCosto.TabIndex = 5
        Me.rbAumentaPrecioCosto.TabStop = True
        Me.rbAumentaPrecioCosto.Text = "Aumentar Precio Costo"
        Me.rbAumentaPrecioCosto.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 15)
        Me.Label7.TabIndex = 4
        '
        'gbArticulos
        '
        Me.gbArticulos.Controls.Add(Me.lbRangoArticuloHasta)
        Me.gbArticulos.Controls.Add(Me.lbRangoArticuloDesde)
        Me.gbArticulos.Controls.Add(Me.cbRangoArticuloHasta)
        Me.gbArticulos.Controls.Add(Me.cbRangoArticuloDesde)
        Me.gbArticulos.Controls.Add(Me.Label4)
        Me.gbArticulos.Controls.Add(Me.Label3)
        Me.gbArticulos.Controls.Add(Me.rbRangoArticulo)
        Me.gbArticulos.Controls.Add(Me.rbTodosArticulos)
        Me.gbArticulos.Location = New System.Drawing.Point(12, 65)
        Me.gbArticulos.Name = "gbArticulos"
        Me.gbArticulos.Size = New System.Drawing.Size(429, 131)
        Me.gbArticulos.TabIndex = 3
        Me.gbArticulos.TabStop = False
        Me.gbArticulos.Tag = "XC"
        '
        'lbRangoArticuloHasta
        '
        Me.lbRangoArticuloHasta.AutoSize = True
        Me.lbRangoArticuloHasta.Location = New System.Drawing.Point(306, 92)
        Me.lbRangoArticuloHasta.Name = "lbRangoArticuloHasta"
        Me.lbRangoArticuloHasta.Size = New System.Drawing.Size(0, 15)
        Me.lbRangoArticuloHasta.TabIndex = 7
        '
        'lbRangoArticuloDesde
        '
        Me.lbRangoArticuloDesde.AutoSize = True
        Me.lbRangoArticuloDesde.Location = New System.Drawing.Point(306, 60)
        Me.lbRangoArticuloDesde.Name = "lbRangoArticuloDesde"
        Me.lbRangoArticuloDesde.Size = New System.Drawing.Size(0, 15)
        Me.lbRangoArticuloDesde.TabIndex = 6
        '
        'cbRangoArticuloHasta
        '
        Me.cbRangoArticuloHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbRangoArticuloHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRangoArticuloHasta.FormattingEnabled = True
        Me.cbRangoArticuloHasta.Location = New System.Drawing.Point(182, 87)
        Me.cbRangoArticuloHasta.Name = "cbRangoArticuloHasta"
        Me.cbRangoArticuloHasta.Size = New System.Drawing.Size(121, 23)
        Me.cbRangoArticuloHasta.TabIndex = 5
        '
        'cbRangoArticuloDesde
        '
        Me.cbRangoArticuloDesde.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbRangoArticuloDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRangoArticuloDesde.FormattingEnabled = True
        Me.cbRangoArticuloDesde.Location = New System.Drawing.Point(182, 55)
        Me.cbRangoArticuloDesde.Name = "cbRangoArticuloDesde"
        Me.cbRangoArticuloDesde.Size = New System.Drawing.Size(121, 23)
        Me.cbRangoArticuloDesde.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(90, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Hasta Articulo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(90, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Desde Articulo:"
        '
        'rbRangoArticulo
        '
        Me.rbRangoArticulo.AutoSize = True
        Me.rbRangoArticulo.Location = New System.Drawing.Point(33, 59)
        Me.rbRangoArticulo.Name = "rbRangoArticulo"
        Me.rbRangoArticulo.Size = New System.Drawing.Size(56, 19)
        Me.rbRangoArticulo.TabIndex = 1
        Me.rbRangoArticulo.TabStop = True
        Me.rbRangoArticulo.Text = "Rango"
        Me.rbRangoArticulo.UseVisualStyleBackColor = True
        '
        'rbTodosArticulos
        '
        Me.rbTodosArticulos.AutoSize = True
        Me.rbTodosArticulos.Checked = True
        Me.rbTodosArticulos.Location = New System.Drawing.Point(33, 22)
        Me.rbTodosArticulos.Name = "rbTodosArticulos"
        Me.rbTodosArticulos.Size = New System.Drawing.Size(125, 19)
        Me.rbTodosArticulos.TabIndex = 0
        Me.rbTodosArticulos.TabStop = True
        Me.rbTodosArticulos.Text = "Todos Los Articulos"
        Me.rbTodosArticulos.UseVisualStyleBackColor = True
        '
        'lbListaPrecio
        '
        Me.lbListaPrecio.AutoSize = True
        Me.lbListaPrecio.Location = New System.Drawing.Point(230, 41)
        Me.lbListaPrecio.Name = "lbListaPrecio"
        Me.lbListaPrecio.Size = New System.Drawing.Size(0, 15)
        Me.lbListaPrecio.TabIndex = 2
        '
        'cbListaPrecio
        '
        Me.cbListaPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbListaPrecio.FormattingEnabled = True
        Me.cbListaPrecio.Location = New System.Drawing.Point(124, 36)
        Me.cbListaPrecio.Name = "cbListaPrecio"
        Me.cbListaPrecio.Size = New System.Drawing.Size(103, 23)
        Me.cbListaPrecio.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lista Precios:"
        '
        'VisualStyler1
        '
        Me.VisualStyler1.HostForm = Me
        Me.VisualStyler1.License = CType(resources.GetObject("VisualStyler1.License"), SkinSoft.VisualStyler.Licensing.VisualStylerLicense)
        Me.VisualStyler1.ShadowStyle = SkinSoft.VisualStyler.ShadowStyle.Bold
        Me.VisualStyler1.ToolStripStyle = SkinSoft.VisualStyler.ToolStripRenderStyle.Professional
        Me.VisualStyler1.LoadVisualStyle(Nothing, "Office2007 (Blue).vssf")
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.GroupBox1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(0, 47)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(472, 331)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 2
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
        'Precio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 378)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Precio"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precio"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.gbArticulos.ResumeLayout(False)
        Me.gbArticulos.PerformLayout()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripRegistrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents lbListaPrecio As System.Windows.Forms.Label
    Friend WithEvents cbListaPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbArticulos As System.Windows.Forms.GroupBox
    Friend WithEvents rbTodosArticulos As System.Windows.Forms.RadioButton
    Friend WithEvents lbRangoArticuloHasta As System.Windows.Forms.Label
    Friend WithEvents lbRangoArticuloDesde As System.Windows.Forms.Label
    Friend WithEvents cbRangoArticuloHasta As System.Windows.Forms.ComboBox
    Friend WithEvents cbRangoArticuloDesde As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbRangoArticulo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbDisminuirPrecioCosto As System.Windows.Forms.RadioButton
    Friend WithEvents rbAumentaPrecioCosto As System.Windows.Forms.RadioButton
    Friend WithEvents tbImportePrecioCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
