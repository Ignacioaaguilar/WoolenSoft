Imports Modelo
Imports System.Windows.Forms
Public Class clsFacturacion
    Public session As New Controlador.clsSession()
    Private Shared FacturacionCodigoArticulo As String
    Private Shared variable As String
    Private Shared codigo As String
    Private Shared PorcDescuentos As String
    Private Shared listOfCodProd As New List(Of String)
    Private Shared Punto_Venta As String
    Private Shared Tipo_Comprobante As String
    Private Shared Numero_Comprobante As String
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
    Public Property CompPunto_Venta() As String
        Get
            Return Me.Punto_Venta
        End Get
        Set(ByVal Value As String)
            Me.Punto_Venta = Value
        End Set
    End Property
    Public Property CompTipo_Comprobante() As String
        Get
            Return Me.Tipo_Comprobante
        End Get
        Set(ByVal Value As String)
            Me.Tipo_Comprobante = Value
        End Set
    End Property
    Public Property CompNumero_Comprobante() As String
        Get
            Return Me.Numero_Comprobante
        End Get
        Set(ByVal Value As String)
            Me.Numero_Comprobante = Value
        End Set
    End Property

    Public Sub llenar_tabla_Comprobante_Encabezado_Factura(ByVal tipoComprobante As String, ByVal Sucursal As String, ByVal Cancelado As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion

        consulta = "select ef.Punto_Venta as [Punto Venta],ef.Tipo_Comprobante as [Tip Comprobante] ,ef.Numero_Comprobante as [Num Comprobante] ,ef.Comprobante,ef.Numero_Cliente as [Num Cliente] , ef.Nombre,ef.Apellido,ef.Situacion_Frente_A_IVA as [SFI]  ,ef.Forma_Pago as [Forma Pago] ,ef.Fecha_Comprobante as [Fech Comprobante],ef.Cancelado,ef.PorcDescuentos  " & vbCrLf
        consulta += " from Encabezado_Factura ef " & vbCrLf
        consulta += " left outer join imputaciones i on ef.Punto_Venta=i.PuntoVenta and ef.Tipo_Comprobante=i.TipoComprobante and ef.Numero_Comprobante=i.NumeroComprobante " & vbCrLf
        consulta += " where Tipo_Comprobante in(" + tipoComprobante + ") and Punto_Venta='" + Sucursal + "'  and Cancelado='" + Cancelado + "' and i.PuntoVenta is null and i.TipoComprobante is null and i.NumeroComprobante is null " & vbCrLf
        consulta += "order by ef.Punto_Venta,ef.Tipo_Comprobante,ef.Numero_Comprobante,ef.Comprobante"

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
        consulta = " select ef.Punto_Venta as [Punto Venta],ef.Tipo_Comprobante as [Tip Comprobante] ,ef.Numero_Comprobante as [Num Comprobante] ,ef.Comprobante,ef.Numero_Cliente as [Num Cliente] , ef.Nombre,ef.Apellido,ef.Situacion_Frente_A_IVA as [SFI]  ,ef.Forma_Pago as [Forma Pago] ,ef.Fecha_Comprobante as [Fech Comprobante],ef.Cancelado,ef.PorcDescuentos  " & vbCrLf
        consulta += " from Encabezado_Factura ef " & vbCrLf
        consulta += " left outer join imputaciones i on ef.Punto_Venta=i.PuntoVenta and ef.Tipo_Comprobante=i.TipoComprobante and ef.Numero_Comprobante=i.NumeroComprobante " & vbCrLf
        consulta += " where " + nombreColumnaBuscar + " like '" & campoBusqueda & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante in(" + tipoComprobante + ")and Cancelado='" + cancelado + "' and i.PuntoVenta is null and i.TipoComprobante is null and i.NumeroComprobante is null " & vbCrLf
        consulta += " order by ef.Punto_Venta,ef.Tipo_Comprobante,ef.Numero_Comprobante,ef.Comprobante "

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
    Public Sub Limpiar_Datos_Comprobante(ByRef dgvFacturacion As DataGridView, ByRef txtNeto As Label, ByRef txtDescuento As Label, ByRef txtIVa21 As Label, ByRef txtIVa105 As Label, ByRef txtIVa27 As Label, ByRef txtSubTotal As Label, ByRef txtTotal As Label, ByRef txtNombre As TextBox, ByRef txtApellido As TextBox, ByRef txtDireccion As TextBox, ByRef txtCelular As TextBox, ByRef txtTelefono As TextBox, ByRef txtCondIVA As TextBox, ByRef txtMail As TextBox, ByRef txtLimiteCC As TextBox, ByRef txtnumeroComprobante As TextBox, ByRef lblTipoComprobante As Label, ByRef lblIdComprobante As Label, ByRef txtporcDesc As TextBox)
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

    Public Sub Limpiar_Importes_Comprobante(ByRef dgvFacturacion As DataGridView, ByRef txtNeto As Label, ByRef txtDescuento As Label, ByRef txtIVa21 As Label, ByRef txtIVa105 As Label, ByRef txtIVa27 As Label, ByRef txtSubTotal As Label, ByRef txtTotal As Label)
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
        Try

        
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
            If datos.Rows.Count > 0 Then
                DatoTipoComprobante.IdTipoComprobante = datos.Rows(0).Item("IdTipoComprobante")
                DatoTipoComprobante.Descripcion = datos.Rows(0).Item("Descripcion")
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)

        End Try

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
    Public Sub registrar(ByVal eFactEncESt() As Controlador.clsFacturacion.eEncabezadoFactura, ByVal eNumero_ComprobanteEStFact() As Controlador.clsNumeroComprobante.eNumeracionComprobante, ByVal eFactCuerpoESt() As Controlador.clsFacturacion.eCuerpoFactura, ByVal eArticulosEStFact() As Controlador.clsArticulos.eArticulo)
        Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim clsFacturacion As New Controlador.clsFacturacion
        Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
        Dim dtdatosDataTable As New DataTable
        Dim tipocomprobante As String
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim clsCliente As New Controlador.clsCliente
        Dim clsImputaciones As New Controlador.clsImputaciones
        Dim i As Integer
        Dim ultimo As Integer
        Dim UltimoImputaciones As Integer
        Dim UltimoCuentaCorriente As Integer
        Dim idx As Integer
        Dim dtdatosFacturacion As New DataTable
        Dim dtdatosEmpresa As New DataTable
        Dim Responsabilidad_IVA_Empresa As String
        Dim Numero_Sucursal As String
        Dim IDComprobante As Integer
        Dim numeroComp As String = String.Empty
        Dim nuComprobante As Integer
        Dim existe As Boolean
        Dim tran As New Collection
        Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
        Dim clsEmpresa As New Controlador.clsEmpresas
        Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
        Dim eFomasdePagoEfectivo(0) As Controlador.clsImputaciones.eImputaciones
        Dim eNumero_Condicion_IVA_Cliente As Controlador.clsCliente.eCondicion_Frente_Al_Iva
        Dim eDatoTipoComprobante As Controlador.clsFacturacion.eTipoComprobante
        Dim clsformaPago As New Controlador.clsFormasDePago
        Dim clssession As New Controlador.clsSession()
        Dim clsCuentaCorriente As New Controlador.clsCuentaCorriente
        Dim eFomasdePagoCuentaCorriente(0) As Controlador.clsCuentaCorriente.eCuentaCorriente
        Dim clsTransaccion As New Controlador.clsTransacciones
        Try
            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Encabezado_Factura.ToString(), esquema)
            clsFacturacion.Obtener_Clave_Principal_Encabezado_Factura(ClavePrincipal)
            clsFacturacion.Pasar_A_Coleccion_Encabezado_Factura(eFactEncESt, datos, 1)
            clsQueryBuilder.ArmaInsert(dfielddefConstantes.Encabezado_Factura.ToString(), esquema, datos, ClavePrincipal, consulta)
            tran.Add(consulta)
            esquema.Clear()
            datos.Clear()
            ClavePrincipal.Clear()
            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
            clsNumeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
            clsNumeroComprobante.Pasar_A_Coleccion(eNumero_ComprobanteEStFact, datos, 1)
            clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, datos, ClavePrincipal, consulta)
            tran.Add(consulta)
            esquema.Clear()
            datos.Clear()
            ClavePrincipal.Clear()
            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Cuerpo_Factura.ToString(), esquema)
            clsFacturacion.Obtener_Clave_Principal_Cuerpo_Factura(ClavePrincipal)
            clsFacturacion.ObtenerUltimoNumeroCuerpoFactura(ultimo)
            For i = 1 To eFactCuerpoESt.Count - 1
                eFactCuerpoESt(i).IdCuerpoFactura = ultimo
                clsFacturacion.Pasar_A_Coleccion_Cuerpo_Factura(eFactCuerpoESt, datos, i)
                clsQueryBuilder.ArmaInsert(dfielddefConstantes.Cuerpo_Factura.ToString(), esquema, datos, ClavePrincipal, consulta)
                tran.Add(consulta)
                consulta = String.Empty
                datos.Clear()
                If (eFactCuerpoESt(i).Numero_Articulo = eArticulosEStFact(i).Id_Producto) Then
                    eArticulosEStFact(i).Stock = Convert.ToString(Convert.ToDouble(eArticulosEStFact(i).Stock) - (Convert.ToDouble(eFactCuerpoESt(i).Cantidad) * Convert.ToInt32(eFactCuerpoESt(i).Signo)))
                    consulta = "update " + dfielddefConstantes.Producto.ToString() + " set Stock='" + (eArticulosEStFact(i).Stock) + "' where ID_Producto= '" + (eFactCuerpoESt(i).Numero_Articulo) + "'"
                    tran.Add(consulta)
                End If
                consulta = ""
                ultimo = ultimo + 1
            Next
            consulta = ""
            esquema.Clear()
            datos.Clear()
            ClavePrincipal.Clear()
            If (eFactEncESt(1).Forma_Pago = dfielddefConstantes.Contado.ToString()) Then
                clsImputaciones.ObtenerUltimoNumeroImputaciones(UltimoImputaciones)
                ReDim eFomasdePagoEfectivo(1)
                clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtdatosEmpresa)
                Responsabilidad_IVA_Empresa = dtdatosEmpresa.Rows(0).Item(dfielddefEmpresa.Responsabilidad_IVA).ToString()
                clsCliente.Obtener_CondicionFrenteAIVa(eFactEncESt(1).Situacion_Frente_A_IVA, eNumero_Condicion_IVA_Cliente)
                clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)

                clsFacturacion.Obtener_Datos_Comprobante(eNumero_Condicion_IVA_Cliente.Id_Condicion_IVA, Numero_Condicion_IVA_Empresa, dfielddefConstantes.Recibo.ToString(), eDatoTipoComprobante)
                tipocomprobante = eDatoTipoComprobante.Descripcion
                IDComprobante = Convert.ToInt32(eDatoTipoComprobante.IdTipoComprobante)

                clsNumeroComprobante.obtener_Numero_Comprobante(clsEmpresa.Compvariable, Convert.ToString(IDComprobante), numeroComp)
                nuComprobante = Convert.ToInt32(numeroComp) + 1
                clsNumeroComprobante.Aumentar_Numeracion_Comprobante(nuComprobante, numeroComp)
                consulta = ""
                consulta = "Update Numeracion_Comprobante set Numeracion='" + (numeroComp) + "' where Id_Tipo_Comprobante='" + (Convert.ToString(IDComprobante)) + "' and Id_Empresa='" + (clsEmpresa.Compvariable) + "'"
                tran.Add(consulta)

                eFomasdePagoEfectivo(1).IdImputaciones = UltimoImputaciones
                eFomasdePagoEfectivo(1).PuntoVentaRecibo = eFactEncESt(1).Punto_Venta
                eFomasdePagoEfectivo(1).TipoComprobanteRecibo = Convert.ToString(IDComprobante).PadLeft(2, "0")
                eFomasdePagoEfectivo(1).NumeroComprobanteRecibo = Convert.ToString(numeroComp).PadLeft(8, "0")

                eFomasdePagoEfectivo(1).Comprobante = eFactEncESt(1).Comprobante
                eFomasdePagoEfectivo(1).NumeroCliente = eFactEncESt(1).Numero_Cliente
                eFomasdePagoEfectivo(1).Fecha = Date.Now()
                eFomasdePagoEfectivo(1).PuntoVenta = eFactEncESt(1).Punto_Venta
                eFomasdePagoEfectivo(1).TipoComprobante = eFactEncESt(1).Tipo_Comprobante
                eFomasdePagoEfectivo(1).NumeroComprobante = eFactEncESt(1).Numero_Comprobante

                eFomasdePagoEfectivo(1).Importe = eFactEncESt(1).Total
                eFomasdePagoEfectivo(1).ID_FormaPago = eFactEncESt(1).Id_Forma_Pago

                If clsformaPago.Compvariable = dfielddefConstantes.FACTURA.ToString() Then
                    eFomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.IngresoEfectivo.ToString()
                    eFomasdePagoEfectivo(1).Signo = "1"
                ElseIf clsformaPago.Compvariable = dfielddefConstantes.NotaDebito.ToString() Then
                    eFomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.IngresoNotaDebito.ToString()
                    eFomasdePagoEfectivo(1).Signo = "1"
                ElseIf clsformaPago.Compvariable = dfielddefConstantes.NotaCredito.ToString() Then
                    eFomasdePagoEfectivo(1).Descripcion = dfielddefConstantes.EgresoNotaCredito.ToString()
                    eFomasdePagoEfectivo(1).Signo = "-1"
                End If
                eFomasdePagoEfectivo(1).NroPuesto = clssession.Session.NroPuesto
                clsQueryBuilder.obtener_estructura(dfielddefConstantes.Imputaciones.ToString(), esquema)
                clsImputaciones.Obtener_Clave_Principal(ClavePrincipal)
                clsImputaciones.Pasar_A_Coleccion(eFomasdePagoEfectivo, datos, 1)
                clsQueryBuilder.ArmaInsert(dfielddefConstantes.Imputaciones.ToString(), esquema, datos, ClavePrincipal, consulta)
                tran.Add(consulta)
            ElseIf (eFactEncESt(1).Forma_Pago = dfielddefConstantes.CuentaCorriente.ToString()) Then
                clsCuentaCorriente.ObtenerUltimoNumeroCuentaCorriente(UltimoCuentaCorriente)
                ReDim eFomasdePagoCuentaCorriente(1)
                eFomasdePagoCuentaCorriente(1).Id_CuentaCorriente = UltimoCuentaCorriente
                eFomasdePagoCuentaCorriente(1).PuntoVenta = eFactEncESt(1).Punto_Venta
                eFomasdePagoCuentaCorriente(1).TipoComprobante = eFactEncESt(1).Tipo_Comprobante
                eFomasdePagoCuentaCorriente(1).NumeroComprobante = eFactEncESt(1).Numero_Comprobante
                eFomasdePagoCuentaCorriente(1).Comprobante = eFactEncESt(1).Comprobante
                eFomasdePagoCuentaCorriente(1).NumeroCliente = eFactEncESt(1).Numero_Cliente
                eFomasdePagoCuentaCorriente(1).Fecha = Date.Now()
                eFomasdePagoCuentaCorriente(1).Importe = eFactEncESt(1).Total
                eFomasdePagoCuentaCorriente(1).Signo = "1"
                If clsformaPago.Compvariable = dfielddefConstantes.FACTURA.ToString() Then
                    eFomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.IngresoCuentaCorriente.ToString()
                ElseIf clsformaPago.Compvariable = dfielddefConstantes.NotaDebito.ToString() Then
                    eFomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.IngresoNotaDebitoCuentaCorriente.ToString()
                ElseIf clsformaPago.Compvariable = dfielddefConstantes.NotaCredito.ToString() Then
                    eFomasdePagoCuentaCorriente(1).Descripcion = dfielddefConstantes.EgresoNotaCreditoCuentaCorriente.ToString()
                End If
                eFomasdePagoCuentaCorriente(1).NroPuesto = clssession.Session.NroPuesto
                clsQueryBuilder.obtener_estructura(dfielddefConstantes.CuentaCorriente.ToString(), esquema)
                clsCuentaCorriente.Obtener_Clave_Principal(ClavePrincipal)
                clsCuentaCorriente.Pasar_A_Coleccion(eFomasdePagoCuentaCorriente, datos, 1)
                clsQueryBuilder.ArmaInsert(dfielddefConstantes.CuentaCorriente.ToString(), esquema, datos, ClavePrincipal, consulta)
                tran.Add(consulta)
            End If
            clsTransaccion.Operaciones_Tabla_Transaccion(tran)
            tran.Clear()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub anularComprobante(ByVal eNotaCredito_Enc_estructura() As Controlador.clsFacturacion.eEncabezadoFactura, ByVal Numero_Comprobante() As Controlador.clsNumeroComprobante.eNumeracionComprobante, ByVal eNotaCredito_Cuerpo_estructura() As Controlador.clsFacturacion.eCuerpoFactura, ByVal Articulos_Estructura() As Controlador.clsArticulos.eArticulo, ByVal Facturacion_Enc_estructura() As Controlador.clsFacturacion.eEncabezadoFactura, ByRef valido As Boolean)
        Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
        Dim esquema As New Collection
        Dim ClavePrincipal As New Collection
        Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim clsTransaccion As New Controlador.clsTransacciones
        Dim tran As New Collection
        Dim clsfacturacion As New Controlador.clsFacturacion()
        Dim consulta As String
        Dim datosCol As New Collection
        Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
        Dim Facturacion_Cuerpo_estructura(0) As Controlador.clsFacturacion.eCuerpoFactura
        Dim ultimo As Integer
        Try

            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Encabezado_Factura.ToString(), esquema)
            clsfacturacion.Obtener_Clave_Principal_Encabezado_Factura(ClavePrincipal)
            clsfacturacion.Pasar_A_Coleccion_Encabezado_Factura(eNotaCredito_Enc_estructura, datosCol, 1)
            clsQueryBuilder.ArmaInsert(dfielddefConstantes.Encabezado_Factura.ToString(), esquema, datosCol, ClavePrincipal, consulta)
            tran.Add(consulta)
            esquema.Clear()
            datosCol.Clear()
            ClavePrincipal.Clear()
            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema)
            clsNumeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
            clsNumeroComprobante.Pasar_A_Coleccion(Numero_Comprobante, datosCol, 1)
            clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Numeracion_Comprobante.ToString(), esquema, datosCol, ClavePrincipal, consulta)
            tran.Add(consulta)
            esquema.Clear()
            datosCol.Clear()
            ClavePrincipal.Clear()
            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Cuerpo_Factura.ToString(), esquema)
            clsfacturacion.Obtener_Clave_Principal_Cuerpo_Factura(ClavePrincipal)

            For i = 1 To eNotaCredito_Cuerpo_estructura.Count - 1
                clsfacturacion.ObtenerUltimoNumeroCuerpoFactura(ultimo)
                eNotaCredito_Cuerpo_estructura(i).IdCuerpoFactura = ultimo
                clsfacturacion.Pasar_A_Coleccion_Cuerpo_Factura(eNotaCredito_Cuerpo_estructura, datosCol, i)
                clsQueryBuilder.ArmaInsert(dfielddefConstantes.Cuerpo_Factura.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                tran.Add(consulta)
                consulta = ""
                datosCol.Clear()
                If (eNotaCredito_Cuerpo_estructura(i).Numero_Articulo = Articulos_Estructura(i).Id_Producto) Then
                    Articulos_Estructura(i).Stock = Articulos_Estructura(i).Stock - eNotaCredito_Cuerpo_estructura(i).Cantidad
                    consulta = "update " + dfielddefConstantes.Producto.ToString() + " set Stock='" + (Articulos_Estructura(i).Stock) + "' where ID_Producto= '" + (eNotaCredito_Cuerpo_estructura(i).Numero_Articulo) + "'"
                    tran.Add(consulta)
                End If
                consulta = ""
            Next

            consulta = ""
            esquema.Clear()
            datosCol.Clear()
            ClavePrincipal.Clear()
            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Encabezado_Factura.ToString(), esquema)
            clsfacturacion.Obtener_Clave_Principal_Encabezado_Factura(ClavePrincipal)
            clsfacturacion.Pasar_A_Coleccion_Encabezado_Factura(Facturacion_Enc_estructura, datosCol, 1)
            clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Encabezado_Factura.ToString(), esquema, datosCol, ClavePrincipal, consulta)
            tran.Add(consulta)
            For idx = 1 To tran.Count
                clsTransaccion.Operaciones_Tabla(tran(idx))
            Next
            tran.Clear()
            valido = True
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
            valido = False
        End Try


    End Sub
End Class
