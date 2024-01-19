<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_CrearCotizacion.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_CrearCotizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>--%>

    <asp:SqlDataSource ID="sds_MaxCotizacion" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_NumeroCotizacionMax" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

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

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    


    <div class="container">

        <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label runat="server" id="Label10">Cotización asociada a:&nbsp; </label>
                <asp:SqlDataSource ID="sds_Vendedores" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Vendedores" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <asp:DropDownList ID="ddl_Vendedores"  runat="server" CssClass="form-control" DataSourceID="sds_Vendedores" DataValueField="id_Usuario" DataTextField="NombreVendedor"  required="true">
                </asp:DropDownList>
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
                            <asp:DropDownList ID="ddl_Familia" runat="server" CssClass="form-control" DataSourceID="sds_Familias" DataValueField="id_Familia" DataTextField="NombreFamilia"  required="true" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label4">Modelo&nbsp; </label>
                            <asp:DropDownList ID="ddl_Equipos" runat="server" CssClass="form-control" DataSourceID="sds_EquiposXFamilia" DataValueField="NombreEquipo" DataTextField="NombreEquipo"  required="true" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <label runat="server" id="Label1">Equipo&nbsp; </label>
                            <asp:DropDownList ID="ddl_SeleccionEquipo" runat="server" CssClass="form-control" DataSourceID="sds_EquipoXmodelo" DataValueField="id_Equipo" DataTextField="NombreEquipo"  required="true">
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
                            <asp:DropDownList ID="ddl_TipoCotizacion" runat="server" CssClass="form-control"  required="true">
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
                            <label runat="server" id="lbl_Precio">&nbsp; </label>
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
                <asp:ListBox runat="server" ID="lbx_Implementaciones" DataSourceID="sds_Implementaciones" DataValueField="id_Actividad"
                    DataTextField="NombreActividad" CssClass="form-control" SelectionMode="Multiple" Rows="7"></asp:ListBox>
            </div>
        </div>
    </div>
    <div class="container">

        <div class="row">

            <div class="col-md-12">
                <div class="pull-right">
                    <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />
                    <asp:Button ID="btn_GenerarCotizacion" runat="server" Text="Generar Cotización" CssClass="btn btn-primary" />

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

     <div id="mpe_GenerarCotizacion" class="modal fade">
            <div class="modal-dialog modal-confirm">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="icon-box">
                            <i class="material-icons">&#xE876;</i>
                        </div>
                        <h4 class="modal-title">Cotización Generada con éxito!</h4>
                    </div>
                    <div class="modal-body">
                        <p class="text-center"></p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="btn_DescargarCotizacion" class="btn btn-primary" Text="Descargar Cotización" />

                    </div>
                </div>
            </div>
        </div>

        <div id="mpe_VerCausaError" class="modal fade">
            <div class="modal-dialog modal-error">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="icon-box">
                            <i class="material-icons">&#xE5CD;</i>
                        </div>
                        <h4 class="modal-title">¡Error al generar la Cotización!</h4>
                        <br />
                        <br />
                        <h5 class="modal-title">(Contacte al admintrador del sistema)</h5>
                    </div>
                    <div class="modal-body">
                        <p class="text-center"></p>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-success btn-block" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>



    <style type="text/css">
        body {
            font-family: 'Varela Round', sans-serif;
        }

        .modal-confirm {
            color: #636363;
            width: 325px;
        }

            .modal-confirm .modal-content {
                padding: 20px;
                border-radius: 5px;
                border: none;
            }

            .modal-confirm .modal-header {
                border-bottom: none;
                position: relative;
            }

            .modal-confirm h4 {
                text-align: center;
                font-size: 26px;
                margin: 30px 0 -15px;
            }

            .modal-confirm .form-control, .modal-confirm .btn {
                min-height: 40px;
                border-radius: 3px;
            }

            .modal-confirm .close {
                position: absolute;
                top: -5px;
                right: -5px;
            }

            .modal-confirm .modal-footer {
                border: none;
                text-align: center;
                border-radius: 5px;
                font-size: 13px;
            }

            .modal-confirm .icon-box {
                color: #fff;
                position: absolute;
                margin: 0 auto;
                left: 0;
                right: 0;
                top: -70px;
                width: 95px;
                height: 95px;
                border-radius: 50%;
                z-index: 9;
                background: #82ce34;
                padding: 15px;
                text-align: center;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.1);
            }

            .modal-confirm .icon-box {
                color: #fff;
                position: absolute;
                margin: 0 auto;
                left: 0;
                right: 0;
                top: -70px;
                width: 95px;
                height: 95px;
                border-radius: 50%;
                z-index: 9;
                background: #82ce34;
                padding: 15px;
                text-align: center;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.1);
            }

                .modal-confirm .icon-box i {
                    font-size: 58px;
                    position: relative;
                    top: 3px;
                }

            .modal-confirm.modal-dialog {
                margin-top: 80px;
            }

            .modal-confirm .btn {
                color: #fff;
                border-radius: 4px;
                background: #82ce34;
                text-decoration: none;
                transition: all 0.4s;
                line-height: normal;
                border: none;
            }

                .modal-confirm .btn:hover, .modal-confirm .btn:focus {
                    background: #6fb32b;
                    outline: none;
                }

        .trigger-btn {
            display: inline-block;
            margin: 100px auto;
        }



        .modal-error {
            color: #636363;
            width: 325px;
        }

            .modal-error .modal-content {
                padding: 20px;
                border-radius: 5px;
                border: none;
            }

            .modal-error .modal-header {
                border-bottom: none;
                position: relative;
            }

            .modal-error h4 {
                text-align: center;
                font-size: 26px;
                margin: 30px 0 -15px;
            }

            .modal-error .form-control, .modal-error .btn {
                min-height: 40px;
                border-radius: 3px;
            }

            .modal-error .close {
                position: absolute;
                top: -5px;
                right: -5px;
            }

            .modal-error .modal-footer {
                border: none;
                text-align: center;
                border-radius: 5px;
                font-size: 13px;
            }

            .modal-error .icon-box {
                color: #fff;
                position: absolute;
                margin: 0 auto;
                left: 0;
                right: 0;
                top: -70px;
                width: 95px;
                height: 95px;
                border-radius: 50%;
                z-index: 9;
                background: #ba4747;
                padding: 15px;
                text-align: center;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.1);
            }

            .modal-error .icon-box {
                color: #fff;
                position: absolute;
                margin: 0 auto;
                left: 0;
                right: 0;
                top: -70px;
                width: 95px;
                height: 95px;
                border-radius: 50%;
                z-index: 9;
                background: #ba4747;
                padding: 15px;
                text-align: center;
                box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.1);
            }

                .modal-error .icon-box i {
                    font-size: 58px;
                    position: relative;
                    top: 3px;
                }

            .modal-error.modal-dialog {
                margin-top: 80px;
            }

            .modal-error .btn {
                color: #fff;
                border-radius: 4px;
                background: #ba4747;
                text-decoration: none;
                transition: all 0.4s;
                line-height: normal;
                border: none;
            }

                .modal-error .btn:hover, .modal-error .btn:focus {
                    background: #ba4747;
                    outline: none;
                }
    </style>
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
