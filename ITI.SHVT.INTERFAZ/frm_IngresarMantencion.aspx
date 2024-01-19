<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_IngresarMantencion.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_IngresarMantencion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_EquipoXidequipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_EquipoXidEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_EquiposXFamilia" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_EquiposXfamilia" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Familia" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">FILTROS PARA INGRESO DE MANTENCIÓN AL SISTEMA</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label runat="server" id="Label2">Filtrar por familia&nbsp; </label>
                            <asp:SqlDataSource ID="sds_Familias" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Familias" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            <asp:DropDownList ID="ddl_Familia" runat="server" CssClass="form-control" DataSourceID="sds_Familias" DataValueField="id_Familia" DataTextField="NombreFamilia" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label runat="server" id="Label4">Seleccione equipo&nbsp; </label>
                            <asp:DropDownList ID="ddl_Equipos" runat="server" CssClass="form-control" DataSourceID="sds_EquiposXFamilia" DataValueField="id_Equipo" DataTextField="NombreEquipo" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label runat="server" id="Label3">Buscar por AFI&nbsp; </label> <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_BuscarAfi" runat="server" class="input form-control text-center" required="" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />
                            <asp:Button ID="btn_BuscarPorAfi" runat="server" Text="Buscar por AFI" CssClass="btn btn-primary" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <asp:UpdatePanel runat="server" ID="upp_Notificacion" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div runat="server" id="pnl_Notificacion" visible="false" class="alert alert-success alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <strong runat="server" id="lbl_Notificacion1"></strong><span runat="server" id="lbl_Notificacion2"></span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="panel panel-primary" id="pnl_casos" runat="server">
            <div class="panel-heading">INFORMACIÓN DEL EQUIPO</div>
            <div class="panel-body">
                <%-- <p>A continuación se muestra el listado de casos disponibles en el sistema, usted aquí podra generar las cartas respectivas.</p>--%>
            </div>
            <section>
                <asp:UpdatePanel runat="server" ID="upp_Novedades" ChildrenAsTriggers="true" UpdateMode="Conditional">

                    <ContentTemplate>
                        <div runat="server" id="pnl_mensaje" visible="false" class="alert alert-link alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong runat="server" id="lbl_mensaje1"></strong><span runat="server" id="lbl_mensaje2"></span>
                        </div>
                        <!-- SQLDataSource a utilizar -->
                        <asp:SqlDataSource ID="sds_equipos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_equipos" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_Familia" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="EstadoEquipo" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="id_Sucursal" Type="int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <asp:SqlDataSource ID="sds_TodosLosEquipos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_TodosLosequipos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                        <!-- Listar opciones del sistema -->
                        <asp:GridView runat="server" ID="gdv_Novedades" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="id_Equipo" HeaderText="AFI" ControlStyle-Font-Bold="true" />
                                <asp:BoundField DataField="NombreEquipo" HeaderText="Nombre" />
                                <asp:BoundField DataField="ModeloEquipo" ItemStyle-VerticalAlign="NotSet" HeaderText="Modelo" />
                                <asp:BoundField DataField="Horometro" ItemStyle-VerticalAlign="NotSet" HeaderText="Horómetro" />
                                <asp:BoundField DataField="EstadoEquipo" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_VerCaso" runat="server" OnClick="btn_VerCaso_Click"
                                            CommandArgument='<%#Eval("id_Equipo")%>' Text="Seleccionar" CssClass="btn btn-success btn-group-justified" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        <%--<asp:FileUpload ID="FileUpload1" runat="Server" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </div>
        <!-- Botones Guardar y Limpiar -->
        <div class="row" id="pnl_botones" runat="server">
            <div class="col-md-12">
                <div class="pull-right">
                    <%--<asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />--%>
                    <%--<asp:Button ID="btn_Guardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" data-toggle="modal" />--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-1">
            </div>
            <div class="col-md-10">
                <div id="DivMensajeAdvertenciaGuardado">
                    <asp:Panel ID="pnl_MensajeAdvertenciaGuardado" runat="server" Visible="false" class="alert alert-success alert-dismissible">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <asp:Label ID="lbl_MensajeAdvertenciaGuardado" Text="MANTENCIÓN REGISTRADA CON ÉXITO!" runat="server" Font-Size="XX-Large" />
                    </asp:Panel>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
         <div class="row">
            <div class="col-md-1">
            </div>
            <div class="col-md-10">
                <div id="DivMensajeAdvertenciaGuardadoError">
                    <asp:Panel ID="pnl_MensajeAdvertenciaGuardadoError" runat="server" Visible="false" class="alert alert-danger alert-dismissible">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <asp:Label ID="lbl_MensajeAdvertenciaGuardadoError" Text="ERROR AL REGISTRAR LA MANTENCIÓN." runat="server" Font-Size="XX-Large" />
                    </asp:Panel>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
        <script>
            $("#<%=pnl_MensajeAdvertenciaGuardado.ClientID%>").delay(3000).fadeTo(500, 0);
            $("#<%=pnl_MensajeAdvertenciaGuardadoError.ClientID%>").delay(3000).fadeTo(500, 0);
        </script>

        <!-- Modal -->
        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_VerCaso" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 90% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_Modal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">

                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">Información de la mantención del equipo : <span class="modal-span" runat="server" id="lbl_idEquipo"></span></p></div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label for="nombre">Horómetro</label> <span runat="server" style="color: red" id="lbl_validacionHorometro"></span>
                                                    <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" runat="server" ID="txt_Horometro" class="input form-control text-center"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2  input-daterange" id="datetimepicker">
                                                    <label for="nombre">Fecha de mantención</label>
                                                    <asp:TextBox runat="server" ID="txt_FechaMantencion" name="start" onkeydown="return false;" class="input form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-8">
                                                    <label for="nombre">Observaciones</label>
                                                     <textarea runat="server" class="form-control" rows="2" id="txt_Observaciones" htmlencode="false"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:SqlDataSource ID="sds_Documentos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_Parque_s_DocumentosMantencion" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_EquipoMantencion" Type="Int64"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <div class="panel panel-primary">
                            <div class="panel-heading">Archivos</div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:FileUpload ID="SubirArchivo" runat="Server" />
                                        <asp:Label ID="lbl_NomArchivoCargado1" runat="server"></asp:Label><br />
                                        <asp:Button runat="server" ID="btn_Subir" Text="Subir Archivo" class="btn btn-primary" OnClick="UploadFile"></asp:Button>
                                        <br />
                                        <br />
                                        <asp:Label runat="server" ID="lbl_ErrorArchivo" Visible="false" Style="font-weight: bold; color: red; font-style: italic;" />
                                    </div>
                                    <div class="col-md-1">
                                    </div>
                                    <div class="col-md-7">
                                        <asp:UpdatePanel runat="server" ID="upp_dctos" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="gdv_Documentos" runat="server" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                                                    GridLines="None" AllowSorting="true">
                                                    <Columns>
                                                        <asp:BoundField DataField="NombreDocumento" HeaderText="Nombre Documento" />
                                                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" />
                                                        <asp:TemplateField HeaderText="Descargar" HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btn_Descargar" Style="width: 70px" runat="server" OnClick="btn_Descargar_Click"
                                                                    CommandArgument='<%#Eval("id_Documento") + "," + Eval("NombreDocumentoFisico")%>' Class="btn btn-success btn-group-justified"> <span class="glyphicon glyphicon-save" aria-hidden="true"></span> </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Eliminar" HeaderStyle-Width="50px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btn_Eliminar" Style="width: 70px" runat="server" OnClick="btn_Eliminar_Click"
                                                                    CommandArgument='<%#Eval("id_Documento")%>' Class="btn btn-danger btn-group-justified"> <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button runat="server" ID="btn_GuardarModal" class="btn btn-primary" Text="Ingresar Mantención" />
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>
   
          


    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" >
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">

    <script type="text/javascript">
        $(function () {
            $('[id*=gdv_Novedades]').footable();
            $('[id*=gdv_Documentos]').footable();
        });
    </script>

    <script>
         function cargarDate() {
                $(".input-daterange").datepicker({
                    language: "es",
                    format: "dd/mm/yyyy",
                    autoclose: true,
                    todayHighlight: true,
                    orientation: "bottom"
                });
            }

        $(document).ready(function () {
            $(".input-daterange").datepicker({
                language: "es",
                format: "dd/mm/yyyy",
                autoclose: true,
                todayHighlight: true,
                orientation: "bottom"
            });
        });
    </script>
</asp:Content>
