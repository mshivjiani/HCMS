<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="CategoryRating.aspx.cs" Inherits="HCMS.JNP.CR.CategoryRating" %>
<%@ Register src="~/Controls/CR/ctrlCategoryRating.ascx" TagPrefix="JNP" TagName="ctrlCategoryRating" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <JNP:ctrlCategoryRating ID="ctrlCategoryRating1" runat="server" />
</asp:Content>
