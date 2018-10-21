Imports Modelo
Imports System.Windows.Forms
Public Class clsResponsabilidadIVA
    Public session As New Controlador.clsSession()
    Private descripcion As String
    Public Property Compdescripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(ByVal Value As String)
            Me.descripcion = Value
        End Set
    End Property
    Public Function es_Numero(ByVal valor As String) As Boolean
        If (IsNumeric(valor)) Then
            es_Numero = True
        Else
            es_Numero = False
        End If
    End Function
    Public Sub llenar_tabla_ResponsabilidadIVA(ByVal cadena As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_tabla(grilla, cadena)
    End Sub
    Public Sub llenar_Combo_ResponsabilidadIVA(ByRef combo As ComboBox, ByVal value As String, ByVal member As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select * from  Condicion_Frente_Al_IVA"
        conectar.cargar_combo(combo, consulta, value, member)
    End Sub
    Public Sub Operaciones_Tabla(ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.consulta_non_query(consulta)
    End Sub

    Public Sub Obtener_Responsabilidad_Iva_Por_Descripcion(ByVal Resp_IVA_Desc As String, ByRef Resp_IVA_ID As Integer)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim datos As New DataTable()

        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select Id_Condicion_IVA,Descripcion from  Condicion_Frente_Al_IVA where Descripcion='" & (Resp_IVA_Desc) & "'"
        datos = conectar.consulta_reader(consulta)
        Resp_IVA_ID = datos.Rows(0).Item("Id_Condicion_IVA")
    End Sub
    Public Function es_Vacio(ByVal valor As String) As Boolean
        If (valor = "") Then
            es_Vacio = True
        Else
            es_Vacio = False
        End If
    End Function
End Class
