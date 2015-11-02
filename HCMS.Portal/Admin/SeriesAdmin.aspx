<%@ Page Title="Series Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeriesAdmin.aspx.cs" Inherits="HCMS.Portal.Admin.SeriesAdmin" %>
<%@ Register src="../Controls/Admin/ctrlSeriesOPMTitleAdmin.ascx" tagname="ctrlSeriesOPMTitleAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <uc1:ctrlSeriesOPMTitleAdmin ID="ctrlSeriesOPMTitleAdmin1" runat="server" />

</asp:Content>
