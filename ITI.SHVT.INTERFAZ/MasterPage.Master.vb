Public Class MasterPage
    Inherits System.Web.UI.MasterPage


#Region "INICIO"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'si no existe ninguna variable de sesion lo manda al login nuevamente
        If Session().Count() = 0 Then
            'FormsAuthentication.SignOut()
            'Response.Redirect("FRM_InicioSesion.aspx")
        End If

        'rescatas valor de session y se le hace un CAST, ya que se guarda como OBJECT.
        'Dim listadoPermiso As List(Of Integer) = DirectCast(Session("listaPermisos"), List(Of Integer))

        lbl_NombreUsuario.Text = Session("NombreColaborador").ToString()
        lbl_Area.Text = Session("Area").ToString()
        ''lbl_NombreUsuario.Text = "Mario Guerra"
        'lbl_Area.Text = "Operaciones"
        mpn_CrearMenu()
    End Sub
#End Region

#Region "BOTONES"
    Protected Sub btnSalir_Click()
        Response.Redirect("~/frm_Login.aspx")
    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Private Sub mpn_CrearMenu()
        sds_MenuSuperiorPadre.SelectParameters("id_Usuario").DefaultValue = Session("id_Usuario").ToString()
        sds_MenuSuperiorPadre.DataBind()

        'Carga de SDS a DataTable
        Dim dt_MenuPadre As DataTable = CType(sds_MenuSuperiorPadre.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim dt_MenuHijo As DataTable = CType(sds_MenuSuperiorHijo.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim vls_MenuSuperior As String = ""

        For i = 0 To dt_MenuPadre.Rows.Count - 1
            If (dt_MenuPadre.Rows(i).Item("OpcionPadre") <> 2) Then
                vls_MenuSuperior = vls_MenuSuperior +
                    "<li><a href='" + dt_MenuPadre.Rows(i).Item("UrlOpcionSistema") + "'>" + dt_MenuPadre.Rows(i).Item("NombreOpcionSistema") + "</a></li>'"
            Else
                vls_MenuSuperior = vls_MenuSuperior +
                    "<li class='dropdown'>" +
                    "<a href='#' class='dropdown-toggle' data-toggle='dropdown' role='button' aria-haspopup='true' aria-expanded='false'>" + dt_MenuPadre.Rows(i).Item("NombreOpcionSistema") +
                    " <span class='caret'></span></a>" +
                    "<ul class='dropdown-menu'>"

                For j = 0 To dt_MenuHijo.Rows.Count - 1
                    If (dt_MenuPadre.Rows(i).Item("id_OpcionSistema") = dt_MenuHijo.Rows(j).Item("OpcionHijo")) Then
                        vls_MenuSuperior = vls_MenuSuperior +
                            "<li><a href='" + dt_MenuHijo.Rows(j).Item("UrlOpcionSistema") + "'>" + dt_MenuHijo.Rows(j).Item("NombreOpcionSistema") + "</a></li>"
                    End If
                Next

                vls_MenuSuperior = vls_MenuSuperior +
                    "</ul>" +
                    "</li>"
            End If
        Next

        vls_MenuSuperior = vls_MenuSuperior +
            "<li><a href='frm_CerrarSesion.aspx'><span class='glyphicon glyphicon-log-out'>  </span> SALIR&nbsp;&nbsp;</a></li>" +
             "<li><a href='frm_CambiarContrasena.aspx'><span class='glyphicon glyphicon-lock'>  </span>&nbsp;&nbsp;</a></li>"
        mnu_Superior.InnerHtml = vls_MenuSuperior
    End Sub
#End Region

End Class