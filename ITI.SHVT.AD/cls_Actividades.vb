Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient

Namespace AD_ACTIVIDADES

    Public Class cls_Actividades
        Public Function fgo_RegistrarActividad(ByVal pvs_NombreActividad As String,
                                            ByVal pviCantidadActividad As Integer,
                                            ByVal pvi_Implementacion As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarActividad"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Actividad", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreActividad", pvs_NombreActividad)
                    vlo_sqlCommand.Parameters.AddWithValue("@CantidadActividad", pviCantidadActividad)
                    vlo_sqlCommand.Parameters.AddWithValue("@Implementacion", pvi_Implementacion)

                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function


        Public Function fgo_ModificarActividad(ByVal pvi_idActiviad As Integer,
                                             ByVal pvs_NombreActividad As String,
                                             ByVal pvi_EstadoActividad As Integer,
                                             ByVal pvi_Cantidad As Integer,
                                             ByVal pvi_Implementacion As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ModificarActividad"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_Actividad", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Actividad", pvi_idActiviad)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreActividad", pvs_NombreActividad)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoActividad", pvi_EstadoActividad)
                    vlo_sqlCommand.Parameters.AddWithValue("@CantidadActividad", pvi_Cantidad)
                    vlo_sqlCommand.Parameters.AddWithValue("@Implementacion", pvi_Implementacion)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ClasificarActividad(ByVal pvi_idFamilia As Integer,
                                                ByVal pvi_idActividad As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_ClasificarActividad"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_ClasificarActividad", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Familia", pvi_idFamilia)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Actividad", pvi_idActividad)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery()
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_EliminarClasificacionActividad(ByVal pvi_idFamilia As Integer,
                                                           ByVal pvi_idActividad As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.eliminacion
            Dim vls_NombreFuncionMetodo As String = "fgo_EliminarClasificacionActividad"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_d_ClasificacionActividad", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Familia", pvi_idFamilia)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Actividad", pvi_idActividad)
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
