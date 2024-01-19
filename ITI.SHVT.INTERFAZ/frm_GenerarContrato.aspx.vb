Public Class frm_GenerarContrato
    Inherits System.Web.UI.Page


#Region "VARIABLES GLOBALES"
    Dim FechaActual As Date = Today()
#End Region

#Region "INICIO"

    ''' <summary>
    ''' Page Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

            sds_NumeroContrato.DataBind()
            Dim dt_Contrato As DataTable = CType(sds_NumeroContratoCrear.Select(DataSourceSelectArguments.Empty), DataView).Table
            lbl_NumContrato.Text = dt_Contrato.Rows(0).Item("NumeroContrato").ToString()

            txt_Fecha.Text = Today()
            txt_Fecha.Text = Replace(txt_Fecha.Text, "-", "/")
        End If
    End Sub

    ''' <summary>
    ''' PreRender
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        'Agregar la opción de seleccionar en dropdownlist COLABORADORES
        If (ddl_Clientes.Items.FindByText("Indicar cliente ...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("Indicar cliente ...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If


        If (ddl_Zonas.Items.FindByText("Indicar zona...") Is Nothing) Then
            ddl_Zonas.Items.Insert(0, New ListItem("Indicar zona...", "", True))

            ddl_Zonas.SelectedIndex = 0
        End If


    End Sub

#End Region

#Region "DROPDOWNLIST"
    Protected Sub ddl_Clientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Clientes.SelectedIndexChanged
        If (ddl_Clientes.SelectedIndex <> -1) Then
            LlenarCamposClientes()

        Else

            LimpiarFormulario()
        End If
        Dim cs = Page.ClientScript
        Dim cstype = Me.GetType()

        If Not cs.IsStartupScriptRegistered(cstype, "CallUpdate") Then
            cs.RegisterStartupScript(cstype, "CallUpdate", "ActualizaCombobox();", True)
        End If

        'If cs IsNot Nothing Then
        '    ClientScript.RegisterStartupScript(Me.GetType(), "CallUpdate", "<script type=text/javascript>$('.chosen-select').chosen();</script>")
        'End If
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    ''' <summary>
    ''' Llenar campos clientes
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub LlenarCamposClientes()
        If (ddl_Clientes.SelectedIndex <> 0) Then
            sds_SoloCliente.SelectParameters("RutCliente").DefaultValue = ddl_Clientes.SelectedValue
            sds_SoloCliente.DataBind()

            'Carga de SDS a DataTable
            Dim dt_Clientes As DataTable = CType(sds_SoloCliente.Select(DataSourceSelectArguments.Empty), DataView).Table

            lbl_RutCliente.InnerText = dt_Clientes.Rows(0).Item("RutCliente").ToString()
            lbl_NombreCliente.InnerText = dt_Clientes.Rows(0).Item("NombreCliente").ToString()
            lbl_NombreRepresentante.InnerText = dt_Clientes.Rows(0).Item("NombresRepresentanteLegal").ToString()
            lbl_TelUno.InnerText = dt_Clientes.Rows(0).Item("ContactoTelUno").ToString()
            lbl_CorreoUno.InnerText = dt_Clientes.Rows(0).Item("CorreoElectronicoUno").ToString()
        Else
            LimpiarFormulario()
        End If
    End Sub

    ''' <summary>
    ''' Limpiar el formulario.
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub LimpiarFormulario()
        txt_Afi.Text = ""
        txt_NombreFaena.Text = ""
        ddl_Clientes.SelectedIndex = -1
        ddl_Zonas.SelectedIndex = -1
        lbl_NombreCliente.InnerText = ""
        lbl_MarcaEquipo.InnerText = ""
        txt_NombreFaena.Text = ""
        lbl_ModeloEquipo.InnerText = ""
        lbl_RutCliente.InnerText = ""
        lbl_Afi.InnerText = ""
        lbl_NombreEquipo.InnerText = ""
        lbl_TelUno.InnerText = ""
        lbl_CorreoUno.InnerText = ""
        lbl_Horometro.InnerText = ""
        lbl_NombreRepresentante.InnerText = ""
        txt_Tarifa.Text = ""
        'txt_Facturacion.Text = ""
        'rbt_mensual.Checked = True
        lbl_ErrorAfi.Visible = False
        lbl_ErrorGuia.Visible = False
        lbl_ErrorTarifa.Visible = False
        txt_NumeroGuia.Text = ""
        txt_Fecha.Text = Today()
        txt_Fecha.Text = Replace(txt_Fecha.Text, "-", "/")
    End Sub
#End Region

#Region "BOTONES"

    ''' <summary>
    ''' Botón Limpiar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True)
        LimpiarFormulario()
    End Sub

    ''' <summary>
    ''' Botón Guardar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        '' Contrato
        'Dim pvi_IdContrato As Integer = lbl_NumContrato.Text
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvs_RutCliente As String = ddl_Clientes.SelectedValue
        Dim pvi_IdEmpresa As Integer = 1 ' Huantajaya Equipos S.A.
        Dim pvd_FechaContrato As Date = txt_Fecha.Text
        Dim pvd_FechaRegistroContrato As Date = FechaActual
        Dim pvi_EstadoContrato As Integer = 1 '1 Activo, 2 Terminado, 3 Anulado
        '' Contrato

        '' Detalle Contrato
        Dim pvi_idZona As Integer = ddl_Zonas.SelectedValue
        Dim pvi_idEquipo As Integer = txt_Afi.Text
        Dim pvi_ValorUnitario As Integer = txt_Tarifa.Text

        Dim pvs_Faena As String = txt_NombreFaena.Text
        Dim pvi_Guia As Integer = txt_NumeroGuia.Text
        Dim pvi_idCotizacion As Integer
        If txt_idCotizacion.Text <> "" Then
            pvi_idCotizacion = txt_idCotizacion.Text
        Else
            pvi_idCotizacion = 999
        End If
        Dim pvi_TipoUnidad As Integer ' Precio Dia/mes

        pvi_TipoUnidad = ddl_Modalidad.SelectedValue

        'If rbt_mensual.Checked Then
        '    pvi_TipoUnidad = 1 'Mensual
        ' Else
        '    pvi_TipoUnidad = 2 'Diario
        'End If

        Dim vlo_RegistrarContrato As New RN.RN_CONTRATOS.cls_Contratos

        If (vlo_RegistrarContrato.fgb_RegistrarContrato(pvi_idUsuario,
                                                        pvs_RutCliente,
                                                        pvi_IdEmpresa,
                                                        pvd_FechaContrato,
                                                        pvd_FechaRegistroContrato,
                                                        pvi_EstadoContrato,
                                                        pvi_idZona,
                                                        pvi_idEquipo,
                                                        pvi_TipoUnidad,
                                                        pvi_ValorUnitario,
                                                        pvs_Faena,
                                                        pvi_Guia,
                                                        pvi_idCotizacion)) Then

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True)

            'LimpiarFormulario()
            Dim dt_Contrato As DataTable = CType(sds_NumeroContratoCrear.Select(DataSourceSelectArguments.Empty), DataView).Table
            lbl_NumContrato.Text = dt_Contrato.Rows(0).Item("NumeroContrato").ToString()
        Else
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCausaError').modal();", True)

        End If

    End Sub


    Private Sub btn_GuardarModal_Click(sender As Object, e As EventArgs) Handles btn_GuardarModal.Click
        LimpiarFormulario()
        Dim dt_Contrato As DataTable = CType(sds_NumeroContrato.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim pvi_NumeroContrato As Integer = Convert.ToInt64(dt_Contrato.Rows(0).Item("NumeroContrato").ToString())
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?idc=" & pvi_NumeroContrato & "&tiporeporte=2" & "','_newtab');", True)

    End Sub


#End Region

#Region "VALIDACIONES"

#End Region

#Region "TEXTCHANGED"
    Protected Sub txt_Afi_TextChanged(sender As Object, e As EventArgs) Handles txt_Afi.TextChanged
        If (txt_Afi.Text <> "") Then
            If IsNumeric(txt_Afi.Text) Then
                sds_SoloEquipo.SelectParameters("id_Equipo").DefaultValue = txt_Afi.Text
                sds_SoloEquipo.DataBind()
                'Carga de SDS a DataTable
                Dim dt_Equipos As DataTable = CType(sds_SoloEquipo.Select(DataSourceSelectArguments.Empty), DataView).Table
                If dt_Equipos.Rows.Count = 0 Then
                    lbl_ErrorAfi.InnerHtml = "Error! - Afi no encontrado."
                    lbl_ErrorAfi.Visible = True
                    txt_Afi.Text = ""
                    lbl_Afi.InnerText = ""
                    lbl_MarcaEquipo.InnerText = ""
                    lbl_ModeloEquipo.InnerText = ""
                    lbl_NombreEquipo.InnerText = ""
                    lbl_Horometro.InnerText = ""
                Else
                    lbl_ErrorAfi.Visible = False
                    lbl_Afi.InnerText = txt_Afi.Text
                    lbl_NombreEquipo.InnerText = dt_Equipos.Rows(0).Item("NombreEquipo").ToString()
                    lbl_MarcaEquipo.InnerText = dt_Equipos.Rows(0).Item("MarcaEquipo").ToString()
                    lbl_ModeloEquipo.InnerText = dt_Equipos.Rows(0).Item("ModeloEquipo").ToString()
                    lbl_Horometro.InnerText = dt_Equipos.Rows(0).Item("Horometro").ToString()
                End If
            Else
                lbl_ErrorAfi.InnerHtml = "Ingrese solo números."
                lbl_ErrorAfi.Visible = True
                txt_Afi.Text = ""
                lbl_Afi.InnerText = ""
                lbl_MarcaEquipo.InnerText = ""
                lbl_ModeloEquipo.InnerText = ""
                lbl_NombreEquipo.InnerText = ""
                lbl_Horometro.InnerText = ""
                txt_Afi.Focus()
                LimpiarFormulario()
                Exit Sub
            End If
        End If
    End Sub

    Protected Sub txt_NumeroGuia_TextChanged(sender As Object, e As EventArgs) Handles txt_NumeroGuia.TextChanged
        If (txt_NumeroGuia.Text <> "") Then
            If IsNumeric(txt_NumeroGuia.Text) Then
                lbl_ErrorGuia.Visible = False
            Else
                lbl_ErrorGuia.InnerHtml = "solo números."
                lbl_ErrorGuia.Visible = True
                txt_NumeroGuia.Text = ""
            End If
        End If

    End Sub



    ' Quizas cambiar fechaactual por Fecha del contrato.
    Protected Sub txt_Tarifa_TextChanged(sender As Object, e As EventArgs) Handles txt_Tarifa.TextChanged
        Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(Convert.ToDateTime(txt_Fecha.Text)), Month(Convert.ToDateTime(txt_Fecha.Text)) + 1, 0))
        Dim pvi_DiasFacturacion As Integer = (pvi_MaximoMes - Day(Convert.ToDateTime(txt_Fecha.Text))) + 1

        If txt_Tarifa.Text <> "" Then
            If IsNumeric(txt_Tarifa.Text) Then
                'If rbt_Diario.Checked = True Then
                'txt_Facturacion.Text = Format((Convert.ToInt32(txt_Tarifa.Text) * pvi_DiasFacturacion), "Currency")
                'Else
                ' txt_Facturacion.Text = Format(((Convert.ToInt32(txt_Tarifa.Text) * pvi_DiasFacturacion) / pvi_MaximoMes), "Currency")
                'If

                lbl_ErrorTarifa.Visible = False
            Else
                lbl_ErrorTarifa.InnerHtml = "solo números."
                lbl_ErrorTarifa.Visible = True
                txt_Tarifa.Text = ""
            End If
        End If

    End Sub


