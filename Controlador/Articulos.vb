Imports System.Windows.Forms
Imports System.IO
Imports Modelo
Public Class Articulos
    Public session As New Controlador.Session()
    Private Shared DataGrid As DataGridView
    Private Shared variable As String
    Private Shared variable_Articulos As String
    Private Shared variable_CargarArticulo As String
    Private Shared codigo_Articulos As String
    Private Shared Id_Producto As String
    Public Shared busquedaComprobante As String
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
        Public Id_Proveedor As String
        Public Id_Tasa_IVA As String
        Public Tasa_IVA As String
        Public Stock_Minimo As String
        Public Stock As String
        Public Pesable As String
        Public Tipo_Unidad As String
        Public Cantidad_Unid_Caja As String
        Public Peso_Unidad As String
        Public INHABILITAR As Boolean
        Public CodProdProveedor As String
    End Structure
    Public Structure eArticuloCuerpoDocumento
        Public IdProducto As String
        Public IdRubro As String
        Public Codigo_Barras As String
        Public Descripcion As String
        Public Id_Proveedor As String
        Public IdTasaIVa As String
        Public TasaIVa As String
        Public StockMinimo As String
        Public Stock As String
        Public Pesable As String
        Public TipoUnidad As String
        Public CantidadUnidadCaja As String
        Public PesoUnidad As String
        Public INABILITAR As String
        Public CodProdProveedor As String
        Public IdListaPrecio As String
        Public DescListaPrecio As String
        Public PrecioCosto As String
        Public Rentabilidad As String
        Public PrecioVenta As String
        Public PrecioKilo As String
        Public cantidad As Integer
        Public Importe As Double
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
    Public Structure eProductoListaPrecios
        Public Id_Lista_Precio As String
        Public Id_Producto As Integer
        Public DescripcionListaPrecio As String
        Public Precio_Costo As String
        Public Rentabilidad As String
        Public Precio_Venta As String
        Public Precio_Kilo As String
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
    Public Property CompvariableCargarArticulo() As String
        Get
            Return Me.variable_CargarArticulo
        End Get
        Set(ByVal Value As String)
            Me.variable_CargarArticulo = Value
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
    
    Public Sub llenar_tabla_Producto_EmpresaArticulo_Producto_Lista_Precio(ByVal idEmpresa As String, ByVal idListaPrecio As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = " select P.Id_Producto as [Cod Producto],Id_Rubro as  [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as [Stock Minimo],Stock,Pesable,Tipo_Unidad as [Tipo Unidad],Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as [Cod Prod Proveedor] " & vbCrLf
        consulta += "  from ((Producto as P" & vbCrLf
        consulta += " inner join EmpresaArticulo as EA on P.Id_Producto=EA.Id_Articulo)" & vbCrLf
        consulta += " inner join Producto_Lista_Precio as PLP on P.Id_Producto = PLP.Id_Producto)  " & vbCrLf
        consulta += " where(INHABILITAR = 0)" & vbCrLf
        consulta += " and  EA.Id_Empresa='" + idEmpresa + "' and PLP.ID_Lista_Precio='" + idListaPrecio + "'"
        conectar.cargar_tabla(grilla, consulta)
    End Sub


    Public Sub llenar_tabla_EmpresaArticulo_Empresa(ByVal idProducto As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select Id_Articulo as [Cod Articulo],EA.Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Codigo Postal],CUIT " & vbCrLf
        consulta += "from (EmpresaArticulo as EA " & vbCrLf
        consulta += "inner join Empresa as E on  E.Id_Empresa=EA.Id_Empresa) " & vbCrLf
        consulta += "where Id_Articulo='" & (idProducto) & "' "
        conectar.cargar_tabla(grilla, consulta)
    End Sub

    Public Sub llenar_tabla_Producto_Lista_Precios_Lista_Precio(ByVal idProducto As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = " Select plp.Id_Lista_Precio as[Cod Lista Precio],lp.Descripcion,Id_Producto as [Cod Producto],Precio_Costo as [Precio Costo],Rentabilidad,Precio_Venta as [Precio Venta],Precio_Kilo as [Precio Kilo]  " & vbCrLf
        consulta += " from (Producto_Lista_Precio as  plp" & vbCrLf
        consulta += " inner join  Lista_Precio as  lp on (Cint(plp.Id_Lista_Precio)=lp.Id_Lista_Precio))" & vbCrLf
        consulta += " where Id_Producto='" & (idProducto) & "'" & vbCrLf
        conectar.cargar_tabla(grilla, consulta)
    End Sub

    Public Sub llenar_tabla_Producto_Lista_Precio_Lista_Precio(ByRef grilla As DataGridView, ByVal IdPrducto As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = " Select plp.Id_Lista_Precio as [Cod Lista Precio],lp.Descripcion,Id_Producto as [Cod Producto],Precio_Costo as [Precio Costo],Rentabilidad,Precio_Venta as [Precio Venta],Precio_Kilo as [Precio Kilo]  " & vbCrLf
        consulta += "from Producto_Lista_Precio as  plp" & vbCrLf
        consulta += "inner join  Lista_Precio as  lp on (Cint(plp.Id_Lista_Precio)=lp.Id_Lista_Precio)" & vbCrLf
        consulta += "where Id_Producto='" & IdPrducto & "' " & vbCrLf
        conectar.cargar_tabla(grilla, consulta)
    End Sub
    Public Sub llenar_tabla_Articulo(ByRef grilla As DataGridView, Optional ByVal nombreColumnaABuscar As String = Nothing, Optional ByVal BusquedaArticulo As String = Nothing)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Id_Producto as [Cod Producto],Id_Rubro as [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as[Stock Minimo] ,Stock,Pesable,Tipo_Unidad as[Tipo Unidad],Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as[Cod Prod Proveedor] from Producto  "
        If nombreColumnaABuscar <> Nothing And BusquedaArticulo <> Nothing Then
            consulta += " where " + nombreColumnaABuscar + " like '" & BusquedaArticulo & "%' "
        End If
        conectar.cargar_tabla(grilla, consulta)
    End Sub
    Public Sub llenar_tabla_Producto_Empresa_Articulo(ByVal IdEmpresa As String, ByRef grilla As DataGridView, Optional ByVal nombreColumnaABuscar As String = Nothing, Optional ByVal BusquedaArticulo As String = Nothing)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = " select Id_Producto as [Cod Producto],Id_Rubro as [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as[Stock Minimo] ,Stock,Pesable,Tipo_Unidad as[Tipo Unidad] ,Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as[Cod Prod Proveedor] " & vbCrLf
        consulta += " from (Producto as P " & vbCrLf
        consulta += " inner join EmpresaArticulo as EA on  P.Id_Producto=EA.Id_Articulo)" & vbCrLf
        consulta += " where INHABILITAR=0 and  EA.Id_Empresa='" + IdEmpresa + "'"

        If nombreColumnaABuscar <> Nothing And BusquedaArticulo <> Nothing Then
            consulta += " and  " + nombreColumnaABuscar + " like '" & BusquedaArticulo & "%'"
        End If
        conectar.cargar_tabla(grilla, consulta)
    End Sub
    Public Sub llenar_tabla_Producto_EmpresaArticulo_Producto_Lista_Precio(ByVal idProveedor As String, ByVal idEmpresa As String, ByVal idListaPrecio As String, ByRef grilla As DataGridView, Optional ByVal nombreColumnaABuscar As String = Nothing, Optional ByVal BusquedaArticulo As String = Nothing)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = " select P.Id_Producto as [Cod Producto],Id_Rubro as [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as [Stock Minimo],Stock,Pesable,Tipo_Unidad as [Tipo Unidad],Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as [Cod Prod Proveedor]" & vbCrLf
        consulta += " from ((Producto as P" & vbCrLf
        consulta += " inner join EmpresaArticulo as EA on P.Id_Producto=EA.Id_Articulo )" & vbCrLf
        consulta += " inner join Producto_Lista_Precio as PLP on  P.Id_Producto = PLP.Id_Producto ) " & vbCrLf
        consulta += " where(INHABILITAR = 0)" & vbCrLf
        consulta += " and P.Id_Proveedor= '" + idProveedor + "'  " & vbCrLf
        consulta += " and EA.Id_Empresa='" + idEmpresa + "' " & vbCrLf
        consulta += " and PLP.ID_Lista_Precio='" + idListaPrecio + "' " & vbCrLf


        If nombreColumnaABuscar <> Nothing And BusquedaArticulo <> Nothing Then
            consulta += " and  " + nombreColumnaABuscar + "  like '" & BusquedaArticulo & "%' " ' "
        End If
        conectar.cargar_tabla(grilla, consulta)
    End Sub

    Public Sub llenar_tabla_Empresa_Articulo(ByVal IdCodProducto As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = " Select Id_Articulo as [Cod Articulo],EA.Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as[Codigo Postal],CUIT " & vbCrLf
        consulta += " from EmpresaArticulo as EA" & vbCrLf
        consulta += " inner join Empresa  as E on   E.Id_Empresa=EA.Id_Empresa " & vbCrLf
        consulta += " where Id_Articulo='" & (IdCodProducto) & "'  "
        conectar.cargar_tabla(grilla, consulta)
    End Sub
    Public Sub llenar_Combo_Articulo(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_combo(combo, cadena, value, member)
    End Sub
    Public Sub llenar_Combo_ProductoListaPrecioALL(ByRef combo As ComboBox, ByVal value As String, ByVal member As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select distinct Id_Lista_Precio,DescripcionListaPrecio from Producto_Lista_Precio"
        conectar.cargar_combo(combo, consulta, value, member)
    End Sub
    Public Sub llenar_Combo_ProductoListaPrecio_Producto(ByRef combo As ComboBox, ByVal value As String, ByVal member As String, ByVal idListaPrecio As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = " select PLP.Id_Producto,Descripcion " & vbCrLf
        consulta += " from (Producto_Lista_Precio as PLP " & vbCrLf
        consulta += " inner join Producto  as P on  PLP.Id_Producto=P.Id_Producto )" & vbCrLf
        consulta += " where PLP.ID_Lista_Precio='" + idListaPrecio + "' " & vbCrLf
        consulta += " order by PLP.Id_Producto "
        conectar.cargar_combo(combo, consulta, value, member)
    End Sub
    Public Sub Operaciones_Tabla(ByVal idempresa As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Update" & vbCrLf
        consulta += " (Producto as p" & vbCrLf
        consulta += "inner join EmpresaArticulo as EA on P.Id_Producto=EA.Id_Articulo)" & vbCrLf
        consulta += " set Stock = 0" & vbCrLf
        consulta += "where EA.Id_Empresa='" + idempresa + "'"
        conectar.consulta_non_query(consulta)
    End Sub

    Public Sub Operaciones_QueryBuilder(ByVal Consulta As String)
        Dim conectar As New coneccion()

        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.consulta_non_query(consulta)
    End Sub
    Public Function es_Vacio(ByVal valor As String) As Boolean
        If (valor = String.Empty) Then
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
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_tabla(tabla, consulta)
    End Sub
    Public Sub ObtenerProductos(ByVal idProducto As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String

        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select * from  Producto where Id_Producto='" + idProducto + "'"
        datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub recuperar_Datos_Producto_EmpresaArticulo(ByVal IdProducto As String, ByVal DatoEmpresa As String, ByRef DatosEmpresaArticulo As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim datos As DataTable

        consulta = " select P.Id_Tasa_IVA, P.Tipo_Unidad,P.Id_Producto,P.Codigo_Barras ,P.Descripcion,P.Cod_Prod_Proveedor " & vbCrLf
        consulta += " from(Producto as P" & vbCrLf
        consulta += " inner join EmpresaArticulo as EA on EA.Id_Articulo=P.Id_Producto )" & vbCrLf
        consulta += " where(P.INHABILITAR = 0)" & vbCrLf
        consulta += " and ((P.Id_Producto ='" + IdProducto + "'))  " & vbCrLf
        consulta += " and EA.Id_Empresa='" + DatoEmpresa + "'  "

        conectar.srt_conexion = session.Session.CadenaConeccion
        DatosEmpresaArticulo = conectar.consulta_reader(consulta)
        
    End Sub
    Public Sub recuperar_Datos_Producto_EmpresaArticulo_Descripcion(ByVal DescripcionProd As String, ByVal DatoEmpresa As String, ByRef DatosEmpresaArticulo As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim datos As DataTable

        consulta = "   select P.Id_Tasa_IVA,P.Tipo_Unidad,P.Id_Producto,P.Descripcion,P.Codigo_Barras ,P.Cod_Prod_Proveedor " & vbCrLf
        consulta += "  from (producto as P" & vbCrLf
        consulta += "  inner join EmpresaArticulo as EA on EA.Id_Articulo=P.Id_Producto )" & vbCrLf
        consulta += "  where(P.INHABILITAR = 0)" & vbCrLf
        consulta += "  and P.Descripcion = '" + (DescripcionProd) + "'" & vbCrLf
        consulta += "  and EA.Id_Empresa='" + DatoEmpresa + "' " & vbCrLf

        conectar.srt_conexion = session.Session.CadenaConeccion
        DatosEmpresaArticulo = conectar.consulta_reader(consulta)

    End Sub

    Public Sub recuperar_Datos(ByVal IdProductoListaPrecio As Integer, ByVal IdProducto As String, ByRef DatosArticuloCuerpoFactura As eArticuloCuerpoDocumento)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim datos As DataTable

        consulta = " select *" & vbCrLf
        consulta += "from (Producto as P" & vbCrLf
        consulta += "Inner join Producto_Lista_Precio as PLP on P.Id_Producto=PLP.Id_Producto)" & vbCrLf
        consulta += "where PLP.Id_Lista_Precio='" + IdProductoListaPrecio.ToString() + "'" & vbCrLf
        consulta += "and P.Id_Producto='" & (IdProducto) & "' or P.Codigo_Barras= '" & (IdProducto) & "'" & vbCrLf

        conectar.srt_conexion = session.Session.CadenaConeccion
        datos = conectar.consulta_reader(consulta)
        If datos.Rows.Count > 0 Then
            PasarDatosArticulosCuerpoFacturaAEstructura(datos, DatosArticuloCuerpoFactura)
        End If
    End Sub
    Public Sub recuperar_Datos_Producto_Lista_Precio(ByVal IdListaPrecio As String, ByRef Datos As DataTable, Optional ByVal RangoArtDesde As String = Nothing, Optional ByVal RangoArtHasta As String = Nothing)
        Dim conectar As New coneccion()
        Dim consulta As String

        consulta = " select * from Producto_Lista_Precio where Id_Lista_Precio='" + IdListaPrecio + "'"

        If RangoArtDesde <> Nothing And RangoArtHasta <> Nothing Then
            consulta += "and Id_Producto>='" + RangoArtDesde + "' and Id_Producto<='" + RangoArtHasta + "'"
        End If
        conectar.srt_conexion = session.Session.CadenaConeccion
        Datos = conectar.consulta_reader(consulta)

    End Sub

    Public Sub recuperar_Datos_Producto_Producto_Lista_Precio_EmpresaArticulo(ByVal idProveedor As String, ByVal IdListaPrecio As String, ByVal idProducto As String, ByVal idEmpresa As String, ByRef DatosArticuloCuerpoFactura As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String


        consulta = " select P.Id_Tasa_IVA, P.Tipo_Unidad,P.Id_Producto,P.Descripcion,PLP.Precio_Costo,PLP.DescripcionListaPrecio,P.Cod_Prod_Proveedor " & vbCrLf
        consulta += " from(((Producto as P" & vbCrLf
        consulta += " Inner join Producto_Lista_Precio as PLP on P.Id_Producto=PLP.Id_Producto )" & vbCrLf
        consulta += " inner join EmpresaArticulo as EA on EA.Id_Articulo=P.Id_Producto ))" & vbCrLf
        consulta += " where(P.INHABILITAR = 0)" & vbCrLf
        consulta += " and P.Id_Producto = PLP.Id_Producto " & vbCrLf
        consulta += " and P.Id_Proveedor='" + idProveedor + "' " & vbCrLf
        consulta += " and PLP.ID_Lista_Precio='" + IdListaPrecio + "'" & vbCrLf
        consulta += " and ((P.Id_Producto ='" + idProducto + "')or (P.Cod_Prod_Proveedor='" + idProducto + "'))  " & vbCrLf
        consulta += " and EA.Id_Empresa='" + idEmpresa + "'  "

        conectar.srt_conexion = session.Session.CadenaConeccion
        DatosArticuloCuerpoFactura = conectar.consulta_reader(consulta)

    End Sub
    Public Sub recuperar_Datos_Producto_Producto_Lista_Precio_EmpresaArticulo_Descripcion(ByVal idProveedor As String, ByVal IdListaPrecio As String, ByVal DescProducto As String, ByVal idEmpresa As String, ByRef DatosArticuloCuerpoFactura As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String

        consulta = "   select P.Id_Tasa_IVA,P.Tipo_Unidad,P.Id_Producto,P.Descripcion,PLP.Precio_Costo,PLP.DescripcionListaPrecio,P.Cod_Prod_Proveedor " & vbCrLf
        consulta += "  from (((producto as P" & vbCrLf
        consulta += "  Inner join Producto_Lista_Precio as PLP on P.Id_Producto=PLP.Id_Producto  )" & vbCrLf
        consulta += "  inner join EmpresaArticulo as EA on EA.Id_Articulo=P.Id_Producto ))" & vbCrLf
        consulta += "  where(P.INHABILITAR = 0)" & vbCrLf
        consulta += "  and P.Id_Proveedor='" + idProveedor + "' " & vbCrLf
        consulta += "  and PLP.ID_Lista_Precio='" + IdListaPrecio + "' " & vbCrLf
        consulta += "  and P.Descripcion = '" + DescProducto + "'" & vbCrLf
        consulta += "  and P.Id_Proveedor= '" + idProveedor + "'  and EA.Id_Empresa='" + idEmpresa + "' " & vbCrLf

        conectar.srt_conexion = session.Session.CadenaConeccion
        DatosArticuloCuerpoFactura = conectar.consulta_reader(consulta)

    End Sub

    Public Sub recuperar_Datos_Producto_EntradaSalidaMercaderia(ByVal Codigo_Producto As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from Producto    where Id_Producto= '" & Codigo_Producto & "'"
        datos = conectar.consulta_reader(consulta)

    End Sub
    Private Sub PasarDatosArticulosCuerpoFacturaAEstructura(ByVal datos As DataTable, ByRef DatosArticuloCuerpoFactura As eArticuloCuerpoDocumento)
        Dim dfielddefArticuloListaPrecio As Controlador.DfieldDef.eArticuloCuerpoDocumento
        DatosArticuloCuerpoFactura.CantidadUnidadCaja = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Cantidad_Unid_Caja)
        DatosArticuloCuerpoFactura.CodProdProveedor = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Cod_Prod_Proveedor)
        DatosArticuloCuerpoFactura.Codigo_Barras = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Codigo_Barras)
        DatosArticuloCuerpoFactura.DescListaPrecio = datos.Rows(0).Item(dfielddefArticuloListaPrecio.DescripcionListaPrecio)
        DatosArticuloCuerpoFactura.Descripcion = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion)
        DatosArticuloCuerpoFactura.INABILITAR = datos.Rows(0).Item(dfielddefArticuloListaPrecio.INHABILITAR)
        DatosArticuloCuerpoFactura.IdListaPrecio = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Lista_Precio)
        DatosArticuloCuerpoFactura.IdProducto = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto)
        DatosArticuloCuerpoFactura.IdRubro = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Rubro)
        DatosArticuloCuerpoFactura.IdTasaIVa = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Tasa_IVA)
        DatosArticuloCuerpoFactura.TasaIVa = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tasa_IVA)
        DatosArticuloCuerpoFactura.Id_Proveedor = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Proveedor)
        DatosArticuloCuerpoFactura.Pesable = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Pesable)
        DatosArticuloCuerpoFactura.PesoUnidad = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Peso_Unidad)
        DatosArticuloCuerpoFactura.PrecioCosto = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Costo)
        DatosArticuloCuerpoFactura.PrecioKilo = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Kilo)
        DatosArticuloCuerpoFactura.PrecioVenta = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta)
        DatosArticuloCuerpoFactura.Rentabilidad = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Rentabilidad)
        DatosArticuloCuerpoFactura.Stock = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Stock)
        DatosArticuloCuerpoFactura.StockMinimo = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Stock_Minimo)
        DatosArticuloCuerpoFactura.TipoUnidad = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad)

    End Sub
    Public Sub se_Cargo(ByVal idProducto As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select * from .Producto where Id_Producto='" & idProducto & "'"
        existe = conectar.verificar_existencia(consulta)
    End Sub


    Public Sub se_Cargo_articulo(ByVal idArticulo As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim Consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        Consulta = "select * from Producto where Id_Producto='" & (idArticulo) & "'"
        existe = conectar.verificar_existencia(Consulta)
    End Sub
    Public Sub se_CargoEmpresaArticulo(ByVal IdArticulo As String, ByVal IdEmpresa As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from  EmpresaArticulo where Id_Articulo='" & (IdArticulo) & "' and Id_Empresa ='" & (IdEmpresa) & "'"
        existe = conectar.verificar_existencia(consulta)
    End Sub
    Public Sub se_CargoProducto_Lista_Precio(ByVal ListaPrecios As String, ByVal IdProducto As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select * from Producto_Lista_Precio where Id_Lista_Precio='" & ListaPrecios & "' and Id_Producto='" & IdProducto & "'"
        existe = conectar.verificar_existencia(consulta)
    End Sub


    Public Sub Limpiar_Datos_Articulo(ByRef text1 As TextBox, ByRef text2 As TextBox, ByRef text3 As TextBox, ByRef text4 As TextBox, ByRef text5 As TextBox, ByRef text6 As TextBox, ByRef text7 As TextBox, ByRef text8 As TextBox, ByRef text9 As TextBox)
        text1.Text = String.Empty
        text2.Text = String.Empty
        text3.Text = String.Empty
        text4.Text = String.Empty
        text5.Text = String.Empty
        text6.Text = String.Empty
        text7.Text = String.Empty
        text8.Text = String.Empty
        text9.Text = String.Empty
    End Sub
    Public Sub Limpiar_Datos_Articulo_Lista_Precio(ByRef text2 As TextBox, ByRef text3 As TextBox, ByRef text4 As TextBox, ByRef text5 As TextBox)

        text2.Text = String.Empty
        text3.Text = String.Empty
        text4.Text = String.Empty
        text5.Text = String.Empty
    End Sub
    Public Sub Limpiar_Datos_Articulo_Lista_Precio_Precio(ByRef tbImportePrecioCosto As TextBox)
        tbImportePrecioCosto.Text = String.Empty
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
        datos.Add(Articulo_estructura(i).Tasa_IVA)
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
    Public Sub Pasar_A_ColeccionArticuloListaPrecio(ByVal ArticuloListaPrecio_estructura() As eArticuloCuerpoDocumento, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(ArticuloListaPrecio_estructura(i).IdListaPrecio)
        datos.Add(ArticuloListaPrecio_estructura(i).IdProducto)
        datos.Add(ArticuloListaPrecio_estructura(i).DescListaPrecio)
        datos.Add(ArticuloListaPrecio_estructura(i).PrecioCosto)
        datos.Add(ArticuloListaPrecio_estructura(i).Rentabilidad)
        datos.Add(ArticuloListaPrecio_estructura(i).PrecioVenta)
        datos.Add(ArticuloListaPrecio_estructura(i).PrecioKilo)
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
    Public Sub ObtenerUltimoNumero(ByRef Ultimo As Integer, ByVal opcion As String)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        If (opcion = DfieldDef.eConstantes.Encabezado_Entrada_Salida_Mercaderia.ToString()) Then
            consulta = "select max(Id_Entrada_Salida) from Encabezado_Entrada_Salida_Mercaderia"
        End If
        If (opcion = DfieldDef.eConstantes.Cuerpo_Entrada_Salida_Mercaderia.ToString()) Then
            consulta = "select max(Id_Cuerpo_Entrada_Salida) from Cuerpo_Entrada_Salida_Mercaderia"
        End If
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub


End Class
