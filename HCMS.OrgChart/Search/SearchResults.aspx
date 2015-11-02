<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/OrgChartMaster.Master"  CodeBehind="SearchResults.aspx.cs" Inherits="HCMS.OrgChart.Search.SearchResults" %>

<%@ Register Src="~/Controls/Search/ctrlOrgChartSearch.ascx" TagName="SearchReports" TagPrefix="Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <Search:SearchReports ID="ctrlSearchReports" runat="server" />
</asp:Content>