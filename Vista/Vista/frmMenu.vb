Imports Controlador
<System.Serializable()> <Microsoft.VisualBasic.ComClass()> Public Class frmMenu
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsGenerales As New Controlador.clsGenerales
    Dim clsEmpresa As New Controlador.clsEmpresas
    Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Dim clsCaja As New Controlador.clsCaja
    Dim clsArticulo As New Controlador.clsArticulos
    Private Sub btnClientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientes.Click
        frmClientes.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmRubros.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmTasaIVA.Show()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmLista_Precios.Show()
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmArticulos.Show()
    End Sub
    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        frmProveedor.Show()
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        frmEmpresa.Show()
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        frmNumeroComprobante.Show()
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        frmLista_Precios.Show()
    End Sub
    Private Sub btnFacturacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFacturacion.Click
        Dim fact As New frmFacturacion
        fact.Show()

    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        frmConfiguracion.Show()
    End Sub
    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim Empresa As New Controlador.clsEmpresas
        Dim consulta As String
        Dim dtdatos As New DataTable
        'Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
        'Dim clsCaja As New Controlador.clsCaja
        Dim dtDatosCaja As New DataTable
        'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + " where Id_Empresa= '" + (Empresa.Compvariable) + "'"

        clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtdatos)
        toolStripStatusEmpresa.Text = dtdatos.Rows(0).Item(dfielddefEmpresa.Razon_Social)
        clsCaja.CajaCerrada(dtDatosCaja, dtdatos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal))
        If (dtDatosCaja.Rows.Count = 0) Then
            Vista.frmCaja.ShowDialog()
        End If

    End Sub


    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBuscarComprobante.Show()
    End Sub
    Private Sub ListadoClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoClientesToolStripMenuItem.Click
        Dim formulario As New frmListado()
        clsGenerales.Compvariable = dfielddefConstantes.cliente.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoArticulosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formulario As New frmListado()
        clsGenerales.Compvariable = dfielddefConstantes.Producto.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoArticulosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formulario As New frmListado()
        clsGenerales.Compvariable = dfielddefConstantes.Producto.ToString
        formulario.Show()
    End Sub
    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        Dim f As New frmSeleccionEmpresa()
        If TabControl1.SelectedIndex = 5 Then
            f.Show()
            Me.Close()
        End If
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        frmConfiguracionComprobantes.Show()
    End Sub
    Private Sub ListadoProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim formulario As New frmListado()
        clsGenerales.Compvariable = dfielddefConstantes.Proveedor.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoProveedoresToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoProveedoresToolStripMenuItem.Click
        Dim formulario As New frmListado()
        clsGenerales.Compvariable = dfielddefConstantes.Proveedor.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoArticulosToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoArticulosToolStripMenuItem.Click
        Dim formulario As New frmListado()
        clsGenerales.Compvariable = dfielddefConstantes.Producto.ToString
        formulario.Show()
    End Sub
    Private Sub ListadoRubrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListadoRubrosToolStripMenuItem.Click
        Dim formulario As New frmListado()
        clsGenerales.Compvariable = dfielddefConstantes.rubro.ToString
        formulario.Show()
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim FactuProv As New frmFacturacionProveedores
        FactuProv.Show()
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim NDProv As New frmNotaDebitoProveedores
        NDProv.Show()
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Dim NCProv As New frmNotaCreditoProveedores
        NCProv.Show()
    End Sub

    Private Sub btnPrecios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrecios.Click
        frmPrecio.Show()
    End Sub

    Private Sub btnVentaRapida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVentaRapida.Click
        frmVentaRapida.Show()
    End Sub

    Private Sub btnNotaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaCredito.Click
        frmNotaCredito.Show()
    End Sub

    Private Sub btnNotaDebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotaDebito.Click
        frmNotaDebito.Show()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        frmEntradaMercaderia.Show()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        frmRegistrarProducto.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Dim Articulo As New Controlador.clsArticulos
        Dim FormEntradaMercaderia As New Vista.frmEntradaMercaderia
        FormEntradaMercaderia.lblTitulo.Text = "Entrada Mercaderia"
        FormEntradaMercaderia.Show()
        clsArticulo.Compvariable = dfielddefConstantes.EntradaMercaderia.ToString()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'Dim Articulo As New Controlador.clsArticulos
        Dim FormEntradaMercaderia As New Vista.frmEntradaMercaderia
        FormEntradaMercaderia.lblTitulo.Text = "Salida Mercaderia"
        FormEntradaMercaderia.Show()
        clsArticulo.Compvariable = dfielddefConstantes.SalidaMercaderia.ToString()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Dim clsGenerales As New Controlador.clsGenerales
        Dim FormImportarExcel As New Vista.frmImportarExcel
        FormImportarExcel.Show()
        clsGenerales.Compvariable = dfielddefConstantes.Producto.ToString()
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        'Dim ingresoEgresos As New Controlador.clsCaja
        clsCaja.Compvariable = dfielddefConstantes.Ingresos.ToString()
        frmIngresoEgreso.Show()
    End Sub

    Private Sub Button16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        'Dim ingresoEgresos As New Controlador.clsCaja
        clsCaja.Compvariable = dfielddefConstantes.Egresos.ToString()
        frmIngresoEgreso.Show()
    End Sub
End Class
