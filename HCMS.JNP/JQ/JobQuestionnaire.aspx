<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="JobQuestionnaire.aspx.cs" Inherits="HCMS.JNP.JQ.JobQuestionnaire" %>
<%@ Register src="~/Controls/JQ/ctrlJQInfo.ascx" tagname="ctrlJQInfo" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlJQInfo ID="jqInfo" runat="server" />
</asp:Content>
