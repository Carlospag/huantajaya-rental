Public Class frm_Cotizaciones
    Inherits System.Web.UI.Page
    Public Shared contador As Integer = 0
#Region "INICIO"
    ''PAGE LOAD
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

            Dim dt_ValoresCotizacion As DataTable = CType(sds_ValoresCotizacion.Select(DataSourceSelectArguments.Empty), DataView).Table

            Dim ValorFormateadoRojo As String = dt_ValoresCotizacion.Rows(0).Item("Aprobada").ToString()
            Dim ValorFormateadoAmarillo As String = dt_ValoresCotizacion.Rows(0).Item("NoConcretada").ToString()
            Dim ValorFormateadoVerde As String = dt_ValoresCotizacion.Rows(0).Item("Aceptada").ToString()

            Dim PorcentajeRojo As Double = Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("Aprobada").ToString()) / Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("Aprobada").ToString() + Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("NoConcretada").ToString() + Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("Aceptada").ToString()))) * 100
            Dim PorcentajeAmarillo As Double = Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("NoConcretada").ToString()) / Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("Aprobada").ToString() + Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("NoConcretada").ToString() + Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("Aceptada").ToString()))) * 100
            Dim PorcentajeVerde As Double = Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("Aceptada").ToString()) / Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("Aprobada").ToString() + Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("NoConcretada").ToString() + Convert.ToInt64(dt_ValoresCotizacion.Rows(0).Item("Aceptada").ToString()))) * 100

            lbl_Rojo.Text = "&nbsp;<b>Aprobadas: </b>" + ValorFormateadoRojo
            lbl_Amarillo.Text = "&nbsp;<b>No Concretadas: </b>" + ValorFormateadoAmarillo
            lbl_Verde.Text = "&nbsp;<b>Concretadas: </b>" + ValorFormateadoVerde

            lbl_PorcentajeRojo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeRojo.ToString("N2") + "%)"
            lbl_PorcentajeAmarillo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeAmarillo.ToString("N2") + "%)"
            lbl_PorcentajeVerde.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeVerde.ToString("N2") + "%)"

            sds_Cotizaciones.DataBind()
            gdv_Cotizaciones.DataSource = sds_Cotizaciones
            gdv_Cotizaciones.DataBind()

            contador = 0

        End If
    End Sub
    ''PRE RENDER COMPLETE
    Private Sub frm_OT_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Estados.Items.FindByText("TODOS...") Is Nothing) Then
            ddl_Estados.Items.Insert(0, New ListItem("TODOS...", "", True))

            ddl_Estados.SelectedIndex = 0
        End If

        If (ddl_TipoCotizacion.Items.FindByText("TODOS...") Is Nothing) Then
            ddl_TipoCotizacion.Items.Insert(0, New ListItem("TODOS...", "", True))

            ddl_TipoCotizacion.SelectedIndex = 0
        End If

        If (ddl_Clientes.Items.FindByText("TODOS...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("TODOS...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If

    End Sub
#End Region

#Region "BOTONES (INICIAR, PAUSA, ELIMINAR, DESCARGAR)"


    ''DESCARGAR UNA OT
    Protected Sub btn_DescargarOT_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_DescargarOT As LinkButton = CType(sender, LinkButton)
        Try
            Dim pvi_idCotizacion As Integer = btn_DescargarOT.CommandArgument
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?pvi_idCotizacion=" & pvi_idCotizacion & "&tiporeporte=10" & "','_newtab');", True)

        Catch ex As Exception
        End Try
    End Sub


#End Region

#Region "BOTONES BUSQUEDA DE OT"
    ''BOTON BUSCAR POR NÚMERO DE OT



    ''BOTON BUSQUEDA POR FILTROS
    Private Sub btn_filtrar_Click(sender As Object, e As EventArgs) Handles btn_filtrar.Click
        contador = contador + 1
        txt_BuscarXID.Text = ""


        Dim pvi_Estado, pvi_TipoCoti As Integer
        Dim pvs_Cliente As String

        If ddl_Estados.SelectedIndex = 0 Then
            pvi_Estado = 999
        Else
            pvi_Estado = ddl_Estados.SelectedValue
        End If

        If ddl_TipoCotizacion.SelectedIndex = 0 Then
            pvi_TipoCoti = 999
        Else
            pvi_TipoCoti = ddl_TipoCotizacion.SelectedValue
        End If

        If ddl_Clientes.SelectedIndex = 0 Then
            pvs_Cliente = "999"
        Else
            pvs_Cliente = ddl_Clientes.SelectedValue
        End If


        sds_CotizacionesXfiltros.SelectParameters("id_TipoCotizacion").DefaultValue = pvi_TipoCoti
        sds_CotizacionesXfiltros.SelectParameters("id_EstadoCotizacion").DefaultValue = pvi_Estado
        sds_CotizacionesXfiltros.SelectParameters("id_Cliente").DefaultValue = pvs_Cliente

        sds_CotizacionesXfiltros.DataBind()
        gdv_Cotizaciones.DataSource = sds_CotizacionesXfiltros
        gdv_Cotizaciones.DataBind()

        If gdv_Cotizaciones.Rows.Count = 0 Then
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay cotizaciones para el filtro seleccionado."
        Else
            pnl_mensaje.Visible = False
        End If


    End Sub

    ''BOTON LIMPIAR FILTROS
    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        txt_BuscarXID.Text = ""
        ddl_TipoCotizacion.SelectedIndex = -1
        ddl_Estados.SelectedIndex = -1
        ddl_Clientes.SelectedIndex = -1

        sds_Cotizaciones.DataBind()
        gdv_Cotizaciones.DataSource = sds_Cotizaciones
        gdv_Cotizaciones.DataBind()
    End Sub

    Private Sub btn_BuscarPorID_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorID.Click

        If IsNumeric(txt_BuscarXID.Text) Then
            ddl_Clientes.SelectedIndex = -1
            ddl_Estados.SelectedIndex = -1
            ddl_TipoCotizacion.SelectedIndex = -1

            sds_CotiXID.SelectParameters("id_Cotizacion").DefaultValue = Convert.ToInt32(txt_BuscarXID.Text)
            sds_CotiXID.DataBind()

            gdv_Cotizaciones.DataSource = sds_CotiXID
            gdv_Cotizaciones.DataBind()

            If gdv_Cotizaciones.Rows.Count = 0 Then
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No hay cotizaciones para el ID ingresado."
            Else
                pnl_mensaje.Visible = False
            End If
        Else
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   Para la búsqueda solo debe ingresar números."
            txt_BuscarXID.Text = ""

            gdv_Cotizaciones.DataSource = Nothing
            gdv_Cotizaciones.DataBind()
        End If


    End Sub



#End Region

    Protected Sub btn_AprobarOC_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_AprobarOC As LinkButton = CType(sender, LinkButton)
        Dim pvi_idcoti As Integer = btn_AprobarOC.CommandArgument
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()

        Dim vlo_ActualizarEstadoCOTI As New RN.cls_Cotizaciones

        Dim pvi_EstadoCOTI As Integer = 1 'PASA DE PENDIENTE DE APROBACIÓN A GENERADA

        vlo_ActualizarEstadoCOTI.fgb_ActualizarEstadoCotizacion(pvi_idcoti, pvi_EstadoCOTI)
        contador = contador

        If txt_BuscarXID.Text <> "" Then
            If IsNumeric(txt_BuscarXID.Text) Then
                ddl_Clientes.SelectedIndex = -1
                ddl_Estados.SelectedIndex = -1
                ddl_TipoCotizacion.SelectedIndex = -1

                sds_CotiXID.SelectParameters("id_Cotizacion").DefaultValue = Convert.ToInt32(txt_BuscarXID.Text)
                sds_CotiXID.DataBind()

                gdv_Cotizaciones.DataSource = sds_CotiXID
                gdv_Cotizaciones.DataBind()

                If gdv_Cotizaciones.Rows.Count = 0 Then
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay cotizaciones para el ID ingresado."
                Else
                    pnl_mensaje.Visible = False
                End If
            Else
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   Para la búsqueda solo debe ingresar números."
                txt_BuscarXID.Text = ""

                gdv_Cotizaciones.DataSource = Nothing
                gdv_Cotizaciones.DataBind()
            End If
        ElseIf contador <> 0 Then
            Dim pvi_Estado, pvi_TipoCoti As Integer
            Dim pvs_Cliente As String

            If ddl_Estados.SelectedIndex = 0 Then
                pvi_Estado = 999
            Else
                pvi_Estado = ddl_Estados.SelectedValue
            End If

            If ddl_TipoCotizacion.SelectedIndex = 0 Then
                pvi_TipoCoti = 999
            Else
                pvi_TipoCoti = ddl_TipoCotizacion.SelectedValue
            End If

            If ddl_Clientes.SelectedIndex = 0 Then
                pvs_Cliente = "999"
            Else
                pvs_Cliente = ddl_Clientes.SelectedValue
            End If


            sds_CotizacionesXfiltros.SelectParameters("id_TipoCotizacion").DefaultValue = pvi_TipoCoti
            sds_CotizacionesXfiltros.SelectParameters("id_EstadoCotizacion").DefaultValue = pvi_Estado
            sds_CotizacionesXfiltros.SelectParameters("id_Cliente").DefaultValue = pvs_Cliente

            sds_CotizacionesXfiltros.DataBind()
            gdv_Cotizaciones.DataSource = sds_CotizacionesXfiltros
            gdv_Cotizaciones.DataBind()

            If gdv_Cotizaciones.Rows.Count = 0 Then
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No hay cotizaciones para el filtro seleccionado."
            Else
                pnl_mensaje.Visible = False
            End If
        Else
            sds_Cotizaciones.DataBind()
            gdv_Cotizaciones.DataSource = sds_Cotizaciones
            gdv_Cotizaciones.DataBind()
        End If



            upp_Novedades.Update()


    End Sub


End Class