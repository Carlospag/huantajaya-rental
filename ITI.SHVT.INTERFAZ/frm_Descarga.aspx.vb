Imports ITI.SHVT.SERV
Imports Microsoft.Reporting.WebForms

Public Class frm_Descarga
    Inherits System.Web.UI.Page

#Region "INICIO"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim pvi_Procedencia As Integer = Convert.ToInt32(Request.QueryString("procedencia"))

            If (pvi_Procedencia = 1) Then 'cartas
                Dim vls_Ruta As String
                Dim vls_NombreDocumento As String

                vls_Ruta = vgs_Contratos & Convert.ToString(Request.QueryString("caso")) & "\"
                vls_NombreDocumento = Convert.ToString(Request.QueryString("documento"))

                Response.Clear()
                Response.ClearHeaders()
                Response.ClearContent()
                Response.AddHeader("Content-Disposition", "attachment; filename=" & vls_NombreDocumento)
                Response.ContentType = "text/plain"
                Response.Flush()
                Response.TransmitFile(vls_Ruta & vls_NombreDocumento)
                Response.End()

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ClosePage", "window.close();", True)

            ElseIf (pvi_Procedencia = 2) Then 'descarga de archivo de documentos adjuntos
                Dim vls_Ruta As String
                Dim vls_NombreDocumento As String

                vls_Ruta = vgs_DirectorioArchivosTemporales & Convert.ToString(Request.QueryString("caso")) & "\"
                vls_NombreDocumento = Convert.ToString(Request.QueryString("documento"))

                Response.Clear()
                Response.ClearHeaders()
                Response.ClearContent()
                Response.AddHeader("Content-Disposition", "attachment; filename=" & vls_NombreDocumento)
                Response.ContentType = "text/plain"
                Response.Flush()
                Response.TransmitFile(vls_Ruta & vls_NombreDocumento)
                Response.End()

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ClosePage", "window.close();", True)
            End If
        End If
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    ''' <summary>
    ''' CARTA DE FALTOS
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CARTA_FALTO()
        Dim pvs_RutColaborador As String = Request.QueryString("rut")                   ' RUT
        Dim pvd_FechaCaso As String = Convert.ToDateTime(Request.QueryString("fecha"))  ' FECHA
        Dim pvs_id_TipoCausa As String = Request.QueryString("causa")                   ' ID TIPO CAUSAL
        Dim pvi_id_Caso As String = Convert.ToInt32(Request.QueryString("id_caso"))     ' ID_CASO
        Dim pvi_idTipoCaso As String = Convert.ToInt32(Request.QueryString("tipo"))     ' TIPO CASO

        Dim TurnoCaso As String
        If (Request.QueryString("turno").ToString = "No aplica") Then
            TurnoCaso = Convert.ToInt32("999")
        Else
            TurnoCaso = Convert.ToInt32(Request.QueryString("turno"))
        End If

        Dim RutFormato As String = pvs_RutColaborador.Replace(".", "")
        RutFormato = RutFormato.Replace("-", "")

        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Carta Falto Slave"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Carta por faltos " & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("RutColaborador", RutFormato, True)
                vlo_Parametros(1) = New ReportParameter("Fecha", pvd_FechaCaso, True)
                vlo_Parametros(2) = New ReportParameter("id_Turno", TurnoCaso, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With
            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' CARTA SANCION DE JEFATURA
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CARTA_SANCION_JEFATURA()
        Dim pvs_RutColaborador As String = Request.QueryString("rut")                   ' RUT
        Dim pvd_FechaCaso As String = Convert.ToDateTime(Request.QueryString("fecha"))  ' FECHA
        Dim pvs_id_TipoCausa As String = Request.QueryString("causa")                   ' ID TIPO CAUSAL
        Dim pvi_id_Caso As String = Convert.ToInt32(Request.QueryString("id_caso"))     ' ID_CASO
        Dim pvi_idTipoCaso As String = Convert.ToInt32(Request.QueryString("tipo"))     ' TIPO CASO

        Dim TurnoCaso As String
        If (Request.QueryString("turno").ToString = "No aplica") Then
            TurnoCaso = Convert.ToInt32("999")
        Else
            TurnoCaso = Convert.ToInt32(Request.QueryString("turno"))
        End If

        Dim RutFormato As String = pvs_RutColaborador.Replace(".", "")
        RutFormato = RutFormato.Replace("-", "")

        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Carta Sancion Jefatura Slave"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Carta por causal" & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("RutColaborador", RutFormato, True)
                vlo_Parametros(1) = New ReportParameter("Fecha", pvd_FechaCaso, True)
                vlo_Parametros(2) = New ReportParameter("id_Turno", TurnoCaso, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With
            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' CARTA DE FELICITACIÓN
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CARTA_FELICITACION()
        Dim pvs_RutColaborador As String = Request.QueryString("rut")                   ' RUT
        Dim pvd_FechaCaso As String = Convert.ToDateTime(Request.QueryString("fecha"))  ' FECHA
        Dim pvs_id_TipoCausa As String = Request.QueryString("causa")                   ' ID TIPO CAUSAL
        Dim pvi_id_Caso As String = Convert.ToInt32(Request.QueryString("id_caso"))     ' ID_CASO
        Dim pvi_idTipoCaso As String = Convert.ToInt32(Request.QueryString("tipo"))     ' TIPO CASO

        Dim TurnoCaso As String
        If (Request.QueryString("turno").ToString = "No aplica") Then
            TurnoCaso = Convert.ToInt32("999")
        Else
            TurnoCaso = Convert.ToInt32(Request.QueryString("turno"))
        End If

        Dim RutFormato As String = pvs_RutColaborador.Replace(".", "")
        RutFormato = RutFormato.Replace("-", "")

        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Carta Felicitacion Slave"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Carta por felicitacion " & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("RutColaborador", RutFormato, True)
                vlo_Parametros(1) = New ReportParameter("Fecha", pvd_FechaCaso, True)
                vlo_Parametros(2) = New ReportParameter("id_Turno", TurnoCaso, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With
            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' MULTA POR CAUSAL DE DERECHO
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CARTA_MULTA_JEFATURA()
        Dim pvs_RutColaborador As String = Request.QueryString("rut")                   ' RUT
        Dim pvd_FechaCaso As String = Convert.ToDateTime(Request.QueryString("fecha"))  ' FECHA
        Dim pvs_id_TipoCausa As String = Request.QueryString("causa")                   ' ID TIPO CAUSAL
        Dim pvi_id_Caso As String = Convert.ToInt32(Request.QueryString("id_caso"))     ' ID_CASO
        Dim pvi_idTipoCaso As String = Convert.ToInt32(Request.QueryString("tipo"))     ' TIPO CASO

        Dim TurnoCaso As String
        If (Request.QueryString("turno").ToString = "No aplica") Then
            TurnoCaso = Convert.ToInt32("999")
        Else
            TurnoCaso = Convert.ToInt32(Request.QueryString("turno"))
        End If

        Dim RutFormato As String = pvs_RutColaborador.Replace(".", "")
        RutFormato = RutFormato.Replace("-", "")

        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Carta Multa Jefatura Slave"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Multa por causal" & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("RutColaborador", RutFormato, True)
                vlo_Parametros(1) = New ReportParameter("Fecha", pvd_FechaCaso, True)
                vlo_Parametros(2) = New ReportParameter("id_Turno", TurnoCaso, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With
            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' MULTA POR FALTOS
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CARTA_MULTA_FALTO()
        Dim pvs_RutColaborador As String = Request.QueryString("rut")                   ' RUT
        Dim pvd_FechaCaso As String = Convert.ToDateTime(Request.QueryString("fecha"))  ' FECHA
        Dim pvs_id_TipoCausa As String = Request.QueryString("causa")                   ' ID TIPO CAUSAL
        Dim pvi_id_Caso As String = Convert.ToInt32(Request.QueryString("id_caso"))     ' ID_CASO
        Dim pvi_idTipoCaso As String = Convert.ToInt32(Request.QueryString("tipo"))     ' TIPO CASO

        Dim TurnoCaso As String
        If (Request.QueryString("turno").ToString = "No aplica") Then
            TurnoCaso = Convert.ToInt32("999")
        Else
            TurnoCaso = Convert.ToInt32(Request.QueryString("turno"))
        End If

        Dim RutFormato As String = pvs_RutColaborador.Replace(".", "")
        RutFormato = RutFormato.Replace("-", "")

        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Carta Multa Falto Slave"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Multa por falto" & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("RutColaborador", RutFormato, True)
                vlo_Parametros(1) = New ReportParameter("Fecha", pvd_FechaCaso, True)
                vlo_Parametros(2) = New ReportParameter("id_Turno", TurnoCaso, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With
            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' GENERAR CARTA EN FORMATO PDF
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub mpn_GeneraPDF()
        Dim vla_warnings() As Warning = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim streams As String() = Nothing
        Dim extension As String = Nothing
        Dim warnings As Microsoft.Reporting.WebForms.Warning()
        Dim vld_FechaActual As DateTime
        vld_FechaActual = DateTime.Now

        Dim returnValue As Byte()
        returnValue = rpu_Informe.ServerReport.Render("PDF", Nothing, mimeType, encoding, extension, streams, warnings)

        Response.Buffer = True
        Response.Clear()
        Response.ContentType = mimeType
        Response.AddHeader("content-disposition", "attachment ; filename=" + (String.Format("{0}", vld_FechaActual.ToString("yyyyMMdd")) + String.Format("-{0}_", vld_FechaActual.ToString("HHmmss")) + String.Format("{0}", "CartaDeAmonestación.")) + extension)
        Response.BinaryWrite(returnValue)
        Response.Flush()
        Response.End()
    End Sub


    '' ******************************************************
    ''      GENERACIÓN DE CARTAS MASTER (GENERAR TODAS)    ''
    '' ******************************************************
    ''' <summary>
    ''' CARTAS FALTO MASTER
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub MASTER_CARTAS_FALTOS()
        Dim TipoCarta As Integer = Convert.ToInt32(Request.QueryString("TipoCarta"))
        Dim Desde As String = Convert.ToString(Request.QueryString("Desde"))
        Dim Hasta As String = Convert.ToString(Request.QueryString("Hasta"))

        'Dim vli_idUsuario As String = Me.Session("IDUsuario").ToString()
        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Cartas Falto Master"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Carta por faltos " & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("id_TipoCaso", TipoCarta, True)
                vlo_Parametros(1) = New ReportParameter("Desde", Desde, True)
                vlo_Parametros(2) = New ReportParameter("Hasta", Hasta, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With

            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' CARTA FELICITACIÓN
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub MASTER_CARTAS_FELICITACION()
        Dim TipoCarta As Integer = Convert.ToInt32(Request.QueryString("TipoCarta"))
        Dim Desde As String = Convert.ToString(Request.QueryString("Desde"))
        Dim Hasta As String = Convert.ToString(Request.QueryString("Hasta"))

        'If IsPostBack Then
        'Dim vli_idUsuario As String = Me.Session("IDUsuario").ToString()
        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Carta Felicitacion Master"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Carta Felicitacion " & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("id_TipoCaso", TipoCarta, True)
                vlo_Parametros(1) = New ReportParameter("Desde", Desde, True)
                vlo_Parametros(2) = New ReportParameter("Hasta", Hasta, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With

            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try
        'End If
    End Sub

    ''' <summary>
    ''' CARTA SANCIÓN JEFATURA
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub MASTER_CARTAS_SANCION_JEFATURA()
        Dim TipoCarta As Integer = Convert.ToInt32(Request.QueryString("TipoCarta"))
        Dim Desde As String = Convert.ToString(Request.QueryString("Desde"))
        Dim Hasta As String = Convert.ToString(Request.QueryString("Hasta"))
        'Dim vli_idUsuario As String = Me.Session("IDUsuario").ToString()
        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Carta Sancion Jefatura Master"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Carta Sanción " & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("id_TipoCaso", TipoCarta, True)
                vlo_Parametros(1) = New ReportParameter("Desde", Desde, True)
                vlo_Parametros(2) = New ReportParameter("Hasta", Hasta, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With

            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' CARTA MULTA JEFATURA
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub MASTER_CARTAS_MULTA_JEFATURA()
        Dim TipoCarta As Integer = Convert.ToInt32(Request.QueryString("TipoCarta"))
        Dim Desde As String = Convert.ToString(Request.QueryString("Desde"))
        Dim Hasta As String = Convert.ToString(Request.QueryString("Hasta"))
        'Dim vli_idUsuario As String = Me.Session("IDUsuario").ToString()
        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Carta Multa Jefatura Master"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Carta Multa " & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("id_TipoCaso", TipoCarta, True)
                vlo_Parametros(1) = New ReportParameter("Desde", Desde, True)
                vlo_Parametros(2) = New ReportParameter("Hasta", Hasta, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With

            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' CARTA MULTA POR FALTO
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub MASTER_CARTAS_MULTA_FALTO()
        Dim TipoCarta As Integer = Convert.ToInt32(Request.QueryString("TipoCarta"))
        Dim Desde As String = Convert.ToString(Request.QueryString("Desde"))
        Dim Hasta As String = Convert.ToString(Request.QueryString("Hasta"))

        'Dim vli_idUsuario As String = Me.Session("IDUsuario").ToString()
        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Carta Multa Falto Master"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Carta Multa " & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As ReportParameter
                vlo_Parametros(0) = New ReportParameter("id_TipoCaso", TipoCarta, True)
                vlo_Parametros(1) = New ReportParameter("Desde", Desde, True)
                vlo_Parametros(2) = New ReportParameter("Hasta", Hasta, True)
                .SetParameters(vlo_Parametros)
                .Refresh()
            End With

            rpu_Informe.Visible = True
            mpn_GeneraPDF()
        Catch ex As Exception

        End Try

    End Sub
    '' ***********************************************************
    ''      FIN GENERACIÓN DE CARTAS MASTER (GENERAR TODAS)     ''
    '' ***********************************************************
#End Region

End Class