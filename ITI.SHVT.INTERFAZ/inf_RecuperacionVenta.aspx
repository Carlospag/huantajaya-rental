<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="inf_RecuperacionVenta.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.inf_RecuperacionVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />

    <asp:SqlDataSource ID="sds_8020" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_infRecuperacionVentaTodos8020" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
            <asp:Parameter Name="Sucursal" Type="int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_8020SinEleccon" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_infRecuperacionVentaTodos8020SinEleccon" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
            <asp:Parameter Name="Sucursal" Type="int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_306090" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_infRecuperacionVentaTodos306090" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
            <asp:Parameter Name="Sucursal" Type="int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">FILTRAR POR:</div>
            <div class="panel-body">
                <div class="row">
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
                            <label runat="server" id="Label4">Sucursal:&nbsp; </label>
                            <asp:SqlDataSource ID="sds_Sucursales" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                            <asp:DropDownList ID="ddl_Sucursal" runat="server" CssClass="form-control" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal" required="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="pull-left">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                            <asp:LinkButton runat="server" ID="btn_GenerarInforme" CssClass="btn btn-primary" Text="Generar Informe" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">DISTRIBUCIÓN DE LA DEUDA POR DÍAS PENDIENTES:</div>
                    <div class="panel-body">
                        <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                        <%--<section class="cuerpo-informe">--%>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" Visible="true" ID="lbl_30"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:TextBox Font-Size="Medium" BackColor="#33cc33" Style="text-align: right" Font-Bold="true" ID="txt_valor30" runat="server" class="input form-control text-center" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <asp:TextBox Font-Size="Smaller" BackColor="#33cc33" Style="text-align: right"  ID="txt_porc_30" runat="server" class="input form-control text-center" ReadOnly="true" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" Visible="true" ID="lbl_30y45"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:TextBox Font-Size="Medium" BackColor="Yellow" Style="text-align: right" Font-Bold="true" ID="txt_valor3045" runat="server" class="input form-control text-center" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <asp:TextBox Font-Size="Smaller" BackColor="Yellow" Style="text-align: right"  ID="txt_porc_3045" runat="server" class="input form-control text-center" ReadOnly="true" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" Visible="true" ID="lbl_60"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:TextBox Font-Size="Medium" BackColor="#ff3300" ForeColor="#ffffff" Style="text-align: right" Font-Bold="true" ID="txt_valor60" runat="server" class="input form-control text-center" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <asp:TextBox Font-Size="Smaller" BackColor="#ff3300"  ForeColor="#ffffff" Style="text-align: right"  ID="txt_porc60" runat="server" class="input form-control text-center" ReadOnly="true" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <asp:Label runat="server" Visible="true" ID="lbl_TotalGeneral"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <asp:TextBox Font-Size="Large" Style="text-align: right" Font-Bold="true" ID="txt_TotalGeneral" runat="server" class="input form-control text-center" ReadOnly="true" />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <asp:TextBox Font-Size="Smaller" Style="text-align: right" Font-Bold="true" ID="txt_TotalPorcentajes" runat="server" class="input form-control text-center" ReadOnly="true" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <asp:TextBox Font-Size="Large" Style="text-align: center" Font-Bold="true" ID="txt_factor" runat="server" ForeColor="White" class="input form-control text-center" ReadOnly="true" />
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">DEUDA CRITICA MAYOR A 60 DÍAS:</div>
                    <div class="panel-body">
                        <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                        <%--<section class="cuerpo-informe">--%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView runat="server" ID="gdv_8020" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                                    GridLines="None" AllowSorting="true">
                                    <Columns>
                                        <asp:BoundField DataField="NombreCliente" ItemStyle-HorizontalAlign="Left" HeaderText="Cliente" HeaderStyle-BackColor="#cccccc" />
                                        <asp:BoundField DataField="Neto" HeaderText="Deuda Total" HeaderStyle-BackColor="#cccccc" />
                                        <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" HeaderStyle-BackColor="#cccccc" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="panel panel-primary">
                    <div class="panel-heading">80% DE LA DEUDA ACTUAL:</div>
                    <div class="panel-body">
                        <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                        <%--<section class="cuerpo-informe">--%>
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView runat="server" ID="gdv_8020SinEleccon" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                                    GridLines="None" AllowSorting="true">
                                    <Columns>
                                        <asp:BoundField DataField="NombreCliente" ItemStyle-HorizontalAlign="Left" HeaderText="Cliente" HeaderStyle-BackColor="#cccccc" />
                                        <asp:BoundField DataField="Neto" HeaderText="Deuda Total" HeaderStyle-BackColor="#cccccc" />
                                        <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" HeaderStyle-BackColor="#cccccc" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        $(function () {
            $('[id*=gdv_EstadosDePago]').footable();
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
        });
    </script>

</asp:Content>
