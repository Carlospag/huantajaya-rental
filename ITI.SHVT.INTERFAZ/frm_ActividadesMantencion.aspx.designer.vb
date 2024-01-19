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


Partial Public Class frm_ActividadesMantencion
    
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
    '''Control upp_Novedades.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upp_Novedades As Global.System.Web.UI.UpdatePanel
    
    '''<summary>
    '''Control sds_Familias.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_Familias As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control ddl_Familias.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddl_Familias As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control sds_ActividadesDisponibles.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_ActividadesDisponibles As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbx_ActividadesDisponibles.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbx_ActividadesDisponibles As Global.System.Web.UI.WebControls.ListBox
    
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
    '''Control sds_ActividadesXFamilia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_ActividadesXFamilia As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbx_ActividadesXfamilia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbx_ActividadesXfamilia As Global.System.Web.UI.WebControls.ListBox
    
    '''<summary>
    '''Control UpdatePanel1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents UpdatePanel1 As Global.System.Web.UI.UpdatePanel
    
    '''<summary>
    '''Control sds_LubricantesDisponibles.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_LubricantesDisponibles As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbx_LubricantesDisponibles.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbx_LubricantesDisponibles As Global.System.Web.UI.WebControls.ListBox
    
    '''<summary>
    '''Control btn_AgregarLubricante.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_AgregarLubricante As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btn_QuitarLubricante.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btn_QuitarLubricante As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control sds_LubricantesXfamilia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents sds_LubricantesXfamilia As Global.System.Web.UI.WebControls.SqlDataSource
    
    '''<summary>
    '''Control lbx_LubricantesXfamilia.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbx_LubricantesXfamilia As Global.System.Web.UI.WebControls.ListBox
End Class
