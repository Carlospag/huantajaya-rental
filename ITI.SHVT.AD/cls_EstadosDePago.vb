Imports ITI.SHVT.SERV.mdl_Variables
Imports System.Data.SqlClient

Namespace AD_ESTADOSDEPAGO
    Public Class cls_EstadosDePago


        Public Function fgo_RegistrarEstadoDePago(ByVal pvi_EstadoComercial As Integer,
                                            ByVal pvi_CorrelativoEP As Integer,
                                            ByVal pvd_FechaInicioEP As Date,
                                            ByVal pvd_FechaFinEP As Date,
                                            ByVal pvi_Contrato As Integer,
                                            ByVal pvi_TipoUnidad As Integer,
                                            ByVal pvi_Tarifa As Integer,
                                            ByVal pvi_DiasFacturar As Integer,
                                            ByVal pvi_ValorNeto As Integer,
                                            ByVal pvi_HorasFacturar As Integer,
                                            ByVal pvs_Observaciones As String,
                                            ByVal pvi_idUsuario As Integer,
                                            ByVal pvi_TipoEstadoPago As Integer,
                                            ByVal pvi_AFI As Integer,
                                            ByVal pvs_Cliente As String,
                                            ByVal pvi_Sucursal As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarEstadoDePago"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vli_id_Usuario As Integer
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_EstadoDePago", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoComercialEP", pvi_EstadoComercial)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorrelativoEP", pvi_CorrelativoEP)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaInicioEP", pvd_FechaInicioEP)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaFinEP", pvd_FechaFinEP)
                    vlo_sqlCommand.Parameters.AddWithValue("@idContratoEP", pvi_Contrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoUnidadEP", pvi_TipoUnidad)
                    vlo_sqlCommand.Parameters.AddWithValue("@TarifaEP", pvi_Tarifa)
                    vlo_sqlCommand.Parameters.AddWithValue("@DiasFacturarEP", pvi_DiasFacturar)
                    vlo_sqlCommand.Parameters.AddWithValue("@ValorNetoEP", pvi_ValorNeto)
                    vlo_sqlCommand.Parameters.AddWithValue("@HorasFacturarEP", pvi_HorasFacturar)
                    vlo_sqlCommand.Parameters.AddWithValue("@ObservacionesEP", pvs_Observaciones)
                    vlo_sqlCommand.Parameters.AddWithValue("@idUsuarioEP", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoEstadoPago", pvi_TipoEstadoPago)
                    vlo_sqlCommand.Parameters.AddWithValue("@AfiVentaCobro", pvi_AFI)
                    vlo_sqlCommand.Parameters.AddWithValue("@ClienteVentaCobro", pvs_Cliente)
                    vlo_sqlCommand.Parameters.AddWithValue("@Sucursal", pvi_Sucursal)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarEstadoDePago(ByVal pvi_idEstadoPago As Integer,
                                                   ByVal pvi_EstadoComercial As Integer,
                                                   ByVal pvi_CorrelativoEP As Integer,
                                                   ByVal pvd_FechaInicioEP As Date,
                                                   ByVal pvd_FechaFinEP As Date,
                                                   ByVal pvi_Contrato As Integer,
                                                   ByVal pvi_TipoUnidad As Integer,
                                                   ByVal pvi_Tarifa As Integer,
                                                   ByVal pvi_DiasFacturar As Integer,
                                                   ByVal pvi_ValorNeto As Integer,
                                                   ByVal pvi_HorasFacturar As Integer,
                                                   ByVal pvs_Observaciones As String,
                                                   ByVal pvi_idUsuario As Integer,
                                                   ByVal pvi_TipoEPago As Integer,
                                                   ByVal pvi_AfiVentaCobro As Integer,
                                                   ByVal pvi_Sucursal As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarEstadoDePago"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_EstadoDePago", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@idEstadoPago", pvi_idEstadoPago)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoComercialEP", pvi_EstadoComercial)
                    vlo_sqlCommand.Parameters.AddWithValue("@CorrelativoEP", pvi_CorrelativoEP)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaInicioEP", pvd_FechaInicioEP)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaFinEP", pvd_FechaFinEP)
                    vlo_sqlCommand.Parameters.AddWithValue("@idContratoEP", pvi_Contrato)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoUnidadEP", pvi_TipoUnidad)
                    vlo_sqlCommand.Parameters.AddWithValue("@TarifaEP", pvi_Tarifa)
                    vlo_sqlCommand.Parameters.AddWithValue("@DiasFacturarEP", pvi_DiasFacturar)
                    vlo_sqlCommand.Parameters.AddWithValue("@ValorNetoEP", pvi_ValorNeto)
                    vlo_sqlCommand.Parameters.AddWithValue("@HorasFacturarEP", pvi_HorasFacturar)
                    vlo_sqlCommand.Parameters.AddWithValue("@ObservacionesEP", pvs_Observaciones)
                    vlo_sqlCommand.Parameters.AddWithValue("@idUsuarioEP", pvi_idUsuario)
                    vlo_sqlCommand.Parameters.AddWithValue("@TipoEP", pvi_TipoEPago)
                    vlo_sqlCommand.Parameters.AddWithValue("@AfiVentaCobro", pvi_AfiVentaCobro)
                    vlo_sqlCommand.Parameters.AddWithValue("@Sucursal", pvi_Sucursal)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarNumeroFactura(ByVal pvi_idEstadoPago As Integer,
                                                   ByVal pvi_NumeroFactura As Integer,
                                                   ByVal pvd_FechaFacturacion As Date, ByVal pvi_SucursalFactura As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarNumeroFactura"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_EstadoDePagoNumeroFactura", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@idEstadoPago", pvi_idEstadoPago)
                    vlo_sqlCommand.Parameters.AddWithValue("@NumeroFactura", pvi_NumeroFactura)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaFacturacion", pvd_FechaFacturacion)
                    vlo_sqlCommand.Parameters.AddWithValue("@SucursalFactura", pvi_SucursalFactura)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarPagoFactura(ByVal pvi_idEstadoPago As Integer, ByVal FechaPago As Date) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarNumeroFactura"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_EstadoDePagoPagoFactura", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@idEstadoPago", pvi_idEstadoPago)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaPago", FechaPago)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarAbonoFactura(ByVal pvi_idEstadoPago As Integer, ByVal ValorAbono As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarAbonoFactura"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_i_Abono", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@id_EstadoDePago", pvi_idEstadoPago)
                    vlo_sqlCommand.Parameters.AddWithValue("@ValorAbono", ValorAbono)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ActualizarPagoFacturaTodos(ByVal NumeroFactura As Integer, ByVal FechaPagoTodos As Date) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarPagoFacturaTodos"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_EstadoDePagoPagoFacturaTodos", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@NumeroFactura", NumeroFactura)
                    vlo_sqlCommand.Parameters.AddWithValue("@FechaPagoTodos", FechaPagoTodos)
                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ConfirmarAnularEP(ByVal pvi_idEstadoPago As Integer,
                                        ByVal pvi_EstadoComercial As Integer) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
            Dim vls_NombreFuncionMetodo As String = "fgo_ConfirmarAnularEP"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer

            Try
                Using vlo_sqlCommand As New SqlCommand("up_parque_u_ConfirmarAnularEP", vlo_SqlConnection)
                    'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                    vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                    'se agregan los parámetros que utiliza el SP
                    vlo_sqlCommand.Parameters.AddWithValue("@idEstadoPago", pvi_idEstadoPago)
                    vlo_sqlCommand.Parameters.AddWithValue("@EstadoComercial", pvi_EstadoComercial)

                    vlo_SqlConnection.Open()
                    vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                    vlo_SqlConnection.Close()

                    Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
            End Try
        End Function

        Public Function fgo_ListadoEstadosDePago(ByVal dt_EstadosDePago As DataTable) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_ListaEstadosDePago"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vli_NroFilasAfectadas As Integer
            Dim dataSet As New DataSet()
            Dim tabla As New DataTable

            'Inicio de captura de errores
            Try

                Using vlo_SqlCommand As New SqlCommand("up_parque_s_EstadosPagoXAgrupacion", vlo_SqlConnection)
                    With vlo_SqlCommand
                        .CommandType = CommandType.StoredProcedure
                    End With
                    Dim vlo_SqlParameter = vlo_SqlCommand.Parameters.AddWithValue("@List", dt_EstadosDePago)
                    vlo_SqlParameter.SqlDbType = SqlDbType.Structured
                    vlo_SqlParameter.TypeName = "dbo.IDList"

                    Using dataAdapter As New SqlDataAdapter(vlo_SqlCommand)
                        dataAdapter.Fill(dataSet)
                        tabla = dataSet.Tables(0)
                    End Using

                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
                'vlo_Transaccion.Rollback()
            Finally
                'Cierre de conexión
                If Not vlo_SqlConnection Is Nothing Then
                    vlo_SqlConnection.Close()
                End If

            End Try

            For Each row As DataRow In tabla.Rows
                For Each item In row.ItemArray
                    Debug.Print(item)
                Next
            Next

            Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, dataSet)
        End Function

        Public Function fgo_ListadoFacturacionAgrupado(ByVal dt_EstadosDePago As DataTable) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.seleccion
            Dim vls_NombreFuncionMetodo As String = "fgo_ListadoFacturacionAgrupado"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim dataSet As New DataSet()
            Dim tabla As New DataTable

            'Inicio de captura de errores
            Try

                Using vlo_SqlCommand As New SqlCommand("up_parque_s_FacturacionXAgrupacionn", vlo_SqlConnection)
                    With vlo_SqlCommand
                        .CommandType = CommandType.StoredProcedure
                    End With
                    Dim vlo_SqlParameter = vlo_SqlCommand.Parameters.AddWithValue("@List", dt_EstadosDePago)
                    vlo_SqlParameter.SqlDbType = SqlDbType.Structured
                    vlo_SqlParameter.TypeName = "dbo.IDDList"

                    Using dataAdapter As New SqlDataAdapter(vlo_SqlCommand)
                        dataAdapter.Fill(dataSet)
                        tabla = dataSet.Tables(0)
                    End Using

                End Using
            Catch ex As Exception
                Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
                'vlo_Transaccion.Rollback()
            Finally
                'Cierre de conexión
                If Not vlo_SqlConnection Is Nothing Then
                    vlo_SqlConnection.Close()
                End If

            End Try

            For Each row As DataRow In tabla.Rows
                For Each item In row.ItemArray
                    Debug.Print(item)
                Next
            Next

            Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, dataSet)
        End Function
    End Class
End Namespace

