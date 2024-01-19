Imports System.Data.SqlClient
Imports ITI.SHVT.SERV.mdl_Variables

Namespace AD_REGISTRARCLIENTE

    Public Class cls_RegistrarCliente

        ''' <summary>
        ''' Regristrar un cliente (Empresa)
        ''' </summary>
        ''' <param name="pvs_RutCliente"></param>
        ''' <param name="pvi_Ciudad"></param>
        ''' <param name="pvs_NombreCliente"></param>
        ''' <param name="pvs_NombreRepresentante"></param>
        ''' <param name="pvi_TelUno"></param>
        ''' <param name="pvi_TelDos"></param>
        ''' <param name="pvs_CorreoUno"></param>
        ''' <param name="pvs_CorreoDos"></param>
        ''' <param name="pvs_Observaciones"></param>
        ''' <param name="pvi_EstadoCliente"></param>
        ''' <param name="pvd_FechaRegistro"></param>
        ''' <param name="pvi_idUsuario"></param>
        ''' <returns>Retorna si el SP se ejecuto con éxito</returns>
        ''' <remarks>Mario Sebastián Guerra Hernández</remarks>
        Public Function fgo_RegistrarCliente(ByVal pvs_RutCliente As String,
                                             ByVal pvi_Ciudad As Integer,
                                             ByVal pvs_NombreCliente As String,
                                             ByVal pvs_NombreRepresentante As String,
                                             ByVal pvi_TelUno As Integer,
                                             ByVal pvi_TelDos As Integer,
                                             ByVal pvs_CorreoUno As String,
                                             ByVal pvs_CorreoDos As String,
                                             ByVal pvs_Observaciones As String,
                                             ByVal pvi_EstadoCliente As Integer,
                                             ByVal pvd_FechaRegistro As Date,
                                             ByVal pvi_idUsuario As Integer,
                                             ByVal pvs_Direccion As String,
                                             ByVal pvs_NombreRepresentanteFinanzas As String,
                                             ByVal pvs_CargoContacto As String,
                                             ByVal pvs_CargoFinanzas As String) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarCliente"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Cliente", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@RutCliente", pvs_RutCliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@idCiudad", pvi_Ciudad)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreCliente", pvs_NombreCliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreRepresentante", pvs_NombreRepresentante)
                    vlo_sqlCommand.Parameters.AddWithValue("@TelUno", pvi_TelUno)
                    vlo_sqlCommand.Parameters.AddWithValue("@TelDos", pvi_TelDos)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoUno", pvs_CorreoUno)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoDos", pvs_CorreoDos)
                    vlo_sqlCommand.Parameters.AddWithValue("@Observaciones", pvs_Observaciones)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoCliente", pvi_EstadoCliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaRegistro", pvd_FechaRegistro)
                    vlo_sqlCommand.Parameters.AddWithValue("@idUsuario", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Direccion", pvs_Direccion)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreRepresentanteFinanzas", pvs_NombreRepresentanteFinanzas)
                    vlo_sqlCommand.Parameters.AddWithValue("@CargoContacto", pvs_CargoContacto)
                    vlo_sqlCommand.Parameters.AddWithValue("@CargoFinanzas", pvs_CargoFinanzas)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    'Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    'If dataReader.Read() Then
                    'vli_id_Usuario = dataReader("idUsuario")
                    'End If

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function





        Public Function fgo_ActualizarCliente(ByVal pvs_RutCliente As String,
                                             ByVal pvi_Ciudad As Integer,
                                             ByVal pvs_NombreCliente As String,
                                             ByVal pvs_NombreRepresentante As String,
                                             ByVal pvi_TelUno As Integer,
                                             ByVal pvi_TelDos As Integer,
                                             ByVal pvs_CorreoUno As String,
                                             ByVal pvs_CorreoDos As String,
                                             ByVal pvs_Observaciones As String,
                                             ByVal pvi_EstadoCliente As Integer,
                                             ByVal pvd_FechaRegistro As Date,
                                             ByVal pvi_idUsuario As Integer,
                                             ByVal pvs_Direccion As String,
                                             ByVal pvs_NombreRepresentanteFinanzas As String,
                                             ByVal pvs_CargoContacto As String,
                                             ByVal pvs_CargoFinanzas As String) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarCliente"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_Cliente", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@RutCliente", pvs_RutCliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@idCiudad", pvi_Ciudad)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreCliente", pvs_NombreCliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreRepresentante", pvs_NombreRepresentante)
                    vlo_sqlCommand.Parameters.AddWithValue("@TelUno", pvi_TelUno)
                    vlo_sqlCommand.Parameters.AddWithValue("@TelDos", pvi_TelDos)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoUno", pvs_CorreoUno)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoDos", pvs_CorreoDos)
                    vlo_sqlCommand.Parameters.AddWithValue("@Observaciones", pvs_Observaciones)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoCliente", pvi_EstadoCliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaRegistro", pvd_FechaRegistro)
                    vlo_sqlCommand.Parameters.AddWithValue("@idUsuario", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Direccion", pvs_Direccion)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreRepresentanteFinanzas", pvs_NombreRepresentanteFinanzas)
                    vlo_sqlCommand.Parameters.AddWithValue("@CargoContacto", pvs_CargoContacto)
                    vlo_sqlCommand.Parameters.AddWithValue("@CargoFinanzas", pvs_CargoFinanzas)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_BuscarCliente(ByVal pvs_RutCliente As String) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_BuscarCliente"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_s_BuscarRutCliente", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@RutCliente", pvs_RutCliente)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

    End Class
End Namespace
