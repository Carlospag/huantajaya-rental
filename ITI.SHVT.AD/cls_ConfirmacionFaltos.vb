Imports System.Data.SqlClient
Imports ITI.SHVT.SERV.mdl_Variables

Namespace AD_CONFIRMACIONFALTOS

    Public Class cls_ConfirmacionFaltos

#Region "METODOS Y FUNCIONES"
        Public Function fgo_ConfirmacionFalto(ByVal pvs_RutColaborador As String, ByVal pvd_FechaCaso As Date, pvs_TurnoCaso As String) As Collection

            Dim vleNm_Operacion As enm_OperacionAccesoDatos = enm_OperacionAccesoDatos.insercion
            Dim vls_NombreFuncionMetodo As String = "fgo_ConfirmacionFalto"
            Dim vlo_SqlConnection As New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            'Dim vlo_Transaccion As SqlTransaction
            'Dim vlo_SqlCommand As SqlCommand
            Dim vli_NroFilasAfectadas As Integer

            'Inicio de captura de errores
            Try

                Using vlo_SqlCommand As New SqlCommand("up_shvt_i_Falto", vlo_SqlConnection)
                    With vlo_SqlCommand
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.AddWithValue("@RutColaborador", pvs_RutColaborador)
                        .Parameters.AddWithValue("@FechaCaso", pvd_FechaCaso)
                        .Parameters.AddWithValue("@TurnoCaso", pvs_TurnoCaso)
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
#End Region

    End Class

End Namespace

