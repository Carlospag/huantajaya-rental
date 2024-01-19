Public Class inf_Facturacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If
            ' DDL_ANHO.SelectedValue = 2022
            DDL_ANHO.SelectedValue = 2023
        End If

    End Sub

    Private Sub inf_Facturacion_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_periodo.Items.FindByText("TODOS...") Is Nothing) Then
            ddl_periodo.Items.Insert(0, New ListItem("TODOS...", "", True))

            ddl_periodo.SelectedIndex = 0
        End If

        If (ddl_Clientes.Items.FindByText("TODOS...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("TODOS...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If

        If (ddl_Tipo.Items.FindByText("TODOS...") Is Nothing) Then
            ddl_Tipo.Items.Insert(0, New ListItem("TODOS...", "", True))

            ddl_Tipo.SelectedIndex = 0
        End If
        If (ddl_TipoInforme.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_TipoInforme.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_TipoInforme.SelectedIndex = 0
        End If

        If (ddl_Sucursal.Items.FindByText("TODAS...") Is Nothing) Then
            ddl_Sucursal.Items.Insert(0, New ListItem("TODAS...", "", True))

            ddl_Sucursal.SelectedIndex = 0
        End If
        If (ddl_SucursalAgrupada.Items.FindByText("TODAS...") Is Nothing) Then
            ddl_SucursalAgrupada.Items.Insert(0, New ListItem("TODAS...", "", True))

            ddl_SucursalAgrupada.SelectedIndex = 0
        End If
    End Sub

    Private Sub btn_GenerarInformeGeneral_Click(sender As Object, e As EventArgs) Handles btn_GenerarInformeGeneral.Click
        Dim pvs_RutCliente As String
        Dim pvs_Periodo As String
        Dim pvs_Anho As String = DDL_ANHO.SelectedValue
        Dim pvi_Tipo As Integer
        Dim pviSucursal As Integer

        If ddl_Sucursal.SelectedIndex = 0 Then
            pviSucursal = 999
        Else
            pviSucursal = ddl_Sucursal.SelectedValue
        End If

        If ddl_Clientes.SelectedIndex = 0 Then
            pvs_RutCliente = "999"
        Else
            pvs_RutCliente = ddl_Clientes.SelectedValue
        End If

        If ddl_periodo.SelectedIndex = 0 Then
            pvs_Periodo = "999"
        Else
            pvs_Periodo = ddl_periodo.SelectedValue
        End If

        If ddl_Tipo.SelectedIndex = 0 Then
            pvi_Tipo = 999
        Else
            pvi_Tipo = ddl_Tipo.SelectedValue
        End If
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?RutFact=" & pvs_RutCliente & "&Periodo=" & pvs_Periodo & "&Anho=" & pvs_Anho & "&TipoFact=" & pvi_Tipo & "&pviSucursal=" & pviSucursal & "&tiporeporte=5" & "','_newtab');", True)
    End Sub


    Private Sub btn_VistaPrevia_Click(sender As Object, e As EventArgs) Handles btn_VistaPreviaAgrupada.Click
        pnl_Visualización.Visible = True

        Dim pvi_SucursalAgrupada As Integer

        If ddl_SucursalAgrupada.SelectedIndex = 0 Then
            pvi_SucursalAgrupada = 999
        Else
            pvi_SucursalAgrupada = ddl_SucursalAgrupada.SelectedValue
        End If

        'sds_FacturacionAgrupada.DataBind()
        'gdv_FacturacionAgrupada.DataSource = sds_FacturacionAgrupada
        'gdv_FacturacionAgrupada.DataBind()

        sds_FacturacionAgrupada.SelectParameters("F_INICIO").DefaultValue = txt_FechaInicio.Text
        sds_FacturacionAgrupada.SelectParameters("F_FIN").DefaultValue = txt_FechaTermino.Text
        sds_FacturacionAgrupada.SelectParameters("Sucursal").DefaultValue = pvi_SucursalAgrupada
        sds_FacturacionAgrupada.DataBind()
        gdv_FacturacionAgrupada.DataSource = sds_FacturacionAgrupada
        gdv_FacturacionAgrupada.DataBind()



        pnl_Visualización.Visible = True
        'btn_GenerarInformeAgrupado.Visible = True
        'btn_RecargarAgrupado.Visible = True

        'btn_GenerarInformeAgrupado.Visible = True
        gdv_FacturacionAgrupada.Visible = True
        gdv_FacturacionGeneral.Visible = False
    End Sub

    Private Sub ddl_TipoInforme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_TipoInforme.SelectedIndexChanged
        If ddl_TipoInforme.SelectedIndex <> 0 Then
            If ddl_TipoInforme.SelectedValue = "01" Then
                pnl_Visualización.Visible = False
                pnl_Clientes.Visible = True
                pnl_Mes.Visible = True
                pnl_Anho.Visible = True
                pnl_Tipo.Visible = True
                pnl_Sucursal.Visible = True
                pnl_FInicio.Visible = False
                pnl_FFin.Visible = False
                pnl_SucursalAgrupada.Visible = False
                btn_VistaPreviaGeneral.Visible = True
                btn_VistaPreviaAgrupada.Visible = False
                'btn_GenerarInformeAgrupado.Visible = False
                'btn_RecargarAgrupado.Visible = False
            Else
                pnl_Visualización.Visible = False
                pnl_Clientes.Visible = False
                pnl_Mes.Visible = False
                pnl_Anho.Visible = False
                pnl_Tipo.Visible = False
                pnl_Sucursal.Visible = False
                pnl_FInicio.Visible = True
                pnl_FFin.Visible = True
                btn_VistaPreviaAgrupada.Visible = True
                pnl_SucursalAgrupada.Visible = True
                btn_VistaPreviaGeneral.Visible = False
                btn_GenerarInformeGeneral.Visible = False
                lbl_Proyeccion.Visible = False
            End If
        Else
            pnl_Visualización.Visible = False
            pnl_Clientes.Visible = False
            pnl_Mes.Visible = False
            pnl_Anho.Visible = False
            pnl_Tipo.Visible = False
            pnl_FInicio.Visible = False
            pnl_FFin.Visible = False
            pnl_Sucursal.Visible = False
            btn_VistaPreviaAgrupada.Visible = False
            btn_VistaPreviaGeneral.Visible = False
            btn_GenerarInformeGeneral.Visible = False
            pnl_SucursalAgrupada.Visible = False
            'btn_GenerarInformeAgrupado.Visible = False
            'btn_RecargarAgrupado.Visible = False
        End If
    End Sub

    Private Sub btn_VistaPreviaGeneral_Click(sender As Object, e As EventArgs) Handles btn_VistaPreviaGeneral.Click
        Dim pvs_RutCliente As String
        Dim pvs_Periodo As String
        Dim pvs_Anho As String = DDL_ANHO.SelectedValue
        Dim pvi_Tipo As Integer
        Dim pvi_Sucursal As Integer

        If ddl_Sucursal.SelectedIndex = 0 Then
            pvi_Sucursal = 999
        Else
            pvi_Sucursal = ddl_Sucursal.SelectedValue
        End If

        If ddl_Clientes.SelectedIndex = 0 Then
            pvs_RutCliente = "999"
        Else
            pvs_RutCliente = ddl_Clientes.SelectedValue
        End If

        If ddl_periodo.SelectedIndex = 0 Then
            pvs_Periodo = "999"
        Else
            pvs_Periodo = ddl_periodo.SelectedValue
        End If

        If ddl_Tipo.SelectedIndex = 0 Then
            pvi_Tipo = 999
        Else
            pvi_Tipo = ddl_Tipo.SelectedValue
        End If

        sds_FacturacionGeneral.SelectParameters("RutCLiente").DefaultValue = pvs_RutCliente
        sds_FacturacionGeneral.SelectParameters("Periodo").DefaultValue = pvs_Periodo
        sds_FacturacionGeneral.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
        sds_FacturacionGeneral.SelectParameters("Tipo").DefaultValue = pvi_Tipo
        sds_FacturacionGeneral.SelectParameters("Sucursal").DefaultValue = pvi_Sucursal

        sds_FacturacionGeneral.DataBind()
        gdv_FacturacionGeneral.DataSource = sds_FacturacionGeneral
        gdv_FacturacionGeneral.DataBind()

        sds_FacturacionGeneralTotales.SelectParameters("RutCLiente").DefaultValue = pvs_RutCliente
        sds_FacturacionGeneralTotales.SelectParameters("Periodo").DefaultValue = pvs_Periodo
        sds_FacturacionGeneralTotales.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
        sds_FacturacionGeneralTotales.SelectParameters("Tipo").DefaultValue = pvi_Tipo
        sds_FacturacionGeneralTotales.SelectParameters("Sucursal").DefaultValue = pvi_Sucursal
        sds_FacturacionGeneralTotales.DataBind()


        Dim dt_FacturacionProyectadaTotales As DataTable = CType(sds_FacturacionGeneralTotales.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_Neto As String = dt_FacturacionProyectadaTotales.Rows(0).Item("ValorNeto").ToString()
        'Dim vls_Iva As String = dt_FacturacionProyectadaTotales.Rows(0).Item("ValorNeto").ToString()
        'Dim vls_Total As String = dt_FacturacionProyectadaTotales.Rows(0).Item("ValorNeto").ToString()
        lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación: </b>" + Format(vls_Neto, "Currency").ToString()
        lbl_Proyeccion.Visible = True

        gdv_FacturacionAgrupada.Visible = False
        gdv_FacturacionGeneral.Visible = True
        pnl_Visualización.Visible = True
        btn_GenerarInformeGeneral.Visible = True
    End Sub

    'Private Sub btn_RecargarAgrupado_Click(sender As Object, e As EventArgs) Handles btn_RecargarAgrupado.Click
    '    Dim dt_FacturacionAgrupado As New DataTable

    '    dt_FacturacionAgrupado.Columns.Add("ID")
    '    Dim contador As Integer = 0
    '    For i = 0 To gdv_FacturacionAgrupada.Rows.Count - 1
    '        Dim filaDT As DataRow = dt_FacturacionAgrupado.NewRow()
    '        Dim chk_edp As CheckBox = gdv_FacturacionAgrupada.Rows(i).FindControl("chk_edp")
    '        Dim hf_edp As HiddenField = gdv_FacturacionAgrupada.Rows(i).FindControl("hf_edp")

    '        If (chk_edp.Checked = True) Then
    '            filaDT("ID") = gdv_FacturacionAgrupada.Rows(i).Cells(0).Text
    '            dt_FacturacionAgrupado.Rows.Add(filaDT)
    '            contador = contador + 1
    '        End If
    '    Next

    '    Dim vlo_ListaEstadosDePago As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
    '    If contador > 0 Then
    '        If vlo_ListaEstadosDePago.fgb_ListadoFacturacionAgrupada(dt_FacturacionAgrupado) Then
    '            'sds_FacturacionAgrupada.SelectParameters("F_INICIO").DefaultValue = txt_FechaInicio.Text
    '            'sds_FacturacionAgrupada.SelectParameters("F_FIN").DefaultValue = txt_FechaTermino.Text

    '            Dim JSONString = String.Empty
    '            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(dt_FacturacionAgrupado)

    '            gdv_FacturacionAgrupada.DataSource = JSONString
    '            gdv_FacturacionAgrupada.DataBind()


    '            'Dim JSONString = String.Empty
    '            ' JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(dt_FacturacionAgrupado)


    '            'gdv_FacturacionAgrupada.DataSource = sds_FacturacionAgrupada
    '            'gdv_FacturacionAgrupada.DataBind()
    '            'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?List=" & JSONString & "&tiporeporte=7" & "','_newtab');", True)

    '            'CargarDatos()
    '            'upp_Notificacion.Update()
    '            'pnl_Notificacion.Visible = False
    '            'pnl_not.Visible = True
    '            'lbl_not1.InnerHtml = "Éxito!"
    '            'lbl_not2.InnerHtml = "   -   Faltos confirmados correctamente."
    '        End If
    '    Else

    '    End If

    'End Sub
End Class