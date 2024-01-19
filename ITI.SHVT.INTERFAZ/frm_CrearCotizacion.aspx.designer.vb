'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class frm_CrearCotizacion
    
    '''<summary>
    '''Control sds_MaxCotizacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_MaxCotizacion As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control sds_EquipoXidequipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_EquipoXidequipo As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control sds_EquiposXFamilia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_EquiposXFamilia As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control sds_EquipoXmodelo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_EquipoXmodelo As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control stm_Principal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents stm_Principal As Global.System.Web.UI.ScriptManager
    
    '''<summary>
    '''Control hdf_NombreArchivo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hdf_NombreArchivo As Global.System.Web.UI.WebControls.HiddenField
    
    '''<summary>
    '''Control hdf_Extension.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hdf_Extension As Global.System.Web.UI.WebControls.HiddenField
    
    '''<summary>
    '''Control Label10.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label10 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control sds_Vendedores.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_Vendedores As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control ddl_Vendedores.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Vendedores As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Label2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label2 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control sds_Familias.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_Familias As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control ddl_Familia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Familia As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Label4.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label4 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control ddl_Equipos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Equipos As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Label1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label1 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control ddl_SeleccionEquipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_SeleccionEquipo As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Label3.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label3 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control sds_Zonas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_Zonas As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control ddl_Zonas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Zonas As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lbl_CLienteBuscar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_CLienteBuscar As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control sds_ListadoClientes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_ListadoClientes As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control ddl_Clientes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Clientes As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Label5.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label5 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control txt_Contacto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_Contacto As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Label6.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label6 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control txt_Faena.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_Faena As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control Label7.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label7 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control ddl_TipoCotizacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_TipoCotizacion As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control Label8.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label8 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control ddl_Modalidad.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Modalidad As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lbl_Precio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Precio As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control txt_Precio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_Precio As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_cant_horas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_cant_horas As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control txt_CantHoras.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_CantHoras As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbl_ValorAlternativo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_ValorAlternativo As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control ddl_ValorAlternativo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_ValorAlternativo As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control sds_CondicionesArriendo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_CondicionesArriendo As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbx_CondicionesArriendo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbx_CondicionesArriendo As Global.System.Web.UI.WebControls.ListBox
    
    '''<summary>
    '''Control sds_Implementaciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_Implementaciones As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbx_Implementaciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbx_Implementaciones As Global.System.Web.UI.WebControls.ListBox
    
    '''<summary>
    '''Control btn_Limpiar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_Limpiar As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control btn_GenerarCotizacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_GenerarCotizacion As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btn_DescargarCotizacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_DescargarCotizacion As Global.System.Web.UI.WebControls.Button
End Class
