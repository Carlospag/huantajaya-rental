Public Class frm_ModificarOC
    Inherits System.Web.UI.Page

    Public TotalFinal As String = "0"

#Region "INICIO"

    ''FORM LOAD
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

            lbl1.Visible = True
            lbl2.Visible = True
            lbl3.Visible = True
            lbl5.Visible = True
            lbl6.Visible = True
            CrearGV()
            txt_TotalFinal.Text = Format((Replace(TotalFinal, "$", "")), "Currency")
            txt_IVA.Text = Format((0), "Currency")
            txt_TotalOC.Text = Format((0), "Currency")
        End If

    End Sub

    ''PRE-RENDER
    Private Sub frm_CrearOC_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_CCPadre.Items.FindByText("Seleccionar CC General...") Is Nothing) Then
            ddl_CCPadre.Items.Insert(0, New ListItem("Seleccionar CC General...", "", True))

            ddl_CCPadre.SelectedIndex = 0
        End If

        If (ddl_CCHijo.Items.FindByText("Seleccionar CC Especifico...") Is Nothing) Then
            ddl_CCHijo.Items.Insert(0, New ListItem("Seleccionar CC Especifico...", "", True))

            ddl_CCHijo.SelectedIndex = 0
        End If
        If (ddl_NombreProveedor.Items.FindByText("Buscar por nombre...") Is Nothing) Then
            ddl_NombreProveedor.Items.Insert(0, New ListItem("Buscar por nombre...", "", True))

            ddl_NombreProveedor.SelectedIndex = 0
        End If
        If (ddl_RutProveedor.Items.FindByText("Buscar por Rut...") Is Nothing) Then
            ddl_RutProveedor.Items.Insert(0, New ListItem("Buscar por Rut...", "", True))

            ddl_RutProveedor.SelectedIndex = 0
        End If

        If (ddl_dctoCompra.Items.FindByText("Seleccionar dcto compra...") Is Nothing) Then
            ddl_dctoCompra.Items.Insert(0, New ListItem("Seleccionar dcto compra...", "", True))

            ddl_dctoCompra.SelectedIndex = 0
        End If
        If (ddl_MedioPago.Items.FindByText("Seleccionar medio de pago...") Is Nothing) Then
            ddl_MedioPago.Items.Insert(0, New ListItem("Seleccionar medio de pago...", "", True))

            ddl_MedioPago.SelectedIndex = 0
        End If
    End Sub

#End Region

