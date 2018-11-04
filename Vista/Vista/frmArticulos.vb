Imports Controlador
Imports DevComponents.DotNetBar
Public Class frmArticulos
    Public id_Articulo As Integer
    Public Descripcion_Articulo As String
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim articulos_Estructura(0) As Controlador.clsArticulos.eArticulo
    Dim dfielddefArticulos As Controlador.clsDfieldDef.eArticulos
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim _datosEmpresa As New DataTable
    Dim clsarticulo As New Controlador.clsArticulos
    Dim clsEmpresa As New Controlador.clsEmpresas()
    Dim clsFacturacion As New Controlador.clsFacturacion()
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim clsfacturacionArticulo As New Controlador.clsFacturacion
    Dim clsGenerales As New Controlador.clsGenerales

    Private Sub SalirArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirArticulo.Click
        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        clsarticulo.Compvariable = String.Empty
        Me.Close()
    End Sub
    Private Sub Articulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Try
            ToolStripNuevoArticulo.Enabled = True
            ToolStripModificarArticulo.Enabled = False
            ToolStripEliminarArticulo.Enabled = False
            clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, _datosEmpresa)
            If clsarticulo.Compvariable = dfielddefConstantes.ArticulosVentaRapida.ToString() Or clsarticulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString() Or clsarticulo.Compvariable = dfielddefConstantes.ArticulosNotaCredito.ToString() Or clsarticulo.Compvariable = dfielddefConstantes.ArticulosNotaDebito.ToString() Then
                ToolStripEnviarArticulo.Visible = True
                clsarticulo.llenar_tabla_Producto_Empresa_Articulo(_datosEmpresa(0).Item("Id_Empresa"), DGVArticulo)
            Else
                ToolStripEnviarArticulo.Visible = False
                clsarticulo.llenar_tabla_Articulo(DGVArticulo)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub ToolStripNuevoArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNuevoArticulo.Click
        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        clsarticulo.Compvariable = dfielddefConstantes.Agregar_Producto.ToString()
        Me.Close()
        frmArticulosAltas.Show()
    End Sub
    Private Sub ToolStripEliminarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEliminarArticulo.Click
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim existe As Boolean

        Dim result As Integer = MessageBoxEx.Show("Desea Eliminar al Articulo: " + CStr(id_Articulo) + " " + Descripcion_Articulo, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                clsFacturacion.se_Cargo_articulo_En_Factura(id_Articulo, existe)
                If Not existe Then
                    ReDim articulos_Estructura(1)
                    articulos_Estructura(1).Id_Producto = id_Articulo
                    articulos_Estructura(1).Id_Rubro = Nothing
                    articulos_Estructura(1).Codigo_Barras = Nothing
                    articulos_Estructura(1).Descripcion = Nothing
                    articulos_Estructura(1).Id_Proveedor = Nothing
                    articulos_Estructura(1).Id_Tasa_IVA = Nothing
                    articulos_Estructura(1).Stock_Minimo = Nothing
                    articulos_Estructura(1).Stock = Nothing
                    articulos_Estructura(1).Pesable = Nothing
                    articulos_Estructura(1).Tipo_Unidad = Nothing
                    articulos_Estructura(1).Cantidad_Unid_Caja = Nothing
                    articulos_Estructura(1).Peso_Unidad = Nothing

                    clsarticulo.Obtener_Clave_Principal(ClavePrincipal)
                    clsarticulo.Pasar_A_Coleccion(articulos_Estructura, datos, 1)
                    clsQueryBuilder.ArmaDelete(dfielddefConstantes.Producto.ToString(), datos, ClavePrincipal, consulta)
                    clsarticulo.Operaciones_Tabla(consulta)

                    MessageBoxEx.Show("El Articulo " + CStr(id_Articulo) + " " + Descripcion_Articulo + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    clsarticulo.llenar_tabla_Articulo(DGVArticulo)
                    LimpiarEstructuras()
                Else
                    MessageBoxEx.Show("El Articulo " + CStr(id_Articulo) + " " + Descripcion_Articulo + " No se puede Eliminar, Posee Movimientos!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Private Sub ToolStripModificarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModificarArticulo.Click
        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        frmArticulosAltas.TBNumeroAsignado.Enabled = False
        frmArticulosAltas.BTNGenerarCodigo.Enabled = False
        frmArticulosAltas.CBRubro.Enabled = False
        clsarticulo.Compvariable = dfielddefConstantes.Modificar_Articulo.ToString()
        Me.Close()
        frmArticulosAltas.Show()
    End Sub
    Private Sub TBBusquedaArticulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBBusquedaArticulo.TextChanged
        Dim consulta As String

        Try
            If Nombre_Columna_a_Buscar <> String.Empty Then
                If Nombre_Columna_a_Buscar = "Cod Producto" Then
                    Nombre_Columna_a_Buscar = dfielddefConstantes.Id_Producto.ToString
                End If
                If Nombre_Columna_a_Buscar = "Cod Rubro" Then
                    Nombre_Columna_a_Buscar = dfielddefConstantes.Id_Rubro.ToString()
                End If
                If Nombre_Columna_a_Buscar = "Cod Barras" Then
                    Nombre_Columna_a_Buscar = dfielddefConstantes.Codigo_Barras.ToString
                End If
                If Nombre_Columna_a_Buscar = "Descripcion" Then
                    Nombre_Columna_a_Buscar = dfielddefConstantes.Descripcion.ToString
                End If

                If clsarticulo.Compvariable = dfielddefConstantes.ArticulosVentaRapida.ToString() Or clsarticulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString() Or clsarticulo.Compvariable = dfielddefConstantes.ArticulosNotaCredito.ToString() Or clsarticulo.Compvariable = dfielddefConstantes.ArticulosNotaDebito.ToString() Then
                    ToolStripEnviarArticulo.Visible = True
                    clsarticulo.llenar_tabla_Producto_Empresa_Articulo(_datosEmpresa(0).Item("Id_Empresa"), DGVArticulo, Nombre_Columna_a_Buscar, TBBusquedaArticulo.Text)
                Else
                    ToolStripEnviarArticulo.Visible = False
                    clsarticulo.llenar_tabla_Articulo(DGVArticulo, Nombre_Columna_a_Buscar, Me.TBBusquedaArticulo.Text)
                End If
            Else
                MessageBoxEx.Show("Error: No selecciono ningun criterio de busqueda!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DGVArticulo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVArticulo.Click
        Try
            ToolStripNuevoArticulo.Enabled = False
            ToolStripModificarArticulo.Enabled = True
            ToolStripEliminarArticulo.Enabled = True

            id_Articulo = CInt(DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Id_Producto).Value.ToString())
            Descripcion_Articulo = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Descripcion).Value.ToString()
            clsarticulo.Compvariable_Articulo = id_Articulo

            frmArticulosAltas.TBCodigoArticulo.Text = CStr(id_Articulo)
            frmArticulosAltas.TBNumeroAsignado.Text = CStr(id_Articulo)

            frmArticulosAltas.TBCodigoBarra.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Codigo_Barras).Value.ToString()
            frmArticulosAltas.TBDescripcion.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Descripcion).Value.ToString()

            clsarticulo.CompId_Proveedor = Convert.ToInt32(DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Id_Proveedor).Value)
            clsarticulo.CompId_Tasa_IVA = Convert.ToInt32(DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Id_Tasa_IVA).Value)

            frmArticulosAltas.TBStockMinimo.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Stock_Minimo).Value.ToString()
            frmArticulosAltas.TBStock.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Stock).Value.ToString()

            frmArticulosAltas.CBPesable.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Pesable).Value.ToString()
            frmArticulosAltas.CBUnidades.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Tipo_Unidad).Value.ToString()
            frmArticulosAltas.TBCantUnidCaja.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Cantidad_Unid_Caja).Value.ToString()
            frmArticulosAltas.TBPesoUnidad.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Peso_Unidad).Value.ToString()

            frmArticulosAltas.cbInhabiliarArticulo.Checked = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.INHABILITAR).Value.ToString()
            frmArticulosAltas.tbCodProdProveedor.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Cod_Prod_Proveedor).Value.ToString()

            Posicion_Columna = DGVArticulo.CurrentCell.ColumnIndex
            Nombre_Columna_a_Buscar = DGVArticulo.Columns(Posicion_Columna).Name

            If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Cod_Producto.ToString, "_", " ")) Or (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Id_Producto.ToString, "_", " ")) Then
                Me.Label2.Text = "Codigo Producto:"
            Else
                If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Cod_Rubro.ToString(), "_", " ")) Or (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Id_Rubro.ToString, "_", " ")) Then
                    Me.Label2.Text = "Rubro:"
                Else
                    If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Cod_Barras.ToString(), "_", " ")) Or (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Codigo_Barras.ToString, "_", " ")) Then
                        Me.Label2.Text = "Codigo Barras:"
                    Else
                        If (Nombre_Columna_a_Buscar = dfielddefConstantes.Descripcion.ToString()) Then
                            Me.Label2.Text = "Descripcion:"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim articulos_Estructura(0)
    End Sub
    Private Sub ToolStripEnviarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEnviarArticulo.Click
        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        If clsarticulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString() Then
            If (clsarticulo.Compvariable_Articulo <> Nothing) Then
                clsfacturacionArticulo.FacturacionCodArticulo = clsarticulo.Compvariable_Articulo.ToString()
            Else
                If (clsarticulo.Compvariable_Articulo = Nothing) Then
                    clsarticulo.Compvariable = ""
                End If
            End If
        End If
        If clsarticulo.Compvariable = dfielddefConstantes.ArticulosNotaCredito.ToString() Then
            If (clsarticulo.Compvariable_Articulo <> Nothing) Then
                frmNotaCredito.txtBusquedaArticulo.Text = clsarticulo.Compvariable_Articulo.ToString()
                clsarticulo.Compvariable = String.Empty
            Else
                If (clsarticulo.Compvariable_Articulo = Nothing) Then
                    frmNotaCredito.txtBusquedaArticulo.Text = Nothing
                    clsarticulo.Compvariable = String.Empty
                End If
            End If
        End If
        If clsarticulo.Compvariable = dfielddefConstantes.ArticulosNotaDebito.ToString() Then
            If (clsarticulo.Compvariable_Articulo <> Nothing) Then
                frmNotaDebito.txtBusquedaArticulo.Text = clsarticulo.Compvariable_Articulo.ToString()
                clsarticulo.Compvariable = String.Empty
            Else
                If (clsarticulo.Compvariable_Articulo = Nothing) Then
                    frmNotaDebito.txtBusquedaArticulo.Text = Nothing
                    clsarticulo.Compvariable = String.Empty
                End If
            End If
        End If
        If clsarticulo.Compvariable = dfielddefConstantes.ArticulosVentaRapida.ToString() Then
            If (clsarticulo.Compvariable_Articulo <> Nothing) Then
                frmVentaRapida.txtBusquedaArticulo.Text = clsarticulo.Compvariable_Articulo.ToString()
                clsarticulo.Compvariable = String.Empty
            Else
                If (clsarticulo.Compvariable_Articulo = Nothing) Then
                    frmVentaRapida.txtBusquedaArticulo.Text = Nothing
                End If
            End If
        End If
        Me.Close()
    End Sub
    Private Sub ToolStripButtonCargarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCargarExcel.Click
        frmImportarExcel.Show()
        clsGenerales.Compvariable = dfielddefConstantes.Producto.ToString()
    End Sub
End Class