Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient

Namespace AD_MODIFICARUSUARIO

    
    Public Class cls_ModificarUsuario

#Region "METODOS Y FUNCIONES"
        ''' <summary>
        ''' Modificar/actualiza la información personal del usuario en cuestión
        ''' </summary>
        ''' <param name="pvi_id_Usuario"></param>
        ''' <param name="pvs_Usuario"></param>
        ''' <param name="pvi_EstadoUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_ModificarUsuario(ByVal pvs_idUsuario As Integer,
                                           ByVal pvsNombreUsuario As String,
                                           ByVal pvs_Apaterno As String,
                                           ByVal pvs_Amaterno As String,
                                           ByVal pvs_CorreoUsuario As String,
                                           ByVal pvs_Nombres As String,
                                           ByVal pvi_TipoCargo As Integer,
                                           ByVal pvi_EstadoUsuario As Integer,
                                           ByVal pvi_Telefono As Integer) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ModificarUsuario"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_Usuario", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@idUsuario", pvs_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreUsuario", pvsNombreUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@ApellidoPaternoUsuario", pvs_Apaterno)
                    vlo_sqlCommand.Parameters.AddWithValue("@ApellidoMaternoUsuario", pvs_Amaterno)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoUsuario", pvs_CorreoUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Nombres", pvs_Nombres)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoCargo", pvi_TipoCargo)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoUsuario", pvi_EstadoUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Telefono", pvi_Telefono)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_CambiarContrasena(ByVal pvs_idUsuario As Integer,
                                           ByVal pvs_Contrasena As String) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_CambiarContrasena"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_ContrasenaUsuario", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", pvs_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Contrasena", pvs_Contrasena)
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
        ''' Eliminación del las opciones del sistema del usuario, para luego agregar todas de nuevo.
        ''' </summary>
        ''' <param name="pvi_id_Usuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_EliminarOpcionesUsuario(ByVal pvi_id_Usuario As Integer) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.eliminacion
            Dim vls_NombreFuncionMetodo As String = "fgo_EliminarOpcionesUsuario"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_d_OpcionesUsuario", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", pvi_id_Usuario)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
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