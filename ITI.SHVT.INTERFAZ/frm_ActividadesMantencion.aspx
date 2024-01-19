<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ActividadesMantencion.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_ActividadesMantencion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
            <div class="panel-heading">ACTIVIDADES POR FAMILIA</div>
            <asp:UpdatePanel runat="server" ID="upp_Novedades" ChildrenAsTriggers="true" UpdateMode="always">
                <ContentTemplate>
                    <div class="panel-body">
                        <%--<p>En el siguiente panel usted debe clasificar cada actividad de mantención con su familia de equipos.</p>--%>
                        
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
                                    SelectCommand="up_parque_s_ActividadesDisponiblesMantencion" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter name="id_Familia" type="Int32"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <label for="Area">Actividades disponibles:</label>
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
                                    SelectCommand="up_parque_s_ActividadesXfamiliaMantencion" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter name="id_Familia" type="Int32"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                               <label for="Area">Actividades asignadas:</label>
                                <asp:ListBox runat="server" ID="lbx_ActividadesXfamilia" DataSourceID="sds_ActividadesXFamilia"  DataValueField="id_Actividad"
                                    DataTextField="NombreActividad" CssClass="form-control" SelectionMode="Single" Rows="18"></asp:ListBox>
                            </div>
                        </div>
                    </section>    
                </ContentTemplate>
            </asp:UpdatePanel>        
        </div> 
        <div class="panel panel-success">
            <div class="panel-heading">LUBRICANTES POR FAMILIA</div>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" ChildrenAsTriggers="true" UpdateMode="always">
                <ContentTemplate>
                    <div class="panel-body">
                    </div>
                    <section class="panel-body">
                        <div class="row">
                            <div class="col-md-5">
                                <asp:SqlDataSource ID="sds_LubricantesDisponibles" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" 
                                    SelectCommand="up_parque_s_LubricantesDisponibles" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter name="id_Familia" type="Int32"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <label for="Area">Lubricantes disponibles:</label>
                                <asp:ListBox runat="server" ID="lbx_LubricantesDisponibles" DataSourceID="sds_LubricantesDisponibles"  DataValueField="id_Lubricante"
                                    DataTextField="NombreLubricante" CssClass="form-control" SelectionMode="Single" Rows="8"></asp:ListBox>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Button ID="btn_AgregarLubricante" runat="server" CssClass="btn-primary btn btn-group-justified" Text=">>" />
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btn_QuitarLubricante" runat="server" CssClass="btn-primary btn btn-group-justified" Text="<<" />
                                </div>
                            </div>
                            <div class="col-md-5">
                                <asp:SqlDataSource ID="sds_LubricantesXfamilia" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" 
                                    SelectCommand="up_parque_s_LubricantesXfamilia" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter name="id_Familia" type="Int32"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                               <label for="Area">Lubricantes asignados:</label>
                                <asp:ListBox runat="server" ID="lbx_LubricantesXfamilia" DataSourceID="sds_LubricantesXfamilia"  DataValueField="id_Lubricante"
                                    DataTextField="NombreLubricante" CssClass="form-control" SelectionMode="Single" Rows="8"></asp:ListBox>
                            </div>
                        </div>
                    </section>    
                </ContentTemplate>
            </asp:UpdatePanel>        
        </div>
    </div>
</asp:Content>
