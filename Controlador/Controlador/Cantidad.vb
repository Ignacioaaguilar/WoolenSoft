Imports System.Windows.Forms
Imports Modelo
Public Class Cantidad
    Private Shared variable As String
    Private Shared CantidadUnidades As Integer
    Private Shared Datos As DataTable
    Private Shared DataGrid As DataGridView
    Private Shared TipoComprobante As String
    
    'Public Structure eEmpresa
    '    Public Id_Empresa As Integer
    '    Public Razon_Social As String
    '    Public Calle As String
    '    Public Piso As String
    '    Public Nro As String
    '    Public Localidad As String
    '    Public Codigo_Postal As String
    '    Public CUIT As String
    '    Public Ingresos_Brutos As String
    '    Public Responsabilidad_IVA As String
    '    Public Nro_Sucursal As String
    '    Public Provincia As String

    'End Structure
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

    Public Sub Busqueda(ByRef tabla As DataGridView, ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.cargar_tabla(tabla, consulta)


    End Sub
    Public Sub recuperar_Datos(ByVal consulta As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        datos = conectar.consulta_reader(consulta)


    End Sub

    Public Sub se_Cargo(ByVal consulta As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        existe = conectar.verificar_existencia(consulta)

    End Sub
    Public Sub obtenerTasa(ByVal valor As String, ByRef tasa As Double)
        tasa = (CDbl(valor) / 100) + 1
    End Sub
    
End Class
