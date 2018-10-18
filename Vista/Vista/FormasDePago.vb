Public Class FormasDePago
    Dim FactEncESt(0) As Controlador.Facturacion.eEncabezadoFactura
    Dim FactCuerpoESt(0) As Controlador.Facturacion.eCuerpoFactura
    Dim ArticulosEStFact(0) As Controlador.Articulos.eArticulo
    Dim Numero_ComprobanteEStFact(0) As Controlador.NumeroComprobante.eNumeracionComprobante
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim dfielddefEmpresa As Controlador.DfieldDef.eEmpresa
    Dim FomasdePagoEfectivo(0) As Controlador.Imputaciones.eImputaciones
    Dim FomasdePagoCuentaCorriente(0) As Controlador.CuentaCorriente.eCuentaCorriente
    Dim formaPago As New Controlador.FormasDePago
    Dim tran As New Collection
    Dim FormFacturacion As New Vista.Facturacion
    Dim FormNotaCredito As New Vista.NotaCredito
    Dim FormNotaDebito As New Vista.NotaDebito
    Public session As New Controlador.Session()
    Public Sub New(ByVal Facturacion_Enc_estructura() As Controlador.Facturacion.eEncabezadoFactura, ByVal Facturacion_Cuerpo_estructura() As Controlador.Facturacion.eCuerpoFactura, ByVal Articulos_Estructura() As Controlador.Articulos.eArticulo, ByVal NumeroComprobante() As Controlador.NumeroComprobante.eNumeracionComprobante)
        FactEncESt = Facturacion_Enc_estructura
        FactCuerpoESt = Facturacion_Cuerpo_estructura
        ArticulosEStFact = Articulos_Estructura
        Numero_ComprobanteEStFact = NumeroComprobante
        InitializeComponent()
    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim Facturacion As New Controlador.Facturacion
        Dim NumeroComprobante As New Controlador.NumeroComprobante
        Dim datosDataTable As New DataTable
        Dim tipocomprobante As String
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Empresa As New Controlador.Empresas
        Dim Numero_Condicion_IVA_Cliente As Controlador.Cliente.eCondicion_Frente_Al_Iva
        Dim Cliente As New Controlador.Cliente
        Dim Articulo As New Controlador.Articulos
        Dim Imputaciones As New Controlador.Imputaciones
        Dim CuentaCorriente As New Controlador.CuentaCorriente
        Dim i As Integer
        Dim ultimo As Integer
        Dim UltimoImputaciones As Integer
        Dim UltimoCuentaCorriente As Integer
        Dim Transaccion As New Controlador.Transacciones
        Dim idx As Integer
        Dim datosFacturacion As New DataTable
        Dim datosEmpresa As New DataTable

        Dim Responsabilidad_IVA_Empresa As String
        Dim Numero_Sucursal As String
        Dim IDComprobante As Integer
        Dim numeroComp As String = String.Empty
        Dim nuComprobante As Integer
        Dim existe As Boolean
        Dim DatoTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Try
            If (rbContado.Checked = True) Or (rbcc.Checked = True) Then
                If (rbContado.Checked = True) Then
                    FactEncESt(1).Id_Forma_Pago = "1"
                    FactEncESt(1).Forma_Pago = dfielddefConstantes.Contado.ToString()
                ElseIf (rbcc.Checked = True) Then
                    FactEncESt(1).Id_Forma_Pago = "2"
                    FactEncESt(1).Forma_Pago = dfielddefConstantes.CuentaCorriente.ToString()
                End If
                querybuilder.obtener_estructura(dfielddefConstantes.Encabezado_Factura.ToString(), esquema)
                Facturacion.Obtener_Clave_Principal_Encabezado_Factura(ClavePrincipal)
                Facturacion.Pasar_A_Coleccion_Encabezado_Factura(FactEncESt, datos, 1)
                querybuilder.ArmaInsert(dfielddefConstantes.Encabezado_Factura.ToString(), esquema, datos, ClavePrincipal, consulta)
                tran.Add(consulta)
                esquema.Clear()
                datos.Clear()
                ClavePrincipal.Clear()
                querybuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
                NumeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
                NumeroComprobante.Pasar_A_Coleccion(Numero_ComprobanteEStFact, datos, 1)
                querybuilder.ArmaUpdate(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, datos, ClavePrincipal, consulta)
                tran.Add(consulta)
                esquema.Clear()
                datos.Clear()
                ClavePrincipal.Clear()
                querybuilder.obtener_estructura(dfielddefConstantes.Cuerpo_Factura.ToString(), esquema)
                Facturacion.Obtener_Clave_Principal_Cuerpo_Factura(ClavePrincipal)
                'consulta = "Select Max(IdCuerpoFactura) as Maximo from " + dfielddefConstantes.Cuerpo_Factura.ToString() + ""
                Facturacion.ObtenerUltimoNumeroCuerpoFactura(ultimo)
                For i = 1 To FactCuerpoESt.Count - 1
                    FactCuerpoESt(i).IdCuerpoFactura = ultimo
                    Facturacion.Pasar_A_Coleccion_Cuerpo_Factura(FactCuerpoESt, datos, i)
                    querybuilder.ArmaInsert(dfielddefConstantes.Cuerpo_Factura.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    consulta = String.Empty
                    datos.Clear()
                    If (FactCuerpoESt(i).Numero_Articulo = ArticulosEStFact(i).Id_Producto) Then
                        ArticulosEStFact(i).Stock = Convert.ToString(Convert.ToDouble(ArticulosEStFact(i).Stock) - (Convert.ToDouble(FactCuerpoESt(i).Cantidad) * Convert.ToInt32(FactCuerpoESt(i).Signo)))
                        consulta = "update " + dfielddefConstantes.Producto.ToString() + " set Stock='" + (ArticulosEStFact(i).Stock) + "' where ID_Producto= '" + (FactCuerpoESt(i).Numero_Articulo) + "'"
                        tran.Add(consulta)
                    End If
                    consulta = ""
                    ultimo = ultimo + 1
                Next
                consulta = ""
                esquema.Clear()
                datos.Clear()
                ClavePrincipal.Clear()
                If (rbContado.Checked = True) Then
                    'consulta = "Select Max(IdImputaciones) as Maximo from " + dfielddefConstantes.Imputaciones.ToString() + ""
                    Imputaciones.ObtenerUltimoNumeroImputaciones(UltimoImputaciones)
                    ReDim FomasdePagoEfectivo(1)
                    'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
                    Empresa.Obtener_Empresa(Empresa.Compvariable, datosEmpresa)
                    Responsabilidad_IVA_Empresa = datosEmpresa.Rows(0).Item(dfielddefEmpresa.Responsabilidad_IVA).ToString()
                    ' = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (FactEncESt(1).Situacion_Frente_A_IVA) & "' "
                    Cliente.Obtener_CondicionFrenteAIVa(FactEncESt(1).Situacion_Frente_A_IVA, Numero_Condicion_IVA_Cliente)
                    'consulta = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                    Empresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)
                    'consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                    'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                    'consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                    'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                    'consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                    'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                    'consulta += " and TC.IdTipoComprobante in ('4','9','15')"

                    Facturacion.Obtener_Datos_Comprobante(Numero_Condicion_IVA_Cliente.Id_Condicion_IVA, Numero_Condicion_IVA_Empresa, dfielddefConstantes.Recibo.ToString(), DatoTipoComprobante)
                    'tipocomprobante = datosFacturacion.Rows(0).Item("Descripcion")
                    'IDComprobante = datosFacturacion.Rows(0).Item("IdTipoComprobante")
                    tipocomprobante = DatoTipoComprobante.Descripcion
                    IDComprobante = Convert.ToInt32(DatoTipoComprobante.IdTipoComprobante)
                    
                    'consulta = "select Numeracion from  " + dfielddefConstantes.Numeracion_Comprobante.ToString() + "  where Id_Empresa='" + Empresa.Compvariable + "' and Id_Tipo_Comprobante = '" & Convert.ToString(IDComprobante) & "'"
                    NumeroComprobante.obtener_Numero_Comprobante(Empresa.Compvariable, Convert.ToString(IDComprobante), numeroComp)
                    nuComprobante = Convert.ToInt32(numeroComp) + 1
                    NumeroComprobante.Aumentar_Numeracion_Comprobante(nuComprobante, numeroComp)
                    consulta = ""
                    consulta = "Update Numeracion_Comprobante set Numeracion='" + (numeroComp) + "' where Id_Tipo_Comprobante='" + (Convert.ToString(IDComprobante)) + "' and Id_Empresa='" + (Empresa.Compvariable) + "'"
                    tran.Add(consulta)

                    FomasdePagoEfectivo(1).IdImputaciones = UltimoImputaciones
                    FomasdePagoEfectivo(1).PuntoVentaRecibo = FactEncESt(1).Punto_Venta
                    FomasdePagoEfectivo(1).TipoComprobanteRecibo = Convert.ToString(IDComprobante).PadLeft(2, "0")
                    FomasdePagoEfectivo(1).NumeroComprobanteRecibo = Convert.ToString(numeroComp).PadLeft(8, "0")

                    FomasdePagoEfectivo(1).Comprobante = FactEncESt(1).Comprobante
                    FomasdePagoEfectivo(1).NumeroCliente = FactEncESt(1).Numero_Cliente
                    FomasdePagoEfectivo(1).Fecha = Date.Now()
                    FomasdePagoEfectivo(1).PuntoVenta = FactEncESt(1).Punto_Venta
                    FomasdePagoEfectivo(1).TipoComprobante = FactEncESt(1).Tipo_Comprobante
                    FomasdePagoEfectivo(1).NumeroComprobante = FactEncESt(1).Numero_Comprobante

                    FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                    FomasdePagoEfectivo(1).ID_FormaPago = FactEncESt(1).Id_Forma_Pago

                    If formaPago.Compvariable = dfielddefConstantes.FACTURA.ToString() Then
                        'FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                        'FomasdePagoEfectivo(1).ID_FormaPago = FactEncESt(1).Id_Forma_Pago
                        FomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.IngresoEfectivo.ToString()
                        FomasdePagoEfectivo(1).Signo = "1"
                    ElseIf formaPago.Compvariable = dfielddefConstantes.NotaDebito.ToString() Then
                        'FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                        'FomasdePagoEfectivo(1).ID_FormaPago = FactEncESt(1).Id_Forma_Pago
                        FomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.IngresoNotaDebito.ToString()
                        FomasdePagoEfectivo(1).Signo = "1"
                    ElseIf formaPago.Compvariable = dfielddefConstantes.NotaCredito.ToString() Then
                        'FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                        'FomasdePagoEfectivo(1).ID_FormaPago = FactEncESt(1).Id_Forma_Pago
                        FomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.EgresoNotaCredito.ToString()
                        FomasdePagoEfectivo(1).Signo = "-1"
                    End If
                    FomasdePagoEfectivo(1).NroPuesto = session.Session.NroPuesto
                    querybuilder.obtener_estructura(dfielddefConstantes.Imputaciones.ToString(), esquema)
                    Imputaciones.Obtener_Clave_Principal(ClavePrincipal)
                    Imputaciones.Pasar_A_Coleccion(FomasdePagoEfectivo, datos, 1)
                    querybuilder.ArmaInsert(dfielddefConstantes.Imputaciones.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                ElseIf (rbcc.Checked = True) Then
                    'consulta = "Select Max(IdCuentaCorriente) as Maximo from " + dfielddefConstantes.CuentaCorriente.ToString() + ""
                    CuentaCorriente.ObtenerUltimoNumeroCuentaCorriente(UltimoCuentaCorriente)
                    ReDim FomasdePagoCuentaCorriente(1)
                    FomasdePagoCuentaCorriente(1).Id_CuentaCorriente = UltimoCuentaCorriente
                    FomasdePagoCuentaCorriente(1).PuntoVenta = FactEncESt(1).Punto_Venta
                    FomasdePagoCuentaCorriente(1).TipoComprobante = FactEncESt(1).Tipo_Comprobante
                    FomasdePagoCuentaCorriente(1).NumeroComprobante = FactEncESt(1).Numero_Comprobante
                    FomasdePagoCuentaCorriente(1).Comprobante = FactEncESt(1).Comprobante
                    FomasdePagoCuentaCorriente(1).NumeroCliente = FactEncESt(1).Numero_Cliente
                    FomasdePagoCuentaCorriente(1).Fecha = Date.Now()
                    FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                    FomasdePagoCuentaCorriente(1).Signo = "1"
                    If formaPago.Compvariable = dfielddefConstantes.FACTURA.ToString() Then
                        ' FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                        FomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.IngresoCuentaCorriente.ToString()
                        'FomasdePagoCuentaCorriente(1).Signo = "1"
                    ElseIf formaPago.Compvariable = dfielddefConstantes.NotaDebito.ToString() Then
                        'FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                        FomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.IngresoNotaDebitoCuentaCorriente.ToString()
                        'FomasdePagoCuentaCorriente(1).Signo = "1"
                    ElseIf formaPago.Compvariable = dfielddefConstantes.NotaCredito.ToString() Then
                        'FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                        FomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.EgresoNotaCreditoCuentaCorriente.ToString()
                        'FomasdePagoCuentaCorriente(1).Signo = "-1"
                    End If
                    FomasdePagoCuentaCorriente(1).NroPuesto = session.Session.NroPuesto
                    querybuilder.obtener_estructura(dfielddefConstantes.CuentaCorriente.ToString(), esquema)
                    CuentaCorriente.Obtener_Clave_Principal(ClavePrincipal)
                    CuentaCorriente.Pasar_A_Coleccion(FomasdePagoCuentaCorriente, datos, 1)
                    querybuilder.ArmaInsert(dfielddefConstantes.CuentaCorriente.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                End If
                Transaccion.Operaciones_Tabla_Transaccion(tran)
                tran.Clear()
                MessageBox.Show("El Comprobante, se ha agregado Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Information)
                LimpiarEstructuras()
                FormNotaCredito.lblCodN.Visible = False
                FormNotaCredito.txtCodigoCliente.Text = ""
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
        ReDim Numero_ComprobanteEStFact(0)
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