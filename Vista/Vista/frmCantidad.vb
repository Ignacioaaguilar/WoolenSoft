Public Class frmCantidad
    Dim dfielddefArticuloListaPrecio As Controlador.DfieldDef.eArticuloCuerpoDocumento
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Cantidad As New Controlador.Cantidad()
        pasarADataGrid(Cantidad.CompDatos, Cantidad.CompDataGrid)
        Me.Close()
    End Sub
    Public Sub pasarADataGrid(ByRef datos As Controlador.Articulos.eArticuloCuerpoDocumento, ByRef DataGrid As DataGridView)
        Dim Cantidad As New Controlador.Cantidad
        Dim UltimaFila As Integer
        Dim ObtenerTasa As Double
        Dim importe As Double

        If Cantidad.CompTipoComprobante = "FACTURA B" Or Cantidad.CompTipoComprobante = "FACTURA C" Then
            UltimaFila = DataGrid.Rows.Count - 1
            DataGrid.Rows.Add()
            DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.TipoUnidad.ToString()     'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
            DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = datos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
            DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = datos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
            If txtCantidad.Text = "" Then
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
            Else
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
            End If
            DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.PrecioVenta.ToString()   'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
            importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
            DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
            DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
        Else
            If Cantidad.CompTipoComprobante = "FACTURA A" Then
                UltimaFila = DataGrid.Rows.Count - 1
                DataGrid.Rows.Add()
                DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.TipoUnidad.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = datos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = datos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                If txtCantidad.Text = "" Then
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
                Else
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
                End If
                'Cantidad.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                Cantidad.obtenerTasa(datos.TasaIVa.ToString(), ObtenerTasa)
                'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.PrecioVenta.ToString() / ObtenerTasa, "##,##0.00")
                importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
            End If
        End If
        If Cantidad.CompTipoComprobante = "VENTA RAPIDA B" Or Cantidad.CompTipoComprobante = "VENTA RAPIDA C" Then
            UltimaFila = DataGrid.Rows.Count - 1
            DataGrid.Rows.Add()
            DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.TipoUnidad.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
            DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = datos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
            DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = datos.Descripcion.ToString()  'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
            If txtCantidad.Text = "" Then
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
            Else
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
            End If
            DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.PrecioVenta.ToString()    'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
            importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
            DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
            DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
        Else
            If Cantidad.CompTipoComprobante = "VENTA RAPIDA A" Then
                UltimaFila = DataGrid.Rows.Count - 1
                DataGrid.Rows.Add()
                DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.TipoUnidad.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = datos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = datos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                If txtCantidad.Text = "" Then
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
                Else
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
                End If
                'Cantidad.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                Cantidad.obtenerTasa(datos.TasaIVa.ToString(), ObtenerTasa)
                'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.PrecioVenta.ToString() / ObtenerTasa, "##,##0.00")
                importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
            End If
        End If
        If Cantidad.CompTipoComprobante = "NOTA DE CREDITO B" Or Cantidad.CompTipoComprobante = "NOTA DE CREDITO C" Then
            UltimaFila = DataGrid.Rows.Count - 1
            DataGrid.Rows.Add()
            DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.TipoUnidad.ToString()     'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
            DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = datos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
            DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = datos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
            If txtCantidad.Text = "" Then
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
            Else
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
            End If
            DataGrid.Rows(UltimaFila).Cells(5).Value = datos.PrecioVenta.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
            importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
            DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
            DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
        Else
            If Cantidad.CompTipoComprobante = "NOTA DE CREDITO A" Then
                UltimaFila = DataGrid.Rows.Count - 1
                DataGrid.Rows.Add()
                DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.TipoUnidad.ToString()  'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = datos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = datos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                If txtCantidad.Text = "" Then
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
                Else
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
                End If
                'Cantidad.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                Cantidad.obtenerTasa(datos.TasaIVa.ToString(), ObtenerTasa)
                'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.PrecioVenta.ToString() / ObtenerTasa, "##,##0.00")
                importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
            End If
        End If
        If Cantidad.CompTipoComprobante = "NOTA DE DEBITO B" Or Cantidad.CompTipoComprobante = "NOTA DE DEBITO C" Then
            UltimaFila = DataGrid.Rows.Count - 1
            DataGrid.Rows.Add()
            DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.TipoUnidad.ToString()   'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
            DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = datos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
            DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = datos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
            If txtCantidad.Text = "" Then
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
            Else
                DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
            End If
            'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
            DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.PrecioVenta.ToString()
            importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
            DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
            DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
        Else
            If Cantidad.CompTipoComprobante = "NOTA DE DEBITO A" Then
                UltimaFila = DataGrid.Rows.Count - 1
                DataGrid.Rows.Add()
                DataGrid.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.TipoUnidad.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                DataGrid.Rows(UltimaFila).Cells("IdArticulo").Value = datos.IdProducto.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                DataGrid.Rows(UltimaFila).Cells("Descripcion").Value = datos.Descripcion.ToString() 'datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                If txtCantidad.Text = "" Then
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = 0
                Else
                    DataGrid.Rows(UltimaFila).Cells("Cantidad").Value = CInt(txtCantidad.Text)
                End If
                'Cantidad.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                Cantidad.obtenerTasa(datos.TasaIVa.ToString(), ObtenerTasa)
                'DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.PrecioVenta.ToString() / ObtenerTasa, "##,##0.00")
                importe = (DataGrid.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(DataGrid.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                DataGrid.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                DataGrid.CurrentCell = DataGrid.Rows(UltimaFila).Cells(0)
            End If
        End If
        datos.cantidad = DataGrid.Rows(UltimaFila).Cells("Cantidad").Value
        datos.Importe = importe
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub Cantidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtCantidad.Focus()
    End Sub
    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        Dim Cantidad As New Controlador.Cantidad()
        If Not Cantidad.es_Numero(txtCantidad.Text) Then
            txtCantidad.Text = ""
        End If
    End Sub
End Class