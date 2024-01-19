
Public Class frm_AgregarUsuarios
    Inherits System.Web.UI.Page

#Region "INICIO"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If


        End If
    End Sub

    Private Sub frm_AgregarUsuarios_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        'Agregar la opción de seleccionar en dropdownlist
        If (ddl_Cargo.Items.FindByText("Seleccionar cargo...") Is Nothing) Then
            ddl_Cargo.Items.Insert(0, New ListItem("Seleccionar cargo...", "", True))

            ddl_Cargo.SelectedIndex = 0
        End If
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    ''' <summary>
    ''' Limpiar el formulario.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LimpiarFormulario()
        txt_RutUsuario.Text = ""
        txt_NombreUsuario.Text = ""
        txt_ApellidoPaternoUsuario.Text = ""
        txt_ApellidoMaternoUsuario.Text = ""
        txt_Usuario.Text = ""
        txt_Telefono.Text = ""
        lbx_OpcionesSistema.SelectedIndex = -1
        pnl_ErrorRut.Visible = False
        pnl_ErrorUsuario.Visible = False
        pnl_Agregado.Visible = False
    End Sub
#End Region

#Region "BOTONES"

    ''' <summary>
    ''' Boton Limpiar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Limpiar_Click(sender As Object, e As System.EventArgs) Handles btn_Limpiar.Click
        LimpiarFormulario()
    End Sub

    ''' <summary>
    ''' Realiza el guardado de la información de un nuevo usuario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim vla_OpcionesUsuario(lbx_OpcionesSistema.Items.Count) As Integer
        Dim vli_i As Integer = 0

        Dim pvs_RutUsuario As String = txt_RutUsuario.Text
        Dim pvs_Correo As String = txt_CorreoUno.Text
        Dim pvi_Cargo As Integer = ddl_Cargo.SelectedValue
        Dim pvs_Nombres As String = txt_NombreUsuario.Text
        Dim pvs_Apaterno As String = txt_ApellidoPaternoUsuario.Text
        Dim pvs_Amaterno As String = txt_ApellidoMaternoUsuario.Text
        Dim pvs_NombreUsuario As String = txt_Usuario.Text
        Dim pvi_Telefono As Integer = txt_Telefono.Text
        'Dim pvs_Ccontrasena As String = txt_Contrasenha.Text

        'Se crea un array con las opciones seleccionadas
        For Each vli_Opcion As ListItem In lbx_OpcionesSistema.Items
            If vli_Opcion.Selected Then
                vla_OpcionesUsuario(vli_i) = vli_Opcion.Value
                vli_i = vli_i + 1
            End If
        Next

        Dim vlo_AgregarUsuario As New RN.RN_AGREGARUSUARIO.cls_AgregarUsuarios
        If (vlo_AgregarUsuario.fgb_AgregarUsuario(pvs_RutUsuario,
                                                  pvs_NombreUsuario,
                                                  pvs_Apaterno,
                                                  pvs_Amaterno,
                                                  pvs_Correo,
                                                  pvs_Nombres,
                                                  pvi_Cargo,
                                                  pvi_Telefono,
                                                  vla_OpcionesUsuario)) Then
            LimpiarFormulario()
            pnl_Agregado.Visible = True
        End If
    End Sub
#End Region

