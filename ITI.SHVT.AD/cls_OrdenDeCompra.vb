Imports System.Data.SqlClient
Imports ITI.SHVT.SERV.mdl_Variables
Public Class cls_OrdenDeCompra

    Public Function fgo_RegistrarOC(ByVal pvs_RutProveedor As String,
                                           ByVal pvi_dctoCompra As Integer,
                                           ByVal pvi_MedioPago As Integer,
                                           ByVal pvi_CCGeneral As Integer,
                                           ByVal pvi_CCEspecifico As Integer,
                                           ByVal pvd_Fecha As Date) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
        Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarOC"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_i_OC", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_Proveedor", pvs_RutProveedor)
                vlo_sqlCommand.Parameters.AddWithValue("@DctoCompra", pvi_dctoCompra)
                vlo_sqlCommand.Parameters.AddWithValue("@MedioPago", pvi_MedioPago)
                vlo_sqlCommand.Parameters.AddWithValue("@CCGeneral", pvi_CCGeneral)
                vlo_sqlCommand.Parameters.AddWithValue("@CCEspecifico", pvi_CCEspecifico)
                vlo_sqlCommand.Parameters.AddWithValue("@FechaOC", pvd_Fecha)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_RegistrarDetalleOC(ByVal pvi_NumeroOC As Integer,
                                           ByVal pvs_NombreProducto As String,
                                           ByVal pvi_Cantidad As Double,
                                           ByVal pvi_ValorUnitario As Double,
                                           ByVal pvi_Descuento As Double,
                                           ByVal pvi_TipoDescuento As Integer,
                                           ByVal pvi_TotalFila As Double) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
        Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarDetalleOC"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_i_DetalleOC", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OC", pvi_NumeroOC)
                vlo_sqlCommand.Parameters.AddWithValue("@NombreProducto", pvs_NombreProducto)
                vlo_sqlCommand.Parameters.AddWithValue("@Cantidad", pvi_Cantidad)
                vlo_sqlCommand.Parameters.AddWithValue("@ValorUnitario", pvi_ValorUnitario)
                vlo_sqlCommand.Parameters.AddWithValue("@Descuento", pvi_Descuento)
                vlo_sqlCommand.Parameters.AddWithValue("@TipoDescuento", pvi_TipoDescuento)
                vlo_sqlCommand.Parameters.AddWithValue("@TotalFila", pvi_TotalFila)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_RegistrarFactura(ByVal pvi_idOC As Integer,
                                           ByVal pvi_NumeroFactura As Integer,
                                           ByVal pvd_FechaFactura As Date,
                                         ByVal pvd_FechaPago As String,
                                           ByVal pvi_ValorFactura As Double,
                                           ByVal pvi_Estado As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
        Dim vls_NombreFuncionMetodo As String = "fgo_RegistrarFactura"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_i_RegistrarFacturaOC", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OC", pvi_idOC)
                vlo_sqlCommand.Parameters.AddWithValue("@NumeroFactura", pvi_NumeroFactura)
                vlo_sqlCommand.Parameters.AddWithValue("@FechaFactura", pvd_FechaFactura)
                vlo_sqlCommand.Parameters.AddWithValue("@FechaPago", pvd_FechaPago)
                vlo_sqlCommand.Parameters.AddWithValue("@ValorFactura", pvi_ValorFactura)
                vlo_sqlCommand.Parameters.AddWithValue("@Estado", pvi_Estado)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_EliminarFacturaOC(ByVal pvi_idOC As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
        Dim vls_NombreFuncionMetodo As String = "fgo_EliminarFacturaOC"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_d_EliminarFacturaOC", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OC", pvi_idOC)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_ActualizarEstadoOC(ByVal pvi_NumeroOC As Integer,
                                               ByVal pvi_EstadoOC As Integer,
                                               ByVal USUARIO As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
        Dim vls_NombreFuncionMetodo As String = "fgo_ActualizarEstadoOT"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_U_EstadoOC", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OC", pvi_NumeroOC)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Estado", pvi_EstadoOC)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Usuario", USUARIO)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_PagarFacturaOC(ByVal pvi_NumeroFactura As Integer,
                                               ByVal pvd_FechaPago As Date) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
        Dim vls_NombreFuncionMetodo As String = "fgo_PagarFacturaOC"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_U_PagarFacturaOC", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@NumeroFactura", pvi_NumeroFactura)
                vlo_sqlCommand.Parameters.AddWithValue("@FechaPago", pvd_FechaPago)
                vlo_SqlConnection.Open()
                vli_NroFilasAfectadas = vlo_sqlCommand.ExecuteNonQuery
                vlo_SqlConnection.Close()

                Return fgo_RetornoFuncionGeneral(True, vleNm_Operacion, , , vli_NroFilasAfectadas)
            End Using
        Catch ex As Exception
            Return fgo_RetornoFuncionGeneral(False, vleNm_Operacion, , , , ex, Me.ToString, vls_NombreFuncionMetodo)
        End Try
    End Function

    Public Function fgo_ProcesarOC(ByVal pvi_NumeroOC As Integer,
                                               ByVal pvi_EstadoOC As Integer) As Collection

        Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.actualizacion
        Dim vls_NombreFuncionMetodo As String = "fgo_ProcesarOC"
        Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
        'Dim vli_id_Usuario As Integer
        Dim vli_NroFilasAfectadas As Integer

        Try
            Using vlo_sqlCommand As New SqlCommand("up_parque_U_ProcesarOC", vlo_SqlConnection)
                'se indica que el comandoSQL va a ejecutar un procedimiento almacenado
                vlo_sqlCommand.CommandType = CommandType.StoredProcedure
                'se agregan los parámetros que utiliza el SP
                vlo_sqlCommand.Parameters.AddWithValue("@id_OC", pvi_NumeroOC)
                vlo_sqlCommand.Parameters.AddWithValue("@id_Estado", pvi_EstadoOC)
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
