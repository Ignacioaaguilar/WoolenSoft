Imports System.IO
Imports System.Management
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Text
Public Class frmRegistrarProducto
    Private Crypto As New RSACryptoServiceProvider
    Private ue As New System.Text.UTF7Encoding
    Public Archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "/" + "Configuracion.txt"
    Private Sub RegistrarProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Clave As String = String.Empty
        Clave = Clave + GetProcessorId() + MBSerialNumber()
        tbCodigo.Text = Encriptar(Clave)
    End Sub
    Public Function GetProcessorId() As String
        Dim manClass As ManagementClass = New ManagementClass("Win32_Processor")
        Dim manObjCol As ManagementObjectCollection = manClass.GetInstances()
        Dim ProcessorId As String = String.Empty
        For Each manObj As ManagementObject In manObjCol
            ProcessorId = manObj.Properties("ProcessorId").Value.ToString()
        Next
        Return ProcessorId
    End Function
    Public Function MBSerialNumber() As String

        'RETRIEVES SERIAL NUMBER OF MOTHERBOARD
        'IF THERE IS MORE THAN ONE MOTHERBOARD, THE SERIAL
        'NUMBERS WILL BE DELIMITED BY COMMAS

        'YOU MUST HAVE WMI INSTALLED AND A REFERENCE TO
        'Microsoft WMI Scripting Library IS REQUIRED

        Dim objs As Object

        Dim obj As Object
        Dim WMI As Object
        Dim sAns As String
        WMI = GetObject("WinMgmts:")
        objs = WMI.InstancesOf("Win32_BaseBoard")
        For Each obj In objs
            sAns = sAns & obj.SerialNumber
            'If sAns < objs.Count Then sAns = sAns & ","
        Next
        MBSerialNumber = sAns
    End Function


    Public Function Encriptar(ByVal numero As String) As String
        Dim i As Integer
        Dim Almacenado As String = String.Empty
        Dim Encriptado As Integer
        For i = 1 To Len(numero)
            If IsNumeric(Mid(numero, i, 1)) Then
                Encriptado = Convert.ToInt32((Mid(numero, i, 1) + 40) * 2)
                Almacenado = Almacenado + Encriptado.ToString()
            Else
                Almacenado = Almacenado + (Mid(numero, i, 1))
            End If
        Next
        Return Almacenado
    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        End
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim TextoEncriptado As String
        If txtNumeroDesc.Text <> String.Empty Then
            If My.Computer.FileSystem.FileExists(Archivo) Then
                Using file As New IO.StreamWriter(Archivo)
                    file.Flush()
                End Using
                Dim sw As New System.IO.StreamWriter(Archivo)
                TextoEncriptado = Encrypt(txtNumeroDesc.Text)
                sw.WriteLine(TextoEncriptado)
                sw.Close()
                End
            Else
                Dim file As System.IO.FileStream
                file = System.IO.File.Create(Archivo)
                file.Close()
                Dim sw As New System.IO.StreamWriter(Archivo)
                TextoEncriptado = Encrypt(txtNumeroDesc.Text)
                sw.WriteLine(TextoEncriptado)
                sw.Close()
                End
            End If
        Else
            MessageBox.Show("No ha ingresado el numero proporcionado por el Administrador!!!", "Informacion", MessageBoxButtons.OK, _
                                                                    MessageBoxIcon.Information)
        End If
    End Sub
    Public Function Encrypt(ByVal plainText As String) As String

        Dim passPhrase As String = "yourPassPhrase"
        Dim saltValue As String = "mySaltValue"
        Dim hashAlgorithm As String = "SHA1"

        Dim passwordIterations As Integer = 2
        Dim initVector As String = "@1B2c3D4e5F6g7H8"
        Dim keySize As Integer = 256

        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

        Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)
        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)
        Dim symmetricKey As New RijndaelManaged()

        symmetricKey.Mode = CipherMode.CBC

        Dim encryptor As ICryptoTransform = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

        Dim memoryStream As New MemoryStream()
        Dim cryptoStream As New CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)

        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)
        cryptoStream.FlushFinalBlock()
        Dim cipherTextBytes As Byte() = memoryStream.ToArray()
        memoryStream.Close()
        cryptoStream.Close()
        Dim cipherText As String = Convert.ToBase64String(cipherTextBytes)
        Return cipherText
    End Function

End Class