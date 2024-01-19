Public Class frm_ModificarProveedor
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub frm_ModificarProveedor_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete

        If (ddl_RutProveedor.Items.FindByText("Buscar por Rut...") Is Nothing) Then
            ddl_RutProveedor.Items.Insert(0, New ListItem("Buscar por Rut...", "", True))

            ddl_RutProveedor.SelectedIndex = 0
        End If

        If (ddl_NombreProveedor.Items.FindByText("Buscar por Nombre...") Is Nothing) Then
            ddl_NombreProveedor.Items.Insert(0, New ListItem("Buscar por Nombre...", "", True))

            ddl_NombreProveedor.SelectedIndex = 0
        End If

        If (ddl_Regiones.Items.FindByText("Seleccionar Región...") Is Nothing) Then
            ddl_Regiones.Items.Insert(0, New ListItem("Seleccionar Región...", "", True))

            ddl_Regiones.SelectedIndex = 0
        End If

        'If (ddl_Comunas.Items.FindByText("Seleccionar Comuna...") Is Nothing) Then
        'ddl_Comunas.Items.Insert(0, New ListItem("Seleccionar Comuna...", "", True))

        'ddl_Comunas.SelectedIndex = 0
        ' End If

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


    Private Sub ddl_RutProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_RutProveedor.SelectedIndexChanged
        pnl_Agregado.Visible = False
        lbl_ErrorRut2.Visible = False
        If (ddl_RutProveedor.SelectedIndex <> 0) Then
            ddl_NombreProveedor.SelectedIndex = -1

            sds_SoloProveedor.SelectParameters("id_Proveedor").DefaultValue = ddl_RutProveedor.SelectedValue
            sds_SoloProveedor.DataBind()

            'Carga de SDS a DataTable
            Dim dt_Proveedor As DataTable = CType(sds_SoloProveedor.Select(DataSourceSelectArguments.Empty), DataView).Table
            txt_RutProveedor.Text = dt_Proveedor.Rows(0).Item("id_Proveedor").ToString()
            txt_NombreProveedor.Text = dt_Proveedor.Rows(0).Item("NombreProveedor").ToString()
            txt_GiroProveedor.Text = dt_Proveedor.Rows(0).Item("GiroProveedor").ToString()
            txt_CorreoProveedor.Text = dt_Proveedor.Rows(0).Item("CorreoProveedor").ToString()

            txt_DireccionProveedor.Text = dt_Proveedor.Rows(0).Item("DireccionProveedor").ToString()
            txt_TelefonoProveedor.Text = dt_Proveedor.Rows(0).Item("TelefonoProveedor").ToString()

            sds_Comunas.SelectParameters("id_Region").DefaultValue = dt_Proveedor.Rows(0).Item("id_RegionProveedor").ToString()
            sds_Comunas.DataBind()
            ddl_Comunas.DataBind()

            ddl_Regiones.SelectedValue = dt_Proveedor.Rows(0).Item("id_RegionProveedor").ToString()
            ddl_Comunas.SelectedValue = dt_Proveedor.Rows(0).Item("id_ComunaProveedor").ToString()


            txt_NombreContactoProveedor.Text = dt_Proveedor.Rows(0).Item("NombreContactoProveedor").ToString()
            txt_TelefonoContactoProveedor.Text = dt_Proveedor.Rows(0).Item("TelefonoContactoProveedor").ToString()
            txt_CorreoContactoProveedor.Text = dt_Proveedor.Rows(0).Item("CorreoContactoProveedor").ToString()
            txt_DireccionContactoProveedor.Text = dt_Proveedor.Rows(0).Item("DireccionContactoProveedor").ToString()

            ddl_dctoCompra.SelectedValue = dt_Proveedor.Rows(0).Item("id_DocumentoCompra").ToString()
            ddl_MedioPago.SelectedValue = dt_Proveedor.Rows(0).Item("id_MedioDePago").ToString()
            txt_Servicios.Text = dt_Proveedor.Rows(0).Item("ServiciosProveedor").ToString()
            ddl_EstadoProveedor.SelectedValue = dt_Proveedor.Rows(0).Item("EstadoProveedor").ToString()

            txt_NombreDestinatario.Text = dt_Proveedor.Rows(0).Item("NombreDestinatario").ToString()
            txt_RutDestinatario.Text = dt_Proveedor.Rows(0).Item("RutDestinatario").ToString()
            ddl_Bancos.SelectedValue = dt_Proveedor.Rows(0).Item("id_Banco").ToString()
            ddl_TipoCuenta.SelectedValue = dt_Proveedor.Rows(0).Item("id_TipoCuenta").ToString()
            txt_NumeroCuenta.Text = dt_Proveedor.Rows(0).Item("NumeroCuenta").ToString()


        Else
            '  LimpiarFormulario()
        End If



    End Sub

    Private Sub ddl_NombreProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_NombreProveedor.SelectedIndexChanged
        pnl_Agregado.Visible = False
        lbl_ErrorRut2.Visible = False

        If (ddl_NombreProveedor.SelectedIndex <> 0) Then

            ddl_RutProveedor.SelectedIndex = -1

            sds_SoloProveedor.SelectParameters("id_Proveedor").DefaultValue = ddl_NombreProveedor.SelectedValue 'CARGAR DATOS DEL PROVEEDOR
            sds_SoloProveedor.DataBind()



            'Carga de SDS a DataTable
            Dim dt_Proveedor As DataTable = CType(sds_SoloProveedor.Select(DataSourceSelectArguments.Empty), DataView).Table
            txt_RutProveedor.Text = dt_Proveedor.Rows(0).Item("id_Proveedor").ToString()
            txt_NombreProveedor.Text = dt_Proveedor.Rows(0).Item("NombreProveedor").ToString()
            txt_GiroProveedor.Text = dt_Proveedor.Rows(0).Item("GiroProveedor").ToString()
            txt_CorreoProveedor.Text = dt_Proveedor.Rows(0).Item("CorreoProveedor").ToString()

            txt_DireccionProveedor.Text = dt_Proveedor.Rows(0).Item("DireccionProveedor").ToString()
            txt_TelefonoProveedor.Text = dt_Proveedor.Rows(0).Item("TelefonoProveedor").ToString()
            ddl_Regiones.SelectedValue = dt_Proveedor.Rows(0).Item("id_RegionProveedor").ToString()

            sds_Comunas.SelectParameters("id_Region").DefaultValue = dt_Proveedor.Rows(0).Item("id_RegionProveedor").ToString() 'CON ESTO CARGAMOS LAS COMUNAS ASOCIADAS A LA REGIÓN SELECCIONADA
            sds_Comunas.DataBind()
            ddl_Comunas.DataBind()

            ddl_Comunas.SelectedValue = dt_Proveedor.Rows(0).Item("id_ComunaProveedor").ToString()

            txt_NombreContactoProveedor.Text = dt_Proveedor.Rows(0).Item("NombreContactoProveedor").ToString()
            txt_TelefonoContactoProveedor.Text = dt_Proveedor.Rows(0).Item("TelefonoContactoProveedor").ToString()
            txt_CorreoContactoProveedor.Text = dt_Proveedor.Rows(0).Item("CorreoContactoProveedor").ToString()
            txt_DireccionContactoProveedor.Text = dt_Proveedor.Rows(0).Item("DireccionContactoProveedor").ToString()

            ddl_dctoCompra.SelectedValue = dt_Proveedor.Rows(0).Item("id_DocumentoCompra").ToString()
            ddl_MedioPago.SelectedValue = dt_Proveedor.Rows(0).Item("id_MedioDePago").ToString()
            txt_Servicios.Text = dt_Proveedor.Rows(0).Item("ServiciosProveedor").ToString()
            ddl_EstadoProveedor.SelectedValue = dt_Proveedor.Rows(0).Item("EstadoProveedor").ToString()


            txt_NombreDestinatario.Text = dt_Proveedor.Rows(0).Item("NombreDestinatario").ToString()
            txt_RutDestinatario.Text = dt_Proveedor.Rows(0).Item("RutDestinatario").ToString()
            ddl_Bancos.SelectedValue = dt_Proveedor.Rows(0).Item("id_Banco").ToString()
            ddl_TipoCuenta.SelectedValue = dt_Proveedor.Rows(0).Item("id_TipoCuenta").ToString()
            txt_NumeroCuenta.Text = dt_Proveedor.Rows(0).Item("NumeroCuenta").ToString()




        Else
            '  LimpiarFormulario()
        End If

    End Sub

    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim pvs_Rut As String = Replace(txt_RutProveedor.Text, ".", "")
        Dim pvs_RutProveedor As String = Replace(pvs_Rut, "-", "")
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
        If (vlo_RegistrarProveedor.fgb_ActualizarProveedor(pvs_RutProveedor,
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
        Else
            pnl_Agregado.Visible = False
        End If
    End Sub

    Private Sub LimpiarFormulario()
        pnl_Agregado.Visible = False
        lbl_ErrorRut2.Visible = False
        ddl_NombreProveedor.SelectedIndex = -1
        ddl_RutProveedor.SelectedIndex = -1

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
End Class