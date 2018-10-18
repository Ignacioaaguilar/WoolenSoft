Public Class ArticuloEmpresa

#Region "Declaration"
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim ArticuloEmpresaArticulos_estructura(0) As Controlador.Articulos.eArticuloEmpresa
#End Region


#Region "Constructor"
    Private Sub ArticuloEmpresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Empresa As New Controlador.Empresas
        Dim consulta As String
        Dim datos As New DataTable
        Dim articulo As New Controlador.Articulos
        Try
            If (articulo.Compvariable_Articulo = dfielddefConstantes.AgregarArticuloEmpresa.ToString()) Then
                'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa='" & (cbCodEmpresa.Text) & "' "
                'Empresa.Obtener_Empresa(consulta, datos)
                Empresa.Obtener_Empresa(cbCodEmpresa.Text, datos)
                If datos.Rows.Count > 0 Then
                    Dim item As New ListViewItem(datos.Rows(0).Item("Razon_Social").ToString())
                    item.SubItems.Add(datos.Rows(0).Item("Nro_Sucursal").ToString())
                    item.SubItems.Add(datos.Rows(0).Item("Calle").ToString())
                    item.SubItems.Add(datos.Rows(0).Item("Nro").ToString())
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
        Dim Empresa As New Controlador.Empresas
        Dim consulta As String
        Dim datos As New DataTable
        Dim articulo As New Controlador.Articulos
        Try
            If (articulo.Compvariable_Articulo = dfielddefConstantes.AgregarArticuloEmpresa.ToString()) Then
                'consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa='" & (cbCodEmpresa.Text) & "' "
                Empresa.Obtener_Empresa(cbCodEmpresa.Text, datos)
                If datos.Rows.Count > 0 Then
                    lwDatosEmpresa.Items.Clear()
                    Dim item As New ListViewItem(datos.Rows(0).Item("Razon_Social").ToString())
                    item.SubItems.Add(datos.Rows(0).Item("Nro_Sucursal").ToString())
                    item.SubItems.Add(datos.Rows(0).Item("Calle").ToString())
                    item.SubItems.Add(datos.Rows(0).Item("Nro").ToString())
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
        Dim articulo As New Controlador.Articulos
        Dim consulta As String
        Dim existe As Boolean
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
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
            articulo.se_CargoEmpresaArticulo(tbCodProducto.Text, cbCodEmpresa.Text, existe)
            If Not (existe) Then
                ReDim ArticuloEmpresaArticulos_estructura(1)
                ArticuloEmpresaArticulos_estructura(1).Id_Articulo = tbCodProducto.Text
                ArticuloEmpresaArticulos_estructura(1).Id_Empresa = cbCodEmpresa.Text
                consulta = String.Empty
                querybuilder.obtener_estructura(dfielddefConstantes.EmpresaArticulo.ToString(), esquema)
                articulo.Obtener_Clave_PrincipalArticuloEmpresa(ClavePrincipal)
                articulo.Pasar_A_ColeccionArticuloEmpresa(ArticuloEmpresaArticulos_estructura, datos, 1)
                querybuilder.ArmaInsert(dfielddefConstantes.EmpresaArticulo.ToString(), esquema, datos, ClavePrincipal, consulta)
                articulo.Operaciones_Tabla(consulta)

                'consulta = " Select Id_Articulo as [Cod Articulo],EA.Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as[Codigo Postal],CUIT " & vbCrLf
                'consulta += " from EmpresaArticulo as EA" & vbCrLf
                'consulta += " inner join Empresa  as E on   E.Id_Empresa=EA.Id_Empresa " & vbCrLf
                'consulta += " where Id_Articulo='" & (tbCodProducto.Text) & "'  "

                articulo.llenar_tabla_Empresa_Articulo(tbCodProducto.Text, ArticulosAltas.DGVEmpresaArticulos)
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