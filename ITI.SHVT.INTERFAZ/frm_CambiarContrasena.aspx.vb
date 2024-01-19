Public Class frm_CambiarContrasena
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_ConfirmarPagoTodos", "$('#mpe_ConfirmarPagoTodos').modal();", True)
    End Sub




    Private Sub btn_ConfirmarCambioClave_Click(sender As Object, e As EventArgs) Handles btn_ConfirmarCambioClave.Click
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim vlo_BuscarUsuario As New RN.RN_AGREGARUSUARIO.cls_AgregarUsuarios
        If (vlo_BuscarUsuario.fgb_BuscarContrasena(pvi_idUsuario, txt_ActualClave.Text)) Then
            If (txt_NuevaClave.Text = txt_ReingresoNuevaClave.Text) Then
                ''UPDATE
                Dim vlo_ModificarUsuario As New RN.RN_MODIFICARUSUARIO.cls_ModificarUsuario
                If (vlo_ModificarUsuario.fgb_CambiarContrasena(pvi_idUsuario, txt_ReingresoNuevaClave.Text)) Then
                    FormsAuthentication.SignOut()
                    Session.Abandon()
                    Session.Clear()
                    Response.Redirect("~/frm_login.aspx")
                End If
            Else
                ''(2) Y (3) DEBEN SER IGUALES
            End If
        Else
            ''LA CLAVE ACTUAL INGRESADA NO ES CORRECTA

        End If
    End Sub

    Private Sub txt_ActualClave_TextChanged(sender As Object, e As EventArgs) Handles txt_ActualClave.TextChanged
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()

        If (txt_ActualClave.Text <> "") Then
            Dim vlo_BuscarUsuario As New RN.RN_AGREGARUSUARIO.cls_AgregarUsuarios
            If (vlo_BuscarUsuario.fgb_BuscarContrasena(pvi_idUsuario, txt_ActualClave.Text)) Then
                lbl_ClaveIncorrecta.Visible = False
                txt_NuevaClave.Focus()
            Else
                lbl_ClaveIncorrecta.Visible = True
                txt_ActualClave.Text = ""
            End If
        End If
    End Sub

    Private Sub txt_ReingresoNuevaClave_TextChanged(sender As Object, e As EventArgs) Handles txt_ReingresoNuevaClave.TextChanged
        If (txt_NuevaClave.Text = txt_ReingresoNuevaClave.Text) Then
            lbl_ReingresoClaveIncorrecta.Visible = False
        Else
            lbl_ReingresoClaveIncorrecta.Visible = True
        End If
    End Sub

    Private Sub btn_Cancelar_Click(sender As Object, e As EventArgs) Handles btn_Cancelar.Click
        Response.Redirect("~/frm_Inicio.aspx")
    End Sub

End Class