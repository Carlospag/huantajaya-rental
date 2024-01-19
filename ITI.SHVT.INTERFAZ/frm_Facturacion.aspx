<%@ Page Title="FACTURACIÓN" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_Facturacion.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />

    <asp:SqlDataSource ID="sds_FacturacionProyectadaReal" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_FacturacionProyectadaReal" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

    <div class="container-fluid">

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary">
            <div class="panel-heading">BUSCAR POR:</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="Label1">Buscar por N° Factura&nbsp; </label>
                            <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_BuscarAfi" runat="server" class="input form-control text-center" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="Label2">Factura a Pagar&nbsp; </label>
                            <span runat="server" style="color: red" id="Span1"></span>
                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="4" ID="txt_FacturaAPagar" runat="server" class="input form-control text-center" />
                        </div>
                    </div>

                    <div class="col-md-1">
                        <div class="form-group">
                            <center><b></b></center>
                            <br />
                            <center><b>-</b></center>
                        </div>
                    </div>
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
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="lbl_Anho">Mes de facturación:</label>
                            <asp:DropDownList ID="ddl_periodo" runat="server" CssClass="form-control">
                                <asp:ListItem Value="01">Enero</asp:ListItem>
                                <asp:ListItem Value="02">Febrero</asp:ListItem>
                                <asp:ListItem Value="03">Marzo</asp:ListItem>
                                <asp:ListItem Value="04">Abril</asp:ListItem>
                                <asp:ListItem Value="05">Mayo</asp:ListItem>
                                <asp:ListItem Value="06">Junio</asp:ListItem>
                                <asp:ListItem Value="07">Julio</asp:ListItem>
                                <asp:ListItem Value="08">Agosto</asp:ListItem>
                                <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                <asp:ListItem Value="10">Octubre</asp:ListItem>
                                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                <asp:ListItem Value="12">Diciembre</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="Label3">Año:</label>
                            <asp:DropDownList ID="DDL_ANHO" runat="server" CssClass="form-control">
                                <asp:ListItem Value="2020">2020</asp:ListItem>
                                <asp:ListItem Value="2021">2021</asp:ListItem>
                                <asp:ListItem Value="2022">2022</asp:ListItem>
                                <asp:ListItem Value="2023">2023</asp:ListItem>
                                            <asp:ListItem Value="2024">2024</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="pull-left">
                            <asp:LinkButton runat="server" ID="btn_BuscarPorAfi" CssClass="btn btn-info" Text="Buscar Por N° Factura" />
                            <asp:LinkButton runat="server" ID="btn_PagarFacturas" CssClass="btn btn-danger" Text="Pagar Factura" /><asp:Label runat="server" Visible="false" ID="lbl_Proyeccion"></asp:Label>
                        </div>
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                            <asp:LinkButton runat="server" ID="btn_filtrar" CssClass="btn btn-primary" Text="Filtrar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">

            </div>
        </div>

        

    </div>
    <div class="container-fluid">
        <asp:UpdatePanel runat="server" ID="upp_Notificacion" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div runat="server" id="pnl_Notificacion" visible="false" class="alert alert-success alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <strong runat="server" id="lbl_Notificacion1"></strong><span runat="server" id="lbl_Notificacion2"></span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="panel panel-primary" id="pnl_casos" runat="server">
            <div class="panel-heading">ESTADOS DE PAGO</div>
            <div class="panel-body">
                <%-- <p>A continuación se muestra el listado de casos disponibles en el sistema, usted aquí podra generar las cartas respectivas.</p>--%>
            </div>
            <section>
                <asp:UpdatePanel runat="server" ID="upp_ListaEstadosPago" ChildrenAsTriggers="true" UpdateMode="Conditional">

                    <ContentTemplate>
                        <div runat="server" id="pnl_mensaje" visible="false" class="alert alert-link alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong runat="server" id="lbl_mensaje1"></strong><span runat="server" id="lbl_mensaje2"></span>
                        </div>
                        <!-- SQLDataSource a utilizar -->
                        <asp:SqlDataSource ID="sds_EstadosPago" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_EstadosDePagoFiltradosFactura" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
                                <asp:Parameter Name="Periodo" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="Anho" Type="String"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <asp:SqlDataSource ID="sds_EstadoPagoxFactura" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_EstadosDePagoxFactura" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="Factura" Type="Int64"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <asp:SqlDataSource ID="sds_EstadoPAgoXID" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_EstadosPagoXidEPEstadosPago" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_EstadoPago" Type="Int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <!-- Listar opciones del sistema -->
                        <asp:GridView runat="server" ID="gdv_EstadosPago" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="id_EstadoDePago" HeaderText="N°" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="NumeroFactura" HeaderText="Factura" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="NombreEquipo" HeaderText="Equipo" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="id_Equipo" HeaderText="AFI" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="FechaInicio" HeaderText="F. Facturación" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="DiasPendientes" HeaderText="Dias Pendientes" HeaderStyle-BackColor="#cccccc" />
                                <%--<asp:BoundField DataField="FechaFin" ItemStyle-VerticalAlign="NotSet" HeaderText="F. Fin" HeaderStyle-BackColor="#cccccc" />--%>
                                <%--<asp:BoundField DataField="Tarifa" ItemStyle-VerticalAlign="NotSet" HeaderText="Tarifa" HeaderStyle-BackColor="#cccccc" />--%>
                                <%--<asp:BoundField DataField="HorasFacturar" ItemStyle-VerticalAlign="NotSet" HeaderText="Horas Fact." HeaderStyle-BackColor="#cccccc" />--%>
                                <%--<asp:BoundField DataField="DiasFacturar" ItemStyle-VerticalAlign="NotSet" HeaderText="Dias Fact." HeaderStyle-BackColor="#cccccc" />--%>
                                <asp:BoundField DataField="TipoEstadoPago" HeaderText="Tipo" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="ValorNeto" ItemStyle-Font-Bold="true" HeaderText="Total Neto" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="IVA" ItemStyle-Font-Bold="true" HeaderText="IVA" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="ValorTotal" ItemStyle-Font-Bold="true" HeaderText="Total" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="EstadoComercial" HeaderText="Estado Comercial" HeaderStyle-BackColor="#cccccc" Visible="false" />

                                <%--<asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_ConfirmarEP" Style="width: 45px" runat="server" OnClick="btn_ConfirmarEP_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Eval("EstadoComercial").ToString() = "Pendiente", True, False)%>' Text="E" CssClass="btn btn-success btn-group-justified"> <span class="glyphicon glyphicon-ok" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_EliminarEP" Style="width: 45px" runat="server" OnClick="btn_EliminarEP_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Eval("EstadoComercial").ToString() = "Pendiente", True, False)%>' Text="A" CssClass="btn btn-danger btn-group-justified "><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="" Visible="true"  HeaderStyle-Width="150px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_Facturar" runat="server" OnClick="btn_Facturar_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Enabled="false" CssClass='<%#IIf(Eval("EstadoComercial") = "Facturado", "btn btn-danger btn-group-justified", "btn btn-success btn-group-justified")%>' Text='<%#IIf(Eval("EstadoComercial") = "Facturado", "Pagar", "Pagada")%>' /></asp:LinkButton>
                                             <%--CommandArgument='<%#Eval("id_EstadoDePago")%>' Enabled='<%# If(Eval("EstadoComercial").ToString() = "Facturado", True, False)%>' CssClass='<%#IIf(Eval("EstadoComercial") = "Facturado", "btn btn-danger btn-group-justified", "btn btn-success btn-group-justified")%>' Text='<%#IIf(Eval("EstadoComercial") = "Facturado", "Pagar", "Pagada")%>' /></asp:LinkButton>--%>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="150px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_Abonar" runat="server" OnClick="btn_Abonar_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Session("id_TipoCargo") = "3", True, False)%>' Enabled='<%# If(Eval("EstadoComercial").ToString() = "Facturado", True, False)%>' CssClass='<%#IIf(Eval("EstadoComercial") = "Facturado", "btn btn-default btn-group-justified", "btn btn-default btn-group-justified")%>' Text='<%#IIf(Eval("EstadoComercial") = "Facturado", "Abonar", "Abonar")%>' /></asp:LinkButton>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%-- <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_DescargarEP" Style="width: 45px" runat="server" OnClick="btn_DescargarEP_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Text="A" CssClass="btn btn-primary btn-group-justified "><span class="glyphicon glyphicon-save" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                        <%--<asp:FileUpload ID="FileUpload1" runat="Server" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>
        </div>
        <!-- Botones Guardar y Limpiar -->
        <div class="row" id="pnl_botones" runat="server">
            <div class="col-md-12">
                <div class="pull-right">
                    <%--<asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />--%>
                    <%--<asp:Button ID="btn_Guardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" data-toggle="modal" />--%>
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

        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_Aviso" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 30% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_Aviso" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <span style="visibility: hidden" class="modal-span" runat="server" id="lbl_NumeroEP"></span>
                                    </div>
                                    <div class="panel-body">

                                      
                                             <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <label for="nombre">Fecha Pago </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6 input-daterange">
                                                    <asp:TextBox MaxLength="10" ID="txt_FechaPago" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                        

                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="nombre">Antes de confirmar el pago, asegúrese de que el dinero este acreditado en la cuenta bancaria.<br />
                                                    </label>
                                                    <label for="nombre">Si esta seguro presione <b>"CONFIRMAR PAGO"</b>, de lo contrario presione <b>"CERRAR"</b> </label>
                                                </div>
                                            </div>

                                            <br />

                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:LinkButton runat="server" ID="btn_Confirmar" CssClass="btn btn-primary" Text="Confirmar Pago" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <b style="color: green"><span class="modal-span" runat="server" id="lbl_PagoFacturaEXITO" visible="FALSE"></span></b>
                                        <b style="color: darkred"><span class="modal-span" runat="server" id="lbl_PagoFacturaERROR" visible="FALSE"></span></b>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-footer">
                        <%--<asp:Button ID="btn_FinalizarContrato" runat="server" Text="Finalizar Contrato" CssClass="btn btn-danger" data-toggle="modal" data-target="#exampleModalCenter" />--%>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_Abono" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 30% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <span class="modal-span" runat="server" id="lbl_NumeroEPAbono"></span>
                                    </div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="nombre">Antes de confirmar el abono, asegúrese de que el dinero este acreditado en la cuenta bancaria.<br />
                                                    </label>
                                                    <label for="nombre">Si esta seguro presione, ingrese el valor abonado y presione <b>"CONFIRMAR ABONO"</b>, de lo contrario presione <b>"CERRAR"</b> </label>
                                                </div>
                                            </div>
                                             <div class="row">
                                            <br />
                                            <div class="col-md-6"><label runat="server" id="Label4">Valor Abonado&nbsp; </label>
                                            <span runat="server" style="color: red" id="Span6"></span>
                                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="9" ID="txt_ValorAbonado" runat="server" class="input form-control text-center" /></div>

                                             </div>
                                            <br />

                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:LinkButton runat="server" ID="btn_ConfirmarAbono" CssClass="btn btn-primary" Text="Confirmar Abono" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <b style="color: darkred"><span class="modal-span" runat="server" id="lbl_AbonoFacturaERRORTodos" visible="FALSE"></span></b>
                                        <b style="color: green"><span class="modal-span" runat="server" id="lbl_AbonoFacturaEXITOTodos" visible="FALSE"></span></b>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-footer">
                        <%--<asp:Button ID="btn_FinalizarContrato" runat="server" Text="Finalizar Contrato" CssClass="btn btn-danger" data-toggle="modal" data-target="#exampleModalCenter" />--%>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>


        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_ConfirmarPagoTodos" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 30% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <span style="visibility: hidden" class="modal-span" runat="server" id="Span2"></span>
                                    </div>
                                    <div class="panel-body">

                                           <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <label for="nombre">Fecha Pago </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6 input-daterange">
                                                    <asp:TextBox MaxLength="10" ID="txt_FechaPagoTodos" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                      
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="nombre">Antes de confirmar el pago, asegúrese de que el dinero este acreditado en la cuenta bancaria.<br />
                                                    </label>
                                                    <label for="nombre">Si esta seguro presione <b>"CONFIRMAR PAGO"</b>, de lo contrario presione <b>"CERRAR"</b> </label>
                                                </div>
                                            </div>

                                            <br />

                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <asp:LinkButton runat="server" ID="btn_ConfirmarPagoTodasFacturas" CssClass="btn btn-primary" Text="Confirmar Pago" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <b style="color: darkred"><span class="modal-span" runat="server" id="lbl_PagoFacturaERRORTodos" visible="FALSE"></span></b>
                                        <b style="color: green"><span class="modal-span" runat="server" id="lbl_PagoFacturaEXITOTodos" visible="FALSE"></span></b>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-footer">
                        <%--<asp:Button ID="btn_FinalizarContrato" runat="server" Text="Finalizar Contrato" CssClass="btn btn-danger" data-toggle="modal" data-target="#exampleModalCenter" />--%>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>

    </div>


    <script>
        $("#<%=pnl_MensajeAdvertenciaGuardado.ClientID%>").delay(3000).fadeTo(500, 0);
    </script>
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
