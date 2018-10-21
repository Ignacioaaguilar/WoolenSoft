Public Class frmProveedorAlta
    Public codigo_Proveedor As Integer
    Dim eProveedor_estructura(0) As Controlador.clsContProveedor.eProveedor
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsProvincia As New Controlador.clsProvincia
    Dim clsrespIVA As New Controlador.clsResponsabilidadIVA
    Dim clsContProveedor As New Controlador.clsContProveedor
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Private Sub ToolStripSalirProveedorAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirProveedorAlta.Click
        For x As Integer = ProgressBarProveedorAlta.Minimum To ProgressBarProveedorAlta.Maximum
            ProgressBarProveedorAlta.Value = x
        Next
        For x As Integer = ProgressBarProveedorAlta.Maximum To ProgressBarProveedorAlta.Minimum Step -1
            ProgressBarProveedorAlta.Value = x
        Next
        Me.Close()
        frmProveedor.Show()
    End Sub

    Private Sub ProveedorAlta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim clsProvincia As New Controlador.clsProvincia
        'Dim respIVA As New Controlador.clsResponsabilidadIVA
        Dim consulta As String
        Try
            'consulta = "Select * from " + dfielddefConstantes.Provincia.ToString() + ""
            clsProvincia.llenar_Combo_provincia(CBProvincia, "Descripcion", "Descripcion")
            'consulta = "Select * from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + ""
            clsrespIVA.llenar_Combo_ResponsabilidadIVA(CBResponsabilidadIVA, "Descripcion", "Descripcion")
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBEmail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBEmail.LostFocus
        'Dim clsContProveedor As New Controlador.clsContProveedor
        If Not (clsContProveedor.ValidateEmail_Proveedor(TBEmail.Text)) Then
            TBEmail.Text = String.Empty
            TBEmail.Focus()
        End If
    End Sub
    Private Sub TBTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBTelefono.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        If Not clsContProveedor.es_Numero(TBTelefono.Text) Then
            TBTelefono.Text = String.Empty
        End If
    End Sub
    Private Sub TBCelular_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCelular.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        If Not clsContProveedor.es_Numero(TBCelular.Text) Then
            TBCelular.Text = String.Empty
        End If
    End Sub
    Private Sub TBNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNumero.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        If Not clsContProveedor.es_Numero(TBNumero.Text) Then
            TBNumero.Text = String.Empty
        End If
    End Sub
    Private Sub TBCodigoPostal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCodigoPostal.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        If Not (clsContProveedor.es_Numero(TBCodigoPostal.Text)) Then
            TBCodigoPostal.Text = String.Empty
        End If
    End Sub
    Private Sub TBCuitProveedor1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCuitProveedor1.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        If Not clsContProveedor.es_Numero(TBCuitProveedor1.Text) Then
            TBCuitProveedor1.Text = String.Empty
        End If
    End Sub
    Private Sub TBCuitProveedor2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCuitProveedor2.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        If Not clsContProveedor.es_Numero(TBCuitProveedor2.Text) Then
            TBCuitProveedor2.Text = String.Empty
        End If
    End Sub
    Private Sub TBCuitProveedor3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCuitProveedor3.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        Dim valido As Boolean
        Try
            If Not clsContProveedor.es_Numero(TBCuitProveedor3.Text) Then
                TBCuitProveedor3.Text = String.Empty
            Else
                If (TBCuitProveedor3.Text <> String.Empty) And (TBCuitProveedor2.Text <> String.Empty) And (TBCuitProveedor1.Text <> String.Empty) Then
                    clsContProveedor.validar_Cuit(TBCuitProveedor1.Text, TBCuitProveedor2.Text, TBCuitProveedor3.Text, valido)
                    If Not valido Then
                        MessageBox.Show("Error: El Numero de CUIT es Invalido!!!", "Informacion", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Exclamation)
                        clsContProveedor.Limpiar_Datos_Proveedor_CUIT(TBCuitProveedor1, TBCuitProveedor2, TBCuitProveedor3)
                        TBCuitProveedor1.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripGurdarProveedorAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripGurdarProveedorAlta.Click
        'Dim clsContProveedor As New Controlador.clsContProveedor
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim ultimo As Integer
        Try
            If (clsContProveedor.Compvariable = dfielddefConstantes.Agregar_Proveedor.ToString()) Then
                If (TBRazonSocial.Text <> String.Empty And TBTelefono.Text <> String.Empty And CBResponsabilidadIVA.Text <> String.Empty And TBNumero.Text <> String.Empty) Then
                    ReDim eProveedor_estructura(1)
                    'consulta = "Select max(Id_Proveedor)from " + dfielddefConstantes.Proveedor.ToString() + ""
                    clsContProveedor.ObtenerUltimoNumeroProveedor(ultimo)
                    eProveedor_estructura(1).Id_Proveedor = ultimo
                    eProveedor_estructura(1).Razon_Social = TBRazonSocial.Text
                    eProveedor_estructura(1).Calle = TBCalle.Text
                    eProveedor_estructura(1).Piso = TBPiso.Text
                    eProveedor_estructura(1).Nro = TBNumero.Text
                    eProveedor_estructura(1).Localidad = TBLocalidad.Text
                    eProveedor_estructura(1).Codigo_Postal = TBCodigoPostal.Text
                    eProveedor_estructura(1).Provincia = CBProvincia.Text
                    eProveedor_estructura(1).Telefono = TBTelefono.Text
                    eProveedor_estructura(1).Celular = TBCelular.Text
                    eProveedor_estructura(1).CUIT = TBCuitProveedor1.Text + "-" + TBCuitProveedor2.Text + "-" + TBCuitProveedor3.Text
                    eProveedor_estructura(1).E_Mail = TBEmail.Text
                    eProveedor_estructura(1).Responsabilidad_IVA = CBResponsabilidadIVA.Text
                    If clsContProveedor.es_Vacio(TBSaldoCorriente.Text) Then
                        eProveedor_estructura(1).Saldo_CC = 0
                    Else
                        eProveedor_estructura(1).Saldo_CC = (TBSaldoCorriente.Text)
                    End If
                    Try
                        clsQueryBuilder.obtener_estructura(dfielddefConstantes.Proveedor.ToString(), esquema)
                        clsContProveedor.Obtener_Clave_Principal(ClavePrincipal)
                        clsContProveedor.Pasar_A_Coleccion(eProveedor_estructura, datos, 1)
                        clsQueryBuilder.ArmaInsert(dfielddefConstantes.Proveedor.ToString(), esquema, datos, ClavePrincipal, consulta)
                        clsContProveedor.Operaciones_Tabla(consulta)
                        MessageBox.Show("Los Datos del Proveedor se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                         MessageBoxIcon.Information)
                        clsContProveedor.Limpiar_Datos_Proveedor(TBRazonSocial, TBCalle, TBCelular, TBTelefono, TBCodigoPostal, TBCuitProveedor1, TBCuitProveedor2, TBCuitProveedor3, TBEmail, TBLocalidad, TBNumero, TBPiso, TBSaldoCorriente)
                        LimpiarEstructuras()
                    Catch ex As Exception
                        MsgBox("Error:" & vbCrLf & ex.Message)
                    End Try
                Else
                    MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
                End If
            Else
                If (clsContProveedor.Compvariable = dfielddefConstantes.Modificar_Proveedor.ToString()) Then
                    If (TBRazonSocial.Text <> String.Empty And TBTelefono.Text <> String.Empty And CBResponsabilidadIVA.Text <> String.Empty And TBNumero.Text <> String.Empty) Then
                        ReDim eProveedor_estructura(1)
                        eProveedor_estructura(1).Id_Proveedor = codigo_Proveedor
                        eProveedor_estructura(1).Razon_Social = TBRazonSocial.Text
                        eProveedor_estructura(1).Calle = TBCalle.Text
                        eProveedor_estructura(1).Piso = TBPiso.Text
                        eProveedor_estructura(1).Nro = TBNumero.Text
                        eProveedor_estructura(1).Localidad = TBLocalidad.Text
                        eProveedor_estructura(1).Codigo_Postal = TBCodigoPostal.Text
                        eProveedor_estructura(1).Provincia = CBProvincia.Text
                        eProveedor_estructura(1).Telefono = TBTelefono.Text
                        eProveedor_estructura(1).Celular = TBCelular.Text
                        eProveedor_estructura(1).CUIT = TBCuitProveedor1.Text + "-" + TBCuitProveedor2.Text + "-" + TBCuitProveedor3.Text
                        eProveedor_estructura(1).E_Mail = TBEmail.Text
                        eProveedor_estructura(1).Responsabilidad_IVA = CBResponsabilidadIVA.Text
                        If clsContProveedor.es_Vacio(TBSaldoCorriente.Text) Then
                            eProveedor_estructura(1).Saldo_CC = 0
                        Else
                            eProveedor_estructura(1).Saldo_CC = (TBSaldoCorriente.Text)
                        End If
                        Try
                            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Proveedor.ToString(), esquema)
                            clsContProveedor.Obtener_Clave_Principal(ClavePrincipal)
                            clsContProveedor.Pasar_A_Coleccion(eProveedor_estructura, datos, 1)
                            clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Proveedor.ToString(), esquema, datos, ClavePrincipal, consulta)
                            clsContProveedor.Operaciones_Tabla(consulta)
                            MessageBox.Show("Los Datos del Proveedor se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                            clsContProveedor.Limpiar_Datos_Proveedor(TBRazonSocial, TBCalle, TBCelular, TBTelefono, TBCodigoPostal, TBCuitProveedor1, TBCuitProveedor2, TBCuitProveedor3, TBEmail, TBLocalidad, TBNumero, TBPiso, TBSaldoCorriente)
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
        For x As Integer = ProgressBarProveedorAlta.Minimum To ProgressBarProveedorAlta.Maximum
            ProgressBarProveedorAlta.Value = x
        Next
        For x As Integer = ProgressBarProveedorAlta.Maximum To ProgressBarProveedorAlta.Minimum Step -1
            ProgressBarProveedorAlta.Value = x
        Next
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim eProveedor_estructura(0)
    End Sub
    Private Sub TBSaldoCorriente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBSaldoCorriente.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        If Not clsContProveedor.validateDoublesAndCurrency_Proveedor(TBSaldoCorriente.Text) Then
            TBSaldoCorriente.Text = String.Empty
        End If
    End Sub
End Class