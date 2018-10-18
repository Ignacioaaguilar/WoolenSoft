Imports System.Windows.Forms
Imports Modelo
Imports System.IO.StreamWriter
Imports System.IO
Imports System.Xml
Public Class Session
    Class Contacto
        Public Cadena As String
        Public NroPuesto As String
        Public Direccion As String
        Public email As String
        Public Sub New()
        End Sub
    End Class
    Public Structure eSession
        Public CadenaConeccion As String
        Public NroPuesto As String
    End Structure
    Public Function Session() As eSession
        Dim ContactosRead As Object
        Dim estsession As eSession
        OpenFileContactosXML(ContactosRead)
        pasaraestructura(ContactosRead, estsession)
        Return estsession
    End Function
    Private Sub OpenFileContactosXML(ByRef ContactosRead As Object)
        'Leer un archivo XML y cargarlo en un objeto
        Dim xmlReader As New XmlTextReader("C:\cfg\Contacto.xml")
        'Crear un objeto para deserializar el archivo XML
        Dim Reader As New Serialization.XmlSerializer(GetType(Contacto))
        'Deserialziar el archivo xml y cargarlo en un objeto
        'Dim ContactosRead = Reader.Deserialize(xmlReader)
        ContactosRead = Reader.Deserialize(xmlReader)
        'Cargar los datos en la forma.
        'txtNombre.Text = ContactosRead.Cadena
        'txtDireccion.Text = ContactosRead.Direccion
        'txtTelefono.Text = ContactosRead.telefono
        'txtEmail.Text = ContactosRead.email
        'Cerrar Archivo XML
        xmlReader.Close()
    End Sub
    Private Sub pasaraestructura(ByVal ContactosRead As Object, ByRef estsession As eSession)
        estsession.CadenaConeccion = ContactosRead.Cadena
        estsession.NroPuesto = ContactosRead.NroPuesto
    End Sub
End Class
