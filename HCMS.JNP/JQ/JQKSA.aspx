<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="JQKSA.aspx.cs" Inherits="HCMS.JNP.JQ.JQKSA" %>
<%@ Register src="~/Controls/JQ/ctrlJQKSA.ascx" tagname="ctrlJQKSA" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlJQKSA ID="jqFactorKSA" runat="server" />
</asp:Content>
