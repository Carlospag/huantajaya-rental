Public Class frm_Facturacion
    Inherits System.Web.UI.Page


#Region "INICIO"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If


            '''''PARA CARGAR LA GRILLA CON EL MES ACTUAL
            Dim FechaActual As Date = Today()
            Dim Mes As String
            Dim MesAux As Integer = Month(FechaActual)
            Dim Anho As Integer = Year(FechaActual)
            If MesAux < 10 Then
                Mes = "0" + MesAux.ToString()
            Else
                Mes = MesAux.ToString()
            End If

            sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = "999"
            sds_EstadosPago.SelectParameters("Periodo").DefaultValue = Mes
            sds_EstadosPago.SelectParameters("Anho").DefaultValue = Anho
            sds_EstadosPago.DataBind()

            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()

            '''''''''''''''''''''''''''''''''
            '''
            If Session("id_Usuario") = 2 Then
                btn_PagarFacturas.Enabled = False
            Else
                btn_PagarFacturas.Enabled = True
            End If

            Dim dt_FacturacionProyectada As DataTable = CType(sds_FacturacionProyectadaReal.Select(DataSourceSelectArguments.Empty), DataView).Table
            Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("FacturacionProyectadaReal").ToString()
            lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada Real: </b>" + Format(vls_Valor, "Currency").ToString()
            lbl_Proyeccion.Visible = True

            DDL_ANHO.SelectedValue = 2023

            txt_FechaPago.Text = Today()
            txt_FechaPago.Text = Replace(txt_FechaPago.Text, "-", "/")

            txt_FechaPagoTodos.Text = Today()
            txt_FechaPagoTodos.Text = Replace(txt_FechaPagoTodos.Text, "-", "/")

        End If

    End Sub

    Private Sub frm_EstadosDePago_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_periodo.Items.FindByText("Seleccionar periodo...") Is Nothing) Then
            ddl_periodo.Items.Insert(0, New ListItem("Seleccionar periodo...", "", True))

            ddl_periodo.SelectedIndex = 0
        End If

        If (ddl_Clientes.Items.FindByText("Seleccionar cliente...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("Seleccionar cliente...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If


    End Sub
#End Region

#Region "BOTONES"

    '' FILTRAR
    Private Sub btn_filtrar_Click(sender As Object, e As EventArgs) Handles btn_filtrar.Click
        txt_BuscarAfi.Text = ""
        Dim pvs_RutCliente, pvs_Periodo As String
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

        sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
        sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
        sds_EstadosPago.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
        sds_EstadosPago.DataBind()

        gdv_EstadosPago.DataSource = sds_EstadosPago
        gdv_EstadosPago.DataBind()

        If gdv_EstadosPago.Rows.Count > 0 Then
            pnl_mensaje.Visible = False
        Else
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No se han encontrado estados de pago facturados o pagados para su selección"
            gdv_EstadosPago.DataSource = Nothing
            gdv_EstadosPago.DataBind()
        End If

    End Sub
    '' ABRIR PARA  GUARDAR EL NUMERO DE ESTADO DE PAGO
    Protected Sub btn_Facturar_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim btn_PagoFactura As LinkButton = CType(sender, LinkButton)
        Dim pvi_idEstadoPago As Integer = btn_PagoFactura.CommandArgument
        lbl_NumeroEP.InnerText = pvi_idEstadoPago

        lbl_PagoFacturaERROR.Visible = False
        lbl_PagoFacturaEXITO.Visible = False

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_Aviso", "$('#mpe_Aviso').modal();", True)

    End Sub

    Protected Sub btn_Abonar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_ConfirmarAbono As LinkButton = CType(sender, LinkButton)
        Dim pvi_idEstadoPago As String = btn_ConfirmarAbono.CommandArgument

        lbl_NumeroEPAbono.InnerText = pvi_idEstadoPago

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_Abono", "$('#mpe_Abono').modal();", True)
        lbl_AbonoFacturaEXITOTodos.Visible = False
        lbl_AbonoFacturaERRORTodos.Visible = False
        lbl_AbonoFacturaEXITOTodos.InnerText = ""
        txt_ValorAbonado.Text = ""
    End Sub


    Private Sub btn_Confirmar_Click(sender As Object, e As EventArgs) Handles btn_Confirmar.Click

        Dim vlo_ActualizarEstadoDePago As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
        If (vlo_ActualizarEstadoDePago.fgb_ActualizarPagoFactura(lbl_NumeroEP.InnerText, txt_FechaPago.Text)) Then

            lbl_PagoFacturaEXITO.InnerText = "Pago registrado registrado con éxito."
            lbl_PagoFacturaEXITO.Visible = True
            lbl_PagoFacturaERROR.Visible = False

            Dim pvs_RutCliente, pvs_Periodo As String
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

            sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
            sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
            sds_EstadosPago.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
            sds_EstadosPago.DataBind()

            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()

            upp_ListaEstadosPago.Update()
        Else
            lbl_PagoFacturaERROR.InnerText = "Error al registrar Pago, Intente más tarde."
            lbl_PagoFacturaEXITO.Visible = False
            lbl_PagoFacturaERROR.Visible = True
        End If
        DDL_ANHO.SelectedValue = 2023
    End Sub

    Private Sub btn_BuscarPorAfi_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorAfi.Click
        If (txt_BuscarAfi.Text <> "") Then
            If IsNumeric(txt_BuscarAfi.Text) Then
                sds_EstadoPagoxFactura.SelectParameters("Factura").DefaultValue = txt_BuscarAfi.Text
                sds_EstadoPagoxFactura.DataBind()
                gdv_EstadosPago.DataSource = sds_EstadoPagoxFactura
                gdv_EstadosPago.DataBind()
                If gdv_EstadosPago.Rows.Count > 0 Then
                    pnl_mensaje.Visible = False
                Else
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay estados de pago Facturados o pagados para la factura ingresada"
                    gdv_EstadosPago.DataSource = Nothing
                    gdv_EstadosPago.DataBind()
                End If
            Else
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   Debe ingresar un valor numérico para realizar la búsqueda"
                gdv_EstadosPago.DataSource = Nothing
                gdv_EstadosPago.DataBind()
            End If
        Else

            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   Debe ingresar un N° de factura para realizar la búsqueda"
            gdv_EstadosPago.DataSource = Nothing
            gdv_EstadosPago.DataBind()

        End If
        ddl_Clientes.SelectedIndex = -1
        ddl_periodo.SelectedIndex = -1
        DDL_ANHO.SelectedValue = 2020
        txt_BuscarAfi.Text = ""
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ddl_Clientes.SelectedIndex = -1
        ddl_periodo.SelectedIndex = -1
        DDL_ANHO.SelectedValue = 2020
        txt_BuscarAfi.Text = ""
    End Sub

    Private Sub btn_PagarFacturas_Click(sender As Object, e As EventArgs) Handles btn_PagarFacturas.Click

        lbl_PagoFacturaERRORTodos.Visible = False
        lbl_PagoFacturaEXITOTodos.Visible = False
        txt_FechaPagoTodos.Text = Today()
        txt_FechaPagoTodos.Text = Replace(txt_FechaPagoTodos.Text, "-", "/")
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_ConfirmarPagoTodos", "$('#mpe_ConfirmarPagoTodos').modal();", True)

        upp_Aviso.Update()
    End Sub

    Private Sub btn_ConfirmarPagoTodasFacturas_Click(sender As Object, e As EventArgs) Handles btn_ConfirmarPagoTodasFacturas.Click
        Dim vlo_ActualizarEstadoDePago As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
        If (vlo_ActualizarEstadoDePago.fgb_ActualizarPagoFacturaTodos(txt_FacturaAPagar.Text, txt_FechaPagoTodos.Text)) Then

            lbl_PagoFacturaEXITOTodos.InnerText = "Pago registrado con éxito."
            lbl_PagoFacturaEXITOTodos.Visible = True
            lbl_PagoFacturaERRORTodos.Visible = False

            Dim pvs_RutCliente, pvs_Periodo As String
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

            sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
            sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
            sds_EstadosPago.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
            sds_EstadosPago.DataBind()

            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()

            upp_ListaEstadosPago.Update()
        Else
            lbl_PagoFacturaERRORTodos.InnerText = "Error al registrar Pago, Intente más tarde."
            lbl_PagoFacturaEXITOTodos.Visible = False
            lbl_PagoFacturaERRORTodos.Visible = True
        End If
    End Sub


    Private Sub btn_ConfirmarAbono_Click(sender As Object, e As EventArgs) Handles btn_ConfirmarAbono.Click
        Dim vlo_ActualizarEstadoDePago As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago


        Dim pvi_idEstadoDePago As Integer = lbl_NumeroEPAbono.InnerText


        If txt_ValorAbonado.Text <> "" And IsNumeric(txt_ValorAbonado.Text) Then
            Dim pvi_ValorAbono As Integer = Convert.ToInt64(txt_ValorAbonado.Text)

            If (vlo_ActualizarEstadoDePago.fgb_ActualizarAbonoFactura(pvi_idEstadoDePago, pvi_ValorAbono)) Then

                lbl_AbonoFacturaEXITOTodos.InnerText = "Abono registrado con éxito."
                lbl_AbonoFacturaEXITOTodos.Visible = True
                lbl_AbonoFacturaERRORTodos.Visible = False

                Dim pvs_RutCliente, pvs_Periodo As String
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

                sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
                sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
                sds_EstadosPago.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
                sds_EstadosPago.DataBind()

                gdv_EstadosPago.DataSource = sds_EstadosPago
                gdv_EstadosPago.DataBind()

                upp_ListaEstadosPago.Update()

                txt_ValorAbonado.Text = ""

            Else
                lbl_AbonoFacturaERRORTodos.InnerText = "Error al registrar el abono, Intente más tarde."
                lbl_AbonoFacturaEXITOTodos.Visible = False
                lbl_AbonoFacturaERRORTodos.Visible = True
            End If
        Else
            lbl_AbonoFacturaERRORTodos.InnerText = "El valor ingresado no es númerico."
            lbl_AbonoFacturaEXITOTodos.Visible = False
            lbl_AbonoFacturaERRORTodos.Visible = True
        End If



    End Sub
    ''ABRIR NUEVO ESTADO DE PAGO




    '' CONFIRMAR EP
    'Protected Sub btn_ConfirmarEP_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim btn_ConfirmarEP As LinkButton = CType(sender, LinkButton)
    '    Dim pvi_idEstadoPago As Integer = btn_ConfirmarEP.CommandArgument
    '    Dim pvi_EstadoComercial As Integer = 1 '(1) Confirmado, (2) Pendiente, (3) Facturado, (4) Anulado

    '    Dim vlo_ActualizarEP As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
    '    If (vlo_ActualizarEP.fgb_ConfirmarAnularEP(pvi_idEstadoPago,
    '                                          pvi_EstadoComercial)) Then

    '        Dim pvs_RutCliente, pvs_Periodo As String
    '        If ddl_Clientes.SelectedIndex = 0 Then
    '            pvs_RutCliente = "999"
    '        Else
    '            pvs_RutCliente = ddl_Clientes.SelectedValue
    '        End If

    '        If ddl_periodo.SelectedIndex = 0 Then
    '            pvs_Periodo = "999"
    '        Else
    '            pvs_Periodo = ddl_periodo.SelectedValue
    '        End If

    '        sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
    '        sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
    '        sds_EstadosPago.DataBind()

    '        gdv_EstadosPago.DataSource = sds_EstadosPago
    '        gdv_EstadosPago.DataBind()

    '        upp_ListaEstadosPago.Update()
    '    Else
    '        'MENSAJE DE ERROR
    '    End If



    'End Sub
    '' ELIMINAR EP
    'Protected Sub btn_EliminarEP_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim btn_EliminarEP As LinkButton = CType(sender, LinkButton)
    '    Dim pvi_idEstadoPago As Integer = btn_EliminarEP.CommandArgument
    '    Dim pvi_EstadoComercial As Integer = 4 '(1) Confirmado, (2) Pendiente, (3) Facturado, (4) Anulado

    '    Dim vlo_ActualizarEP As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
    '    If (vlo_ActualizarEP.fgb_ConfirmarAnularEP(pvi_idEstadoPago,
    '                                          pvi_EstadoComercial)) Then

    '        Dim pvs_RutCliente, pvs_Periodo As String
    '        If ddl_Clientes.SelectedIndex = 0 Then
    '            pvs_RutCliente = "999"
    '        Else
    '            pvs_RutCliente = ddl_Clientes.SelectedValue
    '        End If

    '        If ddl_periodo.SelectedIndex = 0 Then
    '            pvs_Periodo = "999"
    '        Else
    '            pvs_Periodo = ddl_periodo.SelectedValue
    '        End If

    '        sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
    '        sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
    '        sds_EstadosPago.DataBind()

    '        gdv_EstadosPago.DataSource = sds_EstadosPago
    '        gdv_EstadosPago.DataBind()

    '        upp_ListaEstadosPago.Update()
    '    Else
    '        'MENSAJE DE ERROR
    '    End If

    'End Sub
    '' DESCARGAR EP
    'Protected Sub btn_DescargarEP_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim btn_DescargarEP As LinkButton = CType(sender, LinkButton)
    '    Try

    '        Dim vli_id_EstadoPago As Integer = btn_DescargarEP.CommandArgument


    '        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?id=" & vli_id_EstadoPago & "&tiporeporte=1" & "','_newtab');", True)

    '    Catch ex As Exception

    '    End Try
    'End Sub


#End Region




End Class