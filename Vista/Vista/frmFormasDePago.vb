Imports DevComponents.DotNetBar

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
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim dtdatosDataTable As New DataTable
        Dim tipocomprobante As String
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim i As Integer
        Dim ultimo As Integer
        Dim UltimoImputaciones As Integer
        Dim UltimoCuentaCorriente As Integer
        Dim idx As Integer
        Dim dtdatosFacturacion As New DataTable
        Dim dtdatosEmpresa As New DataTable
        Dim Responsabilidad_IVA_Empresa As String
        Dim Numero_Sucursal As String
        Dim IDComprobante As Integer
        Dim numeroComp As String = String.Empty
        Dim nuComprobante As Integer
        Dim existe As Boolean
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

                clsFacturacion.Registrar(eFactEncESt, eNumero_ComprobanteEStFact, eFactCuerpoESt, eArticulosEStFact)

                MessageBoxEx.Show("El Comprobante, se ha agregado Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Information)
                
                LimpiarEstructuras()
                FormNotaCredito.lblCodN.Visible = False
                FormNotaCredito.txtCodigoCliente.Text = ""
                Me.Close()
                clsformaPago.Compvariable = dfielddefConstantes.Si.ToString()
            Else
                MessageBoxEx.Show("Debe seleccionar una forma de pago!!!", "Informacion", MessageBoxButtons.OK, _
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