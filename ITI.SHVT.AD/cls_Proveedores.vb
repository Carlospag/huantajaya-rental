Imports System.Data.SqlClient
Imports ITI.SHVT.SERV.mdl_Variables

Namespace AD_PROVEEDORES
    Public Class cls_Proveedores

        Public Function fgo_RegistrarProveedor(ByVal pvs_RutProveedor As String,
                                               ByVal pvs_NombreProveedor As String,
                                               ByVal pvs_GiroProveedor As String,
                                               ByVal pvs_DireccionProveedor As String,
                                               ByVal pvi_RegionProveedor As Integer,
                                               ByVal pvi_ComunaProveedor As Integer,
                                               ByVal pvs_TelefonoProveedor As String,
                                               ByVal pvs_CorreoProveedor As String,
                                               ByVal pvs_NombreContactoProveedor As String,
                                               ByVal pvs_TelefonoContactoProveedor As String,
                                               ByVal pvs_CorreoContactoProveedor As String,
                                               ByVal pvs_DireccionContactoProveedor As String,
                                               ByVal pvi_DocumentoDeCompra As Integer,
                                               ByVal pvi_MedioDePago As Integer,
                                               ByVal pvs_Servicios As String,
                                               ByVal pvi_EstadoProveedor As Integer,
                                               ByVal pvs_RutDestinatario As String,
                                               ByVal pvs_NombreDestinatario As String,
                                               ByVal pvi_idBanco As Integer,
                                               ByVal pvi_idTipoCuenta As Integer,
                                               ByVal pvs_NumeroCuenta As String) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarProveedor"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Proveedor", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Proveedor", pvs_RutProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreProveedor", pvs_NombreProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@GiroProveedor", pvs_GiroProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@DireccionProveedor", pvs_DireccionProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_RegionProveedor", pvi_RegionProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_ComunaProveedor", pvi_ComunaProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@TelefonoProveedor", pvs_TelefonoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoProveedor", pvs_CorreoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreContactoProveedor", pvs_NombreContactoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@TelefonoContactoProveedor", pvs_TelefonoContactoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoContactoProveedor", pvs_CorreoContactoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@DireccionContactoProveedor", pvs_DireccionContactoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_DocumentoCompra", pvi_DocumentoDeCompra)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_MedioDePago", pvi_MedioDePago)
                    vlo_sqlCommand.Parameters.AddWithValue("@ServiciosProveedor", pvs_Servicios)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoProveedor", pvi_EstadoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@RutDestinatario", pvs_RutDestinatario)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreDestinatario", pvs_NombreDestinatario)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Banco", pvi_idBanco)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_TipoCuenta", pvi_idTipoCuenta)
                    vlo_sqlCommand.Parameters.AddWithValue("@NumeroCuenta", pvs_NumeroCuenta)

                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarProveedor(ByVal pvs_RutProveedor As String,
                                               ByVal pvs_NombreProveedor As String,
                                               ByVal pvs_GiroProveedor As String,
                                               ByVal pvs_DireccionProveedor As String,
                                               ByVal pvi_RegionProveedor As Integer,
                                               ByVal pvi_ComunaProveedor As Integer,
                                               ByVal pvs_TelefonoProveedor As String,
                                               ByVal pvs_CorreoProveedor As String,
                                               ByVal pvs_NombreContactoProveedor As String,
                                               ByVal pvs_TelefonoContactoProveedor As String,
                                               ByVal pvs_CorreoContactoProveedor As String,
                                               ByVal pvs_DireccionContactoProveedor As String,
                                               ByVal pvi_DocumentoDeCompra As Integer,
                                               ByVal pvi_MedioDePago As Integer,
                                               ByVal pvs_Servicios As String,
                                               ByVal pvi_EstadoProveedor As Integer,
                                               ByVal pvs_RutDestinatario As String,
                                               ByVal pvs_NombreDestinatario As String,
                                               ByVal pvi_idBanco As Integer,
                                               ByVal pvi_idTipoCuenta As Integer,
                                               ByVal pvs_NumeroCuenta As String) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarProveedor"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_Proveedor", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Proveedor", pvs_RutProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreProveedor", pvs_NombreProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@GiroProveedor", pvs_GiroProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@DireccionProveedor", pvs_DireccionProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_RegionProveedor", pvi_RegionProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_ComunaProveedor", pvi_ComunaProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@TelefonoProveedor", pvs_TelefonoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoProveedor", pvs_CorreoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreContactoProveedor", pvs_NombreContactoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@TelefonoContactoProveedor", pvs_TelefonoContactoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorreoContactoProveedor", pvs_CorreoContactoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@DireccionContactoProveedor", pvs_DireccionContactoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_DocumentoCompra", pvi_DocumentoDeCompra)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_MedioDePago", pvi_MedioDePago)
                    vlo_sqlCommand.Parameters.AddWithValue("@ServiciosProveedor", pvs_Servicios)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoProveedor", pvi_EstadoProveedor)
                    vlo_sqlCommand.Parameters.AddWithValue("@RutDestinatario", pvs_RutDestinatario)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreDestinatario", pvs_NombreDestinatario)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Banco", pvi_idBanco)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_TipoCuenta", pvi_idTipoCuenta)
                    vlo_sqlCommand.Parameters.AddWithValue("@NumeroCuenta", pvs_NumeroCuenta)

                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function


        Public Function fgo_BuscarRutProveedor(ByVal pvs_RutProveedor As String) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_BuscarRutProveedor"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_s_BuscarRutProveedor", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@RutProveedor", pvs_RutProveedor)
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
