﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_AgregarUsuarios.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_AgregarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    <div class="container">
        <!-- Contenido principal para agregar usuario -->
        <asp:UpdatePanel runat="server" ID="upp_Principal" ChildrenAsTriggers="true" UpdateMode="always">
            <ContentTemplate>
                <section>
                    <!-- Inicio mensaje final -->
                    <div runat="server" id="pnl_Agregado" visible="false" class="alert alert-success alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Terminado!</strong> El usuario fue ingresado satisfactoriamente al sistema.
                    </div>
                </section>
                <!-- Fin mensaje final -->
                <section class="row">
                    <!-- Inicio de seccion de datos personales -->
                    <div class="col-md-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">Datos personales</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="RutUsuario">RUT: </label>
                                            <asp:TextBox runat="server" ID="txt_RutUsuario" CssClass="form-control" pattern="\d{3,8}[\d|kK]{1}" title="Debe ser un RUT válido."
                                                Minlength="8" MaxLength="9" placeholder="123456789" AutoPostBack="true" required></asp:TextBox>
                                            <p class="help-block">Escribir RUT sin puntos ni guión.</p>
                                        </div>
                                    </div>
                                    <%-- <asp:SqlDataSource ID="sds_UsuarioAgregar" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" 
                                        SelectCommand="up_shvt_s_DatosUsuario" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter name="RutColaborador" type="string"></asp:Parameter>
                                        </SelectParameters>
                                    </asp:SqlDataSource>--%>
                                    <div class="col-md-4">
                                        <!-- Mensaje de error rut usuario -->
                                        <div runat="server" id="pnl_ErrorRut" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                            <strong>Error!</strong> <span runat="server" id="lbl_ErrorRut"></span>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="Usuario">Telefono: </label>
                                            <asp:TextBox runat="server" ID="txt_Telefono" MaxLength="8" required="true" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="NombreUsuario">Nombre: </label>
                                            <asp:TextBox runat="server" ID="txt_NombreUsuario" CssClass="form-control" pattern="[A-Za-zñÑáéíóúÁÉÍÓÚ\s ]+" title="Sólo se permiten letras." required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="ApellidoPaternoUsuario">Apellido paterno: </label>
                                            <asp:TextBox runat="server" ID="txt_ApellidoPaternoUsuario" CssClass="form-control" pattern="[A-Za-zñÑáéíóúÁÉÍÓÚ\s ]+" title="Sólo se permiten letras." required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="ApellidoMaternoUsuario">Apellido materno: </label>
                                            <asp:TextBox runat="server" ID="txt_ApellidoMaternoUsuario" CssClass="form-control" pattern="[A-Za-zñÑáéíóúÁÉÍÓÚ\s ]+" title="Sólo se permiten letras." required></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- Fin de seccion de datos personales -->

                <!-- SQLDataSource a utilizar -->
                <asp:SqlDataSource ID="sds_OpcionesSistema" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                    SelectCommand="up_parque_s_OpcionesSistema" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <!-- Listar opciones del sistema -->

                <asp:SqlDataSource ID="sds_Cargos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                    SelectCommand="up_parque_s_Cargos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <!-- Listar opciones del sistema -->


                <section class="row">
                    <!-- Inicio de sección de datos de cuenta de usuario -->
                    <div class="col-md-12">
                        <div class="panel panel-primary">
                            <div class="panel-heading">Cuenta de usuario</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="Usuario">Nombre de usuario: </label>
                                            <asp:TextBox runat="server" ID="txt_Usuario" CssClass="form-control" pattern="[a-z]+" title="Sólo se permiten letras minúsculas."
                                                AutoPostBack="true" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label runat="server" id="lbl_CorreoUno">Correo Electrónico&nbsp; </label>
                                            <label style="color: red">*</label>
                                            <asp:TextBox ID="txt_CorreoUno" pattern="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}" runat="server" class="input form-control" required="" />
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label runat="server" id="Label1">Cargo&nbsp; </label>
                                            <label style="color: red">*</label>
                                            <asp:DropDownList runat="server" ID="ddl_Cargo" DataSourceID="sds_Cargos" DataValueField="id_TipoCargo"
                                                DataTextField="NombreTipoCargo" CssClass="form-control" required="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-4"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="OpcionesSistema">Opciones del sistema: </label>
                                            <asp:ListBox runat="server" ID="lbx_OpcionesSistema" DataSourceID="sds_OpcionesSistema" DataValueField="id_OpcionSistema"
                                                DataTextField="NombreOpcionSistema" CssClass="form-control" SelectionMode="Multiple" Rows="8" required="true"></asp:ListBox><!-- agregar sds con opciones del sistema -->
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <!-- Mensaje de error usuario -->
                                        <div runat="server" id="pnl_ErrorUsuario" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                            <strong>Error!</strong> Usuario ya se encuentra en la base de datos.
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                <!-- Fin de sección de datos de cuenta de usuario -->

                <section class="row">
                    <!-- Inicio de sección de botoneria -->
                    <div class="col-md-12">
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                            <asp:Button runat="server" ID="btn_Guardar" CssClass="btn btn-primary" Text="Guardar" />
                        </div>
                    </div>
                </section>
                <!-- Fin de sección de botoneria -->
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script>
        $(document).ready(function () {
            $('[id*=pnl_Agregado]').delay(2000).fadeOut(1000);
            $('[id*=pnl_ErrorRut]').delay(2000).fadeOut(1000);
            $('[id*=pnl_ErrorUsuario]').delay(2000).fadeOut(1000);
        });
    </script>
</asp:Content>
