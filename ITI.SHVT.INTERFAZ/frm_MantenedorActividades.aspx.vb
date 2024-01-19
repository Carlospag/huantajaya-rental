Imports ITI.SHVT.AD
Public Class frm_MantenedorActividades
    Inherits System.Web.UI.Page

#Region "INICIO"
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

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Estado.Items.FindByText("Seleccionar Estado...") Is Nothing) Then
            ddl_Estado.Items.Insert(0, New ListItem("Seleccionar Estado...", "", True))

            ddl_Estado.SelectedIndex = 0
        End If

        If (ddl_Actividades.Items.FindByText("Seleccionar Actividad...") Is Nothing) Then
            ddl_Actividades.Items.Insert(0, New ListItem("Seleccionar Actividad...", "", True))

            ddl_Actividades.SelectedIndex = 0
        End If


    End Sub
#End Region

#Region "BOTONES"
    Protected Sub btn_Registrar_Click(sender As Object, e As EventArgs) Handles btn_Registrar.Click
        Dim vlo_Actividades As New RN.RN_ACTIVIDADES.cls_Actividades
        Dim pvs_NombreActividad As String = txt_NombreActividad.Text
        Dim pviCantidadActividad As Integer
        Dim pvi_Implementacion As Integer
        If txt_Cantidad.Text <> "" Then
            If IsNumeric((Convert.ToInt32(txt_Cantidad.Text))) Then
                pviCantidadActividad = Convert.ToInt32(txt_Cantidad.Text)
            Else
                pviCantidadActividad = 0
            End If
        Else
            pviCantidadActividad = 0
        End If
        If chk_Implementacion.Checked = True Then
            pvi_Implementacion = 1
        Else
            pvi_Implementacion = 0
        End If

        If pvs_NombreActividad = "" Then
            upp_Notificacion.Update()
            pnl_not.Visible = False
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "Debe ingresar un nombre a la actividad que desea ingresar."
            Exit Sub
        End If

        Dim vpo_ManejadorActividades = New AD_ACTIVIDADES.cls_Actividades

        If (vlo_Actividades.fgb_RegistrarActividad(pvs_NombreActividad,
                                                 pviCantidadActividad,
                                                 pvi_Implementacion)) Then

            upp_Notificacion.Update()
            pnl_Notificacion.Visible = False
            pnl_not.Visible = True
            lbl_not1.InnerHtml = "Éxito!"
            lbl_not2.InnerHtml = "   -   Actividad agregada correctamente."
            LimpiarFormulario()
            upp_agregar.Update()
            upp_modificar.Update()
            chk_Implementacion.Checked = False

        Else
            pnl_not.Visible = False
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = " -   al registrar la Actividad, por favor intente nuevamente."
            Exit Sub
        End If
    End Sub
    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        txt_NombreActividad.Text = ""
        txt_Cantidad.Text = ""
        pnl_not.Visible = False
        chk_Implementacion.Checked = False
        upp_Notificacion.Update()
        pnl_Notificacion.Visible = False
    End Sub


    Protected Sub btn_LimpiarMod_Click(sender As Object, e As EventArgs) Handles btn_LimpiarMod.Click
        pnl_not.Visible = False
        upp_Notificacion.Update()
        pnl_Notificacion.Visible = False
        txt_NombreServicio.Text = ""
        ddl_Actividades.DataBind()
        ddl_Actividades.SelectedIndex = -1
        ddl_Estado.SelectedIndex = 0
        chk_ImplementacionRespuesta.Checked = False
        txt_CantidadRespuesta.Text = ""
    End Sub
    Protected Sub btn_ModificarCausas_Click(sender As Object, e As EventArgs) Handles btn_ModificarCausas.Click

        If ddl_Actividades.SelectedIndex <> 0 Then
            Dim pvi_idActividad As Integer = ddl_Actividades.SelectedValue
            Dim pvs_NombreActividad As String = txt_NombreServicio.Text
            Dim pvi_EstadoActividad As Integer = ddl_Estado.SelectedValue
            Dim pvi_Implementacion As Integer
            Dim pvi_Cantidad As Integer

            If chk_ImplementacionRespuesta.Checked = True Then
                pvi_Implementacion = 1
            Else
                pvi_Implementacion = 0
            End If

            If txt_CantidadRespuesta.Text <> "" Then
                If IsNumeric(Convert.ToInt32(txt_CantidadRespuesta.Text)) Then
                    pvi_Cantidad = Convert.ToInt32(txt_CantidadRespuesta.Text)
                Else
                    pvi_Cantidad = 0
                End If
            Else
                pvi_Cantidad = 0
            End If

            If txt_NombreServicio.Text = "" Then
                pnl_not.Visible = False
                upp_Notificacion.Update()
                pnl_Notificacion.Visible = True
                lbl_Notificacion1.InnerHtml = "Error!"
                lbl_Notificacion2.InnerHtml = "   -   El nombre de la actividad no puede estar vacío, por favor intente nuevamente."
                Exit Sub
            End If



            Dim vlo_Actividades As New RN.RN_ACTIVIDADES.cls_Actividades
            If (vlo_Actividades.fgb_ModificarActividad(pvi_idActividad,
                                                       pvs_NombreActividad,
                                                       pvi_EstadoActividad,
                                                       pvi_Cantidad,
                                                       pvi_Implementacion)) Then

                upp_Notificacion.Update()
                pnl_Notificacion.Visible = False
                pnl_not.Visible = True
                lbl_not1.InnerHtml = "Éxito!"
                lbl_not2.InnerHtml = "   -   Actividad Modificada correctamente."
                LimpiarFormulario()
                upp_agregar.Update()
                upp_modificar.Update()
            Else
                pnl_not.Visible = False
                upp_Notificacion.Update()
                pnl_Notificacion.Visible = True
                lbl_Notificacion1.InnerHtml = "Error!"
                lbl_Notificacion2.InnerHtml = "   -   La actividad no logro ser actualiza, por favor intente nuevamente."
            End If
        Else
            pnl_not.Visible = False
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "   -   Debe seleccionar una actividad antes de actualizar."
        End If


    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Protected Sub LimpiarFormulario()
        txt_CantidadRespuesta.Text = ""
        txt_NombreActividad.Text = ""
        txt_Cantidad.Text = ""
        txt_NombreServicio.Text = ""
        ddl_Actividades.DataBind()
        ddl_Actividades.SelectedIndex = -1
        ddl_Estado.SelectedIndex = 0
        chk_ImplementacionRespuesta.Checked = False

    End Sub
