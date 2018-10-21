Public Class frmEmpresaAlta
    Public codigo_Empresa As Integer
    Dim eEmpresa_estructura(0) As Controlador.clsEmpresas.eEmpresa
    Dim eNumeracionComprobante_estructura(0) As Controlador.clsNumeroComprobante.eNumeracionComprobante
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsProvincia As New Controlador.clsProvincia
    Dim clsrespIVA As New Controlador.clsResponsabilidadIVA
    Dim clsempresa As New Controlador.clsEmpresas
    Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
    Dim clsTransaccion As New Controlador.clsTransacciones
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim clsResponsabilidad_IVA As New Controlador.clsResponsabilidadIVA()
    Private Sub ToolStripSalirEmpresaAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirEmpresaAlta.Click
        For x As Integer = ProgressBarEmpresaAlta.Minimum To ProgressBarEmpresaAlta.Maximum
            ProgressBarEmpresaAlta.Value = x
        Next
        For x As Integer = ProgressBarEmpresaAlta.Maximum To ProgressBarEmpresaAlta.Minimum Step -1
            ProgressBarEmpresaAlta.Value = x
        Next
        Me.Close()
        frmEmpresa.Show()
    End Sub
    Private Sub EmpresaAlta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub ToolStripGuardarEmpresaAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripGuardarEmpresaAlta.Click
        'Dim empresa As New Controlador.clsEmpresas
        'Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
        'Dim Transaccion As New Controlador.clsTransacciones
        Dim consulta As String
        Dim existe As Boolean
        Dim dtdatos As New DataTable
        Dim Datos_Coll As New Collection
        Dim mayor As Integer
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim Trans As New Collection
        Dim Ultimo As Integer
        Dim UltimoNumComprobante As Integer
        'Dim Responsabilidad_IVA As New Controlador.clsResponsabilidadIVA()
        Dim Resp_IVA_ID As Integer
        Try
            For x As Integer = ProgressBarEmpresaAlta.Minimum To ProgressBarEmpresaAlta.Maximum
                ProgressBarEmpresaAlta.Value = x
            Next
            For x As Integer = ProgressBarEmpresaAlta.Maximum To ProgressBarEmpresaAlta.Minimum Step -1
                ProgressBarEmpresaAlta.Value = x
            Next
            If (clsempresa.Compvariable = dfielddefConstantes.Agregar_Empresa.ToString()) Then
                If (TBRazonSocial.Text <> "" And TBLocalidad.Text <> "" And TBCuit1.Text <> "" And TBCuit2.Text <> "" And TBCuit3.Text <> "" And TBIngresosBrutos.Text <> "" And TBNroSucursal.Text <> "") Then
                    ReDim eEmpresa_estructura(1)
                    'consulta = "select max(Id_Empresa) from " + dfielddefConstantes.Empresa.ToString() + ""
                    clsempresa.ObtenerUltimoNumeroEmpresa(Ultimo)
                    eEmpresa_estructura(1).Id_Empresa = Ultimo
                    eEmpresa_estructura(1).Razon_Social = TBRazonSocial.Text
                    eEmpresa_estructura(1).Calle = TBCalle.Text
                    eEmpresa_estructura(1).Piso = TBPiso.Text
                    eEmpresa_estructura(1).Nro = TBNro.Text
                    eEmpresa_estructura(1).Localidad = TBLocalidad.Text
                    eEmpresa_estructura(1).Codigo_Postal = TBCodigoPostal.Text
                    eEmpresa_estructura(1).CUIT = TBCuit1.Text + "-" + TBCuit2.Text + "-" + TBCuit3.Text
                    eEmpresa_estructura(1).Provincia = CBProvincia.Text
                    eEmpresa_estructura(1).Ingresos_Brutos = TBIngresosBrutos.Text
                    clsResponsabilidad_IVA.Obtener_Responsabilidad_Iva_Por_Descripcion(CBResponsabilidadIVA.Text, Resp_IVA_ID)
                    eEmpresa_estructura(1).Id_Responsabilidad_IVA = Resp_IVA_ID
                    eEmpresa_estructura(1).Responsabilidad_IVA = CBResponsabilidadIVA.Text
                    eEmpresa_estructura(1).Nro_Sucursal = TBNroSucursal.Text
                    Try
                        'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + " where Nro_Sucursal='" & (TBNroSucursal.Text) & "'"
                        clsempresa.se_Cargo(TBNroSucursal.Text, existe)
                        If Not (existe) Then
                            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Empresa.ToString(), esquema)
                            clsempresa.Obtener_Clave_Principal(ClavePrincipal)
                            clsempresa.Pasar_A_Coleccion(eEmpresa_estructura, Datos_Coll, 1)
                            clsQueryBuilder.ArmaInsert(dfielddefConstantes.Empresa.ToString(), esquema, Datos_Coll, ClavePrincipal, consulta)
                            'empresa.Operaciones_Tabla(consulta)
                            Trans.Add(consulta)
                            'consulta = "select max(Id_Empresa)as Ultimo_Empresa from " + dfielddefConstantes.Empresa.ToString() + ""
                            'empresa.recuperar_Datos(consulta, datos)
                            'mayor = datos.Rows(0)("Ultimo_Empresa")
                            Dim Comprobante() As String = {"Factura A", "Nota de Debito A", "Nota de Credito A", "Recibo A", "Venta Rapida A", "Factura B", "Nota de Debito B", "Nota de Credito B", "Recibo B", "Venta Rapida B", "Factura C", "Nota de Debito C", "Nota de Credito C", "Recibo C", "Venta Rapida C", "Nota De Credito Int A", "Nota De Credito Int B", "Nota De Credito Int C"}
                            'consulta = "select max(Id_Comprobante) from " + dfielddefConstantes.Numeracion_Comprobante.ToString() + " "
                            clsNumeroComprobante.ObtenerUltimoNumeroComprobanteEmpresa(UltimoNumComprobante)
                            For i = 1 To Comprobante.Count
                                ReDim Preserve eNumeracionComprobante_estructura(i)
                                consulta = ""
                                'consulta = "select IdTipoComprobante from  " + dfielddefConstantes.Tipos_Comprobantes.ToString() + " where Descripcion = '" + UCase(Comprobante(i - 1)) + "'"
                                clsNumeroComprobante.obtener_Datos_Numero_Comprobante_Descripcion_Comprobante(Comprobante(i - 1), dtdatos)
                                Datos_Coll.Clear()
                                esquema.Clear()
                                ClavePrincipal.Clear()

                                eNumeracionComprobante_estructura(i).Id_Comprobante = UltimoNumComprobante
                                eNumeracionComprobante_estructura(i).Descripcion = Comprobante(i - 1)
                                eNumeracionComprobante_estructura(i).Numeracion = "00000000"
                                eNumeracionComprobante_estructura(i).Id_Empresa = eEmpresa_estructura(1).Id_Empresa
                                eNumeracionComprobante_estructura(i).Id_Tipo_Comprobante = dtdatos.Rows(0).Item("IdTipoComprobante")
                                clsQueryBuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
                                clsNumeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
                                clsNumeroComprobante.Pasar_A_Coleccion(eNumeracionComprobante_estructura, Datos_Coll, i)
                                clsQueryBuilder.ArmaInsert(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, Datos_Coll, ClavePrincipal, consulta)
                                Trans.Add(consulta)
                                UltimoNumComprobante = UltimoNumComprobante + 1
                            Next
                            'For i = 1 To Trans.Count
                            '    numeroComprobante.Operaciones_Tabla(Trans(i))
                            'Next
                            clsTransaccion.Operaciones_Tabla_Transaccion(Trans)
                            Trans.Clear()
                            MessageBox.Show("Los Datos de la empresa, se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                            clsempresa.Limpiar_Datos_Empresas(TBRazonSocial, TBCalle, TBPiso, TBNro, TBLocalidad, TBCodigoPostal, TBCuit1, TBCuit2, TBCuit3, TBIngresosBrutos, TBNroSucursal)
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
                If (clsempresa.Compvariable = dfielddefConstantes.Modificar_Empresa.ToString()) Then
                    If (TBRazonSocial.Text <> "" And TBLocalidad.Text <> "" And TBCuit1.Text <> "" And TBCuit2.Text <> "" And TBCuit3.Text <> "" And TBIngresosBrutos.Text <> "" And TBNroSucursal.Text <> "") Then
                        ReDim eEmpresa_estructura(1)
                        eEmpresa_estructura(1).Id_Empresa = codigo_Empresa
                        eEmpresa_estructura(1).Razon_Social = TBRazonSocial.Text
                        eEmpresa_estructura(1).Calle = TBCalle.Text
                        eEmpresa_estructura(1).Piso = TBPiso.Text
                        eEmpresa_estructura(1).Nro = TBNro.Text
                        eEmpresa_estructura(1).Localidad = TBLocalidad.Text
                        eEmpresa_estructura(1).Codigo_Postal = TBCodigoPostal.Text
                        eEmpresa_estructura(1).CUIT = TBCuit1.Text + "-" + TBCuit2.Text + "-" + TBCuit3.Text
                        eEmpresa_estructura(1).Provincia = CBProvincia.Text
                        eEmpresa_estructura(1).Ingresos_Brutos = TBIngresosBrutos.Text
                        eEmpresa_estructura(1).Responsabilidad_IVA = CBResponsabilidadIVA.Text
                        eEmpresa_estructura(1).Nro_Sucursal = TBNroSucursal.Text
                        Try
                            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Empresa.ToString(), esquema)
                            clsempresa.Obtener_Clave_Principal(ClavePrincipal)
                            clsempresa.Pasar_A_Coleccion(eEmpresa_estructura, Datos_Coll, 1)
                            clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Empresa.ToString(), esquema, Datos_Coll, ClavePrincipal, consulta)
                            clsempresa.Operaciones_Tabla(consulta)
                            MessageBox.Show("Los Datos de la empresa, se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                            clsempresa.Limpiar_Datos_Empresas(TBRazonSocial, TBCalle, TBPiso, TBNro, TBLocalidad, TBCodigoPostal, TBCuit1, TBCuit2, TBCuit3, TBIngresosBrutos, TBNroSucursal)
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
        'Dim empresa As New Controlador.clsEmpresas
        If Not (clsempresa.es_Numero(TBCodigoPostal.Text)) Then
            TBCodigoPostal.Text = ""
        End If
    End Sub
    Private Sub TBNroSucursal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNroSucursal.TextChanged
        'Dim empresa As New Controlador.clsEmpresas
        If Not (clsempresa.es_Numero(TBNroSucursal.Text)) Then
            TBNroSucursal.Text = ""
        End If
    End Sub
    Private Sub TBNro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNro.TextChanged
        'Dim empresa As New Controlador.clsEmpresas
        If Not clsempresa.es_Numero(TBNro.Text) Then
            TBNro.Text = ""
        End If
    End Sub
    Private Sub TBCuit3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCuit3.TextChanged
        'Dim empresa As New Controlador.clsEmpresas
        Dim valido As Boolean
        Try
            If Not clsempresa.es_Numero(TBCuit3.Text) Then
                TBCuit3.Text = ""
            Else
                If (TBCuit3.Text <> "") And (TBCuit2.Text <> "") And (TBCuit1.Text <> "") Then
                    clsempresa.validar_Cuit(TBCuit1.Text, TBCuit2.Text, TBCuit3.Text, valido)
                    If Not valido Then
                        MessageBox.Show("Error: El Numero de CUIT es Invalido!!!", "Informacion", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Exclamation)
                        clsempresa.Limpiar_Datos_Empresa_CUIT(TBCuit1, TBCuit2, TBCuit3)
                        TBCuit1.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim eEmpresa_estructura(0)
        ReDim eNumeracionComprobante_estructura(0)
    End Sub
    Private Sub TBCuit1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCuit1.TextChanged
        'Dim empresa As New Controlador.clsEmpresas
        If Not clsempresa.es_Numero(TBCuit1.Text) Then
            TBCuit1.Text = ""
        End If
    End Sub
    Private Sub TBCuit2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCuit2.TextChanged
        'Dim empresa As New Controlador.clsEmpresas
        If Not clsempresa.es_Numero(TBCuit2.Text) Then
            TBCuit2.Text = ""
        End If
    End Sub

    Private Sub TBNroSucursal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNroSucursal.Leave
        If IsNumeric(TBNroSucursal.Text) Then
            TBNroSucursal.Text = TBNroSucursal.Text.PadLeft(4, "0")

        End If
    End Sub
End Class