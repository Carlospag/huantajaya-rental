<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frm_reportes.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" ID="textoError"></asp:Label>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="500" SizeToReportContent="true">
        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="sds_DatosEP" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
            SelectCommand="up_parque_s_DatosEP" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="id_EstadoPago" Type="Int64"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="sds_CotiXID" runat="server" ConnectionString="<%$ ConnectionStrings:SHVTBDConnectionString %>"
            SelectCommand="up_parque_s_CotiXID" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter Name="id_Cotizacion" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>

        <%--<br />
    Format:
    <asp:RadioButtonList ID="rbFormat" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Text="Word" Value="WORD" Selected="True" />
        <asp:ListItem Text="Excel" Value="EXCEL" />
        <asp:ListItem Text="PDF" Value="PDF" />
        <asp:ListItem Text="Image" Value="IMAGE" />
    </asp:RadioButtonList>
    <br />
    <asp:Button ID="btnExport" Text="Export" runat="server" OnClick="Export" />--%>
    </form>
</body>
</html>
