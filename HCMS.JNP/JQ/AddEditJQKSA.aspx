<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="AddEditJQKSA.aspx.cs" Inherits="HCMS.JNP.JQ.AddEditJQKSA" %>
<%@ Register src="~/Controls/JQ/ctrlAddEditKSA.ascx" tagname="ctrlAddEditKSA" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlAddEditKSA ID="jqAddEditKSA" runat="server" />
</asp:Content>

