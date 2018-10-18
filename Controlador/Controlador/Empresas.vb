﻿Imports System.Windows.Forms
Imports Modelo

Public Class Empresas
    Private Shared variable As String
    Private RazonSocial As String
    Private IngresosBrutos As String
    Private Calle As String
    Private Piso As String
    Private Nro As String
    Private CUIT As String
    Private Provincia As String
    Private Telefono As String
    Private Celular As String
    Private E_Mail As String
    Private Codigo_Postal As String
    Private Responsabilidad_IVA As String
    Private Localidad As String
    Private Sucursal As String
    Public Structure eEmpresa
        Public Id_Empresa As String
        Public Razon_Social As String
        Public Calle As String
        Public Piso As String
        Public Nro As String
        Public Localidad As String
        Public Codigo_Postal As String
        Public CUIT As String
        Public Ingresos_Brutos As String
        Public Responsabilidad_IVA As String
        Public Nro_Sucursal As String
        Public Provincia As String
        
    End Structure
    Public Property Compvariable() As String
        Get
            Return Me.variable
        End Get
        Set(ByVal Value As String)
            Me.variable = Value
        End Set
    End Property
    Public Property CompSucursal() As String
        Get
            Return Me.Sucursal
        End Get
        Set(ByVal Value As String)
            Me.Sucursal = Value
        End Set
    End Property
    Public Property CompIngresosBrutos() As String
        Get
            Return Me.IngresosBrutos
        End Get
        Set(ByVal Value As String)
            Me.IngresosBrutos = Value
        End Set
    End Property

    Public Property CompRazonSocial() As String
        Get
            Return Me.RazonSocial
        End Get
        Set(ByVal Value As String)
            Me.RazonSocial = Value
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
    Public Sub llenar_tabla_Empresas(ByVal cadena As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        conectar.cargar_tabla(grilla, cadena)
    End Sub

    Public Sub llenar_Combo_Empresas(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
        Dim conectar As New coneccion()
        conectar.cargar_combo(combo, cadena, value, member)
    End Sub

    Public Sub Operaciones_Tabla(ByVal consulta As String)
        Dim conectar As New coneccion()
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

    Function ValidateEmail_Empresas(ByVal email As String) As Boolean
        Dim emailRegex As New System.Text.RegularExpressions.Regex("^(?<user>[^@]+)@(?<host>.+)$")
        Dim emailMatch As System.Text.RegularExpressions.Match = emailRegex.Match(email)
        Return emailMatch.Success
    End Function

    Function validateDoublesAndCurrency_Empresas(ByVal stringValue As String) As Boolean
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

    Public Sub Descomponer_CUIT_Empresas(ByVal cuit As String, ByRef cuit1 As String, ByRef cuit2 As String, ByRef cuit3 As String)
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


    Public Sub Busqueda(ByRef tabla As DataGridView, ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.cargar_tabla(tabla, consulta)


    End Sub
    Public Sub recuperar_Datos(ByVal consulta As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        datos = conectar.consulta_reader(consulta)


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

    Public Sub se_Cargo(ByVal consulta As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        existe = conectar.verificar_existencia(consulta)

    End Sub

    Public Sub Limpiar_Datos_Empresas(ByRef text1 As TextBox, ByRef text2 As TextBox, ByRef text3 As TextBox, ByRef text4 As TextBox, ByRef text5 As TextBox, ByRef text6 As TextBox, ByRef text7 As TextBox, ByRef text8 As TextBox, ByRef text9 As TextBox, ByRef text10 As TextBox, ByRef text11 As TextBox)
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
    End Sub
    Public Sub Limpiar_Datos_Empresa_CUIT(ByRef text1 As TextBox, ByRef text2 As TextBox, ByRef text3 As TextBox)
        text1.Text = ""
        text2.Text = ""
        text3.Text = ""
    End Sub

    Public Sub Pasar_A_Coleccion(ByVal Empresa_estructura() As eEmpresa, ByRef datos As Collection, ByVal i As Integer)

        datos.Add(Empresa_estructura(i).Id_Empresa)
        datos.Add(Empresa_estructura(i).Razon_Social)
        datos.Add(Empresa_estructura(i).Calle)
        datos.Add(Empresa_estructura(i).Piso)
        datos.Add(Empresa_estructura(i).Nro)
        datos.Add(Empresa_estructura(i).Localidad)
        datos.Add(Empresa_estructura(i).Codigo_Postal)
        datos.Add(Empresa_estructura(i).CUIT)
        datos.Add(Empresa_estructura(i).Ingresos_Brutos)
        datos.Add(Empresa_estructura(i).Responsabilidad_IVA)
        datos.Add(Empresa_estructura(i).Nro_Sucursal)
        datos.Add(Empresa_estructura(i).Provincia)
    End Sub

    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Empresa")
    End Sub

    Public Sub Obtener_Responsabilidad_IVA_Empresa(ByVal consulta As String, ByRef Numero_Sucursal As Integer)
        Dim conectar As New coneccion()
        Dim datos As DataTable

        datos = conectar.consulta_reader(consulta)
        Numero_Sucursal = datos.Rows(0).Item(0)

    End Sub
    Public Sub Obtener_Empresa(ByVal consulta As String, ByRef Datos As DataTable)
        Dim conectar As New coneccion()
        Datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub ObtenerUltimoNumeroEmpresa(ByVal consulta As String, ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then

            Ultimo = 1
        Else

            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub

End Class
