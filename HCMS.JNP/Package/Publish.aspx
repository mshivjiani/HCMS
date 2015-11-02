<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="Publish.aspx.cs" Inherits="HCMS.JNP.Package.Publish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<script language="javascript" type="text/javascript">
    window.onload = function () {
        window.setTimeout('window.location="<%=getDashboardPageURL()%>"; ', 1000);
    }
    </script>
</asp:Content>
