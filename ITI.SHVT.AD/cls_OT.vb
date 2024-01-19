Imports System.Data.SqlClient
Imports ITI.SHVT.SERV.mdl_Variables
Public Class cls_OT


    Public Function fgo_DatosTrabajador(ByVal id_Trabajador As Integer, ByVal Tiempo As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
        Dim vls_NombreFuncionMetodo As String = "fgo_DatosTrabajador"

        'Inicio de captura de errores
        Try
            Dim vlo_SqlDataAdapter As SqlDataAdapter
            Dim vlo_DataSet As New DataSet

            'Asignación de procedimiento almacenado a ejecutar
            vlo_SqlDataAdapter = New SqlDataAdapter("up_parque_s_TrabajadorPorID", pgs_ConnectionStringBDPrincipalSHVT)
            vlo_SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            'Asignación de parámetros
            With vlo_SqlDataAdapter.SelectCommand.Parameters
                .Add("@id_Trabajador", SqlDbType.Int).Value = id_Trabajador
                .Add("@Tiempo", SqlDbType.Int).Value = Tiempo
            End With
            'Ejecución de procedimiento almacenado
            vlo_SqlDataAdapter.Fill(vlo_DataSet)

            'Retorno función
            Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, vlo_DataSet)

        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_RegistrarOT(ByVal pvi_NumeroOT As Integer,
                                            ByVal pvi_AFI As Integer,
                                            ByVal pvi_Responsable As Integer,
                                            ByVal pvi_Supervisor As Integer,
                                            ByVal pvd_FechaOT As DateTime,
                                            ByVal pvi_IdTipoOT As Integer,
                                            ByVal pvi_idUsuario As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
        Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarOT"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_i_OT", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OT", pvi_NumeroOT)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Equipo", pvi_AFI)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Responsable", pvi_Responsable)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Supervisor", pvi_Supervisor)
                vlo_sqlCommand.Parameters.AddWithValue("@FechaOT", pvd_FechaOT)
                vlo_sqlCommand.Parameters.AddWithValue("@id_TipoOT", pvi_IdTipoOT)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", pvi_idUsuario)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_ActualizarOT(ByVal pvi_NumeroOT As Integer,
                                            ByVal pvi_AFI As Integer,
                                            ByVal pvi_Responsable As Integer,
                                            ByVal pvi_Supervisor As Integer,
                                            ByVal pvd_FechaOT As DateTime,
                                            ByVal pvi_IdTipoOT As Integer,
                                            ByVal pvi_CostoRepuesto As Integer,
                                            ByVal pvi_EstadoOT As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
        Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarOT"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_u_OT", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OT", pvi_NumeroOT)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Equipo", pvi_AFI)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Responsable", pvi_Responsable)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Supervisor", pvi_Supervisor)
                vlo_sqlCommand.Parameters.AddWithValue("@FechaOT", pvd_FechaOT)
                vlo_sqlCommand.Parameters.AddWithValue("@id_TipoOT", pvi_IdTipoOT)
                vlo_sqlCommand.Parameters.AddWithValue("@CostoRepuesto", pvi_CostoRepuesto)
                vlo_sqlCommand.Parameters.AddWithValue("@EstadoOT", pvi_EstadoOT)

                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_RegistrarActividadOT(ByVal pvi_NumeroOT As Integer,
                                            ByVal pvi_idActividad As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
        Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarActividadOT"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_i_ActividadXOT", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OT", pvi_NumeroOT)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Actividad", pvi_idActividad)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_EliminarActividadOT(ByVal pvi_NumeroOT As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.eliminacion
        Dim vls_NombreFuncionMetodo As String = "fgo_EliminarActividadOT"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_d_ActividadXOT", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OT", pvi_NumeroOT)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_EliminarTrabajadorOT(ByVal pvi_NumeroOT As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.eliminacion
        Dim vls_NombreFuncionMetodo As String = "fgo_EliminarTrabajadorOT"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_d_TrabajadorXOT", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OT", pvi_NumeroOT)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_ActualizarEstadoOT(ByVal pvi_NumeroOT As Integer,
                                           ByVal pvi_EstadoOT As Integer,
                                           ByVal pvs_Observacion As String) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
        Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarEstadoOT"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_U_EstadoOT", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OT", pvi_NumeroOT)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Estado", pvi_EstadoOT)
                vlo_sqlCommand.Parameters.AddWithValue("@Observacion", pvs_Observacion)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_RegistrarTrabajadorOT(ByVal pvi_NumeroOT As Integer,
                                              ByVal pvi_idTrabajador As Integer,
                                              ByVal pvi_Horas As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
        Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarTrabajadorOT"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_i_TrabajadorXOT", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OT", pvi_NumeroOT)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Trabajador", pvi_idTrabajador)
                vlo_sqlCommand.Parameters.AddWithValue("@Horas", pvi_Horas)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function
End Class
