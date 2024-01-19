<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ConfirmacionFaltos.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_ConfirmacionFaltos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>

    <div class="container">
        <asp:UpdatePanel runat="server" ID="upp_Notificacion" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div runat="server" id="pnl_Notificacion" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <strong runat="server" id="lbl_Notificacion1"></strong><span runat="server" id="lbl_Notificacion2"></span>

                </div>
                <div runat="server" id="pnl_not" visible="false" class="alert alert-success alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <strong runat="server" id="lbl_not1"></strong><span runat="server" id="lbl_not2"></span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="panel panel-primary">
            <div class="panel-heading">PERIODO A CONSULTAR</div>
            <div class="panel-body">
                <div class="row input-daterange" id="datetimepicker">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label runat="server" id="lbl_Mes">Mes:</label>
                            <asp:DropDownList ID="ddl_Mes" runat="server" CssClass="form-control" required>
                                <asp:ListItem Value="1">Enero</asp:ListItem>
                                <asp:ListItem Value="2">Febrero</asp:ListItem>
                                <asp:ListItem Value="3">Marzo</asp:ListItem>
                                <asp:ListItem Value="4">Abril</asp:ListItem>
                                <asp:ListItem Value="5">Mayo</asp:ListItem>
                                <asp:ListItem Value="6">Junio</asp:ListItem>
                                <asp:ListItem Value="7">Julio</asp:ListItem>
                                <asp:ListItem Value="8">Agosto</asp:ListItem>
                                <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label runat="server" id="lbl_Anho">Año:</label>
                            <asp:DropDownList ID="ddl_Anho" runat="server" CssClass="form-control" required>
                                <asp:ListItem Value="2017">2017</asp:ListItem>
                                <asp:ListItem Value="2018">2018</asp:ListItem>
                                <asp:ListItem Value="2019">2019</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label runat="server" id="Label1">Planta:</label>
                            <asp:DropDownList ID="ddl_Planta" runat="server" CssClass="form-control" required>
                                <asp:ListItem Value="1">Renta Fija - Administrativa</asp:ListItem>
                                <asp:ListItem Value="2">Renta Fija - Turnos</asp:ListItem>
                                <asp:ListItem Value="3">Renta Variable</asp:ListItem>
                                <asp:ListItem Value="4">Mostrar Todos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div>
                            <%-- <asp:label runat="server" style="color:black" >* Periodo Renta Fija&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: 09 del mes anterior - 08 mes seleccionado.-</asp:label><br />
                            <asp:label runat="server" style="color:black" >* Periodo Renta Variable&nbsp;: Primer día - Último día del mes seleccionado.-</asp:label>--%>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="pull-right">
                            <asp:Button ID="btn_buscar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="panel panel-primary" id="pnl_faltos" runat="server">
            <div class="panel-heading">LISTADO DE FALTOS CONFIRMADOS</div>
            <div class="panel-body">
                <%-- <p>A continuación se muestra el listado de casos disponibles en el sistema, usted aquí podra generar las cartas respectivas.</p>--%>
            </div>
            <section>
                <asp:UpdatePanel runat="server" ID="upp_Novedades" ChildrenAsTriggers="true" UpdateMode="Always">
                    <ContentTemplate>
                            <div runat="server" id="pnl_mensaje" visible="false" class="alert alert-link alert-dismissible" role="alert">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <strong runat="server" id="lbl_mensaje1"></strong><span runat="server" id="lbl_mensaje2"></span>
                            </div>
                        
                        <!-- SQLDataSource a utilizar -->
                        <asp:SqlDataSource ID="sds_faltos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_shvt_s_Faltos" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="Planta" Type="Int16"></asp:Parameter>
                                <asp:Parameter Name="Mes" Type="Int16"></asp:Parameter>
                                <asp:Parameter Name="Anho" Type="Int16"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <!-- Listar opciones del sistema -->
                        <asp:GridView runat="server" ID="gdv_Novedades" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <%--<asp:BoundField DataField="id_Falto" HeaderText="Id Falto" SortExpression="id" />--%>
                                <asp:BoundField DataField="RutColaborador" HeaderText="Rut Colaborador" SortExpression="Estado" />
                                <asp:BoundField DataField="NombreCompleto" ItemStyle-VerticalAlign="NotSet" HeaderText="Nombre Colaborador" SortExpression="NombreC" />
                                <asp:BoundField DataField="Planta" HeaderText="Planta" SortExpression="Tipo Caso" />
                                <asp:BoundField DataField="FechaMarca" HeaderText="Fecha Falto" SortExpression="Fecha_Caso" />
                                <asp:BoundField DataField="NumeroTurno" HeaderText="Turno" SortExpression="Fecha_Caso" />

                                <asp:TemplateField HeaderText="Confirmar Falto">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_falto" Checked="true" />
                                        <asp:HiddenField runat="server" ID="hf_id_Falto" Value='<%# Eval("id_Falto")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <%--<asp:TemplateField HeaderText="Ver Caso">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_ModificarNovedad" runat="server" OnClick="btn_ModificarNovedad_Click"
                                            CommandArgument='<%#Eval("id_Caso")%>' Text="Ver" CssClass="btn btn-success btn-group-justified" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </div>
        <div class="row" id="pnl_botones" runat="Server">
            <div class="col-md-12">
                <div class="pull-right" id="BotonesModificarLimpiarSolicitud">
                    <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar"></asp:LinkButton>
                    <asp:Button ID="btn_Guardar" runat="server" Text="Confirmar" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>


    <script>
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
    <script type="text/javascript">
        $(function () {
            $('[id*=gdv_Novedades]').footable();
        });
    </script>
</asp:Content>
