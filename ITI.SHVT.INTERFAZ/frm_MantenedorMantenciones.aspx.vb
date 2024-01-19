Imports ITI.SHVT.AD
Public Class frm_MantenedorMantenciones
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
        'If (ddl_Estado.Items.FindByText("Seleccionar Estado...") Is Nothing) Then
        '    ddl_Estado.Items.Insert(0, New ListItem("Seleccionar Estado...", "", True))

        '    ddl_Estado.SelectedIndex = 0
        'End If

        'If (ddl_Actividades.Items.FindByText("Seleccionar Actividad...") Is Nothing) Then
        '    ddl_Actividades.Items.Insert(0, New ListItem("Seleccionar Actividad...", "", True))

        '    ddl_Actividades.SelectedIndex = 0
        'End If


    End Sub




#End Region

#Region "BOTONES"

    Private Sub btn_RegistrarRepuesto_Click(sender As Object, e As EventArgs) Handles btn_RegistrarRepuesto.Click
        Dim pvs_NombreRepuesto As String = txt_NombreRepuesto.Text
        Dim pvs_OriginalRepuesto As String = txt_OriginalRepuesto.Text
        Dim pvs_AlternativoUnoRepuesto As String = txt_AlternativoUnoRepuesto.Text
        Dim pvs_AlternativoDosRepuesto As String = txt_AternativoDosRepuesto.Text
        Dim pvi_Cantidad As Integer = txt_CantidadRepuesto.Text
        Dim pvi_PrecioRepuesto As Integer = txt_PrecioRepuesto.Text

        Dim vpo_ManejadorMantenciones = New RN.RN_MANTENCIONES.cls_Mantenciones
        If (vpo_ManejadorMantenciones.fgb_RegistrarRepuesto(pvs_NombreRepuesto,
                                                            pvs_OriginalRepuesto,
                                                            pvs_AlternativoUnoRepuesto,
                                                            pvs_AlternativoDosRepuesto,
                                                            pvi_Cantidad,
                                                            pvi_PrecioRepuesto)) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = False
            pnl_not.Visible = True
            lbl_not1.InnerHtml = "Éxito!"
            lbl_not2.InnerHtml = "   -   Repuesto agregado correctamente."
            LimpiarRepuestos()
            upp_repuestos.Update()
        Else
            pnl_not.Visible = False
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = " -   al registrar el repuesto, por favor intente nuevamente."
            Exit Sub
        End If

    End Sub

    Private Sub btn_RegistrarLubricante_Click(sender As Object, e As EventArgs) Handles btn_RegistrarLubricante.Click
        Dim pvs_NombreLubricante As String = txt_NombreLubricante.Text
        Dim pvs_TipoLubricante As String = txt_CaracteristicasLubricante.Text
        Dim pvs_CantidadLubricante As String = txt_CantidadLubricante.Text
        Dim pvi_PrecioLubricante As Integer = txt_PrecioLubricante.Text

        Dim vpo_ManejadorMantenciones = New RN.RN_MANTENCIONES.cls_Mantenciones
        If (vpo_ManejadorMantenciones.fgb_RegistrarLubricante(pvs_NombreLubricante,
                                                            pvs_TipoLubricante,
                                                            pvs_CantidadLubricante,
                                                            pvi_PrecioLubricante)) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = False
            pnl_not.Visible = True
            lbl_not1.InnerHtml = "Éxito!"
            lbl_not2.InnerHtml = "   -   Lubricante agregado correctamente."
            LimpiarLubricantes()
            upp_lubricantes.Update()
        Else
            pnl_not.Visible = False
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = " -   al registrar el lubricante, por favor intente nuevamente."
            Exit Sub
        End If
    End Sub

    Private Sub btn_RegistrarActividad_Click(sender As Object, e As EventArgs) Handles btn_RegistrarActividad.Click
        Dim pvs_NombreActividad As String = txt_NombreActividad.Text

        Dim vpo_ManejadorMantenciones = New RN.RN_MANTENCIONES.cls_Mantenciones
        If (vpo_ManejadorMantenciones.fgb_RegistrarActividad(pvs_NombreActividad)) Then
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = False
            pnl_not.Visible = True
            lbl_not1.InnerHtml = "Éxito!"
            lbl_not2.InnerHtml = "   -   Actividad agregada correctamente."
            LimpiarActividades()
            upp_actividades.Update()

        Else
            pnl_not.Visible = False
            upp_Notificacion.Update()
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = " -   al registrar la Actividad, por favor intente nuevamente."
            Exit Sub
        End If
    End Sub

#End Region

#Region "METODOS Y FUNCIONES"
    Protected Sub LimpiarRepuestos()
        txt_NombreRepuesto.Text = ""
        txt_OriginalRepuesto.Text = ""
        txt_AlternativoUnoRepuesto.Text = ""
        txt_AternativoDosRepuesto.Text = ""
        txt_CantidadRepuesto.Text = ""
        txt_PrecioRepuesto.Text = ""
    End Sub
    Protected Sub LimpiarLubricantes()
        txt_NombreLubricante.Text = ""
        txt_CaracteristicasLubricante.Text = ""
        txt_CantidadLubricante.Text = ""
        txt_PrecioLubricante.Text = ""
    End Sub
    Protected Sub LimpiarActividades()
        txt_NombreActividad.Text = ""
    End Sub

#End Region

#Region "DROPDOWNLIST"

#End Region

End Class