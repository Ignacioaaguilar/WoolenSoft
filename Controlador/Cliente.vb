Imports System.Windows.Forms
Imports Modelo

Public Class Cliente
    Public session As New Controlador.Session()
    Private Shared variable As String
    Private Shared codigo As String
    Private Shared botonPulsado As Boolean

    Private Nombre As String
    Private Apellido As String
    Private Calle As String
    Private Piso As String
    Private Nro As String
    Private Saldo_CC As String
    Private CUIT As String
    Private Provincia As String
    Private Telefono As String
    Private Celular As String
    Private E_Mail As String
    Private Codigo_Postal As String
    Private Responsabilidad_IVA As String
    Private Localidad As String
    Public Structure eCliente
        Public Id_Cliente As Integer
        Public Nombre As String
        Public Apellido As String
        Public Calle As String
        Public Piso As String
        Public Nro As String
        Public Saldo_CC As String
        Public CUIT As String
        Public Provincia As String
        Public Telefono As String
        Public Celular As String
        Public E_Mail As String
        Public Codigo_Postal As String
        Public Responsabilidad_IVA As String
        Public Localidad As String
        Public INHABILITAR As Boolean
    End Structure
    Public Structure eCondicion_Frente_Al_Iva
        Public Id_Condicion_IVA As String
        Public Descripcion As String
    End Structure

    Public Property Compvariable() As String
        Get
            Return Me.variable
        End Get
        Set(ByVal Value As String)
            Me.variable = Value
        End Set
    End Property
    Public Property CompCodigo() As String
        Get
            Return Me.codigo
        End Get
        Set(ByVal Value As String)
            Me.codigo = Value
        End Set
    End Property
    Public Property CompBotonPulsado() As Boolean
        Get
            Return Me.botonPulsado
        End Get
        Set(ByVal Value As Boolean)
            Me.botonPulsado = Value
        End Set
    End Property
    Public Property CompNombre() As String
        Get
            Return Me.Nombre
        End Get
        Set(ByVal Value As String)
            Me.Nombre = Value
        End Set
    End Property
    Public Property CompApellido() As String
        Get
            Return Me.Apellido
        End Get
        Set(ByVal Value As String)
            Me.Apellido = Value
        End Set
    End Property
    Public Property CompCalle() As String
        Get
            Return Me.Calle
        End Get
        Set(ByVal Value As String)
            Me.Calle = Value
        End Set
    End Property
    Public Property CompPiso() As String
        Get
            Return Me.Piso
        End Get
        Set(ByVal Value As String)
            Me.Piso = Value
        End Set
    End Property
    Public Property CompNro() As String
        Get
            Return Me.Nro
        End Get
        Set(ByVal Value As String)
            Me.Nro = Value
        End Set
    End Property
    Public Property CompSaldo_CC() As String
        Get
            Return Me.Saldo_CC
        End Get
        Set(ByVal Value As String)
            Me.Saldo_CC = Value
        End Set
    End Property
    Public Property CompCUIT() As String
        Get
            Return Me.CUIT
        End Get
        Set(ByVal Value As String)
            Me.CUIT = Value
        End Set
    End Property
    Public Property CompProvincia() As String
        Get
            Return Me.Provincia
        End Get
        Set(ByVal Value As String)
            Me.Provincia = Value
        End Set
    End Property
    Public Property CompTelefono() As String
        Get
            Return Me.Telefono
        End Get
        Set(ByVal Value As String)
            Me.Telefono = Value
        End Set
    End Property
    Public Property CompCelular() As String
        Get
            Return Me.Celular
        End Get
        Set(ByVal Value As String)
            Me.Celular = Value
        End Set
    End Property
    Public Property CompE_Mail() As String
        Get
            Return Me.E_Mail
        End Get
        Set(ByVal Value As String)
            Me.E_Mail = Value
        End Set
    End Property
    Public Property CompCodigo_Postal() As String
        Get
            Return Me.Codigo_Postal
        End Get
        Set(ByVal Value As String)
            Me.Codigo_Postal = Value
        End Set
    End Property
    Public Property CompResponsabilidad_IVA() As String
        Get
            Return Me.Responsabilidad_IVA
        End Get
        Set(ByVal Value As String)
            Me.Responsabilidad_IVA = Value
        End Set
    End Property
    Public Property CompLocalidad() As String
        Get
            Return Me.Localidad
        End Get
        Set(ByVal Value As String)
            Me.Localidad = Value
        End Set
    End Property
    Public Sub llenar_tabla_cliente(ByRef grilla As DataGridView, Optional ByVal INHABILITAR As Boolean = Nothing)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Id_Cliente as [Cod Cliente],Nombre,Apellido,Calle,Piso,Nro,Saldo_CC as [Saldo CC],CUIT,Provincia,Telefono,Celular,E_Mail as [E Mail],Codigo_Postal as [Codigo Postal],Responsabilidad_IVA as [Responsabilidad IVA],Localidad,INHABILITAR from cliente  "
        If (INHABILITAR <> Nothing) Then
            consulta += "where INHABILITAR=" + INHABILITAR + ""
        End If

        conectar.cargar_tabla(grilla, consulta)
    End Sub
    Public Sub llenar_Combo_Cliente(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_combo(combo, cadena, value, member)
    End Sub
    Public Sub Operaciones_Tabla(ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.consulta_non_query(consulta)
    End Sub
    Public Function es_Vacio(ByVal valor As String) As Boolean
        If (valor = "") Then
            es_Vacio = True
        Else
            es_Vacio = False
        End If
    End Function
    Public Function es_Numero(ByVal valor As String) As Boolean
        If (IsNumeric(valor)) Then
            es_Numero = True
        Else
            es_Numero = False
        End If
    End Function
    Function ValidateEmail_Cliente(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(email)
        Return emailMatch.Success
    End Function
    Function validateDoublesAndCurrency_Cliente(ByVal stringValue As String) As Boolean
        Dim rslt As Boolean = False
        Dim value As Double
        Dim valueToTest As String = stringValue
        Try
            'check if value to be tested contains a currency symbol such as a dollar sign ($)
            valueToTest = Double.Parse(stringValue, Globalization.NumberStyles.Currency)
        Catch ex As Exception

        End Try
        'check if double
        If Double.TryParse(valueToTest, value) Then
            'value is double
            rslt = True
        Else
            'value is not double
            rslt = False
        End If
        Return rslt
    End Function
    Public Sub Descomponer_CUIT_Cliente(ByVal cuit As String, ByRef cuit1 As String, ByRef cuit2 As String, ByRef cuit3 As String)
        Dim i As Integer
        i = 1
        While (i <= 2)
            cuit1 = cuit1 + Mid(cuit, i, 1)
            i = i + 1
        End While
        i = i + 1
        While (i <= 11)
            cuit2 = cuit2 + Mid(cuit, i, 1)
            i = i + 1
        End While
        i = i + 1
        While (i <= 13)
            cuit3 = cuit3 + Mid(cuit, i, 1)
            i = i + 1
        End While
    End Sub
    Public Sub Busqueda(ByRef tabla As DataGridView, ByVal Nombre_Columna_a_Buscar As String, ByVal campoBusqueda As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Id_Cliente as [Cod Cliente],Nombre,Apellido,Calle,Piso,Nro,Saldo_CC as [Saldo CC],CUIT,Provincia,Telefono,Celular,E_Mail as [E-Mail],Codigo_Postal as [Codigo Postal],Responsabilidad_IVA as [Responsabilidad IVA],Localidad,INHABILITAR from cliente  where " + Nombre_Columna_a_Buscar + " like '" & campoBusqueda & "%'"
        conectar.cargar_tabla(tabla, consulta)
    End Sub
    Public Sub validar_Cuit(ByVal numero1 As String, ByVal numero2 As String, ByVal numero3 As String, ByRef esvalido As Boolean)
        Dim digito As Integer
        Dim suma As Integer
        Dim resto As Integer
        Dim digito_verificador As Integer
        Dim complemento As Integer
        Dim valor As Integer

        digito = CInt(numero3)
        suma = 0
        digito_verificador = 0
        valor = 0
        For i As Integer = 1 To Len(numero1)
            Select Case i
                Case 1
                    valor = CInt(Mid(numero1, i, 1))
                    suma = suma + (valor * 5)
                Case 2
                    valor = CInt(Mid(numero1, i, 1))
                    suma = suma + (valor * 4)
            End Select
        Next
        For i As Integer = 1 To Len(numero2)
            Select Case i
                Case 1
                    valor = CInt(Mid(numero2, i, 1))
                    suma = suma + (valor * 3)
                Case 2
                    valor = CInt(Mid(numero2, i, 1))
                    suma = suma + (valor * 2)
                Case 3
                    valor = CInt(Mid(numero2, i, 1))
                    suma = suma + (valor * 7)
                Case 4
                    valor = CInt(Mid(numero2, i, 1))
                    suma = suma + (valor * 6)
                Case 5
                    valor = CInt(Mid(numero2, i, 1))
                    suma = suma + (valor * 5)
                Case 6
                    valor = CInt(Mid(numero2, i, 1))
                    suma = suma + (valor * 4)
                Case 7
                    valor = CInt(Mid(numero2, i, 1))
                    suma = suma + (valor * 3)
                Case 8
                    valor = CInt(Mid(numero2, i, 1))
                    suma = suma + (valor * 2)
            End Select
        Next
        resto = suma Mod 11
        If (resto = 0) Then
            digito_verificador = 0
        Else
            If (resto <> 0) Then
                complemento = 11 - resto
                If (complemento = 10) Then
                    digito_verificador = 10
                Else
                    digito_verificador = complemento
                End If
                If (digito_verificador = digito) Then
                    esvalido = True
                Else
                    esvalido = False
                End If
            End If
        End If
    End Sub
    Public Sub Limpiar_Datos_Cliente(ByRef text1 As TextBox, ByRef text2 As TextBox, ByRef text3 As TextBox, ByRef text4 As TextBox, ByRef text5 As TextBox, ByRef text6 As TextBox, ByRef text7 As TextBox, ByRef text8 As TextBox, ByRef text9 As TextBox, ByRef text10 As TextBox, ByRef text11 As TextBox, ByRef text12 As TextBox, ByRef text13 As TextBox, ByRef text14 As TextBox)
        text1.Text = ""
        text2.Text = ""
        text3.Text = ""
        text4.Text = ""
        text5.Text = ""
        text6.Text = ""
        text7.Text = ""
        text8.Text = ""
        text9.Text = ""
        text10.Text = ""
        text11.Text = ""
        text12.Text = ""
        text13.Text = ""
        text14.Text = ""
    End Sub
    Public Sub Limpiar_Datos_Cliente_CUIT(ByRef text1 As TextBox, ByRef text2 As TextBox, ByRef text3 As TextBox)
        text1.Text = ""
        text2.Text = ""
        text3.Text = ""
    End Sub
    Public Sub Pasar_A_Coleccion(ByVal Cliente_estructura() As eCliente, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(Cliente_estructura(i).Id_Cliente)
        datos.Add(Cliente_estructura(i).Nombre)
        datos.Add(Cliente_estructura(i).Apellido)
        datos.Add(Cliente_estructura(i).Calle)
        datos.Add(Cliente_estructura(i).Piso)
        datos.Add(Cliente_estructura(i).Nro)
        datos.Add(Cliente_estructura(i).Saldo_CC)
        datos.Add(Cliente_estructura(i).CUIT)
        datos.Add(Cliente_estructura(i).Provincia)
        datos.Add(Cliente_estructura(i).Telefono)
        datos.Add(Cliente_estructura(i).Celular)
        datos.Add(Cliente_estructura(i).E_Mail)
        datos.Add(Cliente_estructura(i).Codigo_Postal)
        datos.Add(Cliente_estructura(i).Responsabilidad_IVA)
        datos.Add(Cliente_estructura(i).Localidad)
        datos.Add(Cliente_estructura(i).INHABILITAR)
    End Sub
    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Cliente")
    End Sub
    Public Sub ObtenerConsulta(ByVal consulta As String, ByRef Datos As DataTable)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        Datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub ObtenerConsultaListado(ByRef Datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "SELECT Id_Cliente, Nombre, Apellido, Calle, Piso, Nro, Saldo_CC, CUIT, Provincia, Telefono, Celular, E_Mail, Codigo_Postal, Responsabilidad_IVA, Localidad FROM Cliente"
        Datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub ObtenerDatosCliente(ByVal Codigo_Cliente As Integer, ByRef DatosCliente As eCliente)
        Dim conectar As New coneccion()
        Dim Datos As DataTable
        Dim consulta As String
        consulta = "Select * from Cliente where Id_Cliente=" & Codigo_Cliente & ""
        conectar.srt_conexion = session.Session.CadenaConeccion
        Datos = conectar.consulta_reader(consulta)
        If Datos.Rows.Count > 0 Then
            PasarDatosClienteAEstructura(Datos, DatosCliente)
        Else
            LimpiarStrucCliente(DatosCliente)
        End If
    End Sub
    Public Sub PasarDatosClienteAEstructura(ByVal datos As DataTable, ByRef DClientes As eCliente)
        Dim dfielddefCliente As Controlador.DfieldDef.eCliente
        DClientes.Id_Cliente = datos.Rows(0).Item(dfielddefCliente.Id_Cliente).ToString()
        DClientes.Nombre = datos.Rows(0).Item(dfielddefCliente.Nombre).ToString()
        DClientes.Apellido = datos.Rows(0).Item(dfielddefCliente.Apellido).ToString()
        DClientes.Calle = datos.Rows(0).Item(dfielddefCliente.Calle).ToString()
        DClientes.Piso = datos.Rows(0).Item(dfielddefCliente.Piso).ToString()
        DClientes.Nro = datos.Rows(0).Item(dfielddefCliente.Nro).ToString()
        DClientes.Celular = datos.Rows(0).Item(dfielddefCliente.Celular).ToString()
        DClientes.Telefono = datos.Rows(0).Item(dfielddefCliente.Telefono).ToString()
        DClientes.Responsabilidad_IVA = datos.Rows(0).Item(dfielddefCliente.Responsabilidad_IVA).ToString()
        DClientes.E_Mail = datos.Rows(0).Item(dfielddefCliente.E_Mail).ToString()
        DClientes.Saldo_CC = datos.Rows(0).Item(dfielddefCliente.Saldo_CC).ToString()
        DClientes.Codigo_Postal = datos.Rows(0).Item(dfielddefCliente.Codigo_Postal).ToString()
        DClientes.INHABILITAR = datos.Rows(0).Item(dfielddefCliente.INHABILITAR).ToString()
        DClientes.Localidad = datos.Rows(0).Item(dfielddefCliente.Localidad).ToString()
        DClientes.Provincia = datos.Rows(0).Item(dfielddefCliente.Provincia).ToString()
    End Sub


    Public Sub Obtener_CondicionFrenteAIVa(ByVal Responsabilidad_IVA_Desc As String, ByRef numero_Condicion As eCondicion_Frente_Al_Iva)
        Dim conectar As New coneccion()
        Dim datos As DataTable
        Dim dfieddefCondicionFrenteAlIva As Controlador.DfieldDef.eCondicionFrenteAlIVa
        Dim consulta As String
        consulta = "select Id_Condicion_IVA,Descripcion from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Desc) & "' "
        conectar.srt_conexion = session.Session.CadenaConeccion
        datos = conectar.consulta_reader(consulta)
        numero_Condicion.Id_Condicion_IVA = datos.Rows(0).Item(dfieddefCondicionFrenteAlIva.Id_Condicion_IVA)
        numero_Condicion.Descripcion = datos.Rows(0).Item(dfieddefCondicionFrenteAlIva.Descripcion)
    End Sub
    Public Sub Validar_Cliente(ByVal Codigo_Cliente As Integer, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim consulta As String
        consulta = "Select * from Cliente where Id_Cliente=" & Codigo_Cliente & ""
        conectar.srt_conexion = session.Session.CadenaConeccion
        existe = conectar.verificar_existencia(consulta)
    End Sub
    Public Sub ObtenerIdConsumidorFinal(ByVal consulta As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub ObtenerUltimoNumeroCliente(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select max(Id_Cliente) from cliente"
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub

    Public Sub LimpiarStrucCliente(ByRef Datos_Clientes As eCliente)
        Datos_Clientes.Id_Cliente = 0
        Datos_Clientes.Nombre = String.Empty
        Datos_Clientes.Apellido = String.Empty
        Datos_Clientes.Calle = String.Empty
        Datos_Clientes.Piso = String.Empty
        Datos_Clientes.Nro = String.Empty
        Datos_Clientes.Saldo_CC = String.Empty
        Datos_Clientes.CUIT = String.Empty
        Datos_Clientes.Provincia = String.Empty
        Datos_Clientes.Telefono = String.Empty
        Datos_Clientes.Celular = String.Empty
        Datos_Clientes.E_Mail = String.Empty
        Datos_Clientes.Codigo_Postal = String.Empty
        Datos_Clientes.Responsabilidad_IVA = String.Empty
        Datos_Clientes.Localidad = String.Empty
        Datos_Clientes.INHABILITAR = 0
    End Sub
End Class