#End Region

#Region "RADIOBUTTON"
    ''Protected Sub rbt_mensual_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_mensual.CheckedChanged
    '' pvi_MaximoMes As Integer = Day(DateSerial(Year(Convert.ToDateTime(txt_Fecha.Text)), Month(Convert.ToDateTime(txt_Fecha.Text)) + 1, 0))
    ''Dim pvi_DiasFacturacion As Integer = (pvi_MaximoMes - Day(Convert.ToDateTime(txt_Fecha.Text))) + 1

    ''If txt_Tarifa.Text <> "" Then
    ''If IsNumeric(txt_Tarifa.Text) Then
    ''' txt_Facturacion.Text = Format(((Convert.ToInt32(txt_Tarifa.Text) * pvi_DiasFacturacion) / pvi_MaximoMes), "Currency")
    '' Else
    ''        'txt_Facturacion.Text = ""
    ''       txt_Tarifa.Text = ""
    ''If
    ''Else
    ''      'txt_Facturacion.Text = ""
    ''     txt_Tarifa.Text = ""
    '' End If

    '' End Sub

    '' Protected Sub rbt_Diario_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_Diario.CheckedChanged
    ''Dim pvi_MaximoMes As Integer = Day(DateSerial(Year(Convert.ToDateTime(txt_Fecha.Text)), Month(Convert.ToDateTime(txt_Fecha.Text)) + 1, 0))
    ''Dim pvi_DiasFacturacion As Integer = (pvi_MaximoMes - Day(Convert.ToDateTime(txt_Fecha.Text))) + 1

    ''If txt_Tarifa.Text <> "" Then
    ''If IsNumeric(txt_Tarifa.Text) Then
    ''t_Facturacion.Text = Format((Convert.ToInt32(txt_Tarifa.Text) * pvi_DiasFacturacion), "Currency")
    ''Else
    ''           'txt_Facturacion.Text = ""
    ''          txt_Tarifa.Text = ""
    ''End If
    ''Else
    ''      ' txt_Facturacion.Text = ""
    ''     txt_Tarifa.Text = ""
    ''End If

    ''End Sub

    Private Sub txt_idCotizacion_TextChanged(sender As Object, e As EventArgs) Handles txt_idCotizacion.TextChanged
        If (txt_idCotizacion.Text <> "") Then
            If IsNumeric(txt_idCotizacion.Text) Then
                Dim vlo_ValidarCotizacion As New RN.cls_Cotizaciones
                If (vlo_ValidarCotizacion.fgb_ValidarCotizacion(Convert.ToInt64(txt_idCotizacion.Text))) Then
                    lbl_ErrorAfi.Visible = False

                    ''"Llamar a SP PARA LLENAR CAMPOS"
                    sds_SoloCoti.SelectParameters("id_Cotizacion").DefaultValue = txt_idCotizacion.Text
                    sds_SoloCoti.DataBind()



                    'Carga de SDS a DataTable
                    Dim dt_SoloCoti As DataTable = CType(sds_SoloCoti.Select(DataSourceSelectArguments.Empty), DataView).Table



                    ddl_Clientes.SelectedValue = dt_SoloCoti.Rows(0).Item("RutCliente").ToString()
                    sds_SoloCliente.SelectParameters("RutCliente").DefaultValue = ddl_Clientes.SelectedValue
                    sds_SoloCliente.DataBind()
                    'Carga de SDS a DataTable
                    Dim dt_Clientes As DataTable = CType(sds_SoloCliente.Select(DataSourceSelectArguments.Empty), DataView).Table


                    'txt_Afi.Text = dt_SoloCoti.Rows(0).Item("id_Equipo").ToString()
                    'sds_SoloEquipo.SelectParameters("id_Equipo").DefaultValue = txt_Afi.Text
                    'sds_SoloEquipo.DataBind()
                    'Carga de SDS a DataTable
                    'Dim dt_Equipos As DataTable = CType(sds_SoloEquipo.Select(DataSourceSelectArguments.Empty), DataView).Table



                    lbl_RutCliente.InnerText = dt_Clientes.Rows(0).Item("RutCliente").ToString()
                    lbl_NombreCliente.InnerText = dt_Clientes.Rows(0).Item("NombreCliente").ToString()
                    lbl_NombreRepresentante.InnerText = dt_Clientes.Rows(0).Item("NombresRepresentanteLegal").ToString()
                    lbl_TelUno.InnerText = dt_Clientes.Rows(0).Item("ContactoTelUno").ToString()
                    lbl_CorreoUno.InnerText = dt_Clientes.Rows(0).Item("CorreoElectronicoUno").ToString()



                    'lbl_Afi.InnerText = txt_Afi.Text
                    'lbl_NombreEquipo.InnerText = dt_Equipos.Rows(0).Item("NombreEquipo").ToString()
                    'lbl_MarcaEquipo.InnerText = dt_Equipos.Rows(0).Item("MarcaEquipo").ToString()
                    'lbl_ModeloEquipo.InnerText = dt_Equipos.Rows(0).Item("ModeloEquipo").ToString()
                    'lbl_Horometro.InnerText = dt_Equipos.Rows(0).Item("Horometro").ToString()

                    txt_NombreFaena.Text = dt_SoloCoti.Rows(0).Item("Faena").ToString()

                    txt_Tarifa.Text = dt_SoloCoti.Rows(0).Item("Precio").ToString()

                    ddl_Zonas.SelectedValue = dt_SoloCoti.Rows(0).Item("id_Zona").ToString()

                    'If dt_SoloCoti.Rows(0).Item("TipoUnidad").ToString() = "1" Then
                    'rbt_Diario.Checked = False
                    'rbt_mensual.Checked = True
                    'Else
                    'rbt_Diario.Checked = True
                    'rbt_mensual.Checked = False

                    'End If

                    ddl_Modalidad.SelectedValue = dt_SoloCoti.Rows(0).Item("TipoUnidad").ToString()

                Else
                    LimpiarFormulario()
                    lbl_ErrorCotizacion.InnerHtml = "Cotización no aprobada."
                    lbl_ErrorCotizacion.Visible = True
                    pnl_Agregado.Visible = False
                    txt_idCotizacion.Text = ""
                    txt_idCotizacion.Focus()
                    Exit Sub
                End If


                lbl_ErrorCotizacion.Visible = False
            Else
                LimpiarFormulario()
                lbl_ErrorCotizacion.InnerHtml = "solo números."
                lbl_ErrorCotizacion.Visible = True
                txt_idCotizacion.Text = ""
            End If
        End If
    End Sub




#End Region

End Class