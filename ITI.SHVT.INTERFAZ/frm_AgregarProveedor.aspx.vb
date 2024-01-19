Public Class frm_AgregarProveedor
    Inherits System.Web.UI.Page

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

    Private Sub frm_AgregarProveedor_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Regiones.Items.FindByText("Seleccionar Región...") Is Nothing) Then
            ddl_Regiones.Items.Insert(0, New ListItem("Seleccionar Región...", "", True))

            ddl_Regiones.SelectedIndex = 0
        End If

        If (ddl_Comunas.Items.FindByText("Seleccionar Comuna...") Is Nothing) Then
            ddl_Comunas.Items.Insert(0, New ListItem("Seleccionar Comuna...", "", True))

            ddl_Comunas.SelectedIndex = 0
        End If

        If (ddl_dctoCompra.Items.FindByText("Seleccionar documento compra...") Is Nothing) Then
            ddl_dctoCompra.Items.Insert(0, New ListItem("Seleccionar documento compra...", "", True))

            ddl_dctoCompra.SelectedIndex = 0
        End If

        If (ddl_MedioPago.Items.FindByText("Seleccionar medio de pago...") Is Nothing) Then
            ddl_MedioPago.Items.Insert(0, New ListItem("Seleccionar medio de pago...", "", True))

            ddl_MedioPago.SelectedIndex = 0
        End If

        If (ddl_Bancos.Items.FindByText("Seleccionar banco...") Is Nothing) Then
            ddl_Bancos.Items.Insert(0, New ListItem("Seleccionar banco...", "", True))

            ddl_Bancos.SelectedIndex = 0
        End If
        If (ddl_TipoCuenta.Items.FindByText("Seleccionar Tipo de cuenta...") Is Nothing) Then
            ddl_TipoCuenta.Items.Insert(0, New ListItem("Seleccionar Tipo de cuenta...", "", True))

            ddl_TipoCuenta.SelectedIndex = 0
        End If


        'If (ddl_CCPadre.Items.FindByText("Seleccionar CC General...") Is Nothing) Then
        '     ddl_CCPadre.Items.Insert(0, New ListItem("Seleccionar CC General...", "", True))

        '    ddl_CCPadre.SelectedIndex = 0
        ' End If

        'If (ddl_CCHijo.Items.FindByText("Seleccionar CC Especifico...") Is Nothing) Then
        '     ddl_CCHijo.Items.Insert(0, New ListItem("Seleccionar CC Especifico...", "", True))

        '     ddl_CCHijo.SelectedIndex = 0
        ' End If
    End Sub






    Private Sub ddl_Regiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Regiones.SelectedIndexChanged
        If ddl_Regiones.SelectedIndex = 0 Then
            ddl_Comunas.SelectedIndex = -1
            ddl_Comunas.DataSource = Nothing
        Else
            sds_Comunas.SelectParameters("id_Region").DefaultValue = ddl_Regiones.SelectedValue
            sds_Comunas.DataBind()
        End If


    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click


        Dim pvs_RutProveedor As String = Replace(txt_RutProveedor.Text, "-", "")
        Dim pvs_NombreProveedor As String = txt_NombreProveedor.Text
        Dim pvs_GiroProveedor As String = txt_GiroProveedor.Text
        Dim pvs_DireccionProveedor As String = txt_DireccionProveedor.Text
        Dim pvi_RegionProveedor As Integer = ddl_Regiones.SelectedValue
        Dim pvi_ComunaProveedor As Integer = ddl_Comunas.SelectedValue
        Dim pvs_TelefonoProveedor As String = txt_TelefonoProveedor.Text
        Dim pvs_CorreoProveedor As String = txt_CorreoProveedor.Text

        Dim pvs_NombreContactoProveedor As String = txt_NombreContactoProveedor.Text
        Dim pvS_TelefonoContactoProveedor As String = txt_TelefonoContactoProveedor.Text
        Dim pvs_CorreoContactoProveedor As String = txt_CorreoContactoProveedor.Text
        Dim pvs_DireccionContactoProveedor As String = txt_DireccionContactoProveedor.Text

        Dim pvi_DocumentoDeCompra As Integer
        Dim pvi_MedioDePago As Integer

        If ddl_dctoCompra.SelectedIndex = 0 Then
            pvi_DocumentoDeCompra = 1
        Else
            pvi_DocumentoDeCompra = ddl_dctoCompra.SelectedValue
        End If

        If ddl_MedioPago.SelectedIndex = 0 Then
            pvi_MedioDePago = 1
        Else
            pvi_MedioDePago = ddl_MedioPago.SelectedValue
        End If


        Dim pvs_Servicios As String = txt_Servicios.Text
        Dim pvi_EstadoProveedor As Integer = ddl_EstadoProveedor.SelectedValue

        Dim pvs_RutDestinatario As String = txt_RutDestinatario.Text
        Dim pvs_NombreDestinatario As String = txt_NombreDestinatario.Text
        Dim pvi_idBanco As Integer
        Dim pvi_idTipoCuenta As Integer

        If ddl_Bancos.SelectedIndex = 0 Then
            pvi_idBanco = 27 '27 CORRESPONDE A NO INDICA
        Else
            pvi_idBanco = ddl_Bancos.SelectedValue
        End If

        If ddl_TipoCuenta.SelectedIndex = 0 Then
            pvi_idTipoCuenta = 4 ' 4 CORRESPONDE A NO INDICA
        Else
            pvi_idTipoCuenta = ddl_TipoCuenta.SelectedValue
        End If

        Dim pvs_NumeroCuenta As String = txt_NumeroCuenta.Text

        Dim vlo_RegistrarProveedor As New RN.RN_PROVEEDORES.cls_Proveedores
        If (vlo_RegistrarProveedor.fgb_RegistrarProveedor(pvs_RutProveedor,
                                                      pvs_NombreProveedor,
                                                      pvs_GiroProveedor,
                                                      pvs_DireccionProveedor,
                                                      pvi_RegionProveedor,
                                                      pvi_ComunaProveedor,
                                                      pvs_TelefonoProveedor,
                                                      pvs_CorreoProveedor,
                                                      pvs_NombreContactoProveedor,
                                                      pvS_TelefonoContactoProveedor,
                                                      pvs_CorreoContactoProveedor,
                                                      pvs_DireccionContactoProveedor,
                                                      pvi_DocumentoDeCompra,
                                                      pvi_MedioDePago,
                                                      pvs_Servicios,
                                                      pvi_EstadoProveedor,
                                                      pvs_RutDestinatario,
                                                      pvs_NombreDestinatario,
                                                      pvi_idBanco,
                                                      pvi_idTipoCuenta,
                                                      pvs_NumeroCuenta)) Then
            LimpiarFormulario()
            pnl_Agregado.Visible = True
        End If
    End Sub


    Private Sub LimpiarFormulario()

        txt_RutProveedor.Text = ""

        txt_NombreProveedor.Text = ""
        txt_GiroProveedor.Text = ""
        txt_TelefonoProveedor.Text = ""
        txt_CorreoProveedor.Text = ""

        txt_DireccionProveedor.Text = ""
        ddl_Regiones.SelectedIndex = -1
        ddl_Comunas.SelectedIndex = -1

        txt_NombreContactoProveedor.Text = ""
        txt_DireccionContactoProveedor.Text = ""
        txt_TelefonoContactoProveedor.Text = ""
        txt_CorreoContactoProveedor.Text = ""

        ddl_MedioPago.SelectedIndex = -1
        ddl_dctoCompra.SelectedIndex = -1

        txt_Servicios.Text = ""

        txt_NombreDestinatario.Text = ""
        txt_RutDestinatario.Text = ""
        ddl_TipoCuenta.SelectedIndex = -1
        ddl_Bancos.SelectedIndex = -1
        txt_NumeroCuenta.Text = ""

    End Sub
    ' Private Sub ddl_CCPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_CCPadre.SelectedIndexChanged
    ' If ddl_CCPadre.SelectedIndex = 0 Then
    '        ddl_CCHijo.SelectedIndex = -1
    '        ddl_CCHijo.DataSource = Nothing
    'Else
    '        sds_CCHijos.SelectParameters("id_CentroCostoPadre").DefaultValue = ddl_CCPadre.SelectedValue
    '        sds_CCHijos.DataBind()
    'End If


    ' End Sub


