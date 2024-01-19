<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="inf_Facturacion.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.inf_Facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">¿Qué información desea revisar?</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <div class="row  input-daterange">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="Label2">Tipo:</label>
                            <asp:DropDownList ID="ddl_TipoInforme" runat="server" CssClass="form-control" AutoPostBack="true">
                                <asp:ListItem Value="01">Informe general de facturación</asp:ListItem>
                                <asp:ListItem Value="02">Informe agrupado por cliente</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2" id="pnl_Clientes" runat="server" visible="false">
                        <div class="form-group">
                            <div class="">
                                <label runat="server" id="lbl_CLienteBuscar">Filtrar por Cliente:</label>
                                <asp:SqlDataSource ID="sds_ListadoClientes" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ListaClientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                <asp:DropDownList ID="ddl_Clientes" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_ListadoClientes" DataValueField="RutCliente" DataTextField="NombreCliente">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2" id="pnl_Tipo" runat="server" visible="false">
                        <div class="form-group">
                            <label runat="server" id="Label1">Tipo:</label>
                            <asp:DropDownList ID="ddl_Tipo" runat="server" CssClass="form-control">
                                <asp:ListItem Value="01">Arriendos</asp:ListItem>
                                <asp:ListItem Value="02">Servicio Técnico</asp:ListItem>
                                <asp:ListItem Value="03">Ventas</asp:ListItem>
                                <asp:ListItem Value="04">Transporte</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-2" id="pnl_Mes" runat="server" visible="false">
                        <div class="form-group">
                            <label runat="server" id="lbl_Anho">Mes de facturación:</label>
                            <asp:DropDownList ID="ddl_periodo" runat="server" CssClass="form-control">
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
                    <div class="col-md-2" id="pnl_Anho" runat="server" visible="false">
                        <div class="form-group">
                            <label runat="server" id="Label3">Año:</label><label style="color: red">&nbsp;(*)</label>
                            <asp:DropDownList ID="DDL_ANHO" runat="server" CssClass="form-control">
                                <asp:ListItem Value="2020">2020</asp:ListItem>
                                <asp:ListItem Value="2021">2021</asp:ListItem>
                                <asp:ListItem Value="2022">2022</asp:ListItem>
                                <asp:ListItem Value="2023">2023</asp:ListItem>
                                            <asp:ListItem Value="2024">2024</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                   <div class="col-md-2" id="pnl_Sucursal" runat="server"  visible="false">
                        <div class="form-group">
                            <label runat="server" id="Label4">Sucursal:&nbsp; </label>
                            <asp:SqlDataSource ID="sds_Sucursales" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                            <asp:DropDownList ID="ddl_Sucursal" runat="server" CssClass="form-control" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal" required="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2" id="pnl_FInicio" runat="server" visible="false">
                        <div class="form-group">
                            <label for="txt_Fecha">Desde:</label>
                            <asp:TextBox MaxLength="10" ID="txt_FechaInicio" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                        </div>
                    </div>
                    <div class="col-md-2" id="pnl_FFin" runat="server" visible="false">
                        <div class="form-group">
                            <label for="txt_Fecha">Hasta:</label>
                            <asp:TextBox MaxLength="10" ID="txt_FechaTermino" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="end" onkeydown="return false;" />
                        </div>
                    </div>
                    <div class="col-md-2" id="pnl_SucursalAgrupada" runat="server"  visible="false">
                        <div class="form-group">
                            <label runat="server" id="Label5">Sucursal&nbsp; </label>
                            <label style="color: red">*</label>
                            <asp:SqlDataSource ID="sds_SucursalesAgrupadas" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                            <asp:DropDownList ID="ddl_SucursalAgrupada" runat="server" CssClass="form-control" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal" AutoPostBack="true" required="true">
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="pull-left">
                            <asp:LinkButton runat="server" ID="btn_VistaPreviaAgrupada" CssClass="btn btn-info" Text="Vista Previa" Visible="false" />
                            <asp:LinkButton runat="server" ID="btn_VistaPreviaGeneral" CssClass="btn btn-info" Text="Vista Previa" Visible="false" />
                            <asp:LinkButton runat="server" ID="btn_GenerarInformeGeneral" CssClass="btn btn-primary" Text="Generar Informe" Visible="false" /><asp:Label runat="server" Visible="false" ID="lbl_Proyeccion"></asp:Label>


                            <%--<asp:LinkButton runat="server" ID="btn_GenerarInformeAgrupado" CssClass="btn btn-primary" Text="Generar Informe" visible="false"/>--%>
                            <%--<asp:LinkButton runat="server" ID="btn_RecargarAgrupado" CssClass="btn btn-success" Text="Recargar" visible="false"/>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:SqlDataSource ID="sds_FacturacionGeneralTotales" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
            SelectCommand="up_parque_s_infFacturacionXfiltrosTotales" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
                <asp:Parameter Name="Periodo" Type="String"></asp:Parameter>
                <asp:Parameter Name="Anho" Type="String"></asp:Parameter>
                <asp:Parameter Name="Tipo" Type="int32"></asp:Parameter>
                <asp:Parameter Name="Sucursal" Type="int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>

        <div class="panel panel-primary" id="pnl_Visualización" runat="server" visible="false">
            <div class="panel-heading">PANEL DE VISUALIZACIÓN</div>
            <div class="panel-body">
                <section>
                    <asp:UpdatePanel runat="server" ID="upp_Novedades" ChildrenAsTriggers="true" UpdateMode="Conditional">
                        <ContentTemplate>
                            <%--<div runat="server" id="pnl_mensaje" visible="false" class="alert alert-link alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong runat="server" id="lbl_mensaje1"></strong><span runat="server" id="lbl_mensaje2"></span>
                        </div>--%>
                            <!-- SQLDataSource a utilizar -->
                            <asp:SqlDataSource ID="sds_FacturacionGeneral" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                                SelectCommand="up_parque_s_infFacturacionXfiltrosVP" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="Periodo" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="Anho" Type="String"></asp:Parameter>
                                    <asp:Parameter Name="Tipo" Type="int32"></asp:Parameter>
                                    <asp:Parameter Name="Sucursal" Type="int32"></asp:Parameter>
                                </SelectParameters>
                            </asp:SqlDataSource>

                            <asp:SqlDataSource ID="sds_FacturacionAgrupada" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                                SelectCommand="up_parque_s_infFacturacionAgrupada" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter Name="F_INICIO" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="F_FIN" Type="DateTime"></asp:Parameter>
                                    <asp:Parameter Name="Sucursal" Type="int32"></asp:Parameter>
                                </SelectParameters>
                            </asp:SqlDataSource>



                            <!-- Listar opciones del sistema -->
                            <asp:GridView runat="server" ID="gdv_FacturacionAgrupada" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                                GridLines="None" AllowSorting="true">
                                <Columns>
                                    <%--<asp:BoundField DataField="id_Contrato" HeaderText="Contrato" ControlStyle-Font-Bold="true" />--%>
                                    <%--<asp:TemplateField HeaderText="" HeaderStyle-BackColor="#ffffff">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_edp" Checked="true" />
                                       <asp:HiddenField runat="server" ID="hf_edp" Value='<%# Eval("Nombre_Cliente")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                    <asp:BoundField DataField="Nombre_Cliente" HeaderText="Cliente" />
                                    <asp:BoundField DataField="F_VENTA" ItemStyle-VerticalAlign="NotSet" HeaderText="Facturación Ventas" />
                                    <asp:BoundField DataField="F_ST" ItemStyle-VerticalAlign="NotSet" HeaderText="Facturación S/T" />
                                    <asp:BoundField DataField="FACT_TRANSPORTE" ItemStyle-VerticalAlign="NotSet" HeaderText="Facturación Transporte" />
                                    <asp:BoundField DataField="F_SA" HeaderText="Facturación Sub Arriendo" />
                                    <asp:BoundField DataField="F_ARR" ItemStyle-VerticalAlign="NotSet" HeaderText="Facturación Arriendo" />
                                    <asp:BoundField ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" DataField="TOTAL" HeaderText="Facturación Total" />
                                    <asp:BoundField DataField="FACTOR" HeaderText="Factor de arriendo (%)" />
                                    <asp:BoundField DataField="PORCENTAJE" HeaderText="Facturación (%)" />


                                    <%--<asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_VerCaso" runat="server" OnClick="btn_VerCaso_Click"
                                            CommandArgument='<%#Eval("id_Contrato")%>' Text="Detalles" CssClass="btn btn-success btn-group-justified" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_EstadosPago" runat="server" OnClick="btn_EstadosPago_Click"
                                            CommandArgument='<%#Eval("id_Contrato")%>' Visible='<%# If(Session("id_Usuario") = "5", False, True)%>' Text="Estados de pago" CssClass='<%#IIf(Eval("Tipologia") = "Realizar", "btn btn-danger btn-group-justified", "btn btn-primary btn-group-justified")%>'  />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>

                            <!-- Listar opciones del sistema -->
                            <asp:GridView runat="server" ID="gdv_FacturacionGeneral" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                                GridLines="None" AllowSorting="true">
                                <Columns>
                                    <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                                    <asp:BoundField DataField="NumeroFactura" ItemStyle-VerticalAlign="NotSet" HeaderText="Factura" />
                                    <asp:BoundField DataField="id_Contrato" ItemStyle-VerticalAlign="NotSet" HeaderText="Contrato" />
                                    <asp:BoundField DataField="TipoEstadoPago" ItemStyle-VerticalAlign="NotSet" HeaderText="Tipo" />
                                    <asp:BoundField DataField="NombreEquipo" HeaderText="Equipo" />
                                    <asp:BoundField DataField="id_Equipo" HeaderText="id_Equipo" />
                                    <asp:BoundField DataField="Faena" HeaderText="Faena" />
                                    <asp:BoundField DataField="ValorNeto" HeaderText="Neto" />
                                    <asp:BoundField DataField="IVA" HeaderText="IVA" />
                                    <asp:BoundField DataField="ValorTotal" HeaderText="Total" />
                                </Columns>
                            </asp:GridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </section>
            </div>
        </div>
    </div>


    <%--<script>
        $("#<%=pnl_MensajeAdvertenciaGuardado.ClientID%>").delay(3000).fadeTo(500, 0);
    </script>--%>
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
