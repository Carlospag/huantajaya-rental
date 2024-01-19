<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_AdministrarContrato.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_AdministrarContrato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:SqlDataSource ID="sds_SoloContrato" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloContrato" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Contrato" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sds_ContratoXAfi" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ContratoXAfi" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sds_ContratoXNumeroContrato" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ContratoXNumeroContrato" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Contrato" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sds_FacturacionProyectada" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_FacturacionProyectada" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_MontoFlota" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_MontoFlotaParque" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Sucursal" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_FlotaCliente" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_MontoFlotaParqueXcliente" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Cliente" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    <div class="container-sm">
        <div class="panel panel-primary">
            <div class="panel-heading">BUSCAR POR:</div>
            <div class="panel-body">
                <div class="panel-body">

                    <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                    <%--<section class="cuerpo-informe">--%>
                    <div class="row" id="datetimepicker">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="Label2">Buscar por N° Contrato&nbsp; </label>
                                <span runat="server" style="color: red" id="Span1"></span>
                                <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="4" ID="txt_BuscarContrato" runat="server" class="input form-control text-center" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="Label1">Buscar por AFI&nbsp; </label>
                                <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                                <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_BuscarAfi" runat="server" class="input form-control text-center" />
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <div class="">
                                    <label runat="server" id="lbl_CLienteBuscar">Filtrar por Cliente:</label>
                                    <asp:SqlDataSource ID="sds_ListadoClientes" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ListaClientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                    <asp:DropDownList ID="ddl_Clientes" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_ListadoClientes" DataValueField="RutCliente" DataTextField="NombreCliente">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="lbl_Anho">Filtrar por Estado:</label>
                                <asp:DropDownList ID="ddl_Estado" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1">Activos</asp:ListItem>
                                    <asp:ListItem Value="2">Terminados</asp:ListItem>
                                    <asp:ListItem Value="3">Anulados</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--<div class="col-md-2 input-daterange">
                            <div class="form-group">
                                <label for="txt_Fecha">Fecha Inicio:</label>
                                <asp:TextBox MaxLength="10" ID="txt_FechaInicio" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                            </div>
                        </div>
                        <div class="col-md-2 input-daterange">
                            <div class="form-group">
                                <label for="txt_Fecha">Fecha Fin:</label>
                                <asp:TextBox MaxLength="10" ID="txt_FechaTermino" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="end" onkeydown="return false;" />
                            </div>
                        </div>--%>
                        <div class="col-md-2" id="pnl_Sucursal" runat="server">
                            <div class="form-group">
                                <label runat="server" id="Label4">Filtrar por Sucursal:&nbsp; </label>
                                <asp:SqlDataSource ID="sds_Sucursales" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                <asp:DropDownList ID="ddl_Sucursal" runat="server" CssClass="form-control" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="pull-left">
                                <asp:Button ID="btn_BuscarPorContrato" runat="server" Text="Buscar Por N° Contrato" CssClass="btn btn-info" />
                                <asp:Button ID="btn_BuscarPorAfi" runat="server" Text="Buscar Por AFI" CssClass="btn btn-info" /><asp:Label runat="server" Visible="false" ID="lbl_Proyeccion"></asp:Label><asp:Label runat="server" Visible="false" ID="lbl_Factor"></asp:Label><asp:Label runat="server" Visible="false" ID="lbl_FlotaCliente"></asp:Label><asp:Label runat="server" Visible="false" ID="lbl_PorcentajeArriendo"></asp:Label><asp:Label runat="server" Visible="false" ID="lbl_ContratosActivos"></asp:Label>
                            </div>
                            <div class="pull-right">
                                <asp:LinkButton runat="server" ID="btn_Informe" CssClass="btn btn-default"> Informe  <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />
                                <asp:LinkButton runat="server" ID="btn_filtrar" CssClass="btn btn-primary" Text="Filtrar" />
                            </div>
                        </div>
                    </div>
                </div>
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
            <div class="panel-heading">CONTRATOS</div>
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
                        <asp:SqlDataSource ID="sds_contratos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_ContratosFiltrados" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
                                <asp:Parameter Name="EstadoContrato" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="Sucursal" Type="int32"></asp:Parameter>
                                <%--<asp:Parameter Name="FechaInicioContrato" Type="String"></asp:Parameter>
                                <asp:Parameter Name="FechaTerminoContrato" Type="String"></asp:Parameter>--%>
                            </SelectParameters>
                        </asp:SqlDataSource>


                        <asp:SqlDataSource ID="sds_TodosLosContratos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_TodosLosContratos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                        <!-- Listar opciones del sistema -->
                        <asp:GridView runat="server" ID="gdv_Contratos" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="id_Contrato" HeaderText="Contrato" ControlStyle-Font-Bold="true" />
                                <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                                <asp:BoundField DataField="FechaContrato" ItemStyle-VerticalAlign="NotSet" HeaderText="Fecha Inicio" />
                                <asp:BoundField DataField="FechaEntrega" ItemStyle-VerticalAlign="NotSet" HeaderText="Fecha Fin" />
                                <asp:BoundField DataField="id_Equipo" ItemStyle-VerticalAlign="NotSet" HeaderText="AFI" />
                                <asp:BoundField DataField="NombreEquipo" HeaderText="Equipo" />
                                <asp:BoundField DataField="Faena" HeaderText="Faena" />
                                <asp:BoundField DataField="EstadoContrato" HeaderText="Estado" />
                                <asp:BoundField DataField="Tipologia" HeaderText="" Visible="FALSE" />
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_VerCaso" runat="server" OnClick="btn_VerCaso_Click"
                                            CommandArgument='<%#Eval("id_Contrato")%>' Text="Detalles" CssClass="btn btn-success btn-group-justified" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" >
                                    <ItemTemplate>
                                        <asp:Button ID="btn_EstadosPago" runat="server" OnClick="btn_EstadosPago_Click"
                                            CommandArgument='<%#Eval("id_Contrato")%>' Visible='<%# If(Session("DatosComerciales") = "1", True, False)%>' Text="Estados de pago" CssClass='<%#IIf(Eval("Tipologia") = "Realizar", "btn btn-danger btn-group-justified", "btn btn-primary btn-group-justified")%>' />
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
                    <%-- <asp:LinkButton runat="server" ID="btn_Informe" CssClass="btn btn-default">  <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> </asp:LinkButton>--%>
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

        <script>
            $("#<%=pnl_MensajeAdvertenciaGuardado.ClientID%>").delay(3000).fadeTo(500, 0);
        </script>




        <!-- Modal Detalle Contrato -->
        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_VerCaso" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 90% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_Modal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">Información del contrato número: <span class="modal-span" runat="server" id="lbl_idContrato"></span></p></div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Rut Cliente </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_RutCliente"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">AFI</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_Afi"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Tarifa</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_ValorContrato"></span></div>
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
                                                    <div class="col-md-4">
                                                        <label for="nombre">Nombre</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_NombreCliente"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Equipo</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_NombreEquipo"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Modalidad </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_TipoUnidad"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Usuario</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_UsuarioRegistra"></span></div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Zona</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_NombreZona"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Modelo </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_Modelo"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">F. Contrato </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_FechaContrato"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Hor. Salida </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_HorometroSalida"></span></div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Faena</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_Faena"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">N° de guía</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_Guia"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">F. Entrega</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_FechaDevolucion"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Cotización </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_idCotizacion"></span></div>
                                                </div>


                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Factor A.</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="Factor"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Facturado ($) </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="Facturado"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Pagado ($) </label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="Pagado"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Estado </label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <div class="form-group">
                                                            <%-- <label runat="server" id="Label2">Cambiar Estado:</label>--%>
                                                            <asp:DropDownList ID="ddl_CambiarEstado" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="1">Activo</asp:ListItem>
                                                                <asp:ListItem Value="2">Terminado</asp:ListItem>
                                                                <asp:ListItem Value="3">Anulado</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <asp:SqlDataSource ID="sds_Documentos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_DocumentosContratos" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_Contrato" Type="Int32"></asp:Parameter>
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
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            <asp:Button runat="server" ID="btn_GenerarActaEntrega" class="btn btn-info" Text="Descargar Acta entrega" />
                            <asp:Button runat="server" ID="btn_GuardarModal" class="btn btn-primary" Text="Guardar Cambios" />

                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- Modal Estados de Pago -->
        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_VerEstadosPago" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 90% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_modalEstadoPago" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <b style="color: aqua">ESTADO PAGO:</b>  <span class="modal-span" runat="server" id="lbl_NumeroEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                               <b style="color: aqua">CONTRATO:</b> <span class="modal-span" runat="server" id="lbl_idContratoEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                               <b style="color: aqua">EQUIPO:</b> <span class="modal-span" runat="server" id="lbl_NombreEquipoEP"></span>
                                        <span class="modal-span" runat="server" id="lbl_ModeloEquipoEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      
                                                               <b style="color: aqua">AFI :</b> <span class="modal-span" runat="server" id="lbl_AfiEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                               <b style="color: aqua">FAENA:</b> <span class="modal-span" runat="server" id="lbl_FaenaEP"></span></p>
                                    </div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label for="nombre">Fecha Inicio </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label for="nombre">Fecha Término </label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Tarifa </label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Horas Fact. </label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Días fact.</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label for="nombre">Modalidad</label>
                                                </div>
                                                <%-- <div class="col-md-1">
                                                        
                                                    </div>--%>
                                                <div class="col-md-1">
                                                    <label for="nombre">Valor Neto </label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Iva </label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Valor Total</label>
                                                </div>
                                            </div>

                                            <div class="row ">
                                                <div class="col-md-2 input-daterange">

                                                    <asp:TextBox ID="txt_Fecha_InicioEP" onkeydown="return false;" runat="server" Placeholder="dd/mm/yyyy" class="input form-control" />
                                                </div>
                                                <div class="col-md-2 input-daterange">
                                                    <asp:TextBox ID="txt_Fecha_FinEP" onkeydown="return false;" runat="server" Placeholder="dd/mm/yyyy" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_TarifaEP" AutoPostBack="TRUE" Font-Bold="true" runat="server" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_HorasFacturarEP" runat="server" AutoPostBack="true" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">

                                                    <div class="col-md-4">
                                                        <asp:LinkButton ID="btn_CalcularDias" Style="width: 40px" runat="server"
                                                            Class="btn btn-success"> <span class="glyphicon glyphicon-calendar" aria-hidden="true"></span> </asp:LinkButton>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txt_DiasFacturarEP" Font-Bold="true" runat="server" AutoPostBack="true" class="input form-control" />
                                                    </div>

                                                </div>
                                                <div class="col-md-2">
                                                    <asp:DropDownList ID="ddl_ModoCobroEP" runat="server" CssClass="form-control" AutoPostBack="true">
                                                        <asp:ListItem Value="1">Mensual</asp:ListItem>
                                                        <asp:ListItem Value="2">Diario</asp:ListItem>
                                                        <asp:ListItem Value="3">Proporcional</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <%--<div class="col-md-1">
                                                        
                                                    </div>--%>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_ValorNetoEP" AutoPostBack="true" ReadOnly="true" Font-Bold="TRUE" runat="server" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_ivaEP" ReadOnly="TRUE" runat="server" Font-Bold="TRUE" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_ValorTotalEP" Rows="3" runat="server" ReadOnly="true" Font-Bold="TRUE" class="input form-control" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10">
                                                <label runat="server" id="lbl_Descripcion">Observaciones adicionales&nbsp;</label>
                                                <textarea runat="server" class="form-control" rows="2" id="txt_Observaciones" htmlencode="false"></textarea>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="pull-right">
                                                    <br />
                                                    <br />
                                                    <asp:LinkButton runat="server" ID="btn_LimpiarEP" CssClass="btn btn-default" Text="Limpiar" />
                                                    <asp:Button runat="server" ID="btn_ModificarEstadoPago" CssClass="btn btn-warning" Text="Editar EP" Visible="false" />
                                                    <%--<asp:Button ID="btn_GuardarEP" runat="server" Text="Guardar EP" CssClass="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" />--%>
                                                    <asp:LinkButton runat="server" ID="btn_GuardarEP" CssClass="btn btn-primary" Text="Guardar EP" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="upp_ListaEstadosPago" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">Estados de pago</div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <asp:SqlDataSource ID="sds_EstadosPago" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                                                SelectCommand="up_parque_s_EstadosPagoXcontrato" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="id_Contrato" Type="Int64"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>

                                            <asp:SqlDataSource ID="sds_EstadosPagoXidEP" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                                                SelectCommand="up_parque_s_EstadosPagoXidEP" SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:Parameter Name="id_EstadoPago" Type="Int64"></asp:Parameter>
                                                </SelectParameters>
                                            </asp:SqlDataSource>



                                            <!-- Listar opciones del sistema -->
                                            <asp:GridView runat="server" ID="gdv_EstadosPago" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                                                GridLines="None" AllowSorting="true">
                                                <Columns>
                                                    <asp:BoundField DataField="id_EstadoDePago" HeaderText="N°" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="FechaInicio" HeaderText="F. Inicio" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="FechaFin" ItemStyle-VerticalAlign="NotSet" HeaderText="F. Fin" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="Tarifa" ItemStyle-VerticalAlign="NotSet" HeaderText="Tarifa" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="HorasFacturar" ItemStyle-VerticalAlign="NotSet" HeaderText="Horas Fact." HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="DiasFacturar" ItemStyle-VerticalAlign="NotSet" HeaderText="Dias Fact." HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="TipoPago" HeaderText="Tipo Pago" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="ValorNeto" ItemStyle-Font-Bold="true" HeaderText="Total Neto" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="IVA" ItemStyle-Font-Bold="true" HeaderText="iva" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="Total" ItemStyle-Font-Bold="true" HeaderText="Total" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:BoundField DataField="EstadoComercial" HeaderText="Estado Comercial" HeaderStyle-BackColor="#cccccc" />
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btn_ConfirmarEP" Style="width: 45px" runat="server" OnClick="btn_ConfirmarEP_Click"
                                                                CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Eval("EstadoComercial").ToString() = "Pendiente", True, False)%>' Text="E" CssClass="btn btn-success btn-group-justified"> <span class="glyphicon glyphicon-ok" aria-hidden="true"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btn_ModificarEP" Style="width: 45px" runat="server" OnClick="btn_ModificarEP_Click"
                                                                CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Eval("EstadoComercial").ToString() = "Pendiente", True, False)%>' Text="A" CssClass="btn btn-warning btn-group-justified"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btn_EliminarEP" Style="width: 45px" runat="server" OnClick="btn_EliminarEP_Click"
                                                                CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Eval("EstadoComercial").ToString() = "Pendiente", True, False)%>' Text="A" CssClass="btn btn-danger btn-group-justified "><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btn_DescargarEP" Style="width: 45px" runat="server" OnClick="btn_DescargarEP_Click"
                                                                CommandArgument='<%#Eval("id_EstadoDePago")%>' Text="A" CssClass="btn btn-primary btn-group-justified "><span class="glyphicon glyphicon-save" aria-hidden="true"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-footer">
                        <asp:Button ID="btn_FinalizarContrato" runat="server" Text="Finalizar Contrato" CssClass="btn btn-danger" data-toggle="modal" data-target="#exampleModalCenter" />
                        <asp:LinkButton runat="server" ID="btn_CerrarModal" CssClass="btn btn-default" Text="Cerrar" />
                    </div>
                </div>
            </div>
        </div>
    </div>

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
            $('.chosen-select').chosen();
            //$(function () {
            //    $('.chosen-select').chosen();
            //    $('.chosen-select-deselect').chosen({ allow_single_deselect: true });
            //});
        });
    </script>


    <script>

</script>
</asp:Content>
