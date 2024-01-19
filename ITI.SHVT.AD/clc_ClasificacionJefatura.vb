Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient

Namespace AD_CLASIFICACIONJEFATURA

    Public Class clc_ClasificacionJefatura

        ''' <summary>
        ''' Clasifica al colaborador con un usuario especifico, para posteriormente enviar notificaciones y luego aprobar.
        ''' </summary>
        ''' <param name="pvi_id_Usuario"></param>
        ''' <param name="pvs_RutColaborador"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_ClasificarColaborador(ByVal pvi_id_Usuario As Integer,
                                                ByVal pvs_RutColaborador As String) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_ClasificarColaborador"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_i_ClasificarColaborador", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", pvi_id_Usuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@RutColaborador", pvs_RutColaborador)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery()
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        ''' <summary>
        ''' Elimina una clasificacion de colaborador
        ''' </summary>
        ''' <param name="pvi_id_Usuario"></param>
        ''' <param name="pvs_RutColaborador"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_EliminarClasificacionColaborador(ByVal pvi_id_Usuario As Integer,
                                                             ByVal pvs_RutColaborador As String) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.eliminacion
            Dim vls_NombreFuncionMetodo As String = "fgo_EliminarClasificacionColaborador"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_d_ClasificacionColaborador", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", pvi_id_Usuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@RutColaborador", pvs_RutColaborador)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery()
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

    End Class

End Namespace