#Region "BOTONES"

    ''AGREGAR FILA AL DETALLE DE LA OC
    Private Sub btn_Agregar_Click(sender As Object, e As EventArgs) Handles btn_Agregar.Click
        If txt_Producto.Text <> "" And IsNumeric(txt_Cantidad.Text) And IsNumeric(txt_ValorUnitario.Text) And ddl_dctoCompra.SelectedIndex <> -1 Then
            Dim dt_Detalle As DataTable = DirectCast(ViewState("dt_Detalle"), DataTable)

            Dim Producto As String = txt_Producto.Text
            Dim Cantidad As Integer = txt_Cantidad.Text
            Dim Precio As String = Format((Convert.ToDouble(txt_ValorUnitario.Text)), "Currency")
            Dim Descuento As String
            Dim TipoDescuento As String = ""

            If Not IsNumeric(txt_Descuento.Text) Then
                Descuento = txt_Descuento.Text
                TipoDescuento = ""
            Else
                Descuento = txt_Descuento.Text
                If Descuento.ToString() <> "" Then
                    If ddl_TipoDcto.SelectedValue = 1 Then
                        Descuento = Format((Convert.ToDouble(txt_Descuento.Text)), "Currency")
                        TipoDescuento = "$"
                    Else
                        TipoDescuento = "%"
                        Descuento = Descuento + " %"
                    End If
                End If
            End If

            Dim TotalFila As String = txt_TotalFila.Text

            dt_Detalle.Rows.Add(Producto, Cantidad, Precio, Descuento, TipoDescuento, TotalFila)

            ViewState("dt_Detalle") = dt_Detalle
            CargarGdvDetalle()
            txt_Producto.Text = ""
            txt_Cantidad.Text = ""
            txt_Descuento.Text = ""
            txt_TotalFila.Text = ""
            txt_ValorUnitario.Text = ""

            txt_TotalFinal.Text = Replace(txt_TotalFinal.Text, "$", "")
            txt_TotalFinal.Text = Replace(txt_TotalFinal.Text, ".", "")
            TotalFila = Replace(TotalFila, "$", "")
            TotalFila = Replace(TotalFila, ".", "")
            TotalFinal = Convert.ToDouble(txt_TotalFinal.Text) + Convert.ToDouble(TotalFila)
            txt_TotalFinal.Text = Format((TotalFinal), "Currency")

            If ddl_dctoCompra.SelectedValue = 1 Or ddl_dctoCompra.SelectedValue = 3 Then    ''FACTURA O BOLETA
                txt_IVA.Text = Format((TotalFinal * 0.19), "Currency")
                txt_TotalOC.Text = Format((TotalFinal * 1.19), "Currency")                  ''FACTURA EXENTA
            Else
                txt_IVA.Text = Format((0), "Currency")
                txt_TotalOC.Text = Format((TotalFinal), "Currency")
            End If

            FilaIva.Visible = True
            FilaTotal.Visible = True
            FilaTotalOC.Visible = True
            txt_Producto.Focus()
        End If
    End Sub

    ''LIMPIAR FORMULARIO
    Private Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        limpiar()
    End Sub

    ''GUARDAR LA INFÓRMACIÓN Y GENERAR LA ORDEN DE COMPRA
    Private Sub btn_Guardar_Click(sender As Object, e As EventArgs) Handles btn_Guardar.Click
        Dim pvs_RutProveedor As String
        Dim pvi_dctoCompra As Integer = ddl_dctoCompra.SelectedValue
        Dim pvi_MedioPago As Integer = ddl_MedioPago.SelectedValue
        Dim pvi_CCGeneral As Integer = ddl_CCPadre.SelectedValue
        Dim pvi_CCEspecifico As Integer = ddl_CCHijo.SelectedValue
        Dim pvd_FechaOC As Date = Today()
        Dim vlo_RegistrarOC As New RN.cls_OrdenDeCompra


        If ddl_RutProveedor.SelectedIndex <> 0 Then
            pvs_RutProveedor = ddl_RutProveedor.SelectedValue
        Else
            pvs_RutProveedor = ddl_NombreProveedor.SelectedValue
        End If


        vlo_RegistrarOC.fgb_RegistrarOC(pvs_RutProveedor,
                                            pvi_dctoCompra,
                                            pvi_MedioPago,
                                            pvi_CCGeneral,
                                            pvi_CCEspecifico,
                                            pvd_FechaOC)

        Dim dt_Contrato As DataTable = CType(sds_NumeroOCCrear.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim pvi_NumeroOC As Integer = dt_Contrato.Rows(0).Item("NumeroOC").ToString()

        For i = 0 To gdv_DetalleOC.Rows.Count - 1

            Dim pvs_NombreProducto As String = gdv_DetalleOC.Rows(i).Cells(0).Text
            Dim pvi_Cantidad As Double = Replace(Replace(gdv_DetalleOC.Rows(i).Cells(1).Text, ".", ""), "$", "")
            Dim pvi_ValorUnitario As Double = Replace(Replace(gdv_DetalleOC.Rows(i).Cells(2).Text, ".", ""), "$", "")
            Dim pvi_Descuento As Double

            If gdv_DetalleOC.Rows(i).Cells(3).Text = "&nbsp;" Then
                pvi_Descuento = 0
            Else
                pvi_Descuento = Replace(Replace(Replace(gdv_DetalleOC.Rows(i).Cells(3).Text, ".", ""), "$", ""), "%", "")
            End If

            Dim pvi_TipoDescuento As Integer
            If gdv_DetalleOC.Rows(i).Cells(4).Text = "$" Then
                pvi_TipoDescuento = 1
            Else
                pvi_TipoDescuento = 2
            End If

            Dim pvi_TotalFila As Double = Replace(Replace(gdv_DetalleOC.Rows(i).Cells(5).Text, ".", ""), "$", "")

            vlo_RegistrarOC.fgb_RegistrarDetalleOC(pvi_NumeroOC,
                                                       pvs_NombreProducto,
                                                       pvi_Cantidad,
                                                       pvi_ValorUnitario,
                                                       pvi_Descuento,
                                                       pvi_TipoDescuento,
                                                       pvi_TotalFila)
        Next
        noc.InnerText = pvi_NumeroOC
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_GenerarCotizacion", "$('#mpe_GenerarCotizacion').modal();", True)


        limpiar()
        upp_ocgenerada.Update()
    End Sub

#End Region

#Region "DROPDOWNLIST"

    ''DDL CC PADRE (UNIDAD DE NEGOCIO)
    Private Sub ddl_CCPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_CCPadre.SelectedIndexChanged
        If ddl_CCPadre.SelectedIndex = 0 Then
            ddl_CCHijo.SelectedIndex = -1
            ddl_CCHijo.DataSource = Nothing
        Else
            sds_CCHijos.SelectParameters("id_CentroCostoPadre").DefaultValue = ddl_CCPadre.SelectedValue
            sds_CCHijos.DataBind()
        End If
    End Sub

    ''DDL RUT PROVEEDOR
    Private Sub ddl_RutProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_RutProveedor.SelectedIndexChanged
        pnl_Agregado.Visible = False

        lbl1.InnerText = "RUT: "
        lbl2.InnerText = "Nombre: "
        lbl3.InnerText = "Giro: "
        lbl5.InnerText = "Región: "
        lbl6.InnerText = "Comuna: "

        If (ddl_RutProveedor.SelectedIndex <> 0) Then
            lbl_Rut.Visible = True
            lbl_Nombre.Visible = True
            lbl_Giro.Visible = True
            lbl_Region.Visible = True
            lbl_Comuna.Visible = True

            lbl1.Visible = True
            lbl2.Visible = True
            lbl3.Visible = True
            lbl5.Visible = True
            lbl6.Visible = True

            ddl_NombreProveedor.SelectedIndex = -1

            sds_SoloProveedorOC.SelectParameters("id_Proveedor").DefaultValue = ddl_RutProveedor.SelectedValue
            sds_SoloProveedorOC.DataBind()

            'Carga de SDS a DataTable

            Dim dt_Proveedor As DataTable = CType(sds_SoloProveedorOC.Select(DataSourceSelectArguments.Empty), DataView).Table
            lbl_Rut.InnerText = dt_Proveedor.Rows(0).Item("id_Proveedor").ToString()
            lbl_Nombre.InnerText = dt_Proveedor.Rows(0).Item("NombreProveedor").ToString()
            lbl_Giro.InnerText = dt_Proveedor.Rows(0).Item("GiroProveedor").ToString()

            lbl_Region.InnerText = dt_Proveedor.Rows(0).Item("NombreRegion").ToString()
            lbl_Comuna.InnerText = dt_Proveedor.Rows(0).Item("NombreComuna").ToString()

            ddl_dctoCompra.SelectedValue = dt_Proveedor.Rows(0).Item("id_DocumentoCompra").ToString()
            ddl_MedioPago.SelectedValue = dt_Proveedor.Rows(0).Item("id_MedioDePago").ToString()


        Else
            '  LimpiarFormulario()
        End If



    End Sub

    ''DDL NOMBRE PROVEDOR
    Private Sub ddl_NombreProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_NombreProveedor.SelectedIndexChanged
        pnl_Agregado.Visible = False

        lbl1.InnerText = "RUT: "
        lbl2.InnerText = "Nombre: "
        lbl3.InnerText = "Giro: "
        lbl5.InnerText = "Región: "
        lbl6.InnerText = "Comuna: "


        If (ddl_NombreProveedor.SelectedIndex <> 0) Then
            lbl_Rut.Visible = True
            lbl_Nombre.Visible = True
            lbl_Giro.Visible = True
            lbl_Region.Visible = True
            lbl_Comuna.Visible = True

            lbl1.Visible = True
            lbl2.Visible = True
            lbl3.Visible = True
            lbl5.Visible = True
            lbl6.Visible = True

            ddl_RutProveedor.SelectedIndex = -1

            sds_SoloProveedorOC.SelectParameters("id_Proveedor").DefaultValue = ddl_NombreProveedor.SelectedValue
            sds_SoloProveedorOC.DataBind()

            'Carga de SDS a DataTable

            Dim dt_Proveedor As DataTable = CType(sds_SoloProveedorOC.Select(DataSourceSelectArguments.Empty), DataView).Table
            lbl_Rut.InnerText = dt_Proveedor.Rows(0).Item("id_Proveedor").ToString()
            lbl_Nombre.InnerText = dt_Proveedor.Rows(0).Item("NombreProveedor").ToString()
            lbl_Giro.InnerText = dt_Proveedor.Rows(0).Item("GiroProveedor").ToString()
            lbl_Region.InnerText = dt_Proveedor.Rows(0).Item("NombreRegion").ToString()
            lbl_Comuna.InnerText = dt_Proveedor.Rows(0).Item("NombreComuna").ToString()

            ddl_dctoCompra.SelectedValue = dt_Proveedor.Rows(0).Item("id_DocumentoCompra").ToString()
            ddl_MedioPago.SelectedValue = dt_Proveedor.Rows(0).Item("id_MedioDePago").ToString()
        Else
            '  LimpiarFormulario()
        End If

    End Sub

    '' DDL TIPO DE DOCUMENTO DE COMPRA
    Private Sub ddl_TipoDcto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_TipoDcto.SelectedIndexChanged
        If IsNumeric(txt_ValorUnitario.Text) Then
            If IsNumeric(txt_Cantidad.Text) Then
                If IsNumeric(txt_Descuento.Text) Then
                    If ddl_TipoDcto.SelectedValue = 1 Then
                        txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text)) - Convert.ToDouble(txt_Descuento.Text)), "Currency")
                    Else
                        txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text)) - ((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text) * (Convert.ToDouble(txt_Descuento.Text) / 100)))), "Currency")
                    End If
                Else
                    txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text))), "Currency")
                End If
            End If
        End If
    End Sub

