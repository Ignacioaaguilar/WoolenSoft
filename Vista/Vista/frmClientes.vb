Imports Controlador
Imports DevComponents.DotNetBar
Public Class frmClientes
    Public id_Clientes As Integer
    Public Nombre As String
    Public Apellido As String
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim Cliente_estructura(0) As Controlador.clsCliente.eCliente
    Dim dfielddefCliente As Controlador.clsDfieldDef.eCliente
    Dim dfielddefconstante As Controlador.clsDfieldDef.eConstantes
    Dim clsCliente As New Controlador.clsCliente()
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim clsFacturacion As New Controlador.clsFacturacion()
    Dim clsGenerales As New Controlador.clsGenerales
    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Try
            ToolStripNuevoCliente.Enabled = True
            ToolStripModificarCliente.Enabled = False
            ToolStripEliminarCliente.Enabled = False
            Me.DoubleBuffered = True
            If clsCliente.Compvariable = dfielddefconstante.FACTURA.ToString() Or clsCliente.Compvariable = dfielddefconstante.NotaCredito.ToString() Or clsCliente.Compvariable = dfielddefconstante.NotaDebito.ToString() Then
                ToolStripEnviarCliente.Visible = True
                clsCliente.llenar_tabla_cliente(dgvClientes, False)
            Else
                ToolStripEnviarCliente.Visible = False
                clsCliente.llenar_tabla_cliente(dgvClientes)
            End If

        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripSalirCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirCliente.Click
        For x As Integer = pogressbarClientes.Minimum To pogressbarClientes.Maximum
            pogressbarClientes.Value = x
        Next
        For x As Integer = pogressbarClientes.Maximum To pogressbarClientes.Minimum Step -1
            pogressbarClientes.Value = x
        Next
        clsCliente.Compvariable = String.Empty
        clsCliente.CompCodigo = String.Empty
        Me.Close()
    End Sub
    Private Sub ToolStripNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNuevoCliente.Click
        For x As Integer = pogressbarClientes.Minimum To pogressbarClientes.Maximum
            pogressbarClientes.Value = x
        Next
        For x As Integer = pogressbarClientes.Maximum To pogressbarClientes.Minimum Step -1
            pogressbarClientes.Value = x
        Next
        Me.Close()
        frmClientesAltas.Show()
        clsCliente.Compvariable = dfielddefconstante.Agregar_Cliente.ToString()
    End Sub
    Private Sub dgvClientes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvClientes.Click
        Dim cuit1, cuit2, cuit3 As String
        Try
            Me.DoubleBuffered = True
            ToolStripNuevoCliente.Enabled = False
            ToolStripModificarCliente.Enabled = True
            ToolStripEliminarCliente.Enabled = True

            id_Clientes = CInt(dgvClientes.CurrentRow.Cells(dfielddefCliente.Id_Cliente).Value.ToString())
            Nombre = dgvClientes.CurrentRow.Cells(dfielddefCliente.Nombre).Value.ToString()
            Apellido = dgvClientes.CurrentRow.Cells(dfielddefCliente.Apellido).Value.ToString()
            clsCliente.CompApellido = dgvClientes.CurrentRow.Cells(dfielddefCliente.Apellido).Value.ToString()
            clsCliente.CompCodigo = id_Clientes

            frmClientesAltas.codigo_Cliente = id_Clientes
            frmClientesAltas.NombreCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Nombre).Value.ToString()
            frmClientesAltas.ApellidoCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Apellido).Value.ToString()
            frmClientesAltas.calleCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Calle).Value.ToString()
            frmClientesAltas.pisoCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Piso).Value.ToString()
            frmClientesAltas.numeroCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Id_Cliente).Value.ToString()
            frmClientesAltas.saldoCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Saldo_CC).Value.ToString()
            clsCliente.Descomponer_CUIT_Cliente(dgvClientes.CurrentRow.Cells(dfielddefCliente.CUIT).Value.ToString(), cuit1, cuit2, cuit3)
            frmClientesAltas.cuitCliente1.Text = cuit1
            frmClientesAltas.cuitCliente2.Text = cuit2
            frmClientesAltas.cuitCliente3.Text = cuit3

            frmClientesAltas.provinciaCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Provincia).Value.ToString()
            frmClientesAltas.telefonoCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Telefono).Value.ToString()
            frmClientesAltas.celularCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Celular).Value.ToString()
            frmClientesAltas.EMailCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.E_Mail).Value.ToString()
            frmClientesAltas.codigoPostalCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Codigo_Postal).Value.ToString()
            frmClientesAltas.responsabiliadIVACliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Responsabilidad_IVA).Value.ToString()
            frmClientesAltas.localidadCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Localidad).Value.ToString()

            frmClientesAltas.cbInhabilitar.Checked = dgvClientes.CurrentRow.Cells(dfielddefCliente.INHABILITAR).Value.ToString()
            Posicion_Columna = dgvClientes.CurrentCell.ColumnIndex
            Nombre_Columna_a_Buscar = dgvClientes.Columns(Posicion_Columna).Name


            If (Nombre_Columna_a_Buscar = dfielddefconstante.Nombre.ToString()) Then
                Me.Label2.Text = "Nombre:"
            Else
                If (Nombre_Columna_a_Buscar = dfielddefconstante.Apellido.ToString()) Then
                    Me.Label2.Text = "Apellido:"
                Else
                    If (Nombre_Columna_a_Buscar = dfielddefconstante.Calle.ToString()) Then
                        Me.Label2.Text = "Calle:"
                    Else
                        If (Nombre_Columna_a_Buscar = dfielddefconstante.CUIT.ToString()) Then
                            Me.Label2.Text = "CUIT:"
                        Else
                            If (Nombre_Columna_a_Buscar = dfielddefconstante.Provincia.ToString()) Then
                                Me.Label2.Text = "Provincia:"
                            Else
                                If (Nombre_Columna_a_Buscar = dfielddefconstante.Telefono.ToString()) Then
                                    Me.Label2.Text = "Telefono:"
                                Else
                                    If (Nombre_Columna_a_Buscar = dfielddefconstante.Celular.ToString()) Then
                                        Me.Label2.Text = "Celular:"
                                    Else
                                        If (Nombre_Columna_a_Buscar = Replace(dfielddefconstante.E_Mail.ToString(), "_", " ")) Then
                                            Me.Label2.Text = "E_Mail:"
                                        Else
                                            If (Nombre_Columna_a_Buscar = Replace(dfielddefconstante.Codigo_Postal.ToString(), "_", " ")) Then
                                                Me.Label2.Text = "Codigo_Postal:"
                                            Else
                                                If (Nombre_Columna_a_Buscar = Replace(dfielddefconstante.Responsabilidad_IVA.ToString(), "_", " ")) Then
                                                    Me.Label2.Text = "Responsabilidad_IVA:"
                                                Else
                                                    If (Nombre_Columna_a_Buscar = dfielddefconstante.Localidad.ToString()) Then
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
    Public Sub ToolStripEliminarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEliminarCliente.Click
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim existe As Boolean

        Dim result As Integer = MessageBoxEx.Show("Desea Eliminar al Cliente: " + Nombre + " " + Apellido, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try

                clsFacturacion.Validar_Cliente(Convert.ToString(id_Clientes), existe)
                If Not existe Then
                    ReDim Cliente_estructura(1)
                    Cliente_estructura(1).Id_Cliente = id_Clientes
                    Cliente_estructura(1).Nombre = Nothing
                    Cliente_estructura(1).Apellido = Nothing
                    Cliente_estructura(1).Calle = Nothing
                    Cliente_estructura(1).Piso = Nothing
                    Cliente_estructura(1).Nro = Nothing
                    Cliente_estructura(1).Saldo_CC = Nothing
                    Cliente_estructura(1).CUIT = Nothing
                    Cliente_estructura(1).Provincia = Nothing
                    Cliente_estructura(1).Telefono = Nothing
                    Cliente_estructura(1).Celular = Nothing
                    Cliente_estructura(1).E_Mail = Nothing
                    Cliente_estructura(1).Codigo_Postal = Nothing
                    Cliente_estructura(1).Responsabilidad_IVA = Nothing
                    Cliente_estructura(1).Localidad = Nothing
                    Cliente_estructura(1).INHABILITAR = False
                    clsCliente.Obtener_Clave_Principal(ClavePrincipal)
                    clsCliente.Pasar_A_Coleccion(Cliente_estructura, datos, 1)
                    clsQueryBuilder.ArmaDelete("cliente", datos, ClavePrincipal, consulta)
                    clsCliente.Operaciones_Tabla(consulta)

                    MessageBoxEx.Show("El Cliente " + Nombre + " " + Apellido + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clsCliente.llenar_tabla_cliente(dgvClientes)
                    LimpiarEstructuras()
                Else
                    MessageBoxEx.Show("El Cliente " + Nombre + " " + Apellido + " No se puede Eliminar, Posee Movimientos!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Private Sub ToolStripModificarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModificarCliente.Click
        For x As Integer = pogressbarClientes.Minimum To pogressbarClientes.Maximum
            pogressbarClientes.Value = x
        Next
        For x As Integer = pogressbarClientes.Maximum To pogressbarClientes.Minimum Step -1
            pogressbarClientes.Value = x
        Next
        Me.Close()
        frmClientesAltas.Show()
        clsCliente.Compvariable = dfielddefconstante.Modificar_Cliente.ToString()
    End Sub
    Private Sub tbBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBusqueda.TextChanged
        Dim consulta As String

        Try
            If Nombre_Columna_a_Buscar <> "" Then
                clsCliente.Busqueda(dgvClientes, Nombre_Columna_a_Buscar, Me.tbBusqueda.Text)
            Else
                MessageBoxEx.Show("Error: No selecciono ningun criterio de busqueda!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim Cliente_estructura(0)
    End Sub
    Private Sub ToolStripEnviarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEnviarCliente.Click
        Dim frmFacturacion As New Vista.frmFacturacion()
        For x As Integer = pogressbarClientes.Minimum To pogressbarClientes.Maximum
            pogressbarClientes.Value = x
        Next
        For x As Integer = pogressbarClientes.Maximum To pogressbarClientes.Minimum Step -1
            pogressbarClientes.Value = x
        Next
        If clsCliente.Compvariable = dfielddefconstante.FACTURA.ToString() Then
            If (clsCliente.CompCodigo <> Nothing) Then
                clsCliente.CompCodigo = clsCliente.CompCodigo.ToString()
                clsCliente.Compvariable = ""

            Else
                'If (clientes.CompCodigo = Nothing) Then
                '    Facturacion.txtCodigoCliente.Text = Nothing
                'End If
            End If
        End If
        If clsCliente.Compvariable = dfielddefconstante.NotaCredito.ToString() Then
            If (clsCliente.CompCodigo <> Nothing) Then
                frmNotaCredito.txtCodigoCliente.Text = clsCliente.CompCodigo.ToString()
                clsCliente.Compvariable = ""
            Else
                If (clsCliente.CompCodigo = Nothing) Then
                    frmNotaCredito.txtCodigoCliente.Text = Nothing
                End If
            End If
        End If
        If clsCliente.Compvariable = dfielddefconstante.NotaDebito.ToString() Then
            If (clsCliente.CompCodigo <> Nothing) Then
                frmNotaDebito.txtCodigoCliente.Text = clsCliente.CompCodigo.ToString()
                clsCliente.Compvariable = ""
            Else
                If (clsCliente.CompCodigo = Nothing) Then
                    frmNotaCredito.txtCodigoCliente.Text = Nothing
                End If
            End If
        End If
        Me.Close()
    End Sub
    Private Sub ToolStripButtonCargarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCargarExcel.Click
        frmImportarExcel.Show()
        clsGenerales.Compvariable = dfielddefconstante.cliente.ToString()
    End Sub
End Class