<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Articulos_ListaPrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Articulos_ListaPrecios))
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProgressBarArticulosListaPrecio = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.GuardarArticuloListaPrecio = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.SalirArticuloListaPrecio = New System.Windows.Forms.ToolStripButton
        Me.LBListaPrecioDescripcion = New System.Windows.Forms.Label
        Me.TBPrecioKilo = New System.Windows.Forms.TextBox
        Me.TBPrecioVenta = New System.Windows.Forms.TextBox
        Me.TBRentabilidad = New System.Windows.Forms.TextBox
        Me.TBPrecioCosto = New System.Windows.Forms.TextBox
        Me.TBCodigoProducto = New System.Windows.Forms.TextBox
        Me.CBListaPrecio = New System.Windows.Forms.ComboBox
        Me.LBPrecioKilo = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBarArticulosListaPrecio, Me.ToolStripSeparator1, Me.GuardarArticuloListaPrecio, Me.ToolStripSeparator2, Me.SalirArticuloListaPrecio})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(359, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProgressBarArticulosListaPrecio
        '
        Me.ProgressBarArticulosListaPrecio.Name = "ProgressBarArticulosListaPrecio"
        Me.ProgressBarArticulosListaPrecio.Size = New System.Drawing.Size(136, 36)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'GuardarArticuloListaPrecio
        '
        Me.GuardarArticuloListaPrecio.AutoToolTip = False
        Me.GuardarArticuloListaPrecio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GuardarArticuloListaPrecio.Image = CType(resources.GetObject("GuardarArticuloListaPrecio.Image"), System.Drawing.Image)
        Me.GuardarArticuloListaPrecio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarArticuloListaPrecio.Name = "GuardarArticuloListaPrecio"
        Me.GuardarArticuloListaPrecio.Size = New System.Drawing.Size(36, 36)
        Me.SuperTooltip1.SetSuperTooltip(Me.GuardarArticuloListaPrecio, New DevComponents.DotNetBar.SuperTooltipInfo("Registrar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(62, 21)))
        Me.GuardarArticuloListaPrecio.Text = "Registrar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'SalirArticuloListaPrecio
        '
        Me.SalirArticuloListaPrecio.AutoToolTip = False
        Me.SalirArticuloListaPrecio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SalirArticuloListaPrecio.Image = CType(resources.GetObject("SalirArticuloListaPrecio.Image"), System.Drawing.Image)
        Me.SalirArticuloListaPrecio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SalirArticuloListaPrecio.Name = "SalirArticuloListaPrecio"
        Me.SalirArticuloListaPrecio.Size = New System.Drawing.Size(36, 36)
        Me.SuperTooltip1.SetSuperTooltip(Me.SalirArticuloListaPrecio, New DevComponents.DotNetBar.SuperTooltipInfo("Salir", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.SalirArticuloListaPrecio.Text = "Salir"
        '
        'LBListaPrecioDescripcion
        '
        Me.LBListaPrecioDescripcion.AutoSize = True
        Me.LBListaPrecioDescripcion.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBListaPrecioDescripcion.Location = New System.Drawing.Point(228, 52)
        Me.LBListaPrecioDescripcion.Name = "LBListaPrecioDescripcion"
        Me.LBListaPrecioDescripcion.Size = New System.Drawing.Size(0, 16)
        Me.LBListaPrecioDescripcion.TabIndex = 12
        '
        'TBPrecioKilo
        '
        Me.TBPrecioKilo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBPrecioKilo.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBPrecioKilo.Location = New System.Drawing.Point(160, 201)
        Me.TBPrecioKilo.Name = "TBPrecioKilo"
        Me.TBPrecioKilo.Size = New System.Drawing.Size(89, 24)
        Me.TBPrecioKilo.TabIndex = 12
        '
        'TBPrecioVenta
        '
        Me.TBPrecioVenta.BackColor = System.Drawing.Color.Wheat
        Me.TBPrecioVenta.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBPrecioVenta.Location = New System.Drawing.Point(160, 163)
        Me.TBPrecioVenta.Name = "TBPrecioVenta"
        Me.TBPrecioVenta.ReadOnly = True
        Me.TBPrecioVenta.Size = New System.Drawing.Size(89, 24)
        Me.TBPrecioVenta.TabIndex = 11
        '
        'TBRentabilidad
        '
        Me.TBRentabilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBRentabilidad.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBRentabilidad.Location = New System.Drawing.Point(160, 126)
        Me.TBRentabilidad.Name = "TBRentabilidad"
        Me.TBRentabilidad.Size = New System.Drawing.Size(89, 24)
        Me.TBRentabilidad.TabIndex = 10
        '
        'TBPrecioCosto
        '
        Me.TBPrecioCosto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBPrecioCosto.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBPrecioCosto.Location = New System.Drawing.Point(160, 87)
        Me.TBPrecioCosto.Name = "TBPrecioCosto"
        Me.TBPrecioCosto.Size = New System.Drawing.Size(89, 24)
        Me.TBPrecioCosto.TabIndex = 9
        '
        'TBCodigoProducto
        '
        Me.TBCodigoProducto.BackColor = System.Drawing.Color.PeachPuff
        Me.TBCodigoProducto.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCodigoProducto.Location = New System.Drawing.Point(160, 12)
        Me.TBCodigoProducto.Name = "TBCodigoProducto"
        Me.TBCodigoProducto.ReadOnly = True
        Me.TBCodigoProducto.Size = New System.Drawing.Size(135, 24)
        Me.TBCodigoProducto.TabIndex = 7
        '
        'CBListaPrecio
        '
        Me.CBListaPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBListaPrecio.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBListaPrecio.FormattingEnabled = True
        Me.CBListaPrecio.Location = New System.Drawing.Point(160, 48)
        Me.CBListaPrecio.Name = "CBListaPrecio"
        Me.CBListaPrecio.Size = New System.Drawing.Size(66, 25)
        Me.CBListaPrecio.TabIndex = 8
        '
        'LBPrecioKilo
        '
        Me.LBPrecioKilo.AutoSize = True
        Me.LBPrecioKilo.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBPrecioKilo.Location = New System.Drawing.Point(53, 204)
        Me.LBPrecioKilo.Name = "LBPrecioKilo"
        Me.LBPrecioKilo.Size = New System.Drawing.Size(75, 16)
        Me.LBPrecioKilo.TabIndex = 5
        Me.LBPrecioKilo.Text = "Precio Kilo*:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(53, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Precio Venta*:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Rentabilidad*:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(53, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Precio Costo*:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(53, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Codigo Producto*:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lista Precio*:"
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.LBListaPrecioDescripcion)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.TBPrecioKilo)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.Controls.Add(Me.TBPrecioVenta)
        Me.PanelEx1.Controls.Add(Me.Label3)
        Me.PanelEx1.Controls.Add(Me.TBRentabilidad)
        Me.PanelEx1.Controls.Add(Me.Label4)
        Me.PanelEx1.Controls.Add(Me.TBPrecioCosto)
        Me.PanelEx1.Controls.Add(Me.Label5)
        Me.PanelEx1.Controls.Add(Me.TBCodigoProducto)
        Me.PanelEx1.Controls.Add(Me.LBPrecioKilo)
        Me.PanelEx1.Controls.Add(Me.CBListaPrecio)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(1, 44)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(357, 235)
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
        'Articulos_ListaPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(359, 281)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(450, 200)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(375, 319)
        Me.MinimizeBox = False
        Me.Name = "Articulos_ListaPrecios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Lista Precios"
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProgressBarArticulosListaPrecio As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarArticuloListaPrecio As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirArticuloListaPrecio As System.Windows.Forms.ToolStripButton
    Friend WithEvents TBPrecioKilo As System.Windows.Forms.TextBox
    Friend WithEvents TBPrecioVenta As System.Windows.Forms.TextBox
    Friend WithEvents TBRentabilidad As System.Windows.Forms.TextBox
    Friend WithEvents TBPrecioCosto As System.Windows.Forms.TextBox
    Friend WithEvents TBCodigoProducto As System.Windows.Forms.TextBox
    Friend WithEvents CBListaPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents LBPrecioKilo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LBListaPrecioDescripcion As System.Windows.Forms.Label
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
End Class
