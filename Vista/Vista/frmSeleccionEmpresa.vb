Imports Controlador
Public Class frmSeleccionEmpresa
    Dim dfielfdefSeleccionEmpresa As Controlador.DfieldDef.eEmpresa
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim _id_Empresa As Integer
    Private Sub SeleccionEmpresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Empresa As New Controlador.Empresas
        Dim Consulta As String
        Try
            'Consulta = "select Id_Empresa as [Cod Empresa],Razon_Social as [Razon Social],Calle,Piso,Nro,Localidad,Codigo_Postal as [Cod Postal],CUIT,Ingresos_Brutos as [Ing Brutos],Responsabilidad_IVA as [Resp IVA],Nro_Sucursal as [Nro Sucursal],Provincia from " + dfielddefConstantes.Empresa.ToString() + ""
            Empresa.llenar_tabla_Empresas(dgvSeleccionEmpresa)
            ToolStripSeleccionarEmpresa.Enabled = False
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub dgvSeleccionEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvSeleccionEmpresa.Click
        _id_Empresa = CInt(dgvSeleccionEmpresa.CurrentRow.Cells(dfielfdefSeleccionEmpresa.Id_Empresa).Value.ToString())
        ToolStripSeleccionarEmpresa.Enabled = True
    End Sub
    Private Sub ToolStripSeleccionarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSeleccionarEmpresa.Click
        Dim f As New frmMenu()
        Dim Empresa As New Controlador.Empresas

        Try

            Empresa.Compvariable = Convert.ToString(_id_Empresa)
            f.Show()
            For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
                ToolStripProgressBar.Value = x
            Next
            For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
                ToolStripProgressBar.Value = x
            Next
            Me.Close()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ToolStripSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSalir.Click
        Dim opc As DialogResult = MsgBox("¿Desea salir de la aplicación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")

        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        If opc = DialogResult.Yes Then
            Close()
        End If
    End Sub
    Private Sub ToolStripCrearEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripCrearEmpresa.Click
        Try
            frmEmpresa.Show()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
End Class