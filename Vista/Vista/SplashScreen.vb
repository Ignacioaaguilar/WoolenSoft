Imports System.IO
Imports System.Management
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Text
Public NotInheritable Class SplashScreen
    Private Shared DES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider
    'TODO: Este formulario se puede establecer fácilmente como pantalla de bienvenida para la aplicación desde la ficha "Aplicación"
    '  del Diseñador de proyectos ("Propiedades" bajo el menú "Proyecto").


    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Start()
        Me.Show()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim Clave As String = ""
        Dim ClaveDes As String = ""
        Timer1.Stop()

        'si existe archivo de configuracion que tenga el numero de placa base y coincide
        'Llamo a Loginform
        'Si no existe o no coincide llamo a configurador de num placa base. Creo el archivo y lo grabo y
        'llamo a loginform
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "/" + "Configuracion.txt") Then
            LeerArchivo(ClaveDes)
            If ClaveDes <> String.Empty Then
                ClaveDes = Decrypt(ClaveDes)
            End If
            Clave = Clave + GetProcessorId() + MBSerialNumber()
            If iguales(Clave, ClaveDes) Then
                LoginForm.Show()
            Else
                RegistrarProducto.Show()
            End If
        Else
            RegistrarProducto.Show()
        End If

        'Me.Menu.AllowTransparency = True
        Me.Hide()
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
        Dim Almacenado As String = ""
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

    Public Function DesEncriptar(ByVal numero As String) As String
        Dim i As Integer
        Dim Almacenado As String = ""
        Dim DesEncriptado As Integer
        i = 1
        While i <= Len(numero)

            If IsNumeric(Mid(numero, i, 2)) Then
                DesEncriptado = Convert.ToInt32((Mid(numero, i, 2) / 2) - 40)
                Almacenado = Almacenado + DesEncriptado.ToString()
            Else
                Almacenado = Almacenado + (Mid(numero, i, 2))
            End If
            i += 2
        End While
        Return Almacenado
    End Function
    Function iguales(ByVal Clave As String, ByVal ClaveDes As String) As Boolean
        iguales = String.Equals(Clave, ClaveDes)
        Return iguales
    End Function

    Public Sub LeerArchivo(ByRef ClaveDes As String)
        Dim objReader As New StreamReader(My.Computer.FileSystem.SpecialDirectories.MyDocuments + "/" + "Configuracion.txt")
        Dim sLine As String = ""
        Dim arrText As New ArrayList()
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrText.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        If arrText.Count > 0 Then

            ClaveDes = arrText(0)
        Else
            ClaveDes = ""
        End If
        objReader.Close()
    End Sub

    Public Function Decrypt(ByVal cipherText As String) As String
        Dim passPhrase As String = "yourPassPhrase"
        Dim saltValue As String = "mySaltValue"
        Dim hashAlgorithm As String = "SHA1"

        Dim passwordIterations As Integer = 2
        Dim initVector As String = "@1B2c3D4e5F6g7H8"
        Dim keySize As Integer = 256
        ' Convert strings defining encryption key characteristics into byte
        ' arrays. Let us assume that strings only contain ASCII codes.
        ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
        ' encoding.
        Dim initVectorBytes As Byte() = Encoding.ASCII.GetBytes(initVector)
        Dim saltValueBytes As Byte() = Encoding.ASCII.GetBytes(saltValue)

        ' Convert our ciphertext into a byte array.
        Dim cipherTextBytes As Byte() = Convert.FromBase64String(cipherText)

        ' First, we must create a password, from which the key will be 
        ' derived. This password will be generated from the specified 
        ' passphrase and salt value. The password will be created using
        ' the specified hash algorithm. Password creation can be done in
        ' several iterations.
        Dim password As New PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations)

        ' Use the password to generate pseudo-random bytes for the encryption
        ' key. Specify the size of the key in bytes (instead of bits).
        Dim keyBytes As Byte() = password.GetBytes(keySize \ 8)

        ' Create uninitialized Rijndael encryption object.
        Dim symmetricKey As New RijndaelManaged()

        ' It is reasonable to set encryption mode to Cipher Block Chaining
        ' (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC

        ' Generate decryptor from the existing key bytes and initialization 
        ' vector. Key size will be defined based on the number of the key 
        ' bytes.
        Dim decryptor As ICryptoTransform = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

        ' Define memory stream which will be used to hold encrypted data.
        Dim memoryStream As New MemoryStream(cipherTextBytes)

        ' Define cryptographic stream (always use Read mode for encryption).
        Dim cryptoStream As New CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)

        ' Since at this point we don't know what the size of decrypted data
        ' will be, allocate the buffer long enough to hold ciphertext;
        ' plaintext is never longer than ciphertext.
        Dim plainTextBytes As Byte() = New Byte(cipherTextBytes.Length - 1) {}

        ' Start decrypting.
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)

        ' Close both streams.
        memoryStream.Close()
        cryptoStream.Close()

        ' Convert decrypted data into a string. 
        ' Let us assume that the original plaintext string was UTF8-encoded.
        Dim plainText As String = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount)

        ' Return decrypted string.   
        Return plainText
    End Function
   
End Class

