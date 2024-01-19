<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ModificarCliente.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_ModificarCliente" %>

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

    <div class="container">
        <asp:UpdatePanel ID="upp_Colapsables" runat="server" ChildrenAsTriggers="true" UpdateMode="always">
            <ContentTemplate>

                <!-- Fin mensaje final -->

                <div class="container col-md-2"></div>

                <div class="container col-md-8">
                    <section>
                        <!-- Inicio mensaje final -->
                        <div runat="server" id="pnl_Agregado" visible="false" class="alert alert-success alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong>Terminado!</strong> El cliente se ha Actualizado correctamente.
                        </div>
                    </section>
                    <div class="panel panel-primary">
                        <div class="panel-heading">BUSCAR CLIENTE A MODIFICAR</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="">
                                            <%-- %><label runat="server" id="lbl_CLienteBuscar">Filtrar por Cliente:</label>--%>
                                            <asp:SqlDataSource ID="sds_ListadoClientes" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ListaClientes" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                            <asp:DropDownList ID="ddl_Clientes" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_ListadoClientes" DataValueField="RutCliente" DataTextField="NombreCliente">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:TextBox MaxLength="10" ID="txt_RutCliente" runat="server" class="input form-control" required="" ReadOnly="true" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel panel-primary">
                        <div class="panel-heading">DATOS DE LA EMPRESA</div>
                        <div class="panel-body">
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
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_CLienteBuscar2">Estado&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:DropDownList ID="ddl_Estado" runat="server" CssClass="form-control" required>
                                            <asp:ListItem Value="1">Vigente</asp:ListItem>
                                            <asp:ListItem Value="2">No vigente</asp:ListItem>
                                        </asp:DropDownList>
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
                                        <label for="txt_Fecha">Nombre&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox ID="txt_NombreRepresentanteLegal" runat="server" class="input form-control" required="" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="Label2">Cargo&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <span runat="server" style="color: red" id="Span2"></span>
                                        <asp:TextBox ID="txt_CargoContacto" runat="server" class="input form-control" required="" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_TelUno">Teléfono&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox MinLenght="6" MaxLength="10" ID="txt_TelUno" runat="server" pattern="[0-9]*" class="input form-control" required="" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_CorreoUno">Correo Electrónico&nbsp; </label>
                                        <label style="color: red">*</label>
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
                                <asp:TextBox ID="txt_NombreRepresentanteFinanzas" runat="server" class="input form-control"/>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label runat="server" id="Label6">Cargo&nbsp; </label>
                        
                                <span runat="server" style="color: red" id="Span6"></span>
                                <asp:TextBox ID="txt_CargoFinanzas" runat="server" class="input form-control"  />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label runat="server" id="lbl_TelDos">Teléfono&nbsp; </label>
                            
                                <asp:TextBox MinLenght="6" MaxLength="10" ID="txt_TelDos" runat="server" pattern="[0-9]*" class="input form-control" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label runat="server" id="lbl_CorreoDos">Correo Electrónico &nbsp;</label>
                               
                                <asp:TextBox ID="txt_CorreoDos" runat="server" class="input form-control" />
                            </div>
                        </div>

                    </div>
                            </div></DIV>
                    <%--FILA 3, MOTIVO Y CAUSALES--%>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label runat="server" id="lbl_Descripcion">Observaciones adicionales&nbsp;</label>
                                <label style="color: gray">(Opcional)</label>
                                <textarea runat="server" class="form-control" rows="5" id="txt_Motivo" htmlencode="false"></textarea>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-4">
                            <label style="color: red">(*) Campos obligatorios</label>
                        </div>
                        <div class="col-md-8">
                            <div class="pull-right form-group">
                                <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                                <asp:Button ID="btn_Guardar" runat="server" Text="Modificar Cliente" CssClass="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" />
                            </div>
                        </div>
                    </div>
                </div>

                </div>
                
                <!--</div>-->
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
