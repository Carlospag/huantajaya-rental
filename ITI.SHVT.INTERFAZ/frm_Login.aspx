<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frm_Login.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Login1" %>

<!DOCTYPE html>

<html lang="es">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link rel="apple-touch-icon" sizes="180x180" href="/Resources/Images/apple-touch-icon.png">
    <link rel="shortcut icon" href="Content/img/hrentalicono.ico" type="image/x-icon" />
    <title>Login - Hrental | ERP</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <link href="Content/Login.css" rel="stylesheet" />


</head>
<body>
    <div class="container">
        <div class="container-fluid">
            <div class="loginContainer">

                 <asp:SqlDataSource ID="sds_Usuario" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                SelectCommand="up_parque_s_SoloUsuario" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="id_Usuario" Type="Int32"></asp:Parameter>
                </SelectParameters>
            </asp:SqlDataSource>
                <div class="row">
                    <div class="col-md-12 bg_hcuch_reumato">
                        <a href="http://hrental.cl" target="_blank">
                            <img src="Content/img/capa1.png" class="img-responsive center-block" alt="Teleconsulta" />
                        </a>
                    </div>
                </div>
                <div class="row wrap_principal_reumato">
                    <div class="col-md-7 main_info_reumato">
                        <div class="">
                            <h1><strong>HRental - ERP</strong></h1>
                            <br />
                            <ul  class="listaEspecialidad">
                                <li>Crear y modificar clientes y equipos.</li>
                                <li>Revisar el parque de equipos.</li>
                                <li>Generar un contrato con su respectiva documentación.</li>
                                <li>Dar cumplimiento al plan de mantención de los equipos.</li>
                            </ul>
                            <br />
                            <h4 class="nuestraEspecialidad"><strong>Módulos del sistema:</strong></h4>
                            <ul class="listaEspecialidad">
                                <li>Equipos</li>
                                <li>Clientes</li>
                                <li>Contratos</li>
                                <li>Estados de pago </li>
                                <li>Facturación</li>
                                <li>Mantenciones</li>
                                <li>Dashboard</li>

                            </ul>
                        </div>
                    </div>
                    <div class="col-md-5 wrap_login_reumato section" id="segundaFila">
                        <div class="vcenter">
                            <form class="form-horizontal" id="Login" method="post"  runat="server">
                                <input name="__RequestVerificationToken" type="hidden" value="UqpVJmP0UViPwrBNoI-58EW-pYf6w-HzlurZE08kRDpOjaS2MWlG8T14sVZYCI50HBwl73ybXLyb8YkREHwkNeL1Dv8Mv161uD8lz1W-J5I1" />
                                <div class="row">
                                    <div class="col-md-12">
                                        <h4>Inicio de sesión
                                        </h4>
                                        <p class="text-justify" style="padding-top: 10px;">Ingrese sus credenciales para ingresar al sistema</p>
                                    </div>
                                </div>
                                <div class="row">

                                    <div id="loginData">
                                        <div class="validate-input" data-validate="RUT valido es requerido: 12345678-5">
                                            <asp:TextBox ID="txt_Usuario" runat="server" type="text" class="form-control text-box single-line text-center" placeholder="Usuario" required="required" autofocus="autofocus">
                                </asp:TextBox>
                                            <%--<input runat="server" class="form-control text-box single-line" data-rule-required="true" data-rule-rut="true" data-val="true" data-val-required="El usuario no puede quedar en blanco" id="txt_Usuario" name="Usuario" placeholder="Usuario" type="text" value="" />--%>
                                            <span class="field-validation-valid" data-valmsg-for="RutUsuario" data-valmsg-replace="true"></span>
                                        </div>
                                        <div class="validate-input" data-validate="Password es Requerida">
                                            <asp:TextBox ID="txt_Contrasena" runat="server" type="password" class="form-control text-center" placeholder="Contraseña" required="required"></asp:TextBox>
                                
                                            <%--<input runat="server" class="form-control" data-val="true" data-val-required="La Contraseña no puede quedar en blanco" id="txt_Contrasena" name="Password" placeholder="Contraseña" type="password" />--%>
                                            <span class="field-validation-valid" data-valmsg-for="Password" data-valmsg-replace="true"></span>
                                        </div>

                                        <div class="divBtnIniciarSesion">
                                            <%--<button type="submit" runat="server" class="btnIniciarSesion btn btn-block" id="btn_Ingresar2" OnClick="btn_Descargar_Click">Iniciar Sesión</button>--%>
                                             <asp:Button ID="btn_Ingresar" runat="server" Text="Ingresar" class="btnIniciarSesion btn btn-block" />
                                        </div>
                                    </div>
                                </div>

                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div id="modalInformativo" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header alert" id="modHeader">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="tituloModal"></h4>
                </div>
                <div class="modal-body">
                    <p id="textoModalPrimario" class="confirmacion"></p>
                    <p class="text-warning"><small id="textoModalSecundario"></small></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary" id="btnGuardaModal" style="display: none;">Guardar</button>
                </div>
            </div>
        </div>
    </div>

    <script src="Scripts/jquery-3.1.1.min.js"></script>

    <script src="Scripts/bootstrap.min.js"></script>

</body>

</html>
