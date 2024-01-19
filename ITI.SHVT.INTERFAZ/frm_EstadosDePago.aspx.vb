Public Class frm_EstadosDePago
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
            sds_EstadosPago.SelectParameters("Sucursal").DefaultValue = "999"
            sds_EstadosPago.DataBind()

            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()
            '''''''''''''''''''''''''''''''''

            btn_DescargarSeleccion.Visible = False

            DDL_ANHO.SelectedValue = 2023

            sds_EDPproyectado.SelectParameters("RutCliente").DefaultValue = "999"
            sds_EDPproyectado.SelectParameters("Periodo").DefaultValue = Mes
            sds_EDPproyectado.SelectParameters("Anho").DefaultValue = Anho
            sds_EDPproyectado.SelectParameters("Sucursal").DefaultValue = "999"
            sds_EDPproyectado.DataBind()




            Dim dt_EDPProyectadO As DataTable = CType(sds_EDPproyectado.Select(DataSourceSelectArguments.Empty), DataView).Table
            Dim vls_Valor As String = dt_EDPProyectadO.Rows(0).Item("Total").ToString()
            lbl_ProyeccionEDP.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Estados de pago proyectados: </b>" + Format(vls_Valor, "Currency").ToString()
            lbl_ProyeccionEDP.Visible = True
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

        If (ddl_ModoCobroEP.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_ModoCobroEP.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_ModoCobroEP.SelectedIndex = 0
        End If

        If (ddl_ClienteNuevo.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_ClienteNuevo.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_ClienteNuevo.SelectedIndex = 0
        End If
        If (ddl_TipoEPnuevo.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_TipoEPnuevo.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_TipoEPnuevo.SelectedIndex = 0
        End If
        If (ddl_SucursalesFiltro.Items.FindByText("Todas...") Is Nothing) Then
            ddl_SucursalesFiltro.Items.Insert(0, New ListItem("Todas...", "", True))

            ddl_SucursalesFiltro.SelectedIndex = 0
        End If

    End Sub
#End Region

#Region "BOTONES"
    '' ABRE EL EDITOR
    Protected Sub btn_ModificarEP_Click(ByVal sender As Object, ByVal e As EventArgs)

        btn_ModificarEstadoPago.Visible = True
        btn_GuardarEP.Visible = False

        Dim btn_ModificarEP As LinkButton = CType(sender, LinkButton)
        Dim pvi_idEstadoPago As Integer = btn_ModificarEP.CommandArgument

        sds_EstadoPAgoXID.SelectParameters("id_EstadoPago").DefaultValue = pvi_idEstadoPago
        sds_EstadoPAgoXID.DataBind()


        'Carga de SDS a DataTable

        Dim dt_EstadoPago As DataTable = CType(sds_EstadoPAgoXID.Select(DataSourceSelectArguments.Empty), DataView).Table
        lbl_idContratoEP.InnerText = dt_EstadoPago.Rows(0).Item("id_Contrato").ToString()
        lbl_NumeroEP.InnerText = pvi_idEstadoPago.ToString()
        lbl_NombreEquipoEP.InnerText = dt_EstadoPago.Rows(0).Item("NombreEquipo").ToString()
        lbl_ModeloEquipoEP.InnerText = dt_EstadoPago.Rows(0).Item("ModeloEquipo").ToString()
        lbl_AfiEP.InnerText = dt_EstadoPago.Rows(0).Item("id_Equipo").ToString()
        lbl_FaenaEP.InnerText = dt_EstadoPago.Rows(0).Item("Faena").ToString()
        lbl_TipoEP.InnerText = dt_EstadoPago.Rows(0).Item("TipoEP").ToString()

        txt_Fecha_InicioEP.Text = dt_EstadoPago.Rows(0).Item("FechaInicio").ToString()
        txt_Fecha_FinEP.Text = dt_EstadoPago.Rows(0).Item("FechaFin").ToString()
        'Dim vld_FechaConGuion As String = DateSerial(Year(txt_Fecha_InicioEP.Text), Month(txt_Fecha_InicioEP.Text) + 1, 0)
        'txt_Fecha_FinEP.Text = Replace(vld_FechaConGuion, "-", "/")

        txt_DiasFacturarEP.Text = dt_EstadoPago.Rows(0).Item("DiasFacturar")
        txt_TarifaEP.Text = dt_EstadoPago.Rows(0).Item("Tarifa")
        txt_Observaciones.InnerText = dt_EstadoPago.Rows(0).Item("Observaciones")
        ddl_SucursalEditarEDP.SelectedValue = dt_EstadoPago.Rows(0).Item("Sucursal")

        If lbl_idContratoEP.InnerText = "N/A" Then
            txt_HorasFacturarEP.ReadOnly = True
            txt_DiasFacturarEP.ReadOnly = True
            txt_DiasFacturarEP.ReadOnly = True
            txt_Fecha_FinEP.Visible = False
            lbl_fechaFin.Visible = False
            btn_CalcularDias.Enabled = False
            ddl_ModoCobroEP.Enabled = False
            ddl_SucursalEditarEDP.Visible = True
            lbl_SucursalEditarEDP.Visible = True

        Else
            txt_HorasFacturarEP.ReadOnly = False
            txt_DiasFacturarEP.ReadOnly = False
            txt_DiasFacturarEP.ReadOnly = False
            txt_Fecha_FinEP.Visible = True
            lbl_fechaFin.Visible = True
            btn_CalcularDias.Enabled = True
            ddl_ModoCobroEP.Enabled = True
            ddl_SucursalEditarEDP.Visible = False
            lbl_SucursalEditarEDP.Visible = False
        End If

        Dim FechaActual As Date = txt_Fecha_InicioEP.Text
        If dt_EstadoPago.Rows(0).Item("Tipounidad").ToString() = 1 Then
            ddl_ModoCobroEP.SelectedValue = 1 'MENSUAL
            Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))
            Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
            Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)
            txt_ValorNetoEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes), "Currency").ToString()
            txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
            txt_ValorTotalEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) + Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
        ElseIf dt_EstadoPago.Rows(0).Item("Tipounidad").ToString() = 2 Then ' DIARIO
            ddl_ModoCobroEP.SelectedValue = 2
            Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))
            Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
            Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)
            txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar), "Currency").ToString()
            txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
            txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
        Else
            ddl_ModoCobroEP.SelectedValue = 3
            Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
            txt_HorasFacturarEP.Text = dt_EstadoPago.Rows(0).Item("HorasFacturar")
            Dim vli_HorasFacturar As Integer = Convert.ToInt64(txt_HorasFacturarEP.Text)

            txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar), "Currency").ToString()
            txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
            txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()

        End If

        lbl_Actualizado.Visible = False
        lbl_ActualizadoError.Visible = False
        upp_modalEstadoPago.Update()
        btn_ModificarEstadoPago.Visible = True
        btn_GuardarEP.Visible = False
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerEstadosPago", "$('#mpe_VerEstadosPago').modal();", True)


    End Sub
    '' Actualiza en BD
    Protected Sub btn_ModificarEstadoPago_Click(sender As Object, e As EventArgs) Handles btn_ModificarEstadoPago.Click
        Dim pvi_HorasFacturar As Integer
        Dim pvi_DiasFacturar As Integer

        Dim pvi_idEstadoPago As Integer = Convert.ToInt64(lbl_NumeroEP.InnerText)
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvi_EstadoComercial As Integer = 2 ' (1) Confirmado, (2) Pendiente, (3) Facturado, (4) Anulado , (5) No Pagado
        Dim pvi_CorrelativoEP As Integer = 1 ' Seleccionar el ultimo EP de ese cliente
        Dim pvd_FechaInicioEP As Date = txt_Fecha_InicioEP.Text
        Dim pvd_FechaFinEP As Date = txt_Fecha_FinEP.Text
        Dim pvi_Contrato As Integer
        Dim pvi_TipoEPago As Integer
        Dim pvi_Tarifa As Integer = Convert.ToInt64(txt_TarifaEP.Text)
        Dim pvi_AfiVentaCobro As Integer
        Dim pvi_Sucursal As Integer = 999

        If lbl_idContratoEP.InnerText = "N/A" Then 'Si el valor a actualizar es N/A implica que es un cobro o venta y no un arriendo
            pvi_Contrato = 999
            pvd_FechaFinEP = pvd_FechaInicioEP
            pvi_AfiVentaCobro = lbl_AfiEP.InnerText
            pvi_Sucursal = ddl_SucursalEditarEDP.SelectedValue

            If lbl_TipoEP.InnerText = "Servicio Técnico" Then
                pvi_TipoEPago = 2
            Else
                pvi_TipoEPago = 3
            End If
        Else
            pvi_AfiVentaCobro = 999
            pvi_TipoEPago = 1
            pvi_Contrato = Convert.ToInt64(lbl_idContratoEP.InnerText)
        End If



        If txt_HorasFacturarEP.Text = "" Then
            pvi_HorasFacturar = 999
        Else
            pvi_HorasFacturar = txt_HorasFacturarEP.Text
        End If

        If txt_DiasFacturarEP.Text = "" Then
            pvi_DiasFacturar = 999
        Else
            pvi_DiasFacturar = txt_DiasFacturarEP.Text
        End If

        Dim vli_ValorNetoSinFormato As String = Replace(txt_ValorNetoEP.Text, "$", "")
        Dim pvi_ValorNeto As String = Replace(vli_ValorNetoSinFormato, ".", "")
        Dim pvs_Observaciones As String = txt_Observaciones.InnerText
        Dim pvi_TipoUnidad As Integer = ddl_ModoCobroEP.SelectedValue

        Dim vlo_ActualizarEstadoDePago As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
        If (vlo_ActualizarEstadoDePago.fgb_ActualizarEstadoDePago(pvi_idEstadoPago,
                                                                  pvi_EstadoComercial,
                                                                  pvi_CorrelativoEP,
                                                                  pvd_FechaInicioEP,
                                                                  pvd_FechaFinEP,
                                                                  pvi_Contrato,
                                                                  pvi_TipoUnidad,
                                                                  pvi_Tarifa,
                                                                  pvi_DiasFacturar,
                                                                  pvi_ValorNeto,
                                                                  pvi_HorasFacturar,
                                                                  pvs_Observaciones,
                                                                  pvi_idUsuario,
                                                                  pvi_TipoEPago,
                                                                  pvi_AfiVentaCobro,
                                                                  pvi_Sucursal)) Then


            'pnl_Agregado.Visible = True ''''' CREADO CON ÉXITO

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
            sds_EstadosPago.DataBind()

            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()

            upp_ListaEstadosPago.Update()
            lbl_Actualizado.InnerText = "Estado de pago actualizado con éxito."
            lbl_Actualizado.Visible = True

        Else
            lbl_ActualizadoError.InnerText = "Error al actualizar el estado de pago, intente más tarde."
            lbl_ActualizadoError.Visible = True
        End If
    End Sub

    '' FILTRAR
    Private Sub btn_filtrar_Click(sender As Object, e As EventArgs) Handles btn_filtrar.Click
        txt_BuscarAfi.Text = ""
        Dim pvs_RutCliente, pvs_Periodo, pvs_Sucursal As String
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

        If ddl_SucursalesFiltro.SelectedIndex = 0 Then
            pvs_Sucursal = "999"
        Else
            pvs_Sucursal = ddl_SucursalesFiltro.SelectedValue
        End If


        sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
        sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
        sds_EstadosPago.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
        sds_EstadosPago.SelectParameters("Sucursal").DefaultValue = pvs_Sucursal
        sds_EstadosPago.DataBind()

        gdv_EstadosPago.DataSource = sds_EstadosPago
        gdv_EstadosPago.DataBind()

        If gdv_EstadosPago.Rows.Count > 0 Then
            pnl_mensaje.Visible = False
        Else
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No se han encontrado estados de pago para su selección"
            gdv_EstadosPago.DataSource = Nothing
            gdv_EstadosPago.DataBind()
        End If

        If ddl_Clientes.SelectedIndex = 0 Or ddl_periodo.SelectedIndex = 0 Then
            btn_DescargarSeleccion.Visible = False

        Else
            btn_DescargarSeleccion.Visible = True
        End If


        sds_EDPproyectado.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
        sds_EDPproyectado.SelectParameters("Periodo").DefaultValue = pvs_Periodo
        sds_EDPproyectado.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
        sds_EDPproyectado.SelectParameters("Sucursal").DefaultValue = pvs_Sucursal
        sds_EDPproyectado.DataBind()




        Dim dt_EDPProyectadO As DataTable = CType(sds_EDPproyectado.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_Valor As String = dt_EDPProyectadO.Rows(0).Item("Total").ToString()
        lbl_ProyeccionEDP.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Estados de pagos proyectados: </b>" + Format(vls_Valor, "Currency").ToString()
        lbl_ProyeccionEDP.Visible = True
    End Sub
    '' ABRIR PARA  GUARDAR EL NUMERO DE ESTADO DE PAGO
    Protected Sub btn_Facturar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_Facturar As LinkButton = CType(sender, LinkButton)
        Dim pvi_idEstadoPago As Integer = btn_Facturar.CommandArgument

        sds_EstadoPAgoXID.SelectParameters("id_EstadoPago").DefaultValue = pvi_idEstadoPago
        sds_EstadoPAgoXID.DataBind()
        Dim dt_EstadoPago As DataTable = CType(sds_EstadoPAgoXID.Select(DataSourceSelectArguments.Empty), DataView).Table
        lbl_NEP.InnerText = pvi_idEstadoPago.ToString()
        lbl_TipoEstadoDePago.InnerText = dt_EstadoPago.Rows(0).Item("TipoEP").ToString()

        lbl_NumeroFacturaERROR.Visible = False
        lbl_NumeroFacturaEXITO.Visible = False
        txt_FechaFacturacion.Text = ""
        txt_NFactura.Text = ""

        upp_nfactura.Update()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_NFactura", "$('#mpe_NFactura').modal();", True)
    End Sub
    ''ABRIR NUEVO ESTADO DE PAGO
    Private Sub btn_Nuevo_Click(sender As Object, e As EventArgs) Handles btn_Nuevo.Click
        ddl_TipoEPnuevo.SelectedIndex = -1
        ddl_ClienteNuevo.SelectedIndex = -1
        txt_AFInuevo.Text = ""
        txt_TarifaEPnuevo.Text = ""
        txt_FechaEPnuevo.Text = ""
        txt_Fecha_FinEP.Text = ""
        txt_NETOEPnuevo.Text = ""
        txt_IVAEPnuevo.Text = ""
        txt_TOTALnuevo.Text = ""
        txt_ObservacionesNuevo.InnerText = ""
        lbl_ErrorGuardarNuevoEP.Visible = False
        lbl_ExitoGuardarNuevoEP.Visible = False

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_NuevoEP", "$('#mpe_NuevoEP').modal();", True)
    End Sub
    '' GUARDAR NUEVO ESTADO DE PAGO
    Private Sub btn_GuardarEPnuevo_Click(sender As Object, e As EventArgs) Handles btn_GuardarEPnuevo.Click
        Dim pvi_HorasFacturar As Integer = 999
        Dim pvi_DiasFacturar As Integer = 999

        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvi_EstadoComercial As Integer = 2 ' (1) Confirmado, (2) Pendiente, (3) Facturado, (4) Anulado (5) Pagado
        Dim pvi_CorrelativoEP As Integer = 1 ' Seleccionar el ultimo EP de ese cliente
        Dim pvd_FechaInicioEP As Date = txt_FechaEPnuevo.Text
        Dim pvd_FechaFinEP As Date = txt_FechaEPnuevo.Text
        Dim pvi_Contrato As Integer = 0
        Dim pvi_TipoPago As Integer = 0
        Dim pvi_Tarifa As Integer = Convert.ToInt64(txt_TarifaEPnuevo.Text)
        Dim pvi_TipoEstadoPago As Integer = ddl_TipoEPnuevo.SelectedValue
        Dim PVS_Cliente As String = ddl_ClienteNuevo.SelectedValue
        Dim pvi_AFI As Integer = txt_AFInuevo.Text

        Dim vli_ValorNetoSinFormato As String = Replace(txt_NETOEPnuevo.Text, "$", "")
        Dim pvi_ValorNeto As String = Replace(vli_ValorNetoSinFormato, ".", "")
        Dim pvs_Observaciones As String = txt_ObservacionesNuevo.InnerText
        Dim pvi_TipoUnidad As Integer = 2 'Diario
        Dim pvi_Sucursal As Integer = ddl_SucursalEDPnuevo.SelectedValue
        Dim vlo_RegistrarEstadoDePago As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago

        If (vlo_RegistrarEstadoDePago.fgb_RegistrarEstadoDePago(pvi_EstadoComercial,
                                                                pvi_CorrelativoEP,
                                                                pvd_FechaInicioEP,
                                                                pvd_FechaFinEP,
                                                                pvi_Contrato,
                                                                pvi_TipoUnidad,
                                                                pvi_Tarifa,
                                                                pvi_DiasFacturar,
                                                                pvi_ValorNeto,
                                                                pvi_HorasFacturar,
                                                                pvs_Observaciones,
                                                                pvi_idUsuario,
                                                                pvi_TipoEstadoPago,
                                                                pvi_AFI,
                                                                PVS_Cliente,
                                                                pvi_Sucursal)) Then


            lbl_ExitoGuardarNuevoEP.InnerText = "¡ Estado de pago guardado con éxito !"
            lbl_ExitoGuardarNuevoEP.Visible = True
            lbl_ErrorGuardarNuevoEP.Visible = False

            Dim pvs_RutCliente, pvs_Periodo, pvs_Sucursal As String
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

            If ddl_SucursalesFiltro.SelectedIndex = 0 Then
                pvs_Sucursal = "999"
            Else
                pvs_Sucursal = ddl_SucursalesFiltro.SelectedValue
            End If

            sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
            sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
            sds_EstadosPago.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
            sds_EstadosPago.SelectParameters("Sucursal").DefaultValue = pvs_Sucursal
            sds_EstadosPago.DataBind()

            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()

            upp_ListaEstadosPago.Update()
        Else
            lbl_ExitoGuardarNuevoEP.InnerText = "¡ Error - No logramos guardar el estado de pago, intente más tarde"
            lbl_ExitoGuardarNuevoEP.Visible = False
            lbl_ErrorGuardarNuevoEP.Visible = True
        End If
    End Sub
    '' GUARDAR NUMERO DE FACTURA

    Private Sub btn_GuardarNFactura_Click(sender As Object, e As EventArgs) Handles btn_GuardarNFactura.Click

        If (txt_NFactura.Text <> "") Then
            If IsNumeric(txt_NFactura.Text) Then
                Dim pvi_NumeroEPFacturar As Integer = Convert.ToUInt64(lbl_NEP.InnerText)
                Dim pvs_NumeroFactura As Integer = Convert.ToInt64(txt_NFactura.Text)
                Dim pvi_SucursalFactura As Integer = ddl_Sucursal.SelectedValue

                Dim vlo_ActualizarEstadoDePago As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
                If (vlo_ActualizarEstadoDePago.fgb_ActualizarNumeroFactura(pvi_NumeroEPFacturar,
                                                                            pvs_NumeroFactura,
                                                                            txt_FechaFacturacion.Text, pvi_SucursalFactura)) Then

                    txt_NFactura.Text = ""
                    txt_FechaFacturacion.Text = ""

                    lbl_NumeroFacturaEXITO.InnerText = "¡ Número factura registrado con éxito !"
                    lbl_NumeroFacturaEXITO.Visible = True
                    lbl_NumeroFacturaERROR.Visible = False

                    Dim pvs_RutCliente, pvs_Periodo, pvs_Sucursal As String
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

                    If ddl_SucursalesFiltro.SelectedIndex = 0 Then
                        pvs_Sucursal = "999"
                    Else
                        pvs_Sucursal = ddl_SucursalesFiltro.SelectedValue
                    End If

                    sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
                    sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
                    sds_EstadosPago.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
                    sds_EstadosPago.SelectParameters("Sucursal").DefaultValue = pvs_Sucursal
                    sds_EstadosPago.DataBind()

                    gdv_EstadosPago.DataSource = sds_EstadosPago
                    gdv_EstadosPago.DataBind()

                    upp_ListaEstadosPago.Update()

                Else
                    lbl_NumeroFacturaERROR.InnerText = "Error - Intente más tarde"
                    lbl_NumeroFacturaERROR.Visible = True
                    lbl_NumeroFacturaEXITO.Visible = True
                End If
            Else
                lbl_NumeroFacturaERROR.InnerText = "Error - Debe ingresar un valor númerico"
                lbl_NumeroFacturaERROR.Visible = True
                lbl_NumeroFacturaEXITO.Visible = True
            End If
        Else
            lbl_NumeroFacturaERROR.InnerText = "Error - Favor ingresar número de factura"
            lbl_NumeroFacturaERROR.Visible = True
            lbl_NumeroFacturaEXITO.Visible = False
        End If
    End Sub

    '' Limpiar EP NUEVO
    Private Sub btn_LimpiarEPnuevo_Click(sender As Object, e As EventArgs) Handles btn_LimpiarEPnuevo.Click
        ddl_TipoEPnuevo.SelectedIndex = -1
        ddl_ClienteNuevo.SelectedIndex = -1
        txt_AFInuevo.Text = ""
        txt_TarifaEPnuevo.Text = ""
        txt_FechaEPnuevo.Text = ""
        txt_Fecha_FinEP.Text = ""
        txt_NETOEPnuevo.Text = ""
        txt_IVAEPnuevo.Text = ""
        txt_TOTALnuevo.Text = ""
        txt_ObservacionesNuevo.InnerText = ""
    End Sub
    '' LIMPIAR ESTADO DE PAGO
    Private Sub btn_LimpiarEP_Click(sender As Object, e As EventArgs) Handles btn_LimpiarEP.Click
        If lbl_idContratoEP.InnerText = "N/A" Then
            txt_TarifaEP.Text = ""
            txt_Observaciones.InnerText = ""
            txt_ivaEP.Text = ""
            txt_ValorNetoEP.Text = ""
            txt_ValorTotalEP.Text = ""
            txt_HorasFacturarEP.Text = ""
            txt_Fecha_InicioEP.Text = ""
            txt_Fecha_FinEP.Text = ""
            ddl_ModoCobroEP.SelectedIndex = 2

        Else
            txt_TarifaEP.Text = ""
            txt_Observaciones.InnerText = ""
            txt_ivaEP.Text = ""
            txt_ValorNetoEP.Text = ""
            txt_ValorTotalEP.Text = ""
            txt_HorasFacturarEP.Text = ""
            txt_DiasFacturarEP.Text = ""
            txt_Fecha_InicioEP.Text = ""
            txt_Fecha_FinEP.Text = ""
            ddl_ModoCobroEP.SelectedIndex = -1
        End If


    End Sub

    '' CONFIRMAR EP
    Protected Sub btn_ConfirmarEP_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_ConfirmarEP As LinkButton = CType(sender, LinkButton)
        Dim pvi_idEstadoPago As Integer = btn_ConfirmarEP.CommandArgument
        Dim pvi_EstadoComercial As Integer = 1 '(1) Confirmado, (2) Pendiente, (3) Facturado, (4) Anulado

        Dim vlo_ActualizarEP As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
        If (vlo_ActualizarEP.fgb_ConfirmarAnularEP(pvi_idEstadoPago,
                                              pvi_EstadoComercial)) Then

            Dim pvs_RutCliente, pvs_Periodo, pvs_Sucursal As String
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

            If ddl_SucursalesFiltro.SelectedIndex = 0 Then
                pvs_Sucursal = "999"
            Else
                pvs_Sucursal = ddl_SucursalesFiltro.SelectedValue
            End If

            sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
            sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
            sds_EstadosPago.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
            sds_EstadosPago.SelectParameters("Sucursal").DefaultValue = pvs_Sucursal
            sds_EstadosPago.DataBind()

            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()

            upp_ListaEstadosPago.Update()
        Else
            'MENSAJE DE ERROR
        End If



    End Sub
    '' ELIMINAR EP
    Protected Sub btn_EliminarEP_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_EliminarEP As LinkButton = CType(sender, LinkButton)
        Dim pvi_idEstadoPago As Integer = btn_EliminarEP.CommandArgument
        Dim pvi_EstadoComercial As Integer = 4 '(1) Confirmado, (2) Pendiente, (3) Facturado, (4) Anulado

        Dim vlo_ActualizarEP As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
        If (vlo_ActualizarEP.fgb_ConfirmarAnularEP(pvi_idEstadoPago,
                                              pvi_EstadoComercial)) Then

            Dim pvs_RutCliente, pvs_Periodo, pvs_Sucursal As String
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

            If ddl_SucursalesFiltro.SelectedIndex = 0 Then
                pvs_Sucursal = "999"
            Else
                pvs_Sucursal = ddl_SucursalesFiltro.SelectedValue
            End If

            sds_EstadosPago.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
            sds_EstadosPago.SelectParameters("Periodo").DefaultValue = pvs_Periodo
            sds_EstadosPago.SelectParameters("Anho").DefaultValue = DDL_ANHO.SelectedValue
            sds_EstadosPago.SelectParameters("Sucursal").DefaultValue = pvs_Sucursal
            sds_EstadosPago.DataBind()

            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()

            upp_ListaEstadosPago.Update()
        Else
            'MENSAJE DE ERROR
        End If



    End Sub
    '' DESCARGAR EP
    Protected Sub btn_DescargarEP_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_DescargarEP As LinkButton = CType(sender, LinkButton)
        Try

            Dim vli_id_EstadoPago As Integer = btn_DescargarEP.CommandArgument


            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?id=" & vli_id_EstadoPago & "&tiporeporte=1" & "','_newtab');", True)
            'Response.Redirect("frm_reportes.aspx?id=" & vli_id_EstadoPago & "&tiporeporte=1", False)
            'Context.ApplicationInstance.CompleteRequest()
        Catch ex As Exception

        End Try
    End Sub



#End Region

#Region "DROPDOWNLIST"
    Protected Sub ddl_ModoCobroEP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_ModoCobroEP.SelectedIndexChanged
        ''''CALCULO
        Dim FechaActual As Date = txt_Fecha_InicioEP.Text
        Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))

        If ddl_ModoCobroEP.SelectedIndex <> 0 And txt_TarifaEP.Text <> "" And IsNumeric(txt_TarifaEP.Text) Then

            If ddl_ModoCobroEP.SelectedValue = 1 Then 'COBRO MENSUAL
                If txt_DiasFacturarEP.Text <> "" And IsNumeric(txt_DiasFacturarEP.Text) Then
                    Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                    Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)

                    txt_ValorNetoEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes), "Currency").ToString()
                    txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                    txt_ValorTotalEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) + Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                Else
                    txt_ValorNetoEP.Text = ""
                    txt_ivaEP.Text = ""
                    txt_ValorTotalEP.Text = ""
                End If


            ElseIf ddl_ModoCobroEP.SelectedValue = 2 Then 'COBRO DIARIO
                If txt_DiasFacturarEP.Text <> "" And IsNumeric(txt_DiasFacturarEP.Text) Then
                    Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                    Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)

                    txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar), "Currency").ToString()
                    txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                    txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                Else
                    txt_ValorNetoEP.Text = ""
                    txt_ivaEP.Text = ""
                    txt_ValorTotalEP.Text = ""
                End If

            Else ' COBRO PROPORCIONAL (HORAS)
                If txt_HorasFacturarEP.Text <> "" And IsNumeric(txt_HorasFacturarEP.Text) Then
                    Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                    Dim vli_HorasFacturar As Integer = Convert.ToInt32(txt_HorasFacturarEP.Text)

                    txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar), "Currency").ToString()
                    txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                    txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                Else
                    txt_ValorNetoEP.Text = ""
                    txt_ivaEP.Text = ""
                    txt_ValorTotalEP.Text = ""
                End If
            End If
        Else
            txt_ValorNetoEP.Text = ""
            txt_ivaEP.Text = ""
            txt_ValorTotalEP.Text = ""
        End If
        ''''FIN CALCULO

    End Sub
#End Region

#Region "TEXTCHANGED"
    '' TEXTCHANGED "VALOR NETO"
    Protected Sub txt_ValorNetoEP_TextChanged(sender As Object, e As EventArgs) Handles txt_ValorNetoEP.TextChanged
        If txt_ValorNetoEP.Text <> "" Then
            If IsNumeric(txt_ValorNetoEP.Text) Then
                txt_ValorTotalEP.Text = Convert.ToInt64(txt_ValorNetoEP.Text) * 0.19
            Else
                txt_ValorNetoEP.Text = ""
                txt_ivaEP.Text = ""
                txt_ValorTotalEP.Text = ""
            End If
        Else
            txt_ValorNetoEP.Text = ""
            txt_ivaEP.Text = ""
            txt_ValorTotalEP.Text = ""
        End If
    End Sub
    '' BOTÓN PARA CALCULAR DÍAS DE ACUERDO A LOS CONTROLES DE CALENDARIO
    Protected Sub btn_CalcularDias_Click(sender As Object, e As EventArgs) Handles btn_CalcularDias.Click
        Dim FechaActual As Date = txt_Fecha_InicioEP.Text
        If txt_Fecha_InicioEP.Text <> "" And txt_Fecha_FinEP.Text <> "" Then
            If IsDate(txt_Fecha_InicioEP.Text) And IsDate(txt_Fecha_FinEP.Text) Then
                If Convert.ToDateTime(txt_Fecha_InicioEP.Text) <= Convert.ToDateTime(txt_Fecha_FinEP.Text) Then
                    Dim pvi_DiasFacturacion As Integer = DateDiff(DateInterval.Day, Convert.ToDateTime(txt_Fecha_InicioEP.Text), Convert.ToDateTime(txt_Fecha_FinEP.Text))
                    txt_DiasFacturarEP.Text = pvi_DiasFacturacion + 1


                    ''''CALCULO
                    Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))

                    If ddl_ModoCobroEP.SelectedIndex <> 0 And txt_TarifaEP.Text <> "" And IsNumeric(txt_TarifaEP.Text) Then

                        If ddl_ModoCobroEP.SelectedValue = 1 Then 'COBRO MENSUAL
                            If txt_DiasFacturarEP.Text <> "" And IsNumeric(txt_DiasFacturarEP.Text) Then
                                Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                                Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)

                                txt_ValorNetoEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes), "Currency").ToString()
                                txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                                txt_ValorTotalEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) + Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                            Else
                                txt_ValorNetoEP.Text = ""
                                txt_ivaEP.Text = ""
                                txt_ValorTotalEP.Text = ""
                            End If


                        ElseIf ddl_ModoCobroEP.SelectedValue = 2 Then 'COBRO DIARIO
                            If txt_DiasFacturarEP.Text <> "" And IsNumeric(txt_DiasFacturarEP.Text) Then
                                Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                                Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)

                                txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar), "Currency").ToString()
                                txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                                txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                            Else
                                txt_ValorNetoEP.Text = ""
                                txt_ivaEP.Text = ""
                                txt_ValorTotalEP.Text = ""
                            End If

                        Else ' COBRO PROPORCIONAL (HORAS)
                            If txt_HorasFacturarEP.Text <> "" And IsNumeric(txt_HorasFacturarEP.Text) Then
                                Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                                Dim vli_HorasFacturar As Integer = Convert.ToInt32(txt_HorasFacturarEP.Text)

                                txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar), "Currency").ToString()
                                txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                                txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                            Else
                                txt_ValorNetoEP.Text = ""
                                txt_ivaEP.Text = ""
                                txt_ValorTotalEP.Text = ""
                            End If
                        End If
                    Else
                        txt_ValorNetoEP.Text = ""
                        txt_ivaEP.Text = ""
                        txt_ValorTotalEP.Text = ""
                    End If
                    ''''FIN CALCULO


                Else
                    txt_DiasFacturarEP.Text = ""
                End If
            End If
        End If
    End Sub
    '' TEXTCHANGED "TARIFA"
    Protected Sub txt_TarifaEP_TextChanged(sender As Object, e As EventArgs) Handles txt_TarifaEP.TextChanged
        Dim FechaActual As Date = txt_Fecha_InicioEP.Text
        Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))

        If ddl_ModoCobroEP.SelectedIndex <> 0 And txt_TarifaEP.Text <> "" And IsNumeric(txt_TarifaEP.Text) Then

            If ddl_ModoCobroEP.SelectedValue = 1 Then 'COBRO MENSUAL
                If txt_DiasFacturarEP.Text <> "" And IsNumeric(txt_DiasFacturarEP.Text) Then
                    Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                    Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)

                    txt_ValorNetoEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes), "Currency").ToString()
                    txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                    txt_ValorTotalEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) + Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                Else
                    txt_ValorNetoEP.Text = ""
                    txt_ivaEP.Text = ""
                    txt_ValorTotalEP.Text = ""
                End If


            ElseIf ddl_ModoCobroEP.SelectedValue = 2 Then 'COBRO DIARIO
                If txt_DiasFacturarEP.Text <> "" And IsNumeric(txt_DiasFacturarEP.Text) Then
                    Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                    Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)

                    txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar), "Currency").ToString()
                    txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                    txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                Else
                    txt_ValorNetoEP.Text = ""
                    txt_ivaEP.Text = ""
                    txt_ValorTotalEP.Text = ""
                End If

            Else ' COBRO PROPORCIONAL (HORAS)
                If txt_HorasFacturarEP.Text <> "" And IsNumeric(txt_HorasFacturarEP.Text) Then
                    Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                    Dim vli_HorasFacturar As Integer = Convert.ToInt32(txt_HorasFacturarEP.Text)

                    txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar), "Currency").ToString()
                    txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                    txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                Else
                    txt_ValorNetoEP.Text = ""
                    txt_ivaEP.Text = ""
                    txt_ValorTotalEP.Text = ""
                End If
            End If
        Else
            txt_ValorNetoEP.Text = ""
            txt_ivaEP.Text = ""
            txt_ValorTotalEP.Text = ""
        End If

    End Sub
    '' TEXTCHANGED "DIAS FACTURADOS"
    Protected Sub txt_DiasFacturarEP_TextChanged(sender As Object, e As EventArgs) Handles txt_DiasFacturarEP.TextChanged
        Dim FechaActual As Date = txt_Fecha_InicioEP.Text
        Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))

        If ddl_ModoCobroEP.SelectedIndex <> 0 And txt_TarifaEP.Text <> "" And IsNumeric(txt_TarifaEP.Text) Then

            If ddl_ModoCobroEP.SelectedValue = 1 Then 'COBRO MENSUAL
                If txt_DiasFacturarEP.Text <> "" And IsNumeric(txt_DiasFacturarEP.Text) Then
                    Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                    Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)

                    txt_ValorNetoEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes), "Currency").ToString()
                    txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                    txt_ValorTotalEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) + Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                Else
                    txt_ValorNetoEP.Text = ""
                    txt_ivaEP.Text = ""
                    txt_ValorTotalEP.Text = ""
                End If


            ElseIf ddl_ModoCobroEP.SelectedValue = 2 Then 'COBRO DIARIO
                If txt_DiasFacturarEP.Text <> "" And IsNumeric(txt_DiasFacturarEP.Text) Then
                    Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                    Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)

                    txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar), "Currency").ToString()
                    txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                    txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                Else
                    txt_ValorNetoEP.Text = ""
                    txt_ivaEP.Text = ""
                    txt_ValorTotalEP.Text = ""
                End If

            Else ' COBRO PROPORCIONAL (HORAS)
                If txt_HorasFacturarEP.Text <> "" And IsNumeric(txt_HorasFacturarEP.Text) Then
                    Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                    Dim vli_HorasFacturar As Integer = Convert.ToInt32(txt_HorasFacturarEP.Text)

                    txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar), "Currency").ToString()
                    txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                    txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                Else
                    txt_ValorNetoEP.Text = ""
                    txt_ivaEP.Text = ""
                    txt_ValorTotalEP.Text = ""
                End If
            End If
        Else
            txt_ValorNetoEP.Text = ""
            txt_ivaEP.Text = ""
            txt_ValorTotalEP.Text = ""
        End If
    End Sub
    '' TEXTCHANGED "HORAS FACTURADAS"
    Protected Sub txt_HorasFacturarEP_TextChanged(sender As Object, e As EventArgs) Handles txt_HorasFacturarEP.TextChanged
        Dim FechaActual As Date = txt_Fecha_InicioEP.Text
        Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))
        'Dim pvi_DiasFacturacion As Integer = (pvi_MaximoMes - Day(FechaActual)) + 1

        If ddl_ModoCobroEP.SelectedIndex = 3 Then
            If txt_TarifaEP.Text <> "" And txt_HorasFacturarEP.Text <> "" Then
                If IsNumeric(txt_TarifaEP.Text) And IsNumeric(txt_HorasFacturarEP.Text) Then
                    If IsNumeric(txt_HorasFacturarEP.Text) Then
                        Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                        Dim vli_HorasFacturar As Integer = Convert.ToInt32(txt_HorasFacturarEP.Text)


                        txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar), "Currency").ToString()
                        txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                        txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
                    End If
                End If
            Else
                txt_ValorNetoEP.Text = ""
                txt_ivaEP.Text = ""
                txt_ValorTotalEP.Text = ""
            End If
        Else
            txt_ValorNetoEP.Text = ""
            txt_ivaEP.Text = ""
            txt_ValorTotalEP.Text = ""
        End If
    End Sub
    '' TEXCHANGUED "TARIFA" NUEVO ESTADO DE PAGO
    Private Sub txt_TarifaEPnuevo_TextChanged(sender As Object, e As EventArgs) Handles txt_TarifaEPnuevo.TextChanged

        If txt_TarifaEPnuevo.Text <> "" And IsNumeric(txt_TarifaEPnuevo.Text) Then
            Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEPnuevo.Text)

            txt_NETOEPnuevo.Text = Format(Convert.ToInt64(vli_Tarifa), "Currency").ToString()
            txt_IVAEPnuevo.Text = Format((Convert.ToInt64(vli_Tarifa) * 0.19), "Currency").ToString()
            txt_TOTALnuevo.Text = Format((Convert.ToInt64(vli_Tarifa) * 1.19), "Currency").ToString()
        Else
            txt_NETOEPnuevo.Text = ""
            txt_IVAEPnuevo.Text = ""
            txt_TOTALnuevo.Text = ""
        End If



    End Sub


    '' TEXTCHANGUED PARA VERIFICAR SI EXISTE EL EQUIPO QUE SE QUIERE AGREGAR
    Private Sub txt_AFInuevo_TextChanged(sender As Object, e As EventArgs) Handles txt_AFInuevo.TextChanged
        If (txt_AFInuevo.Text <> "") Then
            If IsNumeric(txt_AFInuevo.Text) Then
                sds_SoloEquipo.SelectParameters("id_Equipo").DefaultValue = txt_AFInuevo.Text
                sds_SoloEquipo.DataBind()
                'Carga de SDS a DataTable
                Dim dt_Equipos As DataTable = CType(sds_SoloEquipo.Select(DataSourceSelectArguments.Empty), DataView).Table
                If dt_Equipos.Rows.Count = 0 Then
                    lbl_ErrorAfiNuevo.InnerHtml = "No encontrado"
                    lbl_ErrorAfiNuevo.Visible = True
                    txt_AFInuevo.Text = ""
                Else
                    lbl_ErrorAfiNuevo.Visible = False
                End If
            Else
                lbl_ErrorAfiNuevo.InnerHtml = "solo números"
                lbl_ErrorAfiNuevo.Visible = True
                txt_AFInuevo.Text = ""
                txt_AFInuevo.Focus()
                Exit Sub
            End If
        Else
            lbl_ErrorAfiNuevo.InnerHtml = "indique AFI"
            lbl_ErrorAfiNuevo.Visible = True
            txt_AFInuevo.Text = ""
            txt_AFInuevo.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btn_BuscarPorAfi_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorAfi.Click


        If (txt_BuscarAfi.Text <> "") Then
            If IsNumeric(txt_BuscarAfi.Text) Then
                sds_EstadoPagoxAFI.SelectParameters("AFI").DefaultValue = txt_BuscarAfi.Text
                sds_EstadoPagoxAFI.DataBind()
                gdv_EstadosPago.DataSource = sds_EstadoPagoxAFI
                gdv_EstadosPago.DataBind()
                If gdv_EstadosPago.Rows.Count > 0 Then
                    pnl_mensaje.Visible = False
                Else
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay estados de pago para el AFI ingresado"
                    gdv_EstadosPago.DataSource = Nothing
                    gdv_EstadosPago.DataBind()
                End If
            Else
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   Debe ingresar un valor numérico para buscar por Equipo"
                gdv_EstadosPago.DataSource = Nothing
                gdv_EstadosPago.DataBind()
            End If
        Else

            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   Debe ingresar un AFI para buscar por Equipo"
            gdv_EstadosPago.DataSource = Nothing
            gdv_EstadosPago.DataBind()

        End If
        ddl_Clientes.SelectedIndex = -1
        ddl_periodo.SelectedIndex = -1
        DDL_ANHO.SelectedValue = 2020
        txt_BuscarEDP.Text = ""
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ddl_Clientes.SelectedIndex = -1
        ddl_periodo.SelectedIndex = -1
        DDL_ANHO.SelectedValue = 2020
        txt_BuscarAfi.Text = ""
        txt_BuscarEDP.Text = ""
    End Sub

    Private Sub btn_BuscarPorEDP_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorEDP.Click
        If (txt_BuscarEDP.Text <> "") Then
            If IsNumeric(txt_BuscarEDP.Text) Then
                sds_EstadoPagoXEDP.SelectParameters("id_EstadoPago").DefaultValue = txt_BuscarEDP.Text
                sds_EstadoPagoXEDP.DataBind()
                gdv_EstadosPago.DataSource = sds_EstadoPagoXEDP
                gdv_EstadosPago.DataBind()
                If gdv_EstadosPago.Rows.Count > 0 Then
                    pnl_mensaje.Visible = False
                Else
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay estados de pago para el EDP ingresado"
                    gdv_EstadosPago.DataSource = Nothing
                    gdv_EstadosPago.DataBind()
                End If
            Else
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   Debe ingresar un valor numérico para buscar por EDP"
                gdv_EstadosPago.DataSource = Nothing
                gdv_EstadosPago.DataBind()
            End If
        Else

            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   Debe ingresar un EDP para buscar por Equipo"
            gdv_EstadosPago.DataSource = Nothing
            gdv_EstadosPago.DataBind()

        End If
        ddl_Clientes.SelectedIndex = -1
        ddl_periodo.SelectedIndex = -1
        DDL_ANHO.SelectedValue = 2020
        txt_BuscarAfi.Text = ""
    End Sub

    Private Sub btn_DescargarSeleccion_Click(sender As Object, e As EventArgs) Handles btn_DescargarSeleccion.Click
        Dim dt_EstadosDePago As New DataTable

        dt_EstadosDePago.Columns.Add("ID")
        Dim contador As Integer = 0
        For i = 0 To gdv_EstadosPago.Rows.Count - 1
            Dim filaDT As DataRow = dt_EstadosDePago.NewRow()
            Dim chk_edp As CheckBox = gdv_EstadosPago.Rows(i).FindControl("chk_edp")
            Dim hf_edp As HiddenField = gdv_EstadosPago.Rows(i).FindControl("hf_edp")

            If (chk_edp.Checked = True) Then
                filaDT("ID") = gdv_EstadosPago.Rows(i).Cells(0).Text
                dt_EstadosDePago.Rows.Add(filaDT)
                contador = contador + 1
            End If

        Next

        Dim vlo_ListaEstadosDePago As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
        If contador > 0 Then
            'If vlo_ListaEstadosDePago.fgb_ListadoEstadosDePago(dt_EstadosDePago) Then
            vlo_ListaEstadosDePago.fgb_ListadoEstadosDePago(dt_EstadosDePago)
            Dim JSONString = String.Empty
            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(dt_EstadosDePago)

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?List=" & JSONString & "&tiporeporte=7" & "','_newtab');", True)


            'End If
            'Else

        End If
        pnl_mensaje.Visible = False
    End Sub







#End Region

End Class