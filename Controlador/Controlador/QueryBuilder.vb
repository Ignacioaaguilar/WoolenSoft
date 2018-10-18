Imports Modelo
Public Class QueryBuilder
    Public Sub obtener_estructura(ByVal Tabla As String, ByRef estructura As Collection)
        Dim consulta As String
        Dim conectar As New coneccion()
        Dim Obtencion As DataTable
        consulta = "Select * from   " & Tabla & ""
        Obtencion = conectar.consulta_reader(consulta)
        For i = 0 To Obtencion.Columns.Count - 1
            estructura.Add(Obtencion.Columns(i).ColumnName)
        Next
    End Sub
    Public Sub ArmaInsert(ByVal Tabla As String, ByVal esquema As Collection, ByVal datos As Collection, ByVal ClavePrincipal As Collection, ByRef consulta As String)
        Dim str As String
        Dim i As Integer
        Dim j As Integer
        Dim dato As String
        str = "insert into " & Tabla & "("

        j = 0
        For i = 1 To esquema.Count

            If j < ClavePrincipal.Count Then

                'If datos(i).GetType().Name <> "Int32" Or esquema(i) <> ClavePrincipal(j + 1) Then
                If i < esquema.Count Then
                    str += esquema(i) + ","
                Else
                    str += esquema(i) + ")"
                End If
                'End If
                j = j + 1
                If j = ClavePrincipal.Count Then
                    j = 0
                End If
            End If
        Next

        str += "Values("
        j = 0
        For i = 1 To esquema.Count
            If j < ClavePrincipal.Count Then

                'If datos(i).GetType().Name <> "Int32" Or esquema(i) <> ClavePrincipal(j + 1) Then
                If datos(i).GetType().Name = "String" Then
                    dato = "'" + datos(i) + "'"
                End If
                If datos(i).GetType().Name = "Int32" Then
                    dato = datos(i)
                End If
                If datos(i).GetType().Name = "Boolean" Then
                    dato = datos(i)
                End If
                If i < datos.Count Then
                    str += dato.ToString() + ","
                Else
                    str += dato.ToString() + ")"
                    'End If
                End If
            j = j + 1

            If j = ClavePrincipal.Count Then
                j = 0
            End If
            End If
        Next


        consulta = str
    End Sub

    Public Sub ArmaUpdate(ByVal Tabla As String, ByVal esquema As Collection, ByVal datos As Collection, ByVal Claves As Collection, ByRef consulta As String)
        Dim str As String
        Dim i As Integer
        Dim dat As Object
        str = "update " & Tabla & " set "
        For i = 1 To esquema.Count
            If datos(i).GetType().Name = "String" Then
                dat = "'" + datos(i) + "'"
            End If
            If datos(i).GetType().Name = "Int32" Then
                dat = datos(i)
            End If
            If datos(i).GetType().Name = "Boolean" Then
                dat = datos(i)
            End If
            If i < esquema.Count Then
                str += esquema(i) + "=" + dat.ToString() + ","
            Else
                str += esquema(i) + "=" + dat.ToString()
            End If
        Next

        str += " where "
        For i = 1 To Claves.Count
            If datos(i).GetType().Name = "Int32" Then
                dat = datos(i)
            End If
            If datos(i).GetType().Name = "String" Then
                dat = "'" + datos(i) + "'"
            End If
            If datos(i).GetType().Name = "Boolean" Then
                dat = "'" + datos(i) + "'"
            End If
            str += Claves(i) + "="
            str += dat.ToString()
            If i < Claves.Count Then
                str += " and "
            End If
        Next
        consulta = str
    End Sub
    Public Sub ArmaDelete(ByVal Tabla As String, ByVal datos As Collection, ByVal Claves As Collection, ByRef consulta As String)
        Dim str As String
        Dim i As Integer
        Dim dat As Object
        str = "Delete From  " & Tabla & ""
        str += " where "
        For i = 1 To Claves.Count

            If datos(i).GetType().Name = "Int32" Then
                dat = datos(i)
            End If
            If datos(i).GetType().Name = "String" Then
                dat = "'" + datos(i) + "'"
            End If
            If datos(i).GetType().Name = "Boolean" Then
                dat = "'" + datos(i) + "'"
            End If
            str += Claves(i) + "="
            str += dat.ToString()
            If i < Claves.Count Then
                str += " and "
            End If
        Next
        consulta = str


    End Sub
End Class
