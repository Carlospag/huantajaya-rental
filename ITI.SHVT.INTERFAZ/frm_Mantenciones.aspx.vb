Imports System.IO
Imports ITI.SHVT.SERV
Public Class frm_Mantenciones
    Inherits System.Web.UI.Page


#Region "INICIO"
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete

        If (ddl_EstadoEquipos.Items.FindByText("Todos los estados...") Is Nothing) Then
            ddl_EstadoEquipos.Items.Insert(0, New ListItem("Todos los estados...", "", True))

            ddl_EstadoEquipos.SelectedIndex = 0
        End If

        If (ddl_Sucursales.Items.FindByText("Todas las sucursales...") Is Nothing) Then
            ddl_Sucursales.Items.Insert(0, New ListItem("Todas las sucursales...", "", True))

            ddl_Sucursales.SelectedIndex = 0
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

            Dim dt_MontoFlota As DataTable = CType(sds_MontoFlota.Select(DataSourceSelectArguments.Empty), DataView).Table
            Dim PorcentajeRojo, PorcentajeAmarillo, PorcentajeVerde As Integer
            Dim ValorFormateadoRojo As String = dt_MontoFlota.Rows(0).Item("Rojo").ToString()
            Dim ValorFormateadoAmarillo As String = dt_MontoFlota.Rows(0).Item("Amarillo").ToString()
            Dim ValorFormateadoVerde As String = dt_MontoFlota.Rows(0).Item("Verde").ToString()
            If ValorFormateadoRojo = "0" Then
                PorcentajeRojo = 0
            Else
                PorcentajeRojo = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Rojo").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Rojo").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Amarillo").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Verde").ToString()))) * 100
            End If

            If ValorFormateadoAmarillo = "0" Then
                PorcentajeAmarillo = 0
            Else
                PorcentajeAmarillo = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Amarillo").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Rojo").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Amarillo").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Verde").ToString()))) * 100
            End If

            If ValorFormateadoVerde = "0" Then
                PorcentajeVerde = 0
            Else
                PorcentajeVerde = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Verde").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Rojo").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Amarillo").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("Verde").ToString()))) * 100
            End If




            lbl_Rojo.Text = "<b>Flota critica: </b>" + Format(ValorFormateadoRojo, "Currency").ToString()
            lbl_Amarillo.Text = "<b>Flota media: </b>" + Format(ValorFormateadoAmarillo, "Currency").ToString()
            lbl_Verde.Text = "<b>Flota Óptima: </b>" + Format(ValorFormateadoVerde, "Currency").ToString()

            lbl_PorcentajeRojo.Text = "&nbsp;&nbsp;&nbsp;(" + Convert.ToString(PorcentajeRojo) + "%)"
            lbl_PorcentajeAmarillo.Text = "&nbsp;&nbsp;&nbsp;(" + Convert.ToString(PorcentajeAmarillo) + "%)"
            lbl_PorcentajeVerde.Text = "&nbsp;&nbsp;&nbsp;(" + Convert.ToString(PorcentajeVerde) + "%)"

            ddl_TipoEquipo.SelectedValue = 1 ' Unidades Mayores
            ddl_EstadoEquipos.SelectedValue = 1 ' Arrendados
            ' mtn_CargarGrilla()

            sds_MantencionEquipos.SelectParameters("TipoEquipo").DefaultValue = 1       ' Equipos Mayores
            sds_MantencionEquipos.SelectParameters("EstadoEquipo").DefaultValue = 1   ' Arrendados
            sds_MantencionEquipos.SelectParameters("id_Sucursal").DefaultValue = 1    ' Todas las sucursales
            sds_MantencionEquipos.DataBind()
            'gdv_UnidadesMenores.DataSource = sds_MantencionEquipos
            'gdv_UnidadesMenores.DataBind()

            gdv_UnidadesMayores.DataSource = sds_MantencionEquipos
            gdv_UnidadesMayores.DataBind()

            gdv_UnidadesMayores.Visible = True
            gdv_UnidadesMenores.Visible = False
            'responsividadMenores()
            responsividadMayores()


        End If

    End Sub
