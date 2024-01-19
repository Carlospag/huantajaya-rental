<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_Cotizaciones.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Cotizaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:SqlDataSource ID="sds_ValoresCotizacion" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ValoresCotizaciones" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

     <asp:SqlDataSource ID="sds_CotizacionesXfiltros" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_VerCotizacionesXFiltros" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_TipoCotizacion" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="id_EstadoCotizacion" Type="int32"></asp:Parameter>
                                <asp:Parameter Name="id_Cliente" Type="String"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>


    <asp:sqldatasource id="sds_TipoCotizacion" runat="server" connectionstring="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        selectcommand="up_parque_s_TiposCotizaciones" selectcommandtype="StoredProcedure"></asp:sqldatasource>
     
    <asp:sqldatasource id="sds_Cotizaciones" runat="server" connectionstring="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        selectcommand="up_parque_s_VerCotizaciones" selectcommandtype="StoredProcedure"></asp:sqldatasource>

     <asp:SqlDataSource ID="sds_CotiXID" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_CotiXID" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Cotizacion" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:scriptmanager id="stm_Principal" runat="server"></asp:scriptmanager>
    <asp:hiddenfield id="hdf_NombreArchivo" runat="server" visible="false" />
    <asp:hiddenfield id="hdf_Extension" runat="server" visible="false" />
    <div class="container-fluid">
          
      
        <div class="row">
            <%--<div class="col-md-12">--%>
            <div class="col-md-2">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/img/Generada.png" Height="25px" />&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_Rojo"></asp:Label><asp:Label runat="server" ID="lbl_PorcentajeRojo"></asp:Label>
            </div>
            <div class="col-md-3">
              
            </div>
            <div class="col-md-2">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/img/NoConcretada.png" Height="25px" />&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_Amarillo"></asp:Label><asp:Label runat="server" ID="lbl_PorcentajeAmarillo"></asp:Label>
            </div>
            <div class="col-md-3">
              
            </div>
            <div class="col-md-2">
                <asp:Image ID="Image6" runat="server" ImageUrl="~/Content/img/Aceptada.png" Height="25px" />&nbsp;&nbsp;<asp:Label runat="server" ID="lbl_Verde"></asp:Label><asp:Label runat="server" ID="lbl_PorcentajeVerde"></asp:Label>
            </div>
            <%-- </div>--%>
           
        </div>
         <br />
        
       

        <div class="panel panel-primary">
            <div class="panel-heading">BUSCAR POR:</div>
            <div class="panel-body">
                <div class="panel-body">

                    <div class="row" id="datetimepicker">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label runat="server" id="Label2">Buscar por N° Cotización&nbsp; </label>
                                <span runat="server" style="color: red" id="Span1"></span>
                                <asp:textbox font-size="X-Large" font-bold="true" maxlength="4" id="txt_BuscarXID" runat="server" class="input form-control text-center" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label runat="server" id="Label1">Filtrar por Tipo:</label>
                                <asp:dropdownlist id="ddl_TipoCotizacion" runat="server" cssclass="form-control" datasourceid="sds_TipoCotizacion" datavaluefield="id_TipoCotizacion" datatextfield="NombreTipoCotizacion">
                                </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label runat="server" id="Label16">Filtrar por Estado:&nbsp; </label>
                                <asp:dropdownlist id="ddl_Estados" runat="server" cssclass="form-control">
                                <asp:ListItem Value="0">GENERADAS</asp:ListItem>
                                <asp:ListItem Value="1">APROBADAS</asp:ListItem>
                                <asp:ListItem Value="2">CONCRETADAS</asp:ListItem>
                                <asp:ListItem Value="3">ANULADAS</asp:ListItem>
                                <asp:ListItem Value="4">NO CONCRETADAS</asp:ListItem>
                            </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label runat="server" id="Label17">Filtrar por Cliente:&nbsp; </label>
                                <asp:sqldatasource id="sds_ListadoClientes" runat="server" connectionstring="<%$ ConnectionStrings:SHVTBDConnectionString %>" selectcommand="up_parque_s_ListaClientesCotizaciones" selectcommandtype="StoredProcedure"></asp:sqldatasource>

                                <asp:dropdownlist id="ddl_Clientes" runat="server" CssClass="form-control chosen-select" datasourceid="sds_ListadoClientes" datavaluefield="RutCliente" datatextfield="NombreCliente">
                            </asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="pull-left">
                                <asp:linkbutton id="btn_BuscarPorID" runat="server" text="Buscar Por N° Cotización" cssclass="btn btn-info" />

                            </div>
                            <div class="pull-right">
                                <%--<asp:LinkButton runat="server" ID="btn_Informe" CssClass="btn btn-default">  <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> </asp:LinkButton>--%>
                                <asp:linkbutton runat="server" id="btn_Limpiar" cssclass="btn btn-default" text="Limpiar filtros" />
                                <asp:linkbutton runat="server" id="btn_filtrar" cssclass="btn btn-primary" text="Filtrar" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">

        <div class="panel panel-primary" id="pnl_casos" runat="server">
            <div class="panel-heading">COTIZACIONES</div>
            <div class="panel-body">
                <%-- <p>A continuación se muestra el listado de casos disponibles en el sistema, usted aquí podra generar las cartas respectivas.</p>--%>
            </div>
            <section>
                <asp:updatepanel runat="server" id="upp_Novedades" childrenastriggers="true" updatemode="Conditional">

                    <ContentTemplate>
                        <div runat="server" id="pnl_mensaje" visible="false" class="alert alert-link alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong runat="server" id="lbl_mensaje1"></strong><span runat="server" id="lbl_mensaje2"></span>
                        </div>

                        <!-- Listar opciones del sistema -->
                        <asp:GridView runat="server" ID="gdv_Cotizaciones" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="id_Cotizacion" HeaderStyle-BackColor="#cccccc" HeaderText="N° COT." ControlStyle-Font-Bold="true" />
                                <asp:BoundField DataField="FechaCotizacion" HeaderStyle-BackColor="#cccccc" HeaderText="FECHA COTIZACIÓN" ControlStyle-Font-Bold="true" />
                                <asp:BoundField DataField="NombreCliente" HeaderStyle-BackColor="#cccccc" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="NotSet" HeaderText="CLIENTE" />
                                <asp:BoundField DataField="NombreEquipo" HeaderStyle-BackColor="#cccccc" HeaderText="EQUIPO" />
                                <asp:BoundField DataField="NombreTipoCotizacion" HeaderStyle-BackColor="#cccccc" ItemStyle-VerticalAlign="NotSet" HeaderText="TIPO COTIZACIÓN" />
                                <asp:BoundField DataField="EstadoCotizacion" HeaderStyle-BackColor="#cccccc" HeaderText="ESTADO COTIZACIÓN" />
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_AprobarOC" Style="width: 45px" runat="server" OnClick="btn_AprobarOC_Click"
                                            CommandArgument='<%#Eval("id_Cotizacion")%>' Enabled='<%# If(Session("id_Usuario") = "2" Or Session("id_Usuario") = "3", True, False)%>' Text="E" Visible='<%# If(Eval("EstadoCotizacion").ToString() = "GENERADA", True, False)%>' CssClass="btn btn-success btn-group-justified"> <span class="glyphicon glyphicon-thumbs-up" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="50px" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btn_DescargarOT" Style="width: 45px" runat="server" OnClick="btn_DescargarOT_Click"
                                            CommandArgument='<%#Eval("id_Cotizacion")%>'   Text="A" CssClass="btn btn-primary btn-group-justified "><span class="glyphicon glyphicon-save" aria-hidden="true"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                </asp:updatepanel>
            </section>
        </div>
        <!-- Botones Guardar y Limpiar -->
        <div class="row" id="pnl_botones" runat="server">
            <div class="col-md-12">
                <div class="pull-right">
                    <%-- <asp:LinkButton runat="server" ID="btn_Informe" CssClass="btn btn-default">  <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span> </asp:LinkButton>--%>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-6">
                <div id="DivMensajeAdvertenciaGuardado">
                    <asp:panel id="pnl_MensajeAdvertenciaGuardado" runat="server" visible="false">
                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                        <asp:Label ID="lbl_MensajeAdvertenciaGuardado" Text="GUARDADO CON ÉXITO!" runat="server" Font-Size="XX-Large" />
                    </asp:panel>
                </div>
            </div>
            <div class="col-md-3"></div>

        </div>

        <script>
            $("#<%=pnl_MensajeAdvertenciaGuardado.ClientID%>").delay(3000).fadeTo(500, 0);
        </script>
    </div>





    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet">
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">

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
        $('.chosen-select').chosen();
        });
    </script>
</asp:Content>
