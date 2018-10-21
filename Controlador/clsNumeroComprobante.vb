Imports System.Windows.Forms
Imports Modelo
Public Class clsNumeroComprobante
    Public session As New Controlador.clsSession()
    Private Shared variable As String
    Private Descripcion As String
    Private Numeracion As String
    Private Id_Empresa As Integer
    Public Structure eNumeracionComprobante
        Public Id_Comprobante As Integer
        Public Descripcion As String
        Public Numeracion As String
        Public Id_Empresa As String
        Public Id_Tipo_Comprobante As String
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
    Public Sub llenar_tabla_NumeroComprobante_Empresa(ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = " select Id_Comprobante as [Cod Comprobante],Descripcion,Numeracion,NC.Id_Empresa as [Cod Empresa],E.Razon_Social as [Nom Empresa] from Numeracion_Comprobante as NC" & vbCrLf
        consulta += "inner join Empresa as E on E.Id_Empresa =NC.Id_Empresa" & vbCrLf
        consulta += "order by NC.Id_Empresa, Id_Comprobante"
        conectar.cargar_tabla(grilla, consulta)
    End Sub
    Public Sub llenar_tabla_NumeroComprobante(ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Id_Comprobante as [Cod Comprobante],Descripcion,Numeracion,Id_Empresa as [Cod Empresa] from Numeracion_Comprobante"
        conectar.cargar_tabla(grilla, consulta)
    End Sub

    Public Sub llenar_Combo_NumeroComprobante(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_combo(combo, cadena, value, member)
    End Sub
    Public Sub Operaciones_Tabla_NumeroComprobante(ByVal Id_Empresa As String, ByVal Operacion As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        If (Operacion = clsDfieldDef.eConstantes.Eliminar_Empresa.ToString()) Then
            consulta = "delete from Numeracion_Comprobante where Id_Empresa='" & (Id_Empresa) & "'"
        End If
        conectar.consulta_non_query(consulta)
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
    Public Sub Busqueda(ByRef tabla As DataGridView, ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_tabla(tabla, consulta)
    End Sub
    Public Sub Busqueda_by_NombreColumna(ByRef tabla As DataGridView, ByVal Nombre_Columna_a_Buscar As String, ByVal Busqueda As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Id_Comprobante as [Cod Comprobante],Descripcion,Numeracion,Id_Empresa as [Cod Empresa] from Numeracion_Comprobante where " + Nombre_Columna_a_Buscar + " like '" & Busqueda & "%'"
        conectar.cargar_tabla(tabla, consulta)
    End Sub
    Public Sub recuperar_Datos(ByVal consulta As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
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
        datos.Add(NumeracionComprobante_estructura(i).Id_Tipo_Comprobante)
    End Sub
    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Comprobante")
    End Sub
    Public Sub obtener_Numero_Comprobante(ByRef IdEmpresa As String, ByRef IdTipoComprobante As Integer, ByRef numero_Comprobante As String)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Numeracion from  Numeracion_Comprobante  where Id_Empresa='" + IdEmpresa + "' and Id_Tipo_Comprobante = '" & Convert.ToString(IdTipoComprobante) & "'"
        datos = conectar.consulta_reader(consulta)
        numero_Comprobante = datos.Rows(0).Item(0)
    End Sub
    Public Sub obtener_Datos_Numero_Comprobante(ByVal tipoComprobante As String, ByVal Id_Empresa As String, ByRef Datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select *from Numeracion_Comprobante  where Descripcion= '" + tipoComprobante + "'and Id_Empresa= '" + Id_Empresa + "'"
        Datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub obtener_Datos_Numero_Comprobante_Descripcion_Comprobante(ByVal descripcion As String, ByRef Datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select IdTipoComprobante from Tipos_Comprobantes where Descripcion = '" + UCase(descripcion) + "'"
        Datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub obtener_Datos_Numero_Comprobante_Tipo_Comprobante(ByVal idEmpresa As String, ByVal idTipoComprobante As String, ByRef Datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Id_Comprobante,Descripcion, Numeracion,Id_Empresa,Id_Tipo_Comprobante from Numeracion_Comprobante   where Id_Empresa='" + idEmpresa + "' and Id_Tipo_Comprobante = '" & idTipoComprobante & "'"
        Datos = conectar.consulta_reader(consulta)
    End Sub

    Public Sub obtener_Datos_Numero_Comprobante_Empresa_TipoComprobante(ByVal idEmpresa As String, ByVal idTipoComprobante As String, ByRef Datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Id_Comprobante,Descripcion, Numeracion,Id_Empresa,Id_Tipo_Comprobante from Numeracion_Comprobante  where Id_Empresa='" + idEmpresa + "' and Id_Tipo_Comprobante = '" & idTipoComprobante & "'"
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
    Public Sub ObtenerUltimoNumeroComprobante(ByVal tipoComprobante As String, ByVal idEmpresa As String, ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select max( Numeracion )from Numeracion_Comprobante  where Descripcion= '" + tipoComprobante + "'and Id_Empresa= '" + idEmpresa + "'"
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub

    Public Sub ObtenerUltimoNumeroComprobanteEmpresa(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select max(Id_Comprobante) from .Numeracion_Comprobante "
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub
End Class
