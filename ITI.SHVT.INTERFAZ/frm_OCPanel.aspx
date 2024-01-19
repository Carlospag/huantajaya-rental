<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_OCPanel.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_OCPanel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />

    <asp:SqlDataSource ID="sds_OCxProveedor" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_OCxProveedor" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Proveedor" Type="String"></asp:Parameter>
            <asp:Parameter Name="EstadoOC" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_OCxOC" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_OCxOC" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OC" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sds_OCProveedores" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_OCProveedores" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_Clientes" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_Clientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_EstadosOC" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_EstadosOC" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_BuscarProveedorDDL" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_BuscarProveedorDDL" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_SoloOC" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloOC" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OC" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_FactrurasXOC" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_FacturasXOC" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OC" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_FacturadoXOC" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_FacturadoXOC" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OC" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_SoloOCDetalle" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloOCDetalle" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OC" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">BUSCAR POR:</div>
            <div class="panel-body">
                <div class="panel-body">
                    <div class="row" id="datetimepicker">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="Label2">Buscar por N° OC&nbsp; </label>
                                <span runat="server" style="color: red" id="Span1"></span>
                                <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="4" ID="txt_BuscarXOT" AutoPostBack="true" runat="server" class="input form-control text-center" />
                            </div>
                        </div>
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="">
                                    <label>Filtrar por Proveedor:</label>
                                    <asp:DropDownList ID="ddl_NombreProveedor" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_BuscarProveedorDDL" DataValueField="id_Proveedor" DataTextField="NombreProveedor">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label runat="server" id="lbl_Anho">Filtrar por Estado:</label>
                                <asp:DropDownList ID="ddl_EstadosOT" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_EstadosOC" DataValueField="id_EstadoCO" DataTextField="NombreEstadoOC">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="panel panel-primary">
            <div class="panel-heading">ORDENES DE COMPRA PENDIENTES DE APROBACIÓN Y/O PROCESAMIENTO</div>
            <div class="panel-body">
                <%-- <p>A continuación se muestra el listado de casos disponibles en el sistema, usted aquí podra generar las cartas respectivas.</p>--%>
            </div>
            <section>
                <asp:UpdatePanel ID="upp_GrillaPermisos" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div runat="server" id="pnl_mensaje" visible="false" class="alert alert-link alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong runat="server" id="lbl_mensaje1"></strong><span runat="server" id="lbl_mensaje2"></span>
                        </div>
                        <asp:GridView runat="server" ID="gdv_OCPendientes" CssClass="table footable table-condensed" AutoGenerateColumns="false"
                            GridLines="none" AllowSorting="true">
                            <Columns>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="30px" HeaderStyle-BackColor="#cccccc"></asp:TemplateField>
                                <asp:BoundField DataField="id_OC" HeaderStyle-Width="30px" HeaderText="OC" HeaderStyle-BackColor="#cccccc" />
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="30px" HeaderStyle-BackColor="#cccccc"></asp:TemplateField>
                                <asp:BoundField DataField="NombreProveedor" HeaderText="PROVEEDOR" FooterStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="NombreMedioPago" HeaderText="MEDIO DE PAGO" HeaderStyle-Width="150PX" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="FechaOC" HeaderText="FECHA OC" HeaderStyle-Width="45px" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="Total" HeaderStyle-Width="100px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;T. NETO" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Right" />
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="20px" HeaderStyle-BackColor="#cccccc"></asp:TemplateField>
                                <asp:BoundField DataField="EstadoOC" HeaderText="ESTADO DE LA OC" HeaderStyle-Width="170px" HeaderStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" />
                                <asp:TemplateField HeaderText="DETALLE" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_DetallesOC" Style="width: 45px" runat="server" OnClick="btn_DetallesOC_Click"
                                            CommandArgument='<%#Eval("id_OC")%>' Text="E" CssClass="btn btn-outline-info btn-group-justified"> <span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="APROBAR" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_AprobarOC" Style="width: 45px" runat="server" OnClick="btn_AprobarOC_Click"
                                            CommandArgument='<%#Eval("id_OC")%>' Enabled='<%# If(Session("id_Usuario") = "1" Or Session("id_Usuario") = "3", True, False)%>' Text="E" Visible='<%# If(Eval("EstadoOC").ToString() = "Pendiente Aprobación", True, False)%>' CssClass="btn btn-success btn-group-justified"> <span class="glyphicon glyphicon-thumbs-up" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PROCESAR" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_ProcesarOC" Style="width: 45px" runat="server" OnClick="btn_ProcesarOC_Click"
                                            CommandArgument='<%#Eval("id_OC")%>' Visible='<%# If(Eval("EstadoOC").ToString() = "Pendiente Procesamiento", True, False)%>' Enabled='<%# If(Session("id_Usuario") = "1" Or Session("id_Usuario") = "3", True, False)%>' Text="A" CssClass="btn btn-warning btn-group-justified "><span class="glyphicon glyphicon-floppy-save" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ANULAR" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_EliminarOC" Style="width: 45px" runat="server" OnClick="btn_EliminarOC_Click"
                                            CommandArgument='<%#Eval("id_OC")%>' Visible='<%# If(Eval("EstadoOC").ToString() = "Anulada" Or Eval("EstadoOC").ToString() = "Procesada", False, True)%>' Text="A" CssClass="btn btn-danger btn-group-justified "><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_DescargarOC" Style="width: 45px" runat="server" OnClick="btn_DescargarOC_Click"
                                            CommandArgument='<%#Eval("id_OC")%>' Enabled='<%# If(Eval("EstadoOC").ToString() = "Pendiente Aprobación", False, True)%>' Text="A" CssClass="btn btn-primary btn-group-justified "><span class="glyphicon glyphicon-save" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </div>
        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_VerCaso" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 90% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_Modal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">ORDEN DE COMPRA #: <span class="modal-span" runat="server" id="lbl_NOC"></span></p></div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="col-md-2">
                                                        <label for="nombre">Proveedor </label>
                                                    </div>
                                                    <div class="col-md-10"><span style="font: 100" class="modal-span" runat="server" id="lbl_Proveedor"></span></div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-md-3">
                                                        <label for="nombre">U. Negocio</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_CN"></span></div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-md-3">
                                                        <label for="nombre">N° Factura</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_NF"></span></div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="col-md-2">
                                                        <label for="nombre">Rut</label>
                                                    </div>
                                                    <div class="col-md-10"><span class="modal-span" runat="server" id="lbl_Rut"></span></div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-md-3">
                                                        <label for="nombre">C. Costo</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_CC"></span></div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Fecha OC</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_FechaOC"></span></div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="col-md-2">
                                                        <label for="nombre">Contacto </label>
                                                    </div>
                                                    <div class="col-md-10"><span class="modal-span" runat="server" id="lbl_Contacto"></span></div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Tipo Pago</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_Pago"></span></div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Aprobado por </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_Aprobador"></span></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="panel panel-info">
                                                    <div class="panel-heading">DETALLE DE LA ORDEN DE COMPRA</div>
                                                    <div class="panel-body">
                                                        <div class="panel-body">
                                                            <div class="row">
                                                                <section>
                                                                    <asp:UpdatePanel runat="server" ID="upp_oc" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:GridView runat="server" ID="gdv_oc" CssClass="table footable table-hover table-condensed" AutoGenerateColumns="False"
                                                                                GridLines="Vertical" AllowSorting="True">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="NombreServicioProducto" HeaderStyle-Width="300px" Visible="true" ControlStyle-Font-Size="1" ControlStyle-ForeColor="#ffffff" HeaderStyle-HorizontalAlign="Left" HeaderText="SERVICIO / PRODUCTO" HeaderStyle-BackColor="#cccccc">
                                                                                        <ControlStyle Font-Bold="True" BackColor="White" ForeColor="#ffffff" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Cantidad" HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#cccccc" FooterStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CANTIDAD" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="ValorUnitario" HeaderStyle-Width="144px" ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#cccccc" FooterStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALOR UNITARIO" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Descuento" HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#cccccc" FooterStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DESCUENTO" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="TipoDescuento" HeaderStyle-Width="186px" ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#cccccc" FooterStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TIPO DESCUENTO" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="TotalFila" HeaderStyle-Width="5px" ItemStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#cccccc" FooterStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="center" ItemStyle-Font-Bold="true" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TOTAL" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle  Font-Bold="True" />
                                                                                    </asp:BoundField>
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

        <!-- Modal DetalleOC -->
        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_ProcesarOC" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 60% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_facturas" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">ORDEN DE COMPRA #: <span class="modal-span" runat="server" id="lbl_nocf"></span></p></div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label runat="server" id="Label1">N° Factura/Boleta&nbsp; </label>
                                                        <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                                                        <asp:TextBox Font-Size="X-Large" Font-Bold="true" ID="txt_NumeroFactura" runat="server" class="form-control text-center" />
                                                    </div>
                                                </div>
                                                <div class="col-md-3  input-daterange">
                                                    <div class="form-group">
                                                        <div class="form-group">
                                                            <label runat="server" id="Label3">Fecha Factura/Boleta </label>
                                                            <asp:TextBox Font-Size="X-Large" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" Font-Bold="true" MaxLength="6" ID="txt_FechaFacturacion" runat="server" class="form-control text-center" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <label runat="server" id="Label4">Total (A pagar)&nbsp; </label>
                                                        <span runat="server" style="color: red" id="Span4"></span>
                                                        <asp:TextBox Font-Size="X-Large" Font-Bold="true" AutoPostBack="true" MaxLength="9" Text="" ID="txt_ValorFactura" runat="server" class="form-control text-center" />
                                                    </div>
                                                </div>
                                                <div class="col-md-1">
                                                    <div class="form-group">
                                                        <label runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
                                                        <asp:LinkButton runat="server" ID="btn_Agregar" CssClass="btn bg-info" Text="Asociar Factura a OC" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="panel panel-info">
                                                    <div class="panel-heading">Facturas Asociadas a la OC: <span class="modal-span" runat="server" id="lbl_ocnf"></span></p></div>
                                                    <div class="panel-body">
                                                        <div class="panel-body">
                                                            <div class="row">
                                                                <section>
                                                                    <asp:UpdatePanel runat="server" ID="upp_facturas2" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:GridView runat="server" ID="gdv_FacturasXOC" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="False"
                                                                                GridLines="none" AllowSorting="True">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="NumeroFactura" HeaderStyle-Width="300px" Visible="true" ControlStyle-Font-Size="1" ControlStyle-ForeColor="#ffffff" HeaderText="N° FACTURA/BOLETA" HeaderStyle-BackColor="#cccccc">
                                                                                        <ControlStyle Font-Bold="True" BackColor="White" ForeColor="#ffffff" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="FechaFactura" HeaderStyle-BackColor="#cccccc" HeaderText="FECHA FACTURA/BOLETA" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="FechaPago" HeaderStyle-BackColor="#cccccc" HeaderText="FECHA PAGO" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="ValorFactura" HeaderStyle-BackColor="#cccccc" HeaderText="VALOR A PAGAR" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="EstadoFactura" HeaderStyle-BackColor="#cccccc" HeaderText="ESTADO" ControlStyle-Font-Bold="true">
                                                                                        <ControlStyle Font-Bold="True" />
                                                                                    </asp:BoundField>
                                                                                    <asp:CommandField ButtonType="Button" HeaderStyle-Width="10px" ShowDeleteButton="True"  DeleteText="X" HeaderStyle-BackColor="#cccccc">
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
                                                <div class="row">
                                                    <div class="col-md-9">
                                                        <div class="form-group">
                                                            <span class="modal-span" runat="server" id="lbl_TotalOC"></span>
                                                            <br />
                                                            <span class="modal-span" runat="server" id="lbl_TotalFacturado"></span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2 pull-right">
                                                        <div class="form-group  pull-right">
                                                            <asp:Button runat="server" ID="btn_GuardarCambios" CssClass="btn btn-primary" Text="Grabar Registro" />
                                                        </div>
                                                    </div>
                                                </div>



                                                <!-- Declarar el UpdatePanel para el panel -->
                                                <asp:UpdatePanel ID="upp_mensaje" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <!-- Contenido del panel -->
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div id="DivMensajeAdvertenciaGuardado">
                                                                    <asp:Panel ID="pnl_MensajeAdvertenciaGuardado" runat="server" Visible="true">
                                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                                        <asp:Label ID="lbl_MensajeAdvertenciaGuardado" runat="server" Font-Size="XX-Large" />
                                                                    </asp:Panel>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>




                                                <div>
                                                    <asp:Panel ID="panelMensaje" runat="server" CssClass="alert alert-success alert-dismissible fade show alert-top" Visible="False">
                                                        <button type="button" class="close" data-dismiss="alert">&times;</button>
                                                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                                                    </asp:Panel>
                                                </div>

                                                <script src="js/bootstrap.min.js"></script>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="modal-footer">

                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>

                            <asp:Button runat="server" ID="btn_ProcesarFactura" class="btn btn-primary" Text="Procesar OC" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .alert-top {
            position: fixed;
            top: -100px; /* Valor inicial fuera de la pantalla */
            left: 0;
            right: 0;
            margin: auto;
            width: 400px;
            transition: top 0.5s ease; /* Transición suave */
        }

            .alert-top.show {
                top: 50px; /* Valor final para mostrar el panel */
            }
    </style>
    <script type="text/javascript">



        var cargarFoo = function () {
            $('[id*=gdv_OCPendientes]').footable();
        };
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

            // JavaScript para mostrar el panel durante 3 segundos
            setTimeout(function () {
                var panel = document.getElementById('<%= pnl_MensajeAdvertenciaGuardado.ClientID %>');
                panel.style.display = 'none';
            <%= pnl_MensajeAdvertenciaGuardado.ClientID %>.update();
            }, 3000);



            $("#<%=pnl_MensajeAdvertenciaGuardado.ClientID%>").delay(3000).fadeTo(500, 0);
            $('.chosen-select').chosen();
            $(".input-daterange").datepicker({
                language: "es",
                format: "dd/mm/yyyy",
                autoclose: true,
                todayHighlight: true,
                orientation: "bottom"
            });
        });
    </script>

    <script>
        function ActualizaCombobox() {
            $('.chosen-select').chosen();
        }
    </script>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (s, e) {
            ActualizaCombobox();
        });
    </script>
</asp:Content>
