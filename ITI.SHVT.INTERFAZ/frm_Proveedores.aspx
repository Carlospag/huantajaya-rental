<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_Proveedores.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdf_NombreArchivo" runat="server" Visible="false" />
    <asp:HiddenField ID="hdf_Extension" runat="server" Visible="false" />
   
    <div class="container-fluid">
        
        <div class="panel panel-primary" id="pnl_casos" runat="server">
            <div class="panel-heading">Listado Clientes</div>
            <div class="panel-body">
                <%-- <p>A continuación se muestra el listado de casos disponibles en el sistema, usted aquí podra generar las cartas respectivas.</p>--%>
            </div>
            <section>
                <asp:UpdatePanel runat="server" ID="upp_ListaEstadosPago" ChildrenAsTriggers="true" UpdateMode="Conditional">

                    <ContentTemplate>
                        
                        <!-- SQLDataSource a utilizar -->
                        

                        <asp:SqlDataSource ID="sds_Proveedores" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                            SelectCommand="up_parque_s_Proveedores" SelectCommandType="StoredProcedure">
                        </asp:SqlDataSource>

                         <asp:SqlDataSource ID="sds_SoloProveedor" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                        SelectCommand="up_parque_s_SoloProveedor" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter Name="id_Proveedor" Type="Int32"></asp:Parameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <!-- Listar opciones del sistema -->
                        <asp:GridView runat="server" ID="gdv_Proveedores" CssClass="table footable table-hover table-condensed table-center" AutoGenerateColumns="false"
                            GridLines="None" AllowSorting="true">
                            <Columns>
                                <asp:BoundField DataField="NombreProveedor" HeaderText="Proveedor" HeaderStyle-BackColor="#cccccc" />
                                <%--<asp:BoundField DataField="NombreVendedor" HeaderText="Vendedor" HeaderStyle-BackColor="#cccccc" />--%>
                                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" HeaderStyle-BackColor="#cccccc" />

                                <asp:TemplateField HeaderText="" HeaderStyle-BackColor="#cccccc">
                                    <ItemTemplate>
                                        <asp:Button ID="btn_Detalles" runat="server" OnClick="btn_Detalles_Click"
                                            CommandArgument='<%#Eval("id_Proveedor")%>' Text="+" CssClass="btn btn-success btn-group-justified" />
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
     
        <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_Detalles" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 90% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="upp_Modal" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">Información General <span class="modal-span" runat="server" id="lbl_idContrato"></span></p></div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Nombre Proveedor</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_NombreProveedor"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Vendedor</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_NombreVendedor"></span></div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="col-md-4">
                                                        <label for="nombre">Teléfono</label>
                                                    </div>
                                                    <div class="col-md-8"><span class="modal-span" runat="server" id="lbl_Tel"></span></div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="col-md-3">
                                                        <label for="nombre">Estado</label>
                                                    </div>
                                                    <div class="col-md-9"><span class="modal-span" runat="server" id="lbl_Estado"></span></div>
                                                </div>
                                            </div>

                                            
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                         <div class="panel panel-primary">
                            <div class="panel-heading">¿Que vende? ¿Que hace?</div>
                            <div class="panel-body">
                               <div class="row">
                                                <div class="col-md-12"> 
                                                   <textarea runat="server" class="form-control" rows="5" id="txt_Nota" htmlencode="false" readonly="true"></textarea>
                                                </div>
                                            </div>
                                
                        </div>

                       
                    </div>
                         <div class="modal-footer">
                         
                       <button type="button" id="btn_CerrarModal" class="btn btn-default" data-dismiss="modal">Cerrar</button>

                    </div>
                </div>
            </div>
        </div>
      
    </div>


    
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
        });
    </script>
</asp:Content>
