<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UploadPage.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.UploadPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="Scripts/jquery-3.1.1.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            alert("lala")
            $('#btnUploadFile').on('click', function () {

                var data = new FormData();

                var files = $("#fileUpload").get(0).files;

                // Add the uploaded image content to the form data collection
                if (files.length > 0) {
                    data.append("UploadedImage", files[0]);
                }

                // Make Ajax request with the contentType = false, and procesDate = false
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "Default.aspx",
                    contentType: false,
                    processData: false,
                    data: data
                });

                ajaxRequest.done(function (xhr, textStatus) {
                    // Do other operation
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="fileUpload">
                Select File to Upload:
                <input id="fileUpload" type="file" />

                <input id="btnUploadFile" type="button" value="Upload File" />
        </div>
    </form>
</body>
</html>
