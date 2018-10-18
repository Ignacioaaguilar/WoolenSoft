Imports Controlador
Public Class frmClientesAltas
    Public codigo_Cliente As Integer
    Dim Cliente_estructura(0) As Controlador.Cliente.eCliente
    Dim dfielddfConstantes As Controlador.DfieldDef.eConstantes

    Private Sub ClientesAltas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim provincia As New Provincia
        Dim respIVA As New ResponsabilidadIVA
        Dim consulta As String
        Try
            'consulta = "Select * from " + dfielddfConstantes.Provincia.ToString + ""
            provincia.llenar_Combo_provincia(provinciaCliente, "Descripcion", "Descripcion")
            'consulta = "Select * from  " + dfielddfConstantes.Condicion_Frente_Al_IVA.ToString + ""
            respIVA.llenar_Combo_ResponsabilidadIVA(responsabiliadIVACliente, "Descripcion", "Descripcion")
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripSalirClientesAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirClientesAltas.Click
        For x As Integer = ProgressBarClienteAlta.Minimum To ProgressBarClienteAlta.Maximum
            ProgressBarClienteAlta.Value = x
        Next
        For x As Integer = ProgressBarClienteAlta.Maximum To ProgressBarClienteAlta.Minimum Step -1
            ProgressBarClienteAlta.Value = x
        Next
        Me.Close()
        frmClientes.Show()
    End Sub
    Private Sub ToolStripGuardarClientesAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripGuardarClientesAltas.Click
        Dim cliente As New Controlador.Cliente()
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim ultimo As Integer
        Try
            If (cliente.Compvariable = dfielddfConstantes.Agregar_Cliente.ToString()) Then
                If (NombreCliente.Text <> "" And ApellidoCliente.Text <> "") Then
                    ReDim Cliente_estructura(1)
                    'consulta = "Select max(Id_Cliente) from " + dfielddfConstantes.cliente.ToString() + ""
                    cliente.ObtenerUltimoNumeroCliente(ultimo)
                    Cliente_estructura(1).Id_Cliente = ultimo
                    Cliente_estructura(1).Nombre = NombreCliente.Text
                    Cliente_estructura(1).Apellido = ApellidoCliente.Text
                    Cliente_estructura(1).Calle = calleCliente.Text
                    Cliente_estructura(1).Piso = pisoCliente.Text
                    Cliente_estructura(1).Nro = numeroCliente.Text
                    Cliente_estructura(1).CUIT = cuitCliente1.Text + "-" + cuitCliente2.Text + "-" + cuitCliente3.Text
                    Cliente_estructura(1).Provincia = provinciaCliente.Text
                    Cliente_estructura(1).Telefono = telefonoCliente.Text
                    Cliente_estructura(1).Celular = celularCliente.Text
                    Cliente_estructura(1).E_Mail = EMailCliente.Text
                    Cliente_estructura(1).Codigo_Postal = codigoPostalCliente.Text
                    Cliente_estructura(1).Responsabilidad_IVA = responsabiliadIVACliente.Text
                    Cliente_estructura(1).Localidad = localidadCliente.Text
                    If cliente.es_Vacio(saldoCliente.Text) Then
                        Cliente_estructura(1).Saldo_CC = 0
                    Else
                        Cliente_estructura(1).Saldo_CC = saldoCliente.Text
                    End If
                    If cbInhabilitar.Checked = True Then
                        Cliente_estructura(1).INHABILITAR = True
                    Else
                        Cliente_estructura(1).INHABILITAR = False
                    End If
                    Try
                        querybuilder.obtener_estructura(dfielddfConstantes.cliente.ToString(), esquema)
                        cliente.Obtener_Clave_Principal(ClavePrincipal)
                        cliente.Pasar_A_Coleccion(Cliente_estructura, datos, 1)
                        querybuilder.ArmaInsert(dfielddfConstantes.cliente.ToString(), esquema, datos, ClavePrincipal, consulta)
                        cliente.Operaciones_Tabla(consulta)
                        MessageBox.Show("Los Datos del Cliente se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                         MessageBoxIcon.Information)
                        cliente.Limpiar_Datos_Cliente(NombreCliente, ApellidoCliente, EMailCliente, telefonoCliente, celularCliente, calleCliente, pisoCliente, numeroCliente, localidadCliente, codigoPostalCliente, cuitCliente1, cuitCliente2, cuitCliente3, saldoCliente)
                        LimpiarEstructuras()
                    Catch ex As Exception
                        MsgBox("Error:" & vbCrLf & ex.Message)
                    End Try
                Else
                    MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
                End If
            Else
                If (cliente.Compvariable = dfielddfConstantes.Modificar_Cliente.ToString()) Then
                    If (NombreCliente.Text <> "" And ApellidoCliente.Text <> "" And telefonoCliente.Text <> "" And responsabiliadIVACliente.Text <> "") Then
                        ReDim Cliente_estructura(1)
                        Cliente_estructura(1).Id_Cliente = codigo_Cliente
                        Cliente_estructura(1).Nombre = NombreCliente.Text
                        Cliente_estructura(1).Apellido = ApellidoCliente.Text
                        Cliente_estructura(1).Calle = calleCliente.Text
                        Cliente_estructura(1).Piso = pisoCliente.Text
                        Cliente_estructura(1).Nro = numeroCliente.Text
                        Cliente_estructura(1).CUIT = cuitCliente1.Text + "-" + cuitCliente2.Text + "-" + cuitCliente3.Text
                        Cliente_estructura(1).Provincia = provinciaCliente.Text
                        Cliente_estructura(1).Telefono = telefonoCliente.Text
                        Cliente_estructura(1).Celular = celularCliente.Text
                        Cliente_estructura(1).E_Mail = EMailCliente.Text
                        Cliente_estructura(1).Codigo_Postal = codigoPostalCliente.Text
                        Cliente_estructura(1).Responsabilidad_IVA = responsabiliadIVACliente.Text
                        Cliente_estructura(1).Localidad = localidadCliente.Text
                        If cliente.es_Vacio(saldoCliente.Text) Then
                            Cliente_estructura(1).Saldo_CC = 0
                        Else
                            Cliente_estructura(1).Saldo_CC = saldoCliente.Text
                        End If
                        If cbInhabilitar.Checked = True Then
                            Cliente_estructura(1).INHABILITAR = True
                        Else
                            Cliente_estructura(1).INHABILITAR = False
                        End If
                        Try
                            querybuilder.obtener_estructura(dfielddfConstantes.cliente.ToString(), esquema)
                            cliente.Obtener_Clave_Principal(ClavePrincipal)
                            cliente.Pasar_A_Coleccion(Cliente_estructura, datos, 1)
                            querybuilder.ArmaUpdate(dfielddfConstantes.cliente.ToString(), esquema, datos, ClavePrincipal, consulta)
                            cliente.Operaciones_Tabla(consulta)
                            MessageBox.Show("Los Datos del Cliente se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                            cliente.Limpiar_Datos_Cliente(NombreCliente, ApellidoCliente, EMailCliente, telefonoCliente, celularCliente, calleCliente, pisoCliente, numeroCliente, localidadCliente, codigoPostalCliente, cuitCliente1, cuitCliente2, cuitCliente3, saldoCliente)
                            LimpiarEstructuras()
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
        For x As Integer = ProgressBarClienteAlta.Minimum To ProgressBarClienteAlta.Maximum
            ProgressBarClienteAlta.Value = x
        Next
        For x As Integer = ProgressBarClienteAlta.Maximum To ProgressBarClienteAlta.Minimum Step -1
            ProgressBarClienteAlta.Value = x
        Next
    End Sub
    Private Sub numeroCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cliente As New Controlador.Cliente()
        If Not cliente.es_Numero(numeroCliente.Text) Then
            numeroCliente.Text = ""
        End If
    End Sub
    Private Sub cuitCliente1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cliente As New Controlador.Cliente()
        If Not cliente.es_Numero(cuitCliente1.Text) Then
            cuitCliente1.Text = ""
        End If
    End Sub
    Private Sub cuitCliente2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cliente As New Controlador.Cliente()
        If Not cliente.es_Numero(cuitCliente2.Text) Then
            cuitCliente2.Text = ""
        End If
    End Sub
    Private Sub cuitCliente3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cliente As New Controlador.Cliente()
        Dim valido As Boolean
        Try
            If Not cliente.es_Numero(cuitCliente3.Text) Then
                cuitCliente3.Text = ""
            Else
                If (cuitCliente3.Text <> "") And (cuitCliente2.Text <> "") And (cuitCliente1.Text <> "") Then
                    cliente.validar_Cuit(cuitCliente1.Text, cuitCliente2.Text, cuitCliente3.Text, valido)
                    If Not valido Then
                        MessageBox.Show("Error: El Numero de CUIT es Invalido!!!", "Informacion", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Exclamation)
                        cliente.Limpiar_Datos_Cliente_CUIT(cuitCliente1, cuitCliente2, cuitCliente3)
                        cuitCliente1.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub codigoPostalCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cliente As New Controlador.Cliente()
        If Not (cliente.es_Numero(codigoPostalCliente.Text)) Or Len(codigoPostalCliente.Text) > 4 Then
            codigoPostalCliente.Text = ""
        End If
    End Sub
    Private Sub EMailCliente_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cliente As New Controlador.Cliente()
        If Not (cliente.ValidateEmail_Cliente(EMailCliente.Text)) Then
            EMailCliente.Text = ""
            EMailCliente.Focus()
        End If
    End Sub
    Private Sub telefonoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cliente As New Controlador.Cliente()
        If Not cliente.es_Numero(telefonoCliente.Text) Then
            telefonoCliente.Text = ""
        End If
    End Sub
    Private Sub celularCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cliente As New Controlador.Cliente()
        If Not cliente.es_Numero(celularCliente.Text) Then
            celularCliente.Text = ""
        End If
    End Sub
    Private Sub saldoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cliente As New Controlador.Cliente()
        If Not (cliente.validateDoublesAndCurrency_Cliente(saldoCliente.Text)) Then
            saldoCliente.Text = ""
        End If
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim Cliente_estructura(0)
    End Sub
    Private Sub telefonoCliente_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles telefonoCliente.TextChanged
        Dim Cliente As New Controlador.Cliente
        If Not (Cliente.es_Numero(telefonoCliente.Text)) Then
            telefonoCliente.Text = ""
        End If
    End Sub
    Private Sub celularCliente_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles celularCliente.TextChanged
        Dim Cliente As New Controlador.Cliente
        If Not (Cliente.es_Numero(celularCliente.Text)) Then
            celularCliente.Text = ""
        End If
    End Sub
    Private Sub numeroCliente_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numeroCliente.TextChanged
        Dim Cliente As New Controlador.Cliente
        If Not (Cliente.es_Numero(numeroCliente.Text)) Then
            numeroCliente.Text = ""
        End If
    End Sub
    Private Sub codigoPostalCliente_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles codigoPostalCliente.TextChanged
        Dim Cliente As New Controlador.Cliente
        If Not (Cliente.es_Numero(codigoPostalCliente.Text)) Then
            codigoPostalCliente.Text = ""
        End If
    End Sub
    Private Sub cuitCliente1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cuitCliente1.TextChanged
        Dim Cliente As New Controlador.Cliente
        If Not (Cliente.es_Numero(cuitCliente1.Text)) Then
            cuitCliente1.Text = ""
        End If
    End Sub
    Private Sub cuitCliente2_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cuitCliente2.TextChanged
        Dim Cliente As New Controlador.Cliente
        If Not (Cliente.es_Numero(cuitCliente2.Text)) Then
            cuitCliente2.Text = ""
        End If
    End Sub
    Private Sub cuitCliente3_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cuitCliente3.TextChanged
        Dim Cliente As New Controlador.Cliente
        If Not (Cliente.es_Numero(cuitCliente3.Text)) Then
            cuitCliente3.Text = ""
        End If
    End Sub
    Private Sub saldoCliente_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saldoCliente.TextChanged
        Dim Cliente As New Controlador.Cliente
        If Not (Cliente.validateDoublesAndCurrency_Cliente(saldoCliente.Text)) Then
            saldoCliente.Text = ""
        End If
    End Sub
End Class