Imports System.IO
Imports ITI.SHVT.SERV
Public Class frm_IngresarMantencion
    Inherits System.Web.UI.Page
    Private Sub frm_IngresarMantencion_PreRenderComplete(sender As Object, e As EventArgs) Handles Me.PreRenderComplete
        If (ddl_Familia.Items.FindByText("Seleccione familia...") Is Nothing) Then
            ddl_Familia.Items.Insert(0, New ListItem("Seleccione familia...", "", True))

            ddl_Familia.SelectedIndex = 0
        End If
        If (ddl_Equipos.Items.FindByText("Seleccione equipo...") Is Nothing) Then
            ddl_Equipos.Items.Insert(0, New ListItem("Seleccione equipo...", "", True))

            ddl_Equipos.SelectedIndex = 0
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        If Not IsPostBack Then
            'Comprobar permisos sobre esta URL
            Dim vls_Url As String = Request.Url.Segments(Request.Url.Segments.Length - 1)
            Dim vlo_VerificarOpcionSistema As New RN.RN_LOGIN.cls_Login
            If (vlo_VerificarOpcionSistema.fgb_VerificarOpcionSistema(Session("id_Usuario"), vls_Url) = False) Then
                Response.Redirect("~/frm_Login.aspx")
            End If

            If Session("id_TipoCargo") = 4 Then 'Usuario 4 - Jefe de servicio técnico
                Response.Redirect("~/frm_Inicio.aspx")
            End If
        End If
    End Sub
