Public Class frmBuscarComprobante
    Dim dfielddefFactuEncabezado As Controlador.DfieldDef.eEncabezadoFactura
    Dim idCliente As String
    Dim PorcDescuentos As String
    Dim dfieldefConstante As Controlador.DfieldDef.eConstantes
    Dim dfielddefCuerpoFact As Controlador.DfieldDef.eCuerpoFactura
    Dim dfielddefEmpresa As Controlador.DfieldDef.eEmpresa
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Dim Responsabilidad_IVA_Empresa As String
    Dim FactEncESt(0) As Controlador.Facturacion.eEncabezadoFactura
    Dim FactCuerpoESt(0) As Controlador.Facturacion.eCuerpoFactura
    Public NotaCredito_Enc_estructura(0) As Controlador.Facturacion.eEncabezadoFactura
    Public NotaCredito_Cuerpo_estructura(0) As Controlador.Facturacion.eCuerpoFactura
    Dim ArticulosEStFact(0) As Controlador.Articulos.eArticulo
    Dim Numero_ComprobanteEStFact(0) As Controlador.NumeroComprobante.eNumeracionComprobante
    Dim dfielddecNumeroComprobante As Controlador.DfieldDef.eNumeroComprobante
    Public Articulos_Estructura(0) As Controlador.Articulos.eArticulo
    Dim FomasdePagoContado(0) As Controlador.Imputaciones.eImputaciones
    Dim FomasdePagoCuentaCorriente(0) As Controlador.CuentaCorriente.eCuentaCorriente
    Dim formaPago As New Controlador.FormasDePago
    Dim tran As New Collection
    Private Sub BuscarComprobante_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Dim facturacion As New Controlador.Facturacion
        Dim Empresa As New Controlador.Empresas
        Dim Datos As New DataTable
        Dim sucursal As String
        Dim listTipoComprobante As New List(Of String)
        Try
            'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
            Empresa.Obtener_Empresa(Empresa.Compvariable, Datos)
            sucursal = Datos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
            If facturacion.Compvariable = dfieldefConstante.FACTURA.ToString() Then
                ToolStripButtonAnularComprobante.Enabled = True
                listTipoComprobante.Add("'01','11','06'")
                'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado  from Encabezado_Factura where Tipo_Comprobante in(" + listTipoComprobante.Item(0) + ") and Punto_Venta='" + sucursal + "'  and Cancelado='" + dfieldefConstante.No.ToString() + "'order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                facturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            ElseIf facturacion.Compvariable = dfieldefConstante.NotaCredito.ToString() Then
                ToolStripButtonAnularComprobante.Enabled = False
                'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from Encabezado_Factura where Tipo_Comprobante in('03','13','08') and Punto_Venta='" + sucursal + "' and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                listTipoComprobante.Add("'03','13','08'")
                facturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            ElseIf facturacion.Compvariable = dfieldefConstante.NotaDebito.ToString() Then
                ToolStripButtonAnularComprobante.Enabled = False
                'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from Encabezado_Factura where Tipo_Comprobante in('02','12','07') and Punto_Venta='" + sucursal + "' and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                listTipoComprobante.Add("'02','12','07'")
                facturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            ElseIf facturacion.Compvariable = dfieldefConstante.VentasRapidas.ToString() Then
                ToolStripButtonAnularComprobante.Enabled = True
                'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from Encabezado_Factura where Tipo_Comprobante in('18','16','17') and Punto_Venta='" + sucursal + "' and  Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                listTipoComprobante.Add("'18','16','17'")
                facturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalir.Click
        Dim Fact As New Controlador.Facturacion
        Dim Cli As New Controlador.Cliente
        Dim Art As New Controlador.Articulos
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
        Dim CuerpoFac As New Controlador.Facturacion
        Dim facturacion As New Controlador.Facturacion
        Dim datosCuerpoFact As New DataTable
        Dim idx As Integer
        Dim articulo As New Controlador.Articulos()
        Dim Cliente As New Controlador.Cliente()

        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Try
            'consulta = "select * from " + dfieldefConstante.Cuerpo_Factura.ToString() + " where Punto_Venta='" + tbPuntoVenta.Text + "' and Tipo_Comprobante='" + tbTipoComprobante.Text + "' and Numero_Comprobante='" + tbNumeroComprobante.Text + "' "
            CuerpoFac.Obtener_Datos_Comprobante_Cuerpo_Factura(tbPuntoVenta.Text, tbTipoComprobante.Text, tbNumeroComprobante.Text, datosCuerpoFact)
            facturacion.ComplistOfCodProd.Clear()
            If facturacion.Compvariable = dfieldefConstante.FACTURA.ToString() Then
                articulo.Compvariable = dfieldefConstante.ArticulosFacturacion.ToString()
                'Vista.Facturacion.txtCodigoCliente.Text = idCliente
                'Vista.Facturacion.TxtPorcDesc.Text = PorcDescuentos
                'Vista.Facturacion.dgvFacturacion.DataSource = Nothing
                Cliente.CompCodigo = idCliente
                facturacion.CompPorcDescuentos = PorcDescuentos
                articulo.busquedaComprobante = "BuscarComprobante"
                For idx = 0 To datosCuerpoFact.Rows.Count - 1
                    ' Vista.Facturacion.txtBusquedaArticulo.Text = datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString + vbCr
                    facturacion.ComplistOfCodProd.Add(datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString + vbCr)
                Next
            Else
                If facturacion.Compvariable = dfieldefConstante.NotaCredito.ToString() Then
                    articulo.Compvariable = dfieldefConstante.ArticulosNotaCredito.ToString()
                    Vista.frmNotaCredito.txtCodigoCliente.Text = idCliente
                    Vista.frmNotaCredito.dgvNotaCredito.DataSource = Nothing
                    For idx = 0 To datosCuerpoFact.Rows.Count - 1
                        Vista.frmNotaCredito.txtBusquedaArticulo.Text = datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString()
                    Next
                Else
                    If facturacion.Compvariable = dfieldefConstante.NotaDebito.ToString() Then
                        articulo.Compvariable = dfieldefConstante.ArticulosNotaDebito.ToString()
                        Vista.frmNotaDebito.txtCodigoCliente.Text = idCliente
                        Vista.frmNotaDebito.dgvNotaDebito.DataSource = Nothing
                        For idx = 0 To datosCuerpoFact.Rows.Count - 1
                            Vista.frmNotaDebito.txtBusquedaArticulo.Text = datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString()
                        Next
                    Else
                        If facturacion.Compvariable = dfieldefConstante.VentasRapidas.ToString() Then
                            articulo.Compvariable = dfieldefConstante.ArticulosVentaRapida.ToString()
                            Vista.frmVentaRapida.dgvVentaRapida.DataSource = Nothing
                            For idx = 0 To datosCuerpoFact.Rows.Count - 1
                                Vista.frmVentaRapida.txtBusquedaArticulo.Text = datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo).ToString()
                            Next
                        End If
                    End If
                End If
            End If
            'facturacion.Compvariable = ""
            'articulo.Compvariable = ""
            facturacion.LimpiarDatosBusquedaComprobante(tbPuntoVenta, tbTipoComprobante, tbNumeroComprobante, tbComprobante, tbApellido, tbNombre, tbCondicionIVA)
            Me.Close()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub txtBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBusqueda.TextChanged
        Dim consulta As String
        Dim articulo As New Controlador.Articulos
        Dim Empresa As New Controlador.Empresas
        Dim Datos As New DataTable
        Dim sucursal As String
        Dim facturacion As New Controlador.Facturacion
        Dim listTipoComprobante As New List(Of String)
        Try
            'consulta = "select * from Empresa where Id_Empresa= '" + (Empresa.Compvariable) + "'"
            Empresa.Obtener_Empresa(Empresa.Compvariable, Datos)
            sucursal = Datos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
            If Nombre_Columna_a_Buscar <> "" Then
                If facturacion.Compvariable = dfieldefConstante.FACTURA.ToString() Then
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from " + dfieldefConstante.Encabezado_Factura.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.tbBusqueda.Text & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante in('01','11','06') and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'01','11','06'")
                ElseIf facturacion.Compvariable = dfieldefConstante.NotaCredito.ToString() Then
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from " + dfieldefConstante.Encabezado_Factura.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.tbBusqueda.Text & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante in('03','13','08') and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'03','13','08'")
                ElseIf facturacion.Compvariable = dfieldefConstante.NotaDebito.ToString() Then
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from " + dfieldefConstante.Encabezado_Factura.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.tbBusqueda.Text & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante in('02','12','07') and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'02','12','07'")
                ElseIf facturacion.Compvariable = dfieldefConstante.VentasRapidas.ToString() Then
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [Tip Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [Fech Comprobante],Cancelado from " + dfieldefConstante.Encabezado_Factura.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.tbBusqueda.Text & "%' and Punto_Venta='" + sucursal + "' and Tipo_Comprobante in('18','16','17')and Cancelado='" + dfieldefConstante.No.ToString() + "' order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'18','16','17'")
                End If
                facturacion.Busqueda(dgvBuscarComprobante, Nombre_Columna_a_Buscar, tbBusqueda.Text, sucursal, listTipoComprobante.Item(0), dfieldefConstante.No.ToString())
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
        Dim CuerpoFac As New Controlador.Facturacion
        Dim EncFac As New Controlador.Facturacion
        Dim facturacion As New Controlador.Facturacion
        Dim datosCuerpoFact As New DataTable
        Dim datosEncFact As New DataTable
        Dim Cliente As New Controlador.Cliente
        Dim Empresa As New Controlador.Empresas()
        Dim NumeroComprobante As New Controlador.NumeroComprobante()
        Dim NotaCredito As New Controlador.Facturacion()
        Dim datos As New DataTable
        'Dim Numero_Condicion_IVA_Cliente As Integer
        Dim Numero_Condicion_IVA_Empresa As Integer
        Dim Numero_Sucursal As String
        Dim tipoComprobante As String
        Dim ultimo As Integer
        Dim Articulo As New Controlador.Articulos
        Dim dtArticulos As New DataTable
        Dim numeracion As String
        Dim IDComprobante As Integer
        Dim numeroComp As String
        Dim idx As Integer
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim ClavePrincipal As New Collection
        Dim datosCol As New Collection
        Dim Transaccion As New Controlador.Transacciones
        Dim Imputaciones As New Controlador.Imputaciones
        Dim UltimoCaja As Integer
        Dim UltimoCuentaCorriente As Integer
        Dim CuentaCorriente As New Controlador.CuentaCorriente
        Dim sucursal As String
        Dim Numero_Condicion_IVA_Cliente As Controlador.Cliente.eCondicion_Frente_Al_Iva
        Dim DatoTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim listTipoComprobante As New List(Of String)
        Try
            If dgvBuscarComprobante.Rows.Count > 1 Then
                Dim result As Integer = MessageBox.Show("Desea Anular el Comprobante: " + tbPuntoVenta.Text + "-" + tbNumeroComprobante.Text + ", Con Nota de Credito Interna?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If result = DialogResult.Yes Then
                    'consulta = "select * from " + dfieldefConstante.Encabezado_Factura.ToString() + " where Punto_Venta='" + tbPuntoVenta.Text + "' and Tipo_Comprobante='" + tbTipoComprobante.Text + "' and Numero_Comprobante='" + tbNumeroComprobante.Text + "' "
                    EncFac.Obtener_Datos_Comprobante_Encabezado_Factura(tbPuntoVenta.Text, tbTipoComprobante.Text, tbNumeroComprobante.Text, datosEncFact)
                    'consulta = "select * from " + dfield.efConstante.Cuerpo_Factura.ToString() + " where Punto_Venta='" + tbPuntoVenta.Text + "' and Tipo_Comprobante='" + tbTipoComprobante.Text + "' and Numero_Comprobante='" + tbNumeroComprobante.Text + "' "
                    CuerpoFac.Obtener_Datos_Comprobante_Cuerpo_Factura(tbPuntoVenta.Text, tbTipoComprobante.Text, tbNumeroComprobante.Text, datosCuerpoFact)

                    'consulta = "select * from " + dfieldefConstante.Empresa.ToString() + "  where Id_Empresa= '" + (Empresa.Compvariable) + "'"
                    Empresa.Obtener_Empresa(Empresa.Compvariable, datos)
                    sucursal = datos.Rows(0).Item(dfielddefEmpresa.Nro_Sucursal).ToString()
                    Responsabilidad_IVA_Empresa = datos.Rows(0).Item(dfielddefEmpresa.Responsabilidad_IVA).ToString()

                    ' consulta = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (tbCondicionIVA.Text) & "' "
                    Cliente.Obtener_CondicionFrenteAIVa(tbCondicionIVA.Text, Numero_Condicion_IVA_Cliente)
                    'consulta = "select Id_Condicion_IVA from Condicion_Frente_Al_IVA where Condicion_Frente_Al_IVA.Descripcion= '" & (Responsabilidad_IVA_Empresa) & "' "
                    Empresa.Obtener_Responsabilidad_IVA_Empresa(Responsabilidad_IVA_Empresa, Numero_Condicion_IVA_Empresa)

                    'consulta = " Select TC.IdTipoComprobante,TC.Descripcion" & vbCrLf
                    'consulta += " from (Tipos_Comprobantes as TC" & vbCrLf
                    'consulta += " inner join Comprobantes as C on TC.IdTipoComprobante=C.IdComprobantes)" & vbCrLf
                    'consulta += " where C.IdCondFrenteIvaEmpresa='" & (Numero_Condicion_IVA_Empresa) & "' " & vbCrLf
                    'consulta += " and C.IdCondFrenteIvaCliente='" & (Numero_Condicion_IVA_Cliente) & "' " & vbCrLf
                    'consulta += " and (C.IdComprobantes)=TC.IdTipoComprobante" & vbCrLf
                    'consulta += " and TC.IdTipoComprobante in ('3','8','13')"

                    facturacion.Obtener_Datos_Comprobante(Numero_Condicion_IVA_Empresa, Numero_Condicion_IVA_Cliente.Id_Condicion_IVA, dfieldefConstante.Nota_De_Credito_Int.ToString(), DatoTipoComprobante)
                    'IDComprobante = datos.Rows(0).Item("IdTipoComprobante")
                    'tipoComprobante = datos.Rows(0).Item("Descripcion")

                    IDComprobante = DatoTipoComprobante.IdTipoComprobante
                    tipoComprobante = DatoTipoComprobante.Descripcion

                    ReDim NotaCredito_Enc_estructura(1)
                    NotaCredito_Enc_estructura(1).Punto_Venta = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Punto_Venta)
                    NotaCredito_Enc_estructura(1).Tipo_Comprobante = Convert.ToString(IDComprobante).PadLeft(2, "0")
                    'consulta = "select max( Numeracion )from " + dfieldefConstante.Numeracion_Comprobante.ToString() + "  where Descripcion= '" + tipoComprobante + "'and Id_Empresa= '" + (Empresa.Compvariable) + "'"
                    NumeroComprobante.ObtenerUltimoNumeroComprobante(tipoComprobante, Empresa.Compvariable, ultimo)
                    NumeroComprobante.Aumentar_Numeracion_Comprobante(ultimo, numeracion)
                    NotaCredito_Enc_estructura(1).Numero_Comprobante = numeracion.Trim
                    NotaCredito_Enc_estructura(1).Comprobante = tipoComprobante
                    NotaCredito_Enc_estructura(1).Numero_Cliente = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Numero_Cliente)
                    NotaCredito_Enc_estructura(1).Nombre = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Nombre)
                    NotaCredito_Enc_estructura(1).Apellido = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Apellido)
                    NotaCredito_Enc_estructura(1).Situacion_Frente_A_IVA = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Situacion_Frente_A_IVA)
                    NotaCredito_Enc_estructura(1).Id_Forma_Pago = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.ID_Forma_Pago)
                    NotaCredito_Enc_estructura(1).Forma_Pago = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Forma_Pago)
                    NotaCredito_Enc_estructura(1).Fecha_Comprobante = Date.Now.ToShortDateString()
                    NotaCredito_Enc_estructura(1).Codigo_Vendedor = 1
                    NotaCredito_Enc_estructura(1).Neto_Grabado_21 = Format(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_21) * -1, "##,##0.00")
                    NotaCredito_Enc_estructura(1).Neto_Grabado_105 = Format(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_105) * -1, "##,##0.00")
                    NotaCredito_Enc_estructura(1).Neto_Grabado_27 = Format(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_27) * -1, "##,##0.00")
                    NotaCredito_Enc_estructura(1).Sub_Total = Format(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Sub_Total) * -1, "##,##0.00")
                    NotaCredito_Enc_estructura(1).Conc_No_Grabado = ""
                    NotaCredito_Enc_estructura(1).Exentos = ""
                    NotaCredito_Enc_estructura(1).IVA_Facturado21 = Format(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado21) * -1, "##,##0.00")
                    NotaCredito_Enc_estructura(1).IVA_Facturado105 = Format(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado105) * -1, "##,##0.00")
                    NotaCredito_Enc_estructura(1).IVA_Facturado27 = Format(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado27) * -1, "##,##0.00")
                    NotaCredito_Enc_estructura(1).IVA_Resp_No_Inscripto = ""
                    NotaCredito_Enc_estructura(1).Persepciones = ""
                    NotaCredito_Enc_estructura(1).PorcDescuentos = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.PorcDescuentos)
                    If datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos) = "" Then
                        NotaCredito_Enc_estructura(1).Descuentos = "0"
                    Else
                        NotaCredito_Enc_estructura(1).Descuentos = Format(Replace(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos), ",", ".") * -1, "##,##0.00")
                    End If
                    NotaCredito_Enc_estructura(1).Retenciones = ""
                    NotaCredito_Enc_estructura(1).Total = Format(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Total) * -1, "##,##0.00")
                    NotaCredito_Enc_estructura(1).Cancelado = dfieldefConstante.No.ToString()
                    NotaCredito_Enc_estructura(1).Signo = -1
                    'consulta = "select *from " + dfieldefConstante.Numeracion_Comprobante.ToString() + "  where Descripcion= '" + tipoComprobante + "'and Id_Empresa= '" + (Empresa.Compvariable) + "'"
                    NumeroComprobante.obtener_Datos_Numero_Comprobante(tipoComprobante, Empresa.Compvariable, datos)

                    ReDim Numero_ComprobanteEStFact(1)
                    Numero_ComprobanteEStFact(1).Id_Comprobante = datos.Rows(0).Item(dfielddecNumeroComprobante.Id_Comprobante)
                    Numero_ComprobanteEStFact(1).Descripcion = datos.Rows(0).Item(dfielddecNumeroComprobante.Descripcion)
                    Numero_ComprobanteEStFact(1).Numeracion = numeracion.Trim
                    Numero_ComprobanteEStFact(1).Id_Empresa = datos.Rows(0).Item(dfielddecNumeroComprobante.Id_Empresa)
                    Numero_ComprobanteEStFact(1).Id_Tipo_Comprobante = IDComprobante
                    idx = 0
                    For i = 1 To datosCuerpoFact.Rows.Count
                        ReDim Preserve NotaCredito_Cuerpo_estructura(i)
                        ReDim Preserve Articulos_Estructura(i)
                        'consulta = "Select Max(IdCuerpoFactura) as Maximo from " + dfieldefConstante.Cuerpo_Factura.ToString() + " "
                        facturacion.ObtenerUltimoNumeroCuerpoFactura(ultimo)
                        NotaCredito_Cuerpo_estructura(i).IdCuerpoFactura = ultimo

                        NotaCredito_Cuerpo_estructura(i).Punto_Venta = datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Punto_Venta)
                        NotaCredito_Cuerpo_estructura(i).Tipo_Comprobante = Convert.ToString(IDComprobante).PadLeft(2, "0")
                        NotaCredito_Cuerpo_estructura(i).Numero_Comprobante = numeracion.Trim
                        NotaCredito_Cuerpo_estructura(i).Comprobante = tipoComprobante
                        NotaCredito_Cuerpo_estructura(i).Numero_Articulo = datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Numero_Articulo)
                        NotaCredito_Cuerpo_estructura(i).Descripcion = datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Descripcion)
                        NotaCredito_Cuerpo_estructura(i).Cantidad = Format(datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Cantidad) * -1, "##,##0.00")
                        NotaCredito_Cuerpo_estructura(i).Precio_Unitario = Format(datosCuerpoFact.Rows(idx).Item(dfielddefCuerpoFact.Precio_Unitario) * -1, "##,##0.00")
                        NotaCredito_Cuerpo_estructura(i).Signo = -1
                        'consulta = "select * from " + dfieldefConstante.Producto.ToString() + " where Id_Producto='" + NotaCredito_Cuerpo_estructura(i).Numero_Articulo + "'"
                        Articulo.ObtenerProductos(NotaCredito_Cuerpo_estructura(i).Numero_Articulo, dtArticulos)
                        Articulos_Estructura(i).Id_Producto = NotaCredito_Cuerpo_estructura(i).Numero_Articulo
                        Articulos_Estructura(i).Stock = dtArticulos.Rows(0).Item("Stock")
                        idx = idx + 1
                    Next
                    FactEncESt = NotaCredito_Enc_estructura
                    querybuilder.obtener_estructura(dfieldefConstante.Encabezado_Factura.ToString(), esquema)
                    facturacion.Obtener_Clave_Principal_Encabezado_Factura(ClavePrincipal)
                    facturacion.Pasar_A_Coleccion_Encabezado_Factura(FactEncESt, datosCol, 1)
                    querybuilder.ArmaInsert(dfieldefConstante.Encabezado_Factura.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    esquema.Clear()
                    datosCol.Clear()
                    ClavePrincipal.Clear()
                    querybuilder.obtener_estructura(dfieldefConstante.Numeracion_Comprobante.ToString(), esquema)
                    NumeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
                    NumeroComprobante.Pasar_A_Coleccion(Numero_ComprobanteEStFact, datosCol, 1)
                    querybuilder.ArmaUpdate(dfieldefConstante.Numeracion_Comprobante.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    esquema.Clear()
                    datosCol.Clear()
                    ClavePrincipal.Clear()
                    querybuilder.obtener_estructura(dfieldefConstante.Cuerpo_Factura.ToString(), esquema)
                    facturacion.Obtener_Clave_Principal_Cuerpo_Factura(ClavePrincipal)
                    FactCuerpoESt = NotaCredito_Cuerpo_estructura
                    ArticulosEStFact = Articulos_Estructura
                    For i = 1 To FactCuerpoESt.Count - 1
                        'consulta = "Select Max(IdCuerpoFactura) as Maximo from " + dfieldefConstante.Cuerpo_Factura.ToString() + ""
                        facturacion.ObtenerUltimoNumeroCuerpoFactura(ultimo)
                        FactCuerpoESt(i).IdCuerpoFactura = ultimo
                        facturacion.Pasar_A_Coleccion_Cuerpo_Factura(FactCuerpoESt, datosCol, i)
                        querybuilder.ArmaInsert(dfieldefConstante.Cuerpo_Factura.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                        tran.Add(consulta)
                        consulta = ""
                        datosCol.Clear()
                        If (FactCuerpoESt(i).Numero_Articulo = ArticulosEStFact(i).Id_Producto) Then
                            ArticulosEStFact(i).Stock = ArticulosEStFact(i).Stock - FactCuerpoESt(i).Cantidad
                            consulta = "update " + dfieldefConstante.Producto.ToString() + " set Stock='" + (ArticulosEStFact(i).Stock) + "' where ID_Producto= '" + (FactCuerpoESt(i).Numero_Articulo) + "'"
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
                    ReDim Preserve FactEncESt(1)
                    FactEncESt(1).Punto_Venta = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Punto_Venta)
                    FactEncESt(1).Tipo_Comprobante = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Tipo_Comprobante)
                    FactEncESt(1).Numero_Comprobante = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Numero_Comprobante)
                    FactEncESt(1).Comprobante = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Comprobante)
                    FactEncESt(1).Numero_Cliente = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Numero_Cliente)
                    FactEncESt(1).Nombre = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Nombre)
                    FactEncESt(1).Apellido = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Apellido)
                    FactEncESt(1).Situacion_Frente_A_IVA = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Situacion_Frente_A_IVA)
                    FactEncESt(1).Id_Forma_Pago = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.ID_Forma_Pago)
                    FactEncESt(1).Forma_Pago = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Forma_Pago)
                    FactEncESt(1).Fecha_Comprobante = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Fecha_Comprobante)
                    FactEncESt(1).Codigo_Vendedor = 1

                    FactEncESt(1).Neto_Grabado_21 = Convert.ToString(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_21))
                    FactEncESt(1).Neto_Grabado_105 = Convert.ToString(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_105))
                    FactEncESt(1).Neto_Grabado_27 = Convert.ToString(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Neto_Grabado_27))
                    FactEncESt(1).Sub_Total = Convert.ToString(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Sub_Total))
                    FactEncESt(1).Conc_No_Grabado = ""
                    FactEncESt(1).Exentos = ""
                    FactEncESt(1).IVA_Facturado21 = Convert.ToString(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado21))
                    FactEncESt(1).IVA_Facturado105 = Convert.ToString(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado105))
                    FactEncESt(1).IVA_Facturado27 = Convert.ToString(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.IVA_Facturado27))
                    FactEncESt(1).IVA_Resp_No_Inscripto = ""
                    FactEncESt(1).Persepciones = ""
                    FactEncESt(1).PorcDescuentos = Convert.ToString(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.PorcDescuentos))

                    If datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos) = "" Then
                        FactEncESt(1).Descuentos = "0"
                    Else
                        FactEncESt(1).Descuentos = datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Descuentos)
                    End If
                    FactEncESt(1).Retenciones = ""
                    FactEncESt(1).Total = Convert.ToString(datosEncFact.Rows(0).Item(dfielddefFactuEncabezado.Total))
                    FactEncESt(1).Cancelado = dfieldefConstante.Si.ToString()
                    FactEncESt(1).Signo = 1
                    consulta = ""
                    esquema.Clear()
                    datosCol.Clear()
                    ClavePrincipal.Clear()
                    querybuilder.obtener_estructura(dfieldefConstante.Encabezado_Factura.ToString(), esquema)
                    facturacion.Obtener_Clave_Principal_Encabezado_Factura(ClavePrincipal)
                    facturacion.Pasar_A_Coleccion_Encabezado_Factura(FactEncESt, datosCol, 1)
                    querybuilder.ArmaUpdate(dfieldefConstante.Encabezado_Factura.ToString(), esquema, datosCol, ClavePrincipal, consulta)
                    tran.Add(consulta)
                    For idx = 1 To tran.Count
                        Transaccion.Operaciones_Tabla(tran(idx))
                    Next
                    tran.Clear()
                    'consulta = "select Punto_Venta as [Punto Venta],Tipo_Comprobante as [T. Comprobante] ,Numero_Comprobante as [Num Comprobante] ,Comprobante,Numero_Cliente as [Num Cliente] , Nombre,Apellido,Situacion_Frente_A_IVA as [SFI]  ,Forma_Pago as [Forma Pago] ,Fecha_Comprobante as [F. Comprobante],Cancelado  from Encabezado_Factura where Tipo_Comprobante in('01','11','06','18','16','17') and Punto_Venta='" + sucursal + "'  and Cancelado='" + dfieldefConstante.No.ToString() + "'order by Punto_Venta,Tipo_Comprobante,Numero_Comprobante,Comprobante"
                    listTipoComprobante.Add("'01','11','06','18','16','17'")
                    facturacion.llenar_tabla_Comprobante_Encabezado_Factura(listTipoComprobante.Item(0), sucursal, dfieldefConstante.No.ToString(), dgvBuscarComprobante)

                    MessageBox.Show("El Comprobante " + tbPuntoVenta.Text + "-" + tbNumeroComprobante.Text + " ,se ha Anulado Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Information)
                    LimpiarEstructuras()
                    facturacion.LimpiarDatosBusquedaComprobante(tbPuntoVenta, tbTipoComprobante, tbNumeroComprobante, tbComprobante, tbApellido, tbNombre, tbCondicionIVA)
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
        ReDim FactEncESt(0)
        ReDim FactCuerpoESt(0)
        ReDim Numero_ComprobanteEStFact(0)
        ReDim ArticulosEStFact(0)
        ReDim FomasdePagoContado(0)
        ReDim FomasdePagoCuentaCorriente(0)
        ReDim NotaCredito_Enc_estructura(0)
        ReDim NotaCredito_Enc_estructura(0)
    End Sub
    Private Sub tbPuntoVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPuntoVenta.TextChanged
        Dim Facturacion As New Controlador.Facturacion
        If Not (Facturacion.es_Numero(tbPuntoVenta.Text)) Then
            tbPuntoVenta.Text = ""
        End If
    End Sub
    Private Sub tbTipoComprobante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbTipoComprobante.TextChanged
        Dim Facturacion As New Controlador.Facturacion
        If Not (Facturacion.es_Numero(tbTipoComprobante.Text)) Then
            tbTipoComprobante.Text = ""
        End If
    End Sub
    Private Sub tbNumeroComprobante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNumeroComprobante.TextChanged
        Dim Facturacion As New Controlador.Facturacion
        If Not (Facturacion.es_Numero(tbNumeroComprobante.Text)) Then
            tbNumeroComprobante.Text = ""
        End If
    End Sub
End Class