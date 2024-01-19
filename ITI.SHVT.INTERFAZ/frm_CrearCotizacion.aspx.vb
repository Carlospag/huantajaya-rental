Public Class frm_CrearCotizacion
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

            If Session("id_TipoCargo") = 4 Then 'Usuario 4 - Jefe de servicio técnico
                Response.Redirect("~/frm_Inicio.aspx")
            End If
            lbl_Precio.InnerHtml = "Precio"
        End If
    End Sub

    Private Sub frm_CrearCotizacion_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Familia.Items.FindByText("Seleccione familia...") Is Nothing) Then
            ddl_Familia.Items.Insert(0, New ListItem("Seleccione familia...", "", True))

            ddl_Familia.SelectedIndex = 0
        End If
        If (ddl_Equipos.Items.FindByText("Seleccione Modelo...") Is Nothing) Then
            ddl_Equipos.Items.Insert(0, New ListItem("Seleccione Modelo...", "", True))

            ddl_Equipos.SelectedIndex = 0
        End If

        If (ddl_SeleccionEquipo.Items.FindByText("Seleccione equipo...") Is Nothing) Then
            ddl_SeleccionEquipo.Items.Insert(0, New ListItem("Seleccione equipo...", "", True))

            ddl_SeleccionEquipo.SelectedIndex = 0
        End If
        If (ddl_Clientes.Items.FindByText("Seleccione cliente...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("Seleccione cliente...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If

        If (ddl_TipoCotizacion.Items.FindByText("Seleccione Tipo...") Is Nothing) Then
            ddl_TipoCotizacion.Items.Insert(0, New ListItem("Seleccione Tipo...", "", True))

            ddl_TipoCotizacion.SelectedIndex = 0
        End If

        If (ddl_Modalidad.Items.FindByText("Seleccione modalidad...") Is Nothing) Then
            ddl_Modalidad.Items.Insert(0, New ListItem("Seleccione modalidad...", "", True))

            ddl_Modalidad.SelectedIndex = 0
        End If

        If (ddl_Vendedores.Items.FindByText("Seleccione vendedor...") Is Nothing) Then
            ddl_Vendedores.Items.Insert(0, New ListItem("Seleccione vendedor...", "", True))

            ddl_Vendedores.SelectedIndex = 0
        End If
        If (ddl_ValorAlternativo.Items.FindByText("No mostrar...") Is Nothing) Then
            ddl_ValorAlternativo.Items.Insert(0, New ListItem("No mostrar...", "", True))

            ddl_ValorAlternativo.SelectedIndex = 0
        End If
    End Sub
#End Region

#Region "BOTONES"
    Private Sub btn_GenerarCotizacion_Click(sender As Object, e As EventArgs) Handles btn_GenerarCotizacion.Click
        Dim vla_ListaImplementaciones(lbx_Implementaciones.Items.Count) As Integer
        Dim vla_ListaCondiciones(lbx_CondicionesArriendo.Items.Count) As Integer
        Dim vli_i As Integer = 0
        Dim vli_o As Integer = 0

        Dim pvi_idEquipo As Integer = ddl_SeleccionEquipo.SelectedValue
        Dim pvs_idCliente As String = ddl_Clientes.SelectedValue
        Dim pvi_idVendedor As Integer = ddl_Vendedores.SelectedValue
        Dim pvi_Modalidad As Integer = ddl_Modalidad.SelectedValue
        Dim pvi_TipoCotizacion As Integer = ddl_TipoCotizacion.SelectedValue
        Dim pvs_Contacto As String = txt_Contacto.Text
        Dim pvs_Faena As String = txt_Faena.Text
        Dim pvi_Precio As Integer = txt_Precio.Text
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvi_idZona As Integer = ddl_Zonas.SelectedValue
        Dim pvi_CantHoras As Integer
        Dim pvs_TextoAlternativo As String

        If txt_CantHoras.Text = "" Then
            pvi_CantHoras = 999
        Else
            pvi_CantHoras = txt_CantHoras.Text
        End If

        If ddl_ValorAlternativo.SelectedIndex = 0 Then
            pvs_TextoAlternativo = "999"
        Else
            pvs_TextoAlternativo = ddl_ValorAlternativo.SelectedValue
        End If


        'Se crea un array con las opciones seleccionadas
        For Each vli_OpcionImplementacion As ListItem In lbx_Implementaciones.Items
            If vli_OpcionImplementacion.Selected Then
                vla_ListaImplementaciones(vli_i) = vli_OpcionImplementacion.Value
                vli_i = vli_i + 1
            End If
        Next

        'Se crea un array con las opciones seleccionadas
        For Each vli_OpcionCondiciones As ListItem In lbx_CondicionesArriendo.Items
            If vli_OpcionCondiciones.Selected Then
                vla_ListaCondiciones(vli_o) = vli_OpcionCondiciones.Value
                vli_o = vli_o + 1
            End If
        Next

        ' vla_ListaImplementaciones, vla_ListaCondiciones 

        Dim vlo_GenerarCotizacion As New RN.cls_Cotizaciones
        If (vlo_GenerarCotizacion.fgb_GenerarCotizacion(pvi_idEquipo,
                                                        pvs_idCliente,
                                                        pvi_TipoCotizacion,
                                                        pvi_Modalidad,
                                                        pvs_Contacto,
                                                        pvs_Faena,
                                                        pvi_Precio,
                                                        pvi_idVendedor,
                                                        pvi_idUsuario,
                                                        pvi_CantHoras,
                                                        pvs_TextoAlternativo,
                                                        pvi_idZona,
                                                        vla_ListaCondiciones,
                                                        vla_ListaImplementaciones
                                                        )) Then

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_GenerarCotizacion", "$('#mpe_GenerarCotizacion').modal();", True)

        Else
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCausaError').modal();", True)
            Exit Sub
        End If


    End Sub

    Private Sub btn_DescargarCotizacion_Click(sender As Object, e As EventArgs) Handles btn_DescargarCotizacion.Click
        limpiar()
        Dim dt_NumeroCotizacion As DataTable = CType(sds_MaxCotizacion.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim pvi_idCotizacion As Integer = Convert.ToInt64(dt_NumeroCotizacion.Rows(0).Item("id_Cotizacion").ToString)
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?pvi_idCotizacion=" & pvi_idCotizacion & "&tiporeporte=10" & "','_newtab');", True)
        limpiar()

    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        limpiar()
    End Sub

#End Region

#Region "METODOS Y FUNCIONES"
    Private Sub limpiar()
        ddl_SeleccionEquipo.SelectedIndex = -1
        ddl_Clientes.SelectedIndex = -1
        ddl_Vendedores.SelectedIndex = -1
        ddl_Modalidad.SelectedIndex = -1
        ddl_TipoCotizacion.SelectedIndex = -1
        ddl_Familia.SelectedIndex = -1
        ddl_Equipos.SelectedIndex = -1
        txt_Contacto.Text = ""
        txt_Faena.Text = ""
        txt_Precio.Text = ""
        txt_CantHoras.Text = ""
        ddl_ValorAlternativo.SelectedIndex = -1

        lbx_CondicionesArriendo.ClearSelection()
        lbx_Implementaciones.ClearSelection()
    End Sub
#End Region

#Region "DROPDOWNLIST"
    Private Sub ddl_Familia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Familia.SelectedIndexChanged
        sds_EquiposXFamilia.SelectParameters("id_Familia").DefaultValue = ddl_Familia.SelectedValue
        sds_EquiposXFamilia.DataBind()
        'txt_BuscarAfi.Text = ""
    End Sub

    Private Sub ddl_Equipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Equipos.SelectedIndexChanged
        sds_EquipoXmodelo.SelectParameters("NombreEquipo").DefaultValue = ddl_Equipos.SelectedValue
        sds_EquipoXmodelo.DataBind()
        'txt_BuscarAfi.Text = ""
    End Sub

    Private Sub ddl_Modalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Modalidad.SelectedIndexChanged
        If ddl_Modalidad.SelectedIndex <> 0 Then
            If ddl_Modalidad.SelectedValue = 3 Then
                ddl_ValorAlternativo.Visible = True
                txt_CantHoras.Visible = True
                lbl_cant_horas.Visible = True
                lbl_ValorAlternativo.Visible = True
                lbl_Precio.InnerHtml = "Precio por hora"
            Else
                ddl_ValorAlternativo.Visible = False
                txt_CantHoras.Visible = False
                lbl_cant_horas.Visible = False
                lbl_ValorAlternativo.Visible = False
                lbl_Precio.InnerHtml = "Precio"
            End If
        Else
            ddl_ValorAlternativo.Visible = False
            txt_CantHoras.Visible = False
            lbl_cant_horas.Visible = False
            lbl_ValorAlternativo.Visible = False
            lbl_Precio.InnerHtml = "Precio"
        End If

    End Sub

#End Region
End Class