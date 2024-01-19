Public Class frm_CertificadosMantencion
    Inherits System.Web.UI.Page

    Private Sub frm_IngresarMantencion_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Familia.Items.FindByText("Seleccione familia...") Is Nothing) Then
            ddl_Familia.Items.Insert(0, New ListItem("Seleccione familia...", "", True))

            ddl_Familia.SelectedIndex = 0
        End If
        If (ddl_Equipos.Items.FindByText("Seleccione equipo...") Is Nothing) Then
            ddl_Equipos.Items.Insert(0, New ListItem("Seleccione equipo...", "", True))

            ddl_Equipos.SelectedIndex = 0
        End If

        If (ddl_Clientes.Items.FindByText("Seleccionar cliente...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("Seleccionar cliente...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If
        End If
    End Sub
#Region "BOTONES"

    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ddl_Equipos.SelectedIndex = -1
        ddl_Familia.SelectedIndex = -1
        txt_BuscarAfi.Text = ""

        'sds_TodosLosEquipos.DataBind()
        gdv_Novedades.DataSource = Nothing
        gdv_Novedades.DataBind()

        'mtn_CargarGrilla()
    End Sub


    Protected Sub btn_VerCaso_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim btn_VerCaso As Button = CType(sender, Button)
        Dim vli_id_Equipo As Integer = btn_VerCaso.CommandArgument
        Dim pvi_RutCliente As String = ddl_Clientes.SelectedValue
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?idrc=" & vli_id_Equipo & "&rutCliente=" & pvi_RutCliente & "&tiporeporte=4" & "','_newtab');", True)
        'Response.Redirect("frm_reportes.aspx?idrc=" & vli_id_Equipo & "&rutCliente=" & pvi_RutCliente & "&tiporeporte=4", False)
        'Context.ApplicationInstance.CompleteRequest()
    End Sub



    Private Sub btn_BuscarPorAfi_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorAfi.Click
        If (txt_BuscarAfi.Text <> "") Then
            If IsNumeric(txt_BuscarAfi.Text) Then
                sds_EquipoXidequipo.SelectParameters("id_Equipo").DefaultValue = Convert.ToInt64(txt_BuscarAfi.Text)
                sds_EquipoXidequipo.DataBind()

                gdv_Novedades.DataSource = sds_EquipoXidequipo
                gdv_Novedades.DataBind()
                'Carga de SDS a DataTable
                Dim dt_Equipos As DataTable = CType(sds_EquipoXidequipo.Select(DataSourceSelectArguments.Empty), DataView).Table

                If dt_Equipos.Rows.Count = 0 Then
                    lbl_ErrorAfi.InnerHtml = "Error! - Afi no encontrado."
                    lbl_ErrorAfi.Visible = True
                    txt_BuscarAfi.Text = ""
                Else
                    lbl_ErrorAfi.Visible = False
                End If
            Else
                lbl_ErrorAfi.InnerHtml = "Ingrese solo números."
                lbl_ErrorAfi.Visible = True
                txt_BuscarAfi.Text = ""
                txt_BuscarAfi.Focus()
                Exit Sub
            End If
        End If
    End Sub


#End Region

#Region "METODOS Y FUNCIONES"
    Private Sub mtn_CargarGrilla()
        gdv_Novedades.DataSource = sds_EquipoXidequipo
        gdv_Novedades.DataBind()



        'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
        If (gdv_Novedades.Rows.Count <> 0) Then
            gdv_Novedades.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_Novedades.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_Novedades.HeaderRow.Cells(3).Attributes("data-hide") = "phone"
            gdv_Novedades.HeaderRow.Cells(4).Attributes("data-hide") = "phone"

            gdv_Novedades.HeaderRow.TableSection = TableRowSection.TableHeader
        End If


    End Sub
#End Region

#Region "DROPDOWNLIST"
    Private Sub ddl_Familia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Familia.SelectedIndexChanged
        sds_EquiposXFamilia.SelectParameters("id_Familia").DefaultValue = ddl_Familia.SelectedValue
        sds_EquiposXFamilia.DataBind()
        txt_BuscarAfi.Text = ""
    End Sub

    Private Sub ddl_Equipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Equipos.SelectedIndexChanged
        sds_EquipoXidequipo.SelectParameters("id_Equipo").DefaultValue = ddl_Equipos.SelectedValue
        sds_EquipoXidequipo.DataBind()
        txt_BuscarAfi.Text = ddl_Equipos.SelectedValue

        gdv_Novedades.DataSource = sds_EquipoXidequipo
        gdv_Novedades.DataBind()
    End Sub


#End Region
End Class