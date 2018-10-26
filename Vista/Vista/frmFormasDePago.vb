Public Class frmFormasDePago
    Dim eFactEncESt(0) As Controlador.clsFacturacion.eEncabezadoFactura
    Dim eFactCuerpoESt(0) As Controlador.clsFacturacion.eCuerpoFactura
    Dim eArticulosEStFact(0) As Controlador.clsArticulos.eArticulo
    Dim eNumero_ComprobanteEStFact(0) As Controlador.clsNumeroComprobante.eNumeracionComprobante
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Dim eFomasdePagoEfectivo(0) As Controlador.clsImputaciones.eImputaciones
    Dim eFomasdePagoCuentaCorriente(0) As Controlador.clsCuentaCorriente.eCuentaCorriente
    Dim clsformaPago As New Controlador.clsFormasDePago
    Dim tran As New Collection
    Dim FormFacturacion As New Vista.frmFacturacion
    Dim FormNotaCredito As New Vista.frmNotaCredito
    Dim FormNotaDebito As New Vista.frmNotaDebito
    Dim clssession As New Controlador.clsSession()
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim clsFacturacion As New Controlador.clsFacturacion
    Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
    Dim clsEmpresa As New Controlador.clsEmpresas
    Dim eNumero_Condicion_IVA_Cliente As Controlador.clsCliente.eCondicion_Frente_Al_Iva
    Dim clsCliente As New Controlador.clsCliente
    Dim clsArticulo As New Controlador.clsArticulos
    Dim clsImputaciones As New Controlador.clsImputaciones
    Dim clsCuentaCorriente As New Controlador.clsCuentaCorriente
    Dim clsTransaccion As New Controlador.clsTransacciones
    Dim eDatoTipoComprobante As Controlador.clsFacturacion.eTipoComprobante


    Public Sub New(ByVal eFacturacion_Enc_estructura() As Controlador.clsFacturacion.eEncabezadoFactura, ByVal eFacturacion_Cuerpo_estructura() As Controlador.clsFacturacion.eCuerpoFactura, ByVal eArticulos_Estructura() As Controlador.clsArticulos.eArticulo, ByVal eNumeroComprobante() As Controlador.clsNumeroComprobante.eNumeracionComprobante)
        eFactEncESt = eFacturacion_Enc_estructura
        eFactCuerpoESt = eFacturacion_Cuerpo_estructura
        eArticulosEStFact = eArticulos_Estructura
        eNumero_ComprobanteEStFact = eNumeroComprobante
        InitializeComponent()
    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsFacturacion As New Controlador.clsFacturacion
        'Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
        Dim dtdatosDataTable As New DataTable
        Dim tipocomprobante As String
        Dim Numero_Condicion_IVA_Empresa As Integer
        'Dim Empresa As New Controlador.clsEmpresas
        'Dim Numero_Condicion_IVA_Cliente As Controlador.clsCliente.eCondicion_Frente_Al_Iva
        'Dim clsCliente As New Controlador.clsCliente
        'Dim Articulo As New Controlador.clsArticulos
        'Dim clsImputaciones As New Controlador.clsImputaciones
        'Dim clsCuentaCorriente As New Controlador.clsCuentaCorriente
        Dim i As Integer
        Dim ultimo As Integer
        Dim UltimoImputaciones As Integer
        Dim UltimoCuentaCorriente As Integer
        'Dim Transaccion As New Controlador.clsTransacciones
        Dim idx As Integer
        Dim dtdatosFacturacion As New DataTable
        Dim dtdatosEmpresa As New DataTable
        Dim Responsabilidad_IVA_Empresa As String
        Dim Numero_Sucursal As String
        Dim IDComprobante As Integer
        Dim numeroComp As String = String.Empty
        Dim nuComprobante As Integer
        Dim existe As Boolean
        'Dim DatoTipoComprobante As Controlador.clsFacturacion.eTipoComprobante
        Try
            If (rbContado.Checked = True) Or (rbcc.Checked = True) Then
                If (rbContado.Checked = True) Then
                    eFactEncESt(1).Id_Forma_Pago = "1"
                    eFactEncESt(1).Cancelado = "Si"
                    eFactEncESt(1).Forma_Pago = dfielddefConstantes.Contado.ToString()
                ElseIf (rbcc.Checked = True) Then
                    eFactEncESt(1).Id_Forma_Pago = "2"
                    eFactEncESt(1).Forma_Pago = dfielddefConstantes.CuentaCorriente.ToString()
                End If
                clsQueryBuilder.obtener_estructura(dfielddefConstantes.Encabezado_Factura.ToString(), esquema)
                clsFacturacion.Obtener_Clave_Principal_Encabezado_Factura(ClavePrincipal)
                clsFacturacion.Pasar_A_Coleccion_Encabezado_Factura(eFactEncESt, datos, 1)
                clsQueryBuilder.ArmaInsert(dfielddefConstantes.Encabezado_Factura.ToString(), esquema, datos, ClavePrincipal, consulta)
                tran.Add(consulta)
                esquema.Clear()
                datos.Clear()
                ClavePrincipal.Clear()
                clsQueryBuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
                clsNumeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
                clsNumeroComprobante.Pasar_A_Coleccion(eNumero_ComprobanteEStFact, datos, 1)
                clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, datos, ClavePrincipal, consulta)
                tran.Add(consulta)
                esquema.Clear()
                datos.Clear()
                ClavePrincipal.Clear()
                clsQueryBuilder.obtener_estructura(dfielddefConstantes.Cuerpo_Factura.ToString(), esquema)
                clsFacturacion.Obtener_Clave_Principal_Cuerpo_Factura(ClavePrincipal)
                'consulta = "Select Max(IdCuerpoFactura) as Maximo from " + dfielddefConstantes.Cuerpo_Factura.ToString() + ""
                clsFacturacion.ObtenerUltimoNumeroCuerpoFactura(ultimo)
                For i = 1 To eFactCuerpoESt.Count - 1
                    eFactCuerpoESt(i).IdCuerpoFactura = ultimo
                    clsFacturacion.Pasar_A_Coleccion_Cuerpo_Factura(eFactCuerpoESt, datos, i)
                    clsQueryBuilder.ArmaInsert(dfielddefConstantes.Cuerpo_Factura.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    consulta = String.Empty
                    datos.Clear()
                    If (eFactCuerpoESt(i).Numero_Articulo = eArticulosEStFact(i).Id_Producto) Then
                        eArticulosEStFact(i).Stock = Convert.ToString(Convert.ToDouble(eArticulosEStFact(i).Stock) - (Convert.ToDouble(eFactCuerpoESt(i).Cantidad) * Convert.ToInt32(eFactCuerpoESt(i).Signo)))
                        consulta = "update " + dfielddefConstantes.Producto.ToString() + " set Stock='" + (eArticulosEStFact(i).Stock) + "' where ID_Producto= '" + (eFactCuerpoESt(i).Numero_Articulo) + "'"
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
                    clsImputaciones.ObtenerUltimoNumeroImputaciones(UltimoImputaciones)
                    ReDim eFomasdePagoEfectivo(1)
                    'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
                    clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtdatosEmpresa)
                    Responsabilidad_IVA_Empresa = dtdatosEmpresa.Rows(0).Item(dfielddefEmpresa.Responsabilidad_IVA).ToString()
                    ' = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (FactEncESt(1).Situacion_Frente_A_IVA) & "' "
                    clsCliente.Obtener_CondicionFrenteAIVa(eFactEncESt(1).Situacion_Frente_A_IVA, eNumero_Condicion_IVA_Cliente)
                    'consulta = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                    clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)
                    'consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                    'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                    'consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                    'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                    'consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                    'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                    'consulta += " and TC.IdTipoComprobante in ('4','9','15')"

                    clsFacturacion.Obtener_Datos_Comprobante(eNumero_Condicion_IVA_Cliente.Id_Condicion_IVA, Numero_Condicion_IVA_Empresa, dfielddefConstantes.Recibo.ToString(), eDatoTipoComprobante)
                    'tipocomprobante = datosFacturacion.Rows(0).Item("Descripcion")
                    'IDComprobante = datosFacturacion.Rows(0).Item("IdTipoComprobante")
                    tipocomprobante = eDatoTipoComprobante.Descripcion
                    IDComprobante = Convert.ToInt32(eDatoTipoComprobante.IdTipoComprobante)

                    'consulta = "select Numeracion from  " + dfielddefConstantes.Numeracion_Comprobante.ToString() + "  where Id_Empresa='" + Empresa.Compvariable + "' and Id_Tipo_Comprobante = '" & Convert.ToString(IDComprobante) & "'"
                    clsNumeroComprobante.obtener_Numero_Comprobante(clsEmpresa.Compvariable, Convert.ToString(IDComprobante), numeroComp)
                    nuComprobante = Convert.ToInt32(numeroComp) + 1
                    clsNumeroComprobante.Aumentar_Numeracion_Comprobante(nuComprobante, numeroComp)
                    consulta = ""
                    consulta = "Update Numeracion_Comprobante set Numeracion='" + (numeroComp) + "' where Id_Tipo_Comprobante='" + (Convert.ToString(IDComprobante)) + "' and Id_Empresa='" + (clsEmpresa.Compvariable) + "'"
                    tran.Add(consulta)

                    eFomasdePagoEfectivo(1).IdImputaciones = UltimoImputaciones
                    eFomasdePagoEfectivo(1).PuntoVentaRecibo = eFactEncESt(1).Punto_Venta
                    eFomasdePagoEfectivo(1).TipoComprobanteRecibo = Convert.ToString(IDComprobante).PadLeft(2, "0")
                    eFomasdePagoEfectivo(1).NumeroComprobanteRecibo = Convert.ToString(numeroComp).PadLeft(8, "0")

                    eFomasdePagoEfectivo(1).Comprobante = eFactEncESt(1).Comprobante
                    eFomasdePagoEfectivo(1).NumeroCliente = eFactEncESt(1).Numero_Cliente
                    eFomasdePagoEfectivo(1).Fecha = Date.Now()
                    eFomasdePagoEfectivo(1).PuntoVenta = eFactEncESt(1).Punto_Venta
                    eFomasdePagoEfectivo(1).TipoComprobante = eFactEncESt(1).Tipo_Comprobante
                    eFomasdePagoEfectivo(1).NumeroComprobante = eFactEncESt(1).Numero_Comprobante

                    eFomasdePagoEfectivo(1).Importe = eFactEncESt(1).Total
                    eFomasdePagoEfectivo(1).ID_FormaPago = eFactEncESt(1).Id_Forma_Pago

                    If clsformaPago.Compvariable = dfielddefConstantes.FACTURA.ToString() Then
                        'FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                        'FomasdePagoEfectivo(1).ID_FormaPago = FactEncESt(1).Id_Forma_Pago
                        eFomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.IngresoEfectivo.ToString()
                        eFomasdePagoEfectivo(1).Signo = "1"
                    ElseIf clsformaPago.Compvariable = dfielddefConstantes.NotaDebito.ToString() Then
                        'FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                        'FomasdePagoEfectivo(1).ID_FormaPago = FactEncESt(1).Id_Forma_Pago
                        eFomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.IngresoNotaDebito.ToString()
                        eFomasdePagoEfectivo(1).Signo = "1"
                    ElseIf clsformaPago.Compvariable = dfielddefConstantes.NotaCredito.ToString() Then
                        'FomasdePagoEfectivo(1).Importe = FactEncESt(1).Total
                        'FomasdePagoEfectivo(1).ID_FormaPago = FactEncESt(1).Id_Forma_Pago
                        eFomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.EgresoNotaCredito.ToString()
                        eFomasdePagoEfectivo(1).Signo = "-1"
                    End If
                    eFomasdePagoEfectivo(1).NroPuesto = clssession.Session.NroPuesto
                    clsQueryBuilder.obtener_estructura(dfielddefConstantes.Imputaciones.ToString(), esquema)
                    clsImputaciones.Obtener_Clave_Principal(ClavePrincipal)
                    clsImputaciones.Pasar_A_Coleccion(eFomasdePagoEfectivo, datos, 1)
                    clsQueryBuilder.ArmaInsert(dfielddefConstantes.Imputaciones.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                ElseIf (rbcc.Checked = True) Then
                    'consulta = "Select Max(IdCuentaCorriente) as Maximo from " + dfielddefConstantes.CuentaCorriente.ToString() + ""
                    clsCuentaCorriente.ObtenerUltimoNumeroCuentaCorriente(UltimoCuentaCorriente)
                    ReDim eFomasdePagoCuentaCorriente(1)
                    eFomasdePagoCuentaCorriente(1).Id_CuentaCorriente = UltimoCuentaCorriente
                    eFomasdePagoCuentaCorriente(1).PuntoVenta = eFactEncESt(1).Punto_Venta
                    eFomasdePagoCuentaCorriente(1).TipoComprobante = eFactEncESt(1).Tipo_Comprobante
                    eFomasdePagoCuentaCorriente(1).NumeroComprobante = eFactEncESt(1).Numero_Comprobante
                    eFomasdePagoCuentaCorriente(1).Comprobante = eFactEncESt(1).Comprobante
                    eFomasdePagoCuentaCorriente(1).NumeroCliente = eFactEncESt(1).Numero_Cliente
                    eFomasdePagoCuentaCorriente(1).Fecha = Date.Now()
                    eFomasdePagoCuentaCorriente(1).Importe = eFactEncESt(1).Total
                    eFomasdePagoCuentaCorriente(1).Signo = "1"
                    If clsformaPago.Compvariable = dfielddefConstantes.FACTURA.ToString() Then
                        ' FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                        eFomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.IngresoCuentaCorriente.ToString()
                        'FomasdePagoCuentaCorriente(1).Signo = "1"
                    ElseIf clsformaPago.Compvariable = dfielddefConstantes.NotaDebito.ToString() Then
                        'FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                        eFomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.IngresoNotaDebitoCuentaCorriente.ToString()
                        'FomasdePagoCuentaCorriente(1).Signo = "1"
                    ElseIf clsformaPago.Compvariable = dfielddefConstantes.NotaCredito.ToString() Then
                        'FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                        eFomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.EgresoNotaCreditoCuentaCorriente.ToString()
                        'FomasdePagoCuentaCorriente(1).Signo = "-1"
                    End If
                    eFomasdePagoCuentaCorriente(1).NroPuesto = clssession.Session.NroPuesto
                    clsQueryBuilder.obtener_estructura(dfielddefConstantes.CuentaCorriente.ToString(), esquema)
                    clsCuentaCorriente.Obtener_Clave_Principal(ClavePrincipal)
                    clsCuentaCorriente.Pasar_A_Coleccion(eFomasdePagoCuentaCorriente, datos, 1)
                    clsQueryBuilder.ArmaInsert(dfielddefConstantes.CuentaCorriente.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                End If
                clsTransaccion.Operaciones_Tabla_Transaccion(tran)
                tran.Clear()
                MessageBox.Show("El Comprobante, se ha agregado Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Information)
                LimpiarEstructuras()
                FormNotaCredito.lblCodN.Visible = False
                FormNotaCredito.txtCodigoCliente.Text = ""
                Me.Close()
                clsformaPago.Compvariable = dfielddefConstantes.Si.ToString()
            Else
                MessageBox.Show("Debe seleccionar una forma de pago!!!", "Informacion", MessageBoxButtons.OK, _
                                                MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim eFactEncESt(0)
        ReDim eFactCuerpoESt(0)
        ReDim eNumero_ComprobanteEStFact(0)
        ReDim eArticulosEStFact(0)
        ReDim eFomasdePagoEfectivo(0)
        ReDim eFomasdePagoCuentaCorriente(0)
        lblImporteCC.Text = ""
        lbImporteContado.Text = ""
        rbContado.Checked = False
        rbcc.Checked = False
    End Sub
    Private Sub rbContado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbContado.CheckedChanged
        If (rbContado.Checked = True) Then
            lbImporteContado.Text = "$" + eFactEncESt(1).Total
            lblImporteCC.Text = ""
        End If
    End Sub
    Private Sub rbcc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbcc.CheckedChanged
        If (rbcc.Checked = True) Then
            lblImporteCC.Text = "$" + eFactEncESt(1).Total
            lbImporteContado.Text = ""
        End If
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        LimpiarEstructuras()
        clsformaPago.Compvariable = dfielddefConstantes.No.ToString()
    End Sub
End Class