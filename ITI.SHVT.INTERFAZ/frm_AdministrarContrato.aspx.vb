Imports System.Data.SqlClient
Imports System.IO
Imports ITI.SHVT.SERV
Imports Microsoft.Reporting.WebForms

Public Class frm_AdministrarContrato
    Inherits System.Web.UI.Page

#Region "VARIABLES GLOBALES"
    Dim pvi_idContrato As Integer = 0
#End Region

#Region "INICIO"
    '' PRE-RENDER CARGAR DDL CON VALORES DEFINIDOS
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Clientes.Items.FindByText("Todos los Clientes...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("Todos los Clientes...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If
        If (ddl_Estado.Items.FindByText("Todos los estados...") Is Nothing) Then
            ddl_Estado.Items.Insert(0, New ListItem("Todos los estados...", "", True))

            ddl_Estado.SelectedIndex = 0
        End If

        If (ddl_ModoCobroEP.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_ModoCobroEP.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_ModoCobroEP.SelectedIndex = 0
        End If
        If (ddl_Sucursal.Items.FindByText("Todas las sucursales...") Is Nothing) Then
            ddl_Sucursal.Items.Insert(0, New ListItem("Todas las sucursales...", "", True))

            ddl_Sucursal.SelectedIndex = 0
        End If
    End Sub

    '' FORM LOAD
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If
            sds_TodosLosContratos.DataBind()
            gdv_Contratos.DataSource = sds_TodosLosContratos
            gdv_Contratos.DataBind()

            sds_FacturacionProyectada.DataBind()
            sds_MontoFlota.DataBind()

            Dim dt_FacturacionProyectada As DataTable = CType(sds_FacturacionProyectada.Select(DataSourceSelectArguments.Empty), DataView).Table

            sds_MontoFlota.SelectParameters("id_Sucursal").DefaultValue = 999 'Arica
            sds_MontoFlota.DataBind()
            Dim dt_MontoFlota As DataTable = CType(sds_MontoFlota.Select(DataSourceSelectArguments.Empty), DataView).Table

            Dim vls_Valor As String = dt_FacturacionProyectada.Rows(0).Item("FacturacionProyectada").ToString()

            Dim ValorFlota As Double = Convert.ToInt64(dt_FacturacionProyectada.Rows(0).Item("FacturacionProyectada").ToString()) / (Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString()) + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString()) + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString())) * 100

            lbl_Factor.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>(%) Factor Rendimiento: </b>(" + Convert.ToString(Format(ValorFlota, "##,##0.0")) + "%)"
            lbl_Proyeccion.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Facturación Proyectada: </b>" + Format(vls_Valor, "Currency").ToString()

            lbl_Proyeccion.Visible = True
            lbl_Factor.Visible = True
            mtn_CargarGrilla()

        End If

    End Sub
#End Region

#Region "BOTONES"
    '' FILTRAR CONTRATOS DE ACUERDO A LOS CONTROLES SELECCIONADOS
    Protected Sub btn_filtrar_Click(sender As Object, e As EventArgs) Handles btn_filtrar.Click
        txt_BuscarAfi.Text = ""
        txt_BuscarContrato.Text = ""
        pnl_botones.Visible = True
        pnl_casos.Visible = True

        Dim pvs_RutCliente As String
        Dim pvi_EstadoContrato As Integer
        Dim pvi_Sucursal As Integer
        'Dim pvs_FechaInicio As String
        'Dim pvs_FechaTermino As String

        If ddl_Clientes.SelectedIndex = 0 Then
            pvs_RutCliente = 999
        Else
            pvs_RutCliente = ddl_Clientes.SelectedValue
        End If

        If ddl_Estado.SelectedIndex = 0 Then
            pvi_EstadoContrato = 999
        Else
            pvi_EstadoContrato = ddl_Estado.SelectedValue
        End If

        'If txt_FechaInicio.Text = "" Then
        '    pvs_FechaInicio = 999
        '    pvs_FechaTermino = 999
        'Else
        '    pvs_FechaInicio = txt_FechaInicio.Text
        '    pvs_FechaTermino = txt_FechaTermino.Text
        'End If
        If ddl_Sucursal.SelectedIndex = 0 Then
            pvi_Sucursal = 999
        Else
            pvi_Sucursal = ddl_Sucursal.SelectedValue
        End If

        sds_contratos.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
        sds_contratos.SelectParameters("EstadoContrato").DefaultValue = pvi_EstadoContrato
        'sds_contratos.SelectParameters("FechaInicioContrato").DefaultValue = pvs_FechaInicio
        'sds_contratos.SelectParameters("FechaTerminoContrato").DefaultValue = pvs_FechaTermino
        sds_contratos.SelectParameters("Sucursal").DefaultValue = pvi_Sucursal
        sds_contratos.DataBind()
        gdv_Contratos.DataSource = sds_contratos
        gdv_Contratos.DataBind()



        If gdv_Contratos.Rows.Count = 0 Then

            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay contratos para este filtro."
        Else
            pnl_mensaje.Visible = False
        End If

        If ddl_Clientes.SelectedIndex <> 0 Then
            sds_FlotaCliente.SelectParameters("id_Cliente").DefaultValue = pvs_RutCliente
            sds_FlotaCliente.DataBind()

            Dim dt_FlotaCliente As DataTable = CType(sds_FlotaCliente.Select(DataSourceSelectArguments.Empty), DataView).Table

            Dim vls_Valor As String = dt_FlotaCliente.Rows(0).Item("Arriendo").ToString()
            Dim vls_ValorPorcentaje As Double = (Convert.ToInt64(dt_FlotaCliente.Rows(0).Item("Arriendo")) / Convert.ToInt64(dt_FlotaCliente.Rows(0).Item("Arriendo_Todos"))) * 100
            lbl_FlotaCliente.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>($) Flota Arrendada: </b>" + Format(vls_Valor, "Currency").ToString()
            lbl_PorcentajeArriendo.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>(%) Flota : </b>" + Format(vls_ValorPorcentaje, "##,##0.0").ToString + "%"
            lbl_ContratosActivos.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>(*) Contratos listados: </b>(" + gdv_Contratos.Rows.Count().ToString + ")"
            lbl_FlotaCliente.Visible = True
            lbl_PorcentajeArriendo.Visible = True
            lbl_ContratosActivos.Visible = True
            lbl_Proyeccion.Visible = False
            lbl_Factor.Visible = False
        Else
            lbl_Proyeccion.Visible = True
            lbl_Factor.Visible = True
            lbl_FlotaCliente.Visible = False
            lbl_PorcentajeArriendo.Visible = False
            lbl_ContratosActivos.Visible = False
        End If
        txt_BuscarAfi.Text = ""


    End Sub
    Private Sub btn_BuscarPorAfi_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorAfi.Click

        If (txt_BuscarAfi.Text <> "") Then
            If IsNumeric(txt_BuscarAfi.Text) Then
                sds_ContratoXAfi.SelectParameters("id_Equipo").DefaultValue = txt_BuscarAfi.Text
                sds_ContratoXAfi.DataBind()
                gdv_Contratos.DataSource = sds_ContratoXAfi
                gdv_Contratos.DataBind()

                'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
                If (gdv_Contratos.Rows.Count <> 0) Then
                    gdv_Contratos.HeaderRow.Cells(0).Attributes("data-class") = "expand"
                    gdv_Contratos.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
                    gdv_Contratos.HeaderRow.Cells(3).Attributes("data-hide") = "phone"
                    gdv_Contratos.HeaderRow.Cells(4).Attributes("data-hide") = "phone"

                    gdv_Contratos.HeaderRow.TableSection = TableRowSection.TableHeader
                    pnl_mensaje.Visible = False
                Else
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay contrato activo para el AFI ingresado"
                    gdv_Contratos.DataSource = Nothing
                    gdv_Contratos.DataBind()
                End If
            Else
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Error!"
                lbl_mensaje2.InnerHtml = "   -   Solo ingrese números"
                gdv_Contratos.DataSource = Nothing
                gdv_Contratos.DataBind()
            End If
        Else
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Error!"
            lbl_mensaje2.InnerHtml = "   -  Favor indicar el AFI a buscar"
            gdv_Contratos.DataSource = Nothing
            gdv_Contratos.DataBind()

        End If
        txt_BuscarContrato.Text = ""
    End Sub
    Private Sub btn_BuscarPorContrato_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorContrato.Click
        If (txt_BuscarContrato.Text <> "") Then
            If IsNumeric(txt_BuscarContrato.Text) Then
                sds_ContratoXNumeroContrato.SelectParameters("id_Contrato").DefaultValue = txt_BuscarContrato.Text
                sds_ContratoXNumeroContrato.DataBind()
                gdv_Contratos.DataSource = sds_ContratoXNumeroContrato
                gdv_Contratos.DataBind()

                'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
                If (gdv_Contratos.Rows.Count <> 0) Then
                    gdv_Contratos.HeaderRow.Cells(0).Attributes("data-class") = "expand"
                    gdv_Contratos.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
                    gdv_Contratos.HeaderRow.Cells(3).Attributes("data-hide") = "phone"
                    gdv_Contratos.HeaderRow.Cells(4).Attributes("data-hide") = "phone"

                    gdv_Contratos.HeaderRow.TableSection = TableRowSection.TableHeader
                    pnl_mensaje.Visible = False
                Else
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay contrato información para el contrato ingresado"
                    gdv_Contratos.DataSource = Nothing
                    gdv_Contratos.DataBind()
                End If
            Else
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Error!"
                lbl_mensaje2.InnerHtml = "   -   Solo ingrese números"
                gdv_Contratos.DataSource = Nothing
                gdv_Contratos.DataBind()
                txt_BuscarContrato.Text = ""
            End If
        Else
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Error!"
            lbl_mensaje2.InnerHtml = "   -  Favor indicar el número de contrato a buscar"
            gdv_Contratos.DataSource = Nothing
            gdv_Contratos.DataBind()

        End If
        txt_BuscarAfi.Text = ""
    End Sub
    '' LIMPIAR CONTROLES DONDE SE FILTRAN LOS CONTRATOS
    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ddl_Clientes.SelectedIndex = -1
        ddl_Estado.SelectedIndex = -1
        'txt_FechaInicio.Text = ""
        'txt_FechaTermino.Text = ""
        txt_BuscarAfi.Text = ""
        txt_BuscarContrato.Text = ""
        lbl_FlotaCliente.Visible = False
        lbl_PorcentajeArriendo.Visible = False

        pnl_mensaje.Visible = False
        sds_TodosLosContratos.DataBind()
        gdv_Contratos.DataSource = sds_TodosLosContratos
        gdv_Contratos.DataBind()
    End Sub


    '' <<<<<<<<<<<<<<<< MODAL DETALLES DE UN CONTRATO >>>>>>>>>>>>>>>>>>>>>>>
    '' ABRIR MODAL DETALLES DE UN CONTRATO
    Protected Sub btn_VerCaso_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_VerCaso As Button = CType(sender, Button)
        Dim vli_id_Contrato As Integer = btn_VerCaso.CommandArgument

        ViewState("id_Contrato") = vli_id_Contrato

        sds_SoloContrato.SelectParameters("id_Contrato").DefaultValue = vli_id_Contrato
        sds_SoloContrato.DataBind()


        sds_Documentos.SelectParameters("id_Contrato").DefaultValue = vli_id_Contrato
        sds_Documentos.DataBind()
        gdv_Documentos.DataSource = sds_Documentos
        gdv_Documentos.DataBind()
        upp_dctos.Update()

        'Carga de SDS a DataTable
        Dim dt_Contrato As DataTable = CType(sds_SoloContrato.Select(DataSourceSelectArguments.Empty), DataView).Table
        'ViewState("id_Caso") = vli_id_Caso
        lbl_idContrato.InnerText = vli_id_Contrato
        lbl_RutCliente.InnerText = ": " + dt_Contrato.Rows(0).Item("RutCliente").ToString()
        lbl_NombreCliente.InnerText = ": " + dt_Contrato.Rows(0).Item("NombreCliente").ToString()
        lbl_Afi.InnerText = ": " + dt_Contrato.Rows(0).Item("id_Equipo").ToString()
        lbl_NombreEquipo.InnerText = ": " + dt_Contrato.Rows(0).Item("NombreEquipo").ToString()

        lbl_FechaContrato.InnerText = ": " + dt_Contrato.Rows(0).Item("FechaContrato").ToString()
        lbl_NombreZona.InnerText = ": " + dt_Contrato.Rows(0).Item("NombreZona").ToString()
        lbl_Faena.InnerText = ": " + (dt_Contrato.Rows(0).Item("Faena")).ToString()
        'lbl_EstadoContrato.InnerText = ": " + dt_Contrato.Rows(0).Item("EstadoContrato").ToString()

        Dim ValorFormateado As String = dt_Contrato.Rows(0).Item("ValorUnitario").ToString()
        lbl_ValorContrato.InnerText = ": " + Format(ValorFormateado, "Currency").ToString()
        lbl_TipoUnidad.InnerText = ": " + dt_Contrato.Rows(0).Item("Tipounidad").ToString()
        lbl_Modelo.InnerText = ": " + dt_Contrato.Rows(0).Item("ModeloEquipo").ToString()
        lbl_HorometroSalida.InnerText = ": " + dt_Contrato.Rows(0).Item("HorometroSalida").ToString()
        lbl_FechaDevolucion.InnerText = ": " + dt_Contrato.Rows(0).Item("FechaDevolucion").ToString()
        lbl_Guia.InnerText = ": " + dt_Contrato.Rows(0).Item("Guia").ToString()
        lbl_FechaRegistro.InnerText = ": " + dt_Contrato.Rows(0).Item("FechaRegistroContrato").ToString()
        lbl_idCotizacion.InnerText = ": " + dt_Contrato.Rows(0).Item("id_Cotizacion").ToString()


        Factor.InnerText = ": " + dt_Contrato.Rows(0).Item("Factor").ToString() + " %"

        Dim ValorFormateadoFact As String = dt_Contrato.Rows(0).Item("Facturado").ToString()
        Facturado.InnerText = ": " + Format(ValorFormateadoFact, "Currency").ToString()

        Dim ValorFormateadoPagado As String = dt_Contrato.Rows(0).Item("Pagado").ToString()
        Pagado.InnerText = ": " + Format(ValorFormateadoPagado, "Currency").ToString()

        Dim vls_Apellidos() As String = dt_Contrato.Rows(0).Item("Nombres").ToString().Split(" ")
        lbl_UsuarioRegistra.InnerText = ": " + vls_Apellidos(0) + " " + dt_Contrato.Rows(0).Item("Apaterno").ToString()

        ddl_CambiarEstado.SelectedValue = dt_Contrato.Rows(0).Item("idEstadoContrato")



        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True)
        upp_Modal.Update()
    End Sub
    '' SUBIR DOCUMENTOS ASOCIADOS AL CONTRATO
    Protected Sub UploadFile(src As Object, e As EventArgs)
        lbl_ErrorArchivo.Visible = False
        lbl_ErrorArchivo.Text = ""

        Dim id_Contrato As String = Integer.Parse(lbl_idContrato.InnerText)
        Dim vls_savePath As String = vgs_Contratos & "\" & id_Contrato & "\"
        If (Not Directory.Exists(vls_savePath)) Then
            Directory.CreateDirectory(vls_savePath)
        End If

        If SubirArchivo.HasFile Then
            Dim vls_NombreArchivoCompleto As String
            Dim vls_NombreArchivoLimpio As String

            vls_NombreArchivoCompleto = SubirArchivo.FileName
            vls_NombreArchivoLimpio = Path.GetFileNameWithoutExtension(vls_NombreArchivoCompleto)

            Dim vls_Fecha As String = Date.Now.ToString
            vls_Fecha = vls_Fecha.Replace(" ", "")
            vls_Fecha = vls_Fecha.Replace(":", "")
            vls_Fecha = vls_Fecha.Replace("/", "")
            vls_Fecha = vls_Fecha.Replace("-", "")

            Dim vls_ExtensionesDisponibles() As String = {".pdf", ".xls", ".xlsx", ".doc", ".docx", ".jpeg", ".jpg", ".png", ".txt", ".mp4"}
            If vls_ExtensionesDisponibles.Contains((Path.GetExtension(SubirArchivo.FileName)).ToLower) Then
                Dim vlo_Caso As New RN.RN_CONTRATOS.cls_Contratos
                If (vlo_Caso.fgb_AdjuntarDocumentoContratos(id_Contrato, vls_NombreArchivoLimpio, (vls_NombreArchivoLimpio + vls_Fecha + Path.GetExtension(SubirArchivo.FileName)))) Then
                    SubirArchivo.PostedFile.SaveAs(vls_savePath & "//" & (vls_NombreArchivoLimpio + vls_Fecha + Path.GetExtension(SubirArchivo.FileName)))
                Else
                    lbl_ErrorArchivo.Visible = True
                    lbl_ErrorArchivo.Text = "Error al subir el archivo, puede que esté repetido."
                End If
            Else
                lbl_ErrorArchivo.Visible = True
                lbl_ErrorArchivo.Text = "Error al subir el archivo, tiene una extensión no permitida."
            End If
        End If


        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True)


        sds_Documentos.SelectParameters("id_Contrato").DefaultValue = id_Contrato
        sds_Documentos.DataBind()
        gdv_Documentos.DataSource = sds_Documentos
        gdv_Documentos.DataBind()

    End Sub
    '' ELIMINAR DOCUMENTOS ASOCIADOS A UN CONTRATO
    Protected Sub btn_Eliminar_Click(ByVal sender As Object, ByVal e As EventArgs)
        lbl_ErrorArchivo.Visible = False
        lbl_ErrorArchivo.Text = ""

        Dim btn_Eliminar As LinkButton = CType(sender, LinkButton)
        Dim vli_id_Documento As Integer = btn_Eliminar.CommandArgument

        Dim vlo_Caso As New RN.RN_PARQUE.cls_Parque
        If (vlo_Caso.fgb_EliminarDocumento(vli_id_Documento)) Then
            sds_Documentos.SelectParameters("id_Contrato").DefaultValue = Convert.ToInt32(lbl_idContrato.InnerText)
            sds_Documentos.DataBind()
            gdv_Documentos.DataSource = sds_Documentos
            gdv_Documentos.DataBind()

        Else
            lbl_ErrorArchivo.Visible = True
            lbl_ErrorArchivo.Text = "Error al subir el archivo, puede que esté repetido."

            sds_Documentos.SelectParameters("id_Contrato").DefaultValue = Convert.ToInt32(lbl_idContrato.InnerText)
            sds_Documentos.DataBind()
            gdv_Documentos.DataSource = sds_Documentos
            gdv_Documentos.DataBind()
        End If
    End Sub
    '' DESCARGAR DOCUMENTOS ASOCIADOS AL CONTRATO
    Protected Sub btn_Descargar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_Descargar As LinkButton = CType(sender, LinkButton)
        Dim vls_Argumentos As String() = btn_Descargar.CommandArgument.Split(","c)
        Dim vli_id_Docto As Integer = vls_Argumentos(0)
        Dim vls_NombreDocumento As String = vls_Argumentos(1)

        Dim id_Contrato As String = lbl_idContrato.InnerText

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_Descarga.aspx?procedencia=1&caso=" & id_Contrato & "&documento=" & vls_NombreDocumento & "','_newtab');", True)
    End Sub
    '' <<<<<<<<<<<<<<<< MODAL DETALLES DE UN CONTRATO >>>>>>>>>>>>>>>>>>>>>>>


    '' <<<<<<<<<<<<<<<< MODAL ESTADOS DE PAGO >>>>>>>>>>>>>>>>>>>>>>>
    '' ABRIR MODAL ESTADOS DE PAGO
    Protected Sub btn_EstadosPago_Click(ByVal sender As Object, ByVal e As EventArgs)
        btn_ModificarEstadoPago.Visible = False
        btn_GuardarEP.Visible = True
        txt_Observaciones.InnerText = ""

        Dim btn_VerEstadoPago As Button = CType(sender, Button)
        Dim vli_id_Contrato As Integer = btn_VerEstadoPago.CommandArgument

        ViewState("id_Contrato") = vli_id_Contrato
        lbl_idContratoEP.InnerText = vli_id_Contrato

        sds_SoloContrato.SelectParameters("id_Contrato").DefaultValue = vli_id_Contrato
        sds_SoloContrato.DataBind()
        'Carga de SDS a DataTable
        Dim dt_Contrato As DataTable = CType(sds_SoloContrato.Select(DataSourceSelectArguments.Empty), DataView).Table

        lbl_NumeroEP.InnerText = dt_Contrato.Rows(0).Item("SiguienteNEP").ToString()
        lbl_NombreEquipoEP.InnerText = dt_Contrato.Rows(0).Item("NombreEquipo").ToString()
        lbl_ModeloEquipoEP.InnerText = dt_Contrato.Rows(0).Item("ModeloEquipo").ToString()
        lbl_AfiEP.InnerText = dt_Contrato.Rows(0).Item("id_Equipo").ToString()
        lbl_FaenaEP.InnerText = dt_Contrato.Rows(0).Item("Faena").ToString()

        ''TRAER FECHA DEL ULTIMO ESTADO DE PAGO PARA ESE CONTRATO Y SUMARLE 1 DÍA, ESA QUEDARIA COMO FECHA INICIO.

        If IsDate(dt_Contrato.Rows(0).Item("FechaSiguienteEP").ToString()) Then
            Dim FechaSiguienteEP As Date = dt_Contrato.Rows(0).Item("FechaSiguienteEP").ToString()
            txt_Fecha_InicioEP.Text = FechaSiguienteEP.Date.AddDays(1)
            Dim vld_FechaConGuion As String = DateSerial(Year(txt_Fecha_InicioEP.Text), Month(txt_Fecha_InicioEP.Text) + 1, 0)

            txt_Fecha_InicioEP.Text = Replace(txt_Fecha_InicioEP.Text, "-", "/")
            txt_Fecha_FinEP.Text = Replace(vld_FechaConGuion, "-", "/")
        Else

            txt_Fecha_InicioEP.Text = dt_Contrato.Rows(0).Item("FechaContrato").ToString()
            Dim vld_FechaConGuion As String = DateSerial(Year(txt_Fecha_InicioEP.Text), Month(txt_Fecha_InicioEP.Text) + 1, 0)

            txt_Fecha_FinEP.Text = Replace(vld_FechaConGuion, "-", "/")

        End If



        txt_DiasFacturarEP.Text = DateDiff(DateInterval.Day, Convert.ToDateTime(txt_Fecha_InicioEP.Text), Convert.ToDateTime(txt_Fecha_FinEP.Text)) + 1
        txt_TarifaEP.Text = dt_Contrato.Rows(0).Item("ValorUnitario").ToString()

        Dim FechaActual As Date = txt_Fecha_InicioEP.Text

        If dt_Contrato.Rows(0).Item("Tipounidad").ToString() = "Mensual" Then
            ddl_ModoCobroEP.SelectedValue = 1
            Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))
            Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
            Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)
            txt_ValorNetoEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes), "Currency").ToString()
            txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
            txt_ValorTotalEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) + Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
        Else
            ddl_ModoCobroEP.SelectedValue = 2
            Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))
            Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
            Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)
            txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar), "Currency").ToString()
            txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
            txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
        End If

        sds_EstadosPago.SelectParameters("id_Contrato").DefaultValue = vli_id_Contrato
        sds_EstadosPago.DataBind()
        gdv_EstadosPago.DataSource = sds_EstadosPago
        gdv_EstadosPago.DataBind()

        upp_ListaEstadosPago.Update()


        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerEstadosPago", "$('#mpe_VerEstadosPago').modal();", True)

        upp_modalEstadoPago.Update()
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
                                Dim vli_HorasFacturar As Double = Convert.ToDouble(txt_HorasFacturarEP.Text)

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
    '' LIMPIAR FORMULARIO DE INGRESO DE ESTADO DE PAGO
    Protected Sub btn_LimpiarEP_Click(sender As Object, e As EventArgs) Handles btn_LimpiarEP.Click
        txt_Fecha_InicioEP.Text = ""
        txt_Fecha_FinEP.Text = ""
        txt_TarifaEP.Text = ""
        txt_HorasFacturarEP.Text = ""
        txt_DiasFacturarEP.Text = ""
        ddl_ModoCobroEP.SelectedIndex = 0
        txt_ValorNetoEP.Text = ""
        txt_ivaEP.Text = ""
        txt_ValorTotalEP.Text = ""
        txt_Observaciones.InnerText = ""
    End Sub
    '' GUARDAR ESTADO DE PAGO
    Protected Sub btn_GuardarEP_Click(sender As Object, e As EventArgs) Handles btn_GuardarEP.Click
        Dim pvi_HorasFacturar As Double
        Dim pvi_DiasFacturar As Integer

        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvi_EstadoComercial As Integer = 2 ' (1) Confirmado, (2) Pendiente, (3) Facturado, (4) Anulado
        Dim pvi_CorrelativoEP As Integer = 1 ' Seleccionar el ultimo EP de ese cliente
        Dim pvd_FechaInicioEP As Date = txt_Fecha_InicioEP.Text
        Dim pvd_FechaFinEP As Date = txt_Fecha_FinEP.Text
        Dim pvi_Contrato As Integer = Convert.ToInt64(lbl_idContratoEP.InnerText)
        Dim pvi_TipoPago As Integer = ddl_ModoCobroEP.SelectedValue
        Dim pvi_Tarifa As Integer = Convert.ToInt64(txt_TarifaEP.Text)

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
        Dim pvi_TipoEstadoPago As Integer = 1 ' Arriendo
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
                                                                999, '999 implica recibir null, porque no es venta ni cobro
                                                                "",
                                                                999)) Then '' no se envia cliente, ya que no es venta cobro

            LimpiarEP()
            'pnl_Agregado.Visible = True ''''' CREADO CON ÉXITO
            sds_EstadosPago.SelectParameters("id_Contrato").DefaultValue = pvi_Contrato
            sds_EstadosPago.DataBind()
            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()

            lbl_idContratoEP.InnerText = pvi_Contrato

            sds_SoloContrato.SelectParameters("id_Contrato").DefaultValue = pvi_Contrato
            sds_SoloContrato.DataBind()
            'Carga de SDS a DataTable
            Dim dt_Contrato As DataTable = CType(sds_SoloContrato.Select(DataSourceSelectArguments.Empty), DataView).Table

            lbl_NumeroEP.InnerText = dt_Contrato.Rows(0).Item("SiguienteNEP").ToString()
            lbl_NombreEquipoEP.InnerText = dt_Contrato.Rows(0).Item("NombreEquipo").ToString()
            lbl_ModeloEquipoEP.InnerText = dt_Contrato.Rows(0).Item("ModeloEquipo").ToString()
            lbl_AfiEP.InnerText = dt_Contrato.Rows(0).Item("id_Equipo").ToString()
            lbl_FaenaEP.InnerText = dt_Contrato.Rows(0).Item("Faena").ToString()

            'txt_Fecha_InicioEP.Text = dt_Contrato.Rows(0).Item("FechaContrato").ToString()
            'Dim vld_FechaConGuion As String = DateSerial(Year(txt_Fecha_InicioEP.Text), Month(txt_Fecha_InicioEP.Text) + 1, 0)
            'txt_Fecha_FinEP.Text = Replace(vld_FechaConGuion, "-", "/")

            If IsDate(dt_Contrato.Rows(0).Item("FechaSiguienteEP").ToString()) Then
                Dim FechaSiguienteEP As Date = dt_Contrato.Rows(0).Item("FechaSiguienteEP").ToString()
                txt_Fecha_InicioEP.Text = FechaSiguienteEP.Date.AddDays(1)
                Dim vld_FechaConGuion As String = DateSerial(Year(txt_Fecha_InicioEP.Text), Month(txt_Fecha_InicioEP.Text) + 1, 0)

                txt_Fecha_InicioEP.Text = Replace(txt_Fecha_InicioEP.Text, "-", "/")
                txt_Fecha_FinEP.Text = Replace(vld_FechaConGuion, "-", "/")
            Else

                txt_Fecha_InicioEP.Text = dt_Contrato.Rows(0).Item("FechaContrato").ToString()
                Dim vld_FechaConGuion As String = DateSerial(Year(txt_Fecha_InicioEP.Text), Month(txt_Fecha_InicioEP.Text) + 1, 0)

                txt_Fecha_FinEP.Text = Replace(vld_FechaConGuion, "-", "/")

            End If

            txt_DiasFacturarEP.Text = DateDiff(DateInterval.Day, Convert.ToDateTime(txt_Fecha_InicioEP.Text), Convert.ToDateTime(txt_Fecha_FinEP.Text)) + 1
            txt_TarifaEP.Text = dt_Contrato.Rows(0).Item("ValorUnitario").ToString()

            Dim FechaActual As Date = txt_Fecha_InicioEP.Text

            If dt_Contrato.Rows(0).Item("Tipounidad").ToString() = "Mensual" Then
                ddl_ModoCobroEP.SelectedValue = 1
                Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))
                Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)
                txt_ValorNetoEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes), "Currency").ToString()
                txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                txt_ValorTotalEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) + Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
            Else
                ddl_ModoCobroEP.SelectedValue = 2
                Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))
                Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)
                txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar), "Currency").ToString()
                txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
            End If

            sds_EstadosPago.SelectParameters("id_Contrato").DefaultValue = pvi_Contrato
            sds_EstadosPago.DataBind()
            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()


            upp_ListaEstadosPago.Update()
            upp_modalEstadoPago.Update()


        End If

    End Sub
    '' MOdificar ESTADO DE PAGO
    Protected Sub btn_ModificarEP_Click(ByVal sender As Object, ByVal e As EventArgs)

        btn_ModificarEstadoPago.Visible = True
        btn_GuardarEP.Visible = False

        Dim btn_ModificarEP As LinkButton = CType(sender, LinkButton)
        Dim pvi_idEstadoPago As Integer = btn_ModificarEP.CommandArgument

        sds_SoloContrato.SelectParameters("id_Contrato").DefaultValue = Convert.ToInt64(lbl_idContratoEP.InnerText)
        sds_SoloContrato.DataBind()

        sds_EstadosPagoXidEP.SelectParameters("id_EstadoPago").DefaultValue = pvi_idEstadoPago
        sds_EstadosPagoXidEP.DataBind()


        'Carga de SDS a DataTable
        Dim dt_Contrato As DataTable = CType(sds_SoloContrato.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim dt_EstadoPago As DataTable = CType(sds_EstadosPagoXidEP.Select(DataSourceSelectArguments.Empty), DataView).Table

        lbl_NumeroEP.InnerText = pvi_idEstadoPago.ToString()
        lbl_NombreEquipoEP.InnerText = dt_Contrato.Rows(0).Item("NombreEquipo").ToString()
        lbl_ModeloEquipoEP.InnerText = dt_Contrato.Rows(0).Item("ModeloEquipo").ToString()
        lbl_AfiEP.InnerText = dt_Contrato.Rows(0).Item("id_Equipo").ToString()
        lbl_FaenaEP.InnerText = dt_Contrato.Rows(0).Item("Faena").ToString()

        txt_Fecha_InicioEP.Text = dt_EstadoPago.Rows(0).Item("FechaInicio").ToString()
        txt_Fecha_FinEP.Text = dt_EstadoPago.Rows(0).Item("FechaFin").ToString()
        'Dim vld_FechaConGuion As String = DateSerial(Year(txt_Fecha_InicioEP.Text), Month(txt_Fecha_InicioEP.Text) + 1, 0)
        'txt_Fecha_FinEP.Text = Replace(vld_FechaConGuion, "-", "/")

        txt_DiasFacturarEP.Text = dt_EstadoPago.Rows(0).Item("DiasFacturar")
        txt_TarifaEP.Text = dt_EstadoPago.Rows(0).Item("Tarifa")
        txt_Observaciones.InnerText = dt_EstadoPago.Rows(0).Item("Observaciones")
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
            Dim vli_HorasFacturar As Double = Convert.ToDouble(txt_HorasFacturarEP.Text)

            txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar), "Currency").ToString()
            txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()
            txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_HorasFacturar) * 0.19), "Currency").ToString()

        End If

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        upp_modalEstadoPago.Update()
        btn_ModificarEstadoPago.Visible = True
        btn_GuardarEP.Visible = False

    End Sub
    '' CONFIRMAR EP
    Protected Sub btn_ConfirmarEP_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_ConfirmarEP As LinkButton = CType(sender, LinkButton)
        Dim pvi_idEstadoPago As Integer = btn_ConfirmarEP.CommandArgument
        Dim pvi_EstadoComercial As Integer = 1 '(1) Confirmado, (2) Pendiente, (3) Facturado, (4) Anulado

        Dim vlo_ActualizarEP As New RN.RN_ESTADOSDEPAGO.cls_EstadosDePago
        If (vlo_ActualizarEP.fgb_ConfirmarAnularEP(pvi_idEstadoPago,
                                              pvi_EstadoComercial)) Then

            sds_EstadosPago.SelectParameters("id_Contrato").DefaultValue = Convert.ToInt64(lbl_idContratoEP.InnerText)
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
            sds_EstadosPago.SelectParameters("id_Contrato").DefaultValue = Convert.ToInt64(lbl_idContratoEP.InnerText)
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
        Catch ex As Exception

        End Try

        'codigo para descargar el estado de pago  <------
    End Sub
    '' boton que guarda la modificación de un estado de pago
    Protected Sub btn_ModificarEstadoPago_Click(sender As Object, e As EventArgs) Handles btn_ModificarEstadoPago.Click
        Dim pvi_HorasFacturar As Double
        Dim pvi_DiasFacturar As Integer

        Dim pvi_idEstadoPago As Integer = Convert.ToInt64(lbl_NumeroEP.InnerText)
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvi_EstadoComercial As Integer = 2 ' (1) Confirmado, (2) Pendiente, (3) Facturado, (4) Anulado
        Dim pvi_CorrelativoEP As Integer = 1 ' Seleccionar el ultimo EP de ese cliente
        Dim pvd_FechaInicioEP As Date = txt_Fecha_InicioEP.Text
        Dim pvd_FechaFinEP As Date = txt_Fecha_FinEP.Text
        Dim pvi_Contrato As Integer = Convert.ToInt64(lbl_idContratoEP.InnerText)
        Dim pvi_TipoPago As Integer = ddl_ModoCobroEP.SelectedValue
        Dim pvi_Tarifa As Integer = Convert.ToInt64(txt_TarifaEP.Text)
        Dim pvi_TipoEP As Integer = 1 'Arriendo
        Dim pvi_AfiVentaCobro As Integer = 999 ' No es venta ni cobro
        Dim pvi_Sucursal As Integer = 999

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
                                                                  pvi_TipoEP,
                                                                  pvi_AfiVentaCobro,
                                                                    pvi_Sucursal)) Then


            'pnl_Agregado.Visible = True ''''' CREADO CON ÉXITO
            btn_ModificarEstadoPago.Visible = False
            btn_GuardarEP.Visible = True
            sds_EstadosPago.SelectParameters("id_Contrato").DefaultValue = pvi_Contrato
            sds_EstadosPago.DataBind()
            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()
            upp_ListaEstadosPago.Update()

            lbl_idContratoEP.InnerText = pvi_Contrato

            sds_SoloContrato.SelectParameters("id_Contrato").DefaultValue = pvi_Contrato
            sds_SoloContrato.DataBind()
            'Carga de SDS a DataTable
            Dim dt_Contrato As DataTable = CType(sds_SoloContrato.Select(DataSourceSelectArguments.Empty), DataView).Table

            lbl_NumeroEP.InnerText = dt_Contrato.Rows(0).Item("SiguienteNEP").ToString()
            lbl_NombreEquipoEP.InnerText = dt_Contrato.Rows(0).Item("NombreEquipo").ToString()
            lbl_ModeloEquipoEP.InnerText = dt_Contrato.Rows(0).Item("ModeloEquipo").ToString()
            lbl_AfiEP.InnerText = dt_Contrato.Rows(0).Item("id_Equipo").ToString()
            lbl_FaenaEP.InnerText = dt_Contrato.Rows(0).Item("Faena").ToString()

            txt_Fecha_InicioEP.Text = dt_Contrato.Rows(0).Item("FechaContrato").ToString()
            Dim vld_FechaConGuion As String = DateSerial(Year(txt_Fecha_InicioEP.Text), Month(txt_Fecha_InicioEP.Text) + 1, 0)
            txt_Fecha_FinEP.Text = Replace(vld_FechaConGuion, "-", "/")

            txt_DiasFacturarEP.Text = DateDiff(DateInterval.Day, Convert.ToDateTime(txt_Fecha_InicioEP.Text), Convert.ToDateTime(txt_Fecha_FinEP.Text)) + 1
            txt_TarifaEP.Text = dt_Contrato.Rows(0).Item("ValorUnitario").ToString()

            Dim FechaActual As Date = txt_Fecha_InicioEP.Text

            If dt_Contrato.Rows(0).Item("Tipounidad").ToString() = "Mensual" Then
                ddl_ModoCobroEP.SelectedValue = 1
                Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))
                Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)
                txt_ValorNetoEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes), "Currency").ToString()
                txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
                txt_ValorTotalEP.Text = Format(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) + Convert.ToInt64(Convert.ToInt64((vli_DiasFacturar * vli_Tarifa) / pvi_MaximoMes) * 0.19), "Currency").ToString()
            Else
                ddl_ModoCobroEP.SelectedValue = 2
                Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(FechaActual), Month(FechaActual) + 1, 0))
                Dim vli_Tarifa As Integer = Convert.ToInt32(txt_TarifaEP.Text)
                Dim vli_DiasFacturar As Integer = Convert.ToInt32(txt_DiasFacturarEP.Text)
                txt_ValorNetoEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar), "Currency").ToString()
                txt_ivaEP.Text = Format(Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
                txt_ValorTotalEP.Text = Format(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) + Convert.ToInt64(Convert.ToInt64(vli_Tarifa * vli_DiasFacturar) * 0.19), "Currency").ToString()
            End If

            sds_EstadosPago.SelectParameters("id_Contrato").DefaultValue = pvi_Contrato
            sds_EstadosPago.DataBind()
            gdv_EstadosPago.DataSource = sds_EstadosPago
            gdv_EstadosPago.DataBind()

            upp_ListaEstadosPago.Update()

            upp_modalEstadoPago.Update()
            ''LimpiarEP()
        End If
    End Sub
    '' Guardar cambios ... detalles del contrato
    Private Sub btn_GuardarModal_Click(sender As Object, e As EventArgs) Handles btn_GuardarModal.Click
        Dim pvi_idContrato As Integer = lbl_idContrato.InnerText
        Dim pvi_EstadoContrato As Integer = ddl_CambiarEstado.SelectedValue

        Dim vlo_ManejadorContratos As New RN.RN_CONTRATOS.cls_Contratos

        If (vlo_ManejadorContratos.fgb_ActualizarContrato(pvi_idContrato,
                                                          pvi_EstadoContrato)) Then

            mtn_CargarGrilla()
        End If


    End Sub
    Private Sub btn_FinalizarContrato_Click(sender As Object, e As EventArgs) Handles btn_FinalizarContrato.Click
        Dim pvi_idContrato As Integer = lbl_idContratoEP.InnerText
        Dim pvi_EstadoContrato As Integer = 2 'Terminar

        Dim vlo_ManejadorContratos As New RN.RN_CONTRATOS.cls_Contratos

        If (vlo_ManejadorContratos.fgb_ActualizarContrato(pvi_idContrato,
                                                          pvi_EstadoContrato)) Then

            mtn_CargarGrilla()
        End If
    End Sub


    '' <<<<<<<<<<<<<<<< MODAL ESTADOS DE PAGO >>>>>>>>>>>>>>>>>>>>>>>