#End Region

#Region "TEXTBOX"

    ''TXT DESCUENTO
    Private Sub txt_Descuento_TextChanged(sender As Object, e As EventArgs) Handles txt_Descuento.TextChanged
        If IsNumeric(txt_ValorUnitario.Text) Then
            If IsNumeric(txt_Cantidad.Text) Then
                If IsNumeric(txt_Descuento.Text) Then
                    If ddl_TipoDcto.SelectedValue = 1 Then
                        txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text)) - Convert.ToDouble(txt_Descuento.Text)), "Currency")
                    Else
                        txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text)) - ((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text) * (Convert.ToDouble(txt_Descuento.Text) / 100)))), "Currency")
                    End If
                Else
                    txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text))), "Currency")
                End If
            End If
        End If
    End Sub

    ''TXT CANTIDAD
    Private Sub txt_Cantidad_TextChanged(sender As Object, e As EventArgs) Handles txt_Cantidad.TextChanged
        If IsNumeric(txt_ValorUnitario.Text) Then
            If IsNumeric(txt_Cantidad.Text) Then
                If IsNumeric(txt_Descuento.Text) Then
                    If ddl_TipoDcto.SelectedValue = 1 Then
                        txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text)) - Convert.ToDouble(txt_Descuento.Text)), "Currency")
                    Else
                        txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text)) - ((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text) * (Convert.ToDouble(txt_Descuento.Text) / 100)))), "Currency")
                    End If
                Else
                    txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text))), "Currency")
                End If

            End If
        End If
        txt_ValorUnitario.Focus()
    End Sub

    ''TXT VALOR UNITARIO
    Private Sub txt_ValorUnitario_TextChanged(sender As Object, e As EventArgs) Handles txt_ValorUnitario.TextChanged
        txt_ValorUnitario.Text = Replace(txt_ValorUnitario.Text, ".", ",")

        If IsNumeric(txt_ValorUnitario.Text) Then
            If IsNumeric(txt_Cantidad.Text) Then
                If IsNumeric(txt_Descuento.Text) Then
                    If ddl_TipoDcto.SelectedValue = 1 Then
                        txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text)) - Convert.ToDouble(txt_Descuento.Text)), "Currency")
                    Else
                        txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text)) - ((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text) * (Convert.ToDouble(txt_Descuento.Text) / 100)))), "Currency")
                    End If
                Else
                    txt_TotalFila.Text = Format(((Convert.ToDouble(txt_ValorUnitario.Text) * Convert.ToDouble(txt_Cantidad.Text))), "Currency")
                End If
            End If
        End If
        txt_Descuento.Focus()
    End Sub

    ''TXT PRODUCTO
    Private Sub txt_Producto_TextChanged(sender As Object, e As EventArgs) Handles txt_Producto.TextChanged
        txt_Cantidad.Focus()
    End Sub

