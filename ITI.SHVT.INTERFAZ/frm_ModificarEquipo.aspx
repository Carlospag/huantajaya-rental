<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_ModificarEquipo.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_ModificarEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="stm_Principal" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>

    <asp:SqlDataSource ID="sds_SoloEquipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_SoloEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_EquipoXidequipo" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_EquipoXidEquipo" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Equipo" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="sds_EquiposXFamilia" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
        SelectCommand="up_parque_s_EquiposXfamilia" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:Parameter Name="id_Familia" Type="Int64"></asp:Parameter>
        </SelectParameters>
    </asp:SqlDataSource>

    <div class="container">
        <asp:UpdatePanel ID="upp_Colapsables" runat="server" ChildrenAsTriggers="true" UpdateMode="always">
            <ContentTemplate>

                <div class="container">
                    <section>
                        <div runat="server" id="pnl_Agregado" visible="false" class="alert alert-success alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong>Terminado!</strong> El Equipo se ha actualizado correctamente.
                        </div>
                        <div runat="server" id="pnl_Noexiste" visible="false" class="alert alert-danger alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <strong>Error!</strong> El Equipo que buscas no esta en el sistema.
                        </div>
                    </section>
                    <div class="panel panel-primary">
                        <div class="panel-heading">BUSCAR EQUIPO</div>
                        <div class="panel-body">
                          
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label runat="server" id="Label7">Filtrar por familia&nbsp; </label>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Familias" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                            <asp:DropDownList ID="ddl_Familias" runat="server" CssClass="form-control" DataSourceID="sds_Familias" DataValueField="id_Familia" DataTextField="NombreFamilia" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label runat="server" id="Label8">Seleccione equipo&nbsp; </label>
                                            <asp:DropDownList ID="ddl_Equipos" runat="server" CssClass="form-control" DataSourceID="sds_EquiposXFamilia" DataValueField="id_Equipo" DataTextField="NombreEquipo" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label runat="server" id="Label9">Buscar por AFI&nbsp; </label>
                                            <span runat="server" style="color: red" id="lbl_ErrorAfi"></span>
                                            <asp:TextBox Font-Size="X-Large" Font-Bold="true" MaxLength="6" ID="txt_BuscarAfi" runat="server" class="input form-control text-center" required="" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" ID="btn_LimpiarFiltros" CssClass="btn btn-default" Text="Limpiar" />
                                            <asp:LinkButton runat="server" ID="btn_BusquedaPorAfi" Text="Busqueda por afi" CssClass="btn btn-primary" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div class="panel panel-primary">
                        <div class="panel-heading">INFORMACION EQUIPOS</div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="txt_Fecha">Número de serie&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox ID="txt_NumeroSerie" runat="server" class="input form-control" required="true" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    
                                </div>
                                <div class="col-md-3"></div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="txt_Fecha">Nombre de equipo&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox ID="txt_NombreEquipo" runat="server" class="input form-control" required="true" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="Label2">Familia&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:SqlDataSource ID="sds_Familias" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Familias" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                        <asp:DropDownList ID="ddl_Familia" runat="server" CssClass="form-control" DataSourceID="sds_Familias" DataValueField="id_Familia" DataTextField="NombreFamilia" AutoPostBack="true" required="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="Label1">Valor de compra&nbsp;</label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox ID="txt_ValorCompra" runat="server" class="input form-control" required="true" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="Label4">Estado&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:SqlDataSource ID="sds_EstadosEquipos" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_EstadoEquipos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                        <asp:DropDownList ID="ddl_EstadoEquipos" runat="server" CssClass="form-control" DataSourceID="sds_EstadosEquipos" DataValueField="id_EstadoEquipo" DataTextField="NombreEstadoEquipo" AutoPostBack="true" required="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_MarcaEquipo">Marca&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox ID="txt_MarcaEquipo" runat="server" class="input form-control" required="true" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_TelDos">Módelo&nbsp;</label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox ID="txt_ModeloEquipo" runat="server" class="input form-control" required="true" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <label runat="server" id="Label5">Procedencia&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:DropDownList ID="ddl_Procedencia" runat="server" CssClass="form-control" required="true">
                                            <asp:ListItem Value="Brasil">Brasil</asp:ListItem>
                                            <asp:ListItem Value="Japón">Japón</asp:ListItem>
                                            <asp:ListItem Value="Inglaterra">Inglaterra</asp:ListItem>
                                            <asp:ListItem Value="EE.UU">EE.UU</asp:ListItem>
                                            <asp:ListItem Value="China">China</asp:ListItem>
                                            <asp:ListItem Value="Alemania">Alemania</asp:ListItem>
                                            <asp:ListItem Value="India">India</asp:ListItem>
                                            <asp:ListItem Value="Italia">Italia</asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_horometro">Horómetro&nbsp; </label>
                                        <label style="color: gray">(Opcional)</label>
                                        <asp:TextBox MaxLength="6" ID="txt_Horometro" pattern="[0-9]*" runat="server" class="input form-control" AutoPostBack="true" />
                                        <p class="help-block"></p>
                                    </div>
                                </div>
                            </div>
                            <div class="row input-daterange" id="datetimepicker">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label for="txt_Fecha">Fecha Adquisición:</label>
                                        <label style="color: red">*</label>
                                        <asp:TextBox MaxLength="10" ID="txt_FechaAdquisicion" runat="server" class="input form-control" placeholder="dd/mm/aaaa" name="start" onkeydown="return false;" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="Label3">Sucursal&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:SqlDataSource ID="sds_Sucursales" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>" SelectCommand="up_parque_s_Sucursales" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                        <asp:DropDownList ID="ddl_Sucursal" runat="server" CssClass="form-control" DataSourceID="sds_Sucursales" DataValueField="id_Sucursal" DataTextField="NombreSucursal" AutoPostBack="true" required>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="lbl_Color">Color&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:DropDownList ID="ddl_Color" runat="server" CssClass="form-control" required="true">
                                            <asp:ListItem Value="Amarillo">Amarillo</asp:ListItem>
                                            <asp:ListItem Value="Verde">Verde</asp:ListItem>
                                            <asp:ListItem Value="Rojo">Rojo</asp:ListItem>
                                            <asp:ListItem Value="Gris">Gris</asp:ListItem>
                                            <asp:ListItem Value="Blanco">Blanco</asp:ListItem>
                                            <asp:ListItem Value="Negro">Negro</asp:ListItem>
                                            <asp:ListItem Value="Azul">Azul</asp:ListItem>
                                            <asp:ListItem Value="Cafe">Cafe</asp:ListItem>
                                            <asp:ListItem Value="Naranjado">Naranjado</asp:ListItem>
                                            <asp:ListItem Value="Morado">Morado</asp:ListItem>
                                            <asp:ListItem Value="Celeste">Celeste</asp:ListItem>
                                            <asp:ListItem Value="Naranjo">Naranjo</asp:ListItem>
                                            <asp:ListItem Value="Metal">Metal</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label runat="server" id="Label6">Año del equipo&nbsp; </label>
                                        <label style="color: red">*</label>
                                        <asp:DropDownList ID="ddl_AnhoEquipo" runat="server" CssClass="form-control" required="true">
                                            <asp:ListItem Value="2005">2005</asp:ListItem>
                                            <asp:ListItem Value="2006">2006</asp:ListItem>
                                            <asp:ListItem Value="2007">2007</asp:ListItem>
                                            <asp:ListItem Value="2008">2008</asp:ListItem>
                                            <asp:ListItem Value="2009">2009</asp:ListItem>
                                            <asp:ListItem Value="2010">2010</asp:ListItem>
                                            <asp:ListItem Value="2011">2011</asp:ListItem>
                                            <asp:ListItem Value="2012">2012</asp:ListItem>
                                            <asp:ListItem Value="2013">2013</asp:ListItem>
                                            <asp:ListItem Value="2014">2014</asp:ListItem>
                                            <asp:ListItem Value="2015">2015</asp:ListItem>
                                            <asp:ListItem Value="2016">2016</asp:ListItem>
                                            <asp:ListItem Value="2017">2017</asp:ListItem>
                                            <asp:ListItem Value="2018">2018</asp:ListItem>
                                            <asp:ListItem Value="2019">2019</asp:ListItem>
                                            <asp:ListItem Value="2020">2020</asp:ListItem>
                                            <asp:ListItem Value="2021">2021</asp:ListItem>
                                            <asp:ListItem Value="2022">2022</asp:ListItem>
                                            <asp:ListItem Value="2023">2023</asp:ListItem>
                                            <asp:ListItem Value="2024">2024</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                    </div>
                   <div class="panel panel-primary" id="datos Opcionales">
                        <div class="panel-heading">DATOS OPCIONALES</div>
                        <div class="panel-body">
                           
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Largo&nbsp; </label>                                    
                                        <asp:TextBox ID="txt_LargoEquipo" runat="server" class="input form-control" type="number"  />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label >Alto&nbsp; </label>                              
                                        <asp:TextBox ID="txt_AltoEquipo" runat="server" class="input form-control" type="number"  />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label >Ancho&nbsp; </label>  
                                        <asp:TextBox ID="txt_AnchoEquipo" runat="server" class="input form-control"  type="number" />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label >Peso&nbsp;</label>
                                        <asp:TextBox ID="txt_PesoEquipo" runat="server" class="input form-control"  type="number" />
                                    </div>
                                </div>
                            </div>
                        
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label >Patente&nbsp; </label>
                                         <!-- <asp:TextBox MaxLength="7" ID="txt_Patente"  runat="server" class="input form-control"  />-->
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label >Accionamiento&nbsp; </label>                                    
                                        <asp:TextBox ID="txt_AccionamientoEquipo" runat="server" class="input form-control"  />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label >Dato 1&nbsp; </label>                                    
                                        <asp:TextBox ID="txt_Dato1Equipo" runat="server" class="input form-control"  />
                                    </div>
                                </div>
                                <div class="col-md-3">
                                   <div class="form-group">
                                        <label >Dato 2&nbsp; </label>                                    
                                        <asp:TextBox ID="txt_Dato2Equipo" runat="server" class="input form-control"  />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label style="color: red">(*) Campos obligatorios</label>
                        </div>
                        <div class="col-md-8">
                            <div class="pull-right">
                                <asp:LinkButton runat="server" ID="btn_Limpiar" CssClass="btn btn-default" Text="Limpiar" />
                                <asp:Button ID="btn_Guardar" runat="server" Text="Actualizar Equipo" CssClass="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter" />
                            </div>
                        </div>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- Modal -->
        <div class="modal fade" id="mpe_VerCausa" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="upp_Modal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title"></h4>
                            </div>
                            <div class="modal-body">

                                <div class="panel panel-primary">
                                    <div class="panel-heading"><span class="modal-span" runat="server" id="lbl_Titulo"></span></p></div>
                                    <div class="panel-body">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lbl_Detalle"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

    </div>







    <!--/container-->


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