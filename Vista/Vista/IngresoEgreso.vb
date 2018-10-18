Public Class IngresoEgreso
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim estIngresoEgreso() As Controlador.Caja.eIngresoEgreso
    Dim session As New Controlador.Session()
    Dim tran As New Collection
    Dim Empresa As New Controlador.Empresas
    Dim dfielddefEmpresa As Controlador.DfieldDef.eEmpresa

    Private Sub IngresoEgreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim IngresosEgresos As New Controlador.Caja
        If IngresosEgresos.Compvariable = dfielddefConstantes.Ingresos.ToString() Then
            Me.Text = "Ingreso"
            _lblMensajeTitulo.Text = "Carga de Ingreso"
            lblMensaje.Text = "Utilice este formulario para procesar ingresos a la caja, tales como: efectivo para cambio, aportes para gastos, etc"


        ElseIf IngresosEgresos.Compvariable = dfielddefConstantes.Egresos.ToString() Then
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
        Dim IngresosEgresos As New Controlador.Caja
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim Transaccion As New Controlador.Transacciones
        Dim ultimo As Integer
        Dim datosEmp As New DataTable
        Try
            animacion()
            If txtImporte.Text <> String.Empty Then
                Empresa.Obtener_Empresa(Empresa.Compvariable, datosEmp)
                ReDim Preserve estIngresoEgreso(1)
                IngresosEgresos.ObtenerUltimoNumeroIngresoEgresos(ultimo)
                estIngresoEgreso(1).Id_IngresosEgresos = ultimo
                estIngresoEgreso(1).Importe = Replace(txtImporte.Text, ".", ",")
                estIngresoEgreso(1).Fecha = txtFecha.Text
                estIngresoEgreso(1).Detalle = txtDetalle.Text
                estIngresoEgreso(1).NroPuesto = session.Session.NroPuesto
                estIngresoEgreso(1).Punto_Venta = datosEmp.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal)
                If IngresosEgresos.Compvariable = dfielddefConstantes.Ingresos.ToString() Then

                    estIngresoEgreso(1).Signo = "1"
                    querybuilder.obtener_estructura(dfielddefConstantes.IngresosEgresos.ToString(), esquema)
                    IngresosEgresos.Obtener_Clave_Principal_IngresoEgreso(ClavePrincipal)
                    IngresosEgresos.Pasar_A_ColeccionIngresosEgresos(estIngresoEgreso, datos, 1)
                    querybuilder.ArmaInsert(dfielddefConstantes.IngresosEgresos.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    Transaccion.Operaciones_Tabla_Transaccion(tran)
                    esquema.Clear()
                    datos.Clear()
                    ClavePrincipal.Clear()
                    IngresosEgresos.LimpiarDatosEgresosIngresos(txtFecha, txtImporte, txtDetalle)
                    MessageBox.Show("El Ingreso se Registro Correctamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
                If IngresosEgresos.Compvariable = dfielddefConstantes.Egresos.ToString() Then

                    estIngresoEgreso(1).Signo = "-1"
                    querybuilder.obtener_estructura(dfielddefConstantes.IngresosEgresos.ToString(), esquema)
                    IngresosEgresos.Obtener_Clave_Principal_IngresoEgreso(ClavePrincipal)
                    IngresosEgresos.Pasar_A_ColeccionIngresosEgresos(estIngresoEgreso, datos, 1)
                    querybuilder.ArmaInsert(dfielddefConstantes.IngresosEgresos.ToString(), esquema, datos, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    Transaccion.Operaciones_Tabla_Transaccion(tran)
                    esquema.Clear()
                    datos.Clear()
                    ClavePrincipal.Clear()
                    IngresosEgresos.LimpiarDatosEgresosIngresos(txtFecha, txtImporte, txtDetalle)
                    MessageBox.Show("El Egreso se Registro Correctamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Else
                If IngresosEgresos.Compvariable = dfielddefConstantes.Ingresos.ToString() Then

                    MessageBox.Show("No se ha podido registar el Ingreso, ingrese el importe.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                If IngresosEgresos.Compvariable = dfielddefConstantes.Egresos.ToString() Then
                    MessageBox.Show("No se ha podido registar el Egreso, ingrese el importe.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If



        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub txtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImporte.TextChanged
        Dim ingresoegresos As New Controlador.Caja
        If Not ingresoegresos.validateDoublesAndCurrency_Comprobante(txtImporte.Text) Then
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