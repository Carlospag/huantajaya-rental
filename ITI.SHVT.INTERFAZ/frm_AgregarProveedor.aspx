<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_AgregarProveedor.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_AgregarProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:SqlDataSource ID="sds_Comunas" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_Comunas" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Region" Type="Int16"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <!--<asp:SqlDataSource ID="sds_CCHijos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_CCHijos" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_CentroCostoPadre" Type="Int16"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>-->

     
        

    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
    
        <!-- Contenido principal para agregar usuario -->
        <asp:UpdatePanel runat="server" ID="upp_Principal" ChildrenAsTriggers="true" UpdateMode="always">
            <ContentTemplate>
               
                <div class="container-fluid">
                     <section>
                    <!-- Inicio mensaje final -->
                    <div runat="server" id="pnl_Agregado" visible="false" class="alert alert-success alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Terminado!</strong> El Proveedor fue ingresado satisfactoriamente al sistema.
                    </div>
                </section>
                        <div class="panel panel-primary">
                            <div class="panel-heading">DATOS DEL PROVEEDOR</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_Colaborador">Rut Proveedor&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <span runat="server" style="color: red" id="lbl_ErrorRut"></span>
                                        <asp:TextBox Minlength="8" MaxLength="9" ID="txt_RutProveedor" runat="server" class="input form-control" AutoPostBack="true" required="true" />
                                        <p class="help-block">Escribir RUT sin puntos ni guión.</p>
                                    </div>
                                </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txt_Fecha">Nombre Proveedor&nbsp; </label>
                                            <label style="color: red">*</label>
                                            <asp:TextBox ID="txt_NombreProveedor" runat="server" class="input form-control" required="true" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="selectedpicker">
                                            <label>Giro&nbsp; </label>
                                            <label style="color: red">*</label>
                                            <asp:TextBox ID="txt_GiroProveedor" runat="server" class="input form-control" required="true" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label >Teléfono&nbsp; </label>
                                            <span runat="server" style="color: red" id="Span3"></span>
                                            <asp:TextBox MinLenght="8" MaxLength="9" ID="txt_TelefonoProveedor" runat="server" pattern="[0-9]*" title="Solo ingresar números" class="input form-control" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label >Correo Electronico&nbsp; </label>
                                            <span runat="server" style="color: red" id="Span4"></span>
                                            <asp:TextBox ID="txt_CorreoProveedor" runat="server" class="input form-control" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="selectedpicker">
                                            <label>Dirección&nbsp; </label>
                                            <label style="color: red">*</label>
                                            <asp:TextBox ID="txt_DireccionProveedor" runat="server" class="input form-control" required="true" />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <div class="">
                                                <label runat="server" id="lbl_Region">Región:</label>
                                                <label style="color: red">*</label>
                                                <asp:SqlDataSource ID="sds_ListaRegiones" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Regiones" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                                <asp:DropDownList ID="ddl_Regiones" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" required="true" DataSourceID="sds_ListaRegiones" DataValueField="id_Region" DataTextField="NombreRegion">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <div class="">
                                                <label runat="server" id="lbl_Comuna">Comuna:</label>
                                                <label style="color: red">*</label>

                                                <asp:DropDownList ID="ddl_Comunas" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_Comunas" required="true" DataValueField="id_Comuna" DataTextField="NombreComuna">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Estado del proveedor&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:DropDownList ID="ddl_EstadoProveedor" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="1">Activo</asp:ListItem>
                                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                </div>

                                <!-- <div class="row">
                                    <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="">
                                            <label runat="server" id="Label1">CC General:</label>
                                            <asp:SqlDataSource ID="sds_CCPadres" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_CCPadres" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                            <asp:DropDownList ID="ddl_CCPadre" runat="server" CssClass="form-control chosen-select" AutoPostBack="true" DataSourceID="sds_CCPadres" DataValueField="id_CentroCostoPadre" DataTextField="NombreCentroCostoPadre">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                    <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="">
                                            <label runat="server" id="Label2">CC Especifico:</label>
                                            
                                            <asp:DropDownList ID="ddl_CCHijo" runat="server" CssClass="form-control chosen-select" DataSourceID="sds_CCHijos" DataValueField="id_CentroCostoHijo" DataTextField="NombreCentroCostoHijo">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                </div>-->
                           
                        </div>
                    </div>



                    <div class="panel panel-primary">
                            <div class="panel-heading">DATOS DE CONTACTO</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txt_Fecha">Nombre Contacto&nbsp; </label>
                                            <asp:TextBox ID="txt_NombreContactoProveedor" runat="server" class="input form-control"  />
                                        </div>
                                    </div>
                                   
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label >Teléfono&nbsp; </label>
                                            <span runat="server" style="color: red" id="Span1"></span>
                                            <asp:TextBox MinLenght="8" MaxLength="9" ID="txt_TelefonoContactoProveedor" runat="server" pattern="[0-9]*" title="Solo ingresar números" class="input form-control"  />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label >Correo Electronico&nbsp; </label>
                                            <span runat="server" style="color: red" id="Span2"></span>
                                            <asp:TextBox ID="txt_CorreoContactoProveedor" runat="server" class="input form-control"  />
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="selectedpicker">
                                            <label>Dirección&nbsp; </label>
                                            <asp:TextBox ID="txt_DireccionContactoProveedor" runat="server" class="input form-control"  />
                                        </div>
                                    </div>
                                </div>
                        </div>
                    </div>

                    <div class="panel panel-primary">
                            <div class="panel-heading">PREFERENCIAS DEL PROVEEDOR (BANCARIAS Y DE PAGO)</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label >RUT Cuenta Destinatario&nbsp; </label>
                                            <span runat="server" style="color: red" id="lbl_ErrorRut2"></span>
                                            <asp:TextBox ID="txt_RutDestinatario" MinLenght="8" MaxLength="9"  AutoPostBack="true" runat="server" class="input form-control"  />
                                            <p class="help-block">Escribir RUT sin puntos ni guión.</p>
                                        </div>
                                    </div>
                                     <div class="col-md-3">
                                        <div class="form-group">
                                            <label >Nombre Cuenta Destinatario&nbsp; </label>
                                            <span runat="server" style="color: red" id="Span8"></span>
                                            <asp:TextBox ID="txt_NombreDestinatario" runat="server" class="input form-control"  />
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label for="txt_Fecha">Banco&nbsp; </label>
                                                   <asp:SqlDataSource ID="sds_Bancos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Bancos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                                <asp:DropDownList ID="ddl_Bancos" runat="server" CssClass="form-control chosen-select"  DataSourceID="sds_Bancos" DataValueField="id_Banco" DataTextField="NombreBanco">
                                                </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Tipo de cuenta&nbsp; </label>
                                                   <asp:SqlDataSource ID="sds_TipoCuentas" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_TipoCuentasBancarias" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                                <asp:DropDownList ID="ddl_TipoCuenta" runat="server" CssClass="form-control chosen-select"  DataSourceID="sds_TipoCuentas" DataValueField="id_TipoCuenta" DataTextField="NombreTipoCuenta">
                                                </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="col-md-2">
                                        <div class="form-group">
                                            <label >Número de cuenta&nbsp; </label>
                                            <span runat="server" style="color: red" id="Span7"></span>
                                            <asp:TextBox ID="txt_NumeroCuenta" TextMode="Number" runat="server" class="input form-control"  />
                                        </div>
                                    </div>

                                    



                                   
                                    </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txt_Fecha">Documento de compra&nbsp; </label>
                                                   <asp:SqlDataSource ID="sds_DctoCompra" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_DocumentosDePago" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                                <asp:DropDownList ID="ddl_dctoCompra" runat="server" CssClass="form-control chosen-select"  DataSourceID="sds_DctoCompra" DataValueField="id_DctoCompra" DataTextField="NombreDctoCompra">
                                                </asp:DropDownList>
                                        </div>
                                    </div>
                                    
                                   
                                   
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label >Medio de pago&nbsp; </label>
                                                   <asp:SqlDataSource ID="sds_MedioPago" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_MediosDePago" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                                                <asp:DropDownList ID="ddl_MedioPago" runat="server" CssClass="form-control chosen-select"  DataSourceID="sds_MedioPago" DataValueField="id_MedioPago" DataTextField="NombreMedioPago">
                                                </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label >¿Que servicios presta? Ej: Baterias, neumaticos, correas, etc.&nbsp; </label>
                                            <asp:TextBox ID="txt_Servicios" runat="server" class="input form-control"  />
                                        </div>
                                    </div>
                                   
                                </div>
                        </div>
                    </div>


                </section>
                <!-- Fin de seccion de datos personales -->


                <!-- Fin de sección de datos de cuenta de usuario -->

                <section class="row">
                    <!-- Inicio de sección de botoneria -->
                    <div class="col-md-12">
                        <div class="pull-left">
                            <label style="color:red"  >* Campos Obligatorios </label>
                            </div>
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="LIMPIAR CAMPOS" />
                            <asp:Button runat="server" ID="btn_Guardar" CssClass="btn btn-primary" Text="REGISTRAR PROVEEDOR" />
                        </div>
                    </div>
                </section>
                <!-- Fin de sección de botoneria -->
            </ContentTemplate>
        </asp:UpdatePanel>
    
    <script type="text/javascript">
        $(function () {
            $('[id*=gdv_Novedades]').footable();
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
            $('.chosen-select').chosen();
            $(".input-daterange").datepicker({
                language: "es",
                format: "dd/mm/yyyy",
                autoclose: true,
                todayHighlight: true,
                orientation: "bottom"
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('[id*=pnl_Agregado]').delay(2000).fadeOut(1000);
            $('[id*=pnl_ErrorRut]').delay(2000).fadeOut(1000);
            $('[id*=pnl_ErrorUsuario]').delay(2000).fadeOut(1000);
        });
    </script>
    <script>
        function ActualizaCombobox() {
            $('.chosen-select').chosen();
        }
    </script>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function (s, e) {
            ActualizaCombobox();
        });
    </script>


</asp:Content>
