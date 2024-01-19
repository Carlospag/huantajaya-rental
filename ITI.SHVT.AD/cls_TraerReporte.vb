Imports System.Data.SqlClient
Namespace AD_REPORTE
    Public Class cls_TraerReporte

        Public Shared Function getReportData(idEquipo As Integer) As DataTable
            Dim dsData = New DataSet
            Dim vlo_sqlDataAdapter As SqlDataAdapter = Nothing
            Dim vlo_SqlConnection As SqlConnection = New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vls_NombreFuncionMetodo As String = "up_parque_s_SoloEquipo"
            vlo_sqlDataAdapter = New SqlDataAdapter("up_parque_s_SoloEquipo", vlo_SqlConnection)
            vlo_sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            vlo_sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id_Equipo", idEquipo)
            vlo_SqlConnection.Open()
            vlo_sqlDataAdapter.Fill(dsData)
            vlo_SqlConnection.Close()
            Return dsData.Tables(0)
        End Function


        Public Shared Function getReportDataContrato(idContrato As Integer) As DataTable
            Dim dsData = New DataSet
            Dim vlo_sqlDataAdapter As SqlDataAdapter = Nothing
            Dim vlo_SqlConnection As SqlConnection = New SqlConnection(pgs_ConnectionStringBDPrincipalSHVT)
            Dim vls_NombreFuncionMetodo As String = "up_parque_s_SoloContrato"
            vlo_sqlDataAdapter = New SqlDataAdapter("up_parque_s_SoloContrato", vlo_SqlConnection)
            vlo_sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            vlo_sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id_Contrato", idContrato)
            vlo_SqlConnection.Open()
            vlo_sqlDataAdapter.Fill(dsData)
            vlo_SqlConnection.Close()
            Return dsData.Tables(0)
        End Function
    End Class

End Namespace
