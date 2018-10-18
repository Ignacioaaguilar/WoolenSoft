Public Class Articulos_ListaPrecios
    Dim ArticuloListaPrecio_estructura(0) As Controlador.Articulos.eArticuloCuerpoDocumento
    Dim dfielddefListaPrecio As Controlador.DfieldDef.eListaPrecio
    Dim dfieldefConstantes As Controlador.DfieldDef.eConstantes
    Dim dfielddefTasaIva As Controlador.DfieldDef.eTasaIVA
    Dim dfielddefProducto As Controlador.DfieldDef.eArticuloCuerpoDocumento
    Dim TasasIVA As Controlador.TasaIVA.eTasaIVA
    Dim ArticuloListaPrecios As Controlador.Articulos.eProductoListaPrecios
    Public Sub New(ByVal tasaIVA As Controlador.TasaIVA.eTasaIVA, ByVal articuloListaPrecio As Controlador.Articulos.eProductoListaPrecios)
        TasasIVA = tasaIVA
        If articuloListaPrecio.Id_Lista_Precio <> Nothing Then
            ArticuloListaPrecios = articuloListaPrecio
        End If
        InitializeComponent()
    End Sub
   

Private Sub SalirArticuloListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirArticuloListaPrecio.Click
        Dim articulo As New Controlador.Articulos
        articulo.Limpiar_Datos_Articulo_Lista_Precio(TBPrecioCosto, TBRentabilidad, TBPrecioVenta, TBPrecioKilo)
        ArticulosAltas.BtnAgregarListaPrecio.Enabled = True
        ArticulosAltas.BtnModificarListaPrecio.Enabled = False
        ArticulosAltas.BtnEliminarListaPrecio.Enabled = False
        For x As Integer = ProgressBarArticulosListaPrecio.Minimum To ProgressBarArticulosListaPrecio.Maximum
            ProgressBarArticulosListaPrecio.Value = x
        Next
        For x As Integer = ProgressBarArticulosListaPrecio.Maximum To ProgressBarArticulosListaPrecio.Minimum Step -1
            ProgressBarArticulosListaPrecio.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub Articulos_ListaPrecios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            ArticulosAltas.BtnAgregarListaPrecio.Enabled = True
            ArticulosAltas.BtnModificarListaPrecio.Enabled = False
            ArticulosAltas.BtnEliminarListaPrecio.Enabled = False
        End If
    End Sub
    Private Sub Articulos_ListaPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim articulo As New Controlador.Articulos
        Dim consulta As String
        Dim datosListaPrecio As Controlador.Lista_Precios.eListaPrecio
        Try
            If (articulo.Compvariable_Articulo = dfieldefConstantes.Agregar_Lista_Precio.ToString()) Then
                'consulta = "Select * from " + dfieldefConstantes.Lista_Precio.ToString() + ""
                Lista_Precio.llenar_Combo_ListaPrecio(CBListaPrecio, "Descripcion", "Id_Lista_Precio")
                'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
                Lista_Precio.recuperar_Datos(CInt(CBListaPrecio.Text), datosListaPrecio)
                'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()
                LBListaPrecioDescripcion.Text = datosListaPrecio.Descripcion

            Else
                If (articulo.Compvariable_Articulo = dfieldefConstantes.Modificar_Lista_Precio.ToString()) Then

                    TBCodigoProducto.Text = ArticuloListaPrecios.Id_Producto
                    CBListaPrecio.Text = ArticuloListaPrecios.Id_Lista_Precio
                    TBPrecioCosto.Text = ArticuloListaPrecios.Precio_Costo
                    TBRentabilidad.Text = ArticuloListaPrecios.Rentabilidad
                    TBPrecioVenta.Text = ArticuloListaPrecios.Precio_Venta
                    TBPrecioKilo.Text = ArticuloListaPrecios.Precio_Kilo

                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub CBListaPrecio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBListaPrecio.GotFocus
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim consulta As String
        Dim datosListaPrecio As Controlador.Lista_Precios.eListaPrecio
        Try
            'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
            ''Lista_Precio.recuperar_Datos(consulta, datos)
            'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()

            'consulta = "Select * from " + dfieldefConstantes.Lista_Precio.ToString() + ""
            'Lista_Precio.llenar_Combo_ListaPrecio(CBListaPrecio, "Descripcion", "Id_Lista_Precio")
            'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
            Lista_Precio.recuperar_Datos(CInt(CBListaPrecio.Text), datosListaPrecio)
            'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()
            LBListaPrecioDescripcion.Text = datosListaPrecio.Descripcion


        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub CBListaPrecio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBListaPrecio.LostFocus
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim consulta As String
        Dim datosListaPrecio As Controlador.Lista_Precios.eListaPrecio
        Try
            'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
            ''Lista_Precio.recuperar_Datos(consulta, datos)
            'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()

            'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
            ''Lista_Precio.recuperar_Datos(consulta, datos)
            'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()

            'consulta = "Select * from " + dfieldefConstantes.Lista_Precio.ToString() + ""
            'Lista_Precio.llenar_Combo_ListaPrecio(CBListaPrecio, "Descripcion", "Id_Lista_Precio")
            'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
            Lista_Precio.recuperar_Datos(CInt(CBListaPrecio.Text), datosListaPrecio)
            'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()
            LBListaPrecioDescripcion.Text = datosListaPrecio.Descripcion


        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBPrecioCosto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBPrecioCosto.LostFocus
        Dim articulo As New Controlador.Articulos
        Dim tasaiava As New Controlador.TasaIVA()
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim consulta As String
        Dim Tasa As Double
        Dim datos As DataTable
        Dim PrecioVenta_Con_Rentabilidad As Double
        Dim PrecioVenta_Con_IVA_Y_Rentabilidad As Double
        Dim valor_PrecioCosto As Double
        Dim valor_Rentabilidad As Double
        Dim datosListaPrecio As Controlador.Lista_Precios.eListaPrecio
        Dim datosTasa As New DataTable
        Dim TasaIVA As New Controlador.TasaIVA
        Try
            'consulta = "select * from " + dfieldefConstantes.Tasa_IVA.ToString() + ""
            'tasaiava.recuperar_Datos(consulta, datos)
            'Tasa = CDbl(datos.Rows(0)("Tasa").ToString())


            TasaIVA.recuperar_Datos(TasasIVA.Id_Tasa_IVA, datosTasa)
            Tasa = CDbl(Replace(datosTasa.Rows(0)("Tasa").ToString(), ",", "."))
            If (TBPrecioCosto.Text <> "") And (TBRentabilidad.Text <> "") Then
                valor_PrecioCosto = Replace(TBPrecioCosto.Text, ".", ",")
                valor_Rentabilidad = Replace(TBRentabilidad.Text, ".", ",")
                PrecioVenta_Con_Rentabilidad = CDbl(valor_PrecioCosto) + (CDbl(valor_PrecioCosto) * CDbl(valor_Rentabilidad) / 100)
                PrecioVenta_Con_IVA_Y_Rentabilidad = CDbl(PrecioVenta_Con_Rentabilidad) + ((CDbl(PrecioVenta_Con_Rentabilidad) * CDbl(Tasa)) / 100)
                TBPrecioVenta.Text = Format((PrecioVenta_Con_IVA_Y_Rentabilidad), "0.00")


                'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
                ''Lista_Precio.recuperar_Datos(consulta, ')
                'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()


                'consulta = "Select * from " + dfieldefConstantes.Lista_Precio.ToString() + ""
                'Lista_Precio.llenar_Combo_ListaPrecio(CBListaPrecio, "Descripcion", "Id_Lista_Precio")
                'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
                Lista_Precio.recuperar_Datos(CInt(CBListaPrecio.Text), datosListaPrecio)
                'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()
                LBListaPrecioDescripcion.Text = datosListaPrecio.Descripcion


            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBPrecioCosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBPrecioCosto.TextChanged
        Dim articulo As New Controlador.Articulos
        Dim consulta As String
        Dim Tasa As Double
        Dim datos As DataTable
        Dim PrecioVenta_Con_Rentabilidad As Double
        Dim PrecioVenta_Con_IVA_Y_Rentabilidad As Double
        Dim valor_PrecioCosto As Double
        Dim valor_Rentabilidad As Double
        Dim datosTasa As New DataTable
        Dim TasaIVA As New Controlador.TasaIVA()
        'Dim Datos_Configuracion As New DataTable
        Dim Configuracion As New Controlador.Configuracion
        Try
            If Not (articulo.validateDoublesAndCurrency_Articulo(TBPrecioCosto.Text)) Then
                TBPrecioCosto.Text = String.Empty
            Else
                'consulta = "Select * from " + dfieldefConstantes.Producto.ToString() + " where Id_Producto='" + TBCodigoProducto.Text + "'"
                articulo.ObtenerProductos(TBCodigoProducto.Text, datos)
                If datos.Rows.Count > 0 Then
                    consulta = String.Empty
                    'consulta = "Select * from Configuracion"
                    'Configuracion.Obtener_Datos_Configuracion(Datos_Configuracion)
                    'If Datos_Configuracion.Rows.Count > 0 Then
                    'consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "

                    TasaIVA.recuperar_Datos(TasasIVA.Id_Tasa_IVA, datosTasa)
                    If datosTasa.Rows.Count > 0 Then
                        Tasa = CDbl(Replace(datosTasa.Rows(0)("Tasa").ToString(), ",", "."))
                        If (TBPrecioCosto.Text <> "") And (TBRentabilidad.Text <> "") Then
                            valor_PrecioCosto = Replace(TBPrecioCosto.Text, ".", ",")
                            valor_Rentabilidad = Replace(TBRentabilidad.Text, ".", ",")
                            PrecioVenta_Con_Rentabilidad = CDbl(valor_PrecioCosto) + (CDbl(valor_PrecioCosto) * CDbl(valor_Rentabilidad) / 100)
                            PrecioVenta_Con_IVA_Y_Rentabilidad = CDbl(PrecioVenta_Con_Rentabilidad) + ((CDbl(PrecioVenta_Con_Rentabilidad) * CDbl(Tasa)) / 100)
                            TBPrecioVenta.Text = Format((PrecioVenta_Con_IVA_Y_Rentabilidad), "0.00")
                        End If
                    End If
                    'End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBRentabilidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBRentabilidad.LostFocus
        Dim articulo As New Controlador.Articulos
        Dim tasaiava As New Controlador.TasaIVA()
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim consulta As String
        Dim Tasa As Double
        Dim datos As DataTable
        Dim PrecioVenta_Con_Rentabilidad As Double
        Dim PrecioVenta_Con_IVA_Y_Rentabilidad As Double
        Dim valor_PrecioCosto As Double
        Dim valor_Rentabilidad As Double
        Dim datosTasa As DataTable
        Dim TasaIVA As New Controlador.TasaIVA
        Dim DatosListaPrecio As Controlador.Lista_Precios.eListaPrecio
        Try
            'consulta = "Select * from " + dfieldefConstantes.Producto.ToString() + " where Id_Producto='" + TBCodigoProducto.Text + "'"
            articulo.ObtenerProductos(TBCodigoProducto.Text, datos)
            If datos.Rows.Count > 0 Then
                'consulta = "select * from " + dfieldefConstantes.Tasa_IVA.ToString() + " where Tasa='" + datos.Rows(0).Item(dfielddefProducto.Id_Tasa_IVA) + "'"
                'tasaiava.recuperar_Datos(consulta, datos)
                TasaIVA.recuperar_Datos(TasasIVA.Id_Tasa_IVA, datosTasa)
                Tasa = CDbl(Replace(datosTasa.Rows(0)("Tasa").ToString(), ",", "."))

                'If datos.Rows.Count > 0 Then
                'Tasa = CDbl(datos.Rows(0)("Tasa").ToString())
                Tasa = CDbl(Replace(datosTasa.Rows(0)("Tasa").ToString(), ",", "."))
                If (TBPrecioCosto.Text <> "") And (TBRentabilidad.Text <> "") Then
                    valor_PrecioCosto = Replace(TBPrecioCosto.Text, ".", ",")
                    valor_Rentabilidad = Replace(TBRentabilidad.Text, ".", ",")
                    PrecioVenta_Con_Rentabilidad = CDbl(valor_PrecioCosto) + (CDbl(valor_PrecioCosto) * CDbl(valor_Rentabilidad) / 100)
                    PrecioVenta_Con_IVA_Y_Rentabilidad = CDbl(PrecioVenta_Con_Rentabilidad) + ((CDbl(PrecioVenta_Con_Rentabilidad) * CDbl(Tasa)) / 100)
                    TBPrecioVenta.Text = Format((PrecioVenta_Con_IVA_Y_Rentabilidad), "0.00")
                    'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
                    Lista_Precio.recuperar_Datos(CInt(CBListaPrecio.Text), DatosListaPrecio)
                    'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()
                    LBListaPrecioDescripcion.Text = DatosListaPrecio.Descripcion
                End If
            End If
            ' End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBRentabilidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBRentabilidad.TextChanged
        Dim articulo As New Controlador.Articulos
        Dim tasaiava As New Controlador.TasaIVA()
        Dim consulta As String
        Dim Tasa As Double
        Dim datos As DataTable
        Dim PrecioVenta_Con_Rentabilidad As Double
        Dim PrecioVenta_Con_IVA_Y_Rentabilidad As Double
        Dim valor_PrecioCosto As Double
        Dim valor_Rentabilidad As Double
        Dim datosTasa As New DataTable
        Dim TasaIVA As New Controlador.TasaIVA()
        Dim Datos_Configuracion As New DataTable
        Dim Configuracion As New Controlador.Configuracion
        Try
            If Not (articulo.validateDoublesAndCurrency_Articulo(TBRentabilidad.Text)) Then
                TBRentabilidad.Text = ""
            Else
                'consulta = "Select * from " + dfieldefConstantes.Producto.ToString() + " where Id_Producto='" + TBCodigoProducto.Text + "'"
                articulo.ObtenerProductos(TBCodigoProducto.Text, datos)
                If datos.Rows.Count > 0 Then
                    consulta = String.Empty
                    'consulta = "Select * from Configuracion"
                    'Configuracion.Obtener_Datos_Configuracion(consulta, Datos_Configuracion)
                    ' consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                    ' TasaIVA.recuperar_Datos(consulta, datosTasa)
                    'If datosTasa.Rows.Count > 0 Then

                    'Tasa = CDbl(Replace(datosTasa.Rows(0)("Tasa").ToString(), ",", "."))

                    TasaIVA.recuperar_Datos(TasasIVA.Id_Tasa_IVA, datosTasa)
                    Tasa = CDbl(Replace(datosTasa.Rows(0)("Tasa").ToString(), ",", "."))
                    If (TBPrecioCosto.Text <> "") And (TBRentabilidad.Text <> "") Then
                        valor_PrecioCosto = Replace(TBPrecioCosto.Text, ".", ",")
                        valor_Rentabilidad = Replace(TBRentabilidad.Text, ".", ",")
                        PrecioVenta_Con_Rentabilidad = CDbl(valor_PrecioCosto) + (CDbl(valor_PrecioCosto) * CDbl(valor_Rentabilidad) / 100)
                        PrecioVenta_Con_IVA_Y_Rentabilidad = CDbl(PrecioVenta_Con_Rentabilidad) + ((CDbl(PrecioVenta_Con_Rentabilidad) * CDbl(Tasa)) / 100)
                        TBPrecioVenta.Text = Format((PrecioVenta_Con_IVA_Y_Rentabilidad), "0.00")
                    End If
                End If
            End If
            ' End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBPrecioKilo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBPrecioKilo.TextChanged
        Dim articulo As New Controlador.Articulos
        If Not (articulo.validateDoublesAndCurrency_Articulo(TBPrecioKilo.Text)) Then
            TBPrecioKilo.Text = ""
        End If
    End Sub
    Private Sub TBPrecioVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBPrecioVenta.TextChanged
        Dim articulo As New Controlador.Articulos
        Dim tasaiava As New Controlador.TasaIVA()
        Dim consulta As String
        Dim Tasa As Double
        Dim datos As DataTable
        Dim PrecioVenta_Con_Rentabilidad As Double
        Dim PrecioVenta_Con_IVA_Y_Rentabilidad As Double
        Dim valor_PrecioCosto As Double
        Dim valor_Rentabilidad As Double
        Dim datosTasa As New DataTable
        Dim TasaIVA As New Controlador.TasaIVA()
        Dim Datos_Configuracion As New DataTable
        Dim Configuracion As New Controlador.Configuracion
        Try
            'consulta = "Select * from " + dfieldefConstantes.Producto.ToString() + " where Id_Producto='" + TBCodigoProducto.Text + "'"
            articulo.ObtenerProductos(TBCodigoProducto.Text, datos)
            If datos.Rows.Count > 0 Then
                consulta = String.Empty
                'consulta = "Select * from Configuracion"
                'Configuracion.Obtener_Datos_Configuracion(consulta, Datos_Configuracion)
                'consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                'TasaIVA.recuperar_Datos(consulta, datosTasa)
                'If datosTasa.Rows.Count > 0 Then
                'Tasa = CDbl(Replace(datosTasa.Rows(0)("Tasa").ToString(), ",", "."))

                TasaIVA.recuperar_Datos(TasasIVA.Id_Tasa_IVA, datosTasa)
                Tasa = CDbl(Replace(datosTasa.Rows(0)("Tasa").ToString(), ",", "."))
                If (TBPrecioCosto.Text <> "") And (TBRentabilidad.Text <> "") Then
                    valor_PrecioCosto = Replace(TBPrecioCosto.Text, ".", ",")
                    valor_Rentabilidad = Replace(TBRentabilidad.Text, ".", ",")
                    PrecioVenta_Con_Rentabilidad = CDbl(valor_PrecioCosto) + (CDbl(valor_PrecioCosto) * CDbl(valor_Rentabilidad) / 100)
                    PrecioVenta_Con_IVA_Y_Rentabilidad = CDbl(PrecioVenta_Con_Rentabilidad) + ((CDbl(PrecioVenta_Con_Rentabilidad) * CDbl(Tasa)) / 100)
                    TBPrecioVenta.Text = Format((PrecioVenta_Con_IVA_Y_Rentabilidad), "0.00")
                End If
            End If
            'End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub GuardarArticuloListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarArticuloListaPrecio.Click
        Dim articulo As New Controlador.Articulos
        Dim consulta As String
        Dim existe As Boolean
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim UltimaFila As Integer
        Try
            If (articulo.Compvariable_Articulo = dfieldefConstantes.Agregar_Lista_Precio.ToString()) Then
                If (CBListaPrecio.Text <> "" And TBCodigoProducto.Text <> "" And TBPrecioCosto.Text <> "" And TBRentabilidad.Text <> "" And TBPrecioVenta.Text <> "" And TBPrecioKilo.Text <> "") Then
                    'consulta = "select * from  " + dfieldefConstantes.Producto.ToString() + " where Id_Producto='" & (TBCodigoProducto.Text) & "'"
                    articulo.se_Cargo_articulo(TBCodigoProducto.Text, existe)
                    If (existe) Then
                        'consulta = "Select * from " + dfieldefConstantes.Producto_Lista_Precio.ToString() + "  where Id_Producto='" & (TBCodigoProducto.Text) & "' and Id_Lista_Precio='" & (CBListaPrecio.Text) & "'"
                        articulo.se_CargoProducto_Lista_Precio(CBListaPrecio.Text, TBCodigoProducto.Text, existe)
                        If Not (existe) Then
                            ReDim ArticuloListaPrecio_estructura(1)
                            ArticuloListaPrecio_estructura(1).IdListaPrecio = CBListaPrecio.Text
                            ArticuloListaPrecio_estructura(1).IdProducto = TBCodigoProducto.Text
                            ArticuloListaPrecio_estructura(1).DescListaPrecio = LBListaPrecioDescripcion.Text.Trim()
                            ArticuloListaPrecio_estructura(1).PrecioCosto = Replace(TBPrecioCosto.Text, ".", ",")
                            ArticuloListaPrecio_estructura(1).Rentabilidad = Replace(TBRentabilidad.Text, ".", ",")
                            ArticuloListaPrecio_estructura(1).PrecioVenta = Replace(TBPrecioVenta.Text, ".", ",")
                            ArticuloListaPrecio_estructura(1).PrecioKilo = Replace(TBPrecioKilo.Text, ".", ",")
                            If (ArticulosAltas.CBPesable.Text = dfieldefConstantes.Si.ToString()) Then
                                Try
                                    consulta = String.Empty
                                    querybuilder.obtener_estructura(dfieldefConstantes.Producto_Lista_Precio.ToString(), esquema)
                                    articulo.Obtener_Clave_PrincipalListaPrecio(ClavePrincipal)
                                    articulo.Pasar_A_ColeccionArticuloListaPrecio(ArticuloListaPrecio_estructura, datos, 1)
                                    querybuilder.ArmaInsert(dfieldefConstantes.Producto_Lista_Precio.ToString(), esquema, datos, ClavePrincipal, consulta)
                                    articulo.Operaciones_QueryBuilder(consulta)

                                    'consulta = " Select plp.Id_Lista_Precio as [Cod Lista Precio],lp.Descripcion,Id_Producto as [Cod Producto],Precio_Costo as [Precio Costo],Rentabilidad,Precio_Venta as [Precio Venta],Precio_Kilo as [Precio Kilo]  " & vbCrLf
                                    'consulta += "from Producto_Lista_Precio as  plp" & vbCrLf
                                    'consulta += "inner join  Lista_Precio as  lp on (Cint(plp.Id_Lista_Precio)=lp.Id_Lista_Precio)" & vbCrLf
                                    'consulta += "where Id_Producto='" & (ArticuloListaPrecio_estructura(1).Id_Producto) & "' " & vbCrLf
                                    articulo.llenar_tabla_Producto_Lista_Precio_Lista_Precio(ArticulosAltas.DGVListaPrecio, ArticuloListaPrecio_estructura(1).IdProducto)

                                    MessageBox.Show("Los Datos de la Lista de Precio del Articulo, se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                                 MessageBoxIcon.Information)
                                    articulo.Limpiar_Datos_Articulo_Lista_Precio(TBPrecioCosto, TBRentabilidad, TBPrecioVenta, TBPrecioKilo)
                                    LimpiarEstructuras()
                                    esquema.Clear()
                                    datos.Clear()
                                    consulta = String.Empty
                                Catch ex As Exception
                                    MsgBox("Error:" & vbCrLf & ex.Message)
                                End Try
                            Else
                                Try
                                    consulta = ""
                                    querybuilder.obtener_estructura(dfieldefConstantes.Producto_Lista_Precio.ToString(), esquema)
                                    articulo.Obtener_Clave_PrincipalListaPrecio(ClavePrincipal)
                                    articulo.Pasar_A_ColeccionArticuloListaPrecio(ArticuloListaPrecio_estructura, datos, 1)
                                    querybuilder.ArmaInsert(dfieldefConstantes.Producto_Lista_Precio.ToString(), esquema, datos, ClavePrincipal, consulta)
                                    articulo.Operaciones_QueryBuilder(consulta)
                                    'consulta = " Select plp.Id_Lista_Precio as [Cod Lista Precio] ,lp.Descripcion,Id_Producto as [Cod Producto],Precio_Costo as [Precio Costo],Rentabilidad,Precio_Venta as [Precio Venta],Precio_Kilo as [Precio Kilo]  " & vbCrLf
                                    'consulta += "from Producto_Lista_Precio as  plp" & vbCrLf
                                    'consulta += "inner join  Lista_Precio as  lp on (Cint(plp.Id_Lista_Precio)=lp.Id_Lista_Precio)" & vbCrLf
                                    'consulta += "where Id_Producto='" & (ArticuloListaPrecio_estructura(1).Id_Producto) & "' " & vbCrLf
                                    articulo.llenar_tabla_Producto_Lista_Precio_Lista_Precio(ArticulosAltas.DGVListaPrecio, ArticuloListaPrecio_estructura(1).IdProducto)
                                    MessageBox.Show("Los Datos de la Lista de Precio del Articulo, se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                                 MessageBoxIcon.Information)
                                    articulo.Limpiar_Datos_Articulo_Lista_Precio(TBPrecioCosto, TBRentabilidad, TBPrecioVenta, TBPrecioKilo)
                                    LimpiarEstructuras()
                                    esquema.Clear()
                                    datos.Clear()
                                    consulta = ""
                                Catch ex As Exception
                                    MsgBox("Error:" & vbCrLf & ex.Message)
                                End Try
                            End If
                        Else
                            MessageBox.Show("Error: La Lista de Precio,no se pudo registrar. Fue Ingresada Anteriormente!!!", "Informacion", MessageBoxButtons.OK, _
                                                                             MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Error: La Lista de Precio,no se pudo registrar. No Existe el Producto!!!", "Informacion", MessageBoxButtons.OK, _
                                                                         MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
                End If
            Else
                If (articulo.Compvariable_Articulo = dfieldefConstantes.Modificar_Lista_Precio.ToString()) Then
                    If (TBCodigoProducto.Text <> "" And TBPrecioCosto.Text <> "" And TBRentabilidad.Text <> "" And TBPrecioVenta.Text <> "" And TBPrecioKilo.Text <> "") Then

                        ReDim ArticuloListaPrecio_estructura(1)
                        ArticuloListaPrecio_estructura(1).IdListaPrecio = CBListaPrecio.Text
                        ArticuloListaPrecio_estructura(1).IdProducto = TBCodigoProducto.Text
                        ArticuloListaPrecio_estructura(1).DescListaPrecio = LBListaPrecioDescripcion.Text.Trim()
                        ArticuloListaPrecio_estructura(1).PrecioCosto = Replace(TBPrecioCosto.Text, ".", ",")
                        ArticuloListaPrecio_estructura(1).Rentabilidad = Replace(TBRentabilidad.Text, ".", ",")
                        ArticuloListaPrecio_estructura(1).PrecioVenta = Replace(TBPrecioVenta.Text, ".", ",")
                        ArticuloListaPrecio_estructura(1).PrecioKilo = Replace(TBPrecioKilo.Text, ".", ",")

                        If (ArticulosAltas.CBPesable.Text = dfieldefConstantes.Si.ToString()) Then
                            Try
                                consulta = ""
                                querybuilder.obtener_estructura(dfieldefConstantes.Producto_Lista_Precio.ToString(), esquema)
                                articulo.Obtener_Clave_PrincipalListaPrecio(ClavePrincipal)
                                articulo.Pasar_A_ColeccionArticuloListaPrecio(ArticuloListaPrecio_estructura, datos, 1)
                                querybuilder.ArmaUpdate(dfieldefConstantes.Producto_Lista_Precio.ToString(), esquema, datos, ClavePrincipal, consulta)
                                articulo.Operaciones_QueryBuilder(consulta)

                                'consulta = " Select plp.Id_Lista_Precio as [Cod Lista Precio],lp.Descripcion,Id_Producto as [Cod Producto],Precio_Costo as [Precio Costo],Rentabilidad,Precio_Venta as [Precio Venta],Precio_Kilo as [Precio Kilo] " & vbCrLf
                                'consulta += "from Producto_Lista_Precio as  plp" & vbCrLf
                                'consulta += "inner join  Lista_Precio as  lp on (Cint(plp.Id_Lista_Precio)=lp.Id_Lista_Precio)" & vbCrLf
                                'consulta += "where Id_Producto='" & (ArticuloListaPrecio_estructura(1).Id_Producto) & "' " & vbCrLf

                                articulo.llenar_tabla_Producto_Lista_Precios_Lista_Precio(ArticuloListaPrecio_estructura(1).IdProducto, ArticulosAltas.DGVListaPrecio)
                                MessageBox.Show("Los Datos de la Lista de Precio del Articulo, se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                             MessageBoxIcon.Information)
                                articulo.Limpiar_Datos_Articulo_Lista_Precio(TBPrecioCosto, TBRentabilidad, TBPrecioVenta, TBPrecioKilo)
                                LimpiarEstructuras()
                                esquema.Clear()
                                datos.Clear()
                                consulta = ""
                            Catch ex As Exception
                                MsgBox("Error:" & vbCrLf & ex.Message)
                            End Try
                        Else
                            Try
                                consulta = ""
                                querybuilder.obtener_estructura(dfieldefConstantes.Producto_Lista_Precio.ToString(), esquema)
                                articulo.Obtener_Clave_PrincipalListaPrecio(ClavePrincipal)
                                articulo.Pasar_A_ColeccionArticuloListaPrecio(ArticuloListaPrecio_estructura, datos, 1)
                                querybuilder.ArmaUpdate(dfieldefConstantes.Producto_Lista_Precio.ToString(), esquema, datos, ClavePrincipal, consulta)
                                articulo.Operaciones_QueryBuilder(consulta)

                                'consulta = " Select plp.Id_Lista_Precio as [Cod Lista Precio],lp.Descripcion,Id_Producto as [Cod Producto],Precio_Costo as [Precio Costo],Rentabilidad,Precio_Venta as [Precio Venta],Precio_Kilo as[Precio Kilo]  " & vbCrLf
                                'consulta += "from Producto_Lista_Precio as  plp" & vbCrLf
                                'consulta += "inner join  Lista_Precio as  lp on (Cint(plp.Id_Lista_Precio)=lp.Id_Lista_Precio)" & vbCrLf
                                'consulta += "where Id_Producto='" & (ArticuloListaPrecio_estructura(1).Id_Producto) & "' " & vbCrLf

                                articulo.llenar_tabla_Producto_Lista_Precios_Lista_Precio(ArticuloListaPrecio_estructura(1).IdProducto, ArticulosAltas.DGVListaPrecio)
                                MessageBox.Show("Los Datos de la Lista de Precio del Articulo, se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                             MessageBoxIcon.Information)
                                articulo.Limpiar_Datos_Articulo_Lista_Precio(TBPrecioCosto, TBRentabilidad, TBPrecioVenta, TBPrecioKilo)
                                LimpiarEstructuras()
                                esquema.Clear()
                                datos.Clear()
                                consulta = ""
                            Catch ex As Exception
                                MsgBox("Error:" & vbCrLf & ex.Message)
                            End Try
                        End If
                    Else
                        MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
        For x As Integer = ProgressBarArticulosListaPrecio.Minimum To ProgressBarArticulosListaPrecio.Maximum
            ProgressBarArticulosListaPrecio.Value = x
        Next
        For x As Integer = ProgressBarArticulosListaPrecio.Maximum To ProgressBarArticulosListaPrecio.Minimum Step -1
            ProgressBarArticulosListaPrecio.Value = x
        Next
    End Sub
    Private Sub TBCodigoProducto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBCodigoProducto.LostFocus
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim consulta As String
        Dim datos As New DataTable
        Dim datosListaPrecio As Controlador.Lista_Precios.eListaPrecio
        Try
            'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
            'Lista_Precio.recuperar_Datos(consulta, datos)
            'LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()


            'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
            Lista_Precio.recuperar_Datos(CInt(CBListaPrecio.Text), datosListaPrecio)
            ' LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()
            LBListaPrecioDescripcion.Text = datosListaPrecio.Descripcion

        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim ArticuloListaPrecio_estructura(0)
    End Sub
    Private Sub CBListaPrecio_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBListaPrecio.Leave
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim consulta As String
        Dim datosListaPrecio As Controlador.Lista_Precios.eListaPrecio
        'consulta = "select * from " + dfieldefConstantes.Lista_Precio.ToString() + "  where Id_Lista_Precio=" & CInt(CBListaPrecio.Text) & " "
        Lista_Precio.recuperar_Datos(CInt(CBListaPrecio.Text), datosListaPrecio)
        ' LBListaPrecioDescripcion.Text = datos.Rows(0).Item(dfielddefListaPrecio.Descripcion).ToString()
        LBListaPrecioDescripcion.Text = datosListaPrecio.Descripcion
    End Sub
End Class