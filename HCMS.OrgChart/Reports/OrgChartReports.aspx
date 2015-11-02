<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="true" CodeBehind="OrgChartReports.aspx.cs" Inherits="HCMS.OrgChart.Reports.OrgChartReports" %>
<%@ Register src="../Controls/Reports/ctrlCustomReports.ascx" tagname="ctrlCustomReports" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlCustomReports ID="ctrlCustomReports1" runat="server" />
</asp:Content>
