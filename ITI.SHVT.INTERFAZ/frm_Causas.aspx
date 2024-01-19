<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_Causas.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Causas" %>

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
        <asp:UpdatePanel runat="server" ID="upp_agregar" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">AGREGAR CAUSAS</div>
                    <div class="panel-body">
                        <p>A continuación podrá ingresar nuevas causas al sistema.</p>

                        <section class="cuerpo-informe">
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="NombreUsuario">Nombre Causa: </label>
                                        <asp:TextBox runat="server" ID="txt_NombreCausa" CssClass="form-control" pattern="[A-Za-zñÑáéíóúÁÉÍÓÚ\s ]+" title="Sólo se permiten letras." required></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_Motivo">Detalle:</label>
                                        <textarea runat="server" class="form-control" rows="6" id="txt_Motivo" required="required" htmlencode="false"></textarea>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-12">
                                    <div class="pull-right">
                                        <asp:LinkButton ID="btn_AgregarCausa" runat="server" Text="Agregar Causa" CssClass="btn btn-primary" />
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upp_modificar" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">MODIFICAR CAUSAS</div>
                    <div class="panel-body">
                        <p>A continuación podrá modificar las causas que estan actualmente en el sistema.</p>

                        <section class="cuerpo-informe">
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label>Causales:</label>
                                        <asp:SqlDataSource ID="sds_ListadoCausales" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_shvt_s_ListaTiposCausas2" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                        <asp:DropDownList ID="ddl_Causales" runat="server" CssClass="form-control" DataSourceID="sds_ListadoCausales" DataValueField="id_TipoCausa" DataTextField="NombreCausa" required="true" AutoPostBack="true">
                                        </asp:DropDownList><br />
                                        <label for="NombreUsuario">Nombre Causa: </label>
                                        <asp:TextBox runat="server" ID="txt_NombreCausaUPP" CssClass="form-control" pattern="[A-Za-zñÑáéíóúÁÉÍÓÚ\s ]+" title="Sólo se permiten letras." required></asp:TextBox><br />
                                        <label for="NombreUsuario">Estado Causa: </label>
                                        <asp:DropDownList ID="ddl_Estado" runat="server" CssClass="form-control" required>
                                            <asp:ListItem Value="1">Activa</asp:ListItem>
                                            <asp:ListItem Value="0">Inactiva</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-7">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_Detalle">Detalle:</label>
                                        <textarea runat="server" class="form-control" rows="6" id="txt_Detalle" required="required" htmlencode="false"></textarea>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-12">
                                    <div class="pull-right">

                                        <asp:LinkButton ID="btn_ModificarCausas" runat="server" Text="Modificar Causa" CssClass="btn btn-primary" />
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


    </div>

</asp:Content>