#Region "BOTONES"
    Protected Sub btn_VerCaso_Click(ByVal sender As Object, ByVal e As EventArgs)
        mtn_CargarGrilla()
        lbl_validacionHorometro.Visible = False
        pnl_MensajeAdvertenciaGuardado.Visible = False
        pnl_MensajeAdvertenciaGuardadoError.Visible = False
        lbl_ErrorArchivo.Visible = False
        lbl_ErrorArchivo.Text = ""
        txt_Horometro.Text = ""
        txt_BuscarAfi.Text = ""
        txt_Observaciones.InnerText = ""
        txt_FechaMantencion.Text = Today()
        txt_FechaMantencion.Text = Replace(txt_FechaMantencion.Text, "-", "/")

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cargarDate", "cargarDate();", True)
        Dim btn_VerCaso As Button = CType(sender, Button)
        Dim vli_id_Equipo As Integer = btn_VerCaso.CommandArgument

        ViewState("id_Equipo") = vli_id_Equipo
        lbl_idEquipo.InnerText = vli_id_Equipo

        sds_SoloEquipo.SelectParameters("id_Equipo").DefaultValue = vli_id_Equipo
        sds_SoloEquipo.DataBind()

        sds_Documentos.SelectParameters("id_EquipoMantencion").DefaultValue = vli_id_Equipo
        sds_Documentos.DataBind()
        gdv_Documentos.DataSource = sds_Documentos
        gdv_Documentos.DataBind()

        upp_dctos.Update()

        'Carga de SDS a DataTable
        Dim dt_Equipos As DataTable = CType(sds_EquipoXidequipo.Select(DataSourceSelectArguments.Empty), DataView).Table

        Dim pvi_idFamilia As Integer = dt_Equipos.Rows(0).Item("id_Familia").ToString()

        If pvi_idFamilia = 1 Or pvi_idFamilia = 12 Then
            txt_Horometro.ReadOnly = True
        Else
            txt_Horometro.ReadOnly = False
        End If
        'ViewState("id_Caso") = vli_id_Caso
        lbl_idEquipo.InnerText = vli_id_Equipo


        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True)
        upp_Modal.Update()

    End Sub
    Protected Sub btn_Limpiar_Click(sender As Object, e As EventArgs) Handles btn_Limpiar.Click
        ddl_Equipos.SelectedIndex = -1
        ddl_Familia.SelectedIndex = -1
        txt_BuscarAfi.Text = ""

        'sds_TodosLosEquipos.DataBind()
        gdv_Novedades.DataSource = Nothing
        gdv_Novedades.DataBind()
        pnl_MensajeAdvertenciaGuardado.Visible = False
        pnl_MensajeAdvertenciaGuardadoError.Visible = False
        'mtn_CargarGrilla()
    End Sub

    ''' ELIMINAR DOCUMENTO ADJUNTO
    Protected Sub btn_Eliminar_Click(ByVal sender As Object, ByVal e As EventArgs)
        lbl_ErrorArchivo.Visible = False
        lbl_ErrorArchivo.Text = ""

        Dim btn_Eliminar As LinkButton = CType(sender, LinkButton)
        Dim vli_id_Documento As Integer = btn_Eliminar.CommandArgument

        Dim vlo_Caso As New RN.RN_PARQUE.cls_Parque
        If (vlo_Caso.fgb_EliminarDocumento(vli_id_Documento)) Then
            sds_Documentos.SelectParameters("id_EquipoMantencion").DefaultValue = Convert.ToInt32(lbl_idEquipo.InnerText)
            sds_Documentos.DataBind()
            gdv_Documentos.DataSource = sds_Documentos
            gdv_Documentos.DataBind()

        Else
            lbl_ErrorArchivo.Visible = True
            lbl_ErrorArchivo.Text = "Error al eliminar el archivo, intente nuevamente."

            sds_Documentos.SelectParameters("id_Equipo").DefaultValue = Convert.ToInt32(lbl_idEquipo.InnerText)
            sds_Documentos.DataBind()
            gdv_Documentos.DataSource = sds_Documentos
            gdv_Documentos.DataBind()
        End If
    End Sub

    ''' DESCARGAR DOCUMENTO ADJUNTO
    Protected Sub btn_Descargar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn_Descargar As LinkButton = CType(sender, LinkButton)
        Dim vls_Argumentos As String() = btn_Descargar.CommandArgument.Split(","c)
        Dim vli_id_Docto As Integer = vls_Argumentos(0)
        Dim vls_NombreDocumento As String = vls_Argumentos(1)

        Dim id_Equipo As String = lbl_idEquipo.InnerText

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('frm_Descarga.aspx?procedencia=2&caso=" & id_Equipo & "&documento=" & vls_NombreDocumento & "','_newtab');", True)
    End Sub

    ''' BOTON SUBIR DOCUMENTOS.
    Protected Sub UploadFile(src As Object, e As EventArgs)
        lbl_ErrorArchivo.Visible = False
        lbl_ErrorArchivo.Text = ""
        Dim id_Equipo As String = Integer.Parse(lbl_idEquipo.InnerText)
        Dim vls_savePath As String = vgs_DirectorioArchivosTemporales & "\" & id_Equipo & "\"
        If (Not Directory.Exists(vls_savePath)) Then
            Directory.CreateDirectory(vls_savePath)
        End If
        If SubirArchivo.HasFile Then
            Dim vls_NombreArchivoCompleto As String
            Dim vls_NombreArchivoLimpio As String
            vls_NombreArchivoCompleto = SubirArchivo.FileName
            vls_NombreArchivoLimpio = Path.GetFileNameWithoutExtension(vls_NombreArchivoCompleto)
            Dim vls_Fecha As String = Date.Now.ToString
            vls_Fecha = vls_Fecha.Replace(" ", "")
            vls_Fecha = vls_Fecha.Replace(":", "")
            vls_Fecha = vls_Fecha.Replace("/", "")
            vls_Fecha = vls_Fecha.Replace("-", "")
            Dim vls_ExtensionesDisponibles() As String = {".pdf", ".xls", ".xlsx", ".doc", ".docx", ".jpeg", ".jpg", ".png", ".txt"}
            If vls_ExtensionesDisponibles.Contains((Path.GetExtension(SubirArchivo.FileName)).ToLower) Then
                Dim vlo_Caso As New RN.RN_MANTENCIONES.cls_Mantenciones
                If (vlo_Caso.fgb_AdjuntarDocumentoMantencion(id_Equipo, vls_NombreArchivoLimpio, (vls_NombreArchivoLimpio + vls_Fecha + Path.GetExtension(SubirArchivo.FileName)))) Then
                    SubirArchivo.PostedFile.SaveAs(vls_savePath & "//" & (vls_NombreArchivoLimpio + vls_Fecha + Path.GetExtension(SubirArchivo.FileName)))
                Else
                    lbl_ErrorArchivo.Visible = True
                    lbl_ErrorArchivo.Text = "Error al subir el archivo, puede que esté repetido."
                End If
            Else
                lbl_ErrorArchivo.Visible = True
                lbl_ErrorArchivo.Text = "Error al subir el archivo, tiene una extensión no permitida."
            End If
        Else
            lbl_ErrorArchivo.Visible = True
            lbl_ErrorArchivo.Text = "Error al subir el archivo, no ha seleccionado ningún documento."
        End If
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True)
        sds_Documentos.SelectParameters("id_EquipoMantencion").DefaultValue = id_Equipo
        sds_Documentos.DataBind()
        gdv_Documentos.DataSource = sds_Documentos
        gdv_Documentos.DataBind()
    End Sub

    Private Sub btn_BuscarPorAfi_Click(sender As Object, e As EventArgs) Handles btn_BuscarPorAfi.Click
        If (txt_BuscarAfi.Text <> "") Then
            If IsNumeric(txt_BuscarAfi.Text) Then
                sds_EquipoXidequipo.SelectParameters("id_Equipo").DefaultValue = Convert.ToInt64(txt_BuscarAfi.Text)
                sds_EquipoXidequipo.DataBind()

                gdv_Novedades.DataSource = sds_EquipoXidequipo
                gdv_Novedades.DataBind()
                'Carga de SDS a DataTable
                Dim dt_Equipos As DataTable = CType(sds_EquipoXidequipo.Select(DataSourceSelectArguments.Empty), DataView).Table

                responsividad()

                If dt_Equipos.Rows.Count = 0 Then
                    lbl_ErrorAfi.InnerHtml = "Error! - Afi no encontrado."
                    lbl_ErrorAfi.Visible = True
                    txt_BuscarAfi.Text = ""
                Else
                    lbl_ErrorAfi.Visible = False
                End If
            Else
                lbl_ErrorAfi.InnerHtml = "Ingrese solo números."
                lbl_ErrorAfi.Visible = True
                txt_BuscarAfi.Text = ""
                txt_BuscarAfi.Focus()
                Exit Sub
            End If
        End If

        pnl_MensajeAdvertenciaGuardado.Visible = False
        pnl_MensajeAdvertenciaGuardadoError.Visible = False
    End Sub


#End Region

#Region "METODOS Y FUNCIONES"
    Private Sub mtn_CargarGrilla()
        gdv_Novedades.DataSource = sds_EquipoXidequipo
        gdv_Novedades.DataBind()

        responsividad()

        gdv_Documentos.DataSource = sds_Documentos
        gdv_Documentos.DataBind()
        'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
        If (gdv_Documentos.Rows.Count <> 0) Then
            gdv_Documentos.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_Documentos.HeaderRow.Cells(1).Attributes("data-hide") = "phone"
            gdv_Documentos.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_Documentos.HeaderRow.Cells(3).Attributes("data-hide") = "phone"

            gdv_Documentos.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub
#End Region

#Region "DROPDOWNLIST"
    Private Sub ddl_Familia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Familia.SelectedIndexChanged
        sds_EquiposXFamilia.SelectParameters("id_Familia").DefaultValue = ddl_Familia.SelectedValue
        sds_EquiposXFamilia.DataBind()
        txt_BuscarAfi.Text = ""

        responsividad()
    End Sub
    Protected Sub responsividad()
        'Comprueba que la grilla no esté vacia y agrega la adaptabilidad a la grilla
        If (gdv_Novedades.Rows.Count <> 0) Then
            gdv_Novedades.HeaderRow.Cells(0).Attributes("data-class") = "expand"
            gdv_Novedades.HeaderRow.Cells(2).Attributes("data-hide") = "phone"
            gdv_Novedades.HeaderRow.Cells(3).Attributes("data-hide") = "phone"
            'gdv_Novedades.HeaderRow.Cells(4).Attributes("data-hide") = "phone"

            gdv_Novedades.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub
    Private Sub ddl_Equipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_Equipos.SelectedIndexChanged
        sds_EquipoXidequipo.SelectParameters("id_Equipo").DefaultValue = ddl_Equipos.SelectedValue
        sds_EquipoXidequipo.DataBind()
        txt_BuscarAfi.Text = ddl_Equipos.SelectedValue

        gdv_Novedades.DataSource = sds_EquipoXidequipo
        gdv_Novedades.DataBind()

        responsividad()
    End Sub

    Private Sub btn_GuardarModal_Click(sender As Object, e As EventArgs) Handles btn_GuardarModal.Click
        'Carga de SDS a DataTable
        Dim dt_Equipos As DataTable = CType(sds_EquipoXidequipo.Select(DataSourceSelectArguments.Empty), DataView).Table
        Dim pvi_idFamilia As Integer = dt_Equipos.Rows(0).Item("id_Familia").ToString()
        Dim vli_ValidadorIngreso As Integer = 0

        If pvi_idFamilia <> 1 And pvi_idFamilia <> 12 Then 'Camionetas y Unidades Menores
            If txt_Horometro.Text <> "" Then
                If IsNumeric(txt_Horometro.Text) Then
                    vli_ValidadorIngreso = 1 'Ingresar
                Else
                    lbl_validacionHorometro.InnerHtml = "Ingrese solo números."
                    lbl_validacionHorometro.Visible = True
                    txt_Horometro.Text = ""
                    txt_Horometro.Focus()
                    vli_ValidadorIngreso = 0 ' No insertar
                End If
            Else
                lbl_validacionHorometro.InnerHtml = "Favor ingresar horómetro"
                lbl_validacionHorometro.Visible = True
                txt_Horometro.Text = ""
                txt_Horometro.Focus()
                vli_ValidadorIngreso = 0 'No insertar
            End If
        Else
            vli_ValidadorIngreso = 1 'Insertar, No validar ingreso de horómetro
        End If


        If vli_ValidadorIngreso = 1 Then
            Dim pvi_idEquipo As Integer = Convert.ToInt64(lbl_idEquipo.InnerText)
            Dim pvi_Horometro As Integer
            If txt_Horometro.Text <> "" Then
                pvi_Horometro = txt_Horometro.Text
            Else
                pvi_Horometro = 99999 ' Solo para enviar un INT y luego en BD insertar NULL
            End If
            Dim pvd_FechaMantencion As Date = txt_FechaMantencion.Text
            Dim pvs_Observacion As String = txt_Observaciones.InnerText
            Dim pvi_idUsuario As Integer = Session("id_Usuario")

            Dim vlo_RegistrarMantencion As New RN.RN_MANTENCIONES.cls_Mantenciones

            If (vlo_RegistrarMantencion.fgb_RegistrarMantencion(pvi_idEquipo,
                                                                pvi_Horometro,
                                                                pvd_FechaMantencion,
                                                                pvs_Observacion,
                                                                pvi_idUsuario)) Then

                pnl_MensajeAdvertenciaGuardado.Visible = True
            Else
                pnl_MensajeAdvertenciaGuardadoError.Visible = True
            End If
        Else
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mpe_VerCaso", "$('#mpe_VerCaso').modal();", True) 'No hacer nada (abrir modal con los mismos campos)
        End If


    End Sub
#End Region



End Class