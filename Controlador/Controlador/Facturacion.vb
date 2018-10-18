Imports Modelo
Imports System.Windows.Forms
Public Class Facturacion
    Private Shared variable As String
    Private Shared codigo As String
    Private Punto_Venta As String
    Private Tipo_Comprobante As String
    Private Numero_Comprobante As String
    Private Numero_Cliente As Integer
    Private Nombre As String
    Private Apellido As String
    Private Situacion_Frente_A_IVA As String
    Private Forma_Pago As String
    Private Fecha_Comprobante As String
    Private Codigo_Vendedor As String
    Private Neto_Grabado As String
    Private Conc_No_Grabado As String
    Private Exentos As String
    Private IVA_Facturado As String
    Private IVA_Resp_No_Inscripto As String
    Private Persepciones As String
    Private Descuentos As String
    Private Retenciones As String
    Private Total As String
    Private Numero_Articulo As String
    Private Descripcion As String
    Private Cantidad As String
    Private Precio_Unitario As String
    Private Tasa As String
    Public Structure eEncabezadoFactura
        Public Punto_Venta As String
        Public Tipo_Comprobante As String
        Public Numero_Comprobante As String
        Public Comprobante As String
        Public Numero_Cliente As Integer
        Public Nombre As String
        Public Apellido As String
        Public Situacion_Frente_A_IVA As String
        Public Id_Forma_Pago As String
        Public Forma_Pago As String
        Public Fecha_Comprobante As String
        Public Codigo_Vendedor As Integer
        Public Conc_No_Grabado As String
        Public Neto_Grabado As String
        Public Exentos As String
        Public IVA_Facturado As String
        Public IVA_Resp_No_Inscripto As String
        Public Persepciones As String
        Public Descuentos As String
        Public Retenciones As String
        Public Total As String
        Public Cancelado As String
    End Structure
    Public Structure eCuerpoFactura
        Public IdCuerpoFactura As Integer
        Public Punto_Venta As String
        Public Tipo_Comprobante As String
        Public Numero_Comprobante As String
        Public Comprobante As String
        Public Numero_Articulo As String
        Public Descripcion As String
        Public Cantidad As String
        Public Precio_Unitario As String

    End Structure
    Public Property Compvariable() As String
        Get
            Return Me.variable
        End Get
        Set(ByVal Value As String)
            Me.variable = Value
        End Set
    End Property
    Public Property CompCodigo() As String
        Get
            Return Me.codigo
        End Get
        Set(ByVal Value As String)
            Me.codigo = Value
        End Set
    End Property
    'Public Property CompFacturacionEncabezado() As eEncabezadoFactura
    '    Get
    '        Return Me.FacturacionEncabezado
    '    End Get
    '    Set(ByVal Value As eEncabezadoFactura)
    '        Me.FacturacionEncabezado = Value
    '    End Set
    'End Property
    'Public Property CompIngresosBrutos() As String
    '    Get
    '        Return Me.IngresosBrutos
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.IngresosBrutos = Value
    '    End Set
    'End Property

    'Public Property CompRazonSocial() As String
    '    Get
    '        Return Me.RazonSocial
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.RazonSocial = Value
    '    End Set
    'End Property
    'Public Property CompCalle() As String
    '    Get
    '        Return Me.Calle
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Calle = Value
    '    End Set
    'End Property
    'Public Property CompPiso() As String
    '    Get
    '        Return Me.Piso
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Piso = Value
    '    End Set
    'End Property
    'Public Property CompNro() As String
    '    Get
    '        Return Me.Nro
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Nro = Value
    '    End Set
    'End Property

    'Public Property CompCUIT() As String
    '    Get
    '        Return Me.CUIT
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.CUIT = Value
    '    End Set
    'End Property
    'Public Property CompProvincia() As String
    '    Get
    '        Return Me.Provincia
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Provincia = Value
    '    End Set
    'End Property
    'Public Property CompTelefono() As String
    '    Get
    '        Return Me.Telefono
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Telefono = Value
    '    End Set
    'End Property
    'Public Property CompCelular() As String
    '    Get
    '        Return Me.Celular
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Celular = Value
    '    End Set
    'End Property
    'Public Property CompE_Mail() As String
    '    Get
    '        Return Me.E_Mail
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.E_Mail = Value
    '    End Set
    'End Property
    'Public Property CompCodigo_Postal() As String
    '    Get
    '        Return Me.Codigo_Postal
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Codigo_Postal = Value
    '    End Set
    'End Property
    'Public Property CompResponsabilidad_IVA() As String
    '    Get
    '        Return Me.Responsabilidad_IVA
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Responsabilidad_IVA = Value
    '    End Set
    'End Property
    'Public Property CompLocalidad() As String
    '    Get
    '        Return Me.Localidad
    '    End Get
    '    Set(ByVal Value As String)
    '        Me.Localidad = Value
    '    End Set
    'End Property
    Public Sub llenar_tabla_Comprobante(ByVal cadena As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        conectar.cargar_tabla(grilla, cadena)
    End Sub

    Public Sub llenar_Combo_Comprobante(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
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

    Function validateDoublesAndCurrency_Comprobante(ByVal stringValue As String) As Boolean
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

    Public Sub se_Cargo(ByVal consulta As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        existe = conectar.verificar_existencia(consulta)

    End Sub

    Public Sub Limpiar_Datos_Comprobante(ByRef dgvFacturacion As DataGridView, ByRef txtSubTotal As TextBox, ByRef txtDescuento As TextBox, ByRef txtIVa As TextBox, ByRef txtTotal As TextBox, ByRef txtNombre As TextBox, ByRef txtApellido As TextBox, ByRef txtDireccion As TextBox, ByRef txtCelular As TextBox, ByRef txtTelefono As TextBox, ByRef txtCondIVA As TextBox, ByRef txtMail As TextBox, ByRef txtLimiteCC As TextBox, ByRef txtnumeroComprobante As TextBox, ByRef lblTipoComprobante As Label, ByRef lblIdComprobante As Label)

        dgvFacturacion.DataSource = Nothing
        dgvFacturacion.Rows.Clear()
        txtSubTotal.Text = "0,00"
        txtDescuento.Text = ""
        txtIVa.Text = "0,00"
        txtTotal.Text = "0,00"
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDireccion.Text = ""
        txtCelular.Text = ""
        txtTelefono.Text = ""
        txtCondIVA.Text = ""
        txtMail.Text = ""
        txtLimiteCC.Text = ""
        txtnumeroComprobante.Text = ""
        lblTipoComprobante.Text = ""
        lblIdComprobante.Text = ""
    End Sub
    Public Sub Limpiar_Datos_ComprobanteVentaRapida(ByRef dgvVentaRapida As DataGridView, ByRef txtSubTotal As TextBox, ByRef txtDescuento As TextBox, ByRef txtIVa As TextBox, ByRef txtTotal As TextBox, ByRef txtnumeroComprobante As TextBox, ByRef lblTipoComprobante As Label, ByRef lblIdComprobante As Label)

        dgvVentaRapida.DataSource = Nothing
        dgvVentaRapida.Rows.Clear()
        txtSubTotal.Text = "0,00"
        txtDescuento.Text = ""
        txtIVa.Text = "0,00"
        txtTotal.Text = "0,00"

        txtnumeroComprobante.Text = ""
        lblTipoComprobante.Text = ""
        lblIdComprobante.Text = ""
    End Sub

    Public Sub LimpiarDatosBusquedaComprobante(ByRef tbPuntoVenta As TextBox, ByRef tbTipoComprobante As TextBox, ByRef tbNumeroComprobante As TextBox, ByRef tbComprobante As TextBox, ByRef tbApellido As TextBox, ByRef tbNombre As TextBox, ByRef tbCondicionIVA As TextBox)
        tbPuntoVenta.Text = ""
        tbTipoComprobante.Text = ""
        tbNumeroComprobante.Text = ""
        tbComprobante.Text = ""
        tbApellido.Text = ""
        tbNombre.Text = ""
        tbCondicionIVA.text = ""

    End Sub
    Public Sub Pasar_A_Coleccion_Encabezado_Factura(ByVal Factura_Encabezado_estructura() As eEncabezadoFactura, ByRef datos As Collection, ByVal i As Integer)

        datos.Add(Factura_Encabezado_estructura(i).Punto_Venta)
        datos.Add(Factura_Encabezado_estructura(i).Tipo_Comprobante)
        datos.Add(Factura_Encabezado_estructura(i).Numero_Comprobante)
        datos.Add(Factura_Encabezado_estructura(i).Comprobante)
        datos.Add(Factura_Encabezado_estructura(i).Numero_Cliente)
        datos.Add(Factura_Encabezado_estructura(i).Nombre)
        datos.Add(Factura_Encabezado_estructura(i).Apellido)
        datos.Add(Factura_Encabezado_estructura(i).Situacion_Frente_A_IVA)
        datos.Add(Factura_Encabezado_estructura(i).Id_Forma_Pago)
        datos.Add(Factura_Encabezado_estructura(i).Forma_Pago)
        datos.Add(Factura_Encabezado_estructura(i).Fecha_Comprobante)
        datos.Add(Factura_Encabezado_estructura(i).Codigo_Vendedor)
        datos.Add(Factura_Encabezado_estructura(i).Neto_Grabado)
        datos.Add(Factura_Encabezado_estructura(i).Conc_No_Grabado)
        datos.Add(Factura_Encabezado_estructura(i).Exentos)
        datos.Add(Factura_Encabezado_estructura(i).IVA_Facturado)
        datos.Add(Factura_Encabezado_estructura(i).IVA_Resp_No_Inscripto)
        datos.Add(Factura_Encabezado_estructura(i).Persepciones)
        datos.Add(Factura_Encabezado_estructura(i).Descuentos)
        datos.Add(Factura_Encabezado_estructura(i).Retenciones)
        datos.Add(Factura_Encabezado_estructura(i).Total)
        datos.Add(Factura_Encabezado_estructura(i).Cancelado)
    End Sub
    Public Sub Pasar_A_Coleccion_Cuerpo_Factura(ByVal Factura_Cuerpo_estructura() As eCuerpoFactura, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(Factura_Cuerpo_estructura(i).IdCuerpoFactura)
        datos.Add(Factura_Cuerpo_estructura(i).Punto_Venta)
        datos.Add(Factura_Cuerpo_estructura(i).Tipo_Comprobante)
        datos.Add(Factura_Cuerpo_estructura(i).Numero_Comprobante)
        datos.Add(Factura_Cuerpo_estructura(i).Comprobante)
        datos.Add(Factura_Cuerpo_estructura(i).Numero_Articulo)
        datos.Add(Factura_Cuerpo_estructura(i).Descripcion)
        datos.Add(Factura_Cuerpo_estructura(i).Cantidad)
        datos.Add(Factura_Cuerpo_estructura(i).Precio_Unitario)
    End Sub

    Public Sub Obtener_Clave_Principal_Encabezado_Factura(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Punto_Venta")
        Clave_Princ.Add("Tipo_Comprobante")
        Clave_Princ.Add("Numero_Comprobante")
    End Sub

    Public Sub Obtener_Clave_Principal_Cuerpo_Factura(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("IdCuerpoFactura")
        Clave_Princ.Add("Punto_Venta")
        Clave_Princ.Add("Tipo_Comprobante")
        Clave_Princ.Add("Numero_Comprobante")
    End Sub
    Public Sub Obtener_Datos_Comprobante(ByVal consulta As String, ByRef Datos As DataTable)
        Dim conectar As New coneccion()
        Datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub Obtener_Tipo_Comprobante(ByVal consulta As String, ByRef descripcion_Comprobante As String)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        datos = conectar.consulta_reader(consulta)
        descripcion_Comprobante = datos.Rows(0).Item(0)
    End Sub
    Public Sub Obtener_Tipo_Comprobante_ID(ByVal consulta As String, ByRef ID_Comprobante As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        datos = conectar.consulta_reader(consulta)
        ID_Comprobante = datos.Rows(0).Item(0)
    End Sub

    Public Sub sumar_Importe(ByVal datagrid As DataGridView, ByRef totalImporte As Double)
        Dim i As Integer
        totalImporte = 0

        For i = 0 To datagrid.Rows.Count - 1
            totalImporte = totalImporte + Convert.ToDouble(datagrid.Rows(i).Cells("Importe").Value)
        Next
    End Sub

    Public Sub obtenerTasa(ByVal valor As String, ByRef tasa As Double)
        tasa = (CDbl(valor) / 100) + 1
    End Sub
    Public Sub ObtenerUltimoNumeroCuerpoFactura(ByVal consulta As String, ByRef Ultimo As Integer)
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
