<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_RepuestosMantencion.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_RepuestosMantencion" %>

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
                    <strong runat="server" id="lbl_Notificacion1"></strong><span runat="server" id="lbl_Notificacion2"></span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


        <asp:SqlDataSource ID="sds_EquiposXFamilia" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
            SelectCommand="up_parque_s_EquiposXfamilia" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="id_Familia" Type="Int64"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="sds_RepuestosDisponibles" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
            SelectCommand="up_parque_s_RepuestosDisponibles" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>

       

        <div class="panel panel-primary">
            <div class="panel-heading">ACTIVIDADES POR FAMILIA</div>
            <asp:UpdatePanel runat="server" ID="upp_Novedades" ChildrenAsTriggers="true" UpdateMode="always">
                <ContentTemplate>
                    <div class="panel-body">
                        <%--<p>En el siguiente panel usted debe clasificar cada actividad de mantención con su familia de equipos.</p>--%>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label runat="server" id="Label2">Filtrar por familia&nbsp; </label>
                                    <asp:SqlDataSource ID="sds_Familias" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Familias" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                    <asp:DropDownList ID="ddl_Familia" runat="server" CssClass="form-control" DataSourceID="sds_Familias" DataValueField="id_Familia" DataTextField="NombreFamilia" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label runat="server" id="Label4">Seleccione equipo&nbsp; </label>
                                    <asp:DropDownList ID="ddl_Equipos" runat="server" CssClass="form-control" DataSourceID="sds_EquiposXFamilia" DataValueField="id_Equipo" DataTextField="NombreEquipo" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label runat="server" id="Label3">AFI DEL EQUIPO&nbsp;&nbsp;&nbsp;&nbsp; </label>
                                    <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                                    <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_BuscarAfi" readonly="true" runat="server" class="input form-control text-center" required="" />
                                </div>
                            </div>
                        </div>
                        <%--<div class="row">
                            <div class="col-md-12">
                                <div class="pull-right">
                                    <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar filtros" />
                                    <asp:Button ID="btn_BuscarPorAfi" runat="server" Text="Buscar por AFI" CssClass="btn btn-primary" />

                                </div>
                            </div>
                        </div>--%>

                    </div>
                    <section class="panel-body">
                        <div class="row">
                            <div class="col-md-5">

                                <label for="Area">Repuestos disponibles:</label>
                                <asp:ListBox runat="server" ID="lbx_RepuestosDisponibles" DataSourceID="sds_RepuestosDisponibles" DataValueField="id_Repuesto"
                                    DataTextField="NombreRepuesto" CssClass="form-control" SelectionMode="Single" Rows="25"></asp:ListBox>
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
                                <asp:SqlDataSource ID="sds_RepuestosXequipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                                    SelectCommand="up_parque_s_RepuestosXequipo" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
                                    </SelectParameters>
                                </asp:SqlDataSource>
                                <label for="Area">Repuestos asignados:</label>
                                <asp:ListBox runat="server" ID="lbx_RepuestosXequipo" DataSourceID="sds_RepuestosXequipo" DataValueField="id_Repuesto"
                                    DataTextField="NombreRepuesto" CssClass="form-control" SelectionMode="Single" Rows="25"></asp:ListBox>
                            </div>
                        </div>
                    </section>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
