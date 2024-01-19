Public Class frm_InformePagos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If
        End If
    End Sub

    Private Sub frm_InformePagos_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Clientes.Items.FindByText("TODOS LOS CLIENTES ...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("TODOS LOS CLIENTES ...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If

        'If (ddl_Sucursal.Items.FindByText("TODAS LAS SUCURSALES ...") Is Nothing) Then
        '    ddl_Sucursal.Items.Insert(0, New ListItem("TODAS LAS SUCURSALES ...", "", True))

        '    ddl_Sucursal.SelectedIndex = 0
        'End If
    End Sub

    Private Sub btn_GenerarInforme_Click(sender As Object, e As EventArgs) Handles btn_GenerarInforme.Click
        Dim pvs_RutCliente As String = ddl_Clientes.SelectedValue

        If ddl_Clientes.SelectedIndex = 0 Then
            pvs_RutCliente = "999"
        Else
            pvs_RutCliente = ddl_Clientes.SelectedValue
        End If


        If txt_FechaTermino.Text <> "" Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?RutClientePagoFactura=" & pvs_RutCliente & "&pvd_DesdePagoFactura=" & txt_FechaInicio.Text & "&pvd_HastaPagoFactura=" & txt_FechaTermino.Text & "&tiporeporte=14" & "','_newtab');", True)

        End If
    End Sub
End Class