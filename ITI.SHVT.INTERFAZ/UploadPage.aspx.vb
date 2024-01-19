Imports System.IO

Public Class UploadPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim httpPostedFile = HttpContext.Current.Request.Files("UploadedImage")
        If (Not (httpPostedFile) Is Nothing) Then
            Dim fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName)
            ' Save the uploaded file to "UploadedFiles" folder
            httpPostedFile.SaveAs(fileSavePath)
        End If
    End Sub

End Class