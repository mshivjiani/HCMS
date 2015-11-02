<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="true" CodeBehind="OrgChartTracker.aspx.cs" Inherits="HCMS.OrgChart.Tracker.OrgChartTracker" %>

<%@ Register Src="~/Controls/Tracker/ctrlOrgChartTracker.ascx" TagName="OrgChartTracker" TagPrefix="tracker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<tracker:OrgChartTracker ID="ctrlSearchReports" runat="server" />
</asp:Content>