#End Region

#Region "GRIEDVIEW"

    ''CREAR GDV DETALLE
    Private Sub CrearGV()
        Dim dt_Detalle As New DataTable
        dt_Detalle.Columns.AddRange(New DataColumn(5) {New DataColumn("Producto"), New DataColumn("Cantidad"), New DataColumn("Valor"), New DataColumn("Descuento"), New DataColumn("TipoDescuento"), New DataColumn("TotalFila")})
        ViewState("dt_Detalle") = dt_Detalle
        CargarGdvDetalle()
    End Sub

    ''CARGAR GDV DETALLE
    Private Sub CargarGdvDetalle()
        gdv_DetalleOC.DataSource = DirectCast(ViewState("dt_Detalle"), DataTable)
        gdv_DetalleOC.DataBind()
    End Sub

    ''BORRAR FILA DE DETALLE
    Private Sub gdv_DetalleOC_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gdv_DetalleOC.RowCommand
        If e.CommandName = "Delete" Then
            If Not String.IsNullOrEmpty(e.CommandArgument.ToString()) Then
                Try
                    Dim rowIndex = Convert.ToInt32(e.CommandArgument)
                    Dim dt_Detalle As DataTable = DirectCast(ViewState("dt_Detalle"), DataTable)
                    gdv_DetalleOC.DataSource = Nothing
                    gdv_DetalleOC.DataBind()
                    gdv_DetalleOC.DeleteRow(rowIndex)
                    'dt_Detalle.Rows(rowIndex).Delete()

                    'ACTUALIZANDO VALORES FINALES, SUBTOTAL, IVA Y TOTAL AL MOMENTO DE BORRAR
                    Dim ValorAEliminar As Double = dt_Detalle.Rows(rowIndex).Item("TotalFila").ToString()
                    TotalFinal = Replace(txt_TotalFinal.Text, ".", "")
                    TotalFinal = Replace(txt_TotalFinal.Text, "$", "")
                    ValorAEliminar = Replace(ValorAEliminar, ".", "")
                    ValorAEliminar = Replace(ValorAEliminar, "$", "")

                    txt_TotalFinal.Text = Format((Convert.ToDouble(TotalFinal) - Convert.ToDouble(ValorAEliminar)), "Currency")
                    If txt_TotalFinal.Text = "$0" Then
                        txt_IVA.Text = Format((0), "Currency")
                        txt_TotalOC.Text = Format((0), "Currency")

                        FilaIva.Visible = False
                        FilaTotal.Visible = False
                        FilaTotalOC.Visible = False
                    Else

                        FilaIva.Visible = True
                        FilaTotal.Visible = True
                        FilaTotalOC.Visible = True
                        If ddl_dctoCompra.SelectedValue = 1 Or ddl_dctoCompra.SelectedValue = 3 Then        ''FACTURA O BOLETA
                            txt_IVA.Text = Format(((Convert.ToDouble(TotalFinal) - Convert.ToDouble(ValorAEliminar)) * 0.19), "Currency")
                            txt_TotalOC.Text = Format(((Convert.ToDouble(TotalFinal) - Convert.ToDouble(ValorAEliminar)) * 1.19), "Currency")
                        Else                                                                                ''FACTURA EXENTA
                            txt_IVA.Text = Format((0), "Currency")
                            txt_TotalOC.Text = Format((Convert.ToDouble(TotalFinal) - Convert.ToDouble(ValorAEliminar)), "Currency")
                        End If

                    End If
                    dt_Detalle.Rows.RemoveAt(rowIndex)
                    dt_Detalle.AcceptChanges()
                    ViewState("dt_Detalle") = dt_Detalle
                    CargarGdvDetalle()
                Catch ex As Exception
                    Dim algo = ex
                End Try
            End If
        End If
    End Sub

    ''METODO PARA DELETE FILA
    Private Sub gdv_DetalleOC_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gdv_DetalleOC.RowDeleting
        Try

        Catch ex As Exception
            Dim algo = ex
        End Try
    End Sub

