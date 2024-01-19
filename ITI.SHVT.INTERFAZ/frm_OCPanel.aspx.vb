Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading
Imports ITI.SHVT.SERV
Imports Microsoft.Reporting.WebForms
Imports System.Web.UI.WebControls
Public Class frm_OCPanel
    Inherits System.Web.UI.Page

#Region "INICIO"

    '' FORM LOAD
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.pnl_MensajeAdvertenciaGuardado.Visible = False
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

            Dim dt_Detalle As New DataTable
            dt_Detalle.Columns.AddRange(New DataColumn(4) {New DataColumn("NumeroFactura"), New DataColumn("FechaFactura"), New DataColumn("FechaPago"), New DataColumn("ValorFactura"), New DataColumn("EstadoFactura")})
            ViewState("dt_Detalle") = dt_Detalle
            CargarGdvDetalle()


            sds_OCProveedores.DataBind()
            gdv_OCPendientes.DataSource = sds_OCProveedores
            gdv_OCPendientes.DataBind()
        End If
    End Sub

    ''PRE RENDER
    Private Sub frm_OCPanel_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_NombreProveedor.Items.FindByText("Todos los proveedores...") Is Nothing) Then
            ddl_NombreProveedor.Items.Insert(0, New ListItem("Todos los proveedores...", "", True))

            ddl_NombreProveedor.SelectedIndex = 0
        End If

        If (ddl_EstadosOT.Items.FindByText("Todos los estados...") Is Nothing) Then
            ddl_EstadosOT.Items.Insert(0, New ListItem("Todos los estados...", "", True))

            ddl_EstadosOT.SelectedIndex = 0
        End If
    End Sub
#End Region

