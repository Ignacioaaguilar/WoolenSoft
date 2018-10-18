Public Class frmNumeroComprobanteAlta
    Public codigo_NumeroComprobante As Integer
    Dim NumeracionComprobante_estructura(0) As Controlador.NumeroComprobante.eNumeracionComprobante
    Dim DfieldDefNumeroComprovante As Controlador.DfieldDef.eNumeroComprobante
    Dim DfieldDefEmpresa As Controlador.DfieldDef.eEmpresa
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Private Sub SalirNumeroComprobanteAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirNumeroComprobanteAlta.Click
        For x As Integer = ProgressBarNumeroComprobanteAlta.Minimum To ProgressBarNumeroComprobanteAlta.Maximum
            ProgressBarNumeroComprobanteAlta.Value = x
        Next
        For x As Integer = ProgressBarNumeroComprobanteAlta.Maximum To ProgressBarNumeroComprobanteAlta.Minimum Step -1
            ProgressBarNumeroComprobanteAlta.Value = x
        Next
        Me.Close()
        frmNumeroComprobante.Show()
    End Sub
    Private Sub CBNumeroEmpresa_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBNumeroEmpresa.GotFocus
        Dim empresa As New Controlador.Empresas
        Dim consulta As String
        Dim datos As New DataTable
        Try
            'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa=" & CInt(CBNumeroEmpresa.Text) & " "
            empresa.recuperar_Datos(CBNumeroEmpresa.Text, datos)
            TBDesEmpresa.Text = datos.Rows(0).Item(DfieldDefEmpresa.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub RegistrarNumeroComprobanteAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarNumeroComprobanteAlta.Click
        Dim numerocomprobante As New Controlador.NumeroComprobante
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Try
            If (numerocomprobante.Compvariable = dfielddefConstantes.Agregar_NumeroComprobante.ToString()) Then
                If (TBDescripcion.Text <> String.Empty And TBNumeracion.Text <> String.Empty) Then
                    ReDim NumeracionComprobante_estructura(1)
                    NumeracionComprobante_estructura(1).Id_Comprobante = Nothing
                    NumeracionComprobante_estructura(1).Descripcion = TBDescripcion.Text
                    NumeracionComprobante_estructura(1).Numeracion = TBNumeracion.Text
                    NumeracionComprobante_estructura(1).Id_Empresa = CBNumeroEmpresa.Text
                    Try
                        querybuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
                        numerocomprobante.Obtener_Clave_Principal(ClavePrincipal)
                        numerocomprobante.Pasar_A_Coleccion(NumeracionComprobante_estructura, datos, 1)
                        querybuilder.ArmaInsert(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, datos, ClavePrincipal, consulta)
                        numerocomprobante.Operaciones_Tabla(consulta)
                        MessageBox.Show("Los Datos del Cliente se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                         MessageBoxIcon.Information)
                        numerocomprobante.Limpiar_Datos_NumeroComprobante(TBDescripcion, TBNumeracion)
                        LimpiarEstructuras()
                    Catch ex As Exception
                        MsgBox("Error:" & vbCrLf & ex.Message)
                    End Try
                Else
                    MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
                End If
            Else
                If (numerocomprobante.Compvariable = dfielddefConstantes.Modificar_NumeroComprobante.ToString()) Then
                    If (TBDescripcion.Text <> "" And TBNumeracion.Text <> "") Then
                        ReDim NumeracionComprobante_estructura(1)
                        NumeracionComprobante_estructura(1).Id_Comprobante = CInt(codigo_NumeroComprobante)
                        NumeracionComprobante_estructura(1).Descripcion = TBDescripcion.Text
                        NumeracionComprobante_estructura(1).Numeracion = TBNumeracion.Text
                        NumeracionComprobante_estructura(1).Id_Empresa = CInt(CBNumeroEmpresa.Text)
                        Try
                            querybuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
                            numerocomprobante.Obtener_Clave_Principal(ClavePrincipal)
                            numerocomprobante.Pasar_A_Coleccion(NumeracionComprobante_estructura, datos, 1)
                            querybuilder.ArmaUpdate(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, datos, ClavePrincipal, consulta)
                            numerocomprobante.Operaciones_Tabla(consulta)
                            MessageBox.Show("Los Datos de la Numeracion, se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                            numerocomprobante.Limpiar_Datos_NumeroComprobante(TBDescripcion, TBNumeracion)
                            LimpiarEstructuras()
                        Catch ex As Exception
                            MsgBox("Error:" & vbCrLf & ex.Message)
                        End Try
                    Else
                        MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                         MessageBoxIcon.Exclamation)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
        For x As Integer = ProgressBarNumeroComprobanteAlta.Minimum To ProgressBarNumeroComprobanteAlta.Maximum
            ProgressBarNumeroComprobanteAlta.Value = x
        Next
        For x As Integer = ProgressBarNumeroComprobanteAlta.Maximum To ProgressBarNumeroComprobanteAlta.Minimum Step -1
            ProgressBarNumeroComprobanteAlta.Value = x
        Next
    End Sub
    Private Sub CBNumeroEmpresa_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBNumeroEmpresa.LostFocus
        Dim empresa As New Controlador.Empresas
        Dim consulta As String
        Dim datos As New DataTable
        Try
            'consulta = "select Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],CUIT,Ingresos_Brutos as [Ing Brutos],Responsabilidad_IVA as [Resp.IVA],Nro_Sucursal as [Nro Sucursal] from " + dfielddefConstantes.Empresa.ToString() + "   where Id_Empresa=" & CInt(CBNumeroEmpresa.Text) & " "
            empresa.recuperar_Datos(CBNumeroEmpresa.Text, datos)
            TBDesEmpresa.Text = datos.Rows(0).Item(DfieldDefEmpresa.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub NumeroComprobanteAlta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim empresa As New Controlador.Empresas
        Dim datos As New DataTable
        Dim consulta As String
        Try
            'consulta = "Select * from " + dfielddefConstantes.Empresa.ToString() + ""
            empresa.llenar_Combo_Empresas(CBNumeroEmpresa, "Id_Empresa", "Id_Empresa")
            'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa='" & (CBNumeroEmpresa.Text) & "' "
            empresa.recuperar_Datos(CBNumeroEmpresa.Text, datos)
            TBDesEmpresa.Text = datos.Rows(0).Item(DfieldDefEmpresa.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBNumeracion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNumeracion.TextChanged
        Dim numeracionComprobante As New Controlador.NumeroComprobante
        If Not (numeracionComprobante.es_Numero(TBNumeracion.Text)) Then
            TBNumeracion.Text = ""
        End If
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim NumeracionComprobante_estructura(0)
    End Sub
    Private Sub CBNumeroEmpresa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBNumeroEmpresa.Leave
        Dim empresa As New Controlador.Empresas
        Dim consulta As String
        Dim datos As New DataTable
        Try
            'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa='" & (CBNumeroEmpresa.Text) & "' "
            empresa.recuperar_Datos(CBNumeroEmpresa.Text, datos)
            TBDesEmpresa.Text = datos.Rows(0).Item(DfieldDefEmpresa.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class