#Region "VALIDACIONES"

    ''' <summary>
    ''' Validacion del rut y Verificación de existencia del rut en el sistema
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub txt_RutUsuario_TextChanged(sender As Object, e As EventArgs) Handles txt_RutUsuario.TextChanged

        Dim vlo_ValidaRut As New ITI.FWI.Validacion.Identificador.RUT
        Dim vlo_Caracter As New ITI.FWI.Conversion.Caracter.Caracter
        Dim vls_RutValidar As String = txt_RutUsuario.Text

        'Agrega el guion para la validacion
        If (vls_RutValidar.Length = 8) Then
            vls_RutValidar = vls_RutValidar.Insert(7, "-")
        ElseIf (vls_RutValidar.Length = 9) Then
            vls_RutValidar = vls_RutValidar.Insert(8, "-")
        End If


        ' Validación de rut
        If vlo_ValidaRut.ValidaRUT(Trim(vlo_Caracter.LimpiaFormatoRUT(Trim(vls_RutValidar.ToUpper)))) = False Then
            lbl_ErrorRut.InnerHtml = "Rut no superó la validación."
            pnl_ErrorRut.Visible = True
            pnl_ErrorUsuario.Visible = False
            pnl_Agregado.Visible = False
            txt_RutUsuario.Text = ""
            txt_RutUsuario.Focus()
            Exit Sub
        Else
            pnl_ErrorRut.Visible = False
            pnl_ErrorUsuario.Visible = False
            pnl_Agregado.Visible = False
            txt_NombreUsuario.Focus()
        End If

        'Verificacion de rut en sistema
        If (txt_RutUsuario.Text.Length = 8 Or txt_RutUsuario.Text.Length = 9) Then
            Dim vlo_BuscarRutUsuario As New RN.RN_AGREGARUSUARIO.cls_AgregarUsuarios
            If (vlo_BuscarRutUsuario.fgb_BuscarRutUsuario(txt_RutUsuario.Text)) Then
                lbl_ErrorRut.InnerHtml = "Rut ya se encuentra en la base de datos."
                pnl_ErrorRut.Visible = True
                pnl_ErrorUsuario.Visible = False
                pnl_Agregado.Visible = False
                txt_RutUsuario.Text = ""
                txt_RutUsuario.Focus()
                Exit Sub
            End If


        End If
        'If (txt_RutUsuario.Text.Length = 8 Or txt_RutUsuario.Text.Length = 9) Then
        '    Dim vlo_BuscarDatosUsuario As New RN.RN_AGREGARUSUARIO.cls_AgregarUsuarios
        '    'Dim vls_Retorno As DataSet = vlo_BuscarDatosUsuario.fgb_BuscarDatosUsuario(txt_RutUsuario.Text)
        '    'If () Then

        '    'End If
        '    sds_UsuarioAgregar.SelectParameters("RutColaborador").DefaultValue = txt_RutUsuario.Text
        '    sds_UsuarioAgregar.DataBind()
        '    Dim dt_Usuario As DataTable = CType(sds_UsuarioAgregar.Select(DataSourceSelectArguments.Empty), DataView).Table

        '    For i = 0 To dt_Usuario.Rows.Count - 1
        '        txt_NombreUsuario.Text = dt_Usuario.Rows(i).Item("NombreColaborador").ToString()

        '        Dim vls_Apellidos() As String = dt_Usuario.Rows(i).Item("ApellidosColaborador").ToString().Split(" ")
        '        If (vls_Apellidos.Count = 1) Then
        '            txt_ApellidoPaternoUsuario.Text = vls_Apellidos(0)
        '        Else
        '            txt_ApellidoPaternoUsuario.Text = vls_Apellidos(0)
        '            txt_ApellidoMaternoUsuario.Text = vls_Apellidos(1)
        '        End If

        '        txt_Usuario.Text = dt_Usuario.Rows(i).Item("Usuario").ToString()
        '        'txt_CorreoUsuario.Text = dt_Usuario.Rows(i).Item("Correo").ToString()
        '        'ddl_Areas.SelectedValue = dt_Usuario.Rows(i).Item("id_Area").ToString()
        '    Next
        'End If
    End Sub

    ''' <summary>
    ''' Verificación de existencia del usuario en el sistema
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub txt_Usuario_TextChanged(sender As Object, e As EventArgs) Handles txt_Usuario.TextChanged
        If (txt_Usuario.Text <> "") Then
            Dim vlo_BuscarUsuario As New RN.RN_AGREGARUSUARIO.cls_AgregarUsuarios
            If (vlo_BuscarUsuario.fgb_BuscarUsuario(txt_Usuario.Text)) Then
                pnl_ErrorUsuario.Visible = True
                pnl_ErrorRut.Visible = False
                pnl_Agregado.Visible = False
                txt_Usuario.Text = ""
                txt_Usuario.Focus()
            Else
                pnl_ErrorRut.Visible = False
                pnl_ErrorUsuario.Visible = False
                pnl_Agregado.Visible = False
            End If
        End If
    End Sub



#End Region
End Class