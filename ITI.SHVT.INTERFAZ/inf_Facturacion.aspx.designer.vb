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


Partial Public Class inf_Facturacion
    
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
    '''Control Label2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label2 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control ddl_TipoInforme.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_TipoInforme As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control pnl_Clientes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_Clientes As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
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
    '''Control pnl_Tipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_Tipo As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control Label1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label1 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control ddl_Tipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Tipo As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control pnl_Mes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_Mes As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control lbl_Anho.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Anho As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control ddl_periodo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_periodo As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control pnl_Anho.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_Anho As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control Label3.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label3 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control DDL_ANHO.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents DDL_ANHO As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control pnl_Sucursal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_Sucursal As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control Label4.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label4 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control sds_Sucursales.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_Sucursales As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control ddl_Sucursal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Sucursal As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control pnl_FInicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_FInicio As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control txt_FechaInicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_FechaInicio As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control pnl_FFin.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_FFin As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control txt_FechaTermino.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_FechaTermino As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control pnl_SucursalAgrupada.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_SucursalAgrupada As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control Label5.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label5 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control sds_SucursalesAgrupadas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_SucursalesAgrupadas As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control ddl_SucursalAgrupada.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_SucursalAgrupada As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control btn_VistaPreviaAgrupada.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_VistaPreviaAgrupada As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control btn_VistaPreviaGeneral.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_VistaPreviaGeneral As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control btn_GenerarInformeGeneral.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_GenerarInformeGeneral As Global.System.Web.UI.WebControls.LinkButton
    
    '''<summary>
    '''Control lbl_Proyeccion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Proyeccion As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control sds_FacturacionGeneralTotales.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_FacturacionGeneralTotales As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control pnl_Visualización.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_Visualización As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control upp_Novedades.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upp_Novedades As Global.System.Web.UI.UpdatePanel
    
    '''<summary>
    '''Control sds_FacturacionGeneral.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_FacturacionGeneral As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control sds_FacturacionAgrupada.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_FacturacionAgrupada As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control gdv_FacturacionAgrupada.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gdv_FacturacionAgrupada As Global.System.Web.UI.WebControls.GridView
    
    '''<summary>
    '''Control gdv_FacturacionGeneral.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gdv_FacturacionGeneral As Global.System.Web.UI.WebControls.GridView
End Class
