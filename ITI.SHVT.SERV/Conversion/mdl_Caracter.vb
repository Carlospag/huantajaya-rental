Namespace Conversion

    Public Module mdl_Caracter

        Public Function fgs_LimpiaTexto(ByVal pvs_Texto As String) As String
            Try
                Dim vls_Retorno As String

                'Tab
                vls_Retorno = Replace(pvs_Texto, vbTab, "")
                'Salto de línea
                vls_Retorno = Replace(vls_Retorno, vbCrLf, "")
                'Espacios inicio y final
                vls_Retorno = Trim(vls_Retorno)

                Return vls_Retorno
            Catch ex As Exception
                Return ""
            End Try
        End Function

    End Module

End Namespace