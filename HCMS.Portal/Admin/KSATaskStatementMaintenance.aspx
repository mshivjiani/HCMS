<%@ Page Title="Series Grade KSA Task Statement Administration" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="KSATaskStatementMaintenance.aspx.cs" Inherits="HCMS.Portal.Admin.KSATaskStatementMaintenance" %>
<%@ Register Src="~/Controls/Admin/KSATaskStatementMaintenance.ascx" TagPrefix="hcms" TagName="KSATaskStatementMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <hcms:KSATaskStatementMaintenance ID="KSATaskStatementMaintenance1" runat="server" />
</asp:Content>
