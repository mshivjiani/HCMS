<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="HCMS.JNP.Approval.Approval" %>
<%@ Register src="../Controls/Approval/ctrlJNPApproval.ascx" tagname="ctrlJNPApproval" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlJNPApproval ID="jnpApproval" runat="server" />
</asp:Content>

