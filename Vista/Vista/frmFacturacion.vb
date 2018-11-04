Imports Controlador
Imports System.IO.Ports
Imports DevComponents.DotNetBar
Public Class frmFacturacion

#Region "Declaration"
    Dim Responsabilidad_IVA_Empresa As String
    Public _Cant As Integer
    Dim Enviar(0) As Byte
    Dim dfielddefFactuEncabezado As Controlador.clsDfieldDef.eEncabezadoFactura
    Public Facturacion_Enc_estructura(0) As Controlador.clsFacturacion.eEncabezadoFactura
    Public Datos_Clientes As Controlador.clsCliente.eCliente
    Public Datos_Clientes_Cond_Frente_A_Iva As Controlador.clsCliente.eCondicion_Frente_Al_Iva
    Public Facturacion_Cuerpo_estructura(0) As Controlador.clsFacturacion.eCuerpoFactura
    Public Numero_Comprobante(0) As Controlador.clsNumeroComprobante.eNumeracionComprobante
    Public Articulos_Estructura(0) As Controlador.clsArticulos.eArticulo
    Public DatosFactura As Controlador.clsFacturacion.eDatosFactura
    Public Datos_Empresa As Controlador.clsEmpresas.eEmpresa
    Public Datos_Tipo_Comprobante As Controlador.clsFacturacion.eTipoComprobante
    Public Datos_Configuracion As Controlador.clsConfiguracion.eConfiguracion
    Public Datos_Configuracion_Balanza As Controlador.clsConfiguracion.eConfiguracion_Balanza
    Public Datos_Articulo As Controlador.clsArticulos.eArticulo
    Public DatosArticuloCuerpoDocumento As Controlador.clsArticulos.eArticuloCuerpoDocumento
    Public datos_Lista_Precio As Controlador.clsLista_Precios.eListaPrecio
    Public ListCuerpoFactura As New List(Of Controlador.clsArticulos.eArticuloCuerpoDocumento)
    Dim dfielddefArticuloListaPrecio As Controlador.clsDfieldDef.eArticuloCuerpoDocumento
    Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Dim dfielddefConfiguracion As Controlador.clsDfieldDef.eConfiguracion
    Dim dfielddefListaPrecio As Controlador.clsDfieldDef.eListaPrecio
    Dim dfielddefCliente As Controlador.clsDfieldDef.eCliente
    Dim dfielddecNumeroComprobantea As Controlador.clsDfieldDef.eNumeroComprobante
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Public estTasaIVA(0) As Controlador.clsTasaIVA.eTasaIVA
    Public session As New Controlador.clsSession()
    Private CodigoCliente As String
    Dim clsEmpresa As New Controlador.clsEmpresas()
    Dim clsConfiguracion As New Controlador.clsConfiguracion
    Dim clsTasaIVA As New Controlador.clsTasaIVA()
    Dim clsLista_Precio As New Controlador.clsLista_Precios
    Dim clsfacturacion As New Controlador.clsFacturacion()
    Dim clsarticulo As New Controlador.clsArticulos()
    Dim clscliente As New Controlador.clsCliente
    Dim eNumero_Condicion_IVA_Cliente As Controlador.clsCliente.eCondicion_Frente_Al_Iva
    Dim eDatoTipoComprobante As Controlador.clsFacturacion.eTipoComprobante
    Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante
    Dim clsformaPago As New Controlador.clsFormasDePago
    Dim clscantidad As New Controlador.clsCantidad()
    Dim eNotaCredito_Enc_estructura(0) As Controlador.clsFacturacion.eEncabezadoFactura
    Dim eNotaCredito_Cuerpo_estructura(0) As Controlador.clsFacturacion.eCuerpoFactura

    Dim dfielddefCuerpoFact As Controlador.clsDfieldDef.eCuerpoFactura
    Dim clsTransaccion As New Controlador.clsTransacciones


    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Dim tran As New Collection
    
#End Region

#Region "Constructor"



    Private Sub Facturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim puerto As Integer
        Dim setting As String
        Try
            clsConfiguracion.Obtener_Datos_Configuracion(Datos_Configuracion)
            clsConfiguracion.Obtener_Datos_Configuracion_Balanza(Datos_Configuracion_Balanza, Datos_Configuracion.Nombre_Balanza)
            OcultarTasasIVA()
            puerto = Convert.ToInt32(Datos_Configuracion.Nro_Puerto)
            If BalanzaConectada(puerto) And Datos_Configuracion_Balanza.Modelo <> String.Empty Then

                AxMSComm2.CommPort = puerto 'Convert.ToInt32(Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Numero_Puerto)) '.6 'pasar un parametro para el puerto com
                AxMSComm2.PortOpen = True                ' abrimos el puerto
                setting = Datos_Configuracion_Balanza.Velocidad + "," + Datos_Configuracion_Balanza.Paridad + "," + Datos_Configuracion_Balanza.Bits_por_Caracter + "," + Datos_Configuracion_Balanza.Bits_paro
                AxMSComm2.Settings = setting
                AxMSComm2.InputLen = Convert.ToInt32(Datos_Configuracion_Balanza.InputLen)
                AxMSComm2.RThreshold = Convert.ToInt32(Datos_Configuracion_Balanza.RThreshold)
                AxMSComm2.InBufferCount = Convert.ToInt32(Datos_Configuracion_Balanza.InBufferCount)
                Enviar(0) = Convert.ToInt32(Datos_Configuracion_Balanza.Bit_a_Enviar)                ' Peticion de transmision de Datos debo enviar dos veces 7
                AxMSComm2.Output = Enviar       ' para que la balanza repsonda con peso con indicador de estabilidad
                AxMSComm2.Output = Enviar
            End If
            clsEmpresa.Obtener_Datos_Empresa(clsEmpresa.Compvariable, Datos_Empresa)
            txtNroSucursal.Text = Datos_Empresa.Nro_Sucursal
            mtFecha.Text = Date.Now
            lblCodN.Visible = False
            LlenarListaPrecios()
            DeshabilitarBotonAnularComprobante()

        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

#Region "Event Form"
    Function BalanzaConectada(ByVal NumeroPuerto As Integer) As Boolean
        Dim puertos As New Collection
        Dim idx As Integer
        Dim encontre As Boolean
        Dim numeroP As Integer
        idx = 1
        encontre = False
        clsConfiguracion.GetSerialPortNames(puertos)
        While idx <= puertos.Count And Not encontre
            clsConfiguracion.ObtenerNumeroPuerto(puertos(idx), numeroP)
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

    Sub LlenarListaPrecios()
        clsConfiguracion.Obtener_Datos_Configuracion(Datos_Configuracion)
        clsLista_Precio.llenar_Combo_ListaPrecio(cbListaPrecio, "Id_Lista_Precio", "Descripcion")
        cbListaPrecio.Text = Datos_Configuracion.Lista_Precio
        datos_Lista_Precio.Id_Lista_Precio = Datos_Configuracion.Id_Lista_Precio
    End Sub

#End Region

