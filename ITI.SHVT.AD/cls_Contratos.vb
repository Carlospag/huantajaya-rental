Imports System.Data.SqlClient
Imports ITI.SHVT.SERV.mdl_Variables
Namespace AD_CONTRATOS


    Public Class cls_Contratos



        Public Function fgo_RegistrarContrato(ByVal pvi_idUsuario As Integer,
                                              ByVal pvs_RutCliente As String,
                                              ByVal pvi_idEmpresa As Integer,
                                              ByVal pvd_FechaContrato As Date,
                                              ByVal pvs_FechaRegistroContrato As Date,
                                              ByVal pvi_EstadoContrato As Integer,
                                              ByVal pvi_Afi As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarContrato"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_idContrato As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Contrato", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    'vlo_sqlCommand.Parameters.AddWithValue("@idContrato", pvi_idContrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@idUsuario", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@RutCliente", pvs_RutCliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@idEmpresa", pvi_idEmpresa)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaContrato", pvd_FechaContrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaRegistroContrato", pvs_FechaRegistroContrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoContrato", pvi_EstadoContrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Equipo", pvi_Afi)

                    vlo_SqlConnection.Open()
                    'vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    If dataReader.Read() Then
                        vli_idContrato = dataReader("id_Contrato")
                    End If

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , vli_idContrato)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarContrato(ByVal pvi_idContrato As Integer,
                                               ByVal pvi_EstadoContrato As Integer) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarContrato"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_Contrato", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@idContrato", pvi_idContrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoContrato", pvi_EstadoContrato)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarFechaRecepcion(ByVal pvi_idContrato As Integer,
                                               ByVal pvd_FechaRecepcion As Date) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarContrato"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_FechaRecepcion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@idContrato", pvi_idContrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaRecepcion", pvd_FechaRecepcion)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function
        Public Function fgo_RegistrarDetalleContrato(ByVal pvi_idContrato As Integer,
                                                     ByVal pvi_idZona As Integer,
                                                     ByVal pvi_Afi As Integer,
                                                     ByVal pvi_ValorUnitario As Integer,
                                                     ByVal pvi_TipoUnidad As Integer,
                                                     ByVal pvs_Faena As String,
                                                     ByVal pvi_Guia As Integer,
                                                     ByVal pvi_idCotizacion As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarDetalleContrato"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_DetalleContrato", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@idContrato", pvi_idContrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@idZona", pvi_idZona)
                    vlo_sqlCommand.Parameters.AddWithValue("@Afi", pvi_Afi)
                    vlo_sqlCommand.Parameters.AddWithValue("@ValorUnitario", pvi_ValorUnitario)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoUnidad", pvi_TipoUnidad)
                    vlo_sqlCommand.Parameters.AddWithValue("@Faena", pvs_Faena)
                    vlo_sqlCommand.Parameters.AddWithValue("@Guia", pvi_Guia)
                    vlo_sqlCommand.Parameters.AddWithValue("@idCotizacion", pvi_idCotizacion)

                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_AdjuntarDocumentoContrato(ByVal pvi_idContrato As Integer,
                                                          ByVal pvs_NombreArchivoLimpio As String,
                                                          ByVal pvs_NombreArchivoCompleto As String) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_AdjuntarArchivo"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_AdjuntarDocumentoContrato", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Contrato", pvi_idContrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreDocumento", pvs_NombreArchivoLimpio)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreDoctoFisico", pvs_NombreArchivoCompleto)
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
End Namespace
