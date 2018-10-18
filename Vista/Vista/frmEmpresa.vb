Imports Controlador
Public Class frmEmpresa
    Public id_Empresa As Integer
    Public Razon_Social As String
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim Empresa_estructura(0) As Controlador.Empresas.eEmpresa
    Dim NumeracionComprobante_estructura(0) As Controlador.NumeroComprobante.eNumeracionComprobante
    Dim dfielddefEmpresa As Controlador.DfieldDef.eEmpresa
    Dim dfieldefConstantes As Controlador.DfieldDef.eConstantes
    Private Sub Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Dim empresa As New Controlador.Empresas
        Try
            'consulta = "select Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],CUIT,Ingresos_Brutos as [Ing Brutos],Responsabilidad_IVA as [Resp IVA],Nro_Sucursal as [Nro Sucursal],Provincia from " + dfieldefConstantes.Empresa.ToString() + ""
            empresa.llenar_tabla_Empresas(DGVEmpresa)
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
        Dim empresa As New Controlador.Empresas
        Dim numerocomprobante As New Controlador.NumeroComprobante
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder

        Dim result As Integer = MessageBox.Show("Desea Eliminar La Empresa: " + CStr(id_Empresa) + " " + Razon_Social, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                ReDim Empresa_estructura(1)
                Empresa_estructura(1).Id_Empresa = id_Empresa
                Empresa_estructura(1).Razon_Social = Nothing
                Empresa_estructura(1).Calle = Nothing
                Empresa_estructura(1).Piso = Nothing
                Empresa_estructura(1).Nro = Nothing
                Empresa_estructura(1).Localidad = Nothing
                Empresa_estructura(1).Codigo_Postal = Nothing
                Empresa_estructura(1).CUIT = Nothing
                Empresa_estructura(1).Provincia = Nothing
                Empresa_estructura(1).Ingresos_Brutos = Nothing
                Empresa_estructura(1).Responsabilidad_IVA = Nothing
                Empresa_estructura(1).Nro_Sucursal = Nothing
                empresa.Obtener_Clave_Principal(ClavePrincipal)
                empresa.Pasar_A_Coleccion(Empresa_estructura, datos, 1)
                querybuilder.ArmaDelete(dfieldefConstantes.Empresa.ToString(), datos, ClavePrincipal, consulta)
                empresa.Operaciones_Tabla(consulta)

                'consulta = "delete from " + dfieldefConstantes.Numeracion_Comprobante.ToString() + " where Id_Empresa='" & (id_Empresa) & "'"
                numerocomprobante.Operaciones_Tabla_NumeroComprobante(id_Empresa, dfieldefConstantes.Eliminar_Empresa.ToString())
                MessageBox.Show("La Empresa " + CStr(id_Empresa) + " " + Razon_Social + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'consulta = "select * from " + dfieldefConstantes.Empresa.ToString() + " "
                empresa.llenar_tabla_Empresas(DGVEmpresa)
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Private Sub DGVEmpresa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVEmpresa.Click
        Dim empresa As New Controlador.Empresas
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
            empresa.Descomponer_CUIT_Empresas(DGVEmpresa.CurrentRow.Cells(dfielddefEmpresa.CUIT).Value.ToString(), cuit1, cuit2, cuit3)
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
        Dim empresa As New Controlador.Empresas
        Try
            If (Nombre_Columna_a_Buscar = Replace(dfieldefConstantes.Razon_Social.ToString(), "_", " ")) Then
                Nombre_Columna_a_Buscar = "Razon_Social"
            End If
            'consulta = "select Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],CUIT,Ingresos_Brutos as [Ing Brutos],Responsabilidad_IVA as [Resp IVA],Nro_Sucursal as [Nro Sucursal],Provincia from " + dfieldefConstantes.Empresa.ToString() + "  where " + Nombre_Columna_a_Buscar + " like '" & Me.TBBusqueda.Text & "%'"
            empresa.Busqueda(DGVEmpresa, Nombre_Columna_a_Buscar, Me.TBBusqueda.Text)
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripNuevaEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNuevaEmpresa.Click
        Dim empresa As New Controlador.Empresas
        For x As Integer = ProgressBarEmpresa.Minimum To ProgressBarEmpresa.Maximum
            ProgressBarEmpresa.Value = x
        Next
        For x As Integer = ProgressBarEmpresa.Maximum To ProgressBarEmpresa.Minimum Step -1
            ProgressBarEmpresa.Value = x
        Next
        Me.Close()
        empresa.Limpiar_Datos_Empresas(frmEmpresaAlta.TBRazonSocial, frmEmpresaAlta.TBCalle, frmEmpresaAlta.TBPiso, frmEmpresaAlta.TBNro, frmEmpresaAlta.TBLocalidad, frmEmpresaAlta.TBCodigoPostal, frmEmpresaAlta.TBCuit1, frmEmpresaAlta.TBCuit2, frmEmpresaAlta.TBCuit3, frmEmpresaAlta.TBIngresosBrutos, frmEmpresaAlta.TBNroSucursal)
        frmEmpresaAlta.Show()
        empresa.Compvariable = dfieldefConstantes.Agregar_Empresa.ToString()
    End Sub
    Private Sub ToolStripModificarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModificarEmpresa.Click
        Dim empresa As New Controlador.Empresas
        For x As Integer = ProgressBarEmpresa.Minimum To ProgressBarEmpresa.Maximum
            ProgressBarEmpresa.Value = x
        Next
        For x As Integer = ProgressBarEmpresa.Maximum To ProgressBarEmpresa.Minimum Step -1
            ProgressBarEmpresa.Value = x
        Next
        Me.Close()
        frmEmpresaAlta.Show()
        empresa.Compvariable = dfieldefConstantes.Modificar_Empresa.ToString()
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim Empresa_estructura(0)
        ReDim NumeracionComprobante_estructura(0)
    End Sub
End Class