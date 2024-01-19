Imports System.Text
Imports System.Security.Cryptography

Public Class cls_General

#Region "MÉTODOS Y FUNCIONES"
    ''' <summary>
    ''' Función que realiza encriptación utilizando MD5. 
    ''' </summary>
    ''' <param name="pvs_TextoAEncriptar">Texto a encriptar</param>
    ''' <returns>Texto encriptado</returns>
    ''' <remarks>Marcelo Woloszyn - 01/03/2007</remarks>
    Public Shared Function fgs_Encripta(ByVal pvs_TextoAEncriptar As String) As String
        Dim vlo_MD5 As New MD5CryptoServiceProvider
        Dim vlby_Byte(), vlby_Hash() As Byte
        Dim vls_TextoEncriptado As String = ""
        'Convierte texto a encriptar a Bytes         
        vlby_Byte = System.Text.Encoding.UTF8.GetBytes(pvs_TextoAEncriptar)
        'Aplicación del algoritmo hash         
        vlby_Hash = vlo_MD5.ComputeHash(vlby_Byte)
        'Convierte la matriz de byte en una cadena         
        For Each vlby_Aux As Byte In vlby_Hash
            vls_TextoEncriptado += vlby_Aux.ToString("x2")
        Next

        'Retorno de función         
        Return vls_TextoEncriptado

    End Function
#End Region

End Class
