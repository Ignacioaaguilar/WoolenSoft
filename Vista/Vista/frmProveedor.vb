Imports Controlador
Public Class frmProveedor
    Dim id_Proveedor As Integer
    Dim Razon_Social As String
    Dim Posicion_Columna As Integer
    Dim Nombre_Columna_a_Buscar As String
    Dim eProveedor_estructura(0) As Controlador.clsContProveedor.eProveedor
    Dim dfielddefProveedor As Controlador.clsDfieldDef.eProveedor
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsproveedor As New Controlador.clsContProveedor()
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim clsContProveedor As New Controlador.clsContProveedor
    Private Sub ToolStripSalirProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirProveedor.Click
        Dim FactProv As New frmFacturacionProveedores()
        Dim NCProv As New frmNotaCreditoProveedores()
        Dim NDProv As New frmNotaDebitoProveedores()
        For x As Integer = ProgressBarProveedor.Minimum To ProgressBarProveedor.Maximum
            ProgressBarProveedor.Value = x
        Next
        For x As Integer = ProgressBarProveedor.Maximum To ProgressBarProveedor.Minimum Step -1
            ProgressBarProveedor.Value = x
        Next
        clsproveedor.CompCodigo = String.Empty
        clsproveedor.Compvariable = String.Empty
        If clsproveedor.CompvariableProveedores = dfielddefConstantes.FACTURAPROVEEDOR.ToString() Then
            FactProv.Show()
        End If
        If clsproveedor.CompvariableProveedores = dfielddefConstantes.NotaCreditoProveedor.ToString() Then
            NCProv.Show()
        End If
        If clsproveedor.CompvariableProveedores = dfielddefConstantes.NotaDebitoProveedor.ToString() Then
            NDProv.Show()
        End If
        Me.Close()
    End Sub
    Private Sub Proveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Try
            ToolStripNuevoProveedor.Enabled = True
            ToolStripModificarProveedor.Enabled = False
            ToolStripEliminarProveedor.Enabled = False
            If clsproveedor.CompvariableProveedores = dfielddefConstantes.FACTURAPROVEEDOR.ToString() Or clsproveedor.CompvariableProveedores = dfielddefConstantes.NotaCreditoProveedor.ToString() Or clsproveedor.CompvariableProveedores = dfielddefConstantes.NotaDebitoProveedor.ToString() Then
                ToolStripEnviarProveedor.Visible = True
                'consulta = "select Id_Proveedor as [Cod Proveedor],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],Provincia,Telefono,Celular,CUIT,E_Mail as [E Mail],Responsabilidad_IVA as [Resp IVA], Saldo_CC as [Saldo CC] from " + dfielddefConstantes.Proveedor.ToString() + ""
                clsproveedor.llenar_tabla_Proveedor(DGVProveedor)
            Else
                ToolStripEnviarProveedor.Visible = False
                'consulta = "select Id_Proveedor as [Cod Proveedor],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],Provincia,Telefono,Celular,CUIT,E_Mail as [E Mail],Responsabilidad_IVA as [Resp IVA], Saldo_CC as [Saldo CC] from " + dfielddefConstantes.Proveedor.ToString() + ""
                clsproveedor.llenar_tabla_Proveedor(DGVProveedor)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripEliminarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEliminarProveedor.Click
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim result As Integer = MessageBox.Show("Desea Eliminar al Proveedor: " + CStr(id_Proveedor) + " " + Razon_Social, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                ReDim eProveedor_estructura(1)
                eProveedor_estructura(1).Id_Proveedor = id_Proveedor
                eProveedor_estructura(1).Razon_Social = Nothing
                eProveedor_estructura(1).Calle = Nothing
                eProveedor_estructura(1).Piso = Nothing
                eProveedor_estructura(1).Nro = Nothing
                eProveedor_estructura(1).Localidad = Nothing
                eProveedor_estructura(1).Codigo_Postal = Nothing
                eProveedor_estructura(1).Provincia = Nothing
                eProveedor_estructura(1).Telefono = Nothing
                eProveedor_estructura(1).Celular = Nothing
                eProveedor_estructura(1).CUIT = Nothing
                eProveedor_estructura(1).E_Mail = Nothing
                eProveedor_estructura(1).Responsabilidad_IVA = Nothing
                eProveedor_estructura(1).Saldo_CC = Nothing
                clsproveedor.Obtener_Clave_Principal(ClavePrincipal)
                clsproveedor.Pasar_A_Coleccion(eProveedor_estructura, datos, 1)
                clsQueryBuilder.ArmaDelete(dfielddefConstantes.Proveedor.ToString(), datos, ClavePrincipal, consulta)
                clsproveedor.Operaciones_Tabla(consulta)
                MessageBox.Show("El Proveedor " + CStr(id_Proveedor) + " " + Razon_Social + " se. Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'consulta = "select Id_Proveedor as [Cod Proveedor],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],Provincia,Telefono,Celular,CUIT,E_Mail as [E Mail],Responsabilidad_IVA as [Resp IVA], Saldo_CC as [Saldo CC] from " + dfielddefConstantes.Proveedor.ToString() + ""
                clsproveedor.llenar_tabla_Proveedor(DGVProveedor)
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Private Sub DGVProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVProveedor.Click
        Dim cuit1, cuit2, cuit3 As String
        Try
            ToolStripNuevoProveedor.Enabled = False
            ToolStripModificarProveedor.Enabled = True
            ToolStripEliminarProveedor.Enabled = True
            id_Proveedor = CInt(DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Id_Proveedor).Value.ToString())
            Razon_Social = DGVProveedor.CurrentRow.Cells(1).Value.ToString()
            clsproveedor.CompCodigo = Convert.ToString(id_Proveedor)
            frmProveedorAlta.codigo_Proveedor = Convert.ToString(id_Proveedor)
            frmProveedorAlta.TBRazonSocial.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Razon_Social).Value.ToString()
            frmProveedorAlta.TBCalle.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Calle).Value.ToString()
            frmProveedorAlta.TBPiso.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Piso).Value.ToString()
            frmProveedorAlta.TBNumero.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Nro).Value.ToString()
            frmProveedorAlta.TBLocalidad.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Localidad).Value.ToString()
            frmProveedorAlta.TBCodigoPostal.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Codigo_Postal).Value.ToString()
            clsproveedor.Descomponer_CUIT_Proveedor(DGVProveedor.CurrentRow.Cells(dfielddefProveedor.CUIT).Value.ToString(), cuit1, cuit2, cuit3)
            frmProveedorAlta.TBCuitProveedor1.Text = cuit1
            frmProveedorAlta.TBCuitProveedor2.Text = cuit2
            frmProveedorAlta.TBCuitProveedor3.Text = cuit3
            frmProveedorAlta.CBProvincia.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Provincia).Value.ToString()
            frmProveedorAlta.TBTelefono.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Telefono).Value.ToString()
            frmProveedorAlta.TBCelular.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Celular).Value.ToString()
            frmProveedorAlta.TBEmail.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.E_Mail).Value.ToString()
            frmProveedorAlta.CBResponsabilidadIVA.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Responsabilidad_IVA).Value.ToString()
            frmProveedorAlta.TBSaldoCorriente.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Saldo_CC).Value.ToString()

            Posicion_Columna = DGVProveedor.CurrentCell.ColumnIndex
            Nombre_Columna_a_Buscar = DGVProveedor.Columns(Posicion_Columna).Name
            If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Razon_Social.ToString(), "_", " ")) Then
                Me.Label2.Text = "Razon Social:"
            Else
                If (Nombre_Columna_a_Buscar = dfielddefConstantes.Calle.ToString()) Then
                    Me.Label2.Text = "Calle:"
                Else
                    If (Nombre_Columna_a_Buscar = dfielddefConstantes.Piso.ToString()) Then
                        Me.Label2.Text = "Piso:"
                    Else
                        If (Nombre_Columna_a_Buscar = dfielddefConstantes.Localidad.ToString()) Then
                            Me.Label2.Text = "Localidad:"
                        Else
                            If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Codigo_Postal.ToString(), "_", " ")) Then
                                Me.Label2.Text = "Codigo Postal:"
                            Else
                                If (Nombre_Columna_a_Buscar = dfielddefConstantes.CUIT.ToString()) Then
                                    Me.Label2.Text = "CUIT:"
                                Else
                                    If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Responsabilidad_IVA.ToString(), "_", " ")) Then
                                        Me.Label2.Text = "Responsbilidad IVA:"
                                    Else
                                        If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.E_Mail.ToString(), "_", " ")) Then
                                            Me.Label2.Text = "E-Mail:"
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
        'Dim clsContProveedor As New Controlador.clsContProveedor
        Try
            If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Razon_Social.ToString(), "_", " ")) Then
                Nombre_Columna_a_Buscar = "Razon_Social"
            Else
                If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Codigo_Postal.ToString(), "_", " ")) Then
                    Nombre_Columna_a_Buscar = "Codigo_Postal"
                Else
                    If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.E_Mail.ToString(), "_", " ")) Then
                        Nombre_Columna_a_Buscar = "E_Mail"
                    End If
                End If
            End If
            'consulta = "select Id_Proveedor as [Cod Proveedor],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],Provincia,Telefono,Celular,CUIT,E_Mail as [E Mail],Responsabilidad_IVA as [Resp IVA], Saldo_CC as [Saldo CC] from " + dfielddefConstantes.Proveedor.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.TBBusqueda.Text & "%'"
            clsproveedor.Busqueda(DGVProveedor, Nombre_Columna_a_Buscar, Me.TBBusqueda.Text)
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripNuevoProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNuevoProveedor.Click
        For x As Integer = ProgressBarProveedor.Minimum To ProgressBarProveedor.Maximum
            ProgressBarProveedor.Value = x
        Next
        For x As Integer = ProgressBarProveedor.Maximum To ProgressBarProveedor.Minimum Step -1
            ProgressBarProveedor.Value = x
        Next
        Me.Close()
        frmProveedorAlta.Show()
        clsproveedor.Compvariable = dfielddefConstantes.Agregar_Proveedor.ToString()
    End Sub
    Private Sub ToolStripModificarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModificarProveedor.Click
        For x As Integer = ProgressBarProveedor.Minimum To ProgressBarProveedor.Maximum
            ProgressBarProveedor.Value = x
        Next
        For x As Integer = ProgressBarProveedor.Maximum To ProgressBarProveedor.Minimum Step -1
            ProgressBarProveedor.Value = x
        Next
        Me.Close()
        frmProveedorAlta.Show()
        clsproveedor.Compvariable = dfielddefConstantes.Modificar_Proveedor.ToString()
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim eProveedor_estructura(0)
    End Sub
    Private Sub ToolStripEnviarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEnviarProveedor.Click
        Dim FactProv As New frmFacturacionProveedores()
        Dim NCProv As New frmNotaCreditoProveedores()
        Dim NDProv As New frmNotaDebitoProveedores()
        Dim proveedor As New Controlador.clsContProveedor()
        For x As Integer = ProgressBarProveedor.Minimum To ProgressBarProveedor.Maximum
            ProgressBarProveedor.Value = x
        Next
        For x As Integer = ProgressBarProveedor.Maximum To ProgressBarProveedor.Minimum Step -1
            ProgressBarProveedor.Value = x
        Next
        If proveedor.CompvariableProveedores = dfielddefConstantes.FACTURAPROVEEDOR.ToString() Then
            If (proveedor.CompCodigo <> Nothing) Then
                proveedor.CompCodigo = proveedor.CompCodigo.ToString()
                FactProv.txtCodigoProveedor.Text = proveedor.CompCodigo.ToString()
                FactProv.Show()
            Else
                If (proveedor.CompCodigo = Nothing) Then
                    frmFacturacionProveedores.txtCodigoProveedor.Text = Nothing
                End If
            End If
        End If
        If proveedor.CompvariableProveedores = dfielddefConstantes.NotaCreditoProveedor.ToString() Then
            If (proveedor.CompCodigo <> Nothing) Then
                proveedor.CompCodigo = proveedor.CompCodigo.ToString()
                NCProv.txtCodigoProveedor.Text = proveedor.CompCodigo.ToString()
                NCProv.Show()
            Else
                If (proveedor.CompCodigo = Nothing) Then
                    frmNotaCreditoProveedores.txtCodigoProveedor.Text = Nothing
                End If
            End If
        End If
        If proveedor.CompvariableProveedores = dfielddefConstantes.NotaDebitoProveedor.ToString() Then
            If (proveedor.CompCodigo <> Nothing) Then
                proveedor.CompCodigo = proveedor.CompCodigo.ToString()
                NDProv.txtCodigoProveedor.Text = proveedor.CompCodigo.ToString()
                NDProv.Show()
            Else
                If (proveedor.CompCodigo = Nothing) Then
                    frmNotaDebitoProveedores.txtCodigoProveedor.Text = Nothing
                End If
            End If
        End If
        Me.Close()
    End Sub
End Class