<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_CambiarContrasena.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_CambiarContrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type='text/css'>
       body {
           background-image: url(Content/img/pass.jpg);
           background-position-x: center;
    background-position-y: center;
    
    background-size: auto;
          
       }
    </style>
    <!-- the rest of the page here -->

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
     <div class="modal fade" data-backdrop="static" data-keyboard="false" id="mpe_ConfirmarPagoTodos" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document" style="width: 40% !important;">
                <div class="modal-content">
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                         <span style="visibility:hidden" class="modal-span" runat="server" id="Span2"></span>
                                    </div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <%--RUT, NOMBRE, APELLIDO PATERNO Y APELLIDO MATERNO--%>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <label for="nombre">Antes de cambiar su contraseña, asegúrese de conocer su actual contraseña.<br /></label> 
                                                </div>
                                            </div>
                                            <br />
                                             <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label runat="server" id="lbl_MarcaEquipo">(1) INGRESE ACTUAL CLAVE&nbsp; </label>
                                                        <label style="color: red">*</label>
                                                    </div>
                                                </div>
                                                 <div class="col-md-6">
                                                    <div class="form-group">
                                                         <label runat="server" visible="FALSE" id="lbl_ClaveIncorrecta" style="color: red">Contraseña actual incorrecta&nbsp; </label>
                                                        <asp:TextBox ID="txt_ActualClave" type="password" runat="server" class="input form-control" AutoPostBack="TRUE"  />
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                             <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label runat="server" id="Label1">(2) INGRESE NUEVA CLAVE&nbsp; </label>
                                                        <label style="color: red">*</label>
                                                    </div>
                                                </div>
                                                 <div class="col-md-6">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txt_NuevaClave" type="password" runat="server" class="input form-control"    />
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label runat="server" id="Label2">(3) REINGRESE NUEVA CLAVE&nbsp; </label>
                                                        <label style="color: red">*</label>
                                                    </div>
                                                </div>
                                                 <div class="col-md-6">
                                                    <div class="form-group">
                                                        <label runat="server" visible="FALSE" id="lbl_ReingresoClaveIncorrecta" style="color: red">Campos (2) y (3) deben ser iguales &nbsp; </label>
                                                        <asp:TextBox ID="txt_ReingresoNuevaClave" type="password" runat="server" class="input form-control" AutoPostBack="TRUE" />
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                 <label runat="server" visible="true" id="Label3" style="color: red">Doble Clic para confirmar &nbsp; </label><br />
                                                <asp:Button runat="server" ID="btn_ConfirmarCambioClave" CssClass="btn btn-primary"  Text="CONFIRMAR CAMBIO" />
                                                    
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-10">
                                        <b style="color: darkred"><span class="modal-span" runat="server" id="lbl_PagoFacturaERRORTodos" visible="FALSE"></span></b>
                                        <b style="color: green"><span class="modal-span" runat="server" id="lbl_PagoFacturaEXITOTodos" visible="FALSE"></span></b>
                                    </div>
                                    <div class="col-md-1"></div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-footer">
                        <%--<asp:Button ID="btn_FinalizarContrato" runat="server" Text="Finalizar Contrato" CssClass="btn btn-danger" data-toggle="modal" data-target="#exampleModalCenter" />--%>
                        <asp:Button runat="server" ID="btn_Cancelar" CssClass="btn btn-default"  Text="CANCELAR" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
