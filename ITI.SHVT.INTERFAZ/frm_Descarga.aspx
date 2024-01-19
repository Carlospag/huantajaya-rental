<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.Master" CodeBehind="frm_Descarga.aspx.vb" Inherits="ITI.SHVT.INTERFAZ.frm_Descarga" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="stm_Principal" runat="server"></asp:ScriptManager>
 <asp:Image ID="img_load" ImageUrl="~/Content/img/CARGANDO.gif" runat="server" />
    <style>
       
    body{
    /*background-color:yellow;*/  
    background-image:url('content/img/Cargando3.gif') ;
    background-position:center;
    background-size: 250px;
    background-repeat:no-repeat;
    } 
    </style>
    <rsweb:ReportViewer ID="rpu_Informe" ProcessingMode="Remote" Visible="false" runat="server"></rsweb:ReportViewer>
    
</asp:Content>