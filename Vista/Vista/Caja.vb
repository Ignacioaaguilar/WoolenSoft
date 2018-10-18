Imports Controlador

Public Class Caja
    Dim estCaja() As Controlador.Caja.eCaja
    Dim session As New Controlador.Session()
    Dim tran As New Collection
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim Empresa As New Controlador.Empresas
    Dim dfielddefEmpresa As Controlador.DfieldDef.eEmpresa
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim cajas As New Controlador.Caja
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim Transaccion As New Controlador.Transacciones
        Dim ultimo As Integer
        Dim datosEmp As New DataTable

        Empresa.Obtener_Empresa(Empresa.Compvariable, datosEmp)
        If (cajas.validateDoublesAndCurrency_Comprobante(txtCajaInicial.Text)) Then

            ReDim Preserve estCaja(1)
            cajas.ObtenerUltimoNumeroCaja(ultimo)
            estCaja(1).IdCaja = ultimo
            estCaja(1).Importe = txtCajaInicial.Text
            estCaja(1).FechaApertura = Date.Now
            estCaja(1).FechaCierre = String.Empty
            estCaja(1).NroPuesto = session.Session.NroPuesto
            estCaja(1).Punto_Venta = datosEmp.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal)
            querybuilder.obtener_estructura(dfielddefConstantes.Caja.ToString(), esquema)
            cajas.Obtener_Clave_Principal(ClavePrincipal)
            cajas.Pasar_A_Coleccion(estCaja, datos, 1)
            querybuilder.ArmaInsert(dfielddefConstantes.Caja.ToString(), esquema, datos, ClavePrincipal, consulta)
            tran.Add(consulta)
            Transaccion.Operaciones_Tabla_Transaccion(tran)
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