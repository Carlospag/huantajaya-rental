Imports System.IO
Imports ITI.SHVT.SERV
Public Class frm_Parque
    Inherits System.Web.UI.Page

    Dim vli_contador As Integer

#Region "INICIO"
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Familia.Items.FindByText("Todas las familias...") Is Nothing) Then
            ddl_Familia.Items.Insert(0, New ListItem("Todas las familias...", "", True))

            ddl_Familia.SelectedIndex = 0
        End If
        If (ddl_EstadoEquipos.Items.FindByText("Todos los estados...") Is Nothing) Then
            ddl_EstadoEquipos.Items.Insert(0, New ListItem("Todos los estados...", "", True))

            ddl_EstadoEquipos.SelectedIndex = 0
        End If

        If (ddl_Sucursales.Items.FindByText("Todas las sucursales...") Is Nothing) Then
            ddl_Sucursales.Items.Insert(0, New ListItem("Todas las sucursales...", "", True))

            ddl_Sucursales.SelectedIndex = 0
        End If
        If (ddl_Clientes.Items.FindByText("Todos los clientes...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("Todos los clientes...", "", True))

            ddl_Clientes.SelectedIndex = 0
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

            sds_MontoFlota.SelectParameters("id_Sucursal").DefaultValue = 999 'Iquique
            sds_MontoFlota.DataBind()
            Dim dt_MontoFlota As DataTable = CType(sds_MontoFlota.Select(DataSourceSelectArguments.Empty), DataView).Table

            Dim ValorFormateadoRojo As String = dt_MontoFlota.Rows(0).Item("ST").ToString()
            Dim ValorFormateadoAmarillo As String = dt_MontoFlota.Rows(0).Item("STOCK").ToString()
            Dim ValorFormateadoVerde As String = dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()

            Dim PorcentajeRojo As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
            Dim PorcentajeAmarillo As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
            Dim PorcentajeVerde As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100

            lbl_Rojo.Text = "&nbsp;<b>Servicio Técnico: </b>" + Format(ValorFormateadoRojo, "Currency").ToString()
            lbl_Amarillo.Text = "&nbsp;<b>Stock: </b>" + Format(ValorFormateadoAmarillo, "Currency").ToString()
            lbl_Verde.Text = "&nbsp;<b>En arriendo: </b>" + Format(ValorFormateadoVerde, "Currency").ToString()

            lbl_PorcentajeRojo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeRojo.ToString("N2") + "%)"
            lbl_PorcentajeAmarillo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeAmarillo.ToString("N2") + "%)"
            lbl_PorcentajeVerde.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeVerde.ToString("N2") + "%)"

            img_Iquique.Visible = True
            img_Arica.Visible = True
            img_AI.Visible = True
            'sds_TodosLosEquipos.DataBind()
            'gdv_Novedades.DataSource = sds_TodosLosEquipos
            'gdv_Novedades.DataBind()

            vli_contador = 0
            mtn_CargarGrilla()
            ddl_EstadoEquipos.SelectedValue = 2
            pnl_mensaje.Visible = False
        End If

    End Sub
#End Region


#Region "BOTONES"


    Protected Sub btn_DescargarBitacora_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim vli_id_Equipo As LinkButton = CType(sender, LinkButton)
        Try
            Dim pvi_idEquipoBitacora As Integer = vli_id_Equipo.CommandArgument
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?pvi_idEquipoBitacora=" & pvi_idEquipoBitacora & "&tiporeporte=15" & "','_newtab');", True)
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btn_VerCaso_Click(ByVal sender As Object, ByVal e As EventArgs)
        'mtn_CargarGrilla()
        Dim btn_VerCaso As Button = CType(sender, Button)
        Dim vli_id_Equipo As Integer = btn_VerCaso.CommandArgument

        ViewState("id_Equipo") = vli_id_Equipo

        sds_SoloEquipo.SelectParameters("id_Equipo").DefaultValue = vli_id_Equipo
        sds_SoloEquipo.DataBind()


        sds_Documentos.SelectParameters("id_Equipo").DefaultValue = vli_id_Equipo
        sds_Documentos.DataBind()
        gdv_Documentos.DataSource = sds_Documentos
        gdv_Documentos.DataBind()

        upp_dctos.Update()

        'Carga de SDS a DataTable
        Dim dt_Equipos As DataTable = CType(sds_SoloEquipo.Select(DataSourceSelectArguments.Empty), DataView).Table
        lbl_idEquipo.InnerText = vli_id_Equipo

        lbl_NumeroSerie.InnerText = ": " + dt_Equipos.Rows(0).Item("NumeroEquipo").ToString()
        'lbl_Nserie.InnerText = lbl_NumeroSerie.InnerText
        lbl_NombreEquipo.InnerText = ": " + dt_Equipos.Rows(0).Item("NombreEquipo").ToString()
        lbl_CabeceraNombre.InnerText = lbl_NombreEquipo.InnerText
        lbl_Horometro.InnerText = ": " + dt_Equipos.Rows(0).Item("Horometro").ToString()
        Dim ValorFormateado As String = dt_Equipos.Rows(0).Item("ValorCompra").ToString()
        lbl_ValorCompra.InnerText = ": " + Format(ValorFormateado, "Currency").ToString()
        lbl_Marca.InnerText = ": " + dt_Equipos.Rows(0).Item("MarcaEquipo").ToString()
        lbl_Modelo.InnerText = ": " + dt_Equipos.Rows(0).Item("ModeloEquipo").ToString()
        lbl_Color.InnerText = ": " + (dt_Equipos.Rows(0).Item("Color")).ToString()
        lbl_Patente.InnerText = ": " + dt_Equipos.Rows(0).Item("Patente").ToString()
        lbl_FechaAdquisicion.InnerText = ": " + dt_Equipos.Rows(0).Item("FechaAdquisicionEquipo").ToString()
        lbl_AfiDetalles.InnerText = ": " + dt_Equipos.Rows(0).Item("id_Equipo").ToString()
        'lbl_sucursal.InnerText = ": " + dt_Equipos.Rows(0).Item("NombreSucursal")
        Dim ValorFormateadoPrecioActual As String = dt_Equipos.Rows(0).Item("PrecioActual").ToString()
        lbl_PrecioActual.InnerText = ": " + Format(ValorFormateadoPrecioActual, "Currency").ToString()
        lbl_EstadoEquipo.InnerText = ": " + dt_Equipos.Rows(0).Item("NombreEstadoEquipo")
        'lbl_CabeceraEstado.InnerText = lbl_EstadoEquipo.InnerText
        lbl_AnhoEquipo.InnerText = ": " + dt_Equipos.Rows(0).Item("AnhoEquipo").ToString()
        lbl_Procedencia.InnerText = ": " + dt_Equipos.Rows(0).Item("Procedencia").ToString()

        Dim ValorFormateadoFacturadp As String = dt_Equipos.Rows(0).Item("Facturado").ToString()
        lbl_FactFecha.InnerText = ": " + Format(ValorFormateadoFacturadp, "Currency").ToString()

        Dim ValorFormateadoValorVenta As String = dt_Equipos.Rows(0).Item("ValorVenta").ToString()
        lbl_ValorVenta.InnerText = ": " + Format(ValorFormateadoValorVenta, "Currency").ToString()

        lbl_UltimaMantencion.InnerText = ": "
        lbl_ProximaMantencion.InnerText = ": "


        sds_SoloContratoXAfi.SelectParameters("id_Equipo").DefaultValue = vli_id_Equipo
        sds_SoloContratoXAfi.DataBind()

        Dim dt_Contrato As DataTable = CType(sds_SoloContratoXAfi.Select(DataSourceSelectArguments.Empty), DataView).Table
        If dt_Contrato.Rows.Count <> 0 Then

            lbl_idContrato.InnerText = dt_Contrato.Rows(0).Item("id_Contrato").ToString()
            lbl_RutCliente.InnerText = ": " + dt_Contrato.Rows(0).Item("RutCliente").ToString()
            lbl_NombreCliente.InnerText = ": " + dt_Contrato.Rows(0).Item("NombreCliente").ToString()
            'lbl_Afi.InnerText = ": " + dt_Contrato.Rows(0).Item("id_Equipo").ToString()
            lbl_NombreEquipo.InnerText = ": " + dt_Contrato.Rows(0).Item("NombreEquipo").ToString()

            lbl_FechaContrato.InnerText = ": " + dt_Contrato.Rows(0).Item("FechaContrato").ToString()
            'lbl_NombreZona.InnerText = ": " + dt_Contrato.Rows(0).Item("NombreZona").ToString()
            'lbl_Faena.InnerText = ": " + (dt_Contrato.Rows(0).Item("Faena")).ToString()
            'lbl_EstadoContrato.InnerText = ": " + dt_Contrato.Rows(0).Item("EstadoContrato").ToString()

            Dim ValorFormateadoVU As String = dt_Contrato.Rows(0).Item("ValorUnitario").ToString()
            lbl_ValorContrato.InnerText = ": " + Format(ValorFormateadoVU, "Currency").ToString()
            lbl_TipoUnidad.InnerText = ": " + dt_Contrato.Rows(0).Item("Tipounidad").ToString()
            lbl_Modelo.InnerText = ": " + dt_Contrato.Rows(0).Item("ModeloEquipo").ToString()

            'lbl_FechaDevolucion.InnerText = ": " + dt_Contrato.Rows(0).Item("FechaDevolucion").ToString()
            lbl_Guia.InnerText = ": " + dt_Contrato.Rows(0).Item("Guia").ToString()
            lbl_FechaRegistro.InnerText = ": " + dt_Contrato.Rows(0).Item("FechaRegistroContrato").ToString()

            Dim vls_Apellidos() As String = dt_Contrato.Rows(0).Item("Nombres").ToString().Split(" ")
            lbl_UsuarioRegistra.InnerText = ": " + vls_Apellidos(0) + " " + dt_Contrato.Rows(0).Item("Apaterno").ToString()

            'ddl_CambiarEstado.SelectedValue = dt_Contrato.Rows(0).Item("idEstadoContrato")
            pnl_Contrato.Visible = True
        Else
            upp_contrato.Update()
            pnl_Contrato.Visible = False

        End If


        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True)
        upp_Modal.Update()
        upp_contrato.Update()



    End Sub

    ''' <summary>
    ''' ELIMINAR DOCUMENTO ADJUNTO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Eliminar_Click(ByVal sender As Object, ByVal e As EventArgs)
        lbl_ErrorArchivo.Visible = False
        lbl_ErrorArchivo.Text = ""

        Dim btn_Eliminar As LinkButton = CType(sender, LinkButton)
        Dim vli_id_Documento As Integer = btn_Eliminar.CommandArgument

        Dim vlo_Caso As New RN.RN_PARQUE.cls_Parque
        If (vlo_Caso.fgb_EliminarDocumento(vli_id_Documento)) Then
            sds_Documentos.SelectParameters("id_Equipo").DefaultValue = Convert.ToInt32(lbl_idEquipo.InnerText)
            sds_Documentos.DataBind()
            gdv_Documentos.DataSource = sds_Documentos
            gdv_Documentos.DataBind()

        Else
            lbl_ErrorArchivo.Visible = True
            lbl_ErrorArchivo.Text = "Error al subir el archivo, puede que esté repetido."

            sds_Documentos.SelectParameters("id_Equipo").DefaultValue = Convert.ToInt32(lbl_idEquipo.InnerText)
            sds_Documentos.DataBind()
            gdv_Documentos.DataSource = sds_Documentos
            gdv_Documentos.DataBind()
        End If
    End Sub

    ''' <summary>
    ''' DESCARGAR DOCUMENTO ADJUNTO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Descargar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_Descargar As LinkButton = CType(sender, LinkButton)
        Dim vls_Argumentos As String() = btn_Descargar.CommandArgument.Split(","c)
        Dim vli_id_Docto As Integer = vls_Argumentos(0)
        Dim vls_NombreDocumento As String = vls_Argumentos(1)

        Dim id_Equipo As String = lbl_idEquipo.InnerText

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_Descarga.aspx?procedencia=2&caso=" & id_Equipo & "&documento=" & vls_NombreDocumento & "','_newtab');", True)
    End Sub

    ''' <summary>
    ''' BOTON SUBIR DOCUMENTOS.
    ''' </summary>
    ''' <param name="src"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub UploadFile(src As Object, e As EventArgs)
        lbl_ErrorArchivo.Visible = False
        lbl_ErrorArchivo.Text = ""
        Dim id_Equipo As String = Integer.Parse(lbl_idEquipo.InnerText)
        Dim vls_savePath As String = vgs_DirectorioArchivosTemporales & "\" & id_Equipo & "\"
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
            Dim vls_ExtensionesDisponibles() As String = {".pdf", ".xls", ".xlsx", ".doc", ".docx", ".jpeg", ".jpg", ".png", ".txt"}
            If vls_ExtensionesDisponibles.Contains((Path.GetExtension(SubirArchivo.FileName)).ToLower) Then
                Dim vlo_Caso As New RN.RN_PARQUE.cls_Parque
                If (vlo_Caso.fgb_AdjuntarDocumento(id_Equipo, vls_NombreArchivoLimpio, (vls_NombreArchivoLimpio + vls_Fecha + Path.GetExtension(SubirArchivo.FileName)))) Then
                    SubirArchivo.PostedFile.SaveAs(vls_savePath & "//" & (vls_NombreArchivoLimpio + vls_Fecha + Path.GetExtension(SubirArchivo.FileName)))
                Else
                    lbl_ErrorArchivo.Visible = True
                    lbl_ErrorArchivo.Text = "Error al subir el archivo, puede que esté repetido."
                End If
            Else
                lbl_ErrorArchivo.Visible = True
                lbl_ErrorArchivo.Text = "Error al subir el archivo, tiene una extensión no permitida."
            End If
        Else
            lbl_ErrorArchivo.Visible = True
            lbl_ErrorArchivo.Text = "Error al subir el archivo, no ha seleccionado ningún documento."
        End If
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True)
        sds_Documentos.SelectParameters("id_Equipo").DefaultValue = id_Equipo
        sds_Documentos.DataBind()
        gdv_Documentos.DataSource = sds_Documentos
        gdv_Documentos.DataBind()
    End Sub

    ''' <summary>
    ''' BOTÓN FILTRO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_filtrar_Click(sender As Object, e As EventArgs) Handles btn_filtrar.Click
        txt_BuscarAfi.Text = ""
        pnl_botones.Visible = True
        pnl_casos.Visible = True
        Dim pvi_familia, pvi_EstadoEquipo, pvi_Sucursal As Integer
        Dim pvs_Cliente As String

        If ddl_Familia.SelectedIndex = 0 Then
            pvi_familia = 999
        Else
            pvi_familia = ddl_Familia.SelectedValue
        End If

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

        If ddl_Clientes.SelectedIndex = 0 Then
            pvs_Cliente = "999"
        Else
            pvs_Cliente = ddl_Clientes.SelectedValue
        End If

        'If vli_contador = 0 Then
        '    pvi_familia = 999
        '    pvi_Sucursal = 999
        '    pvi_
        '    pvi_EstadoEquipo = 2
        'End If

        sds_equipos.SelectParameters("id_Familia").DefaultValue = pvi_familia
        sds_equipos.SelectParameters("EstadoEquipo").DefaultValue = pvi_EstadoEquipo
        sds_equipos.SelectParameters("id_Sucursal").DefaultValue = pvi_Sucursal
        sds_equipos.SelectParameters("id_Cliente").DefaultValue = pvs_Cliente
        sds_equipos.DataBind()

        gdv_Novedades.DataSource = sds_equipos
        gdv_Novedades.DataBind()
        If (gdv_Novedades.Rows.Count <> 0) Then
            gdv_Novedades.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_Novedades.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_Novedades.HeaderRow.Cells(3).Attributes("data-hide") = "phone"
            gdv_Novedades.HeaderRow.Cells(4).Attributes("data-hide") = "phone"

            gdv_Novedades.HeaderRow.TableSection = TableRowSection.TableHeader
            pnl_mensaje.Visible = False
        Else
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay equipos para este filtro."
        End If

        vli_contador = 1
        mtn_CargarGrilla()
    End Sub

    Private Sub img_Arica_Click(sender As Object, e As ImageClickEventArgs) Handles img_Arica.Click


        sds_MontoFlota.SelectParameters("id_Sucursal").DefaultValue = 2 'Arica
        sds_MontoFlota.DataBind()
        Dim dt_MontoFlota As DataTable = CType(sds_MontoFlota.Select(DataSourceSelectArguments.Empty), DataView).Table

        Dim ValorFormateadoRojo As String = dt_MontoFlota.Rows(0).Item("ST").ToString()
        Dim ValorFormateadoAmarillo As String = dt_MontoFlota.Rows(0).Item("STOCK").ToString()
        Dim ValorFormateadoVerde As String = dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()

        Dim PorcentajeRojo As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
        Dim PorcentajeAmarillo As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
        Dim PorcentajeVerde As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100

        lbl_Rojo.Text = "&nbsp;<b>Servicio Técnico: </b>" + Format(ValorFormateadoRojo, "Currency").ToString()
        lbl_Amarillo.Text = "&nbsp;<b>Stock: </b>" + Format(ValorFormateadoAmarillo, "Currency").ToString()
        lbl_Verde.Text = "&nbsp;<b>En arriendo: </b>" + Format(ValorFormateadoVerde, "Currency").ToString()

        lbl_PorcentajeRojo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeRojo.ToString("N2") + "%)"
        lbl_PorcentajeAmarillo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeAmarillo.ToString("N2") + "%)"
        lbl_PorcentajeVerde.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeVerde.ToString("N2") + "%)"
    End Sub

    Private Sub img_Iquique_Click(sender As Object, e As ImageClickEventArgs) Handles img_Iquique.Click


        sds_MontoFlota.SelectParameters("id_Sucursal").DefaultValue = 1 'Iquique
        sds_MontoFlota.DataBind()
        Dim dt_MontoFlota As DataTable = CType(sds_MontoFlota.Select(DataSourceSelectArguments.Empty), DataView).Table

        Dim ValorFormateadoRojo As String = dt_MontoFlota.Rows(0).Item("ST").ToString()
        Dim ValorFormateadoAmarillo As String = dt_MontoFlota.Rows(0).Item("STOCK").ToString()
        Dim ValorFormateadoVerde As String = dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()

        Dim PorcentajeRojo As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
        Dim PorcentajeAmarillo As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
        Dim PorcentajeVerde As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100

        lbl_Rojo.Text = "&nbsp;<b>Servicio Técnico: </b>" + Format(ValorFormateadoRojo, "Currency").ToString()
        lbl_Amarillo.Text = "&nbsp;<b>Stock: </b>" + Format(ValorFormateadoAmarillo, "Currency").ToString()
        lbl_Verde.Text = "&nbsp;<b>En arriendo: </b>" + Format(ValorFormateadoVerde, "Currency").ToString()

        lbl_PorcentajeRojo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeRojo.ToString("N2") + "%)"
        lbl_PorcentajeAmarillo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeAmarillo.ToString("N2") + "%)"
        lbl_PorcentajeVerde.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeVerde.ToString("N2") + "%)"
    End Sub

    Private Sub img_AI_Click(sender As Object, e As ImageClickEventArgs) Handles img_AI.Click


        sds_MontoFlota.SelectParameters("id_Sucursal").DefaultValue = 999 'Arica e Iquique
        sds_MontoFlota.DataBind()
        Dim dt_MontoFlota As DataTable = CType(sds_MontoFlota.Select(DataSourceSelectArguments.Empty), DataView).Table

        Dim ValorFormateadoRojo As String = dt_MontoFlota.Rows(0).Item("ST").ToString()
        Dim ValorFormateadoAmarillo As String = dt_MontoFlota.Rows(0).Item("STOCK").ToString()
        Dim ValorFormateadoVerde As String = dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()

        Dim PorcentajeRojo As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
        Dim PorcentajeAmarillo As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100
        Dim PorcentajeVerde As Double = Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()) / Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ST").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("STOCK").ToString() + Convert.ToInt64(dt_MontoFlota.Rows(0).Item("ARRIENDO").ToString()))) * 100

        lbl_Rojo.Text = "&nbsp;<b>Servicio Técnico: </b>" + Format(ValorFormateadoRojo, "Currency").ToString()
        lbl_Amarillo.Text = "&nbsp;<b>Stock: </b>" + Format(ValorFormateadoAmarillo, "Currency").ToString()
        lbl_Verde.Text = "&nbsp;<b>En arriendo: </b>" + Format(ValorFormateadoVerde, "Currency").ToString()

        lbl_PorcentajeRojo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeRojo.ToString("N2") + "%)"
        lbl_PorcentajeAmarillo.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeAmarillo.ToString("N2") + "%)"
        lbl_PorcentajeVerde.Text = "&nbsp;&nbsp;&nbsp;(" + PorcentajeVerde.ToString("N2") + "%)"
    End Sub
#End Region


    Private Sub mtn_CargarGrilla()
        txt_BuscarAfi.Text = ""
        Dim pvi_familia, pvi_EstadoEquipo, pvi_Sucursal As Integer
        Dim pvs_Cliente As String

        If ddl_Familia.SelectedIndex = -1 Or ddl_Familia.SelectedIndex = 0 Then
            pvi_familia = 999
        Else
            pvi_familia = ddl_Familia.SelectedValue
        End If

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

        If ddl_Clientes.SelectedIndex = -1 Or ddl_Clientes.SelectedIndex = 0 Then
            pvs_Cliente = "999"
        Else
            pvs_Cliente = ddl_Clientes.SelectedValue
        End If
        If vli_contador = 0 Then
            pvi_familia = 999
            pvi_Sucursal = 999
            pvi_EstadoEquipo = 2
        End If

        sds_equipos.SelectParameters("id_Familia").DefaultValue = pvi_familia
        sds_equipos.SelectParameters("EstadoEquipo").DefaultValue = pvi_EstadoEquipo
        sds_equipos.SelectParameters("id_Sucursal").DefaultValue = pvi_Sucursal
        sds_equipos.SelectParameters("id_Cliente").DefaultValue = pvs_Cliente
        sds_equipos.DataBind()

        gdv_Novedades.DataSource = sds_equipos
        gdv_Novedades.DataBind()
        gdv_Documentos.DataBind()

        'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
        If (gdv_Novedades.Rows.Count <> 0) Then
            gdv_Novedades.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_Novedades.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_Novedades.HeaderRow.Cells(3).Attributes("data-hide") = "phone"
            gdv_Novedades.HeaderRow.Cells(4).Attributes("data-hide") = "phone"

            gdv_Novedades.HeaderRow.TableSection = TableRowSection.TableHeader
        Else
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No hay equipos para este filtro."
        End If

        'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
        If (gdv_Documentos.Rows.Count <> 0) Then
            gdv_Documentos.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_Documentos.HeaderRow.Cells(1).Attributes("data-hide") = "phone"
            gdv_Documentos.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_Documentos.HeaderRow.Cells(3).Attributes("data-hide") = "phone"

            gdv_Documentos.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
        vli_contador = 1
    End Sub


    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ddl_EstadoEquipos.SelectedIndex = -1
        ddl_Familia.SelectedIndex = -1
        ddl_Sucursales.SelectedIndex = -1
        ddl_Clientes.SelectedIndex = -1

        sds_TodosLosEquipos.DataBind()
        gdv_Novedades.DataSource = sds_TodosLosEquipos
        gdv_Novedades.DataBind()

        mtn_CargarGrilla()
        pnl_mensaje.Visible = False
        txt_BuscarAfi.Text = ""
    End Sub

    Private Sub btn_BuscarPorAfi_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorAfi.Click
        If (txt_BuscarAfi.Text <> "") Then
            If IsNumeric(txt_BuscarAfi.Text) Then
                sds_EquipoXafi.SelectParameters("id_Equipo").DefaultValue = txt_BuscarAfi.Text
                sds_EquipoXafi.DataBind()
                gdv_Novedades.DataSource = sds_EquipoXafi
                gdv_Novedades.DataBind()

                'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
                If (gdv_Novedades.Rows.Count <> 0) Then
                    gdv_Novedades.HeaderRow.Cells(0).Attributes("data-class") = "expand"
                    gdv_Novedades.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
                    gdv_Novedades.HeaderRow.Cells(3).Attributes("data-hide") = "phone"
                    gdv_Novedades.HeaderRow.Cells(4).Attributes("data-hide") = "phone"

                    gdv_Novedades.HeaderRow.TableSection = TableRowSection.TableHeader
                Else
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay información para el AFI ingresado"
                    gdv_Novedades.DataSource = Nothing
                    gdv_Novedades.DataBind()
                End If
            Else
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Error!"
                lbl_mensaje2.InnerHtml = "   -   Solo ingrese números"
                gdv_Novedades.DataSource = Nothing
                gdv_Novedades.DataBind()
            End If
        Else
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Error!"
            lbl_mensaje2.InnerHtml = "   -  Favor indicar el AFI a buscar"
            gdv_Novedades.DataSource = Nothing
            gdv_Novedades.DataBind()

        End If


    End Sub

    Private Sub btn_Informe_Click(sender As Object, e As EventArgs) Handles btn_Informe.Click
        Dim pvi_familia, pvi_EstadoEquipo, pvi_Sucursal As Integer
        Dim pvs_Cliente As String


        If ddl_Familia.SelectedIndex = -1 Or ddl_Familia.SelectedIndex = 0 Then
            pvi_familia = 999
        Else
            pvi_familia = ddl_Familia.SelectedValue
        End If

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

        If ddl_Clientes.SelectedIndex = -1 Or ddl_Clientes.SelectedIndex = 0 Then
            pvs_Cliente = "999"
        Else
            pvs_Cliente = ddl_Clientes.SelectedValue
        End If

        Response.Redirect("frm_reportes.aspx?pvi_Familia=" & pvi_familia & "&pvi_EstadoEquipo=" & pvi_EstadoEquipo & "&pvi_Sucursal=" & pvi_Sucursal & "&pvs_Cliente=" & pvs_Cliente & "&tiporeporte=12", False)
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?pvi_Familia=" & pvi_familia & "&pvi_EstadoEquipo=" & pvi_EstadoEquipo & "&pvi_Sucursal=" & pvi_Sucursal & "&pvs_Cliente=" & pvs_Cliente & "&tiporeporte=12" & "','_newtab');", True)
    End Sub
End Class