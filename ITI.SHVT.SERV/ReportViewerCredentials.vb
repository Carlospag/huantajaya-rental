Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Security.Principal
Imports System.Net
Imports Microsoft.Reporting.WebForms

Partial Public Class ReportViewerCredentials : Implements IReportServerCredentials
    Private vps_Usuario As String
    Private vps_Contrasena As String
    Private vps_Dominio As String

    Public Sub New(Optional ByVal pvs_Usuario As String = vgs_UsuarioServidorInformes, Optional ByVal pvs_Contrasena As String = vgs_ContrasenaUsuarioServidorInformes, Optional ByVal pvs_Dominio As String = vgs_DominioUsuarioURLServidorInformes)
        Me.vps_Usuario = pvs_Usuario
        Me.vps_Contrasena = pvs_Contrasena
        Me.vps_Dominio = pvs_Dominio
    End Sub
    Public Function GetFormsCredentials(ByRef pvo_AuthCookie As System.Net.Cookie, ByRef pvs_Usuario As String, ByRef pvs_Contrasena As String, ByRef pvs_Dominio As String) As Boolean Implements IReportServerCredentials.GetFormsCredentials
        pvo_AuthCookie = Nothing
        pvs_Usuario = Me.vps_Usuario
        pvs_Contrasena = Me.vps_Contrasena
        pvs_Dominio = Me.vps_Dominio
        Return False
    End Function
    Public ReadOnly Property ImpersonationUser() As WindowsIdentity Implements IReportServerCredentials.ImpersonationUser
        Get
            Return WindowsIdentity.GetCurrent()
        End Get
    End Property
    Public ReadOnly Property NetworkCredentials() As ICredentials Implements IReportServerCredentials.NetworkCredentials
        Get
            Return New NetworkCredential(Me.vps_Usuario, Me.vps_Contrasena, Me.vps_Dominio)
        End Get
    End Property

End Class