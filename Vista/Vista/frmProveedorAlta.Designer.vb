<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedorAlta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProveedorAlta))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProgressBarProveedorAlta = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripGurdarProveedorAlta = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSalirProveedorAlta = New System.Windows.Forms.ToolStripButton
        Me.TBCelular = New System.Windows.Forms.TextBox
        Me.TBTelefono = New System.Windows.Forms.TextBox
        Me.TBEmail = New System.Windows.Forms.TextBox
        Me.TBRazonSocial = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TBCuitProveedor3 = New System.Windows.Forms.TextBox
        Me.TBCuitProveedor2 = New System.Windows.Forms.TextBox
        Me.TBCuitProveedor1 = New System.Windows.Forms.TextBox
        Me.CBResponsabilidadIVA = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CBProvincia = New System.Windows.Forms.ComboBox
        Me.TBCodigoPostal = New System.Windows.Forms.TextBox
        Me.TBLocalidad = New System.Windows.Forms.TextBox
        Me.TBNumero = New System.Windows.Forms.TextBox
        Me.TBPiso = New System.Windows.Forms.TextBox
        Me.TBCalle = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TBSaldoCorriente = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProgressBarProveedorAlta, Me.ToolStripSeparator1, Me.ToolStripGurdarProveedorAlta, Me.ToolStripSeparator2, Me.ToolStripSalirProveedorAlta})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(749, 45)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProgressBarProveedorAlta
        '
        Me.ProgressBarProveedorAlta.Name = "ProgressBarProveedorAlta"
        Me.ProgressBarProveedorAlta.Size = New System.Drawing.Size(117, 42)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripGurdarProveedorAlta
        '
        Me.ToolStripGurdarProveedorAlta.AutoToolTip = False
        Me.ToolStripGurdarProveedorAlta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripGurdarProveedorAlta.Image = CType(resources.GetObject("ToolStripGurdarProveedorAlta.Image"), System.Drawing.Image)
        Me.ToolStripGurdarProveedorAlta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripGurdarProveedorAlta.Name = "ToolStripGurdarProveedorAlta"
        Me.ToolStripGurdarProveedorAlta.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripGurdarProveedorAlta, New DevComponents.DotNetBar.SuperTooltipInfo("Registrar", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(65, 18)))
        Me.ToolStripGurdarProveedorAlta.Text = "Registrar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 45)
        '
        'ToolStripSalirProveedorAlta
        '
        Me.ToolStripSalirProveedorAlta.AutoToolTip = False
        Me.ToolStripSalirProveedorAlta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSalirProveedorAlta.Image = CType(resources.GetObject("ToolStripSalirProveedorAlta.Image"), System.Drawing.Image)
        Me.ToolStripSalirProveedorAlta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSalirProveedorAlta.Name = "ToolStripSalirProveedorAlta"
        Me.ToolStripSalirProveedorAlta.Size = New System.Drawing.Size(36, 42)
        Me.SuperTooltip1.SetSuperTooltip(Me.ToolStripSalirProveedorAlta, New DevComponents.DotNetBar.SuperTooltipInfo("Salir", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue, True, True, New System.Drawing.Size(60, 21)))
        Me.ToolStripSalirProveedorAlta.Text = "Salir"
        '
        'TBCelular
        '
        Me.TBCelular.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBCelular.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCelular.Location = New System.Drawing.Point(475, 44)
        Me.TBCelular.Name = "TBCelular"
        Me.TBCelular.Size = New System.Drawing.Size(163, 26)
        Me.TBCelular.TabIndex = 9
        '
        'TBTelefono
        '
        Me.TBTelefono.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBTelefono.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBTelefono.Location = New System.Drawing.Point(474, 14)
        Me.TBTelefono.Name = "TBTelefono"
        Me.TBTelefono.Size = New System.Drawing.Size(164, 26)
        Me.TBTelefono.TabIndex = 8
        '
        'TBEmail
        '
        Me.TBEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBEmail.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBEmail.Location = New System.Drawing.Point(102, 45)
        Me.TBEmail.Name = "TBEmail"
        Me.TBEmail.Size = New System.Drawing.Size(193, 26)
        Me.TBEmail.TabIndex = 7
        '
        'TBRazonSocial
        '
        Me.TBRazonSocial.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBRazonSocial.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBRazonSocial.Location = New System.Drawing.Point(102, 14)
        Me.TBRazonSocial.Name = "TBRazonSocial"
        Me.TBRazonSocial.Size = New System.Drawing.Size(193, 26)
        Me.TBRazonSocial.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.TBCuitProveedor3)
        Me.GroupBox2.Controls.Add(Me.TBCuitProveedor2)
        Me.GroupBox2.Controls.Add(Me.TBCuitProveedor1)
        Me.GroupBox2.Controls.Add(Me.CBResponsabilidadIVA)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(388, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(340, 106)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "XC"
        Me.GroupBox2.Text = "Fiscal"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(281, 28)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(11, 15)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "-"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(169, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 15)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "-"
        '
        'TBCuitProveedor3
        '
        Me.TBCuitProveedor3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBCuitProveedor3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCuitProveedor3.Location = New System.Drawing.Point(293, 22)
        Me.TBCuitProveedor3.MaxLength = 1
        Me.TBCuitProveedor3.Name = "TBCuitProveedor3"
        Me.TBCuitProveedor3.Size = New System.Drawing.Size(18, 26)
        Me.TBCuitProveedor3.TabIndex = 5
        '
        'TBCuitProveedor2
        '
        Me.TBCuitProveedor2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBCuitProveedor2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCuitProveedor2.Location = New System.Drawing.Point(181, 22)
        Me.TBCuitProveedor2.MaxLength = 8
        Me.TBCuitProveedor2.Name = "TBCuitProveedor2"
        Me.TBCuitProveedor2.Size = New System.Drawing.Size(100, 26)
        Me.TBCuitProveedor2.TabIndex = 4
        '
        'TBCuitProveedor1
        '
        Me.TBCuitProveedor1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBCuitProveedor1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCuitProveedor1.Location = New System.Drawing.Point(146, 22)
        Me.TBCuitProveedor1.MaxLength = 2
        Me.TBCuitProveedor1.Name = "TBCuitProveedor1"
        Me.TBCuitProveedor1.Size = New System.Drawing.Size(23, 26)
        Me.TBCuitProveedor1.TabIndex = 3
        '
        'CBResponsabilidadIVA
        '
        Me.CBResponsabilidadIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBResponsabilidadIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBResponsabilidadIVA.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBResponsabilidadIVA.FormattingEnabled = True
        Me.CBResponsabilidadIVA.Location = New System.Drawing.Point(146, 59)
        Me.CBResponsabilidadIVA.Name = "CBResponsabilidadIVA"
        Me.CBResponsabilidadIVA.Size = New System.Drawing.Size(165, 26)
        Me.CBResponsabilidadIVA.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 16)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Responsabilidad IVA*:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "CUIT:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CBProvincia)
        Me.GroupBox1.Controls.Add(Me.TBCodigoPostal)
        Me.GroupBox1.Controls.Add(Me.TBLocalidad)
        Me.GroupBox1.Controls.Add(Me.TBNumero)
        Me.GroupBox1.Controls.Add(Me.TBPiso)
        Me.GroupBox1.Controls.Add(Me.TBCalle)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(327, 218)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "XC"
        Me.GroupBox1.Text = "Domicilio"
        '
        'CBProvincia
        '
        Me.CBProvincia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBProvincia.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBProvincia.FormattingEnabled = True
        Me.CBProvincia.Location = New System.Drawing.Point(91, 151)
        Me.CBProvincia.Name = "CBProvincia"
        Me.CBProvincia.Size = New System.Drawing.Size(144, 26)
        Me.CBProvincia.TabIndex = 12
        '
        'TBCodigoPostal
        '
        Me.TBCodigoPostal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBCodigoPostal.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCodigoPostal.Location = New System.Drawing.Point(92, 184)
        Me.TBCodigoPostal.MaxLength = 4
        Me.TBCodigoPostal.Name = "TBCodigoPostal"
        Me.TBCodigoPostal.Size = New System.Drawing.Size(105, 26)
        Me.TBCodigoPostal.TabIndex = 11
        '
        'TBLocalidad
        '
        Me.TBLocalidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBLocalidad.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBLocalidad.Location = New System.Drawing.Point(91, 118)
        Me.TBLocalidad.Name = "TBLocalidad"
        Me.TBLocalidad.Size = New System.Drawing.Size(182, 26)
        Me.TBLocalidad.TabIndex = 9
        '
        'TBNumero
        '
        Me.TBNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBNumero.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBNumero.Location = New System.Drawing.Point(91, 84)
        Me.TBNumero.MaxLength = 6
        Me.TBNumero.Name = "TBNumero"
        Me.TBNumero.Size = New System.Drawing.Size(182, 26)
        Me.TBNumero.TabIndex = 8
        '
        'TBPiso
        '
        Me.TBPiso.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBPiso.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBPiso.Location = New System.Drawing.Point(91, 52)
        Me.TBPiso.Name = "TBPiso"
        Me.TBPiso.Size = New System.Drawing.Size(182, 26)
        Me.TBPiso.TabIndex = 7
        '
        'TBCalle
        '
        Me.TBCalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBCalle.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBCalle.Location = New System.Drawing.Point(91, 19)
        Me.TBCalle.Name = "TBCalle"
        Me.TBCalle.Size = New System.Drawing.Size(182, 26)
        Me.TBCalle.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 191)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 16)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Codigo Postal:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Provincia:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 16)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Localidad:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Numero*:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Piso:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 16)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Calle*:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(406, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Celular:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(406, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Telefono*:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "E-Mail:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Razon Social*:"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.TBSaldoCorriente)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(25, 76)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(366, 127)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Tag = "XC"
        Me.GroupBox3.Text = "Saldos"
        '
        'TBSaldoCorriente
        '
        Me.TBSaldoCorriente.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBSaldoCorriente.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBSaldoCorriente.Location = New System.Drawing.Point(145, 52)
        Me.TBSaldoCorriente.MaxLength = 7
        Me.TBSaldoCorriente.Name = "TBSaldoCorriente"
        Me.TBSaldoCorriente.Size = New System.Drawing.Size(168, 26)
        Me.TBSaldoCorriente.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(137, 16)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Saldo Cuenta Corriente:"
        '
        'VisualStyler1
        '
        Me.VisualStyler1.HostForm = Me
        Me.VisualStyler1.License = CType(resources.GetObject("VisualStyler1.License"), SkinSoft.VisualStyler.Licensing.VisualStylerLicense)
        Me.VisualStyler1.ShadowStyle = SkinSoft.VisualStyler.ShadowStyle.Bold
        Me.VisualStyler1.ToolStripStyle = SkinSoft.VisualStyler.ToolStripRenderStyle.Professional
        Me.VisualStyler1.LoadVisualStyle(Nothing, "Office2007 (Blue).vssf")
        '
        'TabControl1
        '
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TabControl1.Location = New System.Drawing.Point(0, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(746, 346)
        Me.TabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document
        Me.TabControl1.TabIndex = 2
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.GroupBox2)
        Me.TabControlPanel1.Controls.Add(Me.TBCelular)
        Me.TabControlPanel1.Controls.Add(Me.GroupBox1)
        Me.TabControlPanel1.Controls.Add(Me.Label3)
        Me.TabControlPanel1.Controls.Add(Me.TBTelefono)
        Me.TabControlPanel1.Controls.Add(Me.Label1)
        Me.TabControlPanel1.Controls.Add(Me.TBEmail)
        Me.TabControlPanel1.Controls.Add(Me.Label2)
        Me.TabControlPanel1.Controls.Add(Me.TBRazonSocial)
        Me.TabControlPanel1.Controls.Add(Me.Label4)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(746, 321)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                    Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = -90
        Me.TabControlPanel1.TabIndex = 0
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabItem1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue
        Me.TabItem1.Text = "Datos Proveedor"
        Me.TabItem1.TextColor = System.Drawing.Color.Black
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.GroupBox3)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 25)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(746, 321)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
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
        Me.TabItem2.Text = "Cuentas Corrientes"
        Me.TabItem2.TextColor = System.Drawing.Color.Black
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        '
        'ProveedorAlta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 398)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(220, 200)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProveedorAlta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Proveedor Alta"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.TabControlPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ProgressBarProveedorAlta As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripGurdarProveedorAlta As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSalirProveedorAlta As System.Windows.Forms.ToolStripButton
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TBSaldoCorriente As System.Windows.Forms.TextBox
    Friend WithEvents TBCelular As System.Windows.Forms.TextBox
    Friend WithEvents TBTelefono As System.Windows.Forms.TextBox
    Friend WithEvents TBEmail As System.Windows.Forms.TextBox
    Friend WithEvents TBRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TBCalle As System.Windows.Forms.TextBox
    Friend WithEvents TBNumero As System.Windows.Forms.TextBox
    Friend WithEvents TBPiso As System.Windows.Forms.TextBox
    Friend WithEvents TBLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents TBCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents CBProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents CBResponsabilidadIVA As System.Windows.Forms.ComboBox
    Friend WithEvents TBCuitProveedor3 As System.Windows.Forms.TextBox
    Friend WithEvents TBCuitProveedor2 As System.Windows.Forms.TextBox
    Friend WithEvents TBCuitProveedor1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
End Class
