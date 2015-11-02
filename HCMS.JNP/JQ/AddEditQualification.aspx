<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="AddEditQualification.aspx.cs" Inherits="HCMS.JNP.JQ.AddEditQualification" %>
<%@ Register src="~/Controls/JQ/ctrlAddEditQualification.ascx" tagname="ctrlAddEditQualification" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlAddEditQualification ID="jqAddEditQual" runat="server" />
</asp:Content>

