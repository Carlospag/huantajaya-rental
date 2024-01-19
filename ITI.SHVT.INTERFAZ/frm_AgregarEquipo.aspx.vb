Public Class frm_AgregarEquipo
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

            sds_SugerenciaAfis.DataBind()
            Dim dt_sugerencias As DataTable = CType(sds_SugerenciaAfis.Select(DataSourceSelectArguments.Empty), DataView).Table

            lbl_UM.InnerText = "Unidades Menores: " + dt_sugerencias.Rows(0).Item("UM").ToString()
            lbl_AND.InnerText = "Andamios: " + dt_sugerencias.Rows(0).Item("ANDAMIOS").ToString()
            lbl_SUB.InnerText = "Sub-arriendos: " + dt_sugerencias.Rows(0).Item("SUB").ToString()
            'sds_ColaboradorXUsuario.SelectParameters("id_Usuario").DefaultValue = Session("id_Usuario").ToString()
            'sds_ColaboradorXUsuario.DataBind()
            'Me.Panel_Causales.Visible = False

            If Session("id_TipoCargo") = 4 Then 'Jefe de servicios no crea equipos
                Response.Redirect("~/frm_Inicio.aspx")
            End If
        End If
    End Sub

    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Familia.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_Familia.Items.Insert(0, New ListItem("Seleccionar...", "", True))
            ddl_Familia.SelectedIndex = 0
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

        If (ddl_Color.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_Color.Items.Insert(0, New ListItem("Seleccionar...", "", True))
            ddl_Color.SelectedIndex = 0
        End If

        If (ddl_AnhoEquipo.Items.FindByText("Seleccionar...") Is Nothing) Then
            ddl_AnhoEquipo.Items.Insert(0, New ListItem("Seleccionar...", "", True))
            ddl_AnhoEquipo.SelectedIndex = 0
        End If
    End Sub
#End Region

#Region "DROPDOWNLIST"
    'Protected Sub ddl_TipoAmonestacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddl_TipoAmonestacion.SelectedIndexChanged
    '   ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
    'If ddl_TipoAmonestacion.SelectedValue = 4 Then
    'Me.Panel_Causales.Visible = True
    'Else
    'Me.Panel_Causales.Visible = False
    'End If
    'End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Private Sub LimpiarFormulario()
        txt_AFI.Text = ""
        txt_NumeroSerie.Text = ""
        txt_NombreEquipo.Text = ""
        ddl_Sucursal.SelectedIndex = -1
        ddl_Familia.SelectedIndex = -1
        ddl_EstadoEquipos.SelectedIndex = -1
        ddl_Procedencia.SelectedIndex = -1
        ddl_AnhoEquipo.SelectedIndex = -1
        txt_MarcaEquipo.Text = ""
        txt_ModeloEquipo.Text = ""
        txt_Patente.Text = ""
        ddl_Color.SelectedIndex = -1
        txt_ValorCompra.Text = ""
        txt_FechaAdquisicion.Text = ""
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
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvi_Afi As Integer = Convert.ToInt64(txt_AFI.Text)
        Dim pvs_NumeroSerie As String = txt_NumeroSerie.Text

        If txt_Horometro.Text = "" Then
            pvi_Horometro = 0
        Else
            pvi_Horometro = Convert.ToInt64(txt_Horometro.Text)
        End If

        Dim pvs_NombreEquipo As String = txt_NombreEquipo.Text
        Dim valorLimpioUno As String = Replace(txt_ValorCompra.Text, "$", "")
        Dim pvi_ValorCompra As String = Replace(valorLimpioUno, ".", "")

        Dim pvs_MarcaEquipo As String = txt_MarcaEquipo.Text
        Dim pvs_ModeloEquipo As String = txt_ModeloEquipo.Text
        Dim pvs_Color As String = ddl_Color.SelectedValue
        'Dim pvs_Patente As String = txt_Patente.Text
        Dim pvd_FechaAdquisicion As Date = txt_FechaAdquisicion.Text
        Dim pvi_Familia As Integer = ddl_Familia.SelectedValue
        Dim pvi_Sucursal As Integer = ddl_Sucursal.SelectedValue
        Dim pvi_EstadoEquipo As Integer = ddl_EstadoEquipos.SelectedValue
        Dim pvs_Procedencia As String = ddl_Procedencia.SelectedValue
        Dim pvi_AnhoEquipo As Integer = ddl_AnhoEquipo.SelectedValue
        Dim pvi_LargoEquipo As String = ValidadorVacios(txt_LargoEquipo.Text)
        Dim pvi_AltoEquipo As String = ValidadorVacios(txt_AltoEquipo.Text)
        Dim pvi_AnchoEquipo As String = ValidadorVacios(txt_AnchoEquipo.Text)
        Dim pvi_PesoEquipo As String = ValidadorVacios(txt_PesoEquipo.Text)
        Dim pvs_Patente As String = ValidadorVacios(txt_Patente.Text)
        Dim pvs_AccionamientoEquipo As String = ValidadorVacios(txt_AccionamientoEquipo.Text)
        Dim pvs_Dato1Equipo As String = ValidadorVacios(txt_Dato1Equipo.Text)
        Dim pvs_Dato2Equipo As String = ValidadorVacios(txt_Dato2Equipo.Text)



        Dim vlo_RegistrarEquipo As New RN.RN_REGISTRAREQUIPO.cls_AgregarEquipo

        If (vlo_RegistrarEquipo.fgb_RegistrarEquipo(pvi_Afi,
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
            pnl_Agregado.Visible = True
        End If
    End Sub

#End Region

#Region "VALIDACIONES"
    Protected Sub txt_AFI_TextChanged(sender As Object, e As EventArgs) Handles txt_AFI.TextChanged
        'Verificacion de AFI en sistema
        Dim vlo_BuscarAfi As New RN.RN_REGISTRAREQUIPO.cls_AgregarEquipo
        If IsNumeric(txt_AFI.Text) Then
            If (vlo_BuscarAfi.fgb_BuscarAfi(Convert.ToInt64(txt_AFI.Text))) Then
                lbl_ErrorAFI.InnerHtml = "Error! - AFI duplicado."
                lbl_ErrorAFI.Visible = True
                pnl_Agregado.Visible = False
                txt_AFI.Text = ""
                txt_AFI.Focus()
                Exit Sub
            Else
                lbl_ErrorAFI.Visible = False
            End If
        Else
            lbl_ErrorAFI.InnerHtml = "Error! - Ingrese solo números"
            lbl_ErrorAFI.Visible = True
            pnl_Agregado.Visible = False
            txt_AFI.Text = ""
            txt_AFI.Focus()
            Exit Sub
        End If


    End Sub
#End Region

#Region "TEXTCHANGUED"
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