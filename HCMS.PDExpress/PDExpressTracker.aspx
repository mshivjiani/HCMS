<%@ Page Title="" Language="C#" MasterPageFile="~/PDMaster.master" AutoEventWireup="true" CodeBehind="PDExpressTracker.aspx.cs" Inherits="HCMS.PDExpress.PDExpressTracker" %>

<%@ Register src="Controls/PDExpress/PDTracker.ascx" tagname="PDTracker" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <uc1:PDTracker ID="PDTracker1" runat="server" />
</asp:Content>
