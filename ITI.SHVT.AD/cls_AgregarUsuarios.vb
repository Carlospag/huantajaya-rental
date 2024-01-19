Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient
Namespace AD_AGREGARUSUARIO
    Public Class cls_AgregarUsuarios

#Region "MÉTODOS Y FUNCIONES"

        ''' <summary>
        ''' Función en busca la existencia de un usuario en el sistema según su rut
        ''' </summary>
        ''' <param name="pvs_RutUsuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_BuscarRutUsuario(ByVal pvs_RutUsuario As String) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_BuscarRutUsuario"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_s_BuscarRutUsuario", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@RutUsuario", pvs_RutUsuario)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        ''' <summary>
        ''' Función que verifica la existencia de un usuario en el sistema
        ''' </summary>
        ''' <param name="pvs_Usuario"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_BuscarUsuario(ByVal pvs_Usuario As String) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_BuscarUsuario"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_s_BuscarUsuario", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreUsuario", pvs_Usuario)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function


        Public Function fgo_AgregarUsuario(ByVal pvs_RutUsuario As String,
                                           ByVal pvsNombreUsuario As String,
                                           ByVal pvs_Apaterno As String,
                                           ByVal pvs_Amaterno As String,
                                           ByVal pvs_CorreoUsuario As String,
                                           ByVal pvs_Nombres As String,
                                           ByVal pvi_TipoCargo As Integer,
                                           ByVal pvi_Telefono As Integer) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_AgregarUsuario"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_id_Usuario As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Usuario", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@RutUsuario", pvs_RutUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreUsuario", pvsNombreUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@ApellidoPaternoUsuario", pvs_Apaterno)
                    vlo_sqlCommand.Parameters.AddWithValue("@ApellidoMaternoUsuario", pvs_Amaterno)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoUsuario", pvs_CorreoUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Nombres", pvs_Nombres)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoCargo", pvi_TipoCargo)
                    vlo_sqlCommand.Parameters.AddWithValue("@Telefono", pvi_Telefono)
                    vlo_SqlConnection.Open()
                    Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    If dataReader.Read() Then
                        vli_id_Usuario = dataReader("id_Usuario")
                    End If

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , vli_id_Usuario)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_BuscarContrasena(ByVal pvi_idUsuario As Integer, ByVal pvs_Contrasena As String) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_BuscarContrasena"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_s_BuscarContrasena", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Contrasena", pvs_Contrasena)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        ''' <summary>
        ''' Función que agrega una opción de sistema a un usuario especifico
        ''' </summary>
        ''' <param name="pvi_id_Usuario"></param>
        ''' <param name="pvi_id_OpcionSistema"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_AgregarOpcionUsuario(ByVal pvi_id_Usuario As Integer,
                                                 ByVal pvi_id_OpcionSistema As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_AgregarOpcionUsuario"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_OpcionUsuario", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", pvi_id_Usuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_OpcionSistema", pvi_id_OpcionSistema)
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
