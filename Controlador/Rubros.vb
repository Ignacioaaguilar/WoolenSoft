Imports Modelo
Imports System.Windows.Forms
Public Class Rubros
    Public session As New Controlador.Session()
    Private codigo As String
    Private descripcion As String
    Public Structure eRubro
        Public Id_Rubro As String
        Public Descripcion As String
    End Structure
    Public Property CompCodigo() As Integer
        Get
            Return Me.codigo
        End Get
        Set(ByVal Value As Integer)
            Me.codigo = Value
        End Set
    End Property
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
    Public Sub llenar_tabla_Rubros(ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Id_Rubro as [cod Rubro],Descripcion from rubro"
        conectar.cargar_tabla(grilla, consulta)
    End Sub

    Public Sub llenar_Combo_Rubros(ByRef combo As ComboBox, ByVal value As String, ByVal member As String, Optional ByVal idRubro As String = Nothing)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from  rubro "
        If (idRubro <> Nothing) Then
            consulta += "where Id_Rubro='" + idRubro + "'"
        End If
        conectar.cargar_combo(combo, consulta, value, member)
    End Sub

    Public Sub Operaciones_Tabla(ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.consulta_non_query(consulta)
    End Sub
    Public Sub se_Cargo(ByVal CodigoRubro As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from rubro where Id_Rubro='" & (CodigoRubro) & "' "
        existe = conectar.verificar_existencia(consulta)
    End Sub

    Public Sub Limpiar_Datos_Rubro(ByRef text1 As TextBox, ByRef text2 As TextBox)
        text1.Text = ""
        text2.Text = ""
    End Sub
    Public Sub recuperar_All_Datos(ByRef datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "SELECT Id_Rubro,Descripcion FROM Rubro"
        datos = conectar.consulta_reader(consulta)
    End Sub

    Public Sub recuperar_Datos(ByVal IdRubro As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from rubro  where Id_Rubro='" & (IdRubro) & "' "
        datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub Pasar_A_Coleccion(ByVal Rubro_estructura() As eRubro, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(Rubro_estructura(i).Id_Rubro)
        datos.Add(Rubro_estructura(i).Descripcion)
    End Sub
    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Rubro")
    End Sub
    Public Sub ObtenerUltimoNumeroRubro(ByVal consulta As String, ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        conectar.srt_conexion = session.Session.CadenaConeccion
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub
End Class
