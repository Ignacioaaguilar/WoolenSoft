Public Class frmNumeroComprobanteAlta
    Public codigo_NumeroComprobante As Integer
    Dim NumeracionComprobante_estructura(0) As Controlador.clsNumeroComprobante.eNumeracionComprobante
    Dim DfieldDefNumeroComprovante As Controlador.clsDfieldDef.eNumeroComprobante
    Dim DfieldDefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsempresa As New Controlador.clsEmpresas
    Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
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
        'Dim empresa As New Controlador.clsEmpresas
        Dim consulta As String
        Dim dtdatos As New DataTable
        Try
            'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa=" & CInt(CBNumeroEmpresa.Text) & " "
            clsempresa.recuperar_Datos(CBNumeroEmpresa.Text, dtdatos)
            TBDesEmpresa.Text = dtdatos.Rows(0).Item(DfieldDefEmpresa.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub RegistrarNumeroComprobanteAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrarNumeroComprobanteAlta.Click
        'Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Try
            If (clsNumeroComprobante.Compvariable = dfielddefConstantes.Agregar_NumeroComprobante.ToString()) Then
                If (TBDescripcion.Text <> String.Empty And TBNumeracion.Text <> String.Empty) Then
                    ReDim NumeracionComprobante_estructura(1)
                    NumeracionComprobante_estructura(1).Id_Comprobante = Nothing
                    NumeracionComprobante_estructura(1).Descripcion = TBDescripcion.Text
                    NumeracionComprobante_estructura(1).Numeracion = TBNumeracion.Text
                    NumeracionComprobante_estructura(1).Id_Empresa = CBNumeroEmpresa.Text
                    Try
                        clsQueryBuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
                        clsNumeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
                        clsNumeroComprobante.Pasar_A_Coleccion(NumeracionComprobante_estructura, datos, 1)
                        clsQueryBuilder.ArmaInsert(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, datos, ClavePrincipal, consulta)
                        clsNumeroComprobante.Operaciones_Tabla(consulta)
                        MessageBox.Show("Los Datos del Cliente se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                         MessageBoxIcon.Information)
                        clsNumeroComprobante.Limpiar_Datos_NumeroComprobante(TBDescripcion, TBNumeracion)
                        LimpiarEstructuras()
                    Catch ex As Exception
                        MsgBox("Error:" & vbCrLf & ex.Message)
                    End Try
                Else
                    MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
                End If
            Else
                If (clsNumeroComprobante.Compvariable = dfielddefConstantes.Modificar_NumeroComprobante.ToString()) Then
                    If (TBDescripcion.Text <> "" And TBNumeracion.Text <> "") Then
                        ReDim NumeracionComprobante_estructura(1)
                        NumeracionComprobante_estructura(1).Id_Comprobante = CInt(codigo_NumeroComprobante)
                        NumeracionComprobante_estructura(1).Descripcion = TBDescripcion.Text
                        NumeracionComprobante_estructura(1).Numeracion = TBNumeracion.Text
                        NumeracionComprobante_estructura(1).Id_Empresa = CInt(CBNumeroEmpresa.Text)
                        Try
                            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
                            clsNumeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
                            clsNumeroComprobante.Pasar_A_Coleccion(NumeracionComprobante_estructura, datos, 1)
                            clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, datos, ClavePrincipal, consulta)
                            clsNumeroComprobante.Operaciones_Tabla(consulta)
                            MessageBox.Show("Los Datos de la Numeracion, se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                            clsNumeroComprobante.Limpiar_Datos_NumeroComprobante(TBDescripcion, TBNumeracion)
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
        'Dim empresa As New Controlador.clsEmpresas
        Dim consulta As String
        Dim dtdatos As New DataTable
        Try
            'consulta = "select Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],CUIT,Ingresos_Brutos as [Ing Brutos],Responsabilidad_IVA as [Resp.IVA],Nro_Sucursal as [Nro Sucursal] from " + dfielddefConstantes.Empresa.ToString() + "   where Id_Empresa=" & CInt(CBNumeroEmpresa.Text) & " "
            clsempresa.recuperar_Datos(CBNumeroEmpresa.Text, dtdatos)
            TBDesEmpresa.Text = dtdatos.Rows(0).Item(DfieldDefEmpresa.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub NumeroComprobanteAlta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim empresa As New Controlador.clsEmpresas
        Dim dtdatos As New DataTable
        Dim consulta As String
        Try
            'consulta = "Select * from " + dfielddefConstantes.Empresa.ToString() + ""
            clsempresa.llenar_Combo_Empresas(CBNumeroEmpresa, "Id_Empresa", "Id_Empresa")
            'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa='" & (CBNumeroEmpresa.Text) & "' "
            clsempresa.recuperar_Datos(CBNumeroEmpresa.Text, dtdatos)
            TBDesEmpresa.Text = dtdatos.Rows(0).Item(DfieldDefEmpresa.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBNumeracion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNumeracion.TextChanged
        Dim numeracionComprobante As New Controlador.clsNumeroComprobante
        If Not (numeracionComprobante.es_Numero(TBNumeracion.Text)) Then
            TBNumeracion.Text = ""
        End If
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim NumeracionComprobante_estructura(0)
    End Sub
    Private Sub CBNumeroEmpresa_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBNumeroEmpresa.Leave
        'Dim empresa As New Controlador.clsEmpresas
        Dim consulta As String
        Dim dtdatos As New DataTable
        Try
            'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa='" & (CBNumeroEmpresa.Text) & "' "
            clsempresa.recuperar_Datos(CBNumeroEmpresa.Text, dtdatos)
            TBDesEmpresa.Text = dtdatos.Rows(0).Item(DfieldDefEmpresa.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class