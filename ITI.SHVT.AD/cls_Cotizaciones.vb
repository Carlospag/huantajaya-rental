Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient
Namespace AD_COTIZACIONES
    Public Class cls_Cotizaciones


        Public Function fgo_GenerarCotizacion(ByVal pvi_idEquipo As Integer,
                                                   ByVal pvs_idCliente As String,
                                                   ByVal pvi_idTipoCotizacion As Integer,
                                                   ByVal pvi_Modalidad As Integer,
                                                   ByVal pvs_Contacto As String,
                                                   ByVal pvs_Faena As String,
                                                   ByVal pvs_Precio As Integer,
                                                   ByVal pvi_idVendedor As Integer,
                                                   ByVal pvi_idUsuario As Integer,
                                                   ByVal pvi_CantHoras As Integer,
                                                   ByVal pvs_TextoAlternativo As String,
                                                   ByVal pvi_idZona As Integer
                                                ) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_GenerarCotizacion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_id_Cotizacion As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Cotizacion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Equipo", pvi_idEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Cliente", pvs_idCliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoCotizacion", pvi_idTipoCotizacion)
                    vlo_sqlCommand.Parameters.AddWithValue("@Modalidad", pvi_Modalidad)
                    vlo_sqlCommand.Parameters.AddWithValue("@Contacto", pvs_Contacto)
                    vlo_sqlCommand.Parameters.AddWithValue("@Faena", pvs_Faena)
                    vlo_sqlCommand.Parameters.AddWithValue("@Precio", pvs_Precio)
                    vlo_sqlCommand.Parameters.AddWithValue("@Vendedor", pvi_idVendedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@Usuario", pvi_idUsuario)

                    vlo_sqlCommand.Parameters.AddWithValue("@CantHoras", pvi_CantHoras)
                    vlo_sqlCommand.Parameters.AddWithValue("@TextoAlternativo", pvs_TextoAlternativo)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Zona", pvi_idZona)
                    vlo_SqlConnection.Open()
                    Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    If dataReader.Read() Then
                        vli_id_Cotizacion = dataReader("id_Cotizacion")
                    End If

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , vli_id_Cotizacion)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function


        Public Function fgo_ActualizarCotizacion(ByVal pvi_idCotizacion As Integer,
                                                ByVal pvi_idEquipo As Integer,
                                                   ByVal pvs_idCliente As String,
                                                   ByVal pvi_idTipoCotizacion As Integer,
                                                   ByVal pvi_Modalidad As Integer,
                                                   ByVal pvs_Contacto As String,
                                                   ByVal pvs_Faena As String,
                                                   ByVal pvs_Precio As Integer,
                                                   ByVal pvi_idVendedor As Integer,
                                                   ByVal pvi_idUsuario As Integer,
                                                   ByVal pvi_EstadoCoti As Integer,
                                                   ByVal pvi_CantHoras As Integer,
                                                   ByVal pvs_TextoAlternativo As String,
                                                   ByVal pvi_idZona As Integer) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarCotizacion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_Cotizacion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Cotizacion", pvi_idCotizacion)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Equipo", pvi_idEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Cliente", pvs_idCliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoCotizacion", pvi_idTipoCotizacion)
                    vlo_sqlCommand.Parameters.AddWithValue("@Modalidad", pvi_Modalidad)
                    vlo_sqlCommand.Parameters.AddWithValue("@Contacto", pvs_Contacto)
                    vlo_sqlCommand.Parameters.AddWithValue("@Faena", pvs_Faena)
                    vlo_sqlCommand.Parameters.AddWithValue("@Precio", pvs_Precio)
                    vlo_sqlCommand.Parameters.AddWithValue("@Vendedor", pvi_idVendedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@Usuario", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoCoti", pvi_EstadoCoti)
                    vlo_sqlCommand.Parameters.AddWithValue("@CantHoras", pvi_CantHoras)
                    vlo_sqlCommand.Parameters.AddWithValue("@TextoAlternativo", pvs_TextoAlternativo)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Zona", pvi_idZona)
                    vlo_SqlConnection.Open()
                    Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarEstadoCotizacion(ByVal pvi_idCotizacion As Integer,
                                                   ByVal pvi_EstadoCoti As Integer) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarEstadoCotizacion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_EstadoCotizacion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Cotizacion", pvi_idCotizacion)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoCoti", pvi_EstadoCoti)
                    vlo_SqlConnection.Open()
                    Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_AgregarCondicion(ByVal pvi_idCotizacion As Integer,
                                             ByVal pvi_idCondicion As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_AgregarCondicion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_CondicionXCotizacion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Cotizacion", pvi_idCotizacion)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Condicion", pvi_idCondicion)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ValidarCotizacion(ByVal pvi_idCOti As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_ValidarCotizacion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_s_ValidarCotizacion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Cotizacion", pvi_idCOti)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function


        Public Function fgo_EliminarCondicion(ByVal pvi_idCotizacion As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_EliminarCondicion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_d_CondicionXCotizacion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Cotizacion", pvi_idCotizacion)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_AgregarImplementacion(ByVal pvi_idCotizacion As Integer,
                                                  ByVal pvi_idImplementacion As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_AgregarImplementacion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_ImplementacionXCotizacion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Cotizacion", pvi_idCotizacion)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Implementacion", pvi_idImplementacion)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_EliminarImplementacion(ByVal pvi_idCotizacion As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_EliminarImplementacion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_d_ImplementacionXCotizacion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Cotizacion", pvi_idCotizacion)
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


