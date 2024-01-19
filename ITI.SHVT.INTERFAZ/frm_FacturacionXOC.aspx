<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_FacturacionXOC.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_FacturacionXOC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    <asp:SqlDataSource ID="sds_FacturacionXOC" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_FacturacionPendienteOC" SelectCommandType="StoredProcedure">

        <SelectParameters>
            <asp:Parameter Name="id_Proveedor" Type="String"></asp:Parameter>
            <asp:Parameter Name="EstadoFactura" Type="Int64"></asp:Parameter>
        </SelectParameters>

    </asp:SqlDataSource>

     <asp:SqlDataSource ID="sds_InformeDeuda" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_InformeGastos" SelectCommandType="StoredProcedure">

        <SelectParameters>
            <asp:Parameter Name="id_Proveedor" Type="String"></asp:Parameter>
            <asp:Parameter Name="EstadoFactura" Type="Int64"></asp:Parameter>
            <asp:Parameter Name="id_CCGeneral" Type="Int64"></asp:Parameter>
            <asp:Parameter Name="id_CCHijo" Type="Int64"></asp:Parameter>
            <asp:Parameter Name="Mes" Type="Int64"></asp:Parameter>
            <asp:Parameter Name="Anho" Type="Int64"></asp:Parameter>
        </SelectParameters>

    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_TotalDeuda" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_FacturacionPendienteOCTOTAL" SelectCommandType="StoredProcedure">

        <SelectParameters>
            <asp:Parameter Name="id_Proveedor" Type="String"></asp:Parameter>
            <asp:Parameter Name="EstadoFactura" Type="Int64"></asp:Parameter>
        </SelectParameters>

    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_FacturasXNF" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_FacturacionPendienteOCXNF" SelectCommandType="StoredProcedure">

        <SelectParameters>
            <asp:Parameter Name="NumeroFactura" Type="Int64"></asp:Parameter>
        </SelectParameters>

    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_CCHijos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_CCHijos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_CentroCostoPadre" Type="Int16"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="sds_BuscarProveedorDDL" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_BuscarProveedorDDL" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">BUSCAR POR:</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label runat="server" id="Label2">Buscar por N° Factura&nbsp; </label>
                                <span runat="server" style="color: red" id="Span1"></span>
                                <asp:TextBox Font-Size="X-Large" Font-Bold="true" ID="txt_BuscarXFactura" AutoPostBack="true" runat="server" class="input form-control text-center" />
                            </div>
                        </div>
                    </div><br />
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="">
                                    <label>Filtrar por Proveedor:</label>
                                    <asp:DropDownList ID="ddl_NombreProveedor" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_BuscarProveedorDDL" DataValueField="id_Proveedor" DataTextField="NombreProveedor">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <div class="">
                                    <label runat="server" id="Label3">CC General:</label>
                                    <label style="color: red">*</label>
                                    <asp:SqlDataSource ID="sds_CCPadres" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_CCPadres" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                    <asp:DropDownList ID="ddl_CCPadre" required="true" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_CCPadres" DataValueField="id_CentroCostoPadre" DataTextField="NombreCentroCostoPadre">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <div class="">
                                    <label runat="server" id="Label4">CC Especifico:</label>
                                    <label style="color: red">*</label>
                                    <asp:DropDownList ID="ddl_CCHijo" required="true" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_CCHijos" DataValueField="id_CentroCostoHijo" DataTextField="NombreCentroCostoHijo" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="lbl_Anho">Estado:</label>
                                <asp:DropDownList ID="ddl_EstadosFactura" runat="server" AutoPostBack="true" CssClass="form-control chosen-select">
                                    <asp:ListItem Value="1">IMPAGAS</asp:ListItem>
                                    <asp:ListItem Value="2">PAGADAS</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2" runat="server">
                            <div class="form-group">
                                <label runat="server" id="Label5">Mes:</label>
                                <asp:DropDownList ID="ddl_periodo" runat="server" AutoPostBack="true" CssClass="form-control chosen-select">
                                    <asp:ListItem Value="01">Enero</asp:ListItem>
                                    <asp:ListItem Value="02">Febrero</asp:ListItem>
                                    <asp:ListItem Value="03">Marzo</asp:ListItem>
                                    <asp:ListItem Value="04">Abril</asp:ListItem>
                                    <asp:ListItem Value="05">Mayo</asp:ListItem>
                                    <asp:ListItem Value="06">Junio</asp:ListItem>
                                    <asp:ListItem Value="07">Julio</asp:ListItem>
                                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                                    <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-1" runat="server">
                            <div class="form-group">
                                <label runat="server" id="Label6">Año:</label>
                                <asp:DropDownList ID="DDL_ANHO" runat="server" AutoPostBack="true" CssClass="form-control chosen-select">
                                    <asp:ListItem Value="2021">2021</asp:ListItem>
                                    <asp:ListItem Value="2022">2022</asp:ListItem>
                                    <asp:ListItem Value="2023">2023</asp:ListItem>
                                    <asp:ListItem Value="2024">2024</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <br />
                            <asp:Label runat="server" Visible="false" ID="lbl_Proyeccion"></asp:Label>
                        </div>
                        <div class="col-md-6"></div>
                         <div class="col-md-1">
                             <asp:LinkButton runat="server" ID="btn_LimpiarFiltros" CssClass="btn btn-default"> Limpiar   <span class="glyphicon glyphicon-trash" aria-hidden="true"></span> </asp:LinkButton>
                         </div>
                        <div class="col-md-1" runat="server">   
                            <asp:LinkButton runat="server" ID="btn_InformeGasto" CssClass="btn btn-default"> Inf. Gastos  <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> </asp:LinkButton>
                        </div>
                        <div class="col-md-1" runat="server">  
                            <asp:LinkButton runat="server" ID="btn_Informe" CssClass="btn btn-default"> Inf. Deuda  <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> </asp:LinkButton>
                        </div>
                    </div>
                </div>
            

        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">Facturación asociada a Ordenes de compra emitidas.</div>
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
                        <asp:GridView runat="server" ID="gdv_FacturacionXOC" CssClass="table footable table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="none" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="NumeroFactura" HeaderText="Factura" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="id_OC" HeaderText="OC" FooterStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="RutProveedor" HeaderText="Rut" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="NombreProveedor" HeaderText="Proveedor" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="NombreCentroCostoPadre" HeaderText="U. Negocio" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="NombreCentroCostoHijo" HeaderText="C. Costo" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="FechaFactura" HeaderText="Fecha Factura" HeaderStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="FechaVencimiento" HeaderText="Fecha Vencimiento" HeaderStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField DataField="DiasFactura" HeaderText="Dias Transcurridos." HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="FechaPago" HeaderText="Fecha Pago" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="ValorFactura" HeaderText="Total" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="EstadoFactura" HeaderText="Estado" HeaderStyle-BackColor="#cccccc" />
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="150px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_PagarFactura" runat="server" OnClick="btn_PagarFactura_Click"
                                            CommandArgument='<%#Eval("NumeroFactura")%>' Enabled='<%# If(Eval("EstadoFactura").ToString() = "IMPAGA", True, False)%>' CssClass='<%#IIf(Eval("EstadoFactura") = "IMPAGA", "btn btn-danger btn-group-justified", "btn btn-success btn-group-justified")%>' Text='<%#IIf(Eval("EstadoFactura") = "PAGADA", "PAGADA", "PAGAR")%>' /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:TemplateField HeaderText="DETALLE" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
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
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </div>

        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_PagoYFecha" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 18% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_nfactura" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <b style="color: aqua">Factura:</b>  <span class="modal-span" runat="server" id="lbl_NFact"></span></p>
                                    </div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="nombre">Fecha Pago </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12 input-daterange">
                                                    <asp:TextBox MaxLength="10" ID="txt_FechaPago" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="pull-right">
                                                    <asp:LinkButton runat="server" ID="btn_GuardarFechaPago" CssClass="btn btn-primary" Text="Pagar" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <b style="color: green"><span class="modal-span" runat="server" id="lbl_NumeroFacturaEXITO" visible="FALSE"></span></b>
                                        <b style="color: darkred"><span class="modal-span" runat="server" id="lbl_NumeroFacturaERROR" visible="FALSE"></span></b>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

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
        });
    </script>
</asp:Content>