#End Region

#Region "BOTONES"
    ''' DESCARGAR MANTENCIÓN
    Protected Sub btn_VerCaso_Click(ByVal sender As Object, ByVal e As EventArgs)
        mtn_CargarGrilla()
        Dim btn_VerCaso As Button = CType(sender, Button)
        Dim vli_id_Equipo As Integer = btn_VerCaso.CommandArgument

        ViewState("id_Equipo") = vli_id_Equipo

        Dim pvi_NumeroEquipo As Integer = vli_id_Equipo


        Response.Redirect("frm_reportes.aspx?idr=" & pvi_NumeroEquipo & "&tiporeporte=3", False)
        Context.ApplicationInstance.CompleteRequest()


    End Sub

    Protected Sub btn_Mantenciones_Click(ByVal sender As Object, ByVal e As EventArgs)
        'mtn_CargarGrilla()
        Dim btn_Mantenciones As Button = CType(sender, Button)
        Dim vli_id_Equipo As Integer = btn_Mantenciones.CommandArgument

        ViewState("id_Equipo") = vli_id_Equipo

        Dim pvi_NumeroEquipo As Integer = vli_id_Equipo

        sds_Mantenciones.SelectParameters("id_Equipo").DefaultValue = vli_id_Equipo
        sds_Mantenciones.DataBind()


        gdv_Mantenciones.DataSource = sds_Mantenciones
        gdv_Mantenciones.DataBind()

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_Mantenciones", "$('#mpe_Mantenciones').modal();", True)
        upp_ListaMantenciones.Update()
        'Response.Redirect("frm_reportes.aspx?idr=" & pvi_NumeroEquipo & "&tiporeporte=3", False)
        'Context.ApplicationInstance.CompleteRequest()
    End Sub

    ''' ELIMINAR DOCUMENTO ADJUNTO


    ''' <summary>
    ''' BOTÓN FILTRO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_filtrar_Click(sender As Object, e As EventArgs) Handles btn_filtrar.Click
        pnl_botones.Visible = True
        pnl_casos.Visible = True
        Dim pvi_EstadoEquipo, pvi_Sucursal As Integer

        If ddl_EstadoEquipos.SelectedIndex = 0 Then
            pvi_EstadoEquipo = 999
        Else
            pvi_EstadoEquipo = ddl_EstadoEquipos.SelectedValue
        End If

        If ddl_Sucursales.SelectedIndex = 0 Then
            pvi_Sucursal = 999
        Else
            pvi_Sucursal = ddl_Sucursales.SelectedValue
        End If

        sds_MantencionEquipos.SelectParameters("TipoEquipo").DefaultValue = ddl_TipoEquipo.SelectedValue
        sds_MantencionEquipos.SelectParameters("EstadoEquipo").DefaultValue = pvi_EstadoEquipo
        sds_MantencionEquipos.SelectParameters("id_Sucursal").DefaultValue = pvi_Sucursal
        sds_MantencionEquipos.DataBind()


        If ddl_TipoEquipo.SelectedValue = 2 Then
            gdv_UnidadesMenores.DataSource = sds_MantencionEquipos
            gdv_UnidadesMenores.DataBind()
            gdv_UnidadesMayores.Visible = False
            gdv_UnidadesMenores.Visible = True
            responsividadMenores()


            If gdv_UnidadesMenores.Rows.Count = 0 Then
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No hay equipos para este filtro."
            Else
                pnl_mensaje.Visible = False
            End If
        Else
            gdv_UnidadesMayores.DataSource = sds_MantencionEquipos
            gdv_UnidadesMayores.DataBind()
            gdv_UnidadesMayores.Visible = True
            gdv_UnidadesMenores.Visible = False

            responsividadMayores()

            If gdv_UnidadesMayores.Rows.Count = 0 Then
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No hay equipos para este filtro."
            Else

                pnl_mensaje.Visible = False
            End If
        End If
        mtn_CargarGrilla()
    End Sub

    Private Sub btn_BuscarPorAfi_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorAfi.Click
        If (txt_BuscarAfi.Text <> "") Then
            If IsNumeric(txt_BuscarAfi.Text) Then
                upp_Novedades.Update()
                sds_MantencionEquipoXAfi.SelectParameters("id_Equipo").DefaultValue = txt_BuscarAfi.Text
                sds_MantencionEquipoXAfi.DataBind()

                Dim dt_Equipo As DataTable = CType(sds_MantencionEquipoXAfi.Select(DataSourceSelectArguments.Empty), DataView).Table

                If dt_Equipo.Rows.Count <> 0 Then
                    Dim id_Familia As Integer = dt_Equipo.Rows(0).Item("id_Familia").ToString()

                    If id_Familia = 1 Or id_Familia = 12 Then
                        sds_MantencionEquipoXAfi.SelectParameters("id_Equipo").DefaultValue = txt_BuscarAfi.Text
                        sds_MantencionEquipoXAfi.DataBind()
                        gdv_UnidadesMenores.DataSource = sds_MantencionEquipoXAfi
                        gdv_UnidadesMenores.DataBind()
                        responsividadMenores()
                        gdv_UnidadesMayores.Visible = False
                        gdv_UnidadesMenores.Visible = True
                        pnl_mensaje.Visible = False
                    Else
                        sds_MantencionEquipoXAfi.SelectParameters("id_Equipo").DefaultValue = txt_BuscarAfi.Text
                        sds_MantencionEquipoXAfi.DataBind()
                        gdv_UnidadesMayores.DataSource = sds_MantencionEquipoXAfi
                        gdv_UnidadesMayores.DataBind()
                        responsividadMayores()
                        gdv_UnidadesMayores.Visible = True
                        gdv_UnidadesMenores.Visible = False
                        pnl_mensaje.Visible = False
                    End If
                Else
                    gdv_UnidadesMayores.Visible = False
                    gdv_UnidadesMenores.Visible = False
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   Equipo no registra mantenciones."
                End If
            Else
                gdv_UnidadesMayores.Visible = False
                gdv_UnidadesMenores.Visible = False
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Error!"
                lbl_mensaje2.InnerHtml = "   -   Ingrese solo números"
                txt_BuscarAfi.Text = ""
            End If
        Else
            gdv_UnidadesMayores.Visible = False
            gdv_UnidadesMenores.Visible = False
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Error!"
            lbl_mensaje2.InnerHtml = "   -   Ingrese AFI para buscar un equipo"
        End If

    End Sub
    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ddl_EstadoEquipos.SelectedIndex = -1
        ddl_TipoEquipo.SelectedValue = 2 'Unidades Menores
        ddl_Sucursales.SelectedIndex = -1
        mtn_CargarGrilla()
        responsividadMayores()
        responsividadMenores()
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Protected Sub responsividadMenores()
        If (gdv_UnidadesMenores.Rows.Count <> 0) Then
            gdv_UnidadesMenores.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_UnidadesMenores.HeaderRow.Cells(1).Attributes("data-hide") = "phone"
            gdv_UnidadesMenores.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_UnidadesMenores.HeaderRow.Cells(6).Attributes("data-hide") = "phone"

            gdv_UnidadesMenores.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub responsividadMayores()
        If (gdv_UnidadesMayores.Rows.Count <> 0) Then
            gdv_UnidadesMayores.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_UnidadesMayores.HeaderRow.Cells(1).Attributes("data-hide") = "phone"
            gdv_UnidadesMayores.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_UnidadesMayores.HeaderRow.Cells(6).Attributes("data-hide") = "phone"

            gdv_UnidadesMayores.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Private Sub mtn_CargarGrilla()
        Dim pvi_EstadoEquipo, pvi_Sucursal As Integer

        If ddl_EstadoEquipos.SelectedIndex = -1 Or ddl_EstadoEquipos.SelectedIndex = 0 Then
            pvi_EstadoEquipo = 999
        Else
            pvi_EstadoEquipo = ddl_EstadoEquipos.SelectedValue
        End If

        If ddl_Sucursales.SelectedIndex = -1 Or ddl_Sucursales.SelectedIndex = 0 Then
            pvi_Sucursal = 999
        Else
            pvi_Sucursal = ddl_Sucursales.SelectedValue
        End If

        sds_MantencionEquipos.SelectParameters("TipoEquipo").DefaultValue = ddl_TipoEquipo.SelectedValue
        sds_MantencionEquipos.SelectParameters("EstadoEquipo").DefaultValue = pvi_EstadoEquipo
        sds_MantencionEquipos.SelectParameters("id_Sucursal").DefaultValue = pvi_Sucursal
        sds_MantencionEquipos.DataBind()

        Dim AuxFamilia As String = ddl_TipoEquipo.SelectedValue

        If AuxFamilia = "" Or ddl_TipoEquipo.SelectedValue = "2" Then 'Vacio. Unidades menores o Camionetas
            gdv_UnidadesMenores.DataSource = sds_MantencionEquipos
            gdv_UnidadesMenores.DataBind()

            responsividadMenores()
        Else
            gdv_UnidadesMayores.DataSource = sds_MantencionEquipos
            gdv_UnidadesMayores.DataBind()
            responsividadMayores()
        End If



        'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
        If (gdv_UnidadesMenores.Rows.Count <> 0) Then
            gdv_UnidadesMenores.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_UnidadesMenores.HeaderRow.Cells(1).Attributes("data-hide") = "phone"
            gdv_UnidadesMenores.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_UnidadesMenores.HeaderRow.Cells(6).Attributes("data-hide") = "phone"

            gdv_UnidadesMenores.HeaderRow.TableSection = TableRowSection.TableHeader
        End If

        If (gdv_UnidadesMayores.Rows.Count <> 0) Then
            gdv_UnidadesMayores.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_UnidadesMayores.HeaderRow.Cells(1).Attributes("data-hide") = "phone"
            gdv_UnidadesMayores.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_UnidadesMayores.HeaderRow.Cells(6).Attributes("data-hide") = "phone"

            gdv_UnidadesMayores.HeaderRow.TableSection = TableRowSection.TableHeader
        End If


        'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla

    End Sub

    Private Sub btn_Informe_Click(sender As Object, e As EventArgs) Handles btn_Informe.Click
        Dim pvi_EstadoEquipo, pvi_Sucursal, vli_TipoEquipo As Integer

        vli_TipoEquipo = ddl_TipoEquipo.SelectedValue

        If ddl_EstadoEquipos.SelectedIndex = 0 Then
            pvi_EstadoEquipo = 999
        Else
            pvi_EstadoEquipo = ddl_EstadoEquipos.SelectedValue
        End If

        If ddl_Sucursales.SelectedIndex = 0 Then
            pvi_Sucursal = 999
        Else
            pvi_Sucursal = ddl_Sucursales.SelectedValue
        End If


        If vli_TipoEquipo = 1 Then
            Response.Redirect("frm_reportes.aspx?TipoEquipo=" & vli_TipoEquipo & "&EstadoEquipo=" & pvi_EstadoEquipo & "&Sucursal=" & pvi_Sucursal & "&tiporeporte=11", False)
        End If

        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?TipoEquipo=" & vli_TipoEquipo & "&EstadoEquipo=" & pvi_EstadoEquipo & "&Sucursal=" & pvi_Sucursal & "&tiporeporte=11" & "','_newtab');", True)
    End Sub




#End Region

End Class