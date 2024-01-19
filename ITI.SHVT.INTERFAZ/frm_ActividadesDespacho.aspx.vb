Public Class frm_ActividadesDespacho
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

        End If
    End Sub
    Protected Sub ddl_Familias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Familias.SelectedIndexChanged
        If (ddl_Familias.SelectedIndex <> 0) Then
            sds_ActividadesDisponibles.SelectParameters("id_Familia").DefaultValue = ddl_Familias.SelectedValue
            lbx_ActividadesDisponibles.DataBind()

            sds_ActividadesXFamilia.SelectParameters("id_Familia").DefaultValue = ddl_Familias.SelectedValue
            lbx_ActividadesXfamilia.DataBind()
        Else
            lbx_ActividadesDisponibles.Items.Clear()
            lbx_ActividadesXfamilia.Items.Clear()
        End If
    End Sub

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Familias.Items.FindByText("Selecionar familia ...") Is Nothing) Then
            ddl_Familias.Items.Insert(0, New ListItem("Selecionar familia ...", "", True))

            ddl_Familias.SelectedIndex = 0
        End If
    End Sub

    Protected Sub btn_AgregarColaborador_Click(sender As Object, e As EventArgs) Handles btn_AgregarColaborador.Click
        If (lbx_ActividadesDisponibles.SelectedIndex = -1 Or ddl_Familias.SelectedIndex = 0) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "  -  Debes seleccionar una actividad para poder asignarla a una familia de equipos."
        Else
            Dim vlo_ClasificarActividad As New RN.RN_ACTIVIDADES.cls_Actividades
            vlo_ClasificarActividad.fgb_ClasificarActividad(ddl_Familias.SelectedValue, lbx_ActividadesDisponibles.SelectedValue)
            lbx_ActividadesDisponibles.DataBind()
            lbx_ActividadesXfamilia.DataBind()
        End If
    End Sub

    Protected Sub btn_QuitarColaborador_Click(sender As Object, e As EventArgs) Handles btn_QuitarColaborador.Click
        If (lbx_ActividadesXfamilia.SelectedIndex = -1) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "  -  Debes seleccionar una actividad para poder eliminar su clasificación."
        Else
            Dim vlo_EliminarClasificacionActividad As New RN.RN_ACTIVIDADES.cls_Actividades
            vlo_EliminarClasificacionActividad.fgb_EliminarClasificacionActividad(ddl_Familias.SelectedValue, lbx_ActividadesXfamilia.SelectedValue)
            lbx_ActividadesDisponibles.DataBind()
            lbx_ActividadesXfamilia.DataBind()
        End If
    End Sub


End Class