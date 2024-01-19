Public Class frm_Proveedores
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

            sds_Proveedores.DataBind()
            gdv_Proveedores.DataSource = sds_Proveedores
            gdv_Proveedores.DataBind()
            '''''''''''''''''''''''''''''''''


        End If
    End Sub

    Protected Sub btn_Detalles_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_Detalles As Button = CType(sender, Button)
        Dim vli_idProveedor As Integer = btn_Detalles.CommandArgument

        ViewState("id_Proveedor") = vli_idProveedor

        sds_SoloProveedor.SelectParameters("id_Proveedor").DefaultValue = vli_idProveedor
        sds_SoloProveedor.DataBind()



        '''Carga de SDS a DataTable
        Dim dt_Proveedor As DataTable = CType(sds_SoloProveedor.Select(DataSourceSelectArguments.Empty), DataView).Table


        lbl_NombreProveedor.InnerText = ": " + dt_Proveedor.Rows(0).Item("NombreProveedor").ToString()
        lbl_NombreVendedor.InnerText = ": " + dt_Proveedor.Rows(0).Item("NombreVendedor").ToString()
        lbl_Tel.InnerText = ": " + dt_Proveedor.Rows(0).Item("Telefono").ToString()
        lbl_Estado.InnerText = ": " + dt_Proveedor.Rows(0).Item("EstadoProveedor").ToString()
        txt_Nota.InnerText = dt_Proveedor.Rows(0).Item("NotaProveedor").ToString()
        ''Dim vls_Apellidos() As String = dt_Contrato.Rows(0).Item("Nombres").ToString().Split(" ")
        ''lbl_UsuarioRegistra.InnerText = ": " + vls_Apellidos(0) + " " + dt_Contrato.Rows(0).Item("Apaterno").ToString()

        ''ddl_CambiarEstado.SelectedValue = dt_Contrato.Rows(0).Item("idEstadoContrato")



        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_Detalles", "$('#mpe_Detalles').modal();", True)
        upp_Modal.Update()
    End Sub

End Class