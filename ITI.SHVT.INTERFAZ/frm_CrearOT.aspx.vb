Public Class frm_CrearOT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL

            If Session("id_TipoCargo") = 4 Then 'Usuario 4 - Jefe de servicio técnico
                Response.Redirect("~/frm_Inicio.aspx")
            End If

            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

            CrearGV()


            Dim dt_NumeroOTCrear As DataTable = CType(sds_NumeroOTCrear.Select(DataSourceSelectArguments.Empty), DataView).Table
            txt_NumeroOT.Text = dt_NumeroOTCrear.Rows(0).Item("NumeroOT").ToString()

            txt_FechaOT.Text = Today()
            txt_FechaOT.Text = Replace(txt_FechaOT.Text, "-", "/")
        End If
    End Sub

    Private Sub CrearGV()
        Dim dt_Trabajadores As New DataTable
        dt_Trabajadores.Columns.AddRange(New DataColumn(4) {New DataColumn("id_Trabajador"), New DataColumn("NombreTrabajador"), New DataColumn("Cargo"), New DataColumn("Tiempo"), New DataColumn("CostoHH")})
        ViewState("dt_Trabajadores") = dt_Trabajadores
        CargarGdvTrabajadores()

        Dim dt_Actividades As New DataTable
        dt_Actividades.Columns.AddRange(New DataColumn(1) {New DataColumn("id_Actividad"), New DataColumn("NombreActividad")})
        ViewState("dt_Actividades") = dt_Actividades
        CargarGdvActividades()
    End Sub

    Private Sub CargarGdvTrabajadores()
        gdv_TrabajadoresOT.DataSource = DirectCast(ViewState("dt_Trabajadores"), DataTable)
        gdv_TrabajadoresOT.DataBind()
    End Sub
    Private Sub CargarGdvActividades()
        gdv_ActividadesOT.DataSource = DirectCast(ViewState("dt_Actividades"), DataTable)
        gdv_ActividadesOT.DataBind()
    End Sub





    Private Sub btn_AgregarTrabajador_Click(sender As Object, e As EventArgs) Handles btn_AgregarTrabajador.Click
        If txt_Tiempo.Text <> "" And IsNumeric(txt_Tiempo.Text) And ddl_TrabajadorDeOT.SelectedIndex <> 0 Then
            Dim dt_Trabajadores As DataTable = DirectCast(ViewState("dt_Trabajadores"), DataTable)
            Dim id_Trabajador As Integer = ddl_TrabajadorDeOT.SelectedValue
            Dim Tiempo As Integer = Convert.ToInt32(txt_Tiempo.Text)

            Dim vlo_DatosTrabajador = New RN.cls_OT

            Try
                Dim tabla = vlo_DatosTrabajador.fgo_DatosTrabajadores(id_Trabajador, Tiempo)
                If tabla.Rows.Count > 0 Then
                    Dim NombreTrabajador As String = tabla.Rows(0).Item("NombreTrabajador")
                    Dim Cargo As String = tabla.Rows(0).Item("Cargo")
                    Dim TiempoTrabajador As String = tabla.Rows(0).Item("Tiempo")
                    Dim CostoHH As String = tabla.Rows(0).Item("CostoHH")

                    dt_Trabajadores.Rows.Add(id_Trabajador, NombreTrabajador, Cargo, Tiempo, CostoHH)


                    ViewState("dt_Trabajadores") = dt_Trabajadores
                    CargarGdvTrabajadores()

                End If
            Catch ex As Exception

            End Try

        End If
        ddl_TrabajadorDeOT.SelectedIndex = 0
        txt_Tiempo.Text = ""



    End Sub

    Private Sub btn_AgregarActividad_Click(sender As Object, e As EventArgs) Handles btn_AgregarActividad.Click
        If ddl_ActividadesOT.SelectedIndex <> 0 Then
            Dim dt_Actividades As DataTable = DirectCast(ViewState("dt_Actividades"), DataTable)
            Dim id_Actividad As Integer = ddl_ActividadesOT.SelectedValue
            Dim NombreActividad As String = ddl_ActividadesOT.SelectedItem.Text
            'Dim Tiempo As String = "30 m"

            Dim vlo_DatosTrabajador = New RN.cls_OT

            dt_Actividades.Rows.Add(id_Actividad, NombreActividad)
            ViewState("dt_Actividades") = dt_Actividades
            CargarGdvActividades()
            ddl_ActividadesOT.SelectedIndex = 0
        End If


    End Sub

    Private Sub gdv_TrabajadoresOT_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdv_TrabajadoresOT.RowCommand
        If e.CommandName = "Delete" Then
            If Not String.IsNullOrEmpty(e.CommandArgument.ToString()) Then
                Try
                    Dim rowIndex = Convert.ToInt32(e.CommandArgument)
                    Dim dt_Trabajadores As DataTable = DirectCast(ViewState("dt_Trabajadores"), DataTable)
                    'gdv_TrabajadoresOT.DeleteRow(rowIndex)
                    gdv_TrabajadoresOT.DataSource = Nothing
                    gdv_TrabajadoresOT.DataBind()
                    gdv_TrabajadoresOT.DeleteRow(rowIndex)
                    'dt_Trabajadores.Rows(rowIndex).Delete()
                    dt_Trabajadores.Rows.RemoveAt(rowIndex)
                    dt_Trabajadores.AcceptChanges()
                    ViewState("dt_Trabajadores") = dt_Trabajadores
                    CargarGdvTrabajadores()
                Catch ex As Exception
                    Dim algo = ex
                End Try
            End If
        End If
    End Sub

    Private Sub gdv_ActividadesOT_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdv_ActividadesOT.RowCommand
        If e.CommandName = "Delete" Then
            If Not String.IsNullOrEmpty(e.CommandArgument.ToString()) Then
                Try
                    Dim rowIndex = Convert.ToInt32(e.CommandArgument)
                    Dim dt_Actividades As DataTable = DirectCast(ViewState("dt_Actividades"), DataTable)
                    'gdv_TrabajadoresOT.DeleteRow(rowIndex)
                    gdv_ActividadesOT.DataSource = Nothing
                    gdv_ActividadesOT.DataBind()
                    gdv_ActividadesOT.DeleteRow(rowIndex)
                    'dt_Trabajadores.Rows(rowIndex).Delete()
                    dt_Actividades.Rows.RemoveAt(rowIndex)
                    dt_Actividades.AcceptChanges()
                    ViewState("dt_Actividades") = dt_Actividades
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

    Private Sub frm_CrearOT_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Supervisor.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_Supervisor.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_Supervisor.SelectedIndex = 0
        End If

        If (ddl_Responsable.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_Responsable.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_Responsable.SelectedIndex = 0
        End If

        If (ddl_ActividadesOT.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_ActividadesOT.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_ActividadesOT.SelectedIndex = 0
        End If

        If (ddl_TiposOT.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_TiposOT.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_TiposOT.SelectedIndex = 0
        End If

        If (ddl_TrabajadorDeOT.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_TrabajadorDeOT.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_TrabajadorDeOT.SelectedIndex = 0
        End If
    End Sub



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

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        txt_AFI.Text = ""
        txt_FechaOT.Text = ""
        txt_Tiempo.Text = ""
        ddl_ActividadesOT.SelectedIndex = -1
        ddl_Responsable.SelectedIndex = -1
        ddl_Supervisor.SelectedIndex = -1
        ddl_TiposOT.SelectedIndex = -1
        ddl_TrabajadorDeOT.SelectedIndex = -1

        txt_FechaOT.Text = Today()
        txt_FechaOT.Text = Replace(txt_FechaOT.Text, "-", "/")


        gdv_ActividadesOT.DataSource = Nothing
        gdv_ActividadesOT.DataBind()
        gdv_TrabajadoresOT.DataSource = Nothing
        gdv_TrabajadoresOT.DataBind()
        ViewState("dt_Actividades") = Nothing
        ViewState("dt_Trabajadores") = Nothing
        CrearGV()
        'CargarGdvTrabajadores()
        'CargarGdvActividades()
    End Sub

    Private Sub btn_GenerarOT_Click(sender As Object, e As EventArgs) Handles btn_GenerarOT.Click
        Dim pvi_NumeroOT As Integer = txt_NumeroOT.Text
        Dim pvd_FechaOT As Date = txt_FechaOT.Text
        Dim pvi_AFI As Integer = txt_AFI.Text
        Dim pvi_IdTipoOT As Integer = ddl_TiposOT.SelectedValue
        Dim pvi_Responsable As Integer = ddl_Responsable.SelectedValue
        Dim pvi_Supervisor As Integer = ddl_Supervisor.SelectedValue
        Dim vlo_RegistrarOT As New RN.cls_OT
        Dim contadorActividades As Integer = 0
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()

        For i = 0 To gdv_ActividadesOT.Rows.Count - 1
            If (vlo_RegistrarOT.fgb_RegistrarActividadOT(pvi_NumeroOT,
                                                         gdv_ActividadesOT.Rows(i).Cells(0).Text)) Then

            End If
            contadorActividades = contadorActividades + 1
        Next

        Dim contadorTrabajadores As Integer = 0
        For i = 0 To gdv_TrabajadoresOT.Rows.Count - 1
            If (vlo_RegistrarOT.fgb_RegistrarTrabajadordOT(pvi_NumeroOT,
                                                         gdv_TrabajadoresOT.Rows(i).Cells(0).Text,
                                                         gdv_TrabajadoresOT.Rows(i).Cells(3).Text)) Then

            End If
            contadorTrabajadores = contadorTrabajadores + 1
        Next
        If (vlo_RegistrarOT.fgb_RegistrarOT(pvi_NumeroOT,
                                            pvi_AFI,
                                            pvi_Responsable,
                                            pvi_Supervisor,
                                            pvd_FechaOT,
                                            pvi_IdTipoOT,
                                            pvi_idUsuario)) Then

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_GenerarOT", "$('#mpe_GenerarOT').modal();", True)

            Dim dt_NumeroOTCrear As DataTable = CType(sds_NumeroOTCrear.Select(DataSourceSelectArguments.Empty), DataView).Table
            txt_NumeroOT.Text = dt_NumeroOTCrear.Rows(0).Item("NumeroOT").ToString()
        Else
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCausaError", "$('#mpe_VerCausaError').modal();", True)
        End If


    End Sub

    Private Sub btn_DescargarOT_Click(sender As Object, e As EventArgs) Handles btn_DescargarOT.Click
        limpiar()
        Dim dt_NumeroOTCrear As DataTable = CType(sds_NumeroOTCrear.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim pvi_idOT As Integer = Convert.ToInt64(dt_NumeroOTCrear.Rows(0).Item("NumeroOT").ToString) - 1
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?pvi_idOT=" & pvi_idOT & "&tiporeporte=9" & "','_newtab');", True)

    End Sub
End Class