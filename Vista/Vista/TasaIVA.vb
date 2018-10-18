Public Class TasaIVA
    Private TasaCodigo As String
    Dim tasaiva_estructura(0) As Controlador.TasaIVA.eTasaIVA
    Dim FieldDefTasaIVA As New Controlador.DfieldDef.eTasaIVA
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        For x As Integer = ProgressBarTasaIVA.Minimum To ProgressBarTasaIVA.Maximum
            ProgressBarTasaIVA.Value = x
        Next
        For x As Integer = ProgressBarTasaIVA.Maximum To ProgressBarTasaIVA.Minimum Step -1
            ProgressBarTasaIVA.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub TasaIVA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Dim tasaiva As New Controlador.TasaIVA
        Dim datos As New DataTable
        Dim col As New AutoCompleteStringCollection
        Dim i As Integer
        Try
            'consulta = "Select Id_Tasa_IVA as [Cod Tasa IVA],Descripcion,Tasa from " + dfielddefConstantes.Tasa_IVA.ToString() + ""
            tasaiva.llenar_tabla_TasaIVA(DGVTasaIVA)
            TIModificar.Enabled = False
            TIEliminar.Enabled = False
            TIGuardar.Enabled = True
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TasaTasaIVA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TasaTasaIVA.TextChanged
        Dim tasaiva As New Controlador.TasaIVA
        If Not (tasaiva.validateDoublesAndCurrency_Cliente(TasaTasaIVA.Text)) Then
            TasaTasaIVA.Text = String.Empty
        End If
    End Sub
    Private Sub TIGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIGuardar.Click
        Dim tasaiva As New Controlador.TasaIVA
        Dim querybuilder As New Controlador.QueryBuilder
        Dim consulta As String
        Dim esquema As New Collection
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim Ultimo As Integer
        Try
            If (DescripcionTasaIVA.Text <> String.Empty And TasaTasaIVA.Text <> String.Empty) Then
                ReDim tasaiva_estructura(1)
                'consulta = "max(Id_Tasa_IVA) from " + dfielddefConstantes.Tasa_IVA.ToString() + ""
                tasaiva.ObtenerUltimoNumeroTasaIVA(Ultimo)
                tasaiva_estructura(1).Id_Tasa_IVA = Convert.ToString(Ultimo)
                tasaiva_estructura(1).Descripcion = DescripcionTasaIVA.Text
                tasaiva_estructura(1).Tasa = Replace(TasaTasaIVA.Text, ".", ",")
                querybuilder.obtener_estructura(dfielddefConstantes.Tasa_IVA.ToString(), esquema)
                tasaiva.Obtener_Clave_Principal(ClavePrincipal)
                tasaiva.Pasar_A_Coleccion(tasaiva_estructura, datos, 1)
                querybuilder.ArmaInsert(dfielddefConstantes.Tasa_IVA.ToString(), esquema, datos, ClavePrincipal, consulta)
                tasaiva.Operaciones_Tabla(consulta)
                'consulta = "select Id_Tasa_IVA as [Cod Tasa IVA],Descripcion,Tasa from " + dfielddefConstantes.Tasa_IVA.ToString() + ""
                tasaiva.llenar_tabla_TasaIVA(DGVTasaIVA)
                MessageBox.Show("Los Datos del Rubro se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Information)
                tasaiva.Limpiar_Datos_TasaIVA(DescripcionTasaIVA, TasaTasaIVA)
                LimpiarEstructuras()
            Else
                MessageBox.Show("Error: Hay Campos Vacios. Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                                    MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
        For x As Integer = ProgressBarTasaIVA.Minimum To ProgressBarTasaIVA.Maximum
            ProgressBarTasaIVA.Value = x
        Next
        For x As Integer = ProgressBarTasaIVA.Maximum To ProgressBarTasaIVA.Minimum Step -1
            ProgressBarTasaIVA.Value = x
        Next
    End Sub
    Private Sub DGVTasaIVA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVTasaIVA.Click
        Try
            TasaCodigo = CInt(DGVTasaIVA.CurrentRow.Cells(FieldDefTasaIVA.Id_Tasa_IVA).Value.ToString())
            DescripcionTasaIVA.Text = DGVTasaIVA.CurrentRow.Cells(FieldDefTasaIVA.Descripcion).Value.ToString()
            TasaTasaIVA.Text = DGVTasaIVA.CurrentRow.Cells(FieldDefTasaIVA.Tasa).Value.ToString()
            TIModificar.Enabled = True
            TIEliminar.Enabled = True
            TIGuardar.Enabled = False
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub TIModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIModificar.Click
        Dim tasaiva As New Controlador.TasaIVA
        Dim consulta As String
        Dim esquema As New Collection
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Try
            ReDim tasaiva_estructura(1)
            tasaiva_estructura(1).Id_Tasa_IVA = TasaCodigo
            tasaiva_estructura(1).Descripcion = DescripcionTasaIVA.Text
            tasaiva_estructura(1).Tasa = Replace(TasaTasaIVA.Text, ".", ",")
            querybuilder.obtener_estructura(dfielddefConstantes.Tasa_IVA.ToString(), esquema)
            tasaiva.Obtener_Clave_Principal(ClavePrincipal)
            tasaiva.Pasar_A_Coleccion(tasaiva_estructura, datos, 1)
            querybuilder.ArmaUpdate(dfielddefConstantes.Tasa_IVA.ToString(), esquema, datos, ClavePrincipal, consulta)
            tasaiva.Operaciones_Tabla(consulta)
            MessageBox.Show("La Tasa de IVA,  se Modifico Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'consulta = "select Id_Tasa_IVA as [Cod Tasa IVA],Descripcion,Tasa from " + dfielddefConstantes.Tasa_IVA.ToString() + " "
            tasaiva.llenar_tabla_TasaIVA(DGVTasaIVA)
            tasaiva.Limpiar_Datos_TasaIVA(DescripcionTasaIVA, TasaTasaIVA)
            TIModificar.Enabled = False
            TIEliminar.Enabled = False
            TIGuardar.Enabled = True
            LimpiarEstructuras()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
        For x As Integer = ProgressBarTasaIVA.Minimum To ProgressBarTasaIVA.Maximum
            ProgressBarTasaIVA.Value = x
        Next
        For x As Integer = ProgressBarTasaIVA.Maximum To ProgressBarTasaIVA.Minimum Step -1
            ProgressBarTasaIVA.Value = x
        Next
    End Sub
    Private Sub TIEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIEliminar.Click
        Dim tasaiva As New Controlador.TasaIVA
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim consulta As String
        Dim querybuilder As New Controlador.QueryBuilder
        Dim result As Integer = MessageBox.Show("Desea Eliminar La Tasa de IVA: " + DescripcionTasaIVA.Text + " " + TasaTasaIVA.Text, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                ReDim tasaiva_estructura(1)
                tasaiva_estructura(1).Id_Tasa_IVA = TasaCodigo
                tasaiva_estructura(1).Descripcion = DescripcionTasaIVA.Text
                tasaiva_estructura(1).Tasa = Replace(TasaTasaIVA.Text, ".", ",")
                tasaiva.Obtener_Clave_Principal(ClavePrincipal)
                tasaiva.Pasar_A_Coleccion(tasaiva_estructura, datos, 1)
                querybuilder.ArmaDelete(dfielddefConstantes.Tasa_IVA.ToString(), datos, ClavePrincipal, consulta)
                tasaiva.Operaciones_Tabla(consulta)
                MessageBox.Show("La Tasa de IVA " + DescripcionTasaIVA.Text + " " + TasaTasaIVA.Text + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'consulta = "select Id_Tasa_IVA as [Cod Tasa IVA],Descripcion,Tasa from " + dfielddefConstantes.Tasa_IVA.ToString() + ""
                tasaiva.llenar_tabla_TasaIVA(DGVTasaIVA)
                tasaiva.Limpiar_Datos_TasaIVA(DescripcionTasaIVA, TasaTasaIVA)
                TIModificar.Enabled = False
                TIEliminar.Enabled = False
                TIGuardar.Enabled = True
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
        For x As Integer = ProgressBarTasaIVA.Minimum To ProgressBarTasaIVA.Maximum
            ProgressBarTasaIVA.Value = x
        Next
        For x As Integer = ProgressBarTasaIVA.Maximum To ProgressBarTasaIVA.Minimum Step -1
            ProgressBarTasaIVA.Value = x
        Next
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim tasaiva_estructura(0)
    End Sub
End Class