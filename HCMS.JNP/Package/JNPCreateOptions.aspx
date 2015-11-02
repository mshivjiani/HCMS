<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="JNPCreateOptions.aspx.cs" Inherits="HCMS.JNP.Package.JNPCreateOptions" %>
<%@ Register src="~/Controls/Package/ctrlJNPChoice.ascx" tagname="ctrlJNPChoice" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
<%--    <div class="sectionTitle">Job Announcement Options</div>
    <br />--%>
    <uc1:ctrlJNPChoice ID="jnpChoice" runat="server" />
</asp:Content>
