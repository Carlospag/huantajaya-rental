Imports System.Drawing

Public Class inf_RecuperacionVenta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Comprobar permisos sobre esta URL

        If Not IsPostBack Then
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If






            sds_8020.SelectParameters("RutCliente").DefaultValue = "999"
            sds_8020.SelectParameters("Sucursal").DefaultValue = 999
            sds_8020.DataBind()

            sds_8020SinEleccon.SelectParameters("RutCliente").DefaultValue = "999"
            sds_8020SinEleccon.SelectParameters("Sucursal").DefaultValue = 999
            sds_8020SinEleccon.DataBind()

            sds_306090.SelectParameters("RutCliente").DefaultValue = "999"
            sds_306090.SelectParameters("Sucursal").DefaultValue = 999
            sds_306090.DataBind()

            gdv_8020.DataSource = sds_8020
            gdv_8020.DataBind()

            gdv_8020SinEleccon.DataSource = sds_8020SinEleccon
            gdv_8020SinEleccon.DataBind()


            lbl_30.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>DEUDA MENOR A 30 DÍAS&nbsp;&nbsp;&nbsp;&nbsp; : </b>"
            lbl_30y45.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>DEUDA ENTRE 30 A 60 DÍAS : </b>"
            lbl_60.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>DEUDA MAYOR A 60 DÍAS&nbsp;&nbsp;&nbsp;&nbsp; : </b>"
            lbl_TotalGeneral.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>DEUDA TOTAL&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; : </b>"

            Dim dt_3060 As DataTable = CType(sds_306090.Select(DataSourceSelectArguments.Empty), DataView).Table

            txt_valor30.Text = dt_3060.Rows(0).Item("Total30").ToString()
            txt_valor3045.Text = dt_3060.Rows(0).Item("Total3060").ToString()
            txt_valor60.Text = dt_3060.Rows(0).Item("Total60").ToString()
            txt_TotalGeneral.Text = dt_3060.Rows(0).Item("TotalGeneral").ToString()

            txt_porc_30.Text = dt_3060.Rows(0).Item("Porcentaje30").ToString()
            txt_porc_3045.Text = dt_3060.Rows(0).Item("Porcentaje3060").ToString()
            txt_porc60.Text = dt_3060.Rows(0).Item("Porcentaje60").ToString()
            txt_TotalPorcentajes.Text = dt_3060.Rows(0).Item("TotalPorcentajes").ToString()

            txt_factor.Text = dt_3060.Rows(0).Item("FactorRecuperacion").ToString()

            Dim valor1 As Double = "1,5"
            Dim valor2 As Double = "2"
            Dim factor1 As String = Replace(txt_factor.Text, "%", "")
            Dim factor2 As String = Replace(factor1, ".", ",")
            Dim factor As Double = Convert.ToDouble(factor2)

            If factor <= valor1 Then
                txt_factor.BackColor = Color.Green
            ElseIf factor > valor1 And factor <= valor2 Then
                txt_factor.BackColor = Color.Yellow
                txt_factor.ForeColor = Color.Black
            Else
                txt_factor.BackColor = Color.Red
            End If

            txt_factor.Text = "Factor de recuperación: " + dt_3060.Rows(0).Item("FactorRecuperacion").ToString()


        End If
    End Sub



    Private Sub btn_GenerarInforme_Click(sender As Object, e As EventArgs) Handles btn_GenerarInforme.Click
        Dim pvi_SucursalRecVenta As Integer

        If ddl_Sucursal.SelectedIndex = 0 Then
            pvi_SucursalRecVenta = 999
        Else
            pvi_SucursalRecVenta = ddl_Sucursal.SelectedValue
        End If


        If ddl_Clientes.SelectedIndex <> 0 Then
            Dim pvs_RutCliente As String = ddl_Clientes.SelectedValue
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?RutClienteRecuperacionVenta=" & pvs_RutCliente & "&pvi_SucursalRecVenta=" & pvi_SucursalRecVenta & "&tiporeporte=8" & "','_newtab');", True)
        Else
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_reportes.aspx?RutClienteRecuperacionVentaTodos=" & "999" & "&pvi_SucursalRecVenta=" & pvi_SucursalRecVenta & "&tiporeporte=13" & "','_newtab');", True)
        End If
    End Sub

    Private Sub inf_RecuperacionVenta_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Clientes.Items.FindByText("TODOS LOS CLIENTES ...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("TODOS LOS CLIENTES ...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If

        If (ddl_Sucursal.Items.FindByText("TODAS LAS SUCURSALES ...") Is Nothing) Then
            ddl_Sucursal.Items.Insert(0, New ListItem("TODAS LAS SUCURSALES ...", "", True))

            ddl_Sucursal.SelectedIndex = 0
        End If
    End Sub

    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ddl_Clientes.SelectedIndex = -1
        ddl_Sucursal.SelectedIndex = -1
    End Sub
End Class