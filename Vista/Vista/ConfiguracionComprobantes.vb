Public Class ConfiguracionComprobantes
    Dim ConfiguracionComprobantes_Estructura(0) As Controlador.Configuracion.eConfiguracionComprobante
    Dim dfielddefConfiguracionComprobante As Controlador.DfieldDef.eConfiguracionComprobantes
    Dim dfielddefConstantes As Controlador.DfieldDef.eConstantes
    Dim dfielddefTipoComprobante As Controlador.DfieldDef.eTipoComprobante
    Dim idx As Integer = 0
    Private Sub btBuscarFactA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarFactA.Click
        PrintDialog.ShowDialog()
        tbImpresoraFactA.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub ToolStripButtonSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonSalir.Click
        For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
            ToolStripProgressBar.Value = x
        Next
        For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
            ToolStripProgressBar.Value = x
        Next
        Me.Close()
    End Sub
    Private Sub tbImpresoraFactA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraFactA.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("1", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "1"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopFactA.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopFactA.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraFactA.Text
    End Sub
    Private Sub tbCantCopFactA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopFactA.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopFactA.Text)) Then
            tbCantCopFactA.Text = ""
        Else
            configuracion.Esta_En_Coleccion("1", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraFactA.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "1"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopFactA.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopFactA.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraFactA.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "1"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopFactA.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopFactA.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraFactA.Text
            End If
        End If
    End Sub
    Private Sub tbImpresoraFactB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraFactB.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("6", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "6"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopFactB.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopFactB.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraFactB.Text
    End Sub
    Private Sub tbCantCopFactB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopFactB.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopFactB.Text)) Then
            tbCantCopFactB.Text = ""
        Else
            configuracion.Esta_En_Coleccion("6", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbCantCopFactB.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "6"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopFactB.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopFactB.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraFactB.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "6"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopFactB.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopFactB.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraFactB.Text
            End If
        End If
    End Sub
    Private Sub tbImpresoraFactC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraFactC.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("11", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "11"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "

        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopFactC.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopFactC.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraFactC.Text
    End Sub
    Private Sub tbCantCopFactC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopFactC.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopFactC.Text)) Then
            tbCantCopFactC.Text = ""
        Else
            configuracion.Esta_En_Coleccion("11", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraFactC.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "11"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)

                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopFactC.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopFactC.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbCantCopFactC.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "11"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopFactC.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopFactC.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraFactC.Text
            End If
        End If
    End Sub
    Private Sub btBuscarFactB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarFactB.Click
        PrintDialog.ShowDialog()
        tbImpresoraFactB.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub btBuscarFactC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarFactC.Click
        PrintDialog.ShowDialog()
        tbImpresoraFactC.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub tbImpresoraNCA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraNCA.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("3", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "3"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopNCB.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNCB.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNCA.Text
    End Sub
    Private Sub tbCantCopNCB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopNCB.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopNCB.Text)) Then
            tbCantCopNCB.Text = ""
        Else
            configuracion.Esta_En_Coleccion("8", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraNCB.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "8"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNCB.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNCB.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNCB.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "8"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNCB.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNCB.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNCB.Text
            End If
        End If
    End Sub
    Private Sub tbCantCopNCA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopNCA.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopNCA.Text)) Then
            tbCantCopNCA.Text = ""
        Else
            configuracion.Esta_En_Coleccion("3", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraNCA.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "3"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNCA.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNCA.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNCA.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "3"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNCA.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNCA.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNCA.Text
            End If
        End If
    End Sub
    Private Sub tbImpresoraNCB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraNCB.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("8", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "8"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNCB.Text
    End Sub
    Private Sub tbImpresoraNCC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraNCC.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("13", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "13"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopNCC.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNCC.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNCC.Text
    End Sub
    Private Sub tbCantCopNCC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopNCC.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopNCC.Text)) Then
            tbCantCopNCC.Text = ""
        Else
            configuracion.Esta_En_Coleccion("13", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraNCC.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "13"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNCC.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNCC.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNCC.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "13"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNCC.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNCC.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNCC.Text
            End If
        End If
    End Sub
    Private Sub btBuscarNCA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarNCA.Click
        PrintDialog.ShowDialog()
        tbImpresoraNCA.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub btBuscarNCB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarNCB.Click
        PrintDialog.ShowDialog()
        tbImpresoraNCB.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub btBuscarNCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarNCC.Click
        PrintDialog.ShowDialog()
        tbImpresoraNCC.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub tbImpresoraNDA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraNDA.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("2", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "2"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopNDA.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNDA.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNDA.Text
    End Sub
    Private Sub tbCantCopNDA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopNDA.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopNDA.Text)) Then
            tbCantCopNDA.Text = ""
        Else
            configuracion.Esta_En_Coleccion("2", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraNDA.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "2"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNDA.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNDA.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNDA.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "2"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)

                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion

                If tbCantCopNDA.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNDA.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNDA.Text
            End If
        End If
    End Sub
    Private Sub tbImpresoraNDB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraNDB.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("7", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "7"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)

        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopNBB.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNBB.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNDB.Text
    End Sub
    Private Sub tbCantCopNBB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopNBB.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopNBB.Text)) Then
            tbCantCopNBB.Text = ""
        Else
            configuracion.Esta_En_Coleccion("7", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbCantCopNBB.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "7"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNBB.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNBB.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbCantCopNBB.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "7"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNBB.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNBB.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbCantCopNBB.Text
            End If
        End If
    End Sub
    Private Sub tbImpresoraNDC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraNDC.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("12", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "12"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion

        If tbCantCopNDC.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNDC.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNDC.Text
    End Sub
    Private Sub tbCantCopNDC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopNDC.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopNDC.Text)) Then
            tbCantCopNDC.Text = ""
        Else
            configuracion.Esta_En_Coleccion("12", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraNDC.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "12"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNDC.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNDC.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNDC.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "12"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopNDC.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopNDC.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraNDC.Text
            End If
        End If
    End Sub
    Private Sub btBuscarNDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarNDA.Click
        PrintDialog.ShowDialog()
        tbImpresoraNDA.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub btBuscarNDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarNDB.Click
        PrintDialog.ShowDialog()
        tbImpresoraNDB.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub btBuscarNDC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarNDC.Click
        PrintDialog.ShowDialog()
        tbImpresoraNDC.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub tbImpresoraVRA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraVRA.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("16", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "16"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopVRA.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopVRA.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraVRA.Text
    End Sub
    Private Sub tbCantCopVRA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopVRA.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopVRA.Text)) Then
            tbCantCopVRA.Text = ""
        Else
            configuracion.Esta_En_Coleccion("16", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraVRA.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "16"
                ' consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopVRA.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopVRA.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraVRA.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "16"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopVRA.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopVRA.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraVRA.Text
            End If
        End If
    End Sub
    Private Sub tbImpresoraVRB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraVRB.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("17", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "17"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopVRB.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopVRB.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraVRB.Text
    End Sub
    Private Sub tbCantCopVRB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopVRB.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopVRB.Text)) Then
            tbCantCopVRB.Text = ""
        Else
            configuracion.Esta_En_Coleccion("17", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraVRB.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "17"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)

                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopVRB.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopVRB.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraVRB.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "17"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopVRB.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopVRB.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraVRB.Text
            End If
        End If
    End Sub
    Private Sub tbImpresoraVRC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbImpresoraVRC.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        configuracion.Esta_En_Coleccion("18", ConfiguracionComprobantes_Estructura, existe, pos)
        If existe Then
            idx = pos
        Else
            idx = ConfiguracionComprobantes_Estructura.Count
            ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
        End If
        ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "18"
        'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
        ' Facturacion.Obtener_Datos_Comprobante(consulta, datos)
        Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
        'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
        ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
        If tbCantCopVRC.Text = "" Then
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
        Else
            ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopVRC.Text)
        End If
        ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraVRC.Text
    End Sub
    Private Sub tbCantCopVRC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCantCopVRC.TextChanged
        Dim consulta As String
        Dim Facturacion As New Controlador.Facturacion
        Dim datosTipoComprobante As Controlador.Facturacion.eTipoComprobante
        Dim configuracion As New Controlador.Configuracion
        Dim existe As Boolean
        Dim pos As Integer
        If Not (configuracion.es_Numero(tbCantCopVRC.Text)) Then
            tbCantCopVRC.Text = ""
        Else
            configuracion.Esta_En_Coleccion("18", ConfiguracionComprobantes_Estructura, existe, pos)
            If existe Then
                idx = pos
            Else
                idx = ConfiguracionComprobantes_Estructura.Count
                ReDim Preserve ConfiguracionComprobantes_Estructura(idx)
            End If
            If tbImpresoraVRC.Text = "" Then
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "18"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopVRC.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopVRC.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraVRC.Text
            Else
                ConfiguracionComprobantes_Estructura(idx).Id_Comprobante = "18"
                'consulta = "select * from Tipos_Comprobantes where IdTipoComprobante='" + ConfiguracionComprobantes_Estructura(idx).Id_Comprobante + "' "
                'Facturacion.Obtener_Datos_Comprobante(consulta, datos)
                Facturacion.Obtener_Tipo_Comprobante(ConfiguracionComprobantes_Estructura(idx).Id_Comprobante, datosTipoComprobante)
                'ConfiguracionComprobantes_Estructura(idx).Descripcion = datos.Rows(0).Item(dfielddefTipoComprobante.Descripcion)
                ConfiguracionComprobantes_Estructura(idx).Descripcion = datosTipoComprobante.Descripcion
                If tbCantCopVRC.Text = "" Then
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = 0
                Else
                    ConfiguracionComprobantes_Estructura(idx).CantidadCopias = Convert.ToInt32(tbCantCopVRC.Text)
                End If
                ConfiguracionComprobantes_Estructura(idx).Impresora = tbImpresoraVRC.Text
            End If
        End If
    End Sub
    Private Sub ToolStripRegistrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRegistrar.Click
        Dim Configuracion As New Controlador.Configuracion
        Dim general As New Controlador.Generales
        Dim consulta As String
        Dim datos As New Collection
        Dim ClavePrincipal As New Collection
        Dim querybuilder As New Controlador.QueryBuilder
        Dim esquema As New Collection
        Dim i As Integer
        Dim trans As New Collection
        Dim existe As Boolean
        Try
            For x As Integer = ToolStripProgressBar.Minimum To ToolStripProgressBar.Maximum
                ToolStripProgressBar.Value = x
            Next
            For x As Integer = ToolStripProgressBar.Maximum To ToolStripProgressBar.Minimum Step -1
                ToolStripProgressBar.Value = x
            Next
            querybuilder.obtener_estructura(dfielddefConstantes.ConfiguracionComprobantes.ToString(), esquema)
            Configuracion.Obtener_Clave_Principal_ConfiguracionComprobante(ClavePrincipal)
            For i = 1 To ConfiguracionComprobantes_Estructura.Count - 1
                Configuracion.Pasar_A_Coleccion_ConfiguracionComprobantes(ConfiguracionComprobantes_Estructura, datos, i)
                Configuracion.Existe(datos(dfielddefConfiguracionComprobante.Id_Comprobante + 1), existe)
                If Not existe Then
                    querybuilder.ArmaInsert(dfielddefConstantes.ConfiguracionComprobantes.ToString(), esquema, datos, ClavePrincipal, consulta)
                Else
                    querybuilder.ArmaUpdate(dfielddefConstantes.ConfiguracionComprobantes.ToString(), esquema, datos, ClavePrincipal, consulta)
                End If
                trans.Add(consulta)
                datos.Clear()
            Next
            general.Operaciones_Tabla_Transaccion(trans)
            MessageBox.Show("Los Datos se Agregaron Correctamente!!!", "Informacion", MessageBoxButtons.OK, _
            MessageBoxIcon.Information)
            Configuracion.Limpiar_Datos_ConfiguracionComprobantes(tbImpresoraFactA, tbCantCopFactA, tbImpresoraFactB, tbCantCopFactB, tbImpresoraFactC, tbCantCopFactC, tbImpresoraNCA, tbCantCopNCA, tbImpresoraNCB, tbCantCopNCB, tbImpresoraNCC, tbCantCopNCC, tbImpresoraNDA, tbCantCopNDA, tbImpresoraNDB, tbCantCopNBB, tbImpresoraNDC, tbCantCopNDC, tbImpresoraVRA, tbCantCopVRA, tbImpresoraVRB, tbCantCopVRB, tbImpresoraVRC, tbCantCopVRC)
            LimpiarEstructuras()
            'consulta = "select Id_Comprobante as [Cod Comprobante],Descripcion,CantidadCopias as [Cant Copias],Impresora from ConfiguracionComprobantes"
            Configuracion.llenar_tabla_Configuracion_Comprobante(dgvConfiguracionComprobantes)
        Catch ex As Exception
            MsgBox("Error:" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub btBuscarVRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarVRA.Click
        PrintDialog.ShowDialog()
        tbImpresoraVRA.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub btBuscarVRB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarVRB.Click
        PrintDialog.ShowDialog()
        tbImpresoraVRB.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Private Sub btBuscarVRC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBuscarVRC.Click
        PrintDialog.ShowDialog()
        tbImpresoraVRC.Text = PrintDialog.PrinterSettings.PrinterName
    End Sub
    Public Sub LimpiarEstructuras()
        ReDim ConfiguracionComprobantes_Estructura(0)
    End Sub
    Private Sub ConfiguracionComprobantes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim consulta As String
        Dim Configuracion As New Controlador.Configuracion
        'consulta = "select Id_Comprobante as [Cod Comprobante],Descripcion,CantidadCopias as [Cant Copias],Impresora from ConfiguracionComprobantes"
        Configuracion.llenar_tabla_Configuracion_Comprobante(dgvConfiguracionComprobantes)
    End Sub
    Private Sub dgvConfiguracionComprobantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvConfiguracionComprobantes.Click
        Dim id_Comprobante As Integer
        id_Comprobante = CInt(dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Id_Comprobante).Value.ToString())
        Select Case id_Comprobante
            Case "1"
                tbImpresoraFactA.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopFactA.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "6"
                tbImpresoraFactB.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopFactB.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "11"
                tbImpresoraFactC.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopFactC.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "3"
                tbImpresoraNCA.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopNCA.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "8"
                tbImpresoraNCB.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopNCB.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "13"
                tbImpresoraNCC.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopNCC.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "2"
                tbImpresoraNDA.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopNDA.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "7"
                tbImpresoraNDB.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopNBB.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "12"
                tbImpresoraNDC.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopNDC.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "16"
                tbImpresoraVRA.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopVRA.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "17"
                tbImpresoraVRB.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopVRB.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
            Case "18"
                tbImpresoraVRC.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.Impresora).Value.ToString()
                tbCantCopVRC.Text = dgvConfiguracionComprobantes.CurrentRow.Cells(dfielddefConfiguracionComprobante.CantidadCopias).Value.ToString()
        End Select
    End Sub
End Class