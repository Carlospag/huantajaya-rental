<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_AgregarCliente.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_AgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="stm_Principal" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>

    <div class="container">
        <asp:UpdatePanel ID="upp_Colapsables" runat="server" ChildrenAsTriggers="true" UpdateMode="always">
            <ContentTemplate>
                <div class="container col-md-2"></div>
                <div class="container col-md-8">
                    <section>
                        <div runat="server" id="pnl_Agregado" visible="false" class="alert alert-success alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong>Terminado!</strong> El cliente se ha registrado correctamente.
                        </div>
                    </section>
                    <div class="panel panel-primary">
                        <div class="panel-heading">DATOS DE EMPRESA</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_Colaborador">Rut Cliente&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <span runat="server" style="color: red" id="lbl_ErrorRut"></span>
                                        <asp:TextBox Minlength="8" MaxLength="9" ID="txt_RutCliente" runat="server" class="input form-control" AutoPostBack="true" required="" />
                                        <p class="help-block">Escribir RUT sin puntos ni guión.</p>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    
                                </div>
                            </div>
                            <div class="row">
                                 <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txt_Fecha">Razón Social&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox ID="txt_NombreCliente" runat="server" class="input form-control" required="" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="selectedpicker">
                                        <label runat="server" id="Labels1">Dirección&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox ID="txt_Direccion" runat="server" class="input form-control" required="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">DATOS DE CONTACTO</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="Label1">Nombre&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <span runat="server" style="color: red" id="Span1"></span>
                                       <asp:TextBox ID="txt_NombreRepresentanteLegal" runat="server" class="input form-control" required=""/>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="Label2">Cargo&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <span runat="server" style="color: red" id="Span2"></span>
                                        <asp:TextBox  ID="txt_CargoContacto" runat="server" class="input form-control" required="" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="Label3">Teléfono&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <span runat="server" style="color: red" id="Span3"></span>
                                        <asp:TextBox MinLenght="8" MaxLength="9" ID="txt_TelUno" runat="server" pattern="[0-9]*" title="Solo ingresar números" class="input form-control" required="" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="Label4">Correo Electronico&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <span runat="server" style="color: red" id="Span4"></span>
                                       <asp:TextBox ID="txt_CorreoUno" runat="server" class="input form-control" required="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-primary">
                        <div class="panel-heading">DATOS DE FINANZAS</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="Label5">Nombre&nbsp; </label>
                                       
                                        <span runat="server" style="color: red" id="Span5"></span>
                                        <asp:TextBox  ID="txt_NombreRepresentanteFinanzas" runat="server" class="input form-control"  />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="Label6">Cargo&nbsp; </label>
                                       
                                        <span runat="server" style="color: red" id="Span6"></span>
                                        <asp:TextBox  ID="txt_CargoFinanzas" runat="server" class="input form-control"  />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="Label7">Teléfono&nbsp; </label>
                                       
                                        <span runat="server" style="color: red" id="Span7"></span>
                                        <asp:TextBox MinLenght="8" MaxLength="9" ID="txt_TelDos" runat="server" pattern="[0-9]*" title="Solo ingresar números" class="input form-control" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="Label8">Correo Electronico&nbsp; </label>
                                       
                                        <span runat="server" style="color: red" id="Span8"></span>
                                       <asp:TextBox ID="txt_CorreoDos" runat="server" class="input form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_Descripcion">Observaciones adicionales&nbsp;</label>
                                        <label style="color: gray">(Opcional)</label>
                                        <textarea runat="server" class="form-control" rows="5" id="txt_Observaciones" htmlencode="false"></textarea>
                                    </div>
                                </div>
                            </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label style="color: red">(*) Campos obligatorios</label>
                        </div>
                        <div class="col-md-8">
                            <div class="pull-right">
                                <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                                <asp:Button ID="btn_Guardar" runat="server" Text="Registrar Cliente" CssClass="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container col-md-2"></div>
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







    <!--/container-->


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
            $('select').selectpicker();

        });

    </script>
</asp:Content>
