<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticulos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProgressBarArticulo = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripNuevoArticulo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripModificarArticulo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripEliminarArticulo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButtonCargarExcel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.SalirArticulo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripEnviarArticulo = New System.Windows.Forms.ToolStripButton
        Me.DGVArticulo = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TBBusquedaArticulo = New System.Windows.Forms.TextBox
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGVArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBarArticulo, Me.ToolStripSeparator1, Me.ToolStripNuevoArticulo, Me.ToolStripSeparator2, Me.ToolStripModificarArticulo, Me.ToolStripSeparator3, Me.ToolStripEliminarArticulo, Me.ToolStripSeparator4, Me.ToolStripButtonCargarExcel, Me.ToolStripSeparator5, Me.SalirArticulo, Me.ToolStripEnviarArticulo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(738, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProgressBarArticulo
        '
        Me.ProgressBarArticulo.Name = "ProgressBarArticulo"
        Me.ProgressBarArticulo.Size = New System.Drawing.Size(116, 36)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripNuevoArticulo
        '
        Me.ToolStripNuevoArticulo.AutoToolTip = False
        Me.ToolStripNuevoArticulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripNuevoArticulo.Image = CType(resources.GetObject("ToolStripNuevoArticulo.Image"), System.Drawing.Image)
        Me.ToolStripNuevoArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripNuevoArticulo.Name = "ToolStripNuevoArticulo"
        Me.ToolStripNuevoArticulo.Size = New System.Drawing.Size(36, 36)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripNuevoArticulo, New DevComponents.DotNetBar.SuperTooltipInfo("Nuevo", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.ToolStripNuevoArticulo.Text = "Nuevo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripModificarArticulo
        '
        Me.ToolStripModificarArticulo.AutoToolTip = False
        Me.ToolStripModificarArticulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripModificarArticulo.Image = CType(resources.GetObject("ToolStripModificarArticulo.Image"), System.Drawing.Image)
        Me.ToolStripModificarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripModificarArticulo.Name = "ToolStripModificarArticulo"
        Me.ToolStripModificarArticulo.Size = New System.Drawing.Size(36, 36)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripModificarArticulo, New DevComponents.DotNetBar.SuperTooltipInfo("Modificar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(62, 21)))
        Me.ToolStripModificarArticulo.Text = "Modificar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripEliminarArticulo
        '
        Me.ToolStripEliminarArticulo.AutoToolTip = False
        Me.ToolStripEliminarArticulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripEliminarArticulo.Image = CType(resources.GetObject("ToolStripEliminarArticulo.Image"), System.Drawing.Image)
        Me.ToolStripEliminarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripEliminarArticulo.Name = "ToolStripEliminarArticulo"
        Me.ToolStripEliminarArticulo.Size = New System.Drawing.Size(36, 36)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripEliminarArticulo, New DevComponents.DotNetBar.SuperTooltipInfo("Eliminar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.ToolStripEliminarArticulo.Text = "Eliminar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButtonCargarExcel
        '
        Me.ToolStripButtonCargarExcel.AutoToolTip = False
        Me.ToolStripButtonCargarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonCargarExcel.Image = CType(resources.GetObject("ToolStripButtonCargarExcel.Image"), System.Drawing.Image)
        Me.ToolStripButtonCargarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCargarExcel.Name = "ToolStripButtonCargarExcel"
        Me.ToolStripButtonCargarExcel.Size = New System.Drawing.Size(36, 36)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripButtonCargarExcel, New DevComponents.DotNetBar.SuperTooltipInfo("Importar Articulos desde Excel", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue))
        Me.ToolStripButtonCargarExcel.Text = "Importar Articulos desde Excel"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 39)
        '
        'SalirArticulo
        '
        Me.SalirArticulo.AutoToolTip = False
        Me.SalirArticulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SalirArticulo.Image = CType(resources.GetObject("SalirArticulo.Image"), System.Drawing.Image)
        Me.SalirArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SalirArticulo.Name = "SalirArticulo"
        Me.SalirArticulo.Size = New System.Drawing.Size(36, 36)
        Me.SuperTooltip1.SetSuperTooltip(Me.SalirArticulo, New DevComponents.DotNetBar.SuperTooltipInfo("Salir", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.SalirArticulo.Text = "Salir"
        '
        'ToolStripEnviarArticulo
        '
        Me.ToolStripEnviarArticulo.AutoToolTip = False
        Me.ToolStripEnviarArticulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripEnviarArticulo.Image = CType(resources.GetObject("ToolStripEnviarArticulo.Image"), System.Drawing.Image)
        Me.ToolStripEnviarArticulo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripEnviarArticulo.Name = "ToolStripEnviarArticulo"
        Me.ToolStripEnviarArticulo.Size = New System.Drawing.Size(36, 36)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripEnviarArticulo, New DevComponents.DotNetBar.SuperTooltipInfo("Enviar Articulo", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(93, 21)))
        Me.ToolStripEnviarArticulo.Text = "Enviar Articulo"
        '
        'DGVArticulo
        '
        Me.DGVArticulo.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVArticulo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVArticulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGVArticulo.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVArticulo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticulo.Location = New System.Drawing.Point(6, 5)
        Me.DGVArticulo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DGVArticulo.Name = "DGVArticulo"
        Me.DGVArticulo.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVArticulo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVArticulo.RowHeadersVisible = False
        Me.DGVArticulo.Size = New System.Drawing.Size(727, 360)
        Me.DGVArticulo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(150, 371)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Busqueda Por"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(220, 371)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 15)
        Me.Label2.TabIndex = 3
        '
        'TBBusquedaArticulo
        '
        Me.TBBusquedaArticulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBBusquedaArticulo.Location = New System.Drawing.Point(149, 389)
        Me.TBBusquedaArticulo.Name = "TBBusquedaArticulo"
        Me.TBBusquedaArticulo.Size = New System.Drawing.Size(484, 23)
        Me.TBBusquedaArticulo.TabIndex = 4
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.DGVArticulo)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.TBBusquedaArticulo)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(0, 42)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(738, 424)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 5
        Me.PanelEx1.Tag = "XC"
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
        'Articulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 470)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PanelEx1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(310, 140)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Articulos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Articulos"
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGVArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProgressBarArticulo As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripNuevoArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripModificarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripEliminarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents DGVArticulo As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBBusquedaArticulo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripEnviarArticulo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCargarExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
End Class
