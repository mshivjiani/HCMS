
<%@ Page Title="JNP Published Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JNPPublishedReport.aspx.cs" Inherits="HCMS.Portal.Admin.JNPPublishedReport" %>
<%@ Register Src="~/Controls/Admin/ctrJNPPublishedReport.ascx" TagPrefix="hcms" TagName="JNPPublishedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <hcms:JNPPublishedReport ID="JNPPublishedReport1" runat="server" />
</asp:Content>
