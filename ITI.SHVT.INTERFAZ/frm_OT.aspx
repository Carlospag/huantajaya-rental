<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_OT.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_OT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="sds_OT" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_OT" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_OTxOTGrilla" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_OTxOTGrilla" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OT" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_OTxAFIGrilla" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_OTxAFIGrilla" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_EstadosOT" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_EstadosOT" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_ObservacionxOT" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ObservacionesxOT" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OT" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_OTxID" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_OTxID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OT" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_OTxFiltros" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_OTxFiltros" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="EstadoOT" Type="Int32"></asp:Parameter>
            <asp:Parameter Name="FechaInicio" Type="String"></asp:Parameter>
            <asp:Parameter Name="FechaTermino" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_TrabajadoresXOT" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_TrabajadoresXOT" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OT" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_ActividadesXOT" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ActividadesXOT" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OT" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_TrabajadoresST" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_TrabajadoresST" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_ActividadesOT" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ActividadesOT" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_TiposOT" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_TiposOT" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">BUSCAR POR:</div>
            <div class="panel-body">
                <div class="panel-body">

                    <div class="row" id="datetimepicker">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="Label2">Buscar por N° OT&nbsp; </label>
                                <span runat="server" style="color: red" id="Span1"></span>
                                <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="4" ID="txt_BuscarXOT" runat="server" class="input form-control text-center" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="Label1">Buscar por AFI&nbsp; </label>
                                <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                                <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_BuscarAfi" runat="server" class="input form-control text-center" />
                            </div>
                        </div>
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="lbl_Anho">Filtrar por Estado:</label>
                                <asp:DropDownList ID="ddl_EstadosOT" runat="server" CssClass="form-control" DataSourceID="sds_EstadosOT" DataValueField="id_EstadoOT" DataTextField="NombreEstadoOT">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2 input-daterange">
                            <div class="form-group">
                                <label for="txt_Fecha">Desde:</label>
                                <asp:TextBox MaxLength="10" ID="txt_FechaInicio" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                            </div>
                        </div>
                        <div class="col-md-2 input-daterange">
                            <div class="form-group">
                                <label for="txt_Fecha">Hasta:</label>
                                <asp:TextBox MaxLength="10" ID="txt_FechaTermino" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="end" onkeydown="return false;" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="pull-left">
                                <asp:LinkButton ID="btn_BuscarPorOT" runat="server" Text="Buscar Por N° OT" CssClass="btn btn-info" />
                                <asp:LinkButton ID="btn_BuscarPorAfi" runat="server" Text="Buscar Por AFI" CssClass="btn btn-info" />
                            </div>
                            <div class="pull-right">
                                <%--<asp:LinkButton runat="server" ID="btn_Informe" CssClass="btn btn-default">  <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> </asp:LinkButton>--%>
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
        <div class="panel panel-primary" id="pnl_casos" runat="server">
            <div class="panel-heading">Ordenes de trabajo</div>
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
                        <!-- Listar opciones del sistema -->
                        <asp:GridView runat="server" ID="gdv_OT" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="id_OT" HeaderStyle-BackColor="#cccccc" HeaderText="OT" ControlStyle-Font-Bold="true" />
                                <asp:BoundField DataField="FechaOT" HeaderStyle-BackColor="#cccccc" ItemStyle-VerticalAlign="NotSet" HeaderText="Fecha" />
                                <asp:BoundField DataField="id_Equipo" HeaderStyle-BackColor="#cccccc" HeaderText="AFI" />
                                <asp:BoundField DataField="NombreEquipo" HeaderStyle-BackColor="#cccccc" ItemStyle-VerticalAlign="NotSet" HeaderText="Equipo" />
                                <asp:BoundField DataField="TipoOT" HeaderStyle-BackColor="#cccccc" HeaderText="Tipo OT" />
                                <asp:BoundField DataField="Responsable" HeaderStyle-BackColor="#cccccc" ItemStyle-VerticalAlign="NotSet" HeaderText="Responsable" />
                                <asp:BoundField DataField="EstadoOT" HeaderStyle-BackColor="#cccccc" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_Iniciar" runat="server" OnClick="btn_Iniciar_Click" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc"
                                            CommandArgument='<%#Eval("id_OT")%>' Visible='<%# If(Eval("EstadoOT").ToString() = "Programada" Or Eval("EstadoOT").ToString() = "Paralizada", True, False)%>' CssClass="btn btn-success btn-group-justified"> <span class="glyphicon glyphicon-play" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_PausarOT" Style="width: 45px" runat="server" OnClick="btn_PausarOT_Click"
                                            CommandArgument='<%#Eval("id_OT")%>' Visible='<%# If(Eval("EstadoOT").ToString() = "Programada" Or Eval("EstadoOT").ToString() = "Paralizada" Or Eval("EstadoOT").ToString() = "Finalizada", False, True)%>' Text="E" CssClass="btn btn-default btn-group-justified"> <span class="glyphicon glyphicon-pause" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_ModificarOT" Style="width: 45px" runat="server" OnClick="btn_ModificarOT_Click"
                                            CommandArgument='<%#Eval("id_OT")%>'  Visible='<%# If(Eval("EstadoOT").ToString() = "Finalizada" Or Session("id_TipoCargo") = "4", False, True)%>' Text="A" CssClass="btn btn-warning btn-group-justified"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_EliminarOT" Style="width: 45px" runat="server" OnClick="btn_EliminarOT_Click"
                                            CommandArgument='<%#Eval("id_OT")%>' Visible='<%# If(Eval("EstadoOT").ToString() = "Anulada" Or Eval("EstadoOT").ToString() = "Finalizada", False, True)%>' Text="A" CssClass="btn btn-info btn-group-justified "><span class="glyphicon glyphicon-edit" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_DescargarOT" Style="width: 45px" runat="server" OnClick="btn_DescargarOT_Click"
                                            CommandArgument='<%#Eval("id_OT")%>' Visible='<%# If(Eval("EstadoOT").ToString() = "Anulada", False, True)%>' Text="A" CssClass="btn btn-primary btn-group-justified "><span class="glyphicon glyphicon-save" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

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
    </div>


    <%--MODAL PAUSAR OT--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_IngresarObservacion" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document" style="width: 40% !important;">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:UpdatePanel ID="upp_modalPausa" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <img class="logo-iti-inicio" src="Content/img/capa1.png" alt="iti" height="60" /></a>
                                        </div>
                                        <div class="col-md-6">

                                            <center><h3><b  style="color: aqua">PARALIZACIÓN DE OT # <span class="modal-span" runat="server" id="lbl_OT"></span></b></h3></center>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    </p>
                                </div>
                                <div class="panel-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-12">
                                                <label runat="server" id="Label3">Añada los motivos de la paralización de la OT: &nbsp;</label>
                                                <textarea runat="server" class="form-control" rows="4" id="txt_ObservacionesParalizacionOT" htmlencode="false"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">

                    <asp:LinkButton runat="server" ID="btn_CerrarModal" CssClass="btn btn-default" Text="Cerrar" />

                    <asp:LinkButton ID="btn_GuardarCambiosPausa" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
    <%--MODAL INGRESO INFORMACIÓN ADICIONAL--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_IngresarObservacionAnulacion" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document" style="width: 40% !important;">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:UpdatePanel ID="upp_ModalAnulacion" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <img class="logo-iti-inicio" src="Content/img/capa1.png" alt="iti" height="60" /></a>
                                        </div>
                                        <div class="col-md-7">

                                            <center><h3><b  style="color: aqua">INGRESO DE INFORMACIÓN - OT # <span class="modal-span" runat="server" id="lbl_OTAnulacion"></span></b></h3></center>
                                        </div>
                                        <div class="col-md-2">
                                        </div>
                                    </div>
                                    </p>
                                </div>
                                <div class="panel-body">
                                    <div class="form-group">

                                        <div class="row">
                                            <div class="col-md-12">
                                                <label runat="server" id="Label4">Añada aquí información nueva para la OT: &nbsp;</label>
                                                <textarea runat="server" class="form-control" rows="4" id="txt_ObservacionesAnulacionOT" htmlencode="false"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">

                    <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-default" Text="Cerrar" />
                    <asp:LinkButton ID="btn_GuardarCambiosAnulacion" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary"/>
                </div>
            </div>
        </div>
    </div>

    <%--MODAL PARA EDITAR OT--%>
    <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_EditarOT" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document" style="width: 80% !important;">
            <div class="modal-content">
                <div class="modal-body">
                    <asp:UpdatePanel ID="upp_EditarOT" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <div class="panel panel-primary">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <img class="logo-iti-inicio" src="Content/img/capa1.png" alt="iti" height="60" /></a>
                                        </div>
                                        <div class="col-md-6">

                                            <center><h3><b  style="color: aqua">Actualizar OT # <span class="modal-span" runat="server" id="lbl_OTEditar"></span></b></h3></center>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    </p>
                                </div>
                                <div class="panel-body">
                                    <div class="form-group">
                                        <div class="row" id="datetimepicker2">
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label runat="server" id="Label6">N° OT&nbsp; </label>
                                                    <span runat="server" style="color: red" id="Span2"></span>
                                                    <asp:TextBox Font-Size="X-Large" Font-Bold="true" ID="txt_NumeroOT" ReadOnly="true" runat="server" class="input form-control text-center" required="true" />
                                                </div>
                                            </div>
                                            <div class="col-md-2 input-daterange">
                                                <div class="form-group">
                                                    <label for="txt_Fecha">Fecha:</label>
                                                    <asp:TextBox MaxLength="10" ID="txt_FechaOT" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label runat="server" id="Label7">AFI&nbsp; </label>
                                                    <span runat="server" style="color: red" id="lbl_Afi"></span>
                                                    <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" AutoPostBack="true" ID="txt_AFI" runat="server" class="input form-control text-center" required="required" />
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label runat="server" id="Label8">Tipo de OT:</label>
                                                    <asp:DropDownList ID="ddl_TiposOT" runat="server" CssClass="form-control" DataSourceID="sds_TiposOT" DataValueField="id_TipoOT" DataTextField="NombreTipoOT">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label runat="server" id="Label9">Responsable:</label>
                                                    <asp:DropDownList ID="ddl_Responsable" runat="server" CssClass="form-control" DataSourceID="sds_TrabajadoresST" DataValueField="id_Trabajador" DataTextField="NombreTrabajador">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <label runat="server" id="Label10">Supervisor:</label>
                                                    <asp:DropDownList ID="ddl_Supervisor" runat="server" CssClass="form-control" DataSourceID="sds_TrabajadoresST" DataValueField="id_Trabajador" DataTextField="NombreTrabajador">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="panel panel-info">
                                                    <div class="panel-heading">Actividades Asociadas a la OT</div>
                                                    <div class="panel-body">
                                                        <div class="panel-body">
                                                            <div class="row">
                                                                <section>
                                                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div runat="server" id="Div1" visible="false" class="alert alert-link alert-dismissible" role="alert">
                                                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                                                    <span aria-hidden="true">&times;</span>
                                                                                </button>
                                                                                <strong runat="server" id="Strong1"></strong><span runat="server" id="Span4"></span>
                                                                            </div>
                                                                            <div class="row">
                                                                                <div class="col-md-8">
                                                                                    <div class="form-group">
                                                                                        <label runat="server" id="Label11">Actividades:</label>
                                                                                        <asp:DropDownList ID="ddl_ActividadesOT" runat="server" CssClass="form-control" DataSourceID="sds_ActividadesOT" DataValueField="id_ActividadOT" DataTextField="NombreActividadOT">
                                                                                        </asp:DropDownList>

                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <div class="form-group">
                                                                                        <br />
                                                                                        <asp:LinkButton runat="server" ID="btn_AgregarActividad" CssClass="btn bg-info" Text="Agregar" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <br />
                                                                            <asp:GridView runat="server" ID="gdv_ActividadesOT" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="False"
                                                                                GridLines="None" AllowSorting="True">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="id_Actividad" Visible="true" ControlStyle-Font-Size="1" ControlStyle-ForeColor="#ffffff" FooterStyle-ForeColor="White" ItemStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                                        <ControlStyle Font-Bold="True" BackColor="White" ForeColor="#ffffff" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="NombreActividadOT" ItemStyle-HorizontalAlign="left" FooterStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Nombre Actividad" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="X">

                                                                                        <ControlStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" />
                                                                                    </asp:CommandField>

                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </section>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="panel panel-success">
                                                    <div class="panel-heading">Trabajadores Asociados a la OT</div>
                                                    <div class="panel-body">
                                                        <div class="panel-body">
                                                            <div class="row">
                                                                <section>
                                                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <div runat="server" id="Div2" visible="false" class="alert alert-link alert-dismissible" role="alert">
                                                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                                                    <span aria-hidden="true">&times;</span>
                                                                                </button>
                                                                                <strong runat="server" id="Strong2"></strong><span runat="server" id="Span3"></span>
                                                                            </div>

                                                                            <div class="row">
                                                                                <div class="col-md-4">
                                                                                    <div class="form-group">
                                                                                        <label runat="server" id="Label12">Nombre Trabajador:</label>
                                                                                        <asp:DropDownList ID="ddl_TrabajadorDeOT" runat="server" CssClass="form-control" DataSourceID="sds_TrabajadoresST" DataValueField="id_Trabajador" DataTextField="NombreTrabajador">
                                                                                        </asp:DropDownList>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-4">
                                                                                    <div class="form-group">
                                                                                        <label runat="server" id="Label13">Tiempo&nbsp; </label>
                                                                                        <span runat="server" style="color: red" id="Span5"></span>
                                                                                        <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="4" ID="txt_Tiempo" runat="server" class="input form-control text-center" />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <div class="form-group">
                                                                                        <br />
                                                                                        <asp:LinkButton runat="server" ID="btn_AgregarTrabajador" CssClass="btn bg-success" Text="Agregar" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <br />
                                                                            <asp:GridView runat="server" ID="gdv_TrabajadoresOT" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="False"
                                                                                GridLines="None" AllowSorting="True">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="id_Trabajador" Visible="true" ControlStyle-Font-Size="1" ControlStyle-ForeColor="#ffffff" FooterStyle-ForeColor="White" ItemStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                                        <ControlStyle Font-Bold="True" BackColor="White" ForeColor="#ffffff" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="NombreTrabajador" HeaderText="Trabajador" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="NombreTipoCargo" HeaderText="Cargo" />
                                                                                    <asp:BoundField DataField="HorasTrabajadorOT" ItemStyle-VerticalAlign="NotSet" HeaderText="Tiempo (hr)" />
                                                                                    <asp:BoundField DataField="CostoHH" HeaderText="Costo HH" />
                                                                                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="X">
                                                                                        <ControlStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" />
                                                                                    </asp:CommandField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </section>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="row">
                                            
                                                    <div class="col-md-12">
                                                        <label runat="server" id="Label5">Información Asociada a la OT: &nbsp;</label>
                                                        <textarea runat="server" class="form-control" rows="8" id="txt_ObservacionesEditar" htmlencode="false" readonly="readonly"></textarea>
                                                    </div>
                                                



                                        <%--<div class="col-md-6">
                                            <div class="panel panel-info">
                                                <div class="panel-heading">Gasto adicionales:</div>
                                                <div class="panel-body">
                                                    <div class="panel-body">
                                                        <div class="row">
                                                            <section>
                                                                <asp:UpdatePanel runat="server" ID="UpdatePanel3" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                       
                                                                        <div class="row">
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <label runat="server" id="Label16">Nombre Gasto&nbsp; </label>
                                                                                    <span runat="server" style="color: red" id="Span9"></span>
                                                                                    <asp:TextBox Font-Size="Large" Font-Bold="true" ID="txt_Gasto" runat="server" class="input form-control text-center" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-3">
                                                                                <div class="form-group">
                                                                                    <label runat="server" id="Label17">Valor Gasto&nbsp; </label>
                                                                                    <span runat="server" style="color: red" id="Span10"></span>
                                                                                    <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="7" ID="txt_ValorGasto" runat="server" class="input form-control text-center" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-1">
                                                                            </div>
                                                                            <div class="col-md-2">
                                                                                <div class="form-group">
                                                                                    <br />
                                                                                    <asp:LinkButton runat="server" ID="btn_AgregarGasto" CssClass="btn bg-info" Text="Agregar" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <br />
                                                                        <asp:GridView runat="server" ID="gdv_Gastos" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="False"
                                                                            GridLines="None" AllowSorting="True">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="id_RepuestosXOT" Visible="true" ControlStyle-Font-Size="1" ControlStyle-ForeColor="#ffffff" FooterStyle-ForeColor="White" ItemStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                                    <ControlStyle Font-Bold="True" BackColor="White" ForeColor="#ffffff" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="NombreRepuesto" ItemStyle-HorizontalAlign="left" FooterStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Nombre Repuesto" ControlStyle-Font-Bold="true">
                                                                                    <ControlStyle Font-Bold="True" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="ValorRepuesto" ItemStyle-HorizontalAlign="left" FooterStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Valor Repuesto" ControlStyle-Font-Bold="true">
                                                                                    <ControlStyle Font-Bold="True" />
                                                                                </asp:BoundField>
                                                                                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="X">

                                                                                    <ControlStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" />
                                                                                </asp:CommandField>

                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </section>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label runat="server" id="Label14">Costos Repuesto&nbsp; </label>
                                                <span runat="server" style="color: red" id="Span6"></span>
                                                <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="7" ID="txt_CostoRepuesto" runat="server" class="input form-control text-center" required="true" />
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label runat="server" id="Label15">Cambiar Estado&nbsp; </label>
                                                <span runat="server" style="color: red" id="Span7"></span>
                                                <asp:DropDownList ID="ddl_CambiarEstadoOT" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="1">Programada</asp:ListItem>
                                                    <asp:ListItem Value="2">Iniciada</asp:ListItem>
                                                    <asp:ListItem Value="3">Paralizada</asp:ListItem>
                                                    <asp:ListItem Value="4">Finalizada</asp:ListItem>
                                                    <asp:ListItem Value="5">Anulada</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>



                                </div>
                            </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">

                    <asp:LinkButton runat="server" ID="LinkButton2" CssClass="btn btn-default" Text="Cerrar" />
                    <asp:LinkButton ID="btn_GuardarCambiosEditar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>




    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">

    <script type="text/javascript">
        $(function () {
            $('[id*=gdv_Novedades]').footable();
            $('[id*=gdv_OT]').footable();
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
