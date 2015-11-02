<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SSASRoles.aspx.cs" Inherits="HCMS.Portal.Admin.SSASRoles" %>
<%@ Register src="../Controls/Admin/ctrlSSASRoles.ascx" tagname="ctrlSSASRoles" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <uc1:ctrlSSASRoles ID="ctrlSSASRoles1" runat="server" />

</asp:Content>
