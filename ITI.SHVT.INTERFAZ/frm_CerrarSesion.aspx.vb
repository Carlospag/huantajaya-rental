Public Class frm_CerrarSesion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FormsAuthentication.SignOut()
        Session.Abandon()
        Session.Clear()
        Response.Redirect("~/frm_login.aspx")
    End Sub

End Class