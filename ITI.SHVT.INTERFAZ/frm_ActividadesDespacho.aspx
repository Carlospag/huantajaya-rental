<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ActividadesDespacho.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_ActividadesDespacho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <div class="container">
        <asp:UpdatePanel runat="server" ID="upp_Notificacion" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div runat="server" id="pnl_Notificacion" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <strong runat="server" id="lbl_Notificacion1"></strong> <span runat="server" id="lbl_Notificacion2"></span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="panel panel-primary">
            <div class="panel-heading">CLASIFICACIÓN DE ACTIVIDADES DE ENTREGA/RECEPCIÓN SEGÚN FAMILIA DE EQUIPOS</div>
            <asp:UpdatePanel runat="server" ID="upp_Novedades" ChildrenAsTriggers="true" UpdateMode="always">
                <ContentTemplate>
                    <div class="panel-body">
                        <p>En el siguiente panel usted debe clasificar cada actividad de despacho/recepción con su familia de equipos.</p>
                        
                        <asp:SqlDataSource ID="sds_Familias" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" 
                            SelectCommand="up_parque_s_Familias" SelectCommandType="StoredProcedure">
                        </asp:SqlDataSource>
                        
                        <div class="row">
                            <div class="col-md-5">
                                <label for="Area">Familia:</label>
                                <asp:DropDownList runat="server" ID="ddl_Familias" DataSourceID="sds_Familias"  DataValueField="id_Familia"
                                    DataTextField="NombreFamilia" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <section class="panel-body">
                        <div class="row">
                            <div class="col-md-5">
                                <asp:SqlDataSource ID="sds_ActividadesDisponibles" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" 
                                    SelectCommand="up_parque_s_ActividadesDisponibles" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter name="id_Familia" type="Int32"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>

                                <label for="Area">Implementación Asociada:</label>
                                <asp:ListBox runat="server" ID="lbx_ActividadesDisponibles" DataSourceID="sds_ActividadesDisponibles"  DataValueField="id_Actividad"
                                    DataTextField="NombreActividad" CssClass="form-control" SelectionMode="Single" Rows="18"></asp:ListBox>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Button ID="btn_AgregarColaborador" runat="server" CssClass="btn-primary btn btn-group-justified" Text=">>" />
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btn_QuitarColaborador" runat="server" CssClass="btn-primary btn btn-group-justified" Text="<<" />
                                </div>
                            </div>
                            <div class="col-md-5">
                                <asp:SqlDataSource ID="sds_ActividadesXFamilia" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" 
                                    SelectCommand="up_parque_s_ActividadesXfamilia" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter name="id_Familia" type="Int32"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                               <label for="Area">Actividades ya asignadas:</label>
                                <asp:ListBox runat="server" ID="lbx_ActividadesXfamilia" DataSourceID="sds_ActividadesXFamilia"  DataValueField="id_Actividad"
                                    DataTextField="NombreActividad" CssClass="form-control" SelectionMode="Single" Rows="18"></asp:ListBox>
                            </div>
                        </div>
                    </section>    
                </ContentTemplate>
            </asp:UpdatePanel>        
        </div>      
    </div>
</asp:Content>
