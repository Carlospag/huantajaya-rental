Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient

Namespace AD_CAUSAS
    Public Class cls_Causas

        ''' <summary>
        ''' Agregar causales al sistema
        ''' </summary>
        ''' <param name="pvs_NombreCausa"></param>
        ''' <param name="pvs_DetalleCausa"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_AgregarCausas(ByVal pvs_NombreCausa As String,
                                                 ByVal pvs_DetalleCausa As String) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_AgregarCausas"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_i_Causas", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreCausa", pvs_NombreCausa)
                    vlo_sqlCommand.Parameters.AddWithValue("@DetalleCausa", pvs_DetalleCausa)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        ''' <summary>
        ''' Modificar causales
        ''' </summary>
        ''' <param name="pvi_idCausa"></param>
        ''' <param name="pvs_NombreCausa"></param>
        ''' <param name="pvs_DetalleCausa"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_ModificarCausas(ByVal pvi_idCausa As Integer,
                                            ByVal pvs_NombreCausa As String,
                                            ByVal pvs_DetalleCausa As String,
                                            ByVal pvi_EstadoCausa As Integer) As Collection

            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ModificarCausas"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_u_Causas", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_TipoCausa", pvi_idCausa)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreCausa", pvs_NombreCausa)
                    vlo_sqlCommand.Parameters.AddWithValue("@DetalleCausa", pvs_DetalleCausa)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoCausa", pvi_EstadoCausa)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_BuscarCausa(ByVal pvi_id_TipoCausa As Integer) As Collection
            Dim vls_Novedad As String = ""
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_BuscarCausa"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_s_CausasMantenedor", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_TipoCausa", pvi_id_TipoCausa)
                    vlo_SqlConnection.Open()
                    Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    If dataReader.Read() Then
                        vls_Novedad = dataReader("id_TipoCausa").ToString + ".-." _
                                    + dataReader("NombreCausa").ToString + ".-." _
                                    + dataReader("DetalleCausa").ToString + ".-." _
                                    + dataReader("EstadoCausa").ToString

                    End If
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , vls_Novedad)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

    End Class

End Namespace