#Region "Event Controls"
    Private Sub TxtPorcDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPorcDesc.TextChanged
        Dim importeTotal As Double
        Dim importeTotalNeto As Double
        Dim ImporteTotalSinDescuento As Double
        Dim consulta As String
        Dim dtdatosiva As New DataTable()
        Dim idx As Integer

        If (Datos_Clientes.Id_Cliente <> Nothing) Then
            consulta = "Select * " & vbCrLf
            consulta += "From Tasa_IVA"
            clsTasaIVA.recuperar_All_Datos(dtdatosiva)
            idx = 1
            ReDim estTasaIVA(0)
            For i As Integer = 0 To dtdatosiva.Rows.Count - 1
                ReDim Preserve estTasaIVA(idx)
                estTasaIVA(idx).Id_Tasa_IVA = dtdatosiva.Rows(i).Item("Id_Tasa_IVA")
                estTasaIVA(idx).Descripcion = dtdatosiva.Rows(i).Item("Descripcion")
                estTasaIVA(idx).Tasa = dtdatosiva.Rows(i).Item("Tasa")
                idx = idx + 1
            Next
            ReDim Preserve Facturacion_Enc_estructura(1)
            If TxtPorcDesc.Text = String.Empty Or (Not IsNumeric(TxtPorcDesc.Text)) Then
                TxtPorcDesc.Text = String.Empty
                Facturacion_Enc_estructura(1).PorcDescuentos = "0"
            Else
                Facturacion_Enc_estructura(1).PorcDescuentos = Replace(TxtPorcDesc.Text, ",", ".")
                If (Convert.ToDouble(Replace(Facturacion_Enc_estructura(1).PorcDescuentos, ",", ".")) > 99) Then
                    MessageBoxEx.Show("El Porcentaje de descuento, debe ser menor al 99%!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                    TxtPorcDesc.Text = String.Empty
                    Facturacion_Enc_estructura(1).PorcDescuentos = "0"
                End If
            End If

            If Facturacion_Enc_estructura(1).Neto_Grabado_21 <> Nothing Then
                txtIVA21.Text = Format(((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) - ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)) * estTasaIVA(1).Tasa / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).IVA_Facturado21 = Math.Round(((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) - ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)) * estTasaIVA(1).Tasa / 100), 3)
            End If
            If Facturacion_Enc_estructura(1).Neto_Grabado_105 <> Nothing Then
                txtIVA105.Text = Format(((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) - ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)) * estTasaIVA(2).Tasa / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).IVA_Facturado105 = Math.Round(((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) - ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)) * estTasaIVA(2).Tasa / 100), 3)
            End If
            If Facturacion_Enc_estructura(1).Neto_Grabado_27 <> Nothing Then
                txtIVA27.Text = Format(((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)) * estTasaIVA(3).Tasa / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).IVA_Facturado105 = Math.Round(((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)) * estTasaIVA(3).Tasa / 100), 3)
            End If
            If Datos_Tipo_Comprobante.Descripcion = "FACTURA A" Then
                importeTotal = Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27)
                txtDescuento.Text = Format(((importeTotal * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).Descuentos = Math.Round(((importeTotal * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100), 3)
                importeTotal = importeTotal - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos)
            Else
                importeTotalNeto = Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27)
                Facturacion_Enc_estructura(1).Descuentos = Math.Round(((importeTotalNeto * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100), 3)
                importeTotal = Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27 - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos))
                If (Facturacion_Enc_estructura(1).Neto_Grabado_21 <> String.Empty) Then
                    ImporteTotalSinDescuento = Math.Round(ImporteTotalSinDescuento + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + (Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) * estTasaIVA(1).Tasa) / 100) * (Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100), 2)
                End If
                If (Facturacion_Enc_estructura(1).Neto_Grabado_105 <> String.Empty) Then
                    ImporteTotalSinDescuento = Math.Round(ImporteTotalSinDescuento + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + (Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) * estTasaIVA(2).Tasa) / 100) * (Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100), 2)
                End If
                If (Facturacion_Enc_estructura(1).Neto_Grabado_27 <> String.Empty) Then
                    ImporteTotalSinDescuento = Math.Round(ImporteTotalSinDescuento + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) + (Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) * estTasaIVA(3).Tasa) / 100) * (Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100), 2)
                End If
                txtDescuento.Text = Format(ImporteTotalSinDescuento, "##,##0.00")
            End If
            Facturacion_Enc_estructura(1).Sub_Total = Math.Round(importeTotal, 3)
            TxtSubTotal.Text = Format(importeTotal, "##,##0.00")
            txtTotal.Text = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), "##,##0.00")
            Facturacion_Enc_estructura(1).Total = Math.Round(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), 3)

        End If
    End Sub
    Private Sub txtBalanza_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBalanza.TextChanged
        If Not (clsfacturacion.validateDoublesAndCurrency_Comprobante(txtBalanza.Text)) Then
            txtBalanza.Text = String.Empty
        End If
    End Sub
    Private Sub txtBusquedaArticulo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusquedaArticulo.KeyDown
        If Not (clsarticulo.es_Numero(txtBusquedaArticulo.Text)) Then
            txtBusquedaArticulo.Text = String.Empty

        ElseIf e.KeyCode = Keys.Enter Then
            clsarticulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString()
            Datos_Articulo.Id_Producto = txtBusquedaArticulo.Text.Trim()
            cargarArticulos()
            txtBusquedaArticulo.Text = String.Empty
        End If
    End Sub
    Private Sub ToolStripBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBuscar.Click
        Dim idx As Integer
        For x As Integer = ProgressBarFacturacion.Minimum To ProgressBarFacturacion.Maximum
            ProgressBarFacturacion.Value = x
        Next
        For x As Integer = ProgressBarFacturacion.Maximum To ProgressBarFacturacion.Minimum Step -1
            ProgressBarFacturacion.Value = x
        Next

        clsfacturacion.Compvariable = dfielddefConstantes.FACTURA.ToString()
        Vista.frmBuscarComprobante.ShowDialog()
        If clsarticulo.busquedaComprobante = dfielddefConstantes.BuscarComprobante.ToString() Then
            If clsfacturacion.ComplistOfCodProd.Count > 0 Then
                txtCodigoCliente.Text = String.Empty
                txtCodigoCliente.Text = clscliente.CompCodigo
                TxtPorcDesc.Text = clsfacturacion.CompPorcDescuentos
                HabilitarBotonAnularComprobante()
                If dgvFacturacion.Rows.Count - 1 >= 1 Then
                    clsfacturacion.Limpiar_Importes_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal)
                    LimpiarEstructuras()
                    agregarFilaInicial()
                End If
                For idx = 0 To clsfacturacion.ComplistOfCodProd.Count - 1
                    txtBusquedaArticulo.Text = clsfacturacion.ComplistOfCodProd(idx)
                Next

            End If
        End If

    End Sub
    Private Sub ToolStripRegistrarFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRegistrarFactura.Click
        Dim consulta As String
        Dim dtdatosDataTable As New DataTable
        Dim tipocomprobante As String
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim dtArticulos As New DataTable
        Dim i As Integer
        Dim dtdatosComprobante As New DataTable
        Dim IdTipoComprobante As Integer

        For x As Integer = ProgressBarFacturacion.Minimum To ProgressBarFacturacion.Maximum
            ProgressBarFacturacion.Value = x
        Next
        For x As Integer = ProgressBarFacturacion.Maximum To ProgressBarFacturacion.Minimum Step -1
            ProgressBarFacturacion.Value = x
        Next
        If txtCodigoCliente.Text <> String.Empty Then
            If Convert.ToDouble(txtNeto.Text) > 0 Then
                ReDim Preserve Facturacion_Enc_estructura(1)
                Facturacion_Enc_estructura(1).Punto_Venta = txtNroSucursal.Text.Trim()
                Facturacion_Enc_estructura(1).Tipo_Comprobante = lblIdComprobante.Text.Trim()
                Facturacion_Enc_estructura(1).Numero_Comprobante = txtnumeroComprobante.Text.Trim()
                Facturacion_Enc_estructura(1).Numero_Cliente = Convert.ToInt32(txtCodigoCliente.Text)
                Facturacion_Enc_estructura(1).Nombre = txtNombre.Text.Trim()
                Facturacion_Enc_estructura(1).Apellido = txtApellido.Text.Trim()
                Facturacion_Enc_estructura(1).Situacion_Frente_A_IVA = txtCondIVA.Text.Trim()
                Facturacion_Enc_estructura(1).Forma_Pago = ""
                Facturacion_Enc_estructura(1).Fecha_Comprobante = mtFecha.Text.Trim()
                Facturacion_Enc_estructura(1).Codigo_Vendedor = 1


                If (Facturacion_Enc_estructura(1).Neto_Grabado_21 <> Nothing) Then
                    Facturacion_Enc_estructura(1).Neto_Grabado_21 = Facturacion_Enc_estructura(1).Neto_Grabado_21
                Else
                    Facturacion_Enc_estructura(1).Neto_Grabado_21 = "0"
                End If
                If (Facturacion_Enc_estructura(1).Neto_Grabado_105 <> Nothing) Then
                    Facturacion_Enc_estructura(1).Neto_Grabado_105 = Facturacion_Enc_estructura(1).Neto_Grabado_105
                Else
                    Facturacion_Enc_estructura(1).Neto_Grabado_105 = "0"
                End If
                If (Facturacion_Enc_estructura(1).Neto_Grabado_27 <> Nothing) Then
                    Facturacion_Enc_estructura(1).Neto_Grabado_27 = Facturacion_Enc_estructura(1).Neto_Grabado_27
                Else
                    Facturacion_Enc_estructura(1).Neto_Grabado_27 = "0"
                End If

                Facturacion_Enc_estructura(1).Conc_No_Grabado = ""
                Facturacion_Enc_estructura(1).Exentos = ""

                If (Facturacion_Enc_estructura(1).IVA_Facturado21 <> Nothing) Then
                    Facturacion_Enc_estructura(1).IVA_Facturado21 = Facturacion_Enc_estructura(1).IVA_Facturado21
                Else
                    Facturacion_Enc_estructura(1).IVA_Facturado21 = "0"
                End If
                If (Facturacion_Enc_estructura(1).IVA_Facturado27 <> Nothing) Then
                    Facturacion_Enc_estructura(1).IVA_Facturado27 = Facturacion_Enc_estructura(1).IVA_Facturado27
                Else
                    Facturacion_Enc_estructura(1).IVA_Facturado27 = "0"
                End If
                If (Facturacion_Enc_estructura(1).IVA_Facturado105 <> Nothing) Then
                    Facturacion_Enc_estructura(1).IVA_Facturado105 = Facturacion_Enc_estructura(1).IVA_Facturado105
                Else
                    Facturacion_Enc_estructura(1).IVA_Facturado105 = "0"
                End If

                If (Facturacion_Enc_estructura(1).PorcDescuentos <> Nothing) Then
                    Facturacion_Enc_estructura(1).PorcDescuentos = Facturacion_Enc_estructura(1).PorcDescuentos
                Else
                    Facturacion_Enc_estructura(1).PorcDescuentos = "0"
                End If

                Facturacion_Enc_estructura(1).IVA_Resp_No_Inscripto = ""
                Facturacion_Enc_estructura(1).Persepciones = ""
                If txtDescuento.Text.Trim() <> String.Empty Then
                    Facturacion_Enc_estructura(1).Descuentos = Replace(txtDescuento.Text.Trim(), ".", ",")
                Else
                    Facturacion_Enc_estructura(1).Descuentos = "0"
                End If
                Facturacion_Enc_estructura(1).Retenciones = ""
                Facturacion_Enc_estructura(1).Total = txtTotal.Text.Trim()
                Facturacion_Enc_estructura(1).Cancelado = dfielddefConstantes.No.ToString()
                Facturacion_Enc_estructura(1).Signo = "1"
                Facturacion_Enc_estructura(1).NroPuesto = session.Session.NroPuesto
                clscliente.Obtener_CondicionFrenteAIVa(txtCondIVA.Text, eNumero_Condicion_IVA_Cliente)
                clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)
                clsfacturacion.Obtener_Datos_Comprobante(eNumero_Condicion_IVA_Cliente.Id_Condicion_IVA, Numero_Condicion_IVA_Empresa, dfielddefConstantes.FACTURA.ToString(), eDatoTipoComprobante)
                tipocomprobante = eDatoTipoComprobante.Descripcion
                IdTipoComprobante = Convert.ToInt32(eDatoTipoComprobante.IdTipoComprobante)
                Facturacion_Enc_estructura(1).Comprobante = tipocomprobante
                clsNumeroComprobante.obtener_Datos_Numero_Comprobante_Empresa_TipoComprobante(clsEmpresa.Compvariable, Convert.ToString(IdTipoComprobante), dtdatosDataTable)
                ReDim Numero_Comprobante(1)
                Numero_Comprobante(1).Id_Comprobante = dtdatosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Id_Comprobante)
                Numero_Comprobante(1).Descripcion = dtdatosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Descripcion)
                Numero_Comprobante(1).Numeracion = txtnumeroComprobante.Text.Trim()
                Numero_Comprobante(1).Id_Empresa = dtdatosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Id_Empresa)
                Numero_Comprobante(1).Id_Tipo_Comprobante = dtdatosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Id_Tipo_Comprobante)

                i = 1

                While i <= ListCuerpoFactura.Count()
                    If dgvFacturacion.Rows(i - 1).Cells("Tipo_Unidad").Value <> String.Empty Then
                        ReDim Preserve Facturacion_Cuerpo_estructura(i)
                        ReDim Preserve Articulos_Estructura(i)

                        Facturacion_Cuerpo_estructura(i).Punto_Venta = txtNroSucursal.Text.Trim()
                        Facturacion_Cuerpo_estructura(i).Tipo_Comprobante = lblIdComprobante.Text.Trim()
                        Facturacion_Cuerpo_estructura(i).Numero_Comprobante = txtnumeroComprobante.Text.Trim()
                        Facturacion_Cuerpo_estructura(i).Comprobante = tipocomprobante
                        Facturacion_Cuerpo_estructura(i).Numero_Articulo = dgvFacturacion.Rows(i - 1).Cells("IdArticulo").Value
                        Facturacion_Cuerpo_estructura(i).Descripcion = dgvFacturacion.Rows(i - 1).Cells("Descripcion").Value
                        Facturacion_Cuerpo_estructura(i).Cantidad = dgvFacturacion.Rows(i - 1).Cells("Cantidad").Value
                        Facturacion_Cuerpo_estructura(i).Precio_Unitario = dgvFacturacion.Rows(i - 1).Cells("PrecioUnitario").Value
                        Facturacion_Cuerpo_estructura(i).Signo = "1"
                        Facturacion_Cuerpo_estructura(i).NroPuesto = session.Session.NroPuesto
                        clsarticulo.ObtenerProductos(Facturacion_Cuerpo_estructura(i).Numero_Articulo, dtArticulos)
                        Articulos_Estructura(i).Id_Producto = Facturacion_Cuerpo_estructura(i).Numero_Articulo
                        Articulos_Estructura(i).Stock = dtArticulos.Rows(0).Item("Stock") ''''VER
                    End If
                    i = i + 1
                End While
                Try

                    Dim FPP As New frmFormasDePago(Facturacion_Enc_estructura, Facturacion_Cuerpo_estructura, Articulos_Estructura, Numero_Comprobante)
                    clsformaPago.Compvariable = dfielddefConstantes.FACTURA.ToString()
                    FPP.ShowDialog()
                    If clsformaPago.Compvariable = dfielddefConstantes.Si.ToString() Then
                        LimpiarEstructuras()
                        clsfacturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
                        txtCodigoCliente.Text = String.Empty
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
                MessageBoxEx.Show("No se han cargado productos!!", "Informacion", MessageBoxButtons.OK, _
                                                 MessageBoxIcon.Information)
            End If

        Else
            MessageBoxEx.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                 MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try

            If AxMSComm2.PortOpen = True And Datos_Configuracion_Balanza.Modelo <> String.Empty Then
                Enviar(0) = Datos_Configuracion_Balanza.Bit_a_Enviar                ' Peticion de transmision de Datos debo enviar dos veces 7
                AxMSComm2.Output = Enviar       ' para que la balanza repsonda con peso con indicador de estabilidad
                AxMSComm2.Output = Enviar

            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            If AxMSComm2.PortOpen = True And Datos_Configuracion_Balanza.Modelo <> String.Empty Then
                AxMSComm2.InputLen = Convert.ToInt32(Datos_Configuracion_Balanza.InputLen)
                AxMSComm2.InBufferCount = Convert.ToInt32(Datos_Configuracion_Balanza.InBufferCount)
            End If

        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub AxMSComm2_OnComm(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxMSComm2.OnComm
        Dim Temp As String
        Dim primeraparte As Integer
        Dim segundaparte As Integer
        Try
            If AxMSComm2.CommEvent = 2 Then ' controla que la interrupcion del puerto sea por recepcion de datos

                Temp = AxMSComm2.Input

                ' y los Carga en una variable llamada temp
                'Mid(Temp, 1, 3)
                txtBalanza.Text = Mid(Temp, 1, 3) & "," & Mid(Temp, 4, 3)  ' aqui sumamos los tres primeros bytes a una coma y los tres bytes siguientes
                'primeraparte = Convert.ToInt32(Datos_Configuracion_Balanza.Bit_a_Enviar) / 2
                'segundaparte = Convert.ToInt32(Datos_Configuracion_Balanza.Bit_a_Enviar) - primeraparte
                'txtBalanza.Text = Mid(Temp, 1, primeraparte) & "," & Mid(Temp, segundaparte, 3)  ' aqui sumamos los tres primeros bytes a una coma y los tres bytes siguientes

                'If Mid(Temp, 7, 1) = "e" Then           ' analizamos el 7 byte para ver si es estable o inestable
                If Mid(Temp, Convert.ToInt32(Datos_Configuracion_Balanza.Bit_a_Enviar), 1) = Datos_Configuracion_Balanza.Caracter_Peso_Estable Then           ' analizamos el 7 byte para ver si es estable o inestable
                    Estable.Text = "Peso Estable"    ' el peso esta inestable
                    Estable.BackColor = Color.GreenYellow
                End If

                'If Mid(Temp, 7, 1) = "i" Then
                If Mid(Temp, Convert.ToInt32(Datos_Configuracion_Balanza.Bit_a_Enviar), 1) = Datos_Configuracion_Balanza.Caracter_Peso_Inestable Then ' analizamos el 7 byte para ver si es estable o inestable
                    Estable.Text = "Peso Inestable"  ' el peso esta inestable
                    Estable.BackColor = Color.Red
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
                    MessageBoxEx.Show("La fecha " + mtFecha.Text + " , no tiene un formato Correcto!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    mtFecha.Text = ""
                    mtFecha.Focus()

            End Select
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvFacturacion_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvFacturacion.CellFormatting
        Dim totalImporte As Double
        Try

            If ListCuerpoFactura.Any() Then
                totalImporte = ListCuerpoFactura.Sum(Function(item) item.Importe)
                txtNeto.Text = Format(totalImporte, "##,##0.00")

                If totalImporte = 0.0 Then
                    txtIVA21.Text = Format(0.0, "##,##0.00")
                    txtIVA105.Text = Format(0.0, "##,##0.00")
                    txtIVA27.Text = Format(0.0, "##,##0.00")
                End If
            Else
                totalImporte = ListCuerpoFactura.Sum(Function(item) item.Importe)
                txtNeto.Text = Format(totalImporte, "##,##0.00")

                If totalImporte = 0.0 Then
                    txtIVA21.Text = Format(0.0, "##,##0.00")
                    txtIVA105.Text = Format(0.0, "##,##0.00")
                    txtIVA27.Text = Format(0.0, "##,##0.00")
                End If

            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBusquedaArticulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBusquedaArticulo.TextChanged

        If (clsarticulo.CompvariableCargarArticulo = dfielddefConstantes.Si.ToString()) Then

            cargarArticulos()
            txtBusquedaArticulo.Text = String.Empty

        Else
            If (clsarticulo.busquedaComprobante = dfielddefConstantes.BuscarComprobante.ToString()) Then
                Datos_Articulo.Id_Producto = txtBusquedaArticulo.Text.Trim()
                cargarArticulos()
                clsarticulo.busquedaComprobante = String.Empty
                txtBusquedaArticulo.Text = String.Empty

            End If
        End If
    End Sub
    Private Sub pbBuscarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBuscarArticulo.Click
        Try
            If Datos_Clientes.Id_Cliente <> Nothing Then
                clsarticulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString()
                clsarticulo.CompvariableCargarArticulo = dfielddefConstantes.Si.ToString()

                frmArticulos.ShowDialog()
                If clsfacturacion.FacturacionCodArticulo <> String.Empty Then
                    Datos_Articulo.Id_Producto = clsfacturacion.FacturacionCodArticulo.ToString()
                    clsarticulo.CompId_Articulo = Nothing
                    clsfacturacion.FacturacionCodArticulo = Nothing
                    txtBusquedaArticulo.Text = Datos_Articulo.Id_Producto
                Else
                    clsarticulo.CompId_Articulo = Nothing
                    clsfacturacion.FacturacionCodArticulo = Nothing
                End If

                AxMSComm2.InputLen = Convert.ToInt32(Datos_Configuracion_Balanza.InputLen)
                AxMSComm2.InBufferCount = Convert.ToInt32(Datos_Configuracion_Balanza.InBufferCount)
            Else
                MessageBoxEx.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Dim tipoComprobante As String
        Dim IDTipoComprobante As Integer
        Dim numeroComp As String
        Dim nuComprobante As Integer
        Dim existe As Boolean
        Try
            If Not (clscliente.es_Numero(txtCodigoCliente.Text)) Then
                txtCodigoCliente.Text = String.Empty
                Datos_Clientes.Id_Cliente = Nothing
                clsfacturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
            ElseIf txtCodigoCliente.Text <> String.Empty Then

                clsEmpresa.Obtener_Datos_Empresa(clsEmpresa.Compvariable, Datos_Empresa)
                CargarDatosCliente(Convert.ToInt32(txtCodigoCliente.Text), Datos_Clientes)
                clscliente.Validar_Cliente(Datos_Clientes.Id_Cliente, existe)
                If existe Then
                    Me.lblCodN.Visible = True
                    clsfacturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
                    txtNombre.Text = Datos_Clientes.Nombre
                    txtApellido.Text = Datos_Clientes.Apellido
                    txtDireccion.Text = Datos_Clientes.Calle + " " + Datos_Clientes.Piso + " " + Datos_Clientes.Nro
                    txtCelular.Text = Datos_Clientes.Celular
                    txtTelefono.Text = Datos_Clientes.Telefono
                    txtCondIVA.Text = Datos_Clientes.Responsabilidad_IVA
                    txtMail.Text = Datos_Clientes.E_Mail
                    txtLimiteCC.Text = Datos_Clientes.Saldo_CC
                    clscliente.Obtener_CondicionFrenteAIVa(Datos_Clientes.Responsabilidad_IVA, Datos_Clientes_Cond_Frente_A_Iva)
                    clsfacturacion.Obtener_Datos_Comprobante(Datos_Clientes_Cond_Frente_A_Iva.Id_Condicion_IVA, Datos_Empresa.Id_Responsabilidad_IVA, dfielddefConstantes.FACTURA.ToString(), Datos_Tipo_Comprobante)
                    tipoComprobante = Datos_Tipo_Comprobante.Descripcion
                    IDTipoComprobante = Convert.ToInt32(Datos_Tipo_Comprobante.IdTipoComprobante)
                    lblTipoComprobante.Text = tipoComprobante
                    lblIdComprobante.Text = Convert.ToString(IDTipoComprobante).PadLeft(2, "0")

                    txtNroSucursal.Text = Datos_Empresa.Nro_Sucursal
                    Responsabilidad_IVA_Empresa = Datos_Empresa.Responsabilidad_IVA

                    If clsarticulo.busquedaComprobante <> dfielddefConstantes.BuscarComprobante.ToString() Then
                        clsNumeroComprobante.obtener_Numero_Comprobante(clsEmpresa.Compvariable, IDTipoComprobante, numeroComp)
                        nuComprobante = Convert.ToInt32(numeroComp) + 1
                        clsNumeroComprobante.Aumentar_Numeracion_Comprobante(nuComprobante, numeroComp)
                    Else
                        numeroComp = clsfacturacion.CompNumero_Comprobante

                    End If
                    txtnumeroComprobante.Text = numeroComp

                    InicializarEstructuras()
                    LimpiarEstructuras()

                    If tipoComprobante = "FACTURA A" Then ' muestra o no el total iva
                        MostrarTasasIVA()
                    Else
                        OcultarTasasIVA()
                    End If
                    If dgvFacturacion.Rows.Count = 0 Then
                        agregarFilaInicial()
                    End If
                Else
                    MessageBoxEx.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                    LimpiarEstructuras()
                    clsfacturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
                    txtCodigoCliente.Text = String.Empty
                    lblCodN.Visible = False
                End If
            End If

        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub pbBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBuscarCliente.Click
        Try
            clscliente.Compvariable = dfielddefConstantes.FACTURA.ToString()
            frmClientes.ShowDialog()
            txtCodigoCliente.Text = clscliente.CompCodigo
            clscliente.CompCodigo = Nothing
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvFacturacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFacturacion.CellContentClick
        Dim filaseleccionada As Integer
        Dim ObtenerTasa As Double
        Dim importe As Double
        Dim importetotal As Double
        Dim descuento As Double
        Dim descuentoCalculado21 As Double
        Dim descuentoCalculado105 As Double
        Dim descuentoCalculado27 As Double
        Dim consulta As String
        Dim dtdatosiva As New DataTable()
        Dim idx As Integer
        Try
            filaseleccionada = Convert.ToInt32(dgvFacturacion.CurrentRow.Index.ToString())
            Dim result As Integer = MessageBoxEx.Show("Desea Eliminar el Articulo: " + CStr(dgvFacturacion.Rows(filaseleccionada).Cells(2).Value), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.Yes Then
                If ListCuerpoFactura.Any() Then
                    clsTasaIVA.recuperar_All_Datos(dtdatosiva)
                    idx = 1
                    ReDim estTasaIVA(0)
                    For i As Integer = 0 To dtdatosiva.Rows.Count - 1
                        ReDim Preserve estTasaIVA(idx)
                        estTasaIVA(idx).Id_Tasa_IVA = dtdatosiva.Rows(i).Item("Id_Tasa_IVA")
                        estTasaIVA(idx).Descripcion = dtdatosiva.Rows(i).Item("Descripcion")
                        estTasaIVA(idx).Tasa = dtdatosiva.Rows(i).Item("Tasa")
                        idx = idx + 1
                    Next

                    If Datos_Tipo_Comprobante.Descripcion = "FACTURA B" Or Datos_Tipo_Comprobante.Descripcion = "FACTURA C" Then
                        clsfacturacion.obtenerTasa(ListCuerpoFactura(filaseleccionada).TasaIVa, ObtenerTasa)
                        importe = Convert.ToDouble(ListCuerpoFactura(filaseleccionada).Importe)
                        If Facturacion_Enc_estructura(1).PorcDescuentos <> Nothing Then
                            descuento = ((importe * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)
                        End If

                        If Convert.ToInt32(ListCuerpoFactura(filaseleccionada).IdTasaIVa) = 1 Then
                            Facturacion_Enc_estructura(1).Neto_Grabado_21 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) - (importe / ObtenerTasa), "##,##0.00")
                            Facturacion_Enc_estructura(1).IVA_Facturado21 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) - ((((importe - descuento) / ObtenerTasa) * ListCuerpoFactura(filaseleccionada).TasaIVa) / 100), "##,##0.00")

                        End If
                        If Convert.ToInt32(ListCuerpoFactura(filaseleccionada).IdTasaIVa) = 2 Then
                            Facturacion_Enc_estructura(1).Neto_Grabado_105 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) - (importe / ObtenerTasa), "##,##0.00")
                            Facturacion_Enc_estructura(1).IVA_Facturado105 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) - ((((importe - descuento) / ObtenerTasa) * ListCuerpoFactura(filaseleccionada).TasaIVa) / 100), " ##,##0.00")

                        End If
                        If Convert.ToInt32(ListCuerpoFactura(filaseleccionada).IdTasaIVa) = 3 Then
                            Facturacion_Enc_estructura(1).Neto_Grabado_27 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - (importe / ObtenerTasa), "##,##0.00")
                            Facturacion_Enc_estructura(1).IVA_Facturado27 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27) - ((((importe - descuento) / ObtenerTasa) * ListCuerpoFactura(filaseleccionada).TasaIVa) / 100), " ##,##0.00")

                        End If
                        descuentoCalculado21 = ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) * estTasaIVA(1).Tasa) / 100)) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos) / 100)
                        descuentoCalculado105 = ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) * estTasaIVA(2).Tasa) / 100)) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos) / 100)
                        descuentoCalculado27 = ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) * estTasaIVA(3).Tasa) / 100)) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos) / 100)
                    Else

                        If Datos_Tipo_Comprobante.Descripcion = "FACTURA A" Then
                            importe = Convert.ToDouble(ListCuerpoFactura(filaseleccionada).Importe)
                            If Facturacion_Enc_estructura(1).PorcDescuentos <> Nothing Then
                                descuento = ((importe * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)
                            End If

                            If Convert.ToInt32(ListCuerpoFactura(filaseleccionada).IdTasaIVa) = 1 Then
                                Facturacion_Enc_estructura(1).Neto_Grabado_21 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) - importe, "##,##0.00")
                                Facturacion_Enc_estructura(1).IVA_Facturado21 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) - (((importe - descuento) * ListCuerpoFactura(filaseleccionada).TasaIVa) / 100), "##,##0.00")
                            End If
                            If Convert.ToInt32(ListCuerpoFactura(filaseleccionada).IdTasaIVa) = 2 Then
                                Facturacion_Enc_estructura(1).Neto_Grabado_105 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) - importe, "##,##0.00")
                                Facturacion_Enc_estructura(1).IVA_Facturado105 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) - (((importe - descuento) * ListCuerpoFactura(filaseleccionada).TasaIVa) / 100), "##,##0.00")
                            End If
                            If Convert.ToInt32(ListCuerpoFactura(filaseleccionada).IdTasaIVa) = 3 Then
                                Facturacion_Enc_estructura(1).Neto_Grabado_27 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - importe, "##,##0.00")
                                Facturacion_Enc_estructura(1).IVA_Facturado27 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27) - (((importe - descuento) * ListCuerpoFactura(filaseleccionada).TasaIVa) / 100), "##,##0.00")
                            End If
                        End If
                    End If

                    If Datos_Tipo_Comprobante.Descripcion = "FACTURA A" Then
                        Facturacion_Enc_estructura(1).Descuentos = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) - (descuento), "##,##0.00")
                        importetotal = Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos)
                        txtDescuento.Text = Format(Facturacion_Enc_estructura(1).Descuentos, "##,##0.00")
                    Else
                        Facturacion_Enc_estructura(1).Descuentos = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) - (descuento / ObtenerTasa), "##,##0.00")
                        importetotal = Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos)
                        txtDescuento.Text = Format(descuentoCalculado21 + descuentoCalculado105 + descuentoCalculado27, "##,##0.00")
                    End If
                    Facturacion_Enc_estructura(1).Sub_Total = Format(importetotal, "##,##0.00")
                    Facturacion_Enc_estructura(1).Total = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), "##,##0.00")

                    TxtSubTotal.Text = Facturacion_Enc_estructura(1).Sub_Total
                    txtTotal.Text = Facturacion_Enc_estructura(1).Total
                    txtIVA21.Text = Facturacion_Enc_estructura(1).IVA_Facturado21
                    txtIVA105.Text = Facturacion_Enc_estructura(1).IVA_Facturado105
                    txtIVA27.Text = Facturacion_Enc_estructura(1).IVA_Facturado27
                    dgvFacturacion.Rows.Remove(dgvFacturacion.CurrentRow)
                    ListCuerpoFactura.RemoveAt(filaseleccionada)

                    txtTotal.Text = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), "##,##0.00")
                    Facturacion_Enc_estructura(1).Total = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), "##,##0.00")
                End If
            End If
            If dgvFacturacion.Rows.Count = 0 Then
                agregarFilaInicial()
            End If
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
        DeshabilitarBotonAnularComprobante()
        Me.Close()
    End Sub
#End Region

#Region "Private Methods"

    Private Sub MostrarTasasIVA()
        gb21.Visible = True
        gb105.Visible = True
        gb27.Visible = True
    End Sub
    Private Sub OcultarTasasIVA()
        gb21.Visible = False
        gb105.Visible = False
        gb27.Visible = False
    End Sub
    Private Sub agregarFilaInicial()
        dgvFacturacion.Rows.Add()
    End Sub
    Private Sub LimpiarEstructuras()
        ReDim Facturacion_Enc_estructura(0)
        ReDim Numero_Comprobante(0)
        ReDim Facturacion_Cuerpo_estructura(0)
        ReDim Articulos_Estructura(0)
        ReDim estTasaIVA(0)
        ListCuerpoFactura.Clear()

    End Sub
    Private Sub cargarArticulos()
        Dim UltimaFila As Integer
        Dim ObtenerTasa As Double
        Dim importe As Double
        Try

            If Not (clsarticulo.es_Numero(Datos_Clientes.Id_Cliente.ToString())) Then
                txtCodigoCliente.Text = String.Empty
            ElseIf clsarticulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString() Then
                clsarticulo.Compvariable = String.Empty
                If Datos_Clientes.Id_Cliente <> Nothing Then
                    datos_Lista_Precio.Id_Lista_Precio = cbListaPrecio.SelectedValue.ToString()
                    clsarticulo.recuperar_Datos(datos_Lista_Precio.Id_Lista_Precio, Datos_Articulo.Id_Producto, DatosArticuloCuerpoDocumento)
                    If DatosArticuloCuerpoDocumento.IdProducto <> Nothing Then

                        If Datos_Articulo.Id_Producto <> Nothing Then
                            If Datos_Tipo_Comprobante.Descripcion = "FACTURA B" Or Datos_Tipo_Comprobante.Descripcion = "FACTURA C" Then
                                If DatosArticuloCuerpoDocumento.Pesable = dfielddefConstantes.Si.ToString() Then
                                    If IsNumeric(txtBalanza.Text) Then
                                        UltimaFila = dgvFacturacion.Rows.Count - 1
                                        dgvFacturacion.Rows(UltimaFila).Cells("Tipo_Unidad").Value = DatosArticuloCuerpoDocumento.TipoUnidad
                                        dgvFacturacion.Rows(UltimaFila).Cells("IdArticulo").Value = DatosArticuloCuerpoDocumento.IdProducto
                                        dgvFacturacion.Rows(UltimaFila).Cells("Descripcion").Value = DatosArticuloCuerpoDocumento.Descripcion
                                        dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value = DatosArticuloCuerpoDocumento.PrecioVenta
                                        dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value = Replace(txtBalanza.Text, ".", ",")
                                        DatosArticuloCuerpoDocumento.cantidad = dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value
                                        importe = Math.Round((Convert.ToDouble(dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value)) * CDbl(Replace(dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value, ".", ",")), 2)
                                        DatosArticuloCuerpoDocumento.Importe = importe
                                        dgvFacturacion.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        obtenerImporteComprobante()
                                        dgvFacturacion.Rows.Add()
                                        dgvFacturacion.CurrentCell = dgvFacturacion.Rows(UltimaFila).Cells(0)
                                    Else
                                        MessageBoxEx.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        clsarticulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
                                        Return
                                    End If
                                Else
                                    'si es pesable obtener peso de balanza sino obtener cantidad de una ventana
                                    If (Datos_Configuracion.Lector_Codigo_Barras.ToString() = dfielddefConstantes.Si.ToString()) Then

                                        UltimaFila = dgvFacturacion.Rows.Count - 1
                                        dgvFacturacion.Rows(UltimaFila).Cells("Tipo_Unidad").Value = DatosArticuloCuerpoDocumento.TipoUnidad
                                        dgvFacturacion.Rows(UltimaFila).Cells("IdArticulo").Value = DatosArticuloCuerpoDocumento.IdProducto
                                        dgvFacturacion.Rows(UltimaFila).Cells("Descripcion").Value = DatosArticuloCuerpoDocumento.Descripcion
                                        dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value = 1
                                        DatosArticuloCuerpoDocumento.cantidad = dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value
                                        dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value = DatosArticuloCuerpoDocumento.PrecioVenta
                                        importe = Math.Round((Convert.ToDouble(dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value)) * CDbl(Replace(dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value, ".", ",")), 2)
                                        DatosArticuloCuerpoDocumento.Importe = importe
                                        dgvFacturacion.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        obtenerImporteComprobante()
                                        dgvFacturacion.Rows.Add()
                                        dgvFacturacion.CurrentCell = dgvFacturacion.Rows(UltimaFila).Cells(0)
                                    Else
                                        Dim FormCantidadad As New Vista.frmCantidad()
                                        clscantidad.CompDatos = DatosArticuloCuerpoDocumento ' datos
                                        clscantidad.CompDataGrid = dgvFacturacion
                                        clscantidad.CompTipoComprobante = Datos_Tipo_Comprobante.Descripcion ' tipoComprobante
                                        FormCantidadad.ShowDialog()
                                        DatosArticuloCuerpoDocumento = clscantidad.CompDatos
                                        obtenerImporteComprobante()
                                    End If
                                End If
                            Else
                                If Datos_Tipo_Comprobante.Descripcion = "FACTURA A" Then 'preguntar si por defecto el ingreso es por codigo barras

                                    If DatosArticuloCuerpoDocumento.Pesable.ToString() = dfielddefConstantes.Si.ToString() Then 'cambiar por NO, se utiliza si el ingreso es por codigo barras es por default
                                        'si es pesable obtener peso de balanza sino obtener cantidad de una ventana
                                        If IsNumeric(txtBalanza.Text) Then
                                            UltimaFila = dgvFacturacion.Rows.Count - 1
                                            dgvFacturacion.Rows(UltimaFila).Cells("Tipo_Unidad").Value = DatosArticuloCuerpoDocumento.TipoUnidad
                                            dgvFacturacion.Rows(UltimaFila).Cells("IdArticulo").Value = DatosArticuloCuerpoDocumento.IdProducto
                                            dgvFacturacion.Rows(UltimaFila).Cells("Descripcion").Value = DatosArticuloCuerpoDocumento.Descripcion
                                            dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value = Replace(txtBalanza.Text, ".", ",")
                                            DatosArticuloCuerpoDocumento.cantidad = dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value
                                            clsfacturacion.obtenerTasa(DatosArticuloCuerpoDocumento.IdTasaIVa, ObtenerTasa)
                                            dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format((Replace(DatosArticuloCuerpoDocumento.PrecioVenta, ".", ",")) / ObtenerTasa, "##,##0.00")
                                            importe = CDbl(dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                            DatosArticuloCuerpoDocumento.Importe = importe
                                            dgvFacturacion.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                            obtenerImporteComprobante()
                                            dgvFacturacion.Rows.Add()
                                            dgvFacturacion.CurrentCell = dgvFacturacion.Rows(UltimaFila).Cells(0)
                                        Else
                                            MessageBoxEx.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            clsarticulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
                                            Return
                                        End If
                                    Else
                                        If (Datos_Configuracion.Lector_Codigo_Barras.ToString() = dfielddefConstantes.Si.ToString()) Then

                                            UltimaFila = dgvFacturacion.Rows.Count - 1
                                            dgvFacturacion.Rows(UltimaFila).Cells("Tipo_Unidad").Value = DatosArticuloCuerpoDocumento.TipoUnidad
                                            dgvFacturacion.Rows(UltimaFila).Cells("IdArticulo").Value = DatosArticuloCuerpoDocumento.IdProducto
                                            dgvFacturacion.Rows(UltimaFila).Cells("Descripcion").Value = DatosArticuloCuerpoDocumento.Descripcion
                                            dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value = 1
                                            DatosArticuloCuerpoDocumento.cantidad = dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value
                                            clsfacturacion.obtenerTasa(DatosArticuloCuerpoDocumento.TasaIVa, ObtenerTasa)
                                            dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(Convert.ToDouble(Replace(DatosArticuloCuerpoDocumento.PrecioVenta, ".", ",")) / ObtenerTasa, "##,##0.00")
                                            DatosArticuloCuerpoDocumento.PrecioVenta = dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value
                                            importe = (dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                            DatosArticuloCuerpoDocumento.Importe = importe
                                            dgvFacturacion.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                            obtenerImporteComprobante()
                                            dgvFacturacion.Rows.Add()
                                            dgvFacturacion.CurrentCell = dgvFacturacion.Rows(UltimaFila).Cells(0)
                                        Else
                                            Dim FormCantidadad As New Vista.frmCantidad()
                                            clscantidad.CompDatos = DatosArticuloCuerpoDocumento
                                            clscantidad.CompDataGrid = dgvFacturacion
                                            clscantidad.CompTipoComprobante = Datos_Tipo_Comprobante.Descripcion ' tipoComprobante
                                            FormCantidadad.ShowDialog()
                                            DatosArticuloCuerpoDocumento = clscantidad.CompDatos
                                            obtenerImporteComprobante()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If txtBusquedaArticulo.Text.Trim() <> String.Empty Then
                            MessageBoxEx.Show("El Articulo no pertenece a la lista de precio: " + cbListaPrecio.Text + " , agreguelo a la lista!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            clsarticulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
                            Return
                        End If
                    End If
                End If
            Else
                MessageBoxEx.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                clsarticulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
                Return
            End If
            clsarticulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub InicializarEstructuras()
        ReDim Preserve Facturacion_Enc_estructura(1)
        Facturacion_Enc_estructura(1).IVA_Facturado105 = "0"
        Facturacion_Enc_estructura(1).IVA_Facturado21 = "0"
        Facturacion_Enc_estructura(1).IVA_Facturado27 = "0"
        Facturacion_Enc_estructura(1).Neto_Grabado_21 = "0"
        Facturacion_Enc_estructura(1).Neto_Grabado_105 = "0"
        Facturacion_Enc_estructura(1).Neto_Grabado_27 = "0"
        Facturacion_Enc_estructura(1).PorcDescuentos = "0"
    End Sub

    Private Sub CargarDatosCliente(ByVal CodigoCliente As Integer, ByRef Datos_Clientes As Controlador.clsCliente.eCliente)
        clscliente.ObtenerDatosCliente(CodigoCliente, Datos_Clientes)
    End Sub
    Private Sub cbListaPrecio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbListaPrecio.SelectedIndexChanged
        If cbListaPrecio.ValueMember <> String.Empty Then

            If ListCuerpoFactura.Any() Then
                Dim result As Integer = MessageBox.Show("Al cambiar la lista de precios se borraran los articulos ingresados. Desea cambiar la lista de precios?", "Modificar Lista Precios", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = DialogResult.Yes Then
                    datos_Lista_Precio.Id_Lista_Precio = cbListaPrecio.SelectedValue

                    LimpiarEstructuras()
                    clsfacturacion.Limpiar_Importes_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal)

                    If dgvFacturacion.Rows.Count = 0 Then
                        agregarFilaInicial()
                    End If
                Else
                    RemoveHandler Me.cbListaPrecio.SelectedIndexChanged, New EventHandler(AddressOf Me.cbListaPrecio_SelectedIndexChanged)
                    cbListaPrecio.SelectedValue = datos_Lista_Precio.Id_Lista_Precio
                    cbListaPrecio.Text = cbListaPrecio.Items(datos_Lista_Precio.Id_Lista_Precio - 1)(1)

                End If

                AddHandler Me.cbListaPrecio.SelectedIndexChanged, New EventHandler(AddressOf Me.cbListaPrecio_SelectedIndexChanged)
            Else
                datos_Lista_Precio.Id_Lista_Precio = cbListaPrecio.SelectedValue
            End If

        End If
    End Sub
    Private Sub obtenerImporteComprobante()
        Dim descuento As Double
        Dim descuentoCalculado21 As Double
        Dim descuentoCalculado105 As Double
        Dim descuentoCalculado27 As Double
        Dim consulta As String
        Dim dtdatosiva As New DataTable()
        Dim idx As Integer
        Dim ObtenerTasa As Double

        clsTasaIVA.recuperar_All_Datos(dtdatosiva)
        idx = 1
        ReDim estTasaIVA(0)
        For i As Integer = 0 To dtdatosiva.Rows.Count - 1
            ReDim Preserve estTasaIVA(idx)
            estTasaIVA(idx).Id_Tasa_IVA = dtdatosiva.Rows(i).Item("Id_Tasa_IVA")
            estTasaIVA(idx).Descripcion = dtdatosiva.Rows(i).Item("Descripcion")
            estTasaIVA(idx).Tasa = dtdatosiva.Rows(i).Item("Tasa")
            idx = idx + 1
        Next

        ReDim Preserve Facturacion_Enc_estructura(1)
        If Datos_Tipo_Comprobante.Descripcion = "FACTURA B" Or Datos_Tipo_Comprobante.Descripcion = "FACTURA C" Then
            clsfacturacion.obtenerTasa(DatosArticuloCuerpoDocumento.TasaIVa, ObtenerTasa)

            If Facturacion_Enc_estructura(1).PorcDescuentos <> Nothing Then
                descuento = ((Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)
            End If

            If Convert.ToInt32(DatosArticuloCuerpoDocumento.IdTasaIVa) = 1 Then
                Facturacion_Enc_estructura(1).Neto_Grabado_21 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + (Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) / ObtenerTasa), "##,##0.00")
                Facturacion_Enc_estructura(1).IVA_Facturado21 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + ((((Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) - descuento) / ObtenerTasa) * DatosArticuloCuerpoDocumento.TasaIVa) / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).Descuentos = Facturacion_Enc_estructura(1).Descuentos + (descuento / ObtenerTasa)
                descuentoCalculado21 = ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) * DatosArticuloCuerpoDocumento.TasaIVa) / 100)) * (Facturacion_Enc_estructura(1).PorcDescuentos) / 100)

            ElseIf Convert.ToInt32(DatosArticuloCuerpoDocumento.IdTasaIVa) = 2 Then
                Facturacion_Enc_estructura(1).Neto_Grabado_105 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + (Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) / ObtenerTasa), "##,##0.00")
                Facturacion_Enc_estructura(1).IVA_Facturado105 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + ((((Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) - descuento) / ObtenerTasa) * DatosArticuloCuerpoDocumento.TasaIVa) / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).Descuentos = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + (descuento / ObtenerTasa), "##,##0.00")


            ElseIf Convert.ToInt32(DatosArticuloCuerpoDocumento.IdTasaIVa) = 3 Then
                Facturacion_Enc_estructura(1).Neto_Grabado_27 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) + (Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) / ObtenerTasa), "##,##0.00")
                Facturacion_Enc_estructura(1).IVA_Facturado27 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27) + ((((Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) - descuento) / ObtenerTasa) * DatosArticuloCuerpoDocumento.TasaIVa) / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).Descuentos = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + (descuento / ObtenerTasa), "##,##0.00")

            End If
            descuentoCalculado21 = ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) * estTasaIVA(1).Tasa) / 100)) * (Facturacion_Enc_estructura(1).PorcDescuentos) / 100)
            descuentoCalculado105 = ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) * estTasaIVA(2).Tasa) / 100)) * (Facturacion_Enc_estructura(1).PorcDescuentos) / 100)
            descuentoCalculado27 = ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) + ((Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) * estTasaIVA(3).Tasa) / 100)) * (Facturacion_Enc_estructura(1).PorcDescuentos) / 100)
        ElseIf Datos_Tipo_Comprobante.Descripcion = "FACTURA A" Then
            If Facturacion_Enc_estructura(1).PorcDescuentos <> Nothing Then
                descuento = ((Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) * Convert.ToDouble(Facturacion_Enc_estructura(1).PorcDescuentos)) / 100)
            End If

            If Convert.ToInt32(DatosArticuloCuerpoDocumento.IdTasaIVa) = 1 Then
                Facturacion_Enc_estructura(1).Neto_Grabado_21 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe), "##,##0.00")
                Facturacion_Enc_estructura(1).IVA_Facturado21 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + (((Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) - descuento) * DatosArticuloCuerpoDocumento.TasaIVa) / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).Descuentos = Facturacion_Enc_estructura(1).Descuentos + descuento
                Facturacion_Enc_estructura(1).Sub_Total = (Facturacion_Enc_estructura(1).Neto_Grabado_21 - Facturacion_Enc_estructura(1).Descuentos)
                Facturacion_Enc_estructura(1).Total = Format(Facturacion_Enc_estructura(1).Neto_Grabado_21 + Facturacion_Enc_estructura(1).Neto_Grabado_105 + Facturacion_Enc_estructura(1).Neto_Grabado_27 - Facturacion_Enc_estructura(1).Descuentos + Facturacion_Enc_estructura(1).IVA_Facturado21 + Facturacion_Enc_estructura(1).IVA_Facturado105 + Facturacion_Enc_estructura(1).IVA_Facturado27, "##,##0.00")
                txtTotal.Text = Format(Facturacion_Enc_estructura(1).Neto_Grabado_21 + Facturacion_Enc_estructura(1).Neto_Grabado_105 + Facturacion_Enc_estructura(1).Neto_Grabado_27 - Facturacion_Enc_estructura(1).Descuentos + Facturacion_Enc_estructura(1).IVA_Facturado21 + Facturacion_Enc_estructura(1).IVA_Facturado105 + Facturacion_Enc_estructura(1).IVA_Facturado27, "##,##0.00")

            ElseIf Convert.ToInt32(DatosArticuloCuerpoDocumento.IdTasaIVa) = 2 Then
                Facturacion_Enc_estructura(1).Neto_Grabado_105 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe), "##,##0.00")
                Facturacion_Enc_estructura(1).IVA_Facturado105 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + (((Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) - descuento) * DatosArticuloCuerpoDocumento.TasaIVa) / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).Descuentos = Format((Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + descuento), "##,##0.00")

            ElseIf Convert.ToInt32(DatosArticuloCuerpoDocumento.IdTasaIVa) = 3 Then
                Facturacion_Enc_estructura(1).Neto_Grabado_27 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) + Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe), "##,##0.00")
                Facturacion_Enc_estructura(1).IVA_Facturado27 = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27) + (((Convert.ToDouble(DatosArticuloCuerpoDocumento.Importe) - descuento) * DatosArticuloCuerpoDocumento.TasaIVa) / 100), "##,##0.00")
                Facturacion_Enc_estructura(1).Descuentos = Format((Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + descuento), "##,##0.00")
            End If
        End If

        If Datos_Tipo_Comprobante.Descripcion = "FACTURA A" Then
            If Facturacion_Enc_estructura(1).Descuentos <> Nothing Then

                txtDescuento.Text = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos), "##,##0.00")
            End If
            If (Facturacion_Enc_estructura(1).Neto_Grabado_21 <> Nothing Or Facturacion_Enc_estructura(1).Neto_Grabado_105 <> Nothing Or Facturacion_Enc_estructura(1).Neto_Grabado_27 <> Nothing) Then
                Facturacion_Enc_estructura(1).Sub_Total = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos), "##,##0.00")
                Facturacion_Enc_estructura(1).Total = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), "##,##0.00")

            End If
        Else
            If Facturacion_Enc_estructura(1).Descuentos <> Nothing Then
                txtDescuento.Text = Format(descuentoCalculado21 + descuentoCalculado105 + descuentoCalculado27, "##,##0.00")
            End If
            If (Facturacion_Enc_estructura(1).Neto_Grabado_21 <> Nothing Or Facturacion_Enc_estructura(1).Neto_Grabado_105 <> Nothing Or Facturacion_Enc_estructura(1).Neto_Grabado_27 <> Nothing) Then
                Facturacion_Enc_estructura(1).Sub_Total = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), "##,##0.00")
                Facturacion_Enc_estructura(1).Total = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), "##,##0.00")
            End If

        End If
        TxtSubTotal.Text = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Sub_Total), "##,##0.00")
        txtIVA21.Text = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21), "##,##0.00")
        txtIVA105.Text = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105), "##,##0.00")
        txtIVA27.Text = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), "##,##0.00")
        txtTotal.Text = Format(Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_21) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_105) + Convert.ToDouble(Facturacion_Enc_estructura(1).Neto_Grabado_27) - Convert.ToDouble(Facturacion_Enc_estructura(1).Descuentos) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado21) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado105) + Convert.ToDouble(Facturacion_Enc_estructura(1).IVA_Facturado27), "##,##0.00")

        ListCuerpoFactura.Add(DatosArticuloCuerpoDocumento)
    End Sub

    Private Sub ToolStripNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNuevo.Click
        LimpiarEstructuras()
        clsfacturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
        txtCodigoCliente.Text = String.Empty
        lblCodN.Visible = False
        DeshabilitarBotonAnularComprobante()
    End Sub

    Private Sub DeshabilitarBotonAnularComprobante()
        ToolStripRegistrarFactura.Enabled = True
        ToolStripBuscar.Enabled = True
        ToolStripAnularComprobante.Enabled = False
    End Sub

    Private Sub HabilitarBotonAnularComprobante()
        ToolStripRegistrarFactura.Enabled = False
        ToolStripBuscar.Enabled = False
        ToolStripAnularComprobante.Enabled = True
    End Sub

#End Region




    Private Sub ToolStripAnularComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripAnularComprobante.Click
        Dim consulta As String
        Dim dtdatosCuerpoFact As New DataTable
        Dim dtdatosEncFact As New DataTable
        Dim dtdatos As New DataTable
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim ultimo As Integer
        Dim dtArticulos As New DataTable
        Dim numeracion As String
        Dim IDComprobante As Integer
        Dim numeroComp As String
        Dim idx As Integer
        Dim esquema As New Collection
        Dim ClavePrincipal As New Collection
        Dim datosCol As New Collection
        Dim UltimoCaja As Integer
        Dim UltimoCuentaCorriente As Integer
        Dim sucursal As String
        Dim listTipoComprobante As New List(Of String)
        Dim valido As Boolean
        Try

            Dim result As Integer = MessageBoxEx.Show("Desea Anular el Comprobante: " + txtNroSucursal.Text + "-" + txtnumeroComprobante.Text + ", Con Nota de Credito Interna?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.Yes Then
                clsfacturacion.Obtener_Datos_Comprobante_Encabezado_Factura(txtNroSucursal.Text, clsfacturacion.CompTipo_Comprobante, txtnumeroComprobante.Text, dtdatosEncFact)
                clsfacturacion.Obtener_Datos_Comprobante_Cuerpo_Factura(txtNroSucursal.Text, clsfacturacion.CompTipo_Comprobante, txtnumeroComprobante.Text, dtdatosCuerpoFact)
                clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtdatos)
                sucursal = dtdatos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
                Responsabilidad_IVA_Empresa = dtdatos.Rows(0).Item(dfielddefEmpresa.Responsabilidad_IVA).ToString()
                clscliente.Obtener_CondicionFrenteAIVa(txtCondIVA.Text, eNumero_Condicion_IVA_Cliente)
                clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)
                clsfacturacion.Obtener_Datos_Comprobante(Numero_Condicion_IVA_Empresa, eNumero_Condicion_IVA_Cliente.Id_Condicion_IVA, dfielddefConstantes.Nota_De_Credito_Int.ToString(), eDatoTipoComprobante)
                IDComprobante = eDatoTipoComprobante.IdTipoComprobante
                tipoComprobante = eDatoTipoComprobante.Descripcion

                ReDim eNotaCredito_Enc_estructura(1)
                eNotaCredito_Enc_estructura(1).Punto_Venta = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Punto_Venta)
                eNotaCredito_Enc_estructura(1).Tipo_Comprobante = Convert.ToString(IDComprobante).PadLeft(2, "0")
                clsNumeroComprobante.ObtenerUltimoNumeroComprobante(tipoComprobante, clsEmpresa.Compvariable, ultimo)
                clsNumeroComprobante.Aumentar_Numeracion_Comprobante(ultimo, numeracion)
                eNotaCredito_Enc_estructura(1).Numero_Comprobante = numeracion.Trim
                eNotaCredito_Enc_estructura(1).Comprobante = tipoComprobante
                eNotaCredito_Enc_estructura(1).Numero_Cliente = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Numero_Cliente)
                eNotaCredito_Enc_estructura(1).Nombre = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Nombre)
                eNotaCredito_Enc_estructura(1).Apellido = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Apellido)
                eNotaCredito_Enc_estructura(1).Situacion_Frente_A_IVA = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Situacion_Frente_A_IVA)
                eNotaCredito_Enc_estructura(1).Id_Forma_Pago = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.ID_Forma_Pago)
                eNotaCredito_Enc_estructura(1).Forma_Pago = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Forma_Pago)
                eNotaCredito_Enc_estructura(1).Fecha_Comprobante = Date.Now.ToShortDateString()
                eNotaCredito_Enc_estructura(1).Codigo_Vendedor = 1
                eNotaCredito_Enc_estructura(1).Neto_Grabado_21 = Format(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_21) * -1, "##,##0.00")
                eNotaCredito_Enc_estructura(1).Neto_Grabado_105 = Format(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_105) * -1, "##,##0.00")
                eNotaCredito_Enc_estructura(1).Neto_Grabado_27 = Format(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_27) * -1, "##,##0.00")
                eNotaCredito_Enc_estructura(1).Sub_Total = Format(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Sub_Total) * -1, "##,##0.00")
                eNotaCredito_Enc_estructura(1).Conc_No_Grabado = ""
                eNotaCredito_Enc_estructura(1).Exentos = ""
                eNotaCredito_Enc_estructura(1).IVA_Facturado21 = Format(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado21) * -1, "##,##0.00")
                eNotaCredito_Enc_estructura(1).IVA_Facturado105 = Format(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado105) * -1, "##,##0.00")
                eNotaCredito_Enc_estructura(1).IVA_Facturado27 = Format(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado27) * -1, "##,##0.00")
                eNotaCredito_Enc_estructura(1).IVA_Resp_No_Inscripto = ""
                eNotaCredito_Enc_estructura(1).Persepciones = ""
                eNotaCredito_Enc_estructura(1).PorcDescuentos = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.PorcDescuentos)
                If dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos) = "" Then
                    eNotaCredito_Enc_estructura(1).Descuentos = "0"
                Else
                    eNotaCredito_Enc_estructura(1).Descuentos = Format(Replace(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos), ",", ".") * -1, "##,##0.00")
                End If
                eNotaCredito_Enc_estructura(1).Retenciones = ""
                eNotaCredito_Enc_estructura(1).Total = Format(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Total) * -1, "##,##0.00")
                eNotaCredito_Enc_estructura(1).Cancelado = dfielddefConstantes.No.ToString()
                eNotaCredito_Enc_estructura(1).Signo = "-1"
                eNotaCredito_Enc_estructura(1).NroPuesto = session.Session.NroPuesto
                clsNumeroComprobante.obtener_Datos_Numero_Comprobante(tipoComprobante, clsEmpresa.Compvariable, dtdatos)

                ReDim Numero_Comprobante(1)
                Numero_Comprobante(1).Id_Comprobante = dtdatos.Rows(0).Item(dfielddecNumeroComprobantea.Id_Comprobante)
                Numero_Comprobante(1).Descripcion = dtdatos.Rows(0).Item(dfielddecNumeroComprobantea.Descripcion)
                Numero_Comprobante(1).Numeracion = numeracion.Trim
                Numero_Comprobante(1).Id_Empresa = dtdatos.Rows(0).Item(dfielddecNumeroComprobantea.Id_Empresa)
                Numero_Comprobante(1).Id_Tipo_Comprobante = IDComprobante
                idx = 0
                For i = 1 To dtdatosCuerpoFact.Rows.Count
                    ReDim Preserve eNotaCredito_Cuerpo_estructura(i)
                    ReDim Preserve Articulos_Estructura(i)
                    clsfacturacion.ObtenerUltimoNumeroCuerpoFactura(ultimo)
                    eNotaCredito_Cuerpo_estructura(i).IdCuerpoFactura = ultimo

                    eNotaCredito_Cuerpo_estructura(i).Punto_Venta = dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Punto_Venta)
                    eNotaCredito_Cuerpo_estructura(i).Tipo_Comprobante = Convert.ToString(IDComprobante).PadLeft(2, "0")
                    eNotaCredito_Cuerpo_estructura(i).Numero_Comprobante = numeracion.Trim
                    eNotaCredito_Cuerpo_estructura(i).Comprobante = tipoComprobante
                    eNotaCredito_Cuerpo_estructura(i).Numero_Articulo = dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo)
                    eNotaCredito_Cuerpo_estructura(i).Descripcion = dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Descripcion)
                    eNotaCredito_Cuerpo_estructura(i).Cantidad = Format(dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Cantidad) * -1, "##,##0.00")
                    eNotaCredito_Cuerpo_estructura(i).Precio_Unitario = Format(dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Precio_Unitario) * -1, "##,##0.00")
                    eNotaCredito_Cuerpo_estructura(i).Signo = "-1"
                    eNotaCredito_Cuerpo_estructura(i).NroPuesto = session.Session.NroPuesto
                    clsarticulo.ObtenerProductos(eNotaCredito_Cuerpo_estructura(i).Numero_Articulo, dtArticulos)
                    Articulos_Estructura(i).Id_Producto = eNotaCredito_Cuerpo_estructura(i).Numero_Articulo
                    Articulos_Estructura(i).Stock = dtArticulos.Rows(0).Item("Stock")
                    idx = idx + 1
                Next

                ReDim Preserve Facturacion_Enc_estructura(1)
                Facturacion_Enc_estructura(1).Punto_Venta = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Punto_Venta)
                Facturacion_Enc_estructura(1).Tipo_Comprobante = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Tipo_Comprobante)
                Facturacion_Enc_estructura(1).Numero_Comprobante = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Numero_Comprobante)
                Facturacion_Enc_estructura(1).Comprobante = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Comprobante)
                Facturacion_Enc_estructura(1).Numero_Cliente = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Numero_Cliente)
                Facturacion_Enc_estructura(1).Nombre = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Nombre)
                Facturacion_Enc_estructura(1).Apellido = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Apellido)
                Facturacion_Enc_estructura(1).Situacion_Frente_A_IVA = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Situacion_Frente_A_IVA)
                Facturacion_Enc_estructura(1).Id_Forma_Pago = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.ID_Forma_Pago)
                Facturacion_Enc_estructura(1).Forma_Pago = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Forma_Pago)
                Facturacion_Enc_estructura(1).Fecha_Comprobante = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Fecha_Comprobante)
                Facturacion_Enc_estructura(1).Codigo_Vendedor = 1

                Facturacion_Enc_estructura(1).Neto_Grabado_21 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_21))
                Facturacion_Enc_estructura(1).Neto_Grabado_105 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_105))
                Facturacion_Enc_estructura(1).Neto_Grabado_27 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_27))
                Facturacion_Enc_estructura(1).Sub_Total = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Sub_Total))
                Facturacion_Enc_estructura(1).Conc_No_Grabado = ""
                Facturacion_Enc_estructura(1).Exentos = ""
                Facturacion_Enc_estructura(1).IVA_Facturado21 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado21))
                Facturacion_Enc_estructura(1).IVA_Facturado105 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado105))
                Facturacion_Enc_estructura(1).IVA_Facturado27 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado27))
                Facturacion_Enc_estructura(1).IVA_Resp_No_Inscripto = ""
                Facturacion_Enc_estructura(1).Persepciones = ""
                Facturacion_Enc_estructura(1).PorcDescuentos = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.PorcDescuentos))

                If dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos) = "" Then
                    Facturacion_Enc_estructura(1).Descuentos = "0"
                Else
                    Facturacion_Enc_estructura(1).Descuentos = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos)
                End If
                Facturacion_Enc_estructura(1).Retenciones = ""
                Facturacion_Enc_estructura(1).Total = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Total))
                Facturacion_Enc_estructura(1).Cancelado = dfielddefConstantes.Si.ToString()
                Facturacion_Enc_estructura(1).Signo = "1"
                Facturacion_Enc_estructura(1).NroPuesto = session.Session.NroPuesto

                clsfacturacion.anularComprobante(eNotaCredito_Enc_estructura, Numero_Comprobante, eNotaCredito_Cuerpo_estructura, Articulos_Estructura, Facturacion_Enc_estructura, valido)

                If valido Then
                    MessageBoxEx.Show("El Comprobante " + txtNroSucursal.Text + "-" + txtnumeroComprobante.Text + " ,se ha Anulado Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Information)
                Else
                    MessageBoxEx.Show("El Comprobante " + txtNroSucursal.Text + "-" + txtnumeroComprobante.Text + " ,no se ha podido Anular!!!", "Informacion", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Information)
                End If
                
                LimpiarEstructuras()
                clsfacturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
            End If
            
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class