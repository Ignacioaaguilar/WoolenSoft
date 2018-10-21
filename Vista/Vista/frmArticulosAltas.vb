Imports Controlador
Public Class frmArticulosAltas
    Public lista_precio As String
    Public Cod_Empresa As String
    Public Cod_Producto As String
    Public Codigo_Producto As String
    Public Razon_Social As String
    Dim articulos_Estructura(0) As Controlador.clsArticulos.eArticulo
    Dim ArticuloListaPrecio_estructura(0) As Controlador.clsArticulos.eArticuloCuerpoDocumento
    Dim ArticuloEmpresa_estructura(0) As Controlador.clsArticulos.eArticuloEmpresa
    Dim codigoGenerado As Integer
    Dim dfielddefArticulos As Controlador.clsDfieldDef.eArticulos
    Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Dim dfielddefTasaIva As Controlador.clsDfieldDef.eTasaIVA
    Dim dfielddefRubro As Controlador.clsDfieldDef.eRubros
    Dim dfielddefListaPrecio As Controlador.clsDfieldDef.eListaPrecio
    Dim dfielddefListaPrecioArticulo As Controlador.clsDfieldDef.eListaPrecioArticulo
    Dim dfielddefProveedor As Controlador.clsDfieldDef.eProveedor
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim ArticuloListaPrecios As New Controlador.clsArticulos.eProductoListaPrecios
    Dim clsrubro As New Controlador.clsRubros
    Dim clsTasaIVA As New Controlador.clsTasaIVA
    Dim clsarticulo As New Controlador.clsArticulos()
    Dim clsContProveedor As New Controlador.clsContProveedor
    Dim clsEmpresa As New Controlador.clsEmpresas
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim eTasaIva As New Controlador.clsTasaIVA.eTasaIVA
    Dim clsGenerales As New Controlador.clsGenerales

    Private Sub ToolStripSalirArticuloAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirArticuloAlta.Click
        'Dim articulo As New Controlador.clsArticulos
        For x As Integer = ProgressBarArticulosAltas.Minimum To ProgressBarArticulosAltas.Maximum
            ProgressBarArticulosAltas.Value = x
        Next
        For x As Integer = ProgressBarArticulosAltas.Maximum To ProgressBarArticulosAltas.Minimum Step -1
            ProgressBarArticulosAltas.Value = x
        Next
        Me.Close()
        frmArticulos.Show()
        clsarticulo.Limpiar_Datos_Articulo(TBCodigoArticulo, TBCodigoBarra, TBDescripcion, TBStockMinimo, TBStock, TBPesoUnidad, TBCantUnidCaja, TBNumeroAsignado, tbCodProdProveedor)
        clsarticulo.Limpiar_Datos_Articulo_Lista_Precio_DataGrid(DGVListaPrecio)
        LimpiarEstructuras()
    End Sub
    Private Sub CBPesable_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBPesable.GotFocus
        If (CBPesable.Text = dfielddefConstantes.Si.ToString()) Then
            TBCantUnidCaja.Visible = False
            Label14.Visible = False
            TBPesoUnidad.Visible = True
            Label15.Visible = True
        Else
            If (CBPesable.Text = dfielddefConstantes.No.ToString()) Then
                TBCantUnidCaja.Visible = True
                Label14.Visible = True
                TBPesoUnidad.Visible = False
                Label15.Visible = False
            End If
        End If
    End Sub
    Private Sub CBPesable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPesable.SelectedIndexChanged
        If (CBPesable.Text = dfielddefConstantes.Si.ToString()) Then
            TBCantUnidCaja.Visible = False
            Label14.Visible = False
            TBPesoUnidad.Visible = True
            Label15.Visible = True
        Else
            If (CBPesable.Text = dfielddefConstantes.No.ToString()) Then
                TBCantUnidCaja.Visible = True
                Label14.Visible = True
                TBPesoUnidad.Visible = False
                Label15.Visible = False
            End If
        End If
    End Sub
    Private Sub ArticulosAltas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Dim dtdatos As New DataTable
        Try
            'consulta = "select * from " + dfielddefConstantes.rubro.ToString() + ""
            clsrubro.llenar_Combo_Rubros(CBRubro, "Descripcion", "Id_Rubro")

            'consulta = "select * from " + dfielddefConstantes.Tasa_IVA.ToString() + ""
            clsTasaIVA.llenar_Combo_TasaIVA(CBTasaIVA, "Descripcion", "Tasa")

            'consulta = "Select * from " + dfielddefConstantes.Proveedor.ToString() + ""
            clsContProveedor.llenar_Combo_Proveedor(CBCodProveedor, "Razon_Social", "Id_Proveedor")

            'consulta = " Select plp.Id_Lista_Precio as[Cod Lista Precio],lp.Descripcion,Id_Producto as [Cod Producto],Precio_Costo as [Precio Costo],Rentabilidad,Precio_Venta as [Precio Venta],Precio_Kilo as [Precio Kilo]  " & vbCrLf
            'consulta += " from (Producto_Lista_Precio as  plp" & vbCrLf
            'consulta += " inner join  Lista_Precio as  lp on (Cint(plp.Id_Lista_Precio)=lp.Id_Lista_Precio))" & vbCrLf
            'consulta += " where Id_Producto='" & (TBNumeroAsignado.Text) & "'" & vbCrLf
            clsarticulo.llenar_tabla_Producto_Lista_Precios_Lista_Precio(TBNumeroAsignado.Text, DGVListaPrecio)
            consulta = String.Empty

            'consulta = "Select Id_Articulo as [Cod Articulo],EA.Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Codigo Postal],CUIT " & vbCrLf
            'consulta += "from (EmpresaArticulo as EA " & vbCrLf
            'consulta += "inner join Empresa as E on  E.Id_Empresa=EA.Id_Empresa) " & vbCrLf
            'consulta += "where Id_Articulo='" & (TBNumeroAsignado.Text) & "' "

            clsarticulo.llenar_tabla_EmpresaArticulo_Empresa(TBNumeroAsignado.Text, DGVEmpresaArticulos)

            'consulta = "Select Id_Empresa from Empresa"
            clsEmpresa.llenar_Combo_Empresas(frmArticuloEmpresa.cbCodEmpresa, "Id_Empresa", "Razon_Social")

            If clsarticulo.Compvariable = dfielddefConstantes.Modificar_Articulo.ToString() Then
                Dim index As Integer
                CBCodProveedor.SelectedIndex = Convert.ToInt32(clsarticulo.CompId_Proveedor) - 1
                CBTasaIVA.SelectedIndex = Convert.ToInt32(clsarticulo.CompId_Tasa_IVA) - 1
            End If
            If clsarticulo.Compvariable = dfielddefConstantes.Agregar_Producto.ToString() Then
                TBCantUnidCaja.Visible = False
                Label14.Visible = False
                TBPesoUnidad.Visible = False
                Label15.Visible = False
            End If
            BtnAgregarListaPrecio.Enabled = False
            BtnModificarListaPrecio.Enabled = False
            BtnEliminarListaPrecio.Enabled = False

            btnAgregarEmpresaArticulo.Enabled = False
            btnModidicarEmpresaArticulo.Enabled = False
            btnEliminarEmpresaArticulo.Enabled = False

            If (clsarticulo.Compvariable = dfielddefConstantes.Modificar_Articulo.ToString()) Then
                BtnAgregarListaPrecio.Enabled = True
                btnAgregarEmpresaArticulo.Enabled = True
                'consulta = "Select * from " + dfielddefConstantes.Producto.ToString() + " where Id_Producto='" + articulo.Compvariable_Articulo + "'"
                clsarticulo.ObtenerProductos(clsarticulo.Compvariable_Articulo, dtdatos)

                'consulta = "select * from " + dfielddefConstantes.rubro.ToString() + " where Id_Rubro='" + datos.Rows(0).Item(dfielddefArticulos.Id_Rubro) + "'"
                clsrubro.llenar_Combo_Rubros(CBRubro, "Descripcion", "Id_Rubro", dtdatos.Rows(0).Item(dfielddefArticulos.Id_Rubro))
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBNumeroAsignado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNumeroAsignado.TextChanged
        Dim longitud As Integer
        Dim cadena As String
        Dim result1 As String
        'Dim articulo As New Controlador.clsArticulos()
        Try
            cadena = TBCodigoArticulo.Text
            longitud = Len(cadena)
            If (clsarticulo.Compvariable = dfielddefConstantes.Agregar_Producto.ToString()) Then
                If (clsarticulo.es_Numero(TBNumeroAsignado.Text)) Then
                    If (longitud > 4) Then
                        result1 = cadena.Remove(longitud - 1)
                        TBCodigoArticulo.Text = result1
                    Else
                        If (longitud = 4) Then
                            BTNGenerarCodigo.Enabled = True
                        End If
                    End If
                Else
                    TBNumeroAsignado.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub BTNGenerarCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNGenerarCodigo.Click
        ' Dim articulo As New Controlador.clsArticulos
        Dim consulta As String
        Dim existe As Boolean
        Try
            TBCodigoArticulo.Text += TBNumeroAsignado.Text
            BTNGenerarCodigo.Enabled = False
            'consulta = "select * from " + dfielddefConstantes.Producto.ToString() + " where Id_Producto='" & (TBCodigoArticulo.Text) & "'"
            clsarticulo.se_Cargo_articulo(TBCodigoArticulo.Text, existe)
            codigoGenerado = 1
            If (existe) Then
                MessageBox.Show("Error: El Codigo del Articulo se Agrego Anteriormente. Ingrese Otro!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Error)
                TBNumeroAsignado.Focus()
                codigoGenerado = 0
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBCodigoBarra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCodigoBarra.TextChanged
        'Dim articulo As New Controlador.clsArticulos
        If Not (clsarticulo.es_Numero(TBCodigoBarra.Text)) Then
            TBCodigoBarra.Text = String.Empty
        End If
    End Sub
    Private Sub TBStockMinimo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBStockMinimo.TextChanged
        'Dim articulo As New Controlador.clsArticulos
        If Not (clsarticulo.validateDoublesAndCurrency_Articulo(TBStockMinimo.Text)) Then
            TBStockMinimo.Text = String.Empty
        End If
    End Sub
    Private Sub TBStock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBStock.TextChanged
        'Dim articulo As New Controlador.clsArticulos
        If Not (clsarticulo.validateDoublesAndCurrency_Articulo(TBStock.Text)) Then
            TBStock.Text = String.Empty
        End If
    End Sub
    Private Sub TBPesoUnidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBPesoUnidad.TextChanged
        'Dim articulo As New Controlador.clsArticulos
        If Not (clsarticulo.validateDoublesAndCurrency_Articulo(TBPesoUnidad.Text)) Then
            TBPesoUnidad.Text = String.Empty
        End If
    End Sub
    Private Sub TBCantUnidCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCantUnidCaja.TextChanged
        'Dim articulo As New Controlador.clsArticulos
        If Not (clsarticulo.es_Numero(TBCantUnidCaja.Text)) Then
            TBCantUnidCaja.Text = String.Empty
        End If
    End Sub
    Private Sub ToolStripGuardarArticuloAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripGuardarArticuloAlta.Click
        'Dim articulo As New Controlador.clsArticulos
        Dim consulta As String
        Dim existe As Boolean
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim esquema As New Collection
        Dim trans As New Collection
        Dim Transacciones As New Controlador.clsGenerales
        Dim dtDatosTasaIVA As New DataTable
        Try
            esquema.Clear()
            datos.Clear()
            ClavePrincipal.Clear()
            If (clsarticulo.Compvariable = dfielddefConstantes.Agregar_Producto.ToString()) Then
                If (CBRubro.Text <> String.Empty And TBCodigoArticulo.Text <> String.Empty And TBNumeroAsignado.Text <> String.Empty And TBDescripcion.Text <> String.Empty And CBTasaIVA.Text <> String.Empty And TBStockMinimo.Text <> String.Empty And TBStock.Text <> String.Empty And CBPesable.Text <> String.Empty) Then
                    BtnAgregarListaPrecio.Enabled = True
                    btnAgregarEmpresaArticulo.Enabled = True
                    If codigoGenerado = 1 Then
                        ReDim articulos_Estructura(1)
                        articulos_Estructura(1).Id_Producto = TBCodigoArticulo.Text
                        articulos_Estructura(1).Id_Rubro = CBRubro.Text
                        articulos_Estructura(1).Codigo_Barras = TBCodigoBarra.Text
                        articulos_Estructura(1).Descripcion = TBDescripcion.Text
                        articulos_Estructura(1).Id_Proveedor = CInt(CBCodProveedor.Text)

                        articulos_Estructura(1).Tasa_IVA = (CBTasaIVA.Text)
                        'consulta = "Select * from Tasa_IVA where Tasa='" + articulos_Estructura(1).Tasa_IVA + "' and Descripcion ='" + LbTasaIVA.Text + "' "
                        clsTasaIVA.recuperar_Datos(articulos_Estructura(1).Tasa_IVA, dtDatosTasaIVA, LbTasaIVA.Text)
                        articulos_Estructura(1).Id_Tasa_IVA = Convert.ToInt32(dtDatosTasaIVA.Rows(0).Item("Id_Tasa_IVA"))


                        articulos_Estructura(1).Tasa_IVA = Convert.ToDouble(CBTasaIVA.Text)
                        articulos_Estructura(1).Stock_Minimo = TBStock.Text
                        articulos_Estructura(1).Stock = TBStockMinimo.Text
                        articulos_Estructura(1).Pesable = CBPesable.Text
                        articulos_Estructura(1).Tipo_Unidad = CBUnidades.Text
                        If (CBPesable.Text = dfielddefConstantes.Si.ToString()) Then
                            articulos_Estructura(1).Cantidad_Unid_Caja = 0
                            articulos_Estructura(1).Peso_Unidad = TBPesoUnidad.Text
                        Else
                            If (CBPesable.Text = dfielddefConstantes.No.ToString()) Then
                                articulos_Estructura(1).Cantidad_Unid_Caja = TBCantUnidCaja.Text
                                articulos_Estructura(1).Peso_Unidad = 0
                            End If
                        End If
                        If cbInhabiliarArticulo.Checked = False Then
                            articulos_Estructura(1).INHABILITAR = False
                        Else
                            articulos_Estructura(1).INHABILITAR = True
                        End If
                        articulos_Estructura(1).CodProdProveedor = tbCodProdProveedor.Text.Trim()
                        Try
                            'consulta = "select * from " + dfielddefConstantes.Producto.ToString() + " where Id_Producto='" & (articulos_Estructura(1).Id_Producto) & "'"
                            clsarticulo.se_Cargo_articulo(articulos_Estructura(1).Id_Producto, existe)
                            If Not (existe) Then
                                clsQueryBuilder.obtener_estructura(dfielddefConstantes.Producto.ToString(), esquema)
                                clsarticulo.Obtener_Clave_Principal(ClavePrincipal)
                                clsarticulo.Pasar_A_Coleccion(articulos_Estructura, datos, 1)
                                clsQueryBuilder.ArmaInsert(dfielddefConstantes.Producto.ToString(), esquema, datos, ClavePrincipal, consulta)
                                clsarticulo.Operaciones_Tabla(consulta)
                                MessageBox.Show("Los Datos del Articulo se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                                LimpiarEstructuras()
                            Else
                                MessageBox.Show("Error: El Codigo del Articulo se Agrego Anteriormente. Ingrese Otro!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Error)
                                TBNumeroAsignado.Focus()
                            End If
                        Catch ex As Exception
                            MsgBox("Error:" & vbCrLf & ex.Message)
                        End Try
                    Else
                        MessageBox.Show("Error: No se Genero el Codigo del Articulo, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                        MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
                End If
            Else
                If (clsarticulo.Compvariable = dfielddefConstantes.Modificar_Articulo.ToString()) Then
                    If (CBRubro.Text <> String.Empty And TBCodigoArticulo.Text <> String.Empty And TBDescripcion.Text <> String.Empty And CBTasaIVA.Text <> String.Empty And TBStockMinimo.Text <> String.Empty And TBStock.Text <> String.Empty And CBPesable.Text <> String.Empty) Then
                        ReDim articulos_Estructura(1)
                        articulos_Estructura(1).Id_Producto = TBCodigoArticulo.Text
                        articulos_Estructura(1).Id_Rubro = CBRubro.Text
                        articulos_Estructura(1).Codigo_Barras = TBCodigoBarra.Text
                        articulos_Estructura(1).Descripcion = TBDescripcion.Text
                        articulos_Estructura(1).Id_Proveedor = CInt(CBCodProveedor.Text)

                        articulos_Estructura(1).Tasa_IVA = (CBTasaIVA.Text)
                        'consulta = "Select * from Tasa_IVA where Tasa='" + articulos_Estructura(1).Tasa_IVA + "' and Descripcion ='" + LbTasaIVA.Text + "' "
                        clsTasaIVA.recuperar_Datos(articulos_Estructura(1).Tasa_IVA, dtDatosTasaIVA, LbTasaIVA.Text)
                        articulos_Estructura(1).Id_Tasa_IVA = Convert.ToInt32(dtDatosTasaIVA.Rows(0).Item("Id_Tasa_IVA"))



                        articulos_Estructura(1).Stock_Minimo = TBStock.Text
                        articulos_Estructura(1).Stock = TBStockMinimo.Text
                        articulos_Estructura(1).Pesable = CBPesable.Text
                        articulos_Estructura(1).Tipo_Unidad = CBUnidades.Text
                        If (CBPesable.Text = dfielddefConstantes.Si.ToString()) Then
                            articulos_Estructura(1).Cantidad_Unid_Caja = 0
                            articulos_Estructura(1).Peso_Unidad = TBPesoUnidad.Text
                        Else
                            If (CBPesable.Text = dfielddefConstantes.No.ToString()) Then
                                articulos_Estructura(1).Cantidad_Unid_Caja = TBCantUnidCaja.Text
                                articulos_Estructura(1).Peso_Unidad = 0
                            End If
                        End If
                        If cbInhabiliarArticulo.Checked = False Then
                            articulos_Estructura(1).INHABILITAR = False
                        Else
                            articulos_Estructura(1).INHABILITAR = True
                        End If
                        articulos_Estructura(1).CodProdProveedor = tbCodProdProveedor.Text.Trim()
                        Try
                            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Producto.ToString(), esquema)
                            clsarticulo.Obtener_Clave_Principal(ClavePrincipal)
                            clsarticulo.Pasar_A_Coleccion(articulos_Estructura, datos, 1)
                            clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Producto.ToString(), esquema, datos, ClavePrincipal, consulta)
                            clsarticulo.Operaciones_Tabla(consulta)
                            MessageBox.Show("Los Datos del Articulo se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Information)
                            clsarticulo.Limpiar_Datos_Articulo(TBCodigoArticulo, TBCodigoBarra, TBDescripcion, TBStockMinimo, TBStock, TBPesoUnidad, TBCantUnidCaja, TBNumeroAsignado, tbCodProdProveedor)
                            clsarticulo.Limpiar_Datos_Articulo_Lista_Precio_DataGrid(DGVListaPrecio)
                            clsarticulo.Limpiar_Datos_Articulo_Empresa_DataGrid(DGVEmpresaArticulos)
                            LimpiarEstructuras()
                        Catch ex As Exception
                            MsgBox("Error:" & vbCrLf & ex.Message)
                        End Try
                    Else
                        MessageBox.Show("Error: Hay Campos Vacios, Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                         MessageBoxIcon.Exclamation)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
        For x As Integer = ProgressBarArticulosAltas.Minimum To ProgressBarArticulosAltas.Maximum
            ProgressBarArticulosAltas.Value = x
        Next
        For x As Integer = ProgressBarArticulosAltas.Maximum To ProgressBarArticulosAltas.Minimum Step -1
            ProgressBarArticulosAltas.Value = x
        Next
    End Sub
    Private Sub BtnModificarListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificarListaPrecio.Click
        'Dim articulo As New Controlador.clsArticulos
        'Dim clsTasaIVA As New Controlador.clsTasaIVA
        Dim dtDatosTasaIVa As DataTable
        Dim eTasaIva As New Controlador.clsTasaIVA.eTasaIVA
        Try

            clsTasaIVA.recuperar_Datos_Descripcion(CBTasaIVA.SelectedValue, dtDatosTasaIVa)
            eTasaIva.Id_Tasa_IVA = dtDatosTasaIVa.Rows(0).Item("Id_Tasa_IVA")
            eTasaIva.Tasa = dtDatosTasaIVa.Rows(0).Item("Tasa")
            eTasaIva.Descripcion = dtDatosTasaIVa.Rows(0).Item("Descripcion")

            Dim ALP As New frmArticulos_ListaPrecios(eTasaIva, ArticuloListaPrecios)

            ALP.CBListaPrecio.DropDownStyle = ComboBoxStyle.DropDown
            ALP.CBListaPrecio.Enabled = False
            clsarticulo.Compvariable_Articulo = dfielddefConstantes.Modificar_Lista_Precio.ToString()
            If (CBPesable.Text <> String.Empty) Then
                If (CBPesable.Text = dfielddefConstantes.Si.ToString()) Then
                    ALP.TBPrecioKilo.Enabled = True
                    ALP.LBPrecioKilo.Enabled = True
                Else
                    ALP.TBPrecioKilo.Enabled = False
                    ALP.LBPrecioKilo.Enabled = False
                End If
            Else
                MessageBox.Show("Error:Falta Completar, el Campo Pesable , Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                        MessageBoxIcon.Exclamation)
            End If
            ALP.Show()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DGVListaPrecio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVListaPrecio.Click
        'Dim articulo As New Controlador.clsArticulos
        'Dim clsTasaIVA As New Controlador.clsTasaIVA
        Dim dtDatosTasaIVa As DataTable
        'Dim eTasaIva As New Controlador.clsTasaIVA.eTasaIVA

        Try
            clsTasaIVA.recuperar_Datos_Descripcion(CBTasaIVA.SelectedValue, dtDatosTasaIVa)
            eTasaIva.Id_Tasa_IVA = dtDatosTasaIVa.Rows(0).Item("Id_Tasa_IVA")
            eTasaIva.Tasa = dtDatosTasaIVa.Rows(0).Item("Tasa")
            eTasaIva.Descripcion = dtDatosTasaIVa.Rows(0).Item("Descripcion")

            lista_precio = DGVListaPrecio.CurrentRow.Cells(0).Value.ToString()
            Codigo_Producto = DGVListaPrecio.CurrentRow.Cells(2).Value.ToString()
            ArticuloListaPrecios.Id_Lista_Precio = DGVListaPrecio.CurrentRow.Cells(0).Value.ToString()
            ArticuloListaPrecios.Id_Producto = DGVListaPrecio.CurrentRow.Cells(2).Value.ToString()
            ArticuloListaPrecios.Precio_Costo = DGVListaPrecio.CurrentRow.Cells(3).Value.ToString()
            ArticuloListaPrecios.Rentabilidad = DGVListaPrecio.CurrentRow.Cells(4).Value.ToString()
            ArticuloListaPrecios.Precio_Venta = DGVListaPrecio.CurrentRow.Cells(5).Value.ToString()
            ArticuloListaPrecios.Precio_Kilo = DGVListaPrecio.CurrentRow.Cells(6).Value.ToString()

            Dim ALP As New frmArticulos_ListaPrecios(eTasaIva, ArticuloListaPrecios)



            BtnAgregarListaPrecio.Enabled = False
            BtnModificarListaPrecio.Enabled = True
            BtnEliminarListaPrecio.Enabled = True
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub BtnAgregarListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarListaPrecio.Click
        'Dim articulo As New Controlador.clsArticulos
        'Dim clsTasaIVA As New Controlador.clsTasaIVA
        Dim dtDatosTasaIVa As DataTable
        'Dim eTasaIva As New Controlador.clsTasaIVA.eTasaIVA

        Try
            clsTasaIVA.recuperar_Datos_Descripcion(CBTasaIVA.SelectedValue, dtDatosTasaIVa)
            eTasaIva.Id_Tasa_IVA = dtDatosTasaIVa.Rows(0).Item("Id_Tasa_IVA")
            eTasaIva.Tasa = dtDatosTasaIVa.Rows(0).Item("Tasa")
            eTasaIva.Descripcion = dtDatosTasaIVa.Rows(0).Item("Descripcion")

            Dim ALP As New frmArticulos_ListaPrecios(eTasaIva, ArticuloListaPrecios)

            clsarticulo.Limpiar_Datos_Articulo_Lista_Precio(ALP.TBPrecioCosto, ALP.TBRentabilidad, ALP.TBPrecioVenta, ALP.TBPrecioKilo)
            ALP.TBCodigoProducto.Text = TBCodigoArticulo.Text
            ALP.CBListaPrecio.DropDownStyle = ComboBoxStyle.DropDownList
            clsarticulo.Compvariable_Articulo = dfielddefConstantes.Agregar_Lista_Precio.ToString()
            If (CBPesable.Text <> String.Empty) Then
                If (CBPesable.Text = dfielddefConstantes.Si.ToString()) Then
                    ALP.TBPrecioKilo.Enabled = True
                    ALP.LBPrecioKilo.Enabled = True
                Else
                    ALP.TBPrecioKilo.Enabled = False
                    ALP.LBPrecioKilo.Enabled = False
                    ALP.TBPrecioKilo.Text = "0"
                End If
            Else
                MessageBox.Show("Error:Falta Completar, el Campo Pesable , Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                        MessageBoxIcon.Exclamation)
            End If
            clsarticulo.CompDataGrid = DGVListaPrecio

            ALP.ShowDialog()

        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub BtnEliminarListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminarListaPrecio.Click
        'Dim articulo As New Controlador.clsArticulos()
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection

        Dim result As Integer = MessageBox.Show("Desea Eliminar del Articulo: " + Codigo_Producto + "  La Lista de Precio: " + lista_precio + "", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                esquema.Clear()
                datos.Clear()
                ClavePrincipal.Clear()
                ReDim ArticuloListaPrecio_estructura(1)
                ArticuloListaPrecio_estructura(1).IdListaPrecio = lista_precio
                ArticuloListaPrecio_estructura(1).IdProducto = Codigo_Producto
                ArticuloListaPrecio_estructura(1).PrecioCosto = Nothing
                ArticuloListaPrecio_estructura(1).Rentabilidad = Nothing
                ArticuloListaPrecio_estructura(1).PrecioVenta = Nothing
                ArticuloListaPrecio_estructura(1).PrecioKilo = Nothing
                clsarticulo.Obtener_Clave_PrincipalListaPrecio(ClavePrincipal)
                clsarticulo.Pasar_A_ColeccionArticuloListaPrecio(ArticuloListaPrecio_estructura, datos, 1)
                clsQueryBuilder.ArmaDelete(dfielddefConstantes.Producto_Lista_Precio.ToString(), datos, ClavePrincipal, consulta)
                clsarticulo.Operaciones_QueryBuilder(consulta)
                MessageBox.Show("La Lista de Precio" + lista_precio + ". Del Articulo: " + Codigo_Producto + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'consulta = "Select plp.Id_Lista_Precio as [Cod Lista Precio],lp.Descripcion,Id_Producto as [Cod Producto],Precio_Costo as [Precio Costo],Rentabilidad,Precio_Venta as [Precio Venta],Precio_Kilo as [Precio Kilo]  " & vbCrLf
                'consulta += "from Producto_Lista_Precio as  plp" & vbCrLf
                'consulta += "inner join  Lista_Precio as  lp on (Cint(plp.Id_Lista_Precio)=lp.Id_Lista_Precio)" & vbCrLf
                'consulta += "where Id_Producto='" & (ArticuloListaPrecio_estructura(1).Id_Producto) & "' "
                clsarticulo.llenar_tabla_Producto_Lista_Precios_Lista_Precio(ArticuloListaPrecio_estructura(1).IdProducto, DGVListaPrecio)
                BtnAgregarListaPrecio.Enabled = True
                BtnModificarListaPrecio.Enabled = False
                BtnEliminarListaPrecio.Enabled = False
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Private Sub CBCodProveedor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBCodProveedor.GotFocus
        'Dim clsContProveedor As New Controlador.clsContProveedor
        Dim consulta As String
        Dim dtdatos As New DataTable
        Try
            'consulta = "select * from " + dfielddefConstantes.Proveedor.ToString() + "  where Id_Proveedor=" & (CBCodProveedor.Text) & " "
            clsContProveedor.recuperar_Datos(CBCodProveedor.Text, dtdatos)
            LBProveedor.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub CBCodProveedor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBCodProveedor.LostFocus
        'Dim clsContProveedor As New Controlador.clsContProveedor
        Dim consulta As String
        Dim dtdatos As New DataTable
        Try
            'consulta = "select * from " + dfielddefConstantes.Proveedor.ToString() + "  where Id_Proveedor=" & (CBCodProveedor.Text) & " "
            clsContProveedor.recuperar_Datos(CBCodProveedor.Text, dtdatos)
            LBProveedor.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Razon_Social).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub CBRubro_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBRubro.SelectedValueChanged
        'Dim rubro As New Controlador.clsRubros
        Dim consulta As String
        Dim dtdatos As New DataTable
        'Dim articulo As New Controlador.clsArticulos
        Try
            If IsNumeric(CBRubro.Text) Then
                ' consulta = "select * from " + dfielddefConstantes.rubro.ToString() + "  where Id_Rubro='" & (CBRubro.Text) & "' "
                clsrubro.recuperar_Datos(CBRubro.Text, dtdatos)
                If dtdatos.Rows.Count > 0 Then
                    LBRubro.Text = dtdatos.Rows(0).Item(dfielddefRubro.Descripcion).ToString()
                    If (clsarticulo.Compvariable = dfielddefConstantes.Agregar_Producto.ToString()) Then
                        TBCodigoArticulo.Text = CBRubro.Text
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarExcel.Click
        'Dim clsGenerales As New Controlador.clsGenerales
        frmImportarExcel.Show()
        clsGenerales.Compvariable = dfielddefConstantes.Producto_Lista_Precio.ToString()
    End Sub
    Private Sub btnAgregarEmpresaArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarEmpresaArticulo.Click
        'Dim articulo As New Controlador.clsArticulos
        Dim consulta As String
        'Dim Empresa As New Controlador.clsEmpresas
        Try
            frmArticuloEmpresa.tbCodProducto.Text = TBCodigoArticulo.Text
            frmArticuloEmpresa.cbCodEmpresa.DropDownStyle = ComboBoxStyle.DropDownList
            clsarticulo.Compvariable_Articulo = dfielddefConstantes.AgregarArticuloEmpresa.ToString()
            frmArticuloEmpresa.ShowDialog()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DGVEmpresaArticulos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGVEmpresaArticulos.Click
        Try
            Cod_Producto = DGVEmpresaArticulos.CurrentRow.Cells(0).Value.ToString()
            Cod_Empresa = DGVEmpresaArticulos.CurrentRow.Cells(1).Value.ToString()
            Razon_Social = DGVEmpresaArticulos.CurrentRow.Cells(2).Value.ToString()
            btnAgregarEmpresaArticulo.Enabled = False
            btnEliminarEmpresaArticulo.Enabled = True
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnEliminarEmpresaArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarEmpresaArticulo.Click
        'Dim articulo As New Controlador.clsArticulos()
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection

        Dim result As Integer = MessageBox.Show("Desea Eliminar el Articulo: " + Cod_Producto + "  de La Empresa: " + Razon_Social + "", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                esquema.Clear()
                datos.Clear()
                ClavePrincipal.Clear()
                ReDim ArticuloEmpresa_estructura(1)
                ArticuloEmpresa_estructura(1).Id_Articulo = Cod_Producto
                ArticuloEmpresa_estructura(1).Id_Empresa = Cod_Empresa
                clsarticulo.Obtener_Clave_PrincipalArticuloEmpresa(ClavePrincipal)
                clsarticulo.Pasar_A_ColeccionArticuloEmpresa(ArticuloEmpresa_estructura, datos, 1)
                clsQueryBuilder.ArmaDelete(dfielddefConstantes.EmpresaArticulo.ToString(), datos, ClavePrincipal, consulta)
                clsarticulo.Operaciones_Tabla(consulta)

                MessageBox.Show("El Articulo " + Cod_Producto + ", se Elimino Correctamente de la Empresa: " + Razon_Social + "", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'consulta = "Select Id_Articulo as [Cod Articulo],EA.Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],CUIT " & vbCrLf
                'consulta += "from EmpresaArticulo as EA " & vbCrLf
                'consulta += "inner join Empresa as E on  E.Id_Empresa=EA.Id_Empresa " & vbCrLf
                'consulta += "where Id_Articulo='" & (ArticuloEmpresa_estructura(1).Id_Articulo) & "' "
                clsarticulo.llenar_tabla_EmpresaArticulo_Empresa(ArticuloEmpresa_estructura(1).Id_Articulo, DGVEmpresaArticulos)

                btnAgregarEmpresaArticulo.Enabled = True
                btnEliminarEmpresaArticulo.Enabled = False
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim articulos_Estructura(0)
        ReDim ArticuloListaPrecio_estructura(0)
        ReDim ArticuloEmpresa_estructura(0)
    End Sub
    Private Sub CBTasaIVA_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBTasaIVA.SelectedValueChanged
        'Dim clsTasaIVA As New Controlador.clsTasaIVA
        Dim consulta As String
        Dim dtdatos As New DataTable
        Try
            If IsNumeric(CBTasaIVA.Text) Then
                'consulta = "select * from " + dfielddefConstantes.Tasa_IVA.ToString() + "  where Tasa='" & (CBTasaIVA.Text) & "' "
                clsTasaIVA.recuperar_Datos(CBTasaIVA.Text, dtdatos)
                If dtdatos.Rows.Count > 0 Then
                    LbTasaIVA.Text = dtdatos.Rows(0).Item(dfielddefTasaIva.Descripcion).ToString()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub CBCodProveedor_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBCodProveedor.SelectedValueChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        Dim consulta As String
        Dim dtdatos As New DataTable
        Try
            If IsNumeric(CBCodProveedor.Text) Then
                'consulta = "select * from " + dfielddefConstantes.Proveedor.ToString() + "  where Id_Proveedor=" & (CBCodProveedor.Text) & " "
                clsContProveedor.recuperar_Datos(CBCodProveedor.Text, dtdatos)
                If dtdatos.Rows.Count > 0 Then
                    LBProveedor.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Razon_Social).ToString()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class