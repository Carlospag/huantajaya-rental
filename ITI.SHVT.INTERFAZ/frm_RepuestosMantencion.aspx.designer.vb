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


Partial Public Class frm_RepuestosMantencion
    
    '''<summary>
    '''Control stm_Principal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents stm_Principal As Global.System.Web.UI.ScriptManager
    
    '''<summary>
    '''Control upp_Notificacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upp_Notificacion As Global.System.Web.UI.UpdatePanel
    
    '''<summary>
    '''Control pnl_Notificacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnl_Notificacion As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control lbl_Notificacion1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Notificacion1 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control lbl_Notificacion2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_Notificacion2 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control sds_EquiposXFamilia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_EquiposXFamilia As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control sds_RepuestosDisponibles.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_RepuestosDisponibles As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control upp_Novedades.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upp_Novedades As Global.System.Web.UI.UpdatePanel
    
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
    '''Control Label3.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Label3 As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control lbl_ErrorAfi.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbl_ErrorAfi As Global.System.Web.UI.HtmlControls.HtmlGenericControl
    
    '''<summary>
    '''Control txt_BuscarAfi.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txt_BuscarAfi As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control lbx_RepuestosDisponibles.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbx_RepuestosDisponibles As Global.System.Web.UI.WebControls.ListBox
    
    '''<summary>
    '''Control btn_AgregarColaborador.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_AgregarColaborador As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btn_QuitarColaborador.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_QuitarColaborador As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control sds_RepuestosXequipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_RepuestosXequipo As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbx_RepuestosXequipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbx_RepuestosXequipo As Global.System.Web.UI.WebControls.ListBox
End Class
