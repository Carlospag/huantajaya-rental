<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ModificarOC.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_ModificarOC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:SqlDataSource ID="sds_Comunas" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_Comunas" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Region" Type="Int16"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="sds_SoloOCeditar" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloOCEditar" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OC" Type="Int16"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

     <asp:SqlDataSource ID="sds_SoloOCDetalleEditar" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloOCDetalleEditar" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_OC" Type="Int16"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_SoloProveedorOC" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloProveedorOC" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Proveedor" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_CCHijos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_CCHijos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_CentroCostoPadre" Type="Int16"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_BuscarProveedorDDL" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_BuscarProveedorDDL" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_NumeroOCCrear" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_NumeroOCCrear" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>

    <!-- Contenido principal para agregar usuario -->
    <asp:UpdatePanel runat="server" ID="upp_Principal" ChildrenAsTriggers="true" UpdateMode="always">
        <ContentTemplate>
            <div class="container-fluid">
                <section>
                    <!-- Inicio mensaje final -->
                    <div runat="server" id="pnl_Agregado" visible="false" class="alert alert-success alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Terminado!</strong> El Proveedor fue actualizado satisfactoriamente al sistema.
                    </div>
                </section>
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="Label6">Buscar por OC:&nbsp; </label>
                            <asp:TextBox ID="txt_BuscarPorOC" pattern="[0-9]*" Font-Size="Large" title="Solo ingresar números" AutoPostBack="true" runat="server" class="input form-control text-center" />
                        </div>
                    </div>
                </div>
                <!-- PANEL DONDE SE INDICA A QUE PROVEEDOR SE LE REALIZARA, COMO TAMBIEN LOS MEDIOS DE PAGO, CC, ETC. -->
                <div class="panel panel-primary">
                    <div class="panel-heading"></div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <div class="">
                                        <label>Buscar por RUT:</label>
                                        <asp:DropDownList ID="ddl_RutProveedor" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_BuscarProveedorDDL" DataValueField="id_Proveedor" DataTextField="id_Proveedor">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <div class="">
                                        <label>Buscar por NOMBRE:</label>
                                        <asp:DropDownList ID="ddl_NombreProveedor" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_BuscarProveedorDDL" DataValueField="id_Proveedor" DataTextField="NombreProveedor">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txt_Fecha">Documento de compra&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:SqlDataSource ID="sds_DctoCompra" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_DocumentosDePago" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                    <asp:DropDownList ID="ddl_dctoCompra" required="true" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_DctoCompra" DataValueField="id_DctoCompra" DataTextField="NombreDctoCompra">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Medio de pago&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:SqlDataSource ID="sds_MedioPago" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_MediosDePago" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                    <asp:DropDownList ID="ddl_MedioPago" required="true" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_MedioPago" DataValueField="id_MedioPago" DataTextField="NombreMedioPago">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <div class="">
                                        <label runat="server" id="Label1">CC General:</label>
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
                                        <label runat="server" id="Label2">CC Especifico:</label>
                                        <label style="color: red">*</label>
                                        <asp:DropDownList ID="ddl_CCHijo" required="true" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_CCHijos" DataValueField="id_CentroCostoHijo" DataTextField="NombreCentroCostoHijo">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="font-size: small">
                            <div class="col-md-2">
                                <label runat="server" style="color: blue" id="lbl1"></label>
                                <label runat="server" style="color: red" visible="false" id="lbl_Rut"></label>
                            </div>
                            <div class="col-md-4">
                                <label runat="server" style="color: blue" id="lbl2"></label>
                                <label runat="server" style="color: red" visible="false" id="lbl_Nombre"></label>
                            </div>
                            <div class="col-md-4">
                                <label runat="server" style="color: blue" id="lbl3"></label>
                                <label runat="server" style="color: red" visible="false" id="lbl_Giro"></label>
                            </div>
                            <!--<div class="col-md-2">
                                <label runat="server" style="color: blue" id="lbl5"></label>
                                <label runat="server" style="color: red" visible="false" id="lbl_Region"></label>
                            </div>-->
                            <div class="col-md-2">
                                <label runat="server" style="color: blue" id="lbl6"></label>
                                <label runat="server" style="color: red" visible="false" id="lbl_Comuna"></label>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- PANEL DONDE SE RELLENAN LOS CAMPOS PARA CREAR EL DETALLE DE LA OC -->
                <div class="panel panel-info">
                    <div class="panel-heading">AGREGAR SERVICIO/PRODUCTO</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txt_Fecha">Producto/Servicio&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox ID="txt_Producto" runat="server" class="input form-control" />
                                </div>
                            </div>
                            <div class="col-md-1 text-center">
                                <div class="form-group">
                                    <label runat="server" id="Labels1">Cantidad:&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox ID="txt_Cantidad" pattern="[0-9]*" Font-Size="Large" title="Solo ingresar números" AutoPostBack="true" runat="server" class="input form-control text-center" />
                                </div>
                            </div>
                            <div class="col-md-2 text-center">
                                <div class="form-group">
                                    <label runat="server" id="Label3">Valor Unitario ($):&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox ID="txt_ValorUnitario" Font-Size="Large" title="Solo ingresar números" AutoPostBack="true" runat="server" class="input form-control text-center" />
                                </div>
                            </div>
                            <div class="col-md-1 text-center">
                                <label runat="server" id="Label5">Descuento:&nbsp; </label>
                                <asp:TextBox ID="txt_Descuento" Font-Size="Large" title="Solo ingresar números" AutoPostBack="true" runat="server" class="input form-control text-center" />
                            </div>
                            <div class="col-md-1">
                                <label runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
                                <asp:DropDownList ID="ddl_TipoDcto" runat="server" AutoPostBack="true" CssClass="form-control">
                                    <asp:ListItem Value="1">$</asp:ListItem>
                                    <asp:ListItem Value="2">%</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 text-center">
                                <div class="form-group">
                                    <label runat="server" id="Label4">Total ($):&nbsp; </label>
                                    <asp:TextBox ID="txt_TotalFila" Font-Size="Large" Font-Bold="true" ReadOnly="true" runat="server" class="input form-control text-center" />
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">

                                    <label runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
                                    <asp:LinkButton runat="server" ID="btn_Agregar" CssClass="btn bg-info" Text="Agregar" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- PANEL CON DETALLE DE LA OC, AC´PA SE VAN AGREGANDO CADA UNO DE LOS SERVICIOS O PRODUCTOS -->
                <div class="panel panel-success">
                    <div class="panel-heading">DETALLE </div>
                    <div class="panel-body">
                        <div class="panel-body">
                            <div class="row">
                                <section>
                                    <asp:UpdatePanel runat="server" ID="upp_Novedades" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:GridView runat="server" ID="gdv_DetalleOC" CssClass="table footable table-hover table-condensed" AutoGenerateColumns="False"
                                                GridLines="None" AllowSorting="True">
                                                <Columns>
                                                    <asp:BoundField DataField="Producto" HeaderStyle-HorizontalAlign="Left" HeaderText="Producto/Servicio">
                                                        <ControlStyle Font-Bold="True" BackColor="White" ForeColor="#ffffff" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                    <asp:BoundField DataField="Valor" HeaderText="Valor Unitario" />
                                                    <asp:BoundField DataField="Descuento" HeaderText="Descuento" />
                                                    <asp:BoundField DataField="TipoDescuento" HeaderText="Tipo Descuento" />
                                                    <asp:BoundField DataField="TotalFila" HeaderText="Total" />
                                                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" DeleteText="X">
                                                        <ControlStyle BackColor="#CC0000" Font-Bold="True" ForeColor="White" />
                                                    </asp:CommandField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </section>
                            </div>

                            <div class="row" runat="server" id="FilaTotal" visible="false">
                                <div class="col-md-9 "></div>
                                <div class="col-md-2 ">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NETO&nbsp;&nbsp;:
                                    <asp:TextBox ID="txt_TotalFinal" Font-Bold="true" ReadOnly="true" Height="18px" runat="server" class="text-right" />
                                </div>
                                <div class="col-md-1 "></div>
                            </div>
                            <div class="row" runat="server" id="FilaIva" visible="false">

                                <div class="col-md-9 "></div>
                                <div class="col-md-2 ">
                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;IVA&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
                                    <asp:TextBox ID="txt_IVA" Font-Bold="true" ReadOnly="true" Height="18px" runat="server" class="text-right" />
                                </div>
                                <div class="col-md-1 "></div>

                            </div>
                            <div class="row" runat="server" id="FilaTotalOC" visible="false">
                                <div class="col-md-9 "></div>
                                <div class="col-md-2 ">
                                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;TOTAL:
                                    <asp:TextBox ID="txt_TotalOC" Font-Bold="true" ReadOnly="true" Height="18px" runat="server" class="text-right" />
                                </div>
                                <div class="col-md-1 "></div>
                            </div>
                        </div>
                    </div>
                    <!-- Fin de sección de datos de cuenta de usuario -->



                </div>

                <!-- Inicio de sección de botoneria -->
                <section class="row">
                    <div class="col-md-8">
                        <div class="pull-left">
                            <label style="color: blue">Si algún dato del proveedor es distinta a la mostrada por pantalla, esta debe ser modificada en el formulario "Modificar Proveedor". </label>
                            </br>
                             <label style="color: blue">Se establecerá como fecha de emisión de la OC la fecha actual al momento de su creación.  </label>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" data-toggle="modal" data-target="#exampleModalCenter" CssClass="btn btn-default" Text="LIMPIAR CAMPOS" />
                            <asp:Button runat="server" ID="btn_Guardar" data-toggle="modal" data-target="#exampleModalCenter" CssClass="btn btn-primary" Text="GENERAR ORDEN DE COMPRA" />
                        </div>
                    </div>
            </div>
            </section>
                <!-- Fin de sección de botoneria -->

            <!-- MODAL DE EXITO Y ERROR AL GENERAR OC -->
            <asp:UpdatePanel runat="server" ID="upp_ocgenerada" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>
                    <div id="mpe_VerCausaError" class="modal fade">
                        <div class="modal-dialog modal-error">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <div class="icon-box">
                                        <i class="material-icons">&#xE5CD;</i>
                                    </div>
                                    <h4 class="modal-title">¡Error al generar la OC!</h4>
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
                    <div id="mpe_GenerarCotizacion" class="modal fade">
                        <div class="modal-dialog modal-confirm">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <div class="icon-box">
                                        <i class="material-icons">&#xE876;</i>
                                    </div>
                                    <h4 class="modal-title">OC Generada con éxito!</h4>
                                </div>
                                <div class="modal-body">
                                    <p class="text-center">
                                        OC N°:
                                        <label id="noc" style="font-size: larger" runat="server"></label>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <!--<asp:Button runat="server" ID="btn_DescargarOC" class="btn btn-primary" Text="Descargar OC" />-->
                                    <button class="btn btn-success btn-block" data-dismiss="modal">Cerrar</button>

                                </div>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>




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
        $(document).ready(function () {
            $('[id*=pnl_Agregado]').delay(2000).fadeOut(1000);
            $('[id*=pnl_ErrorRut]').delay(2000).fadeOut(1000);
            $('[id*=pnl_ErrorUsuario]').delay(2000).fadeOut(1000);
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
