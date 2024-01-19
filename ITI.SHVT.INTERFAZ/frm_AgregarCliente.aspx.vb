Public Class frm_AgregarCliente
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
            'sds_ColaboradorXUsuario.SelectParameters("id_Usuario").DefaultValue = Session("id_Usuario").ToString()
            'sds_ColaboradorXUsuario.DataBind()
            'Me.Panel_Causales.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' AÑADE LA OPCIÓN "SELECCIONAR" EN LOS DDL DEL FORMULARIO.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        'Agregar la opción de seleccionar en dropdownlist COLABORADORES
        'If (ddl_Colaborador.Items.FindByText("Seleccionar colaborador...") Is Nothing) Then
        'ddl_Colaborador.Items.Insert(0, New ListItem("Seleccionar colaborador...", "", True))

        'ddl_Colaborador.SelectedIndex = 0
        'End If

        'Agregar la opción de seleccionar en dropdownlist TIPOS DE CASO
        'If (ddl_TipoAmonestacion.Items.FindByText("Seleccionar tipo de caso...") Is Nothing) Then
        'ddl_TipoAmonestacion.Items.Insert(0, New ListItem("Seleccionar tipo de caso...", "", True))

        'ddl_TipoAmonestacion.SelectedIndex = 0
        'End If

        'Agregar la opción de seleccionar en dropdownlist TURNO
        'If (ddl_Ciudades.Items.FindByText("Seleccionar ciudad...") Is Nothing) Then
        '    ddl_Ciudades.Items.Insert(0, New ListItem("Seleccionar ciudad...", "", True))

        '    ddl_Ciudades.SelectedIndex = 0
        'End If
        'Agregar la opción de seleccionar en dropdownlist CAUSALES
        'If (ddl_Causales.Items.FindByText("Seleccionar causa...") Is Nothing) Then
        'ddl_Causales.Items.Insert(0, New ListItem("Seleccionar causa...", "", True))

        'ddl_Causales.SelectedIndex = 0
        'End If
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
    ''' <summary>
    ''' Limpiar el formulario.
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub LimpiarFormulario()
        txt_RutCliente.Text = ""
        txt_NombreCliente.Text = ""
        txt_NombreRepresentanteLegal.Text = ""
        txt_Direccion.Text = ""
        txt_TelUno.Text = ""
        txt_TelDos.Text = ""
        txt_CorreoUno.Text = ""
        txt_CorreoDos.Text = ""
        txt_Observaciones.InnerText = ""
        txt_CargoFinanzas.Text = ""
        txt_CargoContacto.Text = ""
        txt_NombreRepresentanteFinanzas.Text = ""
    End Sub
#End Region

#Region "BOTONES"

    ''' <summary>
    ''' Boton limpiar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        LimpiarFormulario()
    End Sub


    ''' <summary>
    ''' Boton Guardar Cliente
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim pvi_Teldos As Integer
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvs_RutCliente As String = Replace(txt_RutCliente.Text, "-", "")
        Dim pvs_NombreCliente As String = txt_NombreCliente.Text
        Dim pvs_NombreRepresentante As String = txt_NombreRepresentanteLegal.Text
        Dim pvi_Ciudad As Integer = 2 ' valor fijo IQUIQUE 
        Dim pvi_TelUno As Integer = txt_TelUno.Text
        If txt_TelDos.Text = "" Then
            pvi_Teldos = 0
        Else
            pvi_Teldos = txt_TelDos.Text
        End If
        Dim pvs_CorreoUno As String = txt_CorreoUno.Text
        Dim pvs_Direccion As String = txt_Direccion.Text
        Dim pvs_CorreoDos As String = txt_CorreoDos.Text
        Dim pvs_Observaciones As String = txt_Observaciones.InnerText
        Dim pvd_FechaRegistro As String = Today().ToString()
        Dim pvi_EstadoCliente As Integer = 1 ' 1 Vigente, ya que se esta creando
        Dim pvs_NombreRepresentanteFinanzas As String = txt_NombreRepresentanteFinanzas.Text
        Dim pvs_CargoContacto As String = txt_CargoContacto.Text
        Dim pvs_CargoFinanzas As String = txt_CargoFinanzas.Text


        Dim vlo_RegistrarCliente As New RN.RN_REGISTRARCLIENTE.cls_RegistrarCliente
        If (vlo_RegistrarCliente.fgb_RegistrarCliente(pvs_RutCliente,
                                                      pvi_Ciudad,
                                                      pvs_NombreCliente,
                                                      pvs_NombreRepresentante,
                                                      pvi_TelUno,
                                                      pvi_Teldos,
                                                      pvs_CorreoUno,
                                                      pvs_CorreoDos,
                                                      pvs_Observaciones,
                                                      pvi_EstadoCliente,
                                                      pvd_FechaRegistro,
                                                      pvi_idUsuario,
                                                      pvs_Direccion,
                                                      pvs_NombreRepresentanteFinanzas,
                                                      pvs_CargoContacto,
                                                      pvs_CargoFinanzas)) Then
            LimpiarFormulario()
            pnl_Agregado.Visible = True
        End If
    End Sub


#End Region

#Region "VALIDACIONES"
    Protected Sub txt_RutCliente_TextChanged(sender As Object, e As EventArgs) Handles txt_RutCliente.TextChanged
        Dim vlo_ValidaRut As New ITI.FWI.Validacion.Identificador.RUT
        Dim vlo_Caracter As New ITI.FWI.Conversion.Caracter.Caracter
        Dim vls_RutValidar As String = txt_RutCliente.Text

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
            txt_RutCliente.Text = ""
            txt_RutCliente.Focus()

            Exit Sub
        Else
            lbl_ErrorRut.Visible = False
            pnl_Agregado.Visible = False
            txt_NombreCliente.Focus()
        End If

        'Verificacion de rut en sistema
        Dim RutLimpio As String = Replace(txt_RutCliente.Text, "-", "")
        If (RutLimpio.Length = 8 Or RutLimpio.Length = 9) Then

            Dim vlo_BuscarRutCliente As New RN.RN_REGISTRARCLIENTE.cls_RegistrarCliente
            If (vlo_BuscarRutCliente.fgb_BuscarRutCliente(RutLimpio)) Then
                lbl_ErrorRut.InnerHtml = "Error! - Rut duplicado."
                lbl_ErrorRut.Visible = True
                pnl_Agregado.Visible = False
                txt_RutCliente.Text = ""
                txt_RutCliente.Focus()
                Exit Sub
            End If
        End If
    End Sub
#End Region
End Class