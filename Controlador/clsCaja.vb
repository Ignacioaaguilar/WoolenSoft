Imports System.Windows.Forms
Imports Modelo
Public Class clsCaja
    Public session As New Controlador.clsSession()
    Private Shared variable As String
    Public Structure eCaja
        Public IdCaja As Integer
        Public Importe As String
        Public FechaApertura As String
        Public FechaCierre As String
        Public NroPuesto As String
        Public Punto_Venta As String
    End Structure

    Public Structure eIngresoEgreso
        Public Id_IngresosEgresos As Integer
        Public Importe As String
        Public Fecha As String
        Public Detalle As String
        Public Signo As String
        Public NroPuesto As String
        Public Punto_Venta As String
    End Structure
    Public Property Compvariable() As String
        Get
            Return Me.variable
        End Get
        Set(ByVal Value As String)
            Me.variable = Value
        End Set
    End Property

    Public Sub Pasar_A_Coleccion(ByVal Caja_estructura() As eCaja, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(Caja_estructura(i).IdCaja)
        datos.Add(Caja_estructura(i).Importe)
        datos.Add(Caja_estructura(i).FechaApertura)
        datos.Add(Caja_estructura(i).FechaCierre)
        datos.Add(Caja_estructura(i).NroPuesto)
        datos.Add(Caja_estructura(i).Punto_Venta)
    End Sub

    Public Sub Pasar_A_ColeccionIngresosEgresos(ByVal IngresosEgresos_estructura() As eIngresoEgreso, ByRef datos As Collection, ByVal i As Integer)
        datos.Add(IngresosEgresos_estructura(i).Id_IngresosEgresos)
        datos.Add(IngresosEgresos_estructura(i).Importe)
        datos.Add(IngresosEgresos_estructura(i).Fecha)
        datos.Add(IngresosEgresos_estructura(i).Detalle)
        datos.Add(IngresosEgresos_estructura(i).Signo)
        datos.Add(IngresosEgresos_estructura(i).NroPuesto)
        datos.Add(IngresosEgresos_estructura(i).Punto_Venta)
    End Sub
    Public Sub Obtener_Clave_Principal(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("IdCaja")
    End Sub
    Public Sub Obtener_Clave_Principal_IngresoEgreso(ByRef Clave_Princ As Collection)
        Clave_Princ.Add("Id_IngresosEgresos")
    End Sub
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
    Public Sub CajaCerrada(ByRef datos As DataTable, ByVal Punto_Venta As String)
        Dim conectar As New coneccion()
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "select * from  Caja where FechaCierre='" & (String.Empty) & "' and NroPuesto ='" & (session.Session.NroPuesto) & "' and Punto_Venta='" & (Punto_Venta) & "'"
        datos = conectar.consulta_reader(consulta)
    End Sub

    Public Sub ObtenerUltimoNumeroCaja(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select Max(IdCaja) as Maximo from Caja"
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub

    Public Sub ObtenerUltimoNumeroIngresoEgresos(ByRef Ultimo As Integer)
        Dim conectar As New coneccion()
        Dim datos As New DataTable
        Dim consulta As String
        conectar.srt_conexion = session.Session.CadenaConeccion
        consulta = "Select Max(Id_IngresosEgresos) as Maximo from IngresosEgresos"
        datos = conectar.consulta_reader(consulta)
        If DBNull.Value.Equals(datos.Rows(0).Item(0)) Then
            Ultimo = 1
        Else
            Ultimo = datos.Rows(0).Item(0)
            Ultimo = Ultimo + 1
        End If
    End Sub

    Public Sub LimpiarDatosEgresosIngresos(ByVal txtFecha As TextBox, ByVal txtImporte As TextBox, ByVal txtDetalle As TextBox)
        txtFecha.Text = String.Empty
        txtImporte.Text = String.Empty
        txtDetalle.text = String.Empty
    End Sub
End Class
