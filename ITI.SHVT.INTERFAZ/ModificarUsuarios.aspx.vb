Public Class ModificarUsuarios
    Inherits System.Web.UI.Page


#Region "INICIO"
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete



    End Sub

#End Region

#Region "METODOS Y FUNCIONES"

    ''' <summary>
    ''' Metodo que limpia el formulario completo.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LimpiarFormulario()
        txt_RutUsuario.Text = ""
        txt_NombreUsuario.Text = ""
        txt_ApellidoPaternoUsuario.Text = ""
        txt_ApellidoMaternoUsuario.Text = ""
        txt_Usuario.Text = ""
        lbx_OpcionesSistema.SelectedIndex = -1
        ddl_Usuarios.SelectedIndex = 0
        pnl_ErrorUsuario.Visible = False
        pnl_Agregado.Visible = False
        ddl_EstadoUsuario.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' Llena los campos del formulario según el usuario escojido.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LlenarCamposUsuario()
        If (ddl_Usuarios.SelectedIndex <> 0) Then
            sds_Usuario.SelectParameters("id_Usuario").DefaultValue = ddl_Usuarios.SelectedValue
            sds_Usuario.DataBind()
            sds_OpcionesUsuario.SelectParameters("id_Usuario").DefaultValue = ddl_Usuarios.SelectedValue
            sds_OpcionesUsuario.DataBind()

            'Carga de SDS a DataTable
            Dim dt_Usuario As DataTable = CType(sds_Usuario.Select(DataSourceSelectArguments.Empty), DataView).Table
            Dim dt_OpcionesUsuario As DataTable = CType(sds_OpcionesUsuario.Select(DataSourceSelectArguments.Empty), DataView).Table

            txt_RutUsuario.Text = dt_Usuario.Rows(0).Item("RutUsuario").ToString()
            txt_NombreUsuario.Text = dt_Usuario.Rows(0).Item("Nombres").ToString()

            'txt_ApellidoPaternoUsuario.Text = dt_Usuario.Rows(0).Item("ApellidosColaborador").ToString()
            Dim vls_Apellidos() As String = dt_Usuario.Rows(0).Item("ApellidosColaborador").ToString().Split(" ")
            If (vls_Apellidos.Count = 1) Then
                txt_ApellidoPaternoUsuario.Text = vls_Apellidos(0)
            Else
                txt_ApellidoPaternoUsuario.Text = vls_Apellidos(0)
                txt_ApellidoMaternoUsuario.Text = vls_Apellidos(1)
            End If

            txt_Usuario.Text = dt_Usuario.Rows(0).Item("NombreUsuario").ToString()
            ddl_EstadoUsuario.SelectedValue = Convert.ToInt32(dt_Usuario.Rows(0).Item("EstadoUsuario"))

            lbx_OpcionesSistema.SelectedIndex = -1
            For Each i As ListItem In lbx_OpcionesSistema.Items
                For j = 0 To dt_OpcionesUsuario.Rows.Count - 1
                    If (i.Value = dt_OpcionesUsuario.Rows(j).Item("id_OpcionSistema")) Then
                        i.Selected = True
                    End If
                Next
            Next
        End If
    End Sub

#End Region

#Region "DROPDOWNLISTS"

    ''' <summary>
    ''' ''' Carga los datos del usuario seleccionado, llama a la funcion llenarcamposusuario() que es la que 
    ''' realiza todo el trabajo de rellenado y llamado a SDS
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ddl_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Usuarios.SelectedIndexChanged
        If (ddl_Usuarios.SelectedIndex = 0) Then
            LimpiarFormulario()
        End If

        LlenarCamposUsuario()
    End Sub

#End Region

#Region "BOTONES"

    ''' <summary>
    ''' Realiza el llamado a RN para almacenar todo cambio realizado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim vla_OpcionesUsuario(lbx_OpcionesSistema.Items.Count) As Integer
        Dim vli_i As Integer = 0

        For Each vli_Opcion As ListItem In lbx_OpcionesSistema.Items
            If vli_Opcion.Selected Then
                vla_OpcionesUsuario(vli_i) = vli_Opcion.Value
                vli_i = vli_i + 1
            End If
        Next

        Dim vlo_ModificarUsuario As New RN.RN_MODIFICARUSUARIO.cls_ModificarUsuario
        If (vlo_ModificarUsuario.fgb_ModificarUsuario(ddl_Usuarios.SelectedValue,
                                                      txt_Usuario.Text,
                                                      ddl_EstadoUsuario.SelectedValue,
                                                      vla_OpcionesUsuario)) Then
            ddl_Usuarios.DataBind()
            LimpiarFormulario()
            pnl_Agregado.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Boton que limpia todo el formulario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        LimpiarFormulario()
    End Sub

#End Region

#Region "VALIDACIONES"

    ''' <summary>
    ''' Valida la existencia del Usuario en el sistema.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Fecha: 11/08/2017
    ''' Creado por: Mahicol Castillo Valenzuela
    ''' </remarks>
    Protected Sub txt_Usuario_TextChanged(sender As Object, e As EventArgs) Handles txt_Usuario.TextChanged
        If (txt_Usuario.Text <> "") Then
            Dim vlo_BuscarUsuario As New RN.RN_AGREGARUSUARIO.cls_AgregarUsuarios
            If (vlo_BuscarUsuario.fgb_BuscarUsuario(txt_Usuario.Text)) Then
                pnl_ErrorUsuario.Visible = True
                pnl_Agregado.Visible = False
                txt_Usuario.Text = ""
                txt_Usuario.Focus()
            Else
                pnl_ErrorUsuario.Visible = False
                pnl_Agregado.Visible = False
            End If
        End If
    End Sub

    Private Sub ModificarUsuarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

            'Agregar la opción de seleccionar en dropdownlist
            If (ddl_Usuarios.Items.FindByText("Seleccionar usuario...") Is Nothing) Then
                ddl_Usuarios.Items.Insert(0, New ListItem("Seleccionar usuario...", "", True))

                ddl_Usuarios.SelectedIndex = 0
            End If
        End If
    End Sub

#End Region

End Class