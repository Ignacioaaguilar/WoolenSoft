Imports Controlador
Public Class ArticulosProveedor
    Public id_Articulo As Integer
    Public Descripcion_Articulo As String
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim dfielddefArticulos As Controlador.DfieldDef.eArticulos
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim dfieldefConfiguracion As Controlador.DfieldDef.eConfiguracion
    Private Sub SalirArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirArticulo.Click
        Dim articulo As New Controlador.Articulos
        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        articulo.CompId_Articulo = ""
        articulo.CompDescripcion = ""
        articulo.Compvariable = ""
        ToolStripEnviarArticulo.Enabled = False
        Me.Close()
    End Sub
    Private Sub Articulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim articulo As New Controlador.Articulos()
        Dim consulta As String
        Dim Empresa As New Controlador.Empresas()
        Dim Configuracion As New Controlador.Configuracion()
        Dim datos As New DataTable

        Dim Datos_Configuracion As Controlador.Configuracion.eConfiguracion
        Try
            ' consulta = "Select * from Configuracion"
            Configuracion.Obtener_Datos_Configuracion(Datos_Configuracion)

            'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
            Empresa.Obtener_Empresa(Empresa.Compvariable, datos)

            'consulta = " select P.Id_Producto as [Cod Producto],Id_Rubro as  [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as [Stock Minimo],Stock,Pesable,Tipo_Unidad as [Tipo Unidad],Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as [Cod Prod Proveedor] " & vbCrLf
            'consulta += "  from ((Producto as P" & vbCrLf
            'consulta += " inner join EmpresaArticulo as EA on P.Id_Producto=EA.Id_Articulo)" & vbCrLf
            'consulta += " inner join Producto_Lista_Precio as PLP on P.Id_Producto = PLP.Id_Producto)  " & vbCrLf
            'consulta += " where(INHABILITAR = False)" & vbCrLf
            'consulta += " and  EA.Id_Empresa='" + datos(0).Item("Id_Empresa") + "' and PLP.ID_Lista_Precio='" + Datos_Configuracion.Rows(0).Item(dfieldefConfiguracion.Id_Lista_Precio).ToString() + "'"
            'articulo.llenar_tabla_Producto_EmpresaArticulo_Producto_Lista_Precio(datos(0).Item("Id_Empresa"), Datos_Configuracion.Rows(0).Item(dfieldefConfiguracion.Id_Lista_Precio).ToString(), DGVArticuloProveedor)
            articulo.llenar_tabla_Producto_EmpresaArticulo_Producto_Lista_Precio(datos(0).Item("Id_Empresa"), Datos_Configuracion.Id_Lista_Precio, DGVArticuloProveedor)

            ToolStripEnviarArticulo.Enabled = False
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TBBusquedaArticulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBBusquedaArticulo.TextChanged
        Dim articulo As New Controlador.Articulos()
        Dim consulta As String
        Dim Empresa As New Controlador.Empresas()
        Dim Configuracion As New Controlador.Configuracion()
        Dim datos As New DataTable
        Dim Datos_Configuracion As Controlador.Configuracion.eConfiguracion
        Try
            If Nombre_Columna_a_Buscar <> "" Then
                If Nombre_Columna_a_Buscar = "Cod Producto" Then
                    Nombre_Columna_a_Buscar = "P." + dfielddefConstantes.Id_Producto.ToString
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

                'consulta = "Select * from Configuracion"
                Configuracion.Obtener_Datos_Configuracion(Datos_Configuracion)

                'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
                Empresa.Obtener_Empresa(Empresa.Compvariable, datos)

                'consulta = " select P.Id_Producto as [Cod Producto],Id_Rubro as [Cod Rubro],Codigo_Barras as [Cod Barras],Descripcion,Id_Proveedor as [Cod Proveedor],Id_Tasa_IVA as [Tasa IVA],Stock_Minimo as [Stock Minimo],Stock,Pesable,Tipo_Unidad as [Tipo Unidad],Cantidad_Unid_Caja as [Cantidad Por Caja],Peso_Unidad as [Peso Por Unidad],INHABILITAR,Cod_Prod_Proveedor as [Cod Prod Proveedor]" & vbCrLf
                'consulta += " from ((Producto as P" & vbCrLf
                'consulta += " inner join EmpresaArticulo as EA on P.Id_Producto=EA.Id_Articulo )" & vbCrLf
                'consulta += " inner join Producto_Lista_Precio as PLP on  P.Id_Producto = PLP.Id_Producto ) " & vbCrLf
                'consulta += " where(INHABILITAR = False)" & vbCrLf
                'consulta += " and P.Id_Proveedor= '" + Convert.ToString(articulo.CompId_Proveedor) + "'  " & vbCrLf
                'consulta += " and EA.Id_Empresa='" + datos(0).Item("Id_Empresa") + "' " & vbCrLf
                'consulta += " and PLP.ID_Lista_Precio='" + Datos_Configuracion.Rows(0).Item(dfieldefConfiguracion.Id_Lista_Precio).ToString() + "' " & vbCrLf
                'consulta += " and  " + Nombre_Columna_a_Buscar + "  like '" & Me.TBBusquedaArticulo.Text & "%' " ' "
                'articulo.llenar_tabla_Producto_EmpresaArticulo_Producto_Lista_Precio(Convert.ToString(articulo.CompId_Proveedor), datos(0).Item("Id_Empresa"), Datos_Configuracion.Rows(0).Item(dfieldefConfiguracion.Id_Lista_Precio).ToString(), DGVArticuloProveedor, Nombre_Columna_a_Buscar, Me.TBBusquedaArticulo.Text)

                articulo.llenar_tabla_Producto_EmpresaArticulo_Producto_Lista_Precio(Convert.ToString(articulo.CompId_Proveedor), datos(0).Item("Id_Empresa"), Datos_Configuracion.Id_Lista_Precio, DGVArticuloProveedor, Nombre_Columna_a_Buscar, Me.TBBusquedaArticulo.Text)
            Else
                MessageBox.Show("Error: No selecciono ningun criterio de busqueda!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub DGVArticuloProveedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVArticuloProveedor.Click
        Dim articulo As New Controlador.Articulos()
        Try
            id_Articulo = CInt(DGVArticuloProveedor.CurrentRow.Cells(dfielddefArticulos.Id_Producto).Value.ToString())
            Descripcion_Articulo = DGVArticuloProveedor.CurrentRow.Cells(dfielddefArticulos.Descripcion).Value.ToString()
            ToolStripEnviarArticulo.Enabled = True
            Posicion_Columna = DGVArticuloProveedor.CurrentCell.ColumnIndex
            Nombre_Columna_a_Buscar = DGVArticuloProveedor.Columns(Posicion_Columna).Name
            If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Cod_Producto.ToString, "_", " ")) Or (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Id_Producto.ToString, "_", " ")) Then
                Me.Label2.Text = "Codigo Producto:"
            Else
                If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Cod_Rubro.ToString(), "_", " ")) Or (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Id_Rubro.ToString(), "_", " ")) Then
                    Me.Label2.Text = "Rubro:"
                Else
                    If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Cod_Barras.ToString(), "_", " ")) Or (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Codigo_Barras.ToString(), "_", " ")) Then
                        Me.Label2.Text = "Codigo Barras:"
                    Else
                        If (Nombre_Columna_a_Buscar = dfielddefConstantes.Descripcion.ToString()) Then
                            Me.Label2.Text = "Descripcion:"
                        Else
                            If (Nombre_Columna_a_Buscar = dfielddefConstantes.Pesable.ToString()) Then
                                Me.Label2.Text = "Es Pesable:"
                            Else
                                If (Nombre_Columna_a_Buscar = Replace(dfielddefConstantes.Tipo_Unidad.ToString(), "_", " ")) Then
                                    Me.Label2.Text = "Tipo Unidad:"
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripEnviarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEnviarArticulo.Click
        Dim articulo As New Controlador.Articulos
        Dim facturacionProv As New Vista.FacturacionProveedores()
        For x As Integer = ProgressBarArticulo.Minimum To ProgressBarArticulo.Maximum
            ProgressBarArticulo.Value = x
        Next
        For x As Integer = ProgressBarArticulo.Maximum To ProgressBarArticulo.Minimum Step -1
            ProgressBarArticulo.Value = x
        Next
        articulo.CompId_Articulo = Convert.ToString(id_Articulo)
        articulo.CompDescripcion = Convert.ToString(Descripcion_Articulo)
        Me.Close()
    End Sub
End Class