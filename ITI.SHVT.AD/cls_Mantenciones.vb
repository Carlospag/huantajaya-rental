Imports System.Data.SqlClient
Imports ITI.SHVT.SERV.mdl_Variables
Namespace AD_MANTENCIONES


    Public Class cls_Mantenciones

#Region "CLASIFICACIÓN DE REPUESTOS, LUBRICANTES Y ACTIVIDADES"
        'REPUESTOS
        Public Function fgo_EliminarClasificacionRepuesto(ByVal pvi_idEquipo As Integer,
                                                           ByVal pvi_idRepuesto As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.eliminacion
            Dim vls_NombreFuncionMetodo As String = "fgo_EliminarClasificacionRepuesto"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_d_ClasificarRepuesto", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Equipo", pvi_idEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Repuesto", pvi_idRepuesto)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery()
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function
        Public Function fgo_ClasificarRepuesto(ByVal pvi_idEquipo As Integer,
                                              ByVal pvi_idRepuesto As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_ClasificarRepuesto"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_ClasificarRepuesto", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Equipo", pvi_idEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Repuesto", pvi_idRepuesto)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery()
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function
        'LUBRICANTES
        Public Function fgo_ClasificarLubricante(ByVal pvi_idFamilia As Integer,
                                               ByVal pvi_idLubricante As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_ClasificarActividad"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_ClasificarLubricante", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Familia", pvi_idFamilia)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Lubricante", pvi_idLubricante)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery()
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function
        Public Function fgo_EliminarLubricante(ByVal pvi_idFamilia As Integer,
                                                           ByVal pvi_idLubricante As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.eliminacion
            Dim vls_NombreFuncionMetodo As String = "fgo_EliminarLubricante"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_d_ClasificarLubricante", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Familia", pvi_idFamilia)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Lubricante", pvi_idLubricante)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery()
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function
        'ACTIVIDADES
        Public Function fgo_ClasificarActividad(ByVal pvi_idFamilia As Integer,
                                                ByVal pvi_idActividad As Integer) As Collection
            Dim vli_NroFilasAfectadas As Integer
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_ClasificarActividad"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_ClasificarActividadMantencion", vlo_SqlConnection)
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
                Using vlo_sqlCommand As New SqlCommand("up_parque_d_ClasificacionActividadMantencion", vlo_SqlConnection)
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
#End Region

#Region "REGISTRAR UNA MANTENCIÓN"
        'REGISTRAR LA MANTENCIÓN
        Public Function fgo_RegistrarMantencion(ByVal pvi_idEquipo As Integer,
                                             ByVal pvi_Horometro As Integer,
                                             ByVal pvd_FechaMantencion As Date,
                                             ByVal pvs_Observacion As String,
                                             ByVal pvi_idUsuario As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarMantencion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Mantencion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Equipo", pvi_idEquipo)
                    vlo_sqlCommand.Parameters.AddWithValue("@Horometro", pvi_Horometro)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaMantencion", pvd_FechaMantencion)
                    vlo_sqlCommand.Parameters.AddWithValue("@Observacion", pvs_Observacion)
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
        'ADJUNTAR DOCUMENTO
        Public Function fgo_AdjuntarDocumentoMantencion(ByVal pvi_idEquipo As Integer,
                                                              ByVal pvs_NombreArchivoLimpio As String,
                                                              ByVal pvs_NombreArchivoCompleto As String) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_AdjuntarDocumentoMantencion"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_AdjuntarDocumentoMantencion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_EquipoMantencion", pvi_idEquipo)
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
#End Region

#Region "MANTENEDOR DE MANTENCIONES (REGISTRO DE REPUESTOS, LUBRICANTES Y ACTIVIDADES)"
        Public Function fgo_RegistrarRepuesto(ByVal pvs_NombreRepuesto As String,
                                                     ByVal pvs_OriginalRepuesto As String,
                                                     ByVal pvs_AlternativoUnoRepuesto As String,
                                                     ByVal pvs_AlternativoDosRepuesto As String,
                                                     ByVal pvi_Cantidad As Integer,
                                                     ByVal pvi_PrecioRepuesto As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarRepuesto"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Repuesto", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreRepuesto", pvs_NombreRepuesto)
                    vlo_sqlCommand.Parameters.AddWithValue("@OriginalRepuesto", pvs_OriginalRepuesto)
                    vlo_sqlCommand.Parameters.AddWithValue("@AlternativoUnoRepuesto", pvs_AlternativoUnoRepuesto)
                    vlo_sqlCommand.Parameters.AddWithValue("@AlternativoDosRepuesto", pvs_AlternativoDosRepuesto)
                    vlo_sqlCommand.Parameters.AddWithValue("@CantidadRepuesto", pvi_Cantidad)
                    vlo_sqlCommand.Parameters.AddWithValue("@PrecioRepuesto", pvi_PrecioRepuesto)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_RegistrarLubricante(ByVal pvs_NombreLubricante As String,
                                              ByVal pvs_TipoLubricante As String,
                                              ByVal pvs_CantidadLubricante As String,
                                              ByVal pvi_PrecioLubricante As String) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarLubricante"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Lubricante", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreLubricante", pvs_NombreLubricante)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoLubricante", pvs_TipoLubricante)
                    vlo_sqlCommand.Parameters.AddWithValue("@CantidadLubricante", pvs_CantidadLubricante)
                    vlo_sqlCommand.Parameters.AddWithValue("@PrecioLubricante", pvi_PrecioLubricante)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery

                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_RegistrarActividad(ByVal pvs_NombreActividad As String) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarActividad"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_ActividadMantencion", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@NombreActividad", pvs_NombreActividad)
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
