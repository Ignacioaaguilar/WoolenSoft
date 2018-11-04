<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarComprobante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarComprobante))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripEnviar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSalir = New System.Windows.Forms.ToolStripButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.tbCondicionIVA = New System.Windows.Forms.TextBox
        Me.tbNombre = New System.Windows.Forms.TextBox
        Me.tbApellido = New System.Windows.Forms.TextBox
        Me.tbComprobante = New System.Windows.Forms.TextBox
        Me.tbNumeroComprobante = New System.Windows.Forms.TextBox
        Me.tbTipoComprobante = New System.Windows.Forms.TextBox
        Me.tbPuntoVenta = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbBusqueda = New System.Windows.Forms.TextBox
        Me.dgvBuscarComprobante = New System.Windows.Forms.DataGridView
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvBuscarComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
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
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar, Me.ToolStripSeparator1, Me.ToolStripEnviar, Me.ToolStripSeparator2, Me.ToolStripSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(749, 45)
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
        'ToolStripEnviar
        '
        Me.ToolStripEnviar.AutoToolTip = False
        Me.ToolStripEnviar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripEnviar.Image = CType(resources.GetObject("ToolStripEnviar.Image"), System.Drawing.Image)
        Me.ToolStripEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripEnviar.Name = "ToolStripEnviar"
        Me.ToolStripEnviar.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripEnviar, New DevComponents.DotNetBar.SuperTooltipInfo("Enviar Comprobante", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(121, 21)))
        Me.ToolStripEnviar.Text = "Seleccionar Comprobante"
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(299, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 15)
        Me.Label9.TabIndex = 4
        '
        'tbCondicionIVA
        '
        Me.tbCondicionIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbCondicionIVA.Location = New System.Drawing.Point(582, 39)
        Me.tbCondicionIVA.Name = "tbCondicionIVA"
        Me.tbCondicionIVA.ReadOnly = True
        Me.tbCondicionIVA.Size = New System.Drawing.Size(135, 23)
        Me.tbCondicionIVA.TabIndex = 13
        '
        'tbNombre
        '
        Me.tbNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbNombre.Location = New System.Drawing.Point(343, 69)
        Me.tbNombre.Name = "tbNombre"
        Me.tbNombre.ReadOnly = True
        Me.tbNombre.Size = New System.Drawing.Size(135, 23)
        Me.tbNombre.TabIndex = 12
        '
        'tbApellido
        '
        Me.tbApellido.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbApellido.Location = New System.Drawing.Point(343, 39)
        Me.tbApellido.Name = "tbApellido"
        Me.tbApellido.ReadOnly = True
        Me.tbApellido.Size = New System.Drawing.Size(135, 23)
        Me.tbApellido.TabIndex = 11
        '
        'tbComprobante
        '
        Me.tbComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbComprobante.Location = New System.Drawing.Point(343, 10)
        Me.tbComprobante.Name = "tbComprobante"
        Me.tbComprobante.ReadOnly = True
        Me.tbComprobante.Size = New System.Drawing.Size(135, 23)
        Me.tbComprobante.TabIndex = 10
        '
        'tbNumeroComprobante
        '
        Me.tbNumeroComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbNumeroComprobante.Location = New System.Drawing.Point(137, 69)
        Me.tbNumeroComprobante.Name = "tbNumeroComprobante"
        Me.tbNumeroComprobante.ReadOnly = True
        Me.tbNumeroComprobante.Size = New System.Drawing.Size(100, 23)
        Me.tbNumeroComprobante.TabIndex = 9
        '
        'tbTipoComprobante
        '
        Me.tbTipoComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbTipoComprobante.Location = New System.Drawing.Point(137, 39)
        Me.tbTipoComprobante.Name = "tbTipoComprobante"
        Me.tbTipoComprobante.ReadOnly = True
        Me.tbTipoComprobante.Size = New System.Drawing.Size(100, 23)
        Me.tbTipoComprobante.TabIndex = 8
        '
        'tbPuntoVenta
        '
        Me.tbPuntoVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbPuntoVenta.Location = New System.Drawing.Point(137, 10)
        Me.tbPuntoVenta.Name = "tbPuntoVenta"
        Me.tbPuntoVenta.ReadOnly = True
        Me.tbPuntoVenta.Size = New System.Drawing.Size(100, 23)
        Me.tbPuntoVenta.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(494, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Condicion IVA:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(261, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Apellido:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Punto Venta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(263, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(261, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Comprobante:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Numero Comprobante:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo Comprobante:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(222, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Busqueda por"
        '
        'tbBusqueda
        '
        Me.tbBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tbBusqueda.Location = New System.Drawing.Point(228, 435)
        Me.tbBusqueda.Name = "tbBusqueda"
        Me.tbBusqueda.Size = New System.Drawing.Size(306, 23)
        Me.tbBusqueda.TabIndex = 3
        '
        'dgvBuscarComprobante
        '
        Me.dgvBuscarComprobante.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvBuscarComprobante.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBuscarComprobante.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBuscarComprobante.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBuscarComprobante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBuscarComprobante.Location = New System.Drawing.Point(7, 128)
        Me.dgvBuscarComprobante.Name = "dgvBuscarComprobante"
        Me.dgvBuscarComprobante.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBuscarComprobante.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBuscarComprobante.RowHeadersVisible = False
        Me.dgvBuscarComprobante.Size = New System.Drawing.Size(734, 279)
        Me.dgvBuscarComprobante.TabIndex = 0
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.PanelEx2)
        Me.PanelEx1.Controls.Add(Me.dgvBuscarComprobante)
        Me.PanelEx1.Controls.Add(Me.tbBusqueda)
        Me.PanelEx1.Controls.Add(Me.GroupBox1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(0, 46)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(748, 469)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 6
        '
        'PanelEx2
        '
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.tbCondicionIVA)
        Me.PanelEx2.Controls.Add(Me.Label5)
        Me.PanelEx2.Controls.Add(Me.tbNombre)
        Me.PanelEx2.Controls.Add(Me.Label1)
        Me.PanelEx2.Controls.Add(Me.tbApellido)
        Me.PanelEx2.Controls.Add(Me.Label2)
        Me.PanelEx2.Controls.Add(Me.tbComprobante)
        Me.PanelEx2.Controls.Add(Me.Label3)
        Me.PanelEx2.Controls.Add(Me.tbNumeroComprobante)
        Me.PanelEx2.Controls.Add(Me.Label4)
        Me.PanelEx2.Controls.Add(Me.tbTipoComprobante)
        Me.PanelEx2.Controls.Add(Me.Label6)
        Me.PanelEx2.Controls.Add(Me.tbPuntoVenta)
        Me.PanelEx2.Controls.Add(Me.Label7)
        Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx2.Location = New System.Drawing.Point(7, 9)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(734, 113)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.PanelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 408)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(734, 55)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "XC"
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
        'frmBuscarComprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 516)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarComprobante"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Comprobante"
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvBuscarComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.PanelEx2.ResumeLayout(False)
        Me.PanelEx2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripEnviar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvBuscarComprobante As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbCondicionIVA As System.Windows.Forms.TextBox
    Friend WithEvents tbNombre As System.Windows.Forms.TextBox
    Friend WithEvents tbApellido As System.Windows.Forms.TextBox
    Friend WithEvents tbComprobante As System.Windows.Forms.TextBox
    Friend WithEvents tbNumeroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents tbTipoComprobante As System.Windows.Forms.TextBox
    Friend WithEvents tbPuntoVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
