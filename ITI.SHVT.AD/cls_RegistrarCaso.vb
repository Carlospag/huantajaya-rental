Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient

Namespace AD_REGISTRARCASO

#Region "METODOS Y FUNCIONES"
    Public Class cls_RegistrarCaso
        Public Function fgo_RegistrarCaso(ByVal pvi_TipoCaso As Integer,
                                          ByVal pvi_idUsuario As Integer,
                                          ByVal pvi_TipoCausa As Integer,
                                          ByVal pvs_RutColaborador As String,
                                          ByVal pvd_FechaCaso As Date,
                                          ByVal pvi_TurnoCaso As Integer,
                                          ByVal pvs_MotivoCaso As String,
                                          ByVal pvd_FechaRegistroCaso As Date,
                                          ByVal pvi_EstadoCaso As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarCaso"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_id_Usuario As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_i_Caso", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_TipoCaso", pvi_TipoCaso)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_TipoCausa", pvi_TipoCausa)
                    vlo_sqlCommand.Parameters.AddWithValue("@RutColaborador", pvs_RutColaborador)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaCaso", pvd_FechaCaso)
                    vlo_sqlCommand.Parameters.AddWithValue("@TurnoCaso", pvi_TurnoCaso)
                    vlo_sqlCommand.Parameters.AddWithValue("@MotivoCaso", pvs_MotivoCaso)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaRegistroCaso", pvd_FechaRegistroCaso)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoCaso", pvi_EstadoCaso)
                    vlo_SqlConnection.Open()
                    Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    If dataReader.Read() Then
                        vli_id_Usuario = dataReader("id_Caso")
                    End If

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , vli_id_Usuario)
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
                Using vlo_sqlCommand As New SqlCommand("up_shvt_s_Causas", vlo_SqlConnection)
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

    
#End Region

End Namespace

