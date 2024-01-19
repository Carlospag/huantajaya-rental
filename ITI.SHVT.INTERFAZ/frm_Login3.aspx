<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frm_Login3.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" href="Content/img/hrentalicono.ico" type="image/x-icon" />
    <!-- Los 3 meta tags de arriba deben ser los primeros en el head, cualquier otro contenido del head debe venir después-->
    <title></title>

    <!--boostrap-->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!--Font Awesome-->
    <link href="Content/font-awesome.css" rel="stylesheet" />
    <!-- CSS Personalizado -->
    <link href="Content/Default.css" rel="stylesheet" />
    <!--CSS Login -->
    <link href="Content/signin.css" rel="stylesheet" />

    <!-- Jquery, necesario para los plugins de bootstrap -->
    <script src="Scripts/jquery-3.1.1.min.js"></script>
    <!-- Incluir todos los plugins de bootstrap debajo -->
    <script src="Scripts/bootstrap.min.js"></script>
    <!-- footer -->
    <link href="Content/sticky-footer-navbar.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Cabecera -->
            <header class="navbar" role="banner" id="BarraNavegacion">
                <div class="navbar navbar-default navbar-fixed-top" role="navigation">
                    <!-- navbar-fixed-top -->
                    <div class="container" id="ContenedorNavbar">
                        <div class="navbar-header">
                            <div>
                                <%--<img class="logo-iti-inicio" src="Content/img/capa1.png" id="logo" height="70" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </header>

            <div class="container">
                <div class="col-md-12">
                    <div class="row">
                    </div>
                    <%-- <div class="row">
                        <div class="col-md-3"></div>
                        <div class="col-md-6">
                            <img class= "fa-align-center" style="image-orientation: inherit"  src="Content/img/capa1.png" id="Img1" height="150" />
                        </div>
                        <div class="col-md-3"></div>
                    </div>--%>
                    <div class="row">
                        <div class="col-md-4"></div>
                        <div class="col-md-4">
                            <div class="form-signin">
                                <h2 class="form-signin-heading" style="text-align: center">Bienvenido a HRental</h2>
                                <label for="inputEmail" class="sr-only">Usuario</label>
                                <asp:TextBox ID="txt_Usuario" runat="server" type="text" class="form-control text-center" placeholder="Usuario" required autofocus>
                                </asp:TextBox>
                                <label for="inputPassword" class="sr-only">Contraseña</label>
                                <asp:TextBox ID="txt_Contrasena" runat="server" type="password" class="form-control text-center" placeholder="Contraseña" required></asp:TextBox>
                                <asp:Button ID="btn_Ingresar" runat="server" Text="Ingresar" class="btn btn-lg btn-primary btn-block" />
                            </div>
                        </div>
                        <div class="col-md-4"></div>
                    </div>
                    <div class="row">
                    </div>



                </div>

            </div>


            <center> <asp:Label ID="lbl_Mensaje" runat="server" ForeColor="Red" ></asp:Label></center>

            <asp:SqlDataSource ID="sds_Usuario" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
                SelectCommand="up_parque_s_SoloUsuario" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter Name="id_Usuario" Type="Int32"></asp:Parameter>
                </SelectParameters>
            </asp:SqlDataSource>

            <!-- Pie de página -->
            <a href="#" class="back-to-top"><i class="fa fa-2x fa-angle-up"></i></a>
            <footer class="footer">
                <div class="container">
                    <div class="col-md-6 hidden-xs">
                        <img src="Content/img/excavadora2.png" alt="LogoSistema" height="50" />
                        <p class="text-left sistema-footer">
                            Sistema de gestión del parque de operaciones
                        </p>
                    </div>
                    <div class="col-md-6">
                        <p id="Copyright" class="text-right">
                            <small>HRental - Huantajaya
                                <br>
                                Copyright &copy; 2020 - Área de Operaciones
                            </small>
                        </p>
                    </div>
                </div>
            </footer>

        </div>
    </form>
    <script>
        $('#inputEmail').on('click', function () {
            document.body.scrollTop += this.getBoundingClientRect().top - 100
        });
        $('#inputPassword').on('click', function () {
            document.body.scrollTop += this.getBoundingClientRect().top - 100
        });
    </script>

    <link href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" rel="stylesheet" />

</body>
</html>
