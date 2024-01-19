Public Class frm_ActualizarHorometro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
            txt_FechaTomaHorometro.Text = Today()
            txt_FechaTomaHorometro.Text = Replace(txt_FechaTomaHorometro.Text, "-", "/")

            If Session("id_TipoCargo") <> 3 And Session("id_TipoCargo") <> 6 And Session("id_TipoCargo") <> 13 Then 'Solo actualiza horometros Operaciones
                Response.Redirect("~/frm_Inicio.aspx")
            End If


        End If
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)

    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        If IsNumeric(txt_BuscarAfi.Text) Then

            'validar que afi exista...
            If IsNumeric(txt_Horometro.Text) Then
                Dim vlo_ActualizarHorometro As New RN.RN_REGISTRAREQUIPO.cls_AgregarEquipo
                If (vlo_ActualizarHorometro.fgb_ActualizarHorometro(txt_BuscarAfi.Text,
                                                                    txt_FechaTomaHorometro.Text,
                                                                    txt_Horometro.Text)) Then
                    txt_BuscarAfi.Text = ""
                    txt_Horometro.Text = ""
                    txt_FechaTomaHorometro.Text = Today()
                    txt_FechaTomaHorometro.Text = Replace(txt_FechaTomaHorometro.Text, "-", "/")
                    pnl_Agregado.Visible = True
                    pnl_Error.Visible = False
                Else
                    txt_BuscarAfi.Text = ""
                    txt_Horometro.Text = ""
                    txt_FechaTomaHorometro.Text = Today()
                    txt_FechaTomaHorometro.Text = Replace(txt_FechaTomaHorometro.Text, "-", "/")
                    pnl_Error.Visible = True
                    pnl_Agregado.Visible = False
                End If
                'continuar validando este ingreso par aque no ingresen decimales.
            Else
                lbl_ErrorHorometro.InnerHtml = "Ingrese solo números."
                lbl_ErrorHorometro.Visible = True
                txt_Horometro.Text = ""
                txt_Horometro.Focus()
                Exit Sub
            End If
        Else
            lbl_ErrorAfi.InnerHtml = "Ingrese solo números."
            lbl_ErrorAfi.Visible = True
            txt_BuscarAfi.Text = ""
            txt_BuscarAfi.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        pnl_Agregado.Visible = False
        txt_BuscarAfi.Text = ""
        txt_FechaTomaHorometro.Text = Today()
        txt_FechaTomaHorometro.Text = Replace(txt_FechaTomaHorometro.Text, "-", "/")
        txt_Horometro.Text = ""
    End Sub
End Class