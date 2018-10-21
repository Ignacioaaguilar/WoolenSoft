Imports Controlador

Public Class frmCaja
    Dim estCaja() As Controlador.clsCaja.eCaja
    Dim session As New Controlador.clsSession()
    Dim tran As New Collection
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsEmpresa As New Controlador.clsEmpresas
    Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Dim clscajas As New Controlador.clsCaja
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim clsTransaccion As New Controlador.clsTransacciones
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Dim cajas As New Controlador.clsCaja
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim Transaccion As New Controlador.clsTransacciones
        Dim ultimo As Integer
        Dim dtdatosEmp As New DataTable

        clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtdatosEmp)
        If (clscajas.validateDoublesAndCurrency_Comprobante(txtCajaInicial.Text)) Then

            ReDim Preserve estCaja(1)
            clscajas.ObtenerUltimoNumeroCaja(ultimo)
            estCaja(1).IdCaja = ultimo
            estCaja(1).Importe = txtCajaInicial.Text
            estCaja(1).FechaApertura = Date.Now
            estCaja(1).FechaCierre = String.Empty
            estCaja(1).NroPuesto = session.Session.NroPuesto
            estCaja(1).Punto_Venta = dtdatosEmp.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal)
            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Caja.ToString(), esquema)
            clscajas.Obtener_Clave_Principal(ClavePrincipal)
            clscajas.Pasar_A_Coleccion(estCaja, datos, 1)
            clsQueryBuilder.ArmaInsert(dfielddefConstantes.Caja.ToString(), esquema, datos, ClavePrincipal, consulta)
            tran.Add(consulta)
            clsTransaccion.Operaciones_Tabla_Transaccion(tran)
            esquema.Clear()
            datos.Clear()
            ClavePrincipal.Clear()
            LimpiarEstructuras()
            Me.Close()
        Else
            txtCajaInicial.Text = "0.00"
        End If
    End Sub

    Public Sub LimpiarEstructuras()
        ReDim estCaja(0)
    End Sub
End Class