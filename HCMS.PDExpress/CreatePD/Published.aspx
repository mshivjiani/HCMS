<%@ Page Title="Published" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="true" CodeBehind="Published.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.Published" %>




<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <script language="javascript" type="text/javascript">
        window.onload = function () {
            window.setTimeout('window.location="<%=getDashboardPageURL()%>"; ', 1000);
        }
    </script>
</asp:Content>