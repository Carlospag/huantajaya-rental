<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_MantenedorMantenciones.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_MantenedorMantenciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
        
        
        <asp:UpdatePanel runat="server" ID="upp_repuestos" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">REGISTRAR REPUESTO EN EL SISTEMA</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="txt_Fecha">Nombre Respuesto&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox ID="txt_NombreRepuesto" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txt_Fecha">Original&nbsp; </label>
                                    <asp:TextBox ID="txt_OriginalRepuesto" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txt_Fecha">Alternativo 1&nbsp; </label>
                                    <asp:TextBox ID="txt_AlternativoUnoRepuesto" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txt_Fecha">Alternativo 2&nbsp; </label>
                                    <asp:TextBox ID="txt_AternativoDosRepuesto" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label runat="server" id="lbl_Descripcion">Cant.&nbsp;</label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txt_CantidadRepuesto" htmlencode="false" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label runat="server" id="Label4">Precio&nbsp;</label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox runat="server" class="form-control" ID="txt_PrecioRepuesto" htmlencode="false" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="pull-right">
                                    <asp:LinkButton runat="server" ID="btn_LimpiarRepuesto" CssClass="btn btn-default" Text="Limpiar" />
                                    <asp:LinkButton ID="btn_RegistrarRepuesto" runat="server" Text="Registrar Repuesto" CssClass="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server" ID="upp_lubricantes" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">REGISTRAR LUBRICANTE EN EL SISTEMA</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="txt_Fecha">Nombre Lubricante&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox ID="txt_NombreLubricante" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txt_Fecha">Caracteristicas&nbsp; </label>
                                    <asp:TextBox ID="txt_CaracteristicasLubricante" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txt_Fecha">Cant.&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox ID="txt_CantidadLubricante" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txt_Fecha">Precio&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox ID="txt_PrecioLubricante" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="pull-right">
                                    <asp:LinkButton runat="server" ID="btn_LimpiarLubricante" CssClass="btn btn-default" Text="Limpiar" />
                                    <asp:LinkButton ID="btn_RegistrarLubricante" runat="server" Text="Registrar Lubricante" CssClass="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server" ID="upp_actividades" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panel panel-primary">
                    <div class="panel-heading">REGISTRAR ACTIVIDAD EN EL SISTEMA</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="txt_Fecha">Nombre Actividad&nbsp; </label>
                                    <label style="color: red">*</label>
                                    <asp:TextBox ID="txt_NombreActividad" runat="server" class="input form-control" required="" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="pull-right">
                                    <asp:LinkButton runat="server" ID="btn_LimpiarActividad" CssClass="btn btn-default" Text="Limpiar" />
                                    <asp:LinkButton ID="btn_RegistrarActividad" runat="server" Text="Registrar Actividad" CssClass="btn btn-primary" />
                                </div>
                            </div>
                        </div>
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
