<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_GenerarContrato.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_GenerarContrato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="stm_Principal" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>

    <asp:SqlDataSource ID="sds_SoloCliente" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloCliente" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_SoloCoti" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloCoti" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Cotizacion" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_NumeroContrato" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_NumeroContrato" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sds_NumeroContratoCrear" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_NumeroContratoCrear" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <div class="container-sm">
        <asp:UpdatePanel ID="upp_Colapsables" runat="server" ChildrenAsTriggers="true" UpdateMode="always">
            <ContentTemplate>
                
                
                
                <div class="container col-md-3">
                    <div class="panel panel-primary">
                        <div class="panel-heading"> <asp:Label Font-Bold="true" ForeColor="White" Font-Size="Large" ID="Label6" runat="server"></asp:Label></div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:TextBox ID="txt_idCotizacion" Font-Size="X-Large" Font-Bold="true" placeholder="Número Cotización" runat="server" class="input form-control text-center" AutoPostBack="true" required="true" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <span runat="server" style="color: red" id="lbl_ErrorCotizacion"></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                                             
                <div class="container col-md-12">
                    <section>
                        <div runat="server" id="pnl_Agregado" visible="false" class="alert alert-success alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong>Terminado!</strong> El cliente se ha registrado correctamente.
                        </div>
                        <div runat="server" id="pnl_Noexiste" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong>Error!</strong> El Equipo que buscas no esta en el sistema.
                        </div>
                    </section>

                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            CONTRATO # 
                            <asp:Label Font-Bold="true" ForeColor="White" Font-Size="Large" ID="lbl_NumContrato" runat="server"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:SqlDataSource ID="sds_ListadoClientes" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ListaClientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                        <asp:DropDownList ID="ddl_Clientes" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_ListadoClientes" DataValueField="RutCliente" DataTextField="NombreCliente">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:TextBox ID="txt_Afi" MaxLength="6" class="input form-control text-center" runat="server" placeholder="AFI" AutoPostBack="TRUE" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:SqlDataSource ID="sds_Zonas" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ListaZonas" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                        <asp:DropDownList ID="ddl_Zonas" runat="server" CssClass="form-control" DataSourceID="sds_Zonas" DataValueField="id_Zona" DataTextField="NombreZona" AutoPostBack="true" required="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3 input-daterange">
                                    <div class="form-group">
                                        <asp:TextBox ID="txt_Fecha" runat="server" name="start" onkeydown="return false;" class="input form-control" required="true" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading">Datos del cliente</div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Nombre </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_NombreCliente"></span></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Rut </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_RutCliente"></span></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Contacto</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_NombreRepresentante"></span></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Teléfono</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_TelUno"></span></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Correo</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_CorreoUno"></span></div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="panel panel-info">
                                    <div class="panel-heading">Datos del equipo</div>
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">AFI </label>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="col-md-9"><span class="modal-span" runat="server" style="text-align: left" id="lbl_Afi"></span></div>
                                                    </div>
                                                    <div class="col-md-5">
                                                        <div class="form-group">
                                                            <div class="form-group">
                                                                <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Nombre </label>
                                                    </div>
                                                    <div class="col-md-4"><span class="modal-span" runat="server" id="lbl_NombreEquipo"></span></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Marca </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_MarcaEquipo"></span></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Modelo </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_ModeloEquipo"></span></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Horómetro </label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_Horometro"></span></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                        
                            <asp:Label Font-Bold="true" ForeColor="White" Font-Size="Large" ID="Label1" runat="server"></asp:Label>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <span runat="server" style="color: red" id="lbl_ErrorGuia"></span>
                                    <asp:TextBox ID="txt_NumeroGuia" placeholder="N° DE GUÍA" runat="server" class="input form-control" required="true" AutoPostBack="true" />
                                </div>
                                <div class="col-md-3">
                                    <span runat="server" style="color: red" id="lbl_ErrorTarifa"></span>
                                    <asp:TextBox ID="txt_Tarifa" placeholder="TARIFA" runat="server" class="input form-control" required="true" AutoPostBack="true" />
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:DropDownList ID="ddl_Modalidad" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1">MENSUAL</asp:ListItem>
                                            <asp:ListItem Value="2">DIARIO</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        
                                        <asp:TextBox ID="txt_NombreFaena" placeholder="FAENA" runat="server" class="input form-control" required="true" />
                                    </div>
                                </div>
                            </div>
                        </div>


                        <%-- MODAL --%>
                        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_VerCausa" tabindex="-1" role="dialog">
                            <div class="modal-dialog" role="document" style="width: 90% !important;">
                                <div class="modal-content">
                                    <div class="modal-body">
                                        <asp:UpdatePanel ID="upp_Modal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                            <ContentTemplate>
                                                <div class="panel panel-primary">
                                                    <div class="panel-heading">Información del contrato número</p></div>
                                                    <div class="panel-body">
                                                        <div class="form-group">

                                                            <div class="row">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            <asp:Button runat="server" ID="btn_GuardarModale" class="btn btn-primary" Text="Descargar Contrato" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

               
                    
                
                 <div class="row">
                    <div class="col-md-12">
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                            <asp:Button ID="btn_Guardar" runat="server" Text="Generar Contrato" CssClass="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" />
                        </div>
                    </div>
                </div>
                
                
                </div>


               
                <%--<label style="color: red">(*) Campos obligatorios</label>--%>
                </div>
                <%--<div class="container col-md-1"></div>--%>
            </ContentTemplate>
        </asp:UpdatePanel>



        <!-- Modal HTML  data-dismiss="modal"-->
        <div id="mpe_VerCaso" class="modal fade">
            <div class="modal-dialog modal-confirm">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="icon-box">
                            <i class="material-icons">&#xE876;</i>
                        </div>
                        <h4 class="modal-title">Contrato Generado con éxito!</h4>
                    </div>
                    <div class="modal-body">
                        <p class="text-center"></p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="btn_GuardarModal" class="btn btn-primary" Text="Generar Acta de entrega" />

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
                        <h4 class="modal-title">¡Error al generar el contrato!</h4>
                        <br />
                        <br />
                        <h5 class="modal-title">(Verifique que el equipo este en Stock)</h5>
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



    </div>

    <!-- Modal Detalle Contrato -->

    <!--/container-->
    <%--<link href="https://gitcdn.github.io/bootstrap-toggle/2.2.2/css/bootstrap-toggle.min.css" rel="stylesheet">
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.2/js/bootstrap-toggle.min.js"></script>--%>

    <%--<link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">--%>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />


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
        $(document).ready(function () {
            $('.chosen-select').chosen();
            $(".input-daterange").datepicker({
                language: "es",
                format: "dd/mm/yyyy",
                autoclose: true,
                todayHighlight: true,
                orientation: "bottom"
            });
            $('select').selectpicker();

            $(function () {
                $('#toggle-two').bootstrapToggle({
                    on: 'Diario',
                    off: 'Mensual'
                });
            })

        });
    </script>
    <script>
        function ActualizaCombobox() {
            $('.chosen-select').chosen();
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('[id*=gdv_Novedades]').footable();
        });
    </script>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (s, e) {
            ActualizaCombobox();
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

        function comprueba() {
            if (chk_TipoTarifa.checked) {
                on();
            } else {
                off();
            }
        }

        $(function () {
            $('#toggle-two').bootstrapToggle({
                on: 'Diario',
                off: 'Mensual'
            });
        })



    </script>
</asp:Content>
