﻿Imports Controlador
Public Class frmNotaDebitoProveedores
    Dim dfielddefProveedor As Controlador.clsDfieldDef.eProveedor
    Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim dfieldefConfiguracion As Controlador.clsDfieldDef.eConfiguracion
    Dim Responsabilidad_IVA_Empresa As String
    Dim caracteres As String = ""
    Dim eDatos_Configuracion As Controlador.clsConfiguracion.eConfiguracion
    Dim dtDatosEmpresa As New DataTable
    Public eNotaDebitoProveedor_Enc_estructura(0) As Controlador.clsFacturacionProveedor.eEncabezadoFacturaProveedor
    Public eNotaDebitoProveedor_Cuerpo_estructura(0) As Controlador.clsFacturacionProveedor.eCuerpoFacturaProveedor
    Public eArticulos_Estructura(0) As Controlador.clsArticulos.eArticulo
    Dim dfielddefArticuloListaPrecio As Controlador.clsDfieldDef.eArticuloCuerpoDocumento
    Dim dfielddefConfiguracion As Controlador.clsDfieldDef.eConfiguracion
    Dim dfielddefListaPrecio As Controlador.clsDfieldDef.eListaPrecio
    Dim dfielddefCliente As Controlador.clsDfieldDef.eCliente
    Dim dfielddecNumeroComprobantea As Controlador.clsDfieldDef.eNumeroComprobante
    Dim clsEmpresa As New Controlador.clsEmpresas()
    Dim clsProveedor As New Controlador.clsContProveedor()
    Dim clsNotaDebitoProveedor As New Controlador.clsFacturacionProveedor()
    Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante()
    Dim eDatoTipoComprobante As Controlador.clsFacturacionProveedor.eTipoComprobante
    Dim clsConfiguracion As New Controlador.clsConfiguracion
    Dim clsLista_Precio As New Controlador.clsLista_Precios
    Dim clsarticulo As New Controlador.clsArticulos
    Dim clsFacturacionProveedor As New Controlador.clsFacturacionProveedor
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim eNumero_Condicion_IVA_Cliente As Controlador.clsCliente.eCondicion_Frente_Al_Iva
    Dim clsCliente As New Controlador.clsCliente
    Dim clsformaPago As New Controlador.clsFormasDePago

    

    Enum enumerado
        columnaTipoUnidad = 1
        ColumnaCProdProv = 2
        ColumnaCodArticulo = 3
        ColumnaDescripcionArt = 4
        ColumnaUnidKilos = 5
        ColumnaPUnit = 6
        ColumnaImporte = 7
    End Enum
    Private Sub txtCodigoProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoProveedor.TextChanged
        'Dim Proveedor As New Controlador.clsContProveedor()
        'Dim Empresa As New clsEmpresas()
        'Dim NotaDebitoProveedor As New Controlador.clsFacturacionProveedor()
        'Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante()
        Dim consulta As String
        Dim dtdatos As DataTable
        'Dim DatoTipoComprobante As Controlador.clsFacturacionProveedor.eTipoComprobante
        Dim Numero_Condicion_IVA_Proveedor As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim IDComprobante As Integer
        Dim numeroComp As String
        Dim nuComprobante As Integer
        Dim existe As Boolean
        Try
            If Not (clsProveedor.es_Numero(txtCodigoProveedor.Text)) Then
                txtCodigoProveedor.Text = String.Empty
            ElseIf txtCodigoProveedor.Text <> "" Then

                'consulta = "Select * from Proveedor where Id_Proveedor=" & Convert.ToInt32(txtCodigoProveedor.Text) & ""
                clsProveedor.Validar_Proveedor(Convert.ToInt32(txtCodigoProveedor.Text), existe)
                clsProveedor.ObtenerConsulta(Convert.ToInt32(txtCodigoProveedor.Text), dtdatos)
                'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
                clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtDatosEmpresa)
                Responsabilidad_IVA_Empresa = dtDatosEmpresa.Rows(0).Item(dfielddefEmpresa.Responsabilidad_IVA).ToString()
                If existe Then
                    lblCodN.Visible = True
                    clsNotaDebitoProveedor.Limpiar_Datos_Comprobante_Proveedor(dgvNotaDebitoProveedor, txtSubTotal, txtDescuento, txtIVa, txtTotal, txtRazonSocial, txtDireccion, txtCelular, txtTelefono, txtCondIva, txtMail, txtLimiteCC, txtCodigoPostal, lblTipoComprobante, lblIdComprobante)
                    txtRazonSocial.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Razon_Social).ToString()
                    txtDireccion.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Calle).ToString() + " " + dtdatos.Rows(0).Item(dfielddefProveedor.Piso).ToString() + " " + dtdatos.Rows(0).Item(dfielddefProveedor.Nro).ToString()
                    txtCelular.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Celular).ToString()
                    txtTelefono.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Telefono).ToString()
                    txtCondIva.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Responsabilidad_IVA).ToString()
                    txtMail.Text = dtdatos.Rows(0).Item(dfielddefProveedor.E_Mail).ToString()
                    txtLimiteCC.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Saldo_CC).ToString()
                    txtCodigoPostal.Text = dtdatos.Rows(0).Item(dfielddefProveedor.Codigo_Postal).ToString()
                    'consulta = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIva.Text) & "' "
                    clsProveedor.Obtener_CondicionFrenteAIVa(txtCondIva.Text, Numero_Condicion_IVA_Proveedor)
                    ' consulta = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                    clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)

                    'consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                    'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                    'consulta += " inner join ComprobantesProveedor as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                    'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                    'consulta += " and C.IdCondFrenteIvaProveedor='" & (Numero_Condicion_IVA_Proveedor) & "' " & vbCrLf
                    'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                    'consulta += " and TC.IdTipoComprobante in ('2','7','12')"

                    clsNotaDebitoProveedor.Obtener_Datos_Comprobante_Proveedor(Numero_Condicion_IVA_Proveedor, Numero_Condicion_IVA_Empresa, dfielddefConstantes.Nota_De_Debito.ToString(), eDatoTipoComprobante)
                    'tipoComprobante = datos.Rows(0).Item("Descripcion")
                    lblTipoComprobante.Text = eDatoTipoComprobante.Descripcion
                    'IDComprobante = datos.Rows(0).Item("IdTipoComprobante")

                    lblIdComprobante.Text = Convert.ToString(eDatoTipoComprobante.IdTipoComprobante).PadLeft(2, "0")
                    If eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO A" Then ' muestra o no el total iva
                        Label2.Enabled = True
                        txtIVa.Enabled = True
                    Else
                        Label2.Enabled = False
                        txtIVa.Enabled = False
                    End If
                    lblCodN.Visible = True
                    If dgvNotaDebitoProveedor.Rows.Count = 0 Then
                        agregarFilaInicial()
                    End If
                Else
                    MessageBox.Show("El Proveedor seleccionado no ha sido cargado, Ingreselo al Sistema!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                    LimpiarEstructuras()
                    clsNotaDebitoProveedor.Limpiar_Datos_Comprobante_Proveedor(dgvNotaDebitoProveedor, txtSubTotal, txtDescuento, txtIVa, txtTotal, txtRazonSocial, txtDireccion, txtCelular, txtTelefono, txtCondIva, txtMail, txtLimiteCC, txtCodigoPostal, lblTipoComprobante, lblIdComprobante)
                    txtCodigoProveedor.Text = ""
                    lblCodN.Visible = False
                    If dgvNotaDebitoProveedor.Rows.Count = 0 Then
                        agregarFilaInicial()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub FacturacionProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim Empresa As New Controlador.clsEmpresas()
        Dim Consulta As String
        'Dim clsConfiguracion As New Controlador.clsConfiguracion
        'Dim Lista_Precio As New Controlador.clsLista_Precios
        Dim puerto As Integer
        'Dim proveedor As New Controlador.clsContProveedor()
        Try
            mtFecha.Text = Date.Now
            lblCodN.Visible = False
            If txtCodigoProveedor.Text <> "" Then
                lblCodN.Visible = True
            End If
            'Consulta = "Select * from Configuracion"
            clsConfiguracion.Obtener_Datos_Configuracion(eDatos_Configuracion)
            If clsProveedor.CompvariableProveedores = dfielddefConstantes.NotaDebitoProveedor.ToString() Then
                txtCodigoProveedor.Text = clsProveedor.CompCodigo
                clsProveedor.CompCodigo = Nothing
                clsProveedor.CompvariableProveedores = Nothing
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim eNotaDebitoProveedor_Enc_estructura(0)
        'ReDim Numero_Comprobante(0)
        ReDim eNotaDebitoProveedor_Cuerpo_estructura(0)
        ReDim eArticulos_Estructura(0)
    End Sub
    Private Sub ToolStripButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSalir.Click
        For x As Integer = ProgressBarFacturacionProveedor.Minimum To ProgressBarFacturacionProveedor.Maximum
            ProgressBarFacturacionProveedor.Value = x
        Next
        For x As Integer = ProgressBarFacturacionProveedor.Maximum To ProgressBarFacturacionProveedor.Minimum Step -1
            ProgressBarFacturacionProveedor.Value = x
        Next
        Me.Close()
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
    Private Sub btnBuscarProveedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarProveedor.Click
        'Dim Proveedores As New Controlador.clsContProveedor()
        Try
            clsProveedor.CompvariableProveedores = dfielddefConstantes.NotaDebitoProveedor.ToString()
            Me.Hide()
            frmProveedor.Show()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub tbPuntoVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPuntoVenta.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        Try
            If Not (clsProveedor.es_Numero(tbPuntoVenta.Text)) Then
                tbPuntoVenta.Text = String.Empty
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub tbNumeroComprobante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNumeroComprobante.TextChanged
        'Dim clsContProveedor As New Controlador.clsContProveedor
        Try
            If Not (clsProveedor.es_Numero(tbNumeroComprobante.Text)) Then
                tbNumeroComprobante.Text = String.Empty
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvFacturacionProveedor_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvNotaDebitoProveedor.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub
    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvNotaDebitoProveedor.CurrentCell.ColumnIndex
        Dim fila As Integer = dgvNotaDebitoProveedor.CurrentRow.Index.ToString()
        Dim importe As Double
        Dim cantidad As Double
        Dim valorAct As Double
        Try
            If columna = enumerado.ColumnaCProdProv Then
                ' Obtener caracter  
                Dim caracter As Char = e.KeyChar
                ' comprobar si el caracter es un número o el retroceso  
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    'Me.Text = e.KeyChar  
                    e.KeyChar = Chr(0)
                End If
            ElseIf columna = enumerado.ColumnaCodArticulo Then 'validoEnteros
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
            ElseIf columna = enumerado.ColumnaPUnit Then
                Dim caracter As Char = e.KeyChar
                Dim txt As TextBox = CType(sender, TextBox)
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
    Private Sub dgvNotaDebitoProveedor_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotaDebitoProveedor.CellValueChanged
        Dim importe As Double
        Dim cantidad As Double
        Dim valorAct As Double
        Dim CodigoP As Integer
        Dim DescripcionArt As String
        Try
            If (Not IsNothing(dgvNotaDebitoProveedor.CurrentCell)) Then
                Dim fila As Integer = dgvNotaDebitoProveedor.CurrentRow.Index.ToString()
                Dim columna As Integer = dgvNotaDebitoProveedor.CurrentCell.ColumnIndex
                If columna = enumerado.ColumnaCodArticulo Then
                    If Not IsNothing(Me.dgvNotaDebitoProveedor.Item(columna, fila).Value) Then
                        caracteres = Me.dgvNotaDebitoProveedor.Item(columna, fila).Value.ToString()
                        CodigoP = Convert.ToInt32(caracteres)
                    Else
                        CodigoP = 0
                    End If
                    completar(CodigoP, fila, columna)
                ElseIf columna = enumerado.ColumnaCProdProv Then
                    If Not IsNothing(Me.dgvNotaDebitoProveedor.Item(columna, fila).Value) Then
                        caracteres = Me.dgvNotaDebitoProveedor.Item(columna, fila).Value.ToString()
                        CodigoP = Convert.ToInt32(caracteres)
                    Else
                        CodigoP = 0
                    End If
                    completar(CodigoP, fila, columna)
                ElseIf columna = enumerado.ColumnaDescripcionArt Then
                    If Not IsNothing(Me.dgvNotaDebitoProveedor.Item(columna, fila).Value) Then
                        caracteres = Me.dgvNotaDebitoProveedor.Item(columna, fila).Value.ToString()
                        DescripcionArt = Convert.ToString(caracteres)
                    Else
                        DescripcionArt = 0
                    End If
                    completar_Texto(DescripcionArt, fila, columna)
                ElseIf columna = enumerado.ColumnaUnidKilos Then 'validoEnteros
                    If Not IsNothing(Me.dgvNotaDebitoProveedor.Item(columna, fila).Value) Then
                        caracteres = Me.dgvNotaDebitoProveedor.Item(columna, fila).Value.ToString()
                        valorAct = Convert.ToDouble(caracteres)
                    Else
                        valorAct = 0
                    End If
                    obtenerImporte(valorAct, fila, columna, importe)
                ElseIf columna = enumerado.ColumnaPUnit Then
                    If Not IsNothing(Me.dgvNotaDebitoProveedor.Item(columna, fila).Value) Then
                        valorAct = Convert.ToDouble(Me.dgvNotaDebitoProveedor(columna, fila).Value.ToString())
                    Else
                        valorAct = 0
                    End If
                    obtenerImporte(valorAct, fila, columna, importe)
                End If
            ElseIf dgvNotaDebitoProveedor.Rows.Count = 0 Then
                agregarFilaInicial()
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub completar(ByVal CodigoP As Integer, ByVal fila As Integer, ByVal columna As Integer)
        Dim consulta As String
        'Dim articulo As New Controlador.clsArticulos
        Dim dtdatos As New DataTable
        'Dim Proveedor As New Controlador.clsContProveedor
        Dim Numero_Condicion_IVA_Proveedor As Integer
        'Dim Empresa As New Controlador.clsEmpresas
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim clsFacturacionProveedor As New Controlador.clsFacturacionProveedor
        'Dim DatoTipoComprobante As Controlador.clsFacturacionProveedor.eTipoComprobante
        Dim ObtenerTasa As Double
        Try

            'consulta = " select P.Id_Tasa_IVA, P.Tipo_Unidad,P.Id_Producto,P.Descripcion,PLP.Precio_Costo,PLP.DescripcionListaPrecio,P.Cod_Prod_Proveedor " & vbCrLf
            'consulta += "from ((producto as P" & vbCrLf
            'consulta += "inner join Producto_Lista_Precio as PLP on P.Id_Producto = PLP.Id_Producto) " & vbCrLf
            'consulta += "inner join EmpresaArticulo as EA on P.Id_Producto=EA.Id_Articulo) " & vbCrLf
            'consulta += "where(P.INHABILITAR = False)" & vbCrLf
            'consulta += " and P.Id_Proveedor='" + txtCodigoProveedor.Text.Trim() + "' " & vbCrLf
            'consulta += " and PLP.ID_Lista_Precio='" + Datos_Configuracion.Rows(0).Item(dfieldefConfiguracion.Id_Lista_Precio).ToString() + "' " & vbCrLf
            'consulta += " and ((P.Id_Producto ='" + Convert.ToString(CodigoP) + "')or (P.Cod_Prod_Proveedor='" + Convert.ToString(CodigoP) + "'))  " & vbCrLf
            'consulta += " and EA.Id_Empresa='" + DatosEmpresa(0).Item("Id_Empresa") + "' " & vbCrLf

            clsarticulo.recuperar_Datos_Producto_Producto_Lista_Precio_EmpresaArticulo(txtCodigoProveedor.Text.Trim(), eDatos_Configuracion.Id_Lista_Precio.ToString(), Convert.ToString(CodigoP), dtDatosEmpresa(0).Item("Id_Empresa"), dtdatos)
            If dtdatos.Rows.Count > 0 Then
                'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIva.Text) & "' "
                clsProveedor.Obtener_CondicionFrenteAIVa(txtCondIva.Text, Numero_Condicion_IVA_Proveedor)
                'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)

                'consulta = " Select TC.Descripcion" & vbCrLf
                'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                'consulta += " inner join ComprobantesProveedor as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                'consulta += " and C.IdCondFrenteIvaProveedor='" & (Numero_Condicion_IVA_Proveedor) & "' " & vbCrLf
                'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                'consulta += " and TC.IdTipoComprobante in ('2','7','12')"

                clsFacturacionProveedor.Obtener_Datos_Comprobante_Proveedor(Numero_Condicion_IVA_Proveedor, Numero_Condicion_IVA_Empresa, dfielddefConstantes.Nota_De_Debito.ToString(), eDatoTipoComprobante)
                If eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO A" Then
                    dgvNotaDebitoProveedor.Item(enumerado.columnaTipoUnidad, fila).Value = dtdatos.Rows(0).Item("Tipo_Unidad")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaCProdProv, fila).Value = dtdatos.Rows(0).Item("Cod_Prod_Proveedor")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaCodArticulo, fila).Value = dtdatos.Rows(0).Item("Id_Producto")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaDescripcionArt, fila).Value = dtdatos.Rows(0).Item("Descripcion")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaUnidKilos, fila).Value = "0"
                    clsFacturacionProveedor.obtenerTasa(dtdatos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaPUnit, fila).Value = Format(dtdatos.Rows(0).Item("Precio_Costo").ToString() / ObtenerTasa, "##,##0.00")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaImporte, fila).Value = "0"
                ElseIf eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO B" Or eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO C" Then
                    dgvNotaDebitoProveedor.Item(enumerado.columnaTipoUnidad, fila).Value = dtdatos.Rows(0).Item("Tipo_Unidad")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaCProdProv, fila).Value = dtdatos.Rows(0).Item("Cod_Prod_Proveedor")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaCodArticulo, fila).Value = dtdatos.Rows(0).Item("Id_Producto")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaDescripcionArt, fila).Value = dtdatos.Rows(0).Item("Descripcion")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaUnidKilos, fila).Value = "0"
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaPUnit, fila).Value = dtdatos.Rows(0).Item("Precio_Costo")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaImporte, fila).Value = "0"
                End If
            Else
                clsarticulo.CompId_Proveedor = Convert.ToInt32(txtCodigoProveedor.Text.Trim())
                clsarticulo.CompFila = fila
                Dim frmAP = New Vista.frmArticulosProveedor()
                frmAP.ShowDialog()
                dgvNotaDebitoProveedor.EndEdit()
                If clsarticulo.CompId_Articulo <> "" Then
                    Me.dgvNotaDebitoProveedor.CurrentCell = Me.dgvNotaDebitoProveedor(enumerado.ColumnaCodArticulo, fila)
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaCodArticulo, fila).Value = clsarticulo.CompId_Articulo
                Else
                    If dgvNotaDebitoProveedor.Rows.Count > 0 Then
                        EliminarFila()
                    End If
                    If dgvNotaDebitoProveedor.Rows.Count = 0 Then
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
        'Dim articulo As New Controlador.clsArticulos
        Dim dtdatos As New DataTable
        'Dim Proveedor As New Controlador.clsContProveedor
        Dim Numero_Condicion_IVA_Proveedor As Integer
        'Dim Empresa As New Controlador.clsEmpresas
        Dim Numero_Condicion_IVA_Empresa As Integer
        'Dim clsFacturacionProveedor As New Controlador.clsFacturacionProveedor
        'Dim DatoTipoComprobante As Controlador.clsFacturacionProveedor.eTipoComprobante
        Dim ObtenerTasa As Double
        Try

            'consulta = " select P.Id_Tasa_IVA,P.Tipo_Unidad,P.Id_Producto,P.Descripcion,PLP.Precio_Costo,PLP.DescripcionListaPrecio,P.Cod_Prod_Proveedor "
            'consulta += "from ((producto as P "
            'consulta += "inner join Producto_Lista_Precio as PLP on P.Id_Producto = PLP.Id_Producto) "
            'consulta += "inner join EmpresaArticulo  as EA on P.Id_Producto=EA.Id_Articulo) "
            'consulta += "where(P.INHABILITAR = False)"
            'consulta += " and P.Id_Proveedor='" + txtCodigoProveedor.Text.Trim() + "' "
            'consulta += "and PLP.ID_Lista_Precio='" + Datos_Configuracion.Rows(0).Item(dfieldefConfiguracion.Id_Lista_Precio).ToString() + "'  "
            'consulta += "and P.Descripcion =  '" + (DescripcionArticulo) + "' "
            'consulta += "and EA.Id_Empresa='" + DatosEmpresa(0).Item("Id_Empresa") + "' "

            clsarticulo.recuperar_Datos_Producto_Producto_Lista_Precio_EmpresaArticulo_Descripcion(txtCodigoProveedor.Text.Trim(), eDatos_Configuracion.Id_Lista_Precio, DescripcionArticulo, dtDatosEmpresa(0).Item("Id_Empresa"), dtdatos)
            If dtdatos.Rows.Count > 0 Then
                'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIva.Text) & "' "
                clsProveedor.Obtener_CondicionFrenteAIVa(txtCondIva.Text, Numero_Condicion_IVA_Proveedor)
                'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)

                'consulta = " Select TC.Descripcion" & vbCrLf
                'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                'consulta += " inner join ComprobantesProveedor as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                'consulta += " and C.IdCondFrenteIvaProveedor='" & (Numero_Condicion_IVA_Proveedor) & "' " & vbCrLf
                'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                'consulta += " and TC.IdTipoComprobante in ('2','7','12')"

                clsFacturacionProveedor.Obtener_Datos_Comprobante_Proveedor(Numero_Condicion_IVA_Proveedor, Numero_Condicion_IVA_Empresa, dfielddefConstantes.Nota_De_Debito.ToString(), eDatoTipoComprobante)
                If eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO A" Then
                    dgvNotaDebitoProveedor.Item(enumerado.columnaTipoUnidad, fila).Value = dtdatos.Rows(0).Item("Tipo_Unidad")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaCProdProv, fila).Value = dtdatos.Rows(0).Item("Cod_Prod_Proveedor")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaCodArticulo, fila).Value = dtdatos.Rows(0).Item("Id_Producto")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaDescripcionArt, fila).Value = dtdatos.Rows(0).Item("Descripcion")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaUnidKilos, fila).Value = "0"
                    clsFacturacionProveedor.obtenerTasa(dtdatos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaPUnit, fila).Value = Format(dtdatos.Rows(0).Item("Precio_Costo").ToString() / ObtenerTasa, "##,##0.00")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaImporte, fila).Value = "0"
                ElseIf eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO B" Or eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO C" Then
                    dgvNotaDebitoProveedor.Item(enumerado.columnaTipoUnidad, fila).Value = dtdatos.Rows(0).Item("Tipo_Unidad")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaCProdProv, fila).Value = dtdatos.Rows(0).Item("Cod_Prod_Proveedor")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaCodArticulo, fila).Value = dtdatos.Rows(0).Item("Id_Producto")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaDescripcionArt, fila).Value = dtdatos.Rows(0).Item("Descripcion")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaUnidKilos, fila).Value = "0"
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaPUnit, fila).Value = dtdatos.Rows(0).Item("Precio_Costo")
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaImporte, fila).Value = "0"
                End If
            Else
                clsarticulo.CompId_Proveedor = Convert.ToInt32(txtCodigoProveedor.Text.Trim())
                clsarticulo.CompFila = fila
                Dim frmAP = New Vista.frmArticulosProveedor()
                frmAP.ShowDialog()
                dgvNotaDebitoProveedor.EndEdit()
                If clsarticulo.CompDescripcion <> "" Then
                    dgvNotaDebitoProveedor.Item(enumerado.ColumnaDescripcionArt, fila).Value = clsarticulo.CompDescripcion
                    DescripcionArticulo = clsarticulo.CompDescripcion
                Else
                    If dgvNotaDebitoProveedor.Rows.Count > 0 Then
                        EliminarFila()
                    End If
                    If dgvNotaDebitoProveedor.Rows.Count = 0 Then
                        agregarFilaInicial()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub obtenerImporte(ByVal ValorActual As Double, ByVal fila As Integer, ByVal columna As Integer, ByRef importe As Double)
        Dim cantidad As Double
        Dim precioNeto As Double
        Dim valorAct As Double
        Dim DescripcionArt As String
        Dim CodigoP As Integer
        Try
            If columna = enumerado.ColumnaCProdProv Or columna = enumerado.ColumnaCodArticulo Then
                If Not IsNothing(Me.dgvNotaDebitoProveedor.Item(columna, fila).Value) Then
                    caracteres = Me.dgvNotaDebitoProveedor.Item(columna, fila).Value.ToString()
                    CodigoP = Convert.ToInt32(caracteres)
                Else
                    CodigoP = 0
                End If
                completar(CodigoP, fila, columna)
            ElseIf columna = enumerado.ColumnaDescripcionArt Then
                If Not IsNothing(Me.dgvNotaDebitoProveedor.Item(columna, fila).Value) Then
                    caracteres = Me.dgvNotaDebitoProveedor.Item(columna, fila).Value.ToString()
                    DescripcionArt = Convert.ToString(caracteres)
                Else
                    DescripcionArt = 0
                End If
                completar_Texto(DescripcionArt, fila, columna)
            ElseIf columna = enumerado.ColumnaUnidKilos Then
                cantidad = ValorActual
                If Not IsNothing(Me.dgvNotaDebitoProveedor(Convert.ToInt32(enumerado.ColumnaPUnit), fila).Value) Then
                    precioNeto = Convert.ToDouble(Me.dgvNotaDebitoProveedor(Convert.ToInt32(enumerado.ColumnaPUnit), fila).Value.ToString())
                Else
                    precioNeto = 0
                End If
            ElseIf columna = enumerado.ColumnaPUnit Then
                If Not IsNothing(Me.dgvNotaDebitoProveedor(Convert.ToInt32(enumerado.ColumnaUnidKilos), fila).Value) Then
                    cantidad = Convert.ToDouble(Me.dgvNotaDebitoProveedor(Convert.ToInt32(enumerado.ColumnaUnidKilos), fila).Value.ToString())
                Else
                    cantidad = 0
                End If
                precioNeto = ValorActual
            End If
            If cantidad > 0 And precioNeto > 0 Then
                importe = cantidad * precioNeto
            Else
                importe = 0
            End If
            dgvNotaDebitoProveedor(enumerado.ColumnaImporte, fila).Value = Convert.ToString(importe)
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvNotaDebitoProveedor_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotaDebitoProveedor.CellContentClick
        Dim filaseleccionada As Integer
        Dim colseleccionada As Integer
        Try
            filaseleccionada = Convert.ToInt32(dgvNotaDebitoProveedor.CurrentRow.Index.ToString())
            Dim result As Integer = MessageBox.Show("Desea Eliminar el Articulo: " + CStr(dgvNotaDebitoProveedor.Rows(filaseleccionada).Cells(enumerado.ColumnaDescripcionArt).Value), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.Yes Then
                If dgvNotaDebitoProveedor.Rows.Count > 0 Then
                    dgvNotaDebitoProveedor.Rows.Remove(dgvNotaDebitoProveedor.CurrentRow)
                End If
            End If
            If dgvNotaDebitoProveedor.Rows.Count = 0 Then
                agregarFilaInicial()
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvNotaDebitoProveedor_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvNotaDebitoProveedor.CellFormatting
        'Dim clsFacturacionProveedor As New Controlador.clsFacturacionProveedor()
        Dim totalImporte As Double
        Try
            clsFacturacionProveedor.sumar_Importe(dgvNotaDebitoProveedor, totalImporte)
            txtSubTotal.Text = Format(totalImporte, "##,##0.00")

            If totalImporte = 0.0 Then
                txtIVa.Text = Format(0.0, "##,##0.00")
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtSubTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubTotal.TextChanged
        Dim consulta As String
        'Dim articulo As New Controlador.clsArticulos()
        'Dim Proveedor As New Controlador.clsContProveedor
        'Dim Empresa As New Controlador.clsEmpresas()
        'Dim clsFacturacionProveedor As New Controlador.clsFacturacionProveedor
        'Dim clsTasaIVA As New Controlador.clsTasaIVA()
        Dim Numero_Condicion_IVA_Proveedor As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        'Dim DatoTipoComprobante As Controlador.clsFacturacionProveedor.eTipoComprobante
        Dim obtenerTasa As Double
        Dim Total As Double
        Dim dtdatosTasa As New DataTable
        Dim TIVA As Double
        Try
            If dgvNotaDebitoProveedor.Rows.Count > 0 Then
                If IsNumeric(Convert.ToString(dgvNotaDebitoProveedor.CurrentRow.Cells("CodigoArticulo").Value)) Then
                    'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIva.Text) & "' "
                    clsProveedor.Obtener_CondicionFrenteAIVa(txtCondIva.Text, Numero_Condicion_IVA_Proveedor)
                    'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                    clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)

                    'consulta = " Select TC.Descripcion" & vbCrLf
                    'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                    'consulta += " inner join ComprobantesProveedor as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                    'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                    'consulta += " and C.IdCondFrenteIvaProveedor='" & (Numero_Condicion_IVA_Proveedor) & "' " & vbCrLf
                    'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                    'consulta += " and TC.IdTipoComprobante in ('2','7','12')"
                    clsFacturacionProveedor.Obtener_Datos_Comprobante_Proveedor(Numero_Condicion_IVA_Proveedor, Numero_Condicion_IVA_Empresa, dfielddefConstantes.Nota_De_Debito.ToString(), eDatoTipoComprobante)
                    If eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO A" Then
                        'txtIVa.Text = Format((txtSubTotal.Text.ToString() * 21) / 100, "##,##0.00")
                        consulta = String.Empty
                        'consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                        'TasaIVA.recuperar_Datos(Datos_Configuracion.Id_Tasa_IVA, datosTasa)
                        'TasaIVA.obtenerTasaIva(txtSubTotal.Text.ToString, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                        txtIVa.Text = Format(TIVA, "##,##0.00")
                        If txtDescuento.Text <> String.Empty Then
                            Total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text) - CDbl(txtDescuento.Text)
                            txtTotal.Text = Format(Total, "##,##0.00")
                        Else
                            Total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text) - 0
                            txtTotal.Text = Format(Total, "##,##0.00")
                        End If
                    Else
                        If eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO B" Or eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO C" Then
                            If txtDescuento.Text <> "" Then
                                Total = CDbl(txtSubTotal.Text) - CDbl(txtDescuento.Text)
                                txtTotal.Text = Format(Total, "##,##0.00")
                            Else
                                Total = CDbl(txtSubTotal.Text) - 0
                                txtTotal.Text = Format(Total, "##,##0.00")
                            End If
                        End If
                    End If
                Else
                    txtTotal.Text = txtSubTotal.Text
                End If
            Else
                txtTotal.Text = txtSubTotal.Text
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtDescuento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescuento.TextChanged
        Dim total As Double
        Dim consulta As String
        'Dim articulo As New Controlador.clsArticulos()
        'Dim Proveedor As New Controlador.clsContProveedor
        'Dim Empresa As New Controlador.clsEmpresas()
        'Dim clsTasaIVA As New Controlador.clsTasaIVA()
        'Dim clsFacturacionProveedor As New Controlador.clsFacturacionProveedor
        Dim Numero_Condicion_IVA_Proveedor As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        'Dim DatoTipoComprobante As Controlador.clsFacturacionProveedor.eTipoComprobante
        Dim obtenerTasa As Double
        Dim es_Numero As Boolean
        Dim dtdatosTasa As New DataTable
        Dim TIVA As Double
        Try
            'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIva.Text) & "' "
            clsProveedor.Obtener_CondicionFrenteAIVa(txtCondIva.Text, Numero_Condicion_IVA_Proveedor)
            'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
            clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)

            'consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
            'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
            'consulta += " inner join ComprobantesProveedor as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
            'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
            'consulta += " and C.IdCondFrenteIvaProveedor='" & (Numero_Condicion_IVA_Proveedor) & "' " & vbCrLf
            'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
            'consulta += " and TC.IdTipoComprobante in ('2','7','12')"

            clsFacturacionProveedor.Obtener_Datos_Comprobante_Proveedor(Numero_Condicion_IVA_Proveedor, Numero_Condicion_IVA_Empresa, dfielddefConstantes.Nota_De_Debito.ToString(), eDatoTipoComprobante)
            es_Numero = clsFacturacionProveedor.es_Numero(txtDescuento.Text)
            If es_Numero Then
                If eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO A" Then

                    consulta = String.Empty
                    'consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                    'TasaIVA.recuperar_Datos(Datos_Configuracion.Id_Tasa_IVA, datosTasa)
                    'TasaIVA.obtenerTasaIva(txtSubTotal.Text.ToString, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                    txtIVa.Text = Format(TIVA, "##,##0.00")

                    If txtDescuento.Text = String.Empty Then
                        total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text) - 0
                    Else
                        total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text) - CDbl(Replace(txtDescuento.Text, ".", ","))
                    End If
                    txtTotal.Text = Format(total, "##,##0.00")
                Else
                    If eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO B" Or eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO C" Then
                        If txtDescuento.Text = String.Empty Then
                            total = CDbl(txtSubTotal.Text) - 0
                        Else
                            total = CDbl(txtSubTotal.Text) - CDbl(Replace(txtDescuento.Text, ".", ","))
                        End If
                        txtTotal.Text = Format(total, "##,##0.00")
                    End If
                End If
            Else
                txtDescuento.Text = String.Empty
                If eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO A" Then
                    total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text)
                    txtTotal.Text = Format(total, "##,##0.00")
                Else
                    If eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO B" Or eDatoTipoComprobante.Descripcion = "NOTA DE DEBITO C" Then
                        total = CDbl(txtSubTotal.Text)
                        txtTotal.Text = Format(total, "##,##0.00")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvFNotaDebitoProveedor_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvNotaDebitoProveedor.CellBeginEdit
        'Dim clsFacturacionProveedor As New Controlador.clsFacturacionProveedor
        Try
            If txtCodigoProveedor.Text = String.Empty Then
                MessageBox.Show("No ha Ingresado el Proveedor, Ingreselo!!", "Informacion", MessageBoxButtons.OK, _
                                                   MessageBoxIcon.Information)
                clsFacturacionProveedor.Limpiar_Datos_Comprobante_Proveedor(dgvNotaDebitoProveedor, txtSubTotal, txtDescuento, txtIVa, txtTotal, txtRazonSocial, txtDireccion, txtCelular, txtTelefono, txtCondIva, txtMail, txtLimiteCC, txtCodigoPostal, lblTipoComprobante, lblIdComprobante)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvFacturacionProveedor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvNotaDebitoProveedor.KeyDown
        agregarNuevaFila(e)
    End Sub
    Private Sub agregarNuevaFila(ByVal e As System.Windows.Forms.KeyEventArgs)
        If dgvNotaDebitoProveedor.Rows.Count > 0 Then
            Dim columna As Integer = dgvNotaDebitoProveedor.CurrentCell.ColumnIndex
            If columna > 6 And e.KeyCode = Keys.Enter Then
                dgvNotaDebitoProveedor.Rows.Add()
                dgvNotaDebitoProveedor.CurrentCell = dgvNotaDebitoProveedor.Rows(dgvNotaDebitoProveedor.CurrentRow.Index).Cells("CodigoProductoProveedor")
            End If
        End If
    End Sub
    Private Sub agregarFilaInicial()
        dgvNotaDebitoProveedor.Rows.Add()
    End Sub
    Private Sub EliminarFila()
        dgvNotaDebitoProveedor.Rows.Remove(dgvNotaDebitoProveedor.CurrentRow)
    End Sub
    Private Sub ToolStripButtonRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonRegistrar.Click
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim NotaDebitoProveedor As New Controlador.clsFacturacionProveedor
        Dim dtdatosDataTable As New DataTable
        Dim tipocomprobante As String
        Dim Numero_Condicion_IVA_Empresa As Integer
        'Dim Empresa As New Controlador.clsEmpresas
        'Dim Numero_Condicion_IVA_Cliente As Controlador.clsCliente.eCondicion_Frente_Al_Iva
        'Dim clsCliente As New Controlador.clsCliente
        'Dim Articulo As New Controlador.clsArticulos
        Dim dtArticulos As New DataTable
        Dim i As Integer
        'Dim formaPago As New Controlador.clsFormasDePago
        Dim existe As Boolean
        For x As Integer = ProgressBarFacturacionProveedor.Minimum To ProgressBarFacturacionProveedor.Maximum
            ProgressBarFacturacionProveedor.Value = x
        Next
        For x As Integer = ProgressBarFacturacionProveedor.Maximum To ProgressBarFacturacionProveedor.Minimum Step -1
            ProgressBarFacturacionProveedor.Value = x
        Next
        If txtCodigoProveedor.Text <> "" Then
            If tbPuntoVenta.Text <> "" And tbNumeroComprobante.Text <> "" Then
                'consulta = "select * from Encabezado_Factura_Proveedor where Punto_Venta='" + tbPuntoVenta.Text.Trim() + "'and Numero_Comprobante='" + tbNumeroComprobante.Text.Trim() + "'  and  Tipo_Comprobante='" + lblIdComprobante.Text.Trim() + "' and Id_Proveedor = " + (txtCodigoProveedor.Text) + ""
                clsNotaDebitoProveedor.se_Cargo(tbPuntoVenta.Text.Trim(), tbNumeroComprobante.Text.Trim(), lblIdComprobante.Text.Trim(), txtCodigoProveedor.Text, existe)
                If Not existe Then
                    If Convert.ToDouble(txtSubTotal.Text) > 0 Then
                        ReDim eNotaDebitoProveedor_Enc_estructura(1)
                        eNotaDebitoProveedor_Enc_estructura(1).Punto_Venta = Convert.ToString(tbPuntoVenta.Text.Trim()).PadLeft(4, "0")
                        eNotaDebitoProveedor_Enc_estructura(1).Tipo_Comprobante = lblIdComprobante.Text.Trim()
                        eNotaDebitoProveedor_Enc_estructura(1).Numero_Comprobante = Convert.ToString(tbNumeroComprobante.Text.Trim()).PadLeft(8, "0")
                        eNotaDebitoProveedor_Enc_estructura(1).Id_Proveedor = Convert.ToInt32(txtCodigoProveedor.Text)
                        eNotaDebitoProveedor_Enc_estructura(1).Razon_Social = txtRazonSocial.Text.Trim()
                        eNotaDebitoProveedor_Enc_estructura(1).Situacion_Frente_A_IVA = txtCondIva.Text.Trim()
                        eNotaDebitoProveedor_Enc_estructura(1).Forma_Pago = String.Empty
                        eNotaDebitoProveedor_Enc_estructura(1).Fecha_Comprobante = mtFecha.Text.Trim()
                        eNotaDebitoProveedor_Enc_estructura(1).Codigo_Vendedor = 1
                        eNotaDebitoProveedor_Enc_estructura(1).Neto_Grabado = txtSubTotal.Text.Trim()
                        eNotaDebitoProveedor_Enc_estructura(1).Conc_No_Grabado = String.Empty
                        eNotaDebitoProveedor_Enc_estructura(1).Exentos = String.Empty
                        eNotaDebitoProveedor_Enc_estructura(1).IVA_Facturado = txtIVa.Text.Trim()
                        eNotaDebitoProveedor_Enc_estructura(1).IVA_Resp_No_Inscripto = String.Empty
                        eNotaDebitoProveedor_Enc_estructura(1).Persepciones = String.Empty
                        If txtDescuento.Text.Trim() <> String.Empty Then
                            eNotaDebitoProveedor_Enc_estructura(1).Descuentos = Replace(txtDescuento.Text.Trim(), ".", ",")
                        Else
                            eNotaDebitoProveedor_Enc_estructura(1).Descuentos = "0"
                        End If
                        eNotaDebitoProveedor_Enc_estructura(1).Retenciones = String.Empty
                        eNotaDebitoProveedor_Enc_estructura(1).Total = txtTotal.Text.Trim()
                        eNotaDebitoProveedor_Enc_estructura(1).Cancelado = dfielddefConstantes.No.ToString()
                        eNotaDebitoProveedor_Enc_estructura(1).Signo = "1"
                        'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIva.Text) & "' "
                        clsCliente.Obtener_CondicionFrenteAIVa(txtCondIva.Text, eNumero_Condicion_IVA_Cliente)
                        'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                        clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)
                        'consulta = "select distinct TC.Descripcion from Tipos_Comprobantes as TC,Comprobantes as C where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' and (C.IdComprobantes)=TC.IdTipoComprobante and TC.Descripcion like '" + Replace((dfielddefConstantes.Nota_De_Debito.ToString()), "_", " ") + "%'"
                        clsNotaDebitoProveedor.Obtener_Tipo_Comprobante_by_Descripcion(Numero_Condicion_IVA_Empresa, eNumero_Condicion_IVA_Cliente.Id_Condicion_IVA, Replace((dfielddefConstantes.Nota_De_Debito.ToString()), "_", " "), tipocomprobante)
                        eNotaDebitoProveedor_Enc_estructura(1).Comprobante = tipocomprobante
                        i = 1
                        While i <= dgvNotaDebitoProveedor.Rows.Count
                            If dgvNotaDebitoProveedor.Rows(i - 1).Cells("CodigoArticulo").Value <> "" Then
                                ReDim Preserve eNotaDebitoProveedor_Cuerpo_estructura(i)
                                ReDim Preserve eArticulos_Estructura(i)
                                eNotaDebitoProveedor_Cuerpo_estructura(i).Punto_Venta = tbPuntoVenta.Text.Trim()
                                eNotaDebitoProveedor_Cuerpo_estructura(i).Tipo_Comprobante = lblIdComprobante.Text.Trim()
                                eNotaDebitoProveedor_Cuerpo_estructura(i).Numero_Comprobante = tbNumeroComprobante.Text.Trim()
                                eNotaDebitoProveedor_Cuerpo_estructura(i).Comprobante = tipocomprobante
                                eNotaDebitoProveedor_Cuerpo_estructura(i).Numero_Articulo = dgvNotaDebitoProveedor.Rows(i - 1).Cells("CodigoArticulo").Value
                                eNotaDebitoProveedor_Cuerpo_estructura(i).Descripcion = dgvNotaDebitoProveedor.Rows(i - 1).Cells("Descripcion").Value
                                eNotaDebitoProveedor_Cuerpo_estructura(i).Cantidad = dgvNotaDebitoProveedor.Rows(i - 1).Cells("Cantidad").Value
                                eNotaDebitoProveedor_Cuerpo_estructura(i).Precio_Unitario = dgvNotaDebitoProveedor.Rows(i - 1).Cells("PrecioUnitario").Value
                                eNotaDebitoProveedor_Cuerpo_estructura(i).Signo = "1"
                                'consulta = "select * from " + dfielddefConstantes.Producto.ToString() + " where Id_Producto='" + NotaDebitoProveedor_Cuerpo_estructura(i).Numero_Articulo + "'"
                                clsarticulo.ObtenerProductos(eNotaDebitoProveedor_Cuerpo_estructura(i).Numero_Articulo, dtArticulos)
                                eArticulos_Estructura(i).Id_Producto = eNotaDebitoProveedor_Cuerpo_estructura(i).Numero_Articulo
                                eArticulos_Estructura(i).Stock = dtArticulos.Rows(0).Item("Stock")
                            End If
                            i = i + 1
                        End While
                        Try
                            Dim FPP As New frmFormasDePagoProveedor(eNotaDebitoProveedor_Enc_estructura, eNotaDebitoProveedor_Cuerpo_estructura, eArticulos_Estructura)
                            clsformaPago.Compvariable = dfielddefConstantes.NotaDebitoProveedor.ToString()
                            FPP.ShowDialog()
                            If clsformaPago.Compvariable = dfielddefConstantes.Si.ToString() Then
                                LimpiarEstructuras()
                                clsNotaDebitoProveedor.Limpiar_Datos_Comprobante(dgvNotaDebitoProveedor, txtSubTotal, txtDescuento, txtIVa, txtTotal, txtRazonSocial, txtDireccion, txtCelular, txtTelefono, txtCondIva, txtMail, txtLimiteCC, tbPuntoVenta, tbNumeroComprobante, lblTipoComprobante, lblIdComprobante)
                                txtCodigoProveedor.Text = ""
                                lblCodN.Visible = False
                            Else
                                If clsformaPago.Compvariable = dfielddefConstantes.No.ToString() Then
                                    LimpiarEstructuras()
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox("Error:" & vbCrLf & ex.Message)
                        End Try
                    Else
                        MessageBox.Show("No se han cargado productos!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                    End If
                Else
                    MessageBox.Show("El Comprobante ya ha sido Cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese el Numero de Comprobante!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                 MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub tbNumeroComprobante_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNumeroComprobante.Leave
        tbNumeroComprobante.Text = Convert.ToString(tbNumeroComprobante.Text.Trim()).PadLeft(8, "0")
    End Sub
    Private Sub tbPuntoVenta_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPuntoVenta.Leave
        tbPuntoVenta.Text = Convert.ToString(tbPuntoVenta.Text.Trim()).PadLeft(4, "0")
    End Sub
End Class