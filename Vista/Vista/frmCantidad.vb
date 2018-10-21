Public Class frmCantidad
    Dim dfielddefArticuloListaPrecio As Controlador.clsDfieldDef.eArticuloCuerpoDocumento
    Dim clsCantidad As New Controlador.clsCantidad()
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Dim clsCantidad As New Controlador.clsCantidad()
        pasarADataGrid(clsCantidad.CompDatos, clsCantidad.CompDataGrid)
        Me.Close()
    End Sub
    Public Sub pasarADataGrid(ByRef edatos As Controlador.clsArticulos.eArticuloCuerpoDocumento, ByRef DataGrid As DataGridView)
        'Dim clsCantidad As New Controlador.clsCantidad
        Dim UltimaFila As Integer
        Dim ObtenerTasa As Double
        Dim importe As Double

        If clsCantidad.CompTipoComprobante = "FACTURA B" Or clsCantidad.CompTipoComprobante = "FACTURA C" Then
            UltimaFila = DataGrid.Rows.Count - 1
            DataGrid.Rows.Add()
            DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = edatos.TipoUnidad.ToString()     'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
            DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = edatos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
            DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = edatos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
            If txtCantidad.Text = "" Then
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
            Else
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
            End If
            DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = edatos.PrecioVenta.ToString()   'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
            importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
            DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
            DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
        Else
            If clsCantidad.CompTipoComprobante = "FACTURA A" Then
                UltimaFila = DataGrid.Rows.Count - 1
                DataGrid.Rows.Add()
                DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = edatos.TipoUnidad.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = edatos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = edatos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                If txtCantidad.Text = "" Then
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
                Else
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
                End If
                'Cantidad.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                clsCantidad.obtenerTasa(edatos.TasaIVa.ToString(), ObtenerTasa)
                'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(edatos.PrecioVenta.ToString() / ObtenerTasa, "##,##0.00")
                importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
            End If
        End If
        If clsCantidad.CompTipoComprobante = "VENTA RAPIDA B" Or clsCantidad.CompTipoComprobante = "VENTA RAPIDA C" Then
            UltimaFila = DataGrid.Rows.Count - 1
            DataGrid.Rows.Add()
            DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = edatos.TipoUnidad.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
            DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = edatos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
            DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = edatos.Descripcion.ToString()  'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
            If txtCantidad.Text = "" Then
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
            Else
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
            End If
            DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = edatos.PrecioVenta.ToString()    'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
            importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
            DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
            DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
        Else
            If clsCantidad.CompTipoComprobante = "VENTA RAPIDA A" Then
                UltimaFila = DataGrid.Rows.Count - 1
                DataGrid.Rows.Add()
                DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = edatos.TipoUnidad.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = edatos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = edatos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                If txtCantidad.Text = "" Then
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
                Else
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
                End If
                'Cantidad.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                clsCantidad.obtenerTasa(edatos.TasaIVa.ToString(), ObtenerTasa)
                'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(edatos.PrecioVenta.ToString() / ObtenerTasa, "##,##0.00")
                importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
            End If
        End If
        If clsCantidad.CompTipoComprobante = "NOTA DE CREDITO B" Or clsCantidad.CompTipoComprobante = "NOTA DE CREDITO C" Then
            UltimaFila = DataGrid.Rows.Count - 1
            DataGrid.Rows.Add()
            DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = edatos.TipoUnidad.ToString()     'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
            DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = edatos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
            DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = edatos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
            If txtCantidad.Text = "" Then
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
            Else
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
            End If
            DataGrid.Rows(UltimaFila).Cells(5).Value = edatos.PrecioVenta.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
            importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
            DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
            DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
        Else
            If clsCantidad.CompTipoComprobante = "NOTA DE CREDITO A" Then
                UltimaFila = DataGrid.Rows.Count - 1
                DataGrid.Rows.Add()
                DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = edatos.TipoUnidad.ToString()  'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = edatos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = edatos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                If txtCantidad.Text = "" Then
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
                Else
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
                End If
                'Cantidad.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                clsCantidad.obtenerTasa(edatos.TasaIVa.ToString(), ObtenerTasa)
                'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(edatos.PrecioVenta.ToString() / ObtenerTasa, "##,##0.00")
                importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
            End If
        End If
        If clsCantidad.CompTipoComprobante = "NOTA DE DEBITO B" Or clsCantidad.CompTipoComprobante = "NOTA DE DEBITO C" Then
            UltimaFila = DataGrid.Rows.Count - 1
            DataGrid.Rows.Add()
            DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = edatos.TipoUnidad.ToString()   'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
            DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = edatos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
            DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = edatos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
            If txtCantidad.Text = "" Then
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
            Else
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
            End If
            'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
            DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = edatos.PrecioVenta.ToString()
            importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
            DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
            DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
        Else
            If clsCantidad.CompTipoComprobante = "NOTA DE DEBITO A" Then
                UltimaFila = DataGrid.Rows.Count - 1
                DataGrid.Rows.Add()
                DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = edatos.TipoUnidad.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = edatos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = edatos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                If txtCantidad.Text = "" Then
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
                Else
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
                End If
                'Cantidad.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                clsCantidad.obtenerTasa(edatos.TasaIVa.ToString(), ObtenerTasa)
                'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(edatos.PrecioVenta.ToString() / ObtenerTasa, "##,##0.00")
                importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
            End If
        End If
        edatos.cantidad = DataGrid.Rows(UltimaFila).Cells("Cantidad").Value
        edatos.Importe = importe
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub Cantidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCantidad.Focus()
    End Sub
    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        'Dim clsCantidad As New Controlador.clsCantidad()
        If Not clsCantidad.es_Numero(txtCantidad.Text) Then
            txtCantidad.Text = ""
        End If
    End Sub
End Class