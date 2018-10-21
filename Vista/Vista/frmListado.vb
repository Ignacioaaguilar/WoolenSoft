Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmListado
    Dim clsGenerales As New Controlador.clsGenerales
    Dim clsCliente As New Controlador.clsCliente
    Dim clsProducto As New Controlador.clsArticulos
    Dim clsContProveedor As New Controlador.clsContProveedor
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsEmpresa As New Controlador.clsEmpresas()
    Dim dfielddefEmpresa As New Controlador.clsDfieldDef.eEmpresa
    Dim clsRubro As New Controlador.clsRubros
    Private Sub ClienteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.ClienteBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.KioscoDataSet)
    End Sub
    Private Sub Listado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim clsGenerales As New Controlador.clsGenerales
        Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
        If clsGenerales.Compvariable = dfielddefConstantes.cliente.ToString() Then
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
        ElseIf clsGenerales.Compvariable = dfielddefConstantes.Producto.ToString() Then
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
        ElseIf clsGenerales.Compvariable = dfielddefConstantes.Proveedor.ToString() Then
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
        ElseIf clsGenerales.Compvariable = dfielddefConstantes.rubro.ToString() Then
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
        End If
    End Sub
    Private Sub btnProceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceder.Click
        Dim cryRPT As New ReportDocument
        'Dim clsCliente As New Controlador.clsCliente
        'Dim Producto As New Controlador.clsArticulos
        'Dim clsContProveedor As New Controlador.clsContProveedor
        'Dim Rubro As New Controlador.clsRubros
        Dim consulta As String
        Dim dtdatos As New DataTable
        Dim dsLibreta As New KioscoDataSet
        Dim ds As New DataSet
        'Dim clsGenerales As New Controlador.clsGenerales
        'Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
        'Dim Empresa As New Controlador.clsEmpresas()
        'Dim dfielddefEmpresa As New Controlador.clsDfieldDef.eEmpresa

        'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
        clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtdatos)

        If clsGenerales.Compvariable = dfielddefConstantes.cliente.ToString() Then
            'Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).Remove(0, 6) & "\CrystalReportListadoCliente.rpt"
            Dim path As String = "C:\Users\Nacho\Documents\Visual Studio 2008\Projects\WoolenSoft\Vista\Vista\Cliente.rpt"
            cryRPT.Load(path)
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
            'consulta = "SELECT Id_Cliente, Nombre, Apellido, Calle, Piso, Nro, Saldo_CC, CUIT, Provincia, Telefono, Celular, E_Mail, Codigo_Postal, Responsabilidad_IVA, Localidad FROM Cliente"
            clsCliente.ObtenerConsultaListado(dtdatos)
            cryRPT.SetDataSource(dtdatos)
            cryRPT.SetParameterValue("Prueba", "HOLA")

        ElseIf clsGenerales.Compvariable = dfielddefConstantes.Producto.ToString() Then
            'Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).Remove(0, 6) & "\CrystalReportListadoCliente.rpt"
            Dim path As String = "C:\Users\Nacho\Documents\Visual Studio 2008\Projects\WoolenSoft\Vista\Vista\Productos.rpt"
            cryRPT.Load(path)
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
            'consulta = "SELECT Id_Producto,Id_Rubro,Codigo_Barras,Descripcion,Id_Proveedor,Id_Tasa_IVA,Stock_Minimo,Stock,Pesable,Tipo_Unidad,Cantidad_Unid_Caja,Peso_Unidad FROM Producto as P inner join EmpresaArticulo as EA on P.Id_Producto=EA.Id_Articulo where EA.Id_Empresa='" + datos.Rows(0).Item(dfielddefEmpresa.Id_Empresa) + "'"
            'Producto.recuperar_Datos(consulta, datos)
            cryRPT.SetDataSource(dtdatos)
            'cryRPT.SetParameterValue("Prueba", "HOLA")
        ElseIf clsGenerales.Compvariable = dfielddefConstantes.Proveedor.ToString() Then
            'Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).Remove(0, 6) & "\CrystalReportListadoCliente.rpt"
            Dim path As String = "C:\Users\Nacho\Documents\Visual Studio 2008\Projects\WoolenSoft\Vista\Vista\Proveedores.rpt"
            cryRPT.Load(path)
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
            'consulta = "SELECT Id_Proveedor,Razon_Social,Calle,Piso,Nro,Localidad,Codigo_Postal,Provincia,Telefono,Celular,CUIT,E_Mail,Responsabilidad_IVA,Saldo_CC FROM Proveedor"
            clsContProveedor.recuperar_ALL_Datos(dtdatos)
            cryRPT.SetDataSource(dtdatos)
            'cryRPT.SetParameterValue("Prueba", "HOLA")
        ElseIf clsGenerales.Compvariable = dfielddefConstantes.rubro.ToString() Then
            'Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).Remove(0, 6) & "\CrystalReportListadoCliente.rpt"
            Dim path As String = "C:\Users\Nacho\Documents\Visual Studio 2008\Projects\WoolenSoft\Vista\Vista\Rubro.rpt"
            cryRPT.Load(path)
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
            'consulta = "SELECT Id_Rubro,Descripcion FROM Rubro"
            clsRubro.recuperar_Datos(consulta, dtdatos)
            cryRPT.SetDataSource(dtdatos)
            'cryRPT.SetParameterValue("Prueba", "HOLA")
        End If
        CrystalReportViewer1.ReportSource = cryRPT
        CrystalReportViewer1.Refresh()
    End Sub
End Class