#Region "VALIDACIONES"
    Protected Sub txt_RutProveedor_TextChanged(sender As Object, e As EventArgs) Handles txt_RutProveedor.TextChanged
        Dim vlo_ValidaRut As New ITI.FWI.Validacion.Identificador.RUT
        Dim vlo_Caracter As New ITI.FWI.Conversion.Caracter.Caracter
        Dim vls_RutValidar As String = txt_RutProveedor.Text

        'Agrega el guion para la validacion
        If (vls_RutValidar.Length = 8) Then
            vls_RutValidar = vls_RutValidar.Insert(7, "-")
        ElseIf (vls_RutValidar.Length = 9) Then
            vls_RutValidar = vls_RutValidar.Insert(8, "-")
        End If


        ' Validación de rut
        If vlo_ValidaRut.ValidaRUT(Trim(vlo_Caracter.LimpiaFormatoRUT(Trim(vls_RutValidar.ToUpper)))) = False Then
            lbl_ErrorRut.InnerHtml = "Error! - Rut inválido."
            'pnl_ErrorRut.Visible = True
            'pnl_ErrorUsuario.Visible = False
            lbl_ErrorRut.Visible = True
            pnl_Agregado.Visible = False
            txt_RutProveedor.Text = ""
            txt_RutProveedor.Focus()

            Exit Sub
        Else
            lbl_ErrorRut.Visible = False
            pnl_Agregado.Visible = False
            txt_NombreProveedor.Focus()
        End If

        'Verificacion de rut en sistema
        Dim RutLimpio As String = Replace(txt_RutProveedor.Text, "-", "")
        If (RutLimpio.Length = 8 Or RutLimpio.Length = 9) Then

            Dim vlo_BuscarRutProveedor As New RN.RN_PROVEEDORES.cls_Proveedores
            If (vlo_BuscarRutProveedor.fgb_BuscarRutProveedor(RutLimpio)) Then
                lbl_ErrorRut.InnerHtml = "Error! - Rut duplicado."
                lbl_ErrorRut.Visible = True
                pnl_Agregado.Visible = False
                txt_RutProveedor.Text = ""
                txt_RutProveedor.Focus()
                Exit Sub
            End If
        End If
    End Sub



    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        LimpiarFormulario()
    End Sub

    Private Sub txt_RutDestinatario_TextChanged(sender As Object, e As EventArgs) Handles txt_RutDestinatario.TextChanged
        Dim vlo_ValidaRut As New ITI.FWI.Validacion.Identificador.RUT
        Dim vlo_Caracter As New ITI.FWI.Conversion.Caracter.Caracter
        Dim vls_RutValidar As String = txt_RutDestinatario.Text

        'Agrega el guion para la validacion
        If (vls_RutValidar.Length = 8) Then
            vls_RutValidar = vls_RutValidar.Insert(7, "-")
        ElseIf (vls_RutValidar.Length = 9) Then
            vls_RutValidar = vls_RutValidar.Insert(8, "-")
        End If


        ' Validación de rut
        If vlo_ValidaRut.ValidaRUT(Trim(vlo_Caracter.LimpiaFormatoRUT(Trim(vls_RutValidar.ToUpper)))) = False Then
            lbl_ErrorRut2.InnerHtml = "Error! - Rut inválido."
            'pnl_ErrorRut.Visible = True
            'pnl_ErrorUsuario.Visible = False
            lbl_ErrorRut2.Visible = True
            pnl_Agregado.Visible = False
            txt_RutDestinatario.Text = ""
            txt_RutDestinatario.Focus()

            Exit Sub
        Else
            lbl_ErrorRut2.Visible = False
            pnl_Agregado.Visible = False
            ddl_Bancos.Focus()
        End If


    End Sub



#End Region
End Class