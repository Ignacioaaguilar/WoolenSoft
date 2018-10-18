Imports Modelo
Imports System.Windows.Forms
Public Class TasaIVA
    Public session As New Controlador.Session()
    Public Shared Descripcion As String

    Public Structure eTasaIVA
        Public Id_Tasa_IVA As String
        Public Descripcion As String
        Public Tasa As String
    End Structure
    Private tasa As String
    Public Property CompTasa() As String
        Get
            Return Me.tasa
        End Get
        Set(ByVal Value As String)
            Me.tasa = Value
        End Set
    End Property
    Public Property CompDescripcion() As String
        Get
            Return Me.Descripcion
        End Get
        Set(ByVal Value As String)
            Me.Descripcion = Value
        End Set
    End Property
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
    Public Sub llenar_tabla_TasaIVA(ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select Id_Tasa_IVA as [Cod Tasa IVA],Descripcion,Tasa from Tasa_IVA"
        conectar.cargar_tabla(grilla, consulta)
    End Sub
    Public Sub llenar_Combo_TasaIVA(ByRef combo As ComboBox, ByVal value As String, ByVal member As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from Tasa_IVA"
        conectar.cargar_combo(combo, consulta, value, member)
    End Sub
    Public Sub Operaciones_Tabla(ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.consulta_non_query(consulta)
    End Sub
    Public Sub se_Cargo(ByVal consulta As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        existe = conectar.verificar_existencia(consulta)
    End Sub
    Public Sub recuperar_All_Datos(ByRef datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select * " & vbCrLf
        consulta += "From Tasa_IVA"

        datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub recuperar_Datos_Descripcion(ByVal Descripcion As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String

        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select * from Tasa_IVA where Descripcion ='" & Descripcion & "'"

        datos = conectar.consulta_reader(consulta)
    End Sub

    Public Sub recuperar_Datos(ByVal tasaIVA As Integer, ByRef datos As DataTable, Optional ByVal Descripcion As String = Nothing)
        Dim conectar As New coneccion()
        Dim consulta As String

        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select * from Tasa_IVA where Id_Tasa_IVA=" & tasaIVA & "  "
        If Descripcion <> Nothing Then
            consulta += "and Descripcion ='" & Descripcion & "'"
        End If

        datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub Limpiar_Datos_TasaIVA(ByRef text1 As TextBox, ByRef text2 As TextBox)
        text1.Text = ""
        text2.Text = ""
    End Sub
    Public Sub Pasar_A_Coleccion(ByVal tasaiva_estructura() As TasaIVA.eTasaIVA, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(tasaiva_estructura(i).Id_Tasa_IVA)
        datos.Add(tasaiva_estructura(i).Descripcion)
        datos.Add(tasaiva_estructura(i).Tasa)
    End Sub
    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Tasa_IVA")
    End Sub
    Public Sub ObtenerUltimoNumeroTasaIVA(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "max(Id_Tasa_IVA) from Tasa_IVA"
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub
    Public Sub obtenerTasaIva(ByVal SubTotal As String, ByVal tasa As String, ByRef TIVA As Double)
        TIVA = ((SubTotal * tasa) / 100)
    End Sub
End Class
