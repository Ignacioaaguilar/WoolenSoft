Imports Controlador
Public Class Proveedor
    Public id_Proveedor As Integer
    Public Razon_Social As String
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim Proveedor_estructura(0) As Controlador.ContProveedor.eProveedor
    Dim dfielddefProveedor As Controlador.DfieldDef.eProveedor
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim proveedor As New Controlador.ContProveedor()
    Private Sub ToolStripSalirProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirProveedor.Click
        Dim FactProv As New FacturacionProveedores()
        Dim NCProv As New NotaCreditoProveedores()
        Dim NDProv As New NotaDebitoProveedores()
        For x As Integer = ProgressBarProveedor.Minimum To ProgressBarProveedor.Maximum
            ProgressBarProveedor.Value = x
        Next
        For x As Integer = ProgressBarProveedor.Maximum To ProgressBarProveedor.Minimum Step -1
            ProgressBarProveedor.Value = x
        Next
        proveedor.CompCodigo = String.Empty
        proveedor.Compvariable = String.Empty
        If proveedor.CompvariableProveedores = dfielddefConstantes.FACTURAPROVEEDOR.ToString() Then
            FactProv.Show()
        End If
        If proveedor.CompvariableProveedores = dfielddefConstantes.NotaCreditoProveedor.ToString() Then
            NCProv.Show()
        End If
        If proveedor.CompvariableProveedores = dfielddefConstantes.NotaDebitoProveedor.ToString() Then
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
            If proveedor.CompvariableProveedores = dfielddefConstantes.FACTURAPROVEEDOR.ToString() Or proveedor.CompvariableProveedores = dfielddefConstantes.NotaCreditoProveedor.ToString() Or proveedor.CompvariableProveedores = dfielddefConstantes.NotaDebitoProveedor.ToString() Then
                ToolStripEnviarProveedor.Visible = True
                'consulta = "select Id_Proveedor as [Cod Proveedor],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],Provincia,Telefono,Celular,CUIT,E_Mail as [E Mail],Responsabilidad_IVA as [Resp IVA], Saldo_CC as [Saldo CC] from " + dfielddefConstantes.Proveedor.ToString() + ""
                proveedor.llenar_tabla_Proveedor(DGVProveedor)
            Else
                ToolStripEnviarProveedor.Visible = False
                'consulta = "select Id_Proveedor as [Cod Proveedor],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],Provincia,Telefono,Celular,CUIT,E_Mail as [E Mail],Responsabilidad_IVA as [Resp IVA], Saldo_CC as [Saldo CC] from " + dfielddefConstantes.Proveedor.ToString() + ""
                proveedor.llenar_tabla_Proveedor(DGVProveedor)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripEliminarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEliminarProveedor.Click
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim result As Integer = MessageBox.Show("Desea Eliminar al Proveedor: " + CStr(id_Proveedor) + " " + Razon_Social, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                ReDim Proveedor_estructura(1)
                Proveedor_estructura(1).Id_Proveedor = id_Proveedor
                Proveedor_estructura(1).Razon_Social = Nothing
                Proveedor_estructura(1).Calle = Nothing
                Proveedor_estructura(1).Piso = Nothing
                Proveedor_estructura(1).Nro = Nothing
                Proveedor_estructura(1).Localidad = Nothing
                Proveedor_estructura(1).Codigo_Postal = Nothing
                Proveedor_estructura(1).Provincia = Nothing
                Proveedor_estructura(1).Telefono = Nothing
                Proveedor_estructura(1).Celular = Nothing
                Proveedor_estructura(1).CUIT = Nothing
                Proveedor_estructura(1).E_Mail = Nothing
                Proveedor_estructura(1).Responsabilidad_IVA = Nothing
                Proveedor_estructura(1).Saldo_CC = Nothing
                proveedor.Obtener_Clave_Principal(ClavePrincipal)
                proveedor.Pasar_A_Coleccion(Proveedor_estructura, datos, 1)
                querybuilder.ArmaDelete(dfielddefConstantes.Proveedor.ToString(), datos, ClavePrincipal, consulta)
                proveedor.Operaciones_Tabla(consulta)
                MessageBox.Show("El Proveedor " + CStr(id_Proveedor) + " " + Razon_Social + " se. Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'consulta = "select Id_Proveedor as [Cod Proveedor],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],Provincia,Telefono,Celular,CUIT,E_Mail as [E Mail],Responsabilidad_IVA as [Resp IVA], Saldo_CC as [Saldo CC] from " + dfielddefConstantes.Proveedor.ToString() + ""
                proveedor.llenar_tabla_Proveedor(DGVProveedor)
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
            proveedor.CompCodigo = Convert.ToString(id_Proveedor)
            ProveedorAlta.codigo_Proveedor = Convert.ToString(id_Proveedor)
            ProveedorAlta.TBRazonSocial.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Razon_Social).Value.ToString()
            ProveedorAlta.TBCalle.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Calle).Value.ToString()
            ProveedorAlta.TBPiso.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Piso).Value.ToString()
            ProveedorAlta.TBNumero.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Nro).Value.ToString()
            ProveedorAlta.TBLocalidad.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Localidad).Value.ToString()
            ProveedorAlta.TBCodigoPostal.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Codigo_Postal).Value.ToString()
            proveedor.Descomponer_CUIT_Proveedor(DGVProveedor.CurrentRow.Cells(dfielddefProveedor.CUIT).Value.ToString(), cuit1, cuit2, cuit3)
            ProveedorAlta.TBCuitProveedor1.Text = cuit1
            ProveedorAlta.TBCuitProveedor2.Text = cuit2
            ProveedorAlta.TBCuitProveedor3.Text = cuit3
            ProveedorAlta.CBProvincia.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Provincia).Value.ToString()
            ProveedorAlta.TBTelefono.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Telefono).Value.ToString()
            ProveedorAlta.TBCelular.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Celular).Value.ToString()
            ProveedorAlta.TBEmail.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.E_Mail).Value.ToString()
            ProveedorAlta.CBResponsabilidadIVA.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Responsabilidad_IVA).Value.ToString()
            ProveedorAlta.TBSaldoCorriente.Text = DGVProveedor.CurrentRow.Cells(dfielddefProveedor.Saldo_CC).Value.ToString()

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
        Dim ContProveedor As New Controlador.ContProveedor
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
            proveedor.Busqueda(DGVProveedor, Nombre_Columna_a_Buscar, Me.TBBusqueda.Text)
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
        ProveedorAlta.Show()
        proveedor.Compvariable = dfielddefConstantes.Agregar_Proveedor.ToString()
    End Sub
    Private Sub ToolStripModificarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModificarProveedor.Click
        For x As Integer = ProgressBarProveedor.Minimum To ProgressBarProveedor.Maximum
            ProgressBarProveedor.Value = x
        Next
        For x As Integer = ProgressBarProveedor.Maximum To ProgressBarProveedor.Minimum Step -1
            ProgressBarProveedor.Value = x
        Next
        Me.Close()
        ProveedorAlta.Show()
        proveedor.Compvariable = dfielddefConstantes.Modificar_Proveedor.ToString()
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim Proveedor_estructura(0)
    End Sub
    Private Sub ToolStripEnviarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEnviarProveedor.Click
        Dim FactProv As New FacturacionProveedores()
        Dim NCProv As New NotaCreditoProveedores()
        Dim NDProv As New NotaDebitoProveedores()
        Dim proveedor As New Controlador.ContProveedor()
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
                    FacturacionProveedores.txtCodigoProveedor.Text = Nothing
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
                    NotaCreditoProveedores.txtCodigoProveedor.Text = Nothing
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
                    NotaDebitoProveedores.txtCodigoProveedor.Text = Nothing
                End If
            End If
        End If
        Me.Close()
    End Sub
End Class