<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListado))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.VisualStyler1 = New SkinSoft.VisualStyler.VisualStyler(Me.components)
        Me.expAcciones = New DevComponents.DotNetBar.ExpandablePanel
        Me.btnProceder = New System.Windows.Forms.Button
        Me.expParametros = New DevComponents.DotNetBar.ExpandablePanel
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtPickert1 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.DockContainerItem1 = New DevComponents.DotNetBar.DockContainerItem
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.KioscoDataSet = New Vista.KioscoDataSet
        Me.ClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClienteTableAdapter = New Vista.KioscoDataSetTableAdapters.ClienteTableAdapter
        Me.TableAdapterManager = New Vista.KioscoDataSetTableAdapters.TableAdapterManager
        Me.Contenedor = New DevComponents.DotNetBar.DockContainerItem
        Me.DockContainerItem2 = New DevComponents.DotNetBar.DockContainerItem
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx
        Me.DockContainerItem3 = New DevComponents.DotNetBar.DockContainerItem
        Me.DockContainerItem4 = New DevComponents.DotNetBar.DockContainerItem
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.expAcciones.SuspendLayout()
        Me.expParametros.SuspendLayout()
        CType(Me.KioscoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(207, 1)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(789, 495)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'VisualStyler1
        '
        Me.VisualStyler1.HostForm = Me
        Me.VisualStyler1.License = CType(resources.GetObject("VisualStyler1.License"), SkinSoft.VisualStyler.Licensing.VisualStylerLicense)
        Me.VisualStyler1.ShadowStyle = SkinSoft.VisualStyler.ShadowStyle.Bold
        Me.VisualStyler1.ToolStripStyle = SkinSoft.VisualStyler.ToolStripRenderStyle.Professional
        Me.VisualStyler1.LoadVisualStyle(Nothing, "Office2007 (Blue).vssf")
        '
        'expAcciones
        '
        Me.expAcciones.CanvasColor = System.Drawing.SystemColors.Control
        Me.expAcciones.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.expAcciones.Controls.Add(Me.btnProceder)
        Me.expAcciones.Cursor = System.Windows.Forms.Cursors.Hand
        Me.expAcciones.DisabledBackColor = System.Drawing.Color.Empty
        Me.expAcciones.HideControlsWhenCollapsed = True
        Me.expAcciones.Location = New System.Drawing.Point(6, 239)
        Me.expAcciones.Name = "expAcciones"
        Me.expAcciones.Size = New System.Drawing.Size(195, 93)
        Me.expAcciones.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.expAcciones.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expAcciones.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.expAcciones.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.expAcciones.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expAcciones.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expAcciones.Style.GradientAngle = 90
        Me.expAcciones.TabIndex = 0
        Me.expAcciones.TitleHeight = 30
        Me.expAcciones.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.expAcciones.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expAcciones.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.expAcciones.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.expAcciones.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expAcciones.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expAcciones.TitleStyle.GradientAngle = 90
        Me.expAcciones.TitleText = "Acciones"
        '
        'btnProceder
        '
        Me.btnProceder.Location = New System.Drawing.Point(54, 46)
        Me.btnProceder.Name = "btnProceder"
        Me.btnProceder.Size = New System.Drawing.Size(87, 27)
        Me.btnProceder.TabIndex = 4
        Me.btnProceder.Text = "Proceder"
        Me.btnProceder.UseVisualStyleBackColor = True
        '
        'expParametros
        '
        Me.expParametros.CanvasColor = System.Drawing.SystemColors.Control
        Me.expParametros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.expParametros.Controls.Add(Me.DateTimePicker1)
        Me.expParametros.Controls.Add(Me.Label1)
        Me.expParametros.Controls.Add(Me.dtPickert1)
        Me.expParametros.Controls.Add(Me.Label2)
        Me.expParametros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.expParametros.DisabledBackColor = System.Drawing.Color.Empty
        Me.expParametros.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.expParametros.HideControlsWhenCollapsed = True
        Me.expParametros.Location = New System.Drawing.Point(6, 31)
        Me.expParametros.Name = "expParametros"
        Me.expParametros.Size = New System.Drawing.Size(195, 186)
        Me.expParametros.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.expParametros.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expParametros.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.expParametros.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.expParametros.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.expParametros.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.expParametros.Style.GradientAngle = 90
        Me.expParametros.TabIndex = 12
        Me.expParametros.TitleHeight = 30
        Me.expParametros.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.expParametros.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.expParametros.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.expParametros.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
        Me.expParametros.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.expParametros.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.expParametros.TitleStyle.GradientAngle = 90
        Me.expParametros.TitleText = "Parametros"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(9, 130)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(5)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(178, 23)
        Me.DateTimePicker1.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(9, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha Desde:"
        '
        'dtPickert1
        '
        Me.dtPickert1.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder
        Me.dtPickert1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dtPickert1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPickert1.Location = New System.Drawing.Point(9, 69)
        Me.dtPickert1.Margin = New System.Windows.Forms.Padding(5)
        Me.dtPickert1.Name = "dtPickert1"
        Me.dtPickert1.Size = New System.Drawing.Size(178, 23)
        Me.dtPickert1.TabIndex = 8
        Me.dtPickert1.Value = New Date(2017, 4, 22, 18, 29, 34, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(9, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha Hasta:"
        '
        'DockContainerItem1
        '
        Me.DockContainerItem1.Name = "DockContainerItem1"
        Me.DockContainerItem1.Text = "DockContainerItem1"
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Blue
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'KioscoDataSet
        '
        Me.KioscoDataSet.DataSetName = "KioscoDataSet"
        Me.KioscoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClienteBindingSource
        '
        Me.ClienteBindingSource.DataMember = "Cliente"
        Me.ClienteBindingSource.DataSource = Me.KioscoDataSet
        '
        'ClienteTableAdapter
        '
        Me.ClienteTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CajaTableAdapter = Nothing
        Me.TableAdapterManager.ClienteTableAdapter = Me.ClienteTableAdapter
        Me.TableAdapterManager.ComprobantesTableAdapter = Nothing
        Me.TableAdapterManager.Condicion_Frente_Al_IVATableAdapter = Nothing
        Me.TableAdapterManager.ConfiguracionTableAdapter = Nothing
        Me.TableAdapterManager.CuentaCorrienteTableAdapter = Nothing
        Me.TableAdapterManager.Cuerpo_FacturaTableAdapter = Nothing
        Me.TableAdapterManager.EmpresaArticuloTableAdapter = Nothing
        Me.TableAdapterManager.EmpresaTableAdapter = Nothing
        Me.TableAdapterManager.Encabezado_FacturaTableAdapter = Nothing
        Me.TableAdapterManager.Lista_PrecioTableAdapter = Nothing
        Me.TableAdapterManager.Numeracion_ComprobanteTableAdapter = Nothing
        Me.TableAdapterManager.Producto_Lista_PrecioTableAdapter = Nothing
        Me.TableAdapterManager.ProductoTableAdapter = Nothing
        Me.TableAdapterManager.ProveedorTableAdapter = Nothing
        Me.TableAdapterManager.ProvinciaTableAdapter = Nothing
        Me.TableAdapterManager.RubroTableAdapter = Nothing
        Me.TableAdapterManager.Tasa_IVATableAdapter = Nothing
        Me.TableAdapterManager.Tipos_ComprobantesTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = Vista.KioscoDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Contenedor
        '
        Me.Contenedor.Name = "Contenedor"
        Me.Contenedor.Text = "Contenedor"
        '
        'DockContainerItem2
        '
        Me.DockContainerItem2.Name = "DockContainerItem2"
        Me.DockContainerItem2.Text = "DockContainerItem2"
        '
        'PanelEx1
        '
        Me.PanelEx1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.expParametros)
        Me.PanelEx1.Controls.Add(Me.expAcciones)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Location = New System.Drawing.Point(0, 1)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(205, 1064)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 0
        '
        'DockContainerItem3
        '
        Me.DockContainerItem3.Name = "DockContainerItem3"
        Me.DockContainerItem3.Text = "DockContainerItem3"
        '
        'DockContainerItem4
        '
        Me.DockContainerItem4.Name = "DockContainerItem4"
        Me.DockContainerItem4.Text = "DockContainerItem4"
        '
        'Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 496)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Comic Sans MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Listado"
        Me.ShowInTaskbar = False
        Me.Text = "Listado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.VisualStyler1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.expAcciones.ResumeLayout(False)
        Me.expParametros.ResumeLayout(False)
        Me.expParametros.PerformLayout()
        CType(Me.KioscoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KioscoDataSet As Vista.KioscoDataSet
    Friend WithEvents ClienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ClienteTableAdapter As Vista.KioscoDataSetTableAdapters.ClienteTableAdapter
    Friend WithEvents TableAdapterManager As Vista.KioscoDataSetTableAdapters.TableAdapterManager

    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents VisualStyler1 As SkinSoft.VisualStyler.VisualStyler
    Friend WithEvents expAcciones As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents btnProceder As System.Windows.Forms.Button
    Friend WithEvents expParametros As DevComponents.DotNetBar.ExpandablePanel
    Friend WithEvents DockContainerItem1 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents Contenedor As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents DockContainerItem2 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents DockContainerItem3 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents DockContainerItem4 As DevComponents.DotNetBar.DockContainerItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtPickert1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
End Class
