<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_CrearOT.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_CrearOT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:SqlDataSource ID="sds_TrabajadoresST" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_TrabajadoresST" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_ActividadesOT" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ActividadesOT" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_TiposOT" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_TiposOT" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_NumeroOTCrear" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_NumeroOTCrear" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">DATOS DE LA OT:</div>
            <div class="panel-body">
                <div class="panel-body">
                    <div class="row" id="datetimepicker">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="Label2">N° OT&nbsp; </label>
                                <span runat="server" style="color: red" id="Span1"></span>
                                <asp:TextBox Font-Size="X-Large" Font-Bold="true" ID="txt_NumeroOT" ReadOnly="true" runat="server" class="input form-control text-center" required="true" />
                            </div>
                        </div>
                        <div class="col-md-2 input-daterange">
                            <div class="form-group">
                                <label for="txt_Fecha">Fecha:</label>
                                <asp:TextBox MaxLength="10" ID="txt_FechaOT" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" required="true" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="Label1">AFI&nbsp; </label>
                                <span runat="server" style="color: red" id="lbl_Afi"></span>
                                <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" AutoPostBack="true" ID="txt_AFI" runat="server" class="input form-control text-center" required="true" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="lbl_Anho">Tipo de OT:</label>
                                <asp:DropDownList ID="ddl_TiposOT" runat="server" CssClass="form-control" DataSourceID="sds_TiposOT" DataValueField="id_TipoOT" DataTextField="NombreTipoOT" required="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="Label5">Responsable:</label>
                                <asp:DropDownList ID="ddl_Responsable" runat="server" CssClass="form-control" DataSourceID="sds_TrabajadoresST" DataValueField="id_Trabajador" DataTextField="NombreTrabajador" required="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label runat="server" id="Label7">Supervisor:</label>
                                <asp:DropDownList ID="ddl_Supervisor" runat="server" CssClass="form-control" DataSourceID="sds_TrabajadoresST" DataValueField="id_Trabajador" DataTextField="NombreTrabajador" required="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="panel panel-info">
                    <div class="panel-heading">Agregar Actividades a la OT</div>
                    <div class="panel-body">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label runat="server" id="Label9">Actividades:</label>
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
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="panel panel-success">
                    <div class="panel-heading">Seleccionar trabajadores</div>
                    <div class="panel-body">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label runat="server" id="Label6">Nombre Trabajador:</label>
                                        <asp:DropDownList ID="ddl_TrabajadorDeOT" runat="server" CssClass="form-control" DataSourceID="sds_TrabajadoresST" DataValueField="id_Trabajador" DataTextField="NombreTrabajador">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label runat="server" id="Label8">Tiempo&nbsp; </label>
                                        <span runat="server" style="color: red" id="Span3"></span>
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
                        </div>
                    </div>
                </div>
            </div>

            
        </div>
        <%-- </div>--%>
    </div>

    <div class="container-fluid">
        <%-- <div class="panel panel-primary" id="pnl_casos" runat="server">--%>
        <div class="panel-heading"></div>

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
                                            <asp:GridView runat="server" ID="gdv_ActividadesOT" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="False"
                                                GridLines="None" AllowSorting="True">
                                                <Columns>
                                                    <asp:BoundField DataField="id_Actividad" Visible="true" ControlStyle-Font-Size="1" ControlStyle-ForeColor="#ffffff" FooterStyle-ForeColor="White" ItemStyle-ForeColor="White"  HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                        <ControlStyle Font-Bold="True" BackColor="White" ForeColor="#ffffff"  />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NombreActividad" ItemStyle-HorizontalAlign="left" FooterStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderText="Nombre Actividad" ControlStyle-Font-Bold="true">
                                                        <ControlStyle Font-Bold="True"   />
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
                                    <asp:UpdatePanel runat="server" ID="upp_Novedades" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div runat="server" id="pnl_mensaje" visible="false" class="alert alert-link alert-dismissible" role="alert">
                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                                <strong runat="server" id="lbl_mensaje1"></strong><span runat="server" id="lbl_mensaje2"></span>
                                            </div>


                                            <asp:GridView runat="server" ID="gdv_TrabajadoresOT" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="False"
                                                GridLines="None" AllowSorting="True">
                                                <Columns>
                                                    <asp:BoundField DataField="id_Trabajador" Visible="true" ControlStyle-Font-Size="1" ControlStyle-ForeColor="#ffffff" FooterStyle-ForeColor="White" ItemStyle-ForeColor="White"  HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                        <ControlStyle Font-Bold="True" BackColor="White" ForeColor="#ffffff"  />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NombreTrabajador" HeaderText="Trabajador" ControlStyle-Font-Bold="true">
                                                        <ControlStyle Font-Bold="True" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                                                    <asp:BoundField DataField="Tiempo" ItemStyle-VerticalAlign="NotSet" HeaderText="Tiempo (hr)" />
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




        <div class="panel-body">
        </div>
       

        <div class="row">
                    <div class="col-md-12">
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                            <asp:Button ID="btn_GenerarOT" runat="server" Text="Generar OT" CssClass="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" />
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


         <div id="mpe_GenerarOT" class="modal fade">
            <div class="modal-dialog modal-confirm">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="icon-box">
                            <i class="material-icons">&#xE876;</i>
                        </div>
                        <h4 class="modal-title">OT Generada con éxito!</h4>
                    </div>
                    <div class="modal-body">
                        <p class="text-center"></p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="btn_DescargarOT" class="btn btn-primary" Text="Descargar OT" />

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
                        <h4 class="modal-title">¡Error al generar la OT!</h4>
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



    </div>

    

    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
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
