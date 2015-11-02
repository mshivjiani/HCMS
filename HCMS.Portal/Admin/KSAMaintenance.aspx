<%@ Page Title="KSA Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KSAMaintenance.aspx.cs" Inherits="HCMS.Portal.Admin.KSAMaintenance" %>
<%@ Register Src="~/Controls/Admin/KSAMaintenance.ascx" TagPrefix="hcms" TagName="KSAMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <hcms:KSAMaintenance ID="KSAMaintenance1" runat="server" />
</asp:Content>
