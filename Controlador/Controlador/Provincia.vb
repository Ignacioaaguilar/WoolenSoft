﻿Imports Modelo
Imports System.Windows.Forms
Public Class Provincia
    Private descripcion As String
    Public Property Compdescripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(ByVal Value As String)
            Me.descripcion = Value
        End Set
    End Property
    Public Sub llenar_tabla_provincia(ByVal cadena As String, ByRef grilla As DataGridView)
        Dim conectar As New coneccion()
        conectar.cargar_tabla(grilla, cadena)
    End Sub

    Public Sub llenar_Combo_provincia(ByRef combo As ComboBox, ByVal cadena As String, ByVal value As String, ByVal member As String)
        Dim conectar As New coneccion()
        conectar.cargar_combo(combo, cadena, value, member)


    End Sub

    Public Sub Operaciones_Tabla(ByVal consulta As String)
        Dim conectar As New coneccion()
        conectar.consulta_non_query(consulta)

    End Sub

    Public Function es_Vacio(ByVal valor As String) As Boolean
        If (valor = "") Then
            es_Vacio = True
        Else
            es_Vacio = False

        End If
    End Function


End Class
