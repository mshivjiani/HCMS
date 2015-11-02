<%@ Page Title="TaskStatement Administration" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="TaskStatementMaintenance.aspx.cs" Inherits="HCMS.Portal.Admin.TaskStatementMaintenance" %>
<%@ Register Src="~/Controls/Admin/TaskStatementMaintenance.ascx" TagPrefix="hcms" TagName="TaskStatementMaintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <hcms:TaskStatementMaintenance ID="TaskStatementMaintenance1" runat="server" />
</asp:Content>
