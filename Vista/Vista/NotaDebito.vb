﻿Imports Controlador
Imports System.IO.Ports

Public Class NotaDebito
    Dim Responsabilidad_IVA_Empresa As String
    Public _Cant As Integer
    Dim Enviar(0) As Byte
    Public NotaDebito_Enc_estructura(0) As Controlador.Facturacion.eEncabezadoFactura
    Public NotaDebito_Cuerpo_estructura(0) As Controlador.Facturacion.eCuerpoFactura
    Public Numero_Comprobante(0) As Controlador.NumeroComprobante.eNumeracionComprobante
    Public Articulos_Estructura(0) As Controlador.Articulos.eArticulo
    Public DatosNotaDebito As Controlador.Facturacion.eDatosFactura
    Dim dfielddefArticuloListaPrecio As Controlador.DfieldDef.eArticuloCuerpoDocumento
    Dim dfielddefEmpresa As Controlador.DfieldDef.eEmpresa
    Dim dfielddefConfiguracion As Controlador.DfieldDef.eConfiguracion
    Dim dfielddefListaPrecio As Controlador.DfieldDef.eListaPrecio
    Dim dfielddefCliente As Controlador.DfieldDef.eCliente
    Dim dfielddecNumeroComprobantea As Controlador.DfieldDef.eNumeroComprobante
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim Datos_Configuracion As New DataTable
    Private Sub NotaDebito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Empresa As New Empresas()
        Dim Consulta As String
        Dim Datos As New DataTable
        Dim Configuracion As New Controlador.Configuracion
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim puerto As Integer
        Try
            Consulta = "Select * from " + dfielddefConstantes.Configuracion.ToString() + ""
            'Configuracion.Obtener_Datos_Configuracion(Consulta, Datos_Configuracion)
            puerto = Convert.ToInt32(Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Nro_Puerto))
            If BalanzaConectada(puerto) Then
                AxMSComm2.CommPort = Convert.ToInt32(Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Nro_Puerto)) '.6 'pasar un parametro para el puerto com
                AxMSComm2.PortOpen = True         ' abrimos el puerto
                AxMSComm2.Settings = "9600,N,8,1"

                AxMSComm2.InputLen = 9
                AxMSComm2.RThreshold = 8
                AxMSComm2.InBufferCount = 0

                Enviar(0) = 7                ' Peticion de transmision de Datos debo enviar dos veces 7
                AxMSComm2.Output = Enviar       ' para que la balanza repsonda con peso con indicador de estabilidad
                AxMSComm2.Output = Enviar
            End If

            Consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + "  where Id_Empresa= '" + (Empresa.Compvariable) + "'"
            Empresa.Obtener_Empresa(Consulta, Datos)
            txtNroSucursal.Text = Datos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
            Responsabilidad_IVA_Empresa = Datos.Rows(0).Item(dfielddefEmpresa.Responsabilidad_IVA).ToString()
            mtFecha.Text = Date.Now
            lblCodN.Visible = False
            'Consulta = "Select * from " + dfielddefConstantes.Lista_Precio.ToString() + ""
            Lista_Precio.llenar_Combo_ListaPrecio(cbListaPrecio, "Id_Lista_Precio", "Descripcion")
            cbListaPrecio.Text = Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Lista_Precio).ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalir.Click
        For x As Integer = ProgressBarFacturacion.Minimum To ProgressBarFacturacion.Maximum
            ProgressBarFacturacion.Value = x
        Next
        For x As Integer = ProgressBarFacturacion.Maximum To ProgressBarFacturacion.Minimum Step -1
            ProgressBarFacturacion.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub dgvNotaDebito_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotaDebito.CellContentClick
        Dim filaseleccionada As Integer
        Dim colseleccionada As Integer
        Try
            filaseleccionada = Convert.ToInt32(dgvNotaDebito.CurrentRow.Index.ToString())
            Dim result As Integer = MessageBox.Show("Desea Eliminar el Articulo: " + CStr(dgvNotaDebito.Rows(filaseleccionada).Cells(2).Value), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.Yes Then
                If dgvNotaDebito.Rows.Count > 0 Then
                    dgvNotaDebito.Rows.Remove(dgvNotaDebito.CurrentRow)
                End If
                If dgvNotaDebito.Rows.Count = 0 Then
                    agregarFilaInicial()
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim Cliente As New Controlador.Cliente()
        Try
            Cliente.Compvariable = dfielddefConstantes.NotaDebito.ToString()
            Clientes.Show()
            Cliente.CompCodigo = Nothing
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Dim Cliente As New Controlador.Cliente()
        Dim Empresa As New Controlador.Empresas()
        Dim NotaDebito As New Controlador.Facturacion()
        Dim NumeroComprobante As New Controlador.NumeroComprobante()
        Dim consulta As String
        Dim datos As New DataTable
        Dim Numero_Condicion_IVA_Cliente As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim IDComprobante As Integer
        Dim numeroComp As String
        Dim nuComprobante As Integer
        Dim existe As Boolean
        Try
            If Not (Cliente.es_Numero(txtCodigoCliente.Text)) Then
                txtCodigoCliente.Text = String.Empty
            ElseIf txtCodigoCliente.Text <> "" Then
                consulta = "Select * from " + dfielddefConstantes.cliente.ToString() + " where Id_Cliente=" & Convert.ToInt32(txtCodigoCliente.Text) & ""
                Cliente.Validar_Cliente(consulta, existe)
                If existe Then
                    lblCodN.Visible = True
                    'NotaDebito.Limpiar_Datos_Comprobante(dgvNotaDebito, txtSubTotal, txtDescuento, txtIVa, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante)
                    Cliente.ObtenerConsulta(consulta, datos)
                    txtNombre.Text = datos.Rows(0).Item(dfielddefCliente.Nombre).ToString()
                    txtApellido.Text = datos.Rows(0).Item(dfielddefCliente.Apellido).ToString()
                    txtDireccion.Text = datos.Rows(0).Item(dfielddefCliente.Calle).ToString() + " " + datos.Rows(0).Item(dfielddefCliente.Piso).ToString() + " " + datos.Rows(0).Item(dfielddefCliente.Nro).ToString()
                    txtCelular.Text = datos.Rows(0).Item(dfielddefCliente.Celular).ToString()
                    txtTelefono.Text = datos.Rows(0).Item(dfielddefCliente.Telefono).ToString()
                    txtCondIVA.Text = datos.Rows(0).Item(dfielddefCliente.Responsabilidad_IVA).ToString()
                    txtMail.Text = datos.Rows(0).Item(dfielddefCliente.E_Mail).ToString()
                    txtLimiteCC.Text = datos.Rows(0).Item(dfielddefCliente.Saldo_CC).ToString()
                    txtNroSucursal.Text = datos.Rows(0).Item(dfielddefCliente.Saldo_CC).ToString()
                    consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIVA.Text) & "' "
                    ' Cliente.Obtener_CondicionFrenteAIVa(consulta, Numero_Condicion_IVA_Cliente)
                    consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                    Empresa.Obtener_Responsabilidad_IVA_Empresa(consulta, Numero_Condicion_IVA_Empresa)

                    consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                    consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                    consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                    consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                    consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                    consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                    consulta += " and TC.IdTipoComprobante in ('2','7','12')"

                    ' NotaDebito.Obtener_Datos_Comprobante(consulta, datos)
                    tipoComprobante = datos.Rows(0).Item("Descripcion")
                    lblTipoComprobante.Text = tipoComprobante
                    IDComprobante = datos.Rows(0).Item("IdTipoComprobante")
                    
                    lblIdComprobante.Text = Convert.ToString(IDComprobante).PadLeft(2, "0")
                    consulta = "select * from " + dfielddefConstantes.Empresa.ToString() + " where Id_Empresa= '" + (Empresa.Compvariable) + "'"
                    Empresa.Obtener_Empresa(consulta, datos)
                    txtNroSucursal.Text = datos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
                    Responsabilidad_IVA_Empresa = datos.Rows(0).Item(dfielddefEmpresa.Responsabilidad_IVA).ToString()

                    consulta = "select Numeracion from  " + dfielddefConstantes.Numeracion_Comprobante.ToString() + "  where Id_Empresa='" + Empresa.Compvariable + "' and Id_Tipo_Comprobante = '" & Convert.ToString(IDComprobante) & "'"
                    ' NumeroComprobante.obtener_Numero_Comprobante(consulta, numeroComp)
                    nuComprobante = Convert.ToInt32(numeroComp) + 1
                    NumeroComprobante.Aumentar_Numeracion_Comprobante(nuComprobante, numeroComp)
                    txtnumeroComprobante.Text = numeroComp

                    If tipoComprobante = "NOTA DE DEBITO A" Then ' muestra o no el total iva
                        Label19.Enabled = True
                        txtIVa.Enabled = True
                    Else
                        Label19.Enabled = False
                        txtIVa.Enabled = False
                    End If
                    If dgvNotaDebito.Rows.Count = 0 Then
                        agregarFilaInicial()
                    End If
                Else
                    MessageBox.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                    LimpiarEstructuras()
                    'NotaDebito.Limpiar_Datos_Comprobante(dgvNotaDebito, txtSubTotal, txtDescuento, txtIVa, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante)
                    txtCodigoCliente.Text = String.Empty
                    lblCodN.Visible = False
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub btnBuscarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarArticulo.Click
        Dim articulo As New Controlador.Articulos()
        Try
            If txtCodigoCliente.Text <> "" Then
                articulo.Compvariable = dfielddefConstantes.ArticulosNotaDebito.ToString()
                Articulos.Show()
                articulo.CompId_Articulo = Nothing
                AxMSComm2.InputLen = 0
                AxMSComm2.InBufferCount = 0
            Else
                MessageBox.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBusquedaArticulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusquedaArticulo.TextChanged
        Dim consulta As String
        Dim articulo As New Controlador.Articulos()
        Dim Cliente As New Controlador.Cliente()
        Dim Empresa As New Controlador.Empresas()
        Dim NotaDebito As New Controlador.Facturacion()
        Dim UltimaFila As Integer
        Dim Numero_Condicion_IVA_Cliente As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim ObtenerTasa As Double
        Dim importe As Double
        Dim datos As New DataTable
        Dim Datos_Configuracion As New DataTable
        Dim datos_Lita_Precio As New DataTable
        Dim Configuracion As New Controlador.Configuracion
        Dim Lista_Precio As New Controlador.Lista_Precios
        Try
            If Not (articulo.es_Numero(txtBusquedaArticulo.Text)) Then
                txtBusquedaArticulo.Text = String.Empty
            ElseIf articulo.Compvariable = dfielddefConstantes.ArticulosNotaDebito.ToString() Then
                If txtCodigoCliente.Text <> String.Empty Then

                    consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIVA.Text) & "' "
                    ' Cliente.Obtener_CondicionFrenteAIVa(consulta, Numero_Condicion_IVA_Cliente)
                    consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                    Empresa.Obtener_Responsabilidad_IVA_Empresa(consulta, Numero_Condicion_IVA_Empresa)

                    consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                    consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                    consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                    consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                    consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                    consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                    consulta += " and TC.IdTipoComprobante in ('2','7','12')"

                    ' NotaDebito.Obtener_Datos_Comprobante(consulta, datos)
                    tipoComprobante = datos.Rows(0).Item("Descripcion")
                    consulta = "Select * from " + dfielddefConstantes.Configuracion.ToString() + ""
                    ' Configuracion.Obtener_Datos_Configuracion(consulta, Datos_Configuracion)
                    consulta = "Select * from " + dfielddefConstantes.Lista_Precio.ToString() + "  where Descripcion= '" + cbListaPrecio.Text + "'"
                    'Lista_Precio.recuperar_Datos(consulta, datos_Lita_Precio)

                    consulta = " select *" & vbCrLf
                    consulta += "from (Producto as P" & vbCrLf
                    consulta += "Inner join Producto_Lista_Precio as PLP on P.Id_Producto=PLP.Id_Producto)" & vbCrLf
                    consulta += "where PLP.Id_Lista_Precio='" + datos_Lita_Precio.Rows(0).Item(dfielddefListaPrecio.Id_Lista_Precio).ToString() + "'" & vbCrLf
                    consulta += "and P.Id_Producto='" & (txtBusquedaArticulo.Text) & "' or P.Codigo_Barras= '" & (txtBusquedaArticulo.Text) & "'" & vbCrLf

                    'articulo.recuperar_Datos(consulta, datos)
                    If datos.Rows.Count > 0 Then
                        If txtBusquedaArticulo.Text <> "" Then
                            If tipoComprobante = "NOTA DE DEBITO B" Or tipoComprobante = "NOTA DE DEBITO C" Then 'preguntar si por defecto el ingreso es por codigo barras
                                Label19.Enabled = False
                                txtIVa.Enabled = False

                                If datos.Rows(0).Item(dfielddefArticuloListaPrecio.Pesable).ToString() = dfielddefConstantes.Si.ToString() Then 'cambiar por NO, se utiliza si el ingreso es por codigo barras
                                    'si es pesable obtener peso de balanza sino obtener cantidad de una ventana
                                    If IsNumeric(txtBalanza.Text) Then
                                        UltimaFila = dgvNotaDebito.Rows.Count - 1
                                        dgvNotaDebito.Rows.Add()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = Replace(txtBalanza.Text, ".", ",")
                                        dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
                                        importe = CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        txtBusquedaArticulo.Text = ""
                                        dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                    Else
                                        MessageBox.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        txtBusquedaArticulo.Text = ""
                                    End If
                                Else

                                    If (Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Lector_Codigo_Barras) = dfielddefConstantes.Si.ToString()) Then
                                        UltimaFila = dgvNotaDebito.Rows.Count - 1
                                        dgvNotaDebito.Rows.Add()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = 1
                                        dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
                                        importe = (dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        txtBusquedaArticulo.Text = ""
                                        dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                    Else
                                        Dim cantid As New Controlador.Cantidad()
                                        Dim FormCantidadad As New Vista.Cantidad()
                                        ' cantid.CompDatos = datos
                                        cantid.CompDataGrid = dgvNotaDebito
                                        cantid.CompTipoComprobante = tipoComprobante
                                        FormCantidadad.ShowDialog()
                                        txtBusquedaArticulo.Text = ""
                                    End If
                                End If
                            Else
                                If tipoComprobante = "NOTA DE DEBITO A" Then 'preguntar si por defecto el ingreso es por codigo barras
                                    Label19.Enabled = True
                                    txtIVa.Enabled = True
                                    If datos.Rows(0).Item(dfielddefArticuloListaPrecio.Pesable).ToString() = dfielddefConstantes.Si.ToString() Then 'cambiar por NO, se utiliza si el ingreso es por codigo barras es por default
                                        'si es pesable obtener peso de balanza sino obtener cantidad de una ventana
                                        If IsNumeric(txtBalanza.Text) Then
                                            UltimaFila = dgvNotaDebito.Rows.Count - 1
                                            dgvNotaDebito.Rows.Add()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = Replace(txtBalanza.Text, ".", ",")
                                            NotaDebito.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                                            dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                                            importe = CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                            txtBusquedaArticulo.Text = ""
                                            dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                        Else
                                            MessageBox.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            txtBusquedaArticulo.Text = ""
                                        End If
                                    Else
                                        consulta = "Select * from " + dfielddefConstantes.Configuracion.ToString() + " "
                                        ' Configuracion.Obtener_Datos_Configuracion(consulta, Datos_Configuracion)

                                        If (Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Lector_Codigo_Barras) = dfielddefConstantes.Si.ToString()) Then
                                            UltimaFila = dgvNotaDebito.Rows.Count - 1
                                            dgvNotaDebito.Rows.Add()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = 1
                                            NotaDebito.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                                            dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                                            importe = (dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                            txtBusquedaArticulo.Text = ""
                                            dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                        Else
                                            Dim cantid As New Controlador.Cantidad()
                                            Dim FormCantidadad As New Vista.Cantidad()
                                            'cantid.CompDatos = datos
                                            cantid.CompDataGrid = dgvNotaDebito
                                            cantid.CompTipoComprobante = tipoComprobante
                                            FormCantidadad.ShowDialog()
                                            txtBusquedaArticulo.Text = ""
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If txtBusquedaArticulo.Text.Trim() <> "" Then
                            MessageBox.Show("El Articulo no pertenece a la lista de precio: " + cbListaPrecio.Text + " , agreguelo a la lista!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtBusquedaArticulo.Text = ""
                        End If
                    End If
                Else
                    MessageBox.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                             MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvNotaDebito_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvNotaDebito.CellFormatting
        Dim NotaDebito As New Controlador.Facturacion()
        Dim totalImporte As Double
        Try
            NotaDebito.sumar_Importe(dgvNotaDebito, totalImporte)
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
        Dim articulo As New Controlador.Articulos()
        Dim Cliente As New Controlador.Cliente()
        Dim Empresa As New Controlador.Empresas()
        Dim NotaDebito As New Controlador.Facturacion()
        Dim Numero_Condicion_IVA_Cliente As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim obtenerTasa As Double
        Dim Total As Double
        Dim datosTasa As New DataTable
        Dim TIVA As Double
        Dim TasaIVA As New Controlador.TasaIVA()
        Dim datos As New DataTable
        Dim neto As Double
        Try
            If dgvNotaDebito.Rows.Count > 1 Then
                consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIVA.Text) & "' "
                ' Cliente.Obtener_CondicionFrenteAIVa(consulta, Numero_Condicion_IVA_Cliente)
                consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                Empresa.Obtener_Responsabilidad_IVA_Empresa(consulta, Numero_Condicion_IVA_Empresa)

                consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                consulta += " and TC.IdTipoComprobante in ('2','7','12')"

                'NotaDebito.Obtener_Datos_Comprobante(consulta, datos)
                tipoComprobante = datos.Rows(0).Item("Descripcion")

                If tipoComprobante = "NOTA DE DEBITO A" Then
                    consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                    TasaIVA.recuperar_Datos(consulta, datosTasa)
                    TasaIVA.obtenerTasaIva(txtSubTotal.Text.ToString, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                    txtIVa.Text = Format(TIVA, "##,##0.00")
                    If txtDescuento.Text <> "" Then
                        Total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text) - CDbl(txtDescuento.Text)
                        txtTotal.Text = Format(Total, "##,##0.00")
                        DatosNotaDebito.IVA_Facturado = Format(TIVA, "##,##0.00")
                        DatosNotaDebito.Neto_Grabado = Format(Convert.ToDouble(txtSubTotal.Text), "##,##0.00")
                    Else
                        Total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text) - 0
                        txtTotal.Text = Format(Total, "##,##0.00")
                        DatosNotaDebito.IVA_Facturado = Format(TIVA, "##,##0.00")
                        DatosNotaDebito.Neto_Grabado = Format(Convert.ToDouble(txtSubTotal.Text), "##,##0.00")
                    End If
                Else
                    If tipoComprobante = "NOTA DE DEBITO B" Or tipoComprobante = "NOTA DE DEBITO C" Then
                        consulta = String.Empty
                        consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                        TasaIVA.recuperar_Datos(consulta, datosTasa)
                        If txtDescuento.Text <> "" Then
                            Total = CDbl(txtSubTotal.Text) - CDbl(txtDescuento.Text)
                            txtTotal.Text = Format(Total, "##,##0.00")
                            neto = Convert.ToDouble(txtSubTotal.Text) / ((datosTasa.Rows(0).Item("Tasa").ToString() * 0.01) + 1)
                            DatosNotaDebito.Neto_Grabado = Format(neto, "##,##0.00")
                            TasaIVA.obtenerTasaIva(neto, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                            DatosNotaDebito.IVA_Facturado = Format(TIVA, "##,##0.00")
                        Else
                            Total = CDbl(txtSubTotal.Text) - 0
                            txtTotal.Text = Format(Total, "##,##0.00")
                            'DatosNotaCredito.IVA_Facturado = Format(TIVA, "##,##0.00")
                            neto = Convert.ToDouble(txtSubTotal.Text) / ((datosTasa.Rows(0).Item("Tasa").ToString() * 0.01) + 1)
                            DatosNotaDebito.Neto_Grabado = Format(neto, "##,##0.00")
                            TasaIVA.obtenerTasaIva(neto, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                            DatosNotaDebito.IVA_Facturado = Format(TIVA, "##,##0.00")
                        End If
                    End If
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
        Dim articulo As New Controlador.Articulos()
        Dim Cliente As New Controlador.Cliente()
        Dim Empresa As New Controlador.Empresas()
        Dim NotaDebito As New Controlador.Facturacion()
        Dim Numero_Condicion_IVA_Cliente As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim obtenerTasa As Double
        Dim es_Numero As Boolean
        Dim datosTasa As New DataTable
        Dim TIVA As Double
        Dim TasaIVA As New Controlador.TasaIVA()
        Dim neto As Double
        Dim datos As New DataTable
        Try
            'validar que se ingrese numeros
            consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIVA.Text) & "' "
            ' Cliente.Obtener_CondicionFrenteAIVa(consulta, Numero_Condicion_IVA_Cliente)
            consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
            Empresa.Obtener_Responsabilidad_IVA_Empresa(consulta, Numero_Condicion_IVA_Empresa)

            consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
            consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
            consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
            consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
            consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
            consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
            consulta += " and TC.IdTipoComprobante in ('2','7','12')"

            ' NotaDebito.Obtener_Datos_Comprobante(consulta, datos)
            tipoComprobante = datos.Rows(0).Item("Descripcion")

            es_Numero = NotaDebito.es_Numero(txtDescuento.Text)
            If es_Numero Then
                If tipoComprobante = "NOTA DE DEBITO A" Then
                    'consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                    'TasaIVA.recuperar_Datos(consulta, datosTasa)
                    'TasaIVA.obtenerTasaIva(txtSubTotal.Text.ToString, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                    'txtIVa.Text = Format(TIVA, "##,##0.00")
                    If txtDescuento.Text = "" Then
                        total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text) - 0
                    Else
                        total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text) - CDbl(Replace(txtDescuento.Text, ".", ","))
                    End If
                    consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                    TasaIVA.recuperar_Datos(consulta, datosTasa)
                    TasaIVA.obtenerTasaIva(txtSubTotal.Text, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                    txtIVa.Text = Format(TIVA, "##,##0.00")
                    txtTotal.Text = Format(total, "##,##0.00")
                    DatosNotaDebito.IVA_Facturado = Format(TIVA, "##,##0.00")
                    DatosNotaDebito.Neto_Grabado = Format(Convert.ToDouble(txtSubTotal.Text), "##,##0.00")
                Else
                    If tipoComprobante = "NOTA DE DEBITO B" Or tipoComprobante = "NOTA DE DEBITO C" Then
                        If txtDescuento.Text = "" Then
                            total = CDbl(txtSubTotal.Text) - 0
                        Else
                            total = CDbl(txtSubTotal.Text) - CDbl(Replace(txtDescuento.Text, ".", ","))
                        End If
                        consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                        TasaIVA.recuperar_Datos(consulta, datosTasa)
                        txtTotal.Text = Format(total, "##,##0.00")
                        neto = Convert.ToDouble(txtSubTotal.Text) / ((datosTasa.Rows(0).Item("Tasa").ToString() * 0.01) + 1)
                        DatosNotaDebito.Neto_Grabado = Format(neto, "##,##0.00")

                        TasaIVA.obtenerTasaIva(neto.ToString, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                        DatosNotaDebito.IVA_Facturado = Format(TIVA, "##,##0.00")
                    End If
                End If
            Else
                txtDescuento.Text = ""
                If tipoComprobante = "NOTA DE DEBITO A" Then
                    consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                    TasaIVA.recuperar_Datos(consulta, datosTasa)
                    TasaIVA.obtenerTasaIva(txtSubTotal.Text.ToString, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                    total = CDbl(txtSubTotal.Text) + CDbl(txtIVa.Text)
                    txtTotal.Text = Format(total, "##,##0.00")
                    DatosNotaDebito.IVA_Facturado = Format(TIVA, "##,##0.00")
                    DatosNotaDebito.Neto_Grabado = Format(Convert.ToDouble(txtSubTotal.Text), "##,##0.00")
                Else
                    If tipoComprobante = "NOTA DE DEBITO B" Or tipoComprobante = "NOTA DE DEBITO C" Then
                        total = CDbl(txtSubTotal.Text)
                        txtTotal.Text = Format(total, "##,##0.00")
                        'DatosFactura.IVA_Facturado = Format(TIVA, "##,##0.00")
                        neto = Convert.ToDouble(total) / ((datosTasa.Rows(0).Item("Tasa").ToString() * 0.01) + 1)
                        DatosNotaDebito.Neto_Grabado = Format(neto, "##,##0.00")

                        'txtTotal.Text = Format(txtSubTotal.Text, "##,##0.00")
                        neto = Convert.ToDouble(txtSubTotal.Text) / ((datosTasa.Rows(0).Item("Tasa").ToString() * 0.01) + 1)
                        DatosNotaDebito.Neto_Grabado = Format(neto, "##,##0.00")
                        consulta = "select Tasa from Tasa_IVA where Id_Tasa_IVA=" + Datos_Configuracion.Rows(0).Item("Id_Tasa_IVA") + " "
                        TasaIVA.recuperar_Datos(consulta, datosTasa)
                        TasaIVA.obtenerTasaIva(neto.ToString, datosTasa.Rows(0).Item("Tasa").ToString(), TIVA)
                        DatosNotaDebito.IVA_Facturado = Format(TIVA, "##,##0.00")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
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
    Private Sub AxMSComm2_OnComm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxMSComm2.OnComm
        Dim Temp As String
        Try
            If AxMSComm2.CommEvent = 2 Then ' controla que la interrupcion del puerto sea por recepcion de datos
                Temp = AxMSComm2.Input
                ' y los Carga en una variable llamada temp
                'Mid(Temp, 1, 3)
                txtBalanza.Text = Mid(Temp, 1, 3) & "," & Mid(Temp, 4, 3)  ' aqui sumamos los tres primeros bytes a una coma y los tres bytes siguientes

                If Mid(Temp, 7, 1) = "e" Then           ' analizamos el 7 byte para ver si es estable o inestable
                    Estable.Text = "Peso Estable"    ' el peso esta inestable
                    Estable.BackColor = Color.GreenYellow
                End If

                If Mid(Temp, 7, 1) = "i" Then           ' analizamos el 7 byte para ver si es estable o inestable
                    Estable.Text = "Peso Inestable"  ' el peso esta inestable
                    Estable.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If AxMSComm2.PortOpen = True Then
                Enviar(0) = 7                ' Peticion de transmision de Datos debo enviar dos veces 7
                AxMSComm2.Output = Enviar       ' para que la balanza repsonda con peso con indicador de estabilidad
                AxMSComm2.Output = Enviar

            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If AxMSComm2.PortOpen = True Then
            AxMSComm2.PortOpen = False
            txtBalanza.Text = ""
            AxMSComm2.InputLen = 0
            AxMSComm2.RThreshold = 8
        End If
    End Sub
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        AxMSComm2.CommPort = 3
        AxMSComm2.PortOpen = True         ' abrimos el puerto
        AxMSComm2.Settings = "9600,N,8,1"
        AxMSComm2.InputLen = 9
        AxMSComm2.RThreshold = 8
        AxMSComm2.InBufferCount = 0
        Enviar(0) = 7                ' Peticion de transmision de Datos debo enviar dos veces 7
        AxMSComm2.Output = Enviar       ' para que la balanza repsonda con peso con indicador de estabilidad
        AxMSComm2.Output = Enviar
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtBalanza.Text = ""
        AxMSComm2.InputLen = 0
        AxMSComm2.RThreshold = 8
        AxMSComm2.InBufferCount = 0
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            If AxMSComm2.PortOpen = True Then
                AxMSComm2.InputLen = 0
                AxMSComm2.InBufferCount = 0
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripRegistrarNotaDebito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRegistrarNotaDebito.Click
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim NotaDebito As New Controlador.Facturacion
        Dim NumeroComprobante As New Controlador.NumeroComprobante
        Dim datosDataTable As New DataTable
        Dim tipocomprobante As String
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Empresa As New Controlador.Empresas
        Dim Numero_Condicion_IVA_Cliente As Integer
        Dim Cliente As New Controlador.Cliente
        Dim Articulo As New Controlador.Articulos
        Dim dtArticulos As New DataTable
        Dim i As Integer
        Dim formaPago As New Controlador.FormasDePago
        Dim datosComprobante As New DataTable
        Dim IDComprobante As Integer
        For x As Integer = ProgressBarFacturacion.Minimum To ProgressBarFacturacion.Maximum
            ProgressBarFacturacion.Value = x
        Next
        For x As Integer = ProgressBarFacturacion.Maximum To ProgressBarFacturacion.Minimum Step -1
            ProgressBarFacturacion.Value = x
        Next
        If txtCodigoCliente.Text <> "" Then
            If Convert.ToDouble(txtSubTotal.Text) > 0 Then
                ReDim NotaDebito_Enc_estructura(1)
                NotaDebito_Enc_estructura(1).Punto_Venta = txtNroSucursal.Text.Trim()
                NotaDebito_Enc_estructura(1).Tipo_Comprobante = lblIdComprobante.Text.Trim()
                NotaDebito_Enc_estructura(1).Numero_Comprobante = txtnumeroComprobante.Text.Trim()
                NotaDebito_Enc_estructura(1).Numero_Cliente = Convert.ToInt32(txtCodigoCliente.Text)
                NotaDebito_Enc_estructura(1).Nombre = txtNombre.Text.Trim()
                NotaDebito_Enc_estructura(1).Apellido = txtApellido.Text.Trim()
                NotaDebito_Enc_estructura(1).Situacion_Frente_A_IVA = txtCondIVA.Text.Trim()
                NotaDebito_Enc_estructura(1).Forma_Pago = ""
                NotaDebito_Enc_estructura(1).Fecha_Comprobante = mtFecha.Text.Trim()
                NotaDebito_Enc_estructura(1).Codigo_Vendedor = 1
                'NotaDebito_Enc_estructura(1).Neto_Grabado = DatosNotaDebito.Neto_Grabado ' txtSubTotal.Text.Trim()
                NotaDebito_Enc_estructura(1).Conc_No_Grabado = ""
                NotaDebito_Enc_estructura(1).Exentos = ""
                NotaDebito_Enc_estructura(1).IVA_Facturado21 = DatosNotaDebito.IVA_Facturado 'txtIVa.Text.Trim()
                NotaDebito_Enc_estructura(1).IVA_Resp_No_Inscripto = ""
                NotaDebito_Enc_estructura(1).Persepciones = ""
                If txtDescuento.Text.Trim() <> "" Then
                    NotaDebito_Enc_estructura(1).Descuentos = Replace(txtDescuento.Text.Trim(), ".", ",")
                Else
                    NotaDebito_Enc_estructura(1).Descuentos = "0"
                End If
                NotaDebito_Enc_estructura(1).Retenciones = ""
                NotaDebito_Enc_estructura(1).Total = txtTotal.Text.Trim()
                NotaDebito_Enc_estructura(1).Cancelado = dfielddefConstantes.No.ToString()
                NotaDebito_Enc_estructura(1).Signo = "1"
                consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIVA.Text) & "' "
                '  Cliente.Obtener_CondicionFrenteAIVa(consulta, Numero_Condicion_IVA_Cliente)
                consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                Empresa.Obtener_Responsabilidad_IVA_Empresa(consulta, Numero_Condicion_IVA_Empresa)

                consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                consulta += " and TC.IdTipoComprobante in ('2','7','12')"

                'NotaDebito.Obtener_Tipo_Comprobante(consulta, tipocomprobante)
                ' NotaDebito.Obtener_Datos_Comprobante(consulta, datosComprobante)
                tipocomprobante = datosComprobante.Rows(0).Item("Descripcion")
                IDComprobante = datosComprobante.Rows(0).Item("IdTipoComprobante")


                NotaDebito_Enc_estructura(1).Comprobante = tipocomprobante
                ' consulta = "select Id_Comprobante,Descripcion, Numeracion,Id_Empresa from  " + dfielddefConstantes.Numeracion_Comprobante.ToString() + "  where Id_Empresa='" + Empresa.Compvariable + "' and Id_Comprobante = " & IDComprobante & ""
                'consulta = "select Id_Comprobante,Descripcion, Numeracion,Id_Empresa,Id_Tipo_Comprobante from " + dfielddefConstantes.Numeracion_Comprobante.ToString() + "   where Id_Empresa='" + Empresa.Compvariable + "' and Id_Tipo_Comprobante = '" & Convert.ToString(IDComprobante) & "'"
                NumeroComprobante.obtener_Datos_Numero_Comprobante_Tipo_Comprobante(Empresa.Compvariable, Convert.ToString(IDComprobante), datosDataTable)
                ReDim Numero_Comprobante(1)
                Numero_Comprobante(1).Id_Comprobante = datosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Id_Comprobante)
                Numero_Comprobante(1).Descripcion = datosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Descripcion)
                Numero_Comprobante(1).Numeracion = txtnumeroComprobante.Text.Trim()
                Numero_Comprobante(1).Id_Empresa = datosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Id_Empresa)
                Numero_Comprobante(1).Id_Tipo_Comprobante = datosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Id_Tipo_Comprobante)
                i = 1
                While i <= dgvNotaDebito.Rows.Count
                    If dgvNotaDebito.Rows(i - 1).Cells("Tipo_Unidad").Value <> "" Then
                        ReDim Preserve NotaDebito_Cuerpo_estructura(i)
                        ReDim Preserve Articulos_Estructura(i)
                        NotaDebito_Cuerpo_estructura(i).Punto_Venta = txtNroSucursal.Text.Trim()
                        NotaDebito_Cuerpo_estructura(i).Tipo_Comprobante = lblIdComprobante.Text.Trim()
                        NotaDebito_Cuerpo_estructura(i).Numero_Comprobante = txtnumeroComprobante.Text.Trim()
                        NotaDebito_Cuerpo_estructura(i).Comprobante = tipocomprobante
                        NotaDebito_Cuerpo_estructura(i).Numero_Articulo = dgvNotaDebito.Rows(i - 1).Cells("IdArticulo").Value
                        NotaDebito_Cuerpo_estructura(i).Descripcion = dgvNotaDebito.Rows(i - 1).Cells("Descripcion").Value
                        NotaDebito_Cuerpo_estructura(i).Cantidad = dgvNotaDebito.Rows(i - 1).Cells("Cantidad").Value
                        NotaDebito_Cuerpo_estructura(i).Precio_Unitario = dgvNotaDebito.Rows(i - 1).Cells("PrecioUnitario").Value
                        NotaDebito_Cuerpo_estructura(i).Signo = "1"
                        consulta = "select * from " + dfielddefConstantes.Producto.ToString() + " where Id_Producto='" + NotaDebito_Cuerpo_estructura(i).Numero_Articulo + "'"
                        'Articulo.recuperar_Datos(consulta, dtArticulos)
                        Articulos_Estructura(i).Id_Producto = NotaDebito_Cuerpo_estructura(i).Numero_Articulo
                        Articulos_Estructura(i).Stock = dtArticulos.Rows(0).Item(7)
                    End If
                    i = i + 1
                End While
                Try
                    Dim FPP As New FormasDePago(NotaDebito_Enc_estructura, NotaDebito_Cuerpo_estructura, Articulos_Estructura, Numero_Comprobante)
                    formaPago.Compvariable = dfielddefConstantes.NotaDebito.ToString()
                    FPP.ShowDialog()

                    If formaPago.Compvariable = dfielddefConstantes.Si.ToString() Then
                        LimpiarEstructuras()

                        'NotaDebito.Limpiar_Datos_Comprobante(dgvNotaDebito, txtSubTotal, txtDescuento, txtIV, txtIVa105, ,txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante)
                        txtCodigoCliente.Text = ""
                        lblCodN.Visible = False
                    Else
                        If formaPago.Compvariable = dfielddefConstantes.No.ToString() Then
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
            MessageBox.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                 MessageBoxIcon.Information)
        End If
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim NotaDebito_Cuerpo_estructura(0)
        ReDim Numero_Comprobante(0)
        ReDim NotaDebito_Enc_estructura(0)
        ReDim Articulos_Estructura(0)
    End Sub
    Function BalanzaConectada(ByVal NumeroPuerto As Integer) As Boolean
        Dim Configuracion As New Controlador.Configuracion
        Dim puertos As New Collection
        Dim idx As Integer
        Dim encontre As Boolean
        Dim numeroP As Integer
        idx = 1
        encontre = False
        Configuracion.GetSerialPortNames(puertos)
        While idx <= puertos.Count And Not encontre
            Configuracion.ObtenerNumeroPuerto(puertos(idx), numeroP)
            If numeroP = NumeroPuerto Then
                encontre = True
            Else
                encontre = False
            End If
            idx = idx + 1
        End While
        BalanzaConectada = encontre
        Return BalanzaConectada
    End Function
    Private Sub ToolStripBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBuscar.Click
        Dim Facturacion As New Controlador.Facturacion()
        For x As Integer = ProgressBarFacturacion.Minimum To ProgressBarFacturacion.Maximum
            ProgressBarFacturacion.Value = x
        Next
        For x As Integer = ProgressBarFacturacion.Maximum To ProgressBarFacturacion.Minimum Step -1
            ProgressBarFacturacion.Value = x
        Next
        Facturacion.Compvariable = dfielddefConstantes.NotaDebito.ToString()
        Vista.BuscarComprobante.ShowDialog()
    End Sub
    Private Sub txtBusquedaArticulo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusquedaArticulo.KeyDown
        Dim consulta As String
        Dim articulo As New Controlador.Articulos()
        Dim Cliente As New Controlador.Cliente()
        Dim Empresa As New Controlador.Empresas()
        Dim NotaDebito As New Controlador.Facturacion()
        Dim UltimaFila As Integer
        Dim Numero_Condicion_IVA_Cliente As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim ObtenerTasa As Double
        Dim importe As Double
        Dim datos As New DataTable
        Dim Datos_Configuracion As New DataTable
        Dim datos_Lita_Precio As New DataTable
        Dim Configuracion As New Controlador.Configuracion
        Dim Lista_Precio As New Controlador.Lista_Precios
        Try
            If Not (articulo.es_Numero(txtBusquedaArticulo.Text)) Then
                txtBusquedaArticulo.Text = String.Empty
            ElseIf e.KeyCode = Keys.Enter Then
                If txtCodigoCliente.Text <> String.Empty Then
                    consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIVA.Text) & "' "
                    ' Cliente.Obtener_CondicionFrenteAIVa(consulta, Numero_Condicion_IVA_Cliente)
                    consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                    Empresa.Obtener_Responsabilidad_IVA_Empresa(consulta, Numero_Condicion_IVA_Empresa)

                    consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                    consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                    consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                    consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                    consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                    consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                    consulta += " and TC.IdTipoComprobante in ('2','7','12')"

                    'NotaDebito.Obtener_Datos_Comprobante(consulta, datos)
                    tipoComprobante = datos.Rows(0).Item("Descripcion")

                    consulta = "Select * from " + dfielddefConstantes.Configuracion.ToString() + ""
                    ' Configuracion.Obtener_Datos_Configuracion(consulta, Datos_Configuracion)
                    consulta = "Select * from " + dfielddefConstantes.Lista_Precio.ToString() + "  where Descripcion= '" + cbListaPrecio.Text + "'"
                    'Lista_Precio.recuperar_Datos(consulta, datos_Lita_Precio)

                    consulta = " select *" & vbCrLf
                    consulta += "from (Producto as P" & vbCrLf
                    consulta += "Inner join Producto_Lista_Precio as PLP on P.Id_Producto=PLP.Id_Producto)" & vbCrLf
                    consulta += "where PLP.Id_Lista_Precio='" + datos_Lita_Precio.Rows(0).Item(dfielddefListaPrecio.Id_Lista_Precio).ToString() + "'" & vbCrLf
                    consulta += "and P.Id_Producto='" & (txtBusquedaArticulo.Text) & "' or P.Codigo_Barras= '" & (txtBusquedaArticulo.Text) & "'" & vbCrLf

                    ' articulo.recuperar_Datos(consulta, datos)
                    If datos.Rows.Count > 0 Then
                        If txtBusquedaArticulo.Text <> "" Then
                            If tipoComprobante = "NOTA DE DEBITO B" Or tipoComprobante = "NOTA DE DEBITO C" Then 'preguntar si por defecto el ingreso es por codigo barras
                                Label19.Enabled = False
                                txtIVa.Enabled = False
                                If datos.Rows(0).Item(dfielddefArticuloListaPrecio.Pesable).ToString() = dfielddefConstantes.Si.ToString() Then 'cambiar por NO, se utiliza si el ingreso es por codigo barras
                                    'si es pesable obtener peso de balanza sino obtener cantidad de una ventana
                                    If IsNumeric(txtBalanza.Text) Then
                                        UltimaFila = dgvNotaDebito.Rows.Count - 1
                                        dgvNotaDebito.Rows.Add()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = Replace(txtBalanza.Text, ".", ",")
                                        dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
                                        importe = CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        txtBusquedaArticulo.Text = ""
                                        dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                    Else
                                        MessageBox.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        txtBusquedaArticulo.Text = ""
                                    End If
                                Else
                                    If (Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Lector_Codigo_Barras) = dfielddefConstantes.Si.ToString()) Then
                                        UltimaFila = dgvNotaDebito.Rows.Count - 1
                                        dgvNotaDebito.Rows.Add()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = 1
                                        dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
                                        importe = (dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        txtBusquedaArticulo.Text = ""
                                        dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                    Else
                                        Dim cantid As New Controlador.Cantidad()
                                        Dim FormCantidadad As New Vista.Cantidad()
                                        'cantid.CompDatos = datos
                                        cantid.CompDataGrid = dgvNotaDebito
                                        cantid.CompTipoComprobante = tipoComprobante
                                        FormCantidadad.ShowDialog()
                                        txtBusquedaArticulo.Text = ""
                                    End If
                                End If
                            Else
                                If tipoComprobante = "NOTA DE DEBITO A" Then 'preguntar si por defecto el ingreso es por codigo barras
                                    Label19.Enabled = True
                                    txtIVa.Enabled = True
                                    If datos.Rows(0).Item(dfielddefArticuloListaPrecio.Pesable).ToString() = dfielddefConstantes.Si.ToString() Then 'cambiar por NO, se utiliza si el ingreso es por codigo barras es por default
                                        'si es pesable obtener peso de balanza sino obtener cantidad de una ventana
                                        If IsNumeric(txtBalanza.Text) Then
                                            UltimaFila = dgvNotaDebito.Rows.Count - 1
                                            dgvNotaDebito.Rows.Add()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = Replace(txtBalanza.Text, ".", ",")
                                            NotaDebito.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                                            dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                                            importe = CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                            txtBusquedaArticulo.Text = ""
                                            dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                        Else
                                            MessageBox.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            txtBusquedaArticulo.Text = ""
                                        End If
                                    Else
                                        consulta = "Select * from " + dfielddefConstantes.Configuracion.ToString() + " "
                                        ' Configuracion.Obtener_Datos_Configuracion(consulta, Datos_Configuracion)
                                        If (Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Lector_Codigo_Barras) = dfielddefConstantes.Si.ToString()) Then
                                            UltimaFila = dgvNotaDebito.Rows.Count - 1
                                            dgvNotaDebito.Rows.Add()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = 1
                                            NotaDebito.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                                            dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                                            importe = (dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                            dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                            txtBusquedaArticulo.Text = ""
                                            dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                        Else
                                            Dim cantid As New Controlador.Cantidad()
                                            Dim FormCantidadad As New Vista.Cantidad()
                                            'cantid.CompDatos = datos
                                            cantid.CompDataGrid = dgvNotaDebito
                                            cantid.CompTipoComprobante = tipoComprobante
                                            FormCantidadad.ShowDialog()
                                            txtBusquedaArticulo.Text = ""
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If txtBusquedaArticulo.Text.Trim() <> "" Then
                            MessageBox.Show("El Articulo no pertenece a la lista de precio: " + cbListaPrecio.Text + " , agreguelo a la lista!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtBusquedaArticulo.Text = ""
                        End If
                    End If
                Else
                    MessageBox.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                             MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBusquedaArticulo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusquedaArticulo.Leave
        Dim consulta As String
        Dim articulo As New Controlador.Articulos()
        Dim Cliente As New Controlador.Cliente()
        Dim Empresa As New Controlador.Empresas()
        Dim NotaDebito As New Controlador.Facturacion()
        Dim UltimaFila As Integer
        Dim Numero_Condicion_IVA_Cliente As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim ObtenerTasa As Double
        Dim importe As Double
        Dim datos As New DataTable
        Dim Datos_Configuracion As New DataTable
        Dim datos_Lita_Precio As New DataTable
        Dim Configuracion As New Controlador.Configuracion
        Dim Lista_Precio As New Controlador.Lista_Precios
        Try

            If Not (articulo.es_Numero(txtBusquedaArticulo.Text)) Then
                txtBusquedaArticulo.Text = String.Empty

            ElseIf txtCodigoCliente.Text <> String.Empty Then
                consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIVA.Text) & "' "
                ' Cliente.Obtener_CondicionFrenteAIVa(consulta, Numero_Condicion_IVA_Cliente)
                consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                Empresa.Obtener_Responsabilidad_IVA_Empresa(consulta, Numero_Condicion_IVA_Empresa)

                consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                consulta += " and TC.IdTipoComprobante in ('2','7','12')"

                ' NotaDebito.Obtener_Datos_Comprobante(consulta, datos)
                tipoComprobante = datos.Rows(0).Item("Descripcion")
                consulta = "Select * from " + dfielddefConstantes.Configuracion.ToString() + ""
                'Configuracion.Obtener_Datos_Configuracion(consulta, Datos_Configuracion)
                consulta = "Select * from " + dfielddefConstantes.Lista_Precio.ToString() + "  where Descripcion= '" + cbListaPrecio.Text + "'"

                'Lista_Precio.recuperar_Datos(consulta, datos_Lita_Precio)

                consulta = " select *" & vbCrLf
                consulta += "from (Producto as P" & vbCrLf
                consulta += "Inner join Producto_Lista_Precio as PLP on P.Id_Producto=PLP.Id_Producto)" & vbCrLf
                consulta += "where PLP.Id_Lista_Precio='" + datos_Lita_Precio.Rows(0).Item(dfielddefListaPrecio.Id_Lista_Precio).ToString() + "'" & vbCrLf
                consulta += "and P.Id_Producto='" & (txtBusquedaArticulo.Text) & "' or P.Codigo_Barras= '" & (txtBusquedaArticulo.Text) & "'" & vbCrLf

                'articulo.recuperar_Datos(consulta, datos)
                If datos.Rows.Count > 0 Then
                    If txtBusquedaArticulo.Text <> "" Then
                        If tipoComprobante = "NOTA DE DEBITO B" Or tipoComprobante = "NOTA DE DEBITO C" Then 'preguntar si por defecto el ingreso es por codigo barras
                            Label19.Enabled = False
                            txtIVa.Enabled = False
                            If datos.Rows(0).Item(dfielddefArticuloListaPrecio.Pesable).ToString() = dfielddefConstantes.Si.ToString() Then 'cambiar por NO, se utiliza si el ingreso es por codigo barras
                                'si es pesable obtener peso de balanza sino obtener cantidad de una ventana
                                If IsNumeric(txtBalanza.Text) Then
                                    UltimaFila = dgvNotaDebito.Rows.Count - 1
                                    dgvNotaDebito.Rows.Add()
                                    dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                    dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                    dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                    dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = Replace(txtBalanza.Text, ".", ",")
                                    dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
                                    importe = CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                    dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                    txtBusquedaArticulo.Text = ""
                                    dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                Else
                                    MessageBox.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    txtBusquedaArticulo.Text = ""
                                End If
                            Else
                                If (Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Lector_Codigo_Barras) = dfielddefConstantes.Si.ToString()) Then
                                    UltimaFila = dgvNotaDebito.Rows.Count - 1
                                    dgvNotaDebito.Rows.Add()

                                    dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                    dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                    dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                    dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = 1
                                    dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString()
                                    importe = (dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                    dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                    txtBusquedaArticulo.Text = ""
                                    dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                Else
                                    Dim cantid As New Controlador.Cantidad()
                                    Dim FormCantidadad As New Vista.Cantidad()
                                    'cantid.CompDatos = datos
                                    cantid.CompDataGrid = dgvNotaDebito
                                    cantid.CompTipoComprobante = tipoComprobante
                                    FormCantidadad.ShowDialog()
                                    txtBusquedaArticulo.Text = ""
                                End If
                            End If
                        Else
                            If tipoComprobante = "NOTA DE DEBITO A" Then 'preguntar si por defecto el ingreso es por codigo barras
                                Label19.Enabled = True
                                txtIVa.Enabled = True
                                If datos.Rows(0).Item(dfielddefArticuloListaPrecio.Pesable).ToString() = dfielddefConstantes.Si.ToString() Then 'cambiar por NO, se utiliza si el ingreso es por codigo barras es por default
                                    'si es pesable obtener peso de balanza sino obtener cantidad de una ventana
                                    If IsNumeric(txtBalanza.Text) Then
                                        UltimaFila = dgvNotaDebito.Rows.Count - 1
                                        dgvNotaDebito.Rows.Add()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = Replace(txtBalanza.Text, ".", ",")
                                        NotaDebito.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                                        dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                                        importe = CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        txtBusquedaArticulo.Text = ""
                                        dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                    Else
                                        MessageBox.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        txtBusquedaArticulo.Text = ""
                                    End If
                                Else
                                    consulta = "Select * from " + dfielddefConstantes.Configuracion.ToString() + " "
                                    'Configuracion.Obtener_Datos_Configuracion(consulta, Datos_Configuracion)

                                    If (Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Lector_Codigo_Barras) = dfielddefConstantes.Si.ToString()) Then
                                        UltimaFila = dgvNotaDebito.Rows.Count - 1
                                        dgvNotaDebito.Rows.Add()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Tipo_Unidad").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Tipo_Unidad).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("IdArticulo").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Id_Producto).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Descripcion").Value = datos.Rows(0).Item(dfielddefArticuloListaPrecio.Descripcion).ToString()
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value = 1
                                        NotaDebito.obtenerTasa(datos.Rows(0).Item("Id_Tasa_IVA"), ObtenerTasa)
                                        dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(datos.Rows(0).Item(dfielddefArticuloListaPrecio.Precio_Venta).ToString() / ObtenerTasa, "##,##0.00")
                                        importe = (dgvNotaDebito.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvNotaDebito.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                        dgvNotaDebito.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        txtBusquedaArticulo.Text = ""
                                        dgvNotaDebito.CurrentCell = dgvNotaDebito.Rows(UltimaFila).Cells(0)
                                    Else
                                        Dim cantid As New Controlador.Cantidad()
                                        Dim FormCantidadad As New Vista.Cantidad()
                                        'cantid.CompDatos = datos
                                        cantid.CompDataGrid = dgvNotaDebito
                                        cantid.CompTipoComprobante = tipoComprobante
                                        FormCantidadad.ShowDialog()
                                        txtBusquedaArticulo.Text = ""
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    If txtBusquedaArticulo.Text.Trim() <> "" Then
                        MessageBox.Show("El Articulo no pertenece a la lista de precio: " + cbListaPrecio.Text + " , agreguelo a la lista!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtBusquedaArticulo.Text = ""
                    End If
                End If
            Else
                MessageBox.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBalanza_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBalanza.TextChanged
        Dim VentaRapida As New Controlador.Facturacion()
        If Not (VentaRapida.validateDoublesAndCurrency_Comprobante(txtBalanza.Text)) Then
            txtBalanza.Text = ""
        End If
    End Sub
    Private Sub agregarFilaInicial()
        dgvNotaDebito.Rows.Add()
    End Sub
End Class