<%@ Page Title="Search/Reports" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="True" CodeBehind="SearchReportsAdvanced.aspx.cs" Inherits="HCMS.PDExpress.SearchReportsAdvanced" %>
<%@ Register Src="~/Controls/Search/SearchReportsAdvanced.ascx" TagName="SearchReportsAdvanced" TagPrefix="Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <Search:SearchReportsAdvanced ID="ctrlSearchReportsAdvanced" runat="server" />
</asp:Content>