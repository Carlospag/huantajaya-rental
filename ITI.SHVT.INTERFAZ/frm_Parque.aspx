<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_Parque.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Parque" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sds_SoloContratoXAfi" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloContratoXAfi" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_MontoFlota" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_MontoFlotaParque" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Sucursal" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />

    <div class="container-fluid">

        <div class="row">
            <%--<div class="col-md-12">--%>
            <div class="col-md-3">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/img/taller.png" Height="25px" />&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_Rojo"></asp:Label><asp:Label runat="server" ID="lbl_PorcentajeRojo"></asp:Label>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-3">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/img/stock.png" Height="25px" />&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_Amarillo"></asp:Label><asp:Label runat="server" ID="lbl_PorcentajeAmarillo"></asp:Label>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-3">
                <asp:Image ID="Image6" runat="server" ImageUrl="~/Content/img/imgArriendo.png" Height="25px" />&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_Verde"></asp:Label><asp:Label runat="server" ID="lbl_PorcentajeVerde"></asp:Label>
            </div>
            <div class="col-md-1">

                <asp:ImageButton ID="img_Arica" ImageUrl="~/Content/img/arica.png" runat="server" Height="25px" />
                <asp:ImageButton ID="img_Iquique" ImageUrl="~/Content/img/iquique.png" runat="server" Height="25px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:ImageButton ID="img_AI" ImageUrl="~/Content/img/ai.png" runat="server" Height="25px" />
            </div>
            <%-- </div>--%>
        </div>

        <br />
        <div class="panel panel-primary">
            <div class="panel-heading">FILTROS PARQUE DE EQUIPOS</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <div class="row" id="datetimepicker">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="Label1">Buscar por AFI&nbsp; </label>
                            <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_BuscarAfi" runat="server" class="input form-control text-center" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <div class="">
                                <label runat="server" id="lbl_CLienteBuscar">Filtrar por Cliente:</label>
                                <asp:SqlDataSource ID="sds_ListadoClientes" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ListaClientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                <asp:DropDownList ID="ddl_Clientes" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_ListadoClientes" DataValueField="RutCliente" DataTextField="NombreCliente">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label2">Filtrar por Familia&nbsp; </label>
                            <asp:SqlDataSource ID="sds_Familias" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Familias" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            <asp:DropDownList ID="ddl_Familia" runat="server" CssClass="form-control" DataSourceID="sds_Familias" DataValueField="id_Familia" DataTextField="NombreFamilia">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="Label4">Filtrar por Estado&nbsp; </label>
                            <asp:SqlDataSource ID="sds_EstadosEquipos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_EstadoEquipos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            <asp:DropDownList ID="ddl_EstadoEquipos" runat="server" CssClass="form-control" DataSourceID="sds_EstadosEquipos" DataValueField="id_EstadoEquipo" DataTextField="NombreEstadoEquipo">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
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
                            <asp:LinkButton runat="server" ID="btn_Informe" CssClass="btn btn-default"> Informe <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> </asp:LinkButton>
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
            <div class="panel-heading">PARQUE DE EQUIPOS</div>
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
                                <asp:Parameter Name="id_Cliente" Type="String"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <!-- SQLDataSource a utilizar -->
                        <asp:SqlDataSource ID="sds_EquipoXafi" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_EquipoXAfi" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_Equipo" Type="int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <asp:SqlDataSource ID="sds_TodosLosEquipos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_TodosLosequipos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                        <!-- Listar opciones del sistema -->
                        <asp:GridView runat="server" ID="gdv_Novedades" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="id_Equipo" HeaderStyle-BackColor="#cccccc" HeaderText="AFI" ControlStyle-Font-Bold="true" />
                                <asp:BoundField DataField="NombreEquipo" HeaderStyle-BackColor="#cccccc"  HeaderText="Nombre" />
                                <asp:BoundField DataField="NumeroEquipo" HeaderStyle-BackColor="#cccccc"  ItemStyle-VerticalAlign="NotSet" HeaderText="Serie" />
                                <asp:BoundField DataField="ModeloEquipo" HeaderStyle-BackColor="#cccccc"  ItemStyle-VerticalAlign="NotSet" HeaderText="Modelo" />
                                <asp:BoundField DataField="NombreSucursal" HeaderStyle-BackColor="#cccccc"  ItemStyle-VerticalAlign="NotSet" HeaderText="Sucursal" />
                                <asp:BoundField DataField="EstadoEquipo" HeaderStyle-BackColor="#cccccc"  HeaderText="Estado" />
                                <asp:TemplateField HeaderText=""  HeaderStyle-BackColor="#cccccc" >
                                    <ItemTemplate>
                                        <asp:Button ID="btn_VerCaso" runat="server" OnClick="btn_VerCaso_Click"
                                            CommandArgument='<%#Eval("id_Equipo")%>' Text="Detalles" CssClass="btn btn-success btn-group-justified" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=""  HeaderStyle-BackColor="#cccccc"  HeaderStyle-Width="50px" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_DescargarBitacora" Style="width: 45px" runat="server" OnClick="btn_DescargarBitacora_Click"
                                            CommandArgument='<%#Eval("id_Equipo")%>' Text="A" CssClass="btn btn-primary btn-group-justified "><span class="glyphicon glyphicon-save" aria-hidden="true"></span></asp:LinkButton>
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
        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_VerCaso" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 90% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_Modal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">

                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <b style="color: aqua">Equipo:</b>  <span class="modal-span" runat="server" id="lbl_CabeceraNombre"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                              <%-- <b style="color: aqua">Estado:</b> <span class="modal-span" runat="server" id="lbl_CabeceraEstado"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                        <b style="color: aqua">AFI:</b> <span class="modal-span" runat="server" id="lbl_idEquipo"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                       <%-- <b style="color: aqua">N° Serie:</b> <span class="modal-span" runat="server" id="lbl_Nserie"></span> --%>
                                        </p>


                                    </div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Nombre </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_NombreEquipo"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Procedencia</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_Procedencia"></span></div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="col-md-5">
                                                        <label for="nombre">P. Compra</label>
                                                    </div>
                                                    <div class="col-md-7"><span class="modal-span" runat="server" id="lbl_ValorCompra"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-5">
                                                        <label for="nombre">Horómetro </label>
                                                    </div>
                                                    <div class="col-md-7"><span class="modal-span" runat="server" id="lbl_Horometro"></span></div>
                                                </div>

                                            </div>

                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Marca</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_Marca"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Color</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_Color"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-5">
                                                        <label for="nombre">P. Contable </label>
                                                    </div>
                                                    <div class="col-md-7"><span class="modal-span" runat="server" id="lbl_PrecioActual"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-5">
                                                        <label for="nombre">Últ. Mantención </label>
                                                    </div>
                                                    <div class="col-md-7"><span class="modal-span" runat="server" id="lbl_UltimaMantencion"></span></div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Modelo</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_Modelo"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">N° serie </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_NumeroSerie"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-5">
                                                        <label for="nombre">P. Venta </label>
                                                    </div>
                                                    <div class="col-md-7"><span class="modal-span" runat="server" id="lbl_ValorVenta"></span></div>
                                                </div>
                                                


                                                <div class="col-md-3">
                                                    <div class="col-md-5">
                                                        <label for="nombre">Sig. Mantención </label>
                                                    </div>
                                                    <div class="col-md-7"><span class="modal-span" runat="server" id="lbl_ProximaMantencion"></span></div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-3">
                                                        <label for="nombre">AFI </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_AfiDetalles"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Patente</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_Patente"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-5">
                                                        <label for="nombre">Facturado</label>
                                                    </div>
                                                    <div class="col-md-7"><span class="modal-span" runat="server" id="lbl_FactFecha"></span></div>
                                                </div>
                                                

                                                <div class="col-md-3">
                                                    <div class="col-md-5">
                                                        <label for="nombre">Estado </label>
                                                    </div>
                                                    <div class="col-md-7"><span class="modal-span" runat="server" id="lbl_EstadoEquipo"></span></div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Año </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_AnhoEquipo"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">F. adquisición</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_FechaAdquisicion"></span></div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="upp_contrato" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary" id="pnl_Contrato" runat="server">
                                    <div class="panel-heading"><b style="color: aqua">Contrato:  </b><span class="modal-span" runat="server" id="lbl_idContrato"></span></p> </p></div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Rut Cliente </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_RutCliente"></span></div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Tarifa</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_ValorContrato"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">F. Contrato </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_FechaContrato"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">F. Registro</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_FechaRegistro"></span></div>
                                                </div>

                                            </div>

                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Nombre</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_NombreCliente"></span></div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Modalidad </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_TipoUnidad"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">N° de guía</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_Guia"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Creador</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_UsuarioRegistra"></span></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:SqlDataSource ID="sds_Documentos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_Parque_s_Documentos" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <div class="panel panel-primary">
                            <div class="panel-heading">Archivos</div>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:FileUpload ID="SubirArchivo" runat="Server" />
                                        <asp:Label ID="lbl_NomArchivoCargado1" runat="server"></asp:Label><br />
                                        <asp:Button runat="server" ID="btn_Subir" Text="Subir archivo" class="btn btn-primary" OnClick="UploadFile"></asp:Button>
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
                            <button type="button" id="btn_CerrarModal" class="btn btn-default" data-dismiss="modal">Cerrar</button>
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
            $('[id*=gdv_Novedades]').footable();
            $('[id*=gdv_Documentos]').footable();
            $('.chosen-select').chosen();
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
            $('.chosen-select').chosen();
        });


    </script>


</asp:Content>
