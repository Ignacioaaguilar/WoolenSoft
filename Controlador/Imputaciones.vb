Imports System.Windows.Forms
Imports Modelo
Public Class Imputaciones
    Public session As New Controlador.Session()
    Private Shared variable As String
    Private Shared CantidadUnidades As Integer
    Private Shared Datos As DataTable
    Private Shared DataGrid As DataGridView
    Private Shared TipoComprobante As String
    Public Structure eImputaciones
        Public IdImputaciones As Integer
        Public PuntoVentaRecibo As String
        Public TipoComprobanteRecibo As String
        Public NumeroComprobanteRecibo As String
        Public Comprobante As String
        Public NumeroCliente As String
        Public Fecha As String
        Public PuntoVenta As String
        Public TipoComprobante As String
        Public NumeroComprobante As String
        Public Importe As String
        Public ID_FormaPago As String
        Public Descripcion As String
        Public Signo As String
        Public NroPuesto As String
    End Structure
    Public Property Compvariable() As String
        Get
            Return Me.variable
        End Get
        Set(ByVal Value As String)
            Me.variable = Value
        End Set
    End Property
    Public Property CompTipoComprobante() As String
        Get
            Return Me.TipoComprobante
        End Get
        Set(ByVal Value As String)
            Me.TipoComprobante = Value
        End Set
    End Property
    Public Property CompCantidadUnidades() As Integer
        Get
            Return Me.CantidadUnidades
        End Get
        Set(ByVal Value As Integer)
            Me.CantidadUnidades = Value
        End Set
    End Property
    Public Property CompDatos() As DataTable
        Get
            Return Me.Datos
        End Get
        Set(ByVal Value As DataTable)
            Me.Datos = Value
        End Set
    End Property
    Public Property CompDataGrid() As DataGridView
        Get
            Return Me.DataGrid
        End Get
        Set(ByVal Value As DataGridView)
            Me.DataGrid = Value
        End Set
    End Property
    Public Sub llenar_tabla_Imputaciones(ByVal cadena As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_tabla(grilla, cadena)
    End Sub
    Public Sub llenar_Combo_Imputaciones(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
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
    Public Sub Busqueda(ByRef tabla As DataGridView, ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_tabla(tabla, consulta)
    End Sub
    Public Sub recuperar_Datos(ByVal consulta As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub se_Cargo(ByVal consulta As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        existe = conectar.verificar_existencia(consulta)
    End Sub
    Public Sub obtenerTasa(ByVal valor As String, ByRef tasa As Double)
        tasa = (CDbl(valor) / 100) + 1
    End Sub
    Public Sub Pasar_A_Coleccion(ByVal Imputaciones_estructura() As eImputaciones, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(Imputaciones_estructura(i).IdImputaciones)
        datos.Add(Imputaciones_estructura(i).PuntoVentaRecibo)
        datos.Add(Imputaciones_estructura(i).TipoComprobanteRecibo)
        datos.Add(Imputaciones_estructura(i).NumeroComprobanteRecibo)
        datos.Add(Imputaciones_estructura(i).Comprobante)
        datos.Add(Imputaciones_estructura(i).NumeroCliente)
        datos.Add(Imputaciones_estructura(i).Fecha)
        datos.Add(Imputaciones_estructura(i).PuntoVenta)
        datos.Add(Imputaciones_estructura(i).TipoComprobante)
        datos.Add(Imputaciones_estructura(i).NumeroComprobante)
        datos.Add(Imputaciones_estructura(i).Importe)
        datos.Add(Imputaciones_estructura(i).ID_FormaPago)
        datos.Add(Imputaciones_estructura(i).Descripcion)
        datos.Add(Imputaciones_estructura(i).Signo)
        datos.Add(Imputaciones_estructura(i).NroPuesto)
    End Sub
    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("IdImputaciones")
    End Sub
    Public Sub ObtenerUltimoNumeroImputaciones(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select Max(IdImputaciones) as Maximo from Imputaciones"
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub
End Class
