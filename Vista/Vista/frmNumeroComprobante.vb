Public Class frmNumeroComprobante
    Public id_Comprobante As Integer
    Public Posicion_Columna As Integer
    Public Nombre_Columna_a_Buscar As String
    Public Descripcion As String
    Dim NumeracionComprobante_estructura(0) As Controlador.NumeroComprobante.eNumeracionComprobante
    Dim DfieldDefNumeroComprovante As Controlador.DfieldDef.eNumeroComprobante
    Dim dfielddefConstante As Controlador.DfieldDef.eConstantes
    Private Sub NumeroComprobante_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Dim numerocomprobante As New Controlador.NumeroComprobante()
        Try
            'consulta = " select Id_Comprobante as [Cod Comprobante],Descripcion,Numeracion,NC.Id_Empresa as [Cod Empresa],E.Razon_Social as [Nom Empresa] from Numeracion_Comprobante as NC" & vbCrLf
            'consulta += "inner join Empresa as E on E.Id_Empresa =NC.Id_Empresa" & vbCrLf
            'consulta += "order by NC.Id_Empresa, Id_Comprobante"
            numerocomprobante.llenar_tabla_NumeroComprobante_Empresa(DGVNumeroComprobante)
            ToolStripNuevoNumeroComprobante.Enabled = True
            ToolStripModificarNumeroComprobante.Enabled = False
            ToolStripEliminarNumeroComprobante.Enabled = False
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripSalirNumeroComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalirNumeroComprobante.Click
        For x As Integer = ProgressBarNumeroComprobante.Minimum To ProgressBarNumeroComprobante.Maximum
            ProgressBarNumeroComprobante.Value = x
        Next
        For x As Integer = ProgressBarNumeroComprobante.Maximum To ProgressBarNumeroComprobante.Minimum Step -1
            ProgressBarNumeroComprobante.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub ToolStripNuevoNumeroComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNuevoNumeroComprobante.Click
        Dim numerocomprobante As New Controlador.NumeroComprobante
        For x As Integer = ProgressBarNumeroComprobante.Minimum To ProgressBarNumeroComprobante.Maximum
            ProgressBarNumeroComprobante.Value = x
        Next
        For x As Integer = ProgressBarNumeroComprobante.Maximum To ProgressBarNumeroComprobante.Minimum Step -1
            ProgressBarNumeroComprobante.Value = x
        Next
        Me.Close()
        frmNumeroComprobanteAlta.Show()
        numerocomprobante.Compvariable = dfielddefConstante.Agregar_NumeroComprobante.ToString()
    End Sub
    Private Sub DGVNumeroComprobante_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVNumeroComprobante.Click
        Dim numerocomprobante As New Controlador.NumeroComprobante
        Try
            ToolStripNuevoNumeroComprobante.Enabled = False
            ToolStripModificarNumeroComprobante.Enabled = True
            ToolStripEliminarNumeroComprobante.Enabled = True
            id_Comprobante = CInt(DGVNumeroComprobante.CurrentRow.Cells(DfieldDefNumeroComprovante.Id_Comprobante).Value.ToString())
            Descripcion = DGVNumeroComprobante.CurrentRow.Cells(DfieldDefNumeroComprovante.Descripcion).Value.ToString()

            frmNumeroComprobanteAlta.codigo_NumeroComprobante = id_Comprobante
            frmNumeroComprobanteAlta.TBDescripcion.Text = DGVNumeroComprobante.CurrentRow.Cells(DfieldDefNumeroComprovante.Descripcion).Value.ToString()
            frmNumeroComprobanteAlta.TBNumeracion.Text = DGVNumeroComprobante.CurrentRow.Cells(DfieldDefNumeroComprovante.Numeracion).Value.ToString()
            frmNumeroComprobanteAlta.CBNumeroEmpresa.Text = DGVNumeroComprobante.CurrentRow.Cells(DfieldDefNumeroComprovante.Id_Empresa).Value.ToString()

            Posicion_Columna = DGVNumeroComprobante.CurrentCell.ColumnIndex
            Nombre_Columna_a_Buscar = DGVNumeroComprobante.Columns(Posicion_Columna).Name

            If (Nombre_Columna_a_Buscar = dfielddefConstante.Descripcion.ToString()) Then
                Me.Label2.Text = "Descripcion"
            Else
                If (Nombre_Columna_a_Buscar = dfielddefConstante.Numeracion.ToString()) Then
                    Me.Label2.Text = "Numeracion:"
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripModificarNumeroComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripModificarNumeroComprobante.Click
        Dim numerocomprobante As New Controlador.NumeroComprobante
        For x As Integer = ProgressBarNumeroComprobante.Minimum To ProgressBarNumeroComprobante.Maximum
            ProgressBarNumeroComprobante.Value = x
        Next
        For x As Integer = ProgressBarNumeroComprobante.Maximum To ProgressBarNumeroComprobante.Minimum Step -1
            ProgressBarNumeroComprobante.Value = x
        Next
        Me.Close()
        frmNumeroComprobanteAlta.Show()
        numerocomprobante.Compvariable = dfielddefConstante.Modificar_NumeroComprobante.ToString()
    End Sub
    Private Sub ToolStripEliminarNumeroComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripEliminarNumeroComprobante.Click
        Dim numeroComprobante As New Controlador.NumeroComprobante
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim result As Integer = MessageBox.Show("Desea Eliminar El Comprobante: " + CStr(id_Comprobante) + " " + Descripcion, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                ReDim NumeracionComprobante_estructura(1)
                NumeracionComprobante_estructura(1).Id_Comprobante = id_Comprobante
                NumeracionComprobante_estructura(1).Descripcion = Nothing
                NumeracionComprobante_estructura(1).Numeracion = Nothing
                NumeracionComprobante_estructura(1).Id_Empresa = Nothing

                numeroComprobante.Obtener_Clave_Principal(ClavePrincipal)
                numeroComprobante.Pasar_A_Coleccion(NumeracionComprobante_estructura, datos, 1)
                querybuilder.ArmaDelete(dfielddefConstante.Numeracion_Comprobante.ToString(), datos, ClavePrincipal, consulta)
                numeroComprobante.Operaciones_Tabla(consulta)

                MessageBox.Show("El Numero Comprobante " + CStr(id_Comprobante) + " " + Descripcion + " se. Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'consulta = "select Id_Comprobante as [Cod Comprobante],Descripcion,Numeracion,Id_Empresa as [Cod Empresa] from " + dfielddefConstante.Numeracion_Comprobante.ToString() + ""
                numeroComprobante.llenar_tabla_NumeroComprobante(DGVNumeroComprobante)
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    Private Sub TBBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBBusqueda.TextChanged
        Dim consulta As String
        Dim numeracioncomprobante As New Controlador.NumeroComprobante
        Try
            'consulta = "select Id_Comprobante as [Cod Comprobante],Descripcion,Numeracion,Id_Empresa as [Cod Empresa] from " + dfielddefConstante.Numeracion_Comprobante.ToString() + " where " + Nombre_Columna_a_Buscar + " like '" & Me.TBBusqueda.Text & "%'"
            numeracioncomprobante.Busqueda_by_NombreColumna(DGVNumeroComprobante, dfielddefConstante.Numeracion_Comprobante.ToString(), Me.TBBusqueda.Text)
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim NumeracionComprobante_estructura(0)
    End Sub
End Class