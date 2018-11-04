<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmLoginForm
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
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoginForm))
        Me.UsernameLabel = New System.Windows.Forms.Label
        Me.PasswordLabel = New System.Windows.Forms.Label
        Me.UsernameTextBox = New System.Windows.Forms.TextBox
        Me.PasswordTextBox = New System.Windows.Forms.TextBox
        Me.OK = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(11, 8)
        Me.UsernameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(293, 31)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "&Nombre de usuario"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.Color.Transparent
        Me.PasswordLabel.Location = New System.Drawing.Point(11, 88)
        Me.PasswordLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(293, 30)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "&Contraseña"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.UsernameTextBox.Location = New System.Drawing.Point(11, 43)
        Me.UsernameTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(292, 26)
        Me.UsernameTextBox.TabIndex = 1
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PasswordTextBox.Location = New System.Drawing.Point(11, 122)
        Me.PasswordTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(292, 26)
        Me.PasswordTextBox.TabIndex = 3
        '
        'OK
        '
        Me.OK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OK.Location = New System.Drawing.Point(16, 173)
        Me.OK.Margin = New System.Windows.Forms.Padding(4)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(125, 32)
        Me.OK.TabIndex = 4
        Me.OK.Text = "&Aceptar"
        '
        'Cancel
        '
        Me.Cancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(177, 173)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(125, 32)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "&Cancelar"
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
        Me.PanelEx1.Controls.Add(Me.Cancel)
        Me.PanelEx1.Controls.Add(Me.OK)
        Me.PanelEx1.Controls.Add(Me.PasswordTextBox)
        Me.PanelEx1.Controls.Add(Me.UsernameTextBox)
        Me.PanelEx1.Controls.Add(Me.UsernameLabel)
        Me.PanelEx1.Controls.Add(Me.PasswordLabel)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(1, 1)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(318, 232)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(175, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.DoubleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 6
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'frmLoginForm
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(321, 235)
        Me.Controls.Add(Me.PanelEx1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoginForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Logueo"
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager

End Class
