Imports Modelo
Imports System.Windows.Forms
Public Class Lista_Precios
    Public session As New Controlador.Session()
    Public Structure eListaPrecio
        Public Id_Lista_Precio As Integer
        Public Descripcion As String
    End Structure
    Private descripcion As String
    Public Property Compdescripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(ByVal Value As String)
            Me.descripcion = Value
        End Set
    End Property
    Public Sub llenar_tabla_ListaPrecio(ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Id_Lista_Precio as [Cod Lista Precio],Descripcion from Lista_Precio"
        conectar.cargar_tabla(grilla, consulta)
    End Sub
    Public Sub llenar_Combo_ListaPrecio(ByRef combo As ComboBox, ByVal value As String, ByVal member As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        consulta = "Select * from Lista_Precio"
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_combo(combo, consulta, value, member)
    End Sub
    Public Sub Operaciones_Tabla(ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.consulta_non_query(consulta)

    End Sub
    Public Sub recuperar_Datos_Descripcion(ByVal Desc_ListaPrecio As Integer, ByRef datosListaPrecio As eListaPrecio)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim datos As DataTable

        consulta = "Select * from Lista_Precio  where Descripcion= '" + Desc_ListaPrecio + "'"
        conectar.srt_conexion = session.Session.CadenaConeccion
        datos = conectar.consulta_reader(consulta)
        PasarDatosListaPrecioAEstructura(datos, datosListaPrecio)
    End Sub

    Public Sub recuperar_Datos(ByVal Id_ListaPrecio As Integer, ByRef datosListaPrecio As eListaPrecio)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim datos As DataTable

        consulta = "Select * from Lista_Precio where Id_Lista_Precio= " & Id_ListaPrecio & ""
        conectar.srt_conexion = session.Session.CadenaConeccion
        datos = conectar.consulta_reader(consulta)
        PasarDatosListaPrecioAEstructura(datos, datosListaPrecio)
    End Sub
    Private Sub PasarDatosListaPrecioAEstructura(ByVal datos As DataTable, ByRef datosListaPrecio As eListaPrecio)
        Dim dfielddefListaPrecio As Controlador.DfieldDef.eListaPrecio
        datosListaPrecio.Id_Lista_Precio = datos.Rows(0).Item(dfielddefListaPrecio.Id_Lista_Precio)
        datosListaPrecio.Descripcion = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion)
    End Sub

    Public Sub Limpiar_Datos_ListaPrecio(ByRef text1 As TextBox)
        text1.Text = ""
    End Sub
    Public Function es_Vacio(ByVal valor As String) As Boolean
        If (valor = "") Then
            es_Vacio = True
        Else
            es_Vacio = False
        End If
    End Function
    Public Sub Pasar_A_Coleccion(ByVal ListaPrecio_estructura() As eListaPrecio, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(ListaPrecio_estructura(i).Id_Lista_Precio)
        datos.Add(ListaPrecio_estructura(i).Descripcion)
    End Sub
    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Lista_Precio")
    End Sub
    Public Sub ObtenerUltimoNumeroListaPrecio(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
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