#End Region


#Region "FUNCIONES"

    ''FUNCION PARA LIMPIAR FORMULARIO
    Private Sub limpiar()
        ddl_CCHijo.SelectedIndex = -1
        ddl_CCPadre.SelectedIndex = -1
        ddl_dctoCompra.SelectedIndex = -1
        ddl_MedioPago.SelectedIndex = -1
        ddl_RutProveedor.SelectedIndex = -1
        ddl_NombreProveedor.SelectedIndex = -1
        txt_Cantidad.Text = ""
        txt_Producto.Text = ""
        txt_ValorUnitario.Text = ""
        txt_TotalFila.Text = ""
        txt_Descuento.Text = ""

        txt_IVA.Text = "0"
        txt_TotalFinal.Text = "0"
        txt_TotalOC.Text = "0"
        TotalFinal = "0"

        lbl1.Visible = False
        lbl2.Visible = False
        lbl3.Visible = False
        lbl5.Visible = False
        lbl6.Visible = False
        lbl_Rut.Visible = False
        lbl_Nombre.Visible = False
        lbl_Giro.Visible = False
        lbl_Region.Visible = False
        lbl_Comuna.Visible = False

        FilaIva.Visible = False
        FilaTotal.Visible = False
        FilaTotalOC.Visible = False

        gdv_DetalleOC.DataSource = Nothing
        gdv_DetalleOC.DataBind()

        ViewState("dt_DetalleOC") = Nothing
        CrearGV()
    End Sub

    ''FUNCION PARA LLAMAR AL REDIRECCIONAMIENTO
    Private Sub redireccionamiento()
        Response.Redirect("~/frm_OCPanel.aspx")
    End Sub

    Private Sub txt_BuscarPorOC_TextChanged(sender As Object, e As EventArgs) Handles txt_BuscarPorOC.TextChanged
        sds_SoloOCeditar.SelectParameters("id_OC").DefaultValue = txt_BuscarPorOC.Text
        sds_SoloOCeditar.DataBind()

        sds_SoloOCDetalleEditar.SelectParameters("id_OC").DefaultValue = txt_BuscarPorOC.Text
        sds_SoloOCDetalleEditar.DataBind()
        gdv_DetalleOC.DataSource = sds_SoloOCDetalleEditar
        gdv_DetalleOC.DataBind()
    End Sub

#End Region
End Class