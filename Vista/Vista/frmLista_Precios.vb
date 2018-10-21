Imports Controlador
Public Class frmLista_Precios
    Public CodigoListaPrecio As Integer
    Dim ListaPrecio_estructura(0) As Controlador.clsLista_Precios.eListaPrecio
    Dim dfielddefConstantes As Controlador.clsDfieldDef.eConstantes
    Dim clslistaprecios As New Controlador.clsLista_Precios
    Dim clsQueryBuilder As New Controlador.clsQueryBuilder
    Private Sub Lista_Precios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim listaprecios As New Controlador.clsLista_Precios
        Dim consulta As String
        Try
            consulta = "select Id_Lista_Precio as [Cod Lista Precio],Descripcion from " + dfielddefConstantes.Lista_Precio.ToString() + ""
            clslistaprecios.llenar_tabla_ListaPrecio(DGVListaPrecio)
            GuardarListaPrecio.Enabled = True
            ModificarListaPrecio.Enabled = False
            EliminarListaPrecio.Enabled = False
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub SalirListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirListaPrecio.Click
        For x As Integer = ProgressBarListaPrecio.Minimum To ProgressBarListaPrecio.Maximum
            ProgressBarListaPrecio.Value = x
        Next
        For x As Integer = ProgressBarListaPrecio.Maximum To ProgressBarListaPrecio.Minimum Step -1
            ProgressBarListaPrecio.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub GuardarListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarListaPrecio.Click
        'Dim listaPrecio As New Controlador.clsLista_Precios
        Dim consulta As String
        Dim existe As Boolean
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim ultimo As Integer
        Try
            If (ListaPreciosDescripcion.Text <> "") Then 'existe el producto 
                ReDim ListaPrecio_estructura(1)
                'consulta = "select max(Id_Lista_Precio) from " + dfielddefConstantes.Lista_Precio.ToString() + " "
                clslistaprecios.ObtenerUltimoNumeroListaPrecio(ultimo)
                ListaPrecio_estructura(1).Id_Lista_Precio = ultimo
                ListaPrecio_estructura(1).Descripcion = ListaPreciosDescripcion.Text
                clsQueryBuilder.obtener_estructura(dfielddefConstantes.Lista_Precio.ToString(), esquema)
                clslistaprecios.Obtener_Clave_Principal(ClavePrincipal)
                clslistaprecios.Pasar_A_Coleccion(ListaPrecio_estructura, datos, 1)
                clsQueryBuilder.ArmaInsert(dfielddefConstantes.Lista_Precio.ToString(), esquema, datos, ClavePrincipal, consulta)
                clslistaprecios.Operaciones_Tabla(consulta)
                'consulta = "select Id_Lista_Precio as [Cod Lista Precio],Descripcion from " + dfielddefConstantes.Lista_Precio.ToString() + ""
                clslistaprecios.llenar_tabla_ListaPrecio(DGVListaPrecio)
                MessageBox.Show("Los Datos de la Lista de Precio, se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Information)
                clslistaprecios.Limpiar_Datos_ListaPrecio(ListaPreciosDescripcion)
                LimpiarEstructuras()
            Else
                MessageBox.Show("Error: Hay Campos Vacios. Completelos, Gracias!!!", "Informacion", MessageBoxButtons.OK, _
                                                    MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
        For x As Integer = ProgressBarListaPrecio.Minimum To ProgressBarListaPrecio.Maximum
            ProgressBarListaPrecio.Value = x
        Next
        For x As Integer = ProgressBarListaPrecio.Maximum To ProgressBarListaPrecio.Minimum Step -1
            ProgressBarListaPrecio.Value = x
        Next
    End Sub
    Private Sub ModificarListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarListaPrecio.Click
        'Dim listaPrecio As New Controlador.clsLista_Precios
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Try
            ReDim ListaPrecio_estructura(1)
            ListaPrecio_estructura(1).Id_Lista_Precio = CodigoListaPrecio
            ListaPrecio_estructura(1).Descripcion = ListaPreciosDescripcion.Text

            clsQueryBuilder.obtener_estructura(dfielddefConstantes.Lista_Precio.ToString(), esquema)
            clslistaprecios.Obtener_Clave_Principal(ClavePrincipal)
            clslistaprecios.Pasar_A_Coleccion(ListaPrecio_estructura, datos, 1)
            clsQueryBuilder.ArmaUpdate(dfielddefConstantes.Lista_Precio.ToString(), esquema, datos, ClavePrincipal, consulta)
            clslistaprecios.Operaciones_Tabla(consulta)

            MessageBox.Show("La Lista de Precio, se Modifico Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'consulta = "select Id_Lista_Precio as [Cod Lista Precio],Descripcion from " + dfielddefConstantes.Lista_Precio.ToString() + ""
            clslistaprecios.llenar_tabla_ListaPrecio(DGVListaPrecio)
            clslistaprecios.Limpiar_Datos_ListaPrecio(ListaPreciosDescripcion)

            GuardarListaPrecio.Enabled = True
            ModificarListaPrecio.Enabled = False
            EliminarListaPrecio.Enabled = False
            LimpiarEstructuras()
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
        For x As Integer = ProgressBarListaPrecio.Minimum To ProgressBarListaPrecio.Maximum
            ProgressBarListaPrecio.Value = x
        Next
        For x As Integer = ProgressBarListaPrecio.Maximum To ProgressBarListaPrecio.Minimum Step -1
            ProgressBarListaPrecio.Value = x
        Next
    End Sub
    Private Sub DGVListaPrecio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVListaPrecio.Click
        Try
            CodigoListaPrecio = CInt(DGVListaPrecio.CurrentRow.Cells(0).Value.ToString())
            ListaPreciosDescripcion.Text = DGVListaPrecio.CurrentRow.Cells(1).Value.ToString()
            GuardarListaPrecio.Enabled = False
            ModificarListaPrecio.Enabled = True
            EliminarListaPrecio.Enabled = True
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub EliminarListaPrecio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminarListaPrecio.Click
        'Dim listaPrecio As New Controlador.clsLista_Precios
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        'Dim clsQueryBuilder As New Controlador.clsQueryBuilder
        Dim esquema As New Collection
        Dim result As Integer = MessageBox.Show("Desea Eliminar La Lista de Precios: " + ListaPreciosDescripcion.Text, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            Try
                ReDim ListaPrecio_estructura(1)
                ListaPrecio_estructura(1).Id_Lista_Precio = CodigoListaPrecio
                ListaPrecio_estructura(1).Descripcion = ListaPreciosDescripcion.Text
                clslistaprecios.Obtener_Clave_Principal(ClavePrincipal)
                clslistaprecios.Pasar_A_Coleccion(ListaPrecio_estructura, datos, 1)
                clsQueryBuilder.ArmaDelete(dfielddefConstantes.Lista_Precio.ToString(), datos, ClavePrincipal, consulta)
                clslistaprecios.Operaciones_Tabla(consulta)

                MessageBox.Show("La Lista de Precio " + ListaPreciosDescripcion.Text + " se Elimino Correctamente!!!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'consulta = "select Id_Lista_Precio as [Cod Lista Precio],Descripcion from " + dfielddefConstantes.Lista_Precio.ToString() + ""
                clslistaprecios.llenar_tabla_ListaPrecio(DGVListaPrecio)
                clslistaprecios.Limpiar_Datos_ListaPrecio(ListaPreciosDescripcion)

                GuardarListaPrecio.Enabled = True
                ModificarListaPrecio.Enabled = False
                EliminarListaPrecio.Enabled = False
                LimpiarEstructuras()
            Catch ex As Exception
                MsgBox("Error:" & vbCrLf & ex.Message)
            End Try
        End If
        For x As Integer = ProgressBarListaPrecio.Minimum To ProgressBarListaPrecio.Maximum
            ProgressBarListaPrecio.Value = x
        Next
        For x As Integer = ProgressBarListaPrecio.Maximum To ProgressBarListaPrecio.Minimum Step -1
            ProgressBarListaPrecio.Value = x
        Next
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim ListaPrecio_estructura(0)
    End Sub
End Class