<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_MantenedorActividades.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_MantenedorActividades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>

    <asp:SqlDataSource ID="sds_ActividadesXid" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_ListarActividadesDespachoXid" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Actividad" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

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
                    <div class="panel-heading">INGRESAR UNA ACTIVIDAD DE DESPACHO/RECEPCIÓN</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txt_Fecha">Nombre Actividad&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox ID="txt_NombreActividad" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label runat="server" id="lbl_Descripcion">Cantidad&nbsp;</label>
                                    <label style="color: gray">(Opcional)</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txt_Cantidad" htmlencode="false" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label runat="server" id="Label2">¿Es una implementación?&nbsp;</label>
                                    <label style="color: gray">(Opcional)</label>
                                    <asp:CheckBox runat="server" Text="&nbsp;&nbsp;Si" ID="chk_Implementacion" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="pull-right">
                                    <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                                    <asp:LinkButton ID="btn_Registrar" runat="server" Text="Registrar Actividad" CssClass="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" ID="upp_modificar" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container">
                    <div class="panel panel-primary" id="pnl_faltos" runat="server">
                        <div class="panel-heading">MODIFICAR ACTIVIDAD DE DESPACHO/RECEPCIÓN</div>
                        <div class="panel-body">
                            <p>A continuación podrá modificar una actividad relacionada a las <b>actas de entrega y recepción</b> que esten actualmente en el sistema.</p>

                            <section class="cuerpo-informe">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="NombreUsuario">Seleccionar Actividad: </label>
                                            <asp:SqlDataSource ID="sds_ListadoActividades" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_ListarActividadesDespacho" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                            <asp:DropDownList ID="ddl_Actividades" runat="server" CssClass="form-control" DataSourceID="sds_ListadoActividades" DataValueField="id_Actividad" DataTextField="NombreActividad" required="true" AutoPostBack="true">
                                            </asp:DropDownList><br />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                <div class="form-group">
                                    <label runat="server" id="Label3">¿Es una implementación?&nbsp;</label>
                                    <label style="color: gray">(Opcional)</label>
                                    <asp:CheckBox runat="server" Text="&nbsp;&nbsp;Si" ID="chk_ImplementacionRespuesta" />
                                </div>
                            </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="NombreUsuario">Nombre Actividad: </label>
                                            <asp:TextBox runat="server" ID="txt_NombreServicio" CssClass="form-control" pattern="[A-Za-zñÑáéíóúÁÉÍÓÚ\s ]+" title="Sólo se permiten letras." required="true"></asp:TextBox><br />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label runat="server" id="Label1">Cantidad&nbsp;</label>
                                            <label style="color: gray">(Opcional)</label>
                                            <asp:TextBox runat="server" class="form-control" ID="txt_CantidadRespuesta" htmlencode="false" />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="NombreUsuario">Estado Actividad: </label>
                                            <asp:DropDownList ID="ddl_Estado" runat="server" CssClass="form-control" required>
                                                <asp:ListItem Value="1">Activa</asp:ListItem>
                                                <asp:ListItem Value="0">Inactiva</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" ID="btn_LimpiarMod" CssClass="btn btn-default" Text="Limpiar" />
                                            <asp:LinkButton ID="btn_ModificarCausas" runat="server" Text="Modificar Actividad" CssClass="btn btn-primary" />
                                        </div>
                                    </div>
                                </div>
                            </section>
                        </div
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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
