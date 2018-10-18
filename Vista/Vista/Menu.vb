Imports Controlador
<System.Serializable()> <Microsoft.VisualBasic.ComClass()> Public Class Menu
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim generales As New Controlador.Generales
    Private Sub btnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientes.Click
        Clientes.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Rubros.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TasaIVA.Show()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Lista_Precios.Show()
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Articulos.Show()
    End Sub
    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Proveedor.Show()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Empresa.Show()
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        NumeroComprobante.Show()
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Lista_Precios.Show()
    End Sub
    Private Sub btnFacturacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFacturacion.Click
        Dim fact As New Facturacion
        fact.Show()

    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Configuracion.Show()
    End Sub
    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Empresa As New Controlador.Empresas
        Dim consulta As String
        Dim datos As New DataTable
        Dim dfielddefEmpresa As Controlador.DfieldDef.eEmpresa
        Dim caja As New Controlador.Caja
        Dim DatosCaja As New DataTable
        'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + " where Id_Empresa= '" + (Empresa.Compvariable) + "'"

        Empresa.Obtener_Empresa(Empresa.Compvariable, datos)
        toolStripStatusEmpresa.Text=datos.Rows(0).Item(dfielddefEmpresa.Razon_Social)
        caja.CajaCerrada(DatosCaja, datos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal))
        If (DatosCaja.Rows.Count = 0) Then
            Vista.Caja.ShowDialog()
        End If

    End Sub
   
   
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BuscarComprobante.Show()
    End Sub
    Private Sub ListadoClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoClientesToolStripMenuItem.Click
        Dim formulario As New Listado()
        generales.Compvariable = dfielddefConstantes.cliente.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoArticulosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formulario As New Listado()
        generales.Compvariable = dfielddefConstantes.Producto.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoArticulosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formulario As New Listado()
        generales.Compvariable = dfielddefConstantes.Producto.ToString
        formulario.Show()
    End Sub
    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        Dim f As New SeleccionEmpresa()
        If TabControl1.SelectedIndex = 5 Then
            f.Show()
            Me.Close()
        End If
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        ConfiguracionComprobantes.Show()
    End Sub
    Private Sub ListadoProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formulario As New Listado()
        generales.Compvariable = dfielddefConstantes.Proveedor.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoProveedoresToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoProveedoresToolStripMenuItem.Click
        Dim formulario As New Listado()
        generales.Compvariable = dfielddefConstantes.Proveedor.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoArticulosToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoArticulosToolStripMenuItem.Click
        Dim formulario As New Listado()
        generales.Compvariable = dfielddefConstantes.Producto.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoRubrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoRubrosToolStripMenuItem.Click
        Dim formulario As New Listado()
        generales.Compvariable = dfielddefConstantes.rubro.ToString
        formulario.Show()
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim FactuProv As New FacturacionProveedores
        FactuProv.Show()
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim NDProv As New NotaDebitoProveedores
        NDProv.Show()
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Dim NCProv As New NotaCreditoProveedores
        NCProv.Show()
    End Sub

    Private Sub btnPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrecios.Click
        Precio.Show()
    End Sub

    Private Sub btnVentaRapida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVentaRapida.Click
        VentaRapida.Show()
    End Sub

    Private Sub btnNotaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaCredito.Click
        NotaCredito.Show()
    End Sub

    Private Sub btnNotaDebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaDebito.Click
        NotaDebito.Show()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        EntradaMercaderia.Show()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        RegistrarProducto.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Articulo As New Controlador.Articulos
        Dim FormEntradaMercaderia As New Vista.EntradaMercaderia
        FormEntradaMercaderia.lblTitulo.Text = "Entrada Mercaderia"
        FormEntradaMercaderia.Show()
        Articulo.Compvariable = dfielddefConstantes.EntradaMercaderia.ToString()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim Articulo As New Controlador.Articulos
        Dim FormEntradaMercaderia As New Vista.EntradaMercaderia
        FormEntradaMercaderia.lblTitulo.Text = "Salida Mercaderia"
        FormEntradaMercaderia.Show()
        Articulo.Compvariable = dfielddefConstantes.SalidaMercaderia.ToString()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Generales As New Controlador.Generales
        Dim FormImportarExcel As New Vista.ImportarExcel
        FormImportarExcel.Show()
        Generales.Compvariable = dfielddefConstantes.Producto.ToString()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim ingresoEgresos As New Controlador.Caja
        ingresoEgresos.Compvariable = dfielddefConstantes.Ingresos.ToString()
        IngresoEgreso.Show()
    End Sub

    Private Sub Button16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Dim ingresoEgresos As New Controlador.Caja
        ingresoEgresos.Compvariable = dfielddefConstantes.Egresos.ToString()
        IngresoEgreso.Show()
    End Sub
End Class
