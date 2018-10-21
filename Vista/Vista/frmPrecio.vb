Public Class frmPrecio
    Dim dfielddefArticulo As Controlador.clsDfieldDef.eArticulos
    Dim estArticulosListaPrecio(0) As Controlador.clsArticulos.eArticuloCuerpoDocumento
    Dim dfielddefarticuloListaPrecio As Controlador.clsDfieldDef.eListaPrecioArticulo
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsarticulo As New Controlador.clsArticulos
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Private Sub Precio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        'Dim articulo As New Controlador.clsArticulos
        Try
            'consulta = "select distinct Id_Lista_Precio,DescripcionListaPrecio from " + dfielddefConstantes.Producto_Lista_Precio.ToString() + ""
            clsarticulo.llenar_Combo_ProductoListaPrecioALL(cbListaPrecio, "DescripcionListaPrecio", "Id_Lista_Precio")
            cbRangoArticuloDesde.Enabled = False
            cbRangoArticuloHasta.Enabled = False
            lbRangoArticuloDesde.Text = String.Empty
            lbRangoArticuloHasta.Text = String.Empty
            'consulta = "select Producto_Lista_Precio.Id_Producto,Descripcion from " + dfielddefConstantes.Producto_Lista_Precio.ToString() + ", " + dfielddefConstantes.Producto.ToString() + " where Producto_Lista_Precio.ID_Lista_Precio='" + cbListaPrecio.Text + "' and Producto_Lista_Precio.Id_Producto=Producto.Id_Producto order by Producto_Lista_Precio.Id_Producto"
            clsarticulo.llenar_Combo_ProductoListaPrecio_Producto(cbRangoArticuloDesde, "Descripcion", "Id_Producto", cbListaPrecio.Text)
            'articulo.llenar_Combo_Articulo(cbRangoArticuloHasta, consulta, "Descripcion", "Id_Producto")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub rbRangoArticulo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRangoArticulo.CheckedChanged
        'Dim articulo As New Controlador.clsArticulos
        Dim consulta As String
        If rbRangoArticulo.Checked = True Then
            cbRangoArticuloDesde.Enabled = True
            cbRangoArticuloHasta.Enabled = True
            'consulta = " select PLP.Id_Producto,Descripcion " & vbCrLf
            'consulta += " from (Producto_Lista_Precio as PLP " & vbCrLf
            'consulta += " inner join Producto  as P on  PLP.Id_Producto=P.Id_Producto )" & vbCrLf
            'consulta += " where PLP.ID_Lista_Precio='" + cbListaPrecio.Text + "' " & vbCrLf
            'consulta += " order by PLP.Id_Producto "
            clsarticulo.llenar_Combo_ProductoListaPrecio_Producto(cbRangoArticuloDesde, "Descripcion", "Id_Producto", cbListaPrecio.Text)
            ' articulo.llenar_Combo_Articulo(cbRangoArticuloHasta, consulta, "Descripcion", "Id_Producto")
        End If
    End Sub
    Private Sub rbTodosArticulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTodosArticulos.CheckedChanged
        If rbTodosArticulos.Checked = True Then
            cbRangoArticuloDesde.Enabled = False
            cbRangoArticuloHasta.Enabled = False
            lbRangoArticuloDesde.Text = String.Empty
            lbRangoArticuloHasta.Text = String.Empty
        End If
    End Sub
    Private Sub cbListaPrecio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbListaPrecio.SelectedIndexChanged
        lbListaPrecio.Text = cbListaPrecio.SelectedValue.ToString()
    End Sub
    Private Sub cbRangoArticuloDesde_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRangoArticuloDesde.TextChanged
        lbRangoArticuloDesde.Text = cbRangoArticuloDesde.SelectedValue.ToString()
    End Sub
    Private Sub cbRangoArticuloHasta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRangoArticuloHasta.TextChanged
        lbRangoArticuloHasta.Text = cbRangoArticuloHasta.SelectedValue.ToString()
    End Sub
    Private Sub cbListaPrecio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbListaPrecio.TextChanged
        'Dim articulo As New Controlador.clsArticulos
        Dim consulta As String
        'consulta = " select PLP.Id_Producto,Descripcion " & vbCrLf
        'consulta += " from (Producto_Lista_Precio as PLP " & vbCrLf
        'consulta += " inner join Producto  as P on  PLP.Id_Producto=P.Id_Producto )" & vbCrLf
        'consulta += " where PLP.ID_Lista_Precio='" + cbListaPrecio.Text + "' " & vbCrLf
        'consulta += " order by PLP.Id_Producto "
        clsarticulo.llenar_Combo_ProductoListaPrecio_Producto(cbRangoArticuloDesde, "Descripcion", "Id_Producto", cbListaPrecio.Text)
        'articulo.llenar_Combo_Articulo(cbRangoArticuloHasta, consulta, "Descripcion", "Id_Producto")
    End Sub
    Private Sub ToolStripRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRegistrar.Click
        Dim consulta As String
        'Dim articulo As New Controlador.clsArticulos
        Dim existe As Boolean
        Dim datosColection As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim dtdatos As New DataTable
        Dim dtdatosArticulo As New DataTable
        Dim precioventaConRentab As Double
        Dim precioventa As Double
        Dim idx As Integer
        idx = 1
        If cbListaPrecio.Text <> "" Then
            For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
                ToolStripProgressBar.Value = x
            Next
            For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
                ToolStripProgressBar.Value = x
            Next
            If rbTodosArticulos.Checked = True And tbImportePrecioCosto.Text <> "" Then
                'consulta = " select * from " + dfielddefConstantes.Producto_Lista_Precio.ToString() + " where Id_Lista_Precio='" + cbListaPrecio.Text + "'"
                clsarticulo.recuperar_Datos_Producto_Lista_Precio(cbListaPrecio.Text, dtdatos)
                If rbAumentaPrecioCosto.Checked = True Then
                    For j = 0 To dtdatos.Rows.Count - 1
                        'consulta = "select * from " + dfielddefConstantes.Producto.ToString() + "  where Id_Producto='" + datos.Rows(j).Item(dfielddefArticulo.Id_Producto + 1) + "'"
                        clsarticulo.ObtenerProductos(dtdatos.Rows(j).Item(dfielddefArticulo.Id_Producto + 1), dtdatosArticulo)
                        ReDim Preserve estArticulosListaPrecio(idx)
                        estArticulosListaPrecio(idx).IdListaPrecio = cbListaPrecio.Text
                        estArticulosListaPrecio(idx).IdProducto = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Id_Producto)
                        estArticulosListaPrecio(idx).DescListaPrecio = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Descripcion)
                        estArticulosListaPrecio(idx).PrecioCosto = Convert.ToString(Convert.ToDouble(dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Precio_Costo)) + Convert.ToDouble(tbImportePrecioCosto.Text))
                        estArticulosListaPrecio(idx).Rentabilidad = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Rentabilidad)
                        precioventaConRentab = Convert.ToDouble(estArticulosListaPrecio(idx).PrecioCosto) + Convert.ToDouble((estArticulosListaPrecio(idx).PrecioCosto) * (Convert.ToDouble(estArticulosListaPrecio(idx).Rentabilidad)) / 100)
                        precioventa = precioventaConRentab + (precioventaConRentab * Convert.ToDouble(dtdatosArticulo.Rows(0).Item(dfielddefArticulo.Id_Tasa_IVA)) / 100)
                        estArticulosListaPrecio(idx).PrecioVenta = Convert.ToString(precioventa)
                        estArticulosListaPrecio(idx).PrecioKilo = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Precio_Kilo)
                        idx = idx + 1
                    Next
                Else
                    If rbDisminuirPrecioCosto.Checked = True And tbImportePrecioCosto.Text <> "" Then
                        For j = 0 To dtdatos.Rows.Count - 1
                            'consulta = "select * from " + dfielddefConstantes.Producto.ToString() + "  where Id_Producto='" + datos.Rows(j).Item(dfielddefArticulo.Id_Producto + 1) + "'"
                            clsarticulo.ObtenerProductos(dtdatos.Rows(j).Item(dfielddefArticulo.Id_Producto + 1), dtdatosArticulo)
                            ReDim Preserve estArticulosListaPrecio(idx)
                            estArticulosListaPrecio(idx).IdListaPrecio = cbListaPrecio.Text
                            estArticulosListaPrecio(idx).IdProducto = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Id_Producto)
                            estArticulosListaPrecio(idx).DescListaPrecio = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Descripcion)
                            estArticulosListaPrecio(idx).PrecioCosto = Convert.ToString(Convert.ToDouble(dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Precio_Costo)) - Convert.ToDouble(tbImportePrecioCosto.Text))
                            estArticulosListaPrecio(idx).Rentabilidad = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Rentabilidad)
                            precioventaConRentab = Convert.ToDouble(estArticulosListaPrecio(idx).PrecioCosto) + Convert.ToDouble((estArticulosListaPrecio(idx).PrecioCosto) * (Convert.ToDouble(estArticulosListaPrecio(idx).Rentabilidad)) / 100)
                            precioventa = precioventaConRentab + (precioventaConRentab * Convert.ToDouble(dtdatosArticulo.Rows(0).Item(dfielddefArticulo.Id_Tasa_IVA)) / 100)
                            estArticulosListaPrecio(idx).PrecioVenta = Convert.ToString(precioventa)
                            estArticulosListaPrecio(idx).PrecioKilo = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Precio_Kilo)
                            'estArticulosListaPrecio(idx).Precio_Kilo = datos.Rows(j).Item(dfielddefarticuloListaPrecio.Precio_Kilo)
                            idx = idx + 1
                        Next
                    End If
                End If
            Else
                If rbRangoArticulo.Checked = True And tbImportePrecioCosto.Text <> "" Then
                    'consulta = " select * from " + dfielddefConstantes.Producto_Lista_Precio.ToString() + " where Id_Lista_Precio='" + cbListaPrecio.Text + "' and Id_Producto>='" + cbRangoArticuloDesde.Text + "' and Id_Producto<='" + cbRangoArticuloHasta.Text + "' "
                    clsarticulo.recuperar_Datos_Producto_Lista_Precio(cbListaPrecio.Text, dtdatos, cbRangoArticuloDesde.Text, cbRangoArticuloHasta.Text)
                    If rbAumentaPrecioCosto.Checked = True Then
                        For j = 0 To dtdatos.Rows.Count - 1
                            'consulta = "select * from " + dfielddefConstantes.Producto.ToString() + " where Id_Producto='" + datos.Rows(j).Item(dfielddefArticulo.Id_Producto + 1) + "'"
                            clsarticulo.ObtenerProductos(dtdatos.Rows(j).Item(dfielddefArticulo.Id_Producto + 1), dtdatosArticulo)
                            ReDim Preserve estArticulosListaPrecio(idx)
                            estArticulosListaPrecio(idx).IdListaPrecio = cbListaPrecio.Text
                            estArticulosListaPrecio(idx).IdProducto = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Id_Producto)
                            estArticulosListaPrecio(idx).DescListaPrecio = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Descripcion)
                            estArticulosListaPrecio(idx).PrecioCosto = Convert.ToString(Convert.ToDouble(dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Precio_Costo)) + Convert.ToDouble(tbImportePrecioCosto.Text))
                            estArticulosListaPrecio(idx).Rentabilidad = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Rentabilidad)
                            precioventaConRentab = Convert.ToDouble(estArticulosListaPrecio(idx).PrecioCosto) + Convert.ToDouble((estArticulosListaPrecio(idx).PrecioCosto) * (Convert.ToDouble(estArticulosListaPrecio(idx).Rentabilidad)) / 100)
                            precioventa = precioventaConRentab + (precioventaConRentab * Convert.ToDouble(dtdatosArticulo.Rows(0).Item(dfielddefArticulo.Id_Tasa_IVA)) / 100)
                            estArticulosListaPrecio(idx).PrecioVenta = Convert.ToString(precioventa)
                            estArticulosListaPrecio(idx).PrecioKilo = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Precio_Kilo)
                            idx = idx + 1
                        Next
                    Else
                        If rbDisminuirPrecioCosto.Checked = True And tbImportePrecioCosto.Text <> "" Then
                            For j = 0 To dtdatos.Rows.Count - 1
                                'consulta = "select * from " + dfielddefConstantes.Producto.ToString() + " where Id_Producto='" + datos.Rows(j).Item(dfielddefArticulo.Id_Producto + 1) + "'"
                                clsarticulo.ObtenerProductos(dtdatos.Rows(j).Item(dfielddefArticulo.Id_Producto + 1), dtdatosArticulo)
                                ReDim Preserve estArticulosListaPrecio(idx)
                                estArticulosListaPrecio(idx).IdListaPrecio = cbListaPrecio.Text
                                estArticulosListaPrecio(idx).IdProducto = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Id_Producto)
                                estArticulosListaPrecio(idx).DescListaPrecio = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Descripcion)
                                estArticulosListaPrecio(idx).PrecioCosto = Convert.ToString(Convert.ToDouble(dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Precio_Costo)) - Convert.ToDouble(tbImportePrecioCosto.Text))
                                estArticulosListaPrecio(idx).Rentabilidad = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Rentabilidad)
                                precioventaConRentab = Convert.ToDouble(estArticulosListaPrecio(idx).PrecioCosto) + Convert.ToDouble((estArticulosListaPrecio(idx).PrecioCosto) * (Convert.ToDouble(estArticulosListaPrecio(idx).Rentabilidad)) / 100)
                                precioventa = precioventaConRentab + (precioventaConRentab * Convert.ToDouble(dtdatosArticulo.Rows(0).Item(dfielddefArticulo.Id_Tasa_IVA)) / 100)
                                estArticulosListaPrecio(idx).PrecioVenta = Convert.ToString(precioventa)
                                estArticulosListaPrecio(idx).PrecioKilo = dtdatos.Rows(j).Item(dfielddefarticuloListaPrecio.Precio_Kilo)
                                idx = idx + 1
                            Next
                        End If
                    End If
                End If
            End If
            If tbImportePrecioCosto.Text <> String.Empty And (rbAumentaPrecioCosto.Checked = True Or rbDisminuirPrecioCosto.Checked = True) Then
                For i = 1 To estArticulosListaPrecio.Count - 1
                    consulta = String.Empty
                    clsQueryBuilder.obtener_estructura(dfielddefConstantes.Producto_Lista_Precio.ToString(), esquema)
                    clsarticulo.Obtener_Clave_PrincipalListaPrecio(ClavePrincipal)
                    clsarticulo.Pasar_A_ColeccionArticuloListaPrecio(estArticulosListaPrecio, datosColection, i)
                    clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Producto_Lista_Precio.ToString(), esquema, datosColection, ClavePrincipal, consulta)
                    clsarticulo.Operaciones_Tabla(consulta)
                Next
                MessageBox.Show("El Precio de Costo, se modifico Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                clsarticulo.Limpiar_Datos_Articulo_Lista_Precio_Precio(tbImportePrecioCosto)
                LimpiarEstructuras()
                esquema.Clear()
                dtdatos.Clear()
                consulta = String.Empty
            ElseIf tbImportePrecioCosto.Text = "" Then
                MessageBox.Show("Debe Ingresar, el importe de precio de costo!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                LimpiarEstructuras()
                esquema.Clear()
                dtdatos.Clear()
                consulta = String.Empty
            ElseIf rbAumentaPrecioCosto.Checked = False And rbDisminuirPrecioCosto.Checked = False Then
                MessageBox.Show("Debe seleccionar la opcion, aumentar o disminuir el precio de costo !!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                LimpiarEstructuras()
                esquema.Clear()
                dtdatos.Clear()
                consulta = String.Empty
            End If
        End If
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim estArticulosListaPrecio(0)
    End Sub
    Private Sub ToolStripSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalir.Click
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub tbImportePrecioCosto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImportePrecioCosto.TextChanged
        'Dim articulo As New Controlador.clsArticulos
        If Not clsarticulo.validateDoublesAndCurrency_Articulo(tbImportePrecioCosto.Text) Then
            tbImportePrecioCosto.Text = String.Empty
        End If
    End Sub
End Class