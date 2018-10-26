Imports Modelo
Imports System.Windows.Forms
Public Class clsConfiguracion
    Public session As New Controlador.clsSession()
    Private Shared variable As String

    Public Structure eConfiguracion
        Public Id_Configuracion As Integer
        Public Puerto_Comm As String
        Public Nro_Puerto As String
        Public Nombre_Balanza As String
        Public Lector_Codigo_Barras As String
        Public Lista_Precio As String
        Public Id_Lista_Precio As String
        Public NroPuesto As String
    End Structure
    Public Structure eConfiguracion_Balanza
        Public Id_Balanza As Integer
        Public Id_Marca_Balanza As Integer
        Public Modelo As String
        Public Velocidad As String
        Public Paridad As String
        Public Bits_por_Caracter As String
        Public Bits_paro As String
        Public Handshaking As String
        Public InBufferSize As String
        Public OutBufferSize As String
        Public RThreshold As String
        Public SThreshold As String
        Public InputLen As String
        Public InBufferCount As String
        Public Bit_a_Enviar As String
        Public Caracter_Peso_Estable As String
        Public Caracter_Peso_Inestable As String
    End Structure
    Public Structure eConfiguracionComprobante
        Public Id_Comprobante As String
        Public Descripcion As String
        Public CantidadCopias As Integer
        Public Impresora As String
    End Structure
    Public Property Compvariable() As String
        Get
            Return Me.variable
        End Get
        Set(ByVal Value As String)
            Me.variable = Value
        End Set
    End Property
    Public Sub llenar_tabla_Configuracion_Comprobante(ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim Consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        Consulta = "select Id_Comprobante as [Cod Comprobante],Descripcion,CantidadCopias as [Cant Copias],Impresora from ConfiguracionComprobantes"
        conectar.cargar_tabla(grilla, Consulta)
    End Sub
    Public Sub llenar_tabla_Configuracion(ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        Dim Consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        Consulta = "Select Id_Configuracion as [Cod Configuracion] ,Puerto_Comm as [Puerto Comm],Nro_Puerto as [Num Puerto],Nombre_Balanza as [Nom Balanza],Lector_Codigo_Barras as [Lector Cod Barras],Id_Lista_Precio as [Cod Lista Precio],Lista_Precio as [Desc Lista Precio] from Configuracion"
        conectar.cargar_tabla(grilla, Consulta)
    End Sub
    Public Sub llenar_Combo_Configuracion(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
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
    Function validateDoublesAndCurrency_Comfiguracion(ByVal stringValue As String) As Boolean
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
    Public Sub se_Cargo(ByVal consulta As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        conectar.srt_conexion = session.Session.CadenaConeccion
        existe = conectar.verificar_existencia(consulta)
    End Sub
    Public Sub Existe(ByVal idComprobante As String, ByRef existe As Boolean)
        Dim conectar As New coneccion()
        Dim consulta As String
        consulta = "select * from ConfiguracionComprobantes where Id_Comprobante='" + idComprobante + "' "
        conectar.srt_conexion = session.Session.CadenaConeccion
        existe = conectar.verificar_existencia(consulta)
    End Sub
    Public Sub Limpiar_Datos_ConfiguracionComprobantes(ByRef tbImpresoraFactA As TextBox, ByRef tbCantCopFactA As TextBox, ByRef tbImpresoraFactB As TextBox, ByRef tbCantCopFactB As TextBox, ByRef tbImpresoraFactC As TextBox, ByRef tbCantCopFactC As TextBox, ByRef tbImpresoraNCA As TextBox, ByRef tbCantCopNCA As TextBox, ByRef tbImpresoraNCB As TextBox, ByRef tbCantCopNCB As TextBox, ByRef tbImpresoraNCC As TextBox, ByRef tbCantCopNCC As TextBox, ByRef tbImpresoraNDA As TextBox, ByRef tbCantCopNDA As TextBox, ByRef tbImpresoraNDB As TextBox, ByRef tbCantCopNBB As TextBox, ByRef tbImpresoraNDC As TextBox, ByRef tbCantCopNDC As TextBox, ByRef tbImpresoraVRA As TextBox, ByRef tbCantCopVRA As TextBox, ByRef tbImpresoraVRB As TextBox, ByRef tbCantCopVRB As TextBox, ByRef tbImpresoraVRC As TextBox, ByRef tbCantCopVRC As TextBox)
        tbImpresoraFactA.Text = String.Empty
        tbCantCopFactA.Text = 0
        tbImpresoraFactB.Text = String.Empty
        tbCantCopFactB.Text = 0
        tbImpresoraFactC.Text = String.Empty
        tbCantCopFactC.Text = 0

        tbImpresoraNCA.Text = String.Empty
        tbCantCopNCA.Text = 0
        tbImpresoraNCB.Text = String.Empty
        tbCantCopNCB.Text = 0
        tbImpresoraNCC.Text = String.Empty
        tbCantCopNCC.Text = 0

        tbImpresoraNDA.Text = String.Empty
        tbCantCopNDA.Text = 0
        tbImpresoraNDB.Text = String.Empty
        tbCantCopNBB.Text = 0
        tbImpresoraNDC.Text = String.Empty
        tbCantCopNDC.Text = 0

        tbImpresoraVRA.Text = String.Empty
        tbCantCopVRA.Text = 0
        tbImpresoraVRB.Text = String.Empty
        tbCantCopVRB.Text = 0
        tbImpresoraVRC.Text = String.Empty
        tbCantCopVRC.Text = 0
    End Sub
    Public Sub Limpiar_Datos_Configuracion(ByRef cbDescripcionBalanza As ComboBox, ByRef cbHabilitarCodigoBarra As CheckBox)
        cbDescripcionBalanza.Text = ""
        cbHabilitarCodigoBarra.Checked = False
    End Sub
    Public Sub Pasar_A_Coleccion_Configuracion(ByVal Configuracion() As eConfiguracion, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(Configuracion(i).Id_Configuracion)
        datos.Add(Configuracion(i).Puerto_Comm)
        datos.Add(Configuracion(i).Nro_Puerto)
        datos.Add(Configuracion(i).Nombre_Balanza)
        datos.Add(Configuracion(i).Lector_Codigo_Barras)
        datos.Add(Configuracion(i).Lista_Precio)
        datos.Add(Configuracion(i).Id_Lista_Precio)
        datos.Add(Configuracion(i).NroPuesto)

    End Sub
    Public Sub Obtener_Clave_Principal_Configuracion(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Configuracion")
    End Sub
    Public Sub Pasar_A_Coleccion_ConfiguracionComprobantes(ByVal Configuracion() As eConfiguracionComprobante, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(Configuracion(i).Id_Comprobante)
        datos.Add(Configuracion(i).Descripcion)
        datos.Add(Configuracion(i).CantidadCopias)
        datos.Add(Configuracion(i).Impresora)
    End Sub
    Public Sub Obtener_Clave_Principal_ConfiguracionComprobante(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Comprobante")
    End Sub
    Public Sub Obtener_Datos_Configuracion(ByRef Datos_Configuracion As eConfiguracion)
        Dim conectar As New coneccion()
        Dim Datos As New DataTable
        conectar.srt_conexion = session.Session.CadenaConeccion
        Dim Consulta = "Select * from Configuracion"
        Datos = conectar.consulta_reader(Consulta)
        If Datos.Rows.Count > 0 Then
            PasarDatosConfiguracionAEstructura(Datos, Datos_Configuracion)
        End If
    End Sub
    Private Sub PasarDatosConfiguracionAEstructura(ByVal Datos As DataTable, ByRef Datos_Configuracion As eConfiguracion)
        Dim dfielddefConfiguracion As Controlador.clsDfieldDef.eConfiguracion
        Datos_Configuracion.Id_Configuracion = Datos.Rows(0).Item(dfielddefConfiguracion.Id_Configuracion.ToString())
        Datos_Configuracion.Id_Lista_Precio = Datos.Rows(0).Item(dfielddefConfiguracion.Id_Lista_Precio.ToString())
        Datos_Configuracion.Lector_Codigo_Barras = Datos.Rows(0).Item(dfielddefConfiguracion.Lector_Codigo_Barras.ToString())
        Datos_Configuracion.Lista_Precio = Datos.Rows(0).Item(dfielddefConfiguracion.Lista_Precio.ToString())
        Datos_Configuracion.Id_Lista_Precio = Datos.Rows(0).Item(dfielddefConfiguracion.Id_Lista_Precio.ToString())
        Datos_Configuracion.Nombre_Balanza = Datos.Rows(0).Item(dfielddefConfiguracion.Nombre_Balanza.ToString())
        Datos_Configuracion.Puerto_Comm = Datos.Rows(0).Item(dfielddefConfiguracion.Puerto_Comm.ToString())
        Datos_Configuracion.Nro_Puerto = Datos.Rows(0).Item(dfielddefConfiguracion.Nro_Puerto.ToString())
        Datos_Configuracion.NroPuesto = Datos.Rows(0).Item(dfielddefConfiguracion.NroPuesto.ToString())

    End Sub
    Public Sub ObtenerUltimoConfiguracion(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select max(Id_Configuracion) from Configuracion "
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub
    Sub GetSerialPortNames(ByRef puertocom As Collection)
        ' Show all available COM ports.
        For Each sp As String In My.Computer.Ports.SerialPortNames
            'ListBox1.Items.Add(sp)
            puertocom.Add(sp)
        Next
    End Sub
    Public Sub ObtenerNumeroPuerto(ByVal Puerto As String, ByRef Numero As String)
        Numero = ""
        For i As Integer = 1 To Len(Puerto)
            If IsNumeric(Mid(Puerto, i, 1)) Then
                Numero = Numero + Mid(Puerto, i, 1)
            End If
        Next
        If Len(Puerto) = 0 Then
            Numero = 0
        End If
    End Sub
    Public Sub Esta_En_Coleccion(ByVal valor As String, ByVal estructura() As eConfiguracionComprobante, ByRef existe As Boolean, ByRef pos As Integer)
        Dim i As Integer
        pos = -1
        existe = False
        i = 1
        While Not existe And (i <= estructura.Count - 1)
            If (valor = estructura(i).Id_Comprobante) Then
                existe = True
                pos = i
            Else
                i = i + 1
            End If
        End While
    End Sub

    Public Sub Obtener_Datos_Configuracion_Balanza(ByRef Datos_Configuracion_Balanza As eConfiguracion_Balanza, ByVal Modelo As String)
        Dim conectar As New coneccion()
        Dim Datos As New DataTable
        conectar.srt_conexion = session.Session.CadenaConeccion
        Dim Consulta = "Select * from Balanza where Modelo='" & (Modelo) & "'"
        Datos = conectar.consulta_reader(Consulta)
        If Datos.Rows.Count > 0 Then
            PasarDatosConfiguracionAEstructura_Balanza(Datos, Datos_Configuracion_Balanza)
        End If
    End Sub

    Private Sub PasarDatosConfiguracionAEstructura_Balanza(ByVal Datos As DataTable, ByRef Datos_Configuracion_Balanza As eConfiguracion_Balanza)
        Dim dfielddefConfiguracionBalanza As Controlador.clsDfieldDef.eConfiguracionBalanza
        Datos_Configuracion_Balanza.Id_Balanza = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Id_Balanza.ToString())
        Datos_Configuracion_Balanza.Id_Marca_Balanza = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Id_Marca_Balanza.ToString())
        Datos_Configuracion_Balanza.Modelo = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Modelo.ToString())
        Datos_Configuracion_Balanza.Velocidad = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Velocidad.ToString())
        Datos_Configuracion_Balanza.Paridad = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Paridad.ToString())
        Datos_Configuracion_Balanza.Bits_por_Caracter = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Bits_por_Caracter.ToString())
        Datos_Configuracion_Balanza.Bits_paro = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Bits_paro.ToString())
        Datos_Configuracion_Balanza.Handshaking = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Handshaking.ToString())
        Datos_Configuracion_Balanza.InBufferSize = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.InBufferSize.ToString())
        Datos_Configuracion_Balanza.OutBufferSize = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.OutBufferSize.ToString())
        Datos_Configuracion_Balanza.RThreshold = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.RThreshold.ToString())
        Datos_Configuracion_Balanza.SThreshold = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.SThreshold.ToString())
        Datos_Configuracion_Balanza.InputLen = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.InputLen.ToString())
        Datos_Configuracion_Balanza.InBufferCount = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.InBufferCount.ToString())
        Datos_Configuracion_Balanza.Bit_a_Enviar = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Bit_a_Enviar.ToString())
        Datos_Configuracion_Balanza.Caracter_Peso_Estable = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Caracter_Peso_Estable.ToString())
        Datos_Configuracion_Balanza.Caracter_Peso_Inestable = Datos.Rows(0).Item(dfielddefConfiguracionBalanza.Caracter_Peso_Inestable.ToString())
    End Sub

    Public Sub Obtener_Clave_Principal_Configuracion_Balanza(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_Balanza")
        Clave_Princ.Add("Id_Marca_Balanza")
        Clave_Princ.Add("Modelo")
    End Sub
End Class



