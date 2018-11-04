Imports DevComponents.DotNetBar
Public Class frmBuscarComprobante
    Dim dfielddefFactuEncabezado As Controlador.clsDfieldDef.eEncabezadoFactura
    Dim idCliente As String
    Dim PorcDescuentos As String
    Dim dfieldefConstante As Controlador.clsDfieldDef.eConstantes
    Dim dfielddefCuerpoFact As Controlador.clsDfieldDef.eCuerpoFactura
    Dim dfielddefEmpresa As Controlador.clsDfieldDef.eEmpresa
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim Responsabilidad_IVA_Empresa As String
    Dim eFactEncESt(0) As Controlador.clsFacturacion.eEncabezadoFactura
    Dim eFactCuerpoESt(0) As Controlador.clsFacturacion.eCuerpoFactura
    Dim eNotaCredito_Enc_estructura(0) As Controlador.clsFacturacion.eEncabezadoFactura
    Dim eNotaCredito_Cuerpo_estructura(0) As Controlador.clsFacturacion.eCuerpoFactura
    Dim eArticulosEStFact(0) As Controlador.clsArticulos.eArticulo
    Dim eNumero_ComprobanteEStFact(0) As Controlador.clsNumeroComprobante.eNumeracionComprobante
    Dim dfielddecNumeroComprobante As Controlador.clsDfieldDef.eNumeroComprobante
    Dim eArticulos_Estructura(0) As Controlador.clsArticulos.eArticulo
    Dim eFomasdePagoContado(0) As Controlador.clsImputaciones.eImputaciones
    Dim eFomasdePagoCuentaCorriente(0) As Controlador.clsCuentaCorriente.eCuentaCorriente
    Dim clsformaPago As New Controlador.clsFormasDePago
    Dim tran As New Collection
    Dim clsFacturacion As New Controlador.clsFacturacion
    Dim clsEmpresa As New Controlador.clsEmpresas
    Dim clsCliente As New Controlador.clsCliente
    Dim clsArticulo As New Controlador.clsArticulos
    Dim clsTransaccion As New Controlador.clsTransacciones
    Dim clsImputaciones As New Controlador.clsImputaciones
    Dim clsCuentaCorriente As New Controlador.clsCuentaCorriente
    Dim eNumero_Condicion_IVA_Cliente As Controlador.clsCliente.eCondicion_Frente_Al_Iva
    Dim eDatoTipoComprobante As Controlador.clsFacturacion.eTipoComprobante
    Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante()
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder

    Private Sub BuscarComprobante_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Dim dtDatos As New DataTable
        Dim sucursal As String
        Dim listTipoComprobante As New List(Of String)
        Try
            clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtDatos)
            sucursal = dtDatos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
            If clsFacturacion.Compvariable = dfieldefConstante.FACTURA.ToString() Then
                listTipoComprobante.Add("'01','11','06'")
                clsFacturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            ElseIf clsFacturacion.Compvariable = dfieldefConstante.NotaCredito.ToString() Then
                listTipoComprobante.Add("'03','13','08'")
                clsFacturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            ElseIf clsFacturacion.Compvariable = dfieldefConstante.NotaDebito.ToString() Then
                listTipoComprobante.Add("'02','12','07'")
                clsFacturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            ElseIf clsFacturacion.Compvariable = dfieldefConstante.VentasRapidas.ToString() Then
                listTipoComprobante.Add("'18','16','17'")
                clsFacturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalir.Click
        Dim Fact As New Controlador.clsFacturacion
        Dim Cli As New Controlador.clsCliente
        Dim Art As New Controlador.clsArticulos
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Cli.CompCodigo = String.Empty
        Fact.CompPorcDescuentos = String.Empty
        Fact.Compvariable = String.Empty
        Art.Compvariable = String.Empty
        Me.Close()
    End Sub
    Private Sub dgvBuscarComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvBuscarComprobante.Click
        Try
            idCliente = dgvBuscarComprobante.CurrentRow.Cells(dfielddefFactuEncabezado.Numero_Cliente).Value.ToString()
            PorcDescuentos = dgvBuscarComprobante.CurrentRow.Cells("PorcDescuentos").Value.ToString()
            tbPuntoVenta.Text = dgvBuscarComprobante.CurrentRow.Cells(dfielddefFactuEncabezado.Punto_Venta).Value.ToString()
            tbTipoComprobante.Text = dgvBuscarComprobante.CurrentRow.Cells(dfielddefFactuEncabezado.Tipo_Comprobante).Value.ToString()
            tbNumeroComprobante.Text = dgvBuscarComprobante.CurrentRow.Cells(dfielddefFactuEncabezado.Numero_Comprobante).Value.ToString()
            tbComprobante.Text = dgvBuscarComprobante.CurrentRow.Cells(dfielddefFactuEncabezado.Comprobante).Value.ToString()
            tbApellido.Text = dgvBuscarComprobante.CurrentRow.Cells(dfielddefFactuEncabezado.Apellido).Value.ToString()
            tbNombre.Text = dgvBuscarComprobante.CurrentRow.Cells(dfielddefFactuEncabezado.Nombre).Value.ToString()
            tbCondicionIVA.Text = dgvBuscarComprobante.CurrentRow.Cells(dfielddefFactuEncabezado.Situacion_Frente_A_IVA).Value.ToString()

            Posicion_Columna = dgvBuscarComprobante.CurrentCell.ColumnIndex
            Nombre_Columna_a_Buscar = dgvBuscarComprobante.Columns(Posicion_Columna).Name

            If (Nombre_Columna_a_Buscar = Replace(dfieldefConstante.Punto_Venta.ToString(), "_", " ")) Then
                Me.Label9.Text = "Punto Venta:"
            Else
                If (Nombre_Columna_a_Buscar = Replace(dfieldefConstante.Tipo_Comprobante.ToString(), "_", " ")) Then
                    Me.Label9.Text = "Tipo Comprobante:"
                Else
                    If (Nombre_Columna_a_Buscar = Replace(dfieldefConstante.Numero_Comprobante.ToString(), "_", " ")) Then
                        Me.Label9.Text = "Numero Comprobante:"
                    Else
                        If (Nombre_Columna_a_Buscar = dfieldefConstante.Comprobante.ToString()) Then
                            Me.Label9.Text = "Comprobante:"
                        Else
                            If (Nombre_Columna_a_Buscar = dfieldefConstante.Nombre.ToString()) Then
                                Me.Label9.Text = "Nombre:"
                            Else
                                If (Nombre_Columna_a_Buscar = dfieldefConstante.Apellido.ToString()) Then
                                    Me.Label9.Text = "Apellido:"
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
    Private Sub ToolStripEnviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEnviar.Click
        Dim consulta As String
        Dim dtdatosCuerpoFact As New DataTable
        Dim idx As Integer

        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Try

            clsFacturacion.Obtener_Datos_Comprobante_Cuerpo_Factura(tbPuntoVenta.Text, tbTipoComprobante.Text, tbNumeroComprobante.Text, dtdatosCuerpoFact)
            clsFacturacion.ComplistOfCodProd.Clear()
            If clsFacturacion.Compvariable = dfieldefConstante.FACTURA.ToString() Then
                clsArticulo.Compvariable = dfieldefConstante.ArticulosFacturacion.ToString()
                clsCliente.CompCodigo = idCliente
                clsFacturacion.CompPorcDescuentos = PorcDescuentos
                clsArticulo.busquedaComprobante = "BuscarComprobante"
                clsFacturacion.CompPunto_Venta = tbPuntoVenta.Text
                clsFacturacion.CompTipo_Comprobante = tbTipoComprobante.Text
                clsFacturacion.CompNumero_Comprobante = tbNumeroComprobante.Text
                For idx = 0 To dtdatosCuerpoFact.Rows.Count - 1
                    clsFacturacion.ComplistOfCodProd.Add(dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString + vbCr)
                Next
            Else
                If clsFacturacion.Compvariable = dfieldefConstante.NotaCredito.ToString() Then
                    clsArticulo.Compvariable = dfieldefConstante.ArticulosNotaCredito.ToString()
                    Vista.frmNotaCredito.txtCodigoCliente.Text = idCliente
                    Vista.frmNotaCredito.dgvNotaCredito.DataSource = Nothing
                    For idx = 0 To dtdatosCuerpoFact.Rows.Count - 1
                        Vista.frmNotaCredito.txtBusquedaArticulo.Text = dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString()
                    Next
                Else
                    If clsFacturacion.Compvariable = dfieldefConstante.NotaDebito.ToString() Then
                        clsArticulo.Compvariable = dfieldefConstante.ArticulosNotaDebito.ToString()
                        Vista.frmNotaDebito.txtCodigoCliente.Text = idCliente
                        Vista.frmNotaDebito.dgvNotaDebito.DataSource = Nothing
                        For idx = 0 To dtdatosCuerpoFact.Rows.Count - 1
                            Vista.frmNotaDebito.txtBusquedaArticulo.Text = dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString()
                        Next
                    Else
                        If clsFacturacion.Compvariable = dfieldefConstante.VentasRapidas.ToString() Then
                            clsArticulo.Compvariable = dfieldefConstante.ArticulosVentaRapida.ToString()
                            Vista.frmVentaRapida.dgvVentaRapida.DataSource = Nothing
                            For idx = 0 To dtdatosCuerpoFact.Rows.Count - 1
                                Vista.frmVentaRapida.txtBusquedaArticulo.Text = dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString()
                            Next
                        End If
                    End If
                End If
            End If
            clsFacturacion.LimpiarDatosBusquedaComprobante(tbPuntoVenta, tbTipoComprobante, tbNumeroComprobante, tbComprobante, tbApellido, tbNombre, tbCondicionIVA)
            Me.Close()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBusqueda.TextChanged
        Dim consulta As String
        Dim dtDatos As New DataTable
        Dim sucursal As String
        Dim listTipoComprobante As New List(Of String)
        Try

            clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtDatos)
            sucursal = dtDatos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
            If Nombre_Columna_a_Buscar <> "" Then
                If clsFacturacion.Compvariable = dfieldefConstante.FACTURA.ToString() Then
                    listTipoComprobante.Add("'01','11','06'")
                ElseIf clsFacturacion.Compvariable = dfieldefConstante.NotaCredito.ToString() Then
                    listTipoComprobante.Add("'03','13','08'")
                ElseIf clsFacturacion.Compvariable = dfieldefConstante.NotaDebito.ToString() Then
                    listTipoComprobante.Add("'02','12','07'")
                ElseIf clsFacturacion.Compvariable = dfieldefConstante.VentasRapidas.ToString() Then
                    listTipoComprobante.Add("'18','16','17'")
                End If
                clsFacturacion.Busqueda(dgvBuscarComprobante, Nombre_Columna_a_Buscar, tbBusqueda.Text, sucursal, listTipoComprobante.Item(0), dfieldefConstante.No.ToString())
            Else
                MessageBoxEx.Show("Error: No selecciono ningun criterio de busqueda!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
  
    Public Sub LimpiarEstructuras()
        ReDim eFactEncESt(0)
        ReDim eFactCuerpoESt(0)
        ReDim eNumero_ComprobanteEStFact(0)
        ReDim eArticulosEStFact(0)
        ReDim eFomasdePagoContado(0)
        ReDim eFomasdePagoCuentaCorriente(0)
        ReDim eNotaCredito_Enc_estructura(0)
        ReDim eNotaCredito_Enc_estructura(0)
    End Sub
    Private Sub tbPuntoVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPuntoVenta.TextChanged
        If Not (clsFacturacion.es_Numero(tbPuntoVenta.Text)) Then
            tbPuntoVenta.Text = ""
        End If
    End Sub
    Private Sub tbTipoComprobante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbTipoComprobante.TextChanged
        If Not (clsFacturacion.es_Numero(tbTipoComprobante.Text)) Then
            tbTipoComprobante.Text = ""
        End If
    End Sub
    Private Sub tbNumeroComprobante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNumeroComprobante.TextChanged
        If Not (clsFacturacion.es_Numero(tbNumeroComprobante.Text)) Then
            tbNumeroComprobante.Text = ""
        End If
    End Sub
End Class