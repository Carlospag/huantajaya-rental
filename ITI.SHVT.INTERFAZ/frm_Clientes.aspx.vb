Public Class frm_Clientes
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

            'sds_Clientes.DataBind()
            'gdv_Clientes.DataSource = sds_Clientes
            'gdv_Clientes.DataBind()
            '''''''''''''''''''''''''''''''''
            pnl_datoscontacto.Visible = False
            pnl_datosempresa.Visible = False
            pnl_datosFacturacion.Visible = False

            Me.sds_Clientes.DataBind()

            lvw_Colapsables.DataSource = Me.sds_ClientesRanking
            lvw_Colapsables.DataBind()

            Dim gdv_Permisos As GridView = lvw_Colapsables.Items(Me.ViewState("NroColapsableActual")).FindControl("gdv_Permisos")
            sds_ClientesRanking2.DataBind()
            gdv_Permisos.DataSource = sds_ClientesRanking2
            gdv_Permisos.DataBind()



            upp_Colapsables.Update()


        End If
    End Sub

    Protected Sub btn_DetallesRecuperacion_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim btn_DetallesRecuperacion As Button = CType(sender, Button)

    End Sub

    Protected Sub ddl_Clientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Clientes.SelectedIndexChanged
        If (ddl_Clientes.SelectedIndex = 0) Then
            txt_RutCliente.Text = ""

            pnl_datoscontacto.Visible = False
            pnl_datosempresa.Visible = False
            pnl_datosFacturacion.Visible = False
            pnl_Ranking.visible = True


            lvw_Colapsables.DataSource = Me.sds_ClientesRanking
            lvw_Colapsables.DataBind()

            Dim gdv_Permisos As GridView = lvw_Colapsables.Items(Me.ViewState("NroColapsableActual")).FindControl("gdv_Permisos")
            sds_ClientesRanking2.DataBind()
            gdv_Permisos.DataSource = sds_ClientesRanking2
            gdv_Permisos.DataBind()

            upp_Colapsables.Update()



        Else
            pnl_datoscontacto.Visible = True
            pnl_datosempresa.Visible = True
            pnl_datosFacturacion.Visible = True
            pnl_Ranking.Visible = False

            LlenarCamposClientes()
        End If

    End Sub

    Protected Sub LlenarCamposClientes()

        If (ddl_Clientes.SelectedIndex <> 0) Then

            sds_SoloCliente.SelectParameters("RutCliente").DefaultValue = ddl_Clientes.SelectedValue
            sds_SoloCliente.DataBind()

            'Carga de SDS a DataTable
            Dim dt_Clientes As DataTable = CType(sds_SoloCliente.Select(DataSourceSelectArguments.Empty), DataView).Table

            txt_RutCliente.Text = dt_Clientes.Rows(0).Item("RutCliente").ToString()
            txt_NombreCliente.Text = dt_Clientes.Rows(0).Item("NombreCliente").ToString()
            txt_NombreRepresentanteLegal.Text = dt_Clientes.Rows(0).Item("NombresRepresentanteLegal").ToString()
            'ddl_Ciudades.SelectedValue = Convert.ToInt32(dt_Clientes.Rows(0).Item("id_Ciudad"))
            txt_TelUno.Text = dt_Clientes.Rows(0).Item("ContactoTelUno").ToString()
            txt_TelDos.Text = dt_Clientes.Rows(0).Item("ContactoTelDos").ToString()
            txt_CorreoUno.Text = dt_Clientes.Rows(0).Item("CorreoElectronicoUno").ToString()
            txt_CorreoDos.Text = dt_Clientes.Rows(0).Item("CorreoElectronicoDos").ToString()
            ' ddl_Estado.SelectedValue = Convert.ToInt32(dt_Clientes.Rows(0).Item("EstadoCliente"))
            txt_Direccion.Text = dt_Clientes.Rows(0).Item("Direccion").ToString()
            txt_CargoContacto.Text = dt_Clientes.Rows(0).Item("CargoContacto").ToString()
            txt_CargoFinanzas.Text = dt_Clientes.Rows(0).Item("CargoFinanzas").ToString()
            txt_NombreRepresentanteFinanzas.Text = dt_Clientes.Rows(0).Item("NombreRepresentanteFinanzas").ToString()


            sds_FlotaCliente.SelectParameters("id_Cliente").DefaultValue = ddl_Clientes.SelectedValue
            sds_FlotaCliente.DataBind()

            Dim dt_FlotaCliente As DataTable = CType(sds_FlotaCliente.Select(DataSourceSelectArguments.Empty), DataView).Table

            Dim vls_Valor As String = dt_FlotaCliente.Rows(0).Item("Arriendo").ToString()
            Dim vls_ValorPorcentaje As Double = (Convert.ToInt64(dt_FlotaCliente.Rows(0).Item("Arriendo")) / Convert.ToInt64(dt_FlotaCliente.Rows(0).Item("Arriendo_Todos"))) * 100
            txt_FlotaArrendada.Text = Format(vls_Valor, "Currency").ToString()
            txt_PorcentajeArrendado.Text = Format(vls_ValorPorcentaje, "##,##0.0").ToString + "%"
            txt_ContratosActivos.Text = dt_FlotaCliente.Rows(0).Item("ContratosActivos").ToString()

            sds_FacturacionCliente.SelectParameters("id_Cliente").DefaultValue = ddl_Clientes.SelectedValue
            sds_FacturacionCliente.DataBind()

            Dim dt_FacturacionCliente As DataTable = CType(sds_FacturacionCliente.Select(DataSourceSelectArguments.Empty), DataView).Table

            Dim vls_ValorFacturacionPro As String = dt_FacturacionCliente.Rows(0).Item("FacturacionProyectada").ToString()
            txt_FacturacionProyectada.Text = Format(vls_ValorFacturacionPro, "Currency").ToString()


        Else

        End If
    End Sub



    Private Sub frm_Clientes_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Clientes.Items.FindByText("Ranking de clientes...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("Ranking de clientes...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If
    End Sub
End Class