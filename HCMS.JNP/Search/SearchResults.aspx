<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="HCMS.JNP.Search.SearchResults" %>
<%@ Register Src="~/Controls/Search/SearchReports.ascx" TagName="SearchReports" TagPrefix="Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
  <%--<div class="sectionTitle">Search</div>
    <br />--%>
    <Search:SearchReports ID="ctrlSearchReports" runat="server" />
</asp:Content>
