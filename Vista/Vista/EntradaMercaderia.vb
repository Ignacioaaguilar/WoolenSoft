Imports Controlador
Public Class EntradaMercaderia
    Dim dfielddefEmpresa As New Controlador.DfieldDef.eEmpresa
    Dim caracteres As String = ""
    Dim DatosEmpresa As New DataTable
    Dim Datos_Configuracion As Controlador.Configuracion.eConfiguracion
    Dim dfielddefProveedor As Controlador.DfieldDef.eProveedor
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim dfieldefConfiguracion As Controlador.DfieldDef.eConfiguracion
    Dim EntradaSalidaMercEncESt(0) As Controlador.Articulos.eEncabezadoEntradaSalidaMercaderia
    Dim EntradaSalidaMercaderiaCuerpoESt(0) As Controlador.Articulos.eCuerpoEntradaSalidaMercaderia
    Dim ArticulosESt(0) As Controlador.Articulos.eArticulo
    Enum enumerado
        columnaTipoUnidad = 1
        ColumnaCodBarras = 2
        ColumnaCodArticulo = 3
        ColumnaDescripcionArt = 4
        ColumnaUnidKilos = 5

    End Enum
    Private Sub chbInicializarStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbInicializarStock.CheckedChanged
        If chbInicializarStock.Checked = True Then
            dgvEntradaMercaderia.Enabled = False
            chbActualizarStockArticulos.Checked = False
        Else
            dgvEntradaMercaderia.Enabled = True
        End If
    End Sub

    Private Sub ToolStripButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSalir.Click
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next

        Me.Close()
    End Sub

    Private Sub ToolStripButtonRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonRegistrar.Click
        Dim consulta As String
        Dim Articulos As New Controlador.Articulos()
        Dim Empresa As New Controlador.Empresas()
        Dim Datos As New DataTable
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim ClavePrincipal As New Collection
        Dim ultimo As Integer
        Dim DatosEst As New Collection
        Dim tran As New Collection
        Dim Transaccion As New Controlador.Transacciones
        Dim idx As Integer
        Dim jdx As Integer
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        dgvEntradaMercaderia.EndEdit()
        'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
        Empresa.Obtener_Empresa(Empresa.Compvariable, Datos)
        If chbInicializarStock.Checked = True Then

            'consulta = "Update" & vbCrLf
            'consulta += " (Producto as p" & vbCrLf
            'consulta += "inner join EmpresaArticulo as EA on P.Id_Producto=EA.Id_Articulo)" & vbCrLf
            'consulta += " set Stock = 0" & vbCrLf
            'consulta += "where EA.Id_Empresa='" + Datos.Rows(0).Item(dfielddefEmpresa.Id_Empresa) + "'"

            Articulos.Operaciones_Tabla(Datos.Rows(0).Item(dfielddefEmpresa.Id_Empresa))
            MessageBox.Show("El Stock Se ha Inicializado a Cero, Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                             MessageBoxIcon.Information)
        Else
            If Articulos.Compvariable = dfielddefConstantes.EntradaMercaderia.ToString() Then

                ReDim EntradaSalidaMercEncESt(1)
                'consulta = "select max(Id_Entrada_Salida) from Encabezado_Entrada_Salida_Mercaderia"
                Articulos.ObtenerUltimoNumero(ultimo, dfielddefConstantes.Encabezado_Entrada_Salida_Mercaderia.ToString())
                EntradaSalidaMercEncESt(1).Id_Entrada_Salida = ultimo
                EntradaSalidaMercEncESt(1).Descripcion_Entrada_Salida = tbDescripcion.Text
                EntradaSalidaMercEncESt(1).Fecha_Entrada_Salida = mtFecha.Text
                EntradaSalidaMercEncESt(1).Tipo_Movimiento = "Ingreso Mercaderias"

                querybuilder.obtener_estructura(dfielddefConstantes.Encabezado_Entrada_Salida_Mercaderia.ToString(), esquema)
                Articulos.Obtener_Clave_PrincipalEncabezadoEntradaSalidaMercaderia(ClavePrincipal)
                Articulos.Pasar_A_ColeccionEncabezadoEntradaSalidaMercaderia(EntradaSalidaMercEncESt, DatosEst, 1)
                querybuilder.ArmaInsert(dfielddefConstantes.Encabezado_Entrada_Salida_Mercaderia.ToString(), esquema, DatosEst, ClavePrincipal, consulta)
                tran.Add(consulta)
                consulta = ""
                esquema.Clear()
                ClavePrincipal.Clear()
                DatosEst.Clear()
                'consulta = "select max(Id_Cuerpo_Entrada_Salida) from Cuerpo_Entrada_Salida_Mercaderia"
                Articulos.ObtenerUltimoNumero(ultimo, dfielddefConstantes.Cuerpo_Entrada_Salida_Mercaderia.ToString())
                idx = 1
                jdx = ultimo
                For i As Integer = 0 To dgvEntradaMercaderia.Rows.Count - 1
                    If dgvEntradaMercaderia.Rows(i).Cells("CodArticulo").Value <> "" Then
                        ReDim EntradaSalidaMercaderiaCuerpoESt(idx)

                        EntradaSalidaMercaderiaCuerpoESt(idx).Id_Cuerpo_Entrada_Salida = jdx
                        EntradaSalidaMercaderiaCuerpoESt(idx).Id_Entrada_Salida = EntradaSalidaMercEncESt(1).Id_Entrada_Salida
                        EntradaSalidaMercaderiaCuerpoESt(idx).Tipo_Unidad = dgvEntradaMercaderia.Rows(i).Cells("TipoUnidad").Value()
                        EntradaSalidaMercaderiaCuerpoESt(idx).Codigo_Barras = dgvEntradaMercaderia.Rows(i).Cells("CodBarras").Value()
                        EntradaSalidaMercaderiaCuerpoESt(idx).Codigo_Producto = dgvEntradaMercaderia.Rows(i).Cells("CodArticulo").Value()
                        EntradaSalidaMercaderiaCuerpoESt(idx).Descripcion = dgvEntradaMercaderia.Rows(i).Cells("Descripcion").Value()
                        EntradaSalidaMercaderiaCuerpoESt(idx).CantidadUnidades = dgvEntradaMercaderia.Rows(i).Cells("UnidadesKilos").Value()

                        querybuilder.obtener_estructura(dfielddefConstantes.Cuerpo_Entrada_Salida_Mercaderia.ToString(), esquema)
                        Articulos.Obtener_Clave_PrincipalCuerpoEntradaSalidaMercaderia(ClavePrincipal)
                        Articulos.Pasar_A_ColeccionCuerpoEntradaSalidaMercaderia(EntradaSalidaMercaderiaCuerpoESt, DatosEst, idx)
                        querybuilder.ArmaInsert(dfielddefConstantes.Cuerpo_Entrada_Salida_Mercaderia.ToString(), esquema, DatosEst, ClavePrincipal, consulta)
                        tran.Add(consulta)

                        consulta = ""
                        esquema.Clear()
                        ClavePrincipal.Clear()
                        DatosEst.Clear()

                        'consulta = "select * from Producto    where Id_Producto= '" & (EntradaSalidaMercaderiaCuerpoESt(idx).Codigo_Producto) & "'"
                        Articulos.recuperar_Datos_Producto_EntradaSalidaMercaderia(EntradaSalidaMercaderiaCuerpoESt(idx).Codigo_Producto, Datos)

                        ReDim ArticulosESt(idx)
                        ArticulosESt(idx).Id_Producto = Datos.Rows(0).Item("Id_Producto").ToString()
                        ArticulosESt(idx).Id_Rubro = Datos.Rows(0).Item("Id_Rubro").ToString()
                        ArticulosESt(idx).Codigo_Barras = Datos.Rows(0).Item("Codigo_Barras").ToString()
                        ArticulosESt(idx).Descripcion = Datos.Rows(0).Item("Descripcion").ToString()
                        ArticulosESt(idx).Id_Proveedor = Datos.Rows(0).Item("Id_Proveedor").ToString()
                        ArticulosESt(idx).Id_Tasa_IVA = Datos.Rows(0).Item("Id_Tasa_IVA").ToString()
                        ArticulosESt(idx).Stock_Minimo = Datos.Rows(0).Item("Stock_Minimo").ToString()

                        If chbActualizarStockArticulos.Checked = True Then
                            ArticulosESt(idx).Stock = Convert.ToString(Convert.ToDouble(EntradaSalidaMercaderiaCuerpoESt(idx).CantidadUnidades) + Convert.ToDouble(Datos.Rows(0).Item("Stock")))
                        Else
                            ArticulosESt(idx).Stock = Convert.ToString(EntradaSalidaMercaderiaCuerpoESt(idx).CantidadUnidades)
                        End If
                        ArticulosESt(idx).Pesable = Datos.Rows(0).Item("Pesable").ToString()
                        ArticulosESt(idx).Tipo_Unidad = Datos.Rows(0).Item("Tipo_Unidad").ToString()
                        ArticulosESt(idx).Cantidad_Unid_Caja = Datos.Rows(0).Item("Cantidad_Unid_Caja").ToString()
                        ArticulosESt(idx).Peso_Unidad = Datos.Rows(0).Item("Peso_Unidad").ToString()
                        ArticulosESt(idx).INHABILITAR = Datos.Rows(0).Item("INHABILITAR")
                        ArticulosESt(idx).CodProdProveedor = Datos.Rows(0).Item("Cod_Prod_Proveedor").ToString()

                        querybuilder.obtener_estructura(dfielddefConstantes.Producto.ToString(), esquema)
                        Articulos.Obtener_Clave_Principal(ClavePrincipal)
                        Articulos.Pasar_A_Coleccion(ArticulosESt, DatosEst, idx)
                        querybuilder.ArmaUpdate(dfielddefConstantes.Producto.ToString(), esquema, DatosEst, ClavePrincipal, consulta)
                        tran.Add(consulta)

                        idx = idx + 1
                        jdx = jdx + 1
                        consulta = ""
                        esquema.Clear()
                        ClavePrincipal.Clear()
                        DatosEst.Clear()
                    End If
                Next
                MessageBox.Show("La Entrada de Mercaderia se ha realizado, Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                            MessageBoxIcon.Information)
            Else
                ReDim EntradaSalidaMercEncESt(1)
                'consulta = "select max(Id_Entrada_Salida) from Encabezado_Entrada_Salida_Mercaderia"
                Articulos.ObtenerUltimoNumero(ultimo, dfielddefConstantes.Encabezado_Entrada_Salida_Mercaderia.ToString())
                EntradaSalidaMercEncESt(1).Id_Entrada_Salida = ultimo
                EntradaSalidaMercEncESt(1).Descripcion_Entrada_Salida = tbDescripcion.Text
                EntradaSalidaMercEncESt(1).Fecha_Entrada_Salida = mtFecha.Text
                EntradaSalidaMercEncESt(1).Tipo_Movimiento = "Egreso Mercaderias"

                querybuilder.obtener_estructura(dfielddefConstantes.Encabezado_Entrada_Salida_Mercaderia.ToString(), esquema)
                Articulos.Obtener_Clave_PrincipalEncabezadoEntradaSalidaMercaderia(ClavePrincipal)
                Articulos.Pasar_A_ColeccionEncabezadoEntradaSalidaMercaderia(EntradaSalidaMercEncESt, DatosEst, 1)
                querybuilder.ArmaInsert(dfielddefConstantes.Encabezado_Entrada_Salida_Mercaderia.ToString(), esquema, DatosEst, ClavePrincipal, consulta)
                tran.Add(consulta)
                consulta = ""
                esquema.Clear()
                ClavePrincipal.Clear()
                DatosEst.Clear()
                'consulta = "select max(Id_Cuerpo_Entrada_Salida) from Cuerpo_Entrada_Salida_Mercaderia"
                Articulos.ObtenerUltimoNumero(ultimo, dfielddefConstantes.Cuerpo_Entrada_Salida_Mercaderia.ToString())
                idx = 1
                jdx = ultimo
                For i As Integer = 0 To dgvEntradaMercaderia.Rows.Count - 1
                    If dgvEntradaMercaderia.Rows(i).Cells("CodArticulo").Value <> "" Then
                        ReDim EntradaSalidaMercaderiaCuerpoESt(idx)

                        EntradaSalidaMercaderiaCuerpoESt(idx).Id_Cuerpo_Entrada_Salida = jdx
                        EntradaSalidaMercaderiaCuerpoESt(idx).Id_Entrada_Salida = EntradaSalidaMercEncESt(1).Id_Entrada_Salida
                        EntradaSalidaMercaderiaCuerpoESt(idx).Tipo_Unidad = dgvEntradaMercaderia.Rows(i).Cells("TipoUnidad").Value()
                        EntradaSalidaMercaderiaCuerpoESt(idx).Codigo_Barras = dgvEntradaMercaderia.Rows(i).Cells("CodBarras").Value()
                        EntradaSalidaMercaderiaCuerpoESt(idx).Codigo_Producto = dgvEntradaMercaderia.Rows(i).Cells("CodArticulo").Value()
                        EntradaSalidaMercaderiaCuerpoESt(idx).Descripcion = dgvEntradaMercaderia.Rows(i).Cells("Descripcion").Value()
                        EntradaSalidaMercaderiaCuerpoESt(idx).CantidadUnidades = dgvEntradaMercaderia.Rows(i).Cells("UnidadesKilos").Value()

                        querybuilder.obtener_estructura(dfielddefConstantes.Cuerpo_Entrada_Salida_Mercaderia.ToString(), esquema)
                        Articulos.Obtener_Clave_PrincipalCuerpoEntradaSalidaMercaderia(ClavePrincipal)
                        Articulos.Pasar_A_ColeccionCuerpoEntradaSalidaMercaderia(EntradaSalidaMercaderiaCuerpoESt, DatosEst, idx)
                        querybuilder.ArmaInsert(dfielddefConstantes.Cuerpo_Entrada_Salida_Mercaderia.ToString(), esquema, DatosEst, ClavePrincipal, consulta)
                        tran.Add(consulta)

                        consulta = ""
                        esquema.Clear()
                        ClavePrincipal.Clear()
                        DatosEst.Clear()

                        'consulta = "select * from Producto    where Id_Producto= '" & (EntradaSalidaMercaderiaCuerpoESt(idx).Codigo_Producto) & "'"
                        Articulos.recuperar_Datos_Producto_EntradaSalidaMercaderia(EntradaSalidaMercaderiaCuerpoESt(idx).Codigo_Producto, Datos)

                        ReDim ArticulosESt(idx)
                        ArticulosESt(idx).Id_Producto = Datos.Rows(0).Item("Id_Producto").ToString()
                        ArticulosESt(idx).Id_Rubro = Datos.Rows(0).Item("Id_Rubro").ToString()
                        ArticulosESt(idx).Codigo_Barras = Datos.Rows(0).Item("Codigo_Barras").ToString()
                        ArticulosESt(idx).Descripcion = Datos.Rows(0).Item("Descripcion").ToString()
                        ArticulosESt(idx).Id_Proveedor = Datos.Rows(0).Item("Id_Proveedor").ToString()
                        ArticulosESt(idx).Id_Tasa_IVA = Datos.Rows(0).Item("Id_Tasa_IVA").ToString()
                        ArticulosESt(idx).Stock_Minimo = Datos.Rows(0).Item("Stock_Minimo").ToString()

                        If chbActualizarStockArticulos.Checked = True Then
                            ArticulosESt(idx).Stock = Convert.ToString(Convert.ToDouble(Datos.Rows(0).Item("Stock") - Convert.ToDouble(EntradaSalidaMercaderiaCuerpoESt(idx).CantidadUnidades)))
                        Else
                            ArticulosESt(idx).Stock = Convert.ToString(Convert.ToDouble(EntradaSalidaMercaderiaCuerpoESt(idx).CantidadUnidades) * -1)
                        End If
                        ArticulosESt(idx).Pesable = Datos.Rows(0).Item("Pesable").ToString()
                        ArticulosESt(idx).Tipo_Unidad = Datos.Rows(0).Item("Tipo_Unidad").ToString()
                        ArticulosESt(idx).Cantidad_Unid_Caja = Datos.Rows(0).Item("Cantidad_Unid_Caja").ToString()
                        ArticulosESt(idx).Peso_Unidad = Datos.Rows(0).Item("Peso_Unidad").ToString()
                        ArticulosESt(idx).INHABILITAR = Datos.Rows(0).Item("INHABILITAR")
                        ArticulosESt(idx).CodProdProveedor = Datos.Rows(0).Item("Cod_Prod_Proveedor").ToString()

                        querybuilder.obtener_estructura(dfielddefConstantes.Producto.ToString(), esquema)
                        Articulos.Obtener_Clave_Principal(ClavePrincipal)
                        Articulos.Pasar_A_Coleccion(ArticulosESt, DatosEst, idx)
                        querybuilder.ArmaUpdate(dfielddefConstantes.Producto.ToString(), esquema, DatosEst, ClavePrincipal, consulta)
                        tran.Add(consulta)

                        idx = idx + 1
                        jdx = jdx + 1
                        consulta = ""
                        esquema.Clear()
                        ClavePrincipal.Clear()
                        DatosEst.Clear()
                    End If
                Next
                MessageBox.Show("La Salida de Mercaderia se ha realizado, Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                            MessageBoxIcon.Information)
            End If
            Transaccion.Operaciones_Tabla_Transaccion(tran)
            tran.Clear()
            Limpiar_Estructuras()
            tbDescripcion.Text = String.Empty
            dgvEntradaMercaderia.Rows.Clear()
            If dgvEntradaMercaderia.Rows.Count = 0 Then
                agregarFilaInicial()
            End If
        End If
    End Sub

    Private Sub EliminarFila()
        dgvEntradaMercaderia.Rows.Remove(dgvEntradaMercaderia.CurrentRow)
    End Sub

    Private Sub dgvEntradaMercaderia_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntradaMercaderia.CellContentClick
        Dim filaseleccionada As Integer
        Dim colseleccionada As Integer
        Try
            filaseleccionada = Convert.ToInt32(dgvEntradaMercaderia.CurrentRow.Index.ToString())
            Dim result As Integer = MessageBox.Show("Desea Eliminar el Articulo: " + CStr(dgvEntradaMercaderia.Rows(filaseleccionada).Cells(enumerado.ColumnaDescripcionArt).Value), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.Yes Then
                If dgvEntradaMercaderia.Rows.Count > 0 Then
                    dgvEntradaMercaderia.Rows.RemoveAt(filaseleccionada)
                End If
            End If
            If dgvEntradaMercaderia.Rows.Count = 0 Then
                agregarFilaInicial()
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub agregarFilaInicial()
        dgvEntradaMercaderia.Rows.Add()
    End Sub

    Private Sub dgvEntradaMercaderia_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvEntradaMercaderia.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub
    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvEntradaMercaderia.CurrentCell.ColumnIndex
        Dim fila As Integer = dgvEntradaMercaderia.CurrentRow.Index.ToString()
        Dim importe As Double
        Dim cantidad As Double
        Dim valorAct As Double
        Try
            If columna = enumerado.ColumnaCodArticulo Then 'validoEnteros
                ' Obtener caracter  
                Dim caracter As Char = e.KeyChar
                ' comprobar si el caracter es un número o el retroceso  
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    'Me.Text = e.KeyChar  
                    e.KeyChar = Chr(0)
                End If
            ElseIf columna = enumerado.ColumnaUnidKilos Then
                Dim caracter As Char = e.KeyChar
                Dim txt As TextBox = CType(sender, TextBox)
                ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
                ' es el separador decimal, y que no contiene ya el separador  
                If (Char.IsNumber(caracter)) Or _
                   (caracter = ChrW(Keys.Back)) Or _
                   (caracter = ",") And _
                   (txt.Text.Contains(",") = False) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvEntradaMercaderia_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEntradaMercaderia.CellValueChanged
        Dim importe As Double
        Dim cantidad As Double
        Dim valorAct As Double
        Dim CodigoP As Integer
        Dim DescripcionArt As String
        Try
            If (Not IsNothing(dgvEntradaMercaderia.CurrentCell)) Then
                Dim fila As Integer = dgvEntradaMercaderia.CurrentRow.Index.ToString()
                Dim columna As Integer = dgvEntradaMercaderia.CurrentCell.ColumnIndex
                If columna = enumerado.ColumnaCodArticulo Or columna = enumerado.ColumnaCodBarras Then
                    If Not IsNothing(Me.dgvEntradaMercaderia.Item(columna, fila).Value) Then
                        caracteres = Me.dgvEntradaMercaderia.Item(columna, fila).Value.ToString()
                        CodigoP = Convert.ToInt32(caracteres)
                    Else
                        CodigoP = 0
                    End If
                    completar(CodigoP, fila, columna)
                ElseIf columna = enumerado.ColumnaDescripcionArt Then
                    If Not IsNothing(Me.dgvEntradaMercaderia.Item(columna, fila).Value) Then
                        caracteres = Me.dgvEntradaMercaderia.Item(columna, fila).Value.ToString()
                        DescripcionArt = Convert.ToString(caracteres)
                    Else
                        DescripcionArt = 0
                    End If
                    completar_Texto(DescripcionArt, fila, columna)
                ElseIf columna = enumerado.ColumnaUnidKilos Then 'validoEnteros
                    If Not IsNothing(Me.dgvEntradaMercaderia.Item(columna, fila).Value) Then
                        caracteres = Me.dgvEntradaMercaderia.Item(columna, fila).Value.ToString()
                        valorAct = Convert.ToDouble(caracteres)
                    Else
                        valorAct = 0
                    End If
                ElseIf dgvEntradaMercaderia.Rows.Count = 0 Then
                    agregarFilaInicial()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub completar(ByVal CodigoP As Integer, ByVal fila As Integer, ByVal columna As Integer)
        Dim consulta As String
        Dim articulo As New Controlador.Articulos
        Dim datos As New DataTable
        Dim Proveedor As New Controlador.ContProveedor
        Dim Numero_Condicion_IVA_Proveedor As Integer
        Dim Empresa As New Controlador.Empresas
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim FacturacionProveedor As New Controlador.FacturacionProveedor
        Dim tipoComprobante As String
        Dim ObtenerTasa As Double
        Try

            'consulta = " select P.Id_Tasa_IVA, P.Tipo_Unidad,P.Id_Producto,P.Codigo_Barras ,P.Descripcion,P.Cod_Prod_Proveedor " & vbCrLf
            'consulta += " from(Producto as P" & vbCrLf
            'consulta += " inner join EmpresaArticulo as EA on EA.Id_Articulo=P.Id_Producto )" & vbCrLf
            'consulta += " where(P.INHABILITAR = False)" & vbCrLf
            'consulta += " and ((P.Id_Producto ='" + Convert.ToString(CodigoP) + "'))  " & vbCrLf
            'consulta += " and EA.Id_Empresa='" + DatosEmpresa(0).Item("Id_Empresa") + "'  "

            articulo.recuperar_Datos_Producto_EmpresaArticulo(Convert.ToString(CodigoP), DatosEmpresa(0).Item("Id_Empresa"), datos)
            If datos.Rows.Count > 0 Then
                dgvEntradaMercaderia.Item(enumerado.columnaTipoUnidad, fila).Value = datos.Rows(0).Item("Tipo_Unidad")
                dgvEntradaMercaderia.Item(enumerado.ColumnaCodArticulo, fila).Value = datos.Rows(0).Item("Id_Producto")
                dgvEntradaMercaderia.Item(enumerado.ColumnaDescripcionArt, fila).Value = datos.Rows(0).Item("Descripcion")
                dgvEntradaMercaderia.Item(enumerado.ColumnaUnidKilos, fila).Value = "0"
                dgvEntradaMercaderia.Item(enumerado.ColumnaCodBarras, fila).Value = datos.Rows(0).Item("Codigo_Barras")

            Else
                'articulo.CompId_Proveedor = Convert.ToInt32(txtCodigoProveedor.Text.Trim())
                articulo.Compvariable_Articulo = dfielddefConstantes.EntradaSalidaMercaderias.ToString()
                articulo.CompFila = fila
                Dim frmAP = New Vista.ArticulosProveedor()
                frmAP.ShowDialog()
                dgvEntradaMercaderia.EndEdit()
                If articulo.CompId_Articulo <> "" Then
                    Me.dgvEntradaMercaderia.CurrentCell = Me.dgvEntradaMercaderia(enumerado.ColumnaCodArticulo, fila)
                    dgvEntradaMercaderia.Item(enumerado.ColumnaCodArticulo, fila).Value = articulo.CompId_Articulo
                Else
                    If dgvEntradaMercaderia.Rows.Count > 0 Then
                        EliminarFila()
                    End If
                    If dgvEntradaMercaderia.Rows.Count = 0 Then
                        agregarFilaInicial()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub completar_Texto(ByVal DescripcionArticulo As String, ByVal fila As Integer, ByVal columna As Integer)
        Dim consulta As String
        Dim articulo As New Controlador.Articulos
        Dim datos As New DataTable
        Dim Proveedor As New Controlador.ContProveedor
        Dim Numero_Condicion_IVA_Proveedor As Integer
        Dim Empresa As New Controlador.Empresas
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim FacturacionProveedor As New Controlador.FacturacionProveedor
        Dim tipoComprobante As String
        Dim ObtenerTasa As Double
        Try
            'consulta = "   select P.Id_Tasa_IVA,P.Tipo_Unidad,P.Id_Producto,P.Descripcion,P.Codigo_Barras ,P.Cod_Prod_Proveedor " & vbCrLf
            'consulta += "  from (producto as P" & vbCrLf
            'consulta += "  inner join EmpresaArticulo as EA on EA.Id_Articulo=P.Id_Producto )" & vbCrLf
            'consulta += "  where(P.INHABILITAR = False)" & vbCrLf
            'consulta += "  and P.Descripcion = '" + (DescripcionArticulo) + "'" & vbCrLf
            'consulta += "  and EA.Id_Empresa='" + DatosEmpresa(0).Item("Id_Empresa") + "' " & vbCrLf
            articulo.recuperar_Datos_Producto_EmpresaArticulo_Descripcion(DescripcionArticulo, DatosEmpresa(0).Item("Id_Empresa"), datos)
            If datos.Rows.Count > 0 Then
                dgvEntradaMercaderia.Item(enumerado.columnaTipoUnidad, fila).Value = datos.Rows(0).Item("Tipo_Unidad")
                dgvEntradaMercaderia.Item(enumerado.ColumnaCodArticulo, fila).Value = datos.Rows(0).Item("Id_Producto")
                dgvEntradaMercaderia.Item(enumerado.ColumnaDescripcionArt, fila).Value = datos.Rows(0).Item("Descripcion")
                dgvEntradaMercaderia.Item(enumerado.ColumnaUnidKilos, fila).Value = "0"
                dgvEntradaMercaderia.Item(enumerado.ColumnaCodBarras, fila).Value = datos.Rows(0).Item("Codigo_Barras")
            Else
                'articulo.CompId_Proveedor = Convert.ToInt32(txtCodigoProveedor.Text.Trim())
                articulo.CompFila = fila
                Dim frmAP = New Vista.ArticulosProveedor()
                frmAP.ShowDialog()
                dgvEntradaMercaderia.EndEdit()
                If articulo.CompDescripcion <> "" Then
                    dgvEntradaMercaderia.Item(enumerado.ColumnaDescripcionArt, fila).Value = articulo.CompDescripcion
                    DescripcionArticulo = articulo.CompDescripcion
                Else
                    If dgvEntradaMercaderia.Rows.Count > 0 Then
                        EliminarFila()
                    End If
                    If dgvEntradaMercaderia.Rows.Count = 0 Then
                        agregarFilaInicial()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvEntradaMercaderia_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEntradaMercaderia.KeyDown
        agregarNuevaFila(e)
    End Sub
    Private Sub agregarNuevaFila(ByVal e As System.Windows.Forms.KeyEventArgs)
        If dgvEntradaMercaderia.Rows.Count > 0 Then
            Dim columna As Integer = dgvEntradaMercaderia.CurrentCell.ColumnIndex
            If columna > 3 And e.KeyCode = Keys.Enter Then
                dgvEntradaMercaderia.Rows.Add()
                dgvEntradaMercaderia.CurrentCell = dgvEntradaMercaderia.Rows(dgvEntradaMercaderia.CurrentRow.Index).Cells("CodArticulo")
            End If
        End If
    End Sub
    Public Sub New()
        Dim consulta As String
        Dim Empresa As New Empresas()
        Dim Configuracion As New Controlador.Configuracion
        'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
        Empresa.Obtener_Empresa(Empresa.Compvariable, DatosEmpresa)
        'consulta = "Select * from Configuracion"
        Configuracion.Obtener_Datos_Configuracion(Datos_Configuracion)
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        If dgvEntradaMercaderia.Rows.Count = 0 Then
            agregarFilaInicial()
        End If
        mtFecha.Text = Date.Now
        chbActualizarStockArticulos.Checked = True

    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub mtFecha_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mtFecha.Validated
        Try
            Select Case (IsDate(mtFecha.Text))
                Case False
                    MessageBox.Show("La fecha " + mtFecha.Text + " , no tiene un formato Correcto!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    mtFecha.Text = ""
                    mtFecha.Focus()
            End Select
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub chbActualizarStockArticulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbActualizarStockArticulos.CheckedChanged
        If chbActualizarStockArticulos.Checked = True Then
            chbInicializarStock.Checked = False
        End If
    End Sub

    Private Sub Limpiar_Estructuras()
        ReDim ArticulosESt(0)
        ReDim EntradaSalidaMercaderiaCuerpoESt(0)
        ReDim EntradaSalidaMercEncESt(0)

    End Sub
End Class