#End Region

#Region "METODOS Y FUNCIONES"
    '' FORZAR GRILLA RESPONSIVA
    Private Sub mtn_CargarGrilla()
        gdv_Contratos.DataSource = sds_TodosLosContratos
        gdv_Contratos.DataBind()
        gdv_Documentos.DataBind()

        'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
        If (gdv_Contratos.Rows.Count <> 0) Then
            gdv_Contratos.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_Contratos.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_Contratos.HeaderRow.Cells(3).Attributes("data-hide") = "phone"
            gdv_Contratos.HeaderRow.Cells(4).Attributes("data-hide") = "phone"
            gdv_Contratos.HeaderRow.Cells(5).Attributes("data-hide") = "phone"

            gdv_Contratos.HeaderRow.TableSection = TableRowSection.TableHeader
        End If

        'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
        If (gdv_Documentos.Rows.Count <> 0) Then
            gdv_Documentos.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_Documentos.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_Documentos.HeaderRow.Cells(3).Attributes("data-hide") = "phone"

            gdv_Documentos.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub
    '' Limpiar Estados de pago
    Private Sub LimpiarEP()
        txt_Fecha_InicioEP.Text = ""
        txt_Fecha_FinEP.Text = ""
        txt_TarifaEP.Text = ""
        txt_HorasFacturarEP.Text = ""
        txt_DiasFacturarEP.Text = ""
        ddl_ModoCobroEP.SelectedIndex = 0
        txt_ValorNetoEP.Text = ""
        txt_ivaEP.Text = ""
        txt_ValorTotalEP.Text = ""
        txt_Observaciones.InnerText = ""
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
                    Dim vli_HorasFacturar As Double = Convert.ToDouble(txt_HorasFacturarEP.Text)

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
                    Dim vli_HorasFacturar As Double = Convert.ToDouble(txt_HorasFacturarEP.Text)

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
                        Dim vli_HorasFacturar As Double = Convert.ToDouble(txt_HorasFacturarEP.Text)


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
#End Region

#Region "DROPDOWNLIST"
    '' DDL MODALIDAD DE COBRO O PAGO (MES, DIARIO O PROPORCIONAL)
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
                    Dim vli_HorasFacturar As Double = Convert.ToDouble(txt_HorasFacturarEP.Text)

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

    Private Sub btn_GenerarActaEntrega_Click(sender As Object, e As EventArgs) Handles btn_GenerarActaEntrega.Click

        Dim pvi_NumeroContrato As Integer = lbl_idContrato.InnerText
        'Response.Redirect("frm_reportes.aspx?idc=" & pvi_NumeroContrato & "&tiporeporte=2", False)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?idc=" & pvi_NumeroContrato & "&tiporeporte=2" & "','_newtab');", True)
        'Context.ApplicationInstance.CompleteRequest()
    End Sub

    Private Sub btn_CerrarModal_Click(sender As Object, e As EventArgs) Handles btn_CerrarModal.Click
        pnl_botones.Visible = True
        pnl_casos.Visible = True

        Dim pvs_RutCliente As String
        Dim pvi_EstadoContrato As Integer
        Dim pvi_Sucursal As Integer
        'Dim pvs_FechaInicio As String
        'Dim pvs_FechaTermino As String

        If ddl_Clientes.SelectedIndex = 0 Then
            pvs_RutCliente = 999
        Else
            pvs_RutCliente = ddl_Clientes.SelectedValue
        End If

        If ddl_Estado.SelectedIndex = 0 Then
            pvi_EstadoContrato = 1
        Else
            pvi_EstadoContrato = ddl_Estado.SelectedValue
        End If

        If ddl_Sucursal.SelectedIndex = 0 Then
            pvi_Sucursal = 999
        Else
            pvi_Sucursal = ddl_Sucursal.SelectedValue
        End If

        'If txt_FechaInicio.Text = "" Then
        '    pvs_FechaInicio = 999
        '    pvs_FechaTermino = 999
        'Else
        '    pvs_FechaInicio = txt_FechaInicio.Text
        '    pvs_FechaTermino = txt_FechaTermino.Text
        'End If

        If txt_BuscarContrato.Text <> "" Then
            sds_ContratoXNumeroContrato.SelectParameters("id_Contrato").DefaultValue = txt_BuscarContrato.Text
            sds_ContratoXNumeroContrato.DataBind()
            gdv_Contratos.DataSource = sds_ContratoXNumeroContrato
            gdv_Contratos.DataBind()
        ElseIf txt_BuscarAfi.Text <> "" Then
            sds_ContratoXAfi.SelectParameters("id_Equipo").DefaultValue = txt_BuscarAfi.Text
            sds_ContratoXAfi.DataBind()
            gdv_Contratos.DataSource = sds_ContratoXAfi
            gdv_Contratos.DataBind()
        Else



            sds_contratos.SelectParameters("RutCliente").DefaultValue = pvs_RutCliente
            sds_contratos.SelectParameters("EstadoContrato").DefaultValue = pvi_EstadoContrato
            'sds_contratos.SelectParameters("FechaInicioContrato").DefaultValue = pvs_FechaInicio
            'sds_contratos.SelectParameters("FechaTerminoContrato").DefaultValue = pvs_FechaTermino
            sds_contratos.SelectParameters("Sucursal").DefaultValue = pvi_Sucursal
            sds_contratos.DataBind()
            gdv_Contratos.DataSource = sds_contratos
            gdv_Contratos.DataBind()
        End If





        upp_Modal.Update()
    End Sub

    Private Sub btn_Informe_Click(sender As Object, e As EventArgs) Handles btn_Informe.Click

        Dim pvs_RutCliente As String
        Dim pvi_EstadoContrato As Integer
        Dim pvi_Sucursal As Integer
        'Dim pvs_FechaInicio As String
        'Dim pvs_FechaTermino As String

        If ddl_Clientes.SelectedIndex = 0 Then
            pvs_RutCliente = 999
        Else
            pvs_RutCliente = ddl_Clientes.SelectedValue
        End If

        If ddl_Estado.SelectedIndex = 0 Then
            pvi_EstadoContrato = 999
        Else
            pvi_EstadoContrato = ddl_Estado.SelectedValue
        End If

        If ddl_Sucursal.SelectedIndex = 0 Then
            pvi_Sucursal = 999
        Else
            pvi_Sucursal = ddl_Sucursal.SelectedValue
        End If

        'If txt_FechaInicio.Text = "" Then
        '    pvs_FechaInicio = 999
        '    pvs_FechaTermino = 999
        'Else
        '    pvs_FechaInicio = txt_FechaInicio.Text
        '    pvs_FechaTermino = txt_FechaTermino.Text
        'End If

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?RutCliente=" & pvs_RutCliente & "&pvi_EstadoContrato=" & pvi_EstadoContrato & "&pvi_SucursalInforme=" & pvi_Sucursal & "&tiporeporte=6" & "','_newtab');", True)



    End Sub




#End Region

End Class