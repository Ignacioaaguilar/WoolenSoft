Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms



Public Class coneccion



    'Dim str_conexion As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.AppDomain.CurrentDomain.BaseDirectory + "Kiosco.mdb;Persist Security Info=False;Jet OLEDB:Database Password=kiosco;User ID=Admin;"
    Dim str_conexion As String
    Dim comando As New OleDbCommand
    'La cadena de conexion obviamente la tienen que cambiar por la de ustedes. 

    Dim conexion As New OleDbConnection
    Dim cmd As OleDbCommand



    Public Property srt_conexion() As String
        Get
            Return Me.str_conexion
        End Get
        Set(ByVal str As String)
            Me.str_conexion = str
        End Set
    End Property

    'Public Sub New(ByVal str As String) 
    'Me.str_conexion = str 
    'End Sub 

    Public Sub consulta_non_query(ByVal consulta As String)


        'Este metodo recibe como parametro la consulta completa y sirve para hacer INSERT, UPDATE Y DELETE 
        conexion.ConnectionString = str_conexion

        cmd = New OleDbCommand(consulta, conexion)

        conexion.Open()

        Dim trx As OleDbTransaction = conexion.BeginTransaction(IsolationLevel.ReadCommitted)
        cmd.Transaction = trx
        Try
            cmd.ExecuteNonQuery()


            trx.Commit()
            'MsgBox("La operacion se realizo con exito!", MsgBoxStyle.Information, "Operacion exitosa!")
        Catch ex As Exception
            trx.Rollback()
            MsgBox("Error al operar con la base de datos!", MsgBoxStyle.Critical, "Error!")
        End Try
        conexion.Close()


    End Sub

    Public Sub consulta_non_query_Transaccion(ByVal Trans As Collection)
        'Dim strSQL As String

        'Este metodo recibe como parametro la consulta completa y sirve para hacer INSERT, UPDATE Y DELETE 
        conexion.ConnectionString = str_conexion

        'cmd = New OleDbCommand(Trans, conexion)
        cmd = New OleDbCommand()

        conexion.Open()

        Dim trx As OleDbTransaction = conexion.BeginTransaction(IsolationLevel.ReadCommitted)

        Try



            For index As Integer = 1 To Trans.Count

                cmd = New OleDbCommand(Trans(index), conexion)
                cmd.Transaction = trx
                cmd.ExecuteNonQuery()
            Next
            'cmd.CommandText = strSQL

            trx.Commit()
            'MsgBox("La operacion se realizo con exito!", MsgBoxStyle.Information, "Operacion exitosa!")
        Catch ex As Exception
            trx.Rollback()
            MsgBox("Error al operar con la base de datos!", MsgBoxStyle.Critical, "Error!")
        End Try
        conexion.Close()


    End Sub


    Public Function consulta_reader(ByVal consulta As String) As DataTable

        'Este metodo recibe como parametro la consulta completa y sirve para hacer SELECT 
        Dim dt As New DataTable
        conexion.ConnectionString = str_conexion
        cmd = New OleDbCommand(consulta, conexion)
        conexion.Open()
        Dim trx As OleDbTransaction = conexion.BeginTransaction(IsolationLevel.ReadCommitted)
        cmd.Transaction = trx
        Try

            dt.Load(cmd.ExecuteReader())
            trx.Commit()
        Catch ex As Exception
            MsgBox("Error al operar con la base de datos!", MsgBoxStyle.Critical, "Error!")
            trx.Rollback()
        End Try
        conexion.Close()
        Return dt

    End Function

    Public Sub cargar_lista(ByRef lista As ListBox, ByVal consulta As String, ByVal valueMember As String, ByVal displayMember As String)
        Dim dt As New Data.DataTable
        conexion.ConnectionString = str_conexion
        cmd = New OleDbCommand(consulta, conexion)
        conexion.Open()

        Try
            dt.Load(cmd.ExecuteReader())

            lista.DataSource = dt
            lista.ValueMember = valueMember
            lista.DisplayMember = displayMember
        Catch ex As Exception
            MsgBox("Error al operar con la base de datos!", MsgBoxStyle.Critical, "Error!")

        End Try
        conexion.Close()
    End Sub
    Public Sub cargar_tabla(ByRef tabla As DataGridView, ByVal consulta As String)
        Dim dt As New DataTable

        conexion.ConnectionString = str_conexion
        comando = New OleDbCommand(consulta, conexion)
        conexion.Open()

        Try

            dt.Load(comando.ExecuteReader())

            tabla.DataSource = dt

            'combo.ValueMember = valueMember
            'combo.DisplayMember = displayMember
        Catch ex As Exception
            MsgBox("Error al operar con la base de datos!", MsgBoxStyle.Critical, "Error!")

        End Try
        conexion.Close()

    End Sub

    Public Sub cargar_combo(ByRef combo As ComboBox, ByVal consulta As String, ByVal valueMember As String, ByVal displayMember As String)
        Dim dt As New DataTable
        conexion.ConnectionString = str_conexion
        cmd = New OleDbCommand(consulta, conexion)
        conexion.Open()

        Try
            dt.Load(cmd.ExecuteReader())

            combo.DataSource = dt
            combo.ValueMember = valueMember
            combo.DisplayMember = displayMember
        Catch ex As Exception
            MsgBox("Error al operar con la base de datos!", MsgBoxStyle.Critical, "Error!")

        End Try
        conexion.Close()
    End Sub

    Public Function verificar_existencia(ByVal consulta As String) As Boolean


        'Devuelve true si existe, entonces no grabamos, o devuelve false si no existe entoinces debemos grabar. 
        Dim dt As New DataTable
        conexion.ConnectionString = str_conexion
        cmd = New OleDbCommand(consulta, conexion)
        conexion.Open()
        Try
            dt.Load(cmd.ExecuteReader())

        Catch ex As Exception
            MsgBox("Error al operar con la base de datos!", MsgBoxStyle.Critical, "Error!")

        End Try

        conexion.Close()

        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class







