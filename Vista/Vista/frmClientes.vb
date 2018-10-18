Imports Controlador
Public Class frmClientes
    Public id_Clientes As Integer
    Public Nombre As String
    Public Apellido As String
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim Cliente_estructura(0) As Controlador.Cliente.eCliente
    Dim dfielddefCliente As Controlador.DfieldDef.eCliente
    Dim dfielddefconstante As Controlador.DfieldDef.eConstantes
    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Dim cliente As New Controlador.Cliente()
        Try
            ToolStripNuevoCliente.Enabled = True
            ToolStripModificarCliente.Enabled = False
            ToolStripEliminarCliente.Enabled = False
            Me.DoubleBuffered = True
            If cliente.Compvariable = dfielddefconstante.FACTURA.ToString() Or cliente.Compvariable = dfielddefconstante.NotaCredito.ToString() Or cliente.Compvariable = dfielddefconstante.NotaDebito.ToString() Then

                ToolStripEnviarCliente.Visible = True
                'consulta = "select Id_Cliente as [Cod Cliente],Nombre,Apellido,Calle,Piso,Nro,Saldo_CC as [Saldo CC],CUIT,Provincia,Telefono,Celular,E_Mail as [E Mail],Codigo_Postal as [Codigo Postal],Responsabilidad_IVA as [Responsabilidad IVA],Localidad,INHABILITAR from " + dfielddefconstante.cliente.ToString() + " where INHABILITAR=false "
                cliente.llenar_tabla_cliente(dgvClientes, False)
            Else
                ToolStripEnviarCliente.Visible = False
                'consulta = "select Id_Cliente as [Cod Cliente],Nombre,Apellido,Calle,Piso,Nro,Saldo_CC as [Saldo CC],CUIT,Provincia,Telefono,Celular,E_Mail as [E-Mail],Codigo_Postal as [Codigo Postal],Responsabilidad_IVA as [Responsabilidad IVA],Localidad,INHABILITAR from " + dfielddefconstante.cliente.ToString() + " "
                cliente.llenar_tabla_cliente(dgvClientes)
            End If

        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripSalirCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirCliente.Click
        Dim cliente As New Controlador.Cliente()
        For x As Integer = pogressbarClientes.Minimum To pogressbarClientes.Maximum
            pogressbarClientes.Value = x
        Next
        For x As Integer = pogressbarClientes.Maximum To pogressbarClientes.Minimum Step -1
            pogressbarClientes.Value = x
        Next
        cliente.Compvariable = String.Empty
        cliente.CompCodigo = String.Empty
        Me.Close()
    End Sub
    Private Sub ToolStripNuevoCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNuevoCliente.Click
        Dim Cliente As New Controlador.Cliente()
        For x As Integer = pogressbarClientes.Minimum To pogressbarClientes.Maximum
            pogressbarClientes.Value = x
        Next
        For x As Integer = pogressbarClientes.Maximum To pogressbarClientes.Minimum Step -1
            pogressbarClientes.Value = x
        Next
        Me.Close()
        frmClientesAltas.Show()
        Cliente.Compvariable = dfielddefconstante.Agregar_Cliente.ToString()
    End Sub
    Private Sub dgvClientes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvClientes.Click
        Dim Cliente As New Controlador.Cliente()
        Dim cuit1, cuit2, cuit3 As String
        Try
            Me.DoubleBuffered = True
            ToolStripNuevoCliente.Enabled = False
            ToolStripModificarCliente.Enabled = True
            ToolStripEliminarCliente.Enabled = True

            id_Clientes = CInt(dgvClientes.CurrentRow.Cells(dfielddefCliente.Id_Cliente).Value.ToString())
            Nombre = dgvClientes.CurrentRow.Cells(dfielddefCliente.Nombre).Value.ToString()
            Apellido = dgvClientes.CurrentRow.Cells(dfielddefCliente.Apellido).Value.ToString()
            Cliente.CompApellido = dgvClientes.CurrentRow.Cells(dfielddefCliente.Apellido).Value.ToString()
            Cliente.CompCodigo = id_Clientes

            frmClientesAltas.codigo_Cliente = id_Clientes
            frmClientesAltas.NombreCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Nombre).Value.ToString()
            frmClientesAltas.ApellidoCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Apellido).Value.ToString()
            frmClientesAltas.calleCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Calle).Value.ToString()
            frmClientesAltas.pisoCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Piso).Value.ToString()
            frmClientesAltas.numeroCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Id_Cliente).Value.ToString()
            frmClientesAltas.saldoCliente.Text = dgvClientes.CurrentRow.Cells(dfielddefCliente.Saldo_CC).Value.ToString()
            Cliente.Descomponer_CUIT_Cliente(dgvClientes.CurrentRow.Cells(dfielddefCliente.CUIT).Value.ToString(), cuit1, cuit2, cuit3)
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
        Dim cliente As New Controlador.Cliente()
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim existe As Boolean
        Dim facturacion As New Controlador.Facturacion()
        Dim result As Integer = MessageBox.Show("Desea Eliminar al Cliente: " + Nombre + " " + Apellido, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                'consulta = "Select * from " + dfielddefconstante.Encabezado_Factura.ToString() + "  where Numero_Cliente='" + Convert.ToString(id_Clientes) + "' "
                facturacion.Validar_Cliente(Convert.ToString(id_Clientes), existe)
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
                    cliente.Obtener_Clave_Principal(ClavePrincipal)
                    cliente.Pasar_A_Coleccion(Cliente_estructura, datos, 1)
                    querybuilder.ArmaDelete("cliente", datos, ClavePrincipal, consulta)
                    cliente.Operaciones_Tabla(consulta)

                    MessageBox.Show("El Cliente " + Nombre + " " + Apellido + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'consulta = "select Id_Cliente as [Cod Cliente],Nombre,Apellido,Calle,Piso,Nro,Saldo_CC as [Saldo CC],CUIT,Provincia,Telefono,Celular,E_Mail as [E-Mail],Codigo_Postal as [Codigo Postal],Responsabilidad_IVA as [Responsabilidad IVA],Localidad,INHABILITAR from " + dfielddefconstante.cliente.ToString() + ""
                    cliente.llenar_tabla_cliente(dgvClientes)
                    LimpiarEstructuras()
                Else
                    MessageBox.Show("El Cliente " + Nombre + " " + Apellido + " No se puede Eliminar, Posee Movimientos!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Private Sub ToolStripModificarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModificarCliente.Click
        Dim Cliente As New Controlador.Cliente()
        For x As Integer = pogressbarClientes.Minimum To pogressbarClientes.Maximum
            pogressbarClientes.Value = x
        Next
        For x As Integer = pogressbarClientes.Maximum To pogressbarClientes.Minimum Step -1
            pogressbarClientes.Value = x
        Next
        Me.Close()
        frmClientesAltas.Show()
        Cliente.Compvariable = dfielddefconstante.Modificar_Cliente.ToString()
    End Sub
    Private Sub tbBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBusqueda.TextChanged
        Dim consulta As String
        Dim Cliente As New Controlador.Cliente()
        Try
            If Nombre_Columna_a_Buscar <> "" Then
                'consulta = "select Id_Cliente as [Cod Cliente],Nombre,Apellido,Calle,Piso,Nro,Saldo_CC as [Saldo CC],CUIT,Provincia,Telefono,Celular,E_Mail as [E-Mail],Codigo_Postal as [Codigo Postal],Responsabilidad_IVA as [Responsabilidad IVA],Localidad,INHABILITAR from " + dfielddefconstante.cliente.ToString() + "  where " + Nombre_Columna_a_Buscar + " like '" & Me.tbBusqueda.Text & "%'"
                Cliente.Busqueda(dgvClientes, Nombre_Columna_a_Buscar, Me.tbBusqueda.Text)
            Else
                MessageBox.Show("Error: No selecciono ningun criterio de busqueda!!!", "Informacion", MessageBoxButtons.OK, _
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
        Dim clientes As New Controlador.Cliente()
        Dim frmFacturacion As New Vista.frmFacturacion()
        For x As Integer = pogressbarClientes.Minimum To pogressbarClientes.Maximum
            pogressbarClientes.Value = x
        Next
        For x As Integer = pogressbarClientes.Maximum To pogressbarClientes.Minimum Step -1
            pogressbarClientes.Value = x
        Next
        If clientes.Compvariable = dfielddefconstante.FACTURA.ToString() Then
            If (clientes.CompCodigo <> Nothing) Then

                clientes.CompCodigo = clientes.CompCodigo.ToString()
                'Facturacion.txtCodigoCliente.Text = clientes.CompCodigo.ToString()
                clientes.Compvariable = ""

            Else
                'If (clientes.CompCodigo = Nothing) Then
                '    Facturacion.txtCodigoCliente.Text = Nothing
                'End If
            End If
        End If
        If clientes.Compvariable = dfielddefconstante.NotaCredito.ToString() Then
            If (clientes.CompCodigo <> Nothing) Then
                frmNotaCredito.txtCodigoCliente.Text = clientes.CompCodigo.ToString()
                clientes.Compvariable = ""
            Else
                If (clientes.CompCodigo = Nothing) Then
                    frmNotaCredito.txtCodigoCliente.Text = Nothing
                End If
            End If
        End If
        If clientes.Compvariable = dfielddefconstante.NotaDebito.ToString() Then
            If (clientes.CompCodigo <> Nothing) Then
                frmNotaDebito.txtCodigoCliente.Text = clientes.CompCodigo.ToString()
                clientes.Compvariable = ""
            Else
                If (clientes.CompCodigo = Nothing) Then
                    frmNotaCredito.txtCodigoCliente.Text = Nothing
                End If
            End If
        End If
        Me.Close()
    End Sub
    Private Sub ToolStripButtonCargarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCargarExcel.Click
        Dim Generales As New Controlador.Generales
        frmImportarExcel.Show()
        Generales.Compvariable = dfielddefconstante.cliente.ToString()
    End Sub


End Class