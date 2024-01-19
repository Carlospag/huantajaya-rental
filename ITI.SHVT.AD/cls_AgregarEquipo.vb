Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient

Namespace AD_REGISTRAREQUIPO

    Public Class cls_AgregarEquipo

        Public Function fgo_RegistrarEquipo(ByVal pvi_Afi As Integer,
                                            ByVal pvs_NumeroSerie As String,
                                            ByVal pvs_NombreEquipo As String,
                                            ByVal pvi_ValorCompra As Integer,
                                            ByVal pvs_MarcaEquipo As String,
                                            ByVal pvs_ModeloEquipo As String,
                                            ByVal pvs_Color As String,
                                            ByVal pvs_Patente As String,
                                            ByVal pvd_FechaAdquisicion As Date,
                                            ByVal pvi_Familia As Integer,
                                            ByVal pvi_Sucursal As Integer,
                                            ByVal pvi_EstadoEquipo As Integer,
                                            ByVal pvi_idUsuario As Integer,
                                            ByVal pvi_Horometro As Integer,
                                            ByVal pvs_Procedencia As String,
                                            ByVal pvi_AnhoEquipo As Integer,
                                            ByVal pvi_LargoEquipo As Integer,
                                            ByRef pvi_AltoEquipo As Integer,
                                            ByVal pvi_AnchoEquipo As Integer,
                                            ByVal pvi_PesoEquipo As Integer,
                                            ByRef pvs_AccionamientoEquipo As String,
                                            ByRef pvs_Dato1Equipo As String,
                                            ByRef pvs_Dato2Equipo As String
                                            ) As Collection


            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarEquipo"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Equipo", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@Afi", pvi_Afi)
                    vlo_sqlCommand.Parameters.AddWithValue("@NumeroSerie", pvs_NumeroSerie)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreEquipo", pvs_NombreEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@ValorCompra", pvi_ValorCompra)
                    vlo_sqlCommand.Parameters.AddWithValue("@MarcaEquipo", pvs_MarcaEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@ModeloEquipo", pvs_ModeloEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@Color", pvs_Color)
                    vlo_sqlCommand.Parameters.AddWithValue("@Patente", pvs_Patente)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaAdquisicion", pvd_FechaAdquisicion)
                    vlo_sqlCommand.Parameters.AddWithValue("@Familia", pvi_Familia)
                    vlo_sqlCommand.Parameters.AddWithValue("@Sucursal", pvi_Sucursal)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoEquipo", pvi_EstadoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@idUsuario", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Horometro", pvi_Horometro)
                    vlo_sqlCommand.Parameters.AddWithValue("@Procedencia", pvs_Procedencia)
                    vlo_sqlCommand.Parameters.AddWithValue("@AnhoEquipo", pvi_AnhoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@LargoEquipo", pvi_LargoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@AltoEquipo", pvi_AltoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@AnchoEquipo", pvi_AnchoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@PesoEquipo", pvi_PesoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@AccionamientoEquipo", pvs_AccionamientoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@Dato1Equipo", pvs_Dato1Equipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@Dato2Equipo", pvs_Dato2Equipo)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
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


        Public Function fgo_BuscarAfi(ByVal pvi_Afi As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_BuscarAfi"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_s_BuscarAfi", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@Afi", pvi_Afi)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarEquipo(ByVal pvi_Afi As Integer,
                                             ByVal pvs_NumeroSerie As String,
                                             ByVal pvs_NombreEquipo As String,
                                             ByVal pvi_ValorCompra As Integer,
                                             ByVal pvs_MarcaEquipo As String,
                                             ByVal pvs_ModeloEquipo As String,
                                             ByVal pvs_Color As String,
                                             ByVal pvs_Patente As String,
                                             ByVal pvd_FechaAdquisicion As Date,
                                             ByVal pvi_Familia As Integer,
                                             ByVal pvi_Sucursal As Integer,
                                             ByVal pvi_EstadoEquipo As Integer,
                                             ByVal pvi_idUsuario As Integer,
                                             ByVal pvi_Horometro As Integer,
                                             ByVal pvs_Procedencia As String,
                                             ByVal pvi_AnhoEquipo As Integer,
                                             ByVal pvi_LargoEquipo As Integer,
                                             ByVal pvi_AltoEquipo As Integer,
                                             ByVal pvi_AnchoEquipo As Integer,
                                             ByVal pvi_PesoEquipo As Integer,
                                             ByRef pvs_AccionamientoEquipo As String,
                                             ByRef pvs_Dato1Equipo As String,
                                             ByRef pvs_Dato2Equipo As String) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarEquipo"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_Equipo", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@Afi", pvi_Afi)
                    vlo_sqlCommand.Parameters.AddWithValue("@NumeroSerie", pvs_NumeroSerie)
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreEquipo", pvs_NombreEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@ValorCompra", pvi_ValorCompra)
                    vlo_sqlCommand.Parameters.AddWithValue("@MarcaEquipo", pvs_MarcaEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@ModeloEquipo", pvs_ModeloEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@Color", pvs_Color)
                    vlo_sqlCommand.Parameters.AddWithValue("@Patente", pvs_Patente)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaAdquisicion", pvd_FechaAdquisicion)
                    vlo_sqlCommand.Parameters.AddWithValue("@Familia", pvi_Familia)
                    vlo_sqlCommand.Parameters.AddWithValue("@Sucursal", pvi_Sucursal)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoEquipo", pvi_EstadoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@idUsuario", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@Horometro", pvi_Horometro)
                    vlo_sqlCommand.Parameters.AddWithValue("@Procedencia", pvs_Procedencia)
                    vlo_sqlCommand.Parameters.AddWithValue("@AnhoEquipo", pvi_AnhoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@LargoEquipo", pvi_LargoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@AltoEquipo", pvi_AltoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@AnchoEquipo", pvi_AnchoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@PesoEquipo", pvi_PesoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@AccionamientoEquipo", pvs_AccionamientoEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@Dato1Equipo", pvs_Dato1Equipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@Dato2Equipo", pvs_Dato2Equipo)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarHorometro(ByVal pvi_Afi As Integer,
                                                ByVal pvd_FechaActualizacion As Date,
                                                ByVal pvi_Horometro As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarHorometro"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_Horometro", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@Afi", pvi_Afi)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaActualizacion", pvd_FechaActualizacion)
                    vlo_sqlCommand.Parameters.AddWithValue("@Horometro", pvi_Horometro)
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