<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpresa))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProgressBarEmpresa = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripNuevaEmpresa = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripModificarEmpresa = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripEliminarEmpresa = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSalirEmpresa = New System.Windows.Forms.ToolStripButton
        Me.DGVEmpresa = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.TBBusqueda = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DGVEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBarEmpresa, Me.ToolStripSeparator1, Me.ToolStripNuevaEmpresa, Me.ToolStripSeparator2, Me.ToolStripModificarEmpresa, Me.ToolStripSeparator3, Me.ToolStripEliminarEmpresa, Me.ToolStripSeparator4, Me.ToolStripSalirEmpresa})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(727, 45)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProgressBarEmpresa
        '
        Me.ProgressBarEmpresa.Name = "ProgressBarEmpresa"
        Me.ProgressBarEmpresa.Size = New System.Drawing.Size(117, 42)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripNuevaEmpresa
        '
        Me.ToolStripNuevaEmpresa.AutoToolTip = False
        Me.ToolStripNuevaEmpresa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripNuevaEmpresa.Image = CType(resources.GetObject("ToolStripNuevaEmpresa.Image"), System.Drawing.Image)
        Me.ToolStripNuevaEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripNuevaEmpresa.Name = "ToolStripNuevaEmpresa"
        Me.ToolStripNuevaEmpresa.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripNuevaEmpresa, New DevComponents.DotNetBar.SuperTooltipInfo("Nuevo", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(65, 21)))
        Me.ToolStripNuevaEmpresa.Text = "Nuevo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripModificarEmpresa
        '
        Me.ToolStripModificarEmpresa.AutoToolTip = False
        Me.ToolStripModificarEmpresa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripModificarEmpresa.Image = CType(resources.GetObject("ToolStripModificarEmpresa.Image"), System.Drawing.Image)
        Me.ToolStripModificarEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripModificarEmpresa.Name = "ToolStripModificarEmpresa"
        Me.ToolStripModificarEmpresa.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripModificarEmpresa, New DevComponents.DotNetBar.SuperTooltipInfo("Modificar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(65, 21)))
        Me.ToolStripModificarEmpresa.Text = "Modificar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripEliminarEmpresa
        '
        Me.ToolStripEliminarEmpresa.AutoToolTip = False
        Me.ToolStripEliminarEmpresa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripEliminarEmpresa.Image = CType(resources.GetObject("ToolStripEliminarEmpresa.Image"), System.Drawing.Image)
        Me.ToolStripEliminarEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripEliminarEmpresa.Name = "ToolStripEliminarEmpresa"
        Me.ToolStripEliminarEmpresa.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripEliminarEmpresa, New DevComponents.DotNetBar.SuperTooltipInfo("Eliminar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.ToolStripEliminarEmpresa.Text = "Eliminar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripSalirEmpresa
        '
        Me.ToolStripSalirEmpresa.AutoToolTip = False
        Me.ToolStripSalirEmpresa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSalirEmpresa.Image = CType(resources.GetObject("ToolStripSalirEmpresa.Image"), System.Drawing.Image)
        Me.ToolStripSalirEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSalirEmpresa.Name = "ToolStripSalirEmpresa"
        Me.ToolStripSalirEmpresa.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripSalirEmpresa, New DevComponents.DotNetBar.SuperTooltipInfo("Salir", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.ToolStripSalirEmpresa.Text = "Salir"
        '
        'DGVEmpresa
        '
        Me.DGVEmpresa.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DGVEmpresa.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVEmpresa.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVEmpresa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGVEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVEmpresa.Location = New System.Drawing.Point(3, 4)
        Me.DGVEmpresa.Name = "DGVEmpresa"
        Me.DGVEmpresa.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVEmpresa.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVEmpresa.RowHeadersVisible = False
        Me.DGVEmpresa.Size = New System.Drawing.Size(715, 237)
        Me.DGVEmpresa.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(206, 252)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Busqueda Por"
        '
        'TBBusqueda
        '
        Me.TBBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBBusqueda.Location = New System.Drawing.Point(203, 270)
        Me.TBBusqueda.Name = "TBBusqueda"
        Me.TBBusqueda.Size = New System.Drawing.Size(304, 23)
        Me.TBBusqueda.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(280, 252)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 15)
        Me.Label2.TabIndex = 4
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
        Me.PanelEx1.Controls.Add(Me.DGVEmpresa)
        Me.PanelEx1.Controls.Add(Me.Label2)
        Me.PanelEx1.Controls.Add(Me.TBBusqueda)
        Me.PanelEx1.Controls.Add(Me.Label1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(3, 49)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(721, 308)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 5
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue)
        '
        'Empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 361)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(310, 200)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Empresa"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Empresa"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DGVEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProgressBarEmpresa As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripNuevaEmpresa As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripModificarEmpresa As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripEliminarEmpresa As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSalirEmpresa As System.Windows.Forms.ToolStripButton
    Friend WithEvents DGVEmpresa As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
End Class
