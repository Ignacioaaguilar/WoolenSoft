Imports System.Windows.Forms
Imports Modelo
Public Class Transacciones
    Public session As New Controlador.Session()
    Private Shared variable As String
    Private Shared CantidadUnidades As Integer
    Private Shared Datos As DataTable
    Private Shared DataGrid As DataGridView
    Private Shared TipoComprobante As String
    Public Property Compvariable() As String
        Get
            Return Me.variable
        End Get
        Set(ByVal Value As String)
            Me.variable = Value
        End Set
    End Property
    Public Sub Operaciones_Tabla(ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.consulta_non_query(consulta)
    End Sub
    Public Sub Operaciones_Tabla_Transaccion(ByVal consulta As Collection)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.consulta_non_query_Transaccion(consulta)
    End Sub
End Class
