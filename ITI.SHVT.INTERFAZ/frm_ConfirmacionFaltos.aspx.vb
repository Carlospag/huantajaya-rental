Public Class frm_ConfirmacionFaltos
    Inherits System.Web.UI.Page

#Region "INICIO"

    ''' <summary>
    ''' PAGE LOAD
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If


            ddl_Anho.SelectedIndex = 1
            pnl_faltos.Visible = False
            pnl_botones.Visible = False

        End If
    End Sub

#End Region

#Region "METODOS Y FUNCIONES"
    ''' <summary>
    ''' CARGAR DATOS SEGÚN PARAMETROS INGRESADOS
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub CargarDatos()
        sds_faltos.SelectParameters("Planta").DefaultValue = ddl_Planta.SelectedValue
        sds_faltos.SelectParameters("Mes").DefaultValue = ddl_Mes.SelectedValue
        sds_faltos.SelectParameters("Anho").DefaultValue = ddl_Anho.SelectedValue
        sds_faltos.DataBind()
        gdv_Novedades.DataSource = sds_faltos
        gdv_Novedades.DataBind()

        If gdv_Novedades.Rows.Count = 0 Then
            'upp_Novedades.Update()
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay faltos confirmados para este periodo."
        Else
            pnl_mensaje.Visible = False
        End If


    End Sub
#End Region

#Region "BOTONES"
    ''' <summary>
    ''' BOTÓN BUSCAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        pnl_botones.Visible = True
        pnl_faltos.Visible = True
        CargarDatos()
    End Sub

    ''' <summary>
    ''' BOTÓN GUARDAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click

        Dim dt_DatosFalto As New DataTable

        dt_DatosFalto.Columns.Add("RutColaborador")
        dt_DatosFalto.Columns.Add("FechaCaso")
        dt_DatosFalto.Columns.Add("TurnoCaso")
        Dim contador As Integer = 0
        For i = 0 To gdv_Novedades.Rows.Count - 1
            Dim filaDT As DataRow = dt_DatosFalto.NewRow()
            Dim chk_Confirmar As CheckBox = gdv_Novedades.Rows(i).FindControl("chk_falto")
            Dim hf_id_Falto As HiddenField = gdv_Novedades.Rows(i).FindControl("hf_id_Falto")

            If (chk_Confirmar.Checked = True) Then

                filaDT("RutColaborador") = gdv_Novedades.Rows(i).Cells(0).Text
                filaDT("FechaCaso") = gdv_Novedades.Rows(i).Cells(3).Text
                filaDT("TurnoCaso") = gdv_Novedades.Rows(i).Cells(4).Text

                dt_DatosFalto.Rows.Add(filaDT)
                contador = contador + 1
            End If

        Next

        Dim vlo_ConfirmacionFaltos As New RN.RN_CONFIRMACIONFALTOS.cls_ConfirmacionFaltos
        If contador > 0 Then
            If vlo_ConfirmacionFaltos.fgb_ConfirmacionFaltos(dt_DatosFalto) Then
                CargarDatos()
                upp_Notificacion.Update()
                pnl_Notificacion.Visible = False
                pnl_not.Visible = True
                lbl_not1.InnerHtml = "Éxito!"
                lbl_not2.InnerHtml = "   -   Faltos confirmados correctamente."
            End If
        Else
            upp_Notificacion.Update()
            pnl_not.Visible = False
            pnl_Notificacion.Visible = True
            lbl_Notificacion1.InnerHtml = "Error!"
            lbl_Notificacion2.InnerHtml = "   -  Debes seleccionar al menos un Falto antes de guardar."
        End If
        pnl_mensaje.Visible = False

    End Sub

    ''' <summary>
    ''' BOTÓN LIMPIAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        pnl_not.Visible = False
        pnl_Notificacion.Visible = False
        ddl_Anho.SelectedIndex = -1
        ddl_Mes.SelectedIndex = -1
        ddl_Planta.SelectedIndex = -1
        pnl_botones.Visible = False
        pnl_faltos.Visible = False
        pnl_mensaje.Visible = False
    End Sub
#End Region

#Region "DROPDOWNLIST"
    ''' <summary>
    ''' SELECCIONAR ... EN DROPDOWNLIST
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        'Agregar la opción de seleccionar en dropdownlist AÑO
        If (ddl_Anho.Items.FindByText("Seleccionar año...") Is Nothing) Then
            ddl_Anho.Items.Insert(0, New ListItem("Seleccionar año...", "", True))

            ddl_Anho.SelectedIndex = 0
        End If
        'Agregar la opción de seleccionar en dropdownlist MES
        If (ddl_Mes.Items.FindByText("Seleccionar mes...") Is Nothing) Then
            ddl_Mes.Items.Insert(0, New ListItem("Seleccionar mes...", "", True))

            ddl_Mes.SelectedIndex = 0
        End If
        'Agregar la opción de seleccionar en dropdownlist PLANTA
        If (ddl_Planta.Items.FindByText("Seleccionar planta...") Is Nothing) Then
            ddl_Planta.Items.Insert(0, New ListItem("Seleccionar planta...", "", True))

            ddl_Planta.SelectedIndex = 0
        End If
    End Sub
#End Region

End Class