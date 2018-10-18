Imports System.Windows.Forms
Imports Modelo
Public Class Articulos
    Private Shared DataGrid As DataGridView
    Private Shared variable As String
    Private Shared variable_Articulos As String
    Private Shared codigo_Articulos As String
    Private Shared Id_Producto As String
    Private Id_Rubro As String
    Private Codigo_Barras As String
    Private Shared Descripcion As String
    Private Shared Id_Proveedor As Integer
    Private Shared Id_Tasa_IVA As Integer
    Private Stock_Minimo As String
    Private Stock As String
    Private Shared Pesable As String
    Private Tipo_Unidad As String
    Private Cantidad_Unid_Caja As String
    Private Peso_Unidad As String
    Private Id_Lista_Precio As String
    Private Precio_Costo As String
    Private Rentabilidad As String
    Private Precio_Venta As String
    Private Precio_Kilo As String

    Private Shared fila As Integer
    Public Structure eArticulo
        Public Id_Producto As String
        Public Id_Rubro As String
        Public Codigo_Barras As String
        Public Descripcion As String
        Public Id_Proveedor As Integer
        Public Id_Tasa_IVA As Integer
        Public Stock_Minimo As String
        Public Stock As String
        Public Pesable As String
        Public Tipo_Unidad As String
        Public Cantidad_Unid_Caja As String
        Public Peso_Unidad As String
        Public INHABILITAR As Boolean
        Public CodProdProveedor As String
    End Structure

    Public Structure eArticuloListaPrecio
        Public Id_Lista_Precio As String
        Public Id_Producto As String
        Public DescripcionListaPrecio As String
        Public Precio_Costo As String
        Public Rentabilidad As String
        Public Precio_Venta As String
        Public Precio_Kilo As String
    End Structure

    Public Structure eArticuloEmpresa
        Public Id_Articulo As String
        Public Id_Empresa As String
    End Structure
    Public Structure eEncabezadoEntradaSalidaMercaderia
        Public Id_Entrada_Salida As Integer
        Public Fecha_Entrada_Salida As String
        Public Descripcion_Entrada_Salida As String
        Public Tipo_Movimiento As String
    End Structure
    Public Structure eCuerpoEntradaSalidaMercaderia
        Public Id_Cuerpo_Entrada_Salida As Integer
        Public Id_Entrada_Salida As Integer
        Public Tipo_Unidad As String
        Public Codigo_Barras As String
        Public Codigo_Producto As String
        Public Descripcion As String
        Public CantidadUnidades As String
    End Structure

    Public Property CompDataGrid() As DataGridView
        Get
            Return Me.DataGrid
        End Get
        Set(ByVal Value As DataGridView)
            Me.DataGrid = Value
        End Set
    End Property

    Public Property CompFila() As Integer
        Get
            Return Me.fila
        End Get
        Set(ByVal Value As Integer)
            Me.fila = Value
        End Set
    End Property
    Public Property Compvariable() As String
        Get
            Return Me.variable
        End Get
        Set(ByVal Value As String)
            Me.variable = Value
        End Set
    End Property
    Public Property Compvariable_Articulo() As String
        Get
            Return Me.variable_Articulos
        End Get
        Set(ByVal Value As String)
            Me.variable_Articulos = Value
        End Set
    End Property
    Public Property CompId_Articulo() As String
        Get
            Return Me.codigo_Articulos
        End Get
        Set(ByVal Value As String)
            Me.codigo_Articulos = Value
        End Set
    End Property

    Public Property CompId_Producto() As String
        Get
            Return Me.Id_Producto
        End Get
        Set(ByVal Value As String)
            Me.Id_Producto = Value
        End Set
    End Property
    Public Property CompId_Rubro() As String
        Get
            Return Me.Id_Rubro
        End Get
        Set(ByVal Value As String)
            Me.Id_Rubro = Value
        End Set
    End Property
    Public Property CompCodigo_Barras() As String
        Get
            Return Me.Codigo_Barras
        End Get
        Set(ByVal Value As String)
            Me.Codigo_Barras = Value
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
    Public Property CompId_Proveedor() As Integer
        Get
            Return Me.Id_Proveedor
        End Get
        Set(ByVal Value As Integer)
            Me.Id_Proveedor = Value
        End Set
    End Property
    Public Property CompId_Tasa_IVA() As Integer
        Get
            Return Me.Id_Tasa_IVA
        End Get
        Set(ByVal Value As Integer)
            Me.Id_Tasa_IVA = Value
        End Set
    End Property
    Public Property CompStock_Minimo() As String
        Get
            Return Me.Stock_Minimo
        End Get
        Set(ByVal Value As String)
            Me.Stock_Minimo = Value
        End Set
    End Property
    Public Property CompStock() As String
        Get
            Return Me.Stock
        End Get
        Set(ByVal Value As String)
            Me.Stock = Value
        End Set
    End Property
    Public Property CompPesable() As String
        Get
            Return Me.Pesable
        End Get
        Set(ByVal Value As String)
            Me.Pesable = Value
        End Set
    End Property
    Public Property CompTipo_Unidad() As String
        Get
            Return Me.Tipo_Unidad
        End Get
        Set(ByVal Value As String)
            Me.Tipo_Unidad = Value
        End Set
    End Property
    Public Property CompCantidad_Unid_Caja() As String
        Get
            Return Me.Cantidad_Unid_Caja
        End Get
        Set(ByVal Value As String)
            Me.Cantidad_Unid_Caja = Value
        End Set
    End Property
    Public Property CompPeso_Unidad() As String
        Get
            Return Me.Peso_Unidad
        End Get
        Set(ByVal Value As String)
            Me.Peso_Unidad = Value
        End Set
    End Property
    Public Property CompId_Lista_Precio() As String
        Get
            Return Me.Id_Lista_Precio
        End Get
        Set(ByVal Value As String)
            Me.Id_Lista_Precio = Value
        End Set
    End Property
    Public Property CompRentabilidad() As String
        Get
            Return Me.Rentabilidad
        End Get
        Set(ByVal Value As String)
            Me.Rentabilidad = Value
        End Set
    End Property
    Public Property CompPrecio_Costo() As String
        Get
            Return Me.Precio_Costo
        End Get
        Set(ByVal Value As String)
            Me.Precio_Costo = Value
        End Set
    End Property
    Public Property CompPrecio_Venta() As String
        Get
            Return Me.Precio_Venta
        End Get
        Set(ByVal Value As String)
            Me.Precio_Venta = Value
        End Set
    End Property
    Public Property CompPrecio_Kilo() As String
        Get
            Return Me.Precio_Kilo
        End Get
        Set(ByVal Value As String)
            Me.Precio_Kilo = Value
        End Set
    End Property
    Public Sub llenar_tabla_Articulo(ByVal cadena As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        conectar.cargar_tabla(grilla, cadena)
    End Sub

    Public Sub llenar_Combo_Articulo(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
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
    Function validateDoublesAndCurrency_Articulo(ByVal stringValue As String) As Boolean
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

    Public Sub Limpiar_Datos_Articulo(ByRef text1 As TextBox, ByRef text2 As TextBox, ByRef text3 As TextBox, ByRef text4 As TextBox, ByRef text5 As TextBox, ByRef text6 As TextBox, ByRef text7 As TextBox, ByRef text8 As TextBox, ByRef text9 As TextBox)
        text1.Text = ""
        text2.Text = ""
        text3.Text = ""
        text4.Text = ""
        text5.Text = ""
        text6.Text = ""
        text7.Text = ""
        text8.Text = ""
        text9.Text = ""
    End Sub

    Public Sub Limpiar_Datos_Articulo_Lista_Precio(ByRef text1 As TextBox, ByRef text2 As TextBox, ByRef text3 As TextBox, ByRef text4 As TextBox, ByRef text5 As TextBox)
        text1.Text = ""
        text2.Text = ""
        text3.Text = ""
        text4.Text = ""
        text5.Text = ""

    End Sub

    Public Sub Limpiar_Datos_Articulo_Lista_Precio_Precio(ByRef tbImportePrecioCosto As TextBox)
        tbImportePrecioCosto.Text = ""
    End Sub
    Public Sub Limpiar_Datos_Articulo_Lista_Precio_DataGrid(ByRef text1 As DataGridView)
        'text1.Rows.Clear()
        text1.DataSource = Nothing
    End Sub

    Public Sub Limpiar_Datos_Articulo_Empresa_DataGrid(ByRef text1 As DataGridView)
        'text1.Rows.Clear()
        text1.DataSource = Nothing
    End Sub
    Public Sub Pasar_A_Coleccion(ByVal Articulo_estructura() As eArticulo, ByRef datos As Collection, ByVal i As Integer)

        datos.Add(Articulo_estructura(i).Id_Producto)
        datos.Add(Articulo_estructura(i).Id_Rubro)
        datos.Add(Articulo_estructura(i).Codigo_Barras)
        datos.Add(Articulo_estructura(i).Descripcion)
        datos.Add(Articulo_estructura(i).Id_Proveedor)
        datos.Add(Articulo_estructura(i).Id_Tasa_IVA)
        datos.Add(Articulo_estructura(i).Stock_Minimo)
        datos.Add(Articulo_estructura(i).Stock)
        datos.Add(Articulo_estructura(i).Pesable)
        datos.Add(Articulo_estructura(i).Tipo_Unidad)
        datos.Add(Articulo_estructura(i).Cantidad_Unid_Caja)
        datos.Add(Articulo_estructura(i).Peso_Unidad)
        datos.Add(Articulo_estructura(i).INHABILITAR)
        datos.Add(Articulo_estructura(i).CodProdProveedor)
    End Sub

    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Producto")
    End Sub

    Public Sub Pasar_A_ColeccionArticuloListaPrecio(ByVal ArticuloListaPrecio_estructura() As eArticuloListaPrecio, ByRef datos As Collection, ByVal i As Integer)

        datos.Add(ArticuloListaPrecio_estructura(i).Id_Lista_Precio)
        datos.Add(ArticuloListaPrecio_estructura(i).Id_Producto)
        datos.Add(ArticuloListaPrecio_estructura(i).DescripcionListaPrecio)
        datos.Add(ArticuloListaPrecio_estructura(i).Precio_Costo)
        datos.Add(ArticuloListaPrecio_estructura(i).Rentabilidad)
        datos.Add(ArticuloListaPrecio_estructura(i).Precio_Venta)
        datos.Add(ArticuloListaPrecio_estructura(i).Precio_Kilo)

    End Sub

    Public Sub Obtener_Clave_PrincipalListaPrecio(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Lista_Precio")
        Clave_Princ.Add("Id_Producto")
    End Sub

    Public Sub Pasar_A_ColeccionArticuloEmpresa(ByVal ArticuloLEmpresa_estructura() As eArticuloEmpresa, ByRef datos As Collection, ByVal i As Integer)

        datos.Add(ArticuloLEmpresa_estructura(i).Id_Articulo)
        datos.Add(ArticuloLEmpresa_estructura(i).Id_Empresa)
    End Sub

    Public Sub Obtener_Clave_PrincipalArticuloEmpresa(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Articulo")
        Clave_Princ.Add("Id_Empresa")
    End Sub

    Public Sub Obtener_Clave_PrincipalCuerpoEntradaSalidaMercaderia(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Entrada_Salida")
    End Sub
    Public Sub Obtener_Clave_PrincipalEncabezadoEntradaSalidaMercaderia(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Cuerpo_Entrada_Salida")
        Clave_Princ.Add("Id_Entrada_Salida")
    End Sub
    Public Sub Pasar_A_ColeccionEncabezadoEntradaSalidaMercaderia(ByVal EncabezadoEntradaSalidaMercaderia_estructura() As eEncabezadoEntradaSalidaMercaderia, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(EncabezadoEntradaSalidaMercaderia_estructura(i).Id_Entrada_Salida)
        datos.Add(EncabezadoEntradaSalidaMercaderia_estructura(i).Fecha_Entrada_Salida)
        datos.Add(EncabezadoEntradaSalidaMercaderia_estructura(i).Descripcion_Entrada_Salida)
        datos.Add(EncabezadoEntradaSalidaMercaderia_estructura(i).Tipo_Movimiento)
    End Sub
    Public Sub Pasar_A_ColeccionCuerpoEntradaSalidaMercaderia(ByVal CuerpoEntradaSalidaMercaderia_estructura() As eCuerpoEntradaSalidaMercaderia, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(CuerpoEntradaSalidaMercaderia_estructura(i).Id_Cuerpo_Entrada_Salida)
        datos.Add(CuerpoEntradaSalidaMercaderia_estructura(i).Id_Entrada_Salida)
        datos.Add(CuerpoEntradaSalidaMercaderia_estructura(i).Tipo_Unidad)
        datos.Add(CuerpoEntradaSalidaMercaderia_estructura(i).Codigo_Barras)
        datos.Add(CuerpoEntradaSalidaMercaderia_estructura(i).Codigo_Producto)
        datos.Add(CuerpoEntradaSalidaMercaderia_estructura(i).Descripcion)
        datos.Add(CuerpoEntradaSalidaMercaderia_estructura(i).CantidadUnidades)
    End Sub
    Public Sub ObtenerUltimoNumero(ByVal consulta As String, ByRef Ultimo As Integer)
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
