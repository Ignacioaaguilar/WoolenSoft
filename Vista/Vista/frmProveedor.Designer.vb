<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedor))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProgressBarProveedor = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripNuevoProveedor = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripModificarProveedor = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripEliminarProveedor = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSalirProveedor = New System.Windows.Forms.ToolStripButton
        Me.ToolStripEnviarProveedor = New System.Windows.Forms.ToolStripButton
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.DGVProveedor = New System.Windows.Forms.DataGridView
        Me.TBBusqueda = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBarProveedor, Me.ToolStripSeparator1, Me.ToolStripNuevoProveedor, Me.ToolStripSeparator2, Me.ToolStripModificarProveedor, Me.ToolStripSeparator3, Me.ToolStripEliminarProveedor, Me.ToolStripSeparator4, Me.ToolStripSalirProveedor, Me.ToolStripEnviarProveedor})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(760, 45)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProgressBarProveedor
        '
        Me.ProgressBarProveedor.Name = "ProgressBarProveedor"
        Me.ProgressBarProveedor.Size = New System.Drawing.Size(117, 42)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripNuevoProveedor
        '
        Me.ToolStripNuevoProveedor.AutoToolTip = False
        Me.ToolStripNuevoProveedor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripNuevoProveedor.Image = CType(resources.GetObject("ToolStripNuevoProveedor.Image"), System.Drawing.Image)
        Me.ToolStripNuevoProveedor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripNuevoProveedor.Name = "ToolStripNuevoProveedor"
        Me.ToolStripNuevoProveedor.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripNuevoProveedor, New DevComponents.DotNetBar.SuperTooltipInfo("Agregar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(65, 21)))
        Me.ToolStripNuevoProveedor.Text = "Agregar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripModificarProveedor
        '
        Me.ToolStripModificarProveedor.AutoToolTip = False
        Me.ToolStripModificarProveedor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripModificarProveedor.Image = CType(resources.GetObject("ToolStripModificarProveedor.Image"), System.Drawing.Image)
        Me.ToolStripModificarProveedor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripModificarProveedor.Name = "ToolStripModificarProveedor"
        Me.ToolStripModificarProveedor.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripModificarProveedor, New DevComponents.DotNetBar.SuperTooltipInfo("Modificar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(65, 21)))
        Me.ToolStripModificarProveedor.Text = "Modificar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripEliminarProveedor
        '
        Me.ToolStripEliminarProveedor.AutoToolTip = False
        Me.ToolStripEliminarProveedor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripEliminarProveedor.Image = CType(resources.GetObject("ToolStripEliminarProveedor.Image"), System.Drawing.Image)
        Me.ToolStripEliminarProveedor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripEliminarProveedor.Name = "ToolStripEliminarProveedor"
        Me.ToolStripEliminarProveedor.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripEliminarProveedor, New DevComponents.DotNetBar.SuperTooltipInfo("Eliminar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.ToolStripEliminarProveedor.Text = "Eliminar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripSalirProveedor
        '
        Me.ToolStripSalirProveedor.AutoToolTip = False
        Me.ToolStripSalirProveedor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSalirProveedor.Image = CType(resources.GetObject("ToolStripSalirProveedor.Image"), System.Drawing.Image)
        Me.ToolStripSalirProveedor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSalirProveedor.Name = "ToolStripSalirProveedor"
        Me.ToolStripSalirProveedor.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripSalirProveedor, New DevComponents.DotNetBar.SuperTooltipInfo("Salir", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.ToolStripSalirProveedor.Text = "Salir"
        '
        'ToolStripEnviarProveedor
        '
        Me.ToolStripEnviarProveedor.AutoToolTip = False
        Me.ToolStripEnviarProveedor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripEnviarProveedor.Image = CType(resources.GetObject("ToolStripEnviarProveedor.Image"), System.Drawing.Image)
        Me.ToolStripEnviarProveedor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripEnviarProveedor.Name = "ToolStripEnviarProveedor"
        Me.ToolStripEnviarProveedor.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripEnviarProveedor, New DevComponents.DotNetBar.SuperTooltipInfo("Enviar Proveedor", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(103, 21)))
        Me.ToolStripEnviarProveedor.Text = "Enviar Proveedor"
        '
        'VisualStyler1
        '
        Me.VisualStyler1.HostForm = Me
        Me.VisualStyler1.License = CType(resources.GetObject("VisualStyler1.License"), SkinSoft.VisualStyler.Licensing.VisualStylerLicense)
        Me.VisualStyler1.ShadowStyle = SkinSoft.VisualStyler.ShadowStyle.Bold
        Me.VisualStyler1.ToolStripStyle = SkinSoft.VisualStyler.ToolStripRenderStyle.Professional
        Me.VisualStyler1.LoadVisualStyle(Nothing, "Office2007 (Blue).vssf")
        '
        'DGVProveedor
        '
        Me.DGVProveedor.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVProveedor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVProveedor.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVProveedor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProveedor.Location = New System.Drawing.Point(4, 5)
        Me.DGVProveedor.Name = "DGVProveedor"
        Me.DGVProveedor.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVProveedor.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVProveedor.RowHeadersVisible = False
        Me.DGVProveedor.Size = New System.Drawing.Size(751, 287)
        Me.DGVProveedor.TabIndex = 1
        '
        'TBBusqueda
        '
        Me.TBBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBBusqueda.Location = New System.Drawing.Point(173, 319)
        Me.TBBusqueda.Name = "TBBusqueda"
        Me.TBBusqueda.Size = New System.Drawing.Size(405, 23)
        Me.TBBusqueda.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 302)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Busqueda Por"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(249, 302)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 15)
        Me.Label2.TabIndex = 4
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.Controls.Add(Me.TBBusqueda)
        Me.PanelEx1.Controls.Add(Me.DGVProveedor)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(0, 47)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(759, 354)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 5
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
        'Proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 403)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(260, 200)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Proveedor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Proveedor"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProgressBarProveedor As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripNuevoProveedor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripModificarProveedor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripEliminarProveedor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSalirProveedor As System.Windows.Forms.ToolStripButton
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents DGVProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents TBBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents ToolStripEnviarProveedor As System.Windows.Forms.ToolStripButton
End Class