#End Region

#Region "DROPDOWNLIST"
    Protected Sub ddl_Actividades_TextChanged(sender As Object, e As EventArgs) Handles ddl_Actividades.TextChanged
        If ddl_Actividades.SelectedIndex <> 0 Then
            sds_ActividadesXid.SelectParameters("id_Actividad").DefaultValue = ddl_Actividades.SelectedValue
            sds_ActividadesXid.DataBind()

            Dim dt_Actividades As DataTable = CType(sds_ActividadesXid.Select(DataSourceSelectArguments.Empty), DataView).Table

            txt_NombreServicio.Text = dt_Actividades.Rows(0).Item("NombreActividad").ToString()
            txt_CantidadRespuesta.Text = dt_Actividades.Rows(0).Item("CantidadActividad").ToString()
            ddl_Estado.SelectedValue = dt_Actividades.Rows(0).Item("EstadoActividad").ToString()
            If dt_Actividades.Rows(0).Item("EsImplementacion") = 1 Then
                chk_ImplementacionRespuesta.Checked = True
            Else
                chk_ImplementacionRespuesta.Checked = False
            End If


        Else
            ddl_Estado.SelectedIndex = 0
            txt_NombreServicio.Text = ""
            txt_CantidadRespuesta.Text = ""
            chk_ImplementacionRespuesta.Checked = False
        End If
    End Sub
#End Region

End Class