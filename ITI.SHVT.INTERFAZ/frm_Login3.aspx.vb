Public Class frm_Login
    Inherits System.Web.UI.Page

#Region "BOTONES"
    ''' <summary>
    ''' BOTON INGRESAR
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btn_Ingresar_Click(sender As Object, e As System.EventArgs) Handles btn_Ingresar.Click
        'Response.Redirect("~/Frm_Inicio.aspx")
        If Not IsPostBack Then
            If Session("id_Usuario") IsNot Nothing Then
                Response.Redirect("~/" + Session("UrlPrincipal"))
            End If
        End If

        Dim vls_Usuario As String = Trim(txt_Usuario.Text).ToLower
        Dim vls_Contrasena As String = Trim(txt_Contrasena.Text)

        Dim vlo_VerificarUsuario As New RN.RN_LOGIN.cls_Login
        Dim vls_Retorno As String = vlo_VerificarUsuario.fgb_VerificarUsuario(vls_Usuario, vls_Contrasena)


        If (vls_Retorno <> "") Then
            Dim vli_id_Usuario As Integer = Convert.ToInt32(vls_Retorno.Split("+")(0))
            Dim vls_Url As String = "frm_Inicio.aspx"

            Session.Add("id_Usuario", vli_id_Usuario)
            Session.Add("UrlPrincipal", vls_Url)

            sds_Usuario.SelectParameters("id_Usuario").DefaultValue = vli_id_Usuario
            sds_Usuario.DataBind()
            Dim dt_Usuario As DataTable = CType(sds_Usuario.Select(DataSourceSelectArguments.Empty), DataView).Table
            Session.Add("NombreColaborador", dt_Usuario.Rows(0).Item("Nombres").ToString() + " " +
                                         dt_Usuario.Rows(0).Item("ApellidosColaborador").ToString())
            Session.Add("Area", dt_Usuario.Rows(0).Item("Area").ToString())
            Session.Add("id_TipoCargo", dt_Usuario.Rows(0).Item("id_TipoCargo").ToString())
            Response.Redirect("~/" + vls_Url)
        Else
            lbl_Mensaje.Text = "Usuario o contraseña invalidos"
        End If

    End Sub
#End Region

End Class