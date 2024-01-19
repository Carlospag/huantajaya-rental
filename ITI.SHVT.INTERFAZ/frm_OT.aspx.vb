Public Class frm_OT
    Inherits System.Web.UI.Page

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



            sds_OT.DataBind()
            gdv_OT.DataSource = sds_OT
            gdv_OT.DataBind()

            Dim dt_Trabajadores As New DataTable
            dt_Trabajadores.Columns.AddRange(New DataColumn(4) {New DataColumn("id_Trabajador"), New DataColumn("NombreTrabajador"), New DataColumn("NombreTipoCargo"), New DataColumn("HorasTrabajadorOT"), New DataColumn("CostoHH")})
            ViewState("dt_Trabajadores2") = dt_Trabajadores
            CargarGdvTrabajadores()

            Dim dt_Actividades As New DataTable
            dt_Actividades.Columns.AddRange(New DataColumn(1) {New DataColumn("id_Actividad"), New DataColumn("NombreActividad")})
            ViewState("dt_Actividades2") = dt_Actividades
            CargarGdvActividades()

            ''Dim dt_Repuestos As New DataTable
            ''dt_Repuestos.Columns.AddRange(New DataColumn(2) {New DataColumn("id_RepuestosXOT"), New DataColumn("NombreRepuesto"), New DataColumn("ValorRepuesto")})
            ''ViewState("dt_Repuestos") = dt_Repuestos
            ''CargarGdvRepuestos()
        End If
    End Sub
    ''PRE RENDER COMPLETE
    Private Sub frm_OT_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_EstadosOT.Items.FindByText("Todos...") Is Nothing) Then
            ddl_EstadosOT.Items.Insert(0, New ListItem("Todos...", "", True))

            ddl_EstadosOT.SelectedIndex = 0
        End If
        If (ddl_TrabajadorDeOT.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_TrabajadorDeOT.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_TrabajadorDeOT.SelectedIndex = 0
        End If

        If (ddl_ActividadesOT.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_ActividadesOT.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_ActividadesOT.SelectedIndex = 0
        End If



    End Sub
#End Region

#Region "BOTONES (INICIAR, PAUSA, ELIMINAR, DESCARGAR)"
    ''ABRIR EL MODAL PARA PARALIZAR UNA OT
    Protected Sub btn_PausarOT_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_PausarOT As LinkButton = CType(sender, LinkButton)
        Dim pvi_idOT As Integer = btn_PausarOT.CommandArgument
        lbl_OT.InnerText = pvi_idOT
        upp_modalPausa.Update()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_IngresarObservacion", "$('#mpe_IngresarObservacion').modal();", True)
    End Sub
    ''GUARDAR LOS CAMBIOS EN LA PARALIZACION
    Private Sub btn_GuardarCambiosPausa_Click(sender As Object, e As EventArgs) Handles btn_GuardarCambiosPausa.Click


        Dim vlo_ActualizarEstadoOT As New RN.cls_OT

        Dim pvi_idOT As Integer = Convert.ToUInt64(lbl_OT.InnerText)

        Dim pvi_EstadoOT As Integer = 3 'PASA DE ESTADO DE PARALIZACIÓN
        Dim pvs_Observacion As String = txt_ObservacionesParalizacionOT.InnerText

        If pvs_Observacion = "" Then
            pvs_Observacion = "Pausada sin ingresar observación"
        Else
            pvs_Observacion = pvs_Observacion
        End If

        If (vlo_ActualizarEstadoOT.fgb_ActualizarEstadoOT(pvi_idOT, pvi_EstadoOT, pvs_Observacion)) Then
            txt_ObservacionesParalizacionOT.InnerText = ""
            sds_OT.DataBind()
            gdv_OT.DataSource = sds_OT
            gdv_OT.DataBind()
        End If



    End Sub

    ''ABRIR EL MODAL PARA ANULAR UNA OT
    Protected Sub btn_EliminarOT_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim btn_EliminarOT As LinkButton = CType(sender, LinkButton)
        Dim pvi_idOT As Integer = btn_EliminarOT.CommandArgument
        lbl_OTAnulacion.InnerText = pvi_idOT
        upp_ModalAnulacion.Update()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_IngresarObservacionAnulacion", "$('#mpe_IngresarObservacionAnulacion').modal();", True)
        upp_ModalAnulacion.Update()




    End Sub
    ''GUARDAR LOS CAMBIOS EN LA ANULACIÓN
    Private Sub btn_GuardarCambiosAnulacion_Click(sender As Object, e As EventArgs) Handles btn_GuardarCambiosAnulacion.Click
        Dim vlo_ActualizarEstadoOT As New RN.cls_OT

        Dim pvi_idOT As Integer = Convert.ToUInt64(lbl_OTAnulacion.InnerText)

        Dim pvi_EstadoOT As Integer = 999 'NO MODIFICAR ESTADO
        Dim pvs_Observacion As String = txt_ObservacionesAnulacionOT.InnerText

        If pvs_Observacion = "" Then
            pvs_Observacion = "Usuario guardo cambios sin ingresar información."
        Else
            pvs_Observacion = pvs_Observacion
        End If

        If (vlo_ActualizarEstadoOT.fgb_ActualizarEstadoOT(pvi_idOT, pvi_EstadoOT, pvs_Observacion)) Then
            txt_ObservacionesAnulacionOT.InnerText = ""
            sds_OT.DataBind()
            gdv_OT.DataSource = sds_OT
            gdv_OT.DataBind()
        End If
    End Sub

    ''INICIAR O REANUDAR UNA OT
    Protected Sub btn_Iniciar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_Iniciar As LinkButton = CType(sender, LinkButton)
        Dim vli_OT As Integer = btn_Iniciar.CommandArgument
        Dim vlo_ActualizarEstadoOT As New RN.cls_OT

        Dim pvi_EstadoOT As Integer = 2 'PASA DE PROGRAMADA A INICIADA
        Dim pvs_Observacion As String = ""

        If (vlo_ActualizarEstadoOT.fgb_ActualizarEstadoOT(vli_OT, pvi_EstadoOT, pvs_Observacion)) Then
            sds_OT.DataBind()
            gdv_OT.DataSource = sds_OT
            gdv_OT.DataBind()
        End If
        upp_Novedades.Update()
    End Sub

    ''DESCARGAR UNA OT
    Protected Sub btn_DescargarOT_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_DescargarOT As LinkButton = CType(sender, LinkButton)
        Try
            Dim pvi_idOT As Integer = btn_DescargarOT.CommandArgument
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?pvi_idOT=" & pvi_idOT & "&tiporeporte=9" & "','_newtab');", True)
        Catch ex As Exception
        End Try
    End Sub

    ''MODIFICAR UNA OT
    Protected Sub btn_ModificarOT_Click(ByVal sender As Object, ByVal e As EventArgs)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        Dim ModificarOT As LinkButton = CType(sender, LinkButton)
        Dim pvi_idOT As Integer = ModificarOT.CommandArgument
        lbl_OTEditar.InnerText = pvi_idOT
        upp_EditarOT.Update()

        sds_OTxID.SelectParameters("id_OT").DefaultValue = pvi_idOT
        sds_OTxID.DataBind()
        Dim dt_OTxID As DataTable = CType(sds_OTxID.Select(DataSourceSelectArguments.Empty), DataView).Table
        txt_NumeroOT.Text = dt_OTxID.Rows(0).Item("ID_ot").ToString()
        txt_FechaOT.Text = dt_OTxID.Rows(0).Item("FechaOT").ToString()
        txt_AFI.Text = dt_OTxID.Rows(0).Item("id_Equipo").ToString()
        ddl_TiposOT.SelectedValue = dt_OTxID.Rows(0).Item("id_TipoOT").ToString()
        ddl_Responsable.Text = dt_OTxID.Rows(0).Item("id_Responsable").ToString()
        ddl_Supervisor.Text = dt_OTxID.Rows(0).Item("id_Supervisor").ToString()
        txt_ObservacionesEditar.InnerText = dt_OTxID.Rows(0).Item("Notas").ToString().Replace("<br/>", System.Environment.NewLine)
        txt_CostoRepuesto.Text = dt_OTxID.Rows(0).Item("CostoRepuesto").ToString()
        ddl_CambiarEstadoOT.SelectedValue = dt_OTxID.Rows(0).Item("id_EstadoOT").ToString()

        sds_TrabajadoresXOT.SelectParameters("id_OT").DefaultValue = pvi_idOT
        sds_TrabajadoresXOT.DataBind()
        gdv_TrabajadoresOT.DataSource = sds_TrabajadoresXOT
        gdv_TrabajadoresOT.DataBind()
        Dim dv As DataView = DirectCast(sds_TrabajadoresXOT.Select(DataSourceSelectArguments.Empty), DataView)

        ViewState("dt_Trabajadores2") = DirectCast(dv.ToTable, DataTable)
        sds_ActividadesXOT.SelectParameters("id_OT").DefaultValue = pvi_idOT
        sds_ActividadesXOT.DataBind()
        gdv_ActividadesOT.DataSource = sds_ActividadesXOT
        gdv_ActividadesOT.DataBind()

        Dim dv1 As DataView = DirectCast(sds_ActividadesXOT.Select(DataSourceSelectArguments.Empty), DataView)

        ViewState("dt_Actividades2") = DirectCast(dv1.ToTable, DataTable)

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_EditarOT", "$('#mpe_EditarOT').modal();", True)
        upp_EditarOT.Update()
    End Sub

    ''Agregar Trabajador a la lista
    Private Sub btn_AgregarTrabajador_Click(sender As Object, e As EventArgs) Handles btn_AgregarTrabajador.Click
        If txt_Tiempo.Text <> "" And IsNumeric(txt_Tiempo.Text) And ddl_TrabajadorDeOT.SelectedIndex <> 0 Then
            Dim dt_Trabajadores As DataTable = DirectCast(ViewState("dt_Trabajadores2"), DataTable)
            Dim id_Trabajador As Integer = ddl_TrabajadorDeOT.SelectedValue
            Dim Tiempo As Integer = Convert.ToInt32(txt_Tiempo.Text)

            Dim vlo_DatosTrabajador = New RN.cls_OT

            Try
                Dim tabla = vlo_DatosTrabajador.fgo_DatosTrabajadores(id_Trabajador, Tiempo)
                If tabla.Rows.Count > 0 Then
                    Dim NombreTrabajador As String = tabla.Rows(0).Item("NombreTrabajador")
                    Dim NombreTipoCargo As String = tabla.Rows(0).Item("Cargo")
                    Dim HorasTrabajadorOT As String = tabla.Rows(0).Item("Tiempo")
                    Dim CostoHH As String = tabla.Rows(0).Item("CostoHH")


                    dt_Trabajadores.Rows.Add(id_Trabajador, NombreTrabajador, NombreTipoCargo, HorasTrabajadorOT, CostoHH)


                    ViewState("dt_Trabajadores2") = dt_Trabajadores
                    CargarGdvTrabajadores()

                End If
            Catch ex As Exception

            End Try

        End If
        ddl_TrabajadorDeOT.SelectedIndex = 0
        txt_Tiempo.Text = ""

    End Sub
    ''Agregar Actividad a la lista
    Private Sub btn_AgregarActividad_Click(sender As Object, e As EventArgs) Handles btn_AgregarActividad.Click
        If ddl_ActividadesOT.SelectedIndex <> 0 Then
            Dim dt_Actividades As DataTable = DirectCast(ViewState("dt_Actividades2"), DataTable)
            Dim id_Actividad As Integer = ddl_ActividadesOT.SelectedValue
            Dim NombreActividad As String = ddl_ActividadesOT.SelectedItem.Text
            'Dim Tiempo As String = "30 m"

            Dim vlo_DatosTrabajador = New RN.cls_OT

            dt_Actividades.Rows.Add(id_Actividad, NombreActividad)
            ViewState("dt_Actividades2") = dt_Actividades
            CargarGdvActividades()
            ddl_ActividadesOT.SelectedIndex = 0
        End If


    End Sub

    ''Private Sub btn_AgregarGasto_Click(sender As Object, e As EventArgs) Handles btn_AgregarGasto.Click

    ''    Dim dt_Repuestos As DataTable = DirectCast(ViewState("dt_Repuestos"), DataTable)
    ''    Dim id_Repuesto As Integer = 1
    ''    Dim NombreRepuesto As String = txt_Gasto.Text
    ''    Dim ValorRepuesto As Integer = txt_CostoRepuesto.Text

    ''    'Dim Tiempo As String = "30 m"

    ''    Dim vlo_DatosTrabajador = New RN.cls_OT

    ''    dt_Repuestos.Rows.Add(id_Repuesto, NombreRepuesto, ValorRepuesto)
    ''    ViewState("dt_Repuestos") = dt_Repuestos
    ''    CargarGdvRepuestos()


    ''End Sub

    ''Borrar Trabajadores
    Private Sub gdv_TrabajadoresOT_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdv_TrabajadoresOT.RowCommand
        If e.CommandName = "Delete" Then
            If Not String.IsNullOrEmpty(e.CommandArgument.ToString()) Then
                Try
                    Dim rowIndex = Convert.ToInt32(e.CommandArgument)
                    Dim dt_Trabajadores As DataTable = DirectCast(ViewState("dt_Trabajadores2"), DataTable)
                    'gdv_TrabajadoresOT.DeleteRow(rowIndex)
                    gdv_TrabajadoresOT.DataSource = Nothing
                    gdv_TrabajadoresOT.DataBind()
                    gdv_TrabajadoresOT.DeleteRow(rowIndex)
                    'dt_Trabajadores.Rows(rowIndex).Delete()
                    dt_Trabajadores.Rows.RemoveAt(rowIndex)
                    dt_Trabajadores.AcceptChanges()
                    ViewState("dt_Trabajadores2") = dt_Trabajadores
                    CargarGdvTrabajadores()
                Catch ex As Exception
                    Dim algo = ex
                End Try
            End If
        End If
    End Sub

    ''Borrar Actividades
    Private Sub gdv_ActividadesOT_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdv_ActividadesOT.RowCommand
        If e.CommandName = "Delete" Then
            If Not String.IsNullOrEmpty(e.CommandArgument.ToString()) Then
                Try
                    Dim rowIndex = Convert.ToInt32(e.CommandArgument)
                    Dim dt_Actividades As DataTable = DirectCast(ViewState("dt_Actividades2"), DataTable)

                    gdv_ActividadesOT.DataSource = Nothing
                    gdv_ActividadesOT.DataBind()
                    gdv_ActividadesOT.DeleteRow(rowIndex)

                    dt_Actividades.Rows.RemoveAt(rowIndex)
                    dt_Actividades.AcceptChanges()
                    ViewState("dt_Actividades2") = dt_Actividades
                    CargarGdvActividades()
                Catch ex As Exception
                    Dim algo = ex
                End Try
            End If
        End If
    End Sub

    Private Sub gdv_TrabajadoresOT_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gdv_TrabajadoresOT.RowDeleting
        Try

        Catch ex As Exception
            Dim algo = ex
        End Try
    End Sub
    Private Sub gdv_ActividadesOT_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gdv_ActividadesOT.RowDeleting
        Try

        Catch ex As Exception
            Dim algo = ex
        End Try
    End Sub


#End Region

#Region "BOTONES BUSQUEDA DE OT"
    ''BOTON BUSCAR POR NÚMERO DE OT
    Private Sub btn_BuscarPorOT_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorOT.Click

        txt_BuscarAfi.Text = ""
        ddl_EstadosOT.SelectedIndex = -1
        txt_FechaInicio.Text = ""
        txt_FechaTermino.Text = ""

        If txt_BuscarXOT.Text = "" Then
            pnl_mensaje.Visible = True

            gdv_OT.DataSource = Nothing
            gdv_OT.DataBind()
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -    No ingreso ningún valor, asegurese de estar buscando por Número de OT"
            Exit Sub
        Else
            If IsNumeric(txt_BuscarXOT.Text) Then
                sds_OTxOTGrilla.SelectParameters("id_OT").DefaultValue = Convert.ToInt32(txt_BuscarXOT.Text)
                sds_OTxOTGrilla.DataBind()

                gdv_OT.DataSource = sds_OTxOTGrilla
                gdv_OT.DataBind()

                pnl_mensaje.Visible = False

                If gdv_OT.Rows.Count = 0 Then
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay Ordenes de Trabajo para el Número de OT ingresado."
                    gdv_OT.DataSource = Nothing
                    gdv_OT.DataBind()
                End If
            Else

                gdv_OT.DataSource = Nothing
                gdv_OT.DataBind()
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No ingreso un Valor Númerico"
            End If
        End If




    End Sub

    ''BOTON BUSCAR POR AFI
    Private Sub btn_BuscarPorAfi_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorAfi.Click
        txt_BuscarXOT.Text = ""
        ddl_EstadosOT.SelectedIndex = -1
        txt_FechaInicio.Text = ""
        txt_FechaTermino.Text = ""

        If txt_BuscarAfi.Text = "" Then
            pnl_mensaje.Visible = True
            lbl_mensaje1.InnerHtml = "Información!"
            lbl_mensaje2.InnerHtml = "   -   No ingreso ningún valor, asegurese de estar buscando por AFI."
            gdv_OT.DataSource = Nothing
            gdv_OT.DataBind()
            Exit Sub
        Else
            If IsNumeric(txt_BuscarAfi.Text) Then
                sds_OTxAFIGrilla.SelectParameters("id_Equipo").DefaultValue = Convert.ToInt32(txt_BuscarAfi.Text)
                sds_OTxAFIGrilla.DataBind()

                gdv_OT.DataSource = sds_OTxAFIGrilla
                gdv_OT.DataBind()

                pnl_mensaje.Visible = False

                If gdv_OT.Rows.Count = 0 Then
                    pnl_mensaje.Visible = True
                    lbl_mensaje1.InnerHtml = "Información!"
                    lbl_mensaje2.InnerHtml = "   -   No hay Ordenes de Trabajo para el Número de AFI ingresado."
                    gdv_OT.DataSource = Nothing
                    gdv_OT.DataBind()
                End If
            Else
                pnl_mensaje.Visible = True
                lbl_mensaje1.InnerHtml = "Información!"
                lbl_mensaje2.InnerHtml = "   -   No ingreso un Valor Númerico."
                gdv_OT.DataSource = Nothing
                gdv_OT.DataBind()
            End If
        End If





    End Sub

    ''BOTON BUSQUEDA POR FILTROS
    Private Sub btn_filtrar_Click(sender As Object, e As EventArgs) Handles btn_filtrar.Click
        Dim pvs_FechaInicio As String
        Dim pvs_FechaTermino As String
        Dim pvi_EstadoOT As Integer

        If txt_FechaInicio.Text = "" Then
            pvs_FechaInicio = 999
            pvs_FechaTermino = 999
        Else
            pvs_FechaInicio = txt_FechaInicio.Text
            pvs_FechaTermino = txt_FechaTermino.Text
        End If

        If ddl_EstadosOT.SelectedIndex = 0 Then
            pvi_EstadoOT = 999
        Else
            pvi_EstadoOT = ddl_EstadosOT.SelectedValue
        End If

        sds_OTxFiltros.SelectParameters("EstadoOT").DefaultValue = pvi_EstadoOT
        sds_OTxFiltros.SelectParameters("FechaInicio").DefaultValue = pvs_FechaInicio
        sds_OTxFiltros.SelectParameters("FechaTermino").DefaultValue = pvs_FechaTermino
        sds_OTxFiltros.DataBind()

        gdv_OT.DataSource = sds_OTxFiltros
        gdv_OT.DataBind()
    End Sub

    ''BOTON LIMPIAR FILTROS
    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        txt_BuscarXOT.Text = ""
        txt_BuscarAfi.Text = ""
        ddl_EstadosOT.SelectedIndex = -1
        txt_FechaInicio.Text = ""
        txt_FechaTermino.Text = ""
    End Sub

    ''GUARDAR CAMBIOS DEL BOTON "EDITAR OT"
    Private Sub btn_GuardarCambiosEditar_Click(sender As Object, e As EventArgs) Handles btn_GuardarCambiosEditar.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        Dim pvi_NumeroOT As Integer = txt_NumeroOT.Text
        Dim pvd_FechaOT As Date = txt_FechaOT.Text
        Dim pvi_AFI As Integer = txt_AFI.Text
        Dim pvi_IdTipoOT As Integer = ddl_TiposOT.SelectedValue
        Dim pvi_Responsable As Integer = ddl_Responsable.SelectedValue
        Dim pvi_Supervisor As Integer = ddl_Supervisor.SelectedValue
        Dim vlo_RegistrarOT As New RN.cls_OT
        Dim contadorActividades As Integer = 0
        Dim pvi_CostoRepuesto As Integer = txt_CostoRepuesto.Text
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim Observacion As String = txt_ObservacionesEditar.InnerText
        Dim pvi_EstadoOT As Integer = ddl_CambiarEstadoOT.SelectedValue

        ''For i = 0 To gdv_ActividadesOT.Rows.Count - 1
        ''    If (vlo_RegistrarOT.fgb_RegistrarActividadOT(pvi_NumeroOT,
        ''                                                 gdv_ActividadesOT.Rows(i).Cells(0).Text)) Then

        ''    End If
        ''    contadorActividades = contadorActividades + 1
        ''Next

        ''Dim contadorTrabajadores As Integer = 0
        ''For i = 0 To gdv_TrabajadoresOT.Rows.Count - 1
        ''    If (vlo_RegistrarOT.fgb_RegistrarTrabajadordOT(pvi_NumeroOT,
        ''                                                 gdv_TrabajadoresOT.Rows(i).Cells(0).Text,
        ''                                                 gdv_TrabajadoresOT.Rows(i).Cells(3).Text)) Then

        ''    End If
        ''    contadorTrabajadores = contadorTrabajadores + 1
        ''Next

        If (vlo_RegistrarOT.fgb_ActualizarOT(pvi_NumeroOT,
                                            pvi_AFI,
                                            pvi_Responsable,
                                            pvi_Supervisor,
                                            pvd_FechaOT,
                                            pvi_IdTipoOT,
                                            pvi_CostoRepuesto,
                                            pvi_EstadoOT)) Then


            If (vlo_RegistrarOT.fgb_ElimiarActividadOT(pvi_NumeroOT)) Then
                For i = 0 To gdv_ActividadesOT.Rows.Count - 1
                    If (vlo_RegistrarOT.fgb_RegistrarActividadOT(pvi_NumeroOT,
                                                         gdv_ActividadesOT.Rows(i).Cells(0).Text)) Then
                    End If
                    contadorActividades = contadorActividades + 1
                Next
            End If

            If (vlo_RegistrarOT.fgb_ElimiarTrabajadorOT(pvi_NumeroOT)) Then
                For i = 0 To gdv_TrabajadoresOT.Rows.Count - 1
                    If (vlo_RegistrarOT.fgb_RegistrarTrabajadordOT(pvi_NumeroOT,
                                                         gdv_TrabajadoresOT.Rows(i).Cells(0).Text,
                        gdv_TrabajadoresOT.Rows(i).Cells(3).Text)) Then
                    End If
                    contadorActividades = contadorActividades + 1
                Next
            End If



            sds_OT.DataBind()
            gdv_OT.DataSource = sds_OT
                gdv_OT.DataBind()
                upp_Novedades.Update()
            End If
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Private Sub CargarGdvTrabajadores()
        gdv_TrabajadoresOT.DataSource = DirectCast(ViewState("dt_Trabajadores2"), DataTable)
        gdv_TrabajadoresOT.DataBind()
    End Sub
    Private Sub CargarGdvActividades()
        gdv_ActividadesOT.DataSource = DirectCast(ViewState("dt_Actividades2"), DataTable)
        gdv_ActividadesOT.DataBind()
    End Sub

    ''Private Sub CargarGdvRepuestos()
    ''    gdv_Gastos.DataSource = DirectCast(ViewState("dt_Repuestos"), DataTable)
    ''    gdv_Gastos.DataBind()
    ''End Sub

#End Region
#Region "VALIDACIONES"
    ''Validar existencia de Equipo (AFI)
    Private Sub txt_AFI_TextChanged(sender As Object, e As EventArgs) Handles txt_AFI.TextChanged
        If (txt_AFI.Text <> "") Then
            If IsNumeric(txt_AFI.Text) Then
                sds_SoloEquipo.SelectParameters("id_Equipo").DefaultValue = txt_AFI.Text
                sds_SoloEquipo.DataBind()
                'Carga de SDS a DataTable
                Dim dt_Equipos As DataTable = CType(sds_SoloEquipo.Select(DataSourceSelectArguments.Empty), DataView).Table
                If dt_Equipos.Rows.Count = 0 Then
                    lbl_Afi.InnerHtml = "Error! - Afi no encontrado."
                    lbl_Afi.Visible = True
                    txt_AFI.Text = ""
                    txt_AFI.Focus()
                Else
                    lbl_Afi.Visible = False
                    lbl_Afi.InnerText = ""
                End If
            Else
                lbl_Afi.InnerHtml = "Ingrese solo números."
                lbl_Afi.Visible = True
                txt_AFI.Text = ""
                txt_AFI.Focus()
                Exit Sub
            End If
        Else
            lbl_Afi.InnerHtml = "Campo Requerido"
            lbl_Afi.Visible = True
            txt_AFI.Focus()
        End If
    End Sub


#End Region



End Class