<%@ Page Title="Search/Reports" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="True" CodeBehind="SearchReports.aspx.cs" Inherits="HCMS.PDExpress.Search.SearchReports" %>
<%@ Register Src="~/Controls/Search/SearchReports.ascx" TagName="SearchReports" TagPrefix="Search" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <Search:SearchReports ID="ctrlSearchReports" runat="server" />
</asp:Content>
