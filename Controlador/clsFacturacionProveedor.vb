Imports Modelo
Imports System.Windows.Forms
Public Class clsFacturacionProveedor
    Public session As New Controlador.clsSession()
    Private Shared variable As String
    Public Structure eEncabezadoFacturaProveedor
        Public Id_Proveedor As Integer
        Public Punto_Venta As String
        Public Tipo_Comprobante As String
        Public Numero_Comprobante As String
        Public Comprobante As String
        Public Razon_Social As String
        Public Situacion_Frente_A_IVA As String
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
        Public Signo As String
        Public NroPuesto As String
    End Structure
    Public Structure eCuerpoFacturaProveedor
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
        conectar.srt_conexion = session.Session.CadenaConeccion
        conectar.cargar_tabla(tabla, consulta)
    End Sub
    Public Sub se_Cargo(ByVal idPuntoVenta As String, ByVal idNumeroComprobante As String, ByVal idTipoComprobante As String, ByVal idProveedor As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from Encabezado_Factura_Proveedor where Punto_Venta='" + idPuntoVenta + "'and Numero_Comprobante='" + idNumeroComprobante + "'  and  Tipo_Comprobante='" + idTipoComprobante + "' and Id_Proveedor = '" + idProveedor + "'"
        existe = conectar.verificar_existencia(consulta)
    End Sub
    Public Sub Limpiar_Datos_Comprobante(ByRef dgvFacturacionProveedor As DataGridView, ByRef txtSubTotal As TextBox, ByRef txtDescuento As TextBox, ByRef txtIVa As TextBox, ByRef txtTotal As TextBox, ByRef txtRazonSocial As TextBox, ByRef txtDireccion As TextBox, ByRef txtCelular As TextBox, ByRef txtTelefono As TextBox, ByRef txtCondIVA As TextBox, ByRef txtMail As TextBox, ByRef txtLimiteCC As TextBox, ByRef tbPuntoVenta As TextBox, ByRef tbnumeroComprobante As TextBox, ByRef lblTipoComprobante As Label, ByRef lblIdComprobante As Label)
        dgvFacturacionProveedor.DataSource = Nothing
        dgvFacturacionProveedor.Rows.Clear()
        txtSubTotal.Text = "0,00"
        txtDescuento.Text = ""
        txtIVa.Text = "0,00"
        txtTotal.Text = "0,00"

        txtRazonSocial.Text = ""
        txtDireccion.Text = ""
        txtCelular.Text = ""
        txtTelefono.Text = ""
        txtCondIVA.Text = ""
        txtMail.Text = ""
        txtLimiteCC.Text = ""
        tbPuntoVenta.Text = ""
        tbnumeroComprobante.Text = ""
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
        tbCondicionIVA.Text = ""
    End Sub
    Public Sub Limpiar_Datos_Comprobante_Proveedor(ByRef dgvFacturacionProveedor As DataGridView, ByRef txtSubTotal As TextBox, ByRef txtDescuento As TextBox, ByRef txtIVa As TextBox, ByRef txtTotal As TextBox, ByRef txtRazonSocial As TextBox, ByRef txtDireccion As TextBox, ByRef txtCelular As TextBox, ByRef txtTelefono As TextBox, ByRef txtCondIVA As TextBox, ByRef txtMail As TextBox, ByRef txtLimiteCC As TextBox, ByRef txtCodigoPostal As TextBox, ByRef lblTipoComprobante As Label, ByRef lblIdComprobante As Label)
        dgvFacturacionProveedor.DataSource = Nothing
        dgvFacturacionProveedor.Rows.Clear()
        txtSubTotal.Text = "0,00"
        txtDescuento.Text = ""
        txtIVa.Text = "0,00"
        txtTotal.Text = "0,00"

        txtRazonSocial.Text = ""

        txtDireccion.Text = ""
        txtCelular.Text = ""
        txtTelefono.Text = ""
        txtCondIVA.Text = ""
        txtMail.Text = ""
        txtLimiteCC.Text = ""
        txtCodigoPostal.Text = ""
        'txtnumeroComprobante.Text = ""
        lblTipoComprobante.Text = ""
        lblIdComprobante.Text = ""
    End Sub
    Public Sub Pasar_A_Coleccion_Encabezado_Factura_Proveedor(ByVal Factura_Encabezado_Proveedor_estructura() As eEncabezadoFacturaProveedor, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Id_Proveedor)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Punto_Venta)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Tipo_Comprobante)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Numero_Comprobante)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Comprobante)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Razon_Social)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Situacion_Frente_A_IVA)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Forma_Pago)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Fecha_Comprobante)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Codigo_Vendedor)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Neto_Grabado)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Conc_No_Grabado)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Exentos)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).IVA_Facturado)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).IVA_Resp_No_Inscripto)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Persepciones)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Descuentos)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Retenciones)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Total)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Cancelado)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).Signo)
        datos.Add(Factura_Encabezado_Proveedor_estructura(i).NroPuesto)
    End Sub
    Public Sub Pasar_A_Coleccion_Cuerpo_Factura_Proveedor(ByVal Factura_Cuerpo_Proveedor_estructura() As eCuerpoFacturaProveedor, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).IdCuerpoFactura)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).Punto_Venta)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).Tipo_Comprobante)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).Numero_Comprobante)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).Comprobante)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).Numero_Articulo)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).Descripcion)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).Cantidad)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).Precio_Unitario)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).Signo)
        datos.Add(Factura_Cuerpo_Proveedor_estructura(i).NroPuesto)
    End Sub
    Public Sub Obtener_Clave_Principal_Encabezado_Factura_Proveedor(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Proveedor")
        Clave_Princ.Add("Punto_Venta")
        Clave_Princ.Add("Tipo_Comprobante")
        Clave_Princ.Add("Numero_Comprobante")
    End Sub
    Public Sub Obtener_Clave_Principal_Cuerpo_Factura_Proveedor(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("IdCuerpoFactura")
        Clave_Princ.Add("Punto_Venta")
        Clave_Princ.Add("Tipo_Comprobante")
        Clave_Princ.Add("Numero_Comprobante")
    End Sub
    Public Sub Obtener_Datos_Comprobante(ByVal consulta As String, ByRef Datos As DataTable)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        Datos = conectar.consulta_reader(consulta)
    End Sub
    Public Sub Obtener_Datos_Comprobante_Proveedor(ByVal Numero_Condicion_IVA_Proveedor As String, ByVal Numero_Condicion_IVA_Empresa As String, ByVal tipocomprobante As String, ByRef DatoTipoComprobante As eTipoComprobante)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim datos As DataTable
        Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
        conectar.srt_conexion = session.Session.CadenaConeccion
        If tipocomprobante = dfielddefConstantes.FACTURA.ToString() Then
            consulta = "  Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
            consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
            consulta += " inner join ComprobantesProveedor as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
            consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
            consulta += " and C.IdCondFrenteIvaProveedor='" & (Numero_Condicion_IVA_Proveedor) & "' " & vbCrLf
            consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
            consulta += " and TC.IdTipoComprobante in ('1','11','6')"

        End If
        If tipocomprobante = dfielddefConstantes.Nota_De_Credito.ToString() Then
            consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
            consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
            consulta += " inner join ComprobantesProveedor as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
            consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
            consulta += " and C.IdCondFrenteIvaProveedor='" & (Numero_Condicion_IVA_Proveedor) & "' " & vbCrLf
            consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
            consulta += " and TC.IdTipoComprobante in ('3','8','13')"
        End If
        If tipocomprobante = dfielddefConstantes.Nota_De_Debito.ToString() Then
            consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
            consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
            consulta += " inner join ComprobantesProveedor as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
            consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
            consulta += " and C.IdCondFrenteIvaProveedor='" & (Numero_Condicion_IVA_Proveedor) & "' " & vbCrLf
            consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
            consulta += " and TC.IdTipoComprobante in ('2','7','12')"
        End If
        datos = conectar.consulta_reader(consulta)
        DatoTipoComprobante.IdTipoComprobante = datos.Rows(0).Item("IdTipoComprobante")
        DatoTipoComprobante.Descripcion = datos.Rows(0).Item("Descripcion")

    End Sub
    Public Sub Obtener_Datos_Comprobante_Cliente(ByVal Numero_Condicion_IVA_Cliente As String, ByVal Numero_Condicion_IVA_Empresa As String, ByRef DatoTipoComprobante As eTipoComprobante)
        Dim conectar As New coneccion()
        Dim consulta As String
        Dim datos As DataTable
        Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
        conectar.srt_conexion = session.Session.CadenaConeccion
        'If TipoComprobante = dfielddefConstantes.FACTURA.ToString() Then
        consulta = " Select TC.Descripcion" & vbCrLf
        consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
        consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
        consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
        consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
        consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
        consulta += " and TC.IdTipoComprobante in ('1','11','6')"

        'End If
        'If TipoComprobante = dfielddefConstantes.Nota_De_Credito.ToString() Then
        '    consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
        '    consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
        '    consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
        '    consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
        '    consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
        '    consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
        '    consulta += " and TC.IdTipoComprobante in ('3','8','13')"
        '    'datos = conectar.consulta_reader(consulta)
        'End If
        datos = conectar.consulta_reader(consulta)
        DatoTipoComprobante.IdTipoComprobante = datos.Rows(0).Item("IdTipoComprobante")
        DatoTipoComprobante.Descripcion = datos.Rows(0).Item("Descripcion")

    End Sub
    Public Sub Obtener_Tipo_Comprobante_by_Descripcion(ByVal Numero_Condicion_IVA_Empresa As Integer, ByVal Numero_Condicion_IVA_Cliente As Integer, ByVal tipocomprobante As String, ByRef descripcion_Comprobante As String)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select distinct TC.Descripcion from Tipos_Comprobantes as TC,Comprobantes as C where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa.ToString()) & "' and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente.ToString()) & "' and (C.IdComprobantes)=TC.IdTipoComprobante and TC.Descripcion like '" + tipocomprobante + "%'"
        datos = conectar.consulta_reader(consulta)
        descripcion_Comprobante = datos.Rows(0).Item("Descripcion")
    End Sub


    Public Sub Obtener_Tipo_Comprobante(ByVal consulta As String, ByRef descripcion_Comprobante As String)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        conectar.srt_conexion = session.Session.CadenaConeccion
        datos = conectar.consulta_reader(consulta)
        descripcion_Comprobante = datos.Rows(0).Item("Descripcion")
    End Sub
    Public Sub Obtener_Tipo_Comprobante_ID(ByVal consulta As String, ByRef ID_Comprobante As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        conectar.srt_conexion = session.Session.CadenaConeccion
        datos = conectar.consulta_reader(consulta)
        ID_Comprobante = datos.Rows(0).Item("IdTipoComprobante")
    End Sub
    Public Sub sumar_Importe(ByVal datagrid As DataGridView, ByRef totalImporte As Double)
        Dim i As Integer
        totalImporte = 0
        For i = 0 To datagrid.Rows.Count - 1
            totalImporte = totalImporte + Convert.ToDouble(datagrid.Rows(i).Cells(7).Value)
        Next
    End Sub
    Public Sub obtenerTasa(ByVal valor As String, ByRef tasa As Double)
        tasa = (CDbl(valor) / 100) + 1
    End Sub
    Public Sub ObtenerUltimoNumeroCuerpoFacturaProveedor(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select Max(IdCuerpoFactura) as Maximo from Cuerpo_Factura_Proveedor"
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub
End Class
