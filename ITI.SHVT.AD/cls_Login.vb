Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient
Namespace AD_LOGIN
    Public Class cls_Login
#Region "MÉTODOS Y FUNCIONES"
        ''' <summary>
        ''' Verificar existencia de usuario en el sistema
        ''' Se regresa el id_usuario para variable de session y la url principal de redireccionamiento
        ''' </summary>
        ''' <param name="pvs_Usuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_VerificarUsuario(ByVal pvs_Usuario As String,
                                             ByVal pvs_Contrasena As String) As Collection
            Dim vli_Retorno As String = ""
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_VerificarUsuario"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_s_VerificarUsuario", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@Usuario", pvs_Usuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Contrasena", pvs_Contrasena)
                    vlo_SqlConnection.Open()
                    Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    If dataReader.Read() Then
                        vli_Retorno = dataReader("Url")
                    End If
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , vli_Retorno)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function


        Public Function fgo_VerificarOpcionSistema(ByVal pvi_id_Usuario As Integer,
                                                   ByVal pvs_Url As String) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_VerificarOpcionSistema"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_s_VerificarOpcionSistema", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", pvi_id_Usuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Url", pvs_Url)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function
#End Region
    End Class
End Namespace

