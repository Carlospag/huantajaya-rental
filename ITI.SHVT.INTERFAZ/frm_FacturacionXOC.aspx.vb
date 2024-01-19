Public Class frm_FacturacionXOC
    Inherits System.Web.UI.Page

#Region "INICIO"
    Private Sub frm_FacturacionXOC_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_EstadosFactura.Items.FindByText("Mostrar todos...") Is Nothing) Then
            ddl_EstadosFactura.Items.Insert(0, New ListItem("Mostrar todos...", "", True))

            ddl_EstadosFactura.SelectedIndex = 0
        End If

        If (ddl_NombreProveedor.Items.FindByText("Mostrar todos...") Is Nothing) Then
            ddl_NombreProveedor.Items.Insert(0, New ListItem("Mostrar todos...", "", True))

            ddl_NombreProveedor.SelectedIndex = 0
        End If

        If (ddl_CCPadre.Items.FindByText("Mostrar todos...") Is Nothing) Then
            ddl_CCPadre.Items.Insert(0, New ListItem("Mostrar todos...", "", True))

            ddl_CCPadre.SelectedIndex = 0
        End If

        If (ddl_CCHijo.Items.FindByText("Mostrar todos...") Is Nothing) Then
            ddl_CCHijo.Items.Insert(0, New ListItem("Mostrar todos...", "", True))

            ddl_CCHijo.SelectedIndex = 0
        End If

        If (ddl_periodo.Items.FindByText("Mostrar todos...") Is Nothing) Then
            ddl_periodo.Items.Insert(0, New ListItem("Mostrar todos...", "", True))

            ddl_periodo.SelectedIndex = 0
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            lbl_NumeroFacturaEXITO.Visible = False
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)

            DDL_ANHO.SelectedValue = 2023

            sds_FacturacionXOC.SelectParameters("id_Proveedor").DefaultValue = "999"
            sds_FacturacionXOC.SelectParameters("EstadoFactura").DefaultValue = 1
            sds_InformeDeuda.SelectParameters("id_CCHijo").DefaultValue = 999
            sds_InformeDeuda.SelectParameters("Mes").DefaultValue = 999
            sds_InformeDeuda.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue

            sds_FacturacionXOC.DataBind()
            gdv_FacturacionXOC.DataSource = sds_FacturacionXOC
            gdv_FacturacionXOC.DataBind()

            txt_FechaPago.Text = Today()
            txt_FechaPago.Text = Replace(txt_FechaPago.Text, "-", "/")

            sds_TotalDeuda.SelectParameters("id_Proveedor").DefaultValue = "999"
            sds_TotalDeuda.SelectParameters("EstadoFactura").DefaultValue = 1
            sds_TotalDeuda.DataBind()
            Dim dt_FacturacionProyectada As DataTable = CType(sds_TotalDeuda.Select(DataSourceSelectArguments.Empty), DataView).Table
            Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString()
            lbl_Proyeccion.Text = "<b>Deuda actual: </b>" + dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString() ''"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
            lbl_Proyeccion.Visible = True
        End If

    End Sub
#End Region

