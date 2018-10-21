Imports Modelo
Imports System.Windows.Forms
Public Class clsFacturacion
    Public session As New Controlador.clsSession()
    Private Shared FacturacionCodigoArticulo As String
    Private Shared variable As String
    Private Shared codigo As String
    Private Shared PorcDescuentos As String
    Private Shared listOfCodProd As New List(Of String)
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
        Public Neto_Grabado_21 As String
        Public Neto_Grabado_105 As String
        Public Neto_Grabado_27 As String
        Public Sub_Total As String
        Public Exentos As String
        Public IVA_Facturado21 As String
        Public IVA_Facturado105 As String
        Public IVA_Facturado27 As String
        Public IVA_Resp_No_Inscripto As String
        Public Persepciones As String
        Public PorcDescuentos As String
        Public Descuentos As String
        Public Retenciones As String
        Public Total As String
        Public Cancelado As String
        Public Signo As String
        Public NroPuesto As String
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
        Public Signo As String
        Public NroPuesto As String
    End Structure


    Public Structure eDatosFactura
        Public Neto_Grabado As String
        Public IVA_Facturado As String
    End Structure
    Public Structure eTipoComprobante
        Public IdTipoComprobante As String
        Public Descripcion As String
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

    Public Property ComplistOfCodProd() As List(Of String)
        Get
            Return Me.listOfCodProd
        End Get
        Set(ByVal Value As List(Of String))
            Me.listOfCodProd = Value
        End Set
    End Property
    Public Property CompPorcDescuentos() As String
        Get
            Return Me.PorcDescuentos
        End Get
        Set(ByVal Value As String)
            Me.PorcDescuentos = Value
        End Set
    End Property
    Public Property FacturacionCodArticulo() As String
        Get
            Return Me.FacturacionCodigoArticulo
        End Get
        Set(ByVal Value As String)
            Me.FacturacionCodigoArticulo = Value
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

    Public Sub llenar_tabla_Comprobante_Encabezado_Factura(ByVal tipoComprobante As String, ByVal Sucursal As String, ByVal Cancelado As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado,PorcDescuentos  from Encabezado_Factura where Tipo_Comprobante in(" + tipoComprobante + ") and Punto_Venta='" + Sucursal + "'  and Cancelado='" + Cancelado + "'order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
        conectar.cargar_tabla(grilla, consulta)
    End Sub


    Public Sub llenar_tabla_Comprobante(ByVal cadena As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_tabla(grilla, cadena)
    End Sub
    Public Sub llenar_Combo_Comprobante(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
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
    Public Sub Busqueda(ByRef tabla As DataGridView, ByVal nombreColumnaBuscar As String, ByVal campoBusqueda As String, ByVal sucursal As String, ByVal tipoComprobante As String, ByVal cancelado As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from Encabezado_Factura where " + nombreColumnaBuscar + " like '" & campoBusqueda & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante inin(" + tipoComprobante + ")and Cancelado='" + cancelado + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
        conectar.cargar_tabla(tabla, consulta)
    End Sub
    Public Sub se_Cargo_articulo_En_Factura(ByVal idArticulo As Integer, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from  Cuerpo_Factura   where Numero_Articulo='" + Convert.ToString(idArticulo) + "'"
        existe = conectar.verificar_existencia(consulta)
    End Sub

    Public Sub se_Cargo(ByVal consulta As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        existe = conectar.verificar_existencia(consulta)
    End Sub
    Public Sub Limpiar_Datos_Comprobante(ByRef dgvFacturacion As DataGridView, ByRef txtNeto As TextBox, ByRef txtDescuento As TextBox, ByRef txtIVa21 As TextBox, ByRef txtIVa105 As TextBox, ByRef txtIVa27 As TextBox, ByRef txtSubTotal As TextBox, ByRef txtTotal As TextBox, ByRef txtNombre As TextBox, ByRef txtApellido As TextBox, ByRef txtDireccion As TextBox, ByRef txtCelular As TextBox, ByRef txtTelefono As TextBox, ByRef txtCondIVA As TextBox, ByRef txtMail As TextBox, ByRef txtLimiteCC As TextBox, ByRef txtnumeroComprobante As TextBox, ByRef lblTipoComprobante As Label, ByRef lblIdComprobante As Label, ByRef txtporcDesc As TextBox)
        dgvFacturacion.DataSource = Nothing
        dgvFacturacion.Rows.Clear()
        txtNeto.Text = "0,00"
        txtSubTotal.Text = "0,00"
        txtDescuento.Text = "0,00"
        txtIVa21.Text = "0,00"
        txtIVa105.Text = "0,00"
        txtIVa27.Text = "0,00"
        txtTotal.Text = "0,00"
        txtNombre.Text = String.Empty
        txtApellido.Text = String.Empty
        txtDireccion.Text = String.Empty
        txtCelular.Text = String.Empty
        txtTelefono.Text = String.Empty
        txtCondIVA.Text = String.Empty
        txtMail.Text = String.Empty
        txtLimiteCC.Text = String.Empty
        txtnumeroComprobante.Text = String.Empty
        lblTipoComprobante.Text = String.Empty
        lblIdComprobante.Text = String.Empty
        txtporcDesc.Text = String.Empty
    End Sub

    Public Sub Limpiar_Importes_Comprobante(ByRef dgvFacturacion As DataGridView, ByRef txtNeto As TextBox, ByRef txtDescuento As TextBox, ByRef txtIVa21 As TextBox, ByRef txtIVa105 As TextBox, ByRef txtIVa27 As TextBox, ByRef txtSubTotal As TextBox, ByRef txtTotal As TextBox)
        dgvFacturacion.DataSource = Nothing
        dgvFacturacion.Rows.Clear()
        txtNeto.Text = "0,00"
        txtSubTotal.Text = "0,00"
        txtDescuento.Text = "0,00"
        txtIVa21.Text = "0,00"
        txtIVa105.Text = "0,00"
        txtIVa27.Text = "0,00"
        txtTotal.Text = "0,00"
    End Sub
    Public Sub Limpiar_Datos_ComprobanteVentaRapida(ByRef dgvVentaRapida As DataGridView, ByRef txtSubTotal As TextBox, ByRef txtDescuento As TextBox, ByRef txtIVa As TextBox, ByRef txtTotal As TextBox, ByRef txtnumeroComprobante As TextBox, ByRef lblTipoComprobante As Label, ByRef lblIdComprobante As Label)
        dgvVentaRapida.DataSource = Nothing
        dgvVentaRapida.Rows.Clear()
        txtSubTotal.Text = "0,00"
        txtDescuento.Text = String.Empty
        txtIVa.Text = "0,00"
        txtTotal.Text = "0,00"
        txtnumeroComprobante.Text = String.Empty
        lblTipoComprobante.Text = String.Empty
        lblIdComprobante.Text = String.Empty
    End Sub
    Public Sub LimpiarDatosBusquedaComprobante(ByRef tbPuntoVenta As TextBox, ByRef tbTipoComprobante As TextBox, ByRef tbNumeroComprobante As TextBox, ByRef tbComprobante As TextBox, ByRef tbApellido As TextBox, ByRef tbNombre As TextBox, ByRef tbCondicionIVA As TextBox)
        tbPuntoVenta.Text = String.Empty
        tbTipoComprobante.Text = String.Empty
        tbNumeroComprobante.Text = String.Empty
        tbComprobante.Text = String.Empty
        tbApellido.Text = String.Empty
        tbNombre.Text = String.Empty
        tbCondicionIVA.Text = String.Empty
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
        'datos.Add(Factura_Encabezado_estructura(i).Neto_Grabado)
        datos.Add(Factura_Encabezado_estructura(i).Neto_Grabado_21)
        datos.Add(Factura_Encabezado_estructura(i).Neto_Grabado_105)
        datos.Add(Factura_Encabezado_estructura(i).Neto_Grabado_27)
        datos.Add(Factura_Encabezado_estructura(i).Sub_Total)
        datos.Add(Factura_Encabezado_estructura(i).Conc_No_Grabado)
        datos.Add(Factura_Encabezado_estructura(i).Exentos)
        datos.Add(Factura_Encabezado_estructura(i).IVA_Facturado21)
        datos.Add(Factura_Encabezado_estructura(i).IVA_Facturado105)
        datos.Add(Factura_Encabezado_estructura(i).IVA_Facturado27)
        datos.Add(Factura_Encabezado_estructura(i).IVA_Resp_No_Inscripto)
        datos.Add(Factura_Encabezado_estructura(i).Persepciones)
        datos.Add(Factura_Encabezado_estructura(i).PorcDescuentos)
        datos.Add(Factura_Encabezado_estructura(i).Descuentos)
        datos.Add(Factura_Encabezado_estructura(i).Retenciones)
        datos.Add(Factura_Encabezado_estructura(i).Total)
        datos.Add(Factura_Encabezado_estructura(i).Cancelado)
        datos.Add(Factura_Encabezado_estructura(i).Signo)
        datos.Add(Factura_Encabezado_estructura(i).NroPuesto)
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
        datos.Add(Factura_Cuerpo_estructura(i).Signo)
        datos.Add(Factura_Cuerpo_estructura(i).NroPuesto)
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
    Public Sub Obtener_Datos_Comprobante_Cuerpo_Factura(ByVal Punto_Venta As String, ByVal TipoComprobante As String, ByVal Numero_Comprobante As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from  Cuerpo_Factura where Punto_Venta='" + Punto_Venta + "' and Tipo_Comprobante='" + TipoComprobante + "' and Numero_Comprobante='" + Numero_Comprobante + "' "
        datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub Obtener_Datos_Comprobante_Encabezado_Factura(ByVal Punto_Venta As String, ByVal TipoComprobante As String, ByVal Numero_Comprobante As String, ByRef datos As DataTable)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from Encabezado_Factura where Punto_Venta='" + Punto_Venta + "' and Tipo_Comprobante='" + TipoComprobante + "' and Numero_Comprobante='" + Numero_Comprobante + "' "
        datos = conectar.consulta_reader(consulta)
    End Sub

    Public Sub Obtener_Datos_Comprobante(ByVal Numero_Condicion_IVA_Cliente As String, ByVal Numero_Condicion_IVA_Empresa As String, ByVal TipoComprobante As String, ByRef DatoTipoComprobante As eTipoComprobante)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim datos As DataTable
        Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
        conectar.srt_conexion = session.Session.CadenaConeccion
        If TipoComprobante = dfielddefConstantes.FACTURA.ToString() Then
            consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
            consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
            consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
            consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
            consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
            consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
            consulta += " and TC.IdTipoComprobante in ('1','11','6')"
            'datos = conectar.consulta_reader(consulta)

        End If
        If TipoComprobante = dfielddefConstantes.Nota_De_Credito.ToString() Then
            consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
            consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
            consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
            consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
            consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
            consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
            consulta += " and TC.IdTipoComprobante in ('3','8','13')"
            'datos = conectar.consulta_reader(consulta)
        End If
        If TipoComprobante = dfielddefConstantes.Nota_De_Credito_Int.ToString() Then
            consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
            consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
            consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
            consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
            consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
            consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
            consulta += " and TC.IdTipoComprobante in ('19','20','21')"
            'datos = conectar.consulta_reader(consulta)
        End If
        If TipoComprobante = dfielddefConstantes.Recibo.ToString() Then
            consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
            consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
            consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
            consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
            consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
            consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
            consulta += " and TC.IdTipoComprobante in ('4','9','15')"
        End If
        datos = conectar.consulta_reader(consulta)
        DatoTipoComprobante.IdTipoComprobante = datos.Rows(0).Item("IdTipoComprobante")
        DatoTipoComprobante.Descripcion = datos.Rows(0).Item("Descripcion")

    End Sub
    Public Sub Obtener_Tipo_Comprobante(ByVal idTipoComprobante As String, ByRef datosTipoComprobante As eTipoComprobante)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + idTipoComprobante + "' "
        datos = conectar.consulta_reader(consulta)
        datosTipoComprobante.IdTipoComprobante = datos.Rows(0).Item("IdTipoComprobante")
        datosTipoComprobante.Descripcion = datos.Rows(0).Item("Descripcion")
    End Sub
    'Public Sub Obtener_Tipo_Comprobante_ID(ByVal consulta As String, ByRef ID_Comprobante As Integer)
    '    Dim conectar As New coneccion()
    '    Dim datos As New DataTable
    '    conectar.srt_conexion = session.Session.CadenaConeccion
    '    datos = conectar.consulta_reader(consulta)
    '    ID_Comprobante = datos.Rows(0).Item(0)
    'End Sub
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
    Public Sub ObtenerUltimoNumeroCuerpoFactura(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select Max(IdCuerpoFactura) as Maximo from Cuerpo_Factura"
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub

    Public Sub Validar_Cliente(ByVal numero_Cliente As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim consulta As String
        consulta = "Select * from Encabezado_Factura  where Numero_Cliente='" + numero_Cliente + "' "
        conectar.srt_conexion = session.Session.CadenaConeccion
        existe = conectar.verificar_existencia(consulta)
    End Sub
End Class
