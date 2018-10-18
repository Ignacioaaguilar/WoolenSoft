Public Class Configuracion
    Dim Configuracion_estructura(0) As Controlador.Configuracion.eConfiguracion
    Dim id_Configuracion As Integer
    Dim dfielddefConfiguracion As Controlador.DfieldDef.eConfiguracion
    Dim dfieldefConstantes As Controlador.DfieldDef.eConstantes
    Dim dfielddefTasaIVA As Controlador.DfieldDef.eTasaIVA
    Dim dfielddetListaPrecio As Controlador.DfieldDef.eListaPrecio
    Public session As New Controlador.Session()
    Private Sub Configuracion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Configuracion As New Controlador.Configuracion
        Dim Puertos As New Collection
        Dim Lista_Precio As New Controlador.Lista_Precios
        Dim Tasa_IVA As New Controlador.TasaIVA()
        Dim Consulta As String
        Configuracion.GetSerialPortNames(Puertos)
        cbPuertoComm.DataSource = Puertos
        cbPuertoComm.DisplayMember = "Configuracion"

        ' Consulta = "Select * from " + dfieldefConstantes.Configuracion.ToString() + ""
        Configuracion.llenar_tabla_Configuracion(dgvConfiguracion)
        Configuracion.Compvariable = dfieldefConstantes.Registrar.ToString()

        'Consulta = "Select * from " + dfieldefConstantes.Lista_Precio.ToString() + ""
        Lista_Precio.llenar_Combo_ListaPrecio(cbLista_Precio, "Descripcion", "Id_Lista_Precio")

        
    End Sub
    Private Sub ToolStripRegistrarConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRegistrarConfiguracion.Click
        Dim Configuracion As New Controlador.Configuracion
        Dim consulta As String
        Dim existe As Boolean
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim Ultimo As Integer
        Dim Numero_Puerto As String
        Dim ResultConsulta As Controlador.Configuracion.eConfiguracion
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        'consulta = "select * from " + dfieldefConstantes.Configuracion.ToString() + " "
        Configuracion.Obtener_Datos_Configuracion(ResultConsulta)

        If (cbDescripcionBalanza.Text <> "") Then
            If Configuracion.Compvariable = dfieldefConstantes.Registrar.ToString() Then
                If ResultConsulta.Id_Configuracion = Nothing Then
                    ReDim Configuracion_estructura(1)
                    'consulta = "select max(Id_Configuracion) from " + dfieldefConstantes.Configuracion.ToString() + " "
                    Configuracion.ObtenerUltimoConfiguracion(Ultimo)
                    Configuracion_estructura(1).Id_Configuracion = Ultimo
                    Configuracion_estructura(1).Puerto_Comm = cbPuertoComm.Text
                    Configuracion.ObtenerNumeroPuerto(cbPuertoComm.Text, Numero_Puerto)
                    Configuracion_estructura(1).Nro_Puerto = Numero_Puerto
                    Configuracion_estructura(1).Nombre_Balanza = cbDescripcionBalanza.Text
                    If cbHabilitarCodigoBarra.Checked = True Then
                        Configuracion_estructura(1).Lector_Codigo_Barras = dfieldefConstantes.Si.ToString()
                    Else
                        Configuracion_estructura(1).Lector_Codigo_Barras = dfieldefConstantes.No.ToString()
                    End If
                    Configuracion_estructura(1).Lista_Precio = cbLista_Precio.Text
                    Configuracion_estructura(1).Id_Lista_Precio = cbLista_Precio.SelectedValue
                    Configuracion_estructura(1).NroEquipo = session.Session.NroPuesto
                    querybuilder.obtener_estructura(dfieldefConstantes.Configuracion.ToString(), esquema)
                    Configuracion.Obtener_Clave_Principal_Configuracion(ClavePrincipal)
                    Configuracion.Pasar_A_Coleccion_Configuracion(Configuracion_estructura, datos, 1)
                    querybuilder.ArmaInsert(dfieldefConstantes.Configuracion.ToString(), esquema, datos, ClavePrincipal, consulta)
                    Configuracion.Operaciones_Tabla(consulta)
                    MessageBox.Show("Los Datos se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                    'consulta = "Select Id_Configuracion as [Cod Configuracion] ,Puerto_Comm as [Puerto Comm],Numero_Puerto as [Num Puerto],Nombre_Balanza as [Nom Balanza],Lector_Codigo_Barras as [Lector Cod Barras],Id_Lista_Precio as [Cod Lista Precio],Lista_Precio as [Desc Lista Precio],Id_Tasa_IVA as [Tasa IVA],Descripcion from " + dfieldefConstantes.Configuracion.ToString() + ""
                    Configuracion.llenar_tabla_Configuracion(dgvConfiguracion)
                    LimpiarEstructuras()
                    Configuracion.Limpiar_Datos_Configuracion(cbDescripcionBalanza, cbHabilitarCodigoBarra)
                Else
                    MessageBox.Show("El Sistema Posee una Configuracion Cargada, no se puede ingresar una nueva!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                    Configuracion.Limpiar_Datos_Configuracion(cbDescripcionBalanza, cbHabilitarCodigoBarra)
                End If

            Else
                If Configuracion.Compvariable = dfieldefConstantes.Actualizar.ToString() Then
                    ReDim Configuracion_estructura(1)
                    Configuracion_estructura(1).Id_Configuracion = Convert.ToInt32(id_Configuracion)
                    Configuracion_estructura(1).Puerto_Comm = cbPuertoComm.Text
                    Configuracion.ObtenerNumeroPuerto(cbPuertoComm.Text, Numero_Puerto)
                    Configuracion_estructura(1).Nro_Puerto = Numero_Puerto
                    Configuracion_estructura(1).Nombre_Balanza = cbDescripcionBalanza.Text
                    If cbHabilitarCodigoBarra.Checked = True Then
                        Configuracion_estructura(1).Lector_Codigo_Barras = dfieldefConstantes.Si.ToString()
                    Else
                        Configuracion_estructura(1).Lector_Codigo_Barras = dfieldefConstantes.No.ToString()
                    End If
                    Configuracion_estructura(1).Lista_Precio = cbLista_Precio.Text
                    Configuracion_estructura(1).Id_Lista_Precio = cbLista_Precio.SelectedValue
                    Configuracion_estructura(1).NroEquipo = session.Session.NroPuesto
                    querybuilder.obtener_estructura(dfieldefConstantes.Configuracion.ToString(), esquema)
                    Configuracion.Obtener_Clave_Principal_Configuracion(ClavePrincipal)
                    Configuracion.Pasar_A_Coleccion_Configuracion(Configuracion_estructura, datos, 1)
                    querybuilder.ArmaUpdate(dfieldefConstantes.Configuracion.ToString(), esquema, datos, ClavePrincipal, consulta)
                    Configuracion.Operaciones_Tabla(consulta)
                    MessageBox.Show("Los Datos se Modificaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Information)
                    'consulta = "Select Id_Configuracion as [Cod Configuracion] ,Puerto_Comm as [Puerto Comm],Numero_Puerto as [Num Puerto],Nombre_Balanza as [Nom Balanza],Lector_Codigo_Barras as [Lector Cod Barras],Id_Lista_Precio as [Cod Lista Precio],Lista_Precio as [Desc Lista Precio],Id_Tasa_IVA as [Tasa IVA],Descripcion from " + dfieldefConstantes.Configuracion.ToString() + ""
                    Configuracion.llenar_tabla_Configuracion(dgvConfiguracion)
                    Configuracion.Compvariable = dfieldefConstantes.Registrar.ToString()
                    LimpiarEstructuras()
                    Configuracion.Limpiar_Datos_Configuracion(cbDescripcionBalanza, cbHabilitarCodigoBarra)
                End If
            End If
        Else
            MessageBox.Show("Ingrese El Nombre de La Balanza!!!", "Informacion", MessageBoxButtons.OK, _
                                         MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub dgvConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvConfiguracion.Click
        Dim TasaIVA As New Controlador.TasaIVA()
        Dim Configuracion As New Controlador.Configuracion
        id_Configuracion = CInt(dgvConfiguracion.CurrentRow.Cells(dfielddefConfiguracion.Id_Configuracion).Value.ToString())
        cbDescripcionBalanza.Text = dgvConfiguracion.CurrentRow.Cells(dfielddefConfiguracion.Nombre_Balanza).Value.ToString()
        cbPuertoComm.Text = dgvConfiguracion.CurrentRow.Cells(dfielddefConfiguracion.Puerto_Comm).Value.ToString()
        If dgvConfiguracion.CurrentRow.Cells(dfielddefConfiguracion.Lector_Codigo_Barras).Value.ToString() = dfieldefConstantes.Si.ToString() Then
            cbHabilitarCodigoBarra.Checked = True
        Else
            cbHabilitarCodigoBarra.Checked = False
        End If
        cbLista_Precio.Text = dgvConfiguracion.CurrentRow.Cells(dfielddefConfiguracion.Id_Lista_Precio).Value.ToString()
        ' mostrar()
        Configuracion.Compvariable = dfieldefConstantes.Actualizar.ToString()
    End Sub
    Private Sub ToolStripSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalir.Click
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub ToolStripEliminarConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEliminarConfiguracion.Click
        Dim Configuracion As New Controlador.Configuracion
        Dim consulta As String
        Dim existe As Boolean
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim Ultimo As Integer
        Dim Numero_Puerto As String
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Dim result As Integer = MessageBox.Show("Desea Eliminar La Configuracion N°:" + CStr(id_Configuracion) + " ", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                ReDim Configuracion_estructura(1)
                Configuracion_estructura(1).Id_Configuracion = id_Configuracion
                Configuracion_estructura(1).Puerto_Comm = cbPuertoComm.Text
                Configuracion.ObtenerNumeroPuerto(cbPuertoComm.Text, Numero_Puerto)
                Configuracion_estructura(1).Nro_Puerto = Numero_Puerto
                Configuracion_estructura(1).Nombre_Balanza = cbDescripcionBalanza.Text
                If cbHabilitarCodigoBarra.Checked = True Then
                    Configuracion_estructura(1).Lector_Codigo_Barras = dfieldefConstantes.Si.ToString()
                Else
                    Configuracion_estructura(1).Lector_Codigo_Barras = dfieldefConstantes.No.ToString()
                End If
                Configuracion_estructura(1).Lista_Precio = cbLista_Precio.Text
                Configuracion_estructura(1).Id_Lista_Precio = cbLista_Precio.SelectedValue
                Configuracion.Obtener_Clave_Principal_Configuracion(ClavePrincipal)
                Configuracion.Pasar_A_Coleccion_Configuracion(Configuracion_estructura, datos, 1)
                querybuilder.ArmaDelete(dfieldefConstantes.Configuracion.ToString(), datos, ClavePrincipal, consulta)
                Configuracion.Operaciones_Tabla(consulta)
                MessageBox.Show("Los Datos se Eliminaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                         MessageBoxIcon.Information)
                ' consulta = "Select Id_Configuracion as [Cod Configuracion] ,Puerto_Comm as [Puerto Comm],Numero_Puerto as [Num Puerto],Nombre_Balanza as [Nom Balanza],Lector_Codigo_Barras as [Lector Cod Barras],Id_Lista_Precio as [Cod Lista Precio],Lista_Precio as [Desc Lista Precio],Id_Tasa_IVA as [Tasa IVA],Descripcion from " + dfieldefConstantes.Configuracion.ToString() + ""
                Configuracion.llenar_tabla_Configuracion(dgvConfiguracion)
                Configuracion.Compvariable = dfieldefConstantes.Registrar.ToString()
                Configuracion.Limpiar_Datos_Configuracion(cbDescripcionBalanza, cbHabilitarCodigoBarra)
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim Configuracion_estructura(0)
    End Sub
    
    Private Sub cbLista_Precio_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLista_Precio.SelectedValueChanged
        Dim ListaPrecios As New Controlador.Lista_Precios
        Dim consulta As String
        Dim datosListaPrecio As Controlador.Lista_Precios.eListaPrecio
        If IsNumeric(cbLista_Precio.Text) Then
            'consulta = "select * from Lista_Precio where  Id_Lista_Precio=" & (cbLista_Precio.Text) & ""
            ListaPrecios.recuperar_Datos(cbLista_Precio.Text, datosListaPrecio)
            'If datos.Rows.Count > 0 Then
            If datosListaPrecio.Id_Lista_Precio <> Nothing Then
                'lbListaPrecio.Text = datos.Rows(0).Item(dfielddetListaPrecio.Descripcion)
                lbListaPrecio.Text = datosListaPrecio.Descripcion
            End If
        End If
    End Sub
End Class