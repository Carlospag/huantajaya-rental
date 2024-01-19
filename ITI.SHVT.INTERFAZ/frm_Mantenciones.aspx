<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_Mantenciones.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Mantenciones" %>

<%@ Import Namespace="System.Drawing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_MontoFlota" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_MontoFlotaMantencionActual" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-4">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/img/imgRed.png" Height="20px" />&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_Rojo"></asp:Label><asp:Label runat="server" ID="lbl_PorcentajeRojo"></asp:Label></div>
                <div class="col-md-4">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/img/imgYellow.png" Height="20px" />&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_Amarillo"></asp:Label><asp:Label runat="server" ID="lbl_PorcentajeAmarillo"></asp:Label></div>
                <div class="col-md-4">
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Content/img/imgGreen.png" Height="20px" />&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_Verde"></asp:Label><asp:Label runat="server" ID="lbl_PorcentajeVerde"></asp:Label></div>
            </div>
        </div>
        <br />
        <div class="panel panel-primary">
            <div class="panel-heading">BUSQUEDA DE MANTENCIONES</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <div class="row" id="datetimepicker">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label1">Buscar por AFI&nbsp; </label>
                            <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_BuscarAfi" runat="server" class="input form-control text-center" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label2">Filtrar por Tipo &nbsp; </label>
                            <asp:DropDownList ID="ddl_TipoEquipo" runat="server" CssClass="form-control">
                                <asp:ListItem Value="1">Unidades Mayores</asp:ListItem>
                                <asp:ListItem Value="2">Unidades Menores</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label4">Filtrar por Estado&nbsp; </label>
                            <asp:SqlDataSource ID="sds_EstadosEquipos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_EstadoEquipos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            <asp:DropDownList ID="ddl_EstadoEquipos" runat="server" CssClass="form-control" DataSourceID="sds_EstadosEquipos" DataValueField="id_EstadoEquipo" DataTextField="NombreEstadoEquipo">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label3">Filtrar por Sucursal&nbsp; </label>
                            <asp:SqlDataSource ID="sds_Sucursales" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            <asp:DropDownList ID="ddl_Sucursales" runat="server" CssClass="form-control" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="pull-left">
                            <asp:Button ID="btn_BuscarPorAfi" runat="server" Text="Buscar Por AFI" CssClass="btn btn-info" />
                        </div>
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Informe" CssClass="btn btn-default"> Informe  <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> </asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />
                            <asp:Button ID="btn_filtrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
                <%--</section>--%>
            </div>
        </div>

    </div>
    <div class="container-fluid">
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
            <div class="panel-heading">EQUIPOS PRÓXIMOS A MANTENCIÓN</div>
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
                        <asp:SqlDataSource ID="sds_MantencionEquipos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_MantencionEquipos" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="TipoEquipo" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="EstadoEquipo" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="id_Sucursal" Type="int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="sds_MantencionEquipoXAfi" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_MantencionEquiposXAfi" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_Equipo" Type="int64"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>


                        <asp:SqlDataSource ID="sds_TodasLasMantenciones" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_TodasLasMantenciones" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                        <!-- Listar opciones del sistema -->
                        <asp:GridView runat="server" ID="gdv_UnidadesMenores" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="id_Equipo" HeaderText="AFI" ControlStyle-Font-Bold="true" />
                                <asp:BoundField DataField="NombreEquipo" HeaderText="Nombre" />
                                <asp:BoundField DataField="ModeloEquipo" ItemStyle-VerticalAlign="NotSet" HeaderText="Modelo" />
                                <asp:BoundField DataField="FechaMantencion" ItemStyle-VerticalAlign="NotSet" HeaderText="Última mantención" />
                                <asp:BoundField DataField="FechaProximaMantencion" HeaderText="Próxima Mantención" />
                                <asp:BoundField DataField="DiasRestantes" HeaderText="Dias Restantes" />
                                
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_VerCaso" runat="server" OnClick="btn_VerCaso_Click"
                                            CommandArgument='<%#Eval("id_Equipo")%>' ForeColor='<%# If(Eval("DiasRestantes") > 25, Color.White, If(Eval("DiasRestantes") > 10, Color.Black, Color.White))%>' BackColor='<%# If(Eval("DiasRestantes") > 25, Color.Green, If(Eval("DiasRestantes") > 10, Color.Yellow, Color.Red))%>' Text="Pauta de Mantención" CssClass="btn btn-success btn-group-justified" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_Mantenciones" runat="server" OnClick="btn_Mantenciones_Click"
                                            CommandArgument='<%#Eval("id_Equipo")%>'   Text="Historico" CssClass="btn btn-info btn-group-justified" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                        <asp:GridView runat="server" ID="gdv_UnidadesMayores" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="id_Equipo" HeaderText="AFI" ControlStyle-Font-Bold="true" />
                                <asp:BoundField DataField="NombreEquipo" HeaderText="Nombre" />
                                <asp:BoundField DataField="ModeloEquipo" ItemStyle-VerticalAlign="NotSet" HeaderText="Modelo" />
                                <asp:BoundField DataField="FechaMantencion" ItemStyle-VerticalAlign="NotSet" HeaderText="Fecha Última mantención" />
                                <asp:BoundField DataField="Horometro" ItemStyle-VerticalAlign="NotSet" HeaderText="Horómetro Actual" />
                                <asp:BoundField DataField="HorometroProximaMantencion" HeaderText="Próxima Mantención" />
                                <asp:BoundField DataField="HorasRestantes"  HeaderText="Horas Restantes" />
                                <asp:BoundField DataField="TH"  HeaderText="TH" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_VerCaso" runat="server" OnClick="btn_VerCaso_Click"
                                            CommandArgument='<%#Eval("id_Equipo")%>' ForeColor='<%# If(Eval("HorasRestantes") > 100, Color.White, If(Eval("HorasRestantes") > 0, Color.Black, Color.White))%>' BackColor='<%# If(Eval("HorasRestantes") > 100, Color.Green, If(Eval("HorasRestantes") > 0, Color.Yellow, Color.Red))%>' Text="Pauta de Mantención" CssClass="btn btn-success btn-group-justified" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_Mantenciones" runat="server" OnClick="btn_Mantenciones_Click"
                                            CommandArgument='<%#Eval("id_Equipo")%>'   Text="Historico" CssClass="btn btn-info btn-group-justified" />
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
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <div id="DivMensajeAdvertenciaGuardado">
                    <asp:Panel ID="pnl_MensajeAdvertenciaGuardado" runat="server" Visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <asp:Label ID="lbl_MensajeAdvertenciaGuardado" Text="GUARDADO CON ÉXITO!" runat="server" Font-Size="XX-Large" />
                    </asp:Panel>
                </div>
            </div>
            <div class="col-md-3"></div>

        </div>

        <%-- <rsweb:ReportViewer ID="rpu_Informe" ProcessingMode="Remote" Visible="false" runat="server"></rsweb:ReportViewer>--%>

        <script>
            $("#<%=pnl_MensajeAdvertenciaGuardado.ClientID%>").delay(3000).fadeTo(500, 0);
        </script>

        <!-- Modal -->
        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_Mantenciones" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 90% !important;">

                <div class="modal-content">
                    <div class="modal-body">
                      

                         <asp:UpdatePanel ID="upp_ListaMantenciones" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">HISTORICO DE MANTENCIONES</div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <asp:SqlDataSource ID="sds_Mantenciones" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                                                SelectCommand="up_parque_s_MantencionEquiposXAfiHistorico" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                             


                                            <!-- Listar opciones del sistema -->
                                            <asp:GridView runat="server" ID="gdv_Mantenciones" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                                                GridLines="None" AllowSorting="true">
                                                <Columns>
                                                    <asp:BoundField DataField="FechaMantencion" HeaderText="Fecha mantención" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="HorometroMantencion" HeaderText="Horometro al realizar mantención" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="RegistradoPor" ItemStyle-VerticalAlign="NotSet" HeaderText="Registrada por" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="Notas" ItemStyle-VerticalAlign="NotSet" HeaderText="Observación" HeaderStyle-BackColor="#cccccc" />
                                              
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">

    <script type="text/javascript">
        $(function () {
            $('[id*=gdv_UnidadesMenores]').footable();
            $('[id*=gdv_UnidadesMayores]').footable();
            $('[id*=gdv_Documentos]').footable();
        });
    </script>

    <script>
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
