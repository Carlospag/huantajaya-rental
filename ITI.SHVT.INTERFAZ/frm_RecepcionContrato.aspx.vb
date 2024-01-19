Public Class frm_RecepcionContrato
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If
        End If

    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim pvi_idContrato As Integer = txt_Contrato.Text
        Dim pvd_FechaRecepcion As Date = txt_FechaRecepcion.Text

        Dim vlo_ManejadorContratos As New RN.RN_CONTRATOS.cls_Contratos

        If (vlo_ManejadorContratos.fgb_ActualizarFechaRecepcion(pvi_idContrato,
                                                          pvd_FechaRecepcion)) Then

            pnl_Agregado.Visible = True
            pnl_Error.Visible = False
        Else
            pnl_Agregado.Visible = False
            pnl_Error.Visible = True

        End If
    End Sub
End Class