<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="JNPTracker.aspx.cs" Inherits="HCMS.JNP.Package.JNPTracker" %>
<%@ Register src="~/Controls/Package/ctrlJNPTracker.ascx" TagPrefix="JNP" TagName="ctrlJNPTracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">

    <JNP:ctrlJNPTracker ID="ctrlJNPTracker1" runat="server" />
</asp:Content>
