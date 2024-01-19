Public Class frm_ModificarCotizacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

        End If

        pnl_Agregado.Visible = False

    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        If IsNumeric(txt_NumeroCotizacion.Text) Then
            sds_CotizacionxId.SelectParameters("idCotizacion").DefaultValue = txt_NumeroCotizacion.Text
            sds_CotizacionxId.DataBind()

            'Carga de SDS a DataTable
            Dim dt_Cotizaciones As DataTable = CType(sds_CotizacionxId.Select(DataSourceSelectArguments.Empty), DataView).Table
            If dt_Cotizaciones.Rows.Count = 0 Then
                LimpiarFormulario()
            Else
                txt_Contacto.Text = dt_Cotizaciones.Rows(0).Item("Contacto").ToString()
                txt_Faena.Text = dt_Cotizaciones.Rows(0).Item("Faena").ToString()
                txt_Precio.Text = dt_Cotizaciones.Rows(0).Item("Precio").ToString()



                ddl_Clientes.SelectedValue = dt_Cotizaciones.Rows(0).Item("id_Cliente").ToString()
                ddl_EstadoCotizacion.SelectedValue = dt_Cotizaciones.Rows(0).Item("EstadoCotizacion").ToString()
                ddl_Modalidad.SelectedValue = dt_Cotizaciones.Rows(0).Item("id_ModalidadArriendo").ToString()
                ddl_Vendedores.SelectedValue = dt_Cotizaciones.Rows(0).Item("id_Vendedor").ToString()
                ddl_Tipo.SelectedValue = dt_Cotizaciones.Rows(0).Item("id_TipoCotizacion").ToString()
                ddl_Zonas.SelectedValue = dt_Cotizaciones.Rows(0).Item("id_Zona").ToString()


                If ddl_Modalidad.SelectedValue = 3 Then
                    ddl_ValorAlternativo.Visible = True
                    txt_CantHoras.Visible = True
                    lbl_cant_horas.Visible = True
                    lbl_ValorAlternativo.Visible = True
                    txt_CantHoras.Text = dt_Cotizaciones.Rows(0).Item("CantHoras").ToString()
                    ddl_ValorAlternativo.SelectedValue = dt_Cotizaciones.Rows(0).Item("TextoAlternativo").ToString()
                Else
                    ddl_ValorAlternativo.Visible = False
                        txt_CantHoras.Visible = False
                        lbl_cant_horas.Visible = False
                        lbl_ValorAlternativo.Visible = False
                        txt_CantHoras.Text = ""
                        ddl_ValorAlternativo.SelectedIndex = -1
                    End If






                    'ddl_Familia.SelectedValue = dt_Cotizaciones.Rows(0).Item("Familia").ToString()

                    sds_EquiposXFamilia.SelectParameters("id_Familia").DefaultValue = ddl_Familia.SelectedValue
                sds_EquiposXFamilia.DataBind()

                sds_EquipoXmodelo.SelectParameters("NombreEquipo").DefaultValue = ddl_Equipos.SelectedValue
                sds_EquipoXmodelo.DataBind()

                '' IMPLEMETANCIONES POR ID_COTIZACIÓN
                sds_ImplementacionesXcotizacion.SelectParameters("id_Cotizacion").DefaultValue = txt_NumeroCotizacion.Text
                sds_ImplementacionesXcotizacion.DataBind()
                Dim dt_Implementaciones As DataTable = CType(sds_ImplementacionesXcotizacion.Select(DataSourceSelectArguments.Empty), DataView).Table

                '' CONDICIONES DE LA COTIZACIÓN POR ID_COTIZACIÓN
                sds_CondicionesXcotizacion.SelectParameters("id_Cotizacion").DefaultValue = txt_NumeroCotizacion.Text
                sds_CondicionesXcotizacion.DataBind()
                Dim dt_Condiciones As DataTable = CType(sds_CondicionesXcotizacion.Select(DataSourceSelectArguments.Empty), DataView).Table

                lbx_ActividadesDisponibles.SelectedIndex = -1
                For Each i As ListItem In lbx_ActividadesDisponibles.Items
                    For j = 0 To dt_Implementaciones.Rows.Count - 1
                        If (i.Value = dt_Implementaciones.Rows(j).Item("id_Actividad")) Then
                            i.Selected = True
                        End If
                    Next
                Next

                lbx_CondicionesArriendo.SelectedIndex = -1
                For Each i As ListItem In lbx_CondicionesArriendo.Items
                    For j = 0 To dt_Condiciones.Rows.Count - 1
                        If (i.Value = dt_Condiciones.Rows(j).Item("id_CondicionCotizacion")) Then
                            i.Selected = True
                        End If
                    Next
                Next
            End If
        Else

        End If




    End Sub

    Private Sub ddl_Familia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Familia.SelectedIndexChanged
        sds_EquiposXFamilia.SelectParameters("id_Familia").DefaultValue = ddl_Familia.SelectedValue
        sds_EquiposXFamilia.DataBind()
        'txt_BuscarAfi.Text = ""
        ddl_Equipos.Enabled = True


    End Sub



    Private Sub ddl_Equipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Equipos.SelectedIndexChanged
        sds_EquipoXmodelo.SelectParameters("NombreEquipo").DefaultValue = ddl_Equipos.SelectedValue
        sds_EquipoXmodelo.DataBind()
        'txt_BuscarAfi.Text = ""

        ddl_SeleccionEquipo.Enabled = True

    End Sub

    Private Sub frm_ModificarCotizacion_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
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

        If (ddl_Tipo.Items.FindByText("Seleccione Tipo...") Is Nothing) Then
            ddl_Tipo.Items.Insert(0, New ListItem("Seleccione Tipo...", "", True))

            ddl_Tipo.SelectedIndex = 0
        End If

        If (ddl_Modalidad.Items.FindByText("Seleccione modalidad...") Is Nothing) Then
            ddl_Modalidad.Items.Insert(0, New ListItem("Seleccione modalidad...", "", True))

            ddl_Modalidad.SelectedIndex = 0
        End If

        If (ddl_Vendedores.Items.FindByText("Seleccione vendedor...") Is Nothing) Then
            ddl_Vendedores.Items.Insert(0, New ListItem("Seleccione vendedor...", "", True))

            ddl_Vendedores.SelectedIndex = 0
        End If

        If (ddl_EstadoCotizacion.Items.FindByText("Seleccione estado...") Is Nothing) Then
            ddl_EstadoCotizacion.Items.Insert(0, New ListItem("Seleccione estado...", "", True))

            ddl_EstadoCotizacion.SelectedIndex = 0
        End If
        If (ddl_ValorAlternativo.Items.FindByText("No mostrar...") Is Nothing) Then
            ddl_ValorAlternativo.Items.Insert(0, New ListItem("No mostrar...", "", True))

            ddl_ValorAlternativo.SelectedIndex = 0
        End If

    End Sub

    Private Sub btn_ActualizarCotizacion_Click(sender As Object, e As EventArgs) Handles btn_ActualizarCotizacion.Click
        Dim vla_ListaImplementaciones(lbx_ActividadesDisponibles.Items.Count) As Integer
        Dim vla_ListaCondiciones(lbx_CondicionesArriendo.Items.Count) As Integer
        Dim vli_i As Integer = 0
        Dim vli_o As Integer = 0
        Dim pvi_idEquipo As Integer

        Dim pvi_idCotizacion As Integer = txt_NumeroCotizacion.Text

        If ddl_SeleccionEquipo.SelectedIndex = 0 Then
            pvi_idEquipo = 999
        Else
            pvi_idEquipo = ddl_SeleccionEquipo.SelectedValue
        End If

        Dim pvs_idCliente As String = ddl_Clientes.SelectedValue
        Dim pvi_idVendedor As Integer = ddl_Vendedores.SelectedValue
        Dim pvi_Modalidad As Integer = ddl_Modalidad.SelectedValue
        Dim pvi_TipoCotizacion As Integer = ddl_Tipo.SelectedValue
        Dim pvs_Contacto As String = txt_Contacto.Text
        Dim pvs_Faena As String = txt_Faena.Text
        Dim pvi_Precio As Integer = txt_Precio.Text
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvi_EstadoCoti As Integer = ddl_EstadoCotizacion.SelectedValue
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
        For Each vli_OpcionImplementacion As ListItem In lbx_ActividadesDisponibles.Items
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

        Dim vlo_GenerarCotizacion As New RN.cls_Cotizaciones
        If (vlo_GenerarCotizacion.fgb_ActualizarCotizacion(pvi_idCotizacion,
                                                           pvi_idEquipo,
                                                            pvs_idCliente,
                                                            pvi_TipoCotizacion,
                                                            pvi_Modalidad,
                                                            pvs_Contacto,
                                                            pvs_Faena,
                                                            pvi_Precio,
                                                            pvi_idVendedor,
                                                            pvi_idUsuario,
                                                            pvi_EstadoCoti,
                                                            pvi_CantHoras,
                                                            pvs_TextoAlternativo,
                                                            pvi_idZona,
                                                            vla_ListaCondiciones,
                                                            vla_ListaImplementaciones)) Then


        End If
        pnl_Agregado.Visible = True
        LimpiarFormulario()
    End Sub

    Private Sub LimpiarFormulario()
        ddl_Clientes.SelectedIndex = -1
        ddl_Vendedores.SelectedIndex = -1
        ddl_Modalidad.SelectedIndex = -1
        ddl_Tipo.SelectedIndex = -1
        ddl_EstadoCotizacion.SelectedIndex = -1
        ddl_EstadoCotizacion.SelectedIndex = -1
        txt_Contacto.Text = ""
        txt_Faena.Text = ""
        txt_Precio.Text = ""
        txt_NumeroCotizacion.Text = ""
        txt_CantHoras.Text = ""
        ddl_ValorAlternativo.SelectedIndex = -1
        lbx_CondicionesArriendo.ClearSelection()
        lbx_ActividadesDisponibles.ClearSelection()
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        LimpiarFormulario()
    End Sub

    Private Sub ddl_Modalidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Modalidad.SelectedIndexChanged
        If ddl_Modalidad.SelectedIndex <> 0 Then
            If ddl_Modalidad.SelectedValue = 3 Then
                ddl_ValorAlternativo.Visible = True
                txt_CantHoras.Visible = True
                lbl_cant_horas.Visible = True
                lbl_ValorAlternativo.Visible = True
            Else
                ddl_ValorAlternativo.Visible = False
                txt_CantHoras.Visible = False
                lbl_cant_horas.Visible = False
                lbl_ValorAlternativo.Visible = False
                txt_CantHoras.Text = ""
                ddl_ValorAlternativo.SelectedIndex = -1
            End If
        Else
            ddl_ValorAlternativo.Visible = False
            txt_CantHoras.Visible = False
            lbl_cant_horas.Visible = False
            lbl_ValorAlternativo.Visible = False
            txt_CantHoras.Text = ""
            ddl_ValorAlternativo.SelectedIndex = -1

        End If
    End Sub
End Class