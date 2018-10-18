Imports Controlador
Public Class frmArticulos
    Public id_Articulo As Integer
    Public Descripcion_Articulo As String
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim articulos_Estructura(0) As Controlador.Articulos.eArticulo
    Dim dfielddefArticulos As Controlador.DfieldDef.eArticulos
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim _datosEmpresa As New DataTable
    Private Sub SalirArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirArticulo.Click
        Dim articulo As New Controlador.Articulos
        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        articulo.Compvariable = String.Empty
        Me.Close()
    End Sub
    Private Sub Articulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim articulo As New Controlador.Articulos
        Dim consulta As String
        Dim Empresa As New Controlador.Empresas()
        Try
            ToolStripNuevoArticulo.Enabled = True
            ToolStripModificarArticulo.Enabled = False
            ToolStripEliminarArticulo.Enabled = False
            'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
            Empresa.Obtener_Empresa(Empresa.Compvariable, _datosEmpresa)
            If articulo.Compvariable = dfielddefConstantes.ArticulosVentaRapida.ToString() Or articulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString() Or articulo.Compvariable = dfielddefConstantes.ArticulosNotaCredito.ToString() Or articulo.Compvariable = dfielddefConstantes.ArticulosNotaDebito.ToString() Then
                ToolStripEnviarArticulo.Visible = True
                'consulta = " select Id_Producto as [Cod Producto],Id_Rubro as [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as[Stock Minimo] ,Stock,Pesable,Tipo_Unidad as[Tipo Unidad] ,Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as[Cod Prod Proveedor] " & vbCrLf
                'consulta += " from (Producto as P " & vbCrLf
                'consulta += " inner join EmpresaArticulo as EA on  P.Id_Producto=EA.Id_Articulo)" & vbCrLf
                'consulta += " where INHABILITAR=false and  EA.Id_Empresa='" + _datosEmpresa(0).Item("Id_Empresa") + "'"
                articulo.llenar_tabla_Producto_Empresa_Articulo(_datosEmpresa(0).Item("Id_Empresa"), DGVArticulo)
            Else
                ToolStripEnviarArticulo.Visible = False
                'consulta = "select Id_Producto as [Cod Producto],Id_Rubro as [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as[Stock Minimo] ,Stock,Pesable,Tipo_Unidad as[Tipo Unidad],Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as[Cod Prod Proveedor] from " + dfielddefConstantes.Producto.ToString() + " "
                articulo.llenar_tabla_Articulo(DGVArticulo)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub ToolStripNuevoArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNuevoArticulo.Click
        Dim articulo As New Controlador.Articulos
        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        articulo.Compvariable = dfielddefConstantes.Agregar_Producto.ToString()
        Me.Close()
        frmArticulosAltas.Show()
    End Sub
    Private Sub ToolStripEliminarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEliminarArticulo.Click
        Dim articulo As New Controlador.Articulos()
        Dim Facturacion As New Controlador.Facturacion()
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim existe As Boolean

        Dim result As Integer = MessageBox.Show("Desea Eliminar al Articulo: " + CStr(id_Articulo) + " " + Descripcion_Articulo, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                'consulta = "select * from " + dfielddefConstantes.Cuerpo_Factura.ToString() + "  where Numero_Articulo='" + Convert.ToString(id_Articulo) + "'"
                Facturacion.se_Cargo_articulo_En_Factura(id_Articulo, existe)
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

                    articulo.Obtener_Clave_Principal(ClavePrincipal)
                    articulo.Pasar_A_Coleccion(articulos_Estructura, datos, 1)
                    querybuilder.ArmaDelete(dfielddefConstantes.Producto.ToString(), datos, ClavePrincipal, consulta)
                    articulo.Operaciones_Tabla(consulta)

                    MessageBox.Show("El Articulo " + CStr(id_Articulo) + " " + Descripcion_Articulo + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'consulta = "select Id_Producto as [Cod Producto],Id_Rubro as [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as[Stock Minimo] ,Stock,Pesable,Tipo_Unidad as[Tipo Unidad] ,Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as[Cod Prod Proveedor]  from " + dfielddefConstantes.Producto.ToString() + ""
                    articulo.llenar_tabla_Articulo(DGVArticulo)
                    LimpiarEstructuras()
                Else
                    MessageBox.Show("El Articulo " + CStr(id_Articulo) + " " + Descripcion_Articulo + " No se puede Eliminar, Posee Movimientos!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Private Sub ToolStripModificarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModificarArticulo.Click
        Dim articulo As New Controlador.Articulos
        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        frmArticulosAltas.TBNumeroAsignado.Enabled = False
        frmArticulosAltas.BTNGenerarCodigo.Enabled = False
        frmArticulosAltas.CBRubro.Enabled = False
        articulo.Compvariable = dfielddefConstantes.Modificar_Articulo.ToString()
        Me.Close()
        frmArticulosAltas.Show()
    End Sub
    Private Sub TBBusquedaArticulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBBusquedaArticulo.TextChanged
        Dim consulta As String
        Dim articulo As New Controlador.Articulos
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

                If articulo.Compvariable = dfielddefConstantes.ArticulosVentaRapida.ToString() Or articulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString() Or articulo.Compvariable = dfielddefConstantes.ArticulosNotaCredito.ToString() Or articulo.Compvariable = dfielddefConstantes.ArticulosNotaDebito.ToString() Then
                    ToolStripEnviarArticulo.Visible = True
                    'consulta = " select Id_Producto as [Cod Producto],Id_Rubro as [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as[Stock Minimo] ,Stock,Pesable,Tipo_Unidad as[Tipo Unidad] ,Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as[Cod Prod Proveedor] " & vbCrLf
                    'consulta += " from (Producto as P " & vbCrLf
                    'consulta += " inner join EmpresaArticulo as EA on  P.Id_Producto=EA.Id_Articulo)" & vbCrLf
                    'consulta += " where INHABILITAR=false and  EA.Id_Empresa='" + _datosEmpresa(0).Item("Id_Empresa") + "'"
                    'consulta += " and  " + Nombre_Columna_a_Buscar + " like '" & Me.TBBusquedaArticulo.Text & "%'"
                    articulo.llenar_tabla_Producto_Empresa_Articulo(_datosEmpresa(0).Item("Id_Empresa"), DGVArticulo, Nombre_Columna_a_Buscar, TBBusquedaArticulo.Text)
                Else
                    ToolStripEnviarArticulo.Visible = False
                    'consulta = "select Id_Producto as [Cod Producto],Id_Rubro as [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as[Stock Minimo] ,Stock,Pesable,Tipo_Unidad as[Tipo Unidad],Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as[Cod Prod Proveedor] from " + dfielddefConstantes.Producto.ToString() + " " & vbCrLf
                    'consulta += " where " + Nombre_Columna_a_Buscar + " like '" & Me.TBBusquedaArticulo.Text & "%' "
                    articulo.llenar_tabla_Articulo(DGVArticulo, Nombre_Columna_a_Buscar, Me.TBBusquedaArticulo.Text)
                End If
            Else
                MessageBox.Show("Error: No selecciono ningun criterio de busqueda!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DGVArticulo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVArticulo.Click
        Dim articulo As New Controlador.Articulos()
        Try
            ToolStripNuevoArticulo.Enabled = False
            ToolStripModificarArticulo.Enabled = True
            ToolStripEliminarArticulo.Enabled = True

            id_Articulo = CInt(DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Id_Producto).Value.ToString())
            Descripcion_Articulo = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Descripcion).Value.ToString()
            articulo.Compvariable_Articulo = id_Articulo

            frmArticulosAltas.TBCodigoArticulo.Text = CStr(id_Articulo)
            frmArticulosAltas.TBNumeroAsignado.Text = CStr(id_Articulo)

            frmArticulosAltas.TBCodigoBarra.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Codigo_Barras).Value.ToString()
            frmArticulosAltas.TBDescripcion.Text = DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Descripcion).Value.ToString()

            articulo.CompId_Proveedor = Convert.ToInt32(DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Id_Proveedor).Value)
            articulo.CompId_Tasa_IVA = Convert.ToInt32(DGVArticulo.CurrentRow.Cells(dfielddefArticulos.Id_Tasa_IVA).Value)

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
        Dim articulo As New Controlador.Articulos
        Dim facturacionArticulo As New Controlador.Facturacion

        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        If articulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString() Then
            If (articulo.Compvariable_Articulo <> Nothing) Then
                'Facturacion.CompCodigo = articulo.Compvariable_Articulo.ToString()
                'VFacturacion.txtBusquedaArticulo.Text = articulo.Compvariable_Articulo.ToString()
                facturacionArticulo.FacturacionCodArticulo = articulo.Compvariable_Articulo.ToString()
                'articulo.Compvariable = ""
            Else
                If (articulo.Compvariable_Articulo = Nothing) Then
                    'VFacturacion.txtBusquedaArticulo.Text = Nothing
                    articulo.Compvariable = ""
                End If
            End If
        End If
        If articulo.Compvariable = dfielddefConstantes.ArticulosNotaCredito.ToString() Then
            If (articulo.Compvariable_Articulo <> Nothing) Then
                frmNotaCredito.txtBusquedaArticulo.Text = articulo.Compvariable_Articulo.ToString()
                articulo.Compvariable = String.Empty
            Else
                If (articulo.Compvariable_Articulo = Nothing) Then
                    frmNotaCredito.txtBusquedaArticulo.Text = Nothing
                    articulo.Compvariable = String.Empty
                End If
            End If
        End If
        If articulo.Compvariable = dfielddefConstantes.ArticulosNotaDebito.ToString() Then
            If (articulo.Compvariable_Articulo <> Nothing) Then
                frmNotaDebito.txtBusquedaArticulo.Text = articulo.Compvariable_Articulo.ToString()
                articulo.Compvariable = String.Empty
            Else
                If (articulo.Compvariable_Articulo = Nothing) Then
                    frmNotaDebito.txtBusquedaArticulo.Text = Nothing
                    articulo.Compvariable = String.Empty
                End If
            End If
        End If
        If articulo.Compvariable = dfielddefConstantes.ArticulosVentaRapida.ToString() Then
            If (articulo.Compvariable_Articulo <> Nothing) Then
                frmVentaRapida.txtBusquedaArticulo.Text = articulo.Compvariable_Articulo.ToString()
                articulo.Compvariable = String.Empty
            Else
                If (articulo.Compvariable_Articulo = Nothing) Then
                    frmVentaRapida.txtBusquedaArticulo.Text = Nothing
                End If
            End If
        End If
        Me.Close()
    End Sub
    Private Sub ToolStripButtonCargarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonCargarExcel.Click
        Dim Generales As New Controlador.Generales
        frmImportarExcel.Show()
        Generales.Compvariable = dfielddefConstantes.Producto.ToString()
    End Sub
End Class