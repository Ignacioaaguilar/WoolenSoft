Imports Controlador
Public Class frmRubros
    Private RubroCodigo As String
    Dim eRubro_estructura(0) As Controlador.clsRubros.eRubro
    Dim DfieldDefRubro As Controlador.clsDfieldDef.eRubros
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clsrubro As New Controlador.clsRubros
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Private Sub RubrosSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RubrosSalir.Click
        For x As Integer = ProgressBarRubro.Minimum To ProgressBarRubro.Maximum
            ProgressBarRubro.Value = x
        Next
        For x As Integer = ProgressBarRubro.Maximum To ProgressBarRubro.Minimum Step -1
            ProgressBarRubro.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub Rubros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim rubro As New Controlador.clsRubros
        Dim consulta As String
        Try
            ' consulta = "select Id_Rubro as [cod Rubro],Descripcion from " + dfielddefConstantes.rubro.ToString() + ""
            RubrosModificar.Enabled = False
            RubrosEliminar.Enabled = False
            RubrosGuardar.Enabled = True
            clsrubro.llenar_tabla_Rubros(DGVRubro)
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub CodigoRubro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodigoRubro.TextChanged
        'Dim rubro As New Controlador.clsRubros
        If Not (clsrubro.es_Numero(CodigoRubro.Text)) Then
            CodigoRubro.Text = String.Empty
        End If
    End Sub
    Private Sub RubrosGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RubrosGuardar.Click
        'Dim rubro As New Controlador.clsRubros
        Dim consulta As String
        Dim existe As Boolean
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Try
            If (CodigoRubro.Text <> String.Empty And DescripcionRubro.Text <> String.Empty) Then
                'consulta = "select * from " + dfielddefConstantes.rubro.ToString() + " where Id_Rubro='" & (CodigoRubro.Text) & "' "
                clsrubro.se_Cargo(CodigoRubro.Text, existe)
                If Not existe Then
                    ReDim eRubro_estructura(1)
                    eRubro_estructura(1).Id_Rubro = CodigoRubro.Text
                    eRubro_estructura(1).Descripcion = DescripcionRubro.Text
                    clsQueryBuilder.obtener_estructura(dfielddefConstantes.rubro.ToString(), esquema)
                    clsrubro.Obtener_Clave_Principal(ClavePrincipal)
                    clsrubro.Pasar_A_Coleccion(eRubro_estructura, datos, 1)
                    clsQueryBuilder.ArmaInsert(dfielddefConstantes.rubro.ToString(), esquema, datos, ClavePrincipal, consulta)
                    clsrubro.Operaciones_Tabla(consulta)
                    'consulta = "select Id_Rubro as [cod Rubro],Descripcion from " + dfielddefConstantes.rubro.ToString() + ""
                    clsrubro.llenar_tabla_Rubros(DGVRubro)
                    MessageBox.Show("Los Datos del Rubro se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                         MessageBoxIcon.Information)
                    clsrubro.Limpiar_Datos_Rubro(CodigoRubro, DescripcionRubro)
                    LimpiarEstructuras()
                Else
                    MessageBox.Show("Error: El Codigo Del Rubro ha sido ingresado Con Anterioridad. Ingrese Otro, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                                   MessageBoxIcon.Exclamation)
                    CodigoRubro.Text = ""
                    CodigoRubro.Focus()
                End If
            Else
                MessageBox.Show("Error: Hay Campos Vacios. Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                                    MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
        For x As Integer = ProgressBarRubro.Minimum To ProgressBarRubro.Maximum
            ProgressBarRubro.Value = x
        Next
        For x As Integer = ProgressBarRubro.Maximum To ProgressBarRubro.Minimum Step -1
            ProgressBarRubro.Value = x
        Next
    End Sub
    Private Sub DGVRubro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVRubro.Click
        Try
            RubroCodigo = (DGVRubro.CurrentRow.Cells(DfieldDefRubro.Id_Rubro).Value.ToString())
            CodigoRubro.Text = CStr(RubroCodigo)
            DescripcionRubro.Text = DGVRubro.CurrentRow.Cells(DfieldDefRubro.Descripcion).Value.ToString()
            RubrosModificar.Enabled = True
            RubrosEliminar.Enabled = True
            RubrosGuardar.Enabled = False
            CodigoRubro.Enabled = False
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub RubrosEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RubrosEliminar.Click
        'Dim rubro As New Controlador.clsRubros
        Dim consulta As String
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim datos As New Collection
        Dim result As Integer = MessageBox.Show("Desea Eliminar al Rubro: " + DescripcionRubro.Text, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                ReDim eRubro_estructura(1)
                eRubro_estructura(1).Id_Rubro = RubroCodigo
                eRubro_estructura(1).Descripcion = Nothing
                clsrubro.Obtener_Clave_Principal(ClavePrincipal)
                clsrubro.Pasar_A_Coleccion(eRubro_estructura, datos, 1)
                clsQueryBuilder.ArmaDelete(dfielddefConstantes.rubro.ToString(), datos, ClavePrincipal, consulta)
                clsrubro.Operaciones_Tabla(consulta)
                MessageBox.Show("El Rubro " + DescripcionRubro.Text + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'consulta = "select Id_Rubro as [cod Rubro],Descripcion from " + dfielddefConstantes.rubro.ToString() + ""
                clsrubro.llenar_tabla_Rubros(DGVRubro)
                clsrubro.Limpiar_Datos_Rubro(CodigoRubro, DescripcionRubro)
                RubrosModificar.Enabled = False
                RubrosEliminar.Enabled = False
                RubrosGuardar.Enabled = True
                CodigoRubro.Enabled = True
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
        For x As Integer = ProgressBarRubro.Minimum To ProgressBarRubro.Maximum
            ProgressBarRubro.Value = x
        Next
        For x As Integer = ProgressBarRubro.Maximum To ProgressBarRubro.Minimum Step -1
            ProgressBarRubro.Value = x
        Next
    End Sub
    Private Sub RubrosModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RubrosModificar.Click
        'Dim rubro As New Controlador.clsRubros
        Dim consulta As String
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Try
            ReDim eRubro_estructura(1)
            eRubro_estructura(1).Id_Rubro = RubroCodigo
            eRubro_estructura(1).Descripcion = DescripcionRubro.Text
            clsQueryBuilder.obtener_estructura(dfielddefConstantes.rubro.ToString(), esquema)
            clsrubro.Obtener_Clave_Principal(ClavePrincipal)
            clsrubro.Pasar_A_Coleccion(eRubro_estructura, datos, 1)
            clsQueryBuilder.ArmaUpdate(dfielddefConstantes.rubro.ToString(), esquema, datos, ClavePrincipal, consulta)
            clsrubro.Operaciones_Tabla(consulta)
            MessageBox.Show("El Rubro  se Modifico Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'consulta = "select Id_Rubro as [cod Rubro],Descripcion from " + dfielddefConstantes.rubro.ToString() + ""
            clsrubro.llenar_tabla_Rubros(DGVRubro)
            clsrubro.Limpiar_Datos_Rubro(CodigoRubro, DescripcionRubro)
            RubrosModificar.Enabled = False
            RubrosEliminar.Enabled = False
            RubrosGuardar.Enabled = True
            CodigoRubro.Enabled = True
            LimpiarEstructuras()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
        For x As Integer = ProgressBarRubro.Minimum To ProgressBarRubro.Maximum
            ProgressBarRubro.Value = x
        Next
        For x As Integer = ProgressBarRubro.Maximum To ProgressBarRubro.Minimum Step -1
            ProgressBarRubro.Value = x
        Next
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim eRubro_estructura(0)
    End Sub
End Class