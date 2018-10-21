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
        'Dim clsFacturacion As New Controlador.clsFacturacion
        'Dim Empresa As New Controlador.clsEmpresas
        Dim dtDatos As New DataTable
        Dim sucursal As String
        Dim listTipoComprobante As New List(Of String)
        Try
            'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
            clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtDatos)
            sucursal = dtDatos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
            If clsFacturacion.Compvariable = dfieldefConstante.FACTURA.ToString() Then
                ToolStripButtonAnularComprobante.Enabled = True
                listTipoComprobante.Add("'01','11','06'")
                'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado  from Encabezado_Factura where Tipo_Comprobante in(" + listTipoComprobante.Item(0) + ") and Punto_Venta='" + sucursal + "'  and Cancelado='" + dfieldefConstante.No.ToString() + "'order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                clsFacturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            ElseIf clsFacturacion.Compvariable = dfieldefConstante.NotaCredito.ToString() Then
                ToolStripButtonAnularComprobante.Enabled = False
                'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from Encabezado_Factura where Tipo_Comprobante in('03','13','08') and Punto_Venta='" + sucursal + "' and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                listTipoComprobante.Add("'03','13','08'")
                clsFacturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            ElseIf clsFacturacion.Compvariable = dfieldefConstante.NotaDebito.ToString() Then
                ToolStripButtonAnularComprobante.Enabled = False
                'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from Encabezado_Factura where Tipo_Comprobante in('02','12','07') and Punto_Venta='" + sucursal + "' and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                listTipoComprobante.Add("'02','12','07'")
                clsFacturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            ElseIf clsFacturacion.Compvariable = dfieldefConstante.VentasRapidas.ToString() Then
                ToolStripButtonAnularComprobante.Enabled = True
                'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from Encabezado_Factura where Tipo_Comprobante in('18','16','17') and Punto_Venta='" + sucursal + "' and  Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
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
        'Dim CuerpoFac As New Controlador.clsFacturacion
        'Dim clsFacturacion As New Controlador.clsFacturacion
        Dim dtdatosCuerpoFact As New DataTable
        Dim idx As Integer
        'Dim articulo As New Controlador.clsArticulos()
        'Dim clsCliente As New Controlador.clsCliente()

        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Try
            'consulta = "select * from " + dfieldefConstante.Cuerpo_Factura.ToString() + " where Punto_Venta='" + tbPuntoVenta.Text + "' and Tipo_Comprobante='" + tbTipoComprobante.Text + "' and Numero_Comprobante='" + tbNumeroComprobante.Text + "' "
            clsFacturacion.Obtener_Datos_Comprobante_Cuerpo_Factura(tbPuntoVenta.Text, tbTipoComprobante.Text, tbNumeroComprobante.Text, dtdatosCuerpoFact)
            clsFacturacion.ComplistOfCodProd.Clear()
            If clsFacturacion.Compvariable = dfieldefConstante.FACTURA.ToString() Then
                clsArticulo.Compvariable = dfieldefConstante.ArticulosFacturacion.ToString()
                'Vista.Facturacion.txtCodigoCliente.Text = idCliente
                'Vista.Facturacion.TxtPorcDesc.Text = PorcDescuentos
                'Vista.Facturacion.dgvFacturacion.DataSource = Nothing
                clsCliente.CompCodigo = idCliente
                clsFacturacion.CompPorcDescuentos = PorcDescuentos
                clsArticulo.busquedaComprobante = "BuscarComprobante"
                For idx = 0 To dtdatosCuerpoFact.Rows.Count - 1
                    ' Vista.Facturacion.txtBusquedaArticulo.Text = datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString + vbCr
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
            'facturacion.Compvariable = ""
            'articulo.Compvariable = ""
            clsFacturacion.LimpiarDatosBusquedaComprobante(tbPuntoVenta, tbTipoComprobante, tbNumeroComprobante, tbComprobante, tbApellido, tbNombre, tbCondicionIVA)
            Me.Close()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBusqueda.TextChanged
        Dim consulta As String
        'Dim articulo As New Controlador.clsArticulos
        'Dim Empresa As New Controlador.clsEmpresas
        Dim dtDatos As New DataTable
        Dim sucursal As String
        'Dim clsFacturacion As New Controlador.clsFacturacion
        Dim listTipoComprobante As New List(Of String)
        Try
            'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
            clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtDatos)
            sucursal = dtDatos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
            If Nombre_Columna_a_Buscar <> "" Then
                If clsFacturacion.Compvariable = dfieldefConstante.FACTURA.ToString() Then
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from " + dfieldefConstante.Encabezado_Factura.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.tbBusqueda.Text & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante in('01','11','06') and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'01','11','06'")
                ElseIf clsFacturacion.Compvariable = dfieldefConstante.NotaCredito.ToString() Then
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from " + dfieldefConstante.Encabezado_Factura.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.tbBusqueda.Text & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante in('03','13','08') and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'03','13','08'")
                ElseIf clsFacturacion.Compvariable = dfieldefConstante.NotaDebito.ToString() Then
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from " + dfieldefConstante.Encabezado_Factura.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.tbBusqueda.Text & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante in('02','12','07') and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'02','12','07'")
                ElseIf clsFacturacion.Compvariable = dfieldefConstante.VentasRapidas.ToString() Then
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from " + dfieldefConstante.Encabezado_Factura.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.tbBusqueda.Text & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante in('18','16','17')and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'18','16','17'")
                End If
                clsFacturacion.Busqueda(dgvBuscarComprobante, Nombre_Columna_a_Buscar, tbBusqueda.Text, sucursal, listTipoComprobante.Item(0), dfieldefConstante.No.ToString())
            Else
                MessageBox.Show("Error: No selecciono ningun criterio de busqueda!!!", "Informacion", MessageBoxButtons.OK, _
                                                     MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripButtonAnularComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonAnularComprobante.Click
        Dim consulta As String
        'Dim CuerpoFac As New Controlador.clsFacturacion
        'Dim EncFac As New Controlador.clsFacturacion
        'Dim clsFacturacion As New Controlador.clsFacturacion
        Dim dtdatosCuerpoFact As New DataTable
        Dim dtdatosEncFact As New DataTable
        'Dim clsCliente As New Controlador.clsCliente
        'Dim Empresa As New Controlador.clsEmpresas()
        'Dim clsNumeroComprobante As New Controlador.clsNumeroComprobante()
        'Dim NotaCredito As New Controlador.clsFacturacion()
        Dim dtdatos As New DataTable
        'Dim Numero_Condicion_IVA_Cliente As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim ultimo As Integer
        'Dim Articulo As New Controlador.clsArticulos
        Dim dtArticulos As New DataTable
        Dim numeracion As String
        Dim IDComprobante As Integer
        Dim numeroComp As String
        Dim idx As Integer
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim ClavePrincipal As New Collection
        Dim datosCol As New Collection
        'Dim Transaccion As New Controlador.clsTransacciones
        'Dim clsImputaciones As New Controlador.clsImputaciones
        Dim UltimoCaja As Integer
        Dim UltimoCuentaCorriente As Integer
        'Dim clsCuentaCorriente As New Controlador.clsCuentaCorriente
        Dim sucursal As String
        'Dim Numero_Condicion_IVA_Cliente As Controlador.clsCliente.eCondicion_Frente_Al_Iva
        'Dim DatoTipoComprobante As Controlador.clsFacturacion.eTipoComprobante
        Dim listTipoComprobante As New List(Of String)
        Try
            If dgvBuscarComprobante.Rows.Count > 1 Then
                Dim result As Integer = MessageBox.Show("Desea Anular el Comprobante: " + tbPuntoVenta.Text + "-" + tbNumeroComprobante.Text + ", Con Nota de Credito Interna?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = DialogResult.Yes Then
                    'consulta = "select * from " + dfieldefConstante.Encabezado_Factura.ToString() + " where Punto_Venta='" + tbPuntoVenta.Text + "' and Tipo_Comprobante='" + tbTipoComprobante.Text + "' and Numero_Comprobante='" + tbNumeroComprobante.Text + "' "
                    clsFacturacion.Obtener_Datos_Comprobante_Encabezado_Factura(tbPuntoVenta.Text, tbTipoComprobante.Text, tbNumeroComprobante.Text, dtdatosEncFact)
                    'consulta = "select * from " + dfield.efConstante.Cuerpo_Factura.ToString() + " where Punto_Venta='" + tbPuntoVenta.Text + "' and Tipo_Comprobante='" + tbTipoComprobante.Text + "' and Numero_Comprobante='" + tbNumeroComprobante.Text + "' "
                    clsFacturacion.Obtener_Datos_Comprobante_Cuerpo_Factura(tbPuntoVenta.Text, tbTipoComprobante.Text, tbNumeroComprobante.Text, dtdatosCuerpoFact)

                    'consulta = "select * from " + dfieldefConstante.Empresa.ToString() + "  where Id_Empresa= '" + (Empresa.Compvariable) + "'"
                    clsEmpresa.Obtener_Empresa(clsEmpresa.Compvariable, dtdatos)
                    sucursal = dtdatos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
                    Responsabilidad_IVA_Empresa = dtdatos.Rows(0).Item(dfielddefEmpresa.Responsabilidad_IVA).ToString()

                    ' consulta = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (tbCondicionIVA.Text) & "' "
                    clsCliente.Obtener_CondicionFrenteAIVa(tbCondicionIVA.Text, eNumero_Condicion_IVA_Cliente)
                    'consulta = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                    clsEmpresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)

                    'consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                    'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                    'consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                    'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                    'consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                    'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                    'consulta += " and TC.IdTipoComprobante in ('3','8','13')"

                    clsFacturacion.Obtener_Datos_Comprobante(Numero_Condicion_IVA_Empresa, eNumero_Condicion_IVA_Cliente.Id_Condicion_IVA, dfieldefConstante.Nota_De_Credito_Int.ToString(), eDatoTipoComprobante)
                    'IDComprobante = datos.Rows(0).Item("IdTipoComprobante")
                    'tipoComprobante = datos.Rows(0).Item("Descripcion")

                    IDComprobante = eDatoTipoComprobante.IdTipoComprobante
                    tipoComprobante = eDatoTipoComprobante.Descripcion

                    ReDim eNotaCredito_Enc_estructura(1)
                    eNotaCredito_Enc_estructura(1).Punto_Venta = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Punto_Venta)
                    eNotaCredito_Enc_estructura(1).Tipo_Comprobante = Convert.ToString(IDComprobante).PadLeft(2, "0")
                    'consulta = "select max( Numeracion )from " + dfieldefConstante.Numeracion_Comprobante.ToString() + "  where Descripcion= '" + tipoComprobante + "'and Id_Empresa= '" + (Empresa.Compvariable) + "'"
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
                    eNotaCredito_Enc_estructura(1).Cancelado = dfieldefConstante.No.ToString()
                    eNotaCredito_Enc_estructura(1).Signo = -1
                    'consulta = "select *from " + dfieldefConstante.Numeracion_Comprobante.ToString() + "  where Descripcion= '" + tipoComprobante + "'and Id_Empresa= '" + (Empresa.Compvariable) + "'"
                    clsNumeroComprobante.obtener_Datos_Numero_Comprobante(tipoComprobante, clsEmpresa.Compvariable, dtdatos)

                    ReDim eNumero_ComprobanteEStFact(1)
                    eNumero_ComprobanteEStFact(1).Id_Comprobante = dtdatos.Rows(0).Item(dfielddecNumeroComprobante.Id_Comprobante)
                    eNumero_ComprobanteEStFact(1).Descripcion = dtdatos.Rows(0).Item(dfielddecNumeroComprobante.Descripcion)
                    eNumero_ComprobanteEStFact(1).Numeracion = numeracion.Trim
                    eNumero_ComprobanteEStFact(1).Id_Empresa = dtdatos.Rows(0).Item(dfielddecNumeroComprobante.Id_Empresa)
                    eNumero_ComprobanteEStFact(1).Id_Tipo_Comprobante = IDComprobante
                    idx = 0
                    For i = 1 To dtdatosCuerpoFact.Rows.Count
                        ReDim Preserve eNotaCredito_Cuerpo_estructura(i)
                        ReDim Preserve eArticulos_Estructura(i)
                        'consulta = "Select Max(IdCuerpoFactura) as Maximo from " + dfieldefConstante.Cuerpo_Factura.ToString() + " "
                        clsFacturacion.ObtenerUltimoNumeroCuerpoFactura(ultimo)
                        eNotaCredito_Cuerpo_estructura(i).IdCuerpoFactura = ultimo

                        eNotaCredito_Cuerpo_estructura(i).Punto_Venta = dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Punto_Venta)
                        eNotaCredito_Cuerpo_estructura(i).Tipo_Comprobante = Convert.ToString(IDComprobante).PadLeft(2, "0")
                        eNotaCredito_Cuerpo_estructura(i).Numero_Comprobante = numeracion.Trim
                        eNotaCredito_Cuerpo_estructura(i).Comprobante = tipoComprobante
                        eNotaCredito_Cuerpo_estructura(i).Numero_Articulo = dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo)
                        eNotaCredito_Cuerpo_estructura(i).Descripcion = dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Descripcion)
                        eNotaCredito_Cuerpo_estructura(i).Cantidad = Format(dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Cantidad) * -1, "##,##0.00")
                        eNotaCredito_Cuerpo_estructura(i).Precio_Unitario = Format(dtdatosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Precio_Unitario) * -1, "##,##0.00")
                        eNotaCredito_Cuerpo_estructura(i).Signo = -1
                        'consulta = "select * from " + dfieldefConstante.Producto.ToString() + " where Id_Producto='" + NotaCredito_Cuerpo_estructura(i).Numero_Articulo + "'"
                        clsArticulo.ObtenerProductos(eNotaCredito_Cuerpo_estructura(i).Numero_Articulo, dtArticulos)
                        eArticulos_Estructura(i).Id_Producto = eNotaCredito_Cuerpo_estructura(i).Numero_Articulo
                        eArticulos_Estructura(i).Stock = dtArticulos.Rows(0).Item("Stock")
                        idx = idx + 1
                    Next
                    eFactEncESt = eNotaCredito_Enc_estructura
                    clsquerybuilder.obtener_estructura(dfieldefConstante.Encabezado_Factura.ToString(), esquema)
                    clsFacturacion.Obtener_Clave_Principal_Encabezado_Factura(ClavePrincipal)
                    clsFacturacion.Pasar_A_Coleccion_Encabezado_Factura(eFactEncESt, datosCol, 1)
                    clsquerybuilder.ArmaInsert(dfieldefConstante.Encabezado_Factura.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    esquema.Clear()
                    datosCol.Clear()
                    ClavePrincipal.Clear()
                    clsQueryBuilder.obtener_estructura(dfieldefConstante.Numeracion_Comprobante.ToString(), esquema)
                    clsNumeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
                    clsNumeroComprobante.Pasar_A_Coleccion(eNumero_ComprobanteEStFact, datosCol, 1)
                    clsQueryBuilder.ArmaUpdate(dfieldefConstante.Numeracion_Comprobante.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    esquema.Clear()
                    datosCol.Clear()
                    ClavePrincipal.Clear()
                    clsQueryBuilder.obtener_estructura(dfieldefConstante.Cuerpo_Factura.ToString(), esquema)
                    clsFacturacion.Obtener_Clave_Principal_Cuerpo_Factura(ClavePrincipal)
                    eFactCuerpoESt = eNotaCredito_Cuerpo_estructura
                    eArticulosEStFact = eArticulos_Estructura
                    For i = 1 To eFactCuerpoESt.Count - 1
                        'consulta = "Select Max(IdCuerpoFactura) as Maximo from " + dfieldefConstante.Cuerpo_Factura.ToString() + ""
                        clsFacturacion.ObtenerUltimoNumeroCuerpoFactura(ultimo)
                        eFactCuerpoESt(i).IdCuerpoFactura = ultimo
                        clsFacturacion.Pasar_A_Coleccion_Cuerpo_Factura(eFactCuerpoESt, datosCol, i)
                        clsQueryBuilder.ArmaInsert(dfieldefConstante.Cuerpo_Factura.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                        tran.Add(consulta)
                        consulta = ""
                        datosCol.Clear()
                        If (eFactCuerpoESt(i).Numero_Articulo = eArticulosEStFact(i).Id_Producto) Then
                            eArticulosEStFact(i).Stock = eArticulosEStFact(i).Stock - eFactCuerpoESt(i).Cantidad
                            consulta = "update " + dfieldefConstante.Producto.ToString() + " set Stock='" + (eArticulosEStFact(i).Stock) + "' where ID_Producto= '" + (eFactCuerpoESt(i).Numero_Articulo) + "'"
                            tran.Add(consulta)
                        End If
                        consulta = ""
                    Next
                    'consulta = ""
                    'esquema.Clear()
                    'datosCol.Clear()
                    'ClavePrincipal.Clear()

                    'If (datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Forma_Pago) = dfieldefConstante.Contado.ToString()) Or (datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.ID_Forma_Pago) = "1") Then
                    '    'consulta = "Select Max(IdImputaciones) as Maximo from " + dfieldefConstante.Imputaciones.ToString() + ""
                    '    Imputaciones.ObtenerUltimoNumeroImputaciones(UltimoCaja)
                    '    ReDim FomasdePagoContado(1)
                    '    FomasdePagoContado(1).IdImputaciones = UltimoCaja
                    '    'FomasdePagoContado(1).PuntoVentaRecibo = FactEncESt(1).
                    '    'FomasdePagoContado(1).TipoComprobanteRecibo = FactEncESt(1).Tipo_Comprobante
                    '    'FomasdePagoContado(1).NumeroComprobanteRecibo = FactEncESt(1).Numero_Comprobante
                    '    FomasdePagoContado(1).Comprobante = FactEncESt(1).Comprobante
                    '    FomasdePagoContado(1).NumeroCliente = FactEncESt(1).Numero_Cliente
                    '    FomasdePagoContado(1).Fecha = Date.Now()
                    '    FomasdePagoContado(1).PuntoVenta = FactEncESt(1).Punto_Venta
                    '    FomasdePagoContado(1).TipoComprobante = FactEncESt(1).Tipo_Comprobante
                    '    FomasdePagoContado(1).NumeroComprobante = FactEncESt(1).Numero_Comprobante
                    '    FomasdePagoContado(1).Importe = FactEncESt(1).Total
                    '    FomasdePagoContado(1).ID_FormaPago = FactEncESt(1).Id_Forma_Pago
                    '    FomasdePagoContado(1).Descripcion = dfieldefConstante.CancelacionNotaCredito.ToString()
                    '    FomasdePagoContado(1).Signo = "-1"

                    '    querybuilder.obtener_estructura(dfieldefConstante.Imputaciones.ToString(), esquema)
                    '    Imputaciones.Obtener_Clave_Principal(ClavePrincipal)
                    '    Imputaciones.Pasar_A_Coleccion(FomasdePagoContado, datosCol, 1)
                    '    querybuilder.ArmaInsert(dfieldefConstante.Imputaciones.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                    '    tran.Add(consulta)
                    'ElseIf (datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Forma_Pago) = dfieldefConstante.CuentaCorriente.ToString()) Or (datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.ID_Forma_Pago) = "2") Then
                    '    'consulta = "Select Max(IdCuentaCorriente) as Maximo from " + dfieldefConstante.CuentaCorriente.ToString() + ""
                    '    CuentaCorriente.ObtenerUltimoNumeroCuentaCorriente(UltimoCuentaCorriente)
                    '    ReDim FomasdePagoCuentaCorriente(1)
                    '    FomasdePagoCuentaCorriente(1).Id_CuentaCorriente = UltimoCuentaCorriente
                    '    FomasdePagoCuentaCorriente(1).PuntoVenta = FactEncESt(1).Punto_Venta
                    '    FomasdePagoCuentaCorriente(1).TipoComprobante = FactEncESt(1).Tipo_Comprobante
                    '    FomasdePagoCuentaCorriente(1).NumeroComprobante = FactEncESt(1).Numero_Comprobante
                    '    FomasdePagoCuentaCorriente(1).Comprobante = FactEncESt(1).Comprobante
                    '    FomasdePagoCuentaCorriente(1).NumeroCliente = FactEncESt(1).Numero_Cliente
                    '    FomasdePagoCuentaCorriente(1).Fecha = Date.Now()

                    '    FomasdePagoCuentaCorriente(1).Importe = FactEncESt(1).Total
                    '    FomasdePagoCuentaCorriente(1).Descripcion = dfieldefConstante.CancelacionNotaCredito.ToString()
                    '    FomasdePagoCuentaCorriente(1).Signo = "-1"

                    '    querybuilder.obtener_estructura(dfieldefConstante.CuentaCorriente.ToString(), esquema)
                    '    CuentaCorriente.Obtener_Clave_Principal(ClavePrincipal)
                    '    CuentaCorriente.Pasar_A_Coleccion(FomasdePagoCuentaCorriente, datosCol, 1)
                    '    querybuilder.ArmaInsert(dfieldefConstante.CuentaCorriente.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                    '    tran.Add(consulta)
                    'End If
                    ReDim Preserve eFactEncESt(1)
                    eFactEncESt(1).Punto_Venta = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Punto_Venta)
                    eFactEncESt(1).Tipo_Comprobante = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Tipo_Comprobante)
                    eFactEncESt(1).Numero_Comprobante = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Numero_Comprobante)
                    eFactEncESt(1).Comprobante = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Comprobante)
                    eFactEncESt(1).Numero_Cliente = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Numero_Cliente)
                    eFactEncESt(1).Nombre = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Nombre)
                    eFactEncESt(1).Apellido = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Apellido)
                    eFactEncESt(1).Situacion_Frente_A_IVA = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Situacion_Frente_A_IVA)
                    eFactEncESt(1).Id_Forma_Pago = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.ID_Forma_Pago)
                    eFactEncESt(1).Forma_Pago = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Forma_Pago)
                    eFactEncESt(1).Fecha_Comprobante = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Fecha_Comprobante)
                    eFactEncESt(1).Codigo_Vendedor = 1

                    eFactEncESt(1).Neto_Grabado_21 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_21))
                    eFactEncESt(1).Neto_Grabado_105 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_105))
                    eFactEncESt(1).Neto_Grabado_27 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_27))
                    eFactEncESt(1).Sub_Total = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Sub_Total))
                    eFactEncESt(1).Conc_No_Grabado = ""
                    eFactEncESt(1).Exentos = ""
                    eFactEncESt(1).IVA_Facturado21 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado21))
                    eFactEncESt(1).IVA_Facturado105 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado105))
                    eFactEncESt(1).IVA_Facturado27 = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado27))
                    eFactEncESt(1).IVA_Resp_No_Inscripto = ""
                    eFactEncESt(1).Persepciones = ""
                    eFactEncESt(1).PorcDescuentos = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.PorcDescuentos))

                    If dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos) = "" Then
                        eFactEncESt(1).Descuentos = "0"
                    Else
                        eFactEncESt(1).Descuentos = dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos)
                    End If
                    eFactEncESt(1).Retenciones = ""
                    eFactEncESt(1).Total = Convert.ToString(dtdatosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Total))
                    eFactEncESt(1).Cancelado = dfieldefConstante.Si.ToString()
                    eFactEncESt(1).Signo = 1
                    consulta = ""
                    esquema.Clear()
                    datosCol.Clear()
                    ClavePrincipal.Clear()
                    clsQueryBuilder.obtener_estructura(dfieldefConstante.Encabezado_Factura.ToString(), esquema)
                    clsFacturacion.Obtener_Clave_Principal_Encabezado_Factura(ClavePrincipal)
                    clsFacturacion.Pasar_A_Coleccion_Encabezado_Factura(eFactEncESt, datosCol, 1)
                    clsQueryBuilder.ArmaUpdate(dfieldefConstante.Encabezado_Factura.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    For idx = 1 To tran.Count
                        clsTransaccion.Operaciones_Tabla(tran(idx))
                    Next
                    tran.Clear()
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [T. Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [F. Comprobante],Cancelado  from Encabezado_Factura where Tipo_Comprobante in('01','11','06','18','16','17') and Punto_Venta='" + sucursal + "'  and Cancelado='" + dfieldefConstante.No.ToString() + "'order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'01','11','06','18','16','17'")
                    clsFacturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)

                    MessageBox.Show("El Comprobante " + tbPuntoVenta.Text + "-" + tbNumeroComprobante.Text + " ,se ha Anulado Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Information)
                    LimpiarEstructuras()
                    clsFacturacion.LimpiarDatosBusquedaComprobante(tbPuntoVenta, tbTipoComprobante, tbNumeroComprobante, tbComprobante, tbApellido, tbNombre, tbCondicionIVA)
                End If
            Else
                MessageBox.Show("No hay comprobantes a anular!", "Informacion", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Information)
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
        'Dim clsFacturacion As New Controlador.clsFacturacion
        If Not (clsFacturacion.es_Numero(tbPuntoVenta.Text)) Then
            tbPuntoVenta.Text = ""
        End If
    End Sub
    Private Sub tbTipoComprobante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbTipoComprobante.TextChanged
        'Dim clsFacturacion As New Controlador.clsFacturacion
        If Not (clsFacturacion.es_Numero(tbTipoComprobante.Text)) Then
            tbTipoComprobante.Text = ""
        End If
    End Sub
    Private Sub tbNumeroComprobante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNumeroComprobante.TextChanged
        'Dim clsFacturacion As New Controlador.clsFacturacion
        If Not (clsFacturacion.es_Numero(tbNumeroComprobante.Text)) Then
            tbNumeroComprobante.Text = ""
        End If
    End Sub
End Class