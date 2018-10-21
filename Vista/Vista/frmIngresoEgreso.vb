Public Class frmIngresoEgreso
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim estIngresoEgreso() As Controlador.clsCaja.eIngresoEgreso
    Dim clssession As New Controlador.clsSession()
    Dim tran As New Collection
    Dim clsEmpresa As New Controlador.clsEmpresas
    Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Dim clsIngresosEgresos As New Controlador.clsCaja
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim clsTransaccion As New Controlador.clsTransacciones

    Private Sub IngresoEgreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim IngresosEgresos As New Controlador.clsCaja
        If clsIngresosEgresos.Compvariable = dfielddefConstantes.Ingresos.ToString() Then
            Me.Text = "Ingreso"
            _lblMensajeTitulo.Text = "Carga de Ingreso"
            lblMensaje.Text = "Utilice este formulario para procesar ingresos a la caja, tales como: efectivo para cambio, aportes para gastos, etc"


        ElseIf clsIngresosEgresos.Compvariable = dfielddefConstantes.Egresos.ToString() Then
            Me.Text = "Engreso"
            _lblMensajeTitulo.Text = "Carga de Egresos"
            lblMensaje.Text = "Utilice este formulario para procesar Egresos a la caja."

        End If
        txtFecha.Text = Date.Now

    End Sub

    Private Sub ToolStripSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalir.Click
        animacion()
        Me.Close()
    End Sub

    Private Sub ToolStripGuardarIngresoEgreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripGuardarIngresoEgreso.Click
        'Dim IngresosEgresos As New Controlador.clsCaja
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim Transaccion As New Controlador.clsTransacciones
        Dim ultimo As Integer
        Dim dtdatosEmp As New DataTable
        Try
            animacion()
            If txtImporte.Text <> String.Empty Then
                clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtdatosEmp)
                ReDim Preserve estIngresoEgreso(1)
                clsIngresosEgresos.ObtenerUltimoNumeroIngresoEgresos(ultimo)
                estIngresoEgreso(1).Id_IngresosEgresos = ultimo
                estIngresoEgreso(1).Importe = Replace(txtImporte.Text, ".", ",")
                estIngresoEgreso(1).Fecha = txtFecha.Text
                estIngresoEgreso(1).Detalle = txtDetalle.Text
                estIngresoEgreso(1).NroPuesto = clssession.Session.NroPuesto
                estIngresoEgreso(1).Punto_Venta = dtdatosEmp.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal)
                If clsIngresosEgresos.Compvariable = dfielddefConstantes.Ingresos.ToString() Then

                    estIngresoEgreso(1).Signo = "1"
                    clsQueryBuilder.obtener_estructura(dfielddefConstantes.IngresosEgresos.ToString(), esquema)
                    clsIngresosEgresos.Obtener_Clave_Principal_IngresoEgreso(ClavePrincipal)
                    clsIngresosEgresos.Pasar_A_ColeccionIngresosEgresos(estIngresoEgreso, datos, 1)
                    clsQueryBuilder.ArmaInsert(dfielddefConstantes.IngresosEgresos.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    clsTransaccion.Operaciones_Tabla_Transaccion(tran)
                    esquema.Clear()
                    datos.Clear()
                    ClavePrincipal.Clear()
                    clsIngresosEgresos.LimpiarDatosEgresosIngresos(txtFecha, txtImporte, txtDetalle)
                    MessageBox.Show("El Ingreso se Registro Correctamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
                If clsIngresosEgresos.Compvariable = dfielddefConstantes.Egresos.ToString() Then

                    estIngresoEgreso(1).Signo = "-1"
                    clsQueryBuilder.obtener_estructura(dfielddefConstantes.IngresosEgresos.ToString(), esquema)
                    clsIngresosEgresos.Obtener_Clave_Principal_IngresoEgreso(ClavePrincipal)
                    clsIngresosEgresos.Pasar_A_ColeccionIngresosEgresos(estIngresoEgreso, datos, 1)
                    clsQueryBuilder.ArmaInsert(dfielddefConstantes.IngresosEgresos.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    clsTransaccion.Operaciones_Tabla_Transaccion(tran)
                    esquema.Clear()
                    datos.Clear()
                    ClavePrincipal.Clear()
                    clsIngresosEgresos.LimpiarDatosEgresosIngresos(txtFecha, txtImporte, txtDetalle)
                    MessageBox.Show("El Egreso se Registro Correctamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Else
                If clsIngresosEgresos.Compvariable = dfielddefConstantes.Ingresos.ToString() Then

                    MessageBox.Show("No se ha podido registar el Ingreso, ingrese el importe.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                If clsIngresosEgresos.Compvariable = dfielddefConstantes.Egresos.ToString() Then
                    MessageBox.Show("No se ha podido registar el Egreso, ingrese el importe.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If



        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        'Dim ingresoegresos As New Controlador.clsCaja
        If Not clsIngresosEgresos.validateDoublesAndCurrency_Comprobante(txtImporte.Text) Then
            txtImporte.Text = String.Empty
        End If

    End Sub

    Public Sub LimpiarEstructuras()
        ReDim estIngresoEgreso(0)
    End Sub

    Public Sub animacion()
        For x As Integer = ProgressBarEgresosIngresos.Minimum To ProgressBarEgresosIngresos.Maximum
            ProgressBarEgresosIngresos.Value = x
        Next
        For x As Integer = ProgressBarEgresosIngresos.Maximum To ProgressBarEgresosIngresos.Minimum Step -1
            ProgressBarEgresosIngresos.Value = x
        Next
    End Sub
End Class