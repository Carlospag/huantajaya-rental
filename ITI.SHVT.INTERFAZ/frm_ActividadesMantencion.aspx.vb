Public Class frm_ActividadesMantencion
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

            sds_LubricantesDisponibles.SelectParameters("id_Familia").DefaultValue = ddl_Familias.SelectedValue
            lbx_LubricantesDisponibles.DataBind()

            sds_LubricantesXfamilia.SelectParameters("id_Familia").DefaultValue = ddl_Familias.SelectedValue
            lbx_ActividadesXfamilia.DataBind()
        Else
            lbx_ActividadesDisponibles.Items.Clear()
            lbx_ActividadesXfamilia.Items.Clear()
            lbx_LubricantesDisponibles.Items.Clear()
            lbx_LubricantesXfamilia.Items.Clear()
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
            Dim vlo_ClasificarActividadMantencion As New RN.RN_MANTENCIONES.cls_Mantenciones
            vlo_ClasificarActividadMantencion.fgb_ClasificarActividad(ddl_Familias.SelectedValue, lbx_ActividadesDisponibles.SelectedValue)
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
            Dim vlo_EliminarClasificacionActividadMantencion As New RN.RN_MANTENCIONES.cls_Mantenciones
            vlo_EliminarClasificacionActividadMantencion.fgb_EliminarClasificacionActividad(ddl_Familias.SelectedValue, lbx_ActividadesXfamilia.SelectedValue)
            lbx_ActividadesDisponibles.DataBind()
            lbx_ActividadesXfamilia.DataBind()
        End If
    End Sub

    Private Sub btn_AgregarLubricante_Click(sender As Object, e As EventArgs) Handles btn_AgregarLubricante.Click
        If (lbx_LubricantesDisponibles.SelectedIndex = -1 Or ddl_Familias.SelectedIndex = 0) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "  -  Debes seleccionar un lubricante para poder asignarlo a una familia de equipos."
        Else
            Dim vlo_AgregarLubricante As New RN.RN_MANTENCIONES.cls_Mantenciones
            vlo_AgregarLubricante.fgb_ClasificarLubricante(ddl_Familias.SelectedValue, lbx_LubricantesDisponibles.SelectedValue)
            lbx_LubricantesDisponibles.DataBind()
            lbx_LubricantesXfamilia.DataBind()
        End If
    End Sub

    Private Sub btn_QuitarLubricante_Click(sender As Object, e As EventArgs) Handles btn_QuitarLubricante.Click
        If (lbx_LubricantesXfamilia.SelectedIndex = -1) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "  -  Debes seleccionar un lubricante para poder eliminar su clasificación."
        Else
            Dim vlo_EliminarLubricante As New RN.RN_MANTENCIONES.cls_Mantenciones
            vlo_EliminarLubricante.fgb_EliminarLubricante(ddl_Familias.SelectedValue, lbx_LubricantesXfamilia.SelectedValue)
            lbx_LubricantesDisponibles.DataBind()
            lbx_LubricantesXfamilia.DataBind()
        End If
    End Sub
End Class