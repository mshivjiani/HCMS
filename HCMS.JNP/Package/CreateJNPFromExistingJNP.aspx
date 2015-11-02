<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="false" CodeBehind="CreateJNPFromExistingJNP.aspx.cs" Inherits="HCMS.JNP.Package.CreateJNPFromExistingJNP" %>
<%@ Register src="~/Controls/Package/ctrlCreateJNP.ascx" tagname="controlJNP" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:controlJNP ID="JNPDetails" runat="server" />
</asp:Content>
