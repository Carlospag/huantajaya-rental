Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient
Imports System.Net.Mime.MediaTypeNames

Namespace AD_ADMINISTRARCASO
    Public Class cls_AdministrarCaso
#Region "MÉTODOS Y FUNCIONES"

        Public Function fgo_BuscarCaso(ByVal pvi_id_Caso As Integer) As Collection
            Dim vls_Novedad As String = ""
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_BuscarCaso"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_s_SoloCaso", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Caso", pvi_id_Caso)
                    vlo_SqlConnection.Open()
                    Dim dataReader As SqlDataReader = vlo_sqlCommand.ExecuteReader()
                    If dataReader.Read() Then
                        vls_Novedad = dataReader("id_Caso").ToString + ".-." _
                                    + dataReader("TipoCaso").ToString + ".-." _
                                    + dataReader("NombreJefatura").ToString + ".-." _
                                    + dataReader("NombreCausa").ToString + ".-." _
                                    + dataReader("RutColaborador").ToString + ".-." _
                                    + dataReader("NombreColaborador").ToString + ".-." _
                                    + dataReader("FechaCaso").ToString + ".-." _
                                    + dataReader("TurnoCaso").ToString + ".-." _
                                    + dataReader("MotivoCaso").ToString + ".-." _
                                    + dataReader("FechaRegistroCaso").ToString + ".-." _
                                    + dataReader("FechaGeneracionCarta").ToString + ".-." _
                                    + dataReader("FolioInspeccionTrabajo").ToString + ".-." _
                                    + dataReader("EstadoCaso").ToString + ".-." _
                                    + dataReader("id_TipoCaso").ToString + ".-." _
                                    + dataReader("id_TipoCausa").ToString + ".-."



                    End If
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , vls_Novedad)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarCaso(ByVal pvi_idCaso As Integer) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarCaso"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_u_FechaRegistroCarta", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Caso", pvi_idCaso)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgb_ActualizarIdTipoCaso(ByVal pvs_RutColaborador As String,
                                                 ByVal pvi_idTipoCaso As Integer,
                                                 ByVal pvs_id_TipoCausa As String,
                                                 ByVal pvd_FechaCaso As Date,
                                                 ByVal pvi_id_Caso As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgb_ActualizarIdTipoCaso"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim valor As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_u_idTipoCaso", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@RutColaborador", pvs_RutColaborador)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_TipoCaso", pvi_idTipoCaso)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_TipoCausa", pvs_id_TipoCausa)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaCasoActual", pvd_FechaCaso)
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Caso", pvi_id_Caso)
                    vlo_SqlConnection.Open()
                    valor = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , valor)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_InsertarDocumentos(ByVal pvi_id_Caso As Integer,
                                               ByVal pvs_NombreDocumento As String,
                                               ByVal pvs_ContentType As Byte,
                                               ByVal pvs_Data As Image) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_InsertarDocumentos"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vlo_Transaccion As SqlTransaction
            'Dim vlo_SqlCommand As SqlCommand
            Dim vli_NroFilasAfectadas As Integer

            'Inicio de captura de errores
            Try
                Using vlo_SqlCommand As New SqlCommand("up_shvt_i_documentos", vlo_SqlConnection)
                    With vlo_SqlCommand
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.AddWithValue("@id_Caso", pvi_id_Caso)
                        .Parameters.AddWithValue("@NombreDocumento", pvs_NombreDocumento)
                        .Parameters.AddWithValue("@ContentType", pvs_ContentType)
                        .Parameters.AddWithValue("@Data", pvs_Data)
                    End With
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_SqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()
                End Using

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
                'vlo_Transaccion.Rollback()
            Finally
                'Cierre de conexión
                If Not vlo_SqlConnection Is Nothing Then
                    vlo_SqlConnection.Close()
                End If

            End Try

        End Function

        Public Function fgo_AjusteParametro(ByVal Valor As Integer) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_AjusteParametro"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_u_Parametro", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@ValorParametro", Valor)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_AdjuntarDocumento(ByVal pvi_id_Caso As Integer,
                                                      ByVal pvs_NombreArchivoLimpio As String,
                                                      ByVal pvs_NombreArchivoCompleto As String) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_AdjuntarArchivo"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_i_AdjuntarDocumento", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Caso", pvi_id_Caso)
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

        ''' <summary>
        ''' Elimina un documento asociado según su id
        ''' </summary>
        ''' <param name="pvi_id_Documento"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function fgo_EliminarDocumento(ByVal pvi_id_Documento As Integer) As Collection
            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.eliminacion
            Dim vls_NombreFuncionMetodo As String = "fgo_EliminarDocumento"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_d_Documento", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Documento", pvi_id_Documento)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarModal(ByVal pvi_idCaso As Integer,
                                            ByVal pvs_nroFolio As String,
                                            ByVal pvi_EstadoCaso As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarModal"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim valor As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_u_InfoModal", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_Caso", pvi_idCaso)
                    vlo_sqlCommand.Parameters.AddWithValue("@Nro_Folio", pvs_nroFolio)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoCaso", pvi_EstadoCaso)
                    vlo_SqlConnection.Open()
                    valor = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , valor)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarTipoCaso(ByVal pvi_TipoCaso As Integer,
                                            ByVal Desde As Date,
                                            ByVal Hasta As Date) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarTipoCaso"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim valor As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_shvt_u_ActualizarTipoCaso", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_TipoCaso", pvi_TipoCaso)
                    vlo_sqlCommand.Parameters.AddWithValue("@Desde", Desde)
                    vlo_sqlCommand.Parameters.AddWithValue("@Hasta", Hasta)
                    vlo_SqlConnection.Open()
                    valor = vlo_sqlCommand.ExecuteScalar
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , valor)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function


#End Region
    End Class
End Namespace

