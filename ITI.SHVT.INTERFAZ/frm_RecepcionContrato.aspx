﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_RecepcionContrato.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_RecepcionContrato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="stm_Principal" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>

    <div class="container">
        <asp:UpdatePanel ID="upp_Colapsables" runat="server" ChildrenAsTriggers="true" UpdateMode="always">
            <ContentTemplate>
                <section>
                    <div runat="server" id="pnl_Agregado" visible="false" class="alert alert-success alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Terminado!</strong> La fecha de recepción se ha actualizado correctamente.
                    </div>
                    <div runat="server" id="pnl_Error" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong>Error!</strong> No se ha logrado actualizar la fecha de recepción, intente nuevamente.
                        </div>
                </section>
                <div class="col-md-2"></div>
                <div class="container col-md-12">
                    <div class="panel panel-primary">
                        <div class="panel-heading">MODIFICACIÓN DE FECHA DE RECEPCIÓN</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label runat="server" id="Label6">CONTRATO </label>
                                            <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                                            <asp:TextBox Font-Size="X-Large" Font-Bold="true"  MaxLength="4" ID="txt_Contrato" runat="server" class="input form-control text-center" required="" />
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="col-md-6 input-daterange">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label runat="server" id="Label2">FECHA DE RECEPCIÓN</label>
                                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_FechaRecepcion" runat="server" class="input form-control text-center"  />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="pull-right">
                                        <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                                        <asp:Button ID="btn_Guardar" runat="server" Text="Guardar nueva fecha" CssClass="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-2"></div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- Modal -->
        <div class="modal fade" id="mpe_VerCausa" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="upp_Modal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title"></h4>
                            </div>
                            <div class="modal-body">

                                <div class="panel panel-primary">
                                    <div class="panel-heading"><span class="modal-span" runat="server" id="lbl_Titulo"></span></p></div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_Detalle"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>

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
