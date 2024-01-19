<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_InformePagos.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_InformePagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">FILTRAR POR:</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <div class="row  input-daterange">
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
                     
                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                    
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label4">Sucursal:&nbsp; </label>
                            <asp:SqlDataSource ID="sds_Sucursales" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                            <asp:DropDownList ID="ddl_Sucursal" runat="server" CssClass="form-control" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal" required="true">
                            </asp:DropDownList>
                        </div>
                    </div>--%>
                    <div class="col-md-2">
                            <div class="form-group">
                                <label for="txt_Fecha">Desde:</label>
                                <asp:TextBox MaxLength="10" ID="txt_FechaInicio" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="txt_Fecha">Hasta:</label>
                                <asp:TextBox MaxLength="10" ID="txt_FechaTermino" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="end" onkeydown="return false;" />
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
