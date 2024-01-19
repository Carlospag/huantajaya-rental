<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_EstadosDePago.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_EstadosDePago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">--%>

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
    
     <asp:SqlDataSource ID="sds_EDPproyectado" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_EstadosDePagoFiltradosFlotante" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
                                <asp:Parameter Name="Periodo" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="Anho" Type="String"></asp:Parameter>
                                <asp:Parameter Name="Sucursal" Type="String"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>

    
    <div class="container-fluid">
        <div class="panel panel-primary">
            <div class="panel-heading">BUSCAR POR:</div>
            <div class="panel-body">
                <%--<p>A continuación deberá indicar el periodo para consultar casos.</p>--%>
                <%--<section class="cuerpo-informe">--%>
                <div class="row">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="Label1">Buscar por AFI&nbsp; </label>
                            <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_BuscarAfi" runat="server" class="input form-control text-center" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="Label4">Buscar por EDP&nbsp; </label>
                            <span runat="server" style="color: red" id="Span2"></span>
                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" ID="txt_BuscarEDP" runat="server" class="input form-control text-center" />
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
                    <div class="col-md-1">
                        <div class="form-group">
                            <div class="">
                                <label runat="server" id="Label6">Sucursal:</label>
                                

                                <asp:DropDownList ID="ddl_SucursalesFiltro" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label runat="server" id="lbl_Anho">Periodo:</label>
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
                    <div class="col-md-1">
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
                            <asp:LinkButton runat="server" ID="btn_BuscarPorAfi" CssClass="btn btn-info" Text="Buscar Por AFI" />
                            <asp:LinkButton runat="server" ID="btn_BuscarPorEDP" CssClass="btn btn-info" Text="Buscar Por EDP" /><asp:Label runat="server" Visible="false" ID="lbl_ProyeccionEDP"></asp:Label>
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
        <div class="row">
            <div class="col-md-12">
                <div class="pull-left">
                    <asp:LinkButton runat="server" ID="btn_Nuevo" CssClass="btn btn-success" Text="Nuevo"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></asp:LinkButton>
                </div>
                <%-- <div class="pull-right">
                            
                        </div>--%>
            </div>
        </div>
        <%--<br />--%>
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
                            SelectCommand="up_parque_s_EstadosDePagoFiltrados" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="RutCliente" Type="String"></asp:Parameter>
                                <asp:Parameter Name="Periodo" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="Anho" Type="String"></asp:Parameter>
                                <asp:Parameter Name="Sucursal" Type="String"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <asp:SqlDataSource ID="sds_EstadoPagoxAFI" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_EstadoDePagoxAFI" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="Afi" Type="Int64"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <asp:SqlDataSource ID="sds_EstadoPAgoXID" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_EstadosPagoXidEPEstadosPago" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_EstadoPago" Type="Int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>

                        <asp:SqlDataSource ID="sds_EstadoPagoXEDP" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_EstadosPagoXEDP" SelectCommandType="StoredProcedure">
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
                                <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="NombreEquipo" HeaderText="Equipo" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="id_Equipo" HeaderText="AFI" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="FechaInicio" HeaderText="F. Inicio" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="FechaFin" ItemStyle-VerticalAlign="NotSet" HeaderText="F. Fin" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="Tarifa" ItemStyle-VerticalAlign="NotSet" HeaderText="Tarifa" HeaderStyle-BackColor="#cccccc" />
                                <%--<asp:BoundField DataField="HorasFacturar" ItemStyle-VerticalAlign="NotSet" HeaderText="Horas Fact." HeaderStyle-BackColor="#cccccc" />--%>
                                <asp:BoundField DataField="DiasFacturar" ItemStyle-VerticalAlign="NotSet" HeaderText="Dias Fact." HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="TipoCobro" HeaderText="Tipo Pago" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="ValorNeto" ItemStyle-Font-Bold="true" HeaderText="Total Neto" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="IVA" ItemStyle-Font-Bold="true" HeaderText="iva" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="ValorTotal" ItemStyle-Font-Bold="true" HeaderText="Total" HeaderStyle-BackColor="#cccccc" />
                                <asp:BoundField DataField="EstadoComercial" HeaderText="Estado Comercial" HeaderStyle-BackColor="#cccccc" />

                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_ConfirmarEP" Style="width: 45px" runat="server" OnClick="btn_ConfirmarEP_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Eval("EstadoComercial").ToString() = "Pendiente", True, False)%>' Text="E" CssClass="btn btn-success btn-group-justified"> <span class="glyphicon glyphicon-ok" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_ModificarEP" Style="width: 45px" runat="server" OnClick="btn_ModificarEP_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Eval("EstadoComercial").ToString() = "Pendiente", True, False)%>' Text="A" CssClass="btn btn-warning btn-group-justified"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_EliminarEP" Style="width: 45px" runat="server" OnClick="btn_EliminarEP_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Eval("EstadoComercial").ToString() = "Pendiente", True, False)%>' Text="A" CssClass="btn btn-danger btn-group-justified "><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_Facturar" Style="width: 45px" runat="server" OnClick="btn_Facturar_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Visible='<%# If(Eval("EstadoComercial").ToString() = "Aceptado", True, False)%>' Text="A" CssClass="btn btn-info btn-group-justified "><span class="glyphicon glyphicon-usd" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_DescargarEP" Style="width: 45px" runat="server" OnClick="btn_DescargarEP_Click"
                                            CommandArgument='<%#Eval("id_EstadoDePago")%>' Text="A" CssClass="btn btn-primary btn-group-justified "><span class="glyphicon glyphicon-save" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_edp" Visible='<%# If((ddl_Clientes.SelectedIndex = 0 Or ddl_periodo.SelectedIndex = 0), False, True)%>' Checked="true" />
                                        <asp:HiddenField runat="server" ID="hf_edp" Value='<%# Eval("id_EstadoDePago")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                    <asp:LinkButton runat="server" ID="btn_DescargarSeleccion" CssClass="btn btn-primary" Text="Descargar Selección" />
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

        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_VerEstadosPago" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 90% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_modalEstadoPago" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <b style="color: aqua">ESTADO PAGO:</b>  <span class="modal-span" runat="server" id="lbl_NumeroEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <b style="color: aqua">CONTRATO:</b> <span class="modal-span" runat="server" id="lbl_idContratoEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        <b style="color: aqua">EQUIPO:</b> <span class="modal-span" runat="server" id="lbl_NombreEquipoEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <b style="color: aqua">MODELO: </b><span class="modal-span" runat="server" id="lbl_ModeloEquipoEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      
                                        <b style="color: aqua">AFI :</b> <span class="modal-span" runat="server" id="lbl_AfiEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <b style="color: aqua">FAENA:</b> <span class="modal-span" runat="server" id="lbl_FaenaEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <b style="color: aqua">TIPO:</b> <span class="modal-span" runat="server" id="lbl_TipoEP"></span></p>
                                    </div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <label for="nombre">Fecha Inicio </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label runat="server" id="lbl_fechaFin" for="nombre">Fecha Término </label>
                                                </div>
                                              
                                                 <div class="col-md-1">
                                                    <label runat="server" id="lbl_SucursalEditarEDP" for="nombre" visible="false">Sucursal </label>
                                                </div>
                                                 
                                                <div class="col-md-1">
                                                    <label for="nombre">Tarifa</label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Horas Fact.</label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Días fact.</label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Modalidad</label>
                                                </div>
                                               
                                                <div class="col-md-1">
                                                    <label for="nombre">Valor Neto </label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Iva </label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Valor Total</label>
                                                </div>
                                            </div>

                                            <div class="row ">
                                                <div class="col-md-2 input-daterange">
                                                    <asp:TextBox ID="txt_Fecha_InicioEP" onkeydown="return false;" runat="server" Placeholder="dd/mm/yyyy" class="input form-control" />
                                                </div> 
                                                
                                                <div class="col-md-2 input-daterange">
                                                    <asp:TextBox ID="txt_Fecha_FinEP" onkeydown="return false;" runat="server" Placeholder="dd/mm/yyyy" class="input form-control" />
                                                </div>
                                                
                                                <div class="col-md-1">
                                                    <asp:DropDownList ID="ddl_SucursalEditarEDP" runat="server" CssClass="form-control" Visible="false" >
                                                        <asp:ListItem Value="1">Iquique</asp:ListItem>
                                                        <asp:ListItem Value="2">Arica</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                 
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_TarifaEP" AutoPostBack="TRUE" Font-Bold="true" runat="server" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_HorasFacturarEP" runat="server" AutoPostBack="true" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">

                                                    <div class="col-md-4">
                                                        <asp:LinkButton ID="btn_CalcularDias" Style="width: 40px" runat="server"
                                                            Class="btn btn-success"> <span class="glyphicon glyphicon-calendar" aria-hidden="true"></span> </asp:LinkButton>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txt_DiasFacturarEP" Font-Bold="true" runat="server" AutoPostBack="true" class="input form-control" />
                                                    </div>

                                                </div>
                                                <div class="col-md-1">
                                                    <asp:DropDownList ID="ddl_ModoCobroEP" runat="server" CssClass="form-control" AutoPostBack="true">
                                                        <asp:ListItem Value="1">Mensual</asp:ListItem>
                                                        <asp:ListItem Value="2">Diario</asp:ListItem>
                                                        <asp:ListItem Value="3">Proporcional</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_ValorNetoEP" AutoPostBack="true" ReadOnly="true" Font-Bold="TRUE" runat="server" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_ivaEP" ReadOnly="TRUE" runat="server" Font-Bold="TRUE" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_ValorTotalEP" Rows="3" runat="server" ReadOnly="true" Font-Bold="TRUE" class="input form-control" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-10">
                                                <label runat="server" id="lbl_Descripcion">Observaciones adicionales&nbsp;</label>
                                                <textarea runat="server" class="form-control" rows="2" id="txt_Observaciones" htmlencode="false"></textarea>
                                            </div>
                                            <div class="col-md-2">
                                                <div class="pull-right">
                                                    <br />
                                                    <br />
                                                    <asp:LinkButton runat="server" ID="btn_LimpiarEP" CssClass="btn btn-default" Text="Limpiar" />
                                                    <%--<asp:Button runat="server" ID="btn_ModificarEstadoPago" CssClass="btn btn-warning" Text="Editar EP" Visible="false" />--%>
                                                    <asp:LinkButton runat="server" ID="btn_ModificarEstadoPago" CssClass="btn btn-warning" Text="Editar EP" Visible="false" />
                                                    <asp:Button ID="btn_GuardarEP" runat="server" Text="Guardar EP" CssClass="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4"></div>
                                    <div class="col-md-4">
                                        <b style="color: darkred"><span class="modal-span" runat="server" id="lbl_ActualizadoError" visible="FALSE"></span></b>
                                        <b style="color: green"><span class="modal-span" runat="server" id="lbl_Actualizado" visible="FALSE"></span></b>
                                    </div>
                                    <div class="col-md-4"></div>
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

        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_NFactura" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 18% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_nfactura" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <b style="color: aqua">ESTADO PAGO:</b>  <span class="modal-span" runat="server" id="lbl_NEP"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                               <b style="color: aqua">TIPO:</b> <span class="modal-span" runat="server" id="lbl_TipoEstadoDePago"></span></p></p>
                                    </div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="nombre">Número Factura </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txt_NFactura" runat="server" Font-Size="X-Large" Font-Bold="true" class="input form-control text-center" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="nombre">Fecha Facturación </label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12 input-daterange">
                                                    <asp:TextBox MaxLength="10" ID="txt_FechaFacturacion" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label runat="server" id="Label5">Sucursal&nbsp; </label>
                                                        <label style="color: red">*</label>
                                                        <asp:SqlDataSource ID="sds_Sucursales" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                                        <asp:DropDownList ID="ddl_Sucursal" runat="server" CssClass="form-control" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal" AutoPostBack="true" required="true">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />

                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="pull-right">
                                                    <asp:LinkButton runat="server" ID="btn_GuardarNFactura" CssClass="btn btn-primary" Text="Guardar" />
                                                 
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <b style="color: green"><span class="modal-span" runat="server" id="lbl_NumeroFacturaEXITO" visible="FALSE"></span></b>
                                        <b style="color: darkred"><span class="modal-span" runat="server" id="lbl_NumeroFacturaERROR" visible="FALSE"></span></b>
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

        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_NuevoEP" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 95% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <b style="color: aqua">NUEVO ESTADO DE PAGO</b>  <span class="modal-span" runat="server" id="Span1"></span></p>
                                    </div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>

                                            <div class="row">
                                                <div class="col-md-1">
                                                    <label for="nombre">Tipo</label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label for="nombre">Cliente</label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">AFI</label>
                                                    <span runat="server" style="color: red" id="lbl_ErrorAfiNuevo"></span>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Fecha</label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Sucursal</label>
                                                </div>

                                                <div class="col-md-1">
                                                    <label for="nombre">Tarifa </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label for="nombre">Valor Neto </label>
                                                </div>
                                                <div class="col-md-1">
                                                    <label for="nombre">Iva </label>
                                                </div>
                                                <div class="col-md-2">
                                                    <label for="nombre">Valor Total</label>
                                                </div>
                                            </div>

                                            <div class="row ">
                                                <div class="col-md-1">
                                                    <asp:DropDownList ID="ddl_TipoEPnuevo" runat="server" CssClass="form-control" required="true">
                                                        <asp:ListItem Value="2">Servicio Técnico</asp:ListItem>
                                                        <asp:ListItem Value="3">Venta</asp:ListItem>
                                                        <asp:ListItem Value="4">Transporte</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-2">

                                                    <asp:DropDownList ID="ddl_ClienteNuevo" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_ListadoClientes" DataValueField="RutCliente" DataTextField="NombreCliente">
                                                    </asp:DropDownList>



                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_AFInuevo" runat="server" Font-Bold="true" class="input form-control text-center" required="true" AutoPostBack="true" />
                                                </div>

                                                <div class="col-md-1 input-daterange">

                                                    <asp:TextBox ID="txt_FechaEPnuevo" onkeydown="return false;" runat="server" Placeholder="dd/mm/yyyy" class="input form-control" required="true" />
                                                </div>
                                               <div class="col-md-1">

                                                    <asp:DropDownList ID="ddl_SucursalEDPnuevo" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal">
                                                    </asp:DropDownList>



                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_TarifaEPnuevo" AutoPostBack="TRUE" Font-Bold="true" runat="server" class="input form-control" required="true" />
                                                </div>

                                                <div class="col-md-2">
                                                    <asp:TextBox ID="txt_NETOEPnuevo" AutoPostBack="true" ReadOnly="true" Font-Bold="TRUE" runat="server" class="input form-control" />
                                                </div>
                                                <div class="col-md-1">
                                                    <asp:TextBox ID="txt_IVAEPnuevo" ReadOnly="TRUE" runat="server" Font-Bold="TRUE" class="input form-control" />
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:TextBox ID="txt_TOTALnuevo" Rows="3" runat="server" ReadOnly="true" Font-Bold="TRUE" class="input form-control" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <label runat="server" id="Label2">Observaciones adicionales&nbsp;</label>
                                                <textarea runat="server" class="form-control" rows="2" id="txt_ObservacionesNuevo" htmlencode="false"></textarea>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="pull-right">
                                                    <br />
                                                    <br />
                                                    <asp:LinkButton runat="server" ID="btn_LimpiarEPnuevo" CssClass="btn btn-default" Text="Limpiar" />
                                                    <asp:Button ID="btn_GuardarEPnuevo" runat="server" Text="Guardar EP" CssClass="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" />
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4"></div>
                                    <div class="col-md-4">
                                        <b style="color: green"><span class="modal-span" runat="server" id="lbl_ExitoGuardarNuevoEP" visible="FALSE"></span></b>
                                        <b style="color: darkred"><span class="modal-span" runat="server" id="lbl_ErrorGuardarNuevoEP" visible="FALSE"></span></b>
                                    </div>
                                    <div class="col-md-4"></div>
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
