Imports Controlador
Public Class frmEmpresa
    Public id_Empresa As Integer
    Public Razon_Social As String
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim eEmpresa_estructura(0) As Controlador.clsEmpresas.eEmpresa
    Dim eNumeracionComprobante_estructura(0) As Controlador.clsNumeroComprobante.eNumeracionComprobante
    Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Dim dfieldefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsempresa As New Controlador.clsEmpresas
    Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Private Sub Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        'Dim empresa As New Controlador.clsEmpresas
        Try
            'consulta = "select Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],CUIT,Ingresos_Brutos as [Ing Brutos],Responsabilidad_IVA as [Resp IVA],Nro_Sucursal as [Nro Sucursal],Provincia from " + dfieldefConstantes.Empresa.ToString() + ""
            clsempresa.llenar_tabla_Empresas(DGVEmpresa)
            ToolStripNuevaEmpresa.Enabled = True
            ToolStripModificarEmpresa.Enabled = False
            ToolStripEliminarEmpresa.Enabled = False
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripSalirEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirEmpresa.Click
        For x As Integer = ProgressBarEmpresa.Minimum To ProgressBarEmpresa.Maximum
            ProgressBarEmpresa.Value = x
        Next
        For x As Integer = ProgressBarEmpresa.Maximum To ProgressBarEmpresa.Minimum Step -1
            ProgressBarEmpresa.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub ToolStripEliminarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEliminarEmpresa.Click
        'Dim empresa As New Controlador.clsEmpresas
        'Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder

        Dim result As Integer = MessageBox.Show("Desea Eliminar La Empresa: " + CStr(id_Empresa) + " " + Razon_Social, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                ReDim eEmpresa_estructura(1)
                eEmpresa_estructura(1).Id_Empresa = id_Empresa
                eEmpresa_estructura(1).Razon_Social = Nothing
                eEmpresa_estructura(1).Calle = Nothing
                eEmpresa_estructura(1).Piso = Nothing
                eEmpresa_estructura(1).Nro = Nothing
                eEmpresa_estructura(1).Localidad = Nothing
                eEmpresa_estructura(1).Codigo_Postal = Nothing
                eEmpresa_estructura(1).CUIT = Nothing
                eEmpresa_estructura(1).Provincia = Nothing
                eEmpresa_estructura(1).Ingresos_Brutos = Nothing
                eEmpresa_estructura(1).Responsabilidad_IVA = Nothing
                eEmpresa_estructura(1).Nro_Sucursal = Nothing
                clsempresa.Obtener_Clave_Principal(ClavePrincipal)
                clsempresa.Pasar_A_Coleccion(eEmpresa_estructura, datos, 1)
                clsQueryBuilder.ArmaDelete(dfieldefConstantes.Empresa.ToString(), datos, ClavePrincipal, consulta)
                clsempresa.Operaciones_Tabla(consulta)

                'consulta = "delete from " + dfieldefConstantes.Numeracion_Comprobante.ToString() + " where Id_Empresa='" & (id_Empresa) & "'"
                clsNumeroComprobante.Operaciones_Tabla_NumeroComprobante(id_Empresa, dfieldefConstantes.Eliminar_Empresa.ToString())
                MessageBox.Show("La Empresa " + CStr(id_Empresa) + " " + Razon_Social + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'consulta = "select * from " + dfieldefConstantes.Empresa.ToString() + " "
                clsempresa.llenar_tabla_Empresas(DGVEmpresa)
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Private Sub DGVEmpresa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVEmpresa.Click
        'Dim empresa As New Controlador.clsEmpresas
        Dim cuit1, cuit2, cuit3 As String
        Try
            ToolStripNuevaEmpresa.Enabled = False
            ToolStripModificarEmpresa.Enabled = True
            ToolStripEliminarEmpresa.Enabled = True
            id_Empresa = CInt(DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Id_Empresa).Value.ToString())
            Razon_Social = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Razon_Social).Value.ToString()
            frmEmpresaAlta.codigo_Empresa = id_Empresa
            frmEmpresaAlta.TBRazonSocial.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Razon_Social).Value.ToString()
            frmEmpresaAlta.TBCalle.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Calle).Value.ToString()
            frmEmpresaAlta.TBPiso.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Piso).Value.ToString()
            frmEmpresaAlta.TBNro.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Nro).Value.ToString()
            frmEmpresaAlta.TBLocalidad.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Localidad).Value.ToString()
            frmEmpresaAlta.TBCodigoPostal.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Codigo_Postal).Value.ToString()
            clsempresa.Descomponer_CUIT_Empresas(DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.CUIT).Value.ToString(), cuit1, cuit2, cuit3)
            frmEmpresaAlta.TBCuit1.Text = cuit1
            frmEmpresaAlta.TBCuit2.Text = cuit2
            frmEmpresaAlta.TBCuit3.Text = cuit3

            frmEmpresaAlta.TBIngresosBrutos.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Ingresos_Brutos).Value.ToString()
            frmEmpresaAlta.CBResponsabilidadIVA.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Responsabilidad_IVA).Value.ToString()
            frmEmpresaAlta.TBNroSucursal.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Nro_Sucursal).Value.ToString()
            frmEmpresaAlta.CBProvincia.Text = DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.Provincia).Value.ToString()

            Posicion_Columna = DGVEmpresa.CurrentCell.ColumnIndex
            Nombre_Columna_a_Buscar = DGVEmpresa.Columns(Posicion_Columna).Name

            If (Nombre_Columna_a_Buscar = Replace(dfieldefConstantes.Razon_Social.ToString(), "_", " ")) Then
                Me.Label2.Text = "Razon Social:"
            Else
                If (Nombre_Columna_a_Buscar = dfieldefConstantes.Calle.ToString()) Then
                    Me.Label2.Text = "Calle:"
                Else
                    If (Nombre_Columna_a_Buscar = dfieldefConstantes.Piso.ToString()) Then
                        Me.Label2.Text = "Piso:"
                    Else
                        If (Nombre_Columna_a_Buscar = dfieldefConstantes.CUIT.ToString()) Then
                            Me.Label2.Text = "CUIT:"
                        Else
                            If (Nombre_Columna_a_Buscar = dfieldefConstantes.Provincia.ToString()) Then
                                Me.Label2.Text = "Provincia:"
                            Else
                                If (Nombre_Columna_a_Buscar = dfieldefConstantes.Telefono.ToString()) Then
                                    Me.Label2.Text = "Telefono:"
                                Else
                                    If (Nombre_Columna_a_Buscar = dfieldefConstantes.Celular.ToString()) Then
                                        Me.Label2.Text = "Celular:"
                                    Else
                                        If (Nombre_Columna_a_Buscar = Replace(dfieldefConstantes.E_Mail.ToString(), "_", " ")) Then
                                            Me.Label2.Text = "E_Mail:"
                                        Else
                                            If (Nombre_Columna_a_Buscar = Replace(dfieldefConstantes.Codigo_Postal.ToString(), "_", " ")) Then
                                                Me.Label2.Text = "Codigo_Postal:"
                                            Else
                                                If (Nombre_Columna_a_Buscar = Replace(dfieldefConstantes.Responsabilidad_IVA.ToString(), "_", " ")) Then
                                                    Me.Label2.Text = "Responsabilidad_IVA:"
                                                Else
                                                    If (Nombre_Columna_a_Buscar = dfieldefConstantes.Localidad.ToString()) Then
                                                        Me.Label2.Text = "Localidad:"
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBBusqueda.TextChanged
        Dim consulta As String
        'Dim empresa As New Controlador.clsEmpresas
        Try
            If (Nombre_Columna_a_Buscar = Replace(dfieldefConstantes.Razon_Social.ToString(), "_", " ")) Then
                Nombre_Columna_a_Buscar = "Razon_Social"
            End If
            'consulta = "select Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],CUIT,Ingresos_Brutos as [Ing Brutos],Responsabilidad_IVA as [Resp IVA],Nro_Sucursal as [Nro Sucursal],Provincia from " + dfieldefConstantes.Empresa.ToString() + "  where " + Nombre_Columna_a_Buscar + " like '" & Me.TBBusqueda.Text & "%'"
            clsempresa.Busqueda(DGVEmpresa, Nombre_Columna_a_Buscar, Me.TBBusqueda.Text)
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripNuevaEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNuevaEmpresa.Click
        'Dim empresa As New Controlador.clsEmpresas
        For x As Integer = ProgressBarEmpresa.Minimum To ProgressBarEmpresa.Maximum
            ProgressBarEmpresa.Value = x
        Next
        For x As Integer = ProgressBarEmpresa.Maximum To ProgressBarEmpresa.Minimum Step -1
            ProgressBarEmpresa.Value = x
        Next
        Me.Close()
        clsempresa.Limpiar_Datos_Empresas(frmEmpresaAlta.TBRazonSocial, frmEmpresaAlta.TBCalle, frmEmpresaAlta.TBPiso, frmEmpresaAlta.TBNro, frmEmpresaAlta.TBLocalidad, frmEmpresaAlta.TBCodigoPostal, frmEmpresaAlta.TBCuit1, frmEmpresaAlta.TBCuit2, frmEmpresaAlta.TBCuit3, frmEmpresaAlta.TBIngresosBrutos, frmEmpresaAlta.TBNroSucursal)
        frmEmpresaAlta.Show()
        clsempresa.Compvariable = dfieldefConstantes.Agregar_Empresa.ToString()
    End Sub
    Private Sub ToolStripModificarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModificarEmpresa.Click
        'Dim empresa As New Controlador.clsEmpresas
        For x As Integer = ProgressBarEmpresa.Minimum To ProgressBarEmpresa.Maximum
            ProgressBarEmpresa.Value = x
        Next
        For x As Integer = ProgressBarEmpresa.Maximum To ProgressBarEmpresa.Minimum Step -1
            ProgressBarEmpresa.Value = x
        Next
        Me.Close()
        frmEmpresaAlta.Show()
        clsempresa.Compvariable = dfieldefConstantes.Modificar_Empresa.ToString()
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim eEmpresa_estructura(0)
        ReDim eNumeracionComprobante_estructura(0)
    End Sub
End Class