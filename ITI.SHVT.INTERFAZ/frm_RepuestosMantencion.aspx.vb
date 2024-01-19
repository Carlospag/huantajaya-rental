Public Class frm_RepuestosMantencion
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
    Protected Sub ddl_Familia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Familia.SelectedIndexChanged
        If (ddl_Familia.SelectedIndex <> 0) Then

            sds_EquiposXFamilia.SelectParameters("id_Familia").DefaultValue = ddl_Familia.SelectedValue
            sds_EquiposXFamilia.DataBind()
        Else
            txt_BuscarAfi.Text = ""
        End If


    End Sub

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Familia.Items.FindByText("Selecionar familia ...") Is Nothing) Then
            ddl_Familia.Items.Insert(0, New ListItem("Selecionar familia ...", "", True))

            ddl_Familia.SelectedIndex = 0
        End If
        If (ddl_Equipos.Items.FindByText("Selecionar equipo ...") Is Nothing) Then
            ddl_Equipos.Items.Insert(0, New ListItem("Selecionar equipo ...", "", True))

            ddl_Equipos.SelectedIndex = 0
        End If
    End Sub

    Private Sub ddl_Equipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Equipos.SelectedIndexChanged

        If (ddl_Equipos.SelectedIndex <> 0) Then
            sds_RepuestosDisponibles.SelectParameters("id_Equipo").DefaultValue = ddl_Equipos.SelectedValue
            lbx_RepuestosDisponibles.DataBind()

            sds_RepuestosXequipo.SelectParameters("id_Equipo").DefaultValue = ddl_Equipos.SelectedValue
            lbx_RepuestosXequipo.DataBind()

            txt_BuscarAfi.Text = ddl_Equipos.SelectedValue
        Else
            lbx_RepuestosDisponibles.Items.Clear()
            lbx_RepuestosXequipo.Items.Clear()
            txt_BuscarAfi.Text = ""
        End If

    End Sub

    Protected Sub btn_AgregarColaborador_Click(sender As Object, e As EventArgs) Handles btn_AgregarColaborador.Click
        If (lbx_RepuestosDisponibles.SelectedIndex = -1 Or ddl_Equipos.SelectedIndex = 0) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "  -  Debes seleccionar un repuesto para poder asignarlo a un equipo."
        Else
            Dim vlo_ClasificarRepuesto As New RN.RN_MANTENCIONES.cls_Mantenciones
            vlo_ClasificarRepuesto.fgb_ClasificarRepuesto(ddl_Equipos.SelectedValue, lbx_RepuestosDisponibles.SelectedValue)
            lbx_RepuestosDisponibles.DataBind()
            lbx_RepuestosXequipo.DataBind()
        End If
    End Sub

    Protected Sub btn_QuitarColaborador_Click(sender As Object, e As EventArgs) Handles btn_QuitarColaborador.Click
        If (lbx_RepuestosXequipo.SelectedIndex = -1) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "  -  Debes seleccionar un repuesto para poder eliminar su clasificación."
        Else
            Dim vlo_EliminarRepuesto As New RN.RN_MANTENCIONES.cls_Mantenciones
            vlo_EliminarRepuesto.fgb_EliminarClasificacionRepuesto(ddl_Equipos.SelectedValue, lbx_RepuestosXequipo.SelectedValue)
            lbx_RepuestosDisponibles.DataBind()
            lbx_RepuestosXequipo.DataBind()
        End If
    End Sub





End Class