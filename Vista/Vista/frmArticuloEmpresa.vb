Public Class frmArticuloEmpresa

#Region "Declaration"
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim ArticuloEmpresaArticulos_estructura(0) As Controlador.clsArticulos.eArticuloEmpresa
    Dim clsEmpresa As New Controlador.clsEmpresas
    Dim clsarticulo As New Controlador.clsArticulos
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
#End Region


#Region "Constructor"
    Private Sub ArticuloEmpresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim Empresa As New Controlador.clsEmpresas
        Dim consulta As String
        Dim dtdatos As New DataTable
        'Dim articulo As New Controlador.clsArticulos
        Try
            If (clsarticulo.Compvariable_Articulo = dfielddefConstantes.AgregarArticuloEmpresa.ToString()) Then
                'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa='" & (cbCodEmpresa.Text) & "' "
                'Empresa.Obtener_Empresa(consulta, datos)
                clsEmpresa.Obtener_Empresa(cbCodEmpresa.Text, dtdatos)
                If dtdatos.Rows.Count > 0 Then
                    Dim item As New ListViewItem(dtdatos.Rows(0).Item("Razon_Social").ToString())
                    item.SubItems.Add(dtdatos.Rows(0).Item("Nro_Sucursal").ToString())
                    item.SubItems.Add(dtdatos.Rows(0).Item("Calle").ToString())
                    item.SubItems.Add(dtdatos.Rows(0).Item("Nro").ToString())
                    lwDatosEmpresa.Items.Add(item)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "Event Form"
    Private Sub cbCodEmpresa_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCodEmpresa.SelectedValueChanged
        'Dim Empresa As New Controlador.clsEmpresas
        Dim consulta As String
        Dim dtdatos As New DataTable
        'Dim articulo As New Controlador.clsArticulos
        Try
            If (clsarticulo.Compvariable_Articulo = dfielddefConstantes.AgregarArticuloEmpresa.ToString()) Then
                'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa='" & (cbCodEmpresa.Text) & "' "
                clsEmpresa.Obtener_Empresa(cbCodEmpresa.Text, dtdatos)
                If dtdatos.Rows.Count > 0 Then
                    lwDatosEmpresa.Items.Clear()
                    Dim item As New ListViewItem(dtdatos.Rows(0).Item("Razon_Social").ToString())
                    item.SubItems.Add(dtdatos.Rows(0).Item("Nro_Sucursal").ToString())
                    item.SubItems.Add(dtdatos.Rows(0).Item("Calle").ToString())
                    item.SubItems.Add(dtdatos.Rows(0).Item("Nro").ToString())
                    lwDatosEmpresa.Items.Add(item)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSalir.Click
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub ToolStripButtonRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonRegistrar.Click
        'Dim articulo As New Controlador.clsArticulos
        Dim consulta As String
        Dim existe As Boolean
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim UltimaFila As Integer
        Try
            For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
                ToolStripProgressBar.Value = x
            Next
            For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
                ToolStripProgressBar.Value = x
            Next
            'consulta = "select * from  " + dfielddefConstantes.EmpresaArticulo.ToString() + " where Id_Articulo='" & (tbCodProducto.Text) & "' and Id_Empresa ='" & (cbCodEmpresa.Text) & "'"
            clsarticulo.se_CargoEmpresaArticulo(tbCodProducto.Text, cbCodEmpresa.Text, existe)
            If Not (existe) Then
                ReDim ArticuloEmpresaArticulos_estructura(1)
                ArticuloEmpresaArticulos_estructura(1).Id_Articulo = tbCodProducto.Text
                ArticuloEmpresaArticulos_estructura(1).Id_Empresa = cbCodEmpresa.Text
                consulta = String.Empty
                clsQueryBuilder.obtener_estructura(dfielddefConstantes.EmpresaArticulo.ToString(), esquema)
                clsarticulo.Obtener_Clave_PrincipalArticuloEmpresa(ClavePrincipal)
                clsarticulo.Pasar_A_ColeccionArticuloEmpresa(ArticuloEmpresaArticulos_estructura, datos, 1)
                clsQueryBuilder.ArmaInsert(dfielddefConstantes.EmpresaArticulo.ToString(), esquema, datos, ClavePrincipal, consulta)
                clsarticulo.Operaciones_Tabla(consulta)

                'consulta = " Select Id_Articulo as [Cod Articulo],EA.Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as[Codigo Postal],CUIT " & vbCrLf
                'consulta += " from EmpresaArticulo as EA" & vbCrLf
                'consulta += " inner join Empresa  as E on   E.Id_Empresa=EA.Id_Empresa " & vbCrLf
                'consulta += " where Id_Articulo='" & (tbCodProducto.Text) & "'  "

                clsarticulo.llenar_tabla_Empresa_Articulo(tbCodProducto.Text, frmArticulosAltas.DGVEmpresaArticulos)
                MessageBox.Show("El Articulo, se Agrego Correctamente a la Empresa!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                LimpiarEstructuras()
                esquema.Clear()
                datos.Clear()
                consulta = String.Empty
            Else
                MessageBox.Show("El Articulo ya se ha agregado a la Empresa!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region
#Region "Private Methods"
    Private Sub LimpiarEstructuras()
        ReDim ArticuloEmpresaArticulos_estructura(0)
    End Sub
#End Region
End Class