<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="CopyJNPFromExisting.aspx.cs" Inherits="HCMS.JNP.Package.CopyJNPFromExisting" %>
<%@ Register src="../Controls/Package/ctrlCopyJNP.ascx" tagname="ctrlCopyJNP" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
  <uc1:ctrlCopyJNP ID="ctrlCopyJNP1" runat="server" />
</asp:Content>
