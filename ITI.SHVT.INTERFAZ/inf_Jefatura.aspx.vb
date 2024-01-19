Imports ITI.SHVT.SERV
Imports Microsoft.Reporting.WebForms

Public Class inf_Jefatura
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If
        End If
        sds_ColaboradorXUsuario.SelectParameters("id_Usuario").DefaultValue = Session("id_Usuario").ToString()
        sds_ColaboradorXUsuario.DataBind()
    End Sub
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Colaboradores.Items.FindByText("Seleccionar colaborador...") Is Nothing) Then
            ddl_Colaboradores.Items.Insert(0, New ListItem("Seleccionar colaborador...", "", True))
        End If
    End Sub

#Region "METODOS Y FUNCIONES"
    ''' <summary>
    ''' CASOS POR TRABAJADOR
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CASOSXTRABAJADOR()
        Dim Fecha_Desde As Date = txt_FechaInicio.Text
        Dim Fecha_Hasta As Date = txt_FechaTermino.Text
        Dim rut As String = ddl_Colaboradores.SelectedValue

        Try
            'Generación de informe
            With Me.rpu_Informe.ServerReport
                'Obtención y asignación de credenciales de informe
                .ReportServerCredentials = New ReportViewerCredentials()
                'Asignación de servidor y ruta de informe
                .ReportServerUrl = New Uri(vgs_URLServidorInformes)
                .ReportPath = "/SHVT/Casos por trabajador"
                'Asignación de nombre al archivo del informe
                .DisplayName = "Casos por trabajador" & Today
                'Asignación de parámetros al visualizador de reporte
                Dim vlo_Parametros(2) As Microsoft.Reporting.WebForms.ReportParameter
                vlo_Parametros(0) = New ReportParameter("RutColaborador", rut, True)
                vlo_Parametros(1) = New ReportParameter("Desde", Fecha_Desde, True)
                vlo_Parametros(2) = New ReportParameter("Hasta", Fecha_Hasta, True)
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
        Response.AddHeader("content-disposition", "attachment ; filename=" + (String.Format("{0}", vld_FechaActual.ToString("yyyyMMdd")) + String.Format("-{0}_", vld_FechaActual.ToString("HHmmss")) + String.Format("{0}", "SHVT.")) + extension)
        Response.BinaryWrite(returnValue)
        Response.Flush()
        Response.End()
    End Sub
#End Region

    Protected Sub btn_Generar_Click(sender As Object, e As EventArgs) Handles btn_Generar.Click
        CASOSXTRABAJADOR()
    End Sub
End Class