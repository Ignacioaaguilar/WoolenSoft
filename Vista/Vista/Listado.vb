Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class Listado
    Private Sub ClienteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.ClienteBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.KioscoDataSet)
    End Sub
    Private Sub Listado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim generales As New Controlador.Generales
        Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
        If generales.Compvariable = dfielddefConstantes.cliente.ToString() Then
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
        ElseIf generales.Compvariable = dfielddefConstantes.Producto.ToString() Then
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
        ElseIf generales.Compvariable = dfielddefConstantes.Proveedor.ToString() Then
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
        ElseIf generales.Compvariable = dfielddefConstantes.rubro.ToString() Then
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
        End If
    End Sub
    Private Sub btnProceder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProceder.Click
        Dim cryRPT As New ReportDocument
        Dim Cliente As New Controlador.Cliente
        Dim Producto As New Controlador.Articulos
        Dim ContProveedor As New Controlador.ContProveedor
        Dim Rubro As New Controlador.Rubros
        Dim consulta As String
        Dim datos As New DataTable
        Dim dsLibreta As New KioscoDataSet
        Dim ds As New DataSet
        Dim generales As New Controlador.Generales
        Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
        Dim Empresa As New Controlador.Empresas()
        Dim dfielddefEmpresa As New Controlador.DfieldDef.eEmpresa

        'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
        Empresa.Obtener_Empresa(Empresa.Compvariable, datos)

        If generales.Compvariable = dfielddefConstantes.cliente.ToString() Then
            'Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).Remove(0, 6) & "\CrystalReportListadoCliente.rpt"
            Dim path As String = "C:\Users\Nacho\Documents\Visual Studio 2008\Projects\WoolenSoft\Vista\Vista\Cliente.rpt"
            cryRPT.Load(path)
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
            'consulta = "SELECT Id_Cliente, Nombre, Apellido, Calle, Piso, Nro, Saldo_CC, CUIT, Provincia, Telefono, Celular, E_Mail, Codigo_Postal, Responsabilidad_IVA, Localidad FROM Cliente"
            Cliente.ObtenerConsultaListado(datos)
            cryRPT.SetDataSource(datos)
            cryRPT.SetParameterValue("Prueba", "HOLA")

        ElseIf generales.Compvariable = dfielddefConstantes.Producto.ToString() Then
            'Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).Remove(0, 6) & "\CrystalReportListadoCliente.rpt"
            Dim path As String = "C:\Users\Nacho\Documents\Visual Studio 2008\Projects\WoolenSoft\Vista\Vista\Productos.rpt"
            cryRPT.Load(path)
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
            'consulta = "SELECT Id_Producto,Id_Rubro,Codigo_Barras,Descripcion,Id_Proveedor,Id_Tasa_IVA,Stock_Minimo,Stock,Pesable,Tipo_Unidad,Cantidad_Unid_Caja,Peso_Unidad FROM Producto as P inner join EmpresaArticulo as EA on P.Id_Producto=EA.Id_Articulo where EA.Id_Empresa='" + datos.Rows(0).Item(dfielddefEmpresa.Id_Empresa) + "'"
            'Producto.recuperar_Datos(consulta, datos)
            cryRPT.SetDataSource(datos)
            'cryRPT.SetParameterValue("Prueba", "HOLA")
        ElseIf generales.Compvariable = dfielddefConstantes.Proveedor.ToString() Then
            'Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).Remove(0, 6) & "\CrystalReportListadoCliente.rpt"
            Dim path As String = "C:\Users\Nacho\Documents\Visual Studio 2008\Projects\WoolenSoft\Vista\Vista\Proveedores.rpt"
            cryRPT.Load(path)
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
            'consulta = "SELECT Id_Proveedor,Razon_Social,Calle,Piso,Nro,Localidad,Codigo_Postal,Provincia,Telefono,Celular,CUIT,E_Mail,Responsabilidad_IVA,Saldo_CC FROM Proveedor"
            ContProveedor.recuperar_ALL_Datos(datos)
            cryRPT.SetDataSource(datos)
            'cryRPT.SetParameterValue("Prueba", "HOLA")
        ElseIf generales.Compvariable = dfielddefConstantes.rubro.ToString() Then
            'Dim path As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()).Remove(0, 6) & "\CrystalReportListadoCliente.rpt"
            Dim path As String = "C:\Users\Nacho\Documents\Visual Studio 2008\Projects\WoolenSoft\Vista\Vista\Rubro.rpt"
            cryRPT.Load(path)
            expParametros.Expanded = False
            expParametros.ExpandButtonVisible = False
            'consulta = "SELECT Id_Rubro,Descripcion FROM Rubro"
            Rubro.recuperar_Datos(consulta, datos)
            cryRPT.SetDataSource(datos)
            'cryRPT.SetParameterValue("Prueba", "HOLA")
        End If
        CrystalReportViewer1.ReportSource = cryRPT
        CrystalReportViewer1.Refresh()
    End Sub
End Class