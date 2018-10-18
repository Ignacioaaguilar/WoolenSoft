Public Class EmpresaAlta
    Public codigo_Empresa As Integer
    Dim Empresa_estructura(0) As Controlador.Empresas.eEmpresa
    Dim NumeracionComprobante_estructura(0) As Controlador.NumeroComprobante.eNumeracionComprobante
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Private Sub ToolStripSalirEmpresaAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirEmpresaAlta.Click
        For x As Integer = ProgressBarEmpresaAlta.Minimum To ProgressBarEmpresaAlta.Maximum
            ProgressBarEmpresaAlta.Value = x
        Next
        For x As Integer = ProgressBarEmpresaAlta.Maximum To ProgressBarEmpresaAlta.Minimum Step -1
            ProgressBarEmpresaAlta.Value = x
        Next
        Me.Close()
        Empresa.Show()
    End Sub
    Private Sub EmpresaAlta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim provincia As New Controlador.Provincia
        Dim respIVA As New Controlador.ResponsabilidadIVA
        Dim consulta As String
        Try
            'consulta = "Select * from " + dfielddefConstantes.Provincia.ToString() + ""
            provincia.llenar_Combo_provincia(CBProvincia, "Descripcion", "Descripcion")
            'consulta = "Select * from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + ""
            respIVA.llenar_Combo_ResponsabilidadIVA(CBResponsabilidadIVA, "Descripcion", "Descripcion")
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripGuardarEmpresaAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripGuardarEmpresaAlta.Click
        Dim empresa As New Controlador.Empresas
        Dim numeroComprobante As New Controlador.NumeroComprobante
        Dim Transaccion As New Controlador.Transacciones
        Dim consulta As String
        Dim existe As Boolean
        Dim datos As New DataTable
        Dim Datos_Coll As New Collection
        Dim mayor As Integer
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim Trans As New Collection
        Dim Ultimo As Integer
        Dim UltimoNumComprobante As Integer
        Dim Responsabilidad_IVA As New Controlador.ResponsabilidadIVA()
        Dim Resp_IVA_ID As Integer
        Try
            For x As Integer = ProgressBarEmpresaAlta.Minimum To ProgressBarEmpresaAlta.Maximum
                ProgressBarEmpresaAlta.Value = x
            Next
            For x As Integer = ProgressBarEmpresaAlta.Maximum To ProgressBarEmpresaAlta.Minimum Step -1
                ProgressBarEmpresaAlta.Value = x
            Next
            If (empresa.Compvariable = dfielddefConstantes.Agregar_Empresa.ToString()) Then
                If (TBRazonSocial.Text <> "" And TBLocalidad.Text <> "" And TBCuit1.Text <> "" And TBCuit2.Text <> "" And TBCuit3.Text <> "" And TBIngresosBrutos.Text <> "" And TBNroSucursal.Text <> "") Then
                    ReDim Empresa_estructura(1)
                    'consulta = "select max(Id_Empresa) from " + dfielddefConstantes.Empresa.ToString() + ""
                    empresa.ObtenerUltimoNumeroEmpresa(Ultimo)
                    Empresa_estructura(1).Id_Empresa = Ultimo
                    Empresa_estructura(1).Razon_Social = TBRazonSocial.Text
                    Empresa_estructura(1).Calle = TBCalle.Text
                    Empresa_estructura(1).Piso = TBPiso.Text
                    Empresa_estructura(1).Nro = TBNro.Text
                    Empresa_estructura(1).Localidad = TBLocalidad.Text
                    Empresa_estructura(1).Codigo_Postal = TBCodigoPostal.Text
                    Empresa_estructura(1).CUIT = TBCuit1.Text + "-" + TBCuit2.Text + "-" + TBCuit3.Text
                    Empresa_estructura(1).Provincia = CBProvincia.Text
                    Empresa_estructura(1).Ingresos_Brutos = TBIngresosBrutos.Text
                    Responsabilidad_IVA.Obtener_Responsabilidad_Iva_Por_Descripcion(CBResponsabilidadIVA.Text, Resp_IVA_ID)
                    Empresa_estructura(1).Id_Responsabilidad_IVA = Resp_IVA_ID
                    Empresa_estructura(1).Responsabilidad_IVA = CBResponsabilidadIVA.Text
                    Empresa_estructura(1).Nro_Sucursal = TBNroSucursal.Text
                    Try
                        'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + " where Nro_Sucursal='" & (TBNroSucursal.Text) & "'"
                        empresa.se_Cargo(TBNroSucursal.Text, existe)
                        If Not (existe) Then
                            querybuilder.obtener_estructura(dfielddefConstantes.Empresa.ToString(), esquema)
                            empresa.Obtener_Clave_Principal(ClavePrincipal)
                            empresa.Pasar_A_Coleccion(Empresa_estructura, Datos_Coll, 1)
                            querybuilder.ArmaInsert(dfielddefConstantes.Empresa.ToString(), esquema, Datos_Coll, ClavePrincipal, consulta)
                            'empresa.Operaciones_Tabla(consulta)
                            Trans.Add(consulta)
                            'consulta = "select max(Id_Empresa)as Ultimo_Empresa from " + dfielddefConstantes.Empresa.ToString() + ""
                            'empresa.recuperar_Datos(consulta, datos)
                            'mayor = datos.Rows(0)("Ultimo_Empresa")
                            Dim Comprobante() As String = {"Factura A", "Nota de Debito A", "Nota de Credito A", "Recibo A", "Venta Rapida A", "Factura B", "Nota de Debito B", "Nota de Credito B", "Recibo B", "Venta Rapida B", "Factura C", "Nota de Debito C", "Nota de Credito C", "Recibo C", "Venta Rapida C", "Nota De Credito Int A", "Nota De Credito Int B", "Nota De Credito Int C"}
                            'consulta = "select max(Id_Comprobante) from " + dfielddefConstantes.Numeracion_Comprobante.ToString() + " "
                            numeroComprobante.ObtenerUltimoNumeroComprobanteEmpresa(UltimoNumComprobante)
                            For i = 1 To Comprobante.Count
                                ReDim Preserve NumeracionComprobante_estructura(i)
                                consulta = ""
                                'consulta = "select IdTipoComprobante from  " + dfielddefConstantes.Tipos_Comprobantes.ToString() + " where Descripcion = '" + UCase(Comprobante(i - 1)) + "'"
                                numeroComprobante.obtener_Datos_Numero_Comprobante_Descripcion_Comprobante(Comprobante(i - 1), datos)
                                Datos_Coll.Clear()
                                esquema.Clear()
                                ClavePrincipal.Clear()

                                NumeracionComprobante_estructura(i).Id_Comprobante = UltimoNumComprobante
                                NumeracionComprobante_estructura(i).Descripcion = Comprobante(i - 1)
                                NumeracionComprobante_estructura(i).Numeracion = "00000000"
                                NumeracionComprobante_estructura(i).Id_Empresa = Empresa_estructura(1).Id_Empresa
                                NumeracionComprobante_estructura(i).Id_Tipo_Comprobante = datos.Rows(0).Item("IdTipoComprobante")
                                querybuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
                                numeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
                                numeroComprobante.Pasar_A_Coleccion(NumeracionComprobante_estructura, Datos_Coll, i)
                                querybuilder.ArmaInsert(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, Datos_Coll, ClavePrincipal, consulta)
                                Trans.Add(consulta)
                                UltimoNumComprobante = UltimoNumComprobante + 1
                            Next
                            'For i = 1 To Trans.Count
                            '    numeroComprobante.Operaciones_Tabla(Trans(i))
                            'Next
                            Transaccion.Operaciones_Tabla_Transaccion(Trans)
                            Trans.Clear()
                            MessageBox.Show("Los Datos de la empresa, se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                            empresa.Limpiar_Datos_Empresas(TBRazonSocial, TBCalle, TBPiso, TBNro, TBLocalidad, TBCodigoPostal, TBCuit1, TBCuit2, TBCuit3, TBIngresosBrutos, TBNroSucursal)
                            LimpiarEstructuras()
                        Else
                            MessageBox.Show("Error: El Numero de Sucursal, se Agrego Anteriormente. Ingrese Otro!!!", "Informacion", MessageBoxButtons.OK, _
                                                 MessageBoxIcon.Error)
                            TBNroSucursal.Focus()
                        End If
                    Catch ex As Exception
                        MsgBox("Error:" & vbCrLf & ex.Message)
                    End Try
                Else
                    MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
                End If
            Else
                If (empresa.Compvariable = dfielddefConstantes.Modificar_Empresa.ToString()) Then
                    If (TBRazonSocial.Text <> "" And TBLocalidad.Text <> "" And TBCuit1.Text <> "" And TBCuit2.Text <> "" And TBCuit3.Text <> "" And TBIngresosBrutos.Text <> "" And TBNroSucursal.Text <> "") Then
                        ReDim Empresa_estructura(1)
                        Empresa_estructura(1).Id_Empresa = codigo_Empresa
                        Empresa_estructura(1).Razon_Social = TBRazonSocial.Text
                        Empresa_estructura(1).Calle = TBCalle.Text
                        Empresa_estructura(1).Piso = TBPiso.Text
                        Empresa_estructura(1).Nro = TBNro.Text
                        Empresa_estructura(1).Localidad = TBLocalidad.Text
                        Empresa_estructura(1).Codigo_Postal = TBCodigoPostal.Text
                        Empresa_estructura(1).CUIT = TBCuit1.Text + "-" + TBCuit2.Text + "-" + TBCuit3.Text
                        Empresa_estructura(1).Provincia = CBProvincia.Text
                        Empresa_estructura(1).Ingresos_Brutos = TBIngresosBrutos.Text
                        Empresa_estructura(1).Responsabilidad_IVA = CBResponsabilidadIVA.Text
                        Empresa_estructura(1).Nro_Sucursal = TBNroSucursal.Text
                        Try
                            querybuilder.obtener_estructura(dfielddefConstantes.Empresa.ToString(), esquema)
                            empresa.Obtener_Clave_Principal(ClavePrincipal)
                            empresa.Pasar_A_Coleccion(Empresa_estructura, Datos_Coll, 1)
                            querybuilder.ArmaUpdate(dfielddefConstantes.Empresa.ToString(), esquema, Datos_Coll, ClavePrincipal, consulta)
                            empresa.Operaciones_Tabla(consulta)
                            MessageBox.Show("Los Datos de la empresa, se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                            empresa.Limpiar_Datos_Empresas(TBRazonSocial, TBCalle, TBPiso, TBNro, TBLocalidad, TBCodigoPostal, TBCuit1, TBCuit2, TBCuit3, TBIngresosBrutos, TBNroSucursal)
                            LimpiarEstructuras()
                            TBNroSucursal.Focus()
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
    End Sub
    Private Sub TBCodigoPostal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCodigoPostal.TextChanged
        Dim empresa As New Controlador.Empresas
        If Not (empresa.es_Numero(TBCodigoPostal.Text)) Then
            TBCodigoPostal.Text = ""
        End If
    End Sub
    Private Sub TBNroSucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNroSucursal.TextChanged
        Dim empresa As New Controlador.Empresas
        If Not (empresa.es_Numero(TBNroSucursal.Text)) Then
            TBNroSucursal.Text = ""
        End If
    End Sub
    Private Sub TBNro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNro.TextChanged
        Dim empresa As New Controlador.Empresas
        If Not empresa.es_Numero(TBNro.Text) Then
            TBNro.Text = ""
        End If
    End Sub
    Private Sub TBCuit3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCuit3.TextChanged
        Dim empresa As New Controlador.Empresas
        Dim valido As Boolean
        Try
            If Not empresa.es_Numero(TBCuit3.Text) Then
                TBCuit3.Text = ""
            Else
                If (TBCuit3.Text <> "") And (TBCuit2.Text <> "") And (TBCuit1.Text <> "") Then
                    empresa.validar_Cuit(TBCuit1.Text, TBCuit2.Text, TBCuit3.Text, valido)
                    If Not valido Then
                        MessageBox.Show("Error: El Numero de CUIT es Invalido!!!", "Informacion", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Exclamation)
                        empresa.Limpiar_Datos_Empresa_CUIT(TBCuit1, TBCuit2, TBCuit3)
                        TBCuit1.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim Empresa_estructura(0)
        ReDim NumeracionComprobante_estructura(0)
    End Sub
    Private Sub TBCuit1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCuit1.TextChanged
        Dim empresa As New Controlador.Empresas
        If Not empresa.es_Numero(TBCuit1.Text) Then
            TBCuit1.Text = ""
        End If
    End Sub
    Private Sub TBCuit2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCuit2.TextChanged
        Dim empresa As New Controlador.Empresas
        If Not empresa.es_Numero(TBCuit2.Text) Then
            TBCuit2.Text = ""
        End If
    End Sub

    Private Sub TBNroSucursal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNroSucursal.Leave
        If IsNumeric(TBNroSucursal.Text) Then
            TBNroSucursal.Text = TBNroSucursal.Text.PadLeft(4, "0")
        
        End If
    End Sub
End Class