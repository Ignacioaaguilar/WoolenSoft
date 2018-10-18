Imports Controlador
Imports System.IO.Ports

Public Class frmFacturacion


#Region "Declaration"
    Dim Responsabilidad_IVA_Empresa As String
    Public _Cant As Integer
    Dim Enviar(0) As Byte
    Public Facturacion_Enc_estructura(0) As Controlador.Facturacion.eEncabezadoFactura
    Public Datos_Clientes As Controlador.Cliente.eCliente
    Public Datos_Clientes_Cond_Frente_A_Iva As Controlador.Cliente.eCondicion_Frente_Al_Iva
    Public Facturacion_Cuerpo_estructura(0) As Controlador.Facturacion.eCuerpoFactura
    Public Numero_Comprobante(0) As Controlador.NumeroComprobante.eNumeracionComprobante
    Public Articulos_Estructura(0) As Controlador.Articulos.eArticulo
    Public DatosFactura As Controlador.Facturacion.eDatosFactura
    Public Datos_Empresa As Controlador.Empresas.eEmpresa
    Public Datos_Tipo_Comprobante As Controlador.Facturacion.eTipoComprobante
    Public Datos_Configuracion As Controlador.Configuracion.eConfiguracion
    Public Datos_Articulo As Controlador.Articulos.eArticulo
    Public DatosArticuloCuerpoDocumento As Controlador.Articulos.eArticuloCuerpoDocumento
    Public datos_Lista_Precio As Controlador.Lista_Precios.eListaPrecio
    Public ListCuerpoFactura As New List(Of Controlador.Articulos.eArticuloCuerpoDocumento)
    Dim dfielddefArticuloListaPrecio As Controlador.DfieldDef.eArticuloCuerpoDocumento
    Dim dfielddefEmpresa As Controlador.DfieldDef.eEmpresa
    Dim dfielddefConfiguracion As Controlador.DfieldDef.eConfiguracion
    Dim dfielddefListaPrecio As Controlador.DfieldDef.eListaPrecio
    Dim dfielddefCliente As Controlador.DfieldDef.eCliente
    Dim dfielddecNumeroComprobantea As Controlador.DfieldDef.eNumeroComprobante
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Public estTasaIVA(0) As Controlador.TasaIVA.eTasaIVA
    Public session As New Controlador.Session()
    Private CodigoCliente As String
#End Region

#Region "Constructor"



    Private Sub Facturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Empresa As New Controlador.Empresas()
        Dim Configuracion As New Controlador.Configuracion
        Dim puerto As Integer
        Try
            Configuracion.Obtener_Datos_Configuracion(Datos_Configuracion)
            OcultarTasasIVA()
            puerto = Convert.ToInt32(Datos_Configuracion.Nro_Puerto)
            If BalanzaConectada(puerto) Then
                AxMSComm2.CommPort = puerto 'Convert.ToInt32(Datos_Configuracion.Rows(0).Item(dfielddefConfiguracion.Numero_Puerto)) '.6 'pasar un parametro para el puerto com
                AxMSComm2.PortOpen = True         ' abrimos el puerto
                AxMSComm2.Settings = "9600,N,8,1"
                AxMSComm2.InputLen = 9
                AxMSComm2.RThreshold = 8
                AxMSComm2.InBufferCount = 0
                Enviar(0) = 7                ' Peticion de transmision de Datos debo enviar dos veces 7
                AxMSComm2.Output = Enviar       ' para que la balanza repsonda con peso con indicador de estabilidad
                AxMSComm2.Output = Enviar
            End If
            Empresa.Obtener_Datos_Empresa(Empresa.Compvariable, Datos_Empresa)
            txtNroSucursal.Text = Datos_Empresa.Nro_Sucursal
            mtFecha.Text = Date.Now
            lblCodN.Visible = False
            LlenarListaPrecios()


        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub

#End Region

#Region "Event Form"
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

    Sub LlenarListaPrecios()
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim Configuracion As New Controlador.Configuracion
        Configuracion.Obtener_Datos_Configuracion(Datos_Configuracion)
        Lista_Precio.llenar_Combo_ListaPrecio(cbListaPrecio, "Id_Lista_Precio", "Descripcion")
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
        Dim tasaIva As New Controlador.TasaIVA()
        Dim datosiva As New DataTable()
        Dim idx As Integer

        If (Datos_Clientes.Id_Cliente <> Nothing) Then
            consulta = "Select * " & vbCrLf
            consulta += "From Tasa_IVA"
            tasaIva.recuperar_All_Datos(datosiva)
            idx = 1
            ReDim estTasaIVA(0)
            For i As Integer = 0 To datosiva.Rows.Count - 1
                ReDim Preserve estTasaIVA(idx)
                estTasaIVA(idx).Id_Tasa_IVA = datosiva.Rows(i).Item("Id_Tasa_IVA")
                estTasaIVA(idx).Descripcion = datosiva.Rows(i).Item("Descripcion")
                estTasaIVA(idx).Tasa = datosiva.Rows(i).Item("Tasa")
                idx = idx + 1
            Next
            ReDim Preserve Facturacion_Enc_estructura(1)
            If TxtPorcDesc.Text = String.Empty Or (Not IsNumeric(TxtPorcDesc.Text)) Then
                TxtPorcDesc.Text = String.Empty
                Facturacion_Enc_estructura(1).PorcDescuentos = "0"
            Else
                Facturacion_Enc_estructura(1).PorcDescuentos = Replace(TxtPorcDesc.Text, ",", ".")
                If (Convert.ToDouble(Replace(Facturacion_Enc_estructura(1).PorcDescuentos, ",", ".")) > 99) Then
                    MessageBox.Show("El Porcentaje de descuento, debe ser menor al 99%!!!", "Informacion", MessageBoxButtons.OK, _
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
        Dim VentaRapida As New Controlador.Facturacion()
        If Not (VentaRapida.validateDoublesAndCurrency_Comprobante(txtBalanza.Text)) Then
            txtBalanza.Text = String.Empty
        End If
    End Sub
    Private Sub txtBusquedaArticulo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBusquedaArticulo.KeyDown
        Dim articulo As New Controlador.Articulos()
        If Not (articulo.es_Numero(txtBusquedaArticulo.Text)) Then
            txtBusquedaArticulo.Text = String.Empty

        ElseIf e.KeyCode = Keys.Enter Then
            articulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString()
            Datos_Articulo.Id_Producto = txtBusquedaArticulo.Text.Trim()
            cargarArticulos()
            txtBusquedaArticulo.Text = String.Empty
        End If
    End Sub
    Private Sub ToolStripBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripBuscar.Click
        Dim Fact As New Controlador.Facturacion()
        Dim Cli As New Controlador.Cliente
        Dim idx As Integer
        Dim art As New Controlador.Articulos
        For x As Integer = ProgressBarFacturacion.Minimum To ProgressBarFacturacion.Maximum
            ProgressBarFacturacion.Value = x
        Next
        For x As Integer = ProgressBarFacturacion.Maximum To ProgressBarFacturacion.Minimum Step -1
            ProgressBarFacturacion.Value = x
        Next

        Fact.Compvariable = dfielddefConstantes.FACTURA.ToString()
        Vista.frmBuscarComprobante.ShowDialog()
        If art.busquedaComprobante = dfielddefConstantes.BuscarComprobante.ToString() Then
            If Fact.ComplistOfCodProd.Count > 0 Then
                txtCodigoCliente.Text = Cli.CompCodigo
                TxtPorcDesc.Text = Fact.CompPorcDescuentos

                If dgvFacturacion.Rows.Count - 1 >= 1 Then
                    Fact.Limpiar_Importes_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal)
                    LimpiarEstructuras()
                    agregarFilaInicial()
                End If
                For idx = 0 To Fact.ComplistOfCodProd.Count - 1
                    txtBusquedaArticulo.Text = Fact.ComplistOfCodProd(idx)
                Next

            End If
        End If

    End Sub
    Private Sub ToolStripRegistrarFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRegistrarFactura.Click
        'Dim querybuilder As New Controlador.QueryBuilder
        'Dim esquema As New Collection
        Dim consulta As String
        'Dim datos As New Collection
        'Dim ClavePrincipal As New Collection
        Dim Facturacion As New Controlador.Facturacion
        Dim NumeroComprobante As New Controlador.NumeroComprobante
        Dim datosDataTable As New DataTable
        Dim tipocomprobante As String
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Empresa As New Controlador.Empresas
        Dim Numero_Condicion_IVA_Cliente As Controlador.Cliente.eCondicion_Frente_Al_Iva
        Dim Cliente As New Controlador.Cliente
        Dim Articulo As New Controlador.Articulos
        Dim dtArticulos As New DataTable
        Dim i As Integer
        Dim formaPago As New Controlador.FormasDePago
        Dim datosComprobante As New DataTable
        Dim IdTipoComprobante As Integer
        Dim DatoTipoComprobante As Controlador.Facturacion.eTipoComprobante
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

                'Facturacion_Enc_estructura(1). = DatosFactura.Neto_Grabado 'txtSubTotal.Text.Trim()

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
                'Facturacion_Enc_estructura(1).IVA_Facturado21 = DatosFactura.IVA_Facturado 'txtIVa.Text.Trim()

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
                'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (txtCondIVA.Text) & "' "
                Cliente.Obtener_CondicionFrenteAIVa(txtCondIVA.Text, Numero_Condicion_IVA_Cliente)
                'consulta = "select Id_Condicion_IVA from " + dfielddefConstantes.Condicion_Frente_Al_IVA.ToString() + " where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                Empresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)

                'consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                'consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                'consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                'consulta += " and TC.IdTipoComprobante in ('1','11','6')"

                'Facturacion.Obtener_Tipo_Comprobante(consulta, tipocomprobante)
                Facturacion.Obtener_Datos_Comprobante(Numero_Condicion_IVA_Cliente.Id_Condicion_IVA, Numero_Condicion_IVA_Empresa, dfielddefConstantes.FACTURA.ToString(), DatoTipoComprobante)
                'tipocomprobante = datosComprobante.Rows(0).Item("Descripcion")
                'IdTipoComprobante = Convert.ToInt32(datosComprobante.Rows(0).Item("IdTipoComprobante"))
                tipocomprobante = DatoTipoComprobante.Descripcion
                IdTipoComprobante = Convert.ToInt32(DatoTipoComprobante.IdTipoComprobante)

                Facturacion_Enc_estructura(1).Comprobante = tipocomprobante
                'consulta = "select Id_Comprobante,Descripcion, Numeracion,Id_Empresa,Id_Tipo_Comprobante from " + dfielddefConstantes.Numeracion_Comprobante.ToString() + "   where Id_Empresa='" + Empresa.Compvariable + "' and Id_Tipo_Comprobante = '" & Convert.ToString(IdTipoComprobante) & "'"
                NumeroComprobante.obtener_Datos_Numero_Comprobante_Empresa_TipoComprobante(Empresa.Compvariable, Convert.ToString(IdTipoComprobante), datosDataTable)
                ReDim Numero_Comprobante(1)
                Numero_Comprobante(1).Id_Comprobante = datosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Id_Comprobante)
                Numero_Comprobante(1).Descripcion = datosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Descripcion)
                Numero_Comprobante(1).Numeracion = txtnumeroComprobante.Text.Trim()
                Numero_Comprobante(1).Id_Empresa = datosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Id_Empresa)
                Numero_Comprobante(1).Id_Tipo_Comprobante = datosDataTable.Rows(0).Item(dfielddecNumeroComprobantea.Id_Tipo_Comprobante)

                i = 1

                'While i <= dgvFacturacion.Rows.Count
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
                        'consulta = "select * from " + dfielddefConstantes.Producto.ToString() + " where Id_Producto='" + Facturacion_Cuerpo_estructura(i).Numero_Articulo + "'"
                        Articulo.ObtenerProductos(Facturacion_Cuerpo_estructura(i).Numero_Articulo, dtArticulos)
                        Articulos_Estructura(i).Id_Producto = Facturacion_Cuerpo_estructura(i).Numero_Articulo
                        Articulos_Estructura(i).Stock = dtArticulos.Rows(0).Item("Stock") ''''VER
                    End If
                    i = i + 1
                End While
                Try

                    Dim FPP As New frmFormasDePago(Facturacion_Enc_estructura, Facturacion_Cuerpo_estructura, Articulos_Estructura, Numero_Comprobante)
                    formaPago.Compvariable = dfielddefConstantes.FACTURA.ToString()
                    FPP.ShowDialog()
                    If formaPago.Compvariable = dfielddefConstantes.Si.ToString() Then
                        LimpiarEstructuras()
                        Facturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
                        txtCodigoCliente.Text = String.Empty
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
        Dim articulo As New Controlador.Articulos()

        If (articulo.CompvariableCargarArticulo = dfielddefConstantes.Si.ToString()) Then

            cargarArticulos()
            txtBusquedaArticulo.Text = String.Empty

        Else
            If (articulo.busquedaComprobante = dfielddefConstantes.BuscarComprobante.ToString()) Then
                Datos_Articulo.Id_Producto = txtBusquedaArticulo.Text.Trim()
                cargarArticulos()
                articulo.busquedaComprobante = String.Empty
                txtBusquedaArticulo.Text = String.Empty

            End If
        End If
    End Sub
    Private Sub btnBuscarArticulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarArticulo.Click
        Dim articulo As New Controlador.Articulos()
        Dim FacturacionArt As New Controlador.Facturacion()
        Try
            If Datos_Clientes.Id_Cliente <> Nothing Then
                articulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString()
                articulo.CompvariableCargarArticulo = dfielddefConstantes.Si.ToString()

                frmArticulos.ShowDialog()
                If FacturacionArt.FacturacionCodArticulo <> String.Empty Then
                    Datos_Articulo.Id_Producto = FacturacionArt.FacturacionCodArticulo.ToString()
                    articulo.CompId_Articulo = Nothing
                    FacturacionArt.FacturacionCodArticulo = Nothing
                    txtBusquedaArticulo.Text = Datos_Articulo.Id_Producto
                Else
                    articulo.CompId_Articulo = Nothing
                    FacturacionArt.FacturacionCodArticulo = Nothing
                End If

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
    Public Sub txtCodigoCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCliente.TextChanged
        Dim Clientes As New Controlador.Cliente()
        Dim Empresa As New Controlador.Empresas()
        Dim Facturacion As New Controlador.Facturacion()
        Dim NumeroComprobante As New Controlador.NumeroComprobante()
        Dim tipoComprobante As String
        Dim IDTipoComprobante As Integer
        Dim numeroComp As String
        Dim nuComprobante As Integer
        Dim existe As Boolean
        Try
            If Not (Clientes.es_Numero(txtCodigoCliente.Text)) Then
                'If Not (Clientes.es_Numero(Clientes.CompCodigo)) Then
                txtCodigoCliente.Text = String.Empty
                Datos_Clientes.Id_Cliente = Nothing
                Facturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
            ElseIf txtCodigoCliente.Text <> String.Empty Then
                'ElseIf Clientes.CompCodigo <> String.Empty Then

                Empresa.Obtener_Datos_Empresa(Empresa.Compvariable, Datos_Empresa)
                CargarDatosCliente(Convert.ToInt32(txtCodigoCliente.Text), Datos_Clientes)
                'CargarDatosCliente(Convert.ToInt32(Clientes.CompCodigo), Datos_Clientes)
                Clientes.Validar_Cliente(Datos_Clientes.Id_Cliente, existe)
                If existe Then
                    Me.lblCodN.Visible = True
                    Facturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
                    txtNombre.Text = Datos_Clientes.Nombre
                    txtApellido.Text = Datos_Clientes.Apellido
                    txtDireccion.Text = Datos_Clientes.Calle + " " + Datos_Clientes.Piso + " " + Datos_Clientes.Nro
                    txtCelular.Text = Datos_Clientes.Celular
                    txtTelefono.Text = Datos_Clientes.Telefono
                    txtCondIVA.Text = Datos_Clientes.Responsabilidad_IVA
                    txtMail.Text = Datos_Clientes.E_Mail
                    txtLimiteCC.Text = Datos_Clientes.Saldo_CC
                    Clientes.Obtener_CondicionFrenteAIVa(Datos_Clientes.Responsabilidad_IVA, Datos_Clientes_Cond_Frente_A_Iva)
                    Facturacion.Obtener_Datos_Comprobante(Datos_Clientes_Cond_Frente_A_Iva.Id_Condicion_IVA, Datos_Empresa.Id_Responsabilidad_IVA, dfielddefConstantes.FACTURA.ToString(), Datos_Tipo_Comprobante)
                    tipoComprobante = Datos_Tipo_Comprobante.Descripcion
                    IDTipoComprobante = Convert.ToInt32(Datos_Tipo_Comprobante.IdTipoComprobante)
                    lblTipoComprobante.Text = tipoComprobante
                    lblIdComprobante.Text = Convert.ToString(IDTipoComprobante).PadLeft(2, "0")

                    txtNroSucursal.Text = Datos_Empresa.Nro_Sucursal
                    Responsabilidad_IVA_Empresa = Datos_Empresa.Responsabilidad_IVA

                    NumeroComprobante.obtener_Numero_Comprobante(Empresa.Compvariable, IDTipoComprobante, numeroComp)
                    nuComprobante = Convert.ToInt32(numeroComp) + 1
                    NumeroComprobante.Aumentar_Numeracion_Comprobante(nuComprobante, numeroComp)
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
                    MessageBox.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                    LimpiarEstructuras()
                    Facturacion.Limpiar_Datos_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal, txtNombre, txtApellido, txtDireccion, txtCelular, txtTelefono, txtCondIVA, txtMail, txtLimiteCC, txtnumeroComprobante, lblTipoComprobante, lblIdComprobante, TxtPorcDesc)
                    txtCodigoCliente.Text = String.Empty
                    lblCodN.Visible = False
                End If
            End If

        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        Dim Cli As New Controlador.Cliente()
        Try
            Cli.Compvariable = dfielddefConstantes.FACTURA.ToString()
            frmClientes.ShowDialog()
            txtCodigoCliente.Text = Cli.CompCodigo
            Cli.CompCodigo = Nothing
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvFacturacion_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFacturacion.CellContentClick
        Dim filaseleccionada As Integer
        Dim Facturacion As New Controlador.Facturacion()
        Dim ObtenerTasa As Double
        Dim importe As Double
        Dim importetotal As Double
        Dim descuento As Double
        Dim descuentoCalculado21 As Double
        Dim descuentoCalculado105 As Double
        Dim descuentoCalculado27 As Double
        Dim consulta As String
        Dim tasaIva As New Controlador.TasaIVA()
        Dim datosiva As New DataTable()
        Dim idx As Integer
        Try
            filaseleccionada = Convert.ToInt32(dgvFacturacion.CurrentRow.Index.ToString())
            Dim result As Integer = MessageBox.Show("Desea Eliminar el Articulo: " + CStr(dgvFacturacion.Rows(filaseleccionada).Cells(2).Value), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If result = DialogResult.Yes Then
                If ListCuerpoFactura.Any() Then
                    'consulta = "Select * " & vbCrLf
                    'consulta += "From Tasa_IVA"
                    tasaIva.recuperar_All_Datos(datosiva)
                    idx = 1
                    ReDim estTasaIVA(0)
                    For i As Integer = 0 To datosiva.Rows.Count - 1
                        ReDim Preserve estTasaIVA(idx)
                        estTasaIVA(idx).Id_Tasa_IVA = datosiva.Rows(i).Item("Id_Tasa_IVA")
                        estTasaIVA(idx).Descripcion = datosiva.Rows(i).Item("Descripcion")
                        estTasaIVA(idx).Tasa = datosiva.Rows(i).Item("Tasa")
                        idx = idx + 1
                    Next

                    If Datos_Tipo_Comprobante.Descripcion = "FACTURA B" Or Datos_Tipo_Comprobante.Descripcion = "FACTURA C" Then
                        Facturacion.obtenerTasa(ListCuerpoFactura(filaseleccionada).TasaIVa, ObtenerTasa)
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
        Me.Close()
    End Sub
#End Region

#Region "Private Methods"

    Private Sub MostrarTasasIVA()
        lbl21.Visible = True
        txtIVA21.Visible = True
        lbl105.Visible = True
        txtIVA105.Visible = True
        lbl27.Visible = True
        txtIVA27.Visible = True
    End Sub
    Private Sub OcultarTasasIVA()
        lbl21.Visible = False
        txtIVA21.Visible = False
        lbl105.Visible = False
        txtIVA105.Visible = False
        lbl27.Visible = False
        txtIVA27.Visible = False
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
    Private Sub btnLimpiarBuff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarBuff.Click
        txtBalanza.Text = String.Empty
        AxMSComm2.InputLen = 0
        AxMSComm2.RThreshold = 8
        AxMSComm2.InBufferCount = 0
    End Sub
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click

        AxMSComm2.CommPort = 4
        AxMSComm2.PortOpen = True         ' abrimos el puerto
        AxMSComm2.Settings = "9600,N,8,1"
        AxMSComm2.InputLen = 9
        AxMSComm2.RThreshold = 8
        AxMSComm2.InBufferCount = 0

        Enviar(0) = 7                ' Peticion de transmision de Datos debo enviar dos veces 7
        AxMSComm2.Output = Enviar       ' para que la balanza repsonda con peso con indicador de estabilidad
        AxMSComm2.Output = Enviar
    End Sub
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If AxMSComm2.PortOpen = True Then
            AxMSComm2.PortOpen = False
            txtBalanza.Text = ""
            AxMSComm2.InputLen = 0
            AxMSComm2.RThreshold = 8
        End If
    End Sub
    Private Sub cargarArticulos()
        Dim articulo As New Controlador.Articulos()
        Dim Facturacion As New Controlador.Facturacion()
        Dim UltimaFila As Integer
        Dim ObtenerTasa As Double
        Dim importe As Double
        Try

            If Not (articulo.es_Numero(Datos_Clientes.Id_Cliente.ToString())) Then
                txtCodigoCliente.Text = String.Empty
            ElseIf articulo.Compvariable = dfielddefConstantes.ArticulosFacturacion.ToString() Then
                articulo.Compvariable = String.Empty
                If Datos_Clientes.Id_Cliente <> Nothing Then
                    datos_Lista_Precio.Id_Lista_Precio = cbListaPrecio.SelectedValue.ToString()
                    articulo.recuperar_Datos(datos_Lista_Precio.Id_Lista_Precio, Datos_Articulo.Id_Producto, DatosArticuloCuerpoDocumento)
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
                                        importe = Math.Round((Convert.ToDouble(dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value)) * CDbl(Replace(dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value, ",", ".")), 2)
                                        DatosArticuloCuerpoDocumento.Importe = importe
                                        dgvFacturacion.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        obtenerImporteComprobante()
                                        dgvFacturacion.Rows.Add()
                                        dgvFacturacion.CurrentCell = dgvFacturacion.Rows(UltimaFila).Cells(0)
                                    Else
                                        MessageBox.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        articulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
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
                                        importe = Math.Round((Convert.ToDouble(dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value)) * CDbl(Replace(dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value, ",", ".")), 2)
                                        DatosArticuloCuerpoDocumento.Importe = importe
                                        dgvFacturacion.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                        obtenerImporteComprobante()
                                        dgvFacturacion.Rows.Add()
                                        dgvFacturacion.CurrentCell = dgvFacturacion.Rows(UltimaFila).Cells(0)
                                    Else
                                        Dim cantid As New Controlador.Cantidad()
                                        Dim FormCantidadad As New Vista.frmCantidad()
                                        cantid.CompDatos = DatosArticuloCuerpoDocumento ' datos
                                        cantid.CompDataGrid = dgvFacturacion
                                        cantid.CompTipoComprobante = Datos_Tipo_Comprobante.Descripcion ' tipoComprobante
                                        FormCantidadad.ShowDialog()
                                        DatosArticuloCuerpoDocumento = cantid.CompDatos
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
                                            Facturacion.obtenerTasa(DatosArticuloCuerpoDocumento.IdTasaIVa, ObtenerTasa)
                                            dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format((Replace(DatosArticuloCuerpoDocumento.PrecioVenta, ",", ".")) / ObtenerTasa, "##,##0.00")
                                            importe = CDbl(dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                            DatosArticuloCuerpoDocumento.Importe = importe
                                            dgvFacturacion.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                            obtenerImporteComprobante()
                                            dgvFacturacion.Rows.Add()
                                            dgvFacturacion.CurrentCell = dgvFacturacion.Rows(UltimaFila).Cells(0)
                                        Else
                                            MessageBox.Show("El Articulo es Pesable, conecte la balanza o ingrese el peso manualmente. ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            articulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
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
                                            Facturacion.obtenerTasa(DatosArticuloCuerpoDocumento.TasaIVa, ObtenerTasa)
                                            dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value = Format(Convert.ToDouble(Replace(DatosArticuloCuerpoDocumento.PrecioVenta, ",", ".")) / ObtenerTasa, "##,##0.00")
                                            DatosArticuloCuerpoDocumento.PrecioVenta = dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value
                                            importe = (dgvFacturacion.Rows(UltimaFila).Cells("Cantidad").Value) * CDbl(dgvFacturacion.Rows(UltimaFila).Cells("PrecioUnitario").Value)
                                            DatosArticuloCuerpoDocumento.Importe = importe
                                            dgvFacturacion.Rows(UltimaFila).Cells("Importe").Value = Format(importe, "##,##0.00")
                                            obtenerImporteComprobante()
                                            dgvFacturacion.Rows.Add()
                                            dgvFacturacion.CurrentCell = dgvFacturacion.Rows(UltimaFila).Cells(0)
                                        Else
                                            Dim cantid As New Controlador.Cantidad()
                                            Dim FormCantidadad As New Vista.frmCantidad()
                                            cantid.CompDatos = DatosArticuloCuerpoDocumento
                                            cantid.CompDataGrid = dgvFacturacion
                                            cantid.CompTipoComprobante = Datos_Tipo_Comprobante.Descripcion ' tipoComprobante
                                            FormCantidadad.ShowDialog()
                                            DatosArticuloCuerpoDocumento = cantid.CompDatos
                                            obtenerImporteComprobante()
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If txtBusquedaArticulo.Text.Trim() <> String.Empty Then
                            MessageBox.Show("El Articulo no pertenece a la lista de precio: " + cbListaPrecio.Text + " , agreguelo a la lista!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            articulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
                            Return
                        End If
                    End If
                End If
            Else
                MessageBox.Show("El Cliente no ha sido cargado!!!", "Informacion", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Information)
                articulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
                Return
            End If
            articulo.CompvariableCargarArticulo = dfielddefConstantes.No.ToString()
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

    Private Sub CargarDatosCliente(ByVal CodigoCliente As Integer, ByRef Datos_Clientes As Controlador.Cliente.eCliente)
        Dim Cliente As New Controlador.Cliente()
        Cliente.ObtenerDatosCliente(CodigoCliente, Datos_Clientes)
    End Sub
    Private Sub cbListaPrecio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbListaPrecio.SelectedIndexChanged
        Dim Facturacion As New Controlador.Facturacion
        If cbListaPrecio.ValueMember <> String.Empty Then

            If ListCuerpoFactura.Any() Then
                Dim result As Integer = MessageBox.Show("Al cambiar la lista de precios se borraran los articulos ingresados. Desea cambiar la lista de precios?", "Modificar Lista Precios", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = DialogResult.Yes Then
                    datos_Lista_Precio.Id_Lista_Precio = cbListaPrecio.SelectedValue

                    LimpiarEstructuras()
                    Facturacion.Limpiar_Importes_Comprobante(dgvFacturacion, txtNeto, txtDescuento, txtIVA21, txtIVA105, txtIVA27, TxtSubTotal, txtTotal)

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
        Dim tasaIva As New Controlador.TasaIVA()
        Dim datosiva As New DataTable()
        Dim idx As Integer
        Dim Facturacion As New Controlador.Facturacion()
        Dim ObtenerTasa As Double

        'consulta = "Select * " & vbCrLf
        'consulta += "From Tasa_IVA"
        tasaIva.recuperar_All_Datos(datosiva)
        idx = 1
        ReDim estTasaIVA(0)
        For i As Integer = 0 To datosiva.Rows.Count - 1
            ReDim Preserve estTasaIVA(idx)
            estTasaIVA(idx).Id_Tasa_IVA = datosiva.Rows(i).Item("Id_Tasa_IVA")
            estTasaIVA(idx).Descripcion = datosiva.Rows(i).Item("Descripcion")
            estTasaIVA(idx).Tasa = datosiva.Rows(i).Item("Tasa")
            idx = idx + 1
        Next

        ReDim Preserve Facturacion_Enc_estructura(1)
        If Datos_Tipo_Comprobante.Descripcion = "FACTURA B" Or Datos_Tipo_Comprobante.Descripcion = "FACTURA C" Then
            Facturacion.obtenerTasa(DatosArticuloCuerpoDocumento.TasaIVa, ObtenerTasa)

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
#End Region



End Class