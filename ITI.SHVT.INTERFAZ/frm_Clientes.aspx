<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_Clientes.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />

    <asp:SqlDataSource ID="sds_ClientesRankingXCliente" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ClientesRankingXCliente" SelectCommandType="StoredProcedure" runat="server">
        <SelectParameters>
            <asp:Parameter Name="RutCliente" Type="string" />
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="sds_ClientesRanking" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ClientesRanking" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


    <asp:SqlDataSource ID="sds_ClientesRanking2" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ClientesRanking2" SelectCommandType="StoredProcedure"></asp:SqlDataSource>


    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">BUSCAR POR CLIENTE:</div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <div class="">
                                <%-- %><label runat="server" id="lbl_CLienteBuscar">Filtrar por Cliente:</label>--%>
                                <asp:SqlDataSource ID="sds_ListadoClientes" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ListaClientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                <asp:DropDownList ID="ddl_Clientes" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_ListadoClientes" DataValueField="RutCliente" DataTextField="NombreCliente">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="panel panel-primary" id="pnl_Ranking" runat="server">
            <div class="panel-heading">RANKING DE CLIENTES</div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="container-fluid">
                            <div class="panel-group" id="accordion" role="tablist">
                                <asp:ListView ID="lvw_Colapsables" Visible="true" runat="server">
                                    <ItemTemplate>
                                        <div class="panel panel-default">
                                            <div class="panel-heading row" role="tab" id="heading<%#Container.DataItemIndex%>">
                                                <div class="col-xs-7">
                                                    <h4 class="panel-title">
                                                        <a <%# IIf(Container.DataItemIndex = 0, "", "class='collapsed'")%> role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse<%#Container.DataItemIndex%>">
                                                            <%#Eval("Ranking")%>
                                                        </a>
                                                    </h4>
                                                </div>

                                            </div>
                                            <div id="collapse<%#Container.DataItemIndex%>" class="panel-collapse collapse <%# IIf(Container.DataItemIndex = 0, "in", "")%>" role="tabpanel">
                                                <div class="panel-body">
                                                    <asp:UpdatePanel ID="upp_GrillaPermisos" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div style="display: block !important;">
                                                                <asp:GridView ID="gdv_Permisos" runat="server" AutoGenerateColumns="false" CssClass="footable table table-condensed table-striped table-hover" GridLines="None" UseAccessibleHeader="true">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="RutCliente" ControlStyle-Font-Bold="TRUE" HeaderText="RUT" />
                                                                        <asp:BoundField DataField="Cliente" ControlStyle-Font-Bold="TRUE" HeaderText="CLIENTE" />
                                                                        <asp:BoundField DataField="Demora" ControlStyle-Font-Bold="TRUE" HeaderText="DÍAS RECUPERACIÓN (FACT. PAGADAS / FACT. PENDIENTES)" />
                                                                        <asp:BoundField DataField="NotaDemora" ControlStyle-Font-Bold="TRUE" HeaderText="NOTA DE RECUPERACIÓN DE VENTA" />
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btn_DetallesRecuperacion" runat="server" OnClick="btn_DetallesRecuperacion_Click"
                                                                                    CssClass="btn btn-success btn-group-justified"
                                                                                    Text="Detalles" CommandArgument='<%#Eval("RutCliente")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <%-- <asp:Button ID="Button1" runat="server" Text="Agregar Permiso" class="btn btn-default" CommandName="AbrirModal" />--%>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:ListView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <div class="panel panel-primary" id="pnl_datosempresa" runat="server">
            <div class="panel-heading">DATOS DEL CLIENTE</div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="txt_Fecha">Razón Social&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:TextBox ID="txt_NombreCliente" Font-Size="Medium" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="txt_Fecha">RUT&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:TextBox MaxLength="10" Font-Size="LARGE" ID="txt_RutCliente" runat="server" class="input form-control text-center" required="" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="selectedpicker">
                            <label runat="server" id="Labels1">Dirección&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:TextBox ID="txt_Direccion" Font-Size="Medium" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="lbl_CLienteBuscar2">Estado&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:DropDownList ID="ddl_Estado" runat="server" Font-Size="Medium" CssClass="form-control" Enabled="false">
                                <asp:ListItem Value="1">Vigente</asp:ListItem>
                                <asp:ListItem Value="2">No vigente</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>



        <div class="panel panel-primary" id="pnl_datoscontacto" runat="server">
            <asp:UpdatePanel ID="upp_Colapsables" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            </asp:UpdatePanel>

             

            <div class="panel-heading">DATOS DE CONTACTO</div>
            <div class="panel-body">



                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="txt_Fecha">Nombre&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:TextBox ID="txt_NombreRepresentanteLegal" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label2">Cargo&nbsp; </label>
                            <label style="color: red">*</label>
                            <span runat="server" style="color: red" id="Span5"></span>
                            <asp:TextBox ID="txt_CargoContacto" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label1">Teléfono&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:TextBox MinLenght="6" MaxLength="10" ID="txt_TelUno" runat="server" pattern="[0-9]*" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="lbl_CorreoUno">Correo Electrónico&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:TextBox ID="txt_CorreoUno" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label5">Nombre contacto Finanzas&nbsp; </label>
                            <span runat="server" style="color: red" id="Span6"></span>
                            <asp:TextBox ID="txt_NombreRepresentanteFinanzas" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label6">Cargo contacto Finanzas&nbsp; </label>
                            <span runat="server" style="color: red" id="Span7"></span>
                            <asp:TextBox ID="txt_CargoFinanzas" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label3">Teléfono contacto Finanzas&nbsp; </label>
                            <asp:TextBox MinLenght="6" MaxLength="10" ID="txt_TelDos" runat="server" pattern="[0-9]*" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="lbl_CorreoDos">Correo Electrónico contacto Finanzas &nbsp;</label>
                            <asp:TextBox ID="txt_CorreoDos" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-primary" id="pnl_datosFacturacion" runat="server">
            <div class="panel-heading">DATOS DE FACTURACIÓN</div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label for="txt_Fecha">Contratos Activos&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:TextBox ID="txt_ContratosActivos" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label4">Flota Arrendada&nbsp; </label>
                            <label style="color: red">*</label>
                            <span runat="server" style="color: red" id="Span8"></span>
                            <asp:TextBox ID="txt_FlotaArrendada" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server">(%) Flota Arrendada&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:TextBox ID="txt_PorcentajeArrendado" runat="server" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label7">Facturación Proyectada&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:TextBox ID="txt_FacturacionProyectada" runat="server" pattern="[0-9]*" class="input form-control" ReadOnly="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:SqlDataSource ID="sds_FlotaCliente" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
            SelectCommand="up_parque_s_MontoFlotaParqueXcliente" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="id_Cliente" Type="String"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="sds_FacturacionCliente" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
            SelectCommand="up_parque_s_FacturacionProyectadaXCliente" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="id_Cliente" Type="String"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="sds_Clientes" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
            SelectCommand="up_parque_s_Clientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>



        <asp:SqlDataSource ID="sds_SoloCliente" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
            SelectCommand="up_parque_s_SoloClienteVerCliente" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>

    </div>

    <script type="text/javascript">
        $(function () {
            $('[id*=gdv_EstadosDePago]').footable();
        });
    </script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
    <script type="text/javascript">
        var cargarFoo = function () {
            $('[id*=gdv_Permisos]').footable();
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
