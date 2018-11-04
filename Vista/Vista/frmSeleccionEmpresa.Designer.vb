<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionEmpresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionEmpresa))
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.dgvSeleccionEmpresa = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripCrearEmpresa = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeleccionarEmpresa = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSalir = New System.Windows.Forms.ToolStripButton
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSeleccionEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
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
        'dgvSeleccionEmpresa
        '
        Me.dgvSeleccionEmpresa.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvSeleccionEmpresa.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSeleccionEmpresa.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSeleccionEmpresa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSeleccionEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSeleccionEmpresa.Location = New System.Drawing.Point(6, 48)
        Me.dgvSeleccionEmpresa.Name = "dgvSeleccionEmpresa"
        Me.dgvSeleccionEmpresa.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSeleccionEmpresa.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSeleccionEmpresa.RowHeadersVisible = False
        Me.dgvSeleccionEmpresa.Size = New System.Drawing.Size(906, 333)
        Me.dgvSeleccionEmpresa.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(36, 36)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripSeparator1, Me.ToolStripCrearEmpresa, Me.ToolStripSeparator2, Me.ToolStripSeleccionarEmpresa, Me.ToolStripSeparator3, Me.ToolStripSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(918, 43)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripProgressBar
        '
        Me.ToolStripProgressBar.Name = "ToolStripProgressBar"
        Me.ToolStripProgressBar.Size = New System.Drawing.Size(100, 40)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 43)
        '
        'ToolStripCrearEmpresa
        '
        Me.ToolStripCrearEmpresa.AutoToolTip = False
        Me.ToolStripCrearEmpresa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripCrearEmpresa.Image = CType(resources.GetObject("ToolStripCrearEmpresa.Image"), System.Drawing.Image)
        Me.ToolStripCrearEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripCrearEmpresa.Name = "ToolStripCrearEmpresa"
        Me.ToolStripCrearEmpresa.Size = New System.Drawing.Size(40, 40)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripCrearEmpresa, New DevComponents.DotNetBar.SuperTooltipInfo("Crear Empresa", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(100, 21)))
        Me.ToolStripCrearEmpresa.Text = "Crear Empresa"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 43)
        '
        'ToolStripSeleccionarEmpresa
        '
        Me.ToolStripSeleccionarEmpresa.AutoToolTip = False
        Me.ToolStripSeleccionarEmpresa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSeleccionarEmpresa.Image = CType(resources.GetObject("ToolStripSeleccionarEmpresa.Image"), System.Drawing.Image)
        Me.ToolStripSeleccionarEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSeleccionarEmpresa.Name = "ToolStripSeleccionarEmpresa"
        Me.ToolStripSeleccionarEmpresa.Size = New System.Drawing.Size(40, 40)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripSeleccionarEmpresa, New DevComponents.DotNetBar.SuperTooltipInfo("Seleccionar Empresa", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(125, 21)))
        Me.ToolStripSeleccionarEmpresa.Text = "Seleccionar Empresa"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 43)
        '
        'ToolStripSalir
        '
        Me.ToolStripSalir.AutoToolTip = False
        Me.ToolStripSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSalir.Image = CType(resources.GetObject("ToolStripSalir.Image"), System.Drawing.Image)
        Me.ToolStripSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSalir.Name = "ToolStripSalir"
        Me.ToolStripSalir.Size = New System.Drawing.Size(40, 40)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripSalir, New DevComponents.DotNetBar.SuperTooltipInfo("Salir de la Aplicacion", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(122, 20)))
        Me.ToolStripSalir.Text = "Salir"
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(1, 43)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(917, 344)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 3
        Me.PanelEx1.Text = "1"
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, False, New System.Drawing.Size(100, 18))
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'frmSeleccionEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 388)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgvSeleccionEmpresa)
        Me.Controls.Add(Me.PanelEx1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccion Empresa"
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSeleccionEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents dgvSeleccionEmpresa As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripCrearEmpresa As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeleccionarEmpresa As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
End Class
