<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DelegateOrgChart.aspx.cs" Inherits="HCMS.Portal.Admin.DelegateOrgChart"  %>
<%@ Register src="../Controls/Admin/ctrlDelegateOrgChart.ascx" tagname="ctrlDelegateOrgChart" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<uc1:ctrlDelegateOrgChart ID="ctrlDelegateOrgChart1" runat="server" />
</asp:Content>
