Public Class frm_ModificarCliente
    Inherits System.Web.UI.Page

#Region "INICIO"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If
            txt_RutCliente.Visible = False

        End If
    End Sub



    ''' <summary>
    ''' AÑADE LA OPCIÓN "SELECCIONAR" EN LOS DDL DEL FORMULARIO.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Page_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete

        'If (ddl_Ciudades.Items.FindByText("Seleccionar ciudad...") Is Nothing) Then
        '    ddl_Ciudades.Items.Insert(0, New ListItem("Seleccionar ciudad...", "", True))

        '    ddl_Ciudades.SelectedIndex = 0
        'End If

        If (ddl_Clientes.Items.FindByText("Seleccionar cliente...") Is Nothing) Then
            ddl_Clientes.Items.Insert(0, New ListItem("Seleccionar cliente...", "", True))

            ddl_Clientes.SelectedIndex = 0
        End If

        If (ddl_Estado.Items.FindByText("Seleccionar estado...") Is Nothing) Then
            ddl_Estado.Items.Insert(0, New ListItem("Seleccionar estado...", "", True))

            ddl_Estado.SelectedIndex = 0
        End If
    End Sub

#End Region

#Region "DROPDOWNLIST"

    Protected Sub ddl_Clientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Clientes.SelectedIndexChanged
        If (ddl_Clientes.SelectedIndex = 0) Then
            pnl_Agregado.Visible = False
            LimpiarFormulario()
            txt_RutCliente.Visible = False
        Else
            pnl_Agregado.Visible = False
            txt_RutCliente.Visible = True
            LlenarCamposClientes()
        End If

    End Sub
#End Region

#Region "METODOS Y FUNCIONES"
    Private Sub LimpiarFormulario()
        pnl_Agregado.Visible = False
        txt_RutCliente.Text = ""
        txt_NombreCliente.Text = ""
        txt_NombreRepresentanteLegal.Text = ""
        txt_Direccion.Text = ""
        ddl_Estado.SelectedIndex = -1
        txt_TelUno.Text = ""
        txt_TelDos.Text = ""
        txt_CorreoUno.Text = ""
        txt_CorreoDos.Text = ""
        txt_Motivo.InnerText = ""
        ddl_Clientes.SelectedIndex = -1
        txt_CargoContacto.Text = ""
        txt_CargoFinanzas.Text = ""
        txt_NombreRepresentanteFinanzas.Text = ""
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
            txt_Motivo.InnerText = dt_Clientes.Rows(0).Item("Descripcion").ToString()
            ddl_Estado.SelectedValue = Convert.ToInt32(dt_Clientes.Rows(0).Item("EstadoCliente"))
            txt_Direccion.Text = dt_Clientes.Rows(0).Item("Direccion").ToString()
            txt_CargoContacto.Text = dt_Clientes.Rows(0).Item("CargoContacto").ToString()
            txt_CargoFinanzas.Text = dt_Clientes.Rows(0).Item("CargoFinanzas").ToString()
            txt_NombreRepresentanteFinanzas.Text = dt_Clientes.Rows(0).Item("NombreRepresentanteFinanzas").ToString()
        Else
            LimpiarFormulario()
        End If
    End Sub
#End Region

#Region "BOTONES"
    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        LimpiarFormulario()
    End Sub



    Protected Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click

        Dim pvi_Teldos As Integer
        Dim pvi_idUsuario As Integer = Session("id_Usuario").ToString()
        Dim pvs_RutCliente As String = ddl_Clientes.SelectedValue
        Dim pvs_NombreCliente As String = txt_NombreCliente.Text
        Dim pvs_NombreRepresentante As String = txt_NombreRepresentanteLegal.Text
        Dim pvi_Ciudad As Integer = 2 'Iquique por defecto'
        Dim pvs_Direccion As String = txt_Direccion.Text
        Dim pvi_TelUno As Integer = txt_TelUno.Text
        If txt_TelDos.Text = "" Then
            pvi_Teldos = 0
        Else
            pvi_Teldos = txt_TelDos.Text
        End If
        Dim pvs_CorreoUno As String = txt_CorreoUno.Text
        Dim pvs_CorreoDos As String = txt_CorreoDos.Text
        Dim pvs_Observaciones As String = txt_Motivo.InnerText
        Dim pvd_FechaRegistro As String = Today().ToString()
        Dim pvi_EstadoCliente As Integer = ddl_Estado.SelectedValue ' 1 Vigente, ya que se esta creando
        Dim pvs_NombreRepresentanteFinanzas As String = txt_NombreRepresentanteFinanzas.Text
        Dim pvs_CargoContacto As String = txt_CargoContacto.Text
        Dim pvs_CargoFinanzas As String = txt_CargoFinanzas.Text


        Dim vlo_ActualizarCliente As New RN.RN_REGISTRARCLIENTE.cls_RegistrarCliente
        If (vlo_ActualizarCliente.fgb_ActualizarCliente(pvs_RutCliente,
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


End Class