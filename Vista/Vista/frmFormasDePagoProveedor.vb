Imports Controlador

Public Class frmFormasDePagoProveedor
    Dim FactEncESt(0) As Controlador.clsFacturacionProveedor.eEncabezadoFacturaProveedor
    Dim FactCuerpoESt(0) As Controlador.clsFacturacionProveedor.eCuerpoFacturaProveedor
    Dim ArticulosEStFact(0) As Controlador.clsArticulos.eArticulo
    'Dim Numero_ComprobanteEStFact(0) As Controlador.NumeroComprobante.eNumeracionComprobante
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim FomasdePagoEfectivo(0) As Controlador.clsImputacionesProveedor.eCajaProveedor
    Dim FomasdePagoCuentaCorriente(0) As Controlador.clsCuentaCorrienteProveedor.eCuentaCorrienteProveedor
    Dim formaPago As New Controlador.clsFormasDePago
    Dim tran As New Collection
    Dim Session As New Controlador.clsSession
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim clsFacturacionProveedor As New Controlador.clsFacturacionProveedor
    Dim clsEmpresa As New Controlador.clsEmpresas
    Dim clsCliente As New Controlador.clsCliente
    Dim clsArticulo As New Controlador.clsArticulos
    Dim clsCaja As New Controlador.clsImputacionesProveedor
    Dim clsCuentaCorrienteProveedor As New Controlador.clsCuentaCorrienteProveedor
    Dim clsTransaccion As New Controlador.clsTransacciones
    Public Sub New(ByVal FacturacionProveedor_Enc_estructura() As Controlador.clsFacturacionProveedor.eEncabezadoFacturaProveedor, ByVal FacturacionProveedor_Cuerpo_estructura() As Controlador.clsFacturacionProveedor.eCuerpoFacturaProveedor, ByVal Articulos_Estructura() As Controlador.clsArticulos.eArticulo)
        FactEncESt = FacturacionProveedor_Enc_estructura
        FactCuerpoESt = FacturacionProveedor_Cuerpo_estructura
        ArticulosEStFact = Articulos_Estructura
        InitializeComponent()
    End Sub
    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsFacturacionProveedor As New Controlador.clsFacturacionProveedor
        'Dim NumeroComprobante As New Controlador.NumeroComprobante
        Dim dtdatosDataTable As New DataTable
        Dim tipocomprobante As String
        Dim Numero_Condicion_IVA_Empresa As Integer
        'Dim Empresa As New Controlador.clsEmpresas
        Dim Numero_Condicion_IVA_Cliente As Integer
        'Dim clsCliente As New Controlador.clsCliente
        'Dim Articulo As New Controlador.clsArticulos
        'Dim Caja As New Controlador.clsImputacionesProveedor
        'Dim clsCuentaCorrienteProveedor As New Controlador.clsCuentaCorrienteProveedor
        Dim i As Integer
        Dim ultimo As Integer
        Dim UltimoCaja As Integer
        Dim UltimoCuentaCorriente As Integer
        'Dim Transaccion As New Controlador.clsTransacciones
        Dim idx As Integer
        Try
            If (rbContado.Checked = True) Or (rbcc.Checked = True) Then
                If (rbContado.Checked = True) Then
                    FactEncESt(1).Forma_Pago = dfielddefConstantes.Contado.ToString()
                ElseIf (rbcc.Checked = True) Then
                    FactEncESt(1).Forma_Pago = dfielddefConstantes.CuentaCorriente.ToString()
                End If
                clsQueryBuilder.obtener_estructura(dfielddefConstantes.Encabezado_Factura_Proveedor.ToString(), esquema)
                clsFacturacionProveedor.Obtener_Clave_Principal_Encabezado_Factura_Proveedor(ClavePrincipal)
                clsFacturacionProveedor.Pasar_A_Coleccion_Encabezado_Factura_Proveedor(FactEncESt, datos, 1)
                clsQueryBuilder.ArmaInsert(dfielddefConstantes.Encabezado_Factura_Proveedor.ToString(), esquema, datos, ClavePrincipal, consulta)
                tran.Add(consulta)
                esquema.Clear()
                datos.Clear()
                ClavePrincipal.Clear()
                clsQueryBuilder.obtener_estructura(dfielddefConstantes.Cuerpo_Factura_Proveedor.ToString(), esquema)
                clsFacturacionProveedor.Obtener_Clave_Principal_Cuerpo_Factura_Proveedor(ClavePrincipal)
                For i = 1 To FactCuerpoESt.Count - 1
                    'consulta = "Select Max(IdCuerpoFactura) as Maximo from " + dfielddefConstantes.Cuerpo_Factura_Proveedor.ToString() + ""
                    clsFacturacionProveedor.ObtenerUltimoNumeroCuerpoFacturaProveedor(ultimo)
                    FactCuerpoESt(i).IdCuerpoFactura = ultimo
                    clsFacturacionProveedor.Pasar_A_Coleccion_Cuerpo_Factura_Proveedor(FactCuerpoESt, datos, i)
                    clsQueryBuilder.ArmaInsert(dfielddefConstantes.Cuerpo_Factura_Proveedor.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    consulta = ""
                    datos.Clear()
                    If (FactCuerpoESt(i).Numero_Articulo = ArticulosEStFact(i).Id_Producto) Then
                        ArticulosEStFact(i).Stock = Convert.ToString(Convert.ToDouble(ArticulosEStFact(i).Stock) + Convert.ToDouble(FactCuerpoESt(i).Cantidad))
                        consulta = "update " + dfielddefConstantes.Producto.ToString() + " set Stock='" + (ArticulosEStFact(i).Stock) + "' where ID_Producto= '" + (FactCuerpoESt(i).Numero_Articulo) + "'"
                        tran.Add(consulta)
                    End If
                    consulta = ""
                Next
                consulta = ""
                esquema.Clear()
                datos.Clear()
                ClavePrincipal.Clear()
                If (rbContado.Checked = True) Then
                    'consulta = "Select Max(IdCaja) as Maximo from " + dfielddefConstantes.Imputaciones_Proveedor.ToString() + ""
                    clsCaja.ObtenerUltimoNumeroCaja(UltimoCaja)
                    ReDim FomasdePagoEfectivo(1)
                    FomasdePagoEfectivo(1).Id_Caja = UltimoCaja
                    FomasdePagoEfectivo(1).PuntoVenta = FactEncESt(1).Punto_Venta
                    FomasdePagoEfectivo(1).TipoComprobante = FactEncESt(1).Tipo_Comprobante
                    FomasdePagoEfectivo(1).NumeroComprobante = FactEncESt(1).Numero_Comprobante
                    FomasdePagoEfectivo(1).Comprobante = FactEncESt(1).Comprobante
                    FomasdePagoEfectivo(1).NumeroCliente = FactEncESt(1).Id_Proveedor
                    FomasdePagoEfectivo(1).Fecha = Date.Now()
                    FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total

                    If formaPago.Compvariable = dfielddefConstantes.FACTURAPROVEEDOR.ToString() Then
                        'FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                        FomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.IngresoEfectivo.ToString()
                        FomasdePagoEfectivo(1).Signo = "1"
                    ElseIf formaPago.Compvariable = dfielddefConstantes.NotaDebitoProveedor.ToString() Then
                        'FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                        FomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.IngresoNotaDebito.ToString()
                        FomasdePagoEfectivo(1).Signo = "1"
                    ElseIf formaPago.Compvariable = dfielddefConstantes.NotaCreditoProveedor.ToString() Then
                        'FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                        FomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.EgresoNotaCredito.ToString()
                        FomasdePagoEfectivo(1).Signo = "-1"
                    End If
                    FomasdePagoEfectivo(1).NroPuesto = Session.Session.NroPuesto
                    clsQueryBuilder.obtener_estructura(dfielddefConstantes.Imputaciones_Proveedor.ToString(), esquema)
                    clsCaja.Obtener_Clave_Principal(ClavePrincipal)
                    clsCaja.Pasar_A_Coleccion(FomasdePagoEfectivo, datos, 1)
                    clsQueryBuilder.ArmaInsert(dfielddefConstantes.Imputaciones_Proveedor.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                ElseIf (rbcc.Checked = True) Then
                    'consulta = "Select Max(IdCuentaCorriente) as Maximo from " + dfielddefConstantes.CuentaCorriente_Proveedor.ToString() + ""
                    clsCuentaCorrienteProveedor.ObtenerUltimoNumeroCuentaCorriente(UltimoCuentaCorriente)
                    ReDim FomasdePagoCuentaCorriente(1)
                    FomasdePagoCuentaCorriente(1).Id_CuentaCorriente = UltimoCuentaCorriente
                    FomasdePagoCuentaCorriente(1).PuntoVenta = FactEncESt(1).Punto_Venta
                    FomasdePagoCuentaCorriente(1).TipoComprobante = FactEncESt(1).Tipo_Comprobante
                    FomasdePagoCuentaCorriente(1).NumeroComprobante = FactEncESt(1).Numero_Comprobante
                    FomasdePagoCuentaCorriente(1).Comprobante = FactEncESt(1).Comprobante
                    FomasdePagoCuentaCorriente(1).NumeroCliente = FactEncESt(1).Id_Proveedor
                    FomasdePagoCuentaCorriente(1).Fecha = Date.Now()
                    FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                    If formaPago.Compvariable = dfielddefConstantes.FACTURAPROVEEDOR.ToString() Then
                        'FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                        FomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.IngresoCuentaCorriente.ToString()
                        FomasdePagoCuentaCorriente(1).Signo = "1"
                    ElseIf formaPago.Compvariable = dfielddefConstantes.NotaDebitoProveedor.ToString() Then
                        'FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                        FomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.IngresoNotaDebitoCuentaCorriente.ToString()
                        FomasdePagoCuentaCorriente(1).Signo = "1"
                    ElseIf formaPago.Compvariable = dfielddefConstantes.NotaCreditoProveedor.ToString() Then
                        'FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                        FomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.EgresoNotaCreditoCuentaCorriente.ToString()
                        FomasdePagoCuentaCorriente(1).Signo = "-1"
                    End If
                    FomasdePagoCuentaCorriente(1).NroPuesto = Session.Session.NroPuesto
                    clsQueryBuilder.obtener_estructura(dfielddefConstantes.CuentaCorriente_Proveedor.ToString(), esquema)
                    clsCuentaCorrienteProveedor.Obtener_Clave_Principal(ClavePrincipal)
                    clsCuentaCorrienteProveedor.Pasar_A_Coleccion(FomasdePagoCuentaCorriente, datos, 1)
                    clsQueryBuilder.ArmaInsert(dfielddefConstantes.CuentaCorriente_Proveedor.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                End If
                clsTransaccion.Operaciones_Tabla_Transaccion(tran)
                tran.Clear()
                MessageBox.Show("El Comprobante, se ha agregado Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Information)
                LimpiarEstructuras()
                Me.Close()
                formaPago.Compvariable = dfielddefConstantes.Si.ToString()
            Else
                MessageBox.Show("Debe seleccionar una forma de pago!!!", "Informacion", MessageBoxButtons.OK, _
                                                MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim FactEncESt(0)
        ReDim FactCuerpoESt(0)
        'ReDim Numero_ComprobanteEStFact(0)
        ReDim ArticulosEStFact(0)
        ReDim FomasdePagoEfectivo(0)
        ReDim FomasdePagoCuentaCorriente(0)
        lblImporteCC.Text = ""
        lbImporteContado.Text = ""
        rbContado.Checked = False
        rbcc.Checked = False
    End Sub
    Private Sub rbContado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbContado.CheckedChanged
        If (rbContado.Checked = True) Then
            lbImporteContado.Text = "$" + FactEncESt(1).Total
            lblImporteCC.Text = ""
        End If
    End Sub
    Private Sub rbcc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcc.CheckedChanged
        If (rbcc.Checked = True) Then
            lblImporteCC.Text = "$" + FactEncESt(1).Total
            lbImporteContado.Text = ""
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        LimpiarEstructuras()
        formaPago.Compvariable = dfielddefConstantes.No.ToString()
    End Sub
End Class