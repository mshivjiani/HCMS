<%@ Page Title="Create Job Announcement" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="false" CodeBehind="CreateJNP.aspx.cs" Inherits="HCMS.JNP.Package.CreateJNP" %>
<%@ Register src="~/Controls/Package/ctrlCreateJNP.ascx" tagname="controlJNP" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:controlJNP ID="JNPDetails" runat="server" />
</asp:Content>