#Region "BOTONES"
    Protected Sub btn_PagarFactura_Click(ByVal sender As Object, ByVal e As EventArgs)

        lbl_NumeroFacturaEXITO.Visible = False
        Dim btn_PagarFactura As LinkButton = CType(sender, LinkButton)
        Dim pvi_NumeroFactura As Integer = btn_PagarFactura.CommandArgument
        txt_FechaPago.Text = Today()
        txt_FechaPago.Text = Replace(Today(), "-", "/")
        lbl_NFact.InnerHtml = pvi_NumeroFactura

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_PagoYFecha", "$('#mpe_PagoYFecha').modal();", True)
        upp_nfactura.Update()

    End Sub

    Private Sub btn_GuardarFechaPago_Click(sender As Object, e As EventArgs) Handles btn_GuardarFechaPago.Click
        Dim pvd_FechaPago As Date = txt_FechaPago.Text
        Dim pvi_NumeroFactura As Integer = lbl_NFact.InnerHtml
        Dim vlo_OC As New RN.cls_OrdenDeCompra
        If (vlo_OC.fgb_PagarFacturaOC(pvi_NumeroFactura, pvd_FechaPago)) Then
            lbl_NumeroFacturaEXITO.InnerText = "Pago registrado con éxito."
            lbl_NumeroFacturaEXITO.Visible = True

            Dim pvs_RutProveedor As String
            Dim PVI_EstadoFactura As Integer
            Dim PVI_CCPadre As Integer
            Dim PVI_CCHijo As Integer
            Dim pvi_Mes As Integer
            Dim pvi_Anho As Integer

            If txt_BuscarXFactura.Text = "" Then
                txt_BuscarXFactura.Text = ""

                If ddl_NombreProveedor.SelectedIndex <> 0 Then
                    pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
                Else
                    pvs_RutProveedor = "999"
                End If
                If ddl_EstadosFactura.SelectedIndex <> 0 Then
                    PVI_EstadoFactura = ddl_EstadosFactura.SelectedValue
                Else
                    PVI_EstadoFactura = 999
                End If
                If ddl_CCPadre.SelectedIndex <> 0 Then
                    PVI_CCPadre = ddl_CCPadre.SelectedValue
                Else
                    PVI_CCPadre = 999
                End If
                If ddl_CCHijo.SelectedIndex <> 0 Then
                    PVI_CCHijo = ddl_CCHijo.SelectedValue
                Else
                    PVI_CCHijo = 999
                End If
                If ddl_periodo.SelectedIndex <> 0 Then
                    pvi_Mes = ddl_periodo.SelectedValue
                Else
                    pvi_Mes = 999
                End If
                If DDL_ANHO.SelectedIndex <> 0 Then
                    pvi_Anho = DDL_ANHO.SelectedValue
                Else
                    pvi_Anho = 999
                End If

                sds_InformeDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
                sds_InformeDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
                sds_InformeDeuda.SelectParameters("id_CCGeneral").DefaultValue = PVI_CCPadre
                sds_InformeDeuda.SelectParameters("id_CCHijo").DefaultValue = PVI_CCHijo
                sds_InformeDeuda.SelectParameters("Mes").DefaultValue = pvi_Mes
                sds_InformeDeuda.SelectParameters("Anho").DefaultValue = pvi_Anho
                sds_InformeDeuda.DataBind()
                gdv_FacturacionXOC.DataSource = sds_InformeDeuda
                gdv_FacturacionXOC.DataBind()

                sds_TotalDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
                sds_TotalDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
                sds_TotalDeuda.DataBind()
                Dim dt_FacturacionProyectada As DataTable = CType(sds_TotalDeuda.Select(DataSourceSelectArguments.Empty), DataView).Table
                Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString()
                lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Deuda actual: </b>" + dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString() ''"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
                lbl_Proyeccion.Visible = True

                If gdv_FacturacionXOC.Rows.Count = 0 Then
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay facturas con el filtro seleccionado."
                    gdv_FacturacionXOC.DataSource = Nothing
                    gdv_FacturacionXOC.DataBind()

                    txt_BuscarXFactura.Focus()
                Else
                    pnl_mensaje.Visible = False
                End If
            Else
                sds_FacturasXNF.SelectParameters("NumeroFactura").DefaultValue = txt_BuscarXFactura.Text

                sds_FacturasXNF.DataBind()
                gdv_FacturacionXOC.DataSource = sds_FacturasXNF
                gdv_FacturacionXOC.DataBind()
            End If





            upp_GrillaPermisos.Update()

        End If

    End Sub

    Private Sub ddl_EstadosFactura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_EstadosFactura.SelectedIndexChanged
        Dim pvs_RutProveedor As String
        Dim PVI_EstadoFactura As Integer
        Dim PVI_CCPadre As Integer
        Dim PVI_CCHijo As Integer
        Dim pvi_Mes As Integer
        Dim pvi_Anho As Integer
        txt_BuscarXFactura.Text = ""


        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
        Else
            pvs_RutProveedor = "999"
        End If
        If ddl_EstadosFactura.SelectedIndex <> 0 Then
            PVI_EstadoFactura = ddl_EstadosFactura.SelectedValue
        Else
            PVI_EstadoFactura = 999
        End If
        If ddl_CCPadre.SelectedIndex <> 0 Then
            PVI_CCPadre = ddl_CCPadre.SelectedValue
        Else
            PVI_CCPadre = 999
        End If
        If ddl_CCHijo.SelectedIndex <> 0 Then
            PVI_CCHijo = ddl_CCHijo.SelectedValue
        Else
            PVI_CCHijo = 999
        End If
        If ddl_periodo.SelectedIndex <> 0 Then
            pvi_Mes = ddl_periodo.SelectedValue
        Else
            pvi_Mes = 999
        End If
        If DDL_ANHO.SelectedIndex <> 0 Then
            pvi_Anho = DDL_ANHO.SelectedValue
        Else
            pvi_Anho = 999
        End If

        sds_InformeDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_InformeDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_InformeDeuda.SelectParameters("id_CCGeneral").DefaultValue = PVI_CCPadre
        sds_InformeDeuda.SelectParameters("id_CCHijo").DefaultValue = PVI_CCHijo
        sds_InformeDeuda.SelectParameters("Mes").DefaultValue = pvi_Mes
        sds_InformeDeuda.SelectParameters("Anho").DefaultValue = pvi_Anho
        sds_InformeDeuda.DataBind()
        gdv_FacturacionXOC.DataSource = sds_InformeDeuda
        gdv_FacturacionXOC.DataBind()

        sds_TotalDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_TotalDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_TotalDeuda.DataBind()
        Dim dt_FacturacionProyectada As DataTable = CType(sds_TotalDeuda.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString()
        lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Deuda actual: </b>" + dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString() ''"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
        lbl_Proyeccion.Visible = True

        If gdv_FacturacionXOC.Rows.Count = 0 Then
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay facturas con el filtro seleccionado."
            gdv_FacturacionXOC.DataSource = Nothing
            gdv_FacturacionXOC.DataBind()

            txt_BuscarXFactura.Focus()
        Else
            pnl_mensaje.Visible = False
        End If
    End Sub

    Private Sub ddl_NombreProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_NombreProveedor.SelectedIndexChanged
        Dim pvs_RutProveedor As String
        Dim PVI_EstadoFactura As Integer
        Dim PVI_CCPadre As Integer
        Dim PVI_CCHijo As Integer
        Dim pvi_Mes As Integer
        Dim pvi_Anho As Integer
        txt_BuscarXFactura.Text = ""

        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
        Else
            pvs_RutProveedor = "999"
        End If
        If ddl_EstadosFactura.SelectedIndex <> 0 Then
            PVI_EstadoFactura = ddl_EstadosFactura.SelectedValue
        Else
            PVI_EstadoFactura = 999
        End If
        If ddl_CCPadre.SelectedIndex <> 0 Then
            PVI_CCPadre = ddl_CCPadre.SelectedValue
        Else
            PVI_CCPadre = 999
        End If
        If ddl_CCHijo.SelectedIndex <> 0 Then
            PVI_CCHijo = ddl_CCHijo.SelectedValue
        Else
            PVI_CCHijo = 999
        End If
        If ddl_periodo.SelectedIndex <> 0 Then
            pvi_Mes = ddl_periodo.SelectedValue
        Else
            pvi_Mes = 999
        End If
        If DDL_ANHO.SelectedIndex <> 0 Then
            pvi_Anho = DDL_ANHO.SelectedValue
        Else
            pvi_Anho = 999
        End If


        sds_InformeDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_InformeDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_InformeDeuda.SelectParameters("id_CCGeneral").DefaultValue = PVI_CCPadre
        sds_InformeDeuda.SelectParameters("id_CCHijo").DefaultValue = PVI_CCHijo
        sds_InformeDeuda.SelectParameters("Mes").DefaultValue = pvi_Mes
        sds_InformeDeuda.SelectParameters("Anho").DefaultValue = pvi_Anho

        sds_InformeDeuda.DataBind()
        gdv_FacturacionXOC.DataSource = sds_InformeDeuda
        gdv_FacturacionXOC.DataBind()

        sds_TotalDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_TotalDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_TotalDeuda.DataBind()
        Dim dt_FacturacionProyectada As DataTable = CType(sds_TotalDeuda.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString()
        lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Deuda actual: </b>" + dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString() ''"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
        lbl_Proyeccion.Visible = True

        If gdv_FacturacionXOC.Rows.Count = 0 Then
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay facturas con el filtro seleccionado."
            gdv_FacturacionXOC.DataSource = Nothing
            gdv_FacturacionXOC.DataBind()

            txt_BuscarXFactura.Focus()
        Else
            pnl_mensaje.Visible = False
        End If
    End Sub



    Private Sub txt_BuscarXFactura_TextChanged(sender As Object, e As EventArgs) Handles txt_BuscarXFactura.TextChanged
        If IsNumeric(txt_BuscarXFactura.Text) Then
            ddl_EstadosFactura.SelectedIndex = -1
            ddl_NombreProveedor.SelectedIndex = -1

            sds_FacturasXNF.SelectParameters("NumeroFactura").DefaultValue = txt_BuscarXFactura.Text

            sds_FacturasXNF.DataBind()
            gdv_FacturacionXOC.DataSource = sds_FacturasXNF
            gdv_FacturacionXOC.DataBind()



            If gdv_FacturacionXOC.Rows.Count = 0 Then
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No hay facturas con el N° ingresado."
                gdv_FacturacionXOC.DataSource = Nothing
                gdv_FacturacionXOC.DataBind()

                txt_BuscarXFactura.Focus()
            Else
                pnl_mensaje.Visible = False
            End If
        End If



    End Sub

    Private Sub btn_Informe_Click(sender As Object, e As EventArgs) Handles btn_Informe.Click
        Dim pvs_RutProveedor As String
        Dim PVI_EstadoFactura As Integer


        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
        Else
            pvs_RutProveedor = "999"
        End If

        PVI_EstadoFactura = 1


        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?idProveedor=" & pvs_RutProveedor & "&EstadoFactura=" & PVI_EstadoFactura & "&tiporeporte=17" & "','_newtab');", True)

    End Sub

    Private Sub btn_InformeGasto_Click(sender As Object, e As EventArgs) Handles btn_InformeGasto.Click
        Dim pvs_RutProveedor As String
        Dim PVI_EstadoFactura As Integer
        Dim pvi_CCPadre As Integer
        Dim pvi_CCHijo As Integer
        Dim pvi_Mes As Integer
        Dim pvi_Anho As Integer


        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
        Else
            pvs_RutProveedor = "999"
        End If

        If ddl_EstadosFactura.SelectedIndex <> 0 Then
            PVI_EstadoFactura = ddl_EstadosFactura.SelectedValue
        Else
            PVI_EstadoFactura = 999
        End If

        If ddl_CCPadre.SelectedIndex <> 0 Then
            pvi_CCPadre = ddl_CCPadre.SelectedValue
        Else
            pvi_CCPadre = 999
        End If

        If ddl_CCHijo.SelectedIndex <> 0 Then
            pvi_CCHijo = ddl_CCHijo.SelectedValue
        Else
            pvi_CCHijo = 999
        End If

        If ddl_periodo.SelectedIndex <> 0 Then
            pvi_Mes = ddl_periodo.SelectedValue
        Else
            pvi_Mes = 999
        End If

        If DDL_ANHO.SelectedIndex <> 0 Then
            pvi_Anho = DDL_ANHO.SelectedValue
        Else
            pvi_Anho = 999
        End If

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?idProveedorInfGastos=" & pvs_RutProveedor & "&EstadoFacturaInfGastos=" & PVI_EstadoFactura & "&CCPadreInfGastos=" & pvi_CCPadre & "&CCHijoInfGastos=" & pvi_CCHijo & "&MesInfGastos=" & pvi_Mes & "&AnhoInfGastos=" & pvi_Anho & "&tiporeporte=18" & "','_newtab');", True)

    End Sub

    Private Sub ddl_CCPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_CCPadre.SelectedIndexChanged
        If ddl_CCPadre.SelectedIndex = 0 Then
            ddl_CCHijo.SelectedIndex = -1
            ddl_CCHijo.DataSource = Nothing
        Else
            sds_CCHijos.SelectParameters("id_CentroCostoPadre").DefaultValue = ddl_CCPadre.SelectedValue
            sds_CCHijos.DataBind()
        End If

        Dim pvs_RutProveedor As String
        Dim PVI_EstadoFactura As Integer
        Dim PVI_CCPadre As Integer
        Dim PVI_CCHijo As Integer
        Dim pvi_Mes As Integer
        Dim pvi_Anho As Integer
        txt_BuscarXFactura.Text = ""

        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
        Else
            pvs_RutProveedor = "999"
        End If
        If ddl_EstadosFactura.SelectedIndex <> 0 Then
            PVI_EstadoFactura = ddl_EstadosFactura.SelectedValue
        Else
            PVI_EstadoFactura = 999
        End If
        If ddl_CCPadre.SelectedIndex <> 0 Then
            PVI_CCPadre = ddl_CCPadre.SelectedValue
        Else
            PVI_CCPadre = 999
        End If
        If ddl_CCHijo.SelectedIndex <> 0 Then
            PVI_CCHijo = ddl_CCHijo.SelectedValue
        Else
            PVI_CCHijo = 999
        End If
        If ddl_periodo.SelectedIndex <> 0 Then
            pvi_Mes = ddl_periodo.SelectedValue
        Else
            pvi_Mes = 999
        End If
        If DDL_ANHO.SelectedIndex <> 0 Then
            pvi_Anho = DDL_ANHO.SelectedValue
        Else
            pvi_Anho = 999
        End If


        sds_InformeDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_InformeDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_InformeDeuda.SelectParameters("id_CCGeneral").DefaultValue = PVI_CCPadre
        sds_InformeDeuda.SelectParameters("id_CCHijo").DefaultValue = PVI_CCHijo
        sds_InformeDeuda.SelectParameters("Mes").DefaultValue = pvi_Mes
        sds_InformeDeuda.SelectParameters("Anho").DefaultValue = pvi_Anho

        sds_InformeDeuda.DataBind()
        gdv_FacturacionXOC.DataSource = sds_InformeDeuda
        gdv_FacturacionXOC.DataBind()

        sds_TotalDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_TotalDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_TotalDeuda.DataBind()
        Dim dt_FacturacionProyectada As DataTable = CType(sds_TotalDeuda.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString()
        lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Deuda actual: </b>" + dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString() ''"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
        lbl_Proyeccion.Visible = True

        If gdv_FacturacionXOC.Rows.Count = 0 Then
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay facturas con el filtro seleccionado."
            gdv_FacturacionXOC.DataSource = Nothing
            gdv_FacturacionXOC.DataBind()

            txt_BuscarXFactura.Focus()
        Else
            pnl_mensaje.Visible = False
        End If
    End Sub

    Private Sub ddl_CCHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_CCHijo.SelectedIndexChanged
        Dim pvs_RutProveedor As String
        Dim PVI_EstadoFactura As Integer
        Dim PVI_CCPadre As Integer
        Dim PVI_CCHijo As Integer
        Dim pvi_Mes As Integer
        Dim pvi_Anho As Integer
        txt_BuscarXFactura.Text = ""

        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
        Else
            pvs_RutProveedor = "999"
        End If
        If ddl_EstadosFactura.SelectedIndex <> 0 Then
            PVI_EstadoFactura = ddl_EstadosFactura.SelectedValue
        Else
            PVI_EstadoFactura = 999
        End If
        If ddl_CCPadre.SelectedIndex <> 0 Then
            PVI_CCPadre = ddl_CCPadre.SelectedValue
        Else
            PVI_CCPadre = 999
        End If
        If ddl_CCHijo.SelectedIndex <> 0 Then
            PVI_CCHijo = ddl_CCHijo.SelectedValue
        Else
            PVI_CCHijo = 999
        End If
        If ddl_periodo.SelectedIndex <> 0 Then
            pvi_Mes = ddl_periodo.SelectedValue
        Else
            pvi_Mes = 999
        End If
        If DDL_ANHO.SelectedIndex <> 0 Then
            pvi_Anho = DDL_ANHO.SelectedValue
        Else
            pvi_Anho = 999
        End If


        sds_InformeDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_InformeDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_InformeDeuda.SelectParameters("id_CCGeneral").DefaultValue = PVI_CCPadre
        sds_InformeDeuda.SelectParameters("id_CCHijo").DefaultValue = PVI_CCHijo
        sds_InformeDeuda.SelectParameters("Mes").DefaultValue = pvi_Mes
        sds_InformeDeuda.SelectParameters("Anho").DefaultValue = pvi_Anho

        sds_InformeDeuda.DataBind()
        gdv_FacturacionXOC.DataSource = sds_InformeDeuda
        gdv_FacturacionXOC.DataBind()

        sds_TotalDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_TotalDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_TotalDeuda.DataBind()
        Dim dt_FacturacionProyectada As DataTable = CType(sds_TotalDeuda.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString()
        lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Deuda actual: </b>" + dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString() ''"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
        lbl_Proyeccion.Visible = True

        If gdv_FacturacionXOC.Rows.Count = 0 Then
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay facturas con el filtro seleccionado."
            gdv_FacturacionXOC.DataSource = Nothing
            gdv_FacturacionXOC.DataBind()

            txt_BuscarXFactura.Focus()
        Else
            pnl_mensaje.Visible = False
        End If
    End Sub

    Private Sub ddl_periodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_periodo.SelectedIndexChanged
        Dim pvs_RutProveedor As String
        Dim PVI_EstadoFactura As Integer
        Dim PVI_CCPadre As Integer
        Dim PVI_CCHijo As Integer
        Dim pvi_Mes As Integer
        Dim pvi_Anho As Integer
        txt_BuscarXFactura.Text = ""


        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
        Else
            pvs_RutProveedor = "999"
        End If
        If ddl_EstadosFactura.SelectedIndex <> 0 Then
            PVI_EstadoFactura = ddl_EstadosFactura.SelectedValue
        Else
            PVI_EstadoFactura = 999
        End If
        If ddl_CCPadre.SelectedIndex <> 0 Then
            PVI_CCPadre = ddl_CCPadre.SelectedValue
        Else
            PVI_CCPadre = 999
        End If
        If ddl_CCHijo.SelectedIndex <> 0 Then
            PVI_CCHijo = ddl_CCHijo.SelectedValue
        Else
            PVI_CCHijo = 999
        End If
        If ddl_periodo.SelectedIndex <> 0 Then
            pvi_Mes = ddl_periodo.SelectedValue
        Else
            pvi_Mes = 999
        End If
        If DDL_ANHO.SelectedIndex <> 0 Then
            pvi_Anho = DDL_ANHO.SelectedValue
        Else
            pvi_Anho = 999
        End If

        sds_InformeDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_InformeDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_InformeDeuda.SelectParameters("id_CCGeneral").DefaultValue = PVI_CCPadre
        sds_InformeDeuda.SelectParameters("id_CCHijo").DefaultValue = PVI_CCHijo
        sds_InformeDeuda.SelectParameters("Mes").DefaultValue = pvi_Mes
        sds_InformeDeuda.SelectParameters("Anho").DefaultValue = pvi_Anho
        sds_InformeDeuda.DataBind()
        gdv_FacturacionXOC.DataSource = sds_InformeDeuda
        gdv_FacturacionXOC.DataBind()

        sds_TotalDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_TotalDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_TotalDeuda.DataBind()
        Dim dt_FacturacionProyectada As DataTable = CType(sds_TotalDeuda.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString()
        lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Deuda actual: </b>" + dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString() ''"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
        lbl_Proyeccion.Visible = True

        If gdv_FacturacionXOC.Rows.Count = 0 Then
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay facturas con el filtro seleccionado."
            gdv_FacturacionXOC.DataSource = Nothing
            gdv_FacturacionXOC.DataBind()

            txt_BuscarXFactura.Focus()
        Else
            pnl_mensaje.Visible = False
        End If
    End Sub

    Private Sub DDL_ANHO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_ANHO.SelectedIndexChanged
        Dim pvs_RutProveedor As String
        Dim PVI_EstadoFactura As Integer
        Dim PVI_CCPadre As Integer
        Dim PVI_CCHijo As Integer
        Dim pvi_Mes As Integer
        Dim pvi_Anho As Integer
        txt_BuscarXFactura.Text = ""


        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
        Else
            pvs_RutProveedor = "999"
        End If
        If ddl_EstadosFactura.SelectedIndex <> 0 Then
            PVI_EstadoFactura = ddl_EstadosFactura.SelectedValue
        Else
            PVI_EstadoFactura = 999
        End If
        If ddl_CCPadre.SelectedIndex <> 0 Then
            PVI_CCPadre = ddl_CCPadre.SelectedValue
        Else
            PVI_CCPadre = 999
        End If
        If ddl_CCHijo.SelectedIndex <> 0 Then
            PVI_CCHijo = ddl_CCHijo.SelectedValue
        Else
            PVI_CCHijo = 999
        End If
        If ddl_periodo.SelectedIndex <> 0 Then
            pvi_Mes = ddl_periodo.SelectedValue
        Else
            pvi_Mes = 999
        End If
        If DDL_ANHO.SelectedIndex <> 0 Then
            pvi_Anho = DDL_ANHO.SelectedValue
        Else
            pvi_Anho = 999
        End If

        sds_InformeDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_InformeDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_InformeDeuda.SelectParameters("id_CCGeneral").DefaultValue = PVI_CCPadre
        sds_InformeDeuda.SelectParameters("id_CCHijo").DefaultValue = PVI_CCHijo
        sds_InformeDeuda.SelectParameters("Mes").DefaultValue = pvi_Mes
        sds_InformeDeuda.SelectParameters("Anho").DefaultValue = pvi_Anho
        sds_InformeDeuda.DataBind()
        gdv_FacturacionXOC.DataSource = sds_InformeDeuda
        gdv_FacturacionXOC.DataBind()

        sds_TotalDeuda.SelectParameters("id_Proveedor").DefaultValue = pvs_RutProveedor
        sds_TotalDeuda.SelectParameters("EstadoFactura").DefaultValue = PVI_EstadoFactura
        sds_TotalDeuda.DataBind()
        Dim dt_FacturacionProyectada As DataTable = CType(sds_TotalDeuda.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString()
        lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Deuda actual: </b>" + dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString() ''"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
        lbl_Proyeccion.Visible = True

        If gdv_FacturacionXOC.Rows.Count = 0 Then
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay facturas con el filtro seleccionado."
            gdv_FacturacionXOC.DataSource = Nothing
            gdv_FacturacionXOC.DataBind()

            txt_BuscarXFactura.Focus()
        Else
            pnl_mensaje.Visible = False
        End If
    End Sub

    Private Sub btn_LimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btn_LimpiarFiltros.Click
        ddl_NombreProveedor.SelectedIndex = -1
        ddl_CCPadre.SelectedIndex = -1
        ddl_CCHijo.SelectedIndex = -1
        ddl_periodo.SelectedIndex = -1
        ddl_EstadosFactura.SelectedIndex = -1
        txt_BuscarXFactura.Text = ""


        DDL_ANHO.SelectedValue = 2023

        sds_FacturacionXOC.SelectParameters("id_Proveedor").DefaultValue = "999"
        sds_FacturacionXOC.SelectParameters("EstadoFactura").DefaultValue = 1
        sds_InformeDeuda.SelectParameters("id_CCHijo").DefaultValue = 999
        sds_InformeDeuda.SelectParameters("Mes").DefaultValue = 999
        sds_InformeDeuda.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue

        sds_FacturacionXOC.DataBind()
        gdv_FacturacionXOC.DataSource = sds_FacturacionXOC
        gdv_FacturacionXOC.DataBind()

        txt_FechaPago.Text = Today()
        txt_FechaPago.Text = Replace(txt_FechaPago.Text, "-", "/")

        sds_TotalDeuda.SelectParameters("id_Proveedor").DefaultValue = "999"
        sds_TotalDeuda.SelectParameters("EstadoFactura").DefaultValue = 1
        sds_TotalDeuda.DataBind()
        Dim dt_FacturacionProyectada As DataTable = CType(sds_TotalDeuda.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString()
        lbl_Proyeccion.Text = "<b>Deuda actual: </b>" + dt_FacturacionProyectada.Rows(0).Item("ValorFactura").ToString() ''"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
        lbl_Proyeccion.Visible = True
    End Sub




#End Region

End Class