#Region "BOTONES"
    ''DETALLES DE LA OC
    Protected Sub btn_DetallesOC_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_DetallesOC As LinkButton = CType(sender, LinkButton)
        Dim pvi_idOC As Integer = btn_DetallesOC.CommandArgument

        sds_SoloOC.SelectParameters("id_OC").DefaultValue = pvi_idOC
        sds_SoloOC.DataBind()

        'Carga de SDS a DataTable
        Dim dt_OC As DataTable = CType(sds_SoloOC.Select(DataSourceSelectArguments.Empty), DataView).Table

        lbl_NOC.InnerText = pvi_idOC
        lbl_Proveedor.InnerText = ": " + dt_OC.Rows(0).Item("NombreProveedor").ToString()
        lbl_Rut.InnerText = ": " + dt_OC.Rows(0).Item("RutProveedor").ToString()

        lbl_FechaOC.InnerText = ": " + dt_OC.Rows(0).Item("FechaOC").ToString()


        lbl_CN.InnerText = ": " + dt_OC.Rows(0).Item("NombreCentroCostoPadre").ToString()
        lbl_CC.InnerText = ": " + dt_OC.Rows(0).Item("NombreCentroCostoHijo").ToString()
        lbl_Pago.InnerText = ": " + dt_OC.Rows(0).Item("NombreMedioPago").ToString()

        lbl_Aprobador.InnerText = ": " + dt_OC.Rows(0).Item("UsuarioAprobador").ToString()
        lbl_Contacto.InnerText = ": " + dt_OC.Rows(0).Item("NombreContactoProveedor").ToString()

        If dt_OC.Rows(0).Item("NumeroFactura").ToString() = 0 Then
            lbl_NF.InnerText = ": No ingresada"
        Else
            lbl_NF.InnerText = ": " + dt_OC.Rows(0).Item("NumeroFactura").ToString()
        End If


        sds_SoloOCDetalle.SelectParameters("id_OC").DefaultValue = pvi_idOC
        sds_SoloOCDetalle.DataBind()
        gdv_oc.DataSource = sds_SoloOCDetalle
        gdv_oc.DataBind()

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True)
        upp_Modal.Update()
        upp_oc.Update()
    End Sub

    ''DESCARGAR OC
    Protected Sub btn_DescargarOC_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_DescargarOC As LinkButton = CType(sender, LinkButton)
        Dim pvi_idOC As Integer = btn_DescargarOC.CommandArgument

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?pvi_idOC=" & pvi_idOC & "&tiporeporte=16" & "','_newtab');", True)
    End Sub

    ''ANULAR OC
    Protected Sub btn_EliminarOC_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_EliminarOC As LinkButton = CType(sender, LinkButton)
        Dim pvi_idOC As Integer = btn_EliminarOC.CommandArgument
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()

        Dim vlo_ActualizarEstadoOC As New RN.cls_OrdenDeCompra

        Dim pvi_EstadoOC As Integer = 4 'PASA DE PENDIENTE DE APROBACIÓN A PENDIENTE DE PROCESAMIENTO

        If (vlo_ActualizarEstadoOC.fgb_ActualizarEstadoOC(pvi_idOC, pvi_EstadoOC, pvi_idUsuario)) Then
            If txt_BuscarXOT.Text <> "" Then
                sds_OCxOC.SelectParameters("id_OC").DefaultValue = txt_BuscarXOT.Text
                sds_OCxOC.DataBind()

                gdv_OCPendientes.DataSource = sds_OCxOC
                gdv_OCPendientes.DataBind()
            Else
                Dim EstadoOC As Integer
                Dim id_Proveedor As String
                txt_BuscarXOT.Text = ""

                If ddl_EstadosOT.SelectedIndex <> 0 Then
                    EstadoOC = ddl_EstadosOT.SelectedValue
                Else
                    EstadoOC = 999
                End If

                If ddl_NombreProveedor.SelectedIndex <> 0 Then
                    id_Proveedor = ddl_NombreProveedor.SelectedValue
                Else
                    id_Proveedor = "999"
                End If

                sds_OCxProveedor.SelectParameters("id_Proveedor").DefaultValue = id_Proveedor
                sds_OCxProveedor.SelectParameters("EstadoOC").DefaultValue = EstadoOC
                sds_OCxProveedor.DataBind()

                gdv_OCPendientes.DataSource = sds_OCxProveedor
                gdv_OCPendientes.DataBind()
            End If
        End If
    End Sub

    ''APROBAR OC
    Protected Sub btn_AprobarOC_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_AprobarOC As LinkButton = CType(sender, LinkButton)
        Dim pvi_idOC As Integer = btn_AprobarOC.CommandArgument
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()

        Dim vlo_ActualizarEstadoOC As New RN.cls_OrdenDeCompra

        Dim pvi_EstadoOC As Integer = 2 'PASA DE PENDIENTE DE APROBACIÓN A PENDIENTE DE PROCESAMIENTO

        If (vlo_ActualizarEstadoOC.fgb_ActualizarEstadoOC(pvi_idOC, pvi_EstadoOC, pvi_idUsuario)) Then

            If txt_BuscarXOT.Text <> "" Then
                sds_OCxOC.SelectParameters("id_OC").DefaultValue = txt_BuscarXOT.Text
                sds_OCxOC.DataBind()

                gdv_OCPendientes.DataSource = sds_OCxOC
                gdv_OCPendientes.DataBind()
            Else
                Dim EstadoOC As Integer
                Dim id_Proveedor As String
                txt_BuscarXOT.Text = ""

                If ddl_EstadosOT.SelectedIndex <> 0 Then
                    EstadoOC = ddl_EstadosOT.SelectedValue
                Else
                    EstadoOC = 999
                End If

                If ddl_NombreProveedor.SelectedIndex <> 0 Then
                    id_Proveedor = ddl_NombreProveedor.SelectedValue
                Else
                    id_Proveedor = "999"
                End If

                sds_OCxProveedor.SelectParameters("id_Proveedor").DefaultValue = id_Proveedor
                sds_OCxProveedor.SelectParameters("EstadoOC").DefaultValue = EstadoOC
                sds_OCxProveedor.DataBind()

                gdv_OCPendientes.DataSource = sds_OCxProveedor
                gdv_OCPendientes.DataBind()
            End If
        End If
    End Sub

    ''PROCESAR OC
    Protected Sub btn_ProcesarOC_Click(ByVal sender As Object, ByVal e As EventArgs)
        pnl_MensajeAdvertenciaGuardado.Visible = False ' Establecer el panel como no visible inicialmente


        Dim btn_ProcesarOC As LinkButton = CType(sender, LinkButton)
        Dim pvi_idOC As Integer = btn_ProcesarOC.CommandArgument
        lbl_nocf.InnerText = pvi_idOC
        lbl_nocf.Visible = True

        sds_FactrurasXOC.SelectParameters("id_OC").DefaultValue = pvi_idOC
        sds_FactrurasXOC.DataBind()
        gdv_FacturasXOC.DataSource = sds_FactrurasXOC
        gdv_FacturasXOC.DataBind()


        sds_FacturadoXOC.SelectParameters("id_OC").DefaultValue = pvi_idOC
        sds_FacturadoXOC.DataBind()

        Dim dt_OC As DataTable = CType(sds_FacturadoXOC.Select(DataSourceSelectArguments.Empty), DataView).Table

        Dim TotalOC As String = dt_OC.Rows(0).Item("TotalOC").ToString()
        Dim TotalFacturado As String = dt_OC.Rows(0).Item("TotalFacturado").ToString()

        lbl_TotalOC.InnerText = "Total OC: " + TotalOC
        lbl_TotalFacturado.InnerText = "Total Facturado: " + TotalFacturado


        Dim dv As DataView = DirectCast(sds_FactrurasXOC.Select(DataSourceSelectArguments.Empty), DataView)
        ViewState("dt_Detalle") = DirectCast(dv.ToTable, DataTable)


        If gdv_FacturasXOC.Rows.Count = 0 Then
            txt_FechaFacturacion.Text = ""
            txt_NumeroFactura.Text = ""
            txt_ValorFactura.Text = ""
            txt_NumeroFactura.Focus()
            gdv_FacturasXOC.DataSource = Nothing
            gdv_FacturasXOC.DataBind()
            ViewState("dt_Detalle") = Nothing
            CrearGV()
        Else
            txt_FechaFacturacion.Text = ""
            txt_NumeroFactura.Text = ""
            txt_ValorFactura.Text = ""
            txt_NumeroFactura.Focus()
        End If


        upp_facturas.Update()
        upp_facturas2.Update()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_ProcesarOC", "$('#mpe_ProcesarOC').modal();", True)

    End Sub

    Private Sub limpiarfactura()

        txt_FechaFacturacion.Text = ""
        txt_NumeroFactura.Text = ""
        txt_ValorFactura.Text = ""
        txt_NumeroFactura.Focus()
        gdv_FacturasXOC.DataSource = Nothing
        gdv_FacturasXOC.DataBind()


    End Sub

    ''AGREGAR DATOS A LA FILA
    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        If (txt_NumeroFactura.Text <> "" And IsNumeric(txt_NumeroFactura.Text)) And (IsNumeric(txt_ValorFactura.Text) And txt_ValorFactura.Text <> "") And txt_FechaFacturacion.Text <> "" Then
            Dim dt_Detalle As DataTable = DirectCast(ViewState("dt_Detalle"), DataTable)

            Dim NumeroFactura As String = txt_NumeroFactura.Text
            Dim FechaFactura As String = txt_FechaFacturacion.Text
            Dim FechaPago As String = Nothing
            Dim ValorFactura As String = txt_ValorFactura.Text 'Format((Convert.ToDouble(txt_ValorFactura.Text)), "Currency")
            Dim EstadoFactura As String = "Pago pendiente"

            dt_Detalle.Rows.Add(NumeroFactura, FechaFactura, FechaPago, ValorFactura, EstadoFactura)

            ViewState("dt_Detalle") = dt_Detalle
            CargarGdvDetalle()
            txt_NumeroFactura.Text = ""
            txt_FechaFacturacion.Text = ""
            txt_ValorFactura.Text = ""

            txt_NumeroFactura.Focus()
        End If
        upp_facturas.Update()
    End Sub

    Private Sub TimerCallback(ByVal state As Object)
        ' Ocultar el panel después de 3 segundos
        pnl_MensajeAdvertenciaGuardado.Visible = False
    End Sub

    ''GUARDAR CAMBIOS
    Private Sub btn_GuardarCambios_Click(sender As Object, e As EventArgs) Handles btn_GuardarCambios.Click
        ' Deshabilitar el botón y mostrar el spinner
        btn_GuardarCambios.Attributes.Add("disabled", "disabled")
        btn_GuardarCambios.CssClass += " spinner-border spinner-border-sm"

        ' Deshabilitar el botón y cambiar el texto a "Cargando..."

        btn_GuardarCambios.Attributes.Add("data-original-text", btn_GuardarCambios.Text)
        btn_GuardarCambios.Text = "Cargando..."



        Dim pvi_idOC As Integer = lbl_nocf.InnerText
        Dim vlo_OC As New RN.cls_OrdenDeCompra

        If gdv_FacturasXOC.Rows.Count = 0 Then
            vlo_OC.fgb_EliminarFacturaOC(pvi_idOC)
        End If


        For i = 0 To gdv_FacturasXOC.Rows.Count - 1

            vlo_OC.fgb_EliminarFacturaOC(pvi_idOC)
        Next

        For i = 0 To gdv_FacturasXOC.Rows.Count - 1
            Dim pvi_NumeroFactura As String = gdv_FacturasXOC.Rows(i).Cells(0).Text
            Dim pvd_FechaFactura As Date = gdv_FacturasXOC.Rows(i).Cells(1).Text
            Dim pvd_FechaPago As String = gdv_FacturasXOC.Rows(i).Cells(2).Text
            Dim pvi_TotalFactura As Double = Replace(Replace(gdv_FacturasXOC.Rows(i).Cells(3).Text, ".", ""), "$", "")


            Dim pvi_Estado As Integer
            If gdv_FacturasXOC.Rows(i).Cells(4).Text = "Pago pendiente" Then
                pvi_Estado = 1
            Else
                pvi_Estado = 2
            End If


            vlo_OC.fgb_RegistrarFactura(pvi_idOC, pvi_NumeroFactura, pvd_FechaFactura, pvd_FechaPago, pvi_TotalFactura, pvi_Estado)

        Next
        upp_facturas.Update()
        upp_facturas2.Update()

        sds_FacturadoXOC.SelectParameters("id_OC").DefaultValue = pvi_idOC
        sds_FacturadoXOC.DataBind()

        Dim dt_OC As DataTable = CType(sds_FacturadoXOC.Select(DataSourceSelectArguments.Empty), DataView).Table

        Dim TotalOC As String = dt_OC.Rows(0).Item("TotalOC").ToString()
        Dim TotalFacturado As String = dt_OC.Rows(0).Item("TotalFacturado").ToString()

        lbl_TotalOC.InnerText = "Total OC: " + TotalOC
        lbl_TotalFacturado.InnerText = "Total Facturado: " + TotalFacturado

        ' Habilitar el botón y quitar el spinner
        btn_GuardarCambios.CssClass = btn_GuardarCambios.CssClass.Replace("spinner-border spinner-border-sm", "")

        ' Restaurar el texto original del botón y habilitarlo
        btn_GuardarCambios.Text = btn_GuardarCambios.Attributes("data-original-text")
        btn_GuardarCambios.Attributes.Remove("data-original-text")
        btn_GuardarCambios.Attributes.Remove("disabled")

        Me.lbl_MensajeAdvertenciaGuardado.Text = "Registro grabado con éxito."

        Me.pnl_MensajeAdvertenciaGuardado.CssClass = String.Format("alert alert-{0} alert-dismissable", TipoMensaje.Success.ToString().ToLower())
        Me.pnl_MensajeAdvertenciaGuardado.Attributes.Add("role", "alert")
        Me.pnl_MensajeAdvertenciaGuardado.Visible = True

        pnl_MensajeAdvertenciaGuardado.Visible = True
        ' Ejecutar el temporizador para ocultar el panel después de 3 segundos
        Dim timer As New Timer(AddressOf TimerCallback, Nothing, 3000, Timeout.Infinite)

    End Sub

    Private Sub btn_ProcesarFactura_Click(sender As Object, e As EventArgs) Handles btn_ProcesarFactura.Click

        Dim pvi_idOC As Integer = lbl_nocf.InnerText
        Dim vlo_ActualizarEstadoOC As New RN.cls_OrdenDeCompra
        Dim pvi_EstadoOC As Integer = 3 'PASA DE PENDIENTE DE PROCESAMIENTO A PROCESADA

        sds_FacturadoXOC.SelectParameters("id_OC").DefaultValue = lbl_nocf.InnerText
        sds_FacturadoXOC.DataBind()

        Dim dt_OC As DataTable = CType(sds_FacturadoXOC.Select(DataSourceSelectArguments.Empty), DataView).Table

        Dim TotalOC As String = dt_OC.Rows(0).Item("TotalOC").ToString()
        Dim TotalFacturado As String = dt_OC.Rows(0).Item("TotalFacturado").ToString()

        If TotalOC = TotalFacturado Then
            If (vlo_ActualizarEstadoOC.fgb_ProcesarOC(pvi_idOC, pvi_EstadoOC)) Then
                'MsgBox("Orden de compra procesada con éxito.")
                panelMensaje.CssClass = "alert alert-success"
                panelMensaje.Visible = True
                lblMensaje.Text = "¡Operación exitosa!"
                RecargarGrilla()
            Else
                'MsgBox("Error al procesar la Orden de compra.")
                panelMensaje.CssClass = "alert alert-success"
                panelMensaje.Visible = True
                lblMensaje.Text = "¡Operación exitosa!"
                RecargarGrilla()
            End If
            Exit Sub
        Else
            'MsgBox("Aún no es posible procesar, el valor de la OC es distinto al Facturado.")
            panelMensaje.CssClass = "alert alert-danger"
            panelMensaje.Visible = True
            lblMensaje.Text = "¡Error en la operación!"
            RecargarGrilla()
            Exit Sub
        End If
    End Sub
#End Region

    Private Sub RecargarGrilla()
        ''CARGAR LISTA.
        If txt_BuscarXOT.Text <> "" Then
            sds_OCxOC.SelectParameters("id_OC").DefaultValue = txt_BuscarXOT.Text
            sds_OCxOC.DataBind()

            gdv_OCPendientes.DataSource = sds_OCxOC
            gdv_OCPendientes.DataBind()

            If gdv_OCPendientes.Rows.Count = 0 Then
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No hay Ordenes de compra el número de OC ingresado."
                gdv_OCPendientes.DataSource = Nothing
                gdv_OCPendientes.DataBind()

                txt_BuscarXOT.Focus()
            Else
                pnl_mensaje.Visible = False
            End If

            ddl_EstadosOT.SelectedIndex = -1
            ddl_NombreProveedor.SelectedIndex = -1

            upp_GrillaPermisos.Update()
        Else
            Dim EstadoOC As Integer
            Dim id_Proveedor As String
            txt_BuscarXOT.Text = ""

            If ddl_EstadosOT.SelectedIndex <> 0 Then
                EstadoOC = ddl_EstadosOT.SelectedValue
            Else
                EstadoOC = 999
            End If

            If ddl_NombreProveedor.SelectedIndex <> 0 Then
                id_Proveedor = ddl_NombreProveedor.SelectedValue
            Else
                id_Proveedor = "999"
            End If

            If ddl_NombreProveedor.SelectedIndex <> -1 Then
                sds_OCxProveedor.SelectParameters("id_Proveedor").DefaultValue = id_Proveedor
                sds_OCxProveedor.SelectParameters("EstadoOC").DefaultValue = EstadoOC
                sds_OCxProveedor.DataBind()

                gdv_OCPendientes.DataSource = sds_OCxProveedor
                gdv_OCPendientes.DataBind()

                If gdv_OCPendientes.Rows.Count = 0 Then
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay Ordenes de compra para el filtro seleccionado."
                    gdv_OCPendientes.DataSource = Nothing
                    gdv_OCPendientes.DataBind()
                Else
                    pnl_mensaje.Visible = False
                End If
            End If
            upp_GrillaPermisos.Update()
        End If
    End Sub


#Region "DROPDOWNLIST"
    ''DDL NOMBRE PROVEEDOR
    Private Sub ddl_NombreProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_NombreProveedor.SelectedIndexChanged
        Dim EstadoOC As Integer
        Dim id_Proveedor As String
        txt_BuscarXOT.Text = ""

        If ddl_EstadosOT.SelectedIndex <> 0 Then
            EstadoOC = ddl_EstadosOT.SelectedValue
        Else
            EstadoOC = 999
        End If

        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            id_Proveedor = ddl_NombreProveedor.SelectedValue
        Else
            id_Proveedor = "999"
        End If

        If ddl_NombreProveedor.SelectedIndex <> -1 Then
            sds_OCxProveedor.SelectParameters("id_Proveedor").DefaultValue = id_Proveedor
            sds_OCxProveedor.SelectParameters("EstadoOC").DefaultValue = EstadoOC
            sds_OCxProveedor.DataBind()

            gdv_OCPendientes.DataSource = sds_OCxProveedor
            gdv_OCPendientes.DataBind()

            If gdv_OCPendientes.Rows.Count = 0 Then
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No hay Ordenes de compra para el filtro seleccionado."
                gdv_OCPendientes.DataSource = Nothing
                gdv_OCPendientes.DataBind()
            Else
                pnl_mensaje.Visible = False
            End If
        End If
    End Sub

    ''DDL ESTADOS OC
    Private Sub ddl_EstadosOT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_EstadosOT.SelectedIndexChanged
        Dim EstadoOC As Integer
        Dim id_Proveedor As String
        txt_BuscarXOT.Text = ""

        If ddl_EstadosOT.SelectedIndex <> 0 Then
            EstadoOC = ddl_EstadosOT.SelectedValue
        Else
            EstadoOC = 999
        End If

        If ddl_NombreProveedor.SelectedIndex <> 0 Then
            id_Proveedor = ddl_NombreProveedor.SelectedValue
        Else
            id_Proveedor = "999"
        End If

        If ddl_EstadosOT.SelectedIndex <> -1 Then

            sds_OCxProveedor.SelectParameters("id_Proveedor").DefaultValue = id_Proveedor
            sds_OCxProveedor.SelectParameters("EstadoOC").DefaultValue = EstadoOC
            sds_OCxProveedor.DataBind()

            gdv_OCPendientes.DataSource = sds_OCxProveedor
            gdv_OCPendientes.DataBind()

            If gdv_OCPendientes.Rows.Count = 0 Then
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No hay Ordenes de compra para el filtro seleccionado."
                gdv_OCPendientes.DataSource = Nothing
                gdv_OCPendientes.DataBind()
            Else
                pnl_mensaje.Visible = False
            End If
        End If
    End Sub
#End Region


#Region "TEXTBOX"
    ''TEXTBOT BUSCAR OC
    Private Sub txt_BuscarXOT_TextChanged(sender As Object, e As EventArgs) Handles txt_BuscarXOT.TextChanged
        If IsNumeric(txt_BuscarXOT.Text) Then
            sds_OCxOC.SelectParameters("id_OC").DefaultValue = txt_BuscarXOT.Text
            sds_OCxOC.DataBind()

            gdv_OCPendientes.DataSource = sds_OCxOC
            gdv_OCPendientes.DataBind()

            If gdv_OCPendientes.Rows.Count = 0 Then
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No hay Ordenes de compra el número de OC ingresado."
                gdv_OCPendientes.DataSource = Nothing
                gdv_OCPendientes.DataBind()

                txt_BuscarXOT.Focus()
            Else
                pnl_mensaje.Visible = False
            End If

            ddl_EstadosOT.SelectedIndex = -1
            ddl_NombreProveedor.SelectedIndex = -1
        Else
        End If
    End Sub


    Private Sub txt_ValorFactura_TextChanged(sender As Object, e As EventArgs) Handles txt_ValorFactura.TextChanged
        Dim varaux As String = Replace(Replace(txt_ValorFactura.Text, "$", ""), ".", "")

        If IsNumeric(varaux) Then
            Dim ValorFactura As String = Format((Convert.ToDouble(varaux)), "Currency")
            txt_ValorFactura.Text = ValorFactura
        End If


    End Sub
#End Region

#Region "GRIEDVIEW"
    ''CREAR GDV DETALLE
    Private Sub CrearGV()
        Dim dt_Detalle As New DataTable
        dt_Detalle.Columns.AddRange(New DataColumn(4) {New DataColumn("NumeroFactura"), New DataColumn("FechaFactura"), New DataColumn("FechaPago"), New DataColumn("ValorFactura"), New DataColumn("EstadoFactura")})
        ViewState("dt_Detalle") = dt_Detalle
        CargarGdvDetalle()
    End Sub

    ''CARGAR GDV DETALLE
    Private Sub CargarGdvDetalle()
        gdv_FacturasXOC.DataSource = DirectCast(ViewState("dt_Detalle"), DataTable)
        gdv_FacturasXOC.DataBind()
    End Sub

    ''BORRAR FILA DE DETALLE
    Private Sub gdv_FacturasXOC_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdv_FacturasXOC.RowCommand

        If e.CommandName = "Delete" Then
            If Not String.IsNullOrEmpty(e.CommandArgument.ToString()) Then
                Try
                    Dim rowIndex = Convert.ToInt32(e.CommandArgument)

                    Dim dt_Detalle As DataTable = DirectCast(ViewState("dt_Detalle"), DataTable)

                    gdv_FacturasXOC.DataSource = Nothing
                    gdv_FacturasXOC.DataBind()
                    gdv_FacturasXOC.DeleteRow(rowIndex)

                    dt_Detalle.Rows.RemoveAt(rowIndex)
                    dt_Detalle.AcceptChanges()
                    ViewState("dt_Detalle") = dt_Detalle
                    CargarGdvDetalle()
                Catch ex As Exception
                    Dim algo = ex
                End Try
            End If
        End If
    End Sub



    ''METODO PARA DELETE FILA
    Private Sub gdv_FacturasXOC_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gdv_FacturasXOC.RowDeleting
        Try

        Catch ex As Exception
            Dim algo = ex
        End Try
    End Sub








#End Region

#Region "ENUMERADOR"
    Public Enum TipoMensaje
        Success
        Info
        Warning
        Danger
    End Enum
#End Region

End Class