<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="inf_Jefatura.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.inf_Jefatura" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="stm_Principal" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
    <asp:SqlDataSource ID="sds_ColaboradorXUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_shvt_s_ColaboradorXUsuario" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Usuario" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">INFORME POR COLABORADOR</div>
            <div class="panel-body">
                <p>A continuación podrá generar un informe historico de los colaboradores a su cargo.</p>
                <section class="cuerpo-informe">
                    <div class="row input-daterange" id="datetimepicker">
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txt_FechaInicio">Fecha Inicio</label>
                                <asp:TextBox MaxLength="10" ID="txt_FechaInicio" runat="server" class="form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" required=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label for="txt_FechaFin">Fecha Término</label>
                                <asp:TextBox MaxLength="10" ID="txt_FechaTermino" runat="server" class="form-control" placeholder="dd/mm/aaaa" name="end" onkeydown="return false;" required=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label runat="server" id="lbl_Colaboradores">Colaboradores:</label>
                                <asp:DropDownList runat="server" ID="ddl_Colaboradores" DataSourceID="sds_ColaboradorXUsuario" DataValueField="RutColaborador"
                                    DataTextField="NombreColaborador" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="pull-right">
                                <asp:Button ID="btn_Generar" runat="server" Text="Generar Informe" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>

                </section>
            </div>
        </div>
    </div>
    <rsweb:reportviewer id="rpu_Informe" processingmode="Remote" visible="false" runat="server"></rsweb:reportviewer>
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
</asp:Content>
