Public Class frm_Causas
    Inherits System.Web.UI.Page

#Region "INICIO"
    ''' <summary>
    ''' PAGE LOAD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        pnl_Notificacion.Visible = False
        pnl_not.Visible = False
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If
        End If
    End Sub

    ''' <summary>
    ''' PRE-RENDERCOMPLETE
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Causales.Items.FindByText("Seleccionar causa...") Is Nothing) Then
            ddl_Causales.Items.Insert(0, New ListItem("Seleccionar causa...", "", True))
        End If
        If (ddl_Estado.Items.FindByText("Seleccionar estado...") Is Nothing) Then
            ddl_Estado.Items.Insert(0, New ListItem("Seleccionar estado...", "", True))
        End If
    End Sub
#End Region

#Region "BOTONES"
    ''' <summary>
    ''' BOTON AGREGAR CAUSAL
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_AgregarCausa_Click(sender As Object, e As EventArgs) Handles btn_AgregarCausa.Click
        Dim pvs_NombreCausa As String = txt_NombreCausa.Text
        Dim pvs_DetalleCausa As String = txt_Motivo.InnerText
        Dim vlo_AgregareCausa As New RN.RN_CAUSAS.cls_Causas
        If pvs_NombreCausa = "" Then
            upp_Notificacion.Update()
            pnl_not.Visible = False
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "Debe ingresar un nombre a la causa que desea ingresar."
            Exit Sub
        End If
        If pvs_DetalleCausa = "" Then
            pnl_not.Visible = False
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "Debe ingresar el detalle a la causa que desea ingresar."
            Exit Sub
        End If


        If (vlo_AgregareCausa.fgb_AgregarCausas(pvs_NombreCausa,
                                                pvs_DetalleCausa)) Then

            upp_Notificacion.Update()
            pnl_Notificacion.Visible = False
            pnl_not.Visible = True
            lbl_not1.InnerHtml = "Éxito!"
            lbl_not2.InnerHtml = "   -   Causa agregada correctamente."
            LimpiarFormulario()
            'pnl_Agregado.Visible = True
            upp_agregar.Update()
            upp_modificar.Update()

        End If
    End Sub

    ''' <summary>
    ''' BOTON MODIFICAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_ModificarCausas_Click(sender As Object, e As EventArgs) Handles btn_ModificarCausas.Click
        Dim pvs_NombreCausa As String = txt_NombreCausaUPP.Text
        Dim pvs_DetalleCausa As String = txt_Detalle.InnerText
        Dim vlo_ModificarCausa As New RN.RN_CAUSAS.cls_Causas
        Dim id_TipoCausa As Integer
        Dim pvi_EstadoCausa As Integer

        If ddl_Estado.SelectedIndex = 0 Then
            upp_Notificacion.Update()
            pnl_not.Visible = False
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "Debe indicar el estado de la causa."
        Else
            pvi_EstadoCausa = ddl_Estado.SelectedValue
        End If
        If ddl_Causales.SelectedIndex = 0 Then
            upp_Notificacion.Update()
            pnl_not.Visible = False
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "Debe seleccionar una causa antes de actualizar."
            Exit Sub
        Else
            id_TipoCausa = ddl_Causales.SelectedValue
        End If


        If pvs_NombreCausa = "" Then
            upp_Notificacion.Update()
            pnl_not.Visible = False
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "Debe ingresar un nombre a la causa que desea actualizar."
            Exit Sub
        End If
        If pvs_DetalleCausa = "" Then
            pnl_not.Visible = False
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "Debe ingresar el detalle a la causa que desea actualizar."
            Exit Sub
        End If


        If (vlo_ModificarCausa.fgb_ModificarCausas(id_TipoCausa,
                                                   pvs_NombreCausa,
                                                  pvs_DetalleCausa,
                                                  pvi_EstadoCausa)) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = False
            pnl_not.Visible = True
            lbl_not1.InnerHtml = "Éxito!"
            lbl_not2.InnerHtml = "   -   Causa actualizada correctamente."
            LimpiarFormulario()
            upp_modificar.Update()
        End If
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    ''' <summary>
    ''' LIMPIAR FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub LimpiarFormulario()
        txt_Motivo.InnerText = ""
        txt_NombreCausa.Text = ""
        txt_Detalle.InnerText = ""
        txt_NombreCausaUPP.Text = ""
        ddl_Causales.DataBind()
        ddl_Estado.SelectedIndex = 0

    End Sub
#End Region

#Region "DROPWDOWNLIST"
    ''' <summary>
    ''' DDL CAUSAS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddl_Causales_TextChanged(sender As Object, e As EventArgs) Handles ddl_Causales.TextChanged
        If ddl_Causales.SelectedIndex <> 0 Then
            Dim vlo_Novedad As New RN.RN_CAUSAS.cls_Causas
            Dim vls_RetornoNovedad = vlo_Novedad.fgb_BuscarCausa(ddl_Causales.SelectedValue)

            txt_NombreCausaUPP.Text = Split(vls_RetornoNovedad, ".-.")(1)
            txt_Detalle.InnerText = Split(vls_RetornoNovedad, ".-.")(2)
            ddl_Estado.SelectedValue = Split(vls_RetornoNovedad, ".-.")(3)

        Else
            ddl_Estado.SelectedIndex = 0
            txt_NombreCausaUPP.Text = ""
            txt_Detalle.InnerText = ""
        End If
    End Sub
#End Region

End Class