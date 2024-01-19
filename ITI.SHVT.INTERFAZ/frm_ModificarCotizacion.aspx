<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ModificarCotizacion.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_ModificarCotizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>--%>

    <asp:SqlDataSource ID="sds_EquipoXidequipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_EquipoXidEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_EquiposXFamilia" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_EquiposXfamiliaCotizacion" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Familia" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_EquipoXmodelo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_EquiposXModeloCotizacion" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="NombreEquipo" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_CotizacionxId" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_CotizacionXid" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="idCotizacion" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_ImplementacionesXcotizacion" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ImplementacionesXidCotizacion" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Cotizacion" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

      <asp:SqlDataSource ID="sds_CondicionesXcotizacion" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_CondicionesXidCotizacion" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Cotizacion" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />

   

    <div class="container">

        <section>
                    <!-- Inicio mensaje final -->
                    <div runat="server" id="pnl_Agregado" visible="false" class="alert alert-success alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Terminado!</strong> La cotización fue Actualizada satisfactoriamente.
                    </div>
                </section>

        <div class="panel panel-primary">
            <div class="panel-heading">DATOS DEL EQUIPO</div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label runat="server" id="Label11">N° Cotización&nbsp; </label>
                            <asp:TextBox ID="txt_NumeroCotizacion" runat="server" Font-Size="X-Large" Font-Bold="true" class="input form-control text-center" required="" /><asp:LinkButton ID="btn_Buscar" runat="server" Text="Buscar" CssClass="btn btn-info" />
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label runat="server" id="Label10">Cotización asociada a:&nbsp; </label>
                            <asp:SqlDataSource ID="sds_Vendedores" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Vendedores" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            <asp:DropDownList ID="ddl_Vendedores" runat="server" CssClass="form-control" DataSourceID="sds_Vendedores" DataValueField="id_Usuario" DataTextField="NombreVendedor">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label runat="server" id="Label12">Estado Cotización&nbsp; </label>
                            <asp:DropDownList ID="ddl_EstadoCotizacion" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">GENERADA</asp:ListItem>
                                <asp:ListItem Value="1">APROBADA</asp:ListItem>
                                <asp:ListItem Value="2">CONCRETADA</asp:ListItem>
                                <asp:ListItem Value="3">ANULADA</asp:ListItem>
                                <asp:ListItem Value="4">NO CONCRETADA</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">DATOS DEL EQUIPO</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <div class="row">
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label2">Familia&nbsp; </label>
                            <asp:SqlDataSource ID="sds_Familias" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Familias" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                            <asp:DropDownList ID="ddl_Familia" runat="server" CssClass="form-control" DataSourceID="sds_Familias" DataValueField="id_Familia" DataTextField="NombreFamilia" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label4">Modelo&nbsp; </label>
                            <asp:DropDownList Enabled="FALSE" ID="ddl_Equipos" runat="server" CssClass="form-control" DataSourceID="sds_EquiposXFamilia" DataValueField="NombreEquipo" DataTextField="NombreEquipo" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label1">Equipo&nbsp; </label>
                            <asp:DropDownList Enabled="FALSE" ID="ddl_SeleccionEquipo" runat="server" CssClass="form-control" DataSourceID="sds_EquipoXmodelo" DataValueField="id_Equipo" DataTextField="NombreEquipo">
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label3">Zona&nbsp; </label>
                             <asp:SqlDataSource ID="sds_Zonas" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ListaZonas" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                        <asp:DropDownList ID="ddl_Zonas" runat="server" CssClass="form-control" DataSourceID="sds_Zonas" DataValueField="id_Zona" DataTextField="NombreZona" AutoPostBack="true" required="true">
                                        </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <%--<div class="row">
                    <div class="col-md-12">
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />
                            <asp:Button ID="btn_BuscarPorAfi" runat="server" Text="Buscar por AFI" CssClass="btn btn-primary" />

                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">DATOS DE LA COTIZACIÓN</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>


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
                            <label runat="server" id="Label5">Contacto&nbsp; </label>
                            <asp:TextBox ID="txt_Contacto" runat="server" class="input form-control"  required="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label6">Faena&nbsp; </label>
                            <asp:TextBox ID="txt_Faena" runat="server" class="input form-control"  required="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label7">Tipo&nbsp; </label>
                            <asp:DropDownList ID="ddl_Tipo" runat="server" CssClass="form-control"  required="true">
                                <asp:ListItem Value="1">Arriendo</asp:ListItem>
                                <asp:ListItem Value="2">Venta</asp:ListItem>
                                <asp:ListItem Value="3">Transporte</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="row">
                    
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label8">Modalidad&nbsp; </label>
                            <asp:DropDownList ID="ddl_Modalidad" runat="server" CssClass="form-control" AutoPostBack="true"  required="true">
                                <asp:ListItem Value="1">Diario</asp:ListItem>
                                <asp:ListItem Value="2">Mes</asp:ListItem>
                                <asp:ListItem Value="3">Hora</asp:ListItem>
                                <asp:ListItem Value="4">Pago Único</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label9">Precio&nbsp; </label>
                            <asp:TextBox ID="txt_Precio" runat="server" class="input form-control" required="true" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" visible="false" id="lbl_cant_horas">Horas mínimas&nbsp; </label>
                            <asp:TextBox ID="txt_CantHoras" runat="server" class="input form-control" visible="false" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" visible="false" id="lbl_ValorAlternativo">Valor alternativo a mostrar&nbsp; </label>
                            <asp:DropDownList ID="ddl_ValorAlternativo" runat="server" CssClass="form-control" visible="false" >
                                <asp:ListItem Value="Diarios">Diario</asp:ListItem>
                                <asp:ListItem Value="Mensual">Mensual</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>


                <%--<div class="row">
                    <div class="col-md-12">
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />
                            <asp:Button ID="btn_BuscarPorAfi" runat="server" Text="Buscar por AFI" CssClass="btn btn-primary" />

                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">CONDICIONES DEL ARRIENDO</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <asp:SqlDataSource ID="sds_CondicionesArriendo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                    SelectCommand="up_parque_s_CondicionesCotizacion" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <%--<label for="Area">Implementación Asociada:</label>--%>
                <asp:ListBox runat="server" ID="lbx_CondicionesArriendo" DataSourceID="sds_CondicionesArriendo" DataValueField="id_CondicionCotizacion"
                    DataTextField="NombreCondicionCotizacion" CssClass="form-control" SelectionMode="Multiple" Rows="4"></asp:ListBox>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">IMPLEMENTANCIÓN ASOCIADA A LA COTIZACIÓN</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <asp:SqlDataSource ID="sds_Implementaciones" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                    SelectCommand="up_parque_s_ImplementacionesCotizacion" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <%--<label for="Area">Implementación Asociada:</label>--%>
                <asp:ListBox runat="server" ID="lbx_ActividadesDisponibles" DataSourceID="sds_Implementaciones" DataValueField="id_Actividad"
                    DataTextField="NombreActividad" CssClass="form-control" SelectionMode="Multiple" Rows="7"></asp:ListBox>
            </div>
        </div>
    </div>
    <div class="container">

        <div class="row">

            <div class="col-md-12">
                <div class="pull-right">
                    <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />
                    <asp:Button ID="btn_ActualizarCotizacion" runat="server" Text="Actualizar Cotización" CssClass="btn btn-primary" />

                </div>
            </div>
        </div>

        
    </div>


    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">

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
        });
    </script>


</asp:Content>
