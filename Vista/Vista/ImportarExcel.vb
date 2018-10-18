Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class ImportarExcel
    Dim dfielddefCliente As Controlador.DfieldDef.eCliente
    Dim dfielddfConstantes As Controlador.DfieldDef.eConstantes
    Dim entCliente() As Controlador.Cliente.eCliente
    Dim entArticulos() As Controlador.Articulos.eArticulo
    Dim entArticulosListaPrecio() As Controlador.Articulos.eArticuloCuerpoDocumento
    Dim _Generales As New Controlador.Generales
    Dim Cliente As New Controlador.Cliente
    Dim Articulo As New Controlador.Articulos
    Dim ArticuloListaPrecio As New Controlador.Lista_Precios
    Private Sub ToolStripButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSalir.Click
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub ToolStripButtonExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonExportarExcel.Click
        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim rng2 As Excel.Range
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Archivos de Microsoft Office Excel (*.xls)|*.xls|Excel 2010|*.xlsx"
        saveFileDialog1.Title = "Save an Image File"
        saveFileDialog1.ShowDialog()
        ' If the file name is not an empty string open it for saving.
        If saveFileDialog1.FileName <> "" Then
            ' Saves the Image via a FileStream created by the OpenFile method.


            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add
            'Agregar datos a las celdas de la primera hoja en el libro nuevo
            oSheet = oBook.Worksheets(1)
            oSheet.Name = StrConv(_Generales.Compvariable, VbStrConv.ProperCase)
            ' Agregamos Los datos que queremos agregar
            If _Generales.Compvariable = dfielddfConstantes.cliente.ToString() Then
                oSheet.Range("A1").Value = "ID CLIENTE"
                oSheet.Range("B1").Value = "NOMBRE"
                oSheet.Range("C1").Value = "APELLIDO"
                oSheet.Range("D1").Value = "CALLE"
                oSheet.Range("E1").Value = "PISO"
                oSheet.Range("F1").Value = "NRO"
                oSheet.Range("G1").Value = "SALDO C/C"
                oSheet.Range("H1").Value = "CUIT"
                oSheet.Range("I1").Value = "PROVINCIA"
                oSheet.Range("J1").Value = "TELEFONO"
                oSheet.Range("K1").Value = "CELULAR"
                oSheet.Range("L1").Value = "E-MAIL"
                oSheet.Range("M1").Value = "CODIGO POSTAL"
                oSheet.Range("N1").Value = "RESPONSABILIDAD IVA"
                oSheet.Range("O1").Value = "LOCALIDAD"

                rng2 = oSheet.Range("A1:O1")
            ElseIf _Generales.Compvariable = dfielddfConstantes.Producto.ToString() Then
                oSheet.Range("A1").Value = "ID PRODUCTO"
                oSheet.Range("B1").Value = "ID RUBRO"
                oSheet.Range("C1").Value = "CODIGO BARRAS"
                oSheet.Range("D1").Value = "DESCRIPCION"
                oSheet.Range("E1").Value = "ID PROVEEDOR"
                oSheet.Range("F1").Value = "ID TASA IVA"
                oSheet.Range("G1").Value = "TASA IVA"
                oSheet.Range("H1").Value = "STOCK MINIMO"
                oSheet.Range("I1").Value = "STOCK"
                oSheet.Range("J1").Value = "PESABLE"
                oSheet.Range("K1").Value = "TIPO UNIDAD"
                oSheet.Range("L1").Value = "CANTIDAD UNID CAJA"
                oSheet.Range("M1").Value = "PESO UNIDAD"
                oSheet.Range("N1").Value = "CODIGO PROVEEDOR"
                rng2 = oSheet.Range("A1:N1")

            ElseIf _Generales.Compvariable = dfielddfConstantes.Producto_Lista_Precio.ToString() Then
                oSheet.Range("A1").Value = "ID LISTA PRECIO"
                oSheet.Range("B1").Value = "ID PRODUCTO"
                oSheet.Range("C1").Value = "DESCRIPCION LISTA PRECIO"
                oSheet.Range("D1").Value = "PRECIO COSTO"
                oSheet.Range("E1").Value = "RENTABILIDAD"
                oSheet.Range("F1").Value = "PRECIO VENTA"
                oSheet.Range("G1").Value = "PRECIO KILO"
                rng2 = oSheet.Range("A1:G1")
            End If

            rng2.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Coral)
            rng2.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            rng2.Font.Bold = True
            oExcel.Visible = True
            oExcel.UserControl = True
            'oExcel.ActiveWorkbook.Save()

            'Dim fs As System.IO.FileStream = CType _
            '              (saveFileDialog1.OpenFile(), System.IO.FileStream)
            oBook.SaveAs(saveFileDialog1.FileName)
        End If
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Dim openFileDialog1 As New OpenFileDialog
        Dim valido As Boolean
        'Directorio Predeterminado
        openFileDialog1.InitialDirectory = "C:\"
        'Filtramos solo archivos con extension *.xls
        openFileDialog1.Filter = "Archivos de Microsoft Office Excel (*.xls)|*.xls|Excel 2010|*.xlsx"
        'Si se presiona abrir entonces...
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Asignamos la ruta donde se almacena el fichero excel que se va a importar
            txtRutaXLS.Text = openFileDialog1.FileName
            'Instanciamos nuestra cadena de conexion especial para excel,indicando la ruta del fichero
            Dim cadconex As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Me.txtRutaXLS.Text.Trim & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=1"""
            Dim cn As New OleDb.OleDbConnection(cadconex)
            Dim cmd As New OleDbCommand
            Dim da As New OleDb.OleDbDataAdapter
            Dim dt As New DataTable
            cmd.Connection = cn
            'Consultamos la hoja llamada Clientes de nuestro archivo *.xls
            Dim nombreHoja As String = ObtenerNombrePrimeraHoja(txtRutaXLS.Text)
            nombreHoja = StrConv(nombreHoja, VbStrConv.ProperCase)
            If nombreHoja = StrConv(_Generales.Compvariable, VbStrConv.ProperCase) Then '"Cliente"
                cmd.CommandText = String.Format("SELECT * FROM [{0}$]", nombreHoja)
                cmd.CommandType = CommandType.Text
                da.SelectCommand = cmd
                'Llenamos el datatable
                da.Fill(dt)
                'Llenamos el Datagridview
                If dt.Rows.Count > 0 Then
                    dgvImportacion.DataSource = dt
                    'Ajustamos las columnas del DataGridView
                    dgvImportacion.AutoSizeColumnsMode = 6
                End If
            Else
                MessageBox.Show("El Nombre de la Hoja del Archivo Excel, debe Ser. '" + StrConv(_Generales.Compvariable, VbStrConv.ProperCase) + "' ,Verifiquelo. Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Function ObtenerNombrePrimeraHoja(ByVal rutaLibro As String) As String
        Dim app As Excel.Application = Nothing
        Try
            app = New Excel.Application()
            Dim wb As Excel.Workbook = app.Workbooks.Open(rutaLibro)
            Dim ws As Excel.Worksheet = CType(wb.Worksheets.Item(1), Excel.Worksheet)
            Dim name As String = ws.Name
            ws = Nothing
            wb.Close()
            wb = Nothing
            Return name
        Catch ex As Exception
            Throw
        Finally
            If (Not app Is Nothing) Then _
                app.Quit()
            Runtime.InteropServices.Marshal.ReleaseComObject(app)
            app = Nothing
        End Try
    End Function
    Private Sub ToolStripButtonImportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonImportarExcel.Click
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim ultimo As Integer
        Dim idx As Integer
        Dim existe As Boolean
        Dim valido As Boolean
        Dim Cliente As New Controlador.Cliente
        Dim Articulo As New Controlador.Articulos
        Try
            For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
                ToolStripProgressBar.Value = x
            Next
            For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
                ToolStripProgressBar.Value = x
            Next
            If dgvImportacion.Rows.Count > 0 Then
                idx = 1

                For index As Integer = 0 To dgvImportacion.Rows.Count - 1
                    esquema.Clear()
                    datos.Clear()
                    ClavePrincipal.Clear()
                    If _Generales.Compvariable = dfielddfConstantes.cliente.ToString Then

                        ReDim Preserve entCliente(idx)
                        If (Me.dgvImportacion.Item(0, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Convert.ToInt32(Me.dgvImportacion.Item(0, index).Value())) Then
                                entCliente(idx).Id_Cliente = Convert.ToInt32(Me.dgvImportacion.Item(0, index).Value())
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en ID CLIENTE.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en ID CLIENTE.")
                        End If
                        If (Me.dgvImportacion.Item(1, index).Value().ToString() <> String.Empty) Then
                            entCliente(idx).Nombre = Me.dgvImportacion.Item(1, index).Value().ToString()
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en NOMBRE.")
                        End If
                        If (Me.dgvImportacion.Item(2, index).Value().ToString() <> String.Empty) Then
                            entCliente(idx).Apellido = Me.dgvImportacion.Item(2, index).Value().ToString()
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en APELLIDO.")
                        End If
                        If (Me.dgvImportacion.Item(3, index).Value().ToString() <> String.Empty) Then
                            entCliente(idx).Calle = Me.dgvImportacion.Item(3, index).Value().ToString()
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en CALLE.")
                        End If
                        entCliente(idx).Piso = Me.dgvImportacion.Item(4, index).Value().ToString()

                        If (Me.dgvImportacion.Item(5, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Me.dgvImportacion.Item(5, index).Value().ToString()) Then
                                entCliente(idx).Nro = Me.dgvImportacion.Item(5, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en Numero.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en Numero.")
                        End If

                        If (Me.dgvImportacion.Item(6, index).Value().ToString() <> String.Empty) Then

                            If Cliente.validateDoublesAndCurrency_Cliente(Me.dgvImportacion.Item(6, index).Value().ToString()) Then
                                entCliente(idx).Saldo_CC = Me.dgvImportacion.Item(6, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en Saldo C/C.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en Saldo C/C.")
                        End If
                        If (Me.dgvImportacion.Item(7, index).Value().ToString() <> String.Empty) Then
                            If (Len(Me.dgvImportacion.Item(7, index).Value().ToString()) > 10) And (Len(Me.dgvImportacion.Item(7, index).Value().ToString()) < 13) Then

                                If (Len(Me.dgvImportacion.Item(7, index).Value().ToString()) = 11) Then
                                    entCliente(idx).CUIT = Me.dgvImportacion.Item(7, index).Value().ToString().Substring(0, 2) + "-" + Me.dgvImportacion.Item(7, index).Value().ToString().Substring(2, 8) + "-" + Me.dgvImportacion.Item(7, index).Value().ToString().Substring(10, 1)
                                Else
                                    entCliente(idx).CUIT = Me.dgvImportacion.Item(7, index).Value().ToString()
                                End If
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en CUIT.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en CUIT.")
                        End If
                        entCliente(idx).Provincia = Me.dgvImportacion.Item(8, index).Value().ToString()
                        If (Me.dgvImportacion.Item(9, index).Value().ToString() <> String.Empty) Then
                            entCliente(idx).Telefono = Me.dgvImportacion.Item(9, index).Value().ToString()
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en TELEFONO.")
                        End If
                        entCliente(idx).Celular = Me.dgvImportacion.Item(10, index).Value().ToString()
                        entCliente(idx).E_Mail = Me.dgvImportacion.Item(11, index).Value().ToString()
                        If IsNumeric(Me.dgvImportacion.Item(12, index).Value().ToString()) And (Len(Me.dgvImportacion.Item(12, index).Value().ToString()) = 4) Then
                            entCliente(idx).Codigo_Postal = Me.dgvImportacion.Item(12, index).Value().ToString()
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en CODIGO POSTAL.")
                        End If
                        If (Me.dgvImportacion.Item(13, index).Value().ToString() <> String.Empty) Then
                            entCliente(idx).Responsabilidad_IVA = Me.dgvImportacion.Item(13, index).Value().ToString()
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en RESPONSABILIDAD IVA.")
                        End If
                        entCliente(idx).Localidad = Me.dgvImportacion.Item(14, index).Value().ToString()
                        entCliente(idx).INHABILITAR = "False"
                        querybuilder.obtener_estructura(dfielddfConstantes.cliente.ToString(), esquema)
                        Cliente.Obtener_Clave_Principal(ClavePrincipal)
                        Cliente.Pasar_A_Coleccion(entCliente, datos, idx)
                        'consulta = "Select * from " + dfielddfConstantes.cliente.ToString() + " where Id_Cliente=" & Convert.ToInt32(entCliente(idx).Id_Cliente) & ""
                        Cliente.Validar_Cliente(Convert.ToInt32(entCliente(idx).Id_Cliente), existe)
                        If existe Then
                            querybuilder.ArmaUpdate(dfielddfConstantes.cliente.ToString(), esquema, datos, ClavePrincipal, consulta)
                        Else
                            querybuilder.ArmaInsert(dfielddfConstantes.cliente.ToString(), esquema, datos, ClavePrincipal, consulta)
                        End If
                        Cliente.Operaciones_Tabla(consulta)
                        idx = idx + 1
                    ElseIf _Generales.Compvariable = dfielddfConstantes.Producto.ToString Then
                        ReDim Preserve entArticulos(idx)
                        If (Me.dgvImportacion.Item(0, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Me.dgvImportacion.Item(0, index).Value()) Then
                                entArticulos(idx).Id_Producto = Convert.ToInt32(Me.dgvImportacion.Item(0, index).Value())
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en ID PRODUCTO.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en ID PRODUCTO.")
                        End If

                        If (Me.dgvImportacion.Item(1, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Me.dgvImportacion.Item(1, index).Value().ToString()) Then
                                entArticulos(idx).Id_Rubro = Me.dgvImportacion.Item(1, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en ID RUBRO.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en ID RUBRO.")
                        End If
                        entArticulos(idx).Codigo_Barras = Me.dgvImportacion.Item(2, index).Value().ToString()

                        If (Me.dgvImportacion.Item(3, index).Value().ToString() <> String.Empty) Then
                            entArticulos(idx).Descripcion = Me.dgvImportacion.Item(3, index).Value().ToString()
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en DESCRIPCION.")
                        End If
                        If (Me.dgvImportacion.Item(4, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Me.dgvImportacion.Item(4, index).Value().ToString()) Then
                                entArticulos(idx).Id_Proveedor = Me.dgvImportacion.Item(4, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en ID PROVEEDOR.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en ID PROVEEDOR.")
                        End If
                        If (Me.dgvImportacion.Item(5, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Me.dgvImportacion.Item(5, index).Value().ToString()) Then
                                entArticulos(idx).Id_Tasa_IVA = Me.dgvImportacion.Item(5, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en ID TASA IVA.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en ID TASA IVA.")
                        End If

                        If (Me.dgvImportacion.Item(6, index).Value().ToString() <> String.Empty) Then
                            If Articulo.validateDoublesAndCurrency_Articulo(Me.dgvImportacion.Item(6, index).Value().ToString()) Then
                                entArticulos(idx).Tasa_IVA = Me.dgvImportacion.Item(6, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en TASA IVA.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en TASA IVA.")
                        End If
                        If (Me.dgvImportacion.Item(7, index).Value().ToString() <> String.Empty) Then
                            If Articulo.validateDoublesAndCurrency_Articulo(Me.dgvImportacion.Item(7, index).Value().ToString()) Then
                                entArticulos(idx).Stock_Minimo = Me.dgvImportacion.Item(7, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en STOCK MINIMO.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en STOCK MINIMO.")
                        End If
                        If (Me.dgvImportacion.Item(8, index).Value().ToString() <> String.Empty) Then
                            If Articulo.validateDoublesAndCurrency_Articulo(Me.dgvImportacion.Item(8, index).Value().ToString()) Then
                                entArticulos(idx).Stock = Me.dgvImportacion.Item(8, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en STOCK.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en STOCK.")
                        End If
                        If (Me.dgvImportacion.Item(9, index).Value().ToString() <> String.Empty) Then
                            If (Me.dgvImportacion.Item(9, index).Value().ToString().ToUpper() = "SI") Or (Me.dgvImportacion.Item(9, index).Value().ToString().ToUpper() = "NO") Then
                                entArticulos(idx).Pesable = Me.dgvImportacion.Item(9, index).Value().ToString().ToUpper()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en PESABLE.Debe Completarse con SI o NO .")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en PESABLE.")
                        End If
                        If (Me.dgvImportacion.Item(10, index).Value().ToString() <> String.Empty) Then
                            If (Me.dgvImportacion.Item(10, index).Value().ToString().ToUpper() = "KGS") Or (Me.dgvImportacion.Item(10, index).Value().ToString().ToUpper() = "CAJA") Or (Me.dgvImportacion.Item(10, index).Value().ToString().ToUpper() = "LTS") Or (Me.dgvImportacion.Item(10, index).Value().ToString().ToUpper() = "UN") Then
                                entArticulos(idx).Tipo_Unidad = Me.dgvImportacion.Item(10, index).Value().ToString().ToUpper()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en TIPO UNIDAD. Debe Completarse con KGS, CAJA, LTS o UN")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en TIPO UNIDAD.")
                        End If
                        If (Me.dgvImportacion.Item(11, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Me.dgvImportacion.Item(11, index).Value().ToString()) Then
                                entArticulos(idx).Cantidad_Unid_Caja = Me.dgvImportacion.Item(11, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en CANTIDAD UNID CAJA.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en CANTIDAD UNID CAJA.")
                        End If

                        If (Me.dgvImportacion.Item(12, index).Value().ToString() <> String.Empty) Then
                            If Articulo.validateDoublesAndCurrency_Articulo(Me.dgvImportacion.Item(12, index).Value().ToString()) Then
                                entArticulos(idx).Peso_Unidad = Me.dgvImportacion.Item(12, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en PESO UNIDAD.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en PESO UNIDAD.")
                        End If
                        entArticulos(idx).INHABILITAR = "FALSE"
                        If (Me.dgvImportacion.Item(13, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Me.dgvImportacion.Item(13, index).Value().ToString()) Then
                                entArticulos(idx).CodProdProveedor = Me.dgvImportacion.Item(13, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en CODIGO PROVEEDOR.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en CODIGO PROVEEDOR.")
                        End If
                        querybuilder.obtener_estructura(dfielddfConstantes.Producto.ToString(), esquema)
                        Articulo.Obtener_Clave_Principal(ClavePrincipal)
                        Articulo.Pasar_A_Coleccion(entArticulos, datos, idx)
                        'consulta = "Select * from " + dfielddfConstantes.Producto.ToString() + " where Id_Producto='" & (entArticulos(idx).Id_Producto) & "'"
                        Articulo.se_Cargo(entArticulos(idx).Id_Producto, existe)
                        If existe Then
                            querybuilder.ArmaUpdate(dfielddfConstantes.Producto.ToString(), esquema, datos, ClavePrincipal, consulta)
                        Else
                            querybuilder.ArmaInsert(dfielddfConstantes.Producto.ToString(), esquema, datos, ClavePrincipal, consulta)
                        End If
                        Articulo.Operaciones_QueryBuilder(consulta)
                        idx = idx + 1
                    ElseIf _Generales.Compvariable = dfielddfConstantes.Producto_Lista_Precio.ToString Then
                        ReDim Preserve entArticulosListaPrecio(idx)
                        If (Me.dgvImportacion.Item(0, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Me.dgvImportacion.Item(0, index).Value()) Then
                                entArticulosListaPrecio(idx).IdListaPrecio = Convert.ToInt32(Me.dgvImportacion.Item(0, index).Value())
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en ID LISTA PRECIO.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en ID LISTA PRECIO.")
                        End If
                        If (Me.dgvImportacion.Item(1, index).Value().ToString() <> String.Empty) Then
                            If IsNumeric(Me.dgvImportacion.Item(1, index).Value().ToString()) Then
                                entArticulosListaPrecio(idx).IdProducto = Me.dgvImportacion.Item(1, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en ID PRODUCTO.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en ID PRODUCTO.")
                        End If
                        If (Me.dgvImportacion.Item(2, index).Value().ToString() <> String.Empty) Then
                            entArticulosListaPrecio(idx).DescListaPrecio = Me.dgvImportacion.Item(2, index).Value().ToString()
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en DESCRIPCION LISTA PRECIO.")
                        End If

                        If (Me.dgvImportacion.Item(3, index).Value().ToString() <> String.Empty) Then
                            If Articulo.validateDoublesAndCurrency_Articulo(Me.dgvImportacion.Item(3, index).Value().ToString()) Then
                                entArticulosListaPrecio(idx).PrecioCosto = Me.dgvImportacion.Item(3, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en PRECIO COSTO.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en PRECIO COSTO.")
                        End If
                        If (Me.dgvImportacion.Item(4, index).Value().ToString() <> String.Empty) Then
                            If Articulo.validateDoublesAndCurrency_Articulo(Me.dgvImportacion.Item(4, index).Value().ToString()) Then
                                entArticulosListaPrecio(idx).Rentabilidad = Me.dgvImportacion.Item(4, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en RENTABILIDAD.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en RENTABILIDAD.")
                        End If

                        If (Me.dgvImportacion.Item(5, index).Value().ToString() <> String.Empty) Then
                            If Articulo.validateDoublesAndCurrency_Articulo(Me.dgvImportacion.Item(5, index).Value().ToString()) Then
                                entArticulosListaPrecio(idx).PrecioVenta = Me.dgvImportacion.Item(5, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en PRECIO VENTA.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en PRECIO VENTA.")
                        End If

                        If (Me.dgvImportacion.Item(6, index).Value().ToString() <> String.Empty) Then
                            If Articulo.validateDoublesAndCurrency_Articulo(Me.dgvImportacion.Item(6, index).Value().ToString()) Then
                                entArticulosListaPrecio(idx).PrecioKilo = Me.dgvImportacion.Item(6, index).Value().ToString()
                            Else
                                pintarFilas(dgvImportacion, index)
                                Throw New System.Exception("en PRECIO KILO.")
                            End If
                        Else
                            pintarFilas(dgvImportacion, index)
                            Throw New System.Exception("en PRECIO KILO.")
                        End If
                        querybuilder.obtener_estructura(dfielddfConstantes.Producto_Lista_Precio.ToString(), esquema)
                        Articulo.Obtener_Clave_PrincipalListaPrecio(ClavePrincipal)
                        Articulo.Pasar_A_ColeccionArticuloListaPrecio(entArticulosListaPrecio, datos, idx)
                        'consulta = "Select * from " + dfielddfConstantes.Producto_Lista_Precio.ToString() + " where Id_Lista_Precio='" & (entArticulosListaPrecio(idx).Id_Lista_Precio) & "' and Id_Producto='" & (entArticulosListaPrecio(idx).Id_Producto) & "'"
                        Articulo.se_CargoProducto_Lista_Precio(entArticulosListaPrecio(idx).IdListaPrecio, entArticulosListaPrecio(idx).IdProducto, existe)
                        If existe Then
                            querybuilder.ArmaUpdate(dfielddfConstantes.Producto_Lista_Precio.ToString(), esquema, datos, ClavePrincipal, consulta)
                        Else
                            querybuilder.ArmaInsert(dfielddfConstantes.Producto_Lista_Precio.ToString(), esquema, datos, ClavePrincipal, consulta)
                        End If
                        Articulo.Operaciones_Tabla(consulta)
                        idx = idx + 1
                    End If
                Next
                MessageBox.Show("Los Datos del Archivo Excel, se han Importado Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Information)
                LimpiarEstructuras()
            Else
                MessageBox.Show("No se ha ingresado ningun archivo de Excel para Importar. Ingreselo Por Favor!!!", "Informacion", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim entCliente(0)
        ReDim entArticulos(0)
        ReDim entArticulosListaPrecio(0)
        dgvImportacion.DataSource = Nothing

    End Sub

    Public Sub validar(ByVal dt As DataGridView, ByVal nombreTabla As String, ByRef valido As Boolean)
        Dim i As Integer = 0
        Dim cadena As String = String.Empty

        If (nombreTabla.ToUpper() = dfielddfConstantes.cliente.ToString().ToUpper()) Then
            While (i <= dgvImportacion.Rows.Count)

                If (Len(Me.dgvImportacion.Item(7, i).Value().ToString()) > 10) And (Len(Me.dgvImportacion.Item(7, i).Value().ToString()) < 13) Then

                    If (Len(Me.dgvImportacion.Item(7, i).Value().ToString()) = 11) Then
                        cadena = Me.dgvImportacion.Item(7, i).Value().ToString().Substring(0, 2) + "-" + Me.dgvImportacion.Item(7, i).Value().ToString().Substring(2, 8) + "-" + Me.dgvImportacion.Item(7, i).Value().ToString().Substring(10, 1)


                        Me.dgvImportacion.Item(7, i).Value() = cadena
                    End If
                End If
                i += 1
            End While
        End If
    End Sub

    Private Sub pintarFilas(ByRef grilla As DataGridView, ByVal indice As Integer)
        grilla.Rows(indice).DefaultCellStyle.BackColor = Color.Red
        grilla.Rows(indice).DefaultCellStyle.ForeColor = Color.White
    End Sub

End Class