Public Class frm_ModificarEquipo
    Inherits System.Web.UI.Page

#Region "INICIO"
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

            If Session("id_TipoCargo") = 4 Then 'Jefe de servicios no edita equipos
                Response.Redirect("~/frm_Inicio.aspx")
            End If
            'sds_ColaboradorXUsuario.SelectParameters("id_Usuario").DefaultValue = Session("id_Usuario").ToString()
            'sds_ColaboradorXUsuario.DataBind()
            'Me.Panel_Causales.Visible = False
        End If
    End Sub

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Familias.Items.FindByText("Seleccione familia...") Is Nothing) Then
            ddl_Familias.Items.Insert(0, New ListItem("Seleccione familia...", "", True))

            ddl_Familias.SelectedIndex = 0
        End If
        If (ddl_Equipos.Items.FindByText("Seleccione equipo...") Is Nothing) Then
            ddl_Equipos.Items.Insert(0, New ListItem("Seleccione equipo...", "", True))

            ddl_Equipos.SelectedIndex = 0
        End If

        If (ddl_Familia.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_Familia.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_Familia.SelectedIndex = 0
        End If

        If (ddl_AnhoEquipo.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_AnhoEquipo.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_AnhoEquipo.SelectedIndex = 0
        End If

        If (ddl_Procedencia.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_Procedencia.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_Procedencia.SelectedIndex = 0
        End If

        If (ddl_Sucursal.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_Sucursal.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_Sucursal.SelectedIndex = 0
        End If


        If (ddl_EstadoEquipos.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_EstadoEquipos.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_EstadoEquipos.SelectedIndex = 0
        End If
        'Agregar la opción de seleccionar en dropdownlist CAUSALES
        If (ddl_Color.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_Color.Items.Insert(0, New ListItem("Seleccionar...", "", True))

            ddl_Color.SelectedIndex = 0
        End If
    End Sub
#End Region

#Region "DROPDOWNLIST"
    Private Sub ddl_Familias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Familias.SelectedIndexChanged
        pnl_Agregado.Visible = False
        sds_EquiposXFamilia.SelectParameters("id_Familia").DefaultValue = ddl_Familias.SelectedValue
        sds_EquiposXFamilia.DataBind()
        txt_BuscarAfi.Text = ""
    End Sub

    Private Sub ddl_Equipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Equipos.SelectedIndexChanged
        pnl_Agregado.Visible = False
        sds_EquipoXidequipo.SelectParameters("id_Equipo").DefaultValue = ddl_Equipos.SelectedValue
        sds_EquipoXidequipo.DataBind()
        txt_BuscarAfi.Text = ddl_Equipos.SelectedValue

        'If (txt_BuscarAfi.Text <> "") Then
        '    If IsNumeric(txt_BuscarAfi.Text) Then
        sds_SoloEquipo.SelectParameters("id_Equipo").DefaultValue = txt_BuscarAfi.Text
        sds_SoloEquipo.DataBind()
        'Carga de SDS a DataTable
        Dim dt_Equipos As DataTable = CType(sds_SoloEquipo.Select(DataSourceSelectArguments.Empty), DataView).Table
        If dt_Equipos.Rows.Count = 0 Then
            pnl_Noexiste.Visible = True
            lbl_ErrorAfi.Visible = False
            LimpiarFormulario()
        Else
            txt_NumeroSerie.Text = dt_Equipos.Rows(0).Item("NumeroEquipo").ToString()
            txt_NombreEquipo.Text = dt_Equipos.Rows(0).Item("NombreEquipo").ToString()
            txt_Horometro.Text = dt_Equipos.Rows(0).Item("Horometro").ToString()
            Dim ValorFormateado As String = dt_Equipos.Rows(0).Item("ValorCompra").ToString()
            txt_ValorCompra.Text = Format(ValorFormateado, "Currency")
            txt_MarcaEquipo.Text = dt_Equipos.Rows(0).Item("MarcaEquipo").ToString()
            txt_ModeloEquipo.Text = dt_Equipos.Rows(0).Item("ModeloEquipo").ToString()
            ddl_Color.SelectedValue = (dt_Equipos.Rows(0).Item("Color"))
            txt_Patente.Text = dt_Equipos.Rows(0).Item("Patente").ToString()
            txt_FechaAdquisicion.Text = dt_Equipos.Rows(0).Item("FechaAdquisicionEquipo").ToString()
            ddl_Familia.SelectedValue = Convert.ToInt32(dt_Equipos.Rows(0).Item("id_Familia"))
            ddl_Sucursal.SelectedValue = Convert.ToInt32(dt_Equipos.Rows(0).Item("id_sucursal"))
            ddl_EstadoEquipos.SelectedValue = Convert.ToInt32(dt_Equipos.Rows(0).Item("id_EstadoEquipo"))
            ddl_AnhoEquipo.SelectedValue = dt_Equipos.Rows(0).Item("AnhoEquipo").ToString()
            ddl_Procedencia.SelectedValue = dt_Equipos.Rows(0).Item("Procedencia").ToString()

        End If
        'Else
        '    lbl_ErrorAfi.InnerHtml = "Error! - Ingrese solo números"
        '    lbl_ErrorAfi.Visible = True
        '    pnl_Agregado.Visible = False
        '    txt_BuscarAfi.Text = ""
        '    txt_BuscarAfi.Focus()
        '    LimpiarFormulario()
        '    Exit Sub

        'End If
        'End If

    End Sub

#End Region

#Region "METODOS Y FUNCIONES"
    Private Sub LimpiarFormulario()
        pnl_Agregado.Visible = False
        txt_BuscarAfi.Text = ""
        txt_NumeroSerie.Text = ""
        txt_NombreEquipo.Text = ""
        ddl_Sucursal.SelectedIndex = -1
        ddl_Familia.SelectedIndex = -1
        ddl_EstadoEquipos.SelectedIndex = -1
        ddl_AnhoEquipo.SelectedIndex = -1
        ddl_Procedencia.SelectedIndex = -1
        ddl_Color.SelectedIndex = -1
        txt_MarcaEquipo.Text = ""
        txt_ModeloEquipo.Text = ""
        txt_Patente.Text = ""
        txt_ValorCompra.Text = ""
        txt_FechaAdquisicion.Text = ""
        txt_Horometro.Text = ""
        txt_LargoEquipo.Text = ""
        txt_AltoEquipo.Text = ""
        txt_AnchoEquipo.Text = ""
        txt_PesoEquipo.Text = ""
        txt_AccionamientoEquipo.Text = ""
        txt_Dato1Equipo.Text = ""
        txt_Dato2Equipo.Text = ""

    End Sub
#End Region

#Region "BOTONES"

    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        LimpiarFormulario()
    End Sub

    Protected Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim pvi_Horometro As Integer
        Dim pvs_NumeroSerie As String = txt_NumeroSerie.Text

        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvi_Afi As Integer = Convert.ToInt64(txt_BuscarAfi.Text)

        If txt_Horometro.Text = "" Then
            pvi_Horometro = 0
        Else
            pvi_Horometro = Convert.ToInt64(txt_Horometro.Text)
        End If

        Dim pvs_NombreEquipo As String = txt_NombreEquipo.Text
        Dim pvi_Familia As Integer = ddl_Familia.SelectedValue
        Dim pvs_MarcaEquipo As String = txt_MarcaEquipo.Text
        Dim pvs_ModeloEquipo As String = txt_ModeloEquipo.Text
        Dim pvs_Color As String = ddl_Color.SelectedValue
        'Dim pvs_Patente As String = txt_Patente.Text
        Dim pvd_FechaAdquisicion As Date = txt_FechaAdquisicion.Text
        Dim valorLimpioUno As String = Replace(txt_ValorCompra.Text, "$", "")
        Dim pvi_ValorCompra As String = Replace(valorLimpioUno, ".", "")
        Dim pvi_Sucursal As Integer = ddl_Sucursal.SelectedValue
        Dim pvi_EstadoEquipo As Integer = ddl_EstadoEquipos.SelectedValue
        Dim pvs_Procedencia As String = ddl_Procedencia.SelectedValue
        Dim pvi_AnhoEquipo As String = ddl_AnhoEquipo.SelectedValue
        Dim pvi_LargoEquipo As String = ValidadorVacios(txt_LargoEquipo.Text)
        Dim pvi_AltoEquipo As String = ValidadorVacios(txt_AltoEquipo.Text)
        Dim pvi_AnchoEquipo As String = ValidadorVacios(txt_AnchoEquipo.Text)
        Dim pvi_PesoEquipo As String = ValidadorVacios(txt_PesoEquipo.Text)
        Dim pvs_Patente As String = ValidadorVacios(txt_Patente.Text)
        Dim pvs_AccionamientoEquipo As String = ValidadorVacios(txt_AccionamientoEquipo.Text)
        Dim pvs_Dato1Equipo As String = ValidadorVacios(txt_Dato1Equipo.Text)
        Dim pvs_Dato2Equipo As String = ValidadorVacios(txt_Dato2Equipo.Text)




        '' ''If pvs_NumeroSerie = equipomenor, debe ingresar numerodeserie

        Dim vlo_ModificarEquipo As New RN.RN_REGISTRAREQUIPO.cls_AgregarEquipo
        If (vlo_ModificarEquipo.fgb_ActualizarEquipo(pvi_Afi,
                                                     pvs_NumeroSerie,
                                                     pvs_NombreEquipo,
                                                     pvi_ValorCompra,
                                                     pvs_MarcaEquipo,
                                                     pvs_ModeloEquipo,
                                                     pvs_Color,
                                                     pvs_Patente,
                                                     pvd_FechaAdquisicion,
                                                     pvi_Familia,
                                                     pvi_Sucursal,
                                                     pvi_EstadoEquipo,
                                                     pvi_idUsuario,
                                                     pvi_Horometro,
                                                     pvs_Procedencia,
                                                     pvi_AnhoEquipo,
                                                     pvi_LargoEquipo,
                                                     pvi_AltoEquipo,
                                                     pvi_AnchoEquipo,
                                                     pvi_PesoEquipo,
                                                     pvs_AccionamientoEquipo,
                                                     pvs_Dato1Equipo,
                                                     pvs_Dato2Equipo)) Then
            LimpiarFormulario()
            ddl_Familias.SelectedIndex = -1
            ddl_Equipos.SelectedIndex = -1
            txt_BuscarAfi.Text = ""
            pnl_Agregado.Visible = True
        End If
    End Sub

    Private Sub btn_LimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btn_LimpiarFiltros.Click
        ddl_Familias.SelectedIndex = -1
        ddl_Equipos.SelectedIndex = -1
        txt_BuscarAfi.Text = ""
        pnl_Agregado.Visible = False
    End Sub
    Private Sub btn_BusquedaPorAfi_Click(sender As Object, e As EventArgs) Handles btn_BusquedaPorAfi.Click
        pnl_Agregado.Visible = False
        If (txt_BuscarAfi.Text <> "") Then
            If IsNumeric(txt_BuscarAfi.Text) Then
                sds_SoloEquipo.SelectParameters("id_Equipo").DefaultValue = txt_BuscarAfi.Text
                sds_SoloEquipo.DataBind()
                'Carga de SDS a DataTable
                Dim dt_Equipos As DataTable = CType(sds_SoloEquipo.Select(DataSourceSelectArguments.Empty), DataView).Table
                If dt_Equipos.Rows.Count = 0 Then
                    pnl_Noexiste.Visible = True
                    lbl_ErrorAfi.Visible = False
                    LimpiarFormulario()
                Else
                    pnl_Noexiste.Visible = False
                    lbl_ErrorAfi.Visible = False
                    txt_NumeroSerie.Text = dt_Equipos.Rows(0).Item("NumeroEquipo").ToString()
                    txt_NombreEquipo.Text = dt_Equipos.Rows(0).Item("NombreEquipo").ToString()
                    txt_Horometro.Text = dt_Equipos.Rows(0).Item("Horometro").ToString()
                    Dim ValorFormateado As String = dt_Equipos.Rows(0).Item("ValorCompra").ToString()
                    txt_ValorCompra.Text = Format(ValorFormateado, "Currency")
                    txt_MarcaEquipo.Text = dt_Equipos.Rows(0).Item("MarcaEquipo").ToString()
                    txt_ModeloEquipo.Text = dt_Equipos.Rows(0).Item("ModeloEquipo").ToString()
                    ddl_Color.SelectedValue = (dt_Equipos.Rows(0).Item("Color"))
                    txt_Patente.Text = dt_Equipos.Rows(0).Item("Patente").ToString()
                    txt_FechaAdquisicion.Text = dt_Equipos.Rows(0).Item("FechaAdquisicionEquipo").ToString()
                    ddl_Familia.SelectedValue = Convert.ToInt32(dt_Equipos.Rows(0).Item("id_Familia"))
                    ddl_Sucursal.SelectedValue = Convert.ToInt32(dt_Equipos.Rows(0).Item("id_sucursal"))
                    ddl_EstadoEquipos.SelectedValue = Convert.ToInt32(dt_Equipos.Rows(0).Item("id_EstadoEquipo"))
                    ddl_AnhoEquipo.SelectedValue = dt_Equipos.Rows(0).Item("AnhoEquipo").ToString()
                    ddl_Procedencia.SelectedValue = dt_Equipos.Rows(0).Item("Procedencia").ToString()
                    txt_LargoEquipo.Text = dt_Equipos.Rows(0).Item("Largo").ToString()
                    txt_AltoEquipo.Text = dt_Equipos.Rows(0).Item("Alto").ToString()
                    txt_AnchoEquipo.Text = dt_Equipos.Rows(0).Item("Ancho").ToString()
                    txt_PesoEquipo.Text = dt_Equipos.Rows(0).Item("Peso").ToString()
                    txt_AccionamientoEquipo.Text = dt_Equipos.Rows(0).Item("Accionamiento").ToString()
                    txt_Dato1Equipo.Text = dt_Equipos.Rows(0).Item("Dato1").ToString()
                    txt_Dato2Equipo.Text = dt_Equipos.Rows(0).Item("Dato2").ToString()
                End If
            Else
                lbl_ErrorAfi.InnerHtml = "Error! - Ingrese solo números"
                lbl_ErrorAfi.Visible = True
                pnl_Agregado.Visible = False
                txt_BuscarAfi.Text = ""
                txt_BuscarAfi.Focus()
                LimpiarFormulario()
                Exit Sub
            End If
        End If
    End Sub



#End Region

#Region "VALIDACIONES"
    Protected Sub txt_ValorCompra_TextChanged(sender As Object, e As EventArgs) Handles txt_ValorCompra.TextChanged
        If IsNumeric(txt_ValorCompra.Text) Then
            txt_ValorCompra.Text = Format(txt_ValorCompra.Text, "Currency")
        Else
            txt_ValorCompra.Text = ""

        End If
    End Sub
    Protected Sub txt_Horometro_TextChanged(sender As Object, e As EventArgs) Handles txt_Horometro.TextChanged
        If txt_Horometro.Text <> "" Then
            If Not IsNumeric(txt_Horometro.Text) Then
                txt_Horometro.Text = ""
            End If
        End If

    End Sub

    Public Function ValidadorVacios(valor As String) As String
        If String.IsNullOrEmpty(valor) Then
            Return 0
        Else
            Return valor
        End If

    End Function




#End Region

End Class