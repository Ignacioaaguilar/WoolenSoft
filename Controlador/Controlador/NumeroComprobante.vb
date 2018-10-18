Imports System.Windows.Forms
Imports Modelo
Public Class NumeroComprobante
    Private Shared variable As String
    Private Descripcion As String
    Private Numeracion As String
    Private Id_Empresa As Integer
    Public Structure eNumeracionComprobante
        Public Id_Comprobante As Integer
        Public Descripcion As String
        Public Numeracion As String
        Public Id_Empresa As String

    End Structure
    Public Property Compvariable() As String
        Get
            Return Me.variable
        End Get
        Set(ByVal Value As String)
            Me.variable = Value
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
    Public Property CompNumeracion() As String
        Get
            Return Me.Numeracion
        End Get
        Set(ByVal Value As String)
            Me.Numeracion = Value
        End Set
    End Property
    Public Property CompId_Empresa() As Integer
        Get
            Return Me.Id_Empresa
        End Get
        Set(ByVal Value As Integer)
            Me.Id_Empresa = Value
        End Set
    End Property

    Public Sub llenar_tabla_NumeroComprobante(ByVal cadena As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        conectar.cargar_tabla(grilla, cadena)
    End Sub

    Public Sub llenar_Combo_NumeroComprobante(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
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

   


    Public Sub Busqueda(ByRef tabla As DataGridView, ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.cargar_tabla(tabla, consulta)

    End Sub
    Public Sub recuperar_Datos(ByVal consulta As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        datos = conectar.consulta_reader(consulta)

    End Sub

    Public Sub Limpiar_Datos_NumeroComprobante(ByRef text1 As TextBox, ByRef text2 As TextBox)
        text1.Text = ""
        text2.Text = ""
    End Sub

    Public Sub Pasar_A_Coleccion(ByVal NumeracionComprobante_estructura() As eNumeracionComprobante, ByRef datos As Collection, ByVal i As Integer)

        datos.Add(NumeracionComprobante_estructura(i).Id_Comprobante)
        datos.Add(NumeracionComprobante_estructura(i).Descripcion)
        datos.Add(NumeracionComprobante_estructura(i).Numeracion)
        datos.Add(NumeracionComprobante_estructura(i).Id_Empresa)
        
    End Sub

    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Comprobante")
    End Sub
    Public Sub obtener_Numero_Comprobante(ByRef consulta As String, ByRef numero_Comprobante As String)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        datos = conectar.consulta_reader(consulta)
        numero_Comprobante = datos.Rows(0).Item(0)
    End Sub
    Public Sub obtener_Datos_Numero_Comprobante(ByRef consulta As String, ByRef Datos As DataTable)
        Dim conectar As New coneccion()

        Datos = conectar.consulta_reader(consulta)

    End Sub

    Public Sub Aumentar_Numeracion_Comprobante(ByRef numero As Integer, ByRef numeracion As String)

        Dim cont As Integer
        Dim res As Integer
        Dim cerosAIzquierda As Integer
        Dim numeros As String
        Dim i As Integer
        numeros = Convert.ToString(numero)
        'cont = 0
        'While (numero > 0)
        '    'res = numero Mod 10
        '    cont = cont + 1
        '    numero = numero / 10
        'End While

        'cerosAIzquierda = 8 - cont
        'numeracion = ""
        'For i = 1 To cerosAIzquierda
        '    numeracion = numeracion + "0"
        'Next
        'numeracion = numeracion + Convert.ToString(numeros)
        numeracion = numeros.PadLeft(8, "0"c)
    End Sub
    Public Sub ObtenerUltimoNumeroComprobante(ByVal consulta As String, ByRef Ultimo As Integer